using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;
using DAl.Map;
namespace DAl.Entry
{
    public class EntryMap<T> where T : class, new()
    {
        private List<T> _collect;
        string _tablename;
        /// <summary>
        /// ����
        /// </summary>
        public string TableName
        {
            get { return _tablename; }
            set { _tablename = value; }
        }
       
        public EntryMap()
        {
            _collect = new List<T>();
        }
        /// <summary>
        /// ��ѯ��ļ�¼����
        /// </summary>
        public List<T> Collect
        {
            set { _collect = value; }
        }
       
        ///// <summary>
        ///// ͨ�����ݼ� �õ�һ�����ʵ��
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="data"></param>
        //public void GetInstance(T obj, DataSet data)
        //{
        //    Type t = typeof(T);
        //    PropertyInfo[] ps = t.GetProperties();
        //    foreach (PropertyInfo p in ps)
        //    {
        //        if (p.IsDefined(typeof(FieldMapAttribute), false)){ 
        //            FieldMapAttribute  fb=Attribute.GetCustomAttribute(p,typeof(FieldMapAttribute)) as FieldMapAttribute;
        //            string FName=fb.ColumnName;
        //            p.SetValue(obj,);
                     
        //        }
        //    }
        //}
    }
}
