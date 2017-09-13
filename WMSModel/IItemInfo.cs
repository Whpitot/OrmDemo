using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    public interface IItemInfo
    {
        int FItemID { get; }
        string FNumber { get; }
        string FName { get; }
    }

    public sealed class EmptyItem : IItemInfo
    {
        public int FItemID
        {
            get
            {
                return 0;
            }
        }

        public string FNumber
        {
            get
            {
                return string.Empty;
            }
        }

        public string FName
        {
            get
            {
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return FName;
        }
    }
}
