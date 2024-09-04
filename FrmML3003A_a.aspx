<%--********************************************************************************************************--%>
<%--* Database 	: ML																						--%>	
<%--* 系    統 	: 租賃設備																					--%>
<%--* 程式名稱 	: ML3003A_a																				    --%>
<%--* 程式功能  : 關係人合約撥款檢核	    																    --%>
<%--* 程式作者 	: Maureen															   			            --%>	
<%--* 新增時間 	: 2012/11/21																				--%>	
<%--                                                                                                        --%>
<%--********************************************************************************************************--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3003A_a.aspx.cs" Inherits="FrmML3003A_a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <base target="_self" />
  <meta http-equiv="MSThemeCompatible" content="No" />
    <title>關係人合約檢核</title>
  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3003A_a.js' -->                   
  </script>
</head>
<body style="background-color:#FFFF99;">
    <form id="form1" runat="server">
        <center style="margin-top:4px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                <asp:HiddenField ID="hdnPRINTKEY" Value="" runat="server" />
                <asp:HiddenField ID="hdnINDT" Value="" runat="server" />
                <asp:HiddenField ID="hdnTRADEDT" Value="" runat="server" />
                <asp:HiddenField ID="hdnCREDITDT" Value="" runat="server" />
              <table style="margin:0 auto; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1"width="350">
                  <tr>
                      <td style="text-align: right; width:40%">
                          合約編號</td>
                      <td style="text-align: left; width:60%">
                          <asp:TextBox ID="txtCNTRNO" runat="server" MaxLength="14"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td style="text-align: right">
                          申請書案號</td>
                      <td style="text-align: left">
                          <asp:TextBox ID="txtCASEID" runat="server" MaxLength="14"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td colspan="2" style="text-align: center">
                          <%--<asp:Button ID="cmdPRINT" runat="server" Text="列印" OnClick="cmdPRINT_Click" OnClientClick="cmdPRINT_Click(this);"/>&nbsp; &nbsp;--%>
                          <asp:Button ID="cmdPRINT" runat="server" Text="列印" OnClick="cmdPRINT_Click"/>&nbsp; &nbsp;
                          <asp:Button ID="cmdCLEAR" runat="server" Text="清除" OnClick="cmdCLEAR_Click" />&nbsp; &nbsp;
                          <asp:Button ID="cmdCLOSE" runat="server" Text="關閉" OnClientClick="cmdCLOSE_Click();" />
                      </td>
                  </tr>
              </table> 
           
            <asp:HiddenField ID="SessUSERID" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTUID" runat="server" />
            <asp:HiddenField ID="SessUSERNM" runat="server" />
            <asp:HiddenField ID="SessLOGINTIME" runat="server" />
            <asp:HiddenField ID="SessEMPLID" runat="server" />
            <asp:HiddenField ID="SessBRNHCD" runat="server" />
            <asp:HiddenField ID="SessDBNM" runat="server" />
            <asp:HiddenField ID="SessMTSSVRNM" runat="server" />
            <asp:HiddenField ID="SessSQLSVRNM" runat="server" />
            <asp:HiddenField ID="SessSYSCD" runat="server" />
            <asp:HiddenField ID="SessGROUPID" runat="server" />
            <asp:HiddenField ID="SessDATAGP" runat="server" />
            <asp:HiddenField ID="SessDLRCD" runat="server" />
            <asp:HiddenField ID="SessDLRNM" runat="server" />
            <asp:HiddenField ID="SessDEPTID" runat="server" />
            <asp:HiddenField ID="SessDEPTNM" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTNM" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTID" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTUID" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTNM" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTID" runat="server" />
            <asp:HiddenField ID="REMOTEHOST" runat="server" />
            <asp:HiddenField ID="SUBSCD" runat="server" />
            <asp:HiddenField ID="PROGID" runat="server" />
            <asp:HiddenField ID="SessionString" runat="server" />           
           	
            </ContentTemplate>
        </asp:UpdatePanel>     
        </center>
    </form>
</body>
</html>
