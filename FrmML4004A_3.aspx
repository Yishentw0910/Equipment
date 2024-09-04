<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="FrmML4004A_3.aspx.cs" Inherits="FrmML4004A_3" %>

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
    <%--20121222 Modify By SS Maureen Reason:修改將特殊備註的欄框縮小--%>
    <%--div style="margin:5px;"--%>
      <%--<table class="tb_Contact" width="98%">--%>
    <div style="margin:5px 0px 5px 15px;">
      <table class="tb_Contact" width="180" align="center">
        <tr >
          <th>備註</th>
        </tr>
        <tr>
          <%--20121214 Modify By SS Maureen Reason:發票特殊備註修改限制只能輸入12個中文字(24個字元)--%>
          <%--<td><asp:TextBox ID="txtMain" runat="server" CssClass="txt_table" 
              Height="91px" TextMode="MultiLine" Width="98%"></asp:TextBox></td>--%>
          
          <%--20121222 Modify By SS Maureen Reason:修改將特殊備註的欄框縮小--%>
          <%--<td><asp:TextBox ID="TextBox1" runat="server" CssClass="txt_table" onblur="CheckMLength(this,'24','特殊備註');"
              Height="91px" TextMode="MultiLine" Width="98%" MaxLength="24"></asp:TextBox></td>--%>
          <td><asp:TextBox ID="txtMain" runat="server" CssClass="txt_table" onblur="CheckMLength(this,'24','特殊備註');"
              Height="20px" Width="100%" MaxLength="24"></asp:TextBox></td>
        </tr>
       </table>
       <div class="btn_div" align="center">
            <asp:Button ID="btnSub" runat="server" Text="確認" OnClientClick="return cmdConfirm_Click();" CssClass="btn_normal"/>
        </div>
    </div>
    </form>
</body>
</html>
