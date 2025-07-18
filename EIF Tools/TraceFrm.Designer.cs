
namespace EIF_Tolls
{
    partial class TraceFrm
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.dataGridView1 = new MetroFramework.Controls.MetroGrid();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnExe = new MetroFramework.Controls.MetroButton();
            this.btnConnStrEX = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.cbFileName = new MetroFramework.Controls.MetroComboBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.tgGroup = new MetroFramework.Controls.MetroToggle();
            this.cbText = new MetroFramework.Controls.MetroComboBox();
            this.btnColor = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.txtWord = new MetroFramework.Controls.MetroTextBox();
            this.btAllSearch = new MetroFramework.Controls.MetroButton();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dataGridView1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(23, 249);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1508, 671);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1508, 671);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.UseStyleColors = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // BtnExe
            // 
            this.BtnExe.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnExe.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.BtnExe.Location = new System.Drawing.Point(29, 21);
            this.BtnExe.Name = "BtnExe";
            this.BtnExe.Size = new System.Drawing.Size(182, 33);
            this.BtnExe.TabIndex = 5;
            this.BtnExe.Text = "Log 파일 선택";
            this.BtnExe.UseSelectable = true;
            this.BtnExe.UseStyleColors = true;
            this.BtnExe.Click += new System.EventHandler(this.BtnExe_Click);
            // 
            // btnConnStrEX
            // 
            this.btnConnStrEX.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnConnStrEX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConnStrEX.Location = new System.Drawing.Point(1005, 71);
            this.btnConnStrEX.Name = "btnConnStrEX";
            this.btnConnStrEX.Size = new System.Drawing.Size(109, 25);
            this.btnConnStrEX.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnConnStrEX.TabIndex = 15;
            this.btnConnStrEX.Text = "찾기";
            this.btnConnStrEX.UseCustomBackColor = true;
            this.btnConnStrEX.UseCustomForeColor = true;
            this.btnConnStrEX.UseSelectable = true;
            this.btnConnStrEX.Click += new System.EventHandler(this.btnConnStrEX_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btAllSearch);
            this.metroPanel1.Controls.Add(this.cbFileName);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.tgGroup);
            this.metroPanel1.Controls.Add(this.cbText);
            this.metroPanel1.Controls.Add(this.btnColor);
            this.metroPanel1.Controls.Add(this.btnClear);
            this.metroPanel1.Controls.Add(this.txtWord);
            this.metroPanel1.Controls.Add(this.btnConnStrEX);
            this.metroPanel1.Controls.Add(this.BtnExe);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 75);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1508, 174);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // cbFileName
            // 
            this.cbFileName.FormattingEnabled = true;
            this.cbFileName.ItemHeight = 24;
            this.cbFileName.Location = new System.Drawing.Point(224, 19);
            this.cbFileName.Name = "cbFileName";
            this.cbFileName.Size = new System.Drawing.Size(1120, 30);
            this.cbFileName.TabIndex = 20;
            this.cbFileName.UseSelectable = true;
            this.cbFileName.SelectedIndexChanged += new System.EventHandler(this.cbFileName_SelectedIndexChanged);
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.metroButton2.Location = new System.Drawing.Point(1235, 124);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(109, 25);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "항목 삭제";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.metroButton1.Location = new System.Drawing.Point(1118, 124);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(109, 25);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 21;
            this.metroButton1.Text = "항목 추가";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // tgGroup
            // 
            this.tgGroup.AutoSize = true;
            this.tgGroup.Location = new System.Drawing.Point(1014, 127);
            this.tgGroup.Name = "tgGroup";
            this.tgGroup.Size = new System.Drawing.Size(80, 19);
            this.tgGroup.TabIndex = 20;
            this.tgGroup.Text = "Off";
            this.tgGroup.UseSelectable = true;
            // 
            // cbText
            // 
            this.cbText.FormattingEnabled = true;
            this.cbText.ItemHeight = 24;
            this.cbText.Location = new System.Drawing.Point(224, 124);
            this.cbText.Name = "cbText";
            this.cbText.Size = new System.Drawing.Size(756, 30);
            this.cbText.TabIndex = 19;
            this.cbText.UseSelectable = true;
            // 
            // btnColor
            // 
            this.btnColor.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColor.Location = new System.Drawing.Point(1120, 71);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(109, 25);
            this.btnColor.TabIndex = 18;
            this.btnColor.Text = "색상 선택";
            this.btnColor.UseCustomBackColor = true;
            this.btnColor.UseCustomForeColor = true;
            this.btnColor.UseSelectable = true;
            this.btnColor.UseStyleColors = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnClear
            // 
            this.btnClear.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnClear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.Location = new System.Drawing.Point(1378, 71);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 25);
            this.btnClear.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseCustomBackColor = true;
            this.btnClear.UseCustomForeColor = true;
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtWord
            // 
            // 
            // 
            // 
            this.txtWord.CustomButton.Image = null;
            this.txtWord.CustomButton.Location = new System.Drawing.Point(712, 2);
            this.txtWord.CustomButton.Name = "";
            this.txtWord.CustomButton.Size = new System.Drawing.Size(41, 41);
            this.txtWord.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtWord.CustomButton.TabIndex = 1;
            this.txtWord.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtWord.CustomButton.UseSelectable = true;
            this.txtWord.CustomButton.Visible = false;
            this.txtWord.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtWord.Lines = new string[0];
            this.txtWord.Location = new System.Drawing.Point(224, 64);
            this.txtWord.MaxLength = 32767;
            this.txtWord.Multiline = true;
            this.txtWord.Name = "txtWord";
            this.txtWord.PasswordChar = '\0';
            this.txtWord.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWord.SelectedText = "";
            this.txtWord.SelectionLength = 0;
            this.txtWord.SelectionStart = 0;
            this.txtWord.ShortcutsEnabled = true;
            this.txtWord.Size = new System.Drawing.Size(756, 46);
            this.txtWord.TabIndex = 16;
            this.txtWord.UseSelectable = true;
            this.txtWord.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtWord.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btAllSearch
            // 
            this.btAllSearch.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btAllSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btAllSearch.Location = new System.Drawing.Point(1350, 24);
            this.btAllSearch.Name = "btAllSearch";
            this.btAllSearch.Size = new System.Drawing.Size(109, 25);
            this.btAllSearch.Style = MetroFramework.MetroColorStyle.Blue;
            this.btAllSearch.TabIndex = 23;
            this.btAllSearch.Text = "전체 찾기";
            this.btAllSearch.UseCustomBackColor = true;
            this.btAllSearch.UseCustomForeColor = true;
            this.btAllSearch.UseSelectable = true;
            this.btAllSearch.Click += new System.EventHandler(this.btAllSearch_Click);
            // 
            // TraceFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 945);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TraceFrm";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "Trace Log Analysis Tool";
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroGrid dataGridView1;
        private MetroFramework.Controls.MetroButton BtnExe;
        private MetroFramework.Controls.MetroButton btnConnStrEX;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtWord;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnColor;
        private MetroFramework.Controls.MetroComboBox cbText;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroToggle tgGroup;
        private MetroFramework.Controls.MetroComboBox cbFileName;
        private MetroFramework.Controls.MetroButton btAllSearch;
    }
}

