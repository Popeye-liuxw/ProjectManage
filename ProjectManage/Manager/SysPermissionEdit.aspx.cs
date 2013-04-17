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
    public partial class SysPermissionEdit : System.Web.UI.Page
    {
        private SysPositionManage positionManage = new SysPositionManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string posiID = Request.QueryString["posi"];
                int posi = 0;
                try
                {
                    if (string.IsNullOrEmpty(posiID) || string.IsNullOrEmpty(Request.QueryString["temp"]))
                    {
                        Response.Redirect("SysPermissionManage.aspx", true);
                    }
                    posi = int.Parse(posiID);
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
                ViewState["posiID"] = posiID;
                BindingPosiInfo(posi);
                BindingModules();             

            }
        }

        private void BindingModules()
        {
            this.rpt_List.DataSource = positionManage.GetSysModuleAll();
            this.rpt_List.DataBind();
        }

        private void BindingPosiInfo(int posiID)
        {
            lbl_posiInfo.Text = "未知";
            SysPosiInfoManage posiInfo = new SysPosiInfoManage();
            Vi_SysPosiInfoModel posiInfoModel = posiInfo.GetPosiInfo(posiID);
            if (posiInfoModel != null) lbl_posiInfo.Text = posiInfoModel.PosiName;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = string.Empty;
            if (ViewState["posiID"] == null) return;
            List<PermissionMuster> posiperms = new List<PermissionMuster>();  
            int posiID  = 0;
            if (int.TryParse((string)ViewState["posiID"], out posiID))
            {
                foreach (RepeaterItem item in rpt_List.Items)
                {
                    Vi_SysPosiPermModel posiperm = new Vi_SysPosiPermModel();
                    PermissionMuster permissionMuster = new PermissionMuster();
                    posiperm.PosiID = posiID;
                    posiperm.PosiName = lbl_posiInfo.Text;
                    posiperm.SysModuleID = int.Parse(((Label)item.FindControl("lbl_SysModuleID")).Text);
                    PermissionModel permissionModel = new PermissionModel(((CheckBox)item.FindControl("cbx_Read")).Checked, ((CheckBox)item.FindControl("cbx_Write")).Checked);
                    posiperm.Permissions = positionManage.GetPermissionByModel(permissionModel);
                    permissionMuster.ModuleName = ((Label)item.FindControl("lbl_ModuleName")).Text;
                    //permissionMuster.PermissionID = int.Parse(((Label)item.FindControl("lbl_PermissionID")).Text);
                    permissionMuster.Permissions = permissionModel;
                    permissionMuster.PosiID = posiID;
                    permissionMuster.PosiPermModel = posiperm;
                    permissionMuster.SysModuleID = posiperm.SysModuleID;
                    posiperms.Add(permissionMuster);
                }

                if (positionManage.SavePermission(posiperms))
                {
                    Response.Redirect("SysPermissionManage.aspx", true);
                }
                else
                {
                    lbl_msg.Text = string.Format("{0} 权限设定失败，请稍候重试!", lbl_posiInfo.Text);
                }

            }
            else
            {
                lbl_msg.Text = string.Format("{0} 权限设定失败，系统获取职位相关信息错误", lbl_posiInfo.Text);
            }
        }

        protected void rpt_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int posiID = Convert.ToInt32(ViewState["posiID"]);
                int SysModuleID = Convert.ToInt32((((Label)e.Item.FindControl("lbl_SysModuleID")).Text));
                PermissionModel permissionModel = positionManage.GetPermissionModel(posiID, SysModuleID);
                ((CheckBox)e.Item.FindControl("cbx_Read")).Checked = permissionModel.Read;
                ((CheckBox)e.Item.FindControl("cbx_Write")).Checked = permissionModel.Write;
            }
        }
    }
}