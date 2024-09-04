<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4010B.aspx.cs" Inherits="FrmML4010B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <base target="_self"  />
    <meta http-equiv=Content-Type content="text/html; charset=big5">
    <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv=Pragma content=no-cache>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />
    <script language="javascript" type="text/javascript" src="js/UI.js"></script>
    <script language="javascript" type="text/javascript" src="js/ITG.js"></script>
    <script language="javascript" type="text/javascript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4010A.js' -->
    </script>
</head>
<body onkeydown="body_OnKeyDown(event)" onload="page_onLoad();">
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hdnINVNO" runat="server" />
        <asp:HiddenField ID="hdnPDATE" Value="" runat="server" />
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
            <div class="div_title" runat="server" style="display:none;" id="divMLDINVODETAIL">折讓取消明細資料輸入</div>
            <div class="div_title" runat="server" id="div1">折讓發票明細</div>
            <table class="tb_Contact" id="tabMLDINVODETAILLog" style="margin:5px;" width="99%">
            <tr>
              <th style="width:4%"></th>
              <th style="width:10%">折讓日期</th>
              <th style="width:11%">合約編號</th>
              <th style="width:11%">單體編號</th>
              <th style="width:8%">租金年月</th>
              <th style="width:21%">發票品名</th>
              <th style="width:15%">折讓總額</th>
              <th style="width:13%">折讓金額(未稅)</th>
              <th style="width:15%">折讓稅額</th>
            </tr>
             <asp:Repeater ID="rptMLDDISINVODETAILLog" runat="server" 
                onitemcommand="rptMLDDISINVODETAILLog_ItemCommand">
                  <ItemTemplate> 
            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                  <td><asp:RadioButton ID="optSelect" onclick="optSelect_onclick(this);" GroupName="INVDSEQ" Checked="false" runat="server" /><asp:HiddenField ID="hdnOptValue" Value="0" runat="server" /><asp:HiddenField ID="hdnINVDSEQ" Value='<%#Eval("INVDSEQ")%>' runat="server" /><asp:HiddenField ID="hdnPDATE" Value='<%# Eval("PDATE") %>' runat="server" /></td>
                  <td><%#Eval("PDATE")%></td>
                  <td><%#Eval("CNTRNO")%></td>
                  <td><%# Eval("UNITID")%></td>
                  <td><%# Eval("RENTYEARS")%></td>
                  <td><%# Eval("INVDESC")%></td>
		          <td style="text-align:right"><asp:HiddenField ID="hdnAMOUNTTAX" Value='<%# Eval("AMOUNTTAX") %>' runat="server" /><%# System.Convert.ToDecimal(Eval("AMOUNTTAX")).ToString("#,##0")%></td>
                  <td style="text-align:right"><%# System.Convert.ToDecimal(Eval("DISAMOUNT")).ToString("#,##0")%></td>
                  <td style="text-align:right"><%# System.Convert.ToDecimal(Eval("DISTAX")).ToString("#,##0")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
          </table>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="設定確認" OnClientClick="JavaScript: return btnConfirm_onClick(this);" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click" />
        </div>
        </div>
    </form>
</body>
</html>
