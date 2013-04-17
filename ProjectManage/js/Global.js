//Global 接口
function Global() { }

//发送Ajax请求
Global.SendRequest = function (Url, DataParameters, successFun, LoaddingFun, LoaddingCloseFun, errorFun, completeFun, beforeFun) {
        $.ajax({
                async: true,
                cache: false,
                type: "POST",
                url: Url,
                data: DataParameters,
                datatype: "json",
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                beforeSend: function () {
                        if (LoaddingFun) {
                                LoaddingFun();
                        }
                        if (beforeFun) {
                                beforeFun();
                        }
                },
                success: function (jsonResult) {
                        if (LoaddingCloseFun) {
                                LoaddingCloseFun();
                        }
                        if (successFun) {
                                successFun(jsonResult)
                        }
                },
                error: function (XMLHttpRequest) {
                        if (LoaddingCloseFun) {
                                LoaddingCloseFun();
                        }
                        if (errorFun) {
                                errorFun(XMLHttpRequest);
                        }
                },
                complete: function (XMLHttpRequest) {
                        if (LoaddingCloseFun) {
                                LoaddingCloseFun();
                        }
                        if (completeFun) {
                                completeFun(XMLHttpRequest);
                        }
                }
        });
}

//操作类型
function ProcessType() { }

ProcessType.Add = "1";
ProcessType.Edit = "2";
ProcessType.Delete = "3";
ProcessType.Approve = "4";
ProcessType.Reject = "5";
ProcessType.Active = "6";
ProcessType.Deactive = "7";
ProcessType.View = "8";
ProcessType.Refresh = "9";
ProcessType.Copy = "10";
ProcessType.Disable = "11";
ProcessType.Display = "12";

//页面内容实例化
function GridArgumentData(instance) {
        var gridInstance = this;
        this.Instance = instance;
        this.Container = this.Instance.Container;
        this.Grid = $(".list_wrap", this.Container);
        this.Condition = $(".queryspace", this.Container);
        this.MessageBox = $(".newMessage", this.Container);
        //    this.BindCompleteHandler = function ()
        //    {
        //        gridInstance.ClickEdit("Edit", gridInstance.Instance);
        //    };
        this.ClickEdit = function (linkName, instance) {
                $.each($("a[name=" + linkName + "]", instance.Container), function (index, item) {
                        $(item).click(function () {
                                var tr = $(this).parents("tr:first")[0];
                                var data = Global.Query.GetData(tr)
                                instance.Process(data, ProcessType.Edit);
                                gridInstance.MessageBox.hide();
                        });
                })
        };
}

//页面查询接口
Global.Query = {};
Global.Query.GetData = function (tr) {
        var result = {};
        var arrtempTD = tr.children("td");
        $.each(arrtempTD, function (index, item) {
                var strBindAttribute = $(item).attr("bind");
                var bindObject = eval("(" + strBindAttribute + ")");

        });
}

Global.evalJSON = function (strJson) {
        return eval("(" + strJson + ")");
}
Global.toJSON = function (object) {
        var type = typeof object;
        if ('object' == type) {
                if (Array == object.constructor) type = 'array';
                else if (RegExp == object.constructor) type = 'regexp';
                else type = 'object';
        }
        switch (type) {
                case 'undefined':
                case 'unknown':
                        return;
                        break;
                case 'function':
                case 'boolean':
                case 'regexp':
                        return object.toString();
                        break;
                case 'number':
                        return isFinite(object) ? object.toString() : 'null';
                        break;
                case 'string':
                        return '"' + object.replace(/(\\|\")/g, "\\$1").replace(/\n|\r|\t/g, function () {
                                var a = arguments[0];
                                return (a == '\n') ? '\\n' : (a == '\r') ? '\\r' : (a == '\t') ? '\\t' : ""
                        }) + '"';
                        break;
                case 'object':
                        if (object === null) return 'null';
                        var results = [];
                        for (var property in object) {
                                var value = Global.toJSON(object[property]);
                                if (value !== undefined) results.push(Global.toJSON(property) + ':' + value);
                        }
                        return '{' + results.join(',') + '}';
                        break;
                case 'array':
                        var results = [];
                        for (var i = 0; i < object.length; i++) {
                                var value = Global.toJSON(object[i]);
                                if (value !== undefined) results.push(value);
                        }
                        return '[' + results.join(',') + ']';
                        break;
        }
}

//重写Global.Lodding方法
Global.LoddingFun = function () {
        $.PopCover();
        $.Loadding();
}
//重写Global.LoddingClose方法
Global.LoddingClose = function () {
        $.PopCloseCover();
        $.LaddingClose();
}