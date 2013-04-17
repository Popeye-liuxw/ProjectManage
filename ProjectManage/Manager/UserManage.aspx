<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="ProjectManage.Manager.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
   <table class="forms" runat="server" visible ="false" cellpadding="0" 
        cellspacing="0" border="0" width="94%" id="isExistUpdate">
    <tr>
        <th colspan="6" style="height: 24px">更新同步T3数据库数据用户信息</th>
    </tr>
        <tr>
        <td class="ftfirst" style="width:600px" colspan="2">
            <asp:Label ID="lbl_updatemsg" runat="server" ForeColor="Red" Text="您有数据需要从T3数据库更新！"></asp:Label></td>
        <td colspan="1"><asp:Button ID="btn_Update" CssClass="btn2" runat="server" Text="现在更新" onclick="btn_Update_Click" /></td>
        <td colspan="1"><asp:Button ID="btn_Next" CssClass="btn2" runat="server" Text="下次再说" onclick="btn_Next_Click" /></td>
        <td class ="ftlast"></td>
        </tr>
    </table>
     <asp:Repeater ID="rep_Updateinfo" runat="server">
     <HeaderTemplate><table class="datalist" cellpadding="0"  cellspacing="0" border="0" width="94%">     
     </HeaderTemplate>
        <ItemTemplate><tr><td></td><td style="text-align:left" colspan = "4" class="tipsUpdatesysUser"><asp:Label runat="server" Text='<%#Eval("infoDetail") %>'></asp:Label></td><td></td></tr></ItemTemplate>
     <FooterTemplate></table></FooterTemplate>
     </asp:Repeater>
     <!-- 搜索框 -->
     <table id="search" class="datalist" cellpadding="0" cellspacing="0" border="0" width="94%">
     <tr>
        <th class="thfirst"></th><th colspan="4">用户信息搜索</th><th class="thlast"></th>
     </tr>
     <tr>
        <td class="tfirst"></td><td>用户名：</td>
        <td>
            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
        </td>
        <td>
            姓名：
        </td>
        <td><asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
        </td>
        <td class="tlast"></td>
     </tr>
       <tr>
        <td class="tfirst"></td><td>部门：</td>
        <td>
            <asp:DropDownList  CssClass="selectBox" ID="ddl_department" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            电邮：
        </td>
        <td><asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
        </td>
        <td class="tlast"></td>
     </tr>
     <tr>
     <td class="tfirst"></td>
        <td colspan="3"></td>
        <td >            
         <asp:Button ID="btn_Search" runat="server" Text="搜索" 
                CssClass="btn2" onclick="btn_Search_Click" />
        </td>
     <td class="tlast">
     <asp:LinkButton ID="Link_AddUser" PostBackUrl="SysUserAdd.aspx?id=6F9619FF-8B86-D011-B42D-00C04FC964FF" CssClass="linkBtn" runat="server">[添加人员]</asp:LinkButton>        
     </td>
     </tr>
     </table>
     <!-- 搜索框结束 -->
    <asp:Repeater ID="rep_SysUser" runat="server" 
        onitemcommand="rep_SysUser_ItemCommand" 
        onitemdatabound="rep_SysUser_ItemDataBound">
    <HeaderTemplate>
    <table class="datalist" id="userList" cellpadding="0"  cellspacing="0" border="0" width="94%">  
     <tr>
                                <th class="thfirst">&nbsp;</th>
<%--                                <th>ID</th>--%>
                                <th>员工编号</th>
                                <th>用户名称</th>
                                <th>真实姓名</th>
                                <th>职务</th>
                                <th>部门名称</th>
                                <th>出生日期</th>
                                <th>电子邮箱</th>
                                <th>手机号码</th>
                                <th>联系电话</th>
                                <th class="thlast">相关操作</th>
                        </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td class="tfirst">&nbsp;</td>
<%--    <td align="center"><asp:Label ID="lbl_id" runat="server"></asp:Label></td>--%>
    <td align="center"><asp:Label ID="Label1" runat="server" Text='<%#Eval("employeeID") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label2" runat="server" Text='<%#Eval("userName") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label3" runat="server" Text='<%#Eval("realName") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label4" runat="server" Text='<%#Eval("personProp") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label5" runat="server" Text='<%#Eval("cDepName") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label6" runat="server" Text='<%#Eval("birthday") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label7" runat="server" Text='<%#Eval("email").ToString()==""?"暂未设置":Eval("email") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label8" runat="server" Text='<%#Eval("phoneNum").ToString()==""?"暂未设置":Eval("phoneNum") %>'></asp:Label></td>
    <td align="center"><asp:Label ID="Label9" runat="server" Text='<%#Eval("tel").ToString()==""?"暂未设置":Eval("tel")  %>'></asp:Label></td>
    <td class="tlast" style="width:200px;" align="center">
        <img class="iconTips" alt="" src="../images/pencil.png" /><asp:LinkButton ID="Link_EditUser" PostBackUrl='<%# "SysUserEdit.aspx?id=" + Eval("iD") %>' CssClass="linkBtn" runat="server">[编辑]</asp:LinkButton>
        <img class="iconTips" alt="" src="../images/delsmallpic.png" /><asp:LinkButton ID="Link_Del" CssClass="linkBtn" OnClientClick='return confirm("你确定删除该用户吗！删除后将不可恢复.")' runat="server">[删除]</asp:LinkButton>
    </td>
    </tr>
    </ItemTemplate>
    <FooterTemplate></table>
    
    </FooterTemplate>
    </asp:Repeater><webdiyer:AspNetPager ID="ANP" CssClass="paginator"   
        CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" 
        PrevPageText="上一页"  ShowCustomInfoSection="Left" 
        onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left" 
        LayoutType="Table"  >
</webdiyer:AspNetPager>
</asp:Content>
