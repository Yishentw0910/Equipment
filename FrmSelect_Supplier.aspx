<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmSelect_Supplier.aspx.cs"
  Inherits="FrmSelect_Supplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <base target="_self" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />

  <script language="javascript" src="js/UI.js"></script>

  <script type="text/javascript">
     <!-- #Include file='js/Select_Supplier.js' -->                   
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
          <hr>
        </td>
      </tr>
    </table>
    <div class="div_Info4">
      <table width="98%" cellpadding="1" cellspacing="1" class="tab_query">
        <tr>
          <th width="20%">
            供應商代碼：
          </th>
          <td width="30%">
            <asp:TextBox ID="txtSupplierID" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
          <th width="20%">
            供應商名稱：
          </th>
          <td>
            <asp:TextBox ID="txtSupplierName" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td colspan="4" style="height: 30px; text-align: center;">
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="cmdQuery_Click" />
          </td>
        </tr>
      </table>
    </div>
    <div class="div_Info4 H_260" style="overflow: auto">
      <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="False" Width="98%"
        CssClass="tab_result" OnRowDataBound="grvData_RowDataBound">
        <Columns>
          <asp:BoundField DataField="COMPID" HeaderText="供應商代碼">
            <ItemStyle Width="40%" />
          </asp:BoundField>
          <asp:BoundField DataField="COMPNM" HeaderText="供應商名稱" />
        </Columns>
      </asp:GridView>
    </div>
    <div class="btn_div">
      <asp:Button ID="Button5" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="return cmdConfirm_Click();" />
      <asp:Button ID="Button51" runat="server" Text="取消" CssClass="btn_normal" OnClientClick="return cmdExit_Click();" />
    </div>
  </div>
  </form>
</body>
</html>
