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

    public class CustomerService : IItemSelectService
    {
        ICustomer icustomer = new CustomerSession();

        public IItemInfo SelectItem()
        {
            var f = new frmCustomerMng { SelectModel = true };
            f.ShowDialog();
            return f.SelectedItem as IItemInfo;
        }

        public IItemInfo GetItembyId(int id)
        {
            t_Customer _customer = icustomer.LoadEntity(id);
            if (_customer != null)
            {
                return _customer as IItemInfo;
            }
            return new EmptyItem();
        }
    }
}
