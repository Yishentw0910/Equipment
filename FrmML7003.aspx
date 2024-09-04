<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML7003.aspx.cs" Inherits="FrmML7003" %>

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
    <!-- #Include file='js/ML7003.js' -->
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
    <div class="div_Info H_130">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr>
          <td style="text-align: right;" width="25%">
            公司別：
          </td>
          <td width="25%">
            <asp:DropDownList ID="drpCompID" runat="server">
              <asp:ListItem>請選擇</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td style="text-align: right;" width="25%">
            轉檔日：
          </td>
          <td width="25%">
            <asp:TextBox ID="txtSysDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td style="text-align: center;" colspan="2">
            <asp:Button ID="cmdProc" runat="server" Text="確定" CssClass="btn_normal" OnClientClick="javascipt:return cmdProc_onClick(this);" Width="90" OnClick="cmdProc_Click" />
          </td>
        </tr>
      </table>
    </div>
  </div>
  </form>
</body>
</html>
