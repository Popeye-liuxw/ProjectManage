using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Model;
using ProjectManage.BLL;
namespace ProjectManage
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lbl_RealName.Text = Session["RealName"].ToString();
                    lbl_department.Text = Session["Department"].ToString();
                    BindMenu();
                }
            }
        }
        private void BindMenu()
        {
            SysModuleBLL module = new SysModuleBLL();
            rpt_Menu.DataSource = module.GetFirstModuleNodes();
            rpt_Menu.DataBind();
        }
    }
}
