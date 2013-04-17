<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true"
    CodeBehind="SysProjectUpdate.aspx.cs" Inherits="ProjectManage.Manager.SysProjectUpdate" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <table class="forms" runat="server" visible="false" cellpadding="0" cellspacing="0"
        border="0" width="94%" id="isExistUpdate">
        <tr>
            <th colspan="6" style="height: 24px">
                更新同步T3数据库数据项目信息
            </th>
        </tr>
        <tr>
            <td class="ftfirst" style="width: 600px" colspan="2">
                <asp:Label ID="lbl_updatemsg" runat="server" ForeColor="Red" Text="您有数据需要从T3数据库更新！"></asp:Label>
            </td>
            <td colspan="1">
                <asp:Button ID="btn_Update" CssClass="btn2" runat="server" Text="现在更新" OnClick="btn_Update_Click" />
            </td>
            <td colspan="1">
                <asp:Button ID="btn_Next" CssClass="btn2" runat="server" Text="下次再说" OnClick="btn_Next_Click" />
            </td>
            <td class="ftlast">
            </td>
        </tr>
    </table>
    <asp:Repeater ID="rep_Updateinfo" runat="server">
        <HeaderTemplate>
            <table class="datalist" cellpadding="0" cellspacing="0" border="0" width="94%">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="left">
                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("ProinfoDetail") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rep_SysAllProject" runat="server" OnItemDataBound="rep_SysAllProject_ItemDataBound">
        <HeaderTemplate>
            <table class="datalist" id="userList" cellpadding="0" cellspacing="0" border="0"
                width="94%">
                <tr>
                    <th class="thfirst">
                        &nbsp;
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        项目编号
                    </th>
                    <th>
                        项目名称
                    </th>
                    <th>
                        客户名称
                    </th>
                    <th>
                        项目性质
                    </th>
                    <th>
                        项目类别
                    </th>
                    <th>
                        创建时间
                    </th>
                    <th>
                        项目状态
                    </th>
                    <th class="thlast">
                        相关操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="tfirst">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="lbl_id" runat="server"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("citemcode") %>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("citemname") %>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("cCusAbbName").ToString() ==""?"暂未设置":Eval("cCusAbbName") %>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("PrjNatureName").ToString() ==""?"暂未设置":Eval("PrjNatureName") %>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("PrjTypeName").ToString() ==""?"暂未设置":Eval("PrjTypeName") %>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("CreateTime").ToString()==""?"暂未设置":Eval("CreateTime") %>'></asp:Label>
                </td>
                <td align="center" class="tlast">
                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("bclose").ToString()=="True"?"进行中":"已关闭" %>'></asp:Label>
                </td>
                <td class="tlast" style="width: 200px;" align="center">
                    <img class="iconTips" alt="" src="../images/pencil.png" /><asp:LinkButton ID="Link_Edit"
                        PostBackUrl='<%# "SysProjectEdit.aspx?id=2385&key=" + Eval("ID") %>' CssClass="linkBtn" runat="server">编辑</asp:LinkButton>
      <%--              <img class="iconTips" alt="" src="../images/delsmallpic.png" />
                    <asp:LinkButton ID="Link_Del" PostBackUrl='<%# "SysProjectEdit.aspx?id=2385&uke=dtky&key=" + Eval("ID") %>'
                        CssClass="linkBtn" OnClientClick='return confirm("你确定删除该用户吗！删除后将不可恢复.")' runat="server">删除</asp:LinkButton>--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <webdiyer:AspNetPager ID="ANP" CssClass="paginator" CurrentPageButtonClass="cpb"
        runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
        PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
        CustomInfoTextAlign="Left" LayoutType="Table">
    </webdiyer:AspNetPager>
</asp:Content>
