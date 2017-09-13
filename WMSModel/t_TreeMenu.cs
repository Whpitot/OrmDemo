using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSModel
{
    using WMSDAL.Entry;
    using WMSDAL.Map;
    using WMSDAL.Sql;

    [TableMap("t_TreeMenu", "FuncID")]
    public class t_TreeMenu : EntryObject
    {
        public t_TreeMenu()
        { }
        #region Model
        private int _funcid;
        private string _fnumber;
        private int _fparentid;
        private string _fname;
        private string _url;
        private string _fclassitem;
        private string _duty;
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FuncID", DbType.Int32)]
        public int FuncID
        {
            set { _funcid = value; }
            get { return _funcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FNumber", DbType.String)]
        public string FNumber
        {
            set { _fnumber = value; }
            get { return _fnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FParentID", DbType.Int32)]
        public int FParentID
        {
            set { _fparentid = value; }
            get { return _fparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FName", DbType.String)]
        public string FName
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("Url", DbType.String)]
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("FClassItem", DbType.String)]
        public string FClassItem
        {
            set { _fclassitem = value; }
            get { return _fclassitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMap("Duty", DbType.Int32)]
        public string Duty
        {
            set { _duty = value; }
            get { return _duty; }
        }
        #endregion Model

        public void Save()
        {
            //添加操作
            if (FuncID == 0)
            {
                //子类调用基类的属性
                FuncID = SqlCom.GetMaxNum("t_Emp");
                this.add();
            }
            else
            {
                this.update();
            }
        }

        public t_TreeMenu[] LoadList(string cond)//这些应该都不需要，很繁琐。
        {
            string str = "select * from t_TreeMenu";
            if (cond.Trim() != "")
            {
                str += " where " + cond.Trim();
            }
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                DataTable dt = new DataTable();
                dt = db.DataQuery(str).Tables[0];
                return DataBaseHelper.GetEntities<t_TreeMenu>(dt);
            }            
        }

        public t_TreeMenu LoadEntity(string cond)
        {
            string str = "select * from t_TreeMenu";
            if (cond.Trim() != "")
            {
                str += " where " + cond.Trim();
            }
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryObject<t_TreeMenu>(str);
            }   
        }

        public t_TreeMenu[] LoadEntities(int cond)
        {
            string str = @"select t3.FuncID,t3.FName from t_Item t1 inner join t_UserRight t2 on t1.FItemID=T2.FUserID
                            inner join t_TreeMenu t3 on t2.FRightID=t3.FuncID where t1.FItemID={0}";
            str = string.Format(str, cond);
            using (DbSession db = Db.Get())
            {
                db.OpenConnection();
                return db.QueryList<t_TreeMenu>(str);
            }        
        }
    }
    public interface It_TreeMenu
    {
        t_TreeMenu[] LoadList(string cond);

        t_TreeMenu[] LoadEntities(int cond);

        void Save(t_TreeMenu instance);

        t_TreeMenu LoadEntity(string cond);
    }
}
