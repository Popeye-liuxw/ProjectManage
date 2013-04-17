<%@ Page Title="项目概况" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="ProjectManage.Pages.ProjectBasicinfo.ProjectDetail" %>
<%@ Register TagPrefix="uc" TagName="Spinner" Src="~/Common/UserControls/ChildMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

<script type="text/javascript">
    $("")
    function add_newshow_onclick() {
        window.location.href = "AddProjectResultShow.aspx";
    }

</script>
<div id="r_topmenu">
     <uc:Spinner id="spn_Menu" runat="server" MenuID="3"  />
</div>
<div class="sysTips" id="tip" runat="server" visible="false">
    <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
</div>
<div id="SingleProjectBasic"> <!-- 项目详细信息展示 -->
    <div id="protit">项目<<asp:Label ID="lbl_ProName" runat="server" Text=""></asp:Label>>详细信息</div>
            <div id="ProDetail">
            <asp:Repeater runat="server" ID="repProDetail">
               <HeaderTemplate> <ul class="ultop"></HeaderTemplate>
               <ItemTemplate>
                    <li><h2 style="">项目编号：<asp:Label ID="Label1" runat="server" Text='<%#Eval("citemcode") %>'>"></asp:Label></h2></li>
                    <li><h2 style="">项目名称：<asp:Label ID="Label3" runat="server" Text='<%#Eval("citemname") %>'></asp:Label></h2></li>
                    <li><h2 style="">项目类型：<asp:Label ID="Label4" runat="server" Text='<%#Eval("PrjTypeName") %>'></asp:Label></h2></li>
                    <li><h2 style="">项目性质：<asp:Label ID="Label5" runat="server" Text='<%#Eval("PrjNatureName") %>'></asp:Label></h2></li>
                    <li><h2 style="">客户名称：<asp:Label ID="Label2" runat="server" Text='<%#Eval("cCusAbbName").ToString()==""?"暂未设置":Eval("cCusAbbName") %>'></asp:Label></h2></li>
               </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
              </asp:Repeater>
                <ul id="perperson">
<%--                        <li>
                           <h2 style="">项目经理：<asp:Label ID="lbl_PM" runat="server" Text=''></asp:Label></h2>
                        </li>--%>
                        <li>
                        <h2 style=""><asp:Label ID="lbl_Responsible" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">研发人员：<asp:Label ID="lbl_Dev" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">测试人员：<asp:Label ID="lbl_Tester" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">商务人员：<asp:Label ID="lbl_Market" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">统计信息：<asp:Label ID="lbl_CounPer" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">创建时间：<asp:Label ID="lbl_CreateTime" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">最后更新：<asp:Label ID="lbl_LastUpdateTime" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li>
                        <h2 style="">更新人员：<asp:Label ID="lbl_UpdatePerson" runat="server" Text=''></asp:Label></h2>
                        </li>
                        <li class="Edite">
                            <asp:Button ID="btn_Edite" runat="server" CssClass="btn2" Text="编辑" onclick="btn_Edite_Click" />
                        </li>
               </ul>
            </div>
    </div>
</asp:Content>
