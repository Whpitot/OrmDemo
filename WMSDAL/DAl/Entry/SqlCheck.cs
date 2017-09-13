using System;
using System.Collections.Generic;
 
using System.Text;
using System.Text.RegularExpressions;

namespace DAl.Entry
{
    [System.Serializable]
  public    class SqlCheck
    {
        int _insertcount;

        public int Insertcount
        {
            get { return _insertcount; }
            set { _insertcount = value; }
        }
        int _deletecount;

        public int Deletecount
        {
            get { return _deletecount; }
            set { _deletecount = value; }
        }
        int _selectcount;

        public int Selectcount
        {
            get { return _selectcount; }
            set { _selectcount = value; }
        }
      public  SqlCheck()
      {

          _deletecount = 0;
          _insertcount = 0;
          _selectcount = 0;
      }
    public  bool CheckCond(string cond)
      { 
          bool tss=true;
          if (GetCount(cond,"@[select ]")!=_selectcount)
          {
              tss = false;
          }
          if (GetCount(cond, "@[insert ]") !=_insertcount)
          {
              tss = false;
          }
          if (GetCount(cond, "@[delete ]") != _deletecount)
          {
              tss = false;
          }

          return tss;
      }

      int GetCount(string cond,string pattar)
      {
         MatchCollection   ss = Regex.Matches(cond, pattar, RegexOptions.IgnoreCase);
         return ss.Count;

      }
    }
}
