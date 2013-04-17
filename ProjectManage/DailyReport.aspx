<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyReport.aspx.cs" Inherits="ProjectManage.DailyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right_main" runat="server">

 <table id="Dailysearch" class="datalist"  cellpadding="0" cellspacing="0" border="0"  width="90%">
<tr> <th colspan="8">日报搜索</th></tr>
<tr align="center">
    <td class="tfirst">开始日期：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td>结束日期：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td>项目名称：</td>
    <td><input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'"/></td>
    <td><input type="submit" name="Submit" value="查  询" style="width:74px;height:24px; font-size: 12px;  color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> </td>
    <td class="flast"><input id="addDailyReport" type="button" name="Submit" value="添加日报" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/> </td>
</tr>
</table>
<!-- 弹出层JS操作 -->
<script type="text/javascript" src="js/jquery.zxxbox.3.0.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#addDailyReport").click(function () {
            $("#reportInfo").zxxbox();    //或者是$.zxxbox($("#login"));
            $("#add_daily_Btn").click(function () {
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
<!-- 添加日报隐藏DIV -->
   <div id="reportInfo" class="report_info" style="display:none;">
    <table class="report" id="tb_report" cellpadding="0" cellspacing="0" border="0" width="90%">
    <tr>
    <th align="center"  colspan="4" style="height:40px">日报添加</th>
    </tr>
        <tr>
            <td align="center">选择项目：</td>
            <td align="center"> <select name="departmentname" id="report_select" style="width:140px;">
                    <option value="1">项目1</option>
                    <option value="2">项目2</option>
                    <option value="3">项目3</option>
                    <option value="4">项目4</option>
                    <option value="5">项目5</option>
                </select><span style="color:Red">&nbsp;&nbsp;*</span>(此项为必填项)
             </td>
             <td align="center">当前时间：</td>
             <td align="center">2012/05/15</td>
        </tr>
        <tr>
            <td align="left" colspan="4">今天的工作内容总结，如技术方面的：</td>
            </tr>
         <tr>
            <td align="center" colspan="4"><textarea class="smallArea" style="width:98%; margin:1px auto;" cols="30" name="txta" rows="8"></textarea> </td>
         </tr>
               <tr>
            <td align="left" colspan="4">客户有什么问题吗，写写：</td>
            </tr>
         <tr>
            <td align="center" colspan="4"><textarea class="smallArea" style="width:98%; margin:1px auto;" cols="30" name="txta" rows="8"></textarea> </td>
         </tr>
        <tr  >
            <td align="center" colspan="4">
            <input id="add_daily_Btn" type="button" name="Submit" value="添  加" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="cancelBtn" type="button" name="Submit" value="取  消" style="width:74px;height:24px; font-size: 12px; color:#FFF; background:#486AAA; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF;cursor:hand;"/>
            </td>
        </tr>
    </table>
</div>
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


    <!-- 隐藏层 -->

  

</asp:Content>
