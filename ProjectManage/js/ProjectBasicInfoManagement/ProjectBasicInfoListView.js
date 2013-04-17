//项目基本信息查询
function ProjectBasicInfoListView(container, parent) {
        this.Parent = parent;
        this.Dom = {};
        this.Container = container;
        var Instance = this;

        //添加按钮
        Instance.Dom.btnAdd = $("#btnAdd", container);
        Instance.Dom.btnAdd.click(function () {
                popAare.dialog("open");
        });

        //弹出层
        var popAare = $("#ProjectDetail_Div").dialog(
                        {
                                modal: true,
                                resizable: false,
                                title: "添加项目基本信息",
                                autoOpen: false,
                                width: 1000,
                                height: 400
                        }
                );
        //关闭弹出层
        this.ClosePopArea = function () {
                popAare.dialog("close");
        }
        //初始化明细页面
        var projectBasicInfoDetail = new ProjectBasicInfoDetail($("#ProjectDetail_Div"), Instance);

        //分页控件初始化变量
        Instance.Pager = {
                pagenumber: 1,
                pagecount: 50,
                buttonClickCallback: function (pageClickNumber) {

                }
        };

        //初始化分页控件
        $("#pager", container).pager(Instance.Pager);

        //得到页面数据
        this.GetData = function () {
                var returnObj = {
                        ContractNumber: $("#ContractNumber", container).val(),
                        citemname: $("#citemname", container).val(),
                        citemccode: $("#ProjectClassSelect", container).val(),
                        ProjectNatureSysNo: $("#ProjectNatureSelect", container).val(),
                        PaymentMoeny: $("#PaymentMoeny", container).val(),
                        InDate: $("#InDate", container).val(),
                        cCusCode: $("#CustomerSelect", container).val(),
                        cPersonCode: $("#UsersSelect", container).val()
                };
                if (returnObj.PaymentMoeny == "") returnObj.PaymentMoeny = 0.0;
                //                if (returnObj.InDate == "") returnObj.InDate = "/1990-01-01/";
                return returnObj;
        }

        this.GetPageInfo = function (pageCurrent) {
                var pageInfo = {
                        PageCurrent: 1,
                        PageSize: 20
                };
                if (pageCurrent) {
                        pageInfo.PageCurrent = pageCurrent;
                }
                return pageInfo;
        }

        //查询按钮
        Instance.Dom.btnSearch = $("#BtnSearch", container);
        Instance.Dom.btnSearch.click(function () {
                var dataString = Global.toJSON(Instance.GetData());
                var pageString = Global.toJSON(Instance.GetPageInfo());
                Global.SendRequest("/Hanlder/ProjectBasic/ProjectBasciInfo.ashx", { "action": "0", "queryEntityString": dataString, "PageInfo": pageString }, function (jsonResult) {
                        alert(jsonResult);
                });
        });
}