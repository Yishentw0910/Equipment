<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6006.aspx.cs" Inherits="FrmML6006" %>

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
    <!-- #Include file='js/ML6006.js' -->                   
  </script>

</head>
<body onload="window_onload();">
  <form id="form1" runat="server" onkeydown="body_OnKeyDown(event)">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
    <ContentTemplate>
      <div class="divBody">
        <asp:HiddenField ID="hidShowTag" runat="server" Value="1" />
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
              <th width="20%">
                報表種類：
              </th>
              <td style="width: 80%" colspan="3">
                <asp:DropDownList ID="drpQryType" runat="server" Width="35%">
                  <asp:ListItem Value="">請選擇</asp:ListItem>
                  <asp:ListItem Value="1" Selected>明細表</asp:ListItem>
                  <asp:ListItem Value="2">統計表</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <tr>
                <th class="align_right">
                  統計日期：
                </th>
                <td style="text-align: left;" colspan="3">
                  <asp:TextBox ID="txtStartDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                    onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                  -
                  <asp:TextBox ID="txtEndDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                    onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th class="align_right">
                  供應商：
                </th>
                <td colspan="3">
                  <asp:TextBox ID="txtSipplierId" MaxLength="10" onkeypress="OnlyNumDUCase(this);"
                    onblur="txtSipplierId_onblur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                  <asp:TextBox ID="txtSipplierName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                  <input type="Button" id="btnSipplierId" class="btn_normal" onclick="SupplierClick();"
                    style="width: 25px; padding: 2px;" value="&#8230;" />
                </td>
              </tr>
              <tr>
                <th class="align_right">
                  部門別：
                </th>
                <td colspan="3">
                  <asp:DropDownList ID="drpDeptID" runat="server" Width="20%">
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
                <th>
                  承案業代：
                </th>
                <td colspan="3">
                  <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="20%"></asp:TextBox>
                  <input type="button" id="Button5" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
                    padding: 2px;" value="&#8230;" />
                  <asp:TextBox ID="txtAgencyId" runat="server" CssClass="txt_normal" Style="display: none;"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th colspan="4" style="text-align: center; height: 30px;">
                  <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="javascript: return cmdQuery_onClick(this);"
                    OnClick="cmdQuery_Click" />
                  <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" OnClientClick="return cmdClear_onclick(this)"
                    OnClick="cmdClear_onclick" />
                  <asp:Button ID="cmdExportExcel" runat="server" Text="下載EXCEL" CssClass="btn_normal"
                    OnClientClick="javascript: return cmdExportExcel_onClick(this);" OnClick="cmdExportExcel_Click" />
                </th>
              </tr>
          </table>
        </div>
        <asp:UpdatePanel ID="UpdatePanelDate" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div id="divData1" class="div_Info H_260" style="overflow: auto; margin: 10px; display: none">
              <table id="tabQueryDate1" cellpadding="0" cellspacing="0" class="tab_result" width="205%"
                style="margin: 4px;">
                <tr>
                  <th rowspan="2">
                    合約編號
                  </th>
                  <th rowspan="2">
                    客戶統編
                  </th>
                  <th rowspan="2">
                    客戶名稱
                  </th>
                  <th rowspan="2">
                    營業單位
                  </th>
                  <th rowspan="2">
                    承案業代
                  </th>
                  <th colspan="4">
                    供應商
                  </th>
                  <th rowspan="2">
                    存款金額
                  </th>
                  <th rowspan="2">
                    借款金額
                  </th>
                </tr>
                <tr>
                  <th>
                    統一編號
                  </th>
                  <th>
                    公司名稱
                  </th>
                  <th>
                    業代ID
                  </th>
                  <th>
                    業代姓名
                  </th>
                </tr>
                <asp:Repeater ID="rptData1" runat="server">
                  <ItemTemplate>
                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <%# Eval("CNTRNO")%>
                      </td>
                      <td>
                        <%# Eval("CUSTID")%>
                      </td>
                      <td width="25%">
                        <%# Eval("CUSTNAME")%>
                      </td>
                      <td>
                        <%# Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%# Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%# Eval("DSUPPLIER")%>
                      </td>
                      <td width="25%">
                        <%# Eval("SUPPLIERIDS")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALE")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALENM")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT0")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT1")%>
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <%# Eval("CNTRNO")%>
                      </td>
                      <td>
                        <%# Eval("CUSTID")%>
                      </td>
                      <td width="25%">
                        <%# Eval("CUSTNAME")%>
                      </td>
                      <td>
                        <%# Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%# Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%# Eval("DSUPPLIER")%>
                      </td>
                      <td width="25%">
                        <%# Eval("SUPPLIERIDS")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALE")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALENM")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT0")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT1")%>
                      </td>
                    </tr>
                  </AlternatingItemTemplate>
                </asp:Repeater>
              </table>
            </div>
            <div id="divData2" class="div_Info H_260" style="overflow: auto; margin: 10px; display: none">
              <table id="tabQueryDate2" cellpadding="0" cellspacing="0" class="tab_result" width="205%"
                style="margin: 4px;">
                <tr>
                  <th colspan="4">
                    供應商
                  </th>
                  <th rowspan="2">
                    營業單位
                  </th>
                  <th rowspan="2">
                    承案業代
                  </th>
                  <th rowspan="2">
                    存款金額
                  </th>
                  <th rowspan="2">
                    借款金額
                  </th>
                  <th rowspan="2">
                    合計
                  </th>
                </tr>
                <tr>
                  <th>
                    統一編號
                  </th>
                  <th>
                    公司名稱
                  </th>
                  <th>
                    業代ID
                  </th>
                  <th>
                    業代姓名
                  </th>
                </tr>
                <asp:Repeater ID="rptData2" runat="server">
                  <ItemTemplate>
                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <%# Eval("DSUPPLIER")%>
                      </td>
                      <td width="25%">
                        <%# Eval("SUPPLIERIDS")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALE")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALENM")%>
                      </td>
                      <td>
                        <%# Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%# Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT0")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT1")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT")%>
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                        <%# Eval("DSUPPLIER")%>
                      </td>
                      <td width="25%">
                        <%# Eval("SUPPLIERIDS")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALE")%>
                      </td>
                      <td>
                        <%# Eval("SUPPLIERSALENM")%>
                      </td>
                      <td>
                        <%# Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%# Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT0")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT1")%>
                      </td>
                      <td>
                        <%# Eval("DEPOSITLOANSAMOUNT")%>
                      </td>
                    </tr>
                  </AlternatingItemTemplate>
                </asp:Repeater>
              </table>
            </div>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
