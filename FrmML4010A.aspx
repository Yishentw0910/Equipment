<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4010A.aspx.cs" Inherits="FrmML4010A" %>

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
        <asp:HiddenField ID="hdnSUMMARY" Value="0" runat="server" />
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
            <div class="div_title" runat="server" style="display:none;" id="divMLDINVODETAIL">折讓發票明細資料輸入</div>
            <div class="div_title" runat="server" id="div2">本次折讓發票明細</div>
            <table class="tb_Contact" id="tabMLDINVODETAIL" style="margin:5px;" width="99%">
            <tr>
              <th style="width:13%">合約編號</th>
              <th style="width:13%">單體編號</th>
              <th style="width:10%">租金年月</th>
              <th style="width:23%">發票品名</th>
              <th style="width:17%">銷售總額</th>
              <th style="width:15%">折讓金額(未稅)</th>
              <th style="width:17%">折讓稅額</th>
            </tr>
             <asp:Repeater ID="rptMLDDISINVODETAIL" runat="server" 
                onitemcommand="rptMLDDISINVODETAIL_ItemCommand">
                  <ItemTemplate> 
            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                  <td><%#Eval("CNTRNO")%><asp:HiddenField ID="hdnINVDSEQ" Value='<%# Eval("INVDSEQ") %>' runat="server" /></td>
                  <td><%# Eval("UNITID")%></td>
                  <td><%# Eval("RENTYEARS")%></td>
                  <td><%# Eval("INVDESC")%></td>
                  <td style="text-align:right"><asp:HiddenField ID="hdnTTLSUMMARY" Value='<%# System.Convert.ToDecimal(Eval("SUMMARY")).ToString("#,##0")%>' runat="server" /><%# System.Convert.ToDecimal(Eval("SUMMARY")).ToString("#,##0")%></td>
                  <td style="text-align:right"><asp:TextBox ID="txtDISAMOUNT"  width="95%"   Text='<%# System.Convert.ToDecimal(Eval("DISAMOUNT")).ToString("#,##0")%>'  MaxLength="11" runat="server"  CssClass="txt_table_right" onkeypress="OnlyNumD(this);" onfocus="MoneyFocus(this);" onblur="txtDISAMOUNT_onBlur(this);" ></asp:TextBox></td>
		          <td style="text-align:right"><asp:TextBox ID="txtDISTAX"  width="95%"   Text='<%# System.Convert.ToDecimal(Eval("DISTAX")).ToString("#,##0")%>'  MaxLength="11" runat="server"  CssClass="txt_table_right" onkeypress="OnlyNumD(this);" onfocus="MoneyFocus(this);" onblur="txtDISTAX_onBlur(this);" ></asp:TextBox></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
            <tr>
              <td>總計</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td style="text-align:right;"><asp:Label ID="spanTTLINVSUMMARY" runat="server" Text="0"></asp:Label><asp:HiddenField ID="hdnINVSUMMARY" runat="server" /></td>
              <td style="text-align:right;"><asp:Label ID="spanDISAMOUNT" runat="server" Text="0"></asp:Label><asp:HiddenField ID="hdnALLDISAMOUNT" Value="0" runat="server" /></td>
              <td style="text-align:right;"><asp:Label ID="spanDISAMOUNTTAX" runat="server" Text="0"></asp:Label><asp:HiddenField ID="hdnALLDISAMOUNTTAX" Value="0" runat="server" /></td>
            </tr>
          </table>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="設定確認" OnClientClick="JavaScript: return btnConfirm_onClick(this);" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click" />
        </div>
            <div class="div_title" runat="server" id="div1">折讓發票明細歷程</div>
            <table class="tb_Contact" id="tabMLDINVODETAILLog" style="margin:5px;" width="99%">
            <tr>
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
                onitemcommand="rptMLDDISINVODETAIL_ItemCommand">
                  <ItemTemplate> 
            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                  <td><%#Eval("PDATE")%></td>
                  <td><%#Eval("CNTRNO")%></td>
                  <td><%# Eval("UNITID")%></td>
                  <td><%# Eval("RENTYEARS")%></td>
                  <td><%# Eval("INVDESC")%></td>
		          <td style="text-align:right"><%# System.Convert.ToDecimal(Eval("AMOUNTTAX")).ToString("#,##0")%></td>
                  <td style="text-align:right"><%# System.Convert.ToDecimal(Eval("DISAMOUNT")).ToString("#,##0")%></td>
                  <td style="text-align:right"><%# System.Convert.ToDecimal(Eval("DISTAX")).ToString("#,##0")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
            <tr>
              <td>總計</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td style="text-align:right;"><asp:HiddenField ID="hdnDISAMOUNTTTL" runat="server" /><asp:Label ID="spanDISAMOUNTTTL" runat="server" Text=""></asp:Label></td>
              <td style="text-align:right;"><asp:HiddenField ID="hdnDISAMOUNTTAXTTL" runat="server" /><asp:Label ID="spanDISAMOUNTTAXTTL" runat="server" Text="0"></asp:Label></td>
              <td style="text-align:right;"><asp:HiddenField ID="HiddenField3" runat="server" /><asp:Label ID="spanDISTAXTTL" runat="server" Text="0"></asp:Label></td>
            </tr>
          </table>
    </div>
    </form>
</body>
</html>
