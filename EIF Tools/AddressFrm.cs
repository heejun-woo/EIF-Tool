using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace EIF_Tolls
{
    public partial class AddressFrm : MetroFramework.Forms.MetroForm
    {
        int iPlcType = -1;

        public AddressFrm(MetroStyleManager manager, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

    
            GridUtil.SetDoNotSort(InputGrid);

            tabCtrl.SelectedIndex = 0;
            tabCtrl.TabPages[0].Show();

            iPlcType = plcType;
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
                if (tabCtrl.SelectedIndex == 0) Type1();
                else if (tabCtrl.SelectedIndex == 1) Type2();
                else if (tabCtrl.SelectedIndex == 2) Type3();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Type1()
        {
            FileStream fstream = new FileStream(openFileDialog1.FileName, FileMode.Open);

            Workbook workbook = new Workbook(fstream);

            Worksheet worksheet = workbook.Worksheets[5];

            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 12, true);

            string sType, strLength, strAddr, strTagName, strReport, sArray;

            DataTable dt = new DataTable();

            dt.Columns.Add("Sequence");
            dt.Columns.Add("Direction");
            dt.Columns.Add("적용여부");
            dt.Columns.Add("주체");
            dt.Columns.Add("구분");
            dt.Columns.Add("Specification Data List");
            dt.Columns.Add("설비 Data Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Length");
            dt.Columns.Add("Address");
            dt.Columns.Add("ConnSTring");


            bool bUseFlag = false;
            if (iPlcType == 0)
            {
                #region 기존 PLC
                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        bUseFlag = true;
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        bUseFlag = false;
                    }

                    if (!bUseFlag) continue;


                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 9].Value + "";
                    strLength = (worksheet.Cells[i, 10].Value + "");
                    strAddr = worksheet.Cells[i, 11].Value + "";
                    strTagName = worksheet.Cells[i, 6].Value + "";

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strLength) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;


                    string deviceType = string.Empty, addressNp = string.Empty;

                    string Connstr = string.Empty;

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            deviceType = strAddr.Substring(0, 1);
                            addressNp = strAddr.Substring(1, strAddr.Length - 1);

                            break;

                        default:
                            if (strAddr.Length > 4)
                            {
                                int xx = strAddr.Length - 1;
                                deviceType = strAddr.Substring(0, strAddr.Length - xx);
                                addressNp = strAddr.Substring(strAddr.Length - xx, strAddr.Length - (strAddr.Length - xx));
                            }
                            break;
                    }

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            if (deviceType == "W")
                            {
                                if (addressNp.Split('.').Length > 1)
                                    Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp.Split('.')[0]}, BIT_INDEX={Convert.ToInt32(addressNp.Split('.')[1], 16).ToString()}";
                                else Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp.Split('.')[0]}";

                            }
                            else Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";
                            break;

                        case "U4":
                        case "I4":

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;

                        case "U2":
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;
                        case "I2":   //ushort

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;
                        case "T6":
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";
                            break;

                        case "ASCII":   //string
                            try
                            {
                                strLength = strLength.Trim();
                                strLength = strLength.Replace("\r", "").Replace("\n", "");
                                Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH={ Convert.ToInt32(strLength.ToUpper().Replace("WORD", "")) * 2}";
                            }
                            catch { }
                            break;
                        case "WORD":   //string
                            try
                            {
                                strLength = strLength.Trim();
                                strLength = strLength.Replace("\r", "").Replace("\n", "");

                                if (strLength == "1") Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";
                                else
                                    Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH={ Convert.ToInt32(strLength.ToUpper().Replace("WORD", "")) * 2}";
                            }
                            catch { }
                            break;


                        default:    ////6 정의안됨
                            break;

                    }

                    dt.Rows.Add(new object[] { worksheet.Cells[i, 1].Value + "", worksheet.Cells[i, 2].Value + "", worksheet.Cells[i, 3].Value + "", worksheet.Cells[i, 4].Value + "",
                        worksheet.Cells[i, 5].Value + "", worksheet.Cells[i, 6].Value + "", worksheet.Cells[i, 7].Value + "", sType, strLength, strAddr, Connstr });
                }
                #endregion
            }
            else if (iPlcType == 1)
            {
                #region 지멘스


                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        bUseFlag = true;
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        bUseFlag = false;
                    }

                    if (!bUseFlag) continue;


                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 10].Value + "";
                    strAddr = worksheet.Cells[i, 9].Value + "";

                    sArray = string.Empty;
                    try
                    {
                        if (worksheet.Cells[i, 11].Value != null)
                        {
                            string ss = worksheet.Cells[i, 11].Value.ToString().Replace("[", "").Replace("]", "");
                            int xx = Convert.ToInt32(ss) - 1;
                            if (xx > -1) sArray = $"[{xx}]";
                        }
                    }
                    catch { }

                    strTagName = worksheet.Cells[i, 6].Value + "";

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;


                    string deviceType = string.Empty, addressNp = string.Empty;

                    string Connstr = $"ns=3, S=\"{strAddr.Replace(".", "\".\"")}\"";

                    if (!string.IsNullOrWhiteSpace(sArray)) Connstr += sArray;


                    switch (sType.ToUpper())
                    {
                        case "INT16":   //ushort

                            if (strAddr.Contains(".H_"))
                            {
                                Connstr += ",SIGNED=1";
                            }
                            //else Connstr += ",SIZE=16";

                            break;                                 

                    }




                    dt.Rows.Add(new object[] { worksheet.Cells[i, 1].Value + "", worksheet.Cells[i, 2].Value + "", worksheet.Cells[i, 3].Value + "", worksheet.Cells[i, 4].Value + "",
                        worksheet.Cells[i, 5].Value + "", worksheet.Cells[i, 6].Value + "", worksheet.Cells[i, 7].Value + "", sType, "", strAddr, Connstr });

                 
                }
                #endregion
            }
            fstream.Close();


            InputGrid.DataSource = dt;


            btnDriverString();
        }


        private void BtnTextCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtResult.Text);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Counter Spec 워크시트(.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
        }

        private void btnDriverString()
        {
            //try
            //{

            int chk_cnt = 16;

            List<bool> lst_B = new List<bool>();
            List<bool> lst_M = new List<bool>();
            List<bool> lst_D = new List<bool>();
            List<bool> lst_W = new List<bool>();
            List<bool> lst_R = new List<bool>();
            List<bool> lst_L = new List<bool>();
            List<bool> lst_ZR = new List<bool>();

            for (int i = 0; i < 110000; i++)
            {
                lst_B.Add(false);
                lst_M.Add(false);
                lst_D.Add(false);
                lst_W.Add(false);
                lst_R.Add(false);
                lst_L.Add(false);
                lst_ZR.Add(false);
            }
            txtResult.Text = "";

            int cnt = 0;

            for (int i = 0; i < InputGrid.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty((InputGrid.Rows[i].Cells[10].Value + "").ToString())) break;

                string[] strAddr = InputGrid.Rows[i].Cells[10].Value.ToString().Trim().Split(',');

                if (strAddr.Length < 2) continue;

                if (!strAddr[0].Contains("DEVICE_TYPE=")) continue;
                if (!strAddr[1].Contains("ADDRESS_NO=")) continue;

                string strType = strAddr[0].Replace("DEVICE_TYPE=", "").Trim();
                string strDevNo = strAddr[1].Replace("ADDRESS_NO=", "").Trim();


                int iLength = 1;

                if (strAddr.Length > 2 && strAddr[2].Contains("LENGTH="))
                    iLength = Convert.ToInt32(strAddr[2].Replace("LENGTH=", "").Trim());

                int iDev;

                if (strType.Equals("B") || strType.Equals("W"))
                    iDev = Convert.ToInt32(strDevNo, 16);
                else
                    iDev = Convert.ToInt32(strDevNo);


                int a = 2;

                if (strType == "B")
                {
                    for (int x = 0; x < iLength * a; x++) lst_B[iDev + x] = true;
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
            }

            string str = string.Empty;
            str = proc02("B", ref lst_B, txtResult);
            str = proc02("M", ref lst_M, txtResult);
            str = proc02("D", ref lst_D, txtResult);
            str = proc02("W", ref lst_W, txtResult);
            str = proc02("R", ref lst_R, txtResult);
            str = proc02("L", ref lst_L, txtResult);
            str = proc02("ZR", ref lst_ZR, txtResult);



        }

        private string proc02(string word, ref List<bool> lst, MetroFramework.Controls.MetroTextBox tBOX)
        {
            int chk_cnt = 64; //어드레스 빈공간 최대치 넘을 경우 영역 분리
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

                    if (word.Equals("B") || word.Equals("W"))
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
                else if (d_cnt > 400 && lst[i] == false) // 영역의 Length가 400이 넘을 경우 빈공간이 발견되면 영역 분리, chk_cnt 감안하여 계속해서 연속되는 경우 512를 넘길수 있음 필요시 400 에서 줄여야함
                {
                    isVal = false;
                    str += ":" + d_cnt.ToString();
                    f_cnt = 0;
                    d_cnt = 0;
                }
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



        private void Type2()
        {
            FileStream fstream = new FileStream(openFileDialog1.FileName, FileMode.Open);

            Workbook workbook = new Workbook(fstream);

            Worksheet worksheet = workbook.Worksheets[5];

            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 12, true);

            string sType, strLength, strAddr, strTagName, strReport, sArray;

            DataTable dt = new DataTable();

            dt.Columns.Add("ConnSTring");


            bool bUseFlag = false;

            string str = string.Empty;


            if (iPlcType == 0)
            {
                #region 기존 PLC
                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        bUseFlag = true;

                        str += "\r\n";
                        str += "// " + (worksheet.Cells[i, 1].Value + "") + " " + (worksheet.Cells[i, 2].Value + "") + "\r\n";
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        bUseFlag = false;
                    }

                    if (!bUseFlag) continue;

                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 9].Value + "";
                    strLength = (worksheet.Cells[i, 10].Value + "");
                    strAddr = worksheet.Cells[i, 11].Value + "";
                    strTagName = worksheet.Cells[i, 6].Value + "";

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strLength) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;

                    string deviceType = string.Empty, addressNp = string.Empty;

                    string Connstr = string.Empty;

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            deviceType = strAddr.Substring(0, 1);
                            addressNp = strAddr.Substring(1, strAddr.Length - 1);

                            break;

                        default:
                            if (strAddr.Length > 4)
                            {
                                deviceType = strAddr.Substring(0, strAddr.Length - 4);
                                addressNp = strAddr.Substring(strAddr.Length - 4, strAddr.Length - (strAddr.Length - 4));
                            }
                            break;
                    }

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            if (deviceType == "W")
                            {
                                Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp.Split('.')[0]}, BIT_INDEX={Convert.ToInt32(addressNp.Split('.')[1], 16).ToString()}";
                            }
                            else Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";
                            break;

                        case "U4":
                        case "I4":

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;

                        case "U2":
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;
                        case "I2":   //ushort

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH=1";

                            break;
                        case "T6":
                            Connstr = $"DEVICE_TYPE={deviceType}, DDRESS_NO={addressNp}";
                            break;

                        case "ASCII":   //string
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH={ Convert.ToInt32(strLength.ToUpper().Replace("WORD", "")) * 2}";
                            break;


                        default:    ////6 정의안됨

                            continue;
                            break;

                    }


                    str += $"[{Connstr}] : { worksheet.Cells[i, 7].Value + ""} {sType} {strLength}" + "\r\n";


                    dt.Rows.Add(new object[] { Connstr });
                }

                txtType2.Text = str;
                DriverString(dt);
                #endregion
            }
            else if (iPlcType == 1)
            {
                #region 지멘스
                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        bUseFlag = true;

                        str += "\r\n";
                        str += "// " + (worksheet.Cells[i, 1].Value + "") + " " + (worksheet.Cells[i, 2].Value + "") + "\r\n";
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        bUseFlag = false;
                    }

                    if (!bUseFlag) continue;

                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 10].Value + "";
                    strAddr = worksheet.Cells[i, 9].Value + "";
                    sArray = worksheet.Cells[i, 11].Value + "";
                    strTagName = worksheet.Cells[i, 6].Value + "";

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;

                    string deviceType = string.Empty, addressNp = string.Empty;

                    string Connstr = $"ns=3, S=\"{strAddr.Replace(".", "\".\"")}\"";


                    if (!string.IsNullOrWhiteSpace(sArray)) Connstr += sArray;

                    str += $"[{Connstr}] : { worksheet.Cells[i, 7].Value + ""} {sType} " + "\r\n";


                    dt.Rows.Add(new object[] { Connstr });
                }

                txtType2.Text = str;
                #endregion
            }


            fstream.Close();

        }

        private void DriverString(DataTable dt)
        {
            //try
            //{

            int chk_cnt = 16;

            List<bool> lst_B = new List<bool>();
            List<bool> lst_M = new List<bool>();
            List<bool> lst_D = new List<bool>();
            List<bool> lst_W = new List<bool>();
            List<bool> lst_R = new List<bool>();
            List<bool> lst_L = new List<bool>();
            List<bool> lst_ZR = new List<bool>();

            for (int i = 0; i < 110000; i++)
            {
                lst_B.Add(false);
                lst_M.Add(false);
                lst_D.Add(false);
                lst_W.Add(false);
                lst_R.Add(false);
                lst_L.Add(false);
                lst_ZR.Add(false);
            }
            txtResult.Text = "";

            int cnt = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty((dt.Rows[i][0]).ToString())) break;

                string[] strAddr = dt.Rows[i][0].ToString().Trim().Split(',');

                if (strAddr.Length < 2) continue;

                if (!strAddr[0].Contains("DEVICE_TYPE=")) continue;
                if (!strAddr[1].Contains("ADDRESS_NO=")) continue;

                string strType = strAddr[0].Replace("DEVICE_TYPE=", "").Trim();
                string strDevNo = strAddr[1].Replace("ADDRESS_NO=", "").Trim();


                int iLength = 1;

                if (strAddr.Length > 2 && strAddr[2].Contains("LENGTH="))
                    iLength = Convert.ToInt32(strAddr[2].Replace("LENGTH=", "").Trim());

                int iDev;

                if (strType.Equals("B") || strType.Equals("W"))
                    iDev = Convert.ToInt32(strDevNo, 16);
                else
                    iDev = Convert.ToInt32(strDevNo);


                int a = 2;

                if (strType == "B")
                {
                    for (int x = 0; x < iLength * a; x++) lst_B[iDev + x] = true;
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
            }

            string str = string.Empty;
            str = proc02("B", ref lst_B, txtTypeStr2);
            str = proc02("M", ref lst_M, txtTypeStr2);
            str = proc02("D", ref lst_D, txtTypeStr2);
            str = proc02("W", ref lst_W, txtTypeStr2);
            str = proc02("R", ref lst_R, txtTypeStr2);
            str = proc02("L", ref lst_L, txtTypeStr2);
            str = proc02("ZR", ref lst_ZR, txtTypeStr2);



        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           Clipboard.SetDataObject(txtType2.Text);
        }


        private void Type3()
        {
            FileStream fstream = new FileStream(openFileDialog1.FileName, FileMode.Open);

            Workbook workbook = new Workbook(fstream);

            Worksheet worksheet = workbook.Worksheets[5];

            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, worksheet.Cells.Rows.Count, 12, true);

            string sType, strLength, strAddr, strTagName, strReport, comment, sArray;

            DataTable dt = new DataTable();

            dt.Columns.Add("ConnSTring");


            bool bUseFlag = false;

            string str = string.Empty;

            string strCate = string.Empty;

            bool isHost = false, isTrigger = false;


            if (iPlcType == 0)
            {
                #region 기존 PLC
                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        if (bUseFlag) str += "#endregion" + "\r\n";

                        bUseFlag = true;

                        strCate = (worksheet.Cells[i, 1].Value + "").ToUpper();

                        if (strCate.Length > 30) strCate = strCate.Substring(14, 16);

                        str += "\r\n";
                        str += "#region " + (worksheet.Cells[i, 1].Value + "") + "\r\n";
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        if (bUseFlag)
                        {
                            bUseFlag = false;
                            str += "#endregion" + "\r\n";
                        }
                    }

                    if (!bUseFlag) continue;

                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 9].Value + "";
                    strLength = (worksheet.Cells[i, 10].Value + "");
                    strAddr = worksheet.Cells[i, 11].Value + "";
                    strTagName = (worksheet.Cells[i, 7].Value + "").ToUpper();
                    if (strTagName.Length > 15) strTagName = strTagName.Substring(0, 14);


                    comment = (worksheet.Cells[i, 8].Value + "");
                    if (comment.Length > 20) comment = comment.Substring(0, 20);

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strLength) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;

                    string deviceType = string.Empty, addressNp = string.Empty;

                    string Connstr = string.Empty;


                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            deviceType = strAddr.Substring(0, 1);
                            addressNp = strAddr.Substring(1, strAddr.Length - 1);

                            break;

                        default:
                            if (strAddr.Length > 4)
                            {
                                deviceType = strAddr.Substring(0, strAddr.Length - 4);
                                addressNp = strAddr.Substring(strAddr.Length - 4, strAddr.Length - (strAddr.Length - 4));
                            }
                            break;
                    }


                    strTagName = strTagName.Replace(" ", "_");
                    strCate = strCate.Replace(" ", "_");

                    strTagName = Regex.Replace(strTagName, @"\t|\n|\r", "");
                    strCate = Regex.Replace(strCate, @"\t|\n|\r", "");
                    comment = Regex.Replace(comment, @"\t|\n|\r", "");

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean

                            if (deviceType == "W")
                            {
                                Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp.Split('.')[0]}, BIT_INDEX={Convert.ToInt32(addressNp.Split('.')[1], 16).ToString()}";
                            }
                            else Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";
                            break;

                        case "U4":
                        case "I4":

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;

                        case "U2":
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}";

                            break;
                        case "I2":   //ushort

                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH=1";

                            break;
                        case "T6":
                            Connstr = $"DEVICE_TYPE={deviceType}, DDRESS_NO={addressNp}";
                            break;

                        case "ASCII":   //string
                            Connstr = $"DEVICE_TYPE={deviceType}, ADDRESS_NO={addressNp}, LENGTH={ Convert.ToInt32(strLength.ToUpper().Replace("WORD", "")) * 2}";
                            break;


                        default:    ////6 정의안됨

                            continue;
                            break;

                    }

                    if (cbEmpty.Checked) Connstr = string.Empty;

                    if ((worksheet.Cells[i, 4].Value + "").ToUpper().Trim().Equals("HOST"))
                    {
                        isHost = true;
                    }
                    else if ((worksheet.Cells[i, 4].Value + "").ToUpper().Trim().Equals("EQP"))
                    {
                        isHost = false;
                    }

                    if ((worksheet.Cells[i, 5].Value + "").ToUpper().Trim().Equals("TRIGGER"))
                    {
                        isTrigger = true;
                    }
                    else if ((worksheet.Cells[i, 5].Value + "").ToUpper().Trim().Equals("DATA"))
                    {
                        isTrigger = false;
                    }


                    string strTrace = "true";
                    string strMonitoring = "false";

                    if (!isHost && isTrigger) strMonitoring = "true";

                    switch (sType.ToUpper())
                    {
                        case "B":
                        case "BIT":
                        case "BOOLEAN":   //boolean
                            str += "__INTERNAL_VARIABLE_BOOLEAN(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", " + strMonitoring + ", " + strTrace + ", false, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;

                        case "U4":
                        case "I4":   //short

                            str += "__INTERNAL_VARIABLE_INTEGER(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 0, 0, " + strMonitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;

                        case "U2":
                            str += "__INTERNAL_VARIABLE_SHORT(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 0, 0, " + strMonitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;
                        case "I2":   //ushort

                            str += "__INTERNAL_VARIABLE_INTEGER(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + " , 0, 0, " + strMonitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;


                        case "T6":   //일자
                            str += "__INTERNAL_VARIABLE_SHORTLIST(\"" + (isHost ? "O" : "I") + "_W_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 6, 0, 0, " + strMonitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";
                            break;

                        case "ASCII":   //string
                            str += "__INTERNAL_VARIABLE_STRING(\"" + (isHost ? "O" : "I") + "_W_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ",  " + strMonitoring + ", " + strTrace + ", string.Empty, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";
                            break;


                        default:    ////6 정의안됨
                            str += "error;";
                            str += "\r\n";

                            break;

                    }


                    dt.Rows.Add(new object[] { Connstr });
                }
                #endregion
            }
            else if (iPlcType == 1)
            {
                #region 지멘스
                for (int i = 0; i < worksheet.Cells.Rows.Count; i++)
                {

                    if ((worksheet.Cells[i, 3].Value + "").Equals("O"))
                    {
                        if (bUseFlag) str += "#endregion" + "\r\n";

                        bUseFlag = true;

                        strCate = (worksheet.Cells[i, 1].Value + "").ToUpper();

                        if (strCate.Length > 30) strCate = strCate.Substring(14, 16);

                        str += "\r\n";
                        str += "#region " + (worksheet.Cells[i, 1].Value + "") + "\r\n";
                    }
                    else if ((worksheet.Cells[i, 3].Value + "").Equals("X"))
                    {
                        if (bUseFlag)
                        {
                            bUseFlag = false;
                            str += "#endregion" + "\r\n";
                        }
                    }

                    if (!bUseFlag) continue;

                    strReport = worksheet.Cells[i, 2].Value + "";
                    sType = worksheet.Cells[i, 10].Value + "";
                    strAddr = worksheet.Cells[i, 9].Value + "";
                    sArray = worksheet.Cells[i, 11].Value + "";
                    strTagName = (worksheet.Cells[i, 7].Value + "").ToUpper();
                    if (strTagName.Length > 15) strTagName = strTagName.Substring(0, 14);


                    comment = (worksheet.Cells[i, 8].Value + "");
                    if (comment.Length > 20) comment = comment.Substring(0, 20);

                    if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(strAddr) || string.IsNullOrEmpty(strTagName)) continue;

                    string Connstr = $"ns=3, S=\\\"{strAddr.Replace(".", "\\\".\\\"")}\\\"";
                    if (!string.IsNullOrWhiteSpace(sArray)) Connstr += sArray;

                    strTagName = strTagName.Replace(" ", "_");
                    strCate = strCate.Replace(" ", "_");

                    strTagName = Regex.Replace(strTagName, @"\t|\n|\r", "");
                    strCate = Regex.Replace(strCate, @"\t|\n|\r", "");
                    comment = Regex.Replace(comment, @"\t|\n|\r", "");

                    if (cbEmpty.Checked) Connstr = string.Empty;

                    if ((worksheet.Cells[i, 4].Value + "").ToUpper().Trim().Equals("HOST"))
                    {
                        isHost = true;
                    }
                    else if ((worksheet.Cells[i, 4].Value + "").ToUpper().Trim().Equals("EQP"))
                    {
                        isHost = false;
                    }

                    if ((worksheet.Cells[i, 5].Value + "").ToUpper().Trim().Equals("TRIGGER"))
                    {
                        isTrigger = true;
                    }
                    else if ((worksheet.Cells[i, 5].Value + "").ToUpper().Trim().Equals("DATA"))
                    {
                        isTrigger = false;
                    }


                    string strTrace = "true";
                    string monitoring = "false";

                    if (!isHost && isTrigger) monitoring = "true";

                    switch (sType.Trim())
                    {
                        case "B":
                        case "BIT":
                        case "Boolean":
                        case "BOOLEAN":   //boolean
                            str += "__INTERNAL_VARIABLE_BOOLEAN(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", " + monitoring + ", " + strTrace + ", false, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;

                        case "U4":
                        case "UInt32":
                        case "Int32":
                        case "I4":   //short

                            str += "__INTERNAL_VARIABLE_INTEGER(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 0, 0, " + monitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;
                        case "UInt16":
                        case "U2":
                            str += "__INTERNAL_VARIABLE_SHORT(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 0, 0, " + monitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;

                        case "Int16":
                        case "I2":   //ushort

                            str += "__INTERNAL_VARIABLE_INTEGER(\"" + (isHost ? "O" : "I") + "_B_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + " , 0, 0, " + monitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";

                            break;


                        case "T6":   //일자
                            str += "__INTERNAL_VARIABLE_SHORTLIST(\"" + (isHost ? "O" : "I") + "_W_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ", 6, 0, 0, " + monitoring + ", " + strTrace + ", 0, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";
                            break;

                        case "String":
                        case "ASCII":   //string
                            str += "__INTERNAL_VARIABLE_STRING(\"" + (isHost ? "O" : "I") + "_W_" + strTagName + "\", \"" + strCate + "\", enumAccessType." + (isHost ? "Out" : "In") + ",  " + monitoring + ", " + strTrace + ", string.Empty, \"" + Connstr + "\", \"" + comment + "\");";
                            str += "\r\n";
                            break;


                        default:    ////6 정의안됨
                            str += "error;";
                            str += "\r\n";

                            break;

                    }


                    dt.Rows.Add(new object[] { Connstr });
                }
                #endregion
            }




            txtType3.Text = str;

            fstream.Close();

            //DriverString(dt);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtType3.Text);
        }
    }
}
