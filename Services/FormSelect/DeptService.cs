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

    public class DeptService : IItemSelectService
    {
         IDept idept = new DeptSession();

        public IItemInfo SelectItem()
        {
            var f = new FrmDeptMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Dept _depts = idept.LoadEntities(id)[0];
            if (_depts != null)
            {
                return _depts as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
