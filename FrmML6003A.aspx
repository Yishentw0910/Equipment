<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6003A.aspx.cs" Inherits="FrmML6003A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML6003A.js' -->
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <div>
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
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
          <th width="40%">
            資料來源：
          </th>
          <td width="60%">
            <asp:DropDownList  Width="110px" ID="ddlSOURCE"  runat="server" >
            <asp:ListItem Text="全部" Value="0"/>
            <asp:ListItem Text="長租" Value="1"/>  
            <asp:ListItem Text="分期" Value="2"/>  
            <asp:ListItem Text="設備租賃" Value="3"/>  
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th width="40%">
            資料對象：
          </th>
          <td width="60%">
            <asp:DropDownList  Width="110px" ID="ddlCUST"  runat="server" >
            <asp:ListItem Text="全部" Value="0"/>
            <asp:ListItem Text="客戶" Value="1"/>  
            <asp:ListItem Text="保證人" Value="2"/>  
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th width="40%">
            客戶統編：
          </th>
          <td width="60%">
            <asp:TextBox ID="txtCustID" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal" Width="200px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th width="40%">
            客戶名稱：
          </th>
          <td width="60%">
            <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="200px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="cmdQuery_Click" />
          </th>
        </tr>
      </table>
      <%--<div class="btn_div"></div>--%>
    </div>
    <div class="div_Info4 H_260">
      <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="False" Width="98%"
        CssClass="tab_result" OnRowDataBound="grvData_RowDataBound">
        <Columns>
          <asp:BoundField DataField="CUST_NO" HeaderText="客戶統編">
            <ItemStyle Width="40%" />
          </asp:BoundField>
          <asp:BoundField DataField="CUST_NAME" HeaderText="客戶名稱" />
        </Columns>
      </asp:GridView>
    </div>
    <div class="btn_div">
      <asp:Button ID="Button5" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="return cmdConfirm_Click();" />
    </div>
  </div>
  </form>
</body>
</html>
