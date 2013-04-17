//项目基本信息明细页
function ProjectBasicInfoDetail(container, parent) {
        this.Parent = parent;
        this.Container = container;
        this.Dom = {};
        var Instance = this;

        //开发人员姓名Span
        Instance.Dom.DevelopEngineerSpan = $("#chooseUserSpan_DevelopEngineer");
        Instance.Dom.DevelopEngineerIDSpan = $("#chooseUserIDSpan_DevelopEngineer");
        Instance.Dom.DevelopEngineerSpan.click(function () {
                chooseUserControl.Open(Instance.DevelopCallBack);
        });
        this.DevelopCallBack = function (userInfo) {
                Instance.Dom.DevelopEngineerSpan.text(userInfo.UserName);
                Instance.Dom.DevelopEngineerIDSpan.text(userInfo.UserSysNo);
        }


        //测试人员姓名Span
        Instance.Dom.TestEngineerSpan = $("#chooseUserSpan_TestEngineer");
        Instance.Dom.TestEngineerSpan.click(function () {
                chooseUserControl.Open(Instance.TestCallback);
        });
        Instance.Dom.TestEngineerIDSpan = $("#chooseUserIDSpan_TestEngineer");
        //测试人员回掉
        this.TestCallback = function (userInfo) {
                Instance.Dom.TestEngineerSpan.text(userInfo.UserName);
                Instance.Dom.TestEngineerIDSpan.text(userInfo.UserSysNo);
        }

        //商务人员姓名Span
        Instance.Dom.BusinessEngineerSpan = $("#chooseUserSpan_BusinessEngineer");
        Instance.Dom.BusinessEngineerSpan.click(function () {
                chooseUserControl.Open(Instance.BusinessCallback);
        });
        Instance.Dom.BusinessEngineerIDSpan = $("#chooseUserIDSpan_BusinessEngineer");
        //测试人员回掉
        this.BusinessCallback = function (userInfo) {
                Instance.Dom.BusinessEngineerSpan.text(userInfo.UserName);
                Instance.Dom.BusinessEngineerIDSpan.text(userInfo.UserSysNo);
        }

        //初始化选择用户控件
        var chooseUserControl = new ChooseUsersControl($("#ChooseUserMain_Div"), Instance);

        //保存按钮
        Instance.Dom.BtnSave = $("#BtnSave", container);
        Instance.Dom.BtnSave.click(function () {
                //项目基本信息情报取得
                var JSONString = Global.toJSON(Instance.GetData());
                //发送请求
                Global.SendRequest("/Hanlder/ProjectBasic/ProjectBasciInfo.ashx", { "action": "1", "queryEntityString": JSONString }, function (jsonResult) {
                        //新规成功的场合
                        if (jsonResult != "0") {
                                alert("新规成功！");
                                //关闭弹出层
                                Instance.Parent.ClosePopArea();

                        }
                });
        });

        //项目合同市场编号
        Instance.Dom.ContractNumberTextBox = $("#ContractNumberTextBox", container);
        //项目名称
        Instance.Dom.ProjectNameTextBox = $("#ProjectNameTextBox", container);
        //项目类型
        Instance.Dom.ProjectClassDropdownList = $("#ProjectClassSelect", container);
        //项目性质
        Instance.Dom.ProjectNatureDropdownList = $("#ProjectNatureSelect", container);
        //客户
        Instance.Dom.CustomerDropdownList = $("#CustomerSelect", container);
        //项目经理
        Instance.Dom.UsersDropdownList = $("#UsersSelect", container);


        //封装页面上的参数内容
        this.GetData = function () {
                var resultEntity =
                        {
                                ContractNumber: Instance.Dom.ContractNumberTextBox.val(),
                                ProjectName: Instance.Dom.ProjectNameTextBox.val(),
                                ProjectTypeSysNo: Instance.Dom.ProjectClassDropdownList.val(),
                                ProjectNatureSysNo: Instance.Dom.ProjectNatureDropdownList.val(),
                                CustomerSysNo: Instance.Dom.CustomerDropdownList.val(),
                                ProjectManagerSysNo: Instance.Dom.UsersDropdownList.val(),
                                DevelopEngineer: Instance.Dom.DevelopEngineerIDSpan.text(),
                                TestEngineer: Instance.Dom.TestEngineerIDSpan.text(),
                                BusinessEngineer: Instance.Dom.BusinessEngineerIDSpan.text()
                        };
                return resultEntity;
        }
}