<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3001																					
* �{���\��  : �ץ�֭���@																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20121114 By SS Steven. Reason: �s�W�u�h�^�v��checkbox����A������x�s�i�h�^��ML3000�A�åB�o�eEMAIL�q���~�N.

--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3001.aspx.cs" Inherits="FrmML3001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML3001.js' -->                   
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <div class="divBody">
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
    <div class="div_Info H_130">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr>
          <th class="align_right" width="20%">
            ���q�O�G
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
              <asp:ListItem>�п��</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th class="align_right" width="20%">
            �����O�G
          </th>
          <td>
            <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
              <asp:ListItem>�_�@�B</asp:ListItem>
              <asp:ListItem>�_�G�B</asp:ListItem>
              <asp:ListItem>�_�T�B</asp:ListItem>
              <asp:ListItem>���B</asp:ListItem>
              <asp:ListItem>���ϳB</asp:ListItem>
              <asp:ListItem>�n�ϳB</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �~�N�W�G
          </th>
          <td>
            <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_readonly" Width="80%"></asp:TextBox>
            <input type="button" id="Button4" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
            <asp:TextBox ID="txtAgencyId" runat="server" CssClass="txt_normal" Style="display: none;"></asp:TextBox>
          </td>
          <th class="align_right">
            �ץ�s���G
          </th>
          <td>
            <asp:TextBox ID="txtCaseID" MaxLength="12" onkeypress="OnlyNumDUCase(this);" runat="server"
              CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �Ȥ�νs�G
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
              runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
            <input type="button" id="Button6" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �x�H�֭��G
          </th>
          <td>
            <asp:TextBox ID="txtApproveDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
          <td>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="�M��" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
      <%--<table cellpadding="0" cellspacing="0" class="tab_result" width="1200px" style="margin:4px;">--%>
      <table cellpadding="0" cellspacing="0" class="tab_result" width="150%" style="margin: 4px;">
        <tr>
          <th>
            �֭�
          </th>
          <th>
            �M��
          </th>
          <%--Modify 20121114 By SS Steven. Reason: �s�W�u�h�^�v��checkbox����A������x�s�i�h�^��ML3000�A�åB�o�eEMAIL�q���~�N.--%>
          <%--Mark by Sean 2012/11/30 �B�����i�h�^--%>
		  <th>
            �h�^
          </th>
          <th>
            �i�}
          </th>
          <th>
            �ץ�s��
          </th>
          <th>
            �Ȥ�W��
          </th>
          <th>
            �ӧ@����
          </th>
          <th>
            �ӧ@�~�N
          </th>
          <th>
            �ӧ@����
          </th>
          <th>
            ������A
          </th>
          <th>
            �ʥα���
          </th>
          <th>
            �ӧ@���B
          </th>
          <th>
            ����
          </th>
          <th>
            IRR
          </th>
          <th>
            �i����
          </th>
          <th>
            �i��֭���
          </th>
          <th>
            �x�H�֭��
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <input type="checkbox" id="chkApprove" runat="server" value="1" onclick="checkBox_Onclick(this);" />
              </td>
              <td>
                <input type="checkbox" id="chkRej" runat="server" value="2" onclick="checkBox_Onclick(this);" />
              </td>
              <%--Modify 20121114 By SS Steven. Reason: �s�W�u�h�^�v��checkbox����A������x�s�i�h�^��ML3000�A�åB�o�eEMAIL�q���~�N.--%>
              <%--Mark by Sean 2012/11/30 �B�����i�h�^--%>
			  <td>
                <input type="checkbox" id="chkReturn" runat="server" value="3" onclick="checkBox_Onclick(this);" />
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",this)", Eval("CASEID"), Eval("CUSTID")) %>'
                  runat="server" Text="����" />
              </td>
              <td>
                <asp:Label ID="lblCASEID" runat="server" Text='<%# Eval("CASEID") %>'></asp:Label>
              </td>
              <td width="16%"><%# Eval("CUSTNAME")%> 
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td>
                <%#Eval("USESTATUSNM")%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td>
                <%#Eval("IRR") %>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("CASEINDATE").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("SDATE").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <input type="checkbox" id="chkApprove" runat="server" value="1" onclick="checkBox_Onclick(this);" />
              </td>
              <td>
                <input type="checkbox" id="chkRej" runat="server" value="2" onclick="checkBox_Onclick(this);" />
              </td>
              <%--Modify 20121114 By SS Steven. Reason: �s�W�u�h�^�v��checkbox����A������x�s�i�h�^��ML3000�A�åB�o�eEMAIL�q���~�N.--%>
              <%--Mark by Sean 2012/11/30 �B�����i�h�^--%>  
			  <td>
                <input type="checkbox" id="chkReturn" runat="server" value="3" onclick="checkBox_Onclick(this);" />
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",this)", Eval("CASEID"), Eval("CUSTID")) %>'
                  runat="server" Text="����" />
              </td>
              <td>
                <asp:Label ID="lblCASEID" runat="server" Text='<%# Eval("CASEID") %>'></asp:Label>
              </td>
              <td width="16%"><%# Eval("CUSTNAME")%>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td>
                <%#Eval("USESTATUSNM")%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td>
                <%#Eval("IRR") %>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("CASEINDATE").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("SDATE").ToString())%>
              </td>
          </AlternatingItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSave" runat="server" Text="�x�s" CssClass="btn_normal" OnClick="btnSave_Click" />
    </div>
  </div>
  </form>
</body>
</html>
