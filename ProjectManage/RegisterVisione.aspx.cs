using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;
using ProjectManage.Common;

namespace ProjectManage
{
    public partial class RegisterVisione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri u = Request.Url;
                if (Request.QueryString["user"] == null || Request.QueryString["num"] == null)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
                CheckUser userBll = new CheckUser();
                Vi_SysUserModel user = userBll.GetRegisterVisioneUser(Request.QueryString["num"].ToString(), Request.QueryString["user"].ToString());
                if (user == null)
                {
                    Response.Redirect("WelcomeEverybody.aspx");
                }
                else
                {
                    getMD5 md5 = new getMD5();
                    user.UserPwd = md5.CalculateMD5Hash("000000");
                    if (userBll.UpdateUserInfo(user))
                    {
                        lbl_meg.Text = "激活账户成功，系统已将用户密码发到你的邮箱，请查收";
                        userBll.SendMailUserPwd(user, u.Scheme + "://" + u.Authority);
                    }
                    else
                    {
                        lbl_meg.Text = "激活失败,请联系项目管理系统项目组:liuxiaowei@visione.com.cn 或 lixiaosen@visione.com.cn";
                    }
                    
                }
            }
        }
    }
}