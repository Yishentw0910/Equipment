<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="FrmML4004A_1.aspx.cs" Inherits="FrmML4004A_1" %>

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
    <script language="javascript" type="text/javascript" src="js/ITG.js"></script>
    <script language="javascript" type="text/javascript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4004A_1.js' -->
    </script>
</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
    <div style="margin:5px;">
     <asp:HiddenField ID="hdnMAINTYPE" runat="server" />
     <asp:HiddenField ID="hdnISSUE" runat="server" />
     <table id="tabINVDESC" class="tb_Contact" runat="server" width="98%">
        <tr >
          <th>品名</th>
          <th>未稅額</th>
          <th>稅額</th>
        </tr>
        <tr style="display:none;">
          <td><asp:Label ID="spanINVDESC" runat="server" Text="Label"></asp:Label><asp:TextBox ID="txtINVDESC" runat="server" CssClass="txt_table_left" TextMode="SingleLine" Width="95%" MaxLength="100"></asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanAMOUNT" runat="server" Text=""></asp:Label><asp:TextBox ID="txtAMOUNT" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanTAX" runat="server" Text=""></asp:Label><asp:TextBox ID="txtTAX" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr style="display:none;">
          <td><asp:Label ID="spanINVDESC_RTNAMT" runat="server" Text="本金"></asp:Label><asp:TextBox ID="txtINVDESC_RTNAMT" runat="server" CssClass="txt_table_left" TextMode="SingleLine" Width="95%" MaxLength="100">本金</asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanRTNAMT" runat="server" Text="0"></asp:Label><asp:TextBox ID="txtRTNAMT" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanRTNAMT_TAX" runat="server" Text="0"></asp:Label><asp:TextBox ID="txtRTNAMT_TAX" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr style="display:none;">
          <td><asp:Label ID="spanINVDESC_INSTAMT" runat="server" Text="利息"></asp:Label><asp:TextBox ID="txtINVDESC_INSTAMT" runat="server" CssClass="txt_table_left" TextMode="SingleLine" Width="95%" MaxLength="100">利息</asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanINSTAMT" runat="server" Text="0"></asp:Label><asp:TextBox ID="txtINSTAMT" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
          <td style="text-align:right;"><asp:Label ID="spanINSTAMT_TAX" runat="server" Text="0"></asp:Label><asp:TextBox ID="txtINSTAMT_TAX" runat="server" CssClass="txt_table_right" TextMode="SingleLine" Width="95%" MaxLength="10"></asp:TextBox></td>
        </tr>
       </table>
       <div class="btn_div">
            <asp:Button ID="btnSub" runat="server" Text="確認"  OnClientClick="return cmdConfirm_Click();" CssClass="btn_normal"/>
        </div>
    </div>
    </form>
</body>
</html>
