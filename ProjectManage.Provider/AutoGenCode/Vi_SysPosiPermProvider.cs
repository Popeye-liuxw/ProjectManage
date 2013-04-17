
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysPosiPermProvider.cs
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
    public  abstract partial class Vi_SysPosiPermProvider : DataTiersProvider
    {
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int SaveVi_SysPosiPerm(Vi_SysPosiPermModel Model);
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int UpdateVi_SysPosiPerm(Vi_SysPosiPermModel Model);
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public abstract int DeleteVi_SysPosiPerm(int ID);
		/// <summary>
		/// 根据ID,返回一个Vi_SysPosiPerm对象
		/// </summary>
		/// <param name="id">Vi_SysPosiPerm ID</param>
		/// <returns>Vi_SysPosiPerm对象</returns>
		public abstract Vi_SysPosiPermModel Get_Vi_SysPosiPermModel(Int32 ID);
		/// <summary>
		/// 得到数据表Vi_SysPosiPerm所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		public abstract IList< Vi_SysPosiPermModel> GetVi_SysPosiPermAll();
    }
}
