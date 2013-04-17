<%@ Page Title="项目管理系统-职位权限管理-后台" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" 
    CodeBehind="PermManage.aspx.cs" Inherits="ProjectManage.Manager.PermManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div id="ProjectInfoMain">
        <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"
            width="90%">
            <tr>
                <th class="thfirst">
                    项目编号
                </th>
                <th>
                    项目名称
                </th>
                <th>
                    项目类型
                </th>
                <th>
                    项目性质
                </th>
                <th>
                    应收合同额
                </th>
                <th>
                    应付合同额
                </th>
                <th>
                    签订日期
                </th>
                <th>
                    客户信息
                </th>
                <th>
                    查看详细
                </th>
                <th class="thlast">
                    删除
                </th>
            </tr>
            <tr align="center">
                <td class="tfirst">
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    数据
                </td>
                <td>
                    <a class="editItem" target="_self" href="#">查看详细</a>
                </td>
                <td class="tlast">
                    <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
                </td>
            </tr>
        </table>
        <div id="pager">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"
                        width="90%">
                        <tr>
                            <th class="thfirst">
                                项目编号
                            </th>
                            <th>
                                项目名称
                            </th>
                            <th>
                                项目类型
                            </th>
                            <th>
                                项目性质
                            </th>
                            <th>
                                应收合同额
                            </th>
                            <th>
                                应付合同额
                            </th>
                            <th>
                                签订日期
                            </th>
                            <th>
                                客户信息
                            </th>
                            <th>
                                查看详细
                            </th>
                            <th class="thlast">
                                删除
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr align="center">
                        <td class="tfirst">
                            数据
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </td>
                        <td>
                           <asp:CheckBox ID="CheckBox5" runat="server" />
                            <asp:CheckBox ID="CheckBox6" runat="server" />
                        </td>
                        <td>
                           <asp:CheckBox ID="CheckBox7" runat="server" />
                            <asp:CheckBox ID="CheckBox8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox9" runat="server" />
                            <asp:CheckBox ID="CheckBox10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox11" runat="server" />
                            <asp:CheckBox ID="CheckBox12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox13" runat="server" />
                            <asp:CheckBox ID="CheckBox14" runat="server" />
                        </td>
                        <td>
                            <a class="editItem" target="_self" href="#">查看详细</a>
                        </td>
                        <td class="tlast">
                            <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <p>
            &nbsp;</p>
    </div>
</asp:Content>
