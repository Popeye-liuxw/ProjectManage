﻿
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_DeveloperRecProvider.cs
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
    public  abstract partial class Vi_DeveloperRecProvider : DataTiersProvider
    {
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int SaveVi_DeveloperRec(Vi_DeveloperRecModel Model);
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int UpdateVi_DeveloperRec(Vi_DeveloperRecModel Model);
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="ID">ID</param>
		/// <returns>影响的条数</returns>
		public abstract int DeleteVi_DeveloperRec(int ID);
		/// <summary>
		/// 根据ID,返回一个Vi_DeveloperRec对象
		/// </summary>
		/// <param name="id">Vi_DeveloperRec ID</param>
		/// <returns>Vi_DeveloperRec对象</returns>
		public abstract Vi_DeveloperRecModel Get_Vi_DeveloperRecModel(Int32 ID);
		/// <summary>
		/// 得到数据表Vi_DeveloperRec所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		public abstract IList<Vi_DeveloperRecModel> GetVi_DeveloperRecAll();
    }
}
