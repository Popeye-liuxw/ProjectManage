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
    public partial class SysUserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定所有职位
                BindAllPosi();
                BindDepart();
                try
                {
                    int userId = int.Parse(Request.QueryString["id"].ToString());
                    //根据Id查询给用户信息，绑定到页面上！
                    //ddl_Posi.DataSource = 
                    BindUserBaseInfo(userId);
                    changeCheckState(userId);
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
            }
        }
        private void BindAllPosi() //绑定职位
        {
            SysPosiInfoManage spm = new SysPosiInfoManage();
            chk_PosiList.DataSource = spm.GetPosiInfoAll();
            chk_PosiList.DataTextField = "posiName";
            chk_PosiList.DataValueField = "iD";
            chk_PosiList.DataBind();
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
        

        //根据绑定职位checkBox选中状态
        private void changeCheckState(int userId)
        {
            //先得到这个人的所有职位ID 从职位权限表查询
            SysUserRoleBLL subll = new SysUserRoleBLL();
            List<Vi_SysUserRoleModel> suml = subll.getUserRolesByUserID(userId);
            //遍历得到当前checkBoxList对比改变所属职位的对应状态
            foreach (Vi_SysUserRoleModel item in suml)
            {
                for (int j = 0; j < chk_PosiList.Items.Count; j++)
                {
                    if (item.PosiID ==int.Parse(chk_PosiList.Items[j].Value))
                    {
                        chk_PosiList.Items[j].Selected = true;
                    }
                }
            }
        }
        //保存用户信息（包括基本信息和职位信息）
        private bool SaveInfo()
        {
            return false;
        }
        //根据userId得到用户详细信息
        private void BindUserBaseInfo(int userId)
        {
            UserBLL bll = new UserBLL();
            Vi_SysUserModel sum = bll.getUserModelByUserId(userId);
            userName.Value = sum.UserName;
            userPwd.Value = "****";
            Email.Value = sum.Email.Split('@')[0].ToString();
            telpnone.Value = sum.PhoneNum.Trim();
            telNum.Value = sum.Tel;
            lbl_realName.Text = "[" + sum.RealName + "]";
            lbl_realName.ForeColor = System.Drawing.Color.White;
            ddl_Department.SelectedValue = sum.GroupID;
        }
        protected void btn_SaveInfo_Click(object sender, EventArgs e)
        {
            //保存信息
            int userId = int.Parse(Request.QueryString["id"].ToString());
            //搜集页面信息保存数据
            UserBLL bll = new UserBLL();
            Vi_SysUserModel sum = bll.getUserModelByUserId(userId);
            //保存用户基本信息
            sum.ID = userId;
            sum.UserName = userName.Value;
            getMD5 md5 = new getMD5();
            if (userPwd.Value != "****")
            {
                sum.UserPwd = md5.CalculateMD5Hash(userPwd.Value.ToString());
            }
            if (Email.Value.Trim() != "")
            {
                sum.Email = Email.Value + "@visione.com.cn";
            }
            sum.PhoneNum = telpnone.Value;
            sum.Tel = telNum.Value;
            sum.GroupID = ddl_Department.SelectedValue;
            if (bll.UpdateUserDetailInfo(sum) > 0)
            {
                //更新成功
            }

            //保存职位信息到职位权限表
            //遍历职位信息
            SysUserRoleBLL subll = new SysUserRoleBLL();
            List<Vi_SysUserRoleModel> suml = subll.getUserRolesByUserID(userId);//用户所有职位信息
            try
            {
              
                    for (int j = 0; j < chk_PosiList.Items.Count; j++)
                    { 
                   //    foreach (Vi_SysUserRoleModel item in suml)
                   //    {
                        //如果选中
                        if (chk_PosiList.Items[j].Selected == true)
                        {
                            //且当前选中值不想等则增加一条记录
                            if (subll.IsExistRoleByUserIDAndPosiId(userId,int.Parse(chk_PosiList.Items[j].Value))<=0)
                            {
                                Vi_SysUserRoleModel virm = new Vi_SysUserRoleModel();
                                virm.PosiID = int.Parse(chk_PosiList.Items[j].Value);
                                virm.UserID = userId;
                                virm.Back = "";
                                virm.Back2 = 0;
                                //增加一条角色
                                virm.CreateTime = DateTime.Now;
                                subll.AddUserRole(virm);
                            }
                        }
                        else //判断数据库存在么,存在就删除
                        {

                            if (subll.IsExistRoleByUserIDAndPosiId(userId, int.Parse(chk_PosiList.Items[j].Value))>0)
                            {
                                subll.DelRolebyId(userId, int.Parse(chk_PosiList.Items[j].Value));
                            }
                        }
                    //}
                }
               
                lbl_msg.ForeColor = System.Drawing.Color.FromArgb(255, 106, 0);
                lbl_msg.Text = "用户信息修改出成功！";
            }
            catch (Exception)
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = "用户信息修改出现异常！";
            }

        }
    }
}