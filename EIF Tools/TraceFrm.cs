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
    public partial class TraceFrm : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, List<string>> dicList;

        int diclistcount = 0;

        List<string> log;

        string fontColor;

        public TraceFrm(MetroStyleManager manager)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            List<string> lstCols = new List<string> { "Data" };
            for (int i = 0; i < lstCols.Count; i++)
            {
                dataGridView1.Columns.Add(lstCols[i], lstCols[i]);
            }

            dicList = new Dictionary<string, List<string>>();

            dataGridView1.Columns[0].Width = 1200;

            fontColor = Color.Black.ToArgb().ToString();

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

        private void viewGridView()
        {
            dataGridView1.Rows.Clear();

            dicList = SortDictionary(dicList);

            if (dicList.Count > 0)
            {
                dataGridView1.RowCount = diclistcount;

                int row = 0;

                foreach (List<string> item in dicList.Values)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        string[] str = item[i].Split('|');
                        dataGridView1.Rows[row].Cells[0].Value = str[0];

                        dataGridView1.Rows[row].Cells[0].Style.ForeColor = Color.FromArgb(Convert.ToInt32(str[str.Length -1]));

                        row++;
                    }
                }
            }
        }

        private void cbFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[cbFileName.SelectedIndex].ToString(), System.Text.Encoding.Default);

            log = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                log.Add(line);
            }

            file.Close();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //string line;
            //System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);

            //log = new List<string>();
            //while ((line = file.ReadLine()) != null)
            //{
            //    log.Add(line);
            //}

            //file.Close();
        }

        private void btnConnStrEX_Click(object sender, EventArgs e)
        {
            string strFind = txtWord.Text; // 찾아야할 시점




            if (tgGroup.Checked)
            {
                for (int x = 0; x < cbText.Items.Count; x++)
                {
                    addList(log, cbText.Items[x].ToString());
                }
            }
            else addList(log, txtWord.Text);



 

            viewGridView();
            txtWord.Text = "";
        }

        private void addList(List<string> log, string strFind)
        {
            string key, value;

            for (int i = 0; i < log.Count; i++)
            {
                if (!log[i].Contains(strFind)) continue;

                key = log[i].Substring(0, 22);
                value = log[i] + "|" + fontColor; // log[i].Substring(32, log[i].Length - 32);

                if (dicList.ContainsKey(key))
                {
                    dicList[key].Add(value);
                }
                else
                {
                    dicList[key] = new List<string>() { value };
                }
                diclistcount++;
            }
        }

        public static Dictionary<string, List<string>> SortDictionary(Dictionary<string, List<string>> dict)
        {
            // 내림차순은 ascending을 descending으로 변경
            var sortVar = from item in dict
                          orderby item.Key ascending
                          select item;

            return sortVar.ToDictionary(x => x.Key, x => x.Value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dicList.Clear();
            dataGridView1.Rows.Clear();
            diclistcount = 0;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fontColor = cd.Color.ToArgb().ToString();
            }
            else { fontColor = cd.Color.ToArgb().ToString(); }


            btnColor.ForeColor = Color.FromArgb(Convert.ToInt32(fontColor));
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            cbText.Items.Add(txtWord.Text);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            cbText.Items.Clear();
        }

        private void btAllSearch_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);

            string strFind = txtWord.Text; // 찾아야할 시점

            List<string> log;

            for (int i = 0; i < cbFileName.Items.Count;i++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(cbFileName.Items[i].ToString(), System.Text.Encoding.Default);

                log = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    log.Add(line);
                }

                file.Close();

                if (tgGroup.Checked)
                {
                    for (int x = 0; x < cbText.Items.Count; x++)
                    {
                        addList(log, cbText.Items[x].ToString());
                    }
                }
                else addList(log, txtWord.Text);
            }

            viewGridView();
            txtWord.Text = "";
        }
    }
}
