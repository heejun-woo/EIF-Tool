
namespace EIF_Tolls
{
    partial class FileMgrFrm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelect = new System.Windows.Forms.Button();
            this.lb_SelectFile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCommnet = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(157, 13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(107, 41);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lb_SelectFile
            // 
            this.lb_SelectFile.AutoSize = true;
            this.lb_SelectFile.Location = new System.Drawing.Point(288, 24);
            this.lb_SelectFile.Name = "lb_SelectFile";
            this.lb_SelectFile.Size = new System.Drawing.Size(0, 18);
            this.lb_SelectFile.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upload File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCommnet
            // 
            this.txtCommnet.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCommnet.Location = new System.Drawing.Point(0, 0);
            this.txtCommnet.Multiline = true;
            this.txtCommnet.Name = "txtCommnet";
            this.txtCommnet.Size = new System.Drawing.Size(680, 361);
            this.txtCommnet.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.NAME,
            this.VERSION,
            this.DATETIME,
            this.USE,
            this.SIZE,
            this.COMMENT});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 937);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 41);
            this.button3.TabIndex = 7;
            this.button3.Text = "Use";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.lb_SelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1884, 73);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1884, 937);
            this.splitContainer1.SplitterDistance = 1200;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(29, 90);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1884, 1014);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.TabIndex = 10;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.button4);
            this.splitContainer3.Panel1.Controls.Add(this.button3);
            this.splitContainer3.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.lbDateTime);
            this.splitContainer3.Panel2.Controls.Add(this.lbVersion);
            this.splitContainer3.Panel2.Controls.Add(this.txtCommnet);
            this.splitContainer3.Size = new System.Drawing.Size(680, 937);
            this.splitContainer3.SplitterDistance = 77;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(145, 389);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(0, 18);
            this.lbVersion.TabIndex = 5;
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.Location = new System.Drawing.Point(145, 437);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(0, 18);
            this.lbDateTime.TabIndex = 6;
            // 
            // NO
            // 
            this.NO.HeaderText = "NO";
            this.NO.MinimumWidth = 8;
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.Width = 69;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.MinimumWidth = 8;
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 94;
            // 
            // VERSION
            // 
            this.VERSION.HeaderText = "VERSION";
            this.VERSION.MinimumWidth = 8;
            this.VERSION.Name = "VERSION";
            this.VERSION.ReadOnly = true;
            this.VERSION.Visible = false;
            this.VERSION.Width = 116;
            // 
            // DATETIME
            // 
            this.DATETIME.HeaderText = "DATETIME";
            this.DATETIME.MinimumWidth = 8;
            this.DATETIME.Name = "DATETIME";
            this.DATETIME.ReadOnly = true;
            this.DATETIME.Width = 127;
            // 
            // USE
            // 
            this.USE.HeaderText = "USE";
            this.USE.MinimumWidth = 8;
            this.USE.Name = "USE";
            this.USE.ReadOnly = true;
            this.USE.Width = 77;
            // 
            // SIZE
            // 
            this.SIZE.HeaderText = "SIZE";
            this.SIZE.MinimumWidth = 8;
            this.SIZE.Name = "SIZE";
            this.SIZE.ReadOnly = true;
            this.SIZE.Visible = false;
            this.SIZE.Width = 80;
            // 
            // COMMENT
            // 
            this.COMMENT.HeaderText = "COMMENT";
            this.COMMENT.MinimumWidth = 8;
            this.COMMENT.Name = "COMMENT";
            this.COMMENT.ReadOnly = true;
            this.COMMENT.Visible = false;
            this.COMMENT.Width = 132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Create Time :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Version :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(148, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 41);
            this.button4.TabIndex = 8;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FileMgrFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1134);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileMgrFrm";
            this.Padding = new System.Windows.Forms.Padding(29, 90, 29, 30);
            this.Text = "EIF dll Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lb_SelectFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCommnet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMENT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
    }
}

