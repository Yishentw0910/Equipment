<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5001.aspx.cs" Inherits="FrmML5001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>
        -<%=this.GSTR_PROGNM%></title>
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />

    <script language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>

    <script type="text/javascript">
    <!-- #Include file='js/ML5001.js' -->                   
    </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
                <div class="divBody">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="700">
                        <tr>
                            <td width="40%" align="right" class="ProgID_Title1">
                                <br />
                                <%=this.GSTR_A_PRGID%>
                                &nbsp; &nbsp;
                            </td>
                            <td width="60%" align="left" class="ProgID_Title2">
                                <br />
                                <%=this.GSTR_PROGNM%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <div class="div_Info">
                        <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
                            <tr>
                                <th class="align_right" width="25%">
                                    公司別：
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpCompID" runat="server" Width="25%">
                                        <asp:ListItem Value="">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
							<%--20120531 MODIFY BY SSF MAUREEN REASON:新增回件狀態查詢欄位--%>
                            <tr>
                                <th class="align_right" width="25%">
                                    回件狀態：
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpCaseStatus" runat="server" Width="25%">
                                        <asp:ListItem Value="">請選擇</asp:ListItem>
                                        <asp:ListItem Value="Y">已回件</asp:ListItem>
                                        <asp:ListItem Value="N">未回件</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <%--UPD BY VICKY 20140220 新增[傳遞狀態]--%>
                                <th class="align_right" width="25%">
                                    傳遞狀態：
                                </th>
                                <td width="25%">
                                    <asp:DropDownList ID="drpTransStatus" runat="server" Width="78%">
                                        <asp:ListItem Value="N">未傳遞</asp:ListItem>
                                        <asp:ListItem Value="Y">已傳遞</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th width="20%">
                                    傳遞日起迄：
                                </th>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtTRANSDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="40%"></asp:TextBox>～<asp:TextBox
                                            ID="txtTRANSDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                            onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="40%"></asp:TextBox>
                                </td>
                            </tr>
                            <%--UPD BY VICKY 20140220 調整TABLE,將隱藏的TD,獨立出來,放入隱藏TR中--%>
                            <tr style="display: none;">
                                <th style="display: none;" class="align_right" width="25%">
                                    業代名：
                                </th>
                                <td style="display: none;" width="25%">
                                    <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                    <input type="button" id="Button6" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
                                        padding: 2px;" value="&#8230;" />
                                </td>
                                <th style="display: none;" class="align_right" width="25%">
                                    &nbsp; 案件核准日：
                                </th>
                                <td style="display: none;" width="25%">
                                    &nbsp;
                                    <asp:TextBox ID="txtCASEDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    合約編號：
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" MaxLength="14"
                                        CssClass="txt_normal" Width="30%"></asp:TextBox>
                                </td>
                            </tr>
                            <%--UPD BY VICKY 20140220 調整TABLE,將隱藏的TD,獨立出來,放入隱藏TR中--%>
                            <tr style="display: none;">
                                <th style="display: none;" class="align_right" width="25%">
                                    &nbsp; 起租日：
                                </th>
                                <td style="display: none;" width="25%">
                                    &nbsp;
                                    <asp:TextBox ID="txtRENTSTDT" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    財務撥款確認日起迄：
                                </th>
                                <td style="text-align: left;" colspan="3">
                                    <asp:TextBox ID="txtCNTRNODATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>～<asp:TextBox
                                            ID="txtCNTRNODATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                            onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    客戶統編：
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
                                        runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                                    <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                                    <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
                                        padding: 2px;" value="&#8230;" />
                                </td>
                            </tr>
                            <tr>
                                <th colspan="4" style="text-align: center; height: 30px;">
                                    <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="cmdQuery_Click" />
                                    <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
                                        value="清除" />
                                    <%--UPD BY VICKY 20140220 新增[列印回件簽收單]--%>
                                    <asp:Button ID="cmdPRINT" runat="server" Text="列印回件簽收單" CssClass="btn_normal" Width="110"
                                         Enabled="false" OnClick="cmdPRINT_OnClick"/>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
                        <table id="tblMLDCASEAPPENDDOC" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px; width: 1200px;">
                            <tr>
                                <th style="width: 7%;">
                                    <!--ADD BY VICKY 20140221 新增欄位 -->
                                    傳遞日確認
                                </th>
                                <th style="width: 6%;">
                                    <!--ADD BY VICKY 20140221 新增欄位 -->
                                    傳遞日期
                                </th>
                                <th style="width: 5%;">
                                    展開
                                </th>
                                <th style="width: 10%;">
                                    合約編號
                                </th>
                                <th style="width: 17%;">
                                    客戶名稱
                                </th>
                                <th style="width: 10%;">
                                    部門
                                </th>
                                <th style="width: 6%;">
                                    業代
                                </th>
                                <th style="width: 8%;">
                                    承作類型
                                </th>
                                <th style="display: none;">
                                    交易型態
                                </th>
                                <th style="width: 6%;">
                                    承作金額
                                </th>
                                <th style="width: 4%;">
                                    期數
                                </th>
                                <th style="display: none;">
                                    IRR
                                </th>
                                <th style="display: none;">
                                    月付租金
                                </th>
                                <th style="display: none;">
                                    起租日
                                </th>
                                <th style="display: none;">
                                    迄租日
                                </th>
                                <th style="width: 7%;">
                                    撥款確認日
                                </th>
                                <th style="width: 7%;">
                                    未回件天數
                                </th>
                                <th style="display: none;">
                                    <!--ADD BY VICKY 20140221 儲存主檔需用到的KEY值 -->
                                    回件資料代碼
                                </th>
                            </tr>
                            <asp:Repeater ID="rptData" runat="server">
                                <ItemTemplate>
                                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                                        onclick="MouseDown(event);">
                                        <td>
                                            <!--ADD BY VICKY 20140221 新增欄位 -->
                                            <asp:CheckBox ID="chkcheckDate" runat="server" onClick="TRANSCONFIRMClick(this,'chkcheckDate','lblTRANSDATE')" />
                                        </td>
                                        <td>
                                            <!--ADD BY VICKY 20140221 新增欄位 -->
                                            <asp:Label ID="lblTRANSDATE" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("TRANSDATE").ToString()) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID"),Eval("CASESTATUS")) %>'
                                                runat="server" Text="明細" />
                                        </td>
                                        <td>
                                            <%--<%#Eval("CNTRNO")%>--%>
                                            <!--ADD BY VICKY 20140317 要串出以便列印 -->
                                            <asp:Label ID="lblCNTRNO" runat="server" Text='<%#Eval("CNTRNO")%>'></asp:Label>
                                            
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("CUSTNAME")%>
                                            <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                                                ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <%#Eval("DEPT")%>
                                        </td>
                                        <td>
                                            <%#Eval("EMPLNM")%>
                                        </td>
                                        <td>
                                            <%#Eval("MAINTYPENM")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("TRANSTYPENM")%>
                                        </td>
                                        <td style="text-align: right;">
                                            <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
                                        </td>
                                        <td>
                                            <%#Eval("CONTRACTMONTH")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("IRR")%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
                                        </td>
                                        <td>
                                            <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="display: none;">
                                            <!--ADD BY VICKY 20140221 儲存主檔需用到的KEY值 -->
                                            <asp:Label ID="lblRETUNID" runat="server" Text='<%#Eval("RETUNID")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                                        onclick="MouseDown(event);">
                                        <td>
                                            <!--ADD BY VICKY 20140221 新增欄位 -->
                                            <asp:CheckBox ID="chkcheckDate" runat="server" onClick="TRANSCONFIRMClick(this,'chkcheckDate','lblTRANSDATE')" />
                                        </td>
                                        <td>
                                            <!--ADD BY VICKY 20140221 新增欄位 -->
                                            <asp:Label ID="lblTRANSDATE" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("TRANSDATE").ToString()) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID"),Eval("CASESTATUS")) %>'
                                                runat="server" Text="明細" />
                                        </td>
                                        <td>
                                            <%--<%#Eval("CNTRNO")%>--%>
                                            <!--ADD BY VICKY 20140317 要串出以便列印 -->
                                            <asp:Label ID="lblCNTRNO" runat="server" Text='<%#Eval("CNTRNO")%>'></asp:Label>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("CUSTNAME")%>
                                            <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                                                ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <%#Eval("DEPT")%>
                                        </td>
                                        <td>
                                            <%#Eval("EMPLNM")%>
                                        </td>
                                        <td>
                                            <%#Eval("MAINTYPENM")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("TRANSTYPENM")%>
                                        </td>
                                        <td style="text-align: right;">
                                            <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
                                        </td>
                                        <td>
                                            <%#Eval("CONTRACTMONTH")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("IRR")%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
                                        </td>
                                        <td>
                                            <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="display: none;">
                                            <!--ADD BY VICKY 20140221 儲存主檔需用到的KEY值 -->
                                            <asp:Label ID="lblRETUNID" runat="server" Text='<%#Eval("RETUNID")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%--<div class="btn_div">
           <input type="button" id="Button3" class="btn_normal" onclick="CaseClick();" value="回件資料維護" />
        </div>--%>
                    <%--UPD BY VICKY 20140220 新增[全選][取消全選][確認]--%>
                    <div class="btn_div">
                        <asp:Button ID="cmdALL" runat="server" Text="全選" CssClass="btn_normal" OnClick="cmdALL_Click" Enabled="false" />
                        <asp:Button ID="cmdNOTALL" runat="server" Text="取消全選" CssClass="btn_normal" OnClick="cmdNOTALL_Click" Enabled="false" />
                        <asp:Button ID="cmdSURE" runat="server" Text="確認" CssClass="btn_normal" OnClick="cmdSURE_Click" Enabled="false" />
                    </div>
                </div>
    </form>
</body>
</html>
