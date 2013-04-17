<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="ProjectManage.Common.UserControls.Users" %>
<select id="UsersSelect" class="selectBox">
        <option value="0">请选择</option>
        <asp:Repeater ID="RepeaterUsers" runat="server">
                <ItemTemplate>
                        <option value="<%#Eval("SysNo") %>">
                                <%#Eval("UserName")%></option>
                </ItemTemplate>
        </asp:Repeater>
</select>