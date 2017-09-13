using System;
using System.Collections.Generic;
using System.Text;

namespace WMSDAL.Map
{
    /// <summary>
    /// 表结构映射,主键放在表结构里面
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
    [Serializable]
    public class TableMapAttribute:Attribute
    {
        private string _tablename;
        private string _primarykey;
       /// <summary>
       /// 表的描叙信息
       /// </summary>
       /// <param name="tablename">表名</param>
       /// <param name="primarkey">表的主键</param>
        public TableMapAttribute(string tablename,  string primarkey)
        {
            this._tablename = tablename;
            this._primarykey = primarkey;
        }
       /// <summary>
       /// 表名
       /// </summary>
        public string TableName
        {
            get { return this._tablename; }
            set { this._tablename = value; }
        }
       /// <summary>
       ///主键
       /// </summary>
        public string PrimaryKey
        {
            get { return this._primarykey; }
            set { this._primarykey = value; }
        }
    }
}
