<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChildMenu.ascx.cs" Inherits="ProjectManage.Common.UserControls.ChildMenu" %>
<asp:Repeater ID="rpt_Menu" runat="server">
    <HeaderTemplate>
        <ul class="r_topmenu_ul">
    </HeaderTemplate>
    <ItemTemplate>
        <li class='<%#Eval("Css") %> '>
        <asp:HyperLink ID="link" runat="server" Text='<%#Eval("ModuleName") %> ' NavigateUrl='<%#Eval("URL") %> '></asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<%--<li class="off"><a href="#"></a></li>
<li class="off"><a href="ProjectDetail.aspx">项目概况</a> </li>
<li class="off"><a href="ProjectResultShow.aspx">成果展示</a> </li>
<li class="on"><a href="DevelopmentBonus.aspx">研发奖金</a> </li>
<li class="off"><a href="#">市场奖金</a> </li>
<li class="off"><a href="#">月报</a> </li>
<li class="off"><a href="AddDailyReport.aspx">日报</a> </li>
<li class="off"><a href="ProjectExternalCosts.aspx">外协费</a> </li>
<li class="off"><a href="#"></a></li>--%>
