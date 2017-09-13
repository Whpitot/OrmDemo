using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Map
{
    /// <summary>
    /// 不需要提交的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
  public  class ExclusiveAttribute:Attribute
    {
    }
}
