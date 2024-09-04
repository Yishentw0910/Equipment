<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4008.aspx.cs" Inherits="FrmML4008" %>

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
    <!-- #Include file='js/ML4008.js' -->
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
        <div class="divTitle" style="display:none;" runat="server" id="divTitle">批次開立作業</div>
        <div class="div_Info">
            <asp:HiddenField ID="hdnCLSDT01" Value="" runat="server" />
            <asp:HiddenField ID="hdnCLSDT02" Value="" runat="server" />
            <asp:HiddenField ID="hdnSystemDate" runat="server" />
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
              <th style="text-align:right;" width="18%">公司別：</th>
               <td  width="16%">
                   <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
                   </asp:DropDownList>
               </td>
              <th style="text-align:right;" width="16%">承作類型：</th>
               <td  width="16%">
                   <asp:DropDownList ID="drpMainType" runat="server" Width="80%">
                   </asp:DropDownList>
               </td>
               <th style="text-align:right;" width="16%">發票年月：</th>
               <td width="18%">
                  <asp:TextBox ID="txtInvMonth" runat="server" CssClass="txt_normal" MaxLength="7" Width="63px"></asp:TextBox>
               </td>
            </tr>
            <tr>
               <th colspan= "6" style="text-align:center;">
                   <asp:Label ID="Label1" runat="server" Text="未開立發票筆數共："></asp:Label><asp:TextBox ID="txtInvRowCount" ReadOnly="true" CssClass="txt_readonly_right" Text="0" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="筆"></asp:Label>
               </th>
            </tr>
            <tr>
               <td>&nbsp;</td>
               <td colspan= "1" style="text-align:center;">
                 <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="JavaScript: return cmdQuery_onClick(this);" Width="90"  onclick="cmdQuery_Click"/>
               </td>
               <td colspan= "1"  style="text-align:center;">
                 <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" UseSubmitBehavior="false" OnClientClick="cmdClear_onClick(this);" Width="90"/>
               </td>
               <td style="text-align:center;">
                 <asp:Button ID="cmdProc" runat="server" Text="確定" CssClass="btn_normal" UseSubmitBehavior="false" OnClientClick="cmdProc_onClick(this);" Width="90" onclick="cmdProc_Click"/>             
               </td>
               <td style="text-align:center;">
                 <%--UPD BY HANK 20170926 發票列印改呼叫SSRS電子發票報表--%>
                 <%--<asp:Button ID="cmdPrint" runat="server" Text="發票列印" CssClass="btn_normal" Width="90" OnClientClick="cmdPrint_onClick(this);"/>--%>
                 <asp:Button ID="cmdPrint" runat="server" Text="發票列印" CssClass="btn_normal" Width="90" OnClick="cmdPrint_Click" />
               </td>
               <td>&nbsp;</td>
            </tr>
			<tr>
				<td colspan="6"><br><br>
                  <asp:TextBox ID="txtWriteOut" Height="300px" Width="100%" Style="word-wrap: break-word;
                    word-break: break-all;" TextMode="MultiLine" CssClass="txt_normal" runat="server" readonly></asp:TextBox>
                </td>
			</tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow:auto;margin:10px;display:none;">
             <table width="135%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo" style="margin:4px;" onkeydown="tabQryResultInfo_onkeydown(event);">
                         <tr>
                           <th><asp:CheckBox ID="chkAll" runat="server" /></th>
                           <th>合約編號</th>
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
                               <td><%#Eval("ISSUE") %></td>
                             </tr>
                           </ItemTemplate>
                           <AlternatingItemTemplate>
                             <tr style=" background-color:#E5E5E5" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                               <td><asp:HiddenField ID="hdnPREINVID" Value="<%#Eval("PREINVID")%>" runat="server" />
                               <asp:HiddenField ID="hdnINVODT" Value="" runat="server" />
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
                               <td><%#Eval("ISSUE") %></td>
                            </tr>
                         </AlternatingItemTemplate>
                 </asp:Repeater>
             </table>
        </div>
    </div>
    </form>
</body>
</html>
