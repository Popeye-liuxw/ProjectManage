using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using ProjectManage.Model;
using ProjectManage.Common;

namespace ProjectManage.Manager
{
    public partial class SysUserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepart();
            }
        }

        protected void btn_SaveInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RealName.Value))
            {
                lbl_msg.Text = "未输入用户真实姓名";
                return;
            }
            if (string.IsNullOrEmpty(userName.Value))
            {
                lbl_msg.Text = "未输入用户名";
                return;
            }
            if (string.IsNullOrEmpty(Email.Value))
            {
                lbl_msg.Text = "未输入邮箱地址";
                return;
            }
            UserBLL bll = new UserBLL();
            Vi_SysUserModel sum = new Vi_SysUserModel();
            //保存用户基本信息
            
            sum.UserName = userName.Value;
           
            if (Email.Value.Trim() != "")
            {
                sum.Email = Email.Value + "@visione.com.cn";
            }
            //sum.EmployeeID = item.cPersonCode.Trim(); //员工编号
           
            //m.PersonProp = item.cPersonProp.Trim();//职位名称
            sum.RealName = RealName.Value;//真实姓名
            sum.Birthday = Convert.ToDateTime(Birthday.Value);
            sum.UpdateTime = DateTime.Now;//更新时间
            sum.CreateTime = DateTime.Now;
            sum.PhoneNum = telpnone.Value;
            sum.GroupID = ddl_Department.SelectedValue;
            if (bll.AddUserModelInfo(sum) > 0)
            {
                lbl_msg.ForeColor = System.Drawing.Color.FromArgb(255, 106, 0);
                lbl_msg.Text = "用户信息添加成功！";
            }
            else
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = "用户信息添加失败！";
            }
        }
        //得到所有部门
        private void BindDepart()
        {
            DepartmentBll bll = new DepartmentBll();
            ddl_Department.DataSource = bll.getAllDepartment();
            ddl_Department.DataTextField = "cDepName";
            ddl_Department.DataValueField = "cDepCode";
            ddl_Department.DataBind();
        }
    }
}