using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    public class t_Role
    {
        /// <summary>
        /// t_Role:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
            public t_Role()
            { }
            #region Model
            private int _fitemid;
            private string _fnumber;
            private string _fname;
            private string _fremark;
            /// <summary>
            /// 
            /// </summary>
            public int FItemID
            {
                set { _fitemid = value; }
                get { return _fitemid; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FNumber
            {
                set { _fnumber = value; }
                get { return _fnumber; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FName
            {
                set { _fname = value; }
                get { return _fname; }
            }    
            /// <summary>
            /// 
            /// </summary>
            public string FRemark
            {
                set { _fremark = value; }
                get { return _fremark; }
            }
            #endregion Model
    }
}
