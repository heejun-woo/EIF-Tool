
namespace EIF_Tolls
{
    partial class RMSFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCtrl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.InputGrid = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.resultGrid = new MetroFramework.Controls.MetroGrid();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.txtEqptID = new MetroFramework.Controls.MetroTextBox();
            this.lbRMSPara = new MetroFramework.Controls.MetroLabel();
            this.BtnTextCopy = new MetroFramework.Controls.MetroButton();
            this.txtResult = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.BtnExe = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCategoryName = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tabCtrl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.metroPanel3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.metroTabPage1);
            this.tabCtrl.Controls.Add(this.metroTabPage2);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 1;
            this.tabCtrl.Size = new System.Drawing.Size(1337, 767);
            this.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl.TabIndex = 2;
            this.tabCtrl.UseSelectable = true;
            this.tabCtrl.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroTabPage1.Controls.Add(this.InputGrid);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 12;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1329, 719);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Input";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 11;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InputGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InputGrid.RowHeadersWidth = 51;
            this.InputGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InputGrid.RowTemplate.Height = 27;
            this.InputGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InputGrid.Size = new System.Drawing.Size(1327, 717);
            this.InputGrid.Style = MetroFramework.MetroColorStyle.Purple;
            this.InputGrid.TabIndex = 2;
            this.InputGrid.UseStyleColors = true;
            this.InputGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputGrid_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Unit Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 84;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Para No";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 71;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Parameter Name (ENG)";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 116;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Parameter Name (KOR)";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 116;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Parameter Description";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 138;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Unit";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 56;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Data Type";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 79;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Data Size";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 75;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Sign";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 57;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Format";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 72;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Decimal Place";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 99;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "EQP Parameter";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 104;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "PLC Start Address";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.Width = 116;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.resultGrid);
            this.metroTabPage2.Controls.Add(this.metroPanel3);
            this.metroTabPage2.Controls.Add(this.BtnTextCopy);
            this.metroTabPage2.Controls.Add(this.txtResult);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 12;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1329, 719);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Result";
            this.metroTabPage2.UseStyleColors = true;
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 11;
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToResizeRows = false;
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.resultGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resultGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.resultGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resultGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.EnableHeadersVisualStyles = false;
            this.resultGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.resultGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resultGrid.Location = new System.Drawing.Point(669, 367);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.resultGrid.RowHeadersWidth = 51;
            this.resultGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.resultGrid.RowTemplate.Height = 27;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(660, 352);
            this.resultGrid.TabIndex = 6;
            this.resultGrid.UseStyleColors = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "EQPTID";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.Width = 73;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "EV_TAGID";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.Width = 84;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "RV_TAGID";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.Width = 85;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "DCPN_NUM";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.Width = 99;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "USE_FLAG";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.Width = 87;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "NOTE";
            this.Column19.MinimumWidth = 6;
            this.Column19.Name = "Column19";
            this.Column19.Width = 63;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.txtEqptID);
            this.metroPanel3.Controls.Add(this.lbRMSPara);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(669, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(660, 367);
            this.metroPanel3.TabIndex = 5;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // txtEqptID
            // 
            // 
            // 
            // 
            this.txtEqptID.CustomButton.Image = null;
            this.txtEqptID.CustomButton.Location = new System.Drawing.Point(105, 2);
            this.txtEqptID.CustomButton.Name = "";
            this.txtEqptID.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.txtEqptID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEqptID.CustomButton.TabIndex = 1;
            this.txtEqptID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEqptID.CustomButton.UseSelectable = true;
            this.txtEqptID.CustomButton.Visible = false;
            this.txtEqptID.DisplayIcon = true;
            this.txtEqptID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtEqptID.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtEqptID.Lines = new string[] {
        "Eqpt ID"};
            this.txtEqptID.Location = new System.Drawing.Point(16, 311);
            this.txtEqptID.MaxLength = 32767;
            this.txtEqptID.Multiline = true;
            this.txtEqptID.Name = "txtEqptID";
            this.txtEqptID.PasswordChar = '\0';
            this.txtEqptID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEqptID.SelectedText = "";
            this.txtEqptID.SelectionLength = 0;
            this.txtEqptID.SelectionStart = 0;
            this.txtEqptID.ShortcutsEnabled = true;
            this.txtEqptID.Size = new System.Drawing.Size(153, 50);
            this.txtEqptID.TabIndex = 2;
            this.txtEqptID.Text = "Eqpt ID";
            this.txtEqptID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEqptID.UseSelectable = true;
            this.txtEqptID.UseStyleColors = true;
            this.txtEqptID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEqptID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbRMSPara
            // 
            this.lbRMSPara.Location = new System.Drawing.Point(29, 17);
            this.lbRMSPara.Name = "lbRMSPara";
            this.lbRMSPara.Size = new System.Drawing.Size(599, 335);
            this.lbRMSPara.TabIndex = 4;
            this.lbRMSPara.UseStyleColors = true;
            // 
            // BtnTextCopy
            // 
            this.BtnTextCopy.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnTextCopy.Location = new System.Drawing.Point(473, 31);
            this.BtnTextCopy.Name = "BtnTextCopy";
            this.BtnTextCopy.Size = new System.Drawing.Size(162, 38);
            this.BtnTextCopy.Style = MetroFramework.MetroColorStyle.Orange;
            this.BtnTextCopy.TabIndex = 3;
            this.BtnTextCopy.Text = "Variables Text Copy";
            this.BtnTextCopy.UseSelectable = true;
            this.BtnTextCopy.Click += new System.EventHandler(this.BtnTextCopy_Click);
            // 
            // txtResult
            // 
            // 
            // 
            // 
            this.txtResult.CustomButton.Image = null;
            this.txtResult.CustomButton.Location = new System.Drawing.Point(-49, 1);
            this.txtResult.CustomButton.Name = "";
            this.txtResult.CustomButton.Size = new System.Drawing.Size(717, 717);
            this.txtResult.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtResult.CustomButton.TabIndex = 1;
            this.txtResult.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtResult.CustomButton.UseSelectable = true;
            this.txtResult.CustomButton.Visible = false;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtResult.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtResult.Lines = new string[0];
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.MaxLength = 32767;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.PasswordChar = '\0';
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtResult.SelectedText = "";
            this.txtResult.SelectionLength = 0;
            this.txtResult.SelectionStart = 0;
            this.txtResult.ShortcutsEnabled = true;
            this.txtResult.Size = new System.Drawing.Size(669, 719);
            this.txtResult.TabIndex = 2;
            this.txtResult.UseSelectable = true;
            this.txtResult.UseStyleColors = true;
            this.txtResult.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtResult.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.BtnExe);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.txtCategoryName);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 12;
            this.metroPanel2.Location = new System.Drawing.Point(23, 75);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1337, 78);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 11;
            // 
            // BtnExe
            // 
            this.BtnExe.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnExe.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.BtnExe.Location = new System.Drawing.Point(423, 15);
            this.BtnExe.Name = "BtnExe";
            this.BtnExe.Size = new System.Drawing.Size(182, 57);
            this.BtnExe.TabIndex = 4;
            this.BtnExe.Text = "execute";
            this.BtnExe.UseSelectable = true;
            this.BtnExe.UseStyleColors = true;
            this.BtnExe.Click += new System.EventHandler(this.BtnExe_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(38, 33);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(91, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "카테고리명 :";
            this.metroLabel1.UseStyleColors = true;
            // 
            // txtCategoryName
            // 
            // 
            // 
            // 
            this.txtCategoryName.CustomButton.Image = null;
            this.txtCategoryName.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtCategoryName.CustomButton.Name = "";
            this.txtCategoryName.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtCategoryName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCategoryName.CustomButton.TabIndex = 1;
            this.txtCategoryName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCategoryName.CustomButton.UseSelectable = true;
            this.txtCategoryName.CustomButton.Visible = false;
            this.txtCategoryName.DisplayIcon = true;
            this.txtCategoryName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtCategoryName.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtCategoryName.Lines = new string[] {
        "EQPPARA"};
            this.txtCategoryName.Location = new System.Drawing.Point(162, 20);
            this.txtCategoryName.MaxLength = 32767;
            this.txtCategoryName.Multiline = true;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PasswordChar = '\0';
            this.txtCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCategoryName.SelectedText = "";
            this.txtCategoryName.SelectionLength = 0;
            this.txtCategoryName.SelectionStart = 0;
            this.txtCategoryName.ShortcutsEnabled = true;
            this.txtCategoryName.Size = new System.Drawing.Size(153, 45);
            this.txtCategoryName.TabIndex = 2;
            this.txtCategoryName.Text = "EQPPARA";
            this.txtCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCategoryName.UseSelectable = true;
            this.txtCategoryName.UseStyleColors = true;
            this.txtCategoryName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCategoryName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tabCtrl);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 153);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1337, 767);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // RMSFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 945);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RMSFrm";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "RMS ";
            this.tabCtrl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl tabCtrl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid InputGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private MetroFramework.Controls.MetroTextBox txtCategoryName;
        private MetroFramework.Controls.MetroButton BtnExe;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtResult;
        private MetroFramework.Controls.MetroButton BtnTextCopy;
        private MetroFramework.Controls.MetroLabel lbRMSPara;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroGrid resultGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private MetroFramework.Controls.MetroTextBox txtEqptID;
    }
}

