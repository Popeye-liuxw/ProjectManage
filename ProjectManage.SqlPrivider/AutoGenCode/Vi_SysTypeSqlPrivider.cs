
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysTypeSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using ProjectManage.Model;
using ProjectManage.Provider;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
    public partial class Vi_SysTypeSqlPrivider : Vi_SysTypeProvider
    {
        #region Vi_SysType

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_SysType(Vi_SysTypeModel Model)
        {
            string commandString = "INSERT INTO [Vi_SysType] ([TypeName],[TypeValue],[BigType],[BigValue],[Level],[UserID],[CreateTime]) values( @TypeName, @TypeValue, @BigType, @BigValue, @Level ,@UserID, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command, "@ID", DbType.Int32);
            db.AddInParameter(command, "@TypeName", DbType.String, Model.TypeName);
            db.AddInParameter(command, "@TypeValue", DbType.Int32, Model.TypeValue);
            db.AddInParameter(command, "@BigType", DbType.String, Model.BigType);
            db.AddInParameter(command, "@BigValue", DbType.Int32, Model.BigValue);
            db.AddInParameter(command, "@Level", DbType.Int32, Model.Level);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_SysType(Vi_SysTypeModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_SysType] set [TypeName]=@TypeName,[TypeValue]=@TypeValue,[BigType]=@BigType,[BigValue]=@BigValue,[Level]=@Level,[UserID]=@UserID,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@TypeName", DbType.String, Model.TypeName);
            db.AddInParameter(command, "@TypeValue", DbType.Int32, Model.TypeValue);
            db.AddInParameter(command, "@BigType", DbType.String, Model.BigType);
            db.AddInParameter(command, "@BigValue", DbType.Int32, Model.BigValue);
            db.AddInParameter(command, "@Level", DbType.Int32, Model.Level);
            db.AddInParameter(command, "@UserID", DbType.Int32, Model.UserID);
            //db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);            
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_SysType(int ID)
        {
            string commandString = "delete from Vi_SysType where dbo.Vi_SysType.ID=@dbo.Vi_SysType.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_SysType.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_SysType返回的查询dateset创建一个Vi_SysType对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysType对象</returns>
        private Vi_SysTypeModel Populate_Vi_SysTypeEntity_FromDr(DataSet ds)
        {
            Vi_SysTypeModel nObject = new Vi_SysTypeModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                nObject.TypeValue = ((ds.Tables[0].Rows[0]["TypeValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["TypeValue"]);
                nObject.BigType = ds.Tables[0].Rows[0]["BigType"].ToString();
                nObject.BigValue = ((ds.Tables[0].Rows[0]["BigValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["BigValue"]);
                nObject.Level = ((ds.Tables[0].Rows[0]["Level"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["Level"]);
                nObject.UserID = ((ds.Tables[0].Rows[0]["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                nObject.CreateTime = ((ds.Tables[0].Rows[0]["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]);
                nObject.UpdateTime = ((ds.Tables[0].Rows[0]["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateTime"]);
            }
            else
            {
                return null;
            }
            return nObject;
        }
        /// <summary>
        /// 得到  vi_systype 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_systype 数据实体</returns>
        private Vi_SysTypeModel Populate_Vi_SysTypeEntity_FromDr(IDataReader dr)
        {
            Vi_SysTypeModel Obj = new Vi_SysTypeModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.TypeName = dr["TypeName"].ToString();
            Obj.TypeValue = ((dr["TypeValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TypeValue"]);
            Obj.BigType = dr["BigType"].ToString();
            Obj.BigValue = ((dr["BigValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["BigValue"]);
            Obj.Level = ((dr["Level"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Level"]);
            Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_systype 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_systype 数据实体</returns>
        private Vi_SysTypeModel Populate_Vi_SysTypeEntity_FromDr(DataRow dr)
        {
            Vi_SysTypeModel Obj = new Vi_SysTypeModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.TypeName = dr["TypeName"].ToString();
                Obj.TypeValue = ((dr["TypeValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TypeValue"]);
                Obj.BigType = dr["BigType"].ToString();
                Obj.BigValue = ((dr["BigValue"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["BigValue"]);
                Obj.Level = ((dr["Level"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Level"]);
                Obj.UserID = ((dr["UserID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"]);
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_SysType对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysType对象</returns>
        public override Vi_SysTypeModel Get_Vi_SysTypeModel(Int32 ID)
        {
            Vi_SysTypeModel _Entity = null;
            string commandString = "select * from Vi_SysType where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysTypeEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_SysType所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_SysTypeModel> GetVi_SysTypeAll()
        {
            IList<Vi_SysTypeModel> _Entity = new List<Vi_SysTypeModel>();
            string commandString = "select * from Vi_SysType";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysTypeEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
    }
}
