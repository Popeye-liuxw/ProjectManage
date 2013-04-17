using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;
using Wuqi.Webdiyer;
using ProjectManage.Common;

namespace ProjectManage.Manager
{
    public partial class UserManage : System.Web.UI.Page
    {
        public UserBLL bll = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            index = ((this.ANP.CurrentPageIndex - 1) * this.ANP.PageSize)+1;
            /*
            if (bll.IsExistUpdate())
            {
                isExistUpdate.Visible = true;
            }
            */
            
            if (!Page.IsPostBack)
            {
                BindDepart();
                BindRep(getStrWhere());
                
            }
        }
        public void BindRep(string sqlstr)
        {
            string strWhere =" " + sqlstr;

            int pageIndex = this.ANP.CurrentPageIndex;
            int pageSize = this.ANP.PageSize;
            rep_SysUser.DataSource = bll.getAllSysUser(pageIndex, pageSize, bll.getAllUserREC(strWhere), strWhere);
            this.ANP.RecordCount = bll.getAllUserREC(strWhere);
            rep_SysUser.DataBind();
            this.ANP.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP.CurrentPageIndex, this.ANP.PageCount, this.ANP.RecordCount, this.ANP.PageSize });

        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {
            isExistUpdate.Visible = false;
            rep_Updateinfo.Visible = false;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            try
            {
                
                upddateInfo ui = new upddateInfo();
                ui = bll.dataCopy();
                int count = ui.addNum + ui.updateNum;
                lbl_updatemsg.Text = "您本次一共更新了" + count.ToString() + "条数据！" + "其中新增" + ui.addNum.ToString() + "条,同步修改" + ui.updateNum.ToString() + "条！";
                rep_Updateinfo.DataSource = ui.info;
                rep_Updateinfo.DataBind();
                
            }
            catch (Exception)
            {
                lbl_updatemsg.Text = "本次更新数据发生异常！";
            }
        }

        protected void rep_SysUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


        }
        int index = 1;
        protected void rep_SysUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    ((Label)e.Item.FindControl("lbl_id")).Text = Convert.ToString(index);
            //    index++;
            //}
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRep(getStrWhere());
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindRep(getStrWhere());
        }

        public string getStrWhere()
        {
            string sqlstr = " where 1=1 ";
            if (SQLInjection.FilterStr(txt_UserName.Text.Trim()).Trim() != "")
            {
                sqlstr = sqlstr + " AND UserName like '%" +SQLInjection.FilterStr(txt_UserName.Text.Trim())+ "%' ";
            }
            if (SQLInjection.FilterStr(txt_RealName.Text.Trim()).Trim() != "")
            {
                sqlstr = sqlstr + " AND RealName like '%" + SQLInjection.FilterStr(txt_RealName.Text.Trim()) +"%' ";
            }
            if (SQLInjection.FilterStr(ddl_department.SelectedValue).Trim() != "-1")
            {
                sqlstr = sqlstr +" AND GroupID = '"+SQLInjection.FilterStr(ddl_department.SelectedValue)+"' ";
            }
            if (SQLInjection.FilterStr(txt_Email.Text.Trim()).Trim() != "")
            {
                sqlstr = sqlstr + " AND Email like %" + SQLInjection.FilterStr(txt_Email.Text.Trim()) +"% ";
            }
            return sqlstr;
        }
        public void BindDepart()
        {
            DepartmentBll bll = new DepartmentBll();
            ddl_department.DataSource = bll.getAllDepartment();
            ddl_department.DataTextField = "cDepName";
            ddl_department.DataValueField = "cDepCode";
            ddl_department.DataBind();
            ddl_department.Items.Add("---默认---");
            ddl_department.Items[ddl_department.Items.Count - 1].Value = "-1";
            ddl_department.SelectedIndex = ddl_department.Items.Count - 1;
        }

        protected void btn_AddUser_Click(object sender, EventArgs e)
        {
            
        }

    }
}