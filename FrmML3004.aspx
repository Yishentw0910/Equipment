<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3004.aspx.cs" Inherits="FrmML3004" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML3004.js' -->                   
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
          <th class="align_right" width="25%">
            公司別：
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
              <asp:ListItem>請選擇</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th class="align_right" width="20%">
            部門別：
          </th>
          <td>
            <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
              <asp:ListItem>北一處</asp:ListItem>
              <asp:ListItem>北二處</asp:ListItem>
              <asp:ListItem>北三處</asp:ListItem>
              <asp:ListItem>桃園處</asp:ListItem>
              <asp:ListItem>中區處</asp:ListItem>
              <asp:ListItem>南區處</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            承作類型：
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpMAINTYPE" class="bg_normal" runat="server" DataTextField="MNAME1"
              DataValueField="MCODE">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            撥款申請確認日起迄：
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtStartDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
		
		<%--20121230 EDIT BY SEAN 新增預計撥款日迄日查詢條件  --%>
        <tr>
          <th class="align_right">
            預計撥款日迄日：
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtEndPayDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>

        <tr>
          <th colspan="4" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="清除" />
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_260" style="margin: 10px; overflow: auto;">
      <table width="99%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
        <tr>
          <th>
            展開
          </th>
          <th>
            合約編號
          </th>
          <th>
            客戶名稱
          </th>
          <th>
            承作部門
          </th>
          <th>
            承作類型
          </th>
          <th>
            實撥金額
          </th>
          <th>
            撥款申請日
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label>
              </td>
              <td width="25%"><%# Eval("CUSTNAME")%>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#  Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("V6DATE").ToString())%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>'
                  runat="server" Text="明細" />
              </td>
              <td>
                <asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label>
              </td>
              <td width="25%"><%# Eval("CUSTNAME")%>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#  Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>
              </td>
              <td>
                <%#  Itg.Community.Util.GetRepYear(Eval("V6DATE").ToString())%>
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
