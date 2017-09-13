using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSDAL.Map
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    [Serializable]
     public class MapColumnsToGridViewAttribute:Attribute
    {
        public MapColumnsToGridViewAttribute(string Name, string FieldName, string Caption, int VisibleIndex, bool Visual)
        {
            this.Name = Name;
            this.FieldName = FieldName;
            this.Caption = Caption;
            this.VisibleIndex = VisibleIndex;
            this.Visual = Visual;
        }

        public string Name { get; set; }

        public string FieldName { get; set; }

        public string Caption { get; set; }



        public int VisibleIndex { get; set; }

        public bool Visual { get; set; }
    }
}
