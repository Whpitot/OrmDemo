using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DAl.Map
{
    /// <summary>
    /// ��Ҫ�ύ���ֶ�
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=false,Inherited=true)]
    [Serializable]
    public class FieldMapAttribute:Attribute
    {
       /// <summary>
       /// ����
       /// </summary>
        private string _columnName;
        private DbType _dbtype;  // ������� ����̫��
        private object _defaultvalue;
        private bool _IsIdentity;
        private bool _canrepeat;//�ܷ��ظ�
        private bool _MustInput;//�����ֶ�
       /// <summary>
       /// ���ݿ��ֶ�����
       /// </summary>
       /// <param name="columnName">����</param>
       /// <param name="dbtype">���ݿ�����</param>
     

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
        /// �ܷ��ظ�
        /// </summary>
        public bool CanRepeat
        {
            get { return _canrepeat; }
            set { _canrepeat = value; }
        }
       /// <summary>
       /// �ֶ�����
       /// </summary>
        public string ColumnName
        {
            get { return this._columnName; }
            set { this._columnName = value; }
        }
       /// <summary>
       /// �ֶ�����
       /// </summary>
       public DbType DbType
       {
           get { return this._dbtype; }
           set { this._dbtype = value; }
       }
        /// <summary>
        ///�Ƿ�����
        /// </summary>
        public bool IsIdentity
        {
            get { return _IsIdentity; }
            set { _IsIdentity = value; }
        }
       /// <summary>
       /// Ĭ��ֵ
       /// </summary>
        public object DefaultValue
        {
            get { return this._defaultvalue; }
            set { this._defaultvalue = value; }
        }

        /// <summary>
        ///������
        /// </summary>
        public bool MustInput
        {
            get { return this._MustInput; }
            set { this._MustInput = value; }
        }
    }
}
