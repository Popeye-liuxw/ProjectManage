using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： CheckUser.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/9/13 16:21:39
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 检测用户合法性
    /// </summary>
    public class CheckUser
    {
        private Vi_SysUserProvider userSql;

        public CheckUser()
        {
            userSql = DataFactory.CreateVi_SysUserSqlPrivider();
        }
        /// <summary>
        /// 验证是否存在该用户
        /// </summary>
        /// <param name="username">真实姓名</param>
        /// <param name="birthday">真实生日</param>
        /// <returns></returns>
        public Vi_SysUserModel CheckUserByName(string username, string birthday)
        {
            Vi_SysUserModel result = null;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(birthday))
            {
                result = userSql.CheckUserByName(username, Convert.ToDateTime(birthday));
            }
            return result;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Vi_SysUserModel user)
        {
            bool result = false;
            user.UpdateTime = DateTime.Now;
            int tmp = userSql.UpdateVi_SysUser(user);
            if (tmp > 0) result = true;
            return result;
        }
        /// <summary>
        /// 发送验证邀请邮件
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <param name="url">链接地址</param>
        public void SendEmailUserCheckInfo(Vi_SysUserModel user,string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            string link = url + "/RegisterVisione.aspx?user=" + MD5Tool.MD5Encrypt(user.ID.ToString()) + "&num=" + MD5Tool.MD5Encrypt(user.UserName);
            StringBuilder content = new StringBuilder();
            content.AppendFormat("欢迎 {0} 使用北京中科卓视项目管理系统，以下是你激活本系统的链接地址，点击后激活", user.RealName);
            content.AppendFormat("<a href='{0}' target='_blank' >激活账户</a></br></br>", link);
            content.Append("或者复制下面的链接，在浏览器中打开</br>");
            content.Append(link);

            SysMailSenderBll mail = new SysMailSenderBll();
            mail.SenderEMailMessage(new List<string>() { user.Email }, "中科卓视项目管理系统", content);
        }
        /// <summary>
        /// 检测是否是合法用户激活账户
        /// </summary>
        /// <param name="username">num参数</param>
        /// <param name="userid">user参数</param>
        /// <returns></returns>
        public Vi_SysUserModel GetRegisterVisioneUser(string username, string userid)
        {
            Vi_SysUserModel model = null;
            int userID = 0;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userid)) return model;
            
            if (int.TryParse(MD5Tool.MD5Decrypt(userid), out userID))
            {
                string userName = MD5Tool.MD5Decrypt(username);

                Vi_SysUserModel name = userSql.Get_Vi_SysUserModel(userID);
                if (name != null && name.UserName == userName)
                {
                    model = name;
                }
            }
            return model;
        }
        /// <summary>
        /// 发送密码相关通知邮件
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <param name="ischange">true 表示更改用户密码,false 表示初始化密码</param>
        public void SendMailUserPwd(Vi_SysUserModel user, string url)
        {
            if (string.IsNullOrEmpty(url)) return;
            string link = url;
            StringBuilder content = new StringBuilder();
            content.AppendFormat("恭喜 {0} 激活账户成功，你的初始化密码是000000,请尽快登录系统修改初始密码", user.RealName);
            content.AppendFormat("<a href='{0}' target='_blank'>用户登录</a></br></br>", link);
            content.Append("或者复制下面的链接，在浏览器中打开</br>");
            content.Append(link);
            content.Append("</br></br>友情提示：</br>");
            content.AppendFormat("你的用户名是：{0}", user.UserName);
            content.Append("登录系统时，可以使用用户名+密码组合或者你的姓名+密码组合,赶快来体验吧！");
            content.Append("</br></br>");
            
            content.Append(" 北京中科卓视项目管理系统项目组敬上，如果有什么好的建议或意见请发邮件到：liuxiaowei@visione.com.cn 或 lixiaosen@visione.com.cn");
            SysMailSenderBll mail = new SysMailSenderBll();
            mail.SenderEMailMessage(new List<string>() { user.Email }, "中科卓视项目管理系统账户激活成功", content);
        }
    }
}
