using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManage.Model;
using ProjectManage.ProviderFactory;
using ProjectManage.SqlPrivider;
using ProjectManage.Provider;

/*
 * =================================================================== 
 * 项目说明 
 *====================================================================
 * visione @ CopyRight 2007-2012
 * 文件： SysPosiInfoManage.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/15 16:48:10
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 职位信息相关功能
    /// </summary>
    public class SysPosiInfoManage
    {

        private Vi_SysPosiInfoProvider _PosiInfoSql;
        
        public SysPosiInfoManage()
        {
            _PosiInfoSql = DataFactory.CreateVi_SysPosiInfoSqlPrivider();
        }


        /// <summary>
        /// 根据职位编号得到职位信息
        /// </summary>
        /// <param name="id">职位编号</param>
        /// <returns></returns>
        public Vi_SysPosiInfoModel GetPosiInfo(int id)
        {
            Vi_SysPosiInfoModel PosiInfo = null;
            if (_PosiInfoSql != null)
            {
                PosiInfo = _PosiInfoSql.Get_Vi_SysPosiInfoModel(id);
            }
            return PosiInfo;
        }

        /// <summary>
        /// 向系统中添加一个职位信息
        /// </summary>
        /// <param name="posiInfo">职位信息对象</param>
        /// <returns>true 添加成功 ; false 添加失败</returns>
        public bool SavePosiInfo(Vi_SysPosiInfoModel posiInfo)
        {
            bool result = false;
            if (_PosiInfoSql != null)
            {
                if (_PosiInfoSql.SaveVi_SysPosiInfo(posiInfo) > 0)
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// 删除系统中职位信息
        /// </summary>
        /// <param name="id">职位ID</param>
        /// <returns>true 添加成功 ; false 添加失败</returns>
        public bool DelPosiInfo(int id)
        {
            bool result = false;
            if (_PosiInfoSql != null)
            {
                if (_PosiInfoSql.DeleteVi_SysPosiInfo(id) > 0) result = true;
            }
            return result;
        }


        /// <summary>
        /// 得到所有职位信息
        /// </summary>
        /// <returns></returns>
        public List<Vi_SysPosiInfoModel> GetPosiInfoAll()        
        {
            List<Vi_SysPosiInfoModel> PosiInfos = new List<Vi_SysPosiInfoModel>();
            if (_PosiInfoSql != null)
            {
                PosiInfos = _PosiInfoSql.GetVi_SysPosiInfoAll().ToList();
            }
            return PosiInfos;
        }

        /// <summary>
        /// 检测该职位是否设定了相关权限
        /// </summary>
        /// <param name="PosiID">职位ID</param>
        /// <returns></returns>
        public string ExistsPosiPermByPosiID(string PosiID)
        {
            string result = "未设定";
            int posiID = 0;
            if (int.TryParse(PosiID, out posiID))
            {
                int count = _PosiInfoSql.ExistsSysPosiPermByPosiID(posiID);

                if (count > 0) result = "已设定";
            }   
            return result;
        }
    }
}
