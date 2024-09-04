<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6002.aspx.cs" Inherits="FrmML6002" %>

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

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML6002.js' -->                   
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
          <th class="align_right" width="20%">
            承作類型I：
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
              DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged"
              AutoPostBack="true">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right" width="20%">
            承作類型II：
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1"
              DataValueField="DCODE">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="cmdQuery_Click" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
      <table width="98%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
        <tr>
          <th>
            承作類型I
          </th>
          <th>
            承作類型II
          </th>
          <th>
            撥款金額
          </th>
          <th>
            期數
          </th>
          <th>
            IRR
          </th>
          <th>
            有效日期起期
          </th>
          <th>
            有效日期迄期
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr>
              <td>
                <%#Eval("MNAME1")%>
                <asp:HiddenField ID="hidMCODE" Value='<%#Eval("MCODE")%>' runat="server" />
              </td>
              <td>
                <%#Eval("DNAME1")%>
                <asp:HiddenField ID="hidDCODE" Value='<%#Eval("DCODE")%>' runat="server" />
              </td>
              <td>
                <asp:TextBox ID="txtAMOUNT" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                  onblur="MoneyBlur(this);" runat="server" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("AMOUNT").ToString()) %>'
                  CssClass="txt_table_right"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCONTRACTMONTH" MaxLength="3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                  onblur="MoneyBlur(this);MoneyNull2(this);" runat="server" Text='<%#Eval("CONTRACTMONTH")%>'
                  CssClass="txt_table_right"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtIRR" runat="server" onkeypress="OnlyNumAndSpot(this);" onblur="CheckIRR(this);"
                  MaxLength="7" Text='<%#Eval("IRR")%>' CssClass="txt_table_right"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtEFFSDT" Text='<%# Itg.Community.Util.GetRepYear(Eval("EFFSDT").ToString())%>'
                  MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);"
                  runat="server" CssClass="txt_table"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtEFFEDT" Text='<%# Itg.Community.Util.GetRepYear(Eval("EFFEDT").ToString())%>'
                  MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkEndDate(this);"
                  runat="server" CssClass="txt_table"></asp:TextBox>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSave" runat="server" Text="儲存" Enabled="false" CssClass="btn_normal"
        OnClick="btnSave_Click" />
    </div>
  </div>
  </form>
</body>
</html>
