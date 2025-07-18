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
    public partial class CoaterAPDFrm : MetroFramework.Forms.MetroForm
    {
        int iPlcType = -1;

        public CoaterAPDFrm(MetroStyleManager manager, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            InputGrid.Rows.Add(2000);


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
                        string strType = InputGrid.Rows[i].Cells[6].Value.ToString().Trim().ToUpper();     //DataTyp

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
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "U4":
                            case "UINT32":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;
                            case "I4":   //short
                            case "INT32":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "U2":
                            case "UINT16":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;
                            case "I2":   //ushort
                            case "INT16":

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + ",LENGTH=1" + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;


                            case "ASCII":   //string 
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + ",LENGTH=" + (size * 2).ToString() + ",TRIM_SPACE=1,UPPERCASE=1" + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "T6":   //일자
                                str += "__INTERNAL_VARIABLE_SHORTLIST(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 6, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
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
                                str += "__INTERNAL_VARIABLE_BOOLEAN(\"I_B_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, false, false, false, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UInt32":
                            case "U4":
                                str += "__INTERNAL_VARIABLE_LONG(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "Int32":
                            case "I4":   //short

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "UInt16":
                            case "U2":
                                str += "__INTERNAL_VARIABLE_SHORT(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In, 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";
                                break;

                            case "Int16":
                            case "I2":   //ushort

                                str += "__INTERNAL_VARIABLE_INTEGER(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In , 0, 0, false, false, 0, \"" + strAddr + "\", \"" + comment + "\");";
                                str += "\r\n";

                                break;

                            case "String":   //string
                            case "ASCII":   //string
                                str += "__INTERNAL_VARIABLE_STRING(\"I_W_" + tag_name + "\", \"" + "EQPDATA" + "\", enumAccessType.In,  false, false, string.Empty, \"" + strAddr + "\", \"" + comment + "\");";
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

                    metroTextBox1.AppendText(str);


                    str = str.Replace("__INTERNAL_VARIABLE_INTEGER(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    str = str.Replace("__INTERNAL_VARIABLE_LONG(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    str = str.Replace("__INTERNAL_VARIABLE_SHORT(\"I_W_", "__INTERNAL_VARIABLE_DOUBLE(\"" + "O_W_");
                    str = str.Replace("__INTERNAL_VARIABLE_BOOLEAN(\"I_B_", "__INTERNAL_VARIABLE_BOOLEAN(\"" + "O_B_");
                    str = str.Replace("__INTERNAL_VARIABLE_STRING(\"I_W_", "__INTERNAL_VARIABLE_STRING(\"" + "O_W_");
                    metroTextBox2.AppendText(str.Replace("EQPDATA", "OPCDATA").Replace("enumAccessType.In", "enumAccessType.Out"));
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
    }
}
