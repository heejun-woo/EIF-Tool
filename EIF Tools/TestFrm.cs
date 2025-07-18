using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace EIF_Tolls
{
    public partial class TestFrm : MetroFramework.Forms.MetroForm
    {
        public TestFrm(MetroStyleManager manager)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            InputGrid.Rows.Add(2000);
            OutGrid.Rows.Add(2000);

            GridUtil.SetDoNotSort(InputGrid);
            GridUtil.SetDoNotSort(resultGrid);

            tabCtrl.SelectedIndex = 0;
            tabCtrl.TabPages[0].Show();            

        }

        private void InputGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            break;
                        case Keys.V:
                            GridUtil.PasteClipboardValue(sender as DataGridView);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExe_Click(object sender, EventArgs e)
        {
            
            try
            {
                txtResult.Text = "";
                int cnt = 0;

                int TotalCnt = 0, totalSize = 0;

                Dictionary<string, string> dic = new Dictionary<string, string>();

                for (int i = 0; i < InputGrid.Rows.Count; i++)
                {
                    try
                    {
                        if (string.IsNullOrEmpty((InputGrid.Rows[i].Cells[1].Value + "").ToString())) break;
                        if (string.IsNullOrEmpty((InputGrid.Rows[i].Cells[0].Value + "").ToString())) break;

                        string Code = InputGrid.Rows[i].Cells[0].Value.ToString().Trim();
                        string Str = InputGrid.Rows[i].Cells[1].Value.ToString().Trim();

                        if (string.IsNullOrWhiteSpace(Code)) break;

                        dic.Add(Str, Code);
                    }
                    catch { }

                }



                for (int i = 0; i < OutGrid.Rows.Count; i++)
                {

                    if (string.IsNullOrEmpty((OutGrid.Rows[i].Cells[1].Value + "").ToString())) break;

                    string Str = OutGrid.Rows[i].Cells[1].Value.ToString().Trim();

                    if (string.IsNullOrWhiteSpace(Str)) break;

                    OutGrid.Rows[i].Cells[0].Value = dic[Str];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RvPara(int totalCnt, int totalSize)
        {
            string str = "RVParas Length : " + totalSize + "\r\n";
            str += "RVParasBoolList Length : " + Math.Ceiling(((double)totalSize / 16.0)) + "\r\n";

            str += "\r\n";

            str += "ParaUseYN Length : " + Math.Ceiling(((double)totalCnt / 16.0)) + "\r\n";
            str += "ParaDownYN Length : " + Math.Ceiling(((double)totalCnt / 16.0)) + "\r\n";
            str += "ParaValYN Length : " + Math.Ceiling(((double)totalCnt / 16.0)) + "\r\n";
            str += "ParaGrade Length : " + Math.Ceiling(((double)totalCnt * 2 / 16.0)) + "\r\n";

            str += "\r\n";

            str += "ParaUseYN_Log Length : " + totalCnt + "\r\n";
            str += "ParaDownYN_Log Length : " + totalCnt + "\r\n";
            str += "ParaValYN_Log Length : " + totalCnt + "\r\n";

            lbRMSPara.Text = str;
        }

        private void SQLRMS()
        {
            resultGrid.Rows.Clear();

            for (int i = 0; i < InputGrid.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty((InputGrid.Rows[i].Cells[1].Value + "").ToString()))
                {
                    break;
                }

                string tag_name = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();   //TAG Name
                string comment = InputGrid.Rows[i].Cells[2].Value.ToString().Trim();    //Comment          

                string dcpn = InputGrid.Rows[i].Cells[10].Value.ToString().Trim();

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(resultGrid);

                row.Cells[0].Value = txtEqptID.Text;
                row.Cells[1].Value = tag_name;
                row.Cells[2].Value = "RV" + tag_name.Substring(2, tag_name.Length - 2);
                row.Cells[3].Value = dcpn;
                row.Cells[4].Value = "Y";
                row.Cells[5].Value = comment;


                resultGrid.Rows.Add(row);

            }
        }

        private void BtnTextCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtResult.Text);
        }

        private void OutGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
