namespace FileCompare
{
    using System.Linq;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        enum FileState
        {
            Same,
            New,
            Old,
            Only
        }
        private Dictionary<string, FileState> CompareFiles(string leftDir, string rightDir)
        {
            var result = new Dictionary<string, FileState>();

            var leftFiles = Directory.GetFiles(leftDir, "*", SearchOption.AllDirectories)
                .ToDictionary(f => Path.GetRelativePath(leftDir, f));

            var rightFiles = Directory.GetFiles(rightDir, "*", SearchOption.AllDirectories)
                .ToDictionary(f => Path.GetRelativePath(rightDir, f));

            var allNames = new HashSet<string>(leftFiles.Keys);
            allNames.UnionWith(rightFiles.Keys);

            foreach (var name in allNames)
            {
                bool inLeft = leftFiles.ContainsKey(name);
                bool inRight = rightFiles.ContainsKey(name);

                if (inLeft && inRight)
                {
                    DateTime leftTime = File.GetLastWriteTime(leftFiles[name]);
                    DateTime rightTime = File.GetLastWriteTime(rightFiles[name]);

                    if (leftTime == rightTime)
                        result[name] = FileState.Same;
                    else if (leftTime > rightTime)
                        result[name] = FileState.New;
                    else
                        result[name] = FileState.Old;
                }
                else
                {
                    result[name] = FileState.Only;
                }
            }

            return result;
        }

        private void ApplyColors(Dictionary<string, FileState> states)
        {
            foreach (ListViewItem item in lvwLeftDir.Items)
            {
                if (item.SubItems[1].Text == "<DIR>") continue;

                string name = item.Text;

                if (!states.ContainsKey(name)) continue;

                switch (states[name])
                {
                    case FileState.Same:
                        item.ForeColor = Color.Black;
                        break;

                    case FileState.New:
                        item.ForeColor = Color.Red;
                        break;

                    case FileState.Old:
                        item.ForeColor = Color.Gray;
                        break;

                    case FileState.Only:
                        item.ForeColor = Color.Purple;
                        break;
                }
            }

            // 오른쪽도 동일하게 처리
            foreach (ListViewItem item in lvwrightDir.Items)
            {
                if (item.SubItems[1].Text == "<DIR>") continue;

                string name = item.Text;

                if (!states.ContainsKey(name)) continue;

                switch (states[name])
                {
                    case FileState.Same:
                        item.ForeColor = Color.Black;
                        break;

                    case FileState.New:
                        item.ForeColor = Color.Gray;
                        break;

                    case FileState.Old:
                        item.ForeColor = Color.Red;
                        break;

                    case FileState.Only:
                        item.ForeColor = Color.Purple;
                        break;
                }
            }
        }

        private void btnLeftDir_Click(object sender, EventArgs e)
        {

            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";
                // 현재 텍스트박스에 있는 경로를 초기 선택 폴더로 설정
                if (!string.IsNullOrWhiteSpace(txtLeftDir.Text) &&
                Directory.Exists(txtLeftDir.Text))
                {
                    dlg.SelectedPath = txtLeftDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwLeftDir, dlg.SelectedPath);
                }
                if (Directory.Exists(txtLeftDir.Text) && Directory.Exists(txtRightDir.Text))
                {
                    var states = CompareFiles(txtLeftDir.Text, txtRightDir.Text);
                    ApplyColors(states);
                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를 선택하세요.";
                // 현재 텍스트박스에 있는 경로를 초기 선택 폴더로 설정
                if (!string.IsNullOrWhiteSpace(txtRightDir.Text) &&
                Directory.Exists(txtRightDir.Text))
                {
                    dlg.SelectedPath = txtRightDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwrightDir, dlg.SelectedPath);
                }
                if (Directory.Exists(txtLeftDir.Text) && Directory.Exists(txtRightDir.Text))
                {
                    var states = CompareFiles(txtLeftDir.Text, txtRightDir.Text);
                    ApplyColors(states);
                }
            }
        }
        private void PopulateListView(ListView lv, string rootPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            try
            {
                // 폴더
                var dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);
                foreach (var dir in dirs)
                {
                    string relative = Path.GetRelativePath(rootPath, dir);

                    var item = new ListViewItem(relative);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(Directory.GetLastWriteTime(dir).ToString("g"));
                    lv.Items.Add(item);
                }

                // 파일
                var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    string relative = Path.GetRelativePath(rootPath, file);

                    var item = new ListViewItem(relative);
                    item.SubItems.Add(new FileInfo(file).Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(File.GetLastWriteTime(file).ToString("g"));
                    lv.Items.Add(item);
                }
            }
            finally
            {
                lv.EndUpdate();
            }
        }


        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            CopyFile(lvwLeftDir, txtLeftDir.Text, txtRightDir.Text);
        }

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            CopyFile(lvwrightDir, txtRightDir.Text, txtLeftDir.Text);
        }
        private void CopyFile(ListView sourceList, string sourcePath, string destPath)
        {
            if (sourceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("파일을 선택하세요!");
                return;
            }

            var item = sourceList.SelectedItems[0];

            string relativePath = item.Text;

            string sourceFull = Path.Combine(sourcePath, relativePath);
            string destFull = Path.Combine(destPath, relativePath);

            try
            {
                if (Directory.Exists(sourceFull))
                {
                    CopyDirectory(sourceFull, destFull);
                }
                else
                {
                    // 폴더 생성 보장
                    Directory.CreateDirectory(Path.GetDirectoryName(destFull));

                    if (File.Exists(destFull))
                    {
                        DateTime srcTime = File.GetLastWriteTime(sourceFull);
                        DateTime destTime = File.GetLastWriteTime(destFull);

                        var result = MessageBox.Show(
                            "덮어쓰시겠습니까?",
                            "확인",
                            MessageBoxButtons.YesNo);

                        if (result != DialogResult.Yes)
                            return;
                    }

                    File.Copy(sourceFull, destFull, true);
                }

                MessageBox.Show("복사 완료!");

                PopulateListView(lvwLeftDir, txtLeftDir.Text);
                PopulateListView(lvwrightDir, txtRightDir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
            var states = CompareFiles(txtLeftDir.Text, txtRightDir.Text);
            ApplyColors(states);
        }
        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                string destSub = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSub);
            }
        }
    }
}
