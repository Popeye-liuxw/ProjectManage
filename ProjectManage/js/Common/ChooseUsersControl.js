//选择用户控件实体类
function ChooseUsersControl(container, parent) {
        this.Container = container;
        this.Parent = parent;
        this.Dom = {};
        var Instance = this;
        var UserInfo = {};
        var CallBack = function () { };
        //点击确定按钮取得
        Instance.Dom.BtnSure = $("#btnSure", container);

        //关闭按钮
        Instance.Dom.BtnCancel = $("#btnCancel", container);

        //        //显示姓名层
        //        Instance.Dom.ChooseUserSpan = $("#chooseUserSpan", container);

        //        //用户ID隐藏域
        //        Instance.Dom.ChooseUserIDSpan = $("#chooseUserIDSpan", container);

        //选择用户主体域
        Instance.Dom.ChooseUserArea = $("#chooseUserArea", container).dialog(
                {
                        modal: true,
                        resizable: false,
                        title: "选择员工",
                        autoOpen: false,
                        width: 800,
                        height: 400
                }
        );

        this.Open = function (callBack) {
                //弹处层显示
                Instance.Dom.ChooseUserArea.dialog("open");
                CallBack = callBack;
        }

        this.Close = function () {
                //点击关闭选择用户层
                Instance.Dom.ChooseUserArea.dialog("close");
        }

        //初始化控件
        this.Init = function () {

        }

        //确认用户处理事件
        this.ChooseUserHandler = function () {
                //获取CheckBox
                var checkedUser = $(":checkbox[id=ChooseUserCheckBox]:checked");
                Instance.ClearChoosedUser();
                //数组长度
                var length = checkedUser.length;

                var userName = "";
                var userSysNo = "";
                $.each(checkedUser, function (index, item) {
                        //填充姓名
                        userName += $(item).siblings("span").text();
                        //填充ID
                        userSysNo += $(item).val();
                        //填充逗号
                        if (index != length - 1) {
                                userName += (",");
                                userSysNo += (",");
                        }
                });
                UserInfo = { UserName: userName, UserSysNo: userSysNo };
                CallBack(UserInfo);
                Instance.Dom.ChooseUserArea.dialog("close");
        }

        this.GetUsers = function () {
                return UserInfo;
        }

        //清空以选择用户
        this.ClearChoosedUser = function () {
                //清空CheckBox
                $(":checkbox").attr("checked", false);
                //清空用户姓名
                //                Instance.Dom.ChooseUserSpan.text("点击选择用户");
                //清空用户ID
                //                Instance.Dom.ChooseUserIDSpan.text("");
        }

        //点击确定按钮的时候
        Instance.Dom.BtnSure.bind("click", Instance.ChooseUserHandler);
}