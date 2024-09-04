<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6005.aspx.cs" Inherits="FrmML6005" %>

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
    <!-- #Include file='js/ML6005.js' -->                   
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
        <tr>
          <th class="align_right">
            �~�Z��_���G
          </th>
          <td style="text-align: left;" colspan="3">
            <asp:TextBox ID="txtStartDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
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
      <table width="99%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
        <tr>
          <th>
            �X���s��
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
          <th width="13%">
            ����
          </th>
          <th>
            �~�N
          </th>
          <th width="9%">
            �ӧ@����I
          </th>
          <th width="9%">
            �ӧ@����II
          </th>
          <th>
            IRR
          </th>
          <th>
            �~�Z��
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <%#Eval("�X���s��")%>
              </td>
              <td>
                <%#Eval("�ץ󪬪p")%>
              </td>
              <td>
                <%#Eval("�Ȥ�νs")%>
              </td>
              <td>
                <%# Eval("�Ȥ�W��")%>
              </td>
              <td>
                <%#Eval("��~���")%>
              </td>
              <td>
                <%#Eval("�ӧ@�~��")%>
              </td>
              <td>
                <%#Eval("�ץ�����I")%>
              </td>
              <td>
                <%#Eval("�ץ�����II")%>
              </td>
              <td>
                <%#Eval("IRR")%>
              </td>
              <td>
                <%#Eval("���ڤ�")%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <%#Eval("�X���s��")%>
              </td>
              <td>
                <%#Eval("�ץ󪬪p")%>
              </td>
              <td>
                <%#Eval("�Ȥ�νs")%>
              </td>
              <td>
                <%# Eval("�Ȥ�W��")%>
              </td>
              <td>
                <%#Eval("��~���")%>
              </td>
              <td>
                <%#Eval("�ӧ@�~��")%>
              </td>
              <td>
                <%#Eval("�ץ�����I")%>
              </td>
              <td>
                <%#Eval("�ץ�����II")%>
              </td>
              <td>
                <%#Eval("IRR")%>
              </td>
              <td>
                <%#Eval("���ڤ�")%>
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
