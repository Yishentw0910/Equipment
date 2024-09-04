<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4002.aspx.cs" Inherits="FrmML4002" %>

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
        <div class="divTitle" runat="server" style="display:none;" id="divTitle">�o���J�}�����������Ӹ��</div>
        <div class="div_Info4 H_260" >
            <table class="tb_Contact" id="tabMLDPREINVOPENCNTR" style="margin:5px;" width="98%">
            <tr>
              <th>�X���s��</th>
              <th>�o���}�_��</th>
              <th>���w���</th>
              <th>�X��@�}</th>
              <th>�o���νs</th>
              <th>�o�����Y</th>
              <th>�o���a�}</th>
              <th>�`����</th>
            </tr>
             <asp:Repeater ID="rptMLDPREINVOPENCNTR" runat="server" 
                onitemcommand="rptMLDPREINVOPENCNTR_ItemCommand">
                  <ItemTemplate> 
            <tr>
                  <td><%#Eval("CNTRNO")%></td>
		          <td><%#Eval("RENTSTDTM")%></td>
		          <td><%#Eval("ORDERDATE")%></td>
		          <td><%#Eval("OPENMONTH")%></td>
		          <td><%#Eval("TARGETID")%></td>
		          <td><%#Eval("TARGETNAME")%></td>
		          <td><%#Eval("INVOICEADDR")%></td>
		          <td><%#Eval("ISSUE")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
          </table>
            <div class="btn_div">
              <asp:Button ID="btnConfirm" runat="server" Text="�J�}�T�{" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click"  />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
