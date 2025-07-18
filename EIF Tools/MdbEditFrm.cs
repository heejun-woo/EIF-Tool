using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EIF_Tolls
{
    public partial class MdbEditFrm : MetroFramework.Forms.MetroForm
    {
        string connStr = string.Empty;
        string selectedElmno = string.Empty;

        public MdbEditFrm(MetroStyleManager manager, string str, int plcType)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            connStr = str;

            ConnectDB();

            if (plcType == 1) btnConnStrEX.Visible = false;

        }

        private void ConnectDB()
        {
            selectedElmno = string.Empty;

            treeView1.Nodes.Clear();
            clear();
            if (connStr.Contains("ADDRESS=("))
            {
                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                string sql = "select elmno, ELMNAME FROM ezControl_ELM E WHERE E.LOGICCATNO = '1004' ORDER BY ELMID, to_char(ELMNAME)";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    treeView1.Nodes.Add(Convert.ToString(mdr["elmno"]), Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME"]));
                    getElmList(treeView1.Nodes.Count - 1, Convert.ToString(mdr["elmno"]));
                }
                mdr.Close();
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string sql = "select elmno, ELMNAME FROM ezControl_ELM E WHERE E.LOGICCATNO = '1004' ORDER BY ELMID, ELMNAME";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    treeView1.Nodes.Add(Convert.ToString(mdr["elmno"]), Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME"]));
                    getElmList(treeView1.Nodes.Count - 1, Convert.ToString(mdr["elmno"]));
                }
                mdr.Close();
                conn.Close();
            }

                checkedListBox1.Items.Clear();
        }
        private void clear()
        {
            treeView3.Nodes.Clear();
            label3.Text = "";
            textBox2.Text = "";
            btEXE.Enabled = false;
            btnGroup.Enabled = false;
        }

        public void getElmList(int nodeidx, string elmno)
        {
            if (connStr.Contains("ADDRESS=("))
            {
                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                string sql = "select elmno, ELMNAME FROM ezControl_ELM E WHERE E.LOGICCATNO = '1002' and ELMNO_PR = '" + elmno + "' order by ELMID, to_char(ELMNAME)";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    treeView1.Nodes[nodeidx].Nodes.Add(Convert.ToString(mdr["elmno"]), Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME"]));
                    getElmList(treeView1.Nodes.Count - 1, Convert.ToString(mdr["elmno"]));
                }
                mdr.Close();
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string sql = "select elmno, ELMNAME FROM ezControl_ELM E WHERE E.LOGICCATNO = '1002' and ELMNO_PR = '" + elmno + "' order by ELMID, ELMNAME";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    treeView1.Nodes[nodeidx].Nodes.Add(Convert.ToString(mdr["elmno"]), Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME"]));
                    getElmList(treeView1.Nodes.Count - 1, Convert.ToString(mdr["elmno"]));
                }
                mdr.Close();
                conn.Close();
            }

        }

        private void tgGubun_CheckedChanged(object sender, EventArgs e)
        {
            if (tgGubun.Checked)
            {
                lbGubun.Text = "VAL";
                this.lbGubun.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                lbGubun.Text = "CNN";
                this.lbGubun.ForeColor = System.Drawing.Color.MediumSeaGreen;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            checkedListBox1.Items.Clear();
            clear();

            if (connStr.Contains("ADDRESS=("))
            {
                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                selectedElmno = e.Node.Name;

                string sql = string.Empty;

                sql = "select elmno, (select to_char(ELMNAME)  FROM ezControl_ELM  WHERE e.ELMNO_PR = ELMNO) as ELMNAME_PR, to_char(ELMNAME) as ELMNAME, E.LOGICCATNO FROM ezControl_ELM E, ";
                sql += "(select c.LOGICNO, c.LOGICCATNO from  ezControl_ELM E, ezControl_LOGIC C where e.ELMNO = '" + e.Node.Name + "' and e.LOGICNO = c.LOGICNO and e.LOGICCATNO = c.LOGICCATNO and rownum = 1)  X ";
                sql += "WHERE  E.LOGICNO = X.LOGICNO and E.LOGICCATNO = X.LOGICCATNO ";

                if (rbSort1.Checked) sql += " order by ELMID, to_char(ELMNAME) ";
                else sql += " order by ELMNAME_PR";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    if (selectedElmno.Equals(Convert.ToString(mdr["elmno"]))) continue;
                    checkedListBox1.Items.Add(Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME_PR"]) + ":" + Convert.ToString(mdr["ELMNAME"]), checkBox1.Checked);
                }
                mdr.Close();

                treeView2.Nodes.Clear();

                if (!tgGubun.Checked)
                {
                    sql = " SELECT  substr(VARNAME, 0, INSTR(VARNAME, ':') -1 ) AS CAT ";
                    sql += "FROM ezControl_VAR_INTERNAL_CNN ";
                    sql += "where ELMNO = '" + e.Node.Name + "'  ";
                    sql += " GROUP BY  substr(VARNAME, 0, INSTR(VARNAME, ':') -1 ) order by CAT";
                }
                else
                {
                    sql = " SELECT  substr(VARNAME, 0, INSTR(VARNAME, ':') -1 ) AS CAT ";
                    sql += "FROM ezControl_VAR_INTERNAL_VAL ";
                    sql += "where ELMNO = '" + e.Node.Name + "'  ";
                    sql += " GROUP BY substr(VARNAME, 0, INSTR(VARNAME, ':') -1 )  order by CAT";
                }


                cmd = new OracleCommand(sql, conn);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    treeView2.Nodes.Add(Convert.ToString(mdr["CAT"]), Convert.ToString(mdr["CAT"]));
                }
                mdr.Close();
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                selectedElmno = e.Node.Name;

                string sql = string.Empty;

                sql = "select elmno, (select ELMNAME FROM ezControl_ELM  WHERE e.ELMNO_PR = ELMNO) as ELMNAME_PR, ELMNAME, E.LOGICCATNO FROM ezControl_ELM E, ";
                sql += "(select top 1 c.LOGICNO, c.LOGICCATNO from  ezControl_ELM E, ezControl_LOGIC C where e.ELMNO = '" + e.Node.Name + "' and e.LOGICNO = c.LOGICNO and e.LOGICCATNO = c.LOGICCATNO)  X ";
                sql += "WHERE  E.LOGICNO = X.LOGICNO and E.LOGICCATNO = X.LOGICCATNO ";

                if (rbSort1.Checked) sql += " order by ELMID, ELMNAME";
                else sql += " order by ELMNAME_PR";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    if (selectedElmno.Equals(Convert.ToString(mdr["elmno"]))) continue;
                    checkedListBox1.Items.Add(Convert.ToString(mdr["elmno"]) + ":" + Convert.ToString(mdr["ELMNAME_PR"]) + ":" + Convert.ToString(mdr["ELMNAME"]), checkBox1.Checked);
                }
                mdr.Close();

                treeView2.Nodes.Clear();

                if (!tgGubun.Checked)
                {
                    sql = " SELECT LEFT(VARNAME, CHARINDEX(':', VARNAME ) -1 ) AS CAT ";
                    sql += "FROM ezControl_VAR_INTERNAL_CNN ";
                    sql += "where ELMNO = '" + e.Node.Name + "'  ";
                    sql += " GROUP BY LEFT(VARNAME, CHARINDEX(':', VARNAME) - 1)  order by CAT";
                }
                else
                {
                    sql = " SELECT LEFT(VARNAME, CHARINDEX(':', VARNAME ) -1 ) AS CAT ";
                    sql += "FROM ezControl_VAR_INTERNAL_VAL ";
                    sql += "where ELMNO = '" + e.Node.Name + "'  ";
                    sql += " GROUP BY LEFT(VARNAME, CHARINDEX(':', VARNAME) - 1)  order by CAT";
                }


                cmd = new SqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    treeView2.Nodes.Add(Convert.ToString(mdr["CAT"]), Convert.ToString(mdr["CAT"]));
                }
                mdr.Close();
                conn.Close();
            }

        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selectedStr = e.Node.Name;

            clear();

            if (connStr.Contains("ADDRESS=("))
            {
                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                string sql = string.Empty;

                if (!tgGubun.Checked)
                {
                    sql = "SELECT RIGHT(VARNAME, LEN(VARNAME) - CHARINDEX(':', VARNAME)) AS NAME, VARCNNINFO, VARNAME ";
                    sql += " FROM ezControl_VAR_INTERNAL_CNN ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME like '" + selectedStr + "%' ";
                    sql += " ORDER BY VARNAME";
                }
                else
                {
                    sql = "SELECT RIGHT(VARNAME, LEN(VARNAME) - CHARINDEX(':', VARNAME)) AS NAME, VARVALUE, VARNAME ";
                    sql += " FROM ezControl_VAR_INTERNAL_VAL ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME like '" + selectedStr + "%' ";
                    sql += " ORDER BY VARNAME";
                }

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    if (!tgGubun.Checked)
                    {
                        treeView3.Nodes.Add(Convert.ToString(mdr["VARCNNINFO"]), Convert.ToString(mdr["VARNAME"]));
                    }
                    else
                    {
                        treeView3.Nodes.Add(Convert.ToString(mdr["VARVALUE"]), Convert.ToString(mdr["VARNAME"]));
                    }
                }

                mdr.Close();
                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string sql = string.Empty;

                if (!tgGubun.Checked)
                {
                    sql = "SELECT RIGHT(VARNAME, LEN(VARNAME) - CHARINDEX(':', VARNAME)) AS NAME, VARCNNINFO, VARNAME ";
                    sql += " FROM ezControl_VAR_INTERNAL_CNN ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME like '" + selectedStr + "%' ";
                    sql += " ORDER BY VARNAME";
                }
                else
                {
                    sql = "SELECT RIGHT(VARNAME, LEN(VARNAME) - CHARINDEX(':', VARNAME)) AS NAME, VARVALUE, VARNAME ";
                    sql += " FROM ezControl_VAR_INTERNAL_VAL ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME like '" + selectedStr + "%' ";
                    sql += " ORDER BY VARNAME";
                }


                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    if (!tgGubun.Checked)
                    {
                        treeView3.Nodes.Add(Convert.ToString(mdr["VARCNNINFO"]), Convert.ToString(mdr["VARNAME"]));
                    }
                    else
                    {
                        treeView3.Nodes.Add(Convert.ToString(mdr["VARVALUE"]), Convert.ToString(mdr["VARNAME"]));
                    }
                }

                mdr.Close();
                conn.Close();
            }

        }

        private void btEXE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label3.Text)) return;

            if (MessageBox.Show("적용 하시겠습니까? ", "확인", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            if (connStr.Contains("ADDRESS=("))
            {
                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                string sql = string.Empty;

                if (!tgGubun.Checked)
                {
                    string strDrvElmNo = string.Empty, strDrvNo = string.Empty;

                    #region DrvNo 가져오기
                    sql = "Select Top 1 *  FROM ezControl_VAR_INTERNAL_CNN A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " order by DRVELMNO desc ";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleDataReader mdr = cmd.ExecuteReader();

                    while (mdr.Read())
                    {
                        strDrvElmNo = Convert.ToString(mdr["DRVELMNO"]);
                        strDrvNo = Convert.ToString(mdr["DRVNO"]);
                    }
                    mdr.Close();
                    #endregion

                    sql = "UPDATE A SET VARCNNINFO = '" + textBox2.Text + "', DRVELMNO = '" + strDrvElmNo + "', DRVNO = '" + strDrvNo + "'  ";
                    sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME = '" + label3.Text + "' ";

                    cmd = new OracleCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        string idx = checkedListBox1.CheckedItems[i].ToString().Split(':')[0];

                        #region DrvNo 가져오기
                        sql = "Select Top 1 *  FROM ezControl_VAR_INTERNAL_CNN A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " order by DRVELMNO desc ";

                        cmd = new OracleCommand(sql, conn);
                        mdr = cmd.ExecuteReader();

                        while (mdr.Read())
                        {
                            strDrvElmNo = Convert.ToString(mdr["DRVELMNO"]);
                            strDrvNo = Convert.ToString(mdr["DRVNO"]);
                        }
                        mdr.Close();
                        #endregion

                        #region 존재여부 체크
                        sql = "Select top 1 VARCNNINFO ";
                        sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " and VARNAME = '" + label3.Text + "' ";

                        cmd = new OracleCommand(sql, conn);
                        mdr = cmd.ExecuteReader();

                        bool chk = mdr.HasRows;

                        mdr.Close();
                        #endregion

                        if (chk)
                        {
                            #region 존재하면 Update
                            sql = "UPDATE A SET VARCNNINFO = '" + textBox2.Text + "', DRVELMNO = '" + strDrvElmNo + "', DRVNO = '" + strDrvNo + "'  ";
                            sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                            sql += " where ELMNO = '" + idx + "' ";
                            sql += " and VARNAME = '" + label3.Text + "' ";

                            cmd = new OracleCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 신규 생성
                            sql = "INSERT INTO ezControl_VAR_INTERNAL_CNN ";
                            sql += " VALUES ('" + idx + "', '" + label3.Text + "', '" + strDrvElmNo + "', '" + strDrvNo + "',  '" + textBox2.Text + "' )";

                            cmd = new OracleCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }

                        mdr.Close();

                    }
                }
                else
                {
                    sql = "UPDATE A SET VARVALUE = '" + textBox2.Text + "' ";
                    sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME = '" + label3.Text + "' ";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        string idx = checkedListBox1.CheckedItems[i].ToString().Split(':')[0];

                        #region 존재여부 체크
                        sql = "Select top 1 VARVALUE ";
                        sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " and VARNAME = '" + label3.Text + "' ";

                        cmd = new OracleCommand(sql, conn);
                        OracleDataReader mdr = cmd.ExecuteReader();

                        bool chk = mdr.HasRows;

                        mdr.Close();
                        #endregion

                        if (chk)
                        {
                            #region 존재하면 Update
                            sql = "UPDATE A SET VARVALUE = '" + textBox2.Text + "' ";
                            sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                            sql += " where ELMNO = '" + idx + "' ";
                            sql += " and VARNAME = '" + label3.Text + "' ";

                            cmd = new OracleCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 신규 생성
                            sql = "INSERT INTO ezControl_VAR_INTERNAL_VAL ";
                            sql += " VALUES ('" + idx + "', '" + label3.Text + "', '" + textBox2.Text + "' )";

                            cmd = new OracleCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }


                        mdr.Close();

                    }

                }

                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string sql = string.Empty;

                if (!tgGubun.Checked)
                {
                    string strDrvElmNo = string.Empty, strDrvNo = string.Empty;

                    #region DrvNo 가져오기
                    sql = "Select Top 1 *  FROM ezControl_VAR_INTERNAL_CNN A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " order by DRVELMNO desc ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader mdr = cmd.ExecuteReader();

                    while (mdr.Read())
                    {
                        strDrvElmNo = Convert.ToString(mdr["DRVELMNO"]);
                        strDrvNo = Convert.ToString(mdr["DRVNO"]);
                    }
                    mdr.Close();
                    #endregion

                    sql = "UPDATE A SET VARCNNINFO = '" + textBox2.Text + "', DRVELMNO = '" + strDrvElmNo + "', DRVNO = '" + strDrvNo + "'  ";
                    sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME = '" + label3.Text + "' ";

                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        string idx = checkedListBox1.CheckedItems[i].ToString().Split(':')[0];

                        #region DrvNo 가져오기
                        sql = "Select Top 1 *  FROM ezControl_VAR_INTERNAL_CNN A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " order by DRVELMNO desc ";

                        cmd = new SqlCommand(sql, conn);
                        mdr = cmd.ExecuteReader();

                        while (mdr.Read())
                        {
                            strDrvElmNo = Convert.ToString(mdr["DRVELMNO"]);
                            strDrvNo = Convert.ToString(mdr["DRVNO"]);
                        }
                        mdr.Close();
                        #endregion

                        #region 존재여부 체크
                        sql = "Select top 1 VARCNNINFO ";
                        sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " and VARNAME = '" + label3.Text + "' ";

                        cmd = new SqlCommand(sql, conn);
                        mdr = cmd.ExecuteReader();

                        bool chk = mdr.HasRows;

                        mdr.Close();
                        #endregion

                        if (chk)
                        {
                            #region 존재하면 Update
                            sql = "UPDATE A SET VARCNNINFO = '" + textBox2.Text + "', DRVELMNO = '" + strDrvElmNo + "', DRVNO = '" + strDrvNo + "'  ";
                            sql += " FROM ezControl_VAR_INTERNAL_CNN A ";
                            sql += " where ELMNO = '" + idx + "' ";
                            sql += " and VARNAME = '" + label3.Text + "' ";

                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 신규 생성
                            sql = "INSERT INTO ezControl_VAR_INTERNAL_CNN ";
                            sql += " VALUES ('" + idx + "', '" + label3.Text + "', '" + strDrvElmNo + "', '" + strDrvNo + "',  '" + textBox2.Text + "' )";

                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }

                        mdr.Close();

                    }
                }
                else
                {
                    sql = "UPDATE A SET VARVALUE = '" + textBox2.Text + "' ";
                    sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                    sql += " where ELMNO = '" + selectedElmno + "' ";
                    sql += " and VARNAME = '" + label3.Text + "' ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        string idx = checkedListBox1.CheckedItems[i].ToString().Split(':')[0];

                        #region 존재여부 체크
                        sql = "Select top 1 VARVALUE ";
                        sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                        sql += " where ELMNO = '" + idx + "' ";
                        sql += " and VARNAME = '" + label3.Text + "' ";

                        cmd = new SqlCommand(sql, conn);
                        SqlDataReader mdr = cmd.ExecuteReader();

                        bool chk = mdr.HasRows;

                        mdr.Close();
                        #endregion

                        if (chk)
                        {
                            #region 존재하면 Update
                            sql = "UPDATE A SET VARVALUE = '" + textBox2.Text + "' ";
                            sql += " FROM ezControl_VAR_INTERNAL_VAL A ";
                            sql += " where ELMNO = '" + idx + "' ";
                            sql += " and VARNAME = '" + label3.Text + "' ";

                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 신규 생성
                            sql = "INSERT INTO ezControl_VAR_INTERNAL_VAL ";
                            sql += " VALUES ('" + idx + "', '" + label3.Text + "', '" + textBox2.Text + "' )";

                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            #endregion
                        }


                        mdr.Close();

                    }

                }

                conn.Close();
            }

            MessageBox.Show("완료했습니다.");

            clear();
        }

        private void treeView3_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            label3.Text = e.Node.Text;
            textBox2.Text = e.Node.Name;
            label3.BackColor = Color.Red;
            btEXE.Enabled = true;

            if (tgGroup.Checked && tgGubun.Checked == false)
            {
                btnGroup.Enabled = true;
            }
        }

        private void btnConnStrEX_Click(object sender, EventArgs e)
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


            string sql = string.Empty;



            if (connStr.Contains("ADDRESS=("))
            {
                sql += " select TO_CHAR(C.VARCNNINFO) AS VARCNNINFO ";
                sql += "from ezControl_VAR_INTERNAL_CNN C ";
                sql += "join(select e.ELMNO from ezControl_ELM e where e.useflag = 1 and (e.ELMNO = '" + selectedElmno + "' or e.ELMNO_PR = '" + selectedElmno + "')) e ";
                sql += "on c.ELMNO = e.ELMNO ";
                sql += "where LENGTH(c.VARCNNINFO) > 0 ";
                sql += "AND NOT C.VARNAME LIKE '%:O_%' ";

                sql += "UNION ";
                sql += " select TO_CHAR(C.VARCNNINFO) AS VARCNNINFO ";
                sql += "from ezControl_VAR C ";
                sql += "join(select e.ELMNO from ezControl_ELM e where e.useflag = 1 and (e.ELMNO = '" + selectedElmno + "' or e.ELMNO_PR = '" + selectedElmno + "')) e ";
                sql += "on c.ELMNO = e.ELMNO ";
                sql += "where LENGTH(c.VARCNNINFO) > 0 ";
                sql += "AND NOT C.VARNAME LIKE '%:O_%' ";

                OracleConnection conn = new OracleConnection(connStr);
                conn.Open();

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    string[] strAddr = Convert.ToString(mdr["VARCNNINFO"]).Trim().Replace(" ", "").Split(',');
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

                    strDevNo = strDevNo.Split('.')[0];
                    if (strType.Equals("B") || strType.Equals("W") || strType.Equals("X") || strType.Equals("Y") || strType.Equals("SB"))
                        iDev = Convert.ToInt32(strDevNo, 16);
                    else
                    {
                        if (strDevNo.Equals("XXX")) continue;
                        iDev = Convert.ToInt32(strDevNo);
                    }


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
                mdr.Close();

            }
            else
            {
                sql += " select C.VARCNNINFO AS VARCNNINFO ";
                sql += "from ezControl_VAR_INTERNAL_CNN C ";
                sql += "join(select e.ELMNO from ezControl_ELM e where e.useflag = 1 and (e.ELMNO = '" + selectedElmno + "' or e.ELMNO_PR = '" + selectedElmno + "')) e ";
                sql += "on c.ELMNO = e.ELMNO ";
                sql += "where LEN(c.VARCNNINFO) > 0 ";
                sql += "AND NOT C.VARNAME LIKE '%:O_%' ";

                sql += "UNION ";
                sql += " select C.VARCNNINFO AS VARCNNINFO ";
                sql += "from ezControl_VAR C ";
                sql += "join(select e.ELMNO from ezControl_ELM e where e.useflag = 1 and (e.ELMNO = '" + selectedElmno + "' or e.ELMNO_PR = '" + selectedElmno + "')) e ";
                sql += "on c.ELMNO = e.ELMNO ";
                sql += "where LEN(c.VARCNNINFO) > 0 ";
                sql += "AND NOT C.VARNAME LIKE '%:O_%' ";

                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    string[] strAddr = Convert.ToString(mdr["VARCNNINFO"]).Trim().Replace(" ", "").Split(',');
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

                    strDevNo = strDevNo.Split('.')[0];
                    if (strType.Equals("B") || strType.Equals("W") || strType.Equals("X") || strType.Equals("Y") || strType.Equals("SB"))
                        iDev = Convert.ToInt32(strDevNo, 16);
                    else
                    {
                        if (strDevNo.Equals("XXX")) continue;
                        iDev = Convert.ToInt32(strDevNo);
                    }


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
                mdr.Close();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, checkBox1.Checked ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("적용 하시겠습니까? ", "확인", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string strCategory = label3.Text.Split(':')[0];

            string sql = string.Empty;

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string idx = checkedListBox1.CheckedItems[i].ToString().Split(':')[0];

                string strDrvElmNo = string.Empty, strDrvNo = string.Empty;

                #region DrvNo 가져오기
                sql = "Select Top 1 *  FROM ezControl_VAR_INTERNAL_CNN ";
                sql += " where ELMNO = '" + idx + "' ";
                sql += " order by DRVELMNO desc ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    strDrvElmNo = Convert.ToString(mdr["DRVELMNO"]);
                    strDrvNo = Convert.ToString(mdr["DRVNO"]);
                }
                mdr.Close();
                #endregion

                #region 기존 항목 삭제
                sql = "DELETE FROM ezControl_VAR_INTERNAL_CNN ";
                sql += " where ELMNO = '" + idx + "' ";
                sql += " and VARNAME like '" + strCategory + ":%'";

                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                #endregion

                #region 삭제 후 복사
                sql = "INSERT INTO ezControl_VAR_INTERNAL_CNN ";
                sql += " select '" + idx + "' , VARNAME, '" + strDrvElmNo + "' , '" + strDrvNo + "' , VARCNNINFO ";
                sql += " FROM ezControl_VAR_INTERNAL_CNN ";
                sql += " WHERE ELMNO = '" + selectedElmno + "' ";
                sql += " and VARNAME like '" + strCategory + ":%'";

                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                #endregion
            }

            conn.Close();

            MessageBox.Show("완료했습니다.");

            clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
