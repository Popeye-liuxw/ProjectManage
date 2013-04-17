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
 * 文件： SysDictionaryBll.cs
 * 项目名称：ProjectManageSystem 
 * 创建时间：2012/8/21 17:56:49
 * 负责人：Popeye_lxw
 * ===================================================================
 */
namespace ProjectManage.BLL
{
    /// <summary>
    /// 系统字典相关功能
    /// </summary>
    public class SysDictionaryBll
    {
        private Vi_SysTypeProvider _TypeSql;
        public SysDictionaryBll()
        {
            _TypeSql = DataFactory.CreateVi_SysTypeSqlPrivider();
        }

        #region 私有成员函数
        /// <summary>
        /// 得到最大值
        /// </summary>
        /// <returns></returns>
        private int GetMaxTypeValue()
        {
            int result = _TypeSql.GetMaxTypeValue();
            if (result == 0) result = 1100;
            else result = result + 100;
            return result;
        }

        #endregion



        /// <summary>
        /// 得到主类型相关信息
        /// </summary>
        /// <returns></returns>
        public List<MainTypeModel> GetBigTypeAll()
        {
            List<MainTypeModel> MainTypes = new List<MainTypeModel>();

            List<Vi_SysTypeModel> sysTypes = _TypeSql.GetVi_SysTypeByLevel((Int32)TypeLeve.BigType).ToList();

            foreach (Vi_SysTypeModel item in sysTypes)
            {
                MainTypeModel main = new MainTypeModel()
                {
                    ID = item.ID,
                    TypeName = item.BigType,
                    TypeValue = item.BigValue,
                    CreateTime = item.CreateTime,
                };
                MainTypes.Add(main);
            }

            return MainTypes;
        }

        /// <summary>
        /// 得到所有子类型相关信息
        /// </summary>
        /// <returns></returns>
        public List<ItemTypeModel> GetItemTypeAll(int bigType)
        {
            List<ItemTypeModel> Types = new List<ItemTypeModel>();

            List<Vi_SysTypeModel> sysTypes = _TypeSql.GetVi_SysTypeByTypeValue(bigType, (int)TypeLeve.ItemType).ToList();

            foreach (Vi_SysTypeModel item in sysTypes)
            {
                ItemTypeModel main = new ItemTypeModel()
                {
                    ID = item.ID,
                    TypeName = item.BigType,
                    TypeValue = item.BigValue,
                    ItemName = item.TypeName,
                    ItemValue = item.TypeValue,
                    CreateTime = item.CreateTime,
                };
                Types.Add(main);
            }

            return Types;
        }
        /// <summary>
        /// 得到子类型对象
        /// </summary>
        /// <param name="ID">类型ID</param>
        /// <returns></returns>
        public ItemTypeModel GetItemTypeModel(int ID)
        {
            ItemTypeModel model = new ItemTypeModel();

            Vi_SysTypeModel typeModel = _TypeSql.Get_Vi_SysTypeModel(ID);
            if (typeModel != null)
            {
                model.ID = typeModel.ID;
                model.ItemName = typeModel.TypeName;
                model.ItemValue = typeModel.TypeValue;
                model.TypeName = typeModel.BigType;
                model.TypeValue = typeModel.BigValue;
                model.CreateTime = typeModel.CreateTime;
            }


            return model;
        }

        /// <summary>
        /// 获得最大类型值
        /// </summary>
        /// <returns></returns>
        public string GetBigTypeValue()
        {
            string TypeValue = string.Empty;

            TypeValue = GetMaxTypeValue().ToString();
            
            return TypeValue;
        }

        /// <summary>
        /// 保存大类类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveBigType(MainTypeModel model)
        {
            bool result = false;

            if (model != null)
            {
                Vi_SysTypeModel systype = new Vi_SysTypeModel()
                {
                    TypeName = string.Empty,
                    TypeValue = 0,
                    BigType = model.TypeName,
                    BigValue = model.TypeValue,
                    CreateTime = model.CreateTime,
                    Level = (int)TypeLeve.BigType,
                };
                
                result = _TypeSql.SaveVi_SysType(systype) > 0 ? true : false;
            }
            return result;
        }

        /// <summary>
        /// 保存小类型信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveItemType(ItemTypeModel model)
        {
            bool result = false;

            if (model != null)
            {
                Vi_SysTypeModel systype = new Vi_SysTypeModel()
                {
                    TypeName = model.ItemName,
                    TypeValue = model.ItemValue,
                    BigType = model.TypeName,
                    BigValue = model.TypeValue,
                    CreateTime = model.CreateTime,
                    Level = (int)TypeLeve.ItemType,
                };
                if (model.ID > 0)
                {
                    systype.ID = model.ID;
                    result = _TypeSql.UpdateVi_SysType(systype) > 0 ? true : false;
                }
                else
                {
                    result = _TypeSql.SaveVi_SysType(systype) > 0 ? true : false;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据主键ID获取主类实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MainTypeModel GetMainTypeModel(int id)
        {
            MainTypeModel model = null;

            Vi_SysTypeModel systype = _TypeSql.Get_Vi_SysTypeModel(id);

            if (systype != null)
            {
                model = new MainTypeModel()
                {
                    ID = systype.ID,
                    TypeName = systype.BigType,
                    TypeValue = systype.BigValue,
                    CreateTime = systype.CreateTime,
                };
            }

            return model;
        }

        /// <summary>
        /// 检测是否存在该值
        /// </summary>
        /// <param name="value">要验证的值类型值</param>
        /// <param name="typeValue">主类型值</param>
        /// <returns></returns>
        public bool ExistsItemType(int value, int typeValue)
        {
            return _TypeSql.ExistsItemTypeValue(value, typeValue, (int)TypeLeve.ItemType);
        }

    }
}
