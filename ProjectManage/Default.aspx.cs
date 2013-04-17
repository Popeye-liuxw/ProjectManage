using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using ProjectManage.BLL;
using ProjectManage.Common;
using System.Data;

namespace ProjectManage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("MySpace.aspx");
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            UserBLL ubll = new UserBLL();
            //先判断验证码是否正确
            if (Session["serverCode"] != null)
            {
                if (Session["serverCode"].ToString() != kaptcha.Value.Trim())
                {
                    lbl_msg.Text = "验证码错误！";
                    return;
                }
                if (userName.Value.Trim() == "")
                {
                    lbl_msg.Text = "用户名不能为空！";
                    return;
                }
                if (userPwd.Value.Trim() == "")
                {
                    lbl_msg.Text = "密码不能为空！";
                    return;
                }
                Vi_SysUserModel visum = new Vi_SysUserModel();
                bool bl = System.Text.RegularExpressions.Regex.IsMatch(userName.Value.Trim(), @"[\u4e00-\u9fa5]+$");
                if (bl == false)//不是汉字
                {
                    visum = ubll.getUserModelByUserName(userName.Value.Trim());
                }
                else
                {
                    visum = ubll.getUserModelByRealName(userName.Value.Trim());
                }
                if (visum == null)//说明不存在这个用户
                {
                    lbl_msg.Text = "帐号或者密码错误，请重新输入！";
                    return;
                }
                else
                {
                    getMD5 md5 = new getMD5();
                    SysManagerBll bll = new SysManagerBll();
                    if (visum.UserPwd.Trim() == md5.CalculateMD5Hash(userPwd.Value.Trim()))
                    {                       
                        //到这算登录成功！
                        Session["UserId"] = visum.ID;
                        DataTable dtUserInfo = ubll.getUserInfoById(visum.ID);
                        if (dtUserInfo.Rows.Count > 0)
                        {
                            Session["RealName"] = dtUserInfo.Rows[0]["RealName"].ToString();
                            Session["Department"] = dtUserInfo.Rows[0]["cDepName"].ToString();
                        }

                        //登录成功记录登录日志
                        Vi_SysLogModel logModel = new Vi_SysLogModel();
                        logModel.SysType = 1;
                        logModel.UserName = visum.UserName.Trim();
                        logModel.UserID = visum.ID;
                        ClientInfo ci = new ClientInfo();
                        logModel.TheIP = ci.getIP();
                        logModel.Operate = "用户:" + visum.RealName + "登录成功！";
                        logModel.IOS = ci.SystemCheck();
                        logModel.LastIP = "127.0.0.1";
                        logModel.Browser = ci.getBrowser();
                        logModel.UpdateTime = DateTime.Now;
                        logModel.CreateTime = DateTime.Now;
                        bll.InsertManagerLog(logModel);
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        //登录失败也会记录登录者信息  这里记录的是用户名正确的密码不正确的信息
                        Vi_SysLogModel logModel = new Vi_SysLogModel();
                        logModel.SysType = 1;
                        logModel.UserName = visum.UserName.Trim();
                        logModel.UserID = visum.ID;
                        ClientInfo ci = new ClientInfo();
                        logModel.TheIP = ci.getIP();
                        logModel.Operate = "用户:" + visum.RealName + "登录失败！" + "尝试密码：" + userPwd.Value.Trim();
                        logModel.IOS = ci.SystemCheck();
                        logModel.LastIP = "127.0.0.1";
                        logModel.Browser = ci.getBrowser();
                        logModel.UpdateTime = DateTime.Now;
                        logModel.CreateTime = DateTime.Now;
                        bll.InsertManagerLog(logModel);
                        lbl_msg.Text = "帐号或者密码错误,请重新输入！";
                        return;
                    }
                }
            }
        }
    }
}