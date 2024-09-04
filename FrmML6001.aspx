<%--
Modify 20130416 By SS Eric    Reason:將案件核准日起迄、合約到期日起迄的輸入欄位移至進件日起迄、財務撥款日起迄的右方
Modify 20130416 By SS Eric    Reason:將承作方式移至承作類型I上方
Modify 20130416 By SS Eric    Reason:將有效區分的欄位取消
Modify 20130416 By SS Eric    Reason:將承作方式預設為『和潤件』改成預設為『全部』
Modify 20130416 By SS Eric    Reason:將GRID業代、掃描文件欄位加寬
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6001.aspx.cs" Inherits="FrmML6001" %>

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
    <!-- #Include file='js/ML6001.js' -->                   
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
        
        <tr style="display:none">
          <th width="20%">
            查詢方式：
          </th>
          <td style="width: 10%" colspan="3">
            <asp:DropDownList ID="drpQryType" runat="server" Width="35%" OnSelectedIndexChanged="drpQryType_SelectedIndexChanged"
              AutoPostBack="true">
              <asp:ListItem Value="1">以案件編號查詢</asp:ListItem>
              <asp:ListItem Value="2" Selected >以合約編號查詢</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        
        <tr>
          <th width="20%">
            公司別：
          </th>
          <td width="30%">
            <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
              <asp:ListItem>請選擇</asp:ListItem>
            </asp:DropDownList>
          </td>
          <th width="20%">
            部門別：
          </th>
          <td>
            <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th width="20%">
            案件編號：
          </th>
          <td width="30%">
            <asp:TextBox ID="txtCaseID" onkeypress="OnlyNumDUCase(this);" onblur="txtCaseID_onblur(this);"
              runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
          <th width="20%">
            合約編號：
          </th>
          <td>
            <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" onblur="txtCNTRNO_onblur(this);"
              runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            業代：
          </th>
          <td>
            <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
            <input type="button" id="Button5" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
            <asp:TextBox ID="txtAgencyId" runat="server" CssClass="txt_normal" Style="display: none;"></asp:TextBox>
          </td>
          <td>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <th class="align_right">
            客戶統編：
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
              runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
            <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
              padding: 2px;" value="&#8230;" />
          </td>
        </tr>
        <tr>
          <th class="align_right">
            進件日起迄：
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
          <%--Modify 20130416 By SS Eric    Reason:將案件核准日起迄、合約到期日起迄的輸入欄位移至進件日起迄、財務撥款日起迄的右方--%>
          <th class="align_right">
            案件核准日起迄：
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <%--<tr>
          <th class="align_right">
            案件核准日起迄：
          </th>
          <td style="text-align: left;" colspan="3">
            <asp:TextBox ID="txtStartDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate5" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>--%>
        <%--<tr>
          <th class="align_right">
            合約到期日起迄：
          </th>
          <td style="text-align: left;" colspan="3">
            <asp:TextBox ID="txtStartDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>--%>
        <tr>
          <th class="align_right">
            財務撥款日起迄：
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtSTVerifDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtENVerifDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
          <%--Modify 20130416 By SS Eric    Reason:將案件核准日起迄、合約到期日起迄的輸入欄位移至進件日起迄、財務撥款日起迄的右方--%>
          <th class="align_right">
            合約到期日起迄：
          </th>
          <td style="text-align: left;" colspan="1">
            <asp:TextBox ID="txtStartDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
            -
            <asp:TextBox ID="txtEndDate9" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
              onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
          </td>
        </tr>
        <%--Modify 20130416 By SS Eric    Reason:將承作方式移至承作類型I上方--%>
        <tr>
          <th>
            承作方式：
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpSOURCETYPE" runat="server">
            <%--Modify 20130416 By SS Eric    Reason:將承作方式預設為『和潤件』改成預設為『全部』--%>
              <asp:ListItem Value="" Selected="true">全部</asp:ListItem>
              <asp:ListItem Value="01">和潤件</asp:ListItem>
              <asp:ListItem Value="02">銀行件</asp:ListItem>
              <%--<asp:ListItem Value="01">和潤件</asp:ListItem>
              <asp:ListItem Value="02">銀行件</asp:ListItem>
              <asp:ListItem Value="">全部</asp:ListItem>--%>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <th>
            承作類型I：
          </th>
          <td>
            <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
              DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged"
              AutoPostBack="true">
            </asp:DropDownList>
          </td>
          <th>
            承作類型II：
          </th>
          <td>
            <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1"
              DataValueField="DCODE">
            </asp:DropDownList>
          </td>
        </tr>
        <%--<tr>
          <th>
            承作方式：
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpSOURCETYPE" runat="server">
              <asp:ListItem Value="01">和潤件</asp:ListItem>
              <asp:ListItem Value="02">銀行件</asp:ListItem>
              <asp:ListItem Value="">全部</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>--%>
        <%--Modify 20130416 By SS Eric    Reason:將有效區分的欄位取消--%>
<%--        <tr>
          <th>
            有效區分：
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpVALID" runat="server">
              <asp:ListItem Value="">全部</asp:ListItem>
              <asp:ListItem Value="Y">有效</asp:ListItem>
              <asp:ListItem Value="N">無效</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>--%>
        <tr>
          <th>
            案件狀態：
          </th>
          <td colspan="3">
            <asp:DropDownList ID="drpCASESTATUS" runat="server" OnSelectedIndexChanged="drpCASESTATUS_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
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
     <%--Modify 20130416 By SS Eric    Reason:將GRID業代、掃描文件欄位加寬--%>
      <table width="280%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
      <%--<table width="200%" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">--%>
        <tr>
          <th>
            展開
          </th>
          <th>
            案件/合約編號
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
          <th width="11%">
            部門
          </th>
          <th width="11%">
            CR部門
          </th>
          <%--Modify 20130416 By SS Eric    Reason:將GRID業代、掃描文件欄位加寬--%>
          <th width="5%">
            業代
          </th>
          <%--<th>
            業代
          </th>--%>
          <th>
            CR業代
          </th>
          <th style="display: none;">
            案件編號
          </th>
          <th width="9%">
            承作類型I
          </th>
          <th width="9%">
            承作類型II
          </th>
		  <th>
            結清日期
          </th>
          <%--20130124 Modify by Maureen. Reason:新增掃描文件欄位--%>
          <%--Modify 20130416 By SS Eric    Reason:將GRID業代、掃描文件欄位加寬--%>
          <%--<th>
            掃描文件
          </th>--%>
          <th width="20%">
            掃描文件
          </th>
        </tr>
        <asp:Repeater ID="rptData" runat="server">
          <ItemTemplate>
            <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:HiddenField ID="hdnCASEID" Value='<%#Eval("CASEID")%>' runat="server" />
                <input type="button" id="btnSelect" class="btn_normal" onclick="CaseClick(this,'<%#Eval("CASEID") %>','<%#Eval("CUSTID") %>','<%#Eval("CNTRNO") %>');"
                  value="明細" />
              </td>
              <td style="display: ;">
		        <%# Handler(Eval("CASEID").ToString(),Eval("CNTRNO").ToString()) %>
              </td>
              <td>
                <%#Eval("STATUS")%>
              </td>
              <td>
                <%#Eval("CUSTID")%>
              </td>
              <td>
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" Style="display: none;"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("CRDEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("CREMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("SUBTYPENM")%>
              </td>
			  <td>
                <%#Eval("CLEARDATE")%>
              </td>
              <%--20130124 Modify by Maureen. Reason:新增掃描文件欄位--%>
              <td>
                <asp:Button ID="btnFile1" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File1_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="合約文件" />
                <asp:Button ID="btnFile2" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File2_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="擔保文件"/>
                <asp:Button ID="btnFile3" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File3_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="客戶暨徵信資料"/>
                <asp:HiddenField ID="hdnEXIST1" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST2" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST3" Value="" runat="server" />
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
              onclick="MouseDown(event);">
              <td>
                <asp:HiddenField ID="hdnCASEID" Value='<%#Eval("CASEID")%>' runat="server" />
                <input type="button" id="btnSelect" class="btn_normal" onclick="CaseClick(this,'<%#Eval("CASEID") %>','<%#Eval("CUSTID") %>','<%#Eval("CNTRNO") %>');"
                  value="明細" />
              </td>
              <td style="display: ;">
		        <%# Handler(Eval("CASEID").ToString(),Eval("CNTRNO").ToString()) %>
              </td>
              <td>
                <%#Eval("STATUS")%>
              </td>
              <td>
                <%#Eval("CUSTID")%>
              </td>
              <td>
                <%# Eval("CUSTNAME")%>
                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" Style="display: none;"
                  ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
              </td>
              <td>
                <%#Eval("DEPTIDNM")%>
              </td>
              <td>
                <%#Eval("CRDEPTIDNM")%>
              </td>
              <td>
                <%#Eval("EMPLNM")%>
              </td>
              <td>
                <%#Eval("CREMPLNM")%>
              </td>
              <td>
                <%#Eval("MAINTYPENM")%>
              </td>
              <td>
                <%#Eval("SUBTYPENM")%>
              </td>
			  <td>
                <%#Eval("CLEARDATE")%>
              </td>
              <%--20130124 Modify by Maureen. Reason:新增掃描文件欄位--%>
              <td>
                <asp:Button ID="btnFile1" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File1_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="合約文件" />
                <asp:Button ID="btnFile2" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File2_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="擔保文件"/>
                <asp:Button ID="btnFile3" runat="server" CssClass="btn_normal" OnClientClick='<%# String.Format("return File3_Click(this,\"{0}\",\"{1}\",\"{2}\")",Eval("CASEID"),Eval("RENTYEAR"),Eval("CNTRNO")) %>'
                  Text="客戶暨徵信資料"/>
                <asp:HiddenField ID="hdnEXIST1" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST2" Value="" runat="server" />
                <asp:HiddenField ID="hdnEXIST3" Value="" runat="server" />
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
