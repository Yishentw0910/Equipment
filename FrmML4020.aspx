<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4020.aspx.cs" Inherits="FrmML4020" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
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
    <!-- #Include file='js/ML4020.js' -->                   
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
      <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: absolute; top: 0px;
        height: 100%">
        <table width="100%" height="100%">
          <tr>
            <td>
              <table width="250" height="60" align="center" bgcolor="#F7F7F7" style="border: 1px solid #A6C4E1;
                font: 12px">
                <tr>
                  <td align="center">
                    <font color="#006699">系統處理中，請稍後...</font>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </div>
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
    <ContentTemplate>
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
        <div class="div_Info H_150">
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
              <th class="align_right" width="20%">
                查詢方式：
              </th>
              <td width="30%">
                <asp:DropDownList ID="cboQueryType" runat="server" Width="80%">
                  <asp:ListItem Value="1">單筆</asp:ListItem>
                  <asp:ListItem Value="2">多筆</asp:ListItem>
                </asp:DropDownList>
              </td>
              <th class="align_right" width="20%">
               繳款方式：
              </th>
              <td>
               <asp:DropDownList ID="cboPayType" runat="server" Width="80%">
                 
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                首期發票開立日：
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtStartDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtEndDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                客戶統編：
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
                  runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                <input type="button" id="Button5" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
                  padding: 2px;" value="&#8230;" />
              </td>
            </tr>
            <tr>
              <th class="align_right">
                合約編號：
              </th>
              <td>
                <asp:TextBox ID="txtCNTRNO" MaxLength="14" onkeypress="OnlyNumDUCase(this);" runat="server"
                  CssClass="txt_normal" Width="120px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
              </th>
              <td>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                合約列印條碼：
              </th>
              <td>
                <asp:TextBox ID="txtCNTRNO_CODE" MaxLength="12" onkeypress="OnlyNumDUCase(this);"
                  runat="server" CssClass="txt_normal" Width="100px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
              </th>
              <td>
              </td>
            </tr>
            <tr>
              <th colspan="4" style="text-align: center; height: 30px;">
                <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="return CheckRule(this)"
                  OnClick="cmdQuery_Click" />
                <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" OnClientClick="return cmdClear_onclick(this)"
                  OnClick="cmdClear_onclick" />
              </th>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
          <asp:UpdatePanel ID="UpdatePanelDate" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <table id="tabQueryDate" cellpadding="0" cellspacing="0" class="tab_result" width="155%"
                style="margin: 4px;">
                <tr>
                  <th rowspan="2">
                    列印<br>
                    勾選
                  </th>
                  <th rowspan="2">
                    合約編號
                  </th>
                  <th rowspan="2">
                    客戶名稱
                  </th>
                  <th rowspan="2">
                    合約期數
                  </th>
                  <th rowspan="2">
                    起租日
                  </th>
                  <th rowspan="2">
                    全期數<br>
                    列印
                  </th>
                  <th rowspan="2">
                    部分期數<br>
                    列印
                  </th>
                  <th colspan="2">
                    列印期數
                  </th>
                  <th colspan="2">
                    租金年月
                  </th>
                  <th rowspan="2">
                    客戶應收餘額查詢
                  </th>
                </tr>
                <tr>
                  <th>
                    起
                  </th>
                  <th>
                    迄
                  </th>
                  <th>
                    起
                  </th>
                  <th>
                    迄
                  </th>
                </tr>
                <asp:Repeater ID="rptData" runat="server">
                  <ItemTemplate>
                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <asp:CheckBox ID="chkPrint" Enabled="true" runat="server" />
                      </td>
                      <td>
                        <%# Eval("CNTRNO") %>
                      </td>
                      <td width="25%">
                        <%# Eval("CUSTNAME")%>
                      </td>
                      <td>
                        <%# Eval("CONTRACTMONTH")%>
                        <asp:HiddenField ID="hidCONTRACTMONTH" Value='<%# Itg.Community.Util.GetRepYear(Eval("CONTRACTMONTH").ToString()) %>'
                          runat="server" />
                      </td>
                      <td>
                        <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                        <asp:HiddenField ID="hidRENTSTDT" Value='<%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString()) %>'
                          runat="server" />
                        <asp:HiddenField ID="hidRENTENDT" Value='<%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString()) %>'
                          runat="server" />
                        <asp:HiddenField ID="hidRENTYEARS" Value='<%# Itg.Community.Util.GetRepYear(Eval("RENTYEARS").ToString()) %>'
                          runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkPrintAll" Enabled="true" runat="server" onclick="chkPrintAll_onclick(this);" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkPrintSub" Enabled="true" runat="server" onclick="chkPrintSub_onclick(this);" />
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtPrintIssueS" onkeypress="OnlyNum(this);"
                          onblur="txtPrintIssueS_checkRule(this);" MaxLength="3" ReadOnly="true" runat="server"
                          Width="40px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtPrintIssueE" onkeypress="OnlyNum(this);"
                          onblur="txtPrintIssueE_checkRule(this);" MaxLength="3" ReadOnly="true" runat="server"
                          Width="40px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtRENTYEARS" onkeypress="OnlyNum(this);" onfocus="YearMonthFocus(this)"
                          onblur="YearMonthBlur(this);txtRENTYEARS_checkRule(this);" MaxLength="6" ReadOnly="true"
                          runat="server" Width="60px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtRENTYEARE" onkeypress="OnlyNum(this);" onfocus="YearMonthFocus(this)"
                          onblur="YearMonthBlur(this);txtRENTYEARE_checkRule(this);" MaxLength="6" ReadOnly="true"
                          runat="server" Width="60px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return cmdiReport_onclick(\"{0}\",\"{1}\",this)", Eval("CNTRNO"), Eval("CUSTID")) %>'
                          runat="server" Text="查詢" />
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <asp:CheckBox ID="chkPrint" Enabled="true" runat="server" />
                      </td>
                      <td>
                        <%# Eval("CNTRNO") %>
                      </td>
                      <td width="25%">
                        <%# Eval("CUSTNAME")%>
                      </td>
                      <td>
                        <%# Eval("CONTRACTMONTH")%>
                      </td>
                      <td>
                        <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                      </td>
                      <td>
                        <asp:CheckBox ID="chkPrintAll" Enabled="true" runat="server" onclick="chkPrintAll_onclick(this);" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkPrintSub" Enabled="true" runat="server" onclick="chkPrintSub_onclick(this);" />
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtPrintIssueS" onkeypress="OnlyNum(this);"
                          MaxLength="3" ReadOnly="true" runat="server" Width="40px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtPrintIssueE" onkeypress="OnlyNum(this);"
                          MaxLength="3" ReadOnly="true" runat="server" Width="40px" Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtRENTYEARS" onkeypress="OnlyNum(this);" onfocus="YearMonthFocus(this)"
                          onblur="YearMonthBlur(this);" MaxLength="6" ReadOnly="true" runat="server" Width="60px"
                          Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:TextBox CssClass="txt_table" ID="txtRENTYEARE" onkeypress="OnlyNum(this);" onfocus="YearMonthFocus(this)"
                          onblur="YearMonthBlur(this);" MaxLength="6" ReadOnly="true" runat="server" Width="60px"
                          Text=''></asp:TextBox>
                      </td>
                      <td>
                        <asp:Button ID="cmdiReport" CssClass="btn_normal" OnClientClick='<%# String.Format("return cmdiReport_onclick(\"{0}\",\"{1}\",this)", Eval("CNTRNO"), Eval("CUSTID")) %>'
                          runat="server" Text="查詢" />
                      </td>
                    </tr>
                  </AlternatingItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
          </asp:UpdatePanel>
          </table>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:UpdatePanel ID="UpdatePanelButton" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="btn_div">
        <asp:Button ID="cmdSelectAll" runat="server" Text="全選" CssClass="btn_normal" OnClientClick="javascipt:return cmdSelectAll_Click(this);" Width="90" />
        <asp:Button ID="cmdUnSelectAll" runat="server" Text="取消全選" CssClass="btn_normal" OnClientClick="javascipt:return cmdUnSelectAll_Click(this);" Width="90" />
        <asp:Button ID="cmdPrint" runat="server" Text="列印繳款單" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrint_onClick(this);" Width="90" />
        <asp:Button ID="cmdPrintThank" runat="server" Text="列印感謝函" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrintThank_onClick(this);" Width="90" />
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
