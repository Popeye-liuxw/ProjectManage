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
    public partial class SysPermissionManage : System.Web.UI.Page
    {
        private int index;       
        private SysPosiInfoManage PosiInfo = new SysPosiInfoManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            index = 1;

            if (!IsPostBack)
            {
                gv_List.DataKeyNames = new string[] { "ID" };
                DataBindingList();
            }
        }

        private void DataBindingList()
        {
            gv_List.DataSource = PosiInfo.GetPosiInfoAll();
            gv_List.DataBind();
        }

        protected void gv_List_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (index++).ToString();
                e.Row.Cells[4].Text = PosiInfo.ExistsPosiPermByPosiID(gv_List.DataKeys[e.Row.RowIndex].Values[0].ToString());
            }
        }      

        protected void gv_List_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            String url = String.Format("SysPermissionEdit.aspx?temp=sys&posi={0}", gv_List.DataKeys[e.NewSelectedIndex].Values[0]);
            Response.Redirect(url, false);
        }
    }
}