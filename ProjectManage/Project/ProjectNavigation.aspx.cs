using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
namespace ProjectManage.Project
{
    public partial class ProjectNavigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["prjID"] != null)
            {
                //spn_Menu.QueryString = "&prjID=" + Request.QueryString["prjID"].ToString();
            }
        }
    }
}