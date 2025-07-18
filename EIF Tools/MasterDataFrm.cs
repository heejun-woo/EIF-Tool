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
using Oracle.ManagedDataAccess.Client;

namespace EIF_Tolls
{
    public partial class MasterDataFrm : MetroFramework.Forms.MetroForm
    {
        string connStr = string.Empty;
        string selectedElmno = string.Empty;

        public MasterDataFrm(MetroStyleManager manager, string str, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            connStr = str;

            cbTable.SelectedIndex = 1;
            ckMode.Checked = true;

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

        AssemblyName SaveFile;
        FileInfo SaveFileinfo;


        private void button2_Click(object sender, EventArgs e)
        {
            VIEW(cbTable.Text);
        }


        List<int> ColType = new List<int>();

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCol(cbTable.Text);
        }

        private void SetCol(string strTable)
        {
            try
            {
                InputGrid.Columns.Clear();
                ColType = new List<int>();

                if ( connStr.Contains("ADDRESS=("))
                {
                    OracleConnection conn = new OracleConnection(connStr);
                    conn.Open();

                    string sql = "SELECT COLUMN_NAME, DATA_TYPE FROM all_tab_cols WHERE table_name = '" + strTable + "'";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataReader mdr = cmd.ExecuteReader();


                    while (mdr.Read())
                    {
                        string NAME = Convert.ToString(mdr["COLUMN_NAME"]);
                        string TYPE = Convert.ToString(mdr["DATA_TYPE"]);

                        int iType = 0;

                        switch (TYPE)
                        {
                            case "nvarchar":
                            case "VARCHAR2":
                                iType = 0;
                                break;
                            case "int":
                            case "NUMBER":
                                iType = 1;
                                break;
                            case "CLOB":
                                iType = 2;
                                break;
                            default:
                                iType = 0;
                                break;
                        }

                        InputGrid.Columns.Add(NAME, NAME);
                        ColType.Add(iType);

                    }
                    mdr.Close();
                    conn.Close();

                }
                else
                {
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();

                    string sql = "select COLUMN_NAME, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + strTable + "'";


                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    while (mdr.Read())
                    {
                        string NAME = mdr["COLUMN_NAME"].ToString();
                        string TYPE = mdr["DATA_TYPE"].ToString();

                        int iType = 0;

                        switch (TYPE)
                        {
                            case "nvarchar":
                                iType = 0;
                                break;
                            case "int":
                                iType = 1;
                                break;
                            default:
                                iType = 0;
                                break;
                        }

                        InputGrid.Columns.Add(NAME, NAME);
                        ColType.Add(iType);

                    }
                    mdr.Close();
                    conn.Close();

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VIEW(string strTable)
        {
            try
            {

                if (ckMode.Checked)
                {

                    InputGrid.Rows.Add();

                    DataGridViewRow row = (DataGridViewRow)InputGrid.Rows[0].Clone();
                    row = (DataGridViewRow)InputGrid.RowTemplate.Clone();

                    InputGrid.Rows.Clear();


                    if (connStr.Contains("ADDRESS=("))
                    {
                        OracleConnection conn = new OracleConnection(connStr);
                        conn.Open();

                        string sql = "SELECT * FROM " + strTable;

                        if (!string.IsNullOrWhiteSpace(txtWhere.Text)) sql += " WHERE " + txtWhere.Text;

                        OracleCommand cmd = new OracleCommand(sql, conn);
                        OracleDataReader mdr = cmd.ExecuteReader();

                        while (mdr.Read())
                        {
                            if (InputGrid.Rows.Count > 0) row = (DataGridViewRow)InputGrid.Rows[0].Clone();

                            for (int i = 0; i < mdr.FieldCount; i++) row.Cells[i].Value = mdr[i].ToString();

                            InputGrid.Rows.Add(row);
                        }
                        mdr.Close();
                        conn.Close();
                    }
                    else
                    {

                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();

                        string sql = "SELECT * FROM " + strTable;

                        if (!string.IsNullOrWhiteSpace(txtWhere.Text)) sql += " WHERE " + txtWhere.Text;

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader mdr = cmd.ExecuteReader();

                        while (mdr.Read())
                        {
                            if (InputGrid.Rows.Count > 0) row = (DataGridViewRow)InputGrid.Rows[0].Clone();


                            for (int i = 0; i < mdr.FieldCount; i++) row.Cells[i].Value = mdr[i].ToString();

                            InputGrid.Rows.Add(row);
                        }
                        mdr.Close();
                        conn.Close();
                    }
                }
                else
                {
                    InputGrid.Rows.Clear();
                    InputGrid.Rows.Add(500);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ckMode_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckMode.Checked)
            {
                ckMode.Text = "Select Mode";

                btnDelete.Enabled = true;
                btnINSERT.Enabled = false;
            }
            else
            {
                ckMode.Text = "Insert Mode";

                btnDelete.Enabled = false;
                btnINSERT.Enabled = true;
            }

            VIEW(cbTable.Text);
        }

        private void btnINSERT_Click(object sender, EventArgs e)
        {
            try
            {
                if (connStr.Contains("ADDRESS=("))
                {             
                    for (int i = 0; i < InputGrid.RowCount; i++)
                    {                  
                        if (string.IsNullOrWhiteSpace(InputGrid.Rows[i].Cells[0].Value + "".ToString())) break;

                        string sql = "INSERT INTO " + cbTable.Text;

                        string str = "(";
                        for (int j = 0; j < InputGrid.ColumnCount; j++)
                        {
                            if (j != 0) str += ",";

                            if (ColType[j] == 1)
                            {
                                str += InputGrid.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                str += "'" + InputGrid.Rows[i].Cells[j].Value.ToString() + "'";
                            }
                        }
                        str += ")";

                        sql += " VALUES " + str;

                        OracleConnection conn = new OracleConnection(connStr);
                        conn.Open();

                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                else
                {

                    string sql = "INSERT INTO " + cbTable.Text;

                    for (int i = 0; i < InputGrid.RowCount; i++)
                    {
                        if (string.IsNullOrWhiteSpace(InputGrid.Rows[i].Cells[0].Value + "".ToString())) break;

                        string str = "(";
                        for (int j = 0; j < InputGrid.ColumnCount; j++)
                        {

                            if (j != 0) str += ",";

                            if (ColType[j] == 1)
                            {
                                str += InputGrid.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                str += "'" + InputGrid.Rows[i].Cells[j].Value.ToString() + "'";
                            }
                        }
                        str += ")";

                        if (i == 0) sql += " VALUES " + str;
                        else sql += " , " + str;
                    }

                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                ckMode.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (connStr.Contains("ADDRESS=("))
                {
                    OracleConnection conn = new OracleConnection(connStr);
                    conn.Open();

                    string sql = string.Empty;

                    for (int i = 0; i < InputGrid.SelectedRows.Count; i++)
                    {
                        int rowidx = InputGrid.SelectedRows[i].Index;

                        string str = "";
                        for (int j = 0; j < InputGrid.ColumnCount; j++)
                        {
                            if (ColType[j] == 2 && string.IsNullOrWhiteSpace(InputGrid.Rows[rowidx].Cells[j].Value.ToString())) continue;

                            if (j != 0) str += " AND ";

                            if (ColType[j] == 2)
                            {
                                str += "TO_CHAR(" + InputGrid.Columns[j].Name + ") = ";
                            }
                            else str += InputGrid.Columns[j].Name + " = ";

                            if (ColType[j] == 1)
                            {
                                str += InputGrid.Rows[rowidx].Cells[j].Value.ToString();
                            }
                            else
                            {
                                str += "'" + InputGrid.Rows[rowidx].Cells[j].Value.ToString() + "' ";
                            }
                        }

                        sql = "DELETE FROM " + cbTable.Text + " WHERE " + str;

                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                }
                else
                {
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    string sql = string.Empty;

                    for (int i = 0; i < InputGrid.SelectedRows.Count; i++)
                    {
                        int rowidx = InputGrid.SelectedRows[i].Index;

                        string str = "";
                        for (int j = 0; j < InputGrid.ColumnCount; j++)
                        {
                            if (j != 0) str += " AND ";

                            str += InputGrid.Columns[j].Name + " = ";

                            if (ColType[j] == 1)
                            {
                                str += InputGrid.Rows[rowidx].Cells[j].Value.ToString();
                            }
                            else
                            {
                                str += "'" + InputGrid.Rows[rowidx].Cells[j].Value.ToString() + "' ";
                            }
                        }

                        sql = "DELETE FROM " + cbTable.Text + " WHERE " + str;

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                VIEW(cbTable.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
