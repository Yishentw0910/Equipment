<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5002.aspx.cs" Inherits="FrmML5002" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML5002.js' -->  
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
          <td width="70%">
           <asp:DropDownList ID="drpCompID" runat="server" Width="20%">
             <asp:ListItem Value="">請選擇</asp:ListItem>
           </asp:DropDownList>
          </td>
          <th style="display:none;" class="align_right" width="20%">
            業代名：
          </th>
          <td style="display:none;" width="30%">
            <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
            <input type="button" id="Button6" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
          </td>
        </tr>
        <tr>
          <th class="align_right">
            合約編號：
          </th>
          <td>
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" MaxLength="14"
              CssClass="txt_normal" Width="30%"></asp:TextBox>
          </td>
          <th style="display:none;" class="align_right">&nbsp;
            案件核准日：
          </th>
          <td style="display:none;">&nbsp;
            <asp:TextBox ID="txtCASEDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            財務撥款確認日起迄：
          </th>
          <th style="text-align:left;">
            <asp:TextBox ID="txtCNTRNODATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>～<asp:TextBox ID="txtCNTRNODATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>
          </td>
          <th style="display:none;" class="align_right">&nbsp;
            起租日：
          </th>
          <td style="display:none;">&nbsp;
            <asp:TextBox ID="txtRENTSTDT" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
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
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
      <table cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px; width: 1000px;">
        <tr>
          <th style="width:5%;">
            展開
          </th>
          <th style="width:10%;">
            合約編號
          </th>
          <th style="width:15%;">
            客戶名稱
          </th>
          <th style="width:10%;">
            部門
          </th>
          <th style="display:none;">
            業代
          </th>
          <th style="width:8%;">
            承作類型
          </th>
          <th style="display:none;">
            交易型態
          </th>
          <th style="width:6%;">
            承作金額
          </th>
          <th style="width:5%;">
            期數
          </th>
          <th style="display:none;">
            IRR
          </th>
          <th style="display:none;">
            月付租金
          </th>
          <th style="display:none;">
            起租日
          </th>
          <th style="display:none;">
            迄租日
          </th>
          <th style="width:7%;">
            撥款確認日
          </th>
          <th style="width:7%;">
            未回件天數
          </th>
          <th style="display:none;">
            客服上次退件日
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align:center" ><%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" style="display:none;" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                  Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display:none;">
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td style="display:none;">
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td style="text-align:right;">
                <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td style="display:none;">
                <%#Eval("IRR")%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align:center" ><%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" style="display:none;" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                  Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display:none;">
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td style="display:none;">
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td style="text-align:right;">
                <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td style="display:none;">
                <%#Eval("IRR")%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <%--<div class="btn_div">
           <input type="button" id="Button3" class="btn_normal" onclick="CaseClick();" value="回件資料維護" />
        </div>--%>
  </div>
  </form>
</body>
</html>
