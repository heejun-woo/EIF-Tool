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
    public partial class SolaceFrm : MetroFramework.Forms.MetroForm
    {

        string connStr = string.Empty;
        string selectedElmno = string.Empty;

        public SolaceFrm(MetroStyleManager manager, string str)
        {
            InitializeComponent();

            this.components.SetStyle(this, manager);

            connStr = str;

            ConnectDB();
        }

        private void ConnectDB(string str = "")
        {
            selectedElmno = string.Empty;

            treeView1.Nodes.Clear();

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "select STRUCTID, STRUCTNAME from ezControl_VAR_STRUCT A ";
            if (!string.IsNullOrWhiteSpace(str)) sql += "where a.STRUCTNAME like  '" + str + "%'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                //treeView1.Nodes.Add(Convert.ToString(mdr["STRUCTID"]), Convert.ToString(mdr["STRUCTID"]) + ":" + Convert.ToString(mdr["STRUCTNAME"]));
                treeView1.Nodes.Add(Convert.ToString(mdr["STRUCTID"]), Convert.ToString(mdr["STRUCTNAME"]));
            }
            mdr.Close();
            conn.Close();

        }

        object objLock = new object();

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                lock (objLock)
                {
                    Dictionary<string, string> varno_pr = new Dictionary<string, string>();

                    MultiKeyDictionary<string, string, string> Itemlst = new MultiKeyDictionary<string, string, string>();

                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();

                    string sql = string.Empty;

                    sql = "select b.VARNO, b.VARNAME, b.DATTYPENO, b.VARLENGTH, b.VARNO_PR from ezControl_VAR_STRUCT A, ezControl_VAR_STRUCTINFO B ";
                    sql += " where a.STRUCTID = b.STRUCTID ";
                    sql += " and b.STRUCTID = '" + e.Node.Name + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader mdr = cmd.ExecuteReader();
                    while (mdr.Read())
                    {
                        switch (Convert.ToString(mdr["DATTYPENO"]))
                        {
                            case "17":
                                varno_pr.Add(Convert.ToString(mdr["VARNO"]), Convert.ToString((mdr["VARNAME"])));
                                break;
                            default:
                                if (varno_pr.ContainsKey(Convert.ToString(mdr["VARNO_PR"])))
                                    Itemlst.Add(varno_pr[Convert.ToString(mdr["VARNO_PR"])], Convert.ToString(mdr["VARNAME"]), Convert.ToString(mdr["DATTYPENO"]));
                                break;
                        }
                    }

                    mdr.Close();
                    conn.Close();

                    string str = "public class " + e.Node.Text + "\r\n";
                    str += "{ \r\n";

                    List<string> lstPr = varno_pr.Values.ToList();

                    for (int i = 0; i < lstPr.Count; i++)
                    {
                        str += $"public {lstPr[i]}[] {lstPr[i].ToLower()}" + " { get; set; } \r\n";
                        str += $"\r\n";
                        str += $"public class {lstPr[i]} \r\n";
                        str += "{ \r\n";

                        List<string> lstItem = Itemlst[lstPr[i]].Keys.ToList();
                        List<string> lstItemType = Itemlst[lstPr[i]].Values.ToList();

                        for (int j = 0; j < lstItem.Count; j++)
                        {
                            string strType = string.Empty;

                            switch (lstItemType[j])
                            {
                                case "6":
                                    strType = "string";
                                    break;
                                case "5":
                                case "3":
                                    strType = "int";
                                    break;
                                default:
                                    strType = "string";
                                    break;
                            }

                            str += $"public {strType} {lstItem[j]}" + " { get; set; } \r\n";
                        }
                        str += "} \r\n";

                    }
                    str += "} \r\n";


                    textBox1.Text = str;

                    Clipboard.SetDataObject(textBox1.Text);

                }
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ConnectDB(textBox2.Text);
        }
    }
}

