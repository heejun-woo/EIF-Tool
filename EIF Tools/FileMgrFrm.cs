using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace EIF_Tolls
{
    public partial class FileMgrFrm : MetroFramework.Forms.MetroForm
    {
        string connStr = string.Empty;
        string selectedElmno = string.Empty;

        public FileMgrFrm(MetroStyleManager manager, string str, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            connStr = str;



        }

        AssemblyName SaveFile;
        FileInfo SaveFileinfo;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "dll files (*.dll)|*.dll";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lb_SelectFile.Text = openFileDialog.FileName;
                    SaveFileinfo = new FileInfo(openFileDialog.FileName);

                    Assembly asm = Assembly.LoadFrom(openFileDialog.FileName);
                    SaveFile = asm.GetName();

                    txtCommnet.Text = string.Empty;
                    lbDateTime.Text = SaveFile.Version.ToString();
                    lbDateTime.Text = SaveFileinfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lb_SelectFile.Text)) return;

            int Seq = 0;

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "select isnull(Max(FileID), 0) as no from TB_EIF_FILE_STND";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                Seq = Convert.ToInt32(mdr["no"]) + 1;
            }
            mdr.Close();

            sql = "INSERT INTO TB_EIF_FILE_STND (FileID, Name, Version, DateTime, Data, UseYn, Size, Commnet) ";
            sql += " SELECT " + Seq + ", '" + SaveFileinfo.Name + "', '" + SaveFile.Version.ToString() + "', '" + SaveFileinfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss") + "', BulkColumn, 'N', '" + SaveFileinfo.Length + "', '" + txtCommnet.Text +"'";
            sql += " FROM OPENROWSET (BULK N'" + lb_SelectFile.Text + "', SINGLE_BLOB) AS PIC";

            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            lb_SelectFile.Text = string.Empty;

            VIEW();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VIEW();
        }

        private void VIEW()
        {
            dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "SELECT FileID, Name, Version ,DateTime, UseYn ,Size ,Commnet  FROM TB_EIF_FILE_STND";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string FileID = mdr["FileID"].ToString();
                string FileName = mdr["Name"].ToString();
                string Version = mdr["Version"].ToString();
                string DateTime = mdr["DateTime"].ToString();
                string Use = mdr["UseYn"].ToString();
                string Size = mdr["Size"].ToString();
                string Commnet = mdr["Commnet"].ToString();

                dataGridView1.Rows.Add(FileID, FileName, Version, DateTime, Use, Size, Commnet);
            }
            mdr.Close();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectIdx = dataGridView1.SelectedRows[0].Index;

            string FileID = dataGridView1.Rows[selectIdx].Cells[0].Value.ToString();
            string Name = dataGridView1.Rows[selectIdx].Cells[1].Value.ToString();


            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "UPDATE TB_EIF_FILE_STND SET UseYn ='N' WHERE Name  ='" + Name + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            sql = "UPDATE TB_EIF_FILE_STND SET UseYn ='Y' WHERE FileID  = " + FileID;

            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            VIEW();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIdx = dataGridView1.SelectedRows[0].Index;

                if (selectIdx > dataGridView1.RowCount - 1) return;
                if (selectIdx < 0) return;

                lbVersion.Text = dataGridView1.Rows[selectIdx].Cells[2].Value.ToString();
                lbDateTime.Text = dataGridView1.Rows[selectIdx].Cells[3].Value.ToString();
                txtCommnet.Text = dataGridView1.Rows[selectIdx].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectIdx = dataGridView1.SelectedRows[0].Index;

            string FileID = dataGridView1.Rows[selectIdx].Cells[0].Value.ToString();

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "DELETE FROM TB_EIF_FILE_STND WHERE FileID  = " + FileID;

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            VIEW();
        }
    }
}
