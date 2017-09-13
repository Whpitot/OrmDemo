using System;
using System.Collections.Generic;
using System.Text;
using DAl.Sql;
namespace DAl.Map
{
    public class TableMap
    {
        private string tableName;
        private string[] pkName;
        private Fields columns =new Fields(); 
        private Fields unMapingColumns = new Fields();
        private Fields pkfield=new Fields();
       /// <summary>
       /// ����
       /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        /// <summary>
        /// ����,�����ж��
        /// </summary>
        public string[] PrimaryKeyName
        {
            get { return pkName; }
            set { pkName = value; }
        }
      
        /// <summary>
        /// ��Ҫ�޸ĵ� ��
        /// </summary>
        public Fields Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        /// <summary>
        /// ����Ҫ�޸ĵ���
        /// </summary>
        public Fields UnMapingColumns
        {
            get { return unMapingColumns; }
            set { unMapingColumns = value; }
        }
        /// <summary>
        ///  �õ�����
        /// </summary>
        /// <returns></returns>
        public string GetPk()
        {
            string pks = "";
            for (int i = 0; i < pkName.Length; i++)
            {
                if (pks.Trim() != "")
                {
                    pks += ",";
                }
                pks += pks[i].ToString();
            }
            return pks;
        }
      
    }
}
