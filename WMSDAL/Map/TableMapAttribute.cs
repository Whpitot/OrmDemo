using System;
using System.Collections.Generic;
using System.Text;

namespace WMSDAL.Map
{
    /// <summary>
    /// ��ṹӳ��,�������ڱ�ṹ����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
    [Serializable]
    public class TableMapAttribute:Attribute
    {
        private string _tablename;
        private string _primarykey;
       /// <summary>
       /// ���������Ϣ
       /// </summary>
       /// <param name="tablename">����</param>
       /// <param name="primarkey">�������</param>
        public TableMapAttribute(string tablename,  string primarkey)
        {
            this._tablename = tablename;
            this._primarykey = primarkey;
        }
       /// <summary>
       /// ����
       /// </summary>
        public string TableName
        {
            get { return this._tablename; }
            set { this._tablename = value; }
        }
       /// <summary>
       ///����
       /// </summary>
        public string PrimaryKey
        {
            get { return this._primarykey; }
            set { this._primarykey = value; }
        }
    }
}
