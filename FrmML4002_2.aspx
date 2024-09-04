<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4002_2.aspx.cs" Inherits="FrmML4002_2" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="div_title" runat="server" id="divTitle">�o���J�}���Ӹ��</div>
            <table class="tb_Contact" style="margin:5px;" width="98%">
            <tr>
              <th>�J�}�X���s��</th>
              <th>�X���s��</th>
              <th>�o���}�_��</th>
              <th>�X��@�}</th>
              <th>���w���</th>
              <th>�o���νs</th>
              <th>�o�����Y</th>
              <th>�ӧ@����</th>
              <th>����</th>
              <th>�`����</th>
            </tr>
             <asp:Repeater ID="rptMLDPREINVOPEN" runat="server" 
                onitemcommand="rptMLDPREINVOPEN_ItemCommand">
                  <ItemTemplate> 
            <tr>
              <td><%#Eval("OPENCNTRNO")%></td>
              <td><%#Eval("CNTRNO")%></td>
		          <td><%#Eval("INVOPENMONTH")%></td>
		          <td><%#Eval("OPENMONTH")%></td>
		          <td><%#Eval("ORDERDATE")%></td>
		          <td><%#Eval("TARGETID")%></td>
		          <td><%#Eval("TARGETNAME")%></td>
		          <td><%#Eval("MAINTYPES")%></td>
		          <td><%#Eval("RPAY")%></td>
		          <td><%#Eval("CONTRACTMONTH")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
          </table>
        </div>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="�J�}�T�{" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click"  />
        </div>
    </div>
    </form>
</body>
</html>
