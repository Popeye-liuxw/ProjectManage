using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.Model;
using ProjectManage.BLL;

namespace ProjectManage.Manager
{
    public partial class SysConfigEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ViewState["id"] = 0;
                    string str = Request.QueryString["temp"].ToString();
                    if (str == "sys")
                    {
                        
                    }else if (str == "edit")
                    {
                        int Id = int.Parse(Request.QueryString["config"].ToString());
                        ViewState["id"] = Id;
                        BindEdit(Id);
                    }
                    else
                    {
                        Response.Write("传递参数有误！");
                        Response.End();
                    }                    
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
            }
        }

        private void BindEdit(int id)
        {
            SysMailConfig config = new SysMailConfig();
            Vi_SysEmailServerModel model = config.GetEmailServerConfig(id);
            if (model != null)
            {
                lbl_EmailName.Text = model.EmailName;
                txt_Address.Text = model.Address;
                txt_DisplayName.Text = model.DisplayName;
                txt_EmailName.Text = model.EmailName;
                txt_Port.Text = model.Port.ToString();
                txt_SMTPHost.Text = model.SMTPHost;
                txt_UserName.Text = model.UserName;
                //txt_UserPwd.Text = model.UserPwd;
                cbx_EnableSSL.Checked = model.EnableSSL == 1 ? true : false;
                cbx_State.Checked = model.State == (int)EmailState.OK ? true : false;
            }
        }

        private void ClearEdit()
        {
            txt_Address.Text = string.Empty;
            txt_DisplayName.Text = string.Empty;
            txt_EmailName.Text = string.Empty;
            txt_Port.Text = "25";
            txt_SMTPHost.Text = string.Empty;
            txt_UserName.Text = string.Empty;
            txt_UserPwd.Text = string.Empty;
            cbx_EnableSSL.Checked = false;
            cbx_State.Checked = false;
        }


        protected void btn_SaveInfo_Click(object sender, EventArgs e)
        {
            if (txt_DisplayName.Text.Trim() == string.Empty || txt_EmailName.Text.Trim() == string.Empty || txt_SMTPHost.Text.Trim() == string.Empty || txt_UserName.Text.Trim() == string.Empty || txt_UserPwd.Text.Trim() == string.Empty)
            {
                lbl_msg.Text = "*号字段为必填项";
                return;
            }
            int port;
            if (!int.TryParse(txt_Port.Text, out port))
            {
                lbl_msg.Text = "端口号设置错误，请输入数字";
                return;
            }
            try
            {
                int userid = (int)Session["ManagerId"];
                int id = (int)ViewState["id"];

                SysMailConfig config = new SysMailConfig(txt_UserName.Text, txt_UserPwd.Text, txt_EmailName.Text);
                bool result;
                if (id > 0)
                {
                    result = UpdataConfig(id, config,userid);
                }
                else
                {
                    result = config.SaveMailConfig(txt_DisplayName.Text, txt_Address.Text, port, txt_SMTPHost.Text, cbx_EnableSSL.Checked, cbx_State.Checked, userid);
                }
                    
                if (result)
                    lbl_msg.Text = "恭喜你，配置成功";
                else
                    lbl_msg.Text = "抱歉，配置失败，请重试";               
            }
            catch (Exception)
            {
                lbl_msg.Text = "抱歉，配置失败，请重试";
            }


        }

        private bool UpdataConfig(int id,SysMailConfig config,int userid)
        {
            bool result = false;
            try
            {
                Vi_SysEmailServerModel model = config.GetEmailServerConfig(id);
                if (model != null)
                {
                    model.Address = txt_Address.Text;
                    model.DisplayName = txt_DisplayName.Text;
                    model.EmailName = txt_EmailName.Text;
                    model.EnableSSL = cbx_EnableSSL.Checked ? 1 : 0;
                    model.Port = Convert.ToInt32(txt_Port.Text);
                    model.SMTPHost = txt_SMTPHost.Text;
                    model.State = cbx_State.Checked ? (int)EmailState.OK : (int)EmailState.NO;
                    model.UserID = userid;
                    model.UserName = txt_UserName.Text;
                    model.UserPwd = MD5Tool.MD5Encrypt(txt_UserPwd.Text);
                    result = config.UpdateEmailConfig(model);
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            String url = String.Format("SysConfigManage.aspx?temp=sys");
            Response.Redirect(url, false);
        }
    }
}