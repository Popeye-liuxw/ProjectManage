<%@ Page Title="成果展示" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProjectResultShow.aspx.cs" Inherits="ProjectManage.Pages.ProjectBasicinfo.AddProjectResultShow" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    
<script type="text/javascript">
    $("")
    function add_newshow_onclick() {
        window.location.href = "AddProjectResultShow.aspx";
    }

</script>
<div id="r_topmenu">
     <uc:Spinner id="spn_Menu" runat="server" MenuID="4"  />
</div>
<%--<div style=" text-align:center;">该模块还在开发中，敬请期待</div>--%>

<div id="Add_projectShow">
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#Project_main', {
                resizeType: 1,
                cssPath: '../editor/plugins/code/prettify.css',
                uploadJson: '../SaveFile/upload_json.ashx',
                fileManagerJson: '../SaveFile/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=add]')[0].submit();
                    });
                    //	                K.ctrl(self.edit.doc, 13, function () {
                    //	                    self.sync();
                    //	                    K('form[name=add]')[0].submit();
                    //	                });
                }
            });
            prettyPrint();
        });
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[name="intraduction"]', {
                resizeType: 1,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
        });
        function add_ok_onclick() {
            var html = editor.html();
            var html1 = document.getElementById('Project_main').value;

            if (html == "") {
                alert("请填写项目简介！");
                return false;
            }
            if (html1 == "") {
                alert("请填写项目主要信息！");
                return false;
            }
            else
                alert("添加成功！");
        }

        function add_cancel_onclick() {
            window.history.go(-1);
        }

    </script>
        <table id="Dailysearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="8">添加项目成果展示</th></tr>
<tr align="left">
    <td class="" style="width:200px;">选择项目： 读取当前项目名称</td>
    <td>&nbsp;
    </td>
    <td colspan="6"></td>
</tr>
<tr align="center">
    <td colspan="8">项目简介</td>
</tr>
<tr align="center">
    <td colspan="8"><textarea  rows="50" cols="50" id="Project_intr" name="intraduction" style="width:100%;height:96px;margin:3px auto;"></textarea></td>
</tr>
<tr align="center">
    <td colspan="8">填写系统结构、主要界面、硬件外观、主要功能及其性能：</td>
</tr>
<tr align="center">
    <td colspan="8"><textarea  rows="50" cols="50" id="Project_main" name="content" style="width:100%;height:300px;margin:3px auto;"></textarea></td>
</tr>
<tr  align="center">
<td colspan="8">  
<input type="button" name="content" value="添  加" id="add_ok" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;" onclick="return add_ok_onclick()" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" name="content" value="取  消" id="add_cancel" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;" onclick="return add_cancel_onclick()" />
</td></tr>
</table>

</div>
</asp:Content>
