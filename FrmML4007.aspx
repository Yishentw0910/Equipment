<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4007.aspx.cs" Inherits="FrmML4007" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    <script language="JavaScript" type="text/JavaScript" src="js/UI.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/ITG.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4007.js' -->
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
        <div class="divTitle" style="display:none;" runat="server" id="divTitle">非批次開立作業</div>
        <div class="div_Info H_130">
            <asp:HiddenField ID="hdnCLSDT01" Value="" runat="server" />
            <asp:HiddenField ID="hdnCLSDT02" Value="" runat="server" />
            <asp:HiddenField ID="hdnSystemDate" Value="0" runat="server" />
            <asp:HiddenField ID="hdnLastMonth" Value="0" runat="server" />
            <asp:HiddenField ID="hdnRowCount" Value="0" runat="server" />
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
              <th style="text-align:right;" width="25%">發票開立項目：</th>
               <td colspan="5" width="75%">
                   <%-- UPD BY HANK 20170109 查詢項目增加發票開立項目 --%>
                   <asp:DropDownList ID="drpInvType" runat="server" Width="16%">
                       <asp:ListItem Text="本體發票"></asp:ListItem>
                       <asp:ListItem Text="收入發票"></asp:ListItem>
                   </asp:DropDownList>
               </td>
            </tr>
            <tr>
              <th style="text-align:right;" width="25%">公司別：</th>
               <td  width="25%">
                   <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
                   </asp:DropDownList>
               </td>
              <th style="text-align:right;" width="16%">承作類型：</th>
               <td  width="16%">
                   <asp:DropDownList ID="drpMainType" runat="server" >
                   </asp:DropDownList>
               </td>
               <th style="text-align:right;" width="25%">預計發票開立月：</th>
               <td width="25%">
                  <asp:TextBox ID="txtInvMonth" runat="server" CssClass="txt_normal" MaxLength="7" Width="63px"></asp:TextBox>
               </td>
            </tr>
            <tr>
              <th style="text-align:right;" width="25%">發票期別選擇：</th>
               <th colspan="5" style="text-align:left" width="75%">
                   <asp:RadioButton ID="optLevel1" GroupName="optLevel" runat="server"  />首期<asp:RadioButton ID="optLevel2" GroupName="optLevel" runat="server" />不含首期<asp:RadioButton
                       ID="optLevel3" GroupName="optLevel" runat="server" />全部<asp:HiddenField ID="hdnLevel"
                           runat="server" />
               </th>
               
               
           </tr>
		   <tr>
			   <th style="text-align:right;" width="25%">合約編號：</th>
		       <td colspan="5" width="75%">
                   <asp:TextBox ID="txtCNTRNO" Width="25%" onkeypress="OnlyNumDUCase(this);" CssClass="txt_normal"  MaxLength="14" runat="server"></asp:TextBox>
				   <span style="color: Red;font-size:10pt;">&nbsp;&nbsp;如要預開單張合約的次月發票, 請務必填入</span>
               </td>
		   </tr>
           <tr>
              <th style="text-align:right;" width="25%">實際發票日期：</th>
               <td colspan="5" width="75%">
                   <asp:TextBox ID="txtINVODT" CssClass="txt_normal" MaxLength="10" ReadOnly="true" runat="server"></asp:TextBox>
               </td>
            </tr>
            <tr>
               <td colspan= "6" width="100%" style="text-align:center;">
                 <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="JavaScript: return cmdQuery_onClick(this);" Width="90"  onclick="cmdQuery_Click"/>
                 <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" UseSubmitBehavior="false" OnClientClick="cmdClear_onClick(this);" Width="90" OnClick="cmdClear_Click"/>
               </td>
            </tr>
            <tr>
               <td colspan="6" style="text-align:center;">
                   <div class="div_Info H_260" style="overflow:auto;margin:10px;display:;">
                       <table width="135%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo" style="margin:4px;" onkeydown="tabQryResultInfo_onkeydown(event);">
                         <tr>
                           <th><asp:CheckBox ID="chkAll" runat="server" /></th>
                           <th>合約編號</th>
                           <th>單體</th>
                           <th>品名</th>
                           <th>客戶統編</th>
                           <th>發票抬頭</th>
                           <th>銷售額</th>
                           <th>稅額</th>
                           <th>銷售合計</th>
                           <th>期數</th>
                         </tr>
                         <asp:Repeater ID="rptData" runat="server">
                           <ItemTemplate>
                             <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                               <td><asp:HiddenField ID="hdnPREINVID" Value="<%#Eval("PREINVID")%>" runat="server" />
                               <asp:HiddenField ID="hdnINVODT" Value="" runat="server" />
                               <asp:HiddenField ID="hdnOVERALLOPEN" Value="<%#Eval("OVERALLOPEN")%>" runat="server" />
                               <asp:HiddenField ID="hdnPREINVYYYYMM" Value="<%#Eval("PREINVYYYYMM")%>" runat="server" />
                               <asp:HiddenField ID="hdnINVDESCTYPE" Value="<%#Eval("INVDESCTYPE")%>" runat="server" />
                               <asp:HiddenField ID="hdnMAINTYPE" Value="<%#Eval("MAINTYPE")%>" runat="server" />
                               <asp:HiddenField ID="hdnORDERDAY" Value="<%#Eval("ORDERDAY")%>" runat="server" />
                               <asp:HiddenField ID="hdnCNTRNO" Value="<%#Eval("CNTRNO")%>" runat="server" />
                               <asp:HiddenField ID="hdnTARGETID" Value="<%#Eval("TARGETID")%>" runat="server" />
                                   <asp:CheckBox ID="chkCase" Checked="true" runat="server" /></td>
                               <td><%#Eval("CNTRNO")%></td>
                               <td>&nbsp;</td>
                               <td><%#Eval("INVDESC")%></td>
                               <td><%#Eval("TARGETID")%></td>
                               <td><%#Eval("INVTITLE")%></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT")).ToString("#,##0") %></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("TAX")).ToString("#,##0")%></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("SUMMARY")).ToString("#,##0")%></td>
                               <td><%#System.Convert.ToDecimal(Eval("ISSUE")).ToString("##0") %></td>
                             </tr>
                           </ItemTemplate>
                           <AlternatingItemTemplate>
                             <tr style=" background-color:#E5E5E5" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                               <td><asp:HiddenField ID="hdnPREINVID" Value="<%#Eval("PREINVID")%>" runat="server" />
                               <asp:HiddenField ID="hdnINVODT" Value="" runat="server" />
                               <asp:HiddenField ID="hdnOVERALLOPEN" Value="<%#Eval("OVERALLOPEN")%>" runat="server" />
                               <asp:HiddenField ID="hdnPREINVYYYYMM" Value="<%#Eval("PREINVYYYYMM")%>" runat="server" />
                               <asp:HiddenField ID="hdnINVDESCTYPE" Value="<%#Eval("INVDESCTYPE")%>" runat="server" />
                               <asp:HiddenField ID="hdnMAINTYPE" Value="<%#Eval("MAINTYPE")%>" runat="server" />
                               <asp:HiddenField ID="hdnORDERDAY" Value="<%#Eval("ORDERDAY")%>" runat="server" />
                               <asp:HiddenField ID="hdnCNTRNO" Value="<%#Eval("CNTRNO")%>" runat="server" />
                               <asp:HiddenField ID="hdnTARGETID" Value="<%#Eval("TARGETID")%>" runat="server" />
                                   <asp:CheckBox ID="chkCase" Checked="true" runat="server" /></td>
                               <td><%#Eval("CNTRNO")%></td>
                               <td>&nbsp;</td>
                               <td><%#Eval("INVDESC")%></td>
                               <td><%#Eval("TARGETID")%></td>
                               <td><%#Eval("INVTITLE")%></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT")).ToString("#,##0")%></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("TAX")).ToString("#,##0")%></td>
                               <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("SUMMARY")).ToString("#,##0")%></td>
                               <td><%#System.Convert.ToDecimal(Eval("ISSUE")).ToString("##0") %></td>
                            </tr>
                         </AlternatingItemTemplate>
                         </asp:Repeater>
                       </table>
                   </div>
               </td>
            </tr>
            <tr>
               <td colspan="6" style="text-align:center;">
                 <asp:Button ID="cmdProc" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="cmdProc_onClick(this);" Width="90" onclick="cmdProc_Click"/>             
                 <%--UPD BY HANK 20170926 發票列印改呼叫SSRS電子發票報表--%>
                 <%--<asp:Button ID="cmdPrint" runat="server" Text="發票列印" CssClass="btn_normal" Width="90" OnClientClick="cmdPrint_onClick(this);"/>--%>
                 <asp:Button ID="cmdPrint" runat="server" Text="發票列印" CssClass="btn_normal" Width="90" OnClick="cmdPrint_Click" />
               </td>
            </tr>
          </table>
        </div>
    </div>
    </form>
</body>
</html>
