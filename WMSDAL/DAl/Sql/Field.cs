using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Sql
{
    /// <summary>
    /// 数据库字段类
    /// </summary>
    public class Field
    {
        System.Type _type;//字段类型
        string _fieldname;//字段名称
        object _value;//字段数值
        bool _mustinput;//是否必填
        public Field(Type type, string fieldname, object value)
        {
            this._type =(type==null)?typeof(string):type;
            this._fieldname = fieldname;
            this._value = value;
        }
        public Field(Type type, string fieldname)
            : this(type, fieldname, null)
        { 
        
        }
        public Field(string fieldname, object value)
            : this(null, fieldname, value)
        {

        }
        public Field(Type type, string fieldname, object value,bool mustinput)
            :this(type,fieldname,value)
        {
            this._mustinput = mustinput;
        }
        #region 属性
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            get { return _fieldname; }
            set { _fieldname = value; }
        }
        /// <summary>
        /// 字段类型
        /// </summary>
        public System.Type Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        ///必填项
        /// </summary>
        public bool  MustInput
        {
            get { return _mustinput; }
            set { _mustinput = value; }
        }
        /// <summary>
        /// 字段值
        /// </summary>
        public object Value
        {
            get { return _value; }
            set {
                if (_value == null || _value == DBNull.Value)
                {
                    _value = DBNull.Value;
                }
                else
                {
                    try
                    {
                        _value = System.Convert.ChangeType(_value, _type);
                    }
                    catch
                    {
                        throw new System.Exception("值:" + _value.ToString() + "[" + _value.GetType().Name + "]转换为类型[" + _type.Name + "]时错误");
                    }
                }
            
            }
        }
        /// <summary>
        /// 判断值是不是null
        /// </summary>
        public bool isDBNull
        {
            get
            {
                if (_type == typeof(System.DateTime))
                    if (_value != null && _value != System.DBNull.Value)
                        if ((System.DateTime)_value == System.DateTime.MinValue)
                            return true;
                   return (_value == System.DBNull.Value || _value == null);
                
            }
        }
        #endregion
        #region  方法

        /// <summary>
        /// 判断是否设置了必填项，且没有必填
        /// </summary>
        /// <returns></returns>
        public bool CheckMustInput()
        {
            if (this.MustInput)
            {
                if (isDBNull) return false;
                if (_type == typeof(decimal) || _type == typeof(int) || _type == typeof(double) || _type == typeof(float) || _type == typeof(uint) || _type == typeof(long))
                {
                    if (Convert.ToDouble(Value) == 0)
                        return false;
                }
                else if(_type == typeof(DateTime))
                {
                    if ((DateTime)Value == DateTime.MinValue)
                        return false;
                    if (Value.ToString().Trim() == "1900/1/1 0:00:00")
                        return false;
                }
                else
                {
                    if (Value.ToString().Trim() == "")
                        return false;
                }

            }
            return true;
        }

        public object GetNotNullValue()
        {
            if (isDBNull)
            {
                return "null";
            }
            else if (_type == typeof(decimal) || _type == typeof(int) || _type == typeof(double) || _type == typeof(float) || _type == typeof(uint) || _type == typeof(long))
            {
                return Value.ToString();
            }
            else
            {
                return string.Concat("'",_value.ToString(),"'");
              //  return "'" + Value.ToString().Replace("'", "") + "'";
            }
        }
        public string ToFieldNameString()
        {
            return string.Concat("[", this._fieldname, "]");
        }

        public string ToValueString()
        {
            if (isDBNull)
            {
                return "null";
            }
            else if (_type == typeof(decimal) || _type == typeof(int) || _type == typeof(double) || _type == typeof(float) || _type == typeof(uint) || _type == typeof(long))
            {
                return Value.ToString();
            }
            else
            {
               // return "'" + Value.ToString().Replace("'", "") + "'";
              return   string.Concat("'", Value.ToString(), "'");
            }
        }
        public override string ToString()
        {
             return string.Concat(this.ToFieldNameString(),"=",this.ToValueString());
        }
        public string ToStringbyhu()
        {
            return string.Concat(this.ToFieldNameString(), "<>", this.ToValueString());
        }
        #endregion
    }
}
