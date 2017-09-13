using System;
using System.Collections.Generic;
using System.Text;

namespace WMSDAL.Entry
{
    /// <summary>
    /// 数据库字段集合类
    /// </summary>
    using System.Data;
    using System.Collections.Generic;
    using WMSDAL.Map;

    public class Fields : List<Field>
    {
        public new Fields Add(Field field)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].FieldName.ToLower() ==field.FieldName.ToLower())
                    throw new System.Exception("字段重复!");                     
            }
            base.Add(field);
            return this;
        }

        public void Remove(string FieldName)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].FieldName.ToLower() == FieldName.ToLower())
                    RemoveAt(i);
            }            
        }

        public Field GetField(string Fieldname)//获取主键字段转化为条件
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].FieldName.ToLower() == Fieldname.ToLower())
                    return this[i];
            }
            throw new System.Exception("该字段不存在");
        }




        public string ToCondition()
        {
            string cond = "1=1";
            for (int i = 0; i < this.Count; i++)
            {
                cond += " and " + this[i].ToString();
            }
            return cond;
        }

        public string ToUpdateString()
        {
            string ups = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (ups.Length > 0) ups += ",";
                ups += this[i].ToString();
            }
            return ups;
        }

        public string ToFieldNameList()
        {
            string l = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (l.Length > 0) l += ",";
                l += this[i].ToFieldNameString();
            }
            return l;
        }

        public string ToFieldValueList()
        {
            string l = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (l.Length > 0) l += ",";
                l += this[i].ToValueString();
            }
            return l;
        }
    }
}
