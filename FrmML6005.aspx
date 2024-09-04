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
            業績日起迄：
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
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="javascript: return cmdQuery_onClick(this);"
              OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="清除" />
            <asp:Button ID="cmdExportExcel" runat="server" Text="下載EXCEL" CssClass="btn_normal"
              OnClientClick="javascript: return cmdExportExcel_onClick(this);" OnClick="cmdExportExcel_Click" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="margin: 5px; overflow: auto; font-size: 9pt;">
      <table width="99%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
        <tr>
          <th>
            合約編號
          </th>
          <th>
            案件狀態
          </th>
          <th>
            客戶統編
          </th>
          <th width="15%">
            客戶名稱
          </th>
          <th width="13%">
            部門
          </th>
          <th>
            業代
          </th>
          <th width="9%">
            承作類型I
          </th>
          <th width="9%">
            承作類型II
          </th>
          <th>
            IRR
          </th>
          <th>
            業績日
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <%#Eval("合約編號")%>
              </td>
              <td>
                <%#Eval("案件狀況")%>
              </td>
              <td>
                <%#Eval("客戶統編")%>
              </td>
              <td>
                <%# Eval("客戶名稱")%>
              </td>
              <td>
                <%#Eval("營業單位")%>
              </td>
              <td>
                <%#Eval("承作業務")%>
              </td>
              <td>
                <%#Eval("案件類型I")%>
              </td>
              <td>
                <%#Eval("案件類型II")%>
              </td>
              <td>
                <%#Eval("IRR")%>
              </td>
              <td>
                <%#Eval("撥款日")%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <%#Eval("合約編號")%>
              </td>
              <td>
                <%#Eval("案件狀況")%>
              </td>
              <td>
                <%#Eval("客戶統編")%>
              </td>
              <td>
                <%# Eval("客戶名稱")%>
              </td>
              <td>
                <%#Eval("營業單位")%>
              </td>
              <td>
                <%#Eval("承作業務")%>
              </td>
              <td>
                <%#Eval("案件類型I")%>
              </td>
              <td>
                <%#Eval("案件類型II")%>
              </td>
              <td>
                <%#Eval("IRR")%>
              </td>
              <td>
                <%#Eval("撥款日")%>
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
