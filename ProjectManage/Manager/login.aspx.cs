using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;
using ProjectManage.Common;
using System.Web.Configuration;
using System.Reflection;

namespace ProjectManage.Manager
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AssemblyInfo info = 
            if (!IsPostBack)
            {
                lbl_Version.Text = typeof(Main).Assembly.GetName().Version.ToString();
            }
            
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (Session["serverMCode"] != null)
            {
                if (userName.Value.Trim() == "")
                {
                    lbl_msg.Text = "请输入用户名！";
                    return;
                }
                if (userPwd.Value.Trim() == "")
                {
                    lbl_msg.Text = "请输入密码！";
                    return;
                }
                if (Session["serverMCode"].ToString() != kaptcha.Value.Trim())
                {
                    lbl_msg.Text = "验证码错误！";
                    return;
                }
                try
                {
                    //传入以参数形式 就不用过滤了
                    //string uName = SQLInjection.FilterStr(userName.Value.Trim());
                    SysManagerBll bll = new SysManagerBll();
                    Vi_SysBackUserModel uModel = new Vi_SysBackUserModel();
                    uModel = bll.getManagerUserInfo(userName.Value.Trim());
                    if (uModel != null)
                    {
                        if (uModel.UserName != userName.Value.Trim())
                        {
                            lbl_msg.Text = "用户名或者密码错误！";
                            return;
                        }
                        else
                        {
                            getMD5 md5 = new getMD5();
                            if (md5.CalculateMD5Hash(userPwd.Value.Trim()) == uModel.UserPwd)
                            {
                                Session["ManagerId"] = uModel.ID;
                                Session["UserName"] = uModel.UserName;
                                //写入登录日志
                                Vi_SysLogModel logModel = new Vi_SysLogModel();
                                //logModel.
                                ClientInfo CI = new ClientInfo();
                                logModel.SysType = 2; //2代表是管理员登录
                                logModel.UserID = uModel.ID;
                                logModel.UserName = uModel.UserName;
                                logModel.TheIP = CI.getIP();
                                Vi_SysLogModel lastModel = new Vi_SysLogModel();
                                lastModel = bll.getLastLogInfo(uModel.ID, 2);
                                //查询上次登录IP,如果第一次登录则显示127.0.0.1
                                if ( lastModel == null)
                                {
                                    logModel.LastIP = "127.0.0.1";//这里应该从数据库再查询上次登录IP
                                }
                                else
                                {
                                    logModel.LastIP = lastModel.LastIP;
                                }
                                logModel.IOS = CI.SystemCheck();
                                logModel.Browser = CI.getBrowser();
                                logModel.Operate = "用户" + logModel.UserName + "登陆成功";
                                logModel.Back = "";
                                logModel.CreateTime = DateTime.Now;
                                logModel.UpdateTime = DateTime.Now;
                                bll.InsertManagerLog(logModel);
                                Response.Redirect("dafault.aspx");
                            }
                            else
                            {
                                lbl_msg.Text = "用户名或者密码错误！";
                                return;
                            }
                        }
                    }
                    else
                    {
                        lbl_msg.Text = "用户名或者密码错误！";
                        return;
                    }
                }
                catch (Exception)
                {
                    lbl_msg.Text = "系统错误！";
                }

            }
        }

    }
}