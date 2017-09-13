using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSDAL.Map
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    //放在类前面和属性前面    AllowMultiple = false  不能多次被放置   描述基类时能否被继承
    public class FieldRelationAttribute:Attribute
    {
        /// <summary>
        /// 关联字段
        /// </summary>
        public string FFieldName { get; set; }
        /// <summary>
        /// 返回字段
        /// </summary>
        public string FReturnName { get; set; }
    }
}
