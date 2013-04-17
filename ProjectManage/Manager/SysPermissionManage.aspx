<%@ Page Title="项目管理系统-权限管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="SysPermissionManage.aspx.cs" Inherits="ProjectManage.Manager.SysPermissionManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="pager">
        <asp:GridView ID="gv_List" CssClass="datalist" AutoGenerateColumns="False" runat="server"
            OnRowDataBound="gv_List_RowDataBound" Width="94%" GridLines="None" BorderStyle="None" EnableModelValidation="False" EnableTheming="False"
            onselectedindexchanging="gv_List_SelectedIndexChanging" > 
            <Columns>
                <asp:BoundField HeaderText="序号" >
                    <HeaderStyle CssClass="thfirst" />
                    <ItemStyle CssClass="tfirst" />
                </asp:BoundField>
                <asp:BoundField DataField="PosiName" HeaderText="职位名称"></asp:BoundField>
                <asp:BoundField DataField="Back" HeaderText="职位编号" ></asp:BoundField>
                <asp:BoundField DataField="CreateTime" HeaderText="创建时间"></asp:BoundField>
                <asp:BoundField HeaderText="状态" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                    <img alt="" class="iconTips" src="../images/setperm.png" />
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" Text="设定权限"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle CssClass="linkBtn" />
                    <HeaderStyle CssClass="thlast" />
                    <ItemStyle CssClass="tlast" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
