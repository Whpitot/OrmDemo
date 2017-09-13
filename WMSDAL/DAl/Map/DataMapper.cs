using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace DAl.Map
{
    /// <summary>
    /// Map data from a source into a target object
    /// by copying public property values.
    /// </summary>
    /// <remarks></remarks>
    public static class DataMapper
    {
        #region Map from IDataRead

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        public static void Map(System.Data.IDataReader source, object target)
        {
            Map(source, target, false);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        public static void Map(System.Data.IDataReader source, object target, params string[] ignoreList)
        {
            Map(source, target, false, ignoreList);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        public static void Map(
          System.Data.IDataReader source,
          object target, bool suppressExceptions,
          params string[] ignoreList)
        {
            List<string> ignore = new List<string>(ignoreList);
            for (int i = 0; i < source.FieldCount; i++)
            {
                string propertyName = source.GetName(i);
                if (!ignore.Contains(propertyName))
                {
                    try
                    {
                        SetPropertyValue(target, propertyName, source[propertyName]);
                    }
                    catch (Exception ex)
                    {
                        if (!suppressExceptions)
                            throw new ArgumentException(
                              String.Format("{0} ({1})",
                              "属性复制失败", propertyName), ex);
                    }
                }
            }
        }

        #endregion

        #region Map from IDictionary

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">A name/value dictionary containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <remarks>
        /// The key names in the dictionary must match the property names on the target
        /// object. Target properties may not be readonly or indexed.
        /// </remarks>
        public static void Map(System.Collections.IDictionary source, object target)
        {
            Map(source, target, false);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">A name/value dictionary containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <param name="ignoreList">A list of property names to ignore. 
        /// These properties will not be set on the target object.</param>
        /// <remarks>
        /// The key names in the dictionary must match the property names on the target
        /// object. Target properties may not be readonly or indexed.
        /// </remarks>
        public static void Map(System.Collections.IDictionary source, object target, params string[] ignoreList)
        {
            Map(source, target, false, ignoreList);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">A name/value dictionary containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <param name="ignoreList">A list of property names to ignore. 
        /// These properties will not be set on the target object.</param>
        /// <param name="suppressExceptions">If <see langword="true" />, any exceptions will be supressed.</param>
        /// <remarks>
        /// The key names in the dictionary must match the property names on the target
        /// object. Target properties may not be readonly or indexed.
        /// </remarks>
        public static void Map(
          System.Collections.IDictionary source,
          object target, bool suppressExceptions,
          params string[] ignoreList)
        {
            List<string> ignore = new List<string>(ignoreList);
            foreach (string propertyName in source.Keys)
            {
                if (!ignore.Contains(propertyName))
                {
                    try
                    {
                        SetPropertyValue(target, propertyName, source[propertyName]);
                    }
                    catch (Exception ex)
                    {
                        if (!suppressExceptions)
                            throw new ArgumentException(
                              String.Format("{0} ({1})",
                              "属性复制失败", propertyName), ex);
                    }
                }
            }
        }

        #endregion

        #region Map from Object

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">An object containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <remarks>
        /// The property names and types of the source object must match the property names and types
        /// on the target object. Source properties may not be indexed. 
        /// Target properties may not be readonly or indexed.
        /// </remarks>
        public static void Map(object source, object target)
        {
            Map(source, target, false);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">An object containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <param name="ignoreList">A list of property names to ignore. 
        /// These properties will not be set on the target object.</param>
        /// <remarks>
        /// The property names and types of the source object must match the property names and types
        /// on the target object. Source properties may not be indexed. 
        /// Target properties may not be readonly or indexed.
        /// </remarks>
        public static void Map(object source, object target, params string[] ignoreList)
        {
            Map(source, target, false, ignoreList);
        }

        /// <summary>
        /// Copies values from the source into the
        /// properties of the target.
        /// </summary>
        /// <param name="source">An object containing the source values.</param>
        /// <param name="target">An object with properties to be set from the dictionary.</param>
        /// <param name="ignoreList">A list of property names to ignore. 
        /// These properties will not be set on the target object.</param>
        /// <param name="suppressExceptions">If <see langword="true" />, any exceptions will be supressed.</param>
        /// <remarks>
        /// <para>
        /// The property names and types of the source object must match the property names and types
        /// on the target object. Source properties may not be indexed. 
        /// Target properties may not be readonly or indexed.
        /// </para><para>
        /// Properties to copy are determined based on the source object. Any properties
        /// on the source object marked with the <see cref="BrowsableAttribute"/> equal
        /// to false are ignored.
        /// </para>
        /// </remarks>
        public static void Map(
          object source, object target,
          bool suppressExceptions,
          params string[] ignoreList)
        {
            List<string> ignore = new List<string>(ignoreList);
            PropertyInfo[] sourceProperties =
              GetSourceProperties(source.GetType());
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                string propertyName = sourceProperty.Name;
                if (!ignore.Contains(propertyName))
                {
                    try
                    {
                        SetPropertyValue(
                          target, propertyName,
                          sourceProperty.GetValue(source, null));
                    }
                    catch (Exception ex)
                    {
                        if (!suppressExceptions)
                            throw new ArgumentException(
                              String.Format("{0} ({1})",
                              "属性复制失败", propertyName), ex);
                    }
                }
            }
        }

        private static PropertyInfo[] GetSourceProperties(Type sourceType)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            PropertyDescriptorCollection props =
              TypeDescriptor.GetProperties(sourceType);
            foreach (PropertyDescriptor item in props)
                if (item.IsBrowsable)
                    result.Add(sourceType.GetProperty(item.Name));
            return result.ToArray();
        }

        #endregion

        #region 动态设置字段的值（使用反射）
        //表示是否先检查不带F的字段映射。合理而且统一的设计有助于减少反射，提升性能。
        //例如遇到FNumber这样以F开头的字段，先检查Number属性映射。、
        //否则先检查FNumber属性映射。
        static readonly bool FIRST_CHECK_NOT_F_PRE = true;

        public static void SetPropertyValue(object target, string propertyName, object value)
        {
            PropertyInfo propertyInfo = null;

            if (FIRST_CHECK_NOT_F_PRE)
            {
                //检查不带F的字段映射
                if (propertyInfo == null && propertyName.Substring(0, 1).ToLower() == "f")
                {
                    propertyInfo = target.GetType().GetProperty(propertyName.Substring(1), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }
                //检查普通情况下的映射
                if (propertyInfo == null)
                    propertyInfo = target.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            }
            else
            {
                //检查普通情况下的映射
                if (propertyInfo == null)
                    propertyInfo = target.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                //检查不带F的字段映射
                if (propertyInfo == null && propertyName.Substring(0, 1).ToLower() == "f")
                {
                    propertyInfo = target.GetType().GetProperty(propertyName.Substring(1), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }
            }

            //在没有字段映射的情况下,检查对象是否可扩展
            if (propertyInfo == null)
            {
                if (target is ExtendableObj)
                {
                    ExtendableObj eobj = (target as ExtendableObj);
                    if (eobj.ExtendValue.ContainsKey(propertyName))
                        eobj.ExtendValue[propertyName] = value;
                    else
                        eobj.ExtendValue.Add(propertyName, value);
                    return;
                }
                else
                    throw new Exception("找不到可以匹配" + propertyName + "的属性");
            }

            if (value == null)
                propertyInfo.SetValue(target, value, null);
            else
            {
                Type pType =
                  Utilities.GetPropertyType(propertyInfo.PropertyType);
                Type vType =
                  Utilities.GetPropertyType(value.GetType());
                if (pType.Equals(vType))
                {
                    // types match, just copy value
                    propertyInfo.SetValue(target, value, null);
                }
                else
                {
                    // types don't match, try to coerce
                    if (pType.Equals(typeof(Guid)))
                        propertyInfo.SetValue(
                          target, new Guid(value.ToString()), null);
                    else if (pType.IsEnum && vType.Equals(typeof(string)))
                        propertyInfo.SetValue(target, Enum.Parse(pType, value.ToString()), null);
                    else
                        propertyInfo.SetValue(
                          target, Convert.ChangeType(value, pType), null);
                }
            }
        }
        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo propertyInfo = null;

            if (FIRST_CHECK_NOT_F_PRE)
            {
                //检查不带F的字段映射
                if (propertyInfo == null && propertyName.Substring(0, 1).ToLower() == "f")
                {
                    propertyInfo =
                      source.GetType().GetProperty(propertyName.Substring(1), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }
                //检查普通情况下的映射
                if (propertyInfo == null)
                    propertyInfo = source.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            }
            else
            {
                //检查普通情况下的映射
                if (propertyInfo == null)
                    propertyInfo = source.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                //检查不带F的字段映射
                if (propertyInfo == null && propertyName.Substring(0, 1).ToLower() == "f")
                {
                    propertyInfo =
                      source.GetType().GetProperty(propertyName.Substring(1), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }
            }
            if (propertyInfo != null)
                return propertyInfo.GetValue(source, null);

            if (source is ExtendableObj)
            {
                ExtendableObj s = source as ExtendableObj;
                return s.GetValue(propertyName, true);
            }
            return null;
        }
        #endregion
    }


    public static class Utilities
    {
        #region Replacements for VB runtime functionality

        /// <summary>
        /// Determines whether the specified
        /// value can be converted to a valid number.
        /// </summary>
        public static bool IsNumeric(object value)
        {
            double dbl;
            return double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
              System.Globalization.NumberFormatInfo.InvariantInfo, out dbl);
        }

        /// <summary>
        /// Allows late bound invocation of
        /// properties and methods.
        /// </summary>
        /// <param name="target">Object implementing the property or method.</param>
        /// <param name="methodName">Name of the property or method.</param>
        /// <param name="callType">Specifies how to invoke the property or method.</param>
        /// <param name="args">List of arguments to pass to the method.</param>
        /// <returns>The result of the property or method invocation.</returns>
        public static object CallByName(
          object target, string methodName, CallType callType,
          params object[] args)
        {
            switch (callType)
            {
                case CallType.Get:
                    {
                        PropertyInfo p = target.GetType().GetProperty(methodName);
                        return p.GetValue(target, args);
                    }
                case CallType.Let:
                case CallType.Set:
                    {
                        PropertyInfo p = target.GetType().GetProperty(methodName);
                        object[] index = null;
                        args.CopyTo(index, 1);
                        p.SetValue(target, args[0], index);
                        return null;
                    }
                case CallType.Method:
                    {
                        MethodInfo m = target.GetType().GetMethod(methodName);
                        return m.Invoke(target, args);
                    }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// Returns a property's type, dealing with
        /// Nullable(Of T) if necessary.
        /// </summary>
        /// <param name="propertyType">Type of the
        /// property as returned by reflection.</param>
        public static Type GetPropertyType(Type propertyType)
        {
            Type type = propertyType;
            if (type.IsGenericType &&
              (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
                return Nullable.GetUnderlyingType(type);
            return type;
        }

        /// <summary>
        /// Returns the type of child object
        /// contained in a collection or list.
        /// </summary>
        /// <param name="listType">Type of the list.</param>
        public static Type GetChildItemType(Type listType)
        {
            Type result = null;
            if (listType.IsArray)
                result = listType.GetElementType();
            else
            {
                DefaultMemberAttribute indexer =
                  (DefaultMemberAttribute)Attribute.GetCustomAttribute(
                  listType, typeof(DefaultMemberAttribute));
                if (indexer != null)
                    foreach (PropertyInfo prop in listType.GetProperties(
                      BindingFlags.Public |
                      BindingFlags.Instance |
                      BindingFlags.FlattenHierarchy))
                    {
                        if (prop.Name == indexer.MemberName)
                            result = Utilities.GetPropertyType(prop.PropertyType);
                    }
            }
            return result;
        }
    }

    /// <summary>
    /// Valid options for calling a property or method
    /// via the <see cref="Csla.Utilities.CallByName"/> method.
    /// </summary>
    public enum CallType
    {
        /// <summary>
        /// Gets a value from a property.
        /// </summary>
        Get,
        /// <summary>
        /// Sets a value into a property.
        /// </summary>
        Let,
        /// <summary>
        /// Invokes a method.
        /// </summary>
        Method,
        /// <summary>
        /// Sets a value into a property.
        /// </summary>
        Set
    }


    [Serializable]
   // [DataContract]
    public class ExtendableObj
    {
        public ExtendableObj()
        {
            _val = new Dictionary<string, object>();
        }
        Dictionary<string, object> _val;
      //  [DataMember]
        public Dictionary<string, object> ExtendValue
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }

        /// <summary>
        /// 通过key获取值
        /// </summary>
        public object GetValue(string key, bool ignoreCase)
        {
            foreach (KeyValuePair<string, object> s in _val)
            {
                if (string.Compare(s.Key, key, ignoreCase) == 0)
                {
                    return s.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过key获取值
        /// </summary>
        public void SetValue(string key, object value)
        {
            foreach (KeyValuePair<string, object> s in _val)
            {
                if (string.Compare(s.Key, key, true) == 0)
                {
                    _val[s.Key] = value;
                }
            }
        }
    }


    public static class DataType
    {
        /// <summary>
        /// 从数据类型ID转换为Type类型
        /// </summary>
        public static Type Convert(int typeid)
        {
            switch (typeid)
            {
                case 1:
                    return typeof(string);
                case 2:
                    return typeof(DateTime);
                case 3:
                    return typeof(int);
                case 4:
                    return typeof(double);
                case 5:
                    return typeof(decimal);
                case 6:
                    return typeof(bool);
                case 10:
                  //  return typeof(BaseData);
                case 11:
                   // return typeof(User);
                default:
                    throw new NotSupportedException("系统不支持此类型");
            }
        }
    }
}
