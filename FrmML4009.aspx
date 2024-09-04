<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4009.aspx.cs" Inherits="FrmML4009" %>

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
    <!-- #Include file='js/ML4009.js' -->
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
        <div class="divTitle" runat="server" style="display:none;" id="divTitle">每日批次發票開立設定作業</div>
        <div class="div_Info H_50">
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
               <th style="text-align:right;width:25%;">預計年月：</th>
               <td style="width:75%">
                 <asp:TextBox ID="txtRntYM" runat="server" CssClass="txt_normal"  MaxLength = "7" Width="10%"></asp:TextBox>
              </td>
            </tr>
            <tr>
               <th style="text-align:right;width:25%;">處理區分：</th>
               <td style="width:75%">
	              <asp:DropDownList ID="drpPROCMODE" runat="server">
                    <asp:ListItem Value="" Selected="True">請選擇</asp:ListItem>
                    <asp:ListItem Value="1">新增</asp:ListItem>
                    <asp:ListItem Value="2">修改</asp:ListItem>
                  </asp:DropDownList>
                 <asp:Button ID="cmdQuery" runat="server" Text="查詢" style="display:none;" OnClientClick="JavaScript: return cmdQuery_onClick(this);" CssClass="btn_normal" onclick="cmdQuery_Click"/>
              </td>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow:auto;margin:10px;">
           <table width="98%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo" style="margin:4px;" onkeydown="tabQryResultInfo_onkeydown(event);">
             <tr>
               <th>公司別</th>
               <th>預計年月</th>
               <th>使用者</th>
               <th>作業日</th>
               <th>預計開立日</th>
               <th>停用否</th>
             </tr>
             <asp:Repeater ID="rptMLMMLMBATPLAN" runat="server">
              <ItemTemplate>
               <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                     <td><%#Itg.Community.Util.GetRepYear(Eval("COMPNME").ToString())%>
                     <asp:HiddenField ID="hdnCOMPID" Value='<%# Eval("COMPID") %>' runat="server" />
                     </td>
                     <td><%#Itg.Community.Util.GetRepYear(Eval("OPYM").ToString())%>
                     <asp:HiddenField ID="hdnOPYM" Value='<%# Eval("OPYM") %>' runat="server" />
                     </td>
                     
					 <!-- td><asp:HiddenField ID="hdnEMPLID" Value='<%# Eval("EMPLID") %>' runat="server" /></td -->
					 <td><%#Eval("EMPLNM")%></td>
                     
					 <td><%#Eval("PDATE")%></td>
                     <td><asp:TextBox ID="txtPOPDATE" width="95%" Text='<%# Eval("POPDATE")%>'  onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);"  MaxLength="10" runat="server" CssClass="txt_table" ></asp:TextBox></td>
                     <td>
		              <asp:DropDownList ID="drpOPFLAG" runat="server">
                        <asp:ListItem Value="1">Y</asp:ListItem>
                        <asp:ListItem Value="2">N</asp:ListItem>
                      </asp:DropDownList>
                     </td>
               </tr>
             </ItemTemplate>
             <AlternatingItemTemplate>
                 <tr style=" background-color:#E5E5E5" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);"> 
                     <td><%#Itg.Community.Util.GetRepYear(Eval("COMPNME").ToString())%>
                     <asp:HiddenField ID="hdnCOMPID" Value='<%# Eval("COMPID") %>' runat="server" />
                     </td>
                     <td><%#Itg.Community.Util.GetRepYear(Eval("OPYM").ToString())%>
                     <asp:HiddenField ID="hdnOPYM" Value='<%# Eval("OPYM") %>' runat="server" />
                     </td>
                     
					 <!-- td><asp:HiddenField ID="hdnEMPLID" Value='<%# Eval("EMPLID") %>' runat="server" /></td -->
                     <td><%#Eval("EMPLNM")%></td>
					 
					 <td><%#Eval("PDATE")%></td>
                     <td><asp:TextBox ID="txtPOPDATE"  width="95%" Text='<%# Eval("POPDATE")%>' onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);"  MaxLength="10" runat="server" CssClass="txt_table" ></asp:TextBox></td>
                     <td>
		              <asp:DropDownList ID="drpOPFLAG" runat="server">
                        <asp:ListItem Value="1">Y</asp:ListItem>
                        <asp:ListItem Value="2">N</asp:ListItem>
                      </asp:DropDownList>
                     </td>
                  </tr>
               </AlternatingItemTemplate>
             </asp:Repeater>
           </table>
        </div>
       <div class="btn_div">
            <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
            <asp:Button ID="btnConfirm" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="JavaScript: return btnConfirm_onClick(this);" OnClick="btnConfirm_Click"/>
            <asp:Button ID="cmdClear" runat="server" Text="清除" UseSubmitBehavior="false" CssClass="btn_normal" OnClientClick="cmdClear_onClick(this);" OnClick="cmdClear_Click"/>
       </div>
    </div>
    </form>
</body>
</html>
