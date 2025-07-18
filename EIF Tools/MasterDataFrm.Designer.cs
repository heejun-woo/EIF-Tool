
namespace EIF_Tolls
{
    partial class MasterDataFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lb_SelectFile = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.btnINSERT = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ckMode = new System.Windows.Forms.CheckBox();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.InputGrid = new MetroFramework.Controls.MetroGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_SelectFile
            // 
            this.lb_SelectFile.AutoSize = true;
            this.lb_SelectFile.Location = new System.Drawing.Point(202, 16);
            this.lb_SelectFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_SelectFile.Name = "lb_SelectFile";
            this.lb_SelectFile.Size = new System.Drawing.Size(0, 12);
            this.lb_SelectFile.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 6;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtWhere);
            this.panel1.Controls.Add(this.btnINSERT);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.ckMode);
            this.panel1.Controls.Add(this.cbTable);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lb_SelectFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 73);
            this.panel1.TabIndex = 8;
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(342, 14);
            this.txtWhere.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(539, 21);
            this.txtWhere.TabIndex = 12;
            // 
            // btnINSERT
            // 
            this.btnINSERT.Location = new System.Drawing.Point(1155, 10);
            this.btnINSERT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnINSERT.Name = "btnINSERT";
            this.btnINSERT.Size = new System.Drawing.Size(75, 27);
            this.btnINSERT.TabIndex = 11;
            this.btnINSERT.Text = "Insert";
            this.btnINSERT.UseVisualStyleBackColor = true;
            this.btnINSERT.Click += new System.EventHandler(this.btnINSERT_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1234, 10);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ckMode
            // 
            this.ckMode.AutoSize = true;
            this.ckMode.Location = new System.Drawing.Point(1010, 17);
            this.ckMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckMode.Name = "ckMode";
            this.ckMode.Size = new System.Drawing.Size(86, 16);
            this.ckMode.TabIndex = 10;
            this.ckMode.Text = "checkBox1";
            this.ckMode.UseVisualStyleBackColor = true;
            this.ckMode.CheckStateChanged += new System.EventHandler(this.ckMode_CheckStateChanged);
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Items.AddRange(new object[] {
            "TB_CLCTITEM_STND",
            "TB_COMMONCODE_STND",
            "TB_DEFECT_CODE_STND",
            "TB_EQP_POSITION_STND",
            "TB_RMS_TAG_INFO",
            "TB_EQP_UNIT_STND",
            "TB_RECIPEPARAMETER"});
            this.cbTable.Location = new System.Drawing.Point(109, 14);
            this.cbTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(223, 20);
            this.cbTable.TabIndex = 8;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(20, 60);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.InputGrid);
            this.splitContainer2.Size = new System.Drawing.Size(1195, 549);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 10;
            // 
            // InputGrid
            // 
            this.InputGrid.AllowUserToDeleteRows = false;
            this.InputGrid.AllowUserToOrderColumns = true;
            this.InputGrid.AllowUserToResizeColumns = false;
            this.InputGrid.AllowUserToResizeRows = false;
            this.InputGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.InputGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InputGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputGrid.CausesValidation = false;
            this.InputGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.InputGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.InputGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InputGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.InputGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputGrid.EnableHeadersVisualStyles = false;
            this.InputGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.InputGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InputGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputGrid.Location = new System.Drawing.Point(0, 0);
            this.InputGrid.Name = "InputGrid";
            this.InputGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InputGrid.RowHeadersWidth = 51;
            this.InputGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InputGrid.RowTemplate.Height = 27;
            this.InputGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InputGrid.Size = new System.Drawing.Size(1195, 473);
            this.InputGrid.Style = MetroFramework.MetroColorStyle.Green;
            this.InputGrid.TabIndex = 3;
            this.InputGrid.UseStyleColors = true;
            this.InputGrid.UseWaitCursor = true;
            this.InputGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputGrid_KeyDown);
            // 
            // MasterDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 629);
            this.Controls.Add(this.splitContainer2);
            this.Name = "MasterDataFrm";
            this.Text = "Master Table";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lb_SelectFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroGrid InputGrid;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.CheckBox ckMode;
        private System.Windows.Forms.Button btnINSERT;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtWhere;
    }
}

