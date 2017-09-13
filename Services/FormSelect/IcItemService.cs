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

    public class IcItemService : IItemSelectService
    {
        IICItem iIcItem = new ICItemSession();

        public IItemInfo SelectItem()
        {
            var f = new frmICItemMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_ICItem _IcItems = iIcItem.LoadEntity(id); ;
            if (_IcItems != null)
            {
                return _IcItems as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
