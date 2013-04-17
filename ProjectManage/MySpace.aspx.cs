using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using System.Data;
using ProjectManage.Model;
using ProjectManage.Common;

namespace ProjectManage
{
    public partial class MySpace : System.Web.UI.Page
    {
        private DataTable dtUserInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    int UserId = int.Parse(Session["UserId"].ToString());
                    Bin_repLogs();
                    BindUserInfoData(UserId);
                }
                else
                {
                    Response.Write("请勿非法访问本页面！");
                    Response.End();
                }
            }
        }

        private bool BindUserInfoData(int UserId)
        {
            bool result = false;
           // [UserName],[UserPwd],[RealName],[Birthday],[Email],[PhoneNum],[Tel],[EmployeeID],[GroupID]
            UserBLL bll = new UserBLL();
            dtUserInfo = bll.getUserInfoById(UserId);
            if (dtUserInfo.Rows.Count > 0)
            {
                lbl_Department.Text = dtUserInfo.Rows[0]["cDepName"].ToString();
                lbl_UserName.Text = dtUserInfo.Rows[0]["RealName"].ToString();
                lbl_Email.Text = dtUserInfo.Rows[0]["Email"].ToString();
                txt_telphone.Text = dtUserInfo.Rows[0]["PhoneNum"].ToString();
                //Session["RealName"] = dtUserInfo.Rows[0]["RealName"].ToString();
                //Session["Department"] = dtUserInfo.Rows[0]["cDepName"].ToString();
                //Label lb = this.Master.FindControl("lbl_RealName") as Label;
                //lb.Text = dtUserInfo.Rows[0]["RealName"].ToString();
                //Label lb1 = this.Master.FindControl("lbl_department") as Label;
                //lb1.Text = dtUserInfo.Rows[0]["cDepName"].ToString();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //修改密码,手机号
            UserBLL bll = new UserBLL();
            Vi_SysUserModel model = bll.getUserModelByUserId(int.Parse(Session["UserId"].ToString()));
            //先验证手机号
            if (txt_telphone.Text == "")
            {
                lbl_msg.Text = "请输入你的手机号码！";
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_telphone.Text.Trim(), @"^[1]+[3,5,8]+\d{9}"))
            {
                //不符合规则
                lbl_msg.Text = "请输入正确的手机号码！";
                return;
            }
            //手机号码不修改 密码也没输入则不更新
            if (model.PhoneNum == txt_telphone.Text.Trim() && txt_oldPwd.Text.Trim() == "" && txt_newPwd.Text.Trim() == "" && txt_renewPwd.Text.Trim() == "")
            {

            }//说明有密码框填写了数据 判断更新
            else
            {
                getMD5 md5 = new getMD5();
                model.PhoneNum = txt_telphone.Text.Trim();
                if (txt_oldPwd.Text != "")
                {
                    if (txt_oldPwd.Text == "")
                    {
                        lbl_msg.Text = "请输入你的新密码！";
                        return;
                    }
                    if (txt_renewPwd.Text == "")
                    {
                        lbl_msg.Text = "请重复输入你的新密码！";
                        return;
                    }
                    if (txt_newPwd.Text != txt_renewPwd.Text)
                    {
                        lbl_msg.Text = "两次输入密码不一致！";
                        return;
                    }
                    if (md5.CalculateMD5Hash(txt_oldPwd.Text) != model.UserPwd)
                    {
                        lbl_msg.Text = "旧密码输入错误！";
                        return;
                    }
                    model.UserPwd = md5.CalculateMD5Hash(txt_renewPwd.Text);
                }
                //验证通过 手机的先不验证 也是正则 擦
                //根据用户ID得到当前用户实体类
                if (bll.UpdateUserDetailInfo(model) > 0)
                {
                    if (txt_newPwd.Text == "")
                    {
                        lbl_msg.Text = "手机号码修改成功！";
                        return;
                    }
                    else
                    {
                        lbl_msg.Text = "密码修改成功！";
                        return;
                    }
                }
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = "提示：只填写手机号码，不填写密码信息默认只更新手机号码！";
            MyspaceUpdate.Visible = true;
            MySpaceDetail.Visible = false;
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            MyspaceUpdate.Visible = false;
            MySpaceDetail.Visible = true;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bin_repLogs();
        }
        private void Bin_repLogs()
        {
            SysManagerBll bll = new SysManagerBll();
            int pageIndex = this.ANP.CurrentPageIndex;
            int pageSize = this.ANP.PageSize;
            int recounts = bll.getLogsCountByUserId(int.Parse(Session["UserId"].ToString()), 1);
            DataTable dt = bll.getPagerLogsInfoByUserId(int.Parse(Session["UserId"].ToString()), 1, pageIndex, pageSize, recounts);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = dt.Rows[i]["Operate"].ToString();
                int index = tmp.IndexOf("！") + 1;
                if (tmp.Length > index)
                {
                    dt.Rows[i]["Operate"] = tmp.Remove(index);
                }
            }
            userLog_List.DataSource = dt;
            this.ANP.RecordCount = recounts;
            userLog_List.DataBind();
            this.ANP.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP.CurrentPageIndex, this.ANP.PageCount, this.ANP.RecordCount, this.ANP.PageSize });
 
        }
    }
}