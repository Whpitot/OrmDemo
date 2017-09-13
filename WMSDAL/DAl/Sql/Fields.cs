using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Sql
{
    /// <summary>
    /// 数据库字段集合类
    /// </summary>
    using System.Data;
    using System.Collections.Generic;

    public class Fields : List<Field>
    {
        public Fields()
        {    
        }
     public Fields(DataRow dr)
        {
            Clear();
            DataTable dt = dr.Table;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Field f = new Field(dt.Columns[i].DataType, dt.Columns[i].ColumnName);
                f.Value = dr[i];
                AddField(f);
            }
        }
        public Fields(IDataReader dr)
        {
            Clear();
            for (int i = 0; i < dr.FieldCount; i++)
            {
               Field f = new Field(dr.GetFieldType(i), dr.GetName(i));
                f.Value = dr[i];
                AddField(f);
            }
        }
        public int GetFieldIndex(string FieldName)
        {
            for (int i = 0; i < Count; i++)
            {
                if (GetField(i).FieldName.ToLower() == FieldName.ToLower())
                    return i;
            }
            return -1;
        }
        public bool HasField(string FieldName)
        {
            int fieldindex = GetFieldIndex(FieldName);
            return fieldindex >= 0;
        }
        public new Fields Add(Field field)
        {
            if (GetFieldIndex(field.FieldName) == -1)
                base.Add(field);
            else
                throw new System.Exception("字段重复!");
            return this;
        }
        public Field AddField(Field field)
        {
            if (GetFieldIndex(field.FieldName) == -1)
                this.Add(field);
            else
                throw new System.Exception("字段重复!");
            return field;
        }
        public Field AddField(string Fieldname, string Value)
        {
            Field f = new Field(Fieldname, Value);
            Add(f);
            return f;
        }
        public Field AddField(string Fieldname, object Value, System.Type type)
        {
            Field f = new Field(type, Fieldname, Value);
            Add(f);
            return f;
        }
        public Field AddField(string Fieldname, int Value)
        {
            return AddField(Fieldname, Value, typeof(int));
        }
        public Field AddField<T>(string fieldName, T value)
        {
            return AddField(fieldName, value, typeof(T));
        }
        public Fields Remove(string FieldName)
        {
            RemoveAt(GetFieldIndex(FieldName));
            return this;
        }

        public Field GetField(int Index)
        {
            if (Index < 0 || Index >= Count)
                throw new System.Exception("该字段不存在");
            return (Field)this[Index];
        }
        public Field GetField(string Fieldname)
        {
            return GetField(GetFieldIndex(Fieldname));
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
        public string ToConditionByhu()
        {
            string cond = "1=1";
            for (int i = 0; i < this.Count; i++)
            {
                cond += " and " + this[i].ToStringbyhu();
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

        public void WriteDateRow(DataRow dr)
        {
            DataTable dt = dr.Table;
            for (int i = 0; i < Count; i++)
            {
                if (dt.Columns.Contains(this[i].FieldName))
                    dr[this[i].FieldName] = this[i].Value;
            }
        }
        public static Fields ReadDataRow(DataRow dr)
        {
            Fields f = new Fields(dr);
            return f;
        }
    }
}
