<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true"
    CodeBehind="SysConfigManage.aspx.cs" Inherits="ProjectManage.Manager.SysConfigManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="emailList">
        <div class="sysTips">
            <p> TIPS：系统邮件服务器配置，可以配置多个发信邮箱。</p>
        </div>
        <asp:GridView ID="gv_List" CssClass="datalist" AutoGenerateColumns="false" runat="server"
            Width="94%" GridLines="None" BorderStyle="None" EnableModelValidation="False"
            EnableTheming="False" OnRowDataBound="gv_List_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序号">
                    <HeaderStyle CssClass="thfirst" />
                    <ItemStyle CssClass="tfirst" />
                </asp:BoundField>
                <asp:BoundField DataField="EmailName" HeaderText="配置名称"></asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="邮箱名称" />
                <asp:BoundField DataField="Port" HeaderText="端口号" />
                <asp:BoundField DataField="SMTPHost" HeaderText="SMTP地址" />
                <asp:BoundField DataField="DisplayName" HeaderText="发件人" />
                <asp:BoundField DataField="State" HeaderText="状态" />
                <asp:BoundField DataField="CreateTime" HeaderText="创建时间" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <img class="iconTips" alt="" src="../images/edit.png" />
                        <asp:LinkButton ID="btn_Edit" runat="server" CssClass="linkBtn" CommandArgument='<%#Eval("ID") %>'
                            Text="编辑" OnClick="btn_Edit_Click"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="thlast" />
                    <ItemStyle CssClass="tlast" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div id="SaveUserInfo" class="SaveinfoDiv">
            <asp:Label CssClass="lbl_msgOK" ID="lbl_msg" runat="server" Text=""></asp:Label>
            <asp:Button ID="btn_Add" runat="server" CssClass="btn2" Text="添 加" OnClick="btn_Add_Click" />
            &nbsp;&nbsp;
        </div>
    </div>
</asp:Content>
