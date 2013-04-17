<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"CodeBehind="AddDailyReport.aspx.cs" Inherits="ProjectManage.Project.AddDailyReport" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <script type="text/javascript" src="../Editor/kindeditor-min.js"></script>
    <script type="text/javascript">
        var Daily
        KindEditor.ready(function (K) {

            Daily = K.create('#Daily', {
                resizeType: 1,
                pasteType: 1,
                newlineTag: 'p',
                urlType: 'domain',
                allowPreviewEmoticons: false,
                uploadJson: '../SaveFile/upload_json.ashx',
                fileManagerJson: '../SaveFile/file_manager_json.ashx',
                allowFileManager: false,
                allowImageUpload: true,
                items: ['source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', 'clearhtml', 'quickformat', 'selectall', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'preview'],
                afterChange: function () {
                   
                },
                afterFocus: function (txt) {
                    var value = this.html();
                    if (value == "<br />" || value == "在这里输入当天工作情况总结") {
                        this.html("");
                    }
                },
                afterBlur: function (txt) {
                    var value = this.html();
                    if (value == "" || value == "<br />") {
                        this.html("在这里输入当天工作情况总结");
                    }
                    var countNum = this.count();
                    if (countNum > 5000) {
                        var tmp = countNum - limitnum;
                        var parent = '你输入的内容超出系统设定字符数(' + tmp + '个)，请精简内容，或减少使用一些样式';
                        alert(parent);
                    }
                }
            });
            //prettyPrint();
        });
        var ChangePaper;
        KindEditor.ready(function (K) {
            ChangePaper = K.create('#ChangePaper', {
                resizeType: 1,
                pasteType: 1,
                newlineTag: 'p',
                urlType: 'domain',
                allowPreviewEmoticons: false,
                uploadJson: '../SaveFile/upload_json.ashx',
                fileManagerJson: '../SaveFile/file_manager_json.ashx',
                allowFileManager: false,
                allowImageUpload: true,
                items: ['source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', 'clearhtml', 'quickformat', 'selectall', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'preview'],
                afterChange: function () {
                   
                },
                afterFocus: function (txt) {
                    var value = this.html();
                    if (value == "<br />" || value == "有无需求变更，在这里输入") {
                        this.html("");
                    }
                },
                afterBlur: function (txt) {
                    var value = this.html();
                    if (value == "" || value == "<br />") {
                        this.html("有无需求变更，在这里输入");
                    }
                    var countNum = this.count();
                    if (countNum > 5000) {
                        var tmp = countNum - limitnum;
                        var parent = '你输入的需求变更内容超出系统设定字符数(' + tmp + '个)，请精简内容，或减少使用一些样式';
                        alert(parent);
                    }
                }
            });
            
        });

//        Daily('#Daily').blur(function () {
//                alert('12321');
//            });

////        var blur = Daily.blur();

////        blur = function () {
////            alert('sadfasd');
////        }
////        Daily.focus = function () {
////            alert('sadfasd');
////        }
        function add_ok_onclick() {
            var Dailyhtml = Daily.html();
            var ChangePaperhtml = ChangePaper.html();

            if (Dailyhtml == "<br />" || Dailyhtml == "在这里输入当天工作情况总结") {
                alert("亲，你还没有填写日报内容！");
                return false;
            }
            if (ChangePaperhtml == "<br />") {
                if (confirm("是否要填写需求变更信息？")) {
                    return false;
                }
                else {
                    ChangePaper.html("有无需求变更，在这里输入");
                    return false;
                }
            }
            return confirm("添加成功后将不能修改,确认要添加以上内容吗？");
        }
        function add_cancel_onclick() {
            window.history.go(-1);
        }
        function clearDefault(el) {if (el.defaultValue==el.value) el.value = ""   }
        function clearValue(el) {
            alert(el.value);
            if (el.value == '在这里输入当天工作情况总结') { el.value = ''; el.select(); }
        }
    </script>
    <div id="r_topmenu">
        <uc:Spinner ID="spn_Menu" runat="server" MenuID="8" />
    </div>
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div class="titleDIV">
        <p> 项目：<asp:Label ID="lbl_Title" runat="server"></asp:Label> </p>
    </div>
    <div id="DailyReportList">
        <!-- 当前项目日报表添加 开始 -->
        <div id="AddCurrentProDaily">
            <ul>
                <li>
                    <textarea id="Daily" cols="30" name="txta2" rows="8" style="width:100%;height:60px;margin:3px auto;"  runat="server" clientidmode="Static" >在这里输入当天工作情况总结</textarea>
                </li>
                <li>
                    <textarea id="ChangePaper" cols="30" style="width:100%;height:60px;margin:3px auto;"  name="intraduction" rows="8" runat="server" clientidmode="Static">有无需求变更，在这里输入</textarea></li>
                <!--<li class="AddCurrentProDailyBtn"></li>-->
            </ul>
        </div>
        <!-- 当前项目日报表添加 结束-->
        <!-- 当前项目日报表列表 开始-->
        <div id="DailyList">
        </div>
        <!-- 当前项目日报表列表 结束-->
    </div>
    <div id="AttentionList">
        <h2 class="titleH2">
            关注人:</h2>
        <asp:CheckBoxList ID="cbl_Attention" CssClass="chk_list" runat="server" RepeatDirection="Horizontal"
            RepeatColumns="6" EnableTheming="False" TextAlign="Right">
        </asp:CheckBoxList>
    </div>
    <div class="sysTips">
        <p>
            TIPS：系统将会以邮件形式通知你选中的关注人，他们将会收到你的日报内容</p>
    </div>
    <div id="Edit" class="SaveinfoDiv">
        <asp:Label ID="lbl_msg" runat="server"></asp:Label>
        <asp:Button ID="btn_Save" runat="server" CssClass="btn2" Text="添加" OnClick="btn_Save_Click" OnClientClick="return add_ok_onclick();" />&nbsp;
        <asp:Button ID="btn_Back" runat="server" CssClass="btn2" Text="返回" 
            onclick="btn_Back_Click" />
    </div>
</asp:Content>
