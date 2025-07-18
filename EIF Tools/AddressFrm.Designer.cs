
namespace EIF_Tolls
{
    partial class AddressFrm
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
            this.BtnExe = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.InputGrid = new MetroFramework.Controls.MetroGrid();
            this.tabCtrl = new MetroFramework.Controls.MetroTabControl();
            this.BtnTextCopy = new MetroFramework.Controls.MetroButton();
            this.txtResult = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.txtTypeStr2 = new MetroFramework.Controls.MetroTextBox();
            this.txtType2 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.txtType3 = new MetroFramework.Controls.MetroTextBox();
            this.cbEmpty = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroButton1);
            this.metroPanel2.Controls.Add(this.BtnExe);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 60);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1170, 62);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // BtnExe
            // 
            this.BtnExe.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnExe.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.BtnExe.Location = new System.Drawing.Point(370, 12);
            this.BtnExe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExe.Name = "BtnExe";
            this.BtnExe.Size = new System.Drawing.Size(159, 46);
            this.BtnExe.TabIndex = 4;
            this.BtnExe.Text = "execute";
            this.BtnExe.UseSelectable = true;
            this.BtnExe.UseStyleColors = true;
            this.BtnExe.Click += new System.EventHandler(this.BtnExe_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tabCtrl);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(20, 122);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1170, 614);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 9;
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.Location = new System.Drawing.Point(14, 20);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(159, 26);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "사양서 선택";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroButton2);
            this.metroTabPage2.Controls.Add(this.txtTypeStr2);
            this.metroTabPage2.Controls.Add(this.txtType2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1162, 566);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Type 2";
            this.metroTabPage2.UseStyleColors = true;
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroTabPage1.Controls.Add(this.BtnTextCopy);
            this.metroTabPage1.Controls.Add(this.txtResult);
            this.metroTabPage1.Controls.Add(this.InputGrid);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1162, 566);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Type 1";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // InputGrid
            // 
            this.InputGrid.AllowUserToDeleteRows = false;
            this.InputGrid.AllowUserToOrderColumns = true;
            this.InputGrid.AllowUserToResizeColumns = false;
            this.InputGrid.AllowUserToResizeRows = false;
            this.InputGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.InputGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InputGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputGrid.CausesValidation = false;
            this.InputGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.InputGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.InputGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InputGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.InputGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputGrid.EnableHeadersVisualStyles = false;
            this.InputGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.InputGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InputGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputGrid.Location = new System.Drawing.Point(0, 0);
            this.InputGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputGrid.Name = "InputGrid";
            this.InputGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InputGrid.RowHeadersWidth = 51;
            this.InputGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InputGrid.RowTemplate.Height = 27;
            this.InputGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InputGrid.Size = new System.Drawing.Size(1160, 564);
            this.InputGrid.Style = MetroFramework.MetroColorStyle.Yellow;
            this.InputGrid.TabIndex = 2;
            this.InputGrid.UseStyleColors = true;
            this.InputGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputGrid_KeyDown);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.metroTabPage1);
            this.tabCtrl.Controls.Add(this.metroTabPage2);
            this.tabCtrl.Controls.Add(this.metroTabPage3);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 2;
            this.tabCtrl.Size = new System.Drawing.Size(1170, 614);
            this.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl.TabIndex = 2;
            this.tabCtrl.UseSelectable = true;
            this.tabCtrl.UseStyleColors = true;
            // 
            // BtnTextCopy
            // 
            this.BtnTextCopy.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnTextCopy.Location = new System.Drawing.Point(989, 412);
            this.BtnTextCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTextCopy.Name = "BtnTextCopy";
            this.BtnTextCopy.Size = new System.Drawing.Size(142, 30);
            this.BtnTextCopy.Style = MetroFramework.MetroColorStyle.Orange;
            this.BtnTextCopy.TabIndex = 5;
            this.BtnTextCopy.Text = "Variables Text Copy";
            this.BtnTextCopy.UseSelectable = true;
            this.BtnTextCopy.Visible = false;
            // 
            // txtResult
            // 
            // 
            // 
            // 
            this.txtResult.CustomButton.Image = null;
            this.txtResult.CustomButton.Location = new System.Drawing.Point(1039, 1);
            this.txtResult.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResult.CustomButton.Name = "";
            this.txtResult.CustomButton.Size = new System.Drawing.Size(75, 75);
            this.txtResult.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResult.CustomButton.TabIndex = 1;
            this.txtResult.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResult.CustomButton.UseSelectable = true;
            this.txtResult.CustomButton.Visible = false;
            this.txtResult.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtResult.Lines = new string[0];
            this.txtResult.Location = new System.Drawing.Point(28, 456);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResult.MaxLength = 32767;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.PasswordChar = '\0';
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResult.SelectedText = "";
            this.txtResult.SelectionLength = 0;
            this.txtResult.SelectionStart = 0;
            this.txtResult.ShortcutsEnabled = true;
            this.txtResult.Size = new System.Drawing.Size(1115, 77);
            this.txtResult.TabIndex = 4;
            this.txtResult.UseSelectable = true;
            this.txtResult.UseStyleColors = true;
            this.txtResult.Visible = false;
            this.txtResult.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtResult.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.cbEmpty);
            this.metroTabPage3.Controls.Add(this.metroButton3);
            this.metroTabPage3.Controls.Add(this.txtType3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1162, 566);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Type 3";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Location = new System.Drawing.Point(997, 92);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(142, 30);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroButton2.TabIndex = 7;
            this.metroButton2.Text = "Variables Text Copy";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtTypeStr2
            // 
            // 
            // 
            // 
            this.txtTypeStr2.CustomButton.Image = null;
            this.txtTypeStr2.CustomButton.Location = new System.Drawing.Point(1086, 1);
            this.txtTypeStr2.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTypeStr2.CustomButton.Name = "";
            this.txtTypeStr2.CustomButton.Size = new System.Drawing.Size(75, 75);
            this.txtTypeStr2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTypeStr2.CustomButton.TabIndex = 1;
            this.txtTypeStr2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTypeStr2.CustomButton.UseSelectable = true;
            this.txtTypeStr2.CustomButton.Visible = false;
            this.txtTypeStr2.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTypeStr2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTypeStr2.Lines = new string[0];
            this.txtTypeStr2.Location = new System.Drawing.Point(0, 0);
            this.txtTypeStr2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTypeStr2.MaxLength = 32767;
            this.txtTypeStr2.Multiline = true;
            this.txtTypeStr2.Name = "txtTypeStr2";
            this.txtTypeStr2.PasswordChar = '\0';
            this.txtTypeStr2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTypeStr2.SelectedText = "";
            this.txtTypeStr2.SelectionLength = 0;
            this.txtTypeStr2.SelectionStart = 0;
            this.txtTypeStr2.ShortcutsEnabled = true;
            this.txtTypeStr2.Size = new System.Drawing.Size(1162, 77);
            this.txtTypeStr2.TabIndex = 6;
            this.txtTypeStr2.UseSelectable = true;
            this.txtTypeStr2.UseStyleColors = true;
            this.txtTypeStr2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTypeStr2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtType2
            // 
            // 
            // 
            // 
            this.txtType2.CustomButton.Image = null;
            this.txtType2.CustomButton.Location = new System.Drawing.Point(598, 2);
            this.txtType2.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtType2.CustomButton.Name = "";
            this.txtType2.CustomButton.Size = new System.Drawing.Size(561, 561);
            this.txtType2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtType2.CustomButton.TabIndex = 1;
            this.txtType2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtType2.CustomButton.UseSelectable = true;
            this.txtType2.CustomButton.Visible = false;
            this.txtType2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtType2.Lines = new string[0];
            this.txtType2.Location = new System.Drawing.Point(0, 0);
            this.txtType2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtType2.MaxLength = 32767;
            this.txtType2.Multiline = true;
            this.txtType2.Name = "txtType2";
            this.txtType2.PasswordChar = '\0';
            this.txtType2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtType2.SelectedText = "";
            this.txtType2.SelectionLength = 0;
            this.txtType2.SelectionStart = 0;
            this.txtType2.ShortcutsEnabled = true;
            this.txtType2.Size = new System.Drawing.Size(1162, 566);
            this.txtType2.TabIndex = 8;
            this.txtType2.UseSelectable = true;
            this.txtType2.UseStyleColors = true;
            this.txtType2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtType2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton3.Location = new System.Drawing.Point(991, 25);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(142, 30);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroButton3.TabIndex = 10;
            this.metroButton3.Text = "Variables Text Copy";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // txtType3
            // 
            // 
            // 
            // 
            this.txtType3.CustomButton.Image = null;
            this.txtType3.CustomButton.Location = new System.Drawing.Point(598, 2);
            this.txtType3.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtType3.CustomButton.Name = "";
            this.txtType3.CustomButton.Size = new System.Drawing.Size(561, 561);
            this.txtType3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtType3.CustomButton.TabIndex = 1;
            this.txtType3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtType3.CustomButton.UseSelectable = true;
            this.txtType3.CustomButton.Visible = false;
            this.txtType3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType3.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtType3.Lines = new string[0];
            this.txtType3.Location = new System.Drawing.Point(0, 0);
            this.txtType3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtType3.MaxLength = 32767;
            this.txtType3.Multiline = true;
            this.txtType3.Name = "txtType3";
            this.txtType3.PasswordChar = '\0';
            this.txtType3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtType3.SelectedText = "";
            this.txtType3.SelectionLength = 0;
            this.txtType3.SelectionStart = 0;
            this.txtType3.ShortcutsEnabled = true;
            this.txtType3.Size = new System.Drawing.Size(1162, 566);
            this.txtType3.TabIndex = 11;
            this.txtType3.UseSelectable = true;
            this.txtType3.UseStyleColors = true;
            this.txtType3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtType3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbEmpty
            // 
            this.cbEmpty.AutoSize = true;
            this.cbEmpty.Location = new System.Drawing.Point(840, 32);
            this.cbEmpty.Name = "cbEmpty";
            this.cbEmpty.Size = new System.Drawing.Size(135, 15);
            this.cbEmpty.TabIndex = 13;
            this.cbEmpty.Text = "어드레스 Empty 여부";
            this.cbEmpty.UseSelectable = true;
            // 
            // AddressFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 756);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroPanel2);
            this.Name = "AddressFrm";
            this.Text = "Address";
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton BtnExe;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTabControl tabCtrl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton BtnTextCopy;
        private MetroFramework.Controls.MetroTextBox txtResult;
        private MetroFramework.Controls.MetroGrid InputGrid;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox txtTypeStr2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTextBox txtType2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroTextBox txtType3;
        private MetroFramework.Controls.MetroCheckBox cbEmpty;
    }
}

