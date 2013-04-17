
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： DepartmentProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class DepartmentProvider : DataTiersProvider
    {
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int SaveDepartment(DepartmentModel Model);
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int UpdateDepartment(DepartmentModel Model);
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="cDepCode">cDepCode</param>
		/// <returns>影响的条数</returns>
		public abstract int DeleteDepartment(string cDepCode);
		/// <summary>
		/// 根据ID,返回一个Department对象
		/// </summary>
		/// <param name="id">Department ID</param>
		/// <returns>Department对象</returns>
		public abstract DepartmentModel Get_DepartmentModel(string cDepCode);
		/// <summary>
		/// 得到数据表Department所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		public abstract IList< DepartmentModel> GetDepartmentAll();
    }
}
