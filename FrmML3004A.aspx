<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3004																					
* �{���\��  : ���ڽT�{(�]��)																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.
Modify 20121210 By SS Steven. Reason: �u���Y�H�ˮ֡v���s�令�u���Y�H�ˮ֦C�L�v�A�åB�����C�L�X��.
20161125 ADD BY SS ADAM REASON.�W�[�w���R�P
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
          �X���s��
        </th>
        <td>
          <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly"
            ReadOnly="true"></asp:TextBox>
        </td>
        <th>
          �ץ�s��
        </th>
        <td>
          <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
        </td>
        
        <th>
          ���ڥӽФ�
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
          ���ڸ��</label>
      </div>
      <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
        class="sheet div_menu T_-24 L_375 W_374">
        <label class="label_contain">
          �Ъ���</label>
      </div>
      <div id="fraTab11" class="div_content padleft_0" style="top: -15px;">
        <div class="div_title">
          �X�����</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="12%">
              �ץ�_����
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPRENTSTDT" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th width="15%">
              �Ȥ᭺��ú�Ǥ�
            </th>
            <td width="12%">
              <asp:TextBox ID="txtCUSTFPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th width="12%">
              �w�p���ڤ�
            </th>
            <td>
              <asp:TextBox ID="txtPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              ����O���J
            </th>
            <td>
              <asp:TextBox ID="txtRRFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              �]�ƪ��B
            </th>
            <td>
              <asp:TextBox ID="txtRRTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              �Y����
            </th>
            <td>
              <asp:TextBox ID="txtRRFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              �i���O�Ҫ�
            </th>
            <td>
              <asp:TextBox ID="txtRRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
            <th>
              ���ʫO�Ҫ�
            </th>
            <td>
              <asp:TextBox ID="txtRRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                ReadOnly="true"></asp:TextBox>
            </td>
          </tr>
        </table>
        <br>
        <div class="div_title">
          �i���o��</div>
        <div class="div_table" style="overflow: auto; margin: 4px; height: 100px">
          <table class="tb_Contact" width="2200px" style="margin: 0px;">
            <tr>
              <th>
                ����
              </th>
              <th>
                ���Ҹ��X
              </th>
              <th>
                �o�����
              </th>
              <th>
                ���|���B
              </th>
              <th>
                �|�B
              </th>
              <th>
                �t�|���B
              </th>
              <th>
                ��i���O�Ҫ�
              </th>
              <th>
                �诲�ʫO�Ҫ�
              </th>
              <th>
                ���Y����
              </th>
              <th>
                �~�N�ۥI�B
              </th>
              <th>
                �꼷���B
              </th>
              <th>
                �i���O�Ҫ�����
              </th>
              <th>
                ���ʫO�Ҫ�����
              </th>
              <th>
                �Y���ڲ���
              </th>
              <th>
                ������
              </th>
              <th>
                �״ڶ���
              </th>
              <th>
                �״ڻȦ�
              </th>
              <th>
                ����
              </th>
              <th>
                ��W
              </th>
              <th>
                �b��
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
          �i�������o��</div>
        <div class="div_table" style="overflow: auto; margin: 4px; height: 100px">
          <table class="tb_Contact" width="80%" style="margin: 4px;">
            <tr>
              <th>
                ����
              </th>
              <th>
                �����o�����X
              </th>
              <th>
                ������
              </th>
              <th>
                �������|���B
              </th>
              <th>
                �����|�B
              </th>
              <th>
                �����t�|���B
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
          <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P START --%>
                    <div class="div_title" style="margin-left: -10px;">
                        ���w�I�ڥL�H</div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        <table class="tb_Contact" width="1400px">
                        <tr>
                            <th>
                                ����
                            </th>
                            <th>
                                ���Ҹ��X
                            </th>
                            <th>
                                ���ڤH
                            </th>
                            <th>
                                �״ڶ���
                            </th>
                            <th>
                                �״ڻȦ�
                            </th>
                            <th>
                                ����
                            </th>
                            <th>
                                ��W
                            </th>
                            <th>
                                �b��
                            </th>
                            <th>
                                ���B
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
                        �w���R�P</div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        �e���R�P <asp:Button ID="btnPREPAY" runat="server" CssClass="btn_normal" Text="�d��" Enabled="false" />
                        <br />
                        �����R�P
                        <br />
                        <table class="tb_Contact" width="100%">
                        <tr>
                            <th>
                                ����
                            </th>
                            <th>
                                �w����H
                            </th>
                            <th>
                                �֭p�w��
                            </th>
                            <th>
                                �����R�P
                            </th>
                            <th>
                                �Ѿl�w��
                            </th>
                            <th>
                                �����Դڮ�
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
                        ����O���J</div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                        <tr>
                            <th>
                                ����
                            </th>
                            <th>
                                ����
                            </th>
                            <th>
                                �νs
                            </th>
                            <th>
                                ��H
                            </th>
                            <th>
                                ����O
                            </th>
                            <th>
                                ��I�覡
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
                                            <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="�k�H" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="�ӤH" Value="02"></asp:ListItem>
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
                                            <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="�״�" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="����" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        �����ʫO����O���J</div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                        <tr>
                            <th>
                                ����
                            </th>
                            <th>
                                ����
                            </th>
                            <th>
                                �νs
                            </th>
                            <th>
                                ��H
                            </th>
                            <th>
                                ����O
                            </th>
                            <th>
                                ��I�覡
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
                                            <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="�k�H" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="�ӤH" Value="02"></asp:ListItem>
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
                                            <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                            <asp:ListItem Text="�״�" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="����" Value="02"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P END --%>
        <div class="div_title">
          ��]�ƴڸ��</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="20%">
              �i���O�Ҫ���]�ƴ�
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPERBONDUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="15%">
              �i���O�Ҫ�����
            </th>
            <td width="12%">
              <asp:TextBox ID="txtPERBONDNOTE" ReadOnly="true" runat="server" CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="20%">
              ���ʫO�Ҫ���]�ƴ�
            </th>
            <td>
              <asp:TextBox ID="txtPURCHASEUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              ���ʫO�Ҫ�����
            </th>
            <td>
              <asp:TextBox ID="txtPURCHASENOTE" ReadOnly="true" runat="server" CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th>
              �Y���ک�]�ƴ�
            </th>
            <td>
              <asp:TextBox ID="txtFIRSTPAYUSED" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th>
              �Y���ڲ���
            </th>
            <td>
              <asp:TextBox ID="txtFIRSTPAYNOTE" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              �~�N�ۥI�B
            </th>
            <td>
              <asp:TextBox ID="txtSALESPAY" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
              <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P START --%>
                            <th>
                                ����O��]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtFEEAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>
                                �R�w����]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtPREPAYWOFFAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P END --%>
          </tr>
        </table>
        <br />
        <div class="div_title">
          ���ڸ��</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="18%">
              �i���`�B
            </th>
            <td width="15%">
              <asp:TextBox ID="txtDISCOUNTTOTAL" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="18%">
              �i���|�B
            </th>
            <td width="15%">
              <asp:TextBox ID="txtDISCOUNTTAX" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="15%">
              �꼷���B
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
          �Ъ���</div>
        <div class="div_table" style="overflow: scroll; height: 100px">
          <table class="tb_Contact" style="width: 1000px;">
            <tr>
              <th>
                ����
              </th>
              <th>
                �Ъ�������
              </th>
              <th>
                �Ъ����W��
              </th>
              <th>
                �]�ƪ��p
              </th>
              <th>
                ����
              </th>
              <th>
                ����
              </th>
              <th>
                ������ID
              </th>
              <th>
                ������
              </th>
              <th>
                ����
              </th>
              <th>
                ���楼�|
              </th>
              <th>
                �@�Φ~��
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
                      <asp:ListItem>�s��</asp:ListItem>
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
        AR�ץ�L�Ъ���
        <br />
        <br />
        <div class="div_title">
          �]�Ʀs��a</div>
        <div class="div_table" style="overflow: scroll; height: 100px">
          <table class="tb_Contact" style="width: 1200px;">
            <tr>
              <th>
                ����
              </th>
              <th>
                �s��a
              </th>
              <th>
                �p���H
              </th>
              <th>
                ����
              </th>
              <th>
                ¾��
              </th>
              <th>
                �p���q��
              </th>
              <th>
                ���
              </th>
              <th>
                �ǯu
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
        AR�ץ�L�Ъ����s��a<br />
        <br />
        <div class="div_title">
          AR�ץ�o���[�I�ѤH</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="10%">
              �o���H
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
              �Ȧ�/����
            </th>
            <td>
              <asp:TextBox ID="txtDEPOSITBANKS" ReadOnly="true" CssClass="txt_normal" Width="427px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              �b��
            </th>
            <td>
              <asp:TextBox ID="txtACCOUNT" ReadOnly="true" CssClass="txt_normal" Width="300px"
                runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th>
              �I�ѤH
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
      <asp:Button ID="btnSubmit" runat="server" Text="�T�{" CssClass="btn_normal" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;
      <!--Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.-->
      <asp:Button ID="btnReturn" runat="server" Text="�ץ�h�^" CssClass="btn_normal" OnClick="btnReturn_Click" />&nbsp;&nbsp;&nbsp;
      <!--Modify 20121122 By SS Maureen. Reason: �s�W���Y�H�ˮ֫��s.-->
      <%--Modify 20121210 By SS Steven. Reason: �u���Y�H�ˮ֡v���s�令�u���Y�H�ˮ֦C�L�v�A�åB�����C�L�X��.--%>
      <%--<asp:Button ID="btnRecheck" runat="server" Text="���Y�H�ˮ�" CssClass="btn_normal" OnClientClick="Recheck();" />--%>
      <asp:Button ID="btnRecheck" runat="server" Text="���Y�H�ˮ֦C�L" CssClass="btn_normal" onclick="btnRecheck_Click" />
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
