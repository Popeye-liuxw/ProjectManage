﻿
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysUserProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/15
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
    public  abstract partial class Vi_SysUserProvider : DataTiersProvider
    {
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int SaveVi_SysUser(Vi_SysUserModel Model);
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int UpdateVi_SysUser(Vi_SysUserModel Model);
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public abstract int DeleteVi_SysUser(int ID);
		/// <summary>
		/// 根据ID,返回一个Vi_SysUser对象
		/// </summary>
		/// <param name="id">Vi_SysUser ID</param>
		/// <returns>Vi_SysUser对象</returns>
		public abstract Vi_SysUserModel Get_Vi_SysUserModel(Int32 ID);
		/// <summary>
		/// 得到数据表Vi_SysUser所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		public abstract IList< Vi_SysUserModel> GetVi_SysUserAll();
    }
}
