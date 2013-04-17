// =================================================================== 
// 项目说明
//====================================================================
// visione @ CopyRight 2007-2012
// 文件： Vi_ProjectInfoModel.cs
// 项目名称：ProjectManageSystem 
// 创建时间：2012/8/14
// 负责人：Popeye_lxw
// ===================================================================
using System;
using System.Collections.Generic;
namespace ProjectManage.Model
{
	/// <summary>
	///Vi_ProjectInfo数据实体
	/// </summary>
	[Serializable]
	public class Vi_ProjectInfoModel
	{
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private int _iD;
        ///<summary>
        ///
        ///</summary>
        private int _i_id;
        ///<summary>
        ///
        ///</summary>
        private string _citemcode = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _citemname = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _bclose;
        ///<summary>
        ///
        ///</summary>
        private string _citemccode = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _iotherused;
        ///<summary>
        ///
        ///</summary>
        private string _contractNumber = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _projectNatureSysNo;
        ///<summary>
        ///
        ///</summary>
        private string _cCusCode = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cPersonCode = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _userID;
        ///<summary>
        ///
        ///</summary>
        private DateTime _createTime =DateTime.Parse("1900-01-01");
        ///<summary>
        ///
        ///</summary>
        private DateTime _updateTime=DateTime.Parse("1900-01-01");
        ///<summary>
        ///
        ///</summary>
        private int _prjType;
        ///<summary>
        ///
        ///</summary>
        private int _prjNature;

        private int _developerRec;
        private int _testerRec;
        private int _marketRec;

        #endregion

        #region 构造函数
        ///<summary>
        ///记录各个项目详细信息
        ///</summary>
        public Vi_ProjectInfoModel()
        {
        }
        ///<summary>
        ///记录各个项目详细信息
        ///</summary>
        public Vi_ProjectInfoModel
        (
            int iD,
            int i_id,
            string citemcode,
            string citemname,
            int bclose,
            string citemccode,
            int iotherused,
            string contractNumber,
            int projectNatureSysNo,
            string cCusCode,
            string cPersonCode,
            int userID,
            DateTime createTime,
            DateTime updateTime,
            int prjType,
            int prjNature,
            int developerRec,
            int testerRec,
            int marketRec
         )
        {       
            _iD = iD;
            _i_id = i_id;
            _citemcode = citemcode;
            _citemname = citemname;
            _bclose = bclose;
            _citemccode = citemccode;
            _iotherused = iotherused;
            _contractNumber = contractNumber;
            _projectNatureSysNo = projectNatureSysNo;
            _cCusCode = cCusCode;
            _cPersonCode = cPersonCode;
            _userID = userID;
            _createTime = createTime;
            _updateTime = updateTime;
            _prjType = prjType;
            _prjNature = prjNature;
            _developerRec = developerRec;
            _testerRec = testerRec;
            _marketRec = marketRec;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int I_id
        {
            get { return _i_id; }
            set { _i_id = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string citemcode
        {
            get { return _citemcode; }
            set { _citemcode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string citemname
        {
            get { return _citemname; }
            set { _citemname = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int bclose
        {
            get { return _bclose; }
            set { _bclose = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string citemccode
        {
            get { return _citemccode; }
            set { _citemccode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int iotherused
        {
            get { return _iotherused; }
            set { _iotherused = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ContractNumber
        {
            get { return _contractNumber; }
            set { _contractNumber = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int ProjectNatureSysNo
        {
            get { return _projectNatureSysNo; }
            set { _projectNatureSysNo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string cCusCode
        {
            get { return _cCusCode; }
            set { _cCusCode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string cPersonCode
        {
            get { return _cPersonCode; }
            set { _cPersonCode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int PrjType
        {
            get { return _prjType; }
            set { _prjType = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int PrjNature
        {
            get { return _prjNature; }
            set { _prjNature = value; }
        }

        public int DeveloperRec
        {
            get { return _developerRec; }
            set{_developerRec = value;}
        }

        public int TesterRec
        {
            get { return _testerRec; }
            set { _testerRec = value; }
        }
        public int MarketRec
        {
            get { return _marketRec; }
            set {_marketRec = value; }
        }

        #endregion
	}
    public class updateProInfo
    {
        public int addNum { get; set; }
        public int updateNum { get; set; }
        public List<strProinfo> info { get; set; }
    }
    public class strProinfo
    {
        public String ProinfoDetail { get; set; }
    }
}
