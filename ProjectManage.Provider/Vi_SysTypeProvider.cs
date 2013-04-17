
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_SysTypeProvider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;

namespace ProjectManage.Provider
{
    public  abstract partial class Vi_SysTypeProvider
    {
        /// <summary>
        /// 根据类型等级，或许相应集合
        /// </summary>
        /// <param name="level">类型等级</param>
        /// <returns></returns>
        public abstract IList<Vi_SysTypeModel> GetVi_SysTypeByLevel(int level);

        /// <summary>
        /// 根据大类类型值，获取相应小类集合
        /// </summary>
        /// <param name="bigType">大类类型值</param>
        /// <returns></returns>
        public abstract IList<Vi_SysTypeModel> GetVi_SysTypeByTypeValue(int bigType,int level);

        /// <summary>
        /// 获取最大类型值
        /// </summary>
        /// <returns></returns>
        public abstract int GetMaxTypeValue();

        /// <summary>
        /// 检测是否存在小类型值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool ExistsItemTypeValue(int value, int typeValue, int level);
        
	}
}