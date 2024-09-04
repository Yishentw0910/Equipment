<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmReject.aspx.cs"
  Inherits="FrmReject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <base target="_self" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <title>退件意見
    <%=this.LSTR_CASEID%></title>
  <link rel="stylesheet" href="css/rent.css" />

  <script type="text/javascript">
    <!-- #Include file='js/PreCondition.js' -->
  </script>

</head>
<body>
  <form id="form1" runat="server">
  <div class="div_Info4">
    <table width="90%" class="tb_Info" style="margin: 10px;">
      <tr>
        <th width="20%">
          退件意見：
        </th>
        <td>
          <asp:TextBox ID="txtCond" TextMode="MultiLine" CssClass="txt_normal" Width="300px"
            Height="100px" runat="server"></asp:TextBox>
        </td>
      </tr>
    </table>
    <div class="btn_div">
      <asp:Button ID="Button2" runat="server" Text="確定" OnClientClick="return cmdConfirm_Click();"
        CssClass="btn_normal" />
      <asp:Button ID="Button8" runat="server" Text="取消" OnClientClick="return window.close();"
        CssClass="btn_normal" />
    </div>
  </div>
  </form>
</body>
</html>
