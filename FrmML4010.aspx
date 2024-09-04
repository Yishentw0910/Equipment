<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4010.aspx.cs" Inherits="FrmML4010" %>

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
    <script language="javascript" type="text/javascript" src="js/UI.js"></script>
    <script language="javascript" type="text/javascript" src="js/ITG.js"></script>
    <script language="javascript" type="text/javascript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4010.js' -->
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
        <div class="divTitle" runat="server" style="display:none" id="divTitle">發票異動維護作業</div>
        <asp:HiddenField ID="hdnSysdate" runat="server" />
        <div class="div_Info H_50">
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr style="display:none;">
               <th style="text-align:right;width:25%;">客戶編號：</th>
               <td style="width:75%">
                 <asp:TextBox ID="txtCUSTNO" runat="server" CssClass="txt_normal"  MaxLength = "10" Width="30%"></asp:TextBox>
              </td>
            </tr>
            <tr style="display:none;">
               <th style="text-align:right;width:25%;">合約編號：</th>
               <td style="width:75%">
                 <asp:TextBox ID="txtCNTRNO" runat="server" CssClass="txt_normal"  MaxLength = "14" Width="30%"></asp:TextBox>
              </td>
            </tr>
            <tr style="display:none;">
               <th style="text-align:right;width:25%;">發票狀態：</th>
               <td style="width:75%">
                 <asp:DropDownList ID="drpPRODQRY" DataTextField="MNAME1" DataValueField="MCODE" runat="server"></asp:DropDownList>
              </td>
            </tr>
            <tr>
               <th style="text-align:right;width:25%;">發票號碼：</th>
               <td style="width:75%">
                 <asp:TextBox ID="txtINVNO" runat="server" CssClass="txt_normal"  MaxLength = "10" Width="30%"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td colspan="4" style="text-align:center;">
                 <asp:Button ID="cmdQuery" runat="server" Text="查詢" UseSubmitBehavior="true" OnClientClick="JavaScript: return cmdQuery_onClick(this);" CssClass="btn_normal" onclick="cmdQuery_Click"/>
                 <asp:Button ID="cmdClear" runat="server" Text="清除" CssClass="btn_normal" OnClientClick="Javascript: return cmdClear_onClick(this);" OnClick="cmdClear_Click"/>
              </td>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow:auto;margin:10px;">
           <table width="135%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo" style="margin:4px;" onkeydown="tabQryResultInfo_onkeydown(event);">
             <tr>
               <th>發票號碼</th>
               <th>發票日期</th>
               <th>狀態</th>
               <th>處理日期</th>
               <th>發票統編</th>
               <th>發票抬頭</th>
               <th>合約編號</th>
               <th>品名</th>
               <th>銷售額</th>
               <th>稅額</th>
               <th>銷售合計</th>
               <th>期數</th>
             </tr>
             <asp:Repeater ID="rptData" runat="server">
              <ItemTemplate>
               <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                     <td><%#Eval("INVNO")%>
                     <asp:HiddenField ID="hdnINVNO" Value='<%# Eval("INVNO") %>' runat="server" />
                     <asp:HiddenField ID="hdnPREINVID" Value='<%# Eval("PREINVID") %>' runat="server" />
                     </td>
                     <td><%#Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%></td>
                     <td><asp:DropDownList ID="drpPROD" DataTextField="MNAME1" DataValueField="MCODE" onchange="drpPROD_onchange(this);" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" Style="display:none;"  OnClientClick='<%# String.Format("return CaseClick(\"{0}\",this)", Eval("INVNO")) %>' Width="95%" runat="server" Text="折讓輸入" />
                        <asp:Button ID="btnDisselect" CssClass="btn_normal" Style="display:none;"  OnClientClick='<%# String.Format("return CaseClick(\"{0}\",this)", Eval("INVNO")) %>' Width="95%" runat="server" Text="取消輸入" />
                        <asp:HiddenField ID="hdnPROD" Value='<%# Eval("PROD_OLD") %>' runat="server" />
                        <asp:HiddenField ID="hdnMainType" Value='<%# Eval("MAINTYPE") %>' runat="server" /><asp:HiddenField ID="hdnSUMMARY" Value='<%# Eval("SUMMARY") %>' runat="server" /><asp:HiddenField ID="hdnINVGRPCNT" Value='<%# Eval("INVGRPCNT") %>' runat="server" /><asp:HiddenField ID="hdnOPENMONTH" Value='<%# Eval("OPENMONTH") %>' runat="server" /></td>
                     <td><asp:Label ID="spanPDATE"  Text='<%# Eval("PDATE")%>' style="display:;" runat="server"></asp:Label><asp:TextBox ID="txtPDATE"  onfocus="txtPDATE_onFocus(this);"  onblur="txtPDATE_onBlur(this);"  Text='<%#Eval("PDATE1")%>'  CssClass="txt_table" style="width:95%;display:none;" runat="server"></asp:TextBox></td>
                     <td><%#Eval("CUSTID")%></td>
                     <td><%#Eval("INVTITLE")%></td>
                     <td><%#Eval("CNTRNO")%></td>
                     <td><%#Eval("INVDESC")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT")).ToString("##,##0")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("TAX")).ToString("##,##0")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("SUMMARY")).ToString("##,##0")%></td>
                     <td><%#Eval("ISSUE") %></td>
               </tr>
             </ItemTemplate>
             <AlternatingItemTemplate>
                 <tr style=" background-color:#E5E5E5" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                     <td><%#Eval("INVNO")%>
                     <asp:HiddenField ID="hdnINVNO" Value='<%# Eval("INVNO") %>' runat="server" />
                     <asp:HiddenField ID="hdnPREINVID" Value='<%# Eval("PREINVID") %>' runat="server" />
                     </td>
                     <td><%#Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%></td>
                     <td><asp:DropDownList ID="drpPROD" DataTextField="MNAME1" DataValueField="MCODE" onchange="drpPROD_onchange(this);" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" Style="display:none;"  OnClientClick='<%# String.Format("return CaseClick(\"{0}\",this)", Eval("INVNO")) %>' Width="95%" runat="server" Text="折讓輸入" />
                        <asp:Button ID="btnDisselect" CssClass="btn_normal" Style="display:none;"  OnClientClick='<%# String.Format("return CaseClick(\"{0}\",this)", Eval("INVNO")) %>' Width="95%" runat="server" Text="取消輸入" />
                        <asp:HiddenField ID="hdnPROD" Value='<%# Eval("PROD_OLD") %>' runat="server" />
                        <asp:HiddenField ID="hdnMainType" Value='<%# Eval("MAINTYPE") %>' runat="server" /><asp:HiddenField ID="hdnSUMMARY" Value='<%# Eval("SUMMARY") %>' runat="server" /><asp:HiddenField ID="hdnINVGRPCNT" Value='<%# Eval("INVGRPCNT") %>' runat="server" /><asp:HiddenField ID="hdnOPENMONTH" Value='<%# Eval("OPENMONTH") %>' runat="server" /></td>
                     <td><asp:Label ID="spanPDATE"  Text='<%# Eval("PDATE")%>' style="display:;" runat="server"></asp:Label><asp:TextBox ID="txtPDATE" onfocus="txtPDATE_onFocus(this);"  onblur="txtPDATE_onBlur(this);" Text='<%#Eval("PDATE1")%>'  CssClass="txt_table" style="width:95%;display:none;" runat="server"></asp:TextBox></td>
                     <td><%#Eval("CUSTID")%></td>
                     <td><%#Eval("INVTITLE")%></td>
                     <td><%#Eval("CNTRNO")%></td>
                     <td><%#Eval("INVDESC")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT")).ToString("##,##0")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("TAX")).ToString("##,##0")%></td>
                     <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("SUMMARY")).ToString("##,##0")%></td>
                     <td><%#Eval("ISSUE") %></td>
                  </tr>
               </AlternatingItemTemplate>
             </asp:Repeater>
           </table>
        </div>
       <div class="btn_div">
            <asp:Button ID="btnMdyInvo" runat="server" Text="異動確認" CssClass="btn_normal" OnClientClick="JavaScript: return btnMdyInvo_onClick(this);" OnClick="btnMdyInvo_Click"/>
       </div>
    </div>
    </form>
</body>
</html>
