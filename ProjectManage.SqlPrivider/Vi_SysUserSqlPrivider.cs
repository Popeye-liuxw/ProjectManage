
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using System.Data.Common;
using System.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
	public partial class Vi_SysUserSqlPrivider :Vi_SysUserProvider
	{

        public override bool FieldAccess(System.Data.DataSet de)
        {
            return false;
        }
        /// <summary>
        ///  添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int AddUser(Vi_SysUserModel model)
        {
            string commandString = "INSERT INTO [Vi_SysUser] ([UserName],[UserPwd],[RealName],[Birthday],[PersonProp],[EmployeeID],[GroupID],[CreateTime],[UpdateTime]) values( @UserName,@UserPwd, @RealName, @Birthday, @PersonProp, @EmployeeID, @GroupID, @CreateTime, @UpdateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@UserName", DbType.String,model.UserName);
            db.AddInParameter(command, "@UserPwd", DbType.String, "empty");
            db.AddInParameter(command, "@RealName", DbType.String,model.RealName);
            db.AddInParameter(command, "@Birthday", DbType.DateTime,model.Birthday);
            db.AddInParameter(command, "@PersonProp", DbType.String,model.PersonProp);
            db.AddInParameter(command, "@EmployeeID", DbType.String,model.EmployeeID);
            db.AddInParameter(command, "@GroupID", DbType.String,model.GroupID);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime,model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime,model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int UpdateUser(Vi_SysUserModel model)
        {
            string commandString = "update [Vi_SysUser] set [RealName]=@RealName,[Birthday]=@Birthday,[PersonProp]=@PersonProp,[EmployeeID]=@EmployeeID,[GroupID]=@GroupID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);

           // db.AddInParameter(command, "@ID", DbType.Int32,model.ID);
            db.AddInParameter(command, "@RealName", DbType.String,model.RealName);
            db.AddInParameter(command, "@Birthday", DbType.DateTime,model.Birthday);
            db.AddInParameter(command, "@PersonProp", DbType.String,model.PersonProp);
            db.AddInParameter(command, "@EmployeeID", DbType.String,model.EmployeeID);
            db.AddInParameter(command, "@GroupID", DbType.String,model.GroupID);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime,model.UpdateTime);
            db.AddInParameter(command, "@ID", DbType.Int32, model.ID);
            return db.ExecuteNonQuery(command);	
        }
       /// <summary>
       /// 根据用户名得到用户信息
       /// </summary>
       /// <param name="UserName"></param>
       /// <returns></returns>
        public override Vi_SysUserModel getUserInfoByUserName(string UserName)
        {
            //throw new NotImplementedException();
            Vi_SysUserModel _Entity = null;
            string commandString = "select * from Vi_SysUser where [UserName]=@UserName";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@UserName", DbType.String, UserName);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 根据用户真实姓名得到用户信息
        /// </summary>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public override Vi_SysUserModel getUserInfoByRealName(string RealName)
        {
            Vi_SysUserModel _Entity = null;
            string commandString = "select * from Vi_SysUser where [RealName]=@RserName";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@RserName", DbType.String, RealName);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 根据用户ID得到用户相关信息 包括职位 部门
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public override Vi_SysUserModel getSingle_Vi_SysUserModel(Int32 ID)
        //{
        //    Vi_SysUserModel _Entity = null;
        //    string commandString = "select * from Vi_SysUser where ID=@ID";
        //    DbCommand command = db.GetSqlStringCommand(commandString);
        //    db.AddInParameter(command, "ID", DbType.Int32);
        //    using (IDataReader dr = db.ExecuteReader(command))
        //    {
        //        while (dr.Read())
        //        {
        //            _Entity = Populate_Vi_SysUserEntity_FromDr(dr);
        //        }
        //    }
        //    return _Entity;
        //}

        //public List<Vi_SysUserModel> Page(int pageNum,int pagesize)
        //{
        //    DataTable dt = base.GetPageTable("", "", pageNum, pagesize);
        //    int count = base.GetSqlCount("");
        //}
        /// <summary>
        ///  检查用户激活信息是否正确 以生日作为条件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public override Vi_SysUserModel CheckUserByName(string username, DateTime birthday)
        {
            Vi_SysUserModel _Entity = null;
            string commandString = "select * from Vi_SysUser where [RealName]=@UserName and [Birthday] = @Birthday";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@UserName", DbType.String, username);
            db.AddInParameter(command, "@Birthday", DbType.DateTime, birthday);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysUserEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到所有用户包括未激活的
        /// </summary>
        /// <returns></returns>
        public override IList<Vi_SysUserModel> getAllSysUsers()
        {
            IList<Vi_SysUserModel> _Entity = new List<Vi_SysUserModel>();
            string commandString = "select * from Vi_SysUser";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysUserEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
    }
}
