using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WMSDAL.Map;

namespace WMSDAL.Entry
{
    public class AttrubuteHelper
    {
        public static Dictionary<string, string> FindFieldRelationAttribute<T>(string fieldname) where T : class ,new()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            Type objType = typeof(T);
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                object[] objAttrs = propInfo.GetCustomAttributes(typeof(FieldRelationAttribute), true);
                if (objAttrs.Length > 0)
                {
                    FieldRelationAttribute attr = objAttrs[0] as FieldRelationAttribute;
                    if (attr != null && attr.FFieldName == fieldname)
                    {
                        list.Add(propInfo.Name, attr.FReturnName);
                    }
                }
            }
            return list;        
        }

        public static object GetValue(object o, string property)
        {
            Type type = o.GetType(); //获取类型
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(property); 
            //万一属性为空会报错
            object value = (object)propertyInfo.GetValue(o, null);
            return value;
        }

        public static void SetValue(object o, string property, object value)
        {
            Type type = o.GetType(); 
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(property); 
            propertyInfo.SetValue(o, value, null); 
        }
    }
}
