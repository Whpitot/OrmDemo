using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DAl.Map
{
    /// <summary>
    /// 需要提交的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
    [Serializable]
    public class FieldMapAttribute:Attribute
    {
       /// <summary>
       /// 名称
       /// </summary>
        private string _columnName;
        private DbType _dbtype;  // 这个类型 限制太多
        private object _defaultvalue;
        private bool _IsIdentity;
        private bool _canrepeat;//能否重复
        private bool _MustInput;//必填字段
       /// <summary>
       /// 数据库字段描叙
       /// </summary>
       /// <param name="columnName">名称</param>
       /// <param name="dbtype">数据库类型</param>
     

        public FieldMapAttribute(string columnName,DbType dbtype)
        {
         this._columnName = columnName;
         this._dbtype = dbtype;
         this._IsIdentity = false;
         this.CanRepeat = true;
         this._MustInput = false;
        }
        public FieldMapAttribute(string columnName, DbType dbtype,bool mustinput)
        {
            this._columnName = columnName;
            this._dbtype = dbtype;
            this._MustInput = mustinput;
            this._IsIdentity = false;
            this.CanRepeat = true;
            
        }
        public FieldMapAttribute(string columnName, DbType dbtype, bool isidentity,bool canrepeat)
        {
            this._columnName = columnName;
            this._dbtype = dbtype;
            this._IsIdentity = isidentity;
            this._canrepeat = canrepeat;
            this._MustInput = false;
        }
        public FieldMapAttribute(string columnName, DbType dbtype, object defaultvalue, bool mustinput)
        {
            this._columnName = columnName;
             this._dbtype = dbtype;
            this._defaultvalue = defaultvalue;
            this._MustInput = mustinput;
            this._IsIdentity = false;
            this._canrepeat= true;
        }
        /// <summary>
        /// 能否重复
        /// </summary>
        public bool CanRepeat
        {
            get { return _canrepeat; }
            set { _canrepeat = value; }
        }
       /// <summary>
       /// 字段名字
       /// </summary>
        public string ColumnName
        {
            get { return this._columnName; }
            set { this._columnName = value; }
        }
       /// <summary>
       /// 字段类型
       /// </summary>
       public DbType DbType
       {
           get { return this._dbtype; }
           set { this._dbtype = value; }
       }
        /// <summary>
        ///是否自增
        /// </summary>
        public bool IsIdentity
        {
            get { return _IsIdentity; }
            set { _IsIdentity = value; }
        }
       /// <summary>
       /// 默认值
       /// </summary>
        public object DefaultValue
        {
            get { return this._defaultvalue; }
            set { this._defaultvalue = value; }
        }

        /// <summary>
        ///必填项
        /// </summary>
        public bool MustInput
        {
            get { return this._MustInput; }
            set { this._MustInput = value; }
        }
    }
}
