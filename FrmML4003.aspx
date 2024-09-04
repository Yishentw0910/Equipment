<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4003.aspx.cs" Inherits="FrmML4003" %>

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
    <!-- #Include file='js/ML4003.js' -->
    </script>
</head>
<body onkeydown="body_OnKeyDown(event)" onload="page_onLoad();" onunload="JavaScript:return Page_Unload();">
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
          <hr/>
        </td>
      </tr>
    </table>
        <br>
        <asp:HiddenField ID="hdnMLDPREINVSPLITtoJSON" runat="server" />
        <asp:HiddenField ID="hdnUNITID" runat="server" />
        <asp:HiddenField ID="hdnCUSTNO" runat="server" />
        <asp:HiddenField ID="hdnCUSTNME" runat="server" />
        <asp:HiddenField ID="hdnMLDCONTRACTTARGETRowCount" runat="server" />
        <asp:HiddenField ID="hdnMLDPREINVSPLITRowCount" runat="server" />
        <BR>
        <div>
            <div class="div_title" id="divContact">合約單體資料</div>
        	<table class="tb_Contact" id="tabMLDCONTRACTTARGET" width="99%" style="margin:4px;">
		        <tr>
		          <th>合約編號</th>
		          <th>單體編號</th>
		          <th>月付款</th>
		        </tr>
		         <asp:Repeater ID="rptMLDCONTRACTTARGET" runat="server">
                  <ItemTemplate> 
		        <tr>
 	            <td><%#Eval("CNTRNO")%></td>
		          <td><%#Eval("TARGETID")%></td>
		          <td style="text-align:right"><%#Eval("MONTHPAY")%></td>
		        </tr>
		        </ItemTemplate>
           </asp:Repeater>
		        <tr>
		          <td>總計</td>
		          <td>&nbsp;</td>
		          <td style="text-align:right"><asp:Label ID="spanMONTHPAYTTL" runat="server" Text="0"></asp:Label><asp:HiddenField ID="hdnMONTHPAYTTL" runat="server" /></td>
		        </tr>
            </table>
            <div class="div_title" id="divMLDPREINVSPLIT">拆發票設定&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #990000"> [ 新增請按F8　刪除請按F9 ] </span></div>
            <asp:HiddenField ID="hdnSelectedRow" runat="server" />
            <table class="tb_Contact" id="tabMLDPREINVSPLIT" style="margin:5px;" width="99%">
            <tr>
              <th style="width:7%">發票群組</th>
              <th style="width:10%">對象統編</th>
              <th style="width:13%">對象抬頭</th>
              <th style="width:10%;">單體編號</th>
              <th style="width:7%">月付款</th>
              <th style="width:53%">寄送地址</th>
            </tr>
             <asp:Repeater ID="rptMLDPREINVSPLIT" runat="server" 
                onitemcommand="rptMLDPREINVSPLIT_ItemCommand">
                  <ItemTemplate> 
            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                  <td style="width:7%"><asp:TextBox ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this,'100');" onkeypress="OnlyUCase(this);" CssClass="txt_table" ></asp:TextBox>
                  <td style="width:10%;text-align:left"><asp:TextBox ID="txtTARGETID"  width="95%"   Text='<%# Eval("TARGETID")%>'  MaxLength="10" runat="server" onblur="txtTARGETID_onBlur(this);" CssClass="txt_table" ></asp:TextBox>
                  <td style="width:13%;text-align:left"><asp:TextBox ID="txtTARGETNAME"  width="95%"   Text='<%# Eval("TARGETNAME")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this,'100');" CssClass="txt_table" ></asp:TextBox>
                  <td style="width:10%;"><asp:TextBox ID="txtUNITID"  width="95%"   Text='<%# Eval("UNITID")%>'  MaxLength="17" runat="server" onblur="txtUNITID_onBlur(this);" CssClass="txt_table" ></asp:TextBox>
                  <td style="width:7%;text-align:right"><asp:TextBox ID="txtMONTHPAY"  width="95%"   Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY")).ToString("#,##0")%>'  MaxLength="11" runat="server"  CssClass="txt_table_right" onkeypress="OnlyNumD(this);" onfocus="MoneyFocus(this);" onblur="txtMONTHPAY_onBlur(this);" ></asp:TextBox>
		          <td style="width:53%;text-align:left"><asp:TextBox ID="txtINVZIPCODE"  width="10%"   Text='<%# Eval("INVZIPCODE")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" onblur="PostCodeBlure(this)" CssClass="txt_table" ></asp:TextBox>
                  <input type="button" id="btnINVZIPCODE" class="btn_normal" onclick="PostCodeClick(this);"  style="width:25px;padding:2px;" value="&#8230;" />
		          <asp:TextBox ID="txtINVZIPCODES"  width="20%"   Text='<%# Eval("INVZIPCODES")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" onblur="PostCodeBlure(this)"  CssClass="txt_table" ></asp:TextBox>
                  <asp:TextBox ID="txtINVOICEADDR"  width="59%"   Text='<%# Eval("INVOICEADDR")%>'  runat="server" CssClass="txt_table" MaxLength="100"  onblur="CheckMLength(this,'100');"  ></asp:TextBox></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
            <tr>
              <td style="width:7%">總計</td>
              <td style="width:10%">&nbsp;</td>
              <td style="width:13%">&nbsp;</td>
              <td style="width:10%;">&nbsp;</td>
              <td style="width:7%;text-align:right;"><asp:Label ID="spanSPLTMONTHPAYTTL" runat="server" Text="0"></asp:Label><asp:HiddenField ID="hdnSPLTMONTHPAYTTL" Value="0" runat="server" /></td>
              <td style="width:53%">&nbsp;</td>
            </tr>
          </table>
        </div>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="設定確認" Enabled="false" OnClientClick="JavaScript: return btnConfirm_onClick(this);" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click" />
        </div>
        <asp:DropDownList ID="drpCODE" style="display:none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
          <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
          <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
       <div class="btn_div">
        <asp:DropDownList ID="DropDownList1" style="display:none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
       </div>          
    </div>
    </form>
</body>
</html>
