using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using ProjectManage.Provider;
using System.Data;

namespace ProjectManage.BLL
{
    public class UserBLL
    {
        public bool userIsExist(string userName)
        {
            Vi_SysUserProvider user = DataFactory.CreateVi_SysUserSqlPrivider();
            user.GetVi_SysUserAll();
            return false;
        }
        /// <summary>
        /// 得到所有用户 只得到已经激活的账户
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysUserModel> getAllUsers()
        {
            Vi_SysUserProvider AllUsers = DataFactory.CreateVi_SysUserSqlPrivider();
            return AllUsers.GetVi_SysUserAll().ToList();
        }
        public bool IsExistUpdate()
        {
            bool result = false;
            List<PersonModel> PModel = getAllPersonModel();
            //得到当前数据库所有数据
            List<Vi_SysUserModel> ViSUModel = getAllSysUsers();
            //循环对比更新数据
            Vi_SysUserProvider SysUP = DataFactory.CreateVi_SysUserSqlPrivider();
            foreach (PersonModel item in PModel)
            {
                Vi_SysUserModel model = ViSUModel.FindAll(n => n.EmployeeID == item.cPersonCode).FirstOrDefault();
                if (model == null)//找不到
                {
                    result = true;
                }
                else
                {
                    if (model.RealName.Trim() != item.cPersonName.Trim() || model.Birthday != item.dBirthday || model.GroupID.Trim() != item.cDepCode.Trim() || model.PersonProp.Trim() != item.cPersonProp.Trim())
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 更新用户数据表数据，将T3数据库的用户数据更新到新表
        /// </summary>
        /// <returns></returns>
        public upddateInfo dataCopy()
        {
            upddateInfo ui = new upddateInfo();
            List<strinfo> strinfos = new List<strinfo>();
            int Addcount = 0; //更新数据总数
            int UpdateCount =0;
            //先得到所有T3数据库数据
            List<PersonModel> PModel = getAllPersonModel();
            //得到当前数据库所有数据
            List<Vi_SysUserModel> ViSUModel = getAllSysUsers();
            //循环对比更新数据
            Vi_SysUserProvider SysUP = DataFactory.CreateVi_SysUserSqlPrivider();
            Vi_SysUserModel m = new Vi_SysUserModel();
            foreach (PersonModel item in PModel)
            {
                Vi_SysUserModel model = ViSUModel.FindAll(n => n.EmployeeID == item.cPersonCode).FirstOrDefault();
                if (model == null)
                {
                    
                    m.EmployeeID = item.cPersonCode.Trim(); //员工编号
                    m.GroupID = item.cDepCode.Trim();//部门ID
                    m.PersonProp = item.cPersonProp.Trim();//职位名称
                    m.RealName = item.cPersonName.Trim();//真实姓名
                    m.Birthday = item.dBirthday;
                    m.UpdateTime = DateTime.Now;//更新时间
                    m.CreateTime = DateTime.Now;
                    //插入数据库
                    //帐号默认为 真实姓名简写和编号组合而成 密码默认留空
                    m.UserName = item.cPersonHelp.Trim() + item.cPersonCode.Trim();

                    if (SysUP.AddUser(m) > 0)
                    {
                        Addcount = Addcount + 1;
                        strinfo st = new strinfo();
                        st.infoDetail = "记录号："+(Addcount+UpdateCount).ToString()+"-新增员工：" + m.RealName + ";员工ID为：" + m.EmployeeID + ";职位：" + m.PersonProp + ";更新时间为：" + m.UpdateTime.ToString();

                        strinfos.Add(st);
                        //ui.info.Add(st);
                     }
                }
                else //不为空 判断各项是否相等，有不想等的则更新数据
                {
                    if (model.RealName.Trim() != item.cPersonName.Trim()|| model.Birthday !=item.dBirthday || model.GroupID.Trim() != item.cDepCode.Trim() || model.PersonProp.Trim() != item.cPersonProp.Trim())
                    {
                        //那说明其中有些项已经改变 需要更新
                        StringBuilder sb = new StringBuilder();
                        m.ID = model.ID;
                        m.EmployeeID = item.cPersonCode.Trim(); //员工编号
                        m.GroupID = item.cDepCode.Trim();//部门ID
                        m.PersonProp = item.cPersonProp.Trim();//职位名称
                        m.RealName = item.cPersonName.Trim();//真实姓名
                        m.Birthday = item.dBirthday;
                        m.UpdateTime = DateTime.Now;//更新时间
                        if(model.RealName.Trim() != item.cPersonName.Trim())
                        {
                            sb.Append("真实姓名由<" + model.RealName + ">修改为<" + item.cPersonName + ">,");
                        }
                        if(model.Birthday !=item.dBirthday)
                        {
                            sb.Append("出生日期由<" + model.Birthday.ToShortDateString() + ">修改为<" + item.dBirthday.ToShortDateString() + ">,");
                        }
                        if( model.GroupID.Trim() != item.cDepCode.Trim())
                        {
                            sb.Append("部门ID由<" + model.Birthday + ">修改为<" + item.cDepCode.Trim() + ">,");
                        }
                        if(model.PersonProp.Trim() != item.cPersonProp.Trim())
                        {
                            sb.Append("职位由<"+model.PersonProp.Trim()+">修改为<"+item.cPersonProp.Trim()+">,");
                        }
                        if (SysUP.UpdateUser(m) > 0)
                        {
                            UpdateCount += 1;
                            strinfo st = new strinfo();
                            st.infoDetail = "记录号：" + (Addcount + UpdateCount).ToString() + "-更新员工:" + m.RealName + "信息，" + sb.ToString() + "更新时间:" + m.UpdateTime.ToString();
                            strinfos.Add(st);
                        }
                    }
                }
            }
            ui.info = strinfos;
            ui.addNum = Addcount;
            ui.updateNum = UpdateCount;
            return ui;
        }

        public int UpdateUserDetailInfo(Vi_SysUserModel visysum)
        {
            Vi_SysUserProvider SysUP = DataFactory.CreateVi_SysUserSqlPrivider();
            return SysUP.UpdateVi_SysUser(visysum);
        }

        public int AddUserModelInfo(Vi_SysUserModel visysum)
        {
            Vi_SysUserProvider SysAdd = DataFactory.CreateVi_SysUserSqlPrivider();
            return SysAdd.SaveVi_SysUser(visysum);
        }

        public List<PersonModel> getAllPersonModel()
        {
            PersonProvider AllUsers = DataFactory.CreatePersonSqlPrivider();
            return AllUsers.GetPersonAll().ToList();
        }
        public List<Vi_SysUserModel> getAllVi_SysUser()
        {
            Vi_SysUserProvider AllSysUsers = DataFactory.CreateVi_SysUserSqlPrivider();
            return AllSysUsers.GetVi_SysUserAll().ToList();
        }

        //*******************************
        //这里还得做搜索效果便于用户快速找到目标
        //*******************************

        /// <summary>
        /// 根据索引得到分页后的数据包括未激活的
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable getAllSysUser(int pageNum,int pageSize,int counts,string strWhere)
        {
            Vi_SysUserProvider AllSysUsers = DataFactory.CreateVi_SysUserSqlPrivider();
            return AllSysUsers.GetPageTable("SELECT a.*,b.cDepName FROM Vi_SysUser a left join Department b on a.GroupID = b.cDepCode " + strWhere, "CreateTime", pageNum, pageSize, counts);
        }
        /// <summary>
        /// 得到所用用户包括未激活的
        /// </summary>
        /// <returns></returns>
        public int getAllUserREC(string strWhere)
        {
            Vi_SysUserProvider AllSysUsers = DataFactory.CreateVi_SysUserSqlPrivider();
            return AllSysUsers.GetSqlCount("SELECT a.*,b.cDepName FROM Vi_SysUser a left join Department b on a.GroupID = b.cDepCode " + strWhere);
        }
        public Vi_SysUserModel getUserModelByUserId(int UserId)
        {
            Vi_SysUserProvider Single = DataFactory.CreateVi_SysUserSqlPrivider();
            return Single.Get_Vi_SysUserModel(UserId);
            //System.Data.DataTable dt = Single.GetPageTable("", "", 2, 10);
            
        }
        //
        public Vi_SysUserModel getUserModelByUserName(string UserName)
        {
            Vi_SysUserProvider Single = DataFactory.CreateVi_SysUserSqlPrivider();
            return Single.getUserInfoByUserName(UserName);
        }
        public Vi_SysUserModel getUserModelByRealName(string RealName)
        {
            Vi_SysUserProvider Single = DataFactory.CreateVi_SysUserSqlPrivider();
            return Single.getUserInfoByRealName(RealName);
        }
        //根据用户Id得到用户详细信息 包括用户名称密码 真实姓名 所属部门职务 和部门编号 部门名称
        public DataTable getUserInfoById(int UserId)
        {
            Vi_SysUserProvider Single = DataFactory.CreateVi_SysUserSqlPrivider();
            
            return Single.GetDataTable("SELECT [UserName],[UserPwd],[RealName],[Birthday],[Email],[PhoneNum],[Tel],[EmployeeID],[GroupID],b.cDepName FROM Vi_SysUser a left join Department b on a.GroupID = b.cDepCode where a.ID=" + UserId);
        }
        ////修改用户电话号码和密码
        //public int UpdateSimpleUserInfo(string telPhone, string Pwd)
        //{
        //    string sqlstr = "";
        //    if (telPhone != "")
        //    {
        //        sqlstr = "UPDATE Vi_SysUser SET PhoneNum =";
                
        //    }
        //}


        public List<Vi_SysUserModel> getAllSysUsers()
        {
            Vi_SysUserProvider visup = DataFactory.CreateVi_SysUserSqlPrivider();
            return visup.getAllSysUsers().ToList();
        }
    }
}
