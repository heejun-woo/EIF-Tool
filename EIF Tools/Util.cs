using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Reflection;
using Thrift;

public static class Util
{

    //=====================================================================
    //  DateTime 문자 
    //=====================================================================
    public static string DateTimeText(DateTime datetime)
    {
        string stnow = String.Format("{0:d}_", datetime);
        stnow += String.Format("{0:00}:{1:00}:{2:00}", datetime.Hour, datetime.Minute, datetime.Second);
        return stnow;
    }

    public static string DateTimeText()
    {
        return DateTimeText(DateTime.Now);
    }


    //=====================================================================
    //  시간 측정
    //=====================================================================
    public static double TimeInSeconds(DateTime stime)
    {
        TimeSpan dtime = DateTime.Now - stime;
        double dsec = (double)(dtime.Ticks / 10000000.0);
        return dsec;
    }

    //=====================================================================
    //  숫자인가? (정수, 실수 모두 true로 리턴)
    //=====================================================================
    public static bool IsNumber(string st)
    {
        double val;
        return double.TryParse(st, out val);
    }

    //=====================================================================
    //  정수인가?
    //=====================================================================
    public static bool IsInteger(string st)
    {
        int val;
        return int.TryParse(st, out val);
    }

    //=====================================================================
    //  실수의 반올림
    //=====================================================================
    public static double RoundK(double sv, int ndigit)
    {
        return Math.Round(sv, ndigit);

        // 위의 함수는 반올림 정의와 정확치 않은 경우가 있다.
        // 아래 형식을 활용하면 되긴 하는데 그럴 필요가 있는가??
        //string st = String.Format("{0:0.00}", 1.345);
    }

    //=====================================================================
    //  정수로 반올림
    //=====================================================================
    public static int Int(double sv)
    {
        return Convert.ToInt32(Util.RoundK(sv, 0));
    }

    public static int Int(float sv)
    {
        return Int(sv);
    }

    public static uint UInt(double sv)
    {
        return Convert.ToUInt32(Util.RoundK(sv, 0));
    }

    public static uint UInt(float sv)
    {
        return UInt(sv);
    }



    //=====================================================================
    //  안전 범위의 실수로 바꾸기
    //=====================================================================
    public static double ValR(double val)
    {
        if (val > double.MaxValue)
            val = double.MaxValue;
        else if (val < double.MinValue)
            val = double.MinValue;
        else if (Math.Abs(val) < 1E-30)
            val = 0.0;

        return val;
    }

    public static double ValR(string st)
    {
        double val = 0.0;
        if (double.TryParse(st, out val))
        {
            return ValR(val);
        }
        return val;
    }

    //=====================================================================
    //  수 크기에 따른 표시형식
    //=====================================================================
    public static string StrOfSmallValue(double sv)
    {
        string st;
        if (sv < 1.0e-25)
            st = "0";
        else if (Math.Abs(sv) < 1.0)
            st = string.Format("{0:0.000E-0}", sv);
        else if (Math.Abs(sv) < 100.0)
            st = string.Format("{0:#####0.00}", sv);
        else
            st = string.Format("{0:######0.0}", sv);
        return st;
    }

    //=====================================================================
    //  시간 대기
    //=====================================================================
    public static void HoldForAWhileWithDoEvents(double sec)
    {
        double dsec;
        DateTime stime = DateTime.Now;
        while (true)
        {
            Thread.Sleep(1);

            Application.DoEvents();          

            dsec = Util.TimeInSeconds(stime);
            if (dsec >= sec) break;
        }
    }

    public static void HoldForAWhileWithoutDoEvents(double sec)
    {
        double dsec;
        DateTime stime = DateTime.Now;
        while (true)
        {
            dsec = Util.TimeInSeconds(stime);
            if (dsec >= sec) break;
        }
    }

    //=====================================================================
    //  문자분리
    //=====================================================================
    public static string[] SplitString(string st, char c1)
    {
        return st.Split(c1);
    }
    public static string[] SplitString(string st, char c1, char c2)
    {
        //Char[] carr = { c1, c2 };
        //return st.Split(carr);
        return st.Split(new Char[] { c1, c2 });
    }
    public static string[] SplitString(string st, char[] carr)
    {
        return st.Split(carr);
    }



    //=====================================================================
    //  Text Box 문자 선택
    //=====================================================================
    public static void SetTextBoxAsSelectedNFocused(TextBox txt)
    {
        int leng = txt.Text.Length;
        if (leng > 0)
        {
            txt.Select(0, leng);
        }
        txt.Focus();
    }



    //=====================================================================
    //  Text 뜯어내기 함수 : Substring() 함수는 에러가 발생할 수 있어
    //                       따로 자작함
    //=====================================================================
    public static string TextLeft(string st, int length)
    {
        string rtn = "";

        if (length <= 0)
            rtn = "";
        else if (st.Length <= length)
            rtn = st;
        else
            rtn = st.Substring(0, length);

        return rtn;
    }

    public static string TextRight(string st, int length)
    {
        string rtn = "";

        if (length <= 0)
            rtn = "";
        else if (st.Length <= length)
            rtn = st;
        else
            rtn = st.Substring(st.Length - length);

        return rtn;
    }

    public static string TextMid(string st, int startidx)
    {
        string rtn = "";

        if (startidx < 0) startidx = 0;
        if (startidx >= st.Length)
            rtn = "";
        else
            rtn = st.Substring(startidx);

        return rtn;
    }

    public static string TextMid(string st, int startidx, int length)
    {
        string rtn = "";

        if (startidx < 0) startidx = 0;
        if (length <= 0)
            rtn = "";
        else if (startidx >= st.Length)
            rtn = "";
        else
        {
            if (length >= st.Length - startidx)
                rtn = st.Substring(startidx);
            else
                rtn = st.Substring(startidx, length);
        }

        return rtn;
    }

    //=====================================================================
    //  16진수로 (기억이 잘 안나서...)
    //=====================================================================
    public static string Hex(uint ival)
    {
        return String.Format("{0:X}", ival);
    }
    public static string Hex(int ival)
    {
        return String.Format("{0:X}", ival);
    }

    //=====================================================================
    //  2진수로
    //=====================================================================
    public static string Bin(uint ival)
    {
        uint pow = 1;
        string rtn = "";
        for (int i = 0; i < 32; i++)
        {
            rtn = ((ival & pow) != 0 ? "1" : "0") + rtn;
            pow *= 2;
        }
        return rtn;
    }
    public static string Bin(int ival)
    {
        return Bin((uint)ival);
    }

    //=====================================================================
    //  컨트롤의 모든 자식 컨트롤 얻기
    //  http://www.devpia.com/MAEUL/Contents/Detail.aspx?BoardID=17&MAEULNo=8&no=76292&ref=76285
    //=====================================================================
    public static Control[] GetAllControls(Control ctrl)
    {
        ArrayList allControls = new ArrayList();
        Queue queue = new Queue();

        queue.Enqueue(ctrl.Controls);

        while (queue.Count > 0)
        {
            Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();

            if (controls == null || controls.Count == 0) continue;

            foreach (Control control in controls)
            {
                allControls.Add(control);
                queue.Enqueue(control.Controls);
            }
        }

        return (Control[])allControls.ToArray(typeof(Control));
    }

    //=====================================================================
    //  컨트롤의 모든 자식 컨트롤 중 주어진 타입만 얻기
    //  (!!) 타이머는 못 찾음
    //  (예)
    //      GetAllControlsOfType(frm, typeof(TextBox));
    //=====================================================================
    public static Control[] GetAllControlsOfType(Control ctrl, System.Type type)
    {
        // 일단 모두 찾기
        Control[] ctrlAll = GetAllControls(ctrl);

        // 추려내기
        ArrayList ctrlOfType = new ArrayList();
        foreach (Control control in ctrlAll)
        {
            if (control.GetType() == type)
            {
                ctrlOfType.Add(control);
            }
        }

        return (Control[])ctrlOfType.ToArray(typeof(Control));
    }

    //=====================================================================
    //  컨트롤 안에서 주어진 이름의 자식컨트롤 찾기
    //  (예)
    //      GetControlOfName(frm, "btnEnd");
    //=====================================================================
    public static Control FindControlOfNameInCtrl(Control ctrl, string controlName)
    {
        Control rtn = null;

        ArrayList allControls = new ArrayList();
        Queue queue = new Queue();

        queue.Enqueue(ctrl.Controls);

        while (queue.Count > 0)
        {
            Control.ControlCollection controls = (Control.ControlCollection)queue.Dequeue();

            if (controls == null || controls.Count == 0) continue;

            foreach (Control ctl in controls)
            {
                if (controlName.Equals(ctl.Name))
                {
                    rtn = ctl;
                    goto EndOfFunc;
                }
                queue.Enqueue(ctl.Controls);
            }
        }
    EndOfFunc:
        return rtn;
    }

    //=====================================================================
    //  Label Box 활성화에 따른 모양 설정
    //=====================================================================
    public static void SetLabelBoxDisp(Label lbl, bool enbl)
    {
        if (enbl)
        {
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = Color.Silver;
            lbl.ForeColor = Color.Black;
        }
        else
        {
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = Color.DimGray;
            lbl.ForeColor = Color.Gray;
        }
    }



    //=====================================================================
    //  Control의 모든 속성을 복사
    //=====================================================================
    public static void copyControlProperties(Control src, Control trg)
    {
        if (src.GetType() != trg.GetType()) return;

        foreach (PropertyInfo sourceProperty in src.GetType().GetProperties())
        {
            object newValue = sourceProperty.GetValue(src, null);

            MethodInfo mi = sourceProperty.GetSetMethod(true);
            if (mi != null)
            {
                sourceProperty.SetValue(trg, newValue, null);
            }
        }
    }

}   // end of class Util


public class MultiKeyDictionary<K1, K2, V> : Dictionary<K1, Dictionary<K2, V>>
{
    public V this[K1 key1, K2 key2]
    {
        get
        {
            if (!ContainsKey(key1) || !this[key1].ContainsKey(key2))
                throw new ArgumentOutOfRangeException();
            return base[key1][key2];
        }
        set
        {
            if (!ContainsKey(key1))
                this[key1] = new Dictionary<K2, V>();
            this[key1][key2] = value;
        }
    }

    public void Add(K1 key1, K2 key2, V value)
    {
        if (!ContainsKey(key1))
            this[key1] = new Dictionary<K2, V>();
        this[key1][key2] = value;
    }

    public bool ContainsKey(K1 key1, K2 key2)
    {
        return base.ContainsKey(key1) && this[key1].ContainsKey(key2);
    }

    public new IEnumerable<V> Values
    {
        get
        {
            return from baseDict in base.Values
                   from baseKey in baseDict.Keys
                   select baseDict[baseKey];
        }
    }
}

