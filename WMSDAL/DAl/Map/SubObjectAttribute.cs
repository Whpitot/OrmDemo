using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Map
{   /// <summary>
    /// 标志聚合对象的关系，例如 主从结构
    ///  在这个函数里面我总觉得 主键 不应该是一个
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
    [Serializable]
    public class SubObjectAttribute:Attribute
    {  
        private Type _subObjectType;
        private string _primarykey;
        private string _foreignkey;
        private Type _listObjectType;

       
        /// <summary>
        /// 设置连接类型，比如单据 里面的单据体
        /// </summary>
        /// <param name="subObjectType">单据体的类型</param>
        /// <param name="primarykey">单据的主键</param>
        /// <param name="foreignkey">单据主键在，单据体里面的外键</param>
        public SubObjectAttribute(Type subObjectType,Type sublistType,string primarykey, string foreignkey)
        {
            this._subObjectType = subObjectType;
            this._primarykey = primarykey;
            this._foreignkey = foreignkey;
            this._listObjectType = sublistType;
        }
        public Type ListObjectType
        {
            get { return _listObjectType; }
            set { _listObjectType = value; }
        }
        /// <summary>
        /// 字类的类型
        /// </summary>
        public Type SubObjectType
        {
            get { return this._subObjectType;}
            set { this._subObjectType = value;}
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get { return this._primarykey;}
            set { this._primarykey = value;}
        }
        /// <summary>
        /// 外键
        /// </summary>
        public string ForeignKey
        {
            get { return this._foreignkey;}
            set { this._foreignkey = value;}
        }
        
    }
}
