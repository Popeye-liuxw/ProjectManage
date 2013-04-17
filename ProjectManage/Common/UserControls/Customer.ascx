<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Customer.ascx.cs" Inherits="ProjectManage.Common.UserControls.Customer" %>
<select id="CustomerSelect" class="selectBox">
        <option value="0">请选择</option>
        <asp:Repeater ID="RepeaterCustomer" runat="server">
                <ItemTemplate>
                        <option value="<%#Eval("SysNo") %>">
                                <%#Eval("CompanyName")%></option>
                </ItemTemplate>
        </asp:Repeater>
</select>