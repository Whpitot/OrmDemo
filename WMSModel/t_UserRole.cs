using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    public class t_UserRole
    {
        public t_UserRole()
        { }
        #region Model
        private int _fitemid;
        private int? _fuserid;
        private int? _froleid;
        private int? _ftype;
        /// <summary>
        /// 
        /// </summary>
        public int FItemID
        {
            set { _fitemid = value; }
            get { return _fitemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FUserID
        {
            set { _fuserid = value; }
            get { return _fuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FRoleID
        {
            set { _froleid = value; }
            get { return _froleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FType
        {
            set { _ftype = value; }
            get { return _ftype; }
        }
        #endregion Model
    }
}
