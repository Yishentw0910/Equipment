<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4011.aspx.cs" Inherits="FrmML4011" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script language="JavaScript" type="text/JavaScript" src="js/UI.js"></script>

  <script language="JavaScript" type="text/JavaScript" src="js/ITG.js"></script>

  <script language="JavaScript" type="text/JavaScript" src="js/validate.js"></script>

  <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4011.js' -->
  </script>

</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
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
        <%--2011/12/21 UPD by SS Maureen 發票編號改為區間查詢 --%>
        <tr>
          <th width="25%">
            發票編號：
          </th>
          <td width="25%">
            <asp:TextBox ID="txtINVNOS" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
              Width="100px"></asp:TextBox>
            <asp:HiddenField ID="hidINVNOS" runat="server" Value="" />
            ～
            <asp:TextBox ID="txtINVNOE" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
              Width="100px"></asp:TextBox>
            <asp:HiddenField ID="hidINVNOE" runat="server" Value="" />
          </td>
        </tr>
        <%--2011/11/25 Add發票日期 by SS Maureen--%>
        <tr>
          <th width="25%">
            發票日期：
          </th>
          <td width="25%">
                <asp:TextBox ID="txtINVDATES" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                ～
                <asp:TextBox ID="txtINVDATEE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <%--2011/12/21 ADD by SS Maureen 新增發票年月欄位 --%>
        <tr>
          <th width="25%">
            發票年月：
          </th>
          <td width="25%">
                  <asp:TextBox ID="txtInvYM" runat="server" CssClass="txt_normal" MaxLength="7" Width="60px" AutoPostBack="true" OnTextChanged="txtInvYM_TextChanged"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td style="text-align: center;" colspan="4">
            <%--UPD BY HANK 20170926 發票重印作業修改，原本的列印發票改為列印發票(舊)--%>
            <%--UPD BY HANK 20171102 「列印發票(舊)」按鈕改名為「電子計算機發票列印」--%>
            <%--<asp:Button ID="cmdPrintReport" runat="server" Text="列印發票" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrint_onClick(this);" Width="90" />--%>
            <%--<asp:Button ID="cmdPrintReport" runat="server" Text="列印發票(舊)" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrint_onClick(this);" Width="90" />--%>
            <asp:Button ID="cmdPrintReport" runat="server" Text="電子計算機發票列印" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrint_onClick(this);" Width="140" />
            
            <%--Modify 20120112 By SSF Maureen. Reason: 新增清除鈕功能--%>
            <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" UseSubmitBehavior="false" OnClientClick="cmdClear_onClick(this);" Width="90" OnClick="cmdClear_Click"/>
          
            <%--ADD BY HANK 20170926 新增列印發票(新)按鈕--%>
            <%--UPD BY HANK 20171102 「列印發票(新)」按鈕改名為「電子發票列印」--%>
            <%--<asp:Button ID="cmdPrintReportNew" runat="server" Text="列印發票(新)" CssClass="btn_normal" OnClick="cmdPrintReportNew_Click"  Width="90" />--%>
            <asp:Button ID="cmdPrintReportNew" runat="server" Text="電子發票列印" CssClass="btn_normal" OnClick="cmdPrintReportNew_Click"  Width="100" />
          </td>
        </tr>
      </table>
    </div>
  </div>
  </form>
</body>
</html>
