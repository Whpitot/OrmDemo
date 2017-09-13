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

    public class LevelService : IItemSelectService
    {
         ILevel ilevel = new LevelSession();

        public IItemInfo SelectItem()
        {
            var f = new frmLevelMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Level _levels = ilevel.LoadEntities(id)[0];
            if (_levels != null)
            {
                return _levels as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
