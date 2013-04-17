<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectBasicInfoDetail.ascx.cs"
        Inherits="ProjectManage.ProjectBasicinfo.ProjectBasicInfoDetail" %>
<%@ Register Src="/Common/UserControls/ChooseUsersControl.ascx" TagName="ChooseUsersControl"
        TagPrefix="uc1" %>
<%@ Register Src="../../Common/UserControls/ProjectNature.ascx" TagName="ProjectNature"
        TagPrefix="uc2" %>
<%@ Register Src="../../Common/UserControls/ProjectClass.ascx" TagName="ProjectClass"
        TagPrefix="uc3" %>
<%@ Register Src="../../Common/UserControls/Customer.ascx" TagName="Customer" TagPrefix="uc4" %>
<%@ Register Src="../../Common/UserControls/Users.ascx" TagName="Users" TagPrefix="uc5" %>
<script src="/js/Common/ChooseUsersControl.js" type="text/javascript"></script>
<div id="ProjectDetail_Div" style="display: none; width: 1000px; height: 400px;"
        class="boxy">
        <table id="forms" cellpadding="0" cellspacing="0" border="0" width="90%">
                <tr>
                        <td class="ftfirst" align="right">
                                项目编号：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" id="ContractNumberTextBox"/>
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                项目名称：
                        </td>
                        <td>
                                <input size="40" name="name" class="input1" onblur="this.className='input1'" onfocus="this.className='input1-bor'" id="ProjectNameTextBox"/>
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                项目类型：
                        </td>
                        <td>
                                <uc3:ProjectClass ID="ProjectClass1" runat="server" />
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                项目性质：
                        </td>
                        <td>
                                <uc2:ProjectNature ID="ProjectNature1" runat="server" />
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                客户：
                        </td>
                        <td>
                                <uc4:Customer ID="Customer1" runat="server" />
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                项目经理：
                        </td>
                        <td>
                                <uc5:Users ID="Users1" runat="server" />
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                开发人员：
                        </td>
                        <td>
                                <span style="width: 900px; height: 400px; cursor: pointer;" id="chooseUserSpan_DevelopEngineer">
                                        点击选择用户</span> <span style="display: none;" id="chooseUserIDSpan_DevelopEngineer">
                                </span>
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                                测试人员：
                        </td>
                        <td>
                                <span style="width: 900px; height: 400px; cursor: pointer;" id="chooseUserSpan_TestEngineer">
                                        点击选择用户</span> <span style="display: none;" id="chooseUserIDSpan_TestEngineer">
                                </span>
                        </td>
                        <td class="ftlast" align="left">
                                (此项为必填项)
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right">
                                商务人员：
                        </td>
                        <td>
                                <span style="width: 900px; height: 400px; cursor: pointer;" id="chooseUserSpan_BusinessEngineer">
                                        点击选择用户</span> <span style="display: none;" id="chooseUserIDSpan_BusinessEngineer">
                                </span>
                        </td>
                        <td align="left">
                                (此项为必填项)
                        </td>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                        <td class="ftlast" align="left">
                        </td>
                </tr>
                <tr>
                        <td class="ftfirst" align="right" colspan="6">
                                <input type="button" name="Submit" value="保存" style="width: 60px; height: 24px; font-size: 12px;
                                        background: #86A9D2; border-width: thin thin thin thin; border-color: #CCCCFF #CCCCCC #CCCCCC #CCCCFF"
                                        id="BtnSave" />
                        </td>
                </tr>
        </table>
        <uc1:ChooseUsersControl ID="ChooseUsersControl1" runat="server" />
</div>
