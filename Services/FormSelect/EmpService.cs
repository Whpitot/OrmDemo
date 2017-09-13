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

    public class EmpService : IItemSelectService
    {
        IEmp iemp = new EmpSession();

        public IItemInfo SelectItem()
        {
            var f = new frmEmpMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Emp _emp = iemp.LoadEntity(id);
            if (_emp != null)
            {
                return _emp as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
