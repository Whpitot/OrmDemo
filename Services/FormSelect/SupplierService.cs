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

    public class SupplierService : IItemSelectService
    {
         ISupplier iSupplier = new SupplierSession();

        public IItemInfo SelectItem()
        {
            var f = new frmSupplierMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Supplier _Suppliers = iSupplier.LoadEntities(id)[0];
            if (_Suppliers != null)
            {
                return _Suppliers as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
