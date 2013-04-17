using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;

namespace ProjectManage.Manager
{
    public partial class SysDepartmentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartmentBll bll = new DepartmentBll();
                rep_DepartmentList.DataSource = bll.getAllDepartment();
                rep_DepartmentList.DataBind();

            }
        }
        int index = 0;
        protected void rep_DepartmentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lbl_id")).Text = Convert.ToString(index + 1);
                index++;
            }
        }
    }
}