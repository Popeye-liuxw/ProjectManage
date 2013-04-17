
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： PersonProvider.cs
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
    public  abstract partial class PersonProvider : DataTiersProvider
    {
		///<summary>
		///向数据库中插入一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int SavePerson(PersonModel Model);
		///<summary>
		///更新数据库中一条数据
		///</summary>
		/// <param name="Model">Model</param>
		/// <returns>影响的条数</returns>
		public abstract int UpdatePerson(PersonModel Model);
		///<summary>
		///删除数据库一条数据
		///</summary>
		/// <param name="cPersonCode">cPersonCode</param>
		/// <returns>影响的条数</returns>
		public abstract int DeletePerson(string cPersonCode);
		/// <summary>
		/// 根据ID,返回一个Person对象
		/// </summary>
		/// <param name="id">Person ID</param>
		/// <returns>Person对象</returns>
		public abstract PersonModel Get_PersonModel(string cPersonCode);
		/// <summary>
		/// 得到数据表Person所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		public abstract IList< PersonModel> GetPersonAll();
    }
}
