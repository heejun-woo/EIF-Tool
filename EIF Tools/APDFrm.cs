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
    public partial class APDFrm : MetroFramework.Forms.MetroForm
    {
        int iPlcType = -1;

        public APDFrm(MetroStyleManager manager, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            InputGrid.Rows.Add(20000);


            GridUtil.SetDoNotSort(InputGrid);
            GridUtil.SetDoNotSort(resultGrid);

            tabCtrl.SelectedIndex = 0;
            tabCtrl.TabPages[0].Show();

            iPlcType = plcType;

            if (plcType == 1)
            {
                InputGrid.Columns[6].HeaderText = "OPC UA Tag Name";
                InputGrid.Columns[7].HeaderText = "Data Type";
                InputGrid.Columns[8].HeaderText = "Array";
                InputGrid.Columns[9].HeaderText = "Sign";
                InputGrid.Columns[10].HeaderText = "Format";
                InputGrid.Columns[11].HeaderText = "Decimal Place";
                InputGrid.Columns[12].HeaderText = "Remark";

            }

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
                        string tag_name = InputGrid.Rows[i].Cells[2].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[4].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[7].Value.ToString().Trim();     //addr string

                        int size = 0;
                        if (!string.IsNullOrWhiteSpace(InputGrid.Rows[i].Cells[8].Value.ToString().Trim()))
                            size = Convert.ToInt16(InputGrid.Rows[i].Cells[8].Value.ToString().Trim()); //data size

                        int fp = 0;
                        int.TryParse(InputGrid.Rows[i].Cells[11].Value.ToString().Trim(), out fp);


                        totalSize += size;


                        string strAddr = string.Empty;

                        if (addr.Length > 0)
                        {
                            if (addr.Contains("ZR"))
                            {
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 2) + ",ADDRESS_NO=" + addr.Substring(2, addr.Length - 2);
                            }
                            else
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 1) + ",ADDRESS_NO=" + addr.Substring(1, addr.Length - 1);
                        }

                        if (fp > 0) strAddr += ",FPOINT=" + fp.ToString();

                        switch (strType)
                        {
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "U4":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;


                            case "ASCII":   //string 
                                str += "__INTERNAL_VARIABLE_STRING(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + ",LENGTH=" + (size * 2).ToString() + ",TRIM_SPACE=1,UPPERCASE=1" + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "T6":   //일자
                                str += "__INTERNAL_VARIABLE_SHORTLIST(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, 6, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
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
                        string tag_name = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[4].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[7].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //addr string


                        int fp = 0;
                        int.TryParse(InputGrid.Rows[i].Cells[11].Value.ToString().Trim(), out fp);


                        string strAddr = $"ns=3, S=\\\"{addr.Replace(".", "\\\".\\\"")}\\\"";

                        if (fp > 0)
                        {
                            strAddr += ",FPOINT=" + fp.ToString();
                        }

                        switch (strType)
                        {
                            case "Boolean":
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UInt32":
                            case "Int32":
                            case "U4":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UInt16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;
                            case "Int16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_INTEGER(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "String":   //string
                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"" + tag_name + "\", \"" + txtCategoryName.Text + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + "\", \"" + comment + "\");";
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

                SQLRMS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

                string comment = InputGrid.Rows[i].Cells[4].Value.ToString().Trim();    //Comment          

                string dcpn = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();
                string clctCode = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();


                if (iPlcType == 1)
                {
                    dcpn = InputGrid.Rows[i].Cells[11].Value.ToString().Trim();
                }

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(resultGrid);

                row.Cells[0].Value = txtEqptID.Text;
                row.Cells[1].Value = txtAPDName.Text;
                row.Cells[2].Value = i +1;
                row.Cells[3].Value = clctCode;
                row.Cells[4].Value = dcpn;
                row.Cells[5].Value = comment;


                resultGrid.Rows.Add(row);

            }
        }

        private void BtnTextCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtResult.Text);
        }

        private void APDFrm_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                metroTextBox1.Text = "";
                metroTextBox2.Text = "";

                int cnt = 0;

                int TotalCnt = 0, totalSize = 0;

                for (int i = 0; i < InputGrid.Rows.Count; i++)
                {
                    if ((InputGrid.Rows[i].Cells[1].Value + "").ToString().Trim().Length < 2)
                    {
                        continue;
                    }
                    string str = "";

                    if (iPlcType == 0)
                    {
                        #region 기존 PLC
                        string tag_name = $"IN_PARA_{cnt+1:D5}";
                        string comment = InputGrid.Rows[i].Cells[1].Value.ToString().Trim();    //Comment        

                        string addr = InputGrid.Rows[i].Cells[0].Value.ToString().Trim().ToUpper();

                        string strType;
                        if (addr.Contains('.')) strType = "B";
                        else strType = "INT16";

                        if (addr.Substring(0, 1).Equals("B") || addr.Substring(0, 2).Equals("SM")) strType = "B";

                        int size = 0; 
                        int fp = 0;

                        totalSize += size;

                        string strIdx = string.Empty;
                        if (addr.Split('.').Length > 1)
                        {
                            addr = addr.Split('.')[0];
                            strIdx = addr.Split('.')[1];
                        }

                        string strAddr = string.Empty;

                        if (addr.Length > 0)
                        {
                            if (addr.Contains("ZR") || addr.Contains("SD") || addr.Contains("SM") || addr.Contains("SW") || addr.Contains("SB"))
                            {
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 2) + ",ADDRESS_NO=" + addr.Substring(2, addr.Length - 2);
                            }
                            else
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 1) + ",ADDRESS_NO=" + addr.Substring(1, addr.Length - 1);
                        }
                        if (!string.IsNullOrWhiteSpace(strIdx)) strAddr += ",INDEX=" + strIdx.ToString();

                        if (fp > 0) strAddr += ",FPOINT=" + fp.ToString();

                        switch (strType)
                        {
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";

                                break;

                            case "U4":
                            case "UINT32":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;
                            case "I4":   //short
                            case "INT32":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;

                            case "U2":
                            case "UINT16":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;
                            case "I2":   //ushort
                            case "INT16":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";

                                break;


                            case "ASCII":   //string 
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + ",LENGTH=" + (size * 2).ToString() + ",TRIM_SPACE=1,UPPERCASE=1" + "\", \"" + comment + "\");";
                                break;

                            case "T6":   //일자
                                str += "__INTERNAL_VARIABLE_SHORTLIST(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 6, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;


                            default:    ////6 정의안됨
                                str += "error;";

                                break;

                        }
                        #endregion
                    }
                    else if (iPlcType == 1)
                    {
                        #region 지멘스
                        string tag_name = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[4].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[7].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //addr string


                        int fp = 0;
                        int.TryParse(InputGrid.Rows[i].Cells[11].Value.ToString().Trim(), out fp);


                        string strAddr = $"ns=3, S=\\\"{addr.Replace(".", "\\\".\\\"")}\\\"";

                        if (fp > 0)
                        {
                            strAddr += ",FPOINT=" + fp.ToString();
                        }

                        switch (strType)
                        {
                            case "Boolean":
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "UInt32":
                            case "U4":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "Int32":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "UInt16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "Int16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;

                            case "String":   //string
                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + "\", \"" + comment + "\");";

                                break;


                            default:    ////6 정의안됨
                                str += "error;";

                                break;

                        }
                        #endregion
                    }
                    cnt++;

                    str += "\r\n";
                    metroTextBox1.AppendText(str);


                    //str = str.Replace("__INTERNAL_VARIABLE_INTEGER(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    //str = str.Replace("__INTERNAL_VARIABLE_LONG(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    //str = str.Replace("__INTERNAL_VARIABLE_SHORT(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    //str = str.Replace("__INTERNAL_VARIABLE_BOOLEAN(\"I_B_", "__INTERNAL_VARIABLE_BOOLEAN(\"" + "O_B_");
                    //str = str.Replace("__INTERNAL_VARIABLE_STRING(\"I_W_", "__INTERNAL_VARIABLE_STRING(\"" + "O_W_");
                    //metroTextBox2.AppendText(str.Replace("EQPDATA", "OPCDATA").Replace("enumAccessType.In", "enumAccessType.Out"));
                }
                                   

                tabCtrl.SelectedIndex = 2;
                tabCtrl.TabPages[2].Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(metroTextBox1.Text);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(metroTextBox2.Text);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            List<bool> lst_B = new List<bool>();
            List<bool> lst_M = new List<bool>();
            List<bool> lst_D = new List<bool>();
            List<bool> lst_W = new List<bool>();
            List<bool> lst_R = new List<bool>();
            List<bool> lst_L = new List<bool>();
            List<bool> lst_ZR = new List<bool>();
            List<bool> lst_SD = new List<bool>();
            List<bool> lst_SM = new List<bool>();
            List<bool> lst_SB = new List<bool>();

            List<bool> lst_T = new List<bool>();
            List<bool> lst_X = new List<bool>();
            List<bool> lst_Y = new List<bool>();
            List<bool> lst_C = new List<bool>();
            List<bool> lst_SW = new List<bool>();

            for (int i = 0; i < 700000; i++)
            {
                lst_B.Add(false);
                lst_C.Add(false);
                lst_M.Add(false);
                lst_D.Add(false);
                lst_W.Add(false);
                lst_R.Add(false);
                lst_L.Add(false);
                lst_ZR.Add(false);
                lst_SD.Add(false);
                lst_SM.Add(false);
                lst_SW.Add(false);
                lst_SB.Add(false);
                lst_T.Add(false);
                lst_X.Add(false);
                lst_Y.Add(false);
            }


            for (int i = 0; i < InputGrid.Rows.Count; i++)
            {
                if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().Trim().Length < 2)
                {
                    continue;
                }

                if (InputGrid.Rows[i].Cells[1].Value == null) continue;
                if (InputGrid.Rows[i].Cells[0].Value == null) continue;

                if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("S")) continue;
                else if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("C")) continue;
                else if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("T")) continue;
                //int iPassCnt = 0;
                //if ((InputGrid.Rows[i].Cells[1].Value + "").ToString().Trim().Length < 2)
                //{
                //    iPassCnt++;

                //    if (iPassCnt > 4) continue;
                //}
                //else
                //{
                //    iPassCnt = 0;
                //}

                string addr = InputGrid.Rows[i].Cells[0].Value.ToString().Trim().ToUpper();
                string strAddr1 = string.Empty;

                if (addr.Length > 0)
                {
                    if (addr.Contains("ZR") || addr.Contains("SD") || addr.Contains("SM") || addr.Contains("SW") || addr.Contains("SB"))
                    {
                        strAddr1 = "DEVICE_TYPE=" + addr.Substring(0, 2) + ",ADDRESS_NO=" + addr.Substring(2, addr.Length - 2);
                    }
                    else
                        strAddr1 = "DEVICE_TYPE=" + addr.Substring(0, 1) + ",ADDRESS_NO=" + addr.Substring(1, addr.Length - 1);
                }

                string[] strAddr = strAddr1.Replace(" ", "").Split(',');
                string strType, strDevNo;
                int iLength = 1;
                int iDev;

                if (strAddr.Length >= 2)
                {

                    if (!strAddr[0].Contains("DEVICE_TYPE=")) continue;
                    if (!strAddr[1].Contains("ADDRESS_NO=")) continue;

                    strType = strAddr[0].Replace("DEVICE_TYPE=", "").Trim();
                    strDevNo = strAddr[1].Replace("ADDRESS_NO=", "").Trim();

                }
                else
                {
                    if (!strAddr[0].Contains("DEVICE_TYPE=")) continue;

                    strType = strAddr[0].Replace("DEVICE_TYPE=", "").Substring(0, 1);
                    strDevNo = strAddr[0].Replace("DEVICE_TYPE=", "").Substring(1, strAddr[0].Replace("DEVICE_TYPE=", "").Length - 1);
                }

                if (strAddr.Length > 2 && strAddr[2].Contains("LENGTH="))
                    iLength = Convert.ToInt32(strAddr[2].Replace("LENGTH=", "").Trim());

                try
                {
                    strDevNo = strDevNo.Split('.')[0];
                    if (strType.Equals("B") || strType.Equals("W") || strType.Equals("X") || strType.Equals("Y") || strType.Equals("SB"))
                        iDev = Convert.ToInt32(strDevNo, 16);
                    else
                        iDev = Convert.ToInt32(strDevNo);
                }
                catch { continue; }


                int a = 2;

                if (strType == "B")
                {
                    for (int x = 0; x < iLength * a; x++) lst_B[iDev + x] = true;
                }
                else if (strType == "C")
                {
                    for (int x = 0; x < iLength * a; x++) lst_C[iDev + x] = true;
                }
                else if (strType == "M")
                {
                    for (int x = 0; x < iLength * a; x++) lst_M[iDev + x] = true;
                }
                else if (strType == "D")
                {
                    for (int x = 0; x < iLength * a; x++) lst_D[iDev + x] = true;
                }
                else if (strType == "W")
                {
                    for (int x = 0; x < iLength * a; x++) lst_W[iDev + x] = true;
                }
                else if (strType == "R")
                {
                    for (int x = 0; x < iLength * a; x++) lst_R[iDev + x] = true;
                }
                else if (strType == "L")
                {
                    for (int x = 0; x < iLength * a; x++) lst_L[iDev + x] = true;
                }
                else if (strType == "ZR")
                {
                    for (int x = 0; x < iLength * a; x++) lst_ZR[iDev + x] = true;
                }
                else if (strType == "SD")
                {
                    for (int x = 0; x < iLength * a; x++) lst_SD[iDev + x] = true;
                }
                else if (strType == "SM")
                {
                    for (int x = 0; x < iLength * a; x++) lst_SM[iDev + x] = true;
                }
                else if (strType == "SW")
                {
                    for (int x = 0; x < iLength * a; x++) lst_SW[iDev + x] = true;
                }
                else if (strType == "SB")
                {
                    for (int x = 0; x < iLength * a; x++) lst_SB[iDev + x] = true;
                }
                else if (strType == "T")
                {
                    for (int x = 0; x < iLength * a; x++) lst_T[iDev + x] = true;
                }
                else if (strType == "X")
                {
                    for (int x = 0; x < iLength * a; x++) lst_X[iDev + x] = true;
                }
                else if (strType == "Y")
                {
                    for (int x = 0; x < iLength * a; x++) lst_Y[iDev + x] = true;
                }
            }

            textBox2.Text = "STATION_NO=xxx, MEMORY=";

            proc02("B", ref lst_B, textBox2);
            proc02("C", ref lst_C, textBox2);
            proc02("D", ref lst_D, textBox2);
            proc02("L", ref lst_L, textBox2);
            proc02("M", ref lst_M, textBox2);
            proc02("R", ref lst_R, textBox2);
            proc02("T", ref lst_T, textBox2);
            proc02("W", ref lst_W, textBox2);
            proc02("X", ref lst_X, textBox2);
            proc02("Y", ref lst_Y, textBox2);
            proc02("SB", ref lst_SB, textBox2);
            proc02("SD", ref lst_SD, textBox2);
            proc02("SM", ref lst_SM, textBox2);
            proc02("SW", ref lst_SW, textBox2);
            proc02("ZR", ref lst_ZR, textBox2);


            textBox2.AppendText(",RETRY_COUNT = 3 ,RETRY_LOG = 1");

            Clipboard.SetText(textBox2.Text);

        }

        private string proc02(string word, ref List<bool> lst, MetroFramework.Controls.MetroTextBox tBOX)
        {
            int chk_cnt = Convert.ToInt32(txtCnt.Text); //어드레스 빈공간 최대치 넘을 경우 영역 분리
            int cnt = 0;   //임시카운트
            int f_cnt = 0; //빈영역의 Count을 위한 변수
            int d_cnt = 0; //최종 영역의 Length 를 설정하기 위한 Count
            bool isVal = false; // 새로운 영역을 시작여부를 저장하기 위한 변수 
            string str = "";


            bool bFirst = true; // 처음 문자열에서 "&"을 쓰지 않기 위한 변수

            for (int i = 0; i < lst.Count; i++)
            {
                if ((isVal == false && lst[i])) // 새로운 영역 시작
                {
                    isVal = true;
                    if (word.Equals("B") || word.Equals("W") || word.Equals("X") || word.Equals("Y") || word.Equals("SB"))
                    {
                        if (word.Equals("B") && bFirst)
                        {
                            str += word + ":" + i.ToString("X");
                            bFirst = false;
                        }
                        else
                            str += "&" + word + ":" + i.ToString("X");
                    }
                    else str += "&" + word + ":" + i.ToString();

                    cnt = 1;
                    f_cnt = 0;
                    d_cnt = cnt;
                }
                else if (d_cnt > 1800 && lst[i] == false) // 영역의 Length가 400이 넘을 경우 빈공간이 발견되면 영역 분리, chk_cnt 감안하여 계속해서 연속되는 경우 512를 넘길수 있음 필요시 400 에서 줄여야함
                {
                    isVal = false;
                    str += ":" + d_cnt.ToString();
                    f_cnt = 0;
                    d_cnt = 0;
                }
                //else if (isVal && d_cnt > 0 && i % 512 == 511) // 512의 배수인 경우는 분리하여 length를 512를 넘지 않도록함 
                //{
                //    isVal = false;
                //    str += ":" + (d_cnt + 1).ToString();
                //    f_cnt = 0;
                //    d_cnt = 0;
                //}
                else if (isVal && lst[i]) //사용하는 공간이 연속해서 Count 되는 경우
                {
                    cnt++;
                    f_cnt = 0;
                    d_cnt = cnt;
                }
                else if (isVal && lst[i] == false) //빈공간 발견되면 f_cnt를 증가시켜 chk_cnt을 넘지 않는지 체크 넘으면 영역 분리
                {
                    cnt++;

                    if (f_cnt >= chk_cnt)
                    {
                        isVal = false;
                        str += ":" + d_cnt.ToString();
                    }
                    else
                    {
                        f_cnt++;
                    }
                }
            }


            tBOX.AppendText(str);

            return str;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                metroTextBox1.Text = "";
                metroTextBox2.Text = "";

                int cnt = 0;

                int TotalCnt = 0, totalSize = 0;

                int iPassCnt = 0;

                for (int i = 0; i < InputGrid.Rows.Count; i++)
                {

                    if (InputGrid.Rows[i].Cells[1].Value == null) continue;
                    if (InputGrid.Rows[i].Cells[0].Value == null) continue;

                    if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("S")) continue;
                    else if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("C")) continue;
                    else if ((InputGrid.Rows[i].Cells[0].Value + "").ToString().StartsWith("T")) continue;

                    //if ((InputGrid.Rows[i].Cells[1].Value + "").ToString().Trim().Length < 2)
                    //{
                    //    iPassCnt++;

                    //    if (iPassCnt > 4) continue;
                    //}
                    //else
                    //{
                    //    iPassCnt = 0;
                    //}

                    string str = "";

                    if (iPlcType == 0)
                    {
                        #region 기존 PLC
                        string tag_name = $"IN_PARA_{cnt + 1:D5}";
                        string comment = (InputGrid.Rows[i].Cells[1].Value + "").ToString().Trim();    //Comment        

                        string addr = InputGrid.Rows[i].Cells[0].Value.ToString().Trim().ToUpper();

                        string strType;
                        if (addr.Contains('.')) strType = "B";
                        else strType = "INT16";

                        if (addr.Substring(0, 1).Equals("B") || addr.Substring(0, 1).Equals("X") || addr.Substring(0, 1).Equals("Y") ||
                            addr.Substring(0, 1).Equals("M") || addr.Substring(0, 1).Equals("L") || addr.Substring(0, 1).Equals("F") || addr.Substring(0, 2).Equals("SM")) strType = "B";


                        int size = 0;
                        int fp = 0;

                        totalSize += size;

                        string strIdx = string.Empty;
                        if (addr.Split('.').Length > 1)
                        {
                            strIdx = addr.Split('.')[1];
                            addr = addr.Split('.')[0];
                        }

                        string strAddr = string.Empty;

                        if (addr.Length > 0)
                        {
                            if (addr.Contains("ZR") || addr.Contains("SD") || addr.Contains("SM") || addr.Contains("SW") || addr.Contains("SB"))
                            {
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 2) + ",ADDRESS_NO=" + addr.Substring(2, addr.Length - 2);
                            }
                            else
                                strAddr = "DEVICE_TYPE=" + addr.Substring(0, 1) + ",ADDRESS_NO=" + addr.Substring(1, addr.Length - 1);
                        }
                        if (!string.IsNullOrWhiteSpace(strIdx)) strAddr += ",INDEX=" + strIdx.ToString();

                        if (fp > 0) strAddr += ",FPOINT=" + fp.ToString();

                        switch (strType)
                        {
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";

                                break;

                            case "U4":
                            case "UINT32":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;
                            case "I4":   //short
                            case "INT32":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;

                            case "U2":
                            case "UINT16":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";

                                break;
                            case "I2":   //ushort
                            case "INT16":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";

                                break;


                            case "ASCII":   //string 
                                str += "__INTERNAL_VARIABLE_STRING(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + ",LENGTH=" + (size * 2).ToString() + ",TRIM_SPACE=1,UPPERCASE=1" + "\", \"" + comment + "\");";
                                break;

                            case "T6":   //일자
                                str += "__INTERNAL_VARIABLE_SHORTLIST(\"I_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 6, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;


                            default:    ////6 정의안됨
                                str += "error;";

                                break;

                        }
                        #endregion
                    }
                    else if (iPlcType == 1)
                    {
                        #region 지멘스
                        string tag_name = InputGrid.Rows[i].Cells[3].Value.ToString().Trim();   //TAG Name
                        string comment = InputGrid.Rows[i].Cells[4].Value.ToString().Trim();    //Comment          
                        string strType = InputGrid.Rows[i].Cells[7].Value.ToString().Trim();     //DataTyp

                        string addr = InputGrid.Rows[i].Cells[6].Value.ToString().Trim();     //addr string


                        int fp = 0;
                        int.TryParse(InputGrid.Rows[i].Cells[11].Value.ToString().Trim(), out fp);


                        string strAddr = $"ns=3, S=\\\"{addr.Replace(".", "\\\".\\\"")}\\\"";

                        if (fp > 0)
                        {
                            strAddr += ",FPOINT=" + fp.ToString();
                        }

                        switch (strType)
                        {
                            case "Boolean":
                            case "B":
                            case "BIT":
                            case "BOOLEAN":   //boolean
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "UInt32":
                            case "U4":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "Int32":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "UInt16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                break;

                            case "Int16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";        

                                break;

                            case "String":   //string
                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + "\", \"" + comment + "\");";

                                break;


                            default:    ////6 정의안됨
                                str += "error;";

                                break;

                        }
                        #endregion
                    }

                    str = "EIFAddVariable(" + str.Substring(0, str.Length - 2) + "));";
                    str += "\r\n";
                    cnt++;

                    metroTextBox1.AppendText(str);

                }


                tabCtrl.SelectedIndex = 2;
                tabCtrl.TabPages[2].Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
