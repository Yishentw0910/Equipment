<%--********************************************************************************************************--%>
<%--* Database 	: ML																						--%>	
<%--* �t    �� 	: ����]��																					--%>
<%--* �{���W�� 	: FrmML2001A_c																				--%>
<%--* �{���\��  : �u�h��v�\��A�Ϥ��u�h��(��Ƥ���)�v�M�u�h��(����վ�)�v									--%>
<%--* �{���@�� 	: MAUREEN       																			--%>	
<%--* �s�W�ɶ� 	: 2012/06/04																				--%>	
<%--                                                                                                        --%>
<%--********************************************************************************************************--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B_c.aspx.cs" Inherits="FrmML2001B_c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�h���]</title>
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
            <th class="style3">�h���]</th>
            <td>
                <asp:DropDownList ID="drpREASON" DataTextField="MNAME1" DataValueField="MCODE" runat="server" >
                <%--asp:ListItem Value="">�п��</asp:ListItem>
                <asp:ListItem Value="01">�h��(��Ƥ���)</asp:ListItem>
                <asp:ListItem Value="02">�h��(����վ�)</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th class="style3">�h�󤺮e�G</th>
            <td>
                <asp:TextBox ID="txtREASONDESC" Height="200px" Width="100%" Style="word-wrap: break-word;
                word-break: break-all;" TextMode="MultiLine" CssClass="txt_normal" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style=" margin-left: 50px; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1" width="500">
        <tr>      
	        <td style="text-align: center" colspan="2" class="style2">				
                <asp:Button ID="cmdSURE" runat="server" Text="�T�w" OnClick="cmdSURE_Click"/>
                <%--<asp:Button ID="cmdBACK" runat="server" Text="����"  OnClick="cmdBACK_Click" />--%>
            </td>
        </tr>    
    </table>
    </div>
    </form>
</body>
</html>
