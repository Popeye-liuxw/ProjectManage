using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManage.Project
{
    public partial class MarketBonus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
            if (Request.QueryString["prjID"] == null)
            {
                Response.Redirect("ProjectBasicInfoManagement.aspx");
                return;
            }
            if (!IsPostBack)
            {
                string prjid = Request.QueryString["prjID"].ToString();
                string userid = Session["UserId"].ToString();
                spn_Menu.QueryString = "&prjID=" + prjid;
                spn_Menu.MenuID = 6; //市场奖金
                try
                {
                    int prjID = int.Parse(prjid);
                    int userID = int.Parse(userid);
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"] as string;
                ViewState["prjID"] = prjid;

                //编写页面权限判断
            }
        }
    }
}