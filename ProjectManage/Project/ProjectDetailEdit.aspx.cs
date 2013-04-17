using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using System.Data;
using ProjectManage.Model;

namespace ProjectManage.Project
{
    /// <summary>
    /// 调整页面权限 2012/9/18
    /// by lxw
    /// </summary>
    public partial class ProjectDetailEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["prjID"] == null)
                {
                    Response.Redirect("ProjectBasicInfoManagement.aspx");
                    return;
                }
                string prjid = Request.QueryString["prjID"].ToString();
                string userid = Session["UserId"].ToString();                
                spn_Menu.QueryString = "&prjID=" + prjid;
                spn_Menu.MenuID = 3; //项目概况
                //BindAllUserToProManger();
                try
                {
                    int prjID = int.Parse(prjid);
                    int userID = int.Parse(userid);
                    Btn_Save.Visible = false;
                    SysProjectBll prj = new SysProjectBll();
                    if (prj.getAllProjectWithUser(userID, prjID))
                    {
                        SystemPermission sys = SystemLegalPowerBll.GetSystemPermission(userID, spn_Menu.MenuID);
                        if (sys == SystemPermission.Read || sys == SystemPermission.Write)
                        {
                            if (sys == SystemPermission.Write)
                            {
                                Btn_Save.Visible = true;
                            }
                            
                            BindProDetail(prjID);
                            BindDevUser();
                            BindTestUser();
                            BindMarket();                            
                            BindAllUserCHK(prjID);
                        }
                        else
                        {
                            tip.Visible = true;
                            lbl_Tip.Text = "你的系统权限不够,无法完成项目概况的编辑";
                            return;
                        }
                    }
                    else
                    {
                        tip.Visible = true;
                        lbl_Tip.Text = "抱歉，你并没有参与该项目";
                        return;
                    }
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }

                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"].ToString();
                ViewState["prjID"] = prjid;

            }
        }
        public void BindProDetail(int ProId)
        {
            //绑定基本信息
            SysProjectBll bll = new SysProjectBll();
            UserBLL users = new UserBLL();
            DataTable dt =  bll.getProDetailByProId(ProId);
            if (dt.Rows.Count > 0)
            {
                
               lbl_ProjId.Text = dt.Rows[0]["citemcode"].ToString();
               lbl_ProjName.Text= dt.Rows[0]["citemname"].ToString();
                lbl_ProName.ForeColor = System.Drawing.Color.FromArgb(75, 126, 189);
                lbl_ProName.Text = dt.Rows[0]["citemname"].ToString();
                /*
                //绑定项目类型
                DataTable dtProType = bll.getAllProType();
                ddl_ProType.DataSource = dtProType;
                ddl_ProType.DataTextField = "TypeName";
                ddl_ProType.DataValueField = "TypeValue";
                ddl_ProType.DataBind();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PrjType"].ToString()))
                {
                    ddl_ProType.SelectedValue = dt.Rows[0]["PrjType"].ToString();
                }
                else
                {
                    ddl_ProType.Items.Add("---默认---");
                    ddl_ProType.Items[ddl_ProType.Items.Count - 1].Value = "-1";
                    ddl_ProType.SelectedIndex = ddl_ProType.Items.Count - 1;
                }
                //绑定项目性质
                DataTable dtProNature = bll.getAllProNature();
                ddl_ProNature.DataSource = dtProNature;
                ddl_ProNature.DataTextField = "TypeName";
                ddl_ProNature.DataValueField = "TypeValue";
                ddl_ProNature.DataBind();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PrjNature"].ToString()))
                {
                    ddl_ProNature.SelectedValue = dt.Rows[0]["PrjNature"].ToString();
                }
                else
                {
                    ddl_ProNature.Items.Add("---默认---");
                    ddl_ProNature.Items[ddl_ProNature.Items.Count - 1].Value = "-1";
                    ddl_ProNature.SelectedIndex = ddl_ProNature.Items.Count - 1;
                }


                //绑定客户
                CustomerBll cbll = new CustomerBll();
                ddl_AllCus.DataSource =cbll.getAllCostomer();
                ddl_AllCus.DataTextField = "cCusAbbName";
                ddl_AllCus.DataValueField = "cCusCode";
                ddl_AllCus.DataBind();
                ddl_AllCus.Items.Add("--未设置--");
                ddl_AllCus.Items[ddl_AllCus.Items.Count - 1].Value = "-1";
                if(!String.IsNullOrEmpty(dt.Rows[0]["cCusCode"].ToString()))
                {
                    ddl_AllCus.SelectedValue = dt.Rows[0]["cCusCode"].ToString();
                }
                else
                {
                    ddl_AllCus.SelectedValue = "-1";
                }


                //绑定项目经理
                Vi_SysUserModel ds = bll.getProMangerByProId(ProId);
                if (ds != null)
                {
                    ddl_ProManager.SelectedValue = ds.ID.ToString();
                    ddl_ProManager.Enabled = false;
                }
                ddl_ProType.Enabled = false;
                ddl_ProNature.Enabled = false;
                ddl_AllCus.Enabled = false;
                */
                lbl_ProType.Text = dt.Rows[0]["PrjTypeName"].ToString();
                lbl_ProNature.Text = dt.Rows[0]["PrjNatureName"].ToString();
                lbl_AllCus.Text = dt.Rows[0]["cCusAbbName"].ToString();

                lbl_DeveloperRec.Text = bll.GetUserNameByID(dt.Rows[0]["DeveloperRec"].ToString());
                lbl_MarketRec.Text = bll.GetUserNameByID(dt.Rows[0]["TesterRec"].ToString());
                lbl_TesterRec.Text = bll.GetUserNameByID(dt.Rows[0]["MarketRec"].ToString());
            }

        }
        /*
        public void BindAllUserToProManger()
        {
            UserBLL bll = new UserBLL();
            ddl_ProManager.DataSource = bll.getAllVi_SysUser();
            ddl_ProManager.DataTextField = "RealName";
            ddl_ProManager.DataValueField = "ID";
            ddl_ProManager.DataBind();
            ddl_ProManager.Items.Add(new ListItem("--请选择--", "-1"));
            ddl_ProManager.SelectedValue = "-1";
        }
        public void BinCus()
        {
            
        }
        */
        /// <summary>
        /// 开发部
        /// </summary>
        public void BindDevUser()
        {
            SysProjectBll bll = new SysProjectBll();
            DataTable dt_dev = bll.getAllDevUserList();
            cbl_dev.DataSource = dt_dev;
            cbl_dev.DataTextField = "RealName";
            cbl_dev.DataValueField = "ID";
            cbl_dev.DataBind();
        }
        /// <summary>
        /// 测试部
        /// </summary>
        public void BindTestUser()
        {
            SysProjectBll bll = new SysProjectBll();
            DataTable dt_Tester = bll.getUserListByGroupId(4); //4代测试部
            cbl_TestUser.DataSource = dt_Tester;
            cbl_TestUser.DataTextField = "RealName";
            cbl_TestUser.DataValueField = "ID";
            cbl_TestUser.DataBind();
        }
        public void BindMarket()
        {
            SysProjectBll bll = new SysProjectBll();
            DataTable dt_Market = bll.getUserListByGroupId(5); //4代测试部
            cbl_market.DataSource = dt_Market;
            cbl_market.DataTextField = "RealName";
            cbl_market.DataValueField = "ID";
            cbl_market.DataBind();
        }
        public void BindAllUserCHK(int ProjectId)
        {
            DataTable dtDev = new DataTable();
            DataTable dtTest = new DataTable();
            DataTable dtMarket = new DataTable();
            SysProjectBll bll = new SysProjectBll();
            dtDev = bll.getUserListbyUserType(ProjectId, "Vi_DeveloperRec");
            dtTest = bll.getUserListbyUserType(ProjectId, "Vi_TesterRec");
            dtMarket = bll.getUserListbyUserType(ProjectId, "Vi_MarketRec");
            BindUsers(dtDev, cbl_dev);
            BindUsers(dtTest, cbl_TestUser);
            BindUsers(dtMarket, cbl_market);
        }
        /// <summary>
        /// 选项勾选
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cbl"></param>
        public void BindUsers(DataTable dt, CheckBoxList cbl)
        {
            foreach (DataRow dr in dt.Rows)
            {
                for (int j = 0; j < cbl.Items.Count; j++)
                {
                    if (dr["StaffID"].ToString() == cbl.Items[j].Value)
                    {
                        cbl.Items[j].Selected = true;
                        cbl.Items[j].Text = "<span class='checkedUser'>" + cbl.Items[j].Text + "</span>";

                    }
                }
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SysProjectBll bll = new SysProjectBll();
                int ProjectId = int.Parse(ViewState["prjID"].ToString());
                int UserId = int.Parse(ViewState["userID"].ToString());
                //string dsa = ProjectId.ToString();
                /*
                if (ddl_ProManager.SelectedValue == "-1")
                {
                    lbl_msg.Text = "请选择项目经理,该项为必选项";
                    return;
                }
                */
                DataTable dt = bll.getProDetailByProId(ProjectId);
                //遍历循环开发人员
                for (int i = 0; i < cbl_dev.Items.Count; i++)
                {
                    if (cbl_dev.Items[i].Selected == true)//选中
                    {
                        DataTable dtforId = bll.IsExistUserByProId(" Vi_DeveloperRec ", int.Parse(cbl_dev.Items[i].Value.ToString()), ProjectId);
                        if (dtforId.Rows.Count <= 0)
                        {
                            //根据项目Id和员工ID得到编号ID，由于上面的没有获取到擦
                            Vi_DeveloperRecModel vdrm = new Vi_DeveloperRecModel();
                            vdrm.StaffID = int.Parse(cbl_dev.Items[i].Value.ToString());
                            vdrm.ProjectID = ProjectId;
                            vdrm.ProjectName = dt.Rows[0]["citemname"].ToString();
                            vdrm.UserID = UserId;
                            vdrm.CreateTime = DateTime.Now;
                            vdrm.UpdateTime = DateTime.Now;
                            bll.AddSingleDev(vdrm);
                        }
                    }
                    else //如果没选中则查看
                    {

                        string xxs = cbl_dev.Items[i].Value.ToString();
                        DataTable dtforId = bll.IsExistUserByProId(" Vi_DeveloperRec ", int.Parse(cbl_dev.Items[i].Value.ToString()), ProjectId);
                        if (dtforId.Rows.Count > 0)
                        {
                            //没选中之前存在 则删除记录
                            int delId = int.Parse(dtforId.Rows[0]["ID"].ToString());
                            bll.DeletSingleDevById(delId);
                        }
                    }
                }
                //循环测试人员
                for (int x = 0; x < cbl_TestUser.Items.Count; x++)
                {
                    if (cbl_TestUser.Items[x].Selected == true)
                    {
                        DataTable drforId = bll.IsExistUserByProId(" Vi_TesterRec ", int.Parse(cbl_TestUser.Items[x].Value.ToString()), ProjectId);
                        if (drforId.Rows.Count <= 0)
                        {
                            Vi_TesterRecModel vitrm = new Vi_TesterRecModel();
                            vitrm.StaffID = int.Parse(cbl_TestUser.Items[x].Value.ToString());
                            vitrm.ProjectID = ProjectId;
                            vitrm.ProjectName = dt.Rows[0]["citemname"].ToString();
                            vitrm.UserID = UserId;
                            vitrm.CreateTime = DateTime.Now;
                            vitrm.UpdateTime = DateTime.Now;
                            bll.AddSingleTester(vitrm);
                        }
                    }
                    else
                    {
                        DataTable drforId = bll.IsExistUserByProId(" Vi_TesterRec ", int.Parse(cbl_TestUser.Items[x].Value.ToString()), ProjectId);
                        if (drforId.Rows.Count > 0)
                        {
                            int delId = int.Parse(drforId.Rows[0]["ID"].ToString());
                            bll.DeleSingleTester(delId);
                        }
                    }
                }
                //循环商务人员
                for (int y = 0; y < cbl_market.Items.Count; y++)
                {
                    if (cbl_market.Items[y].Selected == true)
                    {
                        DataTable dtforId = bll.IsExistUserByProId(" Vi_MarketRec ", int.Parse(cbl_market.Items[y].Value.ToString()), ProjectId);
                        if (dtforId.Rows.Count <= 0)
                        {
                            Vi_MarketRecModel vimrm = new Vi_MarketRecModel();
                            vimrm.StaffID = int.Parse(cbl_market.Items[y].Value.ToString());
                            vimrm.ProjectID = ProjectId;
                            vimrm.ProjectName = dt.Rows[0]["citemname"].ToString();
                            vimrm.UserID = UserId;
                            vimrm.CreateTime = DateTime.Now;
                            vimrm.UpdateTime = DateTime.Now;
                            bll.AddSingleMarket(vimrm);
                        }
                    }
                    else
                    {
                        DataTable dtforId = bll.IsExistUserByProId(" Vi_MarketRec ", int.Parse(cbl_market.Items[y].Value.ToString()), ProjectId);
                        if (dtforId.Rows.Count > 0)
                        {
                            int delId = int.Parse(dtforId.Rows[0]["ID"].ToString());
                            bll.DelSingleMarket(delId);
                        }
                    }
                }

                Vi_ProjectInfoModel prj = bll.GetProjectInfoModel(ProjectId);
                if (prj != null)
                {
                    prj.UserID = UserId;
                    prj.UpdateTime = DateTime.Now;
                    bll.UpdateProJectinfo(prj);
                }

                //更新基本信息

                /*处理项目经理 
                DataTable dtManager = bll.getStaffIdByProId(ProjectId);
                if (dtManager.Rows.Count < 0)
                {
                    Vi_ManagerRecModel vimrm = new Vi_ManagerRecModel();
                    vimrm.ProjectID = ProjectId;
                    vimrm.ProjectName = lbl_ProName.Text;
                    vimrm.StaffID = int.Parse(ddl_ProManager.SelectedValue.ToString());
                    vimrm.UpdateTime = DateTime.Now;
                    vimrm.UserID = int.Parse(Session["UserId"].ToString());
                    vimrm.CreateTime = DateTime.Now;
                    bll.AddAProjectManager(vimrm);
                }
                */

                lbl_msg.Text = "项目信息修改成功！";
            }
            catch (Exception)
            {
                lbl_msg.Text = "项目信息修改失败!";
 
            }

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectBasicInfoManagement.aspx");
        }

        //判断给用户是否参与该项目

    }
}