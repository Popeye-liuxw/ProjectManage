using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage.Manager
{
    public partial class SysProjectEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["key"] == null)
                {
                    Response.Write("参数有误");
                    Response.End();
                }
                string key = Request.QueryString["key"].ToString();                                
                ViewState["key"] = key;
                int id;
                if (int.TryParse(key, out id))
                {
                    if (Request.QueryString["uke"] == null)
                    {
                        BindProDetail(id);
                    }
                    else
                    {
                        DeleteProDetail(id);
                    }
                }
            }
        }

        public void DeleteProDetail(int ProId)
        {
            //暂时不实现项目删除功能
        }

        public void BindProDetail(int ProId)
        {
            //绑定基本信息
            SysProjectBll bll = new SysProjectBll();
            UserBLL bllUser = new UserBLL();
            DataTable dt = bll.getProDetailByProId(ProId);
            if (dt.Rows.Count > 0)
            {

                txt_ProCode.Text = dt.Rows[0]["citemcode"].ToString();
                lbl_Updatetitle.Text = dt.Rows[0]["citemname"].ToString();
                //lbl_Updatetitle.ForeColor = System.Drawing.Color.FromArgb(75, 126, 189);
                txt_ProName.Text = dt.Rows[0]["citemname"].ToString();

                //绑定项目类型
                DataTable dtProType = bll.getAllProType();
                ddl_SelectProType.DataSource = dtProType;
                ddl_SelectProType.DataTextField = "TypeName";
                ddl_SelectProType.DataValueField = "TypeValue";
                ddl_SelectProType.DataBind();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PrjType"].ToString()))
                {
                    ddl_SelectProType.SelectedValue = dt.Rows[0]["PrjType"].ToString();
                }
                else
                {
                    ddl_SelectProType.Items.Add("---默认---");
                    ddl_SelectProType.Items[ddl_SelectProType.Items.Count - 1].Value = "-1";
                    ddl_SelectProType.SelectedIndex = ddl_SelectProType.Items.Count - 1;
                }
                //绑定项目性质
                DataTable dtProNature = bll.getAllProNature();
                ddl_SelectProNature.DataSource = dtProNature;
                ddl_SelectProNature.DataTextField = "TypeName";
                ddl_SelectProNature.DataValueField = "TypeValue";
                ddl_SelectProNature.DataBind();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PrjNature"].ToString()))
                {
                    ddl_SelectProNature.SelectedValue = dt.Rows[0]["PrjNature"].ToString();
                }
                else
                {
                    ddl_SelectProNature.Items.Add("---默认---");
                    ddl_SelectProNature.Items[ddl_SelectProNature.Items.Count - 1].Value = "-1";
                    ddl_SelectProNature.SelectedIndex = ddl_SelectProNature.Items.Count - 1;
                }


                //绑定客户
                CustomerBll cbll = new CustomerBll();
                ddl_SelectCustomer.DataSource = cbll.getAllCostomer();
                ddl_SelectCustomer.DataTextField = "cCusAbbName";
                ddl_SelectCustomer.DataValueField = "cCusCode";
                ddl_SelectCustomer.DataBind();
                ddl_SelectCustomer.Items.Add("--未设置--");
                ddl_SelectCustomer.Items[ddl_SelectCustomer.Items.Count - 1].Value = "-1";
                if (!String.IsNullOrEmpty(dt.Rows[0]["cCusCode"].ToString()))
                {
                    ddl_SelectCustomer.SelectedValue = dt.Rows[0]["cCusCode"].ToString();
                }
                else
                {
                    ddl_SelectCustomer.SelectedValue = "-1";
                }
                List<Vi_SysUserModel> users = bllUser.getAllVi_SysUser();
                //bindUserList(ddl_SelectProManager, users);//取消项目经理

                DataTable user = bll.getAllUserList();
                bindUserList(ddl_SelectDeveloperRec, user);
                bindUserList(ddl_SelectTesterRec, user);
                bindUserList(ddl_SelectMarketRec, user);
                try
                {
                    if (!String.IsNullOrEmpty(dt.Rows[0]["DeveloperRec"].ToString()))
                    {
                        ddl_SelectDeveloperRec.SelectedValue = dt.Rows[0]["DeveloperRec"].ToString();
                    }

                    if (!String.IsNullOrEmpty(dt.Rows[0]["TesterRec"].ToString()))
                    {
                        ddl_SelectTesterRec.SelectedValue = dt.Rows[0]["TesterRec"].ToString();
                    }

                    if (!String.IsNullOrEmpty(dt.Rows[0]["MarketRec"].ToString()))
                    {
                        ddl_SelectMarketRec.SelectedValue = dt.Rows[0]["MarketRec"].ToString();
                    }
                    if (!String.IsNullOrEmpty(dt.Rows[0]["bclose"].ToString()))
                    {
                        if (dt.Rows[0]["bclose"].ToString().Trim() == "0")
                        {
                            ddl_SelectClose.SelectedValue = "0";
                        }
                        else
                        {
                            ddl_SelectClose.SelectedValue = "1";
                        }
                    }
                }
                catch (Exception)
                {
                    ddl_SelectDeveloperRec.SelectedValue = "-1";
                    ddl_SelectTesterRec.SelectedValue = "-1";
                    ddl_SelectMarketRec.SelectedValue = "-1";
                }
            }

        }

        private void bindUserList(DropDownList ddl, DataTable users)
        {
            ddl.DataSource = users;
            ddl.DataTextField = "RealName";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Add("--请选择--");
            ddl.Items[ddl.Items.Count - 1].Value = "-1";
            ddl.SelectedIndex = ddl.Items.Count - 1;
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            #region
            bool checkResult = true; //检查所有必填项是否填写
            if (txt_ProName.Text.Trim() == "")
            {
                lbl_msg_ProName.Text = "必填！";
                lbl_msg_ProName.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_ProName.Text = "";
            }
            if (txt_ProCode.Text == "")
            {
                lbl_msg_ProCode.Text = "必填！";
                lbl_msg_ProCode.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_ProCode.Text = "";
            }
            if (ddl_SelectProType.SelectedValue == "-1")
            {
                lbl_msg_ProType.Text = "必填！";
                lbl_msg_ProType.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_ProType.Text = "";
            }
            if (ddl_SelectProNature.SelectedValue == "-1")
            {
                lbl_msg_ProNature.Text = "必填！";
                lbl_msg_ProNature.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_ProNature.Text = "";
            }
            if (ddl_SelectCustomer.SelectedValue == "-1")
            {
                lbl_msg_Customer.Text = "必填！";
                lbl_msg_Customer.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_Customer.Text = "";
            }
            /*
            if (ddl_SelectProManager.SelectedValue == "-1")
            {
                lbl_msg_ProManger.Text = "必填！";
                lbl_msg_ProManger.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_ProManger.Text = "";
            }
            */
            if (ddl_SelectDeveloperRec.SelectedValue == "-1")
            {
                lbl_msg_DeveloperRec.Text = "必填！";
                lbl_msg_DeveloperRec.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_DeveloperRec.Text = "";
            }
            if (ddl_SelectTesterRec.SelectedValue == "-1")
            {

                lbl_msg_TesterRec.Text = "必填！";
                lbl_msg_TesterRec.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_TesterRec.Text = "";
            }
            if (ddl_SelectMarketRec.SelectedValue == "-1")
            {

                lbl_msg_MarketRec.Text = "必填！";
                lbl_msg_MarketRec.ForeColor = System.Drawing.Color.Red;
                checkResult = false;
            }
            else
            {
                lbl_msg_MarketRec.Text = "";
            }
            #endregion
            if (checkResult == true) //如果必填项都填写
            {

                try
                {
                    string key = ViewState["key"].ToString();
                    int id;
                    if (int.TryParse(key, out id))
                    {
                        //执行保存操作
                        SysProjectBll bll = new SysProjectBll();
                        Vi_ProjectInfoModel vipim = bll.GetProjectInfoModel(id);
                        vipim.bclose = int.Parse(ddl_SelectClose.SelectedValue);
                        vipim.citemname = txt_ProName.Text.Trim();//项目名称
                        vipim.citemcode = txt_ProCode.Text.Trim();//项目编号                    
                        vipim.cCusCode = ddl_SelectCustomer.SelectedValue.ToString();//客户名称
                        vipim.PrjType = int.Parse(ddl_SelectProType.SelectedValue.ToString());//项目类型
                        vipim.PrjNature = int.Parse(ddl_SelectProNature.SelectedValue.ToString());//项目性质                    
                        vipim.DeveloperRec = int.Parse(ddl_SelectDeveloperRec.SelectedValue.ToString());
                        vipim.TesterRec = int.Parse(ddl_SelectTesterRec.SelectedValue.ToString());
                        vipim.MarketRec = int.Parse(ddl_SelectMarketRec.SelectedValue.ToString());
                        if (bll.UpdateProJectinfo(vipim) > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存成功！');</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存失败！');</script>");
                }
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SysProjectUpdate.aspx");
        }
    }
}