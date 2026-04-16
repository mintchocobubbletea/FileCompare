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

            // 오른쪽도 동일하게 처리 (방향 반대로!)
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
                        item.ForeColor = Color.Gray; // 오른쪽은 반대!
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
        private void PopulateListView(ListView lv, string folderPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            try
            { // 폴더(디렉터리) 먼저 추가
                var dirs = Directory.EnumerateDirectories(folderPath)
                .Select(p => new DirectoryInfo(p)).OrderBy(d => d.Name);
                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }

                // 파일 추가
                var files = Directory.EnumerateFiles(folderPath)
                .Select(p => new FileInfo(p))
                .OrderBy(f => f.Name);
                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }
                // 컬럼 너비 자동 조정 (컨텐츠 기준)
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    lv.AutoResizeColumn(i,
                    ColumnHeaderAutoResizeStyle.ColumnContent);
                }

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(this, "폴더를 찾을 수 없습니다.", "오류",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "입출력 오류: " + ex.Message, "오류",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string fileName = item.Text;
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(destPath, fileName);
            string sourceFull = Path.Combine(sourcePath, item.Text);
            string destFull = Path.Combine(destPath, item.Text);

            try
            {
                
                if (File.Exists(destFile))
                {
                    DateTime srcTime = File.GetLastWriteTime(sourceFile);
                    DateTime destTime = File.GetLastWriteTime(destFile);

                    
                    if (srcTime > destTime)
                    {
                        var result = MessageBox.Show(
                            "대상 파일보다 최신입니다. 덮어쓰시겠습니까?",
                            "확인",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result != DialogResult.Yes)
                            return;
                    }
                    else
                    {
                        var result = MessageBox.Show(
                            "대상 파일이 더 최신입니다. 그래도 덮어쓰시겠습니까?",
                            "경고",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result != DialogResult.Yes)
                            return;
                    }
                }
                if (Directory.Exists(sourceFull))
                {
                    CopyDirectory(sourceFull, destFull);
                }
                else
                {
                    File.Copy(sourceFull, destFull, true);
                }
                // 복사 실행
                File.Copy(sourceFile, destFile, true);

                MessageBox.Show("복사 완료!");

                // 리스트 새로고침
                PopulateListView(lvwLeftDir, txtLeftDir.Text);
                PopulateListView(lvwrightDir, txtRightDir.Text);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
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
