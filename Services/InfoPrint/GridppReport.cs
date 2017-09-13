using grproLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridppReportDemo
{
    /// <summary>
    /// GridppReport 的摘要说明。
    /// </summary>
    public class Utility
    {
        //public const string GetDatabaseConnectionString()  = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\..\..\Data\Northwind.mdb";

        //此函数用来注册Grid++Report，你必须在你的应用程序启动时调用此函数
        //用你自己的序列号代替"AAAAAAA"，"AAAAAAA"是一个无效的序列号
        public static void RegisterGridppReport()
        {
            GridppReport TempGridppReport = new GridppReport();
            bool Succeeded = TempGridppReport.Register("AAAAAAA");
            if (!Succeeded)
                System.Windows.Forms.MessageBox.Show("Register Grid++Report Failed, Grid++Report will run in trial mode.", "Register"
                    , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        // 将 DataReader 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, IDataReader dr)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dr.FieldCount; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // Loop through the contents of the OleDbDataReader object.
            // 将 DataReader 中的每一条记录转储到Grid++Report 的数据集中去
            while (dr.Read())
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        // 将 DataTable 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            double dtamount = 0;
            double dtamount2 = 0;
            string fcurrname = "";
            string fcurrname2 = "";
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }

            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                    {
                        if (MatchFieldPairs[i].grField.Name == "FCurcyName")
                        {
                            fcurrname = dr[MatchFieldPairs[i].MatchColumnIndex].ToString();
                        }
                        if (MatchFieldPairs[i].grField.Name == "FToalAmount")
                        {
                            dtamount += Convert.ToDouble(dr[MatchFieldPairs[i].MatchColumnIndex]);
                            // if (Report.FieldByName("FEngAmount") != null)
                            Report.FieldByDBName("FEngAmount").AsString = "SAY TOTAL " + fcurrname + " " + new Number2English().NumberToString(dtamount);

                        }


                        if (MatchFieldPairs[i].grField.Name == "FCurcyName2")
                        {
                            fcurrname2 = dr[MatchFieldPairs[i].MatchColumnIndex].ToString();
                        }
                        if (MatchFieldPairs[i].grField.Name == "FToalAmount2")
                        {
                            dtamount2 += Convert.ToDouble(dr[MatchFieldPairs[i].MatchColumnIndex]);
                            Report.FieldByDBName("FEngAmount2").AsString = "SAY TOTAL " + fcurrname2 + " " + new Number2English().NumberToString(dtamount2);

                        }
                        if (MatchFieldPairs[i].grField.Name == "FMEAS")
                        {
                            dtamount2 += Convert.ToDouble(dr[MatchFieldPairs[i].MatchColumnIndex]);
                            Report.FieldByDBName("FEngAmount").AsString = "SAY TOTAL " + new Number2English().NumberToString(dtamount2);
                        }
                        //MessageBox.Show(new Number2English().NumberToString(1850.00));
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                    }
                }

                Report.DetailGrid.Recordset.Post();
            }


        }

        public static uint RGBToOleColor(byte r, byte g, byte b)
        {
            return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
        }

        public static uint ColorToOleColor(System.Drawing.Color val)
        {
            return RGBToOleColor(val.R, val.G, val.B);
        }

        public static string GetSampleRootPath()
        {
            string FileName = Application.StartupPath.ToLower();
            int Index = FileName.LastIndexOf("samples");
            FileName = FileName.Substring(0, Index);
            return FileName + @"samples\";
        }

        public static string GetReportTemplatePath()
        {
            return GetSampleRootPath() + @"Reports\";
        }

        public static string GetReportDataPath()
        {
            return GetSampleRootPath() + @"Data\";
        }

        public static string GetReportDataPathFile()
        {
            return GetReportDataPath() + @"NorthWind.mdb";
        }

        public static string GetDatabaseConnectionString()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + GetReportDataPathFile();
        }
    }

    #region C#中将数字金额转成英文大写金额的函数
    public class Number2English
    {
        private readonly string[] StrNO = new string[19];
        private readonly string[] StrTens = new string[9];
        private readonly string[] Unit = new string[8];

        public string NumberToString(double Number)
        {
            string Str;
            string BeforePoint;
            string AfterPoint;
            string tmpStr;
            int nBit;
            string CurString;
            int nNumLen;
            Init();
            Str = Convert.ToString(Math.Round(Number, 2));
            if (Str.IndexOf(".") == -1)
            {
                BeforePoint = Str;
                AfterPoint = "";
            }
            else
            {
                BeforePoint = Str.Substring(0, Str.IndexOf("."));
                AfterPoint = Str.Substring(Str.IndexOf(".") + 1, Str.Length - Str.IndexOf(".") - 1);
            }
            if (BeforePoint.Length > 12)
            {
                return null;
            }
            Str = "";
            while (BeforePoint.Length > 0)
            {
                nNumLen = Len(BeforePoint);
                if (nNumLen % 3 == 0)
                {
                    CurString = Left(BeforePoint, 3);
                    BeforePoint = Right(BeforePoint, nNumLen - 3);
                }
                else
                {
                    CurString = Left(BeforePoint, (nNumLen % 3));
                    BeforePoint = Right(BeforePoint, nNumLen - (nNumLen % 3));
                }
                nBit = Len(BeforePoint) / 3;
                tmpStr = DecodeHundred(CurString);
                if ((BeforePoint == Len(BeforePoint).ToString() || nBit == 0) && Len(CurString) == 3)
                {
                    if (Convert.ToInt32(Left(CurString, 1)) != 0 & Convert.ToInt32(Right(CurString, 2)) != 0)
                    {
                        tmpStr = Left(tmpStr, tmpStr.IndexOf(Unit[3]) + Len(Unit[3])) + Unit[7] + " " +
                                 Right(tmpStr, Len(tmpStr) - (tmpStr.IndexOf(Unit[3]) + Len(Unit[3])));
                    }
                    else
                    {
                        tmpStr = Unit[7] + " " + tmpStr;
                    }
                }
                if (nBit == 0)
                {
                    Str = Convert.ToString(Str + " " + tmpStr).Trim();
                }
                else
                {
                    Str = Convert.ToString(Str + " " + tmpStr + " " + Unit[nBit - 1]).Trim();
                }
                if (Left(Str, 3) == Unit[7])
                {
                    Str = Convert.ToString(Right(Str, Len(Str) - 3)).Trim();
                }
                if (BeforePoint == Len(BeforePoint).ToString())
                {
                    return "";
                }
            }
            BeforePoint = Str;
            if (Len(AfterPoint) > 0)
            {
                AfterPoint = Unit[5] + " " + DecodeHundred(AfterPoint) + " " + Unit[6];
            }
            else
            {
                AfterPoint = Unit[4];
            }
            return (BeforePoint + " " + AfterPoint).ToUpper();
        }

        private void Init()
        {
            if (StrNO[0] != "One")
            {
                StrNO[0] = "One";
                StrNO[1] = "Two";
                StrNO[2] = "Three";
                StrNO[3] = "Four";
                StrNO[4] = "Five";
                StrNO[5] = "Six";
                StrNO[6] = "Seven";
                StrNO[7] = "Eight";
                StrNO[8] = "Nine";
                StrNO[9] = "Ten";
                StrNO[10] = "Eleven";
                StrNO[11] = "Twelve";
                StrNO[12] = "Thirteen";
                StrNO[13] = "Fourteen";
                StrNO[14] = "Fifteen";
                StrNO[15] = "Sixteen";
                StrNO[16] = "Seventeen";
                StrNO[17] = "Eighteen";
                StrNO[18] = "Nineteen";
                StrTens[0] = "Ten";
                StrTens[1] = "Twenty";
                StrTens[2] = "Thirty";
                StrTens[3] = "Forty";
                StrTens[4] = "Fifty";
                StrTens[5] = "Sixty";
                StrTens[6] = "Seventy";
                StrTens[7] = "Eighty";
                StrTens[8] = "Ninety";
                Unit[0] = "Thousand";
                Unit[1] = "Million";
                Unit[2] = "Billion";
                Unit[3] = "Hundred";
                Unit[4] = "Only";
                Unit[5] = "Dollars and";
                Unit[6] = "Cent";
                Unit[7] = "";
            }
        }

        private string DecodeHundred(string HundredString)
        {
            int tmp;
            string rtn = "";
            if (Len(HundredString) > 0 && Len(HundredString) <= 3)
            {
                switch (Len(HundredString))
                {
                    case 1:
                        tmp = Convert.ToInt32(HundredString);
                        if (tmp != 0)
                        {
                            rtn = StrNO[tmp - 1];
                        }
                        break;
                    case 2:
                        tmp = Convert.ToInt32(HundredString);
                        if (tmp != 0)
                        {
                            if ((tmp < 20))
                            {
                                rtn = StrNO[tmp - 1];
                            }
                            else
                            {
                                if (Convert.ToInt32(Right(HundredString, 1)) == 0)
                                {
                                    rtn = StrTens[Convert.ToInt32(tmp / 10) - 1];
                                }
                                else
                                {
                                    rtn =
                                            Convert.ToString(StrTens[Convert.ToInt32(tmp / 10) - 1] + " " +
                                                             StrNO[Convert.ToInt32(Right(HundredString, 1)) - 1]);
                                }
                            }
                        }
                        break;
                    case 3:
                        if (Convert.ToInt32(Left(HundredString, 1)) != 0)
                        {
                            rtn =
                                    Convert.ToString(StrNO[Convert.ToInt32(Left(HundredString, 1)) - 1] + " " + Unit[3] +
                                                     "AND " +
                                                     DecodeHundred(Right(HundredString, 2)));
                        }
                        else
                        {
                            rtn = DecodeHundred(Right(HundredString, 2));
                        }
                        break;
                    default:
                        break;
                }
            }
            return rtn;
        }

        private string Left(string str, int n)
        {
            return str.Substring(0, n);
        }

        private string Right(string str, int n)
        {
            return str.Substring(str.Length - n, n);
        }

        private int Len(string str)
        {
            return str.Length;
        }
    }
    #endregion
}
