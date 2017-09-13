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

    public class UnitService : IItemSelectService
    {
         IUnit iUnit = new UnitSession();

        public IItemInfo SelectItem()
        {
            var f = new frmUnitMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Unit _Units = iUnit.LoadEntities(id)[0];
            if (_Units != null)
            {
                return _Units as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
