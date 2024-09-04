<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5003.aspx.cs" Inherits="FrmML5003" %>

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
    <!-- #Include file='js/ML5003.js' -->                   
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
          <th class="align_right" width="20%">
            公司別：
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server">
              <asp:ListItem Value="">請選擇</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:查詢條件增加部門別--%>
          <th class="align_right" width="20%">
            部門別：
          </th>
          <td>
            <asp:DropDownList ID="ddlDEPTID" runat="server">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            合約編號：
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" MaxLength="14"
              CssClass="txt_normal" Width="30%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right" width="20%">
            客服點件：
          </th>
          <td>
            <asp:DropDownList ID="drpCheckDate" runat="server">
              <asp:ListItem Value="2">未點件</asp:ListItem>
              <asp:ListItem Value="">全部</asp:ListItem>
              <asp:ListItem Value="1">已點件</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:查詢條件增加客服點件日(起)(迄)--%>
          <th class="align_right" width="20%">
            客服點件日起迄：
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtCHECKDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtCHECKDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>～<asp:TextBox
                ID="txtCHECKDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtCHECKDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right" width="20%">
            客服回件：
          </th>
          <td>
            <asp:DropDownList ID="drpReturn" runat="server">
              <asp:ListItem Value="2">未回件</asp:ListItem>
              <asp:ListItem Value="">全部</asp:ListItem>
              <asp:ListItem Value="1">已回件</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th class="align_right" width="20%">
            客服回件日起迄：
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtCNTRNODATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtCNTRNODATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>～<asp:TextBox
                ID="txtCNTRNODATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtCNTRNODATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
          </td>
        </tr>
        <%--Modify 20140220 By SS Eric Reason:查詢條件增加退件狀態--%>
        <tr>
          <th class="align_right" width="20%">
            退件狀態：
          </th>
          <td>
            <asp:DropDownList ID="ddlBACKMODE" runat="server">
              <asp:ListItem Value="">請選擇</asp:ListItem>        
              <asp:ListItem Value="1">退件未回</asp:ListItem>
              <asp:ListItem Value="2">退件已回</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:查詢條件增加營業處傳遞日(起)(迄)--%>
          <th class="align_right" width="20%">
            營業處傳遞日起迄：
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtSALESDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtSALESDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>～<asp:TextBox
                ID="txtSALESDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtSALESDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
          </td>            
        </tr>
        <tr>
          <th class="align_right">
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
            <%--Modify 20140220 By SS Eric Reason:新增下載EXCEL按鈕--%>
            <asp:Button ID="btnExport" runat="server" Text="下載" CssClass="btn_normal" 
                  onclick="btnExport_Click" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
      <table cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px; width: 1250px;">
        <tr>
          <th style="width: 3%;">
            點件
          </th>
          <th style="width: 6%;">
            點件日
          </th>
          <th style="width: 6%;">
            展開
          </th>
          <th style="width: 10%;">
            合約編號
          </th>
          <th style="width: 15%;">
            客戶名稱
          </th>
          <th style="width: 10%;">
            部門
          </th>
          <th style="display: none;">
            業代
          </th>
          <th style="width: 8%;">
            承作類型
          </th>
          <th style="display: none;">
            交易型態
          </th>
          <th style="width: 7%;">
            承作金額
          </th>
          <th style="width: 5%;">
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
          <th style="width: 8%;">
            回件天數
          </th>
          <th style="width: 8%;">
            客服上次退件日
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:CheckBox ID="chkcheckDate" runat="server" onClick="DOCCONFIRMClick(this,'chkcheckDate','lblRepDate')" />
                <asp:HiddenField ID="hidRETUNID" runat="server" Value='<%#Eval("RETUNID")%>' />
              </td>
              <td>
                <asp:Label ID="lblRepDate" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("RETUNCONFIRMDATE0").ToString()) %>'></asp:Label>
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align: center">
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display: none;">
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
                <%# Itg.Community.Util.GetRepYear(Eval("PAYDATE").ToString()) %>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:CheckBox ID="chkcheckDate" runat="server" onClick="DOCCONFIRMClick(this,'chkcheckDate','lblRepDate')" />
                <asp:HiddenField ID="hidRETUNID" runat="server" Value='<%#Eval("RETUNID")%>' />
              </td>
              <td>
                <asp:Label ID="lblRepDate" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("RETUNCONFIRMDATE0").ToString()) %>'></asp:Label>
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align: center">
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display: none;">
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
                <%# Itg.Community.Util.GetRepYear(Eval("PAYDATE").ToString()) %>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn_normal" OnClick="btnSave_Click" />
    </div>
  </div>
  </form>
</body>
</html>
