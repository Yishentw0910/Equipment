<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="FrmML4004A_2.aspx.cs" Inherits="FrmML4004A_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <base target="_self"  />
    <meta http-equiv=Content-Type content="text/html; charset=big5">
    <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv=Pragma content=no-cache>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />
    <script language="javascript" type="text/javascript" src="js/UI.js"></script>
    <script language="javascript" type="text/javascript" src="js/Itg.js"></script>
    <script language="javascript" type="text/javascript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4004A_2.js' -->
    </script>
</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
    <div style="margin:5px;">
      <table class="tb_Contact" width="98%">
        <tr >
          <th>備註</th>
        </tr>
        <tr>
          <td><asp:TextBox ID="txtMain" runat="server" CssClass="txt_table" 
              Height="91px" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
        </tr>
       </table>
       <div class="btn_div">
            <asp:Button ID="btnSub" runat="server" Text="確認"  OnClientClick="return cmdConfirm_Click();" CssClass="btn_normal"/>
        </div>
    </div>
    </form>
</body>
</html>
