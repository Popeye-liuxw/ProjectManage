<%@ Page Title="成果展示" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectResultShow.aspx.cs" Inherits="ProjectManage.Pages.ProjectBasicinfo.ProjectResultShow" %>
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
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div style=" text-align:center;">该模块还在开发中，敬请期待</div>

<%--<div id="Resultshow">
 <div id= "title"> 项目成果展示标题</div>
 <div id="resultinfo">添加人：*** 添加时间：2012/05/21</div>
 <div id="showcontent">这里时展示内容，类似新闻展示</div>
 <div id="showeditor"><input type="button" name="add_newshow" id="add_newshow" value="修改" style="width:76px;height:24px; font-size: 12px; color:#FFF; cursor:hand;background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF" onclick="return add_newshow_onclick()" /></div>
 </div>--%>

</asp:Content>
