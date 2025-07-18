
namespace EIF_Tolls
{
    partial class MainFrm
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
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnRMS = new MetroFramework.Controls.MetroButton();
            this.btnAPD = new MetroFramework.Controls.MetroButton();
            this.btnEdit = new MetroFramework.Controls.MetroButton();
            this.btnAdress = new MetroFramework.Controls.MetroButton();
            this.cbDBString = new MetroFramework.Controls.MetroComboBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.cbPLCType = new MetroFramework.Controls.MetroComboBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // btnRMS
            // 
            this.btnRMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRMS.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnRMS.Location = new System.Drawing.Point(32, 137);
            this.btnRMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRMS.Name = "btnRMS";
            this.btnRMS.Size = new System.Drawing.Size(210, 161);
            this.btnRMS.TabIndex = 0;
            this.btnRMS.Text = "RMS Para 생성";
            this.btnRMS.UseCustomBackColor = true;
            this.btnRMS.UseSelectable = true;
            this.btnRMS.UseStyleColors = true;
            this.btnRMS.Click += new System.EventHandler(this.btnRMS_Click);
            // 
            // btnAPD
            // 
            this.btnAPD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAPD.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAPD.Location = new System.Drawing.Point(271, 137);
            this.btnAPD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAPD.Name = "btnAPD";
            this.btnAPD.Size = new System.Drawing.Size(210, 161);
            this.btnAPD.TabIndex = 0;
            this.btnAPD.Text = "APD Para 생성";
            this.btnAPD.UseCustomBackColor = true;
            this.btnAPD.UseSelectable = true;
            this.btnAPD.UseStyleColors = true;
            this.btnAPD.Click += new System.EventHandler(this.btnAPD_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnEdit.Location = new System.Drawing.Point(32, 402);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(685, 138);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "MDB Edit Tool";
            this.btnEdit.UseCustomBackColor = true;
            this.btnEdit.UseSelectable = true;
            this.btnEdit.UseStyleColors = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdress
            // 
            this.btnAdress.BackColor = System.Drawing.Color.Khaki;
            this.btnAdress.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAdress.Location = new System.Drawing.Point(508, 137);
            this.btnAdress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdress.Name = "btnAdress";
            this.btnAdress.Size = new System.Drawing.Size(210, 161);
            this.btnAdress.TabIndex = 0;
            this.btnAdress.Text = "Adress 관련";
            this.btnAdress.UseCustomBackColor = true;
            this.btnAdress.UseSelectable = true;
            this.btnAdress.UseStyleColors = true;
            this.btnAdress.Click += new System.EventHandler(this.btnAdress_Click);
            // 
            // cbDBString
            // 
            this.cbDBString.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.cbDBString.FormattingEnabled = true;
            this.cbDBString.ItemHeight = 29;
            this.cbDBString.Location = new System.Drawing.Point(32, 335);
            this.cbDBString.Margin = new System.Windows.Forms.Padding(4);
            this.cbDBString.Name = "cbDBString";
            this.cbDBString.Size = new System.Drawing.Size(684, 35);
            this.cbDBString.Style = MetroFramework.MetroColorStyle.Green;
            this.cbDBString.TabIndex = 1;
            this.cbDBString.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbDBString.UseSelectable = true;
            this.cbDBString.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroButton1.Location = new System.Drawing.Point(32, 595);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(344, 138);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Log Script Tool";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.Lime;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroButton2.Location = new System.Drawing.Point(384, 595);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(344, 138);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Trace Log Tool";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton3.Location = new System.Drawing.Point(248, 46);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(210, 61);
            this.metroButton3.TabIndex = 4;
            this.metroButton3.Text = "미사용";
            this.metroButton3.UseCustomBackColor = true;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            this.metroButton3.Visible = false;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // cbPLCType
            // 
            this.cbPLCType.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.cbPLCType.FormattingEnabled = true;
            this.cbPLCType.ItemHeight = 29;
            this.cbPLCType.Items.AddRange(new object[] {
            "Mitsubishi",
            "Siemens"});
            this.cbPLCType.Location = new System.Drawing.Point(548, 46);
            this.cbPLCType.Margin = new System.Windows.Forms.Padding(4);
            this.cbPLCType.Name = "cbPLCType";
            this.cbPLCType.Size = new System.Drawing.Size(169, 35);
            this.cbPLCType.Style = MetroFramework.MetroColorStyle.Green;
            this.cbPLCType.TabIndex = 1;
            this.cbPLCType.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbPLCType.UseSelectable = true;
            this.cbPLCType.UseStyleColors = true;
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.Color.Yellow;
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroButton4.Location = new System.Drawing.Point(32, 752);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(344, 138);
            this.metroButton4.TabIndex = 5;
            this.metroButton4.Text = "Master Table Manager";
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.UseStyleColors = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.Color.Maroon;
            this.metroButton5.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroButton5.Location = new System.Drawing.Point(384, 752);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(344, 138);
            this.metroButton5.TabIndex = 6;
            this.metroButton5.Text = "EIF dll Manager";
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.UseStyleColors = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(758, 936);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cbPLCType);
            this.Controls.Add(this.cbDBString);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdress);
            this.Controls.Add(this.btnAPD);
            this.Controls.Add(this.btnRMS);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.Padding = new System.Windows.Forms.Padding(29, 90, 29, 30);
            this.Text = "EIF Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton btnRMS;
        private MetroFramework.Controls.MetroButton btnAPD;
        private MetroFramework.Controls.MetroButton btnEdit;
        private MetroFramework.Controls.MetroButton btnAdress;
        private MetroFramework.Controls.MetroComboBox cbDBString;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroComboBox cbPLCType;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
    }
}

