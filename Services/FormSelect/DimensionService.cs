using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FormSelect
{
    using WMSModel;
    using ServiceLib;
    using Wingdell.Control;

    public class DimensionService : IItemSelectService
    {
        IDimension iProxy = new DimensionSession();

        public IItemInfo SelectItem()
        {
            var f = new FrmDimensionMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            Dimension instance = iProxy.LoadEntity(id);
            if (instance != null)
            {
                return instance as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
