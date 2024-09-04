<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4002_1.aspx.cs" Inherits="FrmML4002_1" %>

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
    <!-- #Include file='js/ML4002_1.js' -->
    </script>
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
          <hr/>
        </td>
      </tr>
    </table>
        <br>
        <div class="div_title" runat="server" id="divTitle">發票彙開主約明細資料</div>
            <table class="tb_Contact" id="tabMLDPREINVOPENMAJCNTR" style="margin:5px;" width="98%">
            <tr>
              <th></th>
              <th>合約編號</th>
              <th>發票開起月</th>
              <th>指定日期</th>
              <th>幾月一開</th>
              <th style="display:none">發票統編</th>
              <th style="display:none">發票抬頭</th>
              <th>總期數</th>
            </tr>
             <asp:Repeater ID="rptMLDPREINVOPENMAJCNTR" runat="server" 
                onitemcommand="rptMLDPREINVOPENMAJCNTR_ItemCommand">
                  <ItemTemplate> 
            <tr>
                  <td>
                      <asp:HiddenField ID="hdnCNTRNO" Value='<%#Eval("CNTRNO")%>' runat="server" />
                      <asp:RadioButton ID="optMaster" GroupName="MLDPREINVOPENMAJCNTR" runat="server" /></td>
                  <td><%#Eval("CNTRNO")%></td>
		          <td><%#Eval("RENTSTDTM")%></td>
		          <td><%#Eval("ORDERDATE")%></td>
		          <td><%#Eval("OPENMONTH")%></td>
		          <td style="display:none"></td>
		          <td style="display:none"></td>
		          <td><%#Eval("ISSUE")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
          </table>
        </div>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="彙開確認" Width="120px" CssClass="btn_normal" OnClientClick="JavaScript: return btnConfirm_onClick(this);"  OnClick="btnConfirm_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
