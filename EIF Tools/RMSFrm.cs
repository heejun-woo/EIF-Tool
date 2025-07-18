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
    public partial class RMSFrm : MetroFramework.Forms.MetroForm
    {
        int iPlcType = -1;

        public RMSFrm(MetroStyleManager manager, int plcType)
        {
            InitializeComponent();

            iPlcType = plcType;

            #region 20240228 사양서 양식 변경 전
            //if (plcType == 1)
            //{
            //    InputGrid.Columns.Remove(InputGrid.Columns[7]);

            //    InputGrid.Columns.Add("RMS Parameter Write", "RMS Parameter Write");

            //    InputGrid.Columns.Remove(InputGrid.Columns[7]);
            //    InputGrid.Columns.Remove(InputGrid.Columns[7]);
            //}
            #endregion

            #region 20240228 사양서 양식 변경 후

            if (plcType == 1)
            {
                InputGrid.Columns.Clear();

                InputGrid.Columns.Add("Unit Name", "Unit Name");
                InputGrid.Columns.Add("Para.No", "Para.No");
                InputGrid.Columns.Add("Parameter Name (KOR)", "Parameter Name (KOR)");
                InputGrid.Columns.Add("Parameter Name (ENG)", "Parameter Name (ENG)");
                InputGrid.Columns.Add("Parameter Name (Local)", "Parameter Name (Local)");
                InputGrid.Columns.Add("Standard Parameter Name(ENG)", "Standard Parameter Name(ENG)");
                InputGrid.Columns.Add("Unit", "Unit");
                InputGrid.Columns.Add("Data Type", "Data Type");
                InputGrid.Columns.Add("Decimal Place", "Decimal Place");
                InputGrid.Columns.Add("RMS Tag", "RMS Tag");
                InputGrid.Columns.Add("OPC UA Tag Name", "OPC UA Tag Name");
                InputGrid.Columns.Add("OPC UA Tag Name", "OPC UA Tag Name");

            }
            #endregion

            this.components.SetStyle(this, manager);

            GridUtil.SetDoNotSort(InputGrid);
            GridUtil.SetDoNotSort(resultGrid);

            tabCtrl.SelectedIndex = 0;
            tabCtrl.TabPages[0].Show();

            InputGrid.Rows.Add(2000);
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

                for (int i = 0; i < InputGrid.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty((InputGrid.Rows[i].Cells[1].Value + "").ToString()))
                    {
                        TotalCnt = i++; break;
                    }

                    string str = "";

                    if (iPlcType == 0)
                    {
                        #region 기존 PLC

                        //string tag_name = textBox5.Text + (i + 1).ToString("000");
                        string tag_name = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[12].Value.ToString().Trim();     //addr string
                        int size = Convert.ToInt16(InputGrid.Rows[i].Cells[7].Value.ToString().Trim()); //data size

                        totalSize += size;


                        string strAddr = string.Empty;

                        if (addr.Contains("ZR"))
                        {
                            strAddr = "DEVICE_TYPE=" + addr.Substring(0, 2) + ",ADDRESS_NO=" + addr.Substring(2, addr.Length - 2);
                        }
                        else
                            strAddr = "DEVICE_TYPE=" + addr.Substring(0, 1) + ",ADDRESS_NO=" + addr.Substring(1, addr.Length - 1);


                        // 필요없을땐 주석처리
                        string FPOINT = InputGrid.Rows[i].Cells[10].Value.ToString().Trim();
                        strAddr += ",USEYN=Y" + (string.IsNullOrWhiteSpace(FPOINT) ? string.Empty : ",FPOINT=" + FPOINT);

                        switch (strType.ToUpper())
                        {
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "UINT32":
                            case "U4":
                                str += "__INTERNAL_VARIABLE_LONG(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",SIGN=0,LENGTH=2\", \"" + comment + "\");";
                                str += "\r\n";

                                break;
                            case "INT32":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "UINT16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;
                            case "INT16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_SIGNEDSHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;


                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + ",LENGTH=" + (size * 2).ToString() + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;


                            default:    ////6 정의안됨
                                str += "error;";
                                str += "\r\n";

                                break;

                        } 
                        #endregion
                    }
                    else if (iPlcType == 1)
                    {
                        #region 지멘스

                        #region 20240228 사양서 양식 변경 전
                        //string tag_name = InputGrid.Rows[i].Cells[8].Value.ToString().Trim();   //TAG Name
                        //string comment = InputGrid.Rows[i].Cells[2].Value.ToString().Trim();    //Comment          
                        //string strType = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //DataTyp

                        //string addr = InputGrid.Rows[i].Cells[9].Value.ToString().Trim();     //addr string
                        //string WriteAddr = InputGrid.Rows[i].Cells[10].Value.ToString().Trim();     //addr string 
                        #endregion

                        string tag_name = InputGrid.Rows[i].Cells[9].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[2].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[7].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[10].Value.ToString().Trim();     //addr string
                        string WriteAddr = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();     //addr string 
                        int size = 1;

                        totalSize += size;


                        string strAddr = $"ns=3, S=\\\"{addr.Replace(".", "\\\".\\\"")}\\\"";
                        string strWriteAddr = $"ns=3, S=\\\"{WriteAddr.Replace(".", "\\\".\\\"")}\\\"";

                        switch (strType.ToUpper())
                        {
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out, false, false, false, \"" + strWriteAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UINT32":
                            case "U4":
                                str += "__INTERNAL_VARIABLE_LONG(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                str += "__INTERNAL_VARIABLE_LONG(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out , 0, 0, false, false, 0, \"" + strWriteAddr + ",SIZE=32, SIGNED=0 \", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "INT32":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                str += "__INTERNAL_VARIABLE_INTEGER(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out , 0, 0, false, false, 0, \"" + strWriteAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UINT16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                str += "__INTERNAL_VARIABLE_SHORT(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out , 0, 0, false, false, 0, \"" + strWriteAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;
                            case "INT16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_SIGNEDSHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";
                                str += "\r\n";

                                str += "__INTERNAL_VARIABLE_SIGNEDSHORT(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out , 0, 0, false, false, 0, \"" + strWriteAddr + ",LENGTH=1" + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "STRING":   //string
                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                str += "__INTERNAL_VARIABLE_STRING(\"RV" + tag_name.Substring(2, tag_name.Length - 2) + "\", \"" + "RV_" + txtCategoryName.Text + "\", enumAccessType.Out,  false, false, string.Empty, \"" + strWriteAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;


                            default:    ////6 정의안됨
                                str += "error;";
                                str += "\r\n";

                                break;

                        }
                        #endregion
                    }


                    cnt++;



                    txtResult.AppendText(str);
                }


                tabCtrl.SelectedIndex = 1;
                tabCtrl.TabPages[1].Show();

                RvPara(TotalCnt, totalSize);
                SQLRMS();
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

                string tag_name, comment, dcpn;

                tag_name = string.Empty;
                dcpn = string.Empty;
                comment = string.Empty;

                if (iPlcType == 0)
                {
                    comment = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();    //Comment   
                    tag_name = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();   //TAG Name    
                     dcpn = InputGrid.Rows[i].Cells[10].Value.ToString().Trim();
                }
                else if (iPlcType == 1)
                {
                    comment = InputGrid.Rows[i].Cells[2].Value.ToString().Trim();    //Comment   
                    tag_name = InputGrid.Rows[i].Cells[9].Value.ToString().Trim();
                    dcpn = InputGrid.Rows[i].Cells[8].Value.ToString().Trim();
                }

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(resultGrid);

                row.Cells[0].Value = txtEqptID.Text;
                row.Cells[1].Value = tag_name;
                row.Cells[2].Value = "RV" + tag_name.Substring(2, tag_name.Length - 2);
                row.Cells[3].Value = string.IsNullOrWhiteSpace(dcpn) ? "0" : dcpn;
                row.Cells[4].Value = "Y";
                row.Cells[5].Value = comment;


                resultGrid.Rows.Add(row);

            }
        }

        private void BtnTextCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtResult.Text);
        }
    }
}
