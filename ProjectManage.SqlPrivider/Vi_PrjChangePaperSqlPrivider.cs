
// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_PrjChangePaperSqlPrivider.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/9/3
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ProjectManage.Model;
using ProjectManage.Provider;
using System.Data.Common;
using System.Data;
namespace ProjectManage.SqlPrivider
{
	/// <summary>
	/// 摘要说明。
	/// </summary>
	public partial class Vi_PrjChangePaperSqlPrivider : Vi_PrjChangePaperProvider
	{


        public override IList<Vi_PrjChangePaperModel> GetPrjChangePaper(int prjId, int userId, int top)
        {
            IList<Vi_PrjChangePaperModel> _Entity = new List<Vi_PrjChangePaperModel>();
            string commandString = "SELECT TOP " + top + " [ID],[PrjID],[State],[Summarize],[UserID],[CreateTime],[UpdateTime] FROM [Vi_PrjChangePaper] where PrjID = @prjId and UserID = @userId order by CreateTime desc";
            DbCommand command = db.GetSqlStringCommand(commandString);
            db.AddInParameter(command, "@top", DbType.Int32, top);
            db.AddInParameter(command, "@userId", DbType.Int32, userId);
            db.AddInParameter(command, "@prjId", DbType.Int32, prjId);
            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    _Entity.Add(Populate_Vi_PrjChangePaperEntity_FromDr(dr));
                }
            }
            return _Entity;
        }
    }
}
