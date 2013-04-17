using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManage.Manager
{
    public partial class Manager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ManagerId"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lbl_ManagerName.Text = Session["UserName"].ToString() + "，您好！";
                }
            }
        }
    }
}