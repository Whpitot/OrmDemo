using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Map
{   /// <summary>
    /// ��־�ۺ϶���Ĺ�ϵ������ ���ӽṹ
    ///  ����������������ܾ��� ���� ��Ӧ����һ��
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
        /// �����������ͣ����絥�� ����ĵ�����
        /// </summary>
        /// <param name="subObjectType">�����������</param>
        /// <param name="primarykey">���ݵ�����</param>
        /// <param name="foreignkey">���������ڣ���������������</param>
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
        /// ���������
        /// </summary>
        public Type SubObjectType
        {
            get { return this._subObjectType;}
            set { this._subObjectType = value;}
        }
        /// <summary>
        /// ����
        /// </summary>
        public string PrimaryKey
        {
            get { return this._primarykey;}
            set { this._primarykey = value;}
        }
        /// <summary>
        /// ���
        /// </summary>
        public string ForeignKey
        {
            get { return this._foreignkey;}
            set { this._foreignkey = value;}
        }
        
    }
}
