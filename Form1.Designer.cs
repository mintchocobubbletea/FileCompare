namespace FileCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            panel2 = new Panel();
            btnLeftDir = new Button();
            txtLeftDir = new TextBox();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel6 = new Panel();
            lvwrightDir = new ListView();
            panel5 = new Panel();
            btnRightDir = new Button();
            txtRightDir = new TextBox();
            panel4 = new Panel();
            btnCopyFromRight = new Button();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new Size(873, 440);
            splitContainer1.SplitterDistance = 442;
            splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(lvwLeftDir);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 200);
            panel3.Name = "panel3";
            panel3.Size = new Size(442, 240);
            panel3.TabIndex = 1;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.BackColor = SystemColors.Window;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(3, 3);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(436, 234);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(btnLeftDir);
            panel2.Controls.Add(txtLeftDir);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(442, 100);
            panel2.TabIndex = 0;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLeftDir.Font = new Font("맑은 고딕", 10F);
            btnLeftDir.Location = new Point(341, 23);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(81, 38);
            btnLeftDir.TabIndex = 1;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLeftDir.Location = new Point(17, 30);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(318, 23);
            txtLeftDir.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(442, 100);
            panel1.TabIndex = 0;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyFromLeft.Font = new Font("맑은 고딕", 16F);
            btnCopyFromLeft.Location = new Point(341, 16);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(81, 38);
            btnCopyFromLeft.TabIndex = 1;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 30F);
            lblAppName.ForeColor = SystemColors.Highlight;
            lblAppName.Location = new Point(3, 16);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(262, 54);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ControlDark;
            panel6.Controls.Add(lvwrightDir);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 200);
            panel6.Name = "panel6";
            panel6.Size = new Size(427, 240);
            panel6.TabIndex = 2;
            // 
            // lvwrightDir
            // 
            lvwrightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwrightDir.BackColor = SystemColors.Window;
            lvwrightDir.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            lvwrightDir.FullRowSelect = true;
            lvwrightDir.GridLines = true;
            lvwrightDir.Location = new Point(3, 3);
            lvwrightDir.Name = "lvwrightDir";
            lvwrightDir.Size = new Size(421, 234);
            lvwrightDir.TabIndex = 0;
            lvwrightDir.UseCompatibleStateImageBehavior = false;
            lvwrightDir.View = View.Details;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaption;
            panel5.Controls.Add(btnRightDir);
            panel5.Controls.Add(txtRightDir);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 100);
            panel5.Name = "panel5";
            panel5.Size = new Size(427, 100);
            panel5.TabIndex = 1;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRightDir.Font = new Font("맑은 고딕", 10F);
            btnRightDir.Location = new Point(328, 29);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(81, 38);
            btnRightDir.TabIndex = 3;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Location = new Point(15, 38);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(307, 23);
            txtRightDir.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCopyFromRight);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(427, 100);
            panel4.TabIndex = 0;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Font = new Font("맑은 고딕", 16F);
            btnCopyFromRight.Location = new Point(15, 16);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(81, 38);
            btnCopyFromRight.TabIndex = 1;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "이름";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "크기";
            columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "수정일";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "이름";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "크기";
            columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "수정일";
            columnHeader6.Width = 100;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Padding = new Padding(5);
            Text = "File Compare v1.0";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private ListView lvwLeftDir;
        private Button btnLeftDir;
        private TextBox txtLeftDir;
        private Button btnCopyFromLeft;
        private Label lblAppName;
        private Panel panel6;
        private ListView lvwrightDir;
        private Panel panel5;
        private Button btnRightDir;
        private TextBox txtRightDir;
        private Panel panel4;
        private Button btnCopyFromRight;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
