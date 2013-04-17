using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;
using System.Drawing;
using ProjectManage.Common;

namespace ProjectManage.Manager
{
    public partial class dafault : System.Web.UI.Page
    {
        private log4net.ILog log = log4net.LogManager.GetLogger("测试");
        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("加载页面开始");
            if (Session["ManagerId"] != null)
            {
                Bin_repLogs();
                Bindrep_managerInfo();
            }
            else
            {
                Response.Write("sorry!你还没有登录或登录超时！");
            }
        }
        public void Bin_repLogs()
        {
            SysManagerBll bll = new SysManagerBll();
            int pageIndex = this.ANP.CurrentPageIndex;
            int pageSize = this.ANP.PageSize;
            int recounts = bll.getLogsCountByUserId(int.Parse(Session["ManagerId"].ToString()), 2);
            Rep_UserLogsList.DataSource = bll.getPagerLogsInfoByUserId(int.Parse(Session["ManagerId"].ToString()), 2, pageIndex, pageSize, recounts);
            this.ANP.RecordCount = recounts;
            Rep_UserLogsList.DataBind();
            this.ANP.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP.CurrentPageIndex, this.ANP.PageCount, this.ANP.RecordCount, this.ANP.PageSize });
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bin_repLogs();
        }
        public void Bindrep_managerInfo()
        {
            SysManagerBll bll = new SysManagerBll();
            Vi_SysBackUserModel vsbum = new Vi_SysBackUserModel();
            vsbum = bll.getModelByManagerID(int.Parse(Session["ManagerId"].ToString()));
            lbl_ManName.Text = vsbum.UserName;
            lbl_RealName.Text = vsbum.RealName;
            lbl_Email.Text = vsbum.Email;
            lbl_Tel.Text = vsbum.PhoneNum;
        }

        protected void btn_UpdateInfo_Click(object sender, EventArgs e)
        {
            tab_updateTab.Visible = true;
            UserInfo.Visible = false;
            updateTips.Visible = true;
            //将管理员信息绑定上去
            SysManagerBll bll = new SysManagerBll();
            Vi_SysBackUserModel vsbum = new Vi_SysBackUserModel();
            vsbum = bll.getModelByManagerID(int.Parse(Session["ManagerId"].ToString()));
            txt_RealName.Text = vsbum.RealName;
            txt_Email.Text = vsbum.Email;
            txt_telNumber.Text = vsbum.PhoneNum;
            lbl_userName.Text = vsbum.UserName;
        }

        protected void btn_AddSingleManager_Click(object sender, EventArgs e)
        {

        }

        protected void btn_SaveInfo_Click(object sender, EventArgs e)
        {
            bool chkresult = true;
            if (txt_RealName.Text.Trim() == "")
            {
                lbl_msg_Name.Text = "(*)";
                lbl_msg_Name.ForeColor = Color.Red;
                chkresult = false;
            }
            if (txt_Email.Text.Trim() == "")
            {
                lbl_msg_Email.Text = "(*)";
                lbl_msg_Email.ForeColor = Color.Red;
                chkresult = false;
            }
            if (txt_telNumber.Text.Trim() == "")
            {
                lbl_msg_telNum.Text = "(*)";
                lbl_msg_telNum.ForeColor = Color.Red;
                chkresult = false;
            }
            if (chkresult == false)
            {
                return;
            }
            //更新用户信息
            SysManagerBll bll = new SysManagerBll();
            Vi_SysBackUserModel vsbum = new Vi_SysBackUserModel();
            vsbum = bll.getModelByManagerID(int.Parse(Session["ManagerId"].ToString()));
            vsbum.RealName = txt_RealName.Text.Trim();
            vsbum.Email = txt_Email.Text.Trim();
            vsbum.PhoneNum = txt_telNumber.Text.Trim();
            vsbum.UpdateTime = DateTime.Now;
            if (txt_LoginPass.Text.Trim() != "")
            {
                getMD5 md5 = new getMD5();
                vsbum.UserPwd = md5.CalculateMD5Hash(txt_LoginPass.Text.Trim());
            }
            try
            {
                bll.UpdateManagerInfo(vsbum);
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('信息修改成功！')", true);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存失败,请重试')", true);
            }
            
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            tab_updateTab.Visible = false;
            UserInfo.Visible = true;
            updateTips.Visible = false;
        }
    }
}