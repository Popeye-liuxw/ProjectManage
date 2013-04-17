using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace ProjectManage.ProviderFactory
{
	/// <summary>
	/// ���������
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// ��ȡ��ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            //System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            //return objCache[CacheKey];
            CacheManager cacheManager = (CacheManager)CacheFactory.GetCacheManager();

            return cacheManager.GetData(CacheKey);

        }

		/// <summary>
		/// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			//System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            //objCache.Insert(CacheKey, objObject);
            //��ӻ�����
            CacheManager cacheManager = (CacheManager)CacheFactory.GetCacheManager();
            cacheManager.Add(CacheKey, objObject);			
		}
	}
}
