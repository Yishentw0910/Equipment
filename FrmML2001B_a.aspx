<%--********************************************************************************************************--%>
<%--* Database 	: ML																						--%>	
<%--* �t    �� 	: ����]��																					--%>
<%--* �{���W�� 	: FrmML2001A_a																				--%>
<%--* �{���\��  : �������]             																	--%>
<%--* �{���@�� 	: MAUREEN       																			--%>	
<%--* �s�W�ɶ� 	: 2012/06/04																				--%>	
<%--                                                                                                        --%>
<%--********************************************************************************************************--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B_a.aspx.cs" Inherits="FrmML2001B_a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�������]</title>
    <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />
    <style type="text/css">
        .style6
        {
            width: 165px;
        }
        .style7
        {
            width: 852px;
        }
        .style8
        {
            width: 216px;
        }
    </style>
      <script type="text/javascript" language="javascript" src="js/UI.js"></script>

      <script language="javascript" src="js/Itg.js"></script>

      <script language="javascript" src="js/validate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <center style="margin-top:4px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
              <table style="margin:0 auto; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1"width="500">
                  <tr>
                      <td style="background-color: #ffcc99; text-align: center" colspan="2"><B>�������](�i�ƿ�)</B></td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">�ɴڤH</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="A001" runat="server" AutoPostBack="True"   Text="��B�I�h"/><br/>
                          <asp:CheckBox ID="A002" runat="server" AutoPostBack="True"   Text="���l�Y��"/><br/>
                          <asp:CheckBox ID="A003" runat="server" AutoPostBack="True"   Text="���ߴ��u�A�禬���C"/><br/>
                          <asp:CheckBox ID="A004" runat="server" AutoPostBack="True"   Text="��B�g���L��"/><br/>
                          <asp:CheckBox ID="A005" runat="server" AutoPostBack="True"   Text="�Ӥ᲼/�ūH���`"/><br/>
                          <asp:CheckBox ID="A006" runat="server" AutoPostBack="True"   Text="�Ӥᤣ�ʲ��������]�w�O��"/><br/>
                          <asp:CheckBox ID="A007" runat="server" AutoPostBack="True"   Text="�Ӥᤣ�ʲ�������n�O�O��"/><br/>
                          <asp:CheckBox ID="A008" runat="server" AutoPostBack="True"   Text="�Ӥ�t�Ű����B�]�ȵ��c����"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">�ɴڥت�</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="B001" runat="server" AutoPostBack="True"   Text="����γ~����"/><br/>
                          <asp:CheckBox ID="B002" runat="server" AutoPostBack="True"   Text="�Z�e�׮ɶ��ӵu�B�l�B����"/><br/>
                          <asp:CheckBox ID="B003" runat="server" AutoPostBack="True"   Text="�u������P�~�ӿ��W�c"/><br/>
                          <asp:CheckBox ID="B004" runat="server" AutoPostBack="True"   Text="�P�~���ڥ�"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">�ٴڨӷ�</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="C001" runat="server" AutoPostBack="True"   Text="�ٴڨӷ�����"/><br/>
                          <asp:CheckBox ID="C002" runat="server" AutoPostBack="True"   Text="�ٴگ�O����"/><br/>
                          <asp:CheckBox ID="C003" runat="server" AutoPostBack="True"   Text="�����B�����ڦ��禬��Ұ�"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">���v�O��</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="D001" runat="server" AutoPostBack="True"   Text="��ڸg��̤����O"/><br/>
                          <asp:CheckBox ID="D002" runat="server" AutoPostBack="True"   Text="��O�O����"/><br/>
                          <asp:CheckBox ID="D003" runat="server" AutoPostBack="True"   Text="�Ъ����ʽ褣�ΩξA�Ω�/�G��ʦ���"/><br/>
                          <asp:CheckBox ID="D004" runat="server" AutoPostBack="True"   Text="�Ъ����L�G���"/><br/>
                          <asp:CheckBox ID="D005" runat="server" AutoPostBack="True"   Text="�O�H�d�`"/><br/>
                          <asp:CheckBox ID="D006" runat="server" AutoPostBack="True"   Text="�O�H�w�ɲ{��"/><br/>
                          <asp:CheckBox ID="D007" runat="server" AutoPostBack="True"   Text="�O�H�L�겣"/><br/>
                          <asp:CheckBox ID="D008" runat="server" AutoPostBack="True"   Text="�O�H��/�ūH���`"/><br/>
                          <asp:CheckBox ID="D009" runat="server" AutoPostBack="True"   Text="�O�H���ʲ��������]�w�O��"/><br/>
                          <asp:CheckBox ID="D010" runat="server" AutoPostBack="True"   Text="�O�H���ʲ�������n�O�O��"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">�«H�i��</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="E001" runat="server" AutoPostBack="True"   Text="�~�Ȩӷ��L�󶰤�"/><br/>
                          <asp:CheckBox ID="E002" runat="server" AutoPostBack="True"   Text="�ݤi�����~"/><br/>
                          <asp:CheckBox ID="E003" runat="server" AutoPostBack="True"   Text="��~����I�h"/><br/>
                          <asp:CheckBox ID="E004" runat="server" AutoPostBack="True"   Text="�������Y"/><br/>
                          <asp:CheckBox ID="E005" runat="server" AutoPostBack="True"   Text="�����v���E�P"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">��L</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="F001" runat="server" AutoPostBack="True"   Text="�������B�ש��q�x�����B�Ȥ᭭�����μЪ�������"/><br/>
                          <asp:CheckBox ID="F002" runat="server" AutoPostBack="True"   Text="�ާ@�覡���~�ά[�c(�ӿ���B/����/����)���X�z"/><br/>
                          <asp:CheckBox ID="F003" runat="server" AutoPostBack="True"   Text="�P�F�����šA�|ñ��L����"/><br/>
                          <asp:CheckBox ID="F999" runat="server" AutoPostBack="True" oncheckedchanged="F999_CheckedChanged"  Text="��L�G"/>
                          <asp:TextBox ID="txtF999" runat="server" Width="250px" ></asp:TextBox><br/>
                      </td>
                  </tr>
              </table>                    
              <table>
                  <tr>      
	        	    <td>				
                    <asp:Button ID="cmdSURE" runat="server" Text="�T�w" OnClick="cmdSURE_Click"/>
                    <asp:Button ID="cmdBACK" runat="server" Text="����"  OnClick="cmdBACK_Click" />
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
