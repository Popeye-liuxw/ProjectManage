<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ProjectManage.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <table id="Prosearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="8">搜索</th></tr>
<tr align="center">
    <td class="tfirst">项目编号：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">项目名称：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">项目类型：</td>
    <td> <select name="Protype" class="selectBox" id="Protype">
	        <option value="1">类型1</option>
	        <option value="2">类型2</option>
	        <option value="3">类型3</option>
	        <option value="4">类型4</option>
	        </select>
    </td>
    <td class="tfirst">项目性质</td>
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
    <td class="tfirst">合同额：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">签订时间：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">客户：</td>
    <td> <select name="ProCustomer" class="selectBox" id="Customer">
	        <option value="1">客户1</option>
	        <option value="2">客户2</option>
	        <option value="3">客户3</option>
	        <option value="4">客户4</option>
	        </select>
    </td>
    <td class="tfirst">项目经理</td>
    <td>
        <select name="Manager" class="selectBox" id="Manager">
	        <option value="1">经理1</option>
	        <option value="2">经理2</option>
	        <option value="3">经理3</option>
	        <option value="4">经理4</option>
	        </select>
    </td>
    </tr>
    <tr align="center">
    <td colspan="3">&nbsp;</td>
    <td><input type="submit" name="Submit" value="查  询" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
</td>
<td><input type="submit" name="Submit" value="添加项目" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> 
</td>
    <td colspan="3"></td>
    </tr>
</table>
 <table class="datalist" id="ProjectList" cellpadding="0" cellspacing="0" border="0"  width="90%">



    <tr>
                <th class="thfirst">列头数据</th>
                <th>列头数据</th>
                <th>列头数据</th>
                <th>列头数据</th>
                <th>编辑</th>
                <th class="thlast">删除</th>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="Form.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     </table>
     <div id="pager_top">
    <div class="pager"><a href="#">&lt; Prev</a><a href="#">1</a><span class="current">2</span><a href="#">3</a><a href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a><a href="#">8</a><a href="#">9</a><a href="#">10</a><a href="#">11</a>···<a href="#">18</a><a href="#">Next &gt;</a></div>
    </div>
<p>
</p>
</asp:Content>



