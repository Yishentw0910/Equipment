<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6003.aspx.cs" Inherits="FrmML6003" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <link rel="stylesheet" href="css/rent.css" />

  <script type="text/javascript">
    <!-- #Include file='js/ML6003.js' -->                   
  </script>

</head>
<body>
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
      <asp:HiddenField ID="hdnSysDate" runat="server" />
      <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
<tr>
          <th class="align_right">
            資料來源 
          </th>
          <td>
            <asp:DropDownList  Width="110px" ID="ddlSOURCE"  runat="server" >
            <asp:ListItem Text="全部" Value="0"/>
            <asp:ListItem Text="長租" Value="1"/>  
            <asp:ListItem Text="分期" Value="2"/>  
            <asp:ListItem Text="設備租賃" Value="3"/>  
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            資料對象
          </th>
          <td>
            <asp:DropDownList  Width="110px" ID="ddlCUST"  runat="server" >
            <asp:ListItem Text="全部" Value="0"/>  
            <asp:ListItem Text="客戶" Value="1"/>  
            <asp:ListItem Text="保證人" Value="2"/>  
            </asp:DropDownList>
          </td>
        </tr>        <tr>
          <th class="align_right">
            客戶統編：
          </th>
          <td>
            <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
              runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
            <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
          </td>
        </tr>
        <tr>
          <th class="align_right">
            截止日期：
          </th>
          <td width="75%">
               <asp:TextBox ID="txtBASEDT" CssClass="txt_normal" MaxLength="10" runat="server"></asp:TextBox>
           </td>
        </tr>
        <tr>
          <th colspan="2" style="text-align: center; height: 30px;">
            <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="javascript: return cmdQuery_onClick(this);" OnClick="cmdQuery_Click" />
            <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
              value="清除" />
            <asp:Button ID="cmdExport" runat="server" Text="EXCEL下載" CssClass="btn_normal" onclick="cmdExport_Click" Enabled="false" /> 
          </th>
        </tr>
      </table>
    </div>
    <div class="div_Info H_360" style="margin: 10px; overflow: auto;">
      <table width="1400px" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
        <tr>
          <th style="width:70px">
            撥款日期
          </th>
          <th style="width:70px">
            類型
          </th>
          <th style="width:120px">
            合約編號
          </th>
          <th style="width:240px">
            車型/承作標的
          </th>
          <th style="width:100px">
            保證金
          </th>
          <th style="width:120px">
            實貸金額
          </th>
          <th style="width:120px">
            實繳總金額
          </th>
          <th style="width:120px">
            未到期租金總額
          </th>
          <th style="width:70px">
            租期
          </th>
          <th style="width:70px">
            已繳期數
          </th>
          <th style="width:120px">
            已繳金額總額
          </th>
          <th>
            IRR
          </th>
          <th style="width:100px">
            案件關係
          </th>
          <th style="display:none;">
            合計金額
          </th>
          <th style="display:none;">
            備註
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr>
              <td>
                <%#Eval("PAYDATE")%>
              </td>
              <td>
                <%#Eval("CTYPE")%>
              </td>
              <td>
                <%#Eval("CNTRNO")%>
              </td>
              <td>
                <%#Eval("TNAME")%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("GUARAMT").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("ACTLOAN").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("ACTUSLLOANS").ToString())%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTN").ToString())%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTH")%>
              </td>
              <td>
                <%#Eval("CONTRACTMONTHY")%>
              </td>
              <td>
                <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTY").ToString())%>
              </td>
              <td>
                <%#Itg.Community.Util.NumberFormat(Eval("IRR").ToString())%> 
              </td>
              <td>
                <%#Eval("RELATIONSHIP")%>
              </td>
              <td style="display:none;">
              </t style="display:none;">
              <td>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
  </div>
  </form>
</body>
</html>
