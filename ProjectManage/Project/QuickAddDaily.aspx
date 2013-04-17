<%@ Page Title="快速添加日报" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QuickAddDaily.aspx.cs" Inherits="ProjectManage.Project.QuickAddDaily" %>

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
                    //nothing to do here
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

        // Daily.focus();

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
            var ddl = document.getElementById("ddl_PrjName");
            if (ddl.value == "-1") {
                alert('请先选择项目【友情提示：在选择项目后，目前录入的日报内容将被清除，自行做好备份。】')
                return false;
            }
            return confirm("添加成功后将不能修改,确认要添加以上内容吗？");
        }
        function getSelectedText(name) {
            var obj = document.getElementById(name);
            for (i = 0; i < obj.length; i++) {
                if (obj[i].selected == true) {
                    return obj[i].innerText;
                }
            }
        }

        function add_cancel_onclick() {
            window.history.go(-1);
        }
        
    </script>
    <div id="addReport">
        <div id="selectitems">
            选择项目：<asp:DropDownList ID="ddl_PrjName" runat="server" Width="240px" ClientIDMode="Static"
                OnSelectedIndexChanged="ddl_PrjName_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div id="newpanel" class="repanel">
            <ul>
                <li class="itemname">项目名称：<asp:Label ID="lbl_Title" runat="server"></asp:Label></li>
                <li class="wordtip">当天工作情况总结：</li>
                <li>
                    <div style="width: 96%; margin: 3px auto;">
                        <textarea id="Daily" name="txta2" style="width: 100%; height: 60px; margin: 3px auto; color:#666; "
                            cols="30" rows="8" runat="server" clientidmode="Static">在这里输入当天工作情况总结</textarea>
                    </div>
                </li>
                <li class="wordtip">需求变更描述：</li>
                <li>
                    <div style="width: 96%; margin: 3px auto;">
                        <textarea id="ChangePaper" cols="30" name="intraduction" rows="8" style="width: 100%;
                            height: 60px; margin: 3px auto;" runat="server" clientidmode="Static">有无需求变更，在这里输入</textarea>
                    </div>
                </li>
                <li class="wordtip">项目关注人：</li>
                <li>
                    <asp:CheckBoxList ID="cbl_Attention" CssClass="chk_list" Width="96%" runat="server"
                        RepeatDirection="Horizontal" RepeatColumns="6" EnableTheming="False" TextAlign="Right">
                    </asp:CheckBoxList>
                </li>
            </ul>
            <div class="sysTips" style="width: 96%">
                <p>
                    TIPS：系统将会以邮件形式通知你选中的关注人，他们将会收到你的日报内容</p>
            </div>
            <div id="Editqq" class="SaveinfoDiv">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btn_Save" runat="server" CssClass="btn2" Text="添加" OnClick="btn_Save_Click"
                    OnClientClick="return add_ok_onclick();" />
            </div>
        </div>
    </div>
</asp:Content>
