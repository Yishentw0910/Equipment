<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5003.aspx.cs" Inherits="FrmML5003" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML5003.js' -->                   
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
    <div class="div_Info">
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr>
          <th class="align_right" width="20%">
            ���q�O�G
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server">
              <asp:ListItem Value="">�п��</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:�d�߱���W�[�����O--%>
          <th class="align_right" width="20%">
            �����O�G
          </th>
          <td>
            <asp:DropDownList ID="ddlDEPTID" runat="server">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            �X���s���G
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" MaxLength="14"
              CssClass="txt_normal" Width="30%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right" width="20%">
            �ȪA�I��G
          </th>
          <td>
            <asp:DropDownList ID="drpCheckDate" runat="server">
              <asp:ListItem Value="2">���I��</asp:ListItem>
              <asp:ListItem Value="">����</asp:ListItem>
              <asp:ListItem Value="1">�w�I��</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:�d�߱���W�[�ȪA�I���(�_)(��)--%>
          <th class="align_right" width="20%">
            �ȪA�I���_���G
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtCHECKDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtCHECKDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>��<asp:TextBox
                ID="txtCHECKDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtCHECKDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th class="align_right" width="20%">
            �ȪA�^��G
          </th>
          <td>
            <asp:DropDownList ID="drpReturn" runat="server">
              <asp:ListItem Value="2">���^��</asp:ListItem>
              <asp:ListItem Value="">����</asp:ListItem>
              <asp:ListItem Value="1">�w�^��</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th class="align_right" width="20%">
            �ȪA�^���_���G
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtCNTRNODATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtCNTRNODATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>��<asp:TextBox
                ID="txtCNTRNODATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtCNTRNODATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
          </td>
        </tr>
        <%--Modify 20140220 By SS Eric Reason:�d�߱���W�[�h�󪬺A--%>
        <tr>
          <th class="align_right" width="20%">
            �h�󪬺A�G
          </th>
          <td>
            <asp:DropDownList ID="ddlBACKMODE" runat="server">
              <asp:ListItem Value="">�п��</asp:ListItem>        
              <asp:ListItem Value="1">�h�󥼦^</asp:ListItem>
              <asp:ListItem Value="2">�h��w�^</asp:ListItem>
            </asp:DropDownList>
          </td>
          <%--Modify 20140220 By SS Eric Reason:�d�߱���W�[��~�B�ǻ���(�_)(��)--%>
          <th class="align_right" width="20%">
            ��~�B�ǻ���_���G
          </th>
          <td style="text-align: left;">
            <asp:TextBox ID="txtSALESDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
              onfocus="dateFocus(this)" onblur="dateBlur(this);txtSALESDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>��<asp:TextBox
                ID="txtSALESDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                onblur="dateBlur(this);txtSALESDATEChange();" CssClass="txt_normal" Width="40%"></asp:TextBox>
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
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="�M��" />
            <%--Modify 20140220 By SS Eric Reason:�s�W�U��EXCEL���s--%>
            <asp:Button ID="btnExport" runat="server" Text="�U��" CssClass="btn_normal" 
                  onclick="btnExport_Click" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
      <table cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px; width: 1250px;">
        <tr>
          <th style="width: 3%;">
            �I��
          </th>
          <th style="width: 6%;">
            �I���
          </th>
          <th style="width: 6%;">
            �i�}
          </th>
          <th style="width: 10%;">
            �X���s��
          </th>
          <th style="width: 15%;">
            �Ȥ�W��
          </th>
          <th style="width: 10%;">
            ����
          </th>
          <th style="display: none;">
            �~�N
          </th>
          <th style="width: 8%;">
            �ӧ@����
          </th>
          <th style="display: none;">
            ������A
          </th>
          <th style="width: 7%;">
            �ӧ@���B
          </th>
          <th style="width: 5%;">
            ����
          </th>
          <th style="display: none;">
            IRR
          </th>
          <th style="display: none;">
            ��I����
          </th>
          <th style="display: none;">
            �_����
          </th>
          <th style="display: none;">
            ������
          </th>
          <th style="width: 7%;">
            ���ڽT�{��
          </th>
          <th style="width: 8%;">
            �^��Ѽ�
          </th>
          <th style="width: 8%;">
            �ȪA�W���h���
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:CheckBox ID="chkcheckDate" runat="server" onClick="DOCCONFIRMClick(this,'chkcheckDate','lblRepDate')" />
                <asp:HiddenField ID="hidRETUNID" runat="server" Value='<%#Eval("RETUNID")%>' />
              </td>
              <td>
                <asp:Label ID="lblRepDate" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("RETUNCONFIRMDATE0").ToString()) %>'></asp:Label>
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="����" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align: center">
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display: none;">
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td style="display: none;">
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td style="text-align: right;">
                <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td style="display: none;">
                <%#Eval("IRR")%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("PAYDATE").ToString()) %>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:CheckBox ID="chkcheckDate" runat="server" onClick="DOCCONFIRMClick(this,'chkcheckDate','lblRepDate')" />
                <asp:HiddenField ID="hidRETUNID" runat="server" Value='<%#Eval("RETUNID")%>' />
              </td>
              <td>
                <asp:Label ID="lblRepDate" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("RETUNCONFIRMDATE0").ToString()) %>'></asp:Label>
              </td>
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID")) %>'
                  runat="server" Text="����" />
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td style="text-align: center">
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPT")%>
              </td>
              <td style="display: none;">
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td style="display: none;">
                <%#Eval("TRANSTYPENM")%>
              </td>
              <td style="text-align: right;">
                <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td style="display: none;">
                <%#Eval("IRR")%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
              </td>
              <td style="display: none;">
                <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("PAYDATE").ToString()) %>
              </td>
              <td>
                <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
              </td>
              <td>
                <%# Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
              </td>
            </tr>
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
