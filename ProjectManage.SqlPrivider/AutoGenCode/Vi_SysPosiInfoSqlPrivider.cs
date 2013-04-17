
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiInfoSqlPrivider.cs
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
    public partial class Vi_SysPosiInfoSqlPrivider : Vi_SysPosiInfoProvider
    {
        #region Vi_SysPosiInfo

        ///<summary>
        ///向数据库中插入一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int SaveVi_SysPosiInfo(Vi_SysPosiInfoModel Model)
        {
            string commandString = "INSERT INTO [Vi_SysPosiInfo] ([PosiName],[Back],[CreateTime]) values( @PosiName, @Back, @CreateTime)";
            DbCommand command = db.GetSqlStringCommand(commandString);
            //db.AddInParameter(command, "@ID", DbType.Int32);
            db.AddInParameter(command, "@PosiName", DbType.String, Model.PosiName);
            db.AddInParameter(command, "@Back", DbType.String, Model.Back);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            //db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);

            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///更新数据库中一条数据
        ///</summary>
        /// <param name="Model">Model</param>
        /// <returns>影响的条数</returns>
        public override int UpdateVi_SysPosiInfo(Vi_SysPosiInfoModel Model)
        {
            Model.UpdateTime = DateTime.Now;
            string commandString = "update [Vi_SysPosiInfo] set [PosiName]=@PosiName,[Back]=@Back,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@ID", DbType.Int32, Model.ID);
            db.AddInParameter(command, "@PosiName", DbType.String, Model.PosiName);
            db.AddInParameter(command, "@Back", DbType.String, Model.Back);
            db.AddInParameter(command, "@CreateTime", DbType.DateTime, Model.CreateTime);
            db.AddInParameter(command, "@UpdateTime", DbType.DateTime, Model.UpdateTime);
            return db.ExecuteNonQuery(command);
        }
        ///<summary>
        ///删除数据库一条数据
        ///</summary>
        /// <param name="ID">ID</param>
        /// <returns>影响的条数</returns>
        public override int DeleteVi_SysPosiInfo(int ID)
        {
            string commandString = "delete from Vi_SysPosiInfo where dbo.Vi_SysPosiInfo.ID=@dbo.Vi_SysPosiInfo.ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@dbo.Vi_SysPosiInfo.ID", DbType.Int32, ID);
            return db.ExecuteNonQuery(command);
        }
        /// <summary>
        /// 根据Vi_SysPosiInfo返回的查询dateset创建一个Vi_SysPosiInfo对象
        /// </summary>
        /// <param name="ds">DateSet</param>
        /// <returns>Vi_SysPosiInfo对象</returns>
        private Vi_SysPosiInfoModel Populate_Vi_SysPosiInfoEntity_FromDr(DataSet ds)
        {
            Vi_SysPosiInfoModel nObject = new Vi_SysPosiInfoModel();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nObject.ID = ((ds.Tables[0].Rows[0]["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                nObject.PosiName = ds.Tables[0].Rows[0]["PosiName"].ToString();
                nObject.Back = ds.Tables[0].Rows[0]["Back"].ToString();
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
        /// 得到  vi_sysposiinfo 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysposiinfo 数据实体</returns>
        private Vi_SysPosiInfoModel Populate_Vi_SysPosiInfoEntity_FromDr(IDataReader dr)
        {
            Vi_SysPosiInfoModel Obj = new Vi_SysPosiInfoModel();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.PosiName = dr["PosiName"].ToString();
            Obj.Back = dr["Back"].ToString();
            Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }
        /// <summary>
        /// 得到  vi_sysposiinfo 数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>vi_sysposiinfo 数据实体</returns>
        private Vi_SysPosiInfoModel Populate_Vi_SysPosiInfoEntity_FromDr(DataRow dr)
        {
            Vi_SysPosiInfoModel Obj = new Vi_SysPosiInfoModel();
            if (dr != null)
            {
                Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
                Obj.PosiName = dr["PosiName"].ToString();
                Obj.Back = dr["Back"].ToString();
                Obj.CreateTime = ((dr["CreateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["CreateTime"]);
                Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);
            }
            return Obj;
        }
        /// <summary>
        /// 根据ID,返回一个Vi_SysPosiInfo对象
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Vi_SysPosiInfo对象</returns>
        public override Vi_SysPosiInfoModel Get_Vi_SysPosiInfoModel(Int32 ID)
        {
            Vi_SysPosiInfoModel _Entity = null;
            string commandString = "select * from Vi_SysPosiInfo where ID=@ID";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "ID", DbType.Int32, ID);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity = Populate_Vi_SysPosiInfoEntity_FromDr(dr);
                }
            }
            return _Entity;
        }
        /// <summary>
        /// 得到数据表Vi_SysPosiInfo所有记录
        /// </summary>
        /// <returns>数据集</returns>
        public override IList<Vi_SysPosiInfoModel> GetVi_SysPosiInfoAll()
        {
            IList<Vi_SysPosiInfoModel> _Entity = new List<Vi_SysPosiInfoModel>();
            string commandString = "select * from Vi_SysPosiInfo";
            using (IDataReader dr = db.ExecuteReader(CommandType.Text, commandString))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_SysPosiInfoEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
        #endregion
    }
}
