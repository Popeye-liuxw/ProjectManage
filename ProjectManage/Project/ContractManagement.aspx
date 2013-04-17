<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
        CodeBehind="ContractManagement.aspx.cs" Inherits="ProjectManage.ContractManagement" %>
<%--合同管理--%>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <div class="sysTips" id="tip" runat="server" visible="false">
        <p><asp:Label ID="lbl_Tip" runat="server" Text="系统提示"></asp:Label></p>
    </div>
    <div style=" text-align:center;">该模块还在开发中，敬请期待</div>

<%--        <script src="/js/Contract/ContractListView.js" type="text/javascript"></script>
        <script type="text/javascript">
                $(function () {
                        var contractListView = new ContractListView($("#ContractMain_Div"));
                })
        </script>
        <script language="javascript" type="text/javascript" src="/js/My97DatePicker/WdatePicker.js"></script>
        <div id="ContractMain_Div">
                <table id="Prosearch" class="datalist" cellpadding="0" cellspacing="0" border="0"
                        width="90%">
                        <tr>
                                <th colspan="8">
                                        合同管理
                                </th>
                        </tr>
                        <tr align="center">
                                <td class="tfirst">
                                        (合同)项目编号：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"
                                                bind="F{filedName: ContractNo}" />
                                </td>
                                <td class="tfirst">
                                        项目名称：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                        项目类型：
                                </td>
                                <td>
                                        <select name="Protype" class="selectBox" id="Protype">
                                                <option value="1">类型1</option>
                                                <option value="2">类型2</option>
                                                <option value="3">类型3</option>
                                                <option value="4">类型4</option>
                                        </select>
                                </td>
                                <td class="tfirst">
                                        项目性质
                                </td>
                                <td>
                                        <select name="ProNature" class="selectBox" id="ProNature">
                                                <option value="1">性质1</option>
                                                <option value="2">性质2</option>
                                                <option value="3">性质3</option>
                                                <option value="4">性质4</option>
                                        </select>
                                </td>
                        </tr>
                        <tr align="center">
                                <td class="tfirst">
                                        合同类型：
                                </td>
                                <td>
                                        <select name="ProNature" class="selectBox" id="Select1">
                                                <option value="1">性质1</option>
                                                <option value="2">性质2</option>
                                                <option value="3">性质3</option>
                                                <option value="4">性质4</option>
                                        </select>
                                </td>
                                <td class="tfirst">
                                        合同应付额度：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                        合同应收额度：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                        签订时间
                                </td>
                                <td>
                                        <input size="40" name="name" class="inputcalender" id="datepicker" onblur="this.className='inputcalender'"
                                                onfocus="this.className='inputcalender-bor'" onclick="WdatePicker()"/>
                                </td>
                        </tr>
                        <tr align="center">
                                <td class="tfirst">
                                        客户信息：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                        存档数量：
                                </td>
                                <td>
                                        <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />
                                </td>
                                <td class="tfirst">
                                </td>
                                <td>
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
                                        <input type="button" name="Submit" value="查  询" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;" />
                                </td>
                                <td>
                                        <input type="button" name="button" value="添加合同" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;" id="btnAdd" />
                                </td>
                                <td colspan="3">
                                </td>
                        </tr>
                </table>
                <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"
                        width="90%">
                        <tr>
                                <th class="thfirst">
                                        合同（项目编号）
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
                                        合同类型
                                </th>
                                <th>
                                        合同应付总额
                                </th>
                                <th>
                                        合同应收总额
                                </th>
                                <th>
                                        客户信息
                                </th>
                                <th>
                                        存档数量
                                </th>
                                <th>
                                        编辑
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
                                        数据
                                </td>
                                <td>
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
                                        <a class="editItem" target="_self" href="Form.aspx">编辑</a>
                                </td>
                                <td class="tlast">
                                        <a class="delete" onclick='return confirm("确定删除乎？")'>删除</a>
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
        </div>--%>
</asp:Content>
