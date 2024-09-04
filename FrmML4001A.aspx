<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="FrmML4001A.aspx.cs" Inherits="FrmML4001A" %>

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
    <!-- #Include file='js/ML4001A.js' -->
    </script>
</head>
<body onkeydown="body_OnKeyDown(event)">
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
        <div class="divTitle" runat="server" id="divTitle" style="display:none;width:98%">發票及繳款方式維護</div>
        <!--<div class="div_Info H_770" style="width:98%" >-->
		<div style="width:98%" >
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
                      <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                      <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
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
                    <%--20240316財務要求根據客戶性質判斷發票聯式--%>
                     <asp:TextBox ID="txtCUTYPE"  style="display:none;"  runat="server"></asp:TextBox>
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
            <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                <table  cellpadding="1" cellspacing="1" class="tb_Info">
                    <tr>
                        <th style="width:15%">手續費收入</th>
                        <td style="width:18%"><asp:TextBox ID="txtFEEAMT1"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                        <th style="width:15%">動保費收入</th>
                        <td style="width:18%"><asp:TextBox ID="txtFEEAMT2"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                        <th style="width:15%">墊款息收入</th>
                        <td style="width:18%"><asp:TextBox ID="txtADVANCESINTEREST"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div id="fraDispTypeInfo" class="H_655" style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                    class="sheet div_menu">
                    <label class="label_contain">
                        本體分差發票</label>
                </div>
                <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                    class="sheet div_menu T_-24 L_125">
                    <label class="label_contain">
                        手續費發票</label>
                </div>
                <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                    class="sheet div_menu T_-48 L_250">
                    <label class="label_contain">
                        動保費收入發票</label>
                </div>
                <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                    class="sheet div_menu T_-72 L_375">
                    <label class="label_contain">
                        墊款息收入發票</label>
                </div>
                <%--本體分差發票Begin --%>
                <div id="fraTab11" class="div_content padleft_0 T_-72" style="display: none">
                   <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                      <div class="div_title">發票內容設定</div>
                      <table  cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="tabCntrInvInfo">
                        <tr>
                          <th width="15%">發票開起月</th>
                          <td width="15%"><asp:TextBox ID="txtRENTSTDTM" CssClass="txt_normal" MaxLength="7" runat="server"></asp:TextBox></td>
                          <th width="10%">指定日期</th>
                          <td width="10%"><asp:TextBox ID="txtRENTSTDTD" MaxLength="2" CssClass="txt_normal" runat="server">1</asp:TextBox></td>
                          <th width="10%">發票聯式</th>
                          <td width="20%">
                              <span style="color: red">若客戶為個人<br />發票聯式應為二聯式</span><br />
		                      <asp:DropDownList ID="drpINVKIND1" runat="server" >
                                <asp:ListItem Value="">請選擇</asp:ListItem>
                                <asp:ListItem Value="2">二聯式</asp:ListItem>
                                <asp:ListItem Value="3">三聯式</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                          <th width="10%">幾月一開</th>
                          <td width="10%"><asp:TextBox ID="txtPAYMONTHK" MaxLength="2" CssClass="txt_normal_right"  runat="server">1</asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>單體彙開</th>
                          <td>
                            <asp:DropDownList ID="ddlSingle" runat="server" OnSelectedIndexChanged="ddlSingle_SelectedIndexChanged">
                              <asp:ListItem Value = "1" Selected="True">Y</asp:ListItem>
                              <asp:ListItem Value = "2">N</asp:ListItem>
                            </asp:DropDownList><input type="button" id="btnSplit" class="btn_normal" style="width:95px;padding:1px;display:none;" runat="server" onclick="FrmML4003Click();" value="拆發票設定" />
                          </td>
                          <th>總體彙開</th>
                          <td>
                            <asp:DropDownList ID="ddlSummary" Enabled="false" style="width:30%" runat="server">
                              <asp:ListItem Value = "1">Y</asp:ListItem>
                              <asp:ListItem Value = "2" Selected="True">N</asp:ListItem>
                            </asp:DropDownList>
                              <input type="button" id="btnMerge" runat="server" class="btn_normal" style="width:35%;padding:1px;display:none;" onclick="FrmML4002Click();" value="彙開設定" />
                              <input id="chkMerge" type="checkbox" style="display:none" onclick="chkMerge_onClick(this);" runat="server" /><asp:Label ID="spanChkMerge" runat="server" Text="彙開主約"></asp:Label>
                          </td>
                          <th>預計開立方式</th>
                          <td colspan ="3">
                            <asp:DropDownList ID="ddlAplyTyp" runat="server">
                              <asp:ListItem Value = "1">單筆開立 </asp:ListItem>
                              <asp:ListItem Value = "2" Selected="True">批次開立</asp:ListItem>
                              <asp:ListItem Value = "3">暫不開立</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                       </tr>
                        <tr>
                           <th>本體分差開立方式</th>
                          <td>
                            <asp:DropDownList ID="ddlBdyDiffTyp" runat="server">
                              <asp:ListItem Value ="1">拆開</asp:ListItem>
                              <asp:ListItem Value ="2" Selected="True">不拆開</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td colspan="6"></td>
                       </tr>
                       <tr>
                          <%--UPD BY HANK 20170926 本體分差發票增加載具號碼，捐贈，跟愛心碼--%>
                          <th>載具號碼</th>
                          <td>
                              <asp:TextBox ID="txtCARRIEID" MaxLength="30" CssClass="txt_normal" runat="server" Width="150"></asp:TextBox>
                          </td>
                          <th>捐贈</th>
                          <td>
                              <input id="chkDONATEMARK" type="checkbox" onclick="chkDONATEMARK_onClick(this);" runat="server" />
                          </td>
                          <th>愛心碼</th>
                          <td>
                              <asp:TextBox ID="txtNPOBAN" MaxLength="30" CssClass="txt_normal" runat="server" Enabled="false"></asp:TextBox>
                          </td>
                          <td colspan="2"></td>
                       </tr>
                      </table>
                   </div>   
                   <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                       <div class="div_title">備註設定</div>
                        <table id="tabCntrInvRmkInfo"  cellpadding="1" cellspacing="1" class="tb_Info" runat="server">
                          <tr style="display:none;" runat="server">
                            <th id="TH6" runat="server">租金<asp:HiddenField ID="hdnPREINVNOTEID1" runat="server" /></th>
                            <td id="TD4" runat="server"><asp:CheckBox Checked="true" ID="chk11" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD12" runat="server"><asp:CheckBox Checked="true" ID="chk12" runat="server" Text="期數" />&nbsp;</td>
                            <td id="TD33" runat="server"><asp:CheckBox Checked="true" ID="chk13" runat="server" Text="租賃期間" />&nbsp;</td>
                            <td id="TD14" runat="server"><asp:CheckBox Checked="true" ID="chk14" runat="server" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD36" runat="server"><asp:CheckBox ID="chk15" runat="server" Text="實體帳號" />&nbsp;</td>
                            <td runat="server" id="TD41"><asp:CheckBox ID="chk16" style="display:none;" runat="server" Text="繳款日"/>&nbsp;</td>
                            <td id="TD31" runat="server">
                              <asp:Button ID="btn11" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE1');" runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE1" Value="" runat="server" />
                            </td>
                          </tr>
                          <tr style="display:none;" runat="server">
                            <th id="TH5" runat="server">押金設算息<asp:HiddenField ID="hdnPREINVNOTEID2" runat="server" /></th>
                            <td id="TD8" runat="server"><asp:CheckBox ID="chk21" Checked="true" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD27" runat="server"><asp:CheckBox ID="chk22" Checked="true" runat="server" Text="期數" />&nbsp;</td>
                            <td id="TD2" runat="server"><asp:CheckBox ID="chk23" Checked="true"  runat="server" Text="租賃期間" />&nbsp;</td>
                            <td id="TD10" runat="server"><asp:CheckBox ID="chk24" Enabled="false"  runat="server" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD15" runat="server"><asp:CheckBox ID="chk25" Enabled="false" runat="server" Text="實體帳號" />&nbsp;</td>
                            <td runat="server" id="TD39"><asp:CheckBox ID="chk26" style="display:none;" runat="server" Text="繳款日"/>&nbsp;</td>
                            <td id="TD9" runat="server">
                              <asp:Button ID="btn21" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE2');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE2" Value="" runat="server" />
                            </td>
                          </tr>
                          <tr style="display:none" runat="server">
                            <th id="TH2" runat="server">手續費<asp:HiddenField ID="hdnPREINVNOTEID3" runat="server" /></th>
                            <td id="TD28" runat="server"><asp:CheckBox ID="chk31" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD5" runat="server"><asp:CheckBox ID="chk32" runat="server" Text="期數" />&nbsp;</td>
                            <td id="TD6" runat="server"><asp:CheckBox ID="chk33" runat="server" Text="租賃期間" />&nbsp;</td>
                            <td id="TD19" runat="server"><asp:CheckBox ID="chk34" runat="server" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD1" runat="server"><asp:CheckBox ID="chk35" runat="server" Text="實體帳號" />&nbsp;</td>
                              <td runat="server" id="TD40"><asp:CheckBox ID="chk36" style="display:none;" runat="server" Text="繳款日"/>&nbsp;</td>
                            <td id="TD23" runat="server">
                              <asp:Button ID="btn31" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE3');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE3" Value="" runat="server" />
                            </td>
                          </tr>
                          <tr style="display:none;" runat="server">
                            <th id="TH4" runat="server">本體<asp:HiddenField ID="hdnPREINVNOTEID4" runat="server" /></th>
                            <td id="TD25" runat="server"><asp:CheckBox ID="chk41" Checked="true" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD16" runat="server"><asp:CheckBox ID="chk42" runat="server" style="display:none;" Text="期數" />&nbsp;</td>
                            <td id="TD21" runat="server"><asp:CheckBox ID="chk43" runat="server" style="display:none;" Text="租賃期間" />&nbsp;</td>
                            <td id="TD3" runat="server"><asp:CheckBox ID="chk44" runat="server" style="display:none;" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD7" runat="server"><asp:CheckBox Checked="true" ID="chk45" Text="實體帳號" runat="server" />&nbsp;</td>
                              <td runat="server" id="TD37"><asp:CheckBox ID="chk46" runat="server" style="display:none;" Text="繳款日"/>&nbsp;</td>
                            <td id="TD18" runat="server">
                              <asp:Button ID="btn41" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE4');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE4" Value="" runat="server" />
                            </td>
                          </tr>
                          <tr style="display:none;" runat="server">
                            <th id="TH1" runat="server">分差<asp:HiddenField ID="hdnPREINVNOTEID5" runat="server" /></th>
                            <td id="TD29" runat="server"><asp:CheckBox ID="chk51" Checked="true" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD11" runat="server"><asp:CheckBox ID="chk52" runat="server" style="display:none;" Text="期數" />&nbsp;</td>
                            <td id="TD35" runat="server"><asp:CheckBox ID="chk53" runat="server" style="display:none;" Text="租賃期間" />&nbsp;</td>
                            <td id="TD13" runat="server"><asp:CheckBox ID="chk54" runat="server" style="display:none;" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD34" runat="server"><asp:CheckBox Checked="true" ID="chk55" runat="server" Text="實體帳號" />&nbsp;</td>
                              <td runat="server" id="TD42"><asp:CheckBox ID="chk56" runat="server" style="display:none;" Text="繳款日"/>&nbsp;</td>
                            <td id="TD20" runat="server">
                              <asp:Button ID="btn51" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE5');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE5" Value="" runat="server" />
                            </td>
                          </tr>
                          <tr style="display:none;" runat="server">
                            <th id="TH3" runat="server">本體+分差<asp:HiddenField ID="hdnPREINVNOTEID6" runat="server" /></th>
                            <td id="TD24" runat="server"><asp:CheckBox ID="chk61" Checked="true" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD22" runat="server"><asp:CheckBox ID="chk62" runat="server" style="display:none;" Text="期數" />&nbsp;</td>
                            <td id="TD26" runat="server"><asp:CheckBox ID="chk63" runat="server" style="display:none;" Text="租賃期間" />&nbsp;</td>
                            <td id="TD32" runat="server"><asp:CheckBox ID="chk64" runat="server" style="display:none;" Text="虛擬帳號" />&nbsp;</td>
                            <td style="width: 121px" id="TD30" runat="server"><asp:CheckBox Checked="true" ID="chk65" runat="server" Text="實體帳號" />&nbsp;</td>
                              <td runat="server" id="TD38"><asp:CheckBox ID="chk66" runat="server" style="display:none;" Text="繳款日"/>&nbsp;</td>
                            <td id="TD17" runat="server">
                              <asp:Button ID="btn61" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE6');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE6" Value="" runat="server" />
                             </td>
                          </tr>
                        </table>
                        <div class="btn_div">
                          <asp:Button ID="btnUS" runat="server" Text="發票展期" OnClientClick="JavaScript: return btnUS_onClick(this);" CssClass="btn_normal" onclick="btnUS_Click"/>
                          <asp:Button ID="btnUA" runat="server" Text="整批修正" UseSubmitBehavior="false" OnClientClick="JavaScript: return btnUA_onClick(this);" Enabled="false" CssClass="btn_normal"/>
                          <asp:Button ID="btnUO" runat="server" Text="單筆修正" UseSubmitBehavior="false" OnClientClick="JavaScript: return btnUO_onClick(this);" Enabled="false" CssClass="btn_normal"/> 
                        </div>
                    </div>
                    <div style="margin:5px">
                      <asp:Button ID="btn111" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="租金" CssClass="btn_normal"/>
                      <asp:Button ID="btn222" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="押金設算息" CssClass="btn_normal"/>
                      <asp:Button ID="btn333" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="手續費" CssClass="btn_normal"/>
                      <asp:Button ID="btn444" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="本體" CssClass="btn_normal"/>
                      <asp:Button ID="btn555" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="分差" CssClass="btn_normal"/>
                      <asp:Button ID="btn666" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"  Text="本體+分差" CssClass="btn_normal"/>
                      <%--20120704 MODIFY BY SS MAUREEN REASON:新增標的物明細按鈕--%>
                      <asp:Button ID="btnTargetPrint" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btnTargetPrint_onClick(this);"  Text="標的物明細" CssClass="btn_normal"/>
                    </div>
                   <div class="div_table" style="overflow:auto;margin-left:5px;margin-top:10px;height:375px;">
		                <table class="tb_Contact" style="width:215%;" id="tabInvoDtl" onkeydown="tb_Contact_onkeydown(event);">
		                  <tr>
		                    <th style="width:2%">期數</th>
		                    <th style="width:5%">單體編號</th>
		                    <th style="width:5%">預計開立方式</th>
		                    <th style="width:4%">租金年月</th>
		                    <th style="width:5%">預開發票年月</th>
		                    <th style="width:4%">發票品名</th>
		                    <th style="width:3%">稅率</th>
		                    <th style="width:4%">對象統編</th>
		                    <th style="width:12%">對象名稱</th>
		                    <th style="width:4%">月付款</th>
		                    <th style="width:20%">發票地址</th>
		                    <th style="width:3%">指定日</th>
		                    <th style="width:3%">發票聯式</th>
		                    <th style="width:3%">備註</th>
		                    <th style="width:3%">拆發票</th>
		                    <th style="width:4%">單體彙開</th>
		                    <th style="width:6%">總體彙開</th>
		                  </tr>
		                  <asp:Repeater ID="rptData" runat="server">
                      <ItemTemplate>
		                  <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
		                    <td style="width:2%">
                                <asp:HiddenField ID="hdnPREINVID" runat="server" />
                                <asp:HiddenField ID="hdnUNITID" runat="server" />
                                <asp:HiddenField ID="hdnRENTALPREIOD" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLLVLNUM" Value="" runat="server" />
                                <asp:HiddenField ID="hdnACTACCOUNT" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSPECNOTE" Value="" runat="server" />
                                <asp:HiddenField ID="hdnRENTYEARS" Value="0" runat="server" />
                                <asp:Label ID="lblISSUE"  Text='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server"></asp:Label></td>
		                    <td style="width:5%"><asp:Label ID="lblUNITID"  Text='<%# Eval("UNITID")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%">
		                      <asp:DropDownList ID="drpPREOPENWAY" runat="server">
                                <asp:ListItem Value="1">單筆開立</asp:ListItem>
                                <asp:ListItem Value="2">批次開立</asp:ListItem>
                                <asp:ListItem Value="3">暫不開立</asp:ListItem>
                          </asp:DropDownList>
		                    </td>
		                    <td style="width:4%"><asp:Label ID="lblRENTYEARS"  Text='<%# Eval("RENTYEARS")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%"><asp:Label ID="lblPREINVYYYYMM"  Text='<%# Eval("PREINVYYYYMM")%>' runat="server"></asp:Label><asp:TextBox ID="txtPREINVYYYYMM" Text='<%# Eval("PREINVYYYYMM")%>' style="display:none;" CssClass="txt_table" runat="server"></asp:TextBox></td>
		                    <td style="width:4%">
                           <input type="button" id="btnINVDESC" class="btn_normal" onclick="return FrmML4001A_1Click(this, 'hdnINVDESC', 'hdnAMOUNT', 'hdnTAX', 'hdnPRINCIPAL', 'hdnINSTAMT', 'hdnISSUE');" value="品名設定" style="padding:2px;" />
                            <asp:HiddenField ID="hdnINVDESCTYPE" Value='<%# Eval("INVDESCTYPE")%>' runat="server" />
                            <asp:HiddenField ID="hdnINVDESC" Value='<%# Eval("INVDESC")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPALDESC" Value="" runat="server" />
                            <asp:HiddenField ID="hdnINSTDESC" Value="" runat="server" />
                            <asp:HiddenField ID="hdnAMOUNT" Value='<%# Eval("AMOUNT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForAMOUNT" Value='<%# Eval("TAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPAL" Value='<%# Eval("RTNAMT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForPRINCIPAL" Value='<%# Eval("RTNAMTTAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnINSTAMT" Value='<%# Eval("INSTAMT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForINSTAMT" Value='<%# Eval("INSTAMTTAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnMTRCNTRNO" Value='<%# Eval("MTRCNTRNO")%>' runat="server" />
                            <asp:HiddenField ID="hdnISSUE"  Value='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server" />
                        </td>
		                    <td style="width:3%">
		                      <asp:DropDownList ID="drpTAXTYPE" Enabled="false" runat="server">
                                <asp:ListItem Value="1">應稅</asp:ListItem>
                                <asp:ListItem Value="2">零稅</asp:ListItem>
                                <asp:ListItem Value="3">免稅</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETID"   Text='<%# Eval("TARGETID")%>'  CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETNAME"  Text='<%# Eval("TARGETNAME")%>'   CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="text-align:right;width:4%"><asp:Label ID="lblMONTHPAY"  Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>
		                    <td style="text-align:left;width:21%">
		                     <asp:TextBox ID="txtINVZIPCODE"   Text='<%# Eval("INVZIPCODE")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" style="width:50px" onblur="PostCodeBlure(this)"  CssClass="txt_table" ></asp:TextBox>
                             <input type="button" id="btnINVZIPCODE" class="btn_normal" onclick="PostCodeClick(this);"  style="padding:2px;" value="&#8230;" />
                             <asp:TextBox ID="txtINVZIPCODES"   Text='<%# Eval("INVZIPCODES")%>'  runat="server" CssClass="txt_table" style="width:120px"  onfocus="ObjMFocus(this,'txtINVZIPCODES','txtINVOICEADDR');"  ></asp:TextBox>
                             <asp:TextBox ID="txtINVOICEADDR"   Text='<%# Eval("INVOICEADDR")%>'  runat="server" CssClass="txt_table"  style="width:180px" MaxLength="100"  onblur="CheckMLength(this,'100');"  ></asp:TextBox>
		                    </td>
		                    <td style="width:3%"><asp:TextBox ID="txtORDERDAY"   Text='<%# Eval("ORDERDAY")%>' CssClass="txt_table" style="width:90%" runat="server"></asp:TextBox></td>
		                    <td>
		                      <asp:DropDownList ID="drpINVKIND" runat="server"  Enabled="false" >
                                <asp:ListItem Value="2">二聯式</asp:ListItem>
                                <asp:ListItem Value="3">三聯式</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="text-align:left;width:3%">
		                    <asp:Button ID="btnBZ" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click2(this,'btnBZ','hdnBZ','tabInvoDtl');"   runat="server" Text="備註" />
                            <asp:HiddenField ID="hdnBZ"  Value='<%# Eval("BZ")%>' runat="server" />
		                    <td style="width:3%"><asp:Label ID="spanFGSPLIT"  Text='<%# Eval("FGSPLITNME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSPLIT"  Value='<%# Eval("FGSPLIT")%>' runat="server" /></td>
		                    <td style="width:4%"><asp:Label ID="spanFGSINGLE"  Text='<%# Eval("FGSINGLENME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSINGLE"  Value='<%# Eval("FGSINGLE")%>' runat="server" /></td>
		                    <td style="width:6%"><asp:Label ID="spanFGSUMMARY"  Text='<%# Eval("MTRCNTRNO")%>' runat="server"></asp:Label></td>
		                    </td>
		                  </tr>
		                    </ItemTemplate>
		                    </asp:Repeater>
		         
		                </table>
		              </div>
                </div>
                <%--本體分差發票End --%>
                <%--手續費發票Begin --%>
                <div id="fraTab22" class="div_content padleft_0 T_-72" style="display: none">
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                        <div class="div_title">發票內容設定</div>
                        <table  cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="tabCntrInvInfo_2">
                            <tr>
                              <th width="15%">發票開起月</th>
                              <td width="15%"><asp:TextBox ID="txtRENTSTDTM_2" CssClass="txt_normal" MaxLength="7" runat="server"></asp:TextBox></td>
                              <th width="10%">指定日期</th>
                              <td width="10%"><asp:TextBox ID="txtRENTSTDTD_2" MaxLength="2" CssClass="txt_normal" runat="server">1</asp:TextBox></td>
                              <th width="10%">發票聯式</th>
                              <td width="10%">
		                          <asp:DropDownList ID="drpINVKIND1_2" runat="server" >
                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                    <asp:ListItem Value="2">二聯式</asp:ListItem>
                                    <asp:ListItem Value="3">三聯式</asp:ListItem>
                                  </asp:DropDownList>
                              </td>                              
                              <td width="30%">&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
	                    <div class="div_title">備註設定</div>
	                    <table id="tabCntrInvRmkInfo_2"  cellpadding="1" cellspacing="1" class="tb_Info" runat="server">
                          <tr runat="server">
                            <th id="TH2_2" runat="server" style="width:30%">手續費<asp:HiddenField ID="hdnPREINVNOTEID3_2" runat="server" /></th>
                            <td id="TD28_2" runat="server" style="width:30%"><asp:CheckBox ID="chk31_2" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD23_2" runat="server">
                              <asp:Button ID="btn31_2" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE3_2');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE3_2" Value="" runat="server" />
                            </td>
                          </tr>
	                    </table>
                        <div class="btn_div">
                            <asp:Button ID="btnUS_2" runat="server" Text="發票展期" OnClientClick="JavaScript: return btnUS_2_onClick(this);" CssClass="btn_normal" onclick="btnUS_2_Click"/>
                        </div>
                    </div>
					<div class="div_table" style="overflow:auto;margin-left:5px;margin-top:10px;height:375px;">
		                <table class="tb_Contact" style="width:215%;" id="tabInvoDtl_2" onkeydown="tb_Contact_onkeydown(event);">
		                  <tr>
		                    <th style="width:2%">期數</th>
		                    <th style="width:5%">單體編號</th>
		                    <th style="width:5%">預計開立方式</th>
		                    <th style="width:4%">租金年月</th>
		                    <th style="width:5%">預開發票年月</th>
		                    <th style="width:4%">發票品名</th>
		                    <th style="width:3%">稅率</th>
		                    <th style="width:4%">對象統編</th>
		                    <th style="width:12%">對象名稱</th>
		                    <th style="width:4%">月付款</th>
		                    <th style="width:20%">發票地址</th>
		                    <th style="width:3%">指定日</th>
		                    <th style="width:3%">發票聯式</th>
		                    <th style="width:3%">備註</th>
		                    <th style="width:3%">拆發票</th>
		                    <th style="width:4%">單體彙開</th>
		                    <th style="width:6%">總體彙開</th>
		                  </tr>
		                  <asp:Repeater ID="rptData_2" runat="server">
                      <ItemTemplate>
		                  <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
		                    <td style="width:2%">
                                <asp:HiddenField ID="hdnPREINVID_2" Value='<%# Eval("PREINVID")%>' runat="server" />
                                <asp:HiddenField ID="hdnUNITID_2" Value='<%# Eval("UNITID")%>' runat="server" />
                                <asp:HiddenField ID="hdnRENTALPREIOD_2" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLLVLNUM_2" Value="" runat="server" />
                                <asp:HiddenField ID="hdnACTACCOUNT_2" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSPECNOTE_2" Value="" runat="server" />
                                <asp:HiddenField ID="hdnRENTYEARS_2" Value="0" runat="server" />
                                <asp:Label ID="lblISSUE_2"  Text='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server"></asp:Label></td>
		                    <td style="width:5%"><asp:Label ID="lblUNITID_2"  Text='<%# Eval("UNITID")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%">
		                      <asp:DropDownList ID="drpPREOPENWAY_2" runat="server">
                                <asp:ListItem Value="1">單筆開立</asp:ListItem>
                                <asp:ListItem Value="2">批次開立</asp:ListItem>
                                <asp:ListItem Value="3">暫不開立</asp:ListItem>
                          </asp:DropDownList>
		                    </td>
		                    <td style="width:4%"><asp:Label ID="lblRENTYEARS_2"  Text='<%# Eval("RENTYEARS")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%"><asp:Label ID="lblPREINVYYYYMM_2"  Text='<%# Eval("PREINVYYYYMM")%>' runat="server"></asp:Label><asp:TextBox ID="txtPREINVYYYYMM_2" Text='<%# Eval("PREINVYYYYMM")%>' style="display:none;" CssClass="txt_table" runat="server"></asp:TextBox></td>
		                    <td style="width:4%">
                           <input type="button" id="btnINVDESC_2" class="btn_normal" onclick="return FrmML4001A_1Click(this, 'hdnINVDESC_2', 'hdnAMOUNT_2', 'hdnTAX_2', 'hdnPRINCIPAL_2', 'hdnINSTAMT_2', 'hdnISSUE_2');" value="品名設定" style="padding:2px;" />
                            <asp:HiddenField ID="hdnINVDESCTYPE_2" Value='<%# Eval("INVDESCTYPE")%>' runat="server" />
                            <asp:HiddenField ID="hdnINVDESC_2" Value='<%# Eval("INVDESC")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPALDESC_2" Value="" runat="server" />
                            <asp:HiddenField ID="hdnINSTDESC_2" Value="" runat="server" />
                            <asp:HiddenField ID="hdnAMOUNT_2" Value='<%# Eval("AMOUNT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForAMOUNT_2" Value='<%# Eval("TAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPAL_2" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForPRINCIPAL_2" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnINSTAMT_2" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForINSTAMT_2" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnMTRCNTRNO_2" Value='<%# Eval("MTRCNTRNO")%>' runat="server" />
                            <asp:HiddenField ID="hdnISSUE_2"  Value='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server" />
                        </td>
		                    <td style="width:3%">
		                      <asp:DropDownList ID="drpTAXTYPE_2" Enabled="false" runat="server">
                                <asp:ListItem Value="1">應稅</asp:ListItem>
                                <asp:ListItem Value="2">零稅</asp:ListItem>
                                <asp:ListItem Value="3">免稅</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETID_2"   Text='<%# Eval("TARGETID")%>'  CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETNAME_2"  Text='<%# Eval("TARGETNAME")%>'   CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="text-align:right;width:4%"><asp:Label ID="lblMONTHPAY_2"  Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>
		                    <td style="text-align:left;width:21%">
		                     <asp:TextBox ID="txtINVZIPCODE_2"   Text='<%# Eval("INVZIPCODE")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" style="width:50px" onblur="PostCodeBlure(this)"  CssClass="txt_table" ></asp:TextBox>
                             <input type="button" id="btnINVZIPCODE_2" class="btn_normal" onclick="PostCodeClick(this);"  style="padding:2px;" value="&#8230;" />
                             <asp:TextBox ID="txtINVZIPCODES_2"   Text='<%# Eval("INVZIPCODES")%>'  runat="server" CssClass="txt_table" style="width:120px"  onfocus="ObjMFocus(this,'txtINVZIPCODES_2','txtINVOICEADDR_2');"  ></asp:TextBox>
                             <asp:TextBox ID="txtINVOICEADDR_2"   Text='<%# Eval("INVOICEADDR")%>'  runat="server" CssClass="txt_table"  style="width:180px" MaxLength="100"  onblur="CheckMLength(this,'100');"  ></asp:TextBox>
		                    </td>
		                    <td style="width:3%"><asp:TextBox ID="txtORDERDAY_2"   Text='<%# Eval("ORDERDAY")%>' CssClass="txt_table" style="width:90%" runat="server"></asp:TextBox></td>
		                    <td>
		                      <asp:DropDownList ID="drpINVKIND_2" runat="server" Enabled="false" >
                                <asp:ListItem Value="2">二聯式</asp:ListItem>
                                <asp:ListItem Value="3">三聯式</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="text-align:left;width:3%">
		                    <asp:Button ID="btnBZ_2" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click2(this,'btnBZ_2','hdnBZ_2','tabInvoDtl_2');"   runat="server" Text="備註" />
                            <asp:HiddenField ID="hdnBZ_2"  Value='<%# Eval("BZ")%>' runat="server" />
		                    <td style="width:3%"><asp:Label ID="spanFGSPLIT_2"  Text='<%# Eval("FGSPLITNME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSPLIT2"  Value='<%# Eval("FGSPLIT")%>' runat="server" /></td>
		                    <td style="width:4%"><asp:Label ID="spanFGSINGLE_2"  Text='<%# Eval("FGSINGLENME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSINGLE2"  Value='<%# Eval("FGSINGLE")%>' runat="server" /></td>
		                    <td style="width:6%"><asp:Label ID="spanFGSUMMARY_2"  Text='<%# Eval("MTRCNTRNO")%>' runat="server"></asp:Label></td>
		                    </td>
		                  </tr>
		                    </ItemTemplate>
		                    </asp:Repeater>
		         
		                </table>
		            </div>
                </div>
                <%--手續費發票End --%>
                <%--動保費收入發票Begin --%>
                <div id="fraTab33" class="div_content padleft_0 T_-72" style="display: none">
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                        <div class="div_title">發票內容設定</div>
                        <table  cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="tabCntrInvInfo_3">
                            <tr>
                              <th width="15%">發票開起月</th>
                              <td width="15%"><asp:TextBox ID="txtRENTSTDTM_3" CssClass="txt_normal" MaxLength="7" runat="server"></asp:TextBox></td>
                              <th width="10%">指定日期</th>
                              <td width="10%"><asp:TextBox ID="txtRENTSTDTD_3" MaxLength="2" CssClass="txt_normal" runat="server">1</asp:TextBox></td>
                              <th width="10%">發票聯式</th>
                              <td width="10%">
		                          <asp:DropDownList ID="drpINVKIND1_3" runat="server">
                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                    <asp:ListItem Value="2">二聯式</asp:ListItem>
                                    <asp:ListItem Value="3">三聯式</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td width="30%">&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
	                    <div class="div_title">備註設定</div>
	                    <table id="tabCntrInvRmkInfo_3"  cellpadding="1" cellspacing="1" class="tb_Info" runat="server">
                          <tr runat="server">
                            <th id="TH2_3" runat="server" style="width:30%">動保費收入<asp:HiddenField ID="hdnPREINVNOTEID3_3" runat="server" /></th>
                            <td id="TD28_3" runat="server" style="width:30%"><asp:CheckBox ID="chk31_3" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD23_3" runat="server">
                              <asp:Button ID="btn31_3" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE3_3');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE3_3" Value="" runat="server" />
                            </td>
                          </tr>	                    
                        </table>
                        <div class="btn_div">
                            <asp:Button ID="btnUS_3" runat="server" Text="發票展期" OnClientClick="JavaScript: return btnUS_3_onClick(this);" CssClass="btn_normal" onclick="btnUS_3_Click"/>
                        </div>
                    </div>
					<div class="div_table" style="overflow:auto;margin-left:5px;margin-top:10px;height:375px;">
		                <table class="tb_Contact" style="width:215%;" id="tabInvoDtl_3" onkeydown="tb_Contact_onkeydown(event);">
		                  <tr>
		                    <th style="width:2%">期數</th>
		                    <th style="width:5%">單體編號</th>
		                    <th style="width:5%">預計開立方式</th>
		                    <th style="width:4%">租金年月</th>
		                    <th style="width:5%">預開發票年月</th>
		                    <th style="width:4%">發票品名</th>
		                    <th style="width:3%">稅率</th>
		                    <th style="width:4%">對象統編</th>
		                    <th style="width:12%">對象名稱</th>
		                    <th style="width:4%">月付款</th>
		                    <th style="width:20%">發票地址</th>
		                    <th style="width:3%">指定日</th>
		                    <th style="width:3%">發票聯式</th>
		                    <th style="width:3%">備註</th>
		                    <th style="width:3%">拆發票</th>
		                    <th style="width:4%">單體彙開</th>
		                    <th style="width:6%">總體彙開</th>
		                  </tr>
		                  <asp:Repeater ID="rptData_3" runat="server">
                      <ItemTemplate>
		                  <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
		                    <td style="width:2%">
                                <asp:HiddenField ID="hdnPREINVID_3" Value='<%# Eval("PREINVID")%>' runat="server" />
                                <asp:HiddenField ID="hdnUNITID_3" Value='<%# Eval("UNITID")%>' runat="server" />
                                <asp:HiddenField ID="hdnRENTALPREIOD_3" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLLVLNUM_3" Value="" runat="server" />
                                <asp:HiddenField ID="hdnACTACCOUNT_3" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSPECNOTE_3" Value="" runat="server" />
                                <asp:HiddenField ID="hdnRENTYEARS_3" Value="0" runat="server" />
                                <asp:Label ID="lblISSUE_3"  Text='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server"></asp:Label></td>
		                    <td style="width:5%"><asp:Label ID="lblUNITID_3"  Text='<%# Eval("UNITID")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%">
		                      <asp:DropDownList ID="drpPREOPENWAY_3" runat="server">
                                <asp:ListItem Value="1">單筆開立</asp:ListItem>
                                <asp:ListItem Value="2">批次開立</asp:ListItem>
                                <asp:ListItem Value="3">暫不開立</asp:ListItem>
                          </asp:DropDownList>
		                    </td>
		                    <td style="width:4%"><asp:Label ID="lblRENTYEARS_3"  Text='<%# Eval("RENTYEARS")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%"><asp:Label ID="lblPREINVYYYYMM_3"  Text='<%# Eval("PREINVYYYYMM")%>' runat="server"></asp:Label><asp:TextBox ID="txtPREINVYYYYMM_3" Text='<%# Eval("PREINVYYYYMM")%>' style="display:none;" CssClass="txt_table" runat="server"></asp:TextBox></td>
		                    <td style="width:4%">
                           <input type="button" id="btnINVDESC_3" class="btn_normal" onclick="return FrmML4001A_1Click(this, 'hdnINVDESC_3', 'hdnAMOUNT_3', 'hdnTAX_3', 'hdnPRINCIPAL_3', 'hdnINSTAMT_3', 'hdnISSUE_3');" value="品名設定" style="padding:2px;" />
                            <asp:HiddenField ID="hdnINVDESCTYPE_3" Value='<%# Eval("INVDESCTYPE")%>' runat="server" />
                            <asp:HiddenField ID="hdnINVDESC_3" Value='<%# Eval("INVDESC")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPALDESC_3" Value="" runat="server" />
                            <asp:HiddenField ID="hdnINSTDESC_3" Value="" runat="server" />
                            <asp:HiddenField ID="hdnAMOUNT_3" Value='<%# Eval("AMOUNT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForAMOUNT_3" Value='<%# Eval("TAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPAL_3" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForPRINCIPAL_3" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnINSTAMT_3" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForINSTAMT_3" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnMTRCNTRNO_3" Value='<%# Eval("MTRCNTRNO")%>' runat="server" />
                            <asp:HiddenField ID="hdnISSUE_3"  Value='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server" />
                        </td>
		                    <td style="width:3%">
		                      <asp:DropDownList ID="drpTAXTYPE_3" Enabled="false" runat="server">
                                <asp:ListItem Value="1">應稅</asp:ListItem>
                                <asp:ListItem Value="2">零稅</asp:ListItem>
                                <asp:ListItem Value="3">免稅</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETID_3"   Text='<%# Eval("TARGETID")%>'  CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETNAME_3"  Text='<%# Eval("TARGETNAME")%>'   CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="text-align:right;width:4%"><asp:Label ID="lblMONTHPAY_3"  Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>
		                    <td style="text-align:left;width:21%">
		                     <asp:TextBox ID="txtINVZIPCODE_3"   Text='<%# Eval("INVZIPCODE")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" style="width:50px" onblur="PostCodeBlure(this)"  CssClass="txt_table" ></asp:TextBox>
                             <input type="button" id="btnINVZIPCODE_3" class="btn_normal" onclick="PostCodeClick(this);"  style="padding:2px;" value="&#8230;" />
                             <asp:TextBox ID="txtINVZIPCODES_3"   Text='<%# Eval("INVZIPCODES")%>'  runat="server" CssClass="txt_table" style="width:120px"  onfocus="ObjMFocus(this,'txtINVZIPCODES_3','txtINVOICEADDR_3');"  ></asp:TextBox>
                             <asp:TextBox ID="txtINVOICEADDR_3"   Text='<%# Eval("INVOICEADDR")%>'  runat="server" CssClass="txt_table"  style="width:180px" MaxLength="100"  onblur="CheckMLength(this,'100');"  ></asp:TextBox>
		                    </td>
		                    <td style="width:3%"><asp:TextBox ID="txtORDERDAY_3"   Text='<%# Eval("ORDERDAY")%>' CssClass="txt_table" style="width:90%" runat="server"></asp:TextBox></td>
		                    <td>
		                      <asp:DropDownList ID="drpINVKIND_3" runat="server" Enabled="false" >
                                <asp:ListItem Value="2">二聯式</asp:ListItem>
                                <asp:ListItem Value="3">三聯式</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="text-align:left;width:3%">
		                    <asp:Button ID="btnBZ_3" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click2(this,'btnBZ_3','hdnBZ_3','tabInvoDtl_3');"   runat="server" Text="備註" />
                            <asp:HiddenField ID="hdnBZ_3"  Value='<%# Eval("BZ")%>' runat="server" />
		                    <td style="width:3%"><asp:Label ID="spanFGSPLIT_3"  Text='<%# Eval("FGSPLITNME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSPLIT2"  Value='<%# Eval("FGSPLIT")%>' runat="server" /></td>
		                    <td style="width:4%"><asp:Label ID="spanFGSINGLE_3"  Text='<%# Eval("FGSINGLENME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSINGLE2"  Value='<%# Eval("FGSINGLE")%>' runat="server" /></td>
		                    <td style="width:6%"><asp:Label ID="spanFGSUMMARY_3"  Text='<%# Eval("MTRCNTRNO")%>' runat="server"></asp:Label></td>
		                    </td>
		                  </tr>
		                    </ItemTemplate>
		                    </asp:Repeater>
		         
		                </table>
		            </div>
                </div>
                <%--動保費收入發票End --%>                
                <%--墊款息收入發票Begin --%>
                <div id="fraTab44" class="div_content padleft_0 T_-72" style="display: none">
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
                        <div class="div_title">發票內容設定</div>
                        <table  cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="tabCntrInvInfo_4">
                            <tr>
                              <th width="15%">發票開起月</th>
                              <td width="15%"><asp:TextBox ID="txtRENTSTDTM_4" CssClass="txt_normal" MaxLength="7" runat="server"></asp:TextBox></td>
                              <th width="10%">指定日期</th>
                              <td width="10%"><asp:TextBox ID="txtRENTSTDTD_4" MaxLength="2" CssClass="txt_normal" runat="server">1</asp:TextBox></td>
                              <th width="10%">發票聯式</th>
                              <td width="10%">
		                          <asp:DropDownList ID="drpINVKIND1_4" runat="server" >
                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                    <asp:ListItem Value="2">二聯式</asp:ListItem>
                                    <asp:ListItem Value="3">三聯式</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td width="30%">&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div style="width:98%;border:1px solid #9FA1AD;margin-left:5px;margin-top:10px;">
	                    <div class="div_title">備註設定</div>
	                    <table id="tabCntrInvRmkInfo_4"  cellpadding="1" cellspacing="1" class="tb_Info" runat="server">
                          <tr runat="server">
                            <th id="TH2_4" runat="server" style="width:30%">墊款息收入<asp:HiddenField ID="hdnPREINVNOTEID3_4" runat="server" /></th>
                            <td id="TD28_4" runat="server" style="width:30%"><asp:CheckBox ID="chk31_4" runat="server" Text="合約編號" />&nbsp;</td>
                            <td id="TD23_4" runat="server">
                              <asp:Button ID="btn31_4" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click('hdnSPECNOTE3_4');"  runat="server" Text="特殊備註" />
                              <asp:HiddenField ID="hdnSPECNOTE3_4" Value="" runat="server" />
                            </td>
                          </tr>
	                    </table>
                        <div class="btn_div">
                            <asp:Button ID="btnUS_4" runat="server" Text="發票展期" OnClientClick="JavaScript: return btnUS_4_onClick(this);" CssClass="btn_normal" onclick="btnUS_4_Click"/>
                        </div>
                    </div>
					<div class="div_table" style="overflow:auto;margin-left:5px;margin-top:10px;height:375px;">
		                <table class="tb_Contact" style="width:215%;" id="tabInvoDtl_4" onkeydown="tb_Contact_onkeydown(event);">
		                  <tr>
		                    <th style="width:2%">期數</th>
		                    <th style="width:5%">單體編號</th>
		                    <th style="width:5%">預計開立方式</th>
		                    <th style="width:4%">租金年月</th>
		                    <th style="width:5%">預開發票年月</th>
		                    <th style="width:4%">發票品名</th>
		                    <th style="width:3%">稅率</th>
		                    <th style="width:4%">對象統編</th>
		                    <th style="width:12%">對象名稱</th>
		                    <th style="width:4%">月付款</th>
		                    <th style="width:20%">發票地址</th>
		                    <th style="width:3%">指定日</th>
		                    <th style="width:3%">發票聯式</th>
		                    <th style="width:3%">備註</th>
		                    <th style="width:3%">拆發票</th>
		                    <th style="width:4%">單體彙開</th>
		                    <th style="width:6%">總體彙開</th>
		                  </tr>
		                  <asp:Repeater ID="rptData_4" runat="server">
                      <ItemTemplate>
		                  <tr  onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
		                    <td style="width:2%">
                                <asp:HiddenField ID="hdnPREINVID_4" Value='<%# Eval("PREINVID")%>' runat="server" />
                                <asp:HiddenField ID="hdnUNITID_4" Value='<%# Eval("UNITID")%>' runat="server" />
                                <asp:HiddenField ID="hdnRENTALPREIOD_4" Value="" runat="server" />
                                <asp:HiddenField ID="hdnLLVLNUM_4" Value="" runat="server" />
                                <asp:HiddenField ID="hdnACTACCOUNT_4" Value="" runat="server" />
                                <asp:HiddenField ID="hdnSPECNOTE_4" Value="" runat="server" />
                                <asp:HiddenField ID="hdnRENTYEARS_4" Value="0" runat="server" />
                                <asp:Label ID="lblISSUE_4"  Text='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server"></asp:Label></td>
		                    <td style="width:5%"><asp:Label ID="lblUNITID_4"  Text='<%# Eval("UNITID")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%">
		                      <asp:DropDownList ID="drpPREOPENWAY_4" runat="server">
                                <asp:ListItem Value="1">單筆開立</asp:ListItem>
                                <asp:ListItem Value="2">批次開立</asp:ListItem>
                                <asp:ListItem Value="3">暫不開立</asp:ListItem>
                          </asp:DropDownList>
		                    </td>
		                    <td style="width:4%"><asp:Label ID="lblRENTYEARS_4"  Text='<%# Eval("RENTYEARS")%>' runat="server"></asp:Label></td>
		                    <td style="width:6%"><asp:Label ID="lblPREINVYYYYMM_4"  Text='<%# Eval("PREINVYYYYMM")%>' runat="server"></asp:Label><asp:TextBox ID="txtPREINVYYYYMM_4" Text='<%# Eval("PREINVYYYYMM")%>' style="display:none;" CssClass="txt_table" runat="server"></asp:TextBox></td>
		                    <td style="width:4%">
                           <input type="button" id="btnINVDESC_4" class="btn_normal" onclick="return FrmML4001A_1Click(this, 'hdnINVDESC_4', 'hdnAMOUNT_4', 'hdnTAX_4', 'hdnPRINCIPAL_4', 'hdnINSTAMT_4', 'hdnISSUE_4');" value="品名設定" style="padding:2px;" />
                            <asp:HiddenField ID="hdnINVDESCTYPE_4" Value='<%# Eval("INVDESCTYPE")%>' runat="server" />
                            <asp:HiddenField ID="hdnINVDESC_4" Value='<%# Eval("INVDESC")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPALDESC_4" Value="" runat="server" />
                            <asp:HiddenField ID="hdnINSTDESC_4" Value="" runat="server" />
                            <asp:HiddenField ID="hdnAMOUNT_4" Value='<%# Eval("AMOUNT")%>' runat="server" />
                            <asp:HiddenField ID="hdnTAXForAMOUNT_4" Value='<%# Eval("TAX")%>' runat="server" />
                            <asp:HiddenField ID="hdnPRINCIPAL_4" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForPRINCIPAL_4" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnINSTAMT_4" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnTAXForINSTAMT_4" Value="0" runat="server" />
                            <asp:HiddenField ID="hdnMTRCNTRNO_4" Value='<%# Eval("MTRCNTRNO")%>' runat="server" />
                            <asp:HiddenField ID="hdnISSUE_4"  Value='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>' runat="server" />
                        </td>
		                    <td style="width:3%">
		                      <asp:DropDownList ID="drpTAXTYPE_4" Enabled="false" runat="server">
                                <asp:ListItem Value="1">應稅</asp:ListItem>
                                <asp:ListItem Value="2">零稅</asp:ListItem>
                                <asp:ListItem Value="3">免稅</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETID_4"   Text='<%# Eval("TARGETID")%>'  CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="width:6%"><asp:TextBox ID="txtTARGETNAME_4"  Text='<%# Eval("TARGETNAME")%>'   CssClass="txt_table" style="width:95%" runat="server"></asp:TextBox></td>
		                    <td style="text-align:right;width:4%"><asp:Label ID="lblMONTHPAY_4"  Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY").ToString()).ToString("#,##0")%>' runat="server"></asp:Label></td>
		                    <td style="text-align:left;width:21%">
		                     <asp:TextBox ID="txtINVZIPCODE_4"   Text='<%# Eval("INVZIPCODE")%>'  onkeyup="CheckNumber_keyup(this);" MaxLength="6" runat="server" style="width:50px" onblur="PostCodeBlure(this)"  CssClass="txt_table" ></asp:TextBox>
                             <input type="button" id="btnINVZIPCODE_4" class="btn_normal" onclick="PostCodeClick(this);"  style="padding:2px;" value="&#8230;" />
                             <asp:TextBox ID="txtINVZIPCODES_4"   Text='<%# Eval("INVZIPCODES")%>'  runat="server" CssClass="txt_table" style="width:120px"  onfocus="ObjMFocus(this,'txtINVZIPCODES_4','txtINVOICEADDR_4');"  ></asp:TextBox>
                             <asp:TextBox ID="txtINVOICEADDR_4"   Text='<%# Eval("INVOICEADDR")%>'  runat="server" CssClass="txt_table"  style="width:180px" MaxLength="100"  onblur="CheckMLength(this,'100');"  ></asp:TextBox>
		                    </td>
		                    <td style="width:3%"><asp:TextBox ID="txtORDERDAY_4"   Text='<%# Eval("ORDERDAY")%>' CssClass="txt_table" style="width:90%" runat="server"></asp:TextBox></td>
		                    <td>
		                      <asp:DropDownList ID="drpINVKIND_4" runat="server" Enabled="false" >
                                <asp:ListItem Value="2">二聯式</asp:ListItem>
                                <asp:ListItem Value="3">三聯式</asp:ListItem>
                              </asp:DropDownList>
		                    </td>
		                    <td style="text-align:left;width:3%">
		                    <asp:Button ID="btnBZ_4" CssClass="btn_normal" OnClientClick="return FrmML4001A_2Click2(this,'btnBZ_4','hdnBZ_4','tabInvoDtl_4');"   runat="server" Text="備註" />
                            <asp:HiddenField ID="hdnBZ_4"  Value='<%# Eval("BZ")%>' runat="server" />
		                    <td style="width:3%"><asp:Label ID="spanFGSPLIT_4"  Text='<%# Eval("FGSPLITNME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSPLIT2"  Value='<%# Eval("FGSPLIT")%>' runat="server" /></td>
		                    <td style="width:4%"><asp:Label ID="spanFGSINGLE_4"  Text='<%# Eval("FGSINGLENME")%>' runat="server"></asp:Label><asp:HiddenField ID="hdnFGSINGLE2"  Value='<%# Eval("FGSINGLE")%>' runat="server" /></td>
		                    <td style="width:6%"><asp:Label ID="spanFGSUMMARY_4"  Text='<%# Eval("MTRCNTRNO")%>' runat="server"></asp:Label></td>
		                    </td>
		                  </tr>
		                    </ItemTemplate>
		                    </asp:Repeater>
		         
		                </table>
		            </div>
                </div>
                <%--墊款息收入發票End --%>
            </div>
        </div>
        <table class="tb_Contact" id="tabMLDPREINVSPLIT" style="margin:5px;display:none;" runat="server" width="99%">
          <tr>
            <th>發票群組</th>
            <th>對象統編</th>
            <th>對象抬頭</th>
            <th>單體編號</th>
            <th>月付款</th>
            <th>郵遞區號</th>
            <th>郵遞區號地址</th>
            <th>寄送地址</th>
          </tr>
        </table>
    <div id="divBlock" style="text-align:center; vertical-align:bottom; border-style: solid; border-width: 1px; z-index: 1; position: absolute; top: 1px; left: 11px; height:375px; width: 98%; background-color: #808080;filter: Alpha(Opacity=80);display:none;">   
        <img style="text-align:center;  vertical-align:bottom; width: 751px; height: 198px;" src="images/processing.jpg" />  
    </div>  
        <br /><br /><br /><br /><br /><br />
       <div class="btn_div">
        <asp:DropDownList ID="drpCODE" style="display:none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
            <asp:Button ID="btnExtInvo" runat="server" Text="展期確認" CssClass="btn_normal" OnClientClick="JavaScript: return btnExtInvo_onClick(this);" OnClick="btnExtInvo_Click"/>
       </div>
    </div>
    </form>
</body>
</html>
