using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Map
{
    /// <summary>
    ///针对物料类型
    /// </summary>
   [AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
   [Serializable]
   public class ItemObjectAttribute:Attribute
    {
       public ItemObjectAttribute(string _sql,string _item,Type _type) {

           _sqlField = _sql;
           _itemField = _item;
           ItemObjectType = _type;
       }
       public ItemObjectAttribute(string _sql, Type _type)
       {
           _sqlField = _sql;
           _itemField = _sql;
           ItemObjectType = _type;
       }
        private string _sqlField;  //数据库对应的字段名

        public string SqlField
        {
            get { return _sqlField; }
            set { _sqlField = value; }
        }
        private string _itemField;  //类字段id

        public string ItemField
        {
            get { return _itemField; }
            set { _itemField = value; }
        }
        private Type _ItemObjectType;//类型

        public Type ItemObjectType
        {
            get { return _ItemObjectType; }
            set { _ItemObjectType = value; }
        }
    }
}
