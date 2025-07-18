using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace EIF_Tolls
{
    public partial class LogFrm : MetroFramework.Forms.MetroForm
    {

        public LogFrm(MetroStyleManager manager)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);


        }

        private void BtnExe_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "로그 파일(*.log)|*.log";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    cbFileName.Items.Add(openFileDialog1.FileNames[i]);
                }

                cbFileName.SelectedIndex = 0;
            }
        }

        private void initGridView(List<string> lstCols)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            for (int i = 0; i < lstCols.Count; i++)
            {
                dataGridView1.Columns.Add(lstCols[i], lstCols[i]);
            }
        }


        private void btnConnStrEX_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "CELLID", "EL_PRE_WEIGHT", "EL_AFTER_WEIGHT", "EL_WEIGHT", "EL_JUDG_VALUE" };
            initGridView(lstCols);

            dataGridView1.RowCount = 5000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "\t[EIF] \t[EL] \t"; // 찾아야할 시점

                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;

                    i += 3;
                    string strLen = log[i].Trim();

                    if (strLen.Length == 0) continue;


                    int len = Convert.ToInt16(strLen.Substring(strLen.Length - 1, 1));


                    for (int x = 0; x < len; x++)
                    {
                        if (x == 0) i += 3;
                        else i++;

                        string[] val = log[i].Replace("[", "").Replace("]", "").Split('\t');

                        //if (!string.IsNullOrEmpty(val[5].Trim()) && !string.IsNullOrEmpty(val[6].Trim()) && !string.IsNullOrEmpty(val[7].Trim())) continue;
                        
                        if (Convert.ToDouble(val[5]) != 0 && Convert.ToDouble(val[6]) != 0 && Convert.ToDouble(val[7]) != 0) continue;

                        dataGridView1.Rows[row].Cells[0].Value = val[2];
                        dataGridView1.Rows[row].Cells[1].Value = val[5];
                        dataGridView1.Rows[row].Cells[2].Value = val[6];
                        dataGridView1.Rows[row].Cells[3].Value = val[7];
                        dataGridView1.Rows[row].Cells[4].Value = val[9];


                        row++;
                    }


                }


            }


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "LOTID", "PORT_ID", "EQPT_DFCT_CODE", "DFCT_QTY", "증감" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 6000;

            int row = 0;

            Dictionary<string, int> dicDef = new Dictionary<string, int>();


            string strFind = "[FAAdaptor]Execute Service :(IN DATA) [BR_PRD_REG_EQPT_DFCT_CLCT_L_IN]"; // 찾아야할 시점

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                string time = log[i].Trim().Substring(0, 22);


                int len = 0;
                string strFind2 = "Table Name : IN_DEFECT - Row Count :"; //이후 두번째로 찾아야할 시점
                for (; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind2)) continue;
                    string strLen = log[i].Trim();
                    len = Convert.ToInt16(strLen.Substring(strLen.Length - 1, 1));

                    break;
                }


                for (int x = 0; x < len; x++)
                {
                    if (x == 0) i += 3;
                    else i++;

                    string[] val = log[i].Replace("[", "").Replace("]", "").Split('\t');

                    if (!dicDef.ContainsKey(val[3])) dicDef.Add(val[3], Convert.ToInt32(val[4]));

                    dataGridView1.Rows[row].Cells[0].Value = time;
                    dataGridView1.Rows[row].Cells[1].Value = val[1];
                    dataGridView1.Rows[row].Cells[2].Value = val[2];
                    dataGridView1.Rows[row].Cells[3].Value = val[3];
                    dataGridView1.Rows[row].Cells[4].Value = val[4];
                    dataGridView1.Rows[row].Cells[5].Value = Convert.ToInt32(val[4]) - dicDef[val[3]];


                    dicDef[val[3]] = Convert.ToInt32(val[4]);

                    row++;
                }

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "CELLID", "RESULT_VALUE", "NG_MSGID", "MSG", };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 1000;

            int row = 0;
            string strFind = "[PT]"; // 찾아야할 시점

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                string time = log[i - 4].Trim().Substring(0, 22);


                int len = 0;
                string strFind2 = "Table Name : OUT_CELL - Row Count :"; //이후 두번째로 찾아야할 시점
                for (; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind2)) continue;
                    string strLen = log[i].Trim();
                    len = Convert.ToInt16(strLen.Substring(strLen.Length - 1, 1));

                    break;
                }


                for (int x = 0; x < len; x++)
                {
                    if (x == 0) i += 3;
                    else i++;

                    string[] val = log[i].Replace("[", "").Replace("]", "").Split('\t');

                    if (val[3].Trim().Equals("NG") == false) continue;

                    dataGridView1.Rows[row].Cells[0].Value = time;
                    dataGridView1.Rows[row].Cells[1].Value = val[2];
                    dataGridView1.Rows[row].Cells[2].Value = val[3];
                    dataGridView1.Rows[row].Cells[3].Value = val[4];
                    dataGridView1.Rows[row].Cells[4].Value = SendMesNgMsgIdCode(val[4]).Trim();

                    row++;
                }

            }
        }

        public string SendMesNgMsgIdCode(string strNgCode)
        {
            /* NG_MSGID 내용 */
            //90112   입력된 생산LOTID가 존재하지 않습니다.
            //90113   입력된 생산LOT의 ID의 길이가 상이합니다.
            //90114   입력된 CELLID가 존재하지 않습니다.
            //90115   입력된 CELLID에 상이한 문자가 존재합니다.
            //90116   입력된 CELL의 ID의 길이가 상이합니다.
            //90117   입력된 생산LOT과 CELL의 발번체계가 상이합니다.
            //90118   입력된 CELL과 동일한 CELL이 2개이상 존재합니다.
            //90119   입력된 CELL은 Tray에 담겨 있습니다.
            //101223  불량 셀 이력이 없습니다.
            //101224  재작업 유형과 불량 셀 유형이 불일치 합니다.
            //90120   WIP 정보가 없습니다.

            string strNgMessage = string.Empty;
            switch (strNgCode.Trim())
            {
                case "90112":
                    strNgMessage = "Production LOTID does not exist";
                    break;
                case "90113":
                    strNgMessage = "The length of the Production LOT ID is different";
                    break;
                case "90114":
                    strNgMessage = "The readed CELLID does not exist";
                    break;
                case "90115":
                    strNgMessage = "There are different characters in the readed CELLID";
                    break;
                case "90116":
                    strNgMessage = "The length of the ID of the CELL is different";
                    break;
                case "90117":
                    strNgMessage = "The numbering structure of Production LOT and CELL is different";
                    break;
                case "90118":
                    strNgMessage = "There are two or more cells that are the same as the inputted cell.";
                    break;
                case "90119":
                    strNgMessage = "The inputted cell is already contained in the Tray";
                    break;
                case "101223":
                    strNgMessage = "No bad cell history";
                    break;
                case "101224":
                    strNgMessage = "Rework type and bad cell type do not match";
                    break;
                case "90120":
                    strNgMessage = "No WIP information";
                    break;
                default:
                    break;
            }

            return strNgMessage;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "LOTID", "MGZ", "CUT수량", "차이" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 5000;

            int row = 0;
            string strFind = "[WIP Input Lot] Position ID : "; // 찾아야할 시점v

            Dictionary<string, int> dicLot = new Dictionary<string, int>();

            for (int i = 0; i < log.Count; i++)
            {
                string time;

                if (!log[i].Contains(strFind)) continue;

                string[] data = log[i].Split(',');

                time = log[i].Trim().Substring(0, 22);

                string lot = data[1].Replace("Carrier Lot ID : ", "").Trim();
                string mgz = data[2].Replace("Carrier ID :", "").Trim();
                int cut = Convert.ToInt32(data[4].Replace("Cut Qty :", "").Trim());

                int a = cut;
                if (dicLot.ContainsKey(lot))
                {
                    a = dicLot[lot];
                }
                else dicLot.Add(lot, cut);

                dataGridView1.Rows[row].Cells[0].Value = time;
                dataGridView1.Rows[row].Cells[1].Value = lot;
                dataGridView1.Rows[row].Cells[2].Value = mgz;
                dataGridView1.Rows[row].Cells[3].Value = cut;
                dataGridView1.Rows[row].Cells[4].Value = cut - a;


                dicLot[lot] = cut;

                if (cut - a < 0)
                    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Blue;
                else if (cut - a > 500)
                    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Red;
                else if (cut - a > 300)
                    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Yellow;

                row++;
            }

            file.Dispose();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "Type", "Port", "Carrier ID", "Lot ID", "Out Type", "Result", "잔량" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 1000;

            int row = 0;


            for (int i = 0; i < log.Count; i++)
            {
                string time;
                string tagName;
                string result;

                int ioutType = 0;

                if (log[i].Contains("Virtual Magazine")) continue;
                if (!log[i].Contains("Port #0")) continue;

                if (Regex.IsMatch(log[i], @"\[I_B_CARR_IN_RPT\]\s\[..\]"))
                {
                    string[] data2 = log[i].Split('[');

                    tagName = data2[3].Substring(0, data2[3].Length - 2);
                    result = data2[4].Substring(0, data2[4].Length - 2);
                    ioutType = 2;
                }
                else if (Regex.IsMatch(log[i], @"\[I_B_CARR_OUT_RPT\]\s\[..\]"))
                {
                    string[] data2 = log[i].Split('[');

                    tagName = data2[3].Substring(0, data2[3].Length - 2);
                    result = data2[4].Substring(0, data2[4].Length - 2);
                    ioutType = 3;
                }
                else if (Regex.IsMatch(log[i], @"\[I_B_CARR_ID_RPT\]\s\[..\]"))
                {
                    string[] data2 = log[i].Split('[');


                    tagName = data2[3].Substring(0, data2[3].Length - 2);
                    result = data2[4].Substring(0, data2[4].Length - 2);
                    ioutType = 1;
                }
                else continue;

                time = log[i].Trim().Substring(0, 22);

                string[] data = log[i].Split(',');

                string port = data[1].Substring(0, 10);
                string carrier = string.Empty;
                string lot = data[2].Substring(data[2].Length - 10, 10);
                string strcut = string.Empty;
                string remain = "";
                if (ioutType == 3)
                {
                    int cut = Convert.ToInt32(data[10].Replace("Output Type :", "").Trim());
                    remain = data[6].Replace("Remaining Qty :", "").Trim();


                    if (cut == 1) strcut = "C";
                    else if (cut == 2) strcut = "R";
                    else if (cut == 3) strcut = "H";
                    else if (cut == 4) strcut = "NG";
                    carrier = data[1].Substring(data[1].Length - 10, 10);
                }
                else if (ioutType == 1)
                {
                    carrier = data[1].Substring(23, 10);
                }
                else if (ioutType == 2)
                {
                    carrier = data[1].Substring(23, 10);
                }


                dataGridView1.Rows[row].Cells[0].Value = time;
                dataGridView1.Rows[row].Cells[1].Value = tagName;
                dataGridView1.Rows[row].Cells[2].Value = port;
                dataGridView1.Rows[row].Cells[3].Value = carrier;
                dataGridView1.Rows[row].Cells[4].Value = lot;
                dataGridView1.Rows[row].Cells[5].Value = strcut;
                dataGridView1.Rows[row].Cells[6].Value = result;
                dataGridView1.Rows[row].Cells[7].Value = remain;

                if (ioutType != 1)
                {
                    int idx = int.Parse(Regex.Replace(port, @"\D", ""));

                    if ((idx + 1) / 2 == 1)
                        dataGridView1.Rows[row].Cells[2].Style.BackColor = Color.LimeGreen;
                    else if ((idx + 1) / 2 == 2)
                        dataGridView1.Rows[row].Cells[2].Style.BackColor = Color.SkyBlue;
                    else if ((idx + 1) / 2 == 3)
                        dataGridView1.Rows[row].Cells[2].Style.BackColor = Color.Yellow;

                }
                if (ioutType == 2)
                    dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.Blue;
                else if (ioutType == 3)
                    dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.Red;
                row++;
            }

            file.Dispose();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "REPORT_TAG", "BIZ_RUN", "CONF_ON", "RPT_OFF" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 10000;

            int row = 0;
            string strFind = "[CELL_ID_RPT_01:I_B_CELL_ID_RPT] (Boolean) : ON";// ":I_B_CARR_ID_RPT] (Boolean) : ON"; // 찾아야할 시점

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                bool find2 = false;
                bool find3 = false;
                bool find4 = false;

                string time = log[i].Trim().Substring(0, 22);
                string tagName = "";// log[i].Trim().Substring(56, 14);

                tagName = string.Empty;

                dataGridView1.Rows[row].Cells[0].Value = time;
                dataGridView1.Rows[row].Cells[1].Value = tagName;

                string strFind2 = tagName + "[CELL_ID_RPT_01:O_B_CELL_ID_CONF] (Boolean) : ON"; //이후 두번째로 찾아야할 시점
                string strFind3 = tagName + "[CELL_ID_RPT_01:I_B_CELL_ID_RPT] (Boolean) : OFF"; //이후 두번째로 찾아야할 시점
                string strFind4 = tagName + "[CELL_ID_RPT_01:O_B_CELL_ID_CONF] (Boolean) : OFF"; //이후 두번째로 찾아야할 시점

                for (int j = i; j < log.Count; j++)
                {
                    if (log[j].Contains(strFind2) && !find2)
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[2].Value = dt2 - dt1;
                        find2 = true;
                    }
                    else if (log[j].Contains(strFind3) && !find3)
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[3].Value = dt2 - dt1;

                        find3 = true;
                    }
                    else if (log[j].Contains(strFind4) && !find4)
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[4].Value = dt2 - dt1;

                        find4 = true;

                        break;
                    }
                }

                row++;

            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "REPORT_TAG", "BIZ_RUN", "CONF_ON", "RPT_OFF" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 1000;

            int row = 0;
            string strFind = "I_B_RCP_PARA_VALID_REQ] (Boolean) : ON"; // 찾아야할 시점

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                string time = log[i].Trim().Substring(0, 22);
                string tagName = log[i].Trim().Substring(46, 18);

                dataGridView1.Rows[row].Cells[0].Value = time;
                dataGridView1.Rows[row].Cells[1].Value = tagName;

                string strFind3 = "[YNPARA:ParaValYN] (ShortList) :"; //이후 두번째로 찾아야할 시점

                string strFind4 = "O_B_RCP_PARA_VALID_CONF] (Boolean) : ON"; //이후 두번째로 찾아야할 시점

                for (int j = i; j < log.Count; j++)
                {
                    if (log[j].Contains(strFind3))
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[3].Value = dt2 - dt1;

                    }
                    else if (log[j].Contains(strFind4))
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[4].Value = dt2 - dt1;

                        row++;
                        break;
                    }
                }


            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "LOTID", "Input 수량", "input 차이", "Output 수량", "Output 차이" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 5000;

            int row = 0;
            string strFind = "[FAAdaptor]BR_PRD_REG_EQPT_WIPQTY"; // 찾아야할 시점v
            string strFind2 = "	[LOTID] 	[INPUT_QTY] 	[OUTPUT_QTY] 	[INPUT_QTY_PTN] 	[OUTPUT_QTY_PTN] "; // 찾아야할 시점



            int in1 = 0;
            int out1 = 0;

            for (int i = 0; i < log.Count; i++)
            {
                string time;

                if (!log[i].Contains(strFind)) continue;
                if (log[i].Contains("[FAAdaptor]BR_PRD_REG_EQPT_WIPQTY_INPUT_LOT")) continue;

                for (int j = i; j < log.Count; j++)
                {
                    if (j > i + 10) break;

                    if (log[j].Contains(strFind2))
                    {
                        j++;
                        string[] data = log[j].Split('[');

                        time = log[i].Trim().Substring(0, 22);

                        string lot = data[1].Replace("]", "").Trim();
                        int in2 = Convert.ToInt32(data[2].Replace("]", "").Trim());
                        int out2 = Convert.ToInt32(data[3].Replace("]", "").Trim());


                        if (in1 == 0 && out1 == 0)
                        {
                            in1 = in2;
                            out1 = out2;
                        }

                        dataGridView1.Rows[row].Cells[0].Value = time;
                        dataGridView1.Rows[row].Cells[1].Value = lot;
                        dataGridView1.Rows[row].Cells[2].Value = in2;
                        dataGridView1.Rows[row].Cells[3].Value = in2 - in1;
                        dataGridView1.Rows[row].Cells[4].Value = out2;
                        dataGridView1.Rows[row].Cells[5].Value = out2 - out1;


                        in1 = in2;
                        out1 = out2;

                        //if (cut - a < 0)
                        //    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Blue;
                        //else if (cut - a > 500)
                        //    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Red;
                        //else if (cut - a > 300)
                        //    dataGridView1.Rows[row].Cells[4].Style.BackColor = Color.Yellow;

                        row++;
                        break;
                    }
                }

            }

            file.Dispose();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> CODE = new Dictionary<string, string>();

            CODE.Add("000271", "Loader Heavy Alarm");
            CODE.Add("000272", "Loader Wait - 재공부족");
            CODE.Add("000273", "Loader Wait - Output 보고");
            CODE.Add("000274", "Loader Wait - Validation NG");
            CODE.Add("000275", "Loader 재료교체 - Auto Splicing");
            CODE.Add("000276", "Loader User Stop");
            CODE.Add("000277", "Loader Stop");
            CODE.Add("000278", "Lami Heavy Alarm ");
            CODE.Add("000279", "Lami Wait");
            CODE.Add("000280", "Lami User Stop");
            CODE.Add("000281", "Lami Stop");
            CODE.Add("000282", "STK Heavy Alarm ");
            CODE.Add("000283", "STK Wait");
            CODE.Add("000284", "STK User Stop");
            CODE.Add("000285", "STK Stop");
            CODE.Add("000286", "TAP Heavy Alarm ");
            CODE.Add("000287", "TAP Wait");
            CODE.Add("000288", "TAP User Stop ");
            CODE.Add("000289", "TAP Stop");
            CODE.Add("000290", "INSP Heavy Alarm ");
            CODE.Add("000291", "INSP Wait");
            CODE.Add("000292", "INSP User Stop ");
            CODE.Add("000293", "INSP Stop");
            CODE.Add("000294", "Unloader Heavy Alarm ");
            CODE.Add("000295", "Unloader Wait");
            CODE.Add("000296", "Unloader User Stop");
            CODE.Add("000297", "Unloader Stop");



            Dictionary<string, string> CODE1 = new Dictionary<string, string>();

            CODE1.Add("000277", "Loader Stop");
            CODE1.Add("000281", "Lami Stop");
            CODE1.Add("000285", "STK Stop");
            CODE1.Add("000289", "TAP Stop");
            CODE1.Add("000293", "INSP Stop");
            CODE1.Add("000297", "Unloader Stop");

            List<string> lstCols = new List<string> { "TIME", "EQPID", "EIOSTAT", "TRBL CODE", "LOSS", "WAIT NAME" };
            initGridView(lstCols);


            List<string> log = new List<string>();

            dataGridView1.RowCount = 5000;

            int row = 0;
            string strFind = "	[SRCTYPE] 	[IFMODE] 	[EQPTID] 	[USERID] 	[EIOSTAT] 	[TRBL_CODE] 	[LOTID] 	[EQPT_LOT_PROG_MODE] 	[LOSS_CODE] "; // 찾아야할 시점v

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();

                for (int i = 0; i < log.Count; i++)
                {
                    string time;

                    if (!log[i].Contains(strFind)) continue;

                    string[] data = log[i + 1].Replace("]", "").Split('[');

                    time = log[i - 3].Trim().Substring(0, 22);

                    // if (!data[5].Trim().Equals("W")) continue;

                    dataGridView1.Rows[row].Cells[0].Value = time;
                    dataGridView1.Rows[row].Cells[1].Value = data[3];
                    dataGridView1.Rows[row].Cells[2].Value = data[5];
                    dataGridView1.Rows[row].Cells[3].Value = data[6];
                    dataGridView1.Rows[row].Cells[4].Value = data[9];
                    dataGridView1.Rows[row].Cells[5].Value = CODE.ContainsKey(data[6].Trim()) ? CODE[data[6].Trim()] : string.Empty;

                    if (CODE1.ContainsKey(data[6].Trim()))
                        dataGridView1.Rows[row].Cells[3].Style.BackColor = Color.Yellow;

                    row++;
                }

            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "PT Count", "EL Count" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 1000;



            string strFind = "\t[EIF] \t[EL] \t"; // 찾아야할 시점

            string strFind2 = "\t[EIF] \t[PT] \t"; // 찾아야할 시점

            int elCnt = 0;
            int ptCnt = 0;

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind) && !log[i].Contains(strFind2)) continue;

                i += 3;
                string strLen = log[i].Trim();
                int len = Convert.ToInt16(strLen.Substring(strLen.Length - 1, 1));

                if (log[i - 3].Contains(strFind))
                    elCnt += len;
                else 
                    ptCnt += len;

   

            }


            dataGridView1.Rows[0].Cells[0].Value = ptCnt;
            dataGridView1.Rows[0].Cells[1].Value = elCnt;
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "Time", "Elm Name", "Time" };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "Connection State Changed to Disconnected"; // 찾아야할 시점


                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;


                    string time = log[i].Trim().Substring(0, 22);
                    string tagName = log[i].Trim().Split(' ')[6];


                    dataGridView1.Rows[row].Cells[0].Value = time;
                    dataGridView1.Rows[row].Cells[1].Value = tagName;

                    string strFind2 = "Connection State Changed to Connected"; //이후 두번째로 찾아야할 시점

                    for (int j = i; j < log.Count; j++)
                    {
                        if (!log[j].Contains(strFind2)) continue;

                        string time2 = log[j].Trim().Substring(0, 22);
                        string tagNam2 = log[j].Trim().Split(' ')[6];

                        if (tagName.Equals(tagNam2))
                        {
                            dataGridView1.Rows[row].Cells[2].Value = Convert.ToDateTime(time2) - Convert.ToDateTime(time);

                          
                            break;
                        }
                    }

                    row++;


                }
            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
           List<string> lstCols = new List<string> { "Time", "Elm Name", "Time", "Elm Name", "Time", "Time" };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "I_B_HIST_UW_01_WORK_DIRECTION:"; // 찾아야할 시점


                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;


                    string[] str = log[i].Split(',');


                    dataGridView1.Rows[row].Cells[0].Value = str[4];
                    dataGridView1.Rows[row].Cells[1].Value = str[7];
                    dataGridView1.Rows[row].Cells[2].Value = str[10];
                    dataGridView1.Rows[row].Cells[3].Value = str[13];
                    dataGridView1.Rows[row].Cells[4].Value = str[14];
                    dataGridView1.Rows[row].Cells[5].Value = str[30];



                    row++;


                }
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "Time", "Port ID","EQP", "Type", "Carr ID" };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "[FAAdaptor]Execute Service :(IN DATA) [BR_MHS_EIF_REG_EQPT_PORT_TRF_STATE_IN]"; // 찾아야할 시점


                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;


                    try
                    {
                        string time = log[i].Trim().Substring(0, 22);


                        dataGridView1.Rows[row].Cells[0].Value = time;

                        string[] str = log[i + 11].Trim().Split(']');

                        dataGridView1.Rows[row].Cells[1].Value = str[0].Replace("[", "");
                        dataGridView1.Rows[row].Cells[2].Value = str[4].Replace("[", "");
                        dataGridView1.Rows[row].Cells[3].Value = str[1].Replace("[","");
                        dataGridView1.Rows[row].Cells[4].Value = str[2].Replace("[", "");

                    }
                    catch {

                        dataGridView1.Rows[row].Cells[1].Value = "ERR";
                        dataGridView1.Rows[row].Cells[2].Value = "Row :" + i.ToString();

                    }
                    row++;


                }
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "EQP", "Time", "ID", "PSTN", "Type" };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "[FAAdaptor]Execute Service :(IN DATA) [BR_PRD_CHK_INPUT_LOT_LM_L_IN]"; // 찾아야할 시점

                string strFind2 = "	[EQPT_MOUNT_PSTN_ID] 	[EQPT_MOUNT_PSTN_STATE] 	[INPUT_ID] "; // 찾아야할 시점2


                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;

                    string time = log[i].Trim().Substring(0, 22);
                    string eqp = log[i].Trim().Split(']')[1].Replace("[", "");

                    for (int j = i; j < log.Count; j++)
                    {
                        if (!log[j].Contains(strFind2)) continue;

                        string[] str = log[j + 1].Trim().Split(']');

                        if (str[1].Replace("[", "").Contains("S")) break;

                        dataGridView1.Rows[row].Cells[0].Value = eqp;
                        dataGridView1.Rows[row].Cells[1].Value = time;
                        dataGridView1.Rows[row].Cells[2].Value = str[2].Replace("[", "");
                        dataGridView1.Rows[row].Cells[3].Value = str[0].Replace("[", "");
                        dataGridView1.Rows[row].Cells[4].Value = str[1].Replace("[", "");
                        row++;
                        break;
                    }




                }
            }
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "EQP", "Time", "ID", "Lot", "PSTN", "Unmount Type","Remain Qty", "In Qty", "Out Qty", };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();


                string strFind = "[FAAdaptor]Execute Service :(IN DATA) [BR_PRD_REG_UNMOUNT_INPUT_IN_LOT_L_IN"; // 찾아야할 시점

                string strFind2 = "[EQPT_MOUNT_PSTN_ID] 	[EQPT_MOUNT_PSTN_STATE] 	[INPUT_LOTID] 	[CSTID] 	[UNMOUNT_TYPE] 	[REMAIN_TYPE]"; // 찾아야할 시점2


                for (int i = 0; i < log.Count; i++)
                {
                    if (!log[i].Contains(strFind)) continue;

                    string time = log[i].Trim().Substring(0, 22);
                    string eqp = log[i].Trim().Split(']')[1].Replace("[", "");

                    for (int j = i; j < log.Count; j++)
                    {
                        if (!log[j].Contains(strFind2)) continue;

                        string[] str = log[j + 1].Trim().Split(']');

                        if (str[1].Replace("[", "").Contains("S")) break;

                        dataGridView1.Rows[row].Cells[0].Value = eqp;
                        dataGridView1.Rows[row].Cells[1].Value = time;
                        dataGridView1.Rows[row].Cells[2].Value = str[2].Replace("[", "");
                        dataGridView1.Rows[row].Cells[3].Value = str[3].Replace("[", "");
                        dataGridView1.Rows[row].Cells[4].Value = str[0].Replace("[", "");
                        dataGridView1.Rows[row].Cells[5].Value = str[4].Replace("[", "");
                        dataGridView1.Rows[row].Cells[6].Value = str[6].Replace("[", "");
                        dataGridView1.Rows[row].Cells[7].Value = str[11].Replace("[", "");
                        dataGridView1.Rows[row].Cells[8].Value = str[12].Replace("[", "");
                        row++;
                        break;
                    }




                }
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "EQP", "Start Time", "Time", "Type" };
            initGridView(lstCols);

            dataGridView1.RowCount = 20000;


            List<string> log;
            int row = 0;

            for (int cnt = 0; cnt < cbFileName.Items.Count; cnt++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cnt].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();



                int iRptType = 0;

                for (int i = 0; i < log.Count; i++)
                {
                    if (log[i].Contains("[RCP_PARA_VALID:I_B_RCP_PARA_VALID_REQ] (Boolean) : ON")) iRptType = 1;
                    else if (log[i].Contains("[RCP_PARA_DOWN:I_B_RCP_PARA_DOWN_REQ] (Boolean) : ON")) iRptType = 2;
                    else if (log[i].Contains("[RCP_PARA_UP:I_B_RCP_PARA_UP_REQ] (Boolean) : ON")) iRptType = 3;
                    else continue;

                    string time = log[i].Trim().Substring(0, 22);
                    string eqp = log[i].Trim().Split(']')[1].Replace("[", "").Trim();

                    for (int j = i; j < log.Count; j++)
                    {
                        if (iRptType == 1 && log[j].Contains(eqp) && log[j].Contains("[RCP_PARA_VALID:O_B_RCP_PARA_VALID_CONF] (Boolean) : ON")) iRptType = 1;
                        else if (iRptType == 2 && log[j].Contains(eqp) && log[j].Contains("[RCP_PARA_DOWN:O_B_RCP_PARA_DOWN_SEND] (Boolean) : ON")) iRptType = 2;
                        else if (iRptType == 3 && log[j].Contains(eqp) && log[j].Contains("[RCP_PARA_UP:O_B_RCP_PARA_UP_CONF] (Boolean) : ON")) iRptType = 3;
                        else continue;

                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);
                                              

                        dataGridView1.Rows[row].Cells[0].Value = eqp;
                        dataGridView1.Rows[row].Cells[1].Value = time;
                        dataGridView1.Rows[row].Cells[2].Value = dt2 - dt1;

                        string str = string.Empty;

                        if (iRptType == 1) str = "RecipeValidation";
                        else if (iRptType == 2) str = "RecipeDownload";
                        else if (iRptType == 3) str = "RecipeManualUpload";

                        dataGridView1.Rows[row].Cells[3].Value = str;

                        row++;
                        break;
                    }




                }
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            List<string> lstCols = new List<string> { "TIME", "REPORT_TAG", "BIZ_RUN", "CONF_ON", "RPT_OFF" };
            initGridView(lstCols);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            List<string> log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            dataGridView1.RowCount = 10000;

            int row = 0;
            string strFind = "I_B_TRIGGER_REPORT] (Boolean) : ON";// ":I_B_CARR_ID_RPT] (Boolean) : ON"; // 찾아야할 시점

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                string time = log[i].Trim().Substring(0, 22);
                string tagName = log[i].Trim().Substring(63, log[i].Trim().Length - 63).Split(':')[0];


                dataGridView1.Rows[row].Cells[0].Value = time;
                dataGridView1.Rows[row].Cells[1].Value = tagName;

                string strFind2 = tagName + ":I_B_TRIGGER_REPORT] (Boolean) : OFF"; //이후 두번째로 찾아야할 시점

                for (int j = i; j < log.Count; j++)
                {
                    if (log[j].Contains(strFind2))
                    {
                        string strLen = log[j].Trim();
                        string end_time = log[j].Trim().Substring(0, 22);

                        DateTime dt1 = Convert.ToDateTime(time);
                        DateTime dt2 = Convert.ToDateTime(end_time);

                        dataGridView1.Rows[row].Cells[2].Value = dt2 - dt1;
                        break;
                    }
              
                }

                row++;

            }
        }
    }
    
}
