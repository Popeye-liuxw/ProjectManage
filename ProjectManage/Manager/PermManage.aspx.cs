using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;

namespace ProjectManage.Manager
{
    public partial class PermManage : System.Web.UI.Page
    {
        private SystemPermission permission;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                permission = SystemLegalPowerBll.GetSystemPermission(2, 1);
            }
        }
    }
}