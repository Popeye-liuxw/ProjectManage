
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Provider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/13
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Configuration;
using System.Reflection;
using ProjectManage.Provider;
using ProjectManage.SqlPrivider;
namespace ProjectManage.ProviderFactory
{
	/// <summary>
	/// DataRepository 的摘要说明。
	/// </summary>
	public sealed class DataFactory
	{
        private static readonly string path = ConfigurationManager.AppSettings["DAL"]; 
		public DataFactory()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private static object CreateObject(string path,string CacheKey)
		{			
			object objType = DataCache.GetCache(CacheKey);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(path).CreateInstance(CacheKey);					
					DataCache.SetCache(CacheKey, objType);
				}
				catch(Exception e)
				{
					string w = e.ToString();
				}

			}
			return objType;
		}
		/// <summary>
		/// 得到CustomerSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static CustomerSqlPrivider CreateCustomerSqlPrivider()
		{
			string CacheKey = path+".CustomerSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (CustomerSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到DepartmentSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static DepartmentSqlPrivider CreateDepartmentSqlPrivider()
		{
			string CacheKey = path+".DepartmentSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (DepartmentSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到PersonSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static PersonSqlPrivider CreatePersonSqlPrivider()
		{
			string CacheKey = path+".PersonSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (PersonSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_DeveloperRecSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_DeveloperRecSqlPrivider CreateVi_DeveloperRecSqlPrivider()
		{
			string CacheKey = path+".Vi_DeveloperRecSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_DeveloperRecSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_ManagerRecSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_ManagerRecSqlPrivider CreateVi_ManagerRecSqlPrivider()
		{
			string CacheKey = path+".Vi_ManagerRecSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_ManagerRecSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_MarketRecSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_MarketRecSqlPrivider CreateVi_MarketRecSqlPrivider()
		{
			string CacheKey = path+".Vi_MarketRecSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_MarketRecSqlPrivider)objType;	
		}
        /// <summary>
        /// 得到Vi_PrjChangePaperSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_PrjChangePaperSqlPrivider CreateVi_PrjChangePaperSqlPrivider()
        {
            string CacheKey = path + ".Vi_PrjChangePaperSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_PrjChangePaperSqlPrivider)objType;
        }
        /// <summary>
        /// 得到Vi_PrjDailyPaperSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_PrjDailyPaperSqlPrivider CreateVi_PrjDailyPaperSqlPrivider()
        {
            string CacheKey = path + ".Vi_PrjDailyPaperSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_PrjDailyPaperSqlPrivider)objType;
        }
        /// <summary>
        /// 得到Vi_PrjMonthPaperSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_PrjMonthPaperSqlPrivider CreateVi_PrjMonthPaperSqlPrivider()
        {
            string CacheKey = path + ".Vi_PrjMonthPaperSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_PrjMonthPaperSqlPrivider)objType;
        }
		/// <summary>
		/// 得到Vi_ProjectInfoSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_ProjectInfoSqlPrivider CreateVi_ProjectInfoSqlPrivider()
		{
			string CacheKey = path+".Vi_ProjectInfoSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_ProjectInfoSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_ProjectNatureSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_ProjectNatureSqlPrivider CreateVi_ProjectNatureSqlPrivider()
		{
			string CacheKey = path+".Vi_ProjectNatureSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_ProjectNatureSqlPrivider)objType;
        }
        /// <summary>
        /// 得到Vi_SysBackUserSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_SysBackUserSqlPrivider CreateVi_SysBackUserSqlPrivider()
        {
            string CacheKey = path + ".Vi_SysBackUserSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_SysBackUserSqlPrivider)objType;
        }
        /// <summary>
        /// 得到Vi_SysEmailServerSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_SysEmailServerSqlPrivider CreateVi_SysEmailServerSqlPrivider()
        {
            string CacheKey = path + ".Vi_SysEmailServerSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_SysEmailServerSqlPrivider)objType;
        }
        /// <summary>
        /// 得到Vi_SysLogSqlPrivider对象
        /// </summary>
        /// <returns></returns>
        public static Vi_SysLogSqlPrivider CreateVi_SysLogSqlPrivider()
        {
            string CacheKey = path + ".Vi_SysLogSqlPrivider";
            object objType = CreateObject(path, CacheKey);
            return (Vi_SysLogSqlPrivider)objType;
        }
		/// <summary>
		/// 得到Vi_SysModulesSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysModulesSqlPrivider CreateVi_SysModulesSqlPrivider()
		{
			string CacheKey = path+".Vi_SysModulesSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysModulesSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysPosiInfoSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysPosiInfoSqlPrivider CreateVi_SysPosiInfoSqlPrivider()
		{
			string CacheKey = path+".Vi_SysPosiInfoSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysPosiInfoSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysPosiPermSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysPosiPermSqlPrivider CreateVi_SysPosiPermSqlPrivider()
		{
			string CacheKey = path+".Vi_SysPosiPermSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysPosiPermSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysSendEmailSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysSendEmailSqlPrivider CreateVi_SysSendEmailSqlPrivider()
		{
			string CacheKey = path+".Vi_SysSendEmailSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysSendEmailSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysTypeSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysTypeSqlPrivider CreateVi_SysTypeSqlPrivider()
		{
			string CacheKey = path+".Vi_SysTypeSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysTypeSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysUserSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysUserSqlPrivider CreateVi_SysUserSqlPrivider()
		{
			string CacheKey = path+".Vi_SysUserSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysUserSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_SysUserRoleSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_SysUserRoleSqlPrivider CreateVi_SysUserRoleSqlPrivider()
		{
			string CacheKey = path+".Vi_SysUserRoleSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_SysUserRoleSqlPrivider)objType;	
		}
		/// <summary>
		/// 得到Vi_TesterRecSqlPrivider对象
		/// </summary>
		/// <returns></returns>
		public static Vi_TesterRecSqlPrivider CreateVi_TesterRecSqlPrivider()
		{
			string CacheKey = path+".Vi_TesterRecSqlPrivider";	
			object objType=CreateObject(path,CacheKey);			
			return (Vi_TesterRecSqlPrivider)objType;	
		}
	}
}
