<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4014A.aspx.cs" Inherits="FrmML4014A" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div class="divBody" id="divBody" style="width:95%">
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
        <div class="divTitle" runat="server" id="divTitle" style="display:none;width:98%">銀行件展期維護</div>
        <div class="div_Info" style="width:98%" >
           <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
              <div class="div_title">合約內容</div>
              <table  cellpadding="1" cellspacing="1" class="tb_Info" id="tabCntrInfo">
                <tr>
                  <th style="width:15%">合約編號</th>
                  <td style="width:18%"><asp:TextBox ID="txtCNTRNO" CssClass="txt_readonly" ReadOnly="true" runat="server" Width="95%"></asp:TextBox></td>
                  <th style="width:15%">承作類型</th>
                  <td style="width:18%">
                      <asp:HiddenField ID="hdnSysDate" runat="server" />
                      <asp:HiddenField ID="hdnChgSingle" Value="" runat="server" />
                      <asp:HiddenField ID="hdnFinalLevel" Value="" runat="server" />
                      <asp:HiddenField ID="hdnFGSPLIT" Value="2" runat="server" />
                      <asp:HiddenField ID="hdnCompId" Value= "" runat="server" />
                      <asp:HiddenField ID="hdnPROCEDEINV" Value= "" runat="server" />
                      <asp:HiddenField ID="hdnTTLRent" Value= "" runat="server" />
                      <asp:HiddenField ID="hdnPREINVSETID" runat="server" />
                      <asp:HiddenField ID="hdnOPENMASTER" Value= "" runat="server" />
                      <asp:HiddenField ID="hdnOPENCNTRNO"  Value= "" runat="server" />
                      <asp:HiddenField ID="hdnMAINTYPE"  Value= "" runat="server" />
                      <asp:HiddenField ID="hdnGUARSETRATE" runat="server" />
                      <asp:HiddenField ID="hdnBANKEXPAND" runat="server" />
                      <asp:TextBox ID="txtMAINTYPENM" style="width:90%" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <td style="width:15%"><asp:TextBox ID="txtSUBTYPENM"  style="width:90%" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <td style="width:18%;text-align:center;"><B><asp:Label ID="spanINVStarus" style="display:none;color:#FF0000;" runat="server" Text="已展期"></asp:Label><B></td>
                </tr>
                <tr>
                  <th>客戶名稱</th>
                  <td colspan="5">
                    <asp:TextBox ID="txtINVZIPCODE"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtINVZIPCODES"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtINVOICEADDR"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtLLVLNUM01"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtLLVLNUM02"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtRVACNT"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtACTUSLLOANS"  style="display:none;"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtCUSTID" CssClass="txt_readonly"  runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtCUSTNAME" CssClass="txt_readonly" ReadOnly="true" Width="400px" runat="server"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <th>案件起租日</th>
                  <td><asp:TextBox ID="txtRENTSTDT"  custprop="000" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>案件迄租日</th>
                  <td style="width: 191px"><asp:TextBox ID="txtRENTENDT"  custprop="000" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>總期數</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtCONTRACTMONTH" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
		          <th>履約保證金</th>
		          <td><asp:TextBox ID="txtPERBOND" runat="server"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" Text="0"></asp:TextBox></td>
		          <th>租購保證金</th>
		          <td style="text-align:right;width: 191px"><asp:TextBox ID="txtPURCHASEMARGIN"  custprop="100" runat="server" CssClass="txt_readonly_right" ReadOnly="true" Text="0"></asp:TextBox></td>
                  <th>頭期款</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtFIRSTPAY"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th>首期繳款日</th>
                  <td><asp:TextBox ID="txtCUSTFPAYDATE"   custprop="000"  runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox></td>
                  <th>幾月一繳</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtPAYMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox></td>
                  <th></th>
                  <td></td>
                </tr>
                <tr>
                  <th>月租金</th>
                  <td>
                    第<asp:TextBox ID="txtRSTARTPAY1" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                    ~
                    第<asp:TextBox ID="txtRENDPAY1" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                  </td>
                  <th>月付款(含稅)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX1"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>月付款(未稅)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL1"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    第<asp:TextBox ID="txtRSTARTPAY2" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                    ~
                    第<asp:TextBox ID="txtRENDPAY2" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                  </td>
                  <th>月付款(含稅)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX2"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>月付款(未稅)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL2"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    第<asp:TextBox ID="txtRSTARTPAY3" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                    ~
                    第<asp:TextBox ID="txtRENDPAY3" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                  </td>
                  <th>月付款(含稅)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX3"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>月付款(未稅)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL3"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    第<asp:TextBox ID="txtRSTARTPAY4" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                    ~
                    第<asp:TextBox ID="txtRENDPAY4" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>期
                  </td>
                  <th>月付款(含稅)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX4" custprop="100"  CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>月付款(未稅)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL4"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
              </table>
           </div>           
           <div class="btn_div">
                <asp:Button ID="btnUS" runat="server" Text="展期" CssClass="btn_normal" onclick="btnUS_Click"/> 
           </div>                      
        </div>
        <div class="div_table" style="overflow:auto;margin-left:5px;margin-top:10px;height:375px;">
		    <table class="tb_Contact" style="width:50%;" id="tabInvoDtl" onkeydown="tb_Contact_onkeydown(event);">
		        <tr>
		        <th style="width:33%">期數</th>
		        <th style="width:33%">期付款繳款日</th>
		        <th style="width:34%">月付款</th>
		        </tr>
		        <asp:Repeater ID="rptData" runat="server">
                <ItemTemplate>
		        <tr>
		        <td style="width:33%"><asp:Label ID="lblISSUE"  Text='<%# Eval("ISSUE")%>' runat="server"></asp:Label></td>
		        <td style="width:33%"><asp:Label ID="lblPAYDATE"  Text='<%# Eval("PAYDATE")%>' runat="server"></asp:Label></td>
		        
				<%--20130221 Edit by SEAN 修改展期月付款顯示由月付款(未稅)->月付款(含稅)--%>
				<%--<td style="width:34%"><asp:Label ID="lblRENT" Text='<%# System.Convert.ToDecimal(Eval("RENT").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>--%>
				<td style="width:34%"><asp:Label ID="lblRENTTAX" Text='<%# System.Convert.ToDecimal(Eval("RENTTAX").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>
		        </tr>
		        </ItemTemplate>
		        </asp:Repeater>
            </table>
        </div>
        <div id="divBlock" style="text-align:center; vertical-align:bottom; border-style: solid; border-width: 1px; z-index: 1; position: absolute; top: 1px; left: 11px; height:375px; width: 98%; background-color: #808080;filter: Alpha(Opacity=80);display:none;">   
            <img style="text-align:center;  vertical-align:bottom; width: 751px; height: 198px;" src="images/processing.jpg" />  
        </div>  
       <div class="btn_div">
        <asp:DropDownList ID="drpCODE" style="display:none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
            <asp:Button ID="btnExtInvo" runat="server" Text="展期確認" CssClass="btn_normal" OnClick="btnExtInvo_Click"/>
       </div>            
    </div>
    </form>
</body>
</html>
