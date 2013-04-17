using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;

namespace ProjectManage.Manager
{
    public partial class SysProjectUpdate : System.Web.UI.Page
    {
        private int index = 1;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                /*
                SysProjectBll bll = new SysProjectBll();
                if (bll.IsExistUpdate())
                {
                    isExistUpdate.Visible = true;
                }
                else
                {
                    isExistUpdate.Visible = false;
                }
                */
                isExistUpdate.Visible = false;
                BindAllProjectInfo();
            }
        }
        private void BindAllProjectInfo()
        {
            SysProjectBll bll = new SysProjectBll();
        //    rep_SysAllProject.DataSource = bll.GetAllProjectInfo();
         //   rep_SysAllProject.DataBind();

            int pageIndex = this.ANP.CurrentPageIndex;
            int pageSize = this.ANP.PageSize;
            index = (pageIndex - 1) * pageSize + 1;
            rep_SysAllProject.DataSource = bll.getAllProjectInfoPager(pageIndex, pageSize, bll.getAllProjectCounts(""), "");
            this.ANP.RecordCount = bll.getAllProjectCounts("");
            rep_SysAllProject.DataBind();
            this.ANP.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP.CurrentPageIndex, this.ANP.PageCount, this.ANP.RecordCount, this.ANP.PageSize });
            ViewState["index"] = index;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            SysProjectBll spb = new SysProjectBll();
            //更新T3数据库数据到当前系统
            updateProInfo upi = new updateProInfo();
            upi = spb.dataCopy();
            rep_Updateinfo.DataSource = upi.info;
            rep_Updateinfo.DataBind();
            
        }
        protected void btn_Next_Click(object sender, EventArgs e)
        {
            isExistUpdate.Visible = false;
            rep_Updateinfo.Visible = false;

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(ViewState["index"].ToString(), out index))
            {
                ViewState["index"] = index;
            }
            //绑定数据
            BindAllProjectInfo();
        }
        protected void rep_SysAllProject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lbl_id")).Text = Convert.ToString(index);
                index++;
            }
        }
    }
}