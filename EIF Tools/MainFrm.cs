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
using System.Xml;
using System.Text.RegularExpressions;

namespace EIF_Tolls
{
    public partial class MainFrm : MetroFramework.Forms.MetroForm
    {

        MetroStyleManager manager;
        public MainFrm()
        {
            InitializeComponent();

            manager = this.components.SetStyle(this);

            cbPLCType.SelectedIndex = 1;


        }


        public static T[] setSizeIntArray<T>(T[] srcArray, int size)
        {
            List<T> copied = new List<T>();

            for (int loop = 0; loop < size; loop++)
            {
                if (srcArray.Length > loop)
                {
                    copied.Add(srcArray[loop]);
                }
                else
                {
                    copied.Add(default);
                }
            }

            return copied.ToArray();
        }

        public string UnescapeUnicode(string str)
        {
            Regex Regex = new Regex(@"\\[uU]([0-9A-Fa-f]{4})");

            return Regex.Replace(str,
                match => ((char)int.Parse(match.Value.Substring(2),
                    System.Globalization.NumberStyles.HexNumber)).ToString());

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            loadXml();
        }


        public string RemoveSpecialCharacterFromString(string str)
        {
            return Regex.Replace(str, @"[^a-zA-Z0-9가-힣]", string.Empty, RegexOptions.Singleline);
        }

        private void btnRMS_Click(object sender, EventArgs e)
        {    
            RMSFrm frm = new RMSFrm(manager, cbPLCType.SelectedIndex);
            frm.Show();
        }

        private void btnAPD_Click(object sender, EventArgs e)
        {
            APDFrm frm = new APDFrm(manager, cbPLCType.SelectedIndex);
            frm.Show();
        }

        private void btnAdress_Click(object sender, EventArgs e)
        {
            AddressFrm frm = new AddressFrm(manager, cbPLCType.SelectedIndex);
            frm.Show();
        }

        private void loadXml()
        {
            cbDBString.DisplayMember = "Display";
            cbDBString.ValueMember = "Value";

            XmlDocument xml = new XmlDocument();
            xml.Load("config.xml");

            XmlNodeList lst = xml.GetElementsByTagName("connectionStrings");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach(XmlNode item in lst)
            {
                cbDBString.Items.Add(new { Display = item["name"].InnerText, Value = item["string"].InnerText });
            }

            if (cbDBString.Items.Count > 1) cbDBString.SelectedIndex = 0;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            MdbEditFrm frm = new MdbEditFrm(manager, (cbDBString.SelectedItem as dynamic).Value, cbPLCType.SelectedIndex);
            frm.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LogFrm frm = new LogFrm(manager);
            frm.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            TraceFrm frm = new TraceFrm(manager);
            frm.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

            string s = "0.00001";
            double d = Double.Parse(s);
            int a;

            double dRms_Value = Double.Parse(s);
            string strRMS_Value = dRms_Value.ToString($"F{5}");

            MessageBox.Show(strRMS_Value);

            TestFrm frm = new TestFrm(manager);
            frm.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            MasterDataFrm frm = new MasterDataFrm(manager, (cbDBString.SelectedItem as dynamic).Value, cbPLCType.SelectedIndex);
            frm.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            FileMgrFrm frm = new FileMgrFrm(manager, (cbDBString.SelectedItem as dynamic).Value, cbPLCType.SelectedIndex);
            frm.Show();
        }
    }
}

public static class UnicodeExtensions
{
    private static readonly Regex Regex = new Regex(@"\\[uU]([0-9A-Fa-f]{4})");

    public static string UnescapeUnicode(this string str)
    {
        return Regex.Replace(str,
            match => ((char)int.Parse(match.Value.Substring(2),
                System.Globalization.NumberStyles.HexNumber)).ToString());
    }
}
