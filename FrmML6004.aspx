<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6004.aspx.cs" Inherits="FrmML6004" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script language="JavaScript" type="text/JavaScript" src="js/UI.js"></script>

  <script language="JavaScript" type="text/JavaScript" src="js/ITG.js"></script>

  <script language="JavaScript" type="text/JavaScript" src="js/validate.js"></script>

  <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML6004.js' -->
  </script>

</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
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
    <div class="div_Info H_130">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr style="display:none">
          <th colspan="2" class="align_right" width="50%">
            公司別：
          </th>
          <td colspan="2" width="50%">
            <asp:DropDownList ID="drpCompID" runat="server">
            </asp:DropDownList>
          </td>
        </tr>
        <tr style="display:none">
          <th colspan="2" class="align_right">
            部門別：
          </th>
          <td colspan="2">
            <asp:DropDownList ID="drpDeptID" runat="server">
            </asp:DropDownList>
          </td>
        </tr>
        <tr style="display:none">
          <th colspan="2" class="align_right">
            承作類型：
          </th>
          <td colspan="2">
            <asp:DropDownList ID="drpMAINTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th colspan="2" class="align_right">
            <asp:RadioButton ID="rdoCNTRNO" GroupName="rdo" runat="server" />合約編號：
          </th>
          <td colspan="2">
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
              Width="150px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th colspan="2" class="align_right">
            <asp:RadioButton ID="rdoDateSE" GroupName="rdo" runat="server" />日期起迄：
          </th>
          <td colspan="2">
            <asp:TextBox ID="txtSTADT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtENDDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th colspan="2" class="align_right">
            截止日：
          </th>
          <td colspan="2">
            <asp:TextBox ID="txtSTOPDT"  MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td style="text-align: center;" colspan="4">
            <asp:Button ID="cmdPrint" runat="server" Text="列印(原)" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrint_onClick(this);"
              Width="90" />
            <asp:Button ID="cmd_Print" runat="server" Text="列印(新)" CssClass="btn_normal" OnClientClick="javascipt:return cmd_Print_onClick(this);"
              Width="90" />
          </td>
        </tr>
      </table>
    </div>
  </div>
  </form>
</body>
</html>
