<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectExternalCosts.aspx.cs" Inherits="ProjectManage.ProjectExternalCosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

    <table id="ExternalCostssearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="10">项目外协费信息查询</th></tr>
<tr align="center">
    <td class="tfirst">项目名称：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td>项目编号：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td >时间自：</td>
    <td>
     <input size="30" type="text" id="ExternalCostsstart" class="inputcalender" onblur="this.className='inputcalender'"
                    onfocus="this.className='inputcalender-bor'" />
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(function () {
                            $("#ExternalCostsstart").datepicker();
                        });
                    });
                </script>
    </td>
    <td>到：</td>
    <td>
        <input size="30" type="text" id="ExternalCostsend" class="inputcalender" onblur="this.className='inputcalender'"
                    onfocus="this.className='inputcalender-bor'" />
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(function () {
                            $("#ExternalCostsend").datepicker();
                        });
                    });
                </script>
    </td>
    <td>
            <input type="submit" name="Submit" value="查  询" style="width:76px;height:24px; font-size: 12px;color:#FFF; background:#486AAA;cursor:hand; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/> 
    </td>
    <td class="tlast"> 
    <script type="text/javascript" src="js/jquery.zxxbox.3.0.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#add_newExternal").click(function () {
                $("#ExternalCostsAdd").zxxbox();    //或者是$.zxxbox($("#login"));
                $("#add_Exter_Btn").click(function () {
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
               // location.href = "AddProjectShow.aspx";
            });
        });
    </script>
            <input type="button" name="add_newExternal" id="add_newExternal" value="添加新展示" style="width:76px;height:24px; font-size: 12px; color:#FFF; cursor:hand;background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"/>
     </td>
    </tr>
</table>
<!-- 项目外协费添加隐藏层 -->
<div id="ExternalCostsAdd" class="ExternalCosts" style="display:none">
    <table id = "addexternalcostsinfo" class="tb_ExternalCosts">
    <tr>
    <th colspan="2">项目外协费记录添加</th>
    </tr>
    <tr>
    <td>外协项目：</td>
    <td><select name="ProName" class="selectBox" id="ProName">
            <option value="0">请选择项目</option>
	        <option value="1">项目1</option>
	        <option value="2">项目2</option>
	        <option value="3">项目3</option>
	        <option value="4">项目4</option>
	        </select>
    </td>
    </tr>
    <tr>
        <td>外协人员/单位：
        </td>
        <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/>
        </td>
    </tr>
    <tr>
        <td>外协金额：
        </td>
        <td><input size="40" name="pric" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/>
        </td>
    </tr>
    <tr>
    <td colspan="2">外协事由：</td>
      </tr>
    <tr>
        <td colspan="2">
        <textarea class="smallArea" style="width:98%; margin:1px auto;" cols="40" name="txta" rows="6"></textarea>
        </td>
    </tr>
    <tr align="center">
        <td colspan="2">
                    <input id="add_Exter_Btn" type="button" name="Submit" value="添  加" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="cancelBtn" type="button" name="Submit" value="取  消" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/>
        </td>
    </tr>
    </table>
    </div>

    <!-- 查询数据列表 -->
<table class="datalist" id="ExternalCostslist" cellpadding="0" cellspacing="0" border="0"  width="90%">
    <tr>
                <th class="thfirst">外协费编号</th>
                <th>项目名称</th>
                <th>外协费事由</th>
                <th>外协人员/单位</th>
                <th>外协金额</th>
                <th class="thlast">删除</th>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
     <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
    <tr align="center">
    <td class="tfirst">数据</td>
    <td>数据</td>
    <td>数据</td>
    <td>数据</td>
    <td><a class="editItem" target="_self" href="AddProjectShow.aspx">编辑</a></td>
    <td class="tlast"><a class="delete" onclick='return confirm("确定删除乎？")'>删除</a></td>
    </tr>
     </table>
<div id="pager_top">
    <div class="pager"><a href="#">&lt; Prev</a><a href="#">1</a><span class="current">2</span><a href="#">3</a><a href="#">4</a><a href="#">5</a><a href="#">6</a><a href="#">7</a><a href="#">8</a><a href="#">9</a><a href="#">10</a><a href="#">11</a>···<a href="#">18</a><a href="#">Next &gt;</a></div>
    </div>
    
</asp:Content>
