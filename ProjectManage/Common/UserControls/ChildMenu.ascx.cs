using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;

namespace ProjectManage.Common.UserControls
{
    public partial class ChildMenu : System.Web.UI.UserControl
    {
        private int _menuID = 0;

        /// <summary>
        /// 当前选中的模块ID
        /// </summary>
        public int MenuID
        {
            get
            {
                return _menuID;
            }
            set
            {
                _menuID = value;
            }
        }

        private string queryString = string.Empty;

        /// <summary>
        /// 查询字符串,可以组织多个。形如prjID = 1
        /// </summary>
        public string QueryString
        {
            get { return queryString; }
            set 
            {
                if (value.IndexOf('&') == 0)
                {
                    queryString = value;
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
            }
        }

        private void BindMenu()
        {
            SysModuleBLL module = new SysModuleBLL();
            rpt_Menu.DataSource = module.GetChildMenuNodes(_menuID, "02", queryString);
            rpt_Menu.DataBind();
        }
    }
}