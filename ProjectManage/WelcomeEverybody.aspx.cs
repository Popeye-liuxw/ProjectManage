using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Model;
using ProjectManage.BLL;
using ProjectManage.Common;


namespace ProjectManage
{
    public partial class WelcomeEverybody : System.Web.UI.Page
    {
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger("验证用户是否为本公司人员");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Check_Click(object sender, EventArgs e)
        {
            Uri u = Request.Url;
            if (userName.Value.Trim() == "")
            {
                lbl_msg.Text = "用户名不能为空！";
                return;
            }
            if (userDay.Value.Trim() == "")
            {
                lbl_msg.Text = "密码不能为空！";
                return;
            }
            if (userMail.Value.Trim() == "")
            {
                lbl_msg.Text = "电子邮箱地址不能为空";
                return;
            }
            CheckUser userBll = new CheckUser();

            Vi_SysUserModel user = userBll.CheckUserByName(userName.Value, userDay.Value);
            if (user == null)
            {
                lbl_msg.Text = "非本公司人员";
                return;
            }

            if (user.UserPwd == "empty")
            {
                logger.Info(user.RealName + " 是本公司人员");
                user.Email = userMail.Value + "@visione.com.cn";
                if (userBll.UpdateUserInfo(user))
                {
                    logger.Info("开始为 " + user.RealName + " 发送激活邮件");
                    //发送邮件通知用户激活

                    userBll.SendEmailUserCheckInfo(user, u.Scheme + "://" + u.Authority);
                    lbl_msg.Text = "验证已通过，请查看邮箱";
                }
                else
                {
                    lbl_msg.Text = "系统繁忙，稍后在试";
                }
            }
            else
            {
                lbl_msg.Text = string.Format("{0}您已激活", user.RealName);
            }

        }


    }
}