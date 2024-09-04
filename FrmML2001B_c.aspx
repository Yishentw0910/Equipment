<%--********************************************************************************************************--%>
<%--* Database 	: ML																						--%>	
<%--* 系    統 	: 租賃設備																					--%>
<%--* 程式名稱 	: FrmML2001A_c																				--%>
<%--* 程式功能  : 「退件」功能，區分「退件(資料不齊)」和「退件(條件調整)」									--%>
<%--* 程式作者 	: MAUREEN       																			--%>	
<%--* 新增時間 	: 2012/06/04																				--%>	
<%--                                                                                                        --%>
<%--********************************************************************************************************--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B_c.aspx.cs" Inherits="FrmML2001B_c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>退件原因</title>
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>
    <style type="text/css">
        .style2
        {
            width: 546px;
        }
        .style3
        {
            width: 89px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="margin-top: 50px; margin-left: 50px; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1" width="500">
        <tr>
            <th class="style3">退件原因</th>
            <td>
                <asp:DropDownList ID="drpREASON" DataTextField="MNAME1" DataValueField="MCODE" runat="server" >
                <%--asp:ListItem Value="">請選擇</asp:ListItem>
                <asp:ListItem Value="01">退件(資料不齊)</asp:ListItem>
                <asp:ListItem Value="02">退件(條件調整)</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th class="style3">退件內容：</th>
            <td>
                <asp:TextBox ID="txtREASONDESC" Height="200px" Width="100%" Style="word-wrap: break-word;
                word-break: break-all;" TextMode="MultiLine" CssClass="txt_normal" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style=" margin-left: 50px; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1" width="500">
        <tr>      
	        <td style="text-align: center" colspan="2" class="style2">				
                <asp:Button ID="cmdSURE" runat="server" Text="確定" OnClick="cmdSURE_Click"/>
                <%--<asp:Button ID="cmdBACK" runat="server" Text="關閉"  OnClick="cmdBACK_Click" />--%>
            </td>
        </tr>    
    </table>
    </div>
    </form>
</body>
</html>
