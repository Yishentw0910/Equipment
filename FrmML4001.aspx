<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4001.aspx.cs" Inherits="FrmML4001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
   <base target="_self"  />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv=Content-Type content="text/html; charset=big5">
    <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv=Pragma content=no-cache>
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />
    <script language="javascript" type="text/javascript" src="js/UI.js"></script>
    <script language="javascript" type="text/javascript" src="js/ITG.js"></script>
    <script language="javascript" type="text/javascript" src="js/validate.js"></script>
    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4001.js' --> 
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
          <hr/>
        </td>
      </tr>
    </table>
        <br>
        <div class="divTitle" runat="server" style="display:none;" id="divTitle" >發票及繳款方式維護查詢</div>
        <div class="div_Info H_130">
          <table width="100%" cellpadding="1" cellspacing="1" id="tabQryCond" class="tab_query">
            <tr>
              <th style="width:25%">公司別：</th>
               <td style="width:25%">
                   <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
                     <asp:ListItem Value="">請選擇</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td>&nbsp;
               </td>
               <td>&nbsp;
               </td>
            </tr>
            <tr>
               <th style="width:25%">部門別：</th>
               <td style="width:25%">
                    <asp:DropDownList ID="drpDeptID" runat="server" >
                     <asp:ListItem Value="">請選擇</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <th  style="width:25%">業代名：</th>
               <td  style="width:25%">
                  <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
                <input type="button" id="btnAgency" class="btn_normal" onclick="AgencyClick();" style="width:25px;padding:2px;" value="&#8230;" /> 
               </td>
            </tr>
            <tr>
               <th  style="width:25%">合約編號：</th>
               <td  style="width:25%"><asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" Width="90%" CssClass="txt_normal" Text="" MaxLength="14"></asp:TextBox></td>
               <th  style="width:25%">財務撥款確認日起迄：</th>
               <td  style="width:25%">
                  <asp:TextBox ID="txtStartDate" runat="server" CssClass="txt_normal" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" MaxLength="10" Width="80px"></asp:TextBox>
                  -
                  <asp:TextBox ID="txtEndDate" runat="server" CssClass="txt_normal" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" MaxLength="10" Width="80px"></asp:TextBox>
               </td>
            </tr>
            <tr>
               <th>客戶統編：</th>
               <td colspan="3">
                 <asp:TextBox ID="txtCustID" runat="server" CssClass="txt_normal" Width="30%"></asp:TextBox>
                <input type="button" id="Button5" class="btn_normal" onclick="CustomerClick();" style="width:25px;padding:2px;" value="&#8230;" /> 
                   <asp:Label ID="spanCustNme" runat="server" Text=""></asp:Label>
              </td>
            </tr>
            <tr>
              <th colspan="4" style="text-align:center;height:30px;">
                 <asp:Button ID="cmdQuery" runat="server" Text="查詢" UseSubmitBehavior="true" OnClientClick="JavaScript: return cmdQuery_onClick(this);" CssClass="btn_normal" onclick="cmdQuery_Click"/>
              </th>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" id="divrptData" style="overflow:auto;margin:10px;">
           <table width="98%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo" style="margin:4px;">
             <tr>
               <th width="5%">展開</th>
               <th width="18%">合約編號</th>
               <th width="25%">客戶名稱</th>
               <th width="15%">承作部門</th>
               <th width="10%">承作類型</th>
               <th width="10%">承作金額</th>
               <th width="5%">期數</th>
               <th width="12%">財務確認日</th>
             </tr>
             <asp:Repeater ID="rptData" runat="server">
              <ItemTemplate>
               <tr class="singleline"  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                 <td>
                     <asp:Button ID="btnSelect" CssClass="btn_normal"   OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("COMPID"), Eval("CNTRNO"), Eval("TGRTCNT"), Eval("MAINTYPE"), Eval("MAINTYPENM"),Eval("PREINVSETID")) %>' Width="95%" runat="server" Text="明細" />
                   <asp:HiddenField ID="hdnCompId" Value="<%#Eval("COMPID")%>" runat="server" />
                   <asp:HiddenField ID="hdnPREINVSETID" Value="<%#Eval("PREINVSETID")%>" runat="server" />
                   <asp:HiddenField ID="hdnTRGTCNT" Value="<%#Eval("TGRTCNT")%>" runat="server" />
                 </td>
                 <td><asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label></td>
                 <td style="text-align:left;"><%#Eval("CUSTNAME")%></td>
                 <td><%#Eval("DEPTNM")%></td>
                 <td><%#Eval("MAINTYPENM")%></td>
                 <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT").ToString()).ToString("#,##0") %></td>
                 <td> <%#Eval("CONTRACTMONTH")%></td>
                 <td><%#  Itg.Community.Util.GetRepYear(Eval("VDATE").ToString())%></td>
               </tr>
                
             </ItemTemplate>
             <AlternatingItemTemplate>
                 <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                 <td>
                     <asp:Button ID="btnSelect" CssClass="btn_normal"   OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("COMPID"), Eval("CNTRNO"), Eval("TGRTCNT"), Eval("MAINTYPE"), Eval("MAINTYPENM"),Eval("PREINVSETID")) %>' Width="95%" runat="server" Text="明細" />
                   <asp:HiddenField ID="hdnCompId" Value="<%#Eval("COMPID")%>" runat="server" />
                   <asp:HiddenField ID="hdnPREINVSETID" Value="<%#Eval("PREINVSETID")%>" runat="server" />
                   <asp:HiddenField ID="hdnTRGTCNT" Value="<%#Eval("TGRTCNT")%>" runat="server" />
                 </td>
                 <td><asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label></td>
                 <td style="text-align:left;"><%#Eval("CUSTNAME")%></td>
                 <td><%#Eval("DEPTNM")%></td>
                 <td><%#Eval("MAINTYPENM")%></td>
                 <td style="text-align:right;"><%#System.Convert.ToDecimal(Eval("AMOUNT").ToString()).ToString("#,##0") %></td>
                 <td> <%#Eval("CONTRACTMONTH")%></td>
                 <td><%#  Itg.Community.Util.GetRepYear(Eval("VDATE").ToString())%></td>
               </tr>
               </AlternatingItemTemplate>
             </asp:Repeater>
           </table>
        </div>
    </div>
  </form>
</body>
</html>
