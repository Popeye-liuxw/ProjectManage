using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using ProjectManage.ProviderFactory;
using System.Data;

/*
 * =================================================================== 
 * 项目说明 
 * ====================================================================
 * visione @ CopyRight 2007-2012
 * File Name： SysProjectBll.cs
 * Project Name：ProjectManageSystem 
 * Create Time：2012/8/30 17:09:53
 * Code By：lxs
 * Code By：lxs,Popeye_lxw
 * ===================================================================
 */

namespace ProjectManage.BLL
{
    public class SysProjectBll
    {
        /// <summary>
        /// 得到所有项目信息
        /// </summary>
        /// <returns></returns>
        public List<Vi_ProjectInfoModel> GetAllProjectInfo()
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.GetVi_ProjectInfoAll().ToList();
        }
        /// <summary>
        /// 得到分页数据项目信息根据查询条件
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <param name="Counts"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getAllProjectInfoPager(int PageNum,int PageSize,int Counts,string strWhere)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                           + "[iotherused],[ContractNumber],[ProjectNatureSysNo],a.[cCusCode],e.cCusAbbName,[cPersonCode],"
                           + "a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                           + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                           + "left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 left join Customer as e on a.cCusCode = e.cCusCode " + strWhere;
            return visip.GetPageTable(sqlstr, "", PageNum, PageSize, Counts);
        }
        /// <summary>
        /// 根据查询条件得到所有项目信息的总数
        /// </summary>
        /// <param name="strWhere">查询条件可为空</param>
        /// <returns></returns>
        public int getAllProjectCounts(string strWhere)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                           + "[iotherused],[ContractNumber],[ProjectNatureSysNo],[cCusCode],[cPersonCode],"
                           + "a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                           + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                           + "left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 " + strWhere;
            return visip.GetSqlCount(sqlstr);
        }
        /// <summary>
        /// 判断是否存在更新的项目信息
        /// </summary>
        /// <returns></returns>
        public bool IsExistUpdate()
        {
            bool result = false;
            
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            //查询当前项目信息表所有项目信息
            List<Vi_ProjectInfoModel> lipim = visip.GetVi_ProjectInfoAll().ToList();
            //得到T3数据库所有数据
            DataTable dtFitem = new DataTable();
            try
            {
                dtFitem = visip.GetDataTable(string.Format("SELECT [I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused] FROM [UFDATA_005_{0}].[dbo].[fitemss00]", DateTime.Now.Year));
            }
            catch (Exception ex)
            {
                dtFitem = visip.GetDataTable(string.Format("SELECT [I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused] FROM fitemss00"));
            }
            //循环对比
            foreach (DataRow dr in dtFitem.Rows)
            {
               Vi_ProjectInfoModel model =   lipim.FindAll(n => n.I_id == int.Parse(dr["I_id"].ToString())).FirstOrDefault();
               if (model == null)//找不到
               {
                   result = true;
               }
               else
               {
                   if (model.citemcode != dr["citemcode"].ToString().Trim() || model.citemname != dr["citemname"].ToString().Trim() || model.citemccode != dr["citemccode"].ToString().Trim())
                   {
                       result = true;
                   }
               }
            }
            return result;
        }
        /// <summary>
        /// 项目数据更新
        /// </summary>
        /// <returns></returns>
        public updateProInfo dataCopy()
        {
            updateProInfo upi = new updateProInfo();
            List<strProinfo> lispi = new List<strProinfo>();
            int Addcount = 0; //添加记录总数
            int UpdateCount = 0;//更新记录总数
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            //查询当前项目信息表所有项目信息
            List<Vi_ProjectInfoModel> lipim = visip.GetVi_ProjectInfoAll().ToList();
            DataTable dtFitem = new DataTable();
            try
            {
                dtFitem = visip.GetDataTable(string.Format("SELECT [I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused] FROM [UFDATA_005_{0}].[dbo].[fitemss00]",DateTime.Now.Year));
            }
            catch (Exception ex)
            {
                dtFitem = visip.GetDataTable(string.Format("SELECT [I_id],[citemcode],[citemname],[bclose],[citemccode],[iotherused] FROM fitemss00"));
            }
            Vi_ProjectInfoModel vipim = new Vi_ProjectInfoModel();
            foreach (DataRow dr in dtFitem.Rows)
            {
                Vi_ProjectInfoModel model = lipim.FindAll(n => n.I_id == int.Parse(dr["I_id"].ToString())).FirstOrDefault();
                if (model == null)
                {
                    //添加新记录
                    vipim.I_id = int.Parse(dr["I_id"].ToString().Trim());
                    vipim.citemcode = dr["citemcode"].ToString().Trim();
                    vipim.citemname = dr["citemname"].ToString().Trim();
                    vipim.citemccode = dr["citemccode"].ToString().Trim();
                    //vipim.bclose = int.Parse(dr["bclose"].ToString());
                    vipim.UpdateTime = DateTime.Now;
                    vipim.CreateTime = DateTime.Now;
                    if (visip.AddProjectFromT3(vipim) > 0)
                    {
                        Addcount = Addcount + 1;
                        strProinfo stri = new strProinfo();
                        stri.ProinfoDetail = "记录号：" + (Addcount + UpdateCount).ToString() + "-新增项目信息：项目Id：" + vipim.I_id + ";项目代号为：" + vipim.citemcode + ";项目名称为：" + vipim.citemname + ",项目分类编号为：" + vipim.citemccode + ";更新时间为：" + vipim.UpdateTime;
                        lispi.Add(stri);
                    }
                    //得到数据
                }
                else
                {
                    //更新记录
                    if (model.citemcode != dr["citemcode"].ToString().Trim() || model.citemname != dr["citemname"].ToString().Trim() || model.citemccode != dr["citemccode"].ToString().Trim())
                    {
                        StringBuilder sb = new StringBuilder();
                        if(model.I_id != int.Parse(dr["I_id"].ToString().Trim()))
                        {
                            sb.Append("项目ID由：["+model.I_id+"]更改为:["+dr["I_id"].ToString().Trim()+"],");
                        }
                        if(model.citemcode != dr["citemcode"].ToString().Trim())
                        {
                            sb.Append("项目代号由：["+model.I_id+"]更改为:["+dr["citemcode"].ToString().Trim()+"],");
                        }
                        if(model.citemname != dr["citemname"].ToString().Trim())
                        {
                            sb.Append("项目名称由：["+model.citemname+"]更改为:["+dr["citemname"].ToString().Trim()+"],");
                        }
                        if(model.citemccode != dr["citemccode"].ToString().Trim())
                        {
                            sb.Append("项目分类编号由：["+model.citemccode+"]更改为:["+dr["citemccode"].ToString().Trim()+"],");
                        }
                        //更新记录
                        model.I_id = int.Parse(dr["I_id"].ToString().Trim());
                        model.citemcode = dr["citemcode"].ToString().Trim();
                        model.citemname = dr["citemname"].ToString().Trim();
                        model.citemccode = dr["citemccode"].ToString().Trim();
                        model.UpdateTime = DateTime.Now;
                        
                        
                        if (visip.UpdateProFromT3(model) > 0)
                        {
                            UpdateCount = UpdateCount + 1;
                            strProinfo stri = new strProinfo();
                            stri.ProinfoDetail = "记录号："+(Addcount + UpdateCount).ToString() + "更新项目[" + model.citemname + "]信息：" + sb.ToString() + "更新时间：" + model.UpdateTime.ToString();
                            lispi.Add(stri);
                        }
                    }
                }
                //数据搞定 oh yeah
                
            }
            upi.info = lispi;
            upi.addNum = Addcount;
            upi.updateNum = UpdateCount;
            return upi;
        }
        /// <summary>
        /// 根据用户ID得到用户相关的项目分页条件查询分页数据 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="counts"></param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public DataTable getProjectsInfoByStrWhere(int pageNum,int pageSize,int counts,string strwhere,int UserId)
        {
            //
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                            + "[iotherused],[ContractNumber],[ProjectNatureSysNo],a.[cCusCode],d.cCusAbbName,[cPersonCode],"
                            +"a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                            +" FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                            + "left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 left join Customer as d on a.cCusCode = d.cCusCode " + strwhere
                            + " and a.bclose = 1 and a.ID in (select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                            + "union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                            + "union select ProjectID,StaffID from Vi_TesterRec) as a where StaffID=" + UserId + ")";
            return  visip.GetPageTable(sqlstr, "", pageNum, pageSize, counts);

        }
        /// <summary>
        /// 根据查询条件和UserId得到用户相关的项目所有记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int getCountByStrWhere(string strWhere,int UserId)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT a.[ID],a.[i_id],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                            + "[iotherused],[ContractNumber],[ProjectNatureSysNo],a.[cCusCode],d.cCusAbbName,[cPersonCode],"
                            + "a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                            + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                            + "left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 left join Customer as d on a.cCusCode = d.cCusCode " + strWhere
                            + " and a.bclose = 1 and a.ID in (select distinct ProjectID from (select ProjectID,StaffID from Vi_DeveloperRec "
                            +"union select ProjectID,StaffID from  Vi_ManagerRec union select ProjectID,StaffID from Vi_MarketRec "
                            + "union select ProjectID,StaffID from Vi_TesterRec) as a where StaffID=" + UserId + ")";
            return visip.GetSqlCount(sqlstr);
        }
        /// <summary>
        /// 得到所有未分配项目的数量总和
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getUnallocatedDataCount(string strWhere)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.getUnallocatedCount(strWhere);
        }
        public DataTable getUnallocatedData(int pageNum, int pageSize, int counts, string strWhere)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.getUnallocatedData(pageNum, pageSize, counts, strWhere);
        }




        /// <summary>
        /// 得到所有项目类型
        /// </summary>
        /// <returns></returns>
        public DataTable getAllProType()
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.GetDataTable("select TypeValue, TypeName from Vi_SysType where BigValue=1100 and [Level] = 100");
        }
        /// <summary>
        /// 得到项目性质
        /// </summary>
        /// <returns></returns>
        public DataTable getAllProNature()
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.GetDataTable("select TypeValue, TypeName from Vi_SysType where BigValue=1200 and [Level] = 100");
        }
        
        /// <summary>
        /// 获取某个用户是否参与某个项目
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="PrjId">项目ID</param>
        /// <returns></returns>
        public bool getAllProjectWithUser(int UserId,int PrjId)
        {
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return visip.ProjectWithUser(UserId, PrjId);
        }
        
        /// <summary>
        /// 根据项目Id得到当前项目的详细信息
        /// </summary>
        /// <param name="ProId"></param>
        /// <returns></returns>
        public DataTable getProDetailByProId(int ProId)
        {
            DataTable dt = new DataTable();
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT a.[ID],a.[i_id],d.[RealName],[citemcode],[citemname] ,[bclose],a.[citemccode],b.TypeName,"
                            + "[iotherused],[ContractNumber],[ProjectNatureSysNo],a.[cCusCode],a.[DeveloperRec],a.[TesterRec],a.[MarketRec],e.cCusAbbName,[cPersonCode],"
                            + "a.[UserID],a.[CreateTime],a.[UpdateTime],[PrjType],[PrjNature],b.TypeName as PrjTypeName, c.TypeName as PrjNatureName"
                            + " FROM [Vi_ProjectInfo] a  left join Vi_SysType b on a.PrjType = b.TypeValue and b.BigValue = 1100 "
                            + "left join  Vi_SysType c on a.PrjNature = c.TypeValue and c.BigValue = 1200 "
                            + " left join Vi_SysUser d on d.ID =a.[UserID] left join Customer as e on a.cCusCode = e.cCusCode  where a.ID=" + ProId;
            dt = visip.GetDataTable(sqlstr);
            return dt;
        }



        //查询项目开发人员 从研发部查询
        //查询项目测试人员 从测试部查询
        //查询项目商务人员 从市场部门查询
        //封装啊 写成一个方法
        /// <summary>
        /// 根据用户所在的部门ID得到该部门所有的用户ID和真名
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public DataTable getUserListByGroupId(int GroupId)
        {
            DataTable dt = new DataTable();
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "select ID,RealName from  Vi_SysUser where UserPwd not in ('empty') and  GroupID = " + GroupId;//得到用户ID和真名
            dt = visip.GetDataTable(sqlstr);
            return dt;
        }
        //由于这里有应用研发人员和算法研发人员
        /// <summary>
        /// 得到所有研发人员 包括应用研发和算法研发
        /// </summary>
        /// <returns></returns>
        public DataTable getAllDevUserList()
        {
            DataTable dt = new DataTable();
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            //string sqlstr = "select ID,RealName from  Vi_SysUser where GroupID =06 or GroupID=03";
            string sqlstr = "select ID,RealName from  Vi_SysUser where UserPwd not in ('empty') and GroupID in (06,03)";
            return visip.GetDataTable(sqlstr);
        }

        /// <summary>
        /// 得到所有研发人员 包括应用研发和算法研发
        /// </summary>
        /// <returns></returns>
        public DataTable getAllUserList()
        {
            DataTable dt = new DataTable();
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            //string sqlstr = "select ID,RealName from  Vi_SysUser where GroupID =06 or GroupID=03";
            string sqlstr = "select ID,RealName from  Vi_SysUser where UserPwd not in ('empty')";
            return visip.GetDataTable(sqlstr);
        }


        /// <summary>
        /// 根据项目ID得到不同类型的项目参与人员
        /// </summary>
        /// <param name="ProId"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public DataTable getUserListbyUserType(int ProId, string TableName)
        {
            DataTable dt = new DataTable();
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr = "SELECT StaffID,RealName FROM " + TableName + " join Vi_SysUser on StaffID =Vi_SysUser.ID  where  Vi_SysUser.UserPwd <> 'empty' and ProjectID = " + ProId;
            dt = visip.GetDataTable(sqlstr);
            return dt;
        }
        /// <summary>
        /// 更新项目选择人员
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="staffId"></param>
        /// <param name="ProId"></param>
        /// <param name="ProjectName"></param>
        /// <param name="userId"></param>
        public void AddProRelatedUser(string tableName, int staffId, int ProId, string ProjectName,int userId)
        {
            string sqlstr = "INSERT INTO " + tableName + " (StaffID,ProjectID,ProjectName,UserID,UpdateTime) VALUES (" + staffId + "," + ProId + ",'" + ProjectName + "'," +userId+",'"+DateTime.Now+"')";
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
        }
        /// <summary>
        /// 根据项目ID判断有无存在
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="userId"></param>
        /// <param name="ProId"></param>
        /// <returns></returns>
        public DataTable IsExistUserByProId(string tbName, int staffId, int ProId)
        {
           // bool result = false;
            Vi_ProjectInfoProvider visip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            string sqlstr1 = "SELECT ID,StaffID,ProjectID FROM " + tbName + " WHERE StaffID = " + staffId + " AND ProjectID =" + ProId;
            DataTable dttemp = visip.GetDataTable(sqlstr1);
            //if (dttemp.Rows.Count > 0)
            //{
            //    //说明存在 得到ID更新之
            //    result = true;
            //}
            //else
            //{
            //    //说明不存在，加之
            //}
            //return result;
            return dttemp;
        }


        #region 项目开发人员相关逻辑
        /// <summary>
        /// 得到所有项目开发人员
        /// </summary>
        /// <returns></returns>
        public List<Vi_DeveloperRecModel> getAllDeveloper()
        {
            Vi_DeveloperRecProvider vidrp = DataFactory.CreateVi_DeveloperRecSqlPrivider();
            return vidrp.GetVi_DeveloperRecAll().ToList();
        }
        /// <summary>
        /// 根据ID得到一条开发人员实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Vi_DeveloperRecModel getSingleDevInfoById(Int32 Id)
        {
            Vi_DeveloperRecProvider vidrp = DataFactory.CreateVi_DeveloperRecSqlPrivider();
            return vidrp.Get_Vi_DeveloperRecModel(Id);
        }
        /// <summary>
        /// 根据ID删除一条记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeletSingleDevById(Int32 Id)
        {
            Vi_DeveloperRecProvider vidrp = DataFactory.CreateVi_DeveloperRecSqlPrivider();
            return vidrp.DeleteVi_DeveloperRec(Id);
        }
        /// <summary>
        /// 新增一个开发人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Int32 AddSingleDev(Vi_DeveloperRecModel model)
        {
            Vi_DeveloperRecProvider vidrp = DataFactory.CreateVi_DeveloperRecSqlPrivider();
            return vidrp.SaveVi_DeveloperRec(model);
        }
        /// <summary>
        /// 更新一条 开发人员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Int32 UpdateSingleDev(Vi_DeveloperRecModel model)
        {
            Vi_DeveloperRecProvider vidrp = DataFactory.CreateVi_DeveloperRecSqlPrivider();
            return vidrp.UpdateVi_DeveloperRec(model);
        }
        #endregion


        #region 项目测试人员
        //Vi_TesterRecProvider
        /// <summary>
        /// 为该项目增加一个测试人员
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int AddSingleTester(Vi_TesterRecModel Model)
        {
            Vi_TesterRecProvider vitrp = DataFactory.CreateVi_TesterRecSqlPrivider();
            return vitrp.SaveVi_TesterRec(Model);
        }
        /// <summary>
        /// 为该项目删除一个测试人员
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleSingleTester(int ID)
        {
            Vi_TesterRecProvider vitrp = DataFactory.CreateVi_TesterRecSqlPrivider();
            return vitrp.DeleteVi_TesterRec(ID);
        }
        #endregion
        #region 市场商务人员
        /// <summary>
        /// 新增一个项目市场人员
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int AddSingleMarket(Vi_MarketRecModel Model)
        {
            Vi_MarketRecProvider vimrp = DataFactory.CreateVi_MarketRecSqlPrivider();
            return vimrp.SaveVi_MarketRec(Model);
        }
        /// <summary>
        /// 删除一条项目市场人员信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelSingleMarket(int Id)
        {
            Vi_MarketRecProvider vimrp = DataFactory.CreateVi_MarketRecSqlPrivider();
            return vimrp.DeleteVi_MarketRec(Id);
        }
        #endregion


        /// <summary>
        /// 根据项目ID得到项目经理  目前只分配一个项目经理
        /// </summary>
        /// <param name="ProId"></param>
        /// <returns></returns>
        public Vi_SysUserModel getProMangerByProId(int ProId)
        {
            DataTable dt = getStaffIdByProId(ProId);
            Vi_SysUserModel model = null;
            if (dt.Rows.Count > 0)
            {
                int UserId = int.Parse(dt.Rows[0]["StaffID"].ToString());
                Vi_SysUserProvider vimrp = DataFactory.CreateVi_SysUserSqlPrivider();
                model = vimrp.Get_Vi_SysUserModel(UserId);
            }
            return model;

        }
       /// <summary>
       /// 根据项目ID得到员工ID 从项目经理表
       /// </summary>
       /// <param name="ProId"></param>
       /// <returns></returns>
        public DataTable getStaffIdByProId(int ProId)
        {
            string sqlstr = "SELECT ID,StaffID,ProjectID FROM Vi_ManagerRec where ProjectID =" + ProId;
            Vi_MarketRecProvider vimrp = DataFactory.CreateVi_MarketRecSqlPrivider();
            return vimrp.GetDataTable(sqlstr);
        }
        /// <summary>
        /// 添加一个新项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSinglePro(Vi_ProjectInfoModel model)
        {
            Vi_ProjectInfoProvider vipip = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return vipip.SaveVi_ProjectInfo(model);
        }

        /// <summary>
        /// 新增项目时添加一名项目经理
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int AddAProjectManager(Vi_ManagerRecModel Model)
        {
            Vi_ManagerRecProvider vimrp = DataFactory.CreateVi_ManagerRecSqlPrivider();            
            return vimrp.SaveVi_ManagerRec(Model);
        }
        /// <summary>
        /// 根据项目ID,获取项目实体
        /// </summary>
        /// <param name="ProId">项目ID</param>
        /// <returns></returns>
        public Vi_ProjectInfoModel GetProjectInfoModel(int ProId)
        {
            Vi_ProjectInfoModel model = null;
            if (ProId > 0)
            {
                Vi_ProjectInfoProvider projectSql = DataFactory.CreateVi_ProjectInfoSqlPrivider();
                model = projectSql.Get_Vi_ProjectInfoModel(ProId);
            }
             return model;
        }
        /// <summary>
        /// 获取某人相关的项目信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<Vi_ProjectInfoModel> GetProjectInfoByUser(int userID)
        {
            List<Vi_ProjectInfoModel> models = null;
            if (userID > 0)
            {
                Vi_ProjectInfoProvider projectSql = DataFactory.CreateVi_ProjectInfoSqlPrivider();
                models = projectSql.GetProjectInfoByUser(userID).ToList();
            }
            return models;
        }
        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateProJectinfo(Vi_ProjectInfoModel model)
        {
            Vi_ProjectInfoProvider projectSql = DataFactory.CreateVi_ProjectInfoSqlPrivider();
            return  projectSql.UpdateVi_ProjectInfo(model);
        }
        /// <summary>
        /// 获取用户真实姓名，用来界面显示
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserNameByID(int userid)
        {
            string result = string.Empty;
            Vi_SysUserProvider userSql = DataFactory.CreateVi_SysUserSqlPrivider();
            Vi_SysUserModel user = userSql.Get_Vi_SysUserModel(userid);
            if (user != null) result = user.RealName;
            return result;
        }
        /// <summary>
        /// 获取用户真实姓名，用来界面显示
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserNameByID(string userID)
        {
            int userid;
            string result = string.Empty;
            if (int.TryParse(userID, out userid))
            {             
                Vi_SysUserProvider userSql = DataFactory.CreateVi_SysUserSqlPrivider();
                Vi_SysUserModel user = userSql.Get_Vi_SysUserModel(userid);
                if (user != null) result = user.RealName;
            }
            return result;
        }

    }
}
