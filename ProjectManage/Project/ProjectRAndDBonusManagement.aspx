<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
        CodeBehind="ProjectRAndDBonusManagement.aspx.cs" Inherits="ProjectManage.Pages.ProjectR_DBonus.ProjectRAndDBonusManagement" %>
<%--项目研发奖金--%>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
        <script type="text/javascript">
        </script>
        <div id="ProjectRAndDBonusMain_Div">
                <table id="Prosearch" class="datalist" cellpadding="0" cellspacing="0" border="0"
                        width="90%">
                        <tr>
                                <th colspan="8">
                                        研发奖金管理
                                </th>
                        </tr>
                        <tr align="center">
                                <td class="tfirst">
                                        项目名称：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"
                                                bind="F{filedName: ContractNo}" />
                                </td>
                                <td class="tfirst">
                                        发放对象：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                        发放时间：
                                </td>
                                <td>
                                        <input size="40" name="name" class="inputcalender" id="Text1" onblur="this.className='inputcalender'"
                                                onfocus="this.className='inputcalender-bor'" />
                                </td>
                                <td class="tfirst">
                                </td>
                                <td>
                                </td>
                        </tr>
                        <tr align="center">
                                <td colspan="3">
                                        &nbsp;
                                </td>
                                <td>
                                        <input type="button" name="Submit" value="查  询" class="btn2" id="BtnSearch" />
                                </td>
                                <td>
                                        <input type="button" name="Submit" value="添加奖金" class="btn2" id="btnAdd" />
                                </td>
                                <td colspan="3">
                                </td>
                        </tr>
                </table>
                <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"
                        width="90%">
                        <tr>
                                <th class="thfirst">
                                        项目名称
                                </th>
                                <th>
                                        发放对象
                                </th>
                                <th>
                                        发放时间
                                </th>
                                <th>
                                        编辑
                                </th>
                                <th class="thlast">
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="#">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                </td>
                        </tr>
                </table>
                <div id="pager_top">
                        <div class="pager">
                                <a href="#">&lt; Prev</a><a href="#">1</a><span class="current">2</span><a href="#">3</a><a
                                        href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a><a href="#">8</a><a
                                                href="#">9</a><a href="#">10</a><a href="#">11</a>···<a href="#">18</a><a href="#">Next
                                                        &gt;</a></div>
                </div>
                <p>
                        &nbsp;</p>
        </div>
</asp:Content>
