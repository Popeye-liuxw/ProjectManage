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
    public partial class PosiInfoManage : System.Web.UI.Page
    {
        private int index;
        private SysPosiInfoManage PosiInfo = new SysPosiInfoManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            index = 1;
            if (!IsPostBack)
            {                
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
            }
        }

        protected void btn_Commit_Click(object sender, EventArgs e)
        {
            Vi_SysPosiInfoModel posiInfo = new Vi_SysPosiInfoModel();
            if (txt_PosiName.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存失败，未录入职位名称')", true);
                return;
            }
            posiInfo.PosiName = txt_PosiName.Text;
            posiInfo.CreateTime = DateTime.Now;
            posiInfo.Back = txt_Back.Text;
            if (PosiInfo.SavePosiInfo(posiInfo))
            {
                DataBindingList();
                InitializeComponent();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Tip", "alert('保存失败,请重试')", true);
                return;
            }
        }
        private void InitializeComponent()
        {
            txt_PosiName.Text = string.Empty;
            txt_Back.Text = string.Empty;
        }
    }
}