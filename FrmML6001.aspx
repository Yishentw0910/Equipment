<%--
Modify 20130416 By SS Eric    Reason:�N�ץ�֭��_���B�X�������_������J��첾�ܶi���_���B�]�ȼ��ڤ�_�����k��
Modify 20130416 By SS Eric    Reason:�N�ӧ@�覡���ܩӧ@����I�W��
Modify 20130416 By SS Eric    Reason:�N���İϤ���������
Modify 20130416 By SS Eric    Reason:�N�ӧ@�覡�w�]���y�M���z�令�w�]���y�����z
Modify 20130416 By SS Eric    Reason:�NGRID�~�N�B���y������[�e
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6001.aspx.cs" Inherits="FrmML6001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <link rel="stylesheet" href="css/rent.css" />

  <script type="text/javascript">
    <!-- #Include file='js/ML6001.js' -->                   
  </script>

</head>
<body>
  <form id="form1" runat="server" onkeydown="body_OnKeyDown(event)">
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
    <div class="div_Info">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        
        <tr style="display:none">
          <th width="20%">
            �d�ߤ覡�G
          </th>
          <td style="width: 10%" colspan="3">
            <asp:DropDownList ID="drpQryType" runat="server" Width="35%" OnSelectedIndexChanged="drpQryType_SelectedIndexChanged"
              AutoPostBack="true">
              <asp:ListItem Value="1">�H�ץ�s���d��</asp:ListItem>
              <asp:ListItem Value="2" Selected >�H�X���s���d��</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        
        <tr>
          <th width="20%">
            ���q�O�G
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
              <asp:ListItem>�п��</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th width="20%">
            �����O�G
          </th>
          <td>
            <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th width="20%">
            �ץ�s���G
          </th>
          <td width="30%">
            <asp:TextBox ID="txtCaseID" onkeypress="OnlyNumDUCase(this);" onblur="txtCaseID_onblur(this);"
              runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
          <th width="20%">
            �X���s���G
          </th>
          <td>
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" onblur="txtCNTRNO_onblur(this);"
              runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            �~�N�G
          </th>
          <td>
            <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
            <input type="button" id="Button5" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
            <asp:TextBox ID="txtAgencyId" runat="server" CssClass="txt_normal" Style="display: none;"></asp:TextBox>
          </td>
          <td>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �Ȥ�νs�G
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
              runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
            <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �i���_���G
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
          <%--Modify 20130416 By SS Eric    Reason:�N�ץ�֭��_���B�X�������_������J��첾�ܶi���_���B�]�ȼ��ڤ�_�����k��--%>
          <th class="align_right">
            �ץ�֭��_���G
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <%--<tr>
          <th class="align_right">
            �ץ�֭��_���G
          </th>
          <td style="text-align: left;" colspan="3">
            <asp:TextBox ID="txtStartDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>--%>
        <%--<tr>
          <th class="align_right">
            �X�������_���G
          </th>
          <td style="text-align: left;" colspan="3">
            <asp:TextBox ID="txtStartDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>--%>
        <tr>
          <th class="align_right">
            �]�ȼ��ڤ�_���G
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtSTVerifDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtENVerifDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
          <%--Modify 20130416 By SS Eric    Reason:�N�ץ�֭��_���B�X�������_������J��첾�ܶi���_���B�]�ȼ��ڤ�_�����k��--%>
          <th class="align_right">
            �X�������_���G
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <%--Modify 20130416 By SS Eric    Reason:�N�ӧ@�覡���ܩӧ@����I�W��--%>
        <tr>
          <th>
            �ӧ@�覡�G
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpSOURCETYPE" runat="server">
            <%--Modify 20130416 By SS Eric    Reason:�N�ӧ@�覡�w�]���y�M���z�令�w�]���y�����z--%>
              <asp:ListItem Value="" Selected="true">����</asp:ListItem>
              <asp:ListItem Value="01">�M���</asp:ListItem>
              <asp:ListItem Value="02">�Ȧ��</asp:ListItem>
              <%--<asp:ListItem Value="01">�M���</asp:ListItem>
              <asp:ListItem Value="02">�Ȧ��</asp:ListItem>
              <asp:ListItem Value="">����</asp:ListItem>--%>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th>
            �ӧ@����I�G
          </th>
          <td>
            <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
              DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged"
              AutoPostBack="true">
            </asp:DropDownList>
          </td>
          <th>
            �ӧ@����II�G
          </th>
          <td>
            <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1"
              DataValueField="DCODE">
            </asp:DropDownList>
          </td>
        </tr>
        <%--<tr>
          <th>
            �ӧ@�覡�G
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpSOURCETYPE" runat="server">
              <asp:ListItem Value="01">�M���</asp:ListItem>
              <asp:ListItem Value="02">�Ȧ��</asp:ListItem>
              <asp:ListItem Value="">����</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>--%>
        <%--Modify 20130416 By SS Eric    Reason:�N���İϤ���������--%>
<%--        <tr>
          <th>
            ���İϤ��G
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpVALID" runat="server">
              <asp:ListItem Value="">����</asp:ListItem>
              <asp:ListItem Value="Y">����</asp:ListItem>
              <asp:ListItem Value="N">�L��</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>--%>
        <tr>
          <th>
            �ץ󪬺A�G
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpCASESTATUS" runat="server" OnSelectedIndexChanged="drpCASESTATUS_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClientClick="javascript: return cmdQuery_onClick(this);"
              OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="�M��" />
            <asp:Button ID="cmdExportExcel" runat="server" Text="�U��EXCEL" CssClass="btn_normal"
              OnClientClick="javascript: return cmdExportExcel_onClick(this);" OnClick="cmdExportExcel_Click" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="margin: 5px; overflow: auto; font-size: 9pt;">
     <%--Modify 20130416 By SS Eric    Reason:�NGRID�~�N�B���y������[�e--%>
      <table width="280%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
      <%--<table width="200%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">--%>
        <tr>
          <th>
            �i�}
          </th>
          <th>
            �ץ�/�X���s��
          </th>
          <th>
            �ץ󪬺A
          </th>
          <th>
            �Ȥ�νs
          </th>
          <th width="15%">
            �Ȥ�W��
          </th>
          <th width="11%">
            ����
          </th>
          <th width="11%">
            CR����
          </th>
          <%--Modify 20130416 By SS Eric    Reason:�NGRID�~�N�B���y������[�e--%>
          <th width="5%">
            �~�N
          </th>
          <%--<th>
            �~�N
          </th>--%>
          <th>
            CR�~�N
          </th>
          <th style="display: none;">
            �ץ�s��
          </th>
          <th width="9%">
            �ӧ@����I
          </th>
          <th width="9%">
            �ӧ@����II
          </th>
		  <th>
            ���M���
          </th>
          <%--20130124 Modify by Maureen. Reason:�s�W���y������--%>
          <%--Modify 20130416 By SS Eric    Reason:�NGRID�~�N�B���y������[�e--%>
          <%--<th>
            ���y���
          </th>--%>
          <th width="20%">
            ���y���
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:HiddenField ID="hdnCASEID" Value='<%#Eval("CASEID")%>' runat="server" />
                <input type="button" id="btnSelect" class="btn_normal" onclick="CaseClick(this,'<%#Eval("CASEID") %>','<%#Eval("CUSTID") %>','<%#Eval("CNTRNO") %>');"
                  value="����" />
              </td>
              <td style="display: ;">
		        <%# Handler(Eval("CASEID").ToString(),Eval("CNTRNO").ToString()) %>
              </td>
              <td>
                <%#Eval("STATUS")%>
              </td>
              <td>
                <%#Eval("CUSTID")%>
              </td>
              <td>
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" Style="display: none;"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("CRDEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("CREMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("SUBTYPENM")%>
              </td>
			  <td>
                <%#Eval("CLEARDATE")%>
              </td>
              <%--20130124 Modify by Maureen. Reason:�s�W���y������--%>
              <td>
                <asp:Button ID="btnFile1" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File1_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="�X�����" />
                <asp:Button ID="btnFile2" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File2_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="��O���"/>
                <asp:Button ID="btnFile3" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File3_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="�Ȥ�[�x�H���"/>
                <asp:HiddenField ID="hdnEXIST1" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST2" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST3" Value="" runat="server" />
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:HiddenField ID="hdnCASEID" Value='<%#Eval("CASEID")%>' runat="server" />
                <input type="button" id="btnSelect" class="btn_normal" onclick="CaseClick(this,'<%#Eval("CASEID") %>','<%#Eval("CUSTID") %>','<%#Eval("CNTRNO") %>');"
                  value="����" />
              </td>
              <td style="display: ;">
		        <%# Handler(Eval("CASEID").ToString(),Eval("CNTRNO").ToString()) %>
              </td>
              <td>
                <%#Eval("STATUS")%>
              </td>
              <td>
                <%#Eval("CUSTID")%>
              </td>
              <td>
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" Style="display: none;"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("CRDEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("CREMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("SUBTYPENM")%>
              </td>
			  <td>
                <%#Eval("CLEARDATE")%>
              </td>
              <%--20130124 Modify by Maureen. Reason:�s�W���y������--%>
              <td>
                <asp:Button ID="btnFile1" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File1_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="�X�����" />
                <asp:Button ID="btnFile2" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File2_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="��O���"/>
                <asp:Button ID="btnFile3" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File3_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="�Ȥ�[�x�H���"/>
                <asp:HiddenField ID="hdnEXIST1" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST2" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST3" Value="" runat="server" />
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:Repeater>
      </table>
    </div>
  </div>
  </form>
</body>
</html>
