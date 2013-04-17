<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffManage.aspx.cs" Inherits="ProjectManage.StaffManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">
    <!-- 员工管理 -->
<!-- 页面功能：1.查看人员列表 2.修改，删除人员，3.添加-->
<p id="opertitle">用户信息管理</p>
<table id="usersearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="8">员工信息搜索</th></tr>
<tr align="center">
    <td class="tfirst">员工编号：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">员工姓名：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td class="tfirst">所属部门：</td>
    <td> <select name="Protype" class="selectBox" id="Protype">
            <option value="1">请选择部门</option>
	        <option value="1">部门1</option>
	        <option value="2">部门2</option>
	        <option value="3">部门3</option>
	        <option value="4">部门4</option>
	        </select>
    </td>
    <td class="tfirst">用户状态</td>
    <td>
        <select name="ProNature" class="selectBox" id="ProNature">
	        <option value="1">正常</option>
	        <option value="2">已禁用</option>
	        </select>
    </td>
    </tr>
    <tr align="center">
    <script type="text/javascript" src="js/jquery.zxxbox.3.0.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#add_user").click(function () {
            $("#userInfo").zxxbox();    //或者是$.zxxbox($("#login"));
                /*
                *
                一些登录操作
                *
                */
            $("#loginBtn").click(function () {
                /*
                *
                一些登录操作
                *
                */
                alert("添加成功！");
                $.zxxbox.hide();
            });

            $("#cancelBtn").click(function () {
                $.zxxbox.hide();
            });
        });
    });
</script>
    <td colspan="3">&nbsp;</td>
<td><input type="submit" name="Submit" value="查  询" style="width:76px;height:24px; font-size: 12px;color:#FFF; background:#486AAA;cursor:hand; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/> 
</td>
<td><input type="button" name="add_user" id="add_user" value="添加新员工" style="width:76px;height:24px; font-size: 12px; color:#FFF; cursor:hand;background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/> 
</td>
    <td colspan="3"></td>
    </tr>
</table>

<table class="datalist" id="userdatalist" cellpadding="0" cellspacing="0" border="0"  width="90%">
    <tr>
                <th class="thfirst">列头数据</th>
                <th>员工编号</th>
                <th>员工姓名</th>
                <th>所属部门</th>
                <th>编辑</th>
                <th class="thlast">删除</th>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="#">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     </table>
     <!-- 分页 样式-->
    <div id="pager_top">
    <div class="pager"><a href="#">&lt; Prev</a><a href="#">1</a><span class="current">2</span><a href="#">3</a><a href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a><a href="#">8</a><a href="#">9</a><a href="#">10</a><a href="#">11</a>···<a href="#">18</a><a href="#">Next &gt;</a></div>
    </div>
    <!-- 添加用户信息隐藏层 -->
    <div id="userInfo" class="u_info" style="display:none;">
    <table class="tb_userinfo" cellpadding="0" cellspacing="0" border="0" width="90%">
    <tr>
    <th align="center"  colspan="2" style="height:40px">添加新用户</th>
    </tr>
        <tr>
            <td align="center">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
            <td colspan="2"  align="center">
                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />  <span style="color:Red">&nbsp;*</span>(此项为必填项)
            </td>
        </tr>
        <tr>
            <td align="center">部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：</td>
            <td colspan="2"  align="center">
                <select name="departmentname" id="departmentname">
                    <option value="1">总经办</option>
                    <option value="2">软件研发部</option>
                    <option value="3">财务部</option>
                    <option value="4">市场部</option>
                    <option value="5">算法部</option>
                </select><span style="color:Red">&nbsp;&nbsp;*</span>(此项为必填项)
            </td>
        </tr>
        <tr>
            <td align="center">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
            <td align="center">
                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" />  <span style="color:Red">&nbsp;*</span>(此项为必填项)
            </td>
        </tr>
        <tr  >
            <td align="center" colspan="3">
            <input id="loginBtn" type="button" name="Submit" value="添  加" style="width:74px;cursor:hand;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="cancelBtn" type="button" name="Submit" value="取  消" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA;cursor:hand; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/>
            </td>
        </tr>
    </table>
</div>

</asp:Content>
