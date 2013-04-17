<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="dafault.aspx.cs" Inherits="ProjectManage.Manager.dafault" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

   <!-- 修改密码 添加用户 -->
   <table class="datalist" id="UserInfo" runat="server"  cellpadding="0" 
        cellspacing="0" border="0" width="94%">
   <tr><th class="thfirst"></th><th colspan="4">管理员信息</th><th class="thlast"></th></tr>
   <tr>
    <td class="tfirst"></td>
        <td>用户名：</td><td><asp:Label ID="lbl_ManName" runat="server" Text="Label"></asp:Label></td>
        <td>真实姓名：</td><td><asp:Label ID="lbl_RealName" runat="server" Text="Label"></asp:Label></td>
    <td class="tlast"></td>
   </tr>
   <tr>
        <td class="tfirst"></td>
        <td>电子邮箱：</td><td><asp:Label ID="lbl_Email" runat="server" Text="Label"></asp:Label></td>
        <td>手机号码：</td><td><asp:Label ID="lbl_Tel" runat="server" Text="Label"></asp:Label></td>
        <td class="tlast"></td>
    </tr>
   <tr>
   <td class="tfirst"></td>
   <td colspan="2"> <asp:Button ID="btn_UpdateInfo" runat="server" CssClass="btn2" Text="修改信息" onclick="btn_UpdateInfo_Click" /> </td>
   <td colspan="2"> <asp:Button ID="btn_AddManager" runat="server" CssClass="btn2" Text="增加管理" onclick="btn_AddSingleManager_Click" />  </td>
   <td class="tlast"></td>
   </tr>
   </table>
   <div runat="server" id="updateTips" visible="false" class="sysTips" style="width:94%"><p>TIPS：用户名，不支持修改，密码如果不做更改，留空即可，带*为必填项！</p></div>
    <table class="datalist" id="tab_updateTab" runat="server" visible="false" cellpadding="0" 
        cellspacing="0" border="0" width="94%">
   <tr><th class="thfirst"></th><th colspan="6">修改管理员<asp:Label ID="lbl_userName" runat="server" Text=""></asp:Label>信息</th><th class="thlast"></th></tr>
   <tr>
    <td class="tfirst"></td>
        <td>真实姓名：</td><td style="width:210px;"><asp:TextBox  ID="txt_RealName" runat="server"></asp:TextBox></td><td>
            <asp:Label ID="lbl_msg_Name" runat="server" Text="(*)"></asp:Label></td>
        <td>电子邮箱：</td><td style="width:210px;"><asp:TextBox ID="txt_Email" runat="server"></asp:TextBox></td><td>
            <asp:Label ID="lbl_msg_Email" runat="server" Text="(*)"></asp:Label></td>
    <td class="tlast"></td>
   </tr>
   <tr>
        <td class="tfirst" style="height: 18px"></td>
        <td style="height: 18px">手机号码：</td><td  style="width:210px;">
            <asp:TextBox ID="txt_telNumber" runat="server"></asp:TextBox></td><td>
                <asp:Label ID="lbl_msg_telNum" runat="server" Text="(*)"></asp:Label></td>
        <td style="height: 18px">登录密码：</td><td style="width:210px;"><asp:TextBox ID="txt_LoginPass" runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lbl_msg_pwd" runat="server" Text="-"></asp:Label></td>
        <td class="tlast" style="height: 18px"></td>
    </tr>
   <tr>
   <td class="tfirst"></td>
   <td colspan="3"> 
       <asp:Button ID="btn_SaveInfo" runat="server" CssClass="btn2" 
           Text="保存" onclick="btn_SaveInfo_Click" /> </td>
   <td colspan="3"> 
       <asp:Button ID="btn_cancel" runat="server" CssClass="btn2" 
           Text="返回" onclick="btn_cancel_Click"/>  </td>
   <td class="tlast"></td>
   </tr>
   </table>
   <asp:Repeater runat="server" ID="Rep_UserLogsList">
   <HeaderTemplate>
   <table class="datalist" id="managerLog" cellpadding="0" 
        cellspacing="0" border="0" width="94%">
   <tr>
    <th class="thfirst"></th>
    <th colspan="3">用户登录日志信息</th>
    <th class="thlast"></th>
   </tr>
   </HeaderTemplate>
   <ItemTemplate>
   <tr>
    <td class="tfirst" style="width:20px;"></td>
    <td colspan="2" style="text-align:left">ID:<%#Eval("ID") %>,用户名:<%#Eval("UserName") %>,本次登录IP:<%#Eval("TheIP")%>,操作系统:<%#Eval("IOS") %>,浏览器：<%#Eval("Browser")%>,内容：<%#Eval("Operate")%></td>
    <td>时间：<%#Eval("CreateTime") %></td>
    <td class="tlast"></td>
   </tr>
   </ItemTemplate>
   <FooterTemplate>
   </table>
   </FooterTemplate>
   </asp:Repeater>
   <webdiyer:AspNetPager ID="ANP" CssClass="paginator"   
        CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" 
        PrevPageText="上一页"  ShowCustomInfoSection="Left" 
        onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left" 
        LayoutType="Table"  >
</webdiyer:AspNetPager>
</asp:Content>
