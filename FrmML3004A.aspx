<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3004																					
* 程式功能  : 撥款確認(財務)																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
20161125 ADD BY SS ADAM REASON.增加預撥沖銷
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3004A.aspx.cs" Inherits="FrmML3004A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <base target="_self" />
  <meta http-equiv=Content-Type content="text/html; charset=big5">
  <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv=Pragma content=no-cache>
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript">
    <!-- #Include file='js/ML3004A.js' -->                   
  </script>

</head>
<body onload="window_onload()">
  <form id="form1" runat="server">
  <div class="divBody" id="divBody">
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
    <table class="divStatus" width="98%">
      <tr>
        <th>
          合約編號
        </th>
        <td>
          <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly"
            ReadOnly="true"></asp:TextBox>
        </td>
        <th>
          案件編號
        </th>
        <td>
          <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
        </td>
        
        <th>
          撥款申請日
        </th>
        <td>
          <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
            ReadOnly="true"></asp:TextBox>
        </td>
        <td>
          <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
        </td>
      </tr>
    </table>
    <div id="fraDispTypeInfo" class="frame_content div_Info H_1100">
      <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
        class="sheet div_menu W_373">
        <label class="label_contain">
          撥款資料</label>
      </div>
      <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
        class="sheet div_menu T_-24 L_375 W_374">
        <label class="label_contain">
          標的物</label>
      </div>
      <div id="fraTab11" class="div_content padleft_0" style="top: -15px;">
        <div class="div_title">
          合約資料</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="12%">
              案件起租日
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPRENTSTDT" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th width="15%">
              客戶首期繳納日
            </th>
            <td width="12%">
              <asp:TextBox ID="txtCUSTFPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th width="12%">
              預計撥款日
            </th>
            <td>
              <asp:TextBox ID="txtPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              手續費收入
            </th>
            <td>
              <asp:TextBox ID="txtRRFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              設備金額
            </th>
            <td>
              <asp:TextBox ID="txtRRTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              頭期款
            </th>
            <td>
              <asp:TextBox ID="txtRRFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              履約保證金
            </th>
            <td>
              <asp:TextBox ID="txtRRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              租購保證金
            </th>
            <td>
              <asp:TextBox ID="txtRRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
          </tr>
        </table>
        <br>
        <div class="div_title">
          進項發票</div>
        <div class="div_table" style="overflow: auto; margin: 4px; height: 100px">
          <table class="tb_Contact" width="2200px" style="margin: 0px;">
            <tr>
              <th>
                項次
              </th>
              <th>
                憑證號碼
              </th>
              <th>
                發票日期
              </th>
              <th>
                未稅金額
              </th>
              <th>
                稅額
              </th>
              <th>
                含稅金額
              </th>
              <th>
                抵履約保證金
              </th>
              <th>
                抵租購保證金
              </th>
              <th>
                抵頭期款
              </th>
              <th>
                業代自付額
              </th>
              <th>
                實撥金額
              </th>
              <th>
                履約保證金票據
              </th>
              <th>
                租購保證金票據
              </th>
              <th>
                頭期款票據
              </th>
              <th>
                供應商
              </th>
              <th>
                匯款項次
              </th>
              <th>
                匯款銀行
              </th>
              <th>
                分行
              </th>
              <th>
                戶名
              </th>
              <th>
                帳號
              </th>
            </tr>
            <asp:Repeater ID="rptMLDCONTRACTINV" runat="server">
              <ItemTemplate>
                <tr>
                  <td>
                    <%# Container.ItemIndex +1 %>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCERTIFICATENO" ReadOnly="true" Text='<%# Eval("CERTIFICATENO")%>'
                      Width="96px" runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtINVDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtNOTAXAMOUNT" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOTAXAMOUNT").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtTAX" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("TAX").ToString()) %>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:Label ID="lblANOUMTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                      runat="server"></asp:Label>
                    <asp:HiddenField ID="hidANOUMTTAX" Value='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                      runat="server" />
                  </td>
                  <td>
                    <asp:TextBox ID="txtPERBONDUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDUSED").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtHIREPURUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("HIREPURUSED").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtFIRSTPAYUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYUSED").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtINVSALESPAY" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("INVSALESPAY").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtACTUALLYAMOUNT" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtPERBONDNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDNOTE").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtPURCHASENOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PURCHASENOTE").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtFIRSTPAYNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYNOTE").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtSUPPLIERS" Width="160px" ReadOnly="true" runat="server" CssClass="txt_table"
                      Text='<%# Eval("SUPPLIERS")%>'></asp:TextBox>
                    <asp:HiddenField ID="hidSUPPLIER" Value='<%# Eval("SUPPLIER") %>' runat="server" />
                    <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                  </td>
                  <td>
                    <asp:Label ID="lblSUPSEQ" Text='<%# Eval("SUPSEQ")%>' runat="server"></asp:Label>
                  </td>
                  <td>
                    <asp:TextBox ID="txtBANKNM" ReadOnly="true" runat="server" CssClass="txt_table" Width="160px"
                      Text='<%# Eval("BANKNM")%>'></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCOMPNM" ReadOnly="true" runat="server" CssClass="txt_table" Width="160px"
                      Text='<%# Eval("COMPNM")%>'></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtRV_NAME" ReadOnly="true" runat="server" CssClass="txt_table"
                      Width="160px" Text='<%# Eval("RV_NAME")%>'></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtRVACNT" ReadOnly="true" runat="server" CssClass="txt_table" Width="132px"
                      Text='<%# Eval("RVACNT")%>'></asp:TextBox>
                  </td>
                </tr>
              </ItemTemplate>
            </asp:Repeater>
          </table>
        </div>
        <br>
        <br>
        <div class="div_title">
          進項折讓發票</div>
        <div class="div_table" style="overflow: auto; margin: 4px; height: 100px">
          <table class="tb_Contact" width="80%" style="margin: 4px;">
            <tr>
              <th>
                項次
              </th>
              <th>
                折讓發票號碼
              </th>
              <th>
                折讓日
              </th>
              <th>
                折讓未稅金額
              </th>
              <th>
                折讓稅額
              </th>
              <th>
                折讓含稅金額
              </th>
            </tr>
            <asp:Repeater ID="rptMLDCONTRACTINVD" runat="server">
              <ItemTemplate>
                <tr>
                  <td>
                    <%# Container.ItemIndex +1 %>
                    <asp:HiddenField ID="hidDISCOUNTINVOICEID" Value='<%# Eval("DISCOUNTINVOICEID") %>'
                      runat="server" />
                  </td>
                  <td>
                    <asp:TextBox ID="txtDISCOUNTINVNUM" ReadOnly="true" Text='<%# Eval("DISCOUNTINVNUM")%>'
                      Width="96px" runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtDISCOUNTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DISCOUNTDATE").ToString()) %>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtDISCOUNTAMOUNT" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtDISCOUNTTAX" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtDISCOUNTAMOUNTTAX" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                </tr>
              </ItemTemplate>
            </asp:Repeater>
          </table>
        </div>
          <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                    <div class="div_title" style="margin-left: -10px;">
                        指定付款他人</div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        <table class="tb_Contact" width="1400px">
                        <tr>
                            <th>
                                項次
                            </th>
                            <th>
                                憑證號碼
                            </th>
                            <th>
                                收款人
                            </th>
                            <th>
                                匯款項次
                            </th>
                            <th>
                                匯款銀行
                            </th>
                            <th>
                                分行
                            </th>
                            <th>
                                戶名
                            </th>
                            <th>
                                帳號
                            </th>
                            <th>
                                金額
                            </th>
                        </tr>
                        <asp:Repeater ID="rptMLDASSPAYMF" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCERTNO" runat="server" Text='<%# Eval("CERTNO") %>'
                                            CssClass="txt_table" Width="120px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPAYEE" runat="server" Text='<%# Eval("PAYEE") %>'
                                            CssClass="txt_table" Width="110px" Enabled="false"></asp:TextBox>
                                        <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                            onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px;
                                            padding: 2px;" value="&#8230;" />
                                        <asp:TextBox ID="txtPAYEENM" runat="server" Text='<%# Eval("PAYEENM") %>'
                                            CssClass="txt_table" Width="180px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSUPSEQ" runat="server" Text='<%# Eval("SUPSEQ") %>' 
                                            CssClass="txt_table" Width="40px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTRANSBANK" runat="server" Text='<%# Eval("TRANSBANK") %>'
                                            CssClass="txt_table" Width="200px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSUBBANK" runat="server" Text='<%# Eval("SUBBANK") %>'
                                            CssClass="txt_table" Width="140px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtACCNM" runat="server" Text='<%# Eval("ACCNM") %>'
                                            CssClass="txt_table" Width="180px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtACC" runat="server" Text='<%# Eval("ACC") %>'
                                            CssClass="txt_table" Width="160px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTRANSAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TRANSAMT").ToString()) %>'
                                            CssClass="txt_table_right" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        預撥沖銷</div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        前次沖銷 <asp:Button ID="btnPREPAY" runat="server" CssClass="btn_normal" Text="查詢" Enabled="false" />
                        <br />
                        本次沖銷
                        <br />
                        <table class="tb_Contact" width="100%">
                        <tr>
                            <th>
                                項次
                            </th>
                            <th>
                                預撥對象
                            </th>
                            <th>
                                累計預撥
                            </th>
                            <th>
                                本次沖銷
                            </th>
                            <th>
                                剩餘預撥
                            </th>
                            <th>
                                本次墊款息
                            </th>
                        </tr>
                        <asp:Repeater ID="rptMLDPREPAYWOFF" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                         <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPREPAYOBJ" runat="server" Text='<%# Eval("PREPAYOBJ") %>'
                                            CssClass="txt_table" Width="160px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTOTALPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TOTALPREPAYAMT").ToString()) %>'
                                            CssClass="txt_table_right" Width="120px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNOWPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOWPREPAYAMT").ToString()) %>'
                                            CssClass="txt_table_right" Width="120px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLASTPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("LASTPREPAYAMT").ToString()) %>'
                                            CssClass="txt_table_right" Width="120px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtADVANCESINTEREST" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("ADVANCESINTEREST").ToString()) %>'
                                            CssClass="txt_table_right" Width="100px" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        手續費收入</div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                        <tr>
                            <th>
                                項次
                            </th>
                            <th>
                                身分
                            </th>
                            <th>
                                統編
                            </th>
                            <th>
                                對象
                            </th>
                            <th>
                                手續費
                            </th>
                            <th>
                                支付方式
                            </th>
                        </tr>
                        <asp:Repeater ID="rptMLDFEEINCOME1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpCUSTTYPE" runat="server" Enabled="false">
                                            <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                            <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                            CssClass="txt_table" Width="100px" Enabled="false"></asp:TextBox>
                                        <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                            onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px;
                                            padding: 2px;" value="&#8230;" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                            CssClass="txt_table" Width="180px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                            runat="server"  CssClass="txt_table_right" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                            <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                            <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        重車動保手續費收入</div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                        <tr>
                            <th>
                                項次
                            </th>
                            <th>
                                身分
                            </th>
                            <th>
                                統編
                            </th>
                            <th>
                                對象
                            </th>
                            <th>
                                手續費
                            </th>
                            <th>
                                支付方式
                            </th>
                        </tr>
                            <asp:Repeater ID="rptMLDFEEINCOME2" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpCUSTTYPE" runat="server" Enabled="false">
                                            <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                            <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                            CssClass="txt_table" Width="100px" Enabled="false"></asp:TextBox>
                                        <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                            onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px;
                                            padding: 2px;" value="&#8230;" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                            CssClass="txt_table" Width="180px" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                            runat="server"  CssClass="txt_table_right" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                            <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                            <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
        <div class="div_title">
          抵設備款資料</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="20%">
              履約保證金抵設備款
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPERBONDUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="15%">
              履約保證金票據
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPERBONDNOTE" ReadOnly="true" runat="server" CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="20%">
              租購保證金抵設備款
            </th>
            <td>
              <asp:TextBox ID="txtPURCHASEUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              租購保證金票據
            </th>
            <td>
              <asp:TextBox ID="txtPURCHASENOTE" ReadOnly="true" runat="server" CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th>
              頭期款抵設備款
            </th>
            <td>
              <asp:TextBox ID="txtFIRSTPAYUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th>
              頭期款票據
            </th>
            <td>
              <asp:TextBox ID="txtFIRSTPAYNOTE" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              業代自付額
            </th>
            <td>
              <asp:TextBox ID="txtSALESPAY" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
              <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                            <th>
                                手續費抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtFEEAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>
                                沖預撥抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtPREPAYWOFFAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
          </tr>
        </table>
        <br />
        <div class="div_title">
          撥款資料</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="18%">
              進項總額
            </th>
            <td width="15%">
              <asp:TextBox ID="txtDISCOUNTTOTAL" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="18%">
              進項稅額
            </th>
            <td width="15%">
              <asp:TextBox ID="txtDISCOUNTTAX" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="15%">
              實撥金額
            </th>
            <td>
              <asp:TextBox ID="txtACTUALLYAMOUNT" ReadOnly="true" custprop="100" MaxLength="9"
                runat="server" CssClass="txt_normal_right"></asp:TextBox>
            </td>
          </tr>
        </table>
      </div>
      <div id="fraTab22" class="div_content padleft_0" style="top: -15px;">
        <div class="div_title">
          標的物</div>
        <div class="div_table" style="overflow: scroll; height: 100px">
          <table class="tb_Contact" style="width: 1000px;">
            <tr>
              <th>
                項次
              </th>
              <th>
                標的物種類
              </th>
              <th>
                標的物名稱
              </th>
              <th>
                設備狀況
              </th>
              <th>
                型號
              </th>
              <th>
                機號
              </th>
              <th>
                供應商ID
              </th>
              <th>
                供應商
              </th>
              <th>
                價格
              </th>
              <th>
                價格未稅
              </th>
              <th>
                耐用年限
              </th>
            </tr>
            <asp:Repeater ID="rptMLDCASETARGET" runat="server">
              <ItemTemplate>
                <tr>
                  <td>
                    <%# Container.ItemIndex +1 %>
                  </td>
                  <td>
                    <asp:DropDownList ID="drpTARGETTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                      class="bg_normal" runat="server">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                  </td>
                  <td>
                    <asp:TextBox ID="txtTARGETNAME" ReadOnly="true" Text='<%# Eval("TARGETNAME")%>' runat="server"
                      CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:DropDownList ID="drpTARGETSTATUS" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                      runat="server">
                      <asp:ListItem>新機</asp:ListItem>
                    </asp:DropDownList>
                  </td>
                  <td>
                    <asp:TextBox ID="txtTARGETMODELNO" ReadOnly="true" Text='<%# Eval("TARGETMODELNO")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtTARGETMACHINENO" ReadOnly="true" Text='<%# Eval("TARGETMACHINENO")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtSUPPLIERID" ReadOnly="true" Text='<%# Eval("SUPPLIERID")%>' Width="80px"
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtSUPPLIERIDS" ReadOnly="true" Text='<%# Eval("SUPPLIERIDS")%>'
                      Width="160px" runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtTARGETPRICE" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>'
                      runat="server" CssClass="txt_table_right"></asp:TextBox>
                  </td>
                  <td>
                    <asp:Label ID="lblTARGETPRICENOTAX" readonly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>'
                      runat="server"></asp:Label>
                  </td>
                  <td>
                    <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                  </td>
                </tr>
              </ItemTemplate>
            </asp:Repeater>
          </table>
        </div>
        <asp:CheckBox ID="chkAr1" runat="server" Enabled="false" Checked="true" />
        AR案件無標的物
        <br />
        <br />
        <div class="div_title">
          設備存放地</div>
        <div class="div_table" style="overflow: scroll; height: 100px">
          <table class="tb_Contact" style="width: 1200px;">
            <tr>
              <th>
                項次
              </th>
              <th>
                存放地
              </th>
              <th>
                聯絡人
              </th>
              <th>
                部門
              </th>
              <th>
                職稱
              </th>
              <th>
                聯絡電話
              </th>
              <th>
                手機
              </th>
              <th>
                傳真
              </th>
              <th>
                E-mail
              </th>
            </tr>
            <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
              <ItemTemplate>
                <tr>
                  <td>
                    <%# Container.ItemIndex +1 %>
                  </td>
                  <td width="370px">
                    <asp:TextBox ID="txtSTOREDZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                      Text='<%# Eval("STOREDZIPCODE")%>'></asp:TextBox>
                    <asp:TextBox ID="txtSTOREDZIPCODES" ReadOnly="true" runat="server" Width="120px"
                      CssClass="txt_table" Text='<%# Eval("STOREDZIPCODES")%>'></asp:TextBox>
                    <asp:TextBox ID="txtSTOREDADDR" ReadOnly="true" runat="server" CssClass="txt_table"
                      Width="150px" Text='<%# Eval("STOREDADDR")%>'></asp:TextBox>
                    <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTNAME" ReadOnly="true" Text='<%# Eval("CONTACTNAME")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtDEPTNAME" ReadOnly="true" Text='<%# Eval("DEPTNAME")%>' runat="server"
                      CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTTITLE" ReadOnly="true" Text='<%# Eval("CONTACTTITLE")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTTELCODE" Width="20px" ReadOnly="true" runat="server" Text='<%# Eval("CONTACTTELCODE")%>'
                      CssClass="txt_table" />
                    <asp:TextBox ID="txtCONTACTTEL" ReadOnly="true" Text='<%# Eval("CONTACTTEL")%>' runat="server"
                      CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTMPHONE" ReadOnly="true" Text='<%# Eval("CONTACTMPHONE")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTFAXCODE" ReadOnly="true" Width="20px" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>'
                      CssClass="txt_table" />
                    <asp:TextBox ID="txtCONTACTFAX" ReadOnly="true" Text='<%# Eval("CONTACTFAX")%>' runat="server"
                      CssClass="txt_table"></asp:TextBox>
                  </td>
                  <td>
                    <asp:TextBox ID="txtCONTACTEMAIL" ReadOnly="true" Text='<%# Eval("CONTACTEMAIL")%>'
                      runat="server" CssClass="txt_table"></asp:TextBox>
                  </td>
                </tr>
              </ItemTemplate>
            </asp:Repeater>
          </table>
        </div>
        <asp:CheckBox ID="chkAr2" runat="server" Enabled="false" Checked="true" />
        AR案件無標的物存放地<br />
        <br />
        <div class="div_title">
          AR案件發票暨背書人</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="10%">
              發票人
            </th>
            <td>
              <asp:TextBox ID="txtBILLNOTECUSTID" ReadOnly="true" CssClass="txt_normal" Width="120px"
                runat="server"></asp:TextBox>
              <asp:TextBox ID="txtBILLNOTECUST" ReadOnly="true" CssClass="txt_normal" Width="300px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              銀行/分行
            </th>
            <td>
              <asp:TextBox ID="txtDEPOSITBANKS" ReadOnly="true" CssClass="txt_normal" Width="427px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              帳號
            </th>
            <td>
              <asp:TextBox ID="txtACCOUNT" ReadOnly="true" CssClass="txt_normal" Width="300px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              背書人
            </th>
            <td>
              <asp:TextBox ID="txtENDORSERID" ReadOnly="true" CssClass="txt_normal" Width="120px"
                runat="server"></asp:TextBox>
              <asp:TextBox ID="txtENDORSER" ReadOnly="true" CssClass="txt_normal" Width="300px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
        </table>
      </div>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSubmit" runat="server" Text="確認" CssClass="btn_normal" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;
      <!--Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.-->
      <asp:Button ID="btnReturn" runat="server" Text="案件退回" CssClass="btn_normal" OnClick="btnReturn_Click" />&nbsp;&nbsp;&nbsp;
      <!--Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕.-->
      <%--Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.--%>
      <%--<asp:Button ID="btnRecheck" runat="server" Text="關係人檢核" CssClass="btn_normal" OnClientClick="Recheck();" />--%>
      <asp:Button ID="btnRecheck" runat="server" Text="關係人檢核列印" CssClass="btn_normal" onclick="btnRecheck_Click" />
      <asp:TextBox ID="hdnPRINTKEY" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
      <asp:TextBox ID="SessUSERID" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
      <asp:TextBox ID="SessDEPTNM" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
      <asp:TextBox ID="hdnINDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
      <asp:TextBox ID="hdnTRADEDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
      <asp:TextBox ID="hdnCREDITDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
    </div>
  </div>
  </form>
</body>
</html>
