using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManage.BLL;
using System.Web.UI.HtmlControls;
using System.Data;
using ProjectManage.Model;


namespace ProjectManage
{
    /// <summary>
    /// 调整页面权限 2012/9/18
    /// by lxw
    /// </summary>
    public partial class ProjectBasicInfoManagement : System.Web.UI.Page
    {
        int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                string userid = Session["UserId"].ToString();

                try
                {
                    int userID = int.Parse(userid);
                    btn_AddNewPro.Visible = false;
                    btn_OK.Visible = false;
                    btn_unProject.Visible = false;
                    BindItemsData("", -1, -1);
                    BindProType();
                    BindProNature();
                    SystemPermission sys = SystemLegalPowerBll.GetSystemPermission(userID, 2);//项目管理                   
                    if (sys == SystemPermission.Read || sys == SystemPermission.Write)
                    {

                        if (sys == SystemPermission.Write)
                        {
                            //市场主管添加项目基本信息
                            btn_AddNewPro.Visible = true;
                            btn_OK.Visible = true;
                            //btn_unProject.Visible = true; //分配项目功能去掉，项目经理流程去掉，以后根据项目负责人来管理
                        }
                    }
                    else
                    {
                        tip.Visible = true;
                        lbl_Tip.Text = "对不起，没有系统权限！";
                    }
                }
                catch (Exception)
                {
                    Response.Write("传递参数有误！");
                    Response.End();
                }
                ViewState["userID"] = userid;
                ViewState["userName"] = Session["RealName"] as string;
            }
        }

        public void BindUnData(string ProName, int ProTypeValue, int ProNatureName, int pagesize)
        {
            SysProjectBll bll = new SysProjectBll();
            string strWhere = " where 1=1";
            if (ProName != "")
            {
                ProName = ProjectManage.Common.SQLInjection.FilterStr(ProName);//fuck it
                strWhere += " and a.citemname like '%" + ProName + "%'";
            }
            if (ProTypeValue != -1)//类型
            {
                strWhere += " and [PrjType] =" + ProTypeValue;
            }
            if (ProNatureName != -1)//性质
            {
                strWhere += " and [PrjNature] = " + ProNatureName;
            }
            //组合字符串 过滤 然后传入查询
            //where b.TypeValue =   and c.TypeValue = 
            int pageIndex = this.ANP1.CurrentPageIndex;
            int pageSize = this.ANP1.PageSize = pagesize;
            this.ANP1.RecordCount = bll.getUnallocatedDataCount(strWhere);
            rep_Unallocated.DataSource = bll.getUnallocatedData(pageIndex, pageSize, this.ANP.RecordCount, strWhere);
            rep_Unallocated.DataBind();
            this.ANP1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP1.CurrentPageIndex, this.ANP1.PageCount, this.ANP1.RecordCount, this.ANP1.PageSize });
        }
        /// <summary>
        /// 分页绑定已分配项目信息
        /// </summary>
        /// 
        public void BindItemsData(string ProName, int ProTypeValue, int ProNatureName)
        {
            SysProjectBll bll = new SysProjectBll();
            string strWhere = " where 1=1";
            if (ProName != "")
            {
                ProName = ProjectManage.Common.SQLInjection.FilterStr(ProName);//fuck it
                strWhere += " and a.citemname like '%" + ProName + "%'";
            }
            if (ProTypeValue != -1)//类型
            {
                strWhere += " and [PrjType] =" + ProTypeValue;
            }
            if (ProNatureName != -1)//性质
            {
                strWhere += " and [PrjNature] = " + ProNatureName;
            }
            //组合字符串 过滤 然后传入查询
            //where b.TypeValue =   and c.TypeValue = 
            int pageIndex = this.ANP.CurrentPageIndex;
            int pageSize = this.ANP.PageSize = 18;
            this.ANP.RecordCount = bll.getCountByStrWhere(strWhere, int.Parse(Session["UserId"].ToString()));
            rep_PojList.DataSource = bll.getProjectsInfoByStrWhere(pageIndex, pageSize, this.ANP.RecordCount, strWhere, int.Parse(Session["UserId"].ToString()));
            rep_PojList.DataBind();
            this.ANP.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.ANP.CurrentPageIndex, this.ANP.PageCount, this.ANP.RecordCount, this.ANP.PageSize });
        }
        //绑定项目类型
        public void BindProType()
        {
            SysProjectBll bll = new SysProjectBll();
            ddl_ProType.DataSource = bll.getAllProType();
            ddl_ProType.DataTextField = "TypeName";
            ddl_ProType.DataValueField = "TypeValue";

            ddl_ProType.DataBind();
            ddl_ProType.Items.Add("---默认---");
            ddl_ProType.Items[ddl_ProType.Items.Count - 1].Value = "-1";
            ddl_ProType.SelectedIndex = ddl_ProType.Items.Count - 1;
        }
        public void BindProNature()
        {
            SysProjectBll bll = new SysProjectBll();
            ddl_ProNature.DataSource = bll.getAllProNature();
            ddl_ProNature.DataTextField = "TypeName";
            ddl_ProNature.DataValueField = "TypeValue";
            //ddl_ProNature.Items[0].Text = "请选择";
            // ddl_ProNature.Items[0].Value = "-1";
            ddl_ProNature.DataBind();
            ddl_ProNature.Items.Add("---默认---");
            ddl_ProNature.Items[ddl_ProNature.Items.Count - 1].Value = "-1";
            ddl_ProNature.SelectedIndex = ddl_ProNature.Items.Count - 1;

        }
        //绑定项目性质
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindItemsData("", -1, -1);
        }

        protected void rep_PojList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lbl_id")).Text = Convert.ToString(index + 1);
                index++;
                // HtmlTableCell td = e.Item.FindControl("tdEdit") as HtmlTableCell;
                // td.Visible = false;
            }



        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            //绑定已分配
            if (rep_PojList.Visible == true && btn_unProject.Text != "返回")
            {
                BindItemsData(sProName.Value.ToString().Trim(), int.Parse(ddl_ProType.SelectedValue.ToString()), int.Parse(ddl_ProNature.SelectedValue.ToString()));
            }
            else
            {
                BindUnData(sProName.Value.ToString().Trim(), int.Parse(ddl_ProType.SelectedValue.ToString()), int.Parse(ddl_ProNature.SelectedValue.ToString()), 18);
            }
            //绑定未分配
        }

        protected void rep_PojList_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            // HtmlTableCell th = e.Item.FindControl("thEdit") as HtmlTableCell;
            // th.Visible = false;
        }

        protected void btn_AddNewPro_Click(object sender, EventArgs e)
        {
            if (lbl_Updatetitle.Text != "添加项目" || AddProBaseInfo.Visible == false)
            {
                rep_PojList.Visible = false;
                ANP.Visible = false;
                //显示添加项目基本信息表格
                AddProBaseInfo.Visible = true;

                rep_Unallocated.Visible = false;
                ANP1.Visible = false;
                BindSelect();
                lbl_Updatetitle.Text = "添加项目";
                btn_OK.Text = "确定";
                txt_ProName.Text = "";
                txt_ProCode.Text = "";

                txt_ProName.Enabled = true;
                txt_ProCode.Enabled = true;

            }

        }


        public void BindSelect()
        {
            //项目类型 --
            SysProjectBll bll = new SysProjectBll();
            DataTable dt_ProType = bll.getAllProType();
            ddl_SelectProType.DataSource = dt_ProType;
            ddl_SelectProType.DataTextField = "TypeName";
            ddl_SelectProType.DataValueField = "TypeValue";
            ddl_SelectProType.DataBind();
            ddl_SelectProType.Items.Add("--请选择--");
            ddl_SelectProType.Items[ddl_SelectProType.Items.Count - 1].Value = "-1";
            ddl_SelectProType.SelectedIndex = ddl_SelectProType.Items.Count - 1;
            //项目性质 -- 
            DataTable dt_ProNature = bll.getAllProNature();
            ddl_SelectProNature.DataSource = dt_ProNature;
            ddl_SelectProNature.DataTextField = "TypeName";
            ddl_SelectProNature.DataValueField = "TypeValue";
            ddl_SelectProNature.DataBind();
            ddl_SelectProNature.Items.Add("--请选择--");
            ddl_SelectProNature.Items[ddl_SelectProNature.Items.Count - 1].Value = "-1";
            ddl_SelectProNature.SelectedIndex = ddl_SelectProNature.Items.Count - 1;

            //所属客户 -- 读出所有客户信息绑定

            //项目经理和负责人 -- 读出所有员工信息绑定
            UserBLL bllUser = new UserBLL();
            List<Vi_SysUserModel> users = bllUser.getAllVi_SysUser();
            //bindUserList(ddl_SelectProManager, users);//取消项目经理

            DataTable user =bll.getAllUserList();
            bindUserList(ddl_SelectDeveloperRec, user);
            bindUserList(ddl_SelectTesterRec, user);
            bindUserList(ddl_SelectMarketRec, user);

            // --  绑定客户信息
            CustomerBll cbll = new CustomerBll();
            ddl_SelectCustomer.DataSource = cbll.getAllCostomer();
            ddl_SelectCustomer.DataTextField = "cCusAbbName";
            ddl_SelectCustomer.DataValueField = "cCusCode";
            ddl_SelectCustomer.DataBind();
            ddl_SelectCustomer.Items.Add("--请选择--");
            ddl_SelectCustomer.Items[ddl_SelectCustomer.Items.Count - 1].Value = "-1";
            ddl_SelectCustomer.SelectedIndex = ddl_SelectCustomer.Items.Count - 1;
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


        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            rep_PojList.Visible = true;
            ANP.Visible = true;
            AddProBaseInfo.Visible = false;//添加项目基本信息隐藏
            rep_Unallocated.Visible = false;//未分配项目信息隐藏
            ANP1.Visible = false;//未分配项目信息分页隐藏

            btn_unProject.Text = "未分配项目";
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
                if (btn_OK.Text == "确定")//如果 btn_Ok text 为确定则代表是保存数据
                {
                    try
                    {
                        Vi_ProjectInfoModel vipim = new Vi_ProjectInfoModel();
                        //执行保存操作
                        SysProjectBll bll = new SysProjectBll();

                        vipim.citemname = txt_ProName.Text.Trim();//项目名称
                        vipim.citemcode = txt_ProCode.Text.Trim();//项目编号
                        vipim.I_id = 0;
                        vipim.cCusCode = ddl_SelectCustomer.SelectedValue.ToString();//客户名称
                        vipim.PrjType = int.Parse(ddl_SelectProType.SelectedValue.ToString());//项目类型
                        vipim.PrjNature = int.Parse(ddl_SelectProNature.SelectedValue.ToString());//项目性质
                        vipim.UserID = int.Parse(Session["UserId"].ToString());//UserId
                        vipim.DeveloperRec = int.Parse(ddl_SelectDeveloperRec.SelectedValue.ToString());
                        vipim.TesterRec = int.Parse(ddl_SelectTesterRec.SelectedValue.ToString());
                        vipim.MarketRec = int.Parse(ddl_SelectMarketRec.SelectedValue.ToString());
                        vipim.UpdateTime = DateTime.Now;
                        vipim.CreateTime = DateTime.Now;
                        int ProId = bll.AddSinglePro(vipim);//添加项目信息
                        if (ProId > 0)
                        {
                            //根据项目ID和用户ID判断项目经理存在不
                            //DataTable dtManager = bll.getStaffIdByProId(ProId);
                            //if (dtManager.Rows.Count > 0)//项目经理存在
                            //{
                            //  if (ddl_SelectProManager.SelectedValue.ToString().Trim() != dtManager.Rows[0]["StaffID"].ToString().Trim())
                            // {
                            /*
                                    Vi_ManagerRecModel vimrm = new Vi_ManagerRecModel();
                                    vimrm.ProjectID = ProId;
                                    vimrm.ProjectName = txt_ProName.Text.Trim();
                                    vimrm.StaffID = int.Parse(ddl_SelectProManager.SelectedValue.ToString());//得到项目经理ID
                                    vimrm.UpdateTime = DateTime.Now;
                                    vimrm.UserID = int.Parse(Session["UserId"].ToString());
                                    vimrm.CreateTime = DateTime.Now;
                                    bll.AddAProjectManager(vimrm);
                            */
                            // }
                            //}
                            /*
                            Vi_DeveloperRecModel vdrm = new Vi_DeveloperRecModel();
                            vdrm.StaffID = int.Parse(ddl_SelectDeveloperRec.SelectedValue.ToString());
                            vdrm.ProjectID = ProId;
                            vdrm.ProjectName = vipim.citemname;
                            vdrm.UserID = vipim.UserID;
                            vdrm.CreateTime = DateTime.Now;
                            vdrm.UpdateTime = DateTime.Now;
                            bll.AddSingleDev(vdrm);

                            Vi_TesterRecModel vitrm = new Vi_TesterRecModel();
                            vitrm.StaffID = int.Parse(ddl_SelectTesterRec.SelectedValue.ToString());
                            vitrm.ProjectID = ProId;
                            vitrm.ProjectName = vipim.citemname;
                            vitrm.UserID = vipim.UserID;
                            vitrm.CreateTime = DateTime.Now;
                            vitrm.UpdateTime = DateTime.Now;
                            bll.AddSingleTester(vitrm);


                            Vi_MarketRecModel vimrm = new Vi_MarketRecModel();
                            vimrm.StaffID = int.Parse(ddl_SelectMarketRec.SelectedValue.ToString());
                            vimrm.ProjectID = ProId;
                            vimrm.ProjectName = vipim.citemname;
                            vimrm.UserID = vipim.UserID;
                            vimrm.CreateTime = DateTime.Now;
                            vimrm.UpdateTime = DateTime.Now;
                            bll.AddSingleMarket(vimrm);
                            */
                        }
                    }
                    catch (Exception)
                    {

                    }
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('保存成功！');</script>");
                }
                /*
              else
              { 
                  //设置未分配项目信息

                  if (int.Parse(txt_ProName.ToolTip) != 0)//说明项目信息已经绑定
                  {
                      bool result = true;

                      if (ddl_SelectProType.SelectedValue == "-1")
                      {
                          lbl_msg_ProType.Text = "必填！";
                          result = false;
                      }
                      if (ddl_SelectCustomer.SelectedValue == "-1")
                      {
                          lbl_msg_Customer.Text = "必填！";
                          result = false;
                      }
                      if (ddl_SelectProNature.SelectedValue == "-1")
                      {
                          lbl_msg_ProNature.Text = "必填！";
                          result = false;
                      }
                      //if (ddl_SelectProManager.SelectedValue == "-1")
                      //{
                      //    lbl_msg_ProManger.Text = "必填";
                      //    result = false;
                      //}
                      if (result == true)
                      {
                          try
                          {
                              //根据未分配项目ID得到项目model
                              SysProjectBll BLL = new SysProjectBll();
                              Vi_ProjectInfoModel vipim = BLL.GetProjectInfoModel(int.Parse(txt_ProName.ToolTip));
                              vipim.PrjType = int.Parse(ddl_SelectProType.SelectedValue.ToString());
                              vipim.PrjNature = int.Parse(ddl_SelectProNature.SelectedValue.ToString());
                              vipim.cCusCode = ddl_SelectCustomer.SelectedValue.ToString();
                              //vipim.ID = int.Parse(txt_ProName.ToolTip);
                              vipim.DeveloperRec = int.Parse(ddl_SelectDeveloperRec.SelectedValue.ToString());
                              vipim.TesterRec = int.Parse(ddl_SelectTesterRec.SelectedValue.ToString());
                              vipim.MarketRec = int.Parse(ddl_SelectMarketRec.SelectedValue.ToString());
                              BLL.UpdateProJectinfo(vipim);

                                
                               //保存项目经理
                              Vi_ManagerRecModel model = new Vi_ManagerRecModel();
                              model.ProjectID = int.Parse(txt_ProName.ToolTip);
                              model.ProjectName = txt_ProName.Text.Trim();
                              model.StaffID = int.Parse(ddl_SelectProManager.SelectedValue.ToString());
                              model.UpdateTime = DateTime.Now;
                              model.CreateTime = DateTime.Now;
                              model.UserID = int.Parse(Session["UserId"].ToString());
                              BLL.AddAProjectManager(model);
                                
                          }
                          catch (Exception)
                          {
                              Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('项目信息修改失败！');</script>");
                          }
                          Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('项目信息修改成功！');</script>");

                      }
                      //修改model数值 保存数据
                  }
                  //


              }*/

            }
        }

        protected void ANP1_PageChanged(object sender, EventArgs e)
        {
            BindUnData("", -1, -1, 18);
        }

        protected void rep_Unallocated_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandSource.GetType() == typeof(LinkButton))
            {
                int Id = int.Parse(((Label)e.Item.FindControl("lbl_proId")).Text.Trim());
                //得到项目ID  根据项目id查询项目 model
                txt_ProName.ToolTip = Id.ToString();
                AddProBaseInfo.Visible = true;
                SysProjectBll BLL = new SysProjectBll();
                Vi_ProjectInfoModel model = BLL.GetProjectInfoModel(Id);
                txt_ProName.Text = model.citemname;
                txt_ProCode.Text = model.citemcode;
                BindSelect();
                BindUnData("", -1, -1, 12);
                txt_ProName.Enabled = false;
                txt_ProCode.Enabled = false;
                lbl_Updatetitle.Text = "编辑项目[" + model.citemname + "]";


                //编辑项目时 txt_ProName txt_ProCode 设置为 禁止修改



            }
        }

        protected void rep_Unallocated_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ((Label)e.Item.FindControl("lbl_UNid")).Text = Convert.ToString(index + 1);
                index++;
                // HtmlTableCell td = e.Item.FindControl("tdEdit") as HtmlTableCell;
                // td.Visible = false;
            }
        }

        protected void btn_unProject_Click(object sender, EventArgs e)
        {
            if (btn_unProject.Text == "返回")
            {
                AddProBaseInfo.Visible = false;
                rep_PojList.Visible = true;
                ANP.Visible = true;
                rep_Unallocated.Visible = false;
                ANP1.Visible = false;
                btn_unProject.Text = "未分配项目";
            }
            else
            {

                //查看未分配项目
                AddProBaseInfo.Visible = false;
                rep_PojList.Visible = false;
                ANP.Visible = false;
                BindItemsData("", -1, -1);
                rep_Unallocated.Visible = true;
                ANP1.Visible = true;
                SysProjectBll bll = new SysProjectBll();
                BindUnData("", -1, -1, 18);//绑定未分配项目
                btn_unProject.Text = "返回";
                //清空数据
                lbl_msg_Customer.Text = "";
                lbl_msg_ProCode.Text = "";
                lbl_msg_ProName.Text = "";
                lbl_msg_ProNature.Text = "";
                lbl_msg_ProType.Text = "";
                //lbl_msg_ProManger.Text = "";
                lbl_msg_DeveloperRec.Text = "";
                lbl_msg_MarketRec.Text = "";
                lbl_msg_TesterRec.Text = "";
                btn_OK.Text = "保存";

            }
        }
    }
}