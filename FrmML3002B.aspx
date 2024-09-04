<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3002B.aspx.cs" Inherits="FrmML3002B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML3002A.js' -->                   
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <div>
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
    <div class="div_Info4">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr>
          <th width="20%">
            客戶統編：
          </th>
          <td width="30%">
            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
          <th width="20%">
            客戶名稱：
          </th>
          <td>
            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th width="20%">
            案件編號：
          </th>
          <td width="30%">
            <asp:TextBox ID="txtCaseID" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
              Width="80%"></asp:TextBox>
          </td>
          <th width="20%">
            合約編號：
          </th>
          <td>
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
              Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th width="20%">
            撥款核准日：
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
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="btnQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="btnQuery_Click" />
          </th>
        </tr>
      </table>
      <%--<div class="btn_div"></div>--%>
    </div>
    <div class="div_Info4 H_260">
      <table cellpadding="0" cellspacing="0" class="tab_result" width="99%">
        <tr>
          <th>
            客戶統編
          </th>
          <th>
            客戶名稱
          </th>
          <th>
            案件編號
          </th>
          <th>
            合約編號
          </th>
          <th>
            案件狀態
          </th>
          <th>
            案件申請日
          </th>
          <th>
            業代名稱
          </th>
          <th style="display:none;">
            效力
          </th>
        </tr>
        <asp:Repeater ID="rptCase" runat="server">
          <ItemTemplate>
            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);Row_Click(this)"
              ondblclick="Row_dblClick(this)" class="singleline">
              <td>
                <%#Eval("CUSTID")%>
              </td>
              <td width="25%"><%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" style="display:none;" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                  Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("CASEID")%>
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td>
                <%# Itg.Community.Util.GetCaseStatus(Eval("CASESTATUS").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("A_SYSDT").ToString())%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td style="display:none;">
                <%# Itg.Community.Util.GetEffect(Eval("CASESTATUS").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <div class="btn_div">
      <asp:Button ID="Button5" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="return cmdConfirm_Click();" />
    </div>
  </div>
  </form>
</body>
</html>
