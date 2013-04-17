using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManage.Manager
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] != null)
            {
                if (Request.QueryString["logout"].ToString() == "logout")
                {                    
                    Session.Clear();
                    if (Request.QueryString["type"] == null || Request.QueryString["type"].ToString() != "1")
                    {
                        Response.Write("<script language=javascript>alert('您已安全退出系统！');window.location.href='login.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('您已安全退出系统！');window.location.href='../Default.aspx';</script>");
                    }
                }
            }
            else
            {
                Response.Write("Hey,kid! Nothing is here !!! ");
            }
        }
    }
}