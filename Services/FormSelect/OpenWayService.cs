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

    public class OpenWayService : IItemSelectService
    {
        IOpenWay iProxy = new OpenWaySession();

        public IItemInfo SelectItem()
        { 
            var f = new FrmOpenWayMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            OpenWay _Units = iProxy.LoadEntity(id);
            if (_Units != null)
            {
                return _Units as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
