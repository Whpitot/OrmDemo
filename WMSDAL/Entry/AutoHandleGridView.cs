using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WMSDAL.Map;

namespace WMSDAL.Entry
{
    public class AutoHandleGridView   //这样做就不需要绑定定死了，传一个字符串过来；这个实体关系映射就不需要了
    {
        public static void AutoBindColumnToGridView<T>(GridView gridView) where T : class,new()
        {
            T Entry = new T();
            Type entryType = Entry.GetType();//得到他的全名称
            foreach (PropertyInfo item in entryType.GetProperties())
            {
                if (item.IsDefined(typeof(MapColumnsToGridViewAttribute), false))
                {
                    MapColumnsToGridViewAttribute mapColumns = Attribute.GetCustomAttribute(item, typeof(MapColumnsToGridViewAttribute)) as MapColumnsToGridViewAttribute;
                    gridView.Columns.Add(new GridColumn()
                    {
                        Name = mapColumns.Name,
                        FieldName = mapColumns.FieldName,
                        Caption = mapColumns.Caption,
                        VisibleIndex = mapColumns.VisibleIndex,
                        Visible = mapColumns.Visual
                    });
                }
            }
        }

        public static void CalculateSumOfColumns(GridView gridView, string[] columns, SummaryItemType summaryItemType)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                GridColumn gridColumn = gridView.Columns.ColumnByFieldName(columns[i]);
                gridColumn.SummaryItem.SummaryType = summaryItemType;
            }
        }
    }
}
