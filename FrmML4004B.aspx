<%@ page language="C#" validaterequest="false" autoeventwireup="true" codefile="FrmML4004B.aspx.cs"
    inherits="FrmML4004B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>
        -<%=this.GSTR_PROGNM%></title>
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />

    <script language="javascript" type="text/javascript" src="js/UI.js"></script>

    <script language="javascript" type="text/javascript" src="js/ITG.js"></script>

    <script language="javascript" type="text/javascript" src="js/validate.js"></script>

    <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4004B.js' -->
    </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <div class="divBody" id="divBody" style="width: 95%">
            <div class="divTitle" runat="server" id="divTitle">
                �w�}�o����ƺ��@
            </div>
            <!--<div class="div_Info H_770"  style="width:98%">-->
            <div style="width: 98%">
                <div style="width: 97%; border: 1px solid #9FA1AD; margin-left: 5px; margin-top: 10px;">
                    <div class="div_title">
                        �X�����e
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" id="tabCntrInfo">
                        <tr>
                            <th style="width: 15%">�X���s��</th>
                            <td style="width: 18%">
                                <asp:TextBox ID="txtCNTRNO" CssClass="txt_readonly" ReadOnly="true" runat="server"
                                    Width="95%">
                                </asp:TextBox>
                            </td>
                            <th style="width: 15%">�ӧ@����</th>
                            <td style="width: 18%">
                                <asp:HiddenField ID="hdnSysDate" runat="server" />
                                <asp:HiddenField ID="hdnMAXINVRENTYM" runat="server" />
                                <asp:HiddenField ID="hdnCLSDT01" Value="" runat="server" />
                                <asp:HiddenField ID="hdnCLSDT02" Value="" runat="server" />
                                <asp:HiddenField ID="hdnChgSingle" Value="" runat="server" />
                                <asp:HiddenField ID="hdnFinalLevel" Value="" runat="server" />
                                <asp:HiddenField ID="hdnFGSPLIT" Value="2" runat="server" />
                                <asp:HiddenField ID="hdnCompId" Value="" runat="server" />
                                <asp:HiddenField ID="hdnPROCEDEINV" Value="" runat="server" />
                                <asp:HiddenField ID="hdnTTLRent" Value="" runat="server" />
                                <asp:HiddenField ID="hdnPREINVSETID" runat="server" />
                                <asp:HiddenField ID="hdnOPENMASTER" Value="" runat="server" />
                                <asp:HiddenField ID="hdnOPENCNTRNO" Value="" runat="server" />
                                <asp:HiddenField ID="hdnMAINTYPE" Value="" runat="server" />
                                <asp:HiddenField ID="hdnGUARSETRATE" runat="server" />
                                <asp:TextBox ID="txtMAINTYPENM" Style="width: 90%" CssClass="txt_readonly" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="txtSUBTYPENM" Style="width: 90%" CssClass="txt_readonly" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <td style="width: 18%; text-align: center;">
                                <b>
                                    <asp:Label ID="spanINVStarus" Style="display: ; color: #FF0000;" runat="server" Text="�w�i��"></asp:Label>
                                </b><b>
                                    <asp:Label
                                        ID="spanINVAPLY" Style="display: none; color: #990099;" runat="server" Text="�w�}��"></asp:Label>
                                </b></td>
                        </tr>
                        <tr>
                            <th>�Ȥ�W��</th>
                            <td colspan="5">
                                <asp:TextBox ID="txtCUSTID" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtINVZIPCODE" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtINVZIPCODES" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtINVOICEADDR" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtLLVLNUM01" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtLLVLNUM02" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtRVACNT" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtACTUSLLOANS" Style="display: none;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtCUSTNAME" CssClass="txt_readonly" ReadOnly="true" Width="200px"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�ץ�_����</th>
                            <td>
                                <asp:TextBox ID="txtRENTSTDT" custprop="000" CssClass="txt_readonly" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <th>�ץ󨴯���</th>
                            <td style="width: 191px">
                                <asp:TextBox ID="txtRENTENDT" custprop="000" CssClass="txt_readonly" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <th>�`����</th>
                            <td style="text-align: right;">
                                <asp:TextBox ID="txtCONTRACTMONTH" CssClass="txt_readonly_right" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�i���O�Ҫ�</th>
                            <td>
                                <asp:TextBox ID="txtPERBOND" runat="server" custprop="100" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="0">
                                </asp:TextBox>
                            </td>
                            <th>���ʫO�Ҫ�</th>
                            <td style="text-align: right; width: 191px">
                                <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="0">
                                </asp:TextBox>
                            </td>
                            <th>�Y����</th>
                            <td style="text-align: right;">
                                <asp:TextBox ID="txtFIRSTPAY" custprop="100" CssClass="txt_readonly_right" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>����ú�ڤ�</th>
                            <td>
                                <asp:TextBox ID="txtCUSTFPAYDATE" custprop="000" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>�X��@ú</th>
                            <td style="text-align: right; width: 191px">
                                <asp:TextBox ID="txtPAYMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th></th>
                            <td></td>
                        </tr>
                        <!--  UPD BY VICKY 20150129 MARK�_�� -->
                        <%--<tr>
                  <th>�믲��</th>
                  <td>
                    ��<asp:TextBox ID="txtRSTARTPAY1" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                    ~
                    ��<asp:TextBox ID="txtRENDPAY1" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                  </td>
                  <th>��I��(�t�|)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX1"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>��I��(���|)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL1"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    ��<asp:TextBox ID="txtRSTARTPAY2" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                    ~
                    ��<asp:TextBox ID="txtRENDPAY2" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                  </td>
                  <th>��I��(�t�|)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX2"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>��I��(���|)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL2"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    ��<asp:TextBox ID="txtRSTARTPAY3" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                    ~
                    ��<asp:TextBox ID="txtRENDPAY3" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                  </td>
                  <th>��I��(�t�|)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX3"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>��I��(���|)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL3"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th></th>
                  <td>
                    ��<asp:TextBox ID="txtRSTARTPAY4" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                    ~
                    ��<asp:TextBox ID="txtRENDPAY4" CssClass="txt_readonly_right" ReadOnly="true" Width="20px" runat="server"></asp:TextBox>��
                  </td>
                  <th>��I��(�t�|)</th>
                  <td style="text-align:right;width: 191px"><asp:TextBox ID="txtRPRINCIPALTAX4" custprop="100"  CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                  <th>��I��(���|)</th>
                  <td style="text-align:right;"><asp:TextBox ID="txtRPRINCIPAL4"  custprop="100" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>--%>
                    </table>
                </div>
                <%--UPD BY VICKY 20150130 �[�J�����b�ڰ϶�--%>
                <div style="width: 97%; border: 1px solid #9FA1AD; margin-left: 5px; margin-top: 10px;">
                    <div class="div_title">
                        �����b��
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="Table1">
                        <tr>
                            <th width="15%">�`�����i(��)��
                            </th>
                            <td width="18%">
                                <asp:TextBox ID="txtCONTRACTMONTH1" Width="95%" CssClass="txt_readonly_right" ReadOnly="true"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <th width="15%">�`�������ڪ��B
                            </th>
                            <td width="18%">
                                <asp:TextBox ID="txtBILLAMT" Width="90%" custprop="100" CssClass="txt_readonly_right"
                                    ReadOnly="true" runat="server">
                                </asp:TextBox>
                            </td>
                            <th width="15%">
                                <asp:Label ID="labSUMFINANCIALFEES" runat="server" Text="����O" Style="display: none;"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="txtSUMFINANCIALFEES" Width="90%" CssClass="txt_readonly_right" ReadOnly="true"
                                    runat="server" Style="display: none;">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 97%; border: 1px solid #9FA1AD; margin-left: 5px; margin-top: 10px;">
                    <div class="div_title">
                        �o�����e�]�w
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" runat="server" id="tabCntrInvInfo">
                        <tr>
                            <th width="15%">�o���}�_��</th>
                            <td width="15%">
                                <asp:TextBox ID="txtRENTSTDTM" CssClass="txt_normal" MaxLength="7" runat="server"></asp:TextBox>
                            </td>
                            <th width="10%">���w���</th>
                            <td width="10%">
                                <asp:TextBox ID="txtRENTSTDTD" MaxLength="2" CssClass="txt_normal" runat="server">1</asp:TextBox></td>
                            <th width="10%">�o���p��</th>
                            <td width="10%">
                                <asp:DropDownList ID="drpINVKIND1" runat="server">
                                    <asp:ListItem Value="2">�G�p��</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">�T�p��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <th width="15%">�X��@�}</th>
                            <td width="15%">
                                <asp:TextBox ID="txtPAYMONTHK" MaxLength="2" CssClass="txt_normal_right" runat="server">1</asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>����J�}</th>
                            <td>
                                <asp:DropDownList ID="ddlSingle" runat="server" OnSelectedIndexChanged="ddlSingle_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Selected="True">Y</asp:ListItem>
                                    <asp:ListItem Value="2" >N</asp:ListItem>
                                </asp:DropDownList>
                                <input type="button" id="btnSplit" class="btn_normal" style="width: 85px; padding: 1px; display: ;"
                                    runat="server" onclick="FrmML4003Click();" value="��o���]�w" />
                            </td>
                            <th>�`��J�}</th>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlSummary" runat="server">
                                    <asp:ListItem Value="1" Selected="True">Y</asp:ListItem>
                                    <asp:ListItem Value="2">N</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <input type="button" id="btnMerge" runat="server" class="btn_normal" style="width: 35%; padding: 1px; display: none;"
                                    onclick="FrmML4002Click();" value="�J�}�]�w" />
                                <input id="chkMerge" type="checkbox" style="display: none" onclick="chkMerge_onClick(this);"
                                    runat="server" /><asp:Label ID="spanChkMerge" runat="server" Text="�J�}�D��"></asp:Label>
                            </td>
                            <th>�w�p�}�ߤ覡</th>
                            <td>
                                <asp:DropDownList ID="ddlAplyTyp" runat="server">
                                    <asp:ListItem Value="1">�浧�}�� </asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">�妸�}��</asp:ListItem>
                                    <asp:ListItem Value="3">�Ȥ��}��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>������t�}�ߤ覡</th>
                            <td>
                                <asp:DropDownList ID="ddlBdyDiffTyp" runat="server">
                                    <asp:ListItem Value="1" >��}</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">����}</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="6"></td>
                        </tr>
                        <tr>
                            <%--20230221 �]�i��ݭn ���ML4004A�s�W������t�o���W�[���㸹�X�A���ءA��R�߽X--%>
                            <%--UPD BY HANK 20170926 ������t�o���W�[���㸹�X�A���ءA��R�߽X--%>
                            <th>���㸹�X</th>
                            <td>
                                <asp:TextBox ID="txtCARRIEID" MaxLength="30" CssClass="txt_normal" runat="server" Width="150"></asp:TextBox>
                            </td>
                            <th>����</th>
                            <td>
                                <input id="chkDONATEMARK" type="checkbox" onclick="chkDONATEMARK_onClick(this);" runat="server" />
                            </td>
                            <th>�R�߽X</th>
                            <td>
                                <asp:TextBox ID="txtNPOBAN" MaxLength="30" CssClass="txt_normal" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </div>
                <div style="width: 97%; border: 1px solid #9FA1AD; margin-left: 5px; margin-top: 10px;">
                    <div class="div_title">
                        �Ƶ��]�w
                    </div>
                    <table id="tabCntrInvRmkInfo" cellpadding="1" cellspacing="1" class="tb_Info" runat="server">
                        <tr style="display: none;" runat="server">
                            <th id="TH6" runat="server">����<asp:HiddenField ID="hdnPREINVNOTEID1" runat="server" />
                            </th>
                            <td id="TD4" runat="server">
                                <asp:CheckBox Checked="true" ID="chk11" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD12" runat="server">
                                <asp:CheckBox Checked="true" ID="chk12" runat="server" Text="����" />
                                &nbsp;</td>
                            <td id="TD33" runat="server">
                                <asp:CheckBox Checked="true" ID="chk13" runat="server" Text="�������" />
                                &nbsp;</td>
                            <td id="TD14" runat="server">
                                <asp:CheckBox Checked="true" ID="chk14" runat="server" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD36" runat="server">
                                <asp:CheckBox ID="chk15" runat="server" Text="����b��" />
                                &nbsp;</td>
                            <td runat="server" id="TD41">
                                <asp:CheckBox ID="chk16" Style="display: none;" runat="server" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD31" runat="server">
                                <asp:Button ID="btn11" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE1');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE1" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr style="display: none;" runat="server">
                            <th id="TH5" runat="server">����]�⮧<asp:HiddenField ID="hdnPREINVNOTEID2" runat="server" />
                            </th>
                            <td id="TD8" runat="server">
                                <asp:CheckBox ID="chk21" Checked="true" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD27" runat="server">
                                <asp:CheckBox ID="chk22" Checked="true" runat="server" Text="����" />
                                &nbsp;</td>
                            <td id="TD2" runat="server">
                                <asp:CheckBox ID="chk23" Checked="true" runat="server" Text="�������" />
                                &nbsp;</td>
                            <td id="TD10" runat="server">
                                <asp:CheckBox ID="chk24" Enabled="false" runat="server" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD15" runat="server">
                                <asp:CheckBox ID="chk25" Enabled="false" runat="server" Text="����b��" />
                                &nbsp;</td>
                            <td runat="server" id="TD39">
                                <asp:CheckBox ID="chk26" Style="display: none;" runat="server" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD9" runat="server">
                                <asp:Button ID="btn21" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE2');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE2" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr style="display: none" runat="server">
                            <th id="TH2" runat="server">����O<asp:HiddenField ID="hdnPREINVNOTEID3" runat="server" />
                                &nbsp;</th>
                            <td id="TD28" runat="server">
                                <asp:CheckBox ID="chk31" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD5" runat="server">
                                <asp:CheckBox ID="chk32" runat="server" Text="����" />
                                &nbsp;</td>
                            <td id="TD6" runat="server">
                                <asp:CheckBox ID="chk33" runat="server" Text="�������" />
                                &nbsp;</td>
                            <td id="TD19" runat="server">
                                <asp:CheckBox ID="chk34" runat="server" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD1" runat="server">
                                <asp:CheckBox ID="chk35" runat="server" Text="����b��" />
                                &nbsp;</td>
                            <td runat="server" id="TD40">
                                <asp:CheckBox ID="chk36" Style="display: none;" runat="server" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD23" runat="server">
                                <asp:Button ID="btn31" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE3');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE3" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr style="display: none;" runat="server">
                            <th id="TH4" runat="server">����<asp:HiddenField ID="hdnPREINVNOTEID4" runat="server" />
                            </th>
                            <td id="TD25" runat="server">
                                <asp:CheckBox ID="chk41" Checked="true" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD16" runat="server">
                                <asp:CheckBox ID="chk42" runat="server" Style="display: none;" Text="����" />
                                &nbsp;</td>
                            <td id="TD21" runat="server">
                                <asp:CheckBox ID="chk43" runat="server" Style="display: none;" Text="�������" />
                                &nbsp;</td>
                            <td id="TD3" runat="server">
                                <asp:CheckBox ID="chk44" runat="server" Style="display: none;" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD7" runat="server">
                                <asp:CheckBox Checked="true" ID="chk45" Text="����b��" runat="server" />
                                &nbsp;</td>
                            <td runat="server" id="TD37">
                                <asp:CheckBox ID="chk46" Style="display: none;" runat="server" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD18" runat="server">
                                <asp:Button ID="btn41" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE4');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE4" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr style="display: none;" runat="server">
                            <th id="TH1" runat="server">���t<asp:HiddenField ID="hdnPREINVNOTEID5" runat="server" />
                            </th>
                            <td id="TD29" runat="server">
                                <asp:CheckBox ID="chk51" Checked="true" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD11" runat="server">
                                <asp:CheckBox ID="chk52" runat="server" Style="display: none;" Text="����" />
                                &nbsp;</td>
                            <td id="TD35" runat="server">
                                <asp:CheckBox ID="chk53" runat="server" Style="display: none;" Text="�������" />
                                &nbsp;</td>
                            <td id="TD13" runat="server">
                                <asp:CheckBox ID="chk54" runat="server" Style="display: none;" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD34" runat="server">
                                <asp:CheckBox Checked="true" ID="chk55" runat="server" Text="����b��" />
                                &nbsp;</td>
                            <td runat="server" id="TD42">
                                <asp:CheckBox ID="chk56" runat="server" Style="display: none;" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD20" runat="server">
                                <asp:Button ID="btn51" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE5');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE5" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr style="display: none;" runat="server">
                            <th id="TH3" runat="server">����+���t<asp:HiddenField ID="hdnPREINVNOTEID6" runat="server" />
                            </th>
                            <td id="TD24" runat="server">
                                <asp:CheckBox ID="chk61" Checked="true" runat="server" Text="�X���s��" />
                                &nbsp;</td>
                            <td id="TD22" runat="server">
                                <asp:CheckBox ID="chk62" runat="server" Style="display: none;" Text="����" />
                                &nbsp;</td>
                            <td id="TD26" runat="server">
                                <asp:CheckBox ID="chk63" runat="server" Style="display: none;" Text="�������" />
                                &nbsp;</td>
                            <td id="TD32" runat="server">
                                <asp:CheckBox ID="chk64" runat="server" Style="display: none;" Text="�����b��" />
                                &nbsp;</td>
                            <td style="width: 121px" id="TD30" runat="server">
                                <asp:CheckBox Checked="true" ID="chk65" runat="server" Text="����b��" />
                                &nbsp;</td>
                            <td runat="server" id="TD38">
                                <asp:CheckBox ID="chk66" runat="server" Style="display: none;" Text="ú�ڤ�" />
                                &nbsp;</td>
                            <td id="TD17" runat="server">
                                <asp:Button ID="btn61" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click('hdnSPECNOTE6');"
                                    runat="server" Text="�S��Ƶ�" />
                                <asp:HiddenField ID="hdnSPECNOTE6" Value="" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div class="btn_div">
                        <asp:Button ID="btnUS" runat="server" Text="�o���i��" CssClass="btn_normal" />
                        <asp:Button ID="btnUA" runat="server" Text="��孫�i" Enabled="false" CssClass="btn_normal"
                            OnClick="btnUA_Click" />
                        <asp:Button ID="btnUO" runat="server" Text="�浧�ץ�" Enabled="false" CssClass="btn_normal" />
                    </div>
                </div>
                <div style="margin: 5px">
                    <asp:Button ID="btn111" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="����" CssClass="btn_normal" />
                    <asp:Button ID="btn222" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="����]�⮧" CssClass="btn_normal" />
                    <asp:Button ID="btn333" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="����O" CssClass="btn_normal" />
                    <asp:Button ID="btn444" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="����" CssClass="btn_normal" />
                    <asp:Button ID="btn555" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="���t" CssClass="btn_normal" />
                    <asp:Button ID="btn666" runat="server" UseSubmitBehavior="true" OnClientClick="JavaScript: return btn111to666_onClick(this);"
                        Text="����+���t" CssClass="btn_normal" />
                </div>
                <div class="div_table" style="overflow: auto; margin-left: 5px; margin-top: 10px; height: 375px;">
                    <table class="tb_Contact" style="width: 215%;" id="tabInvoDtl" onkeydown="tb_Contact_onkeydown(event);">
                        <tr>
                            <th>����</th>
                            <th>����s��</th>
                            <th>�w�p�}�ߤ覡</th>
                            <th>�����~��</th>
                            <th>�w�}�o���~��</th>
                            <th>�o���~�W</th>
                            <th>�|�v</th>
                            <th>�o�����</th>
                            <th>�o�����X</th>
                            <th>��H�νs</th>
                            <th>��H�W��</th>
                            <th>��I��</th>
                            <th>�o���a�}</th>
                            <th>���w��</th>
                            <th>�o���p��</th>
                            <th>�Ƶ�</th>
                            <th>��o��</th>
                            <th>����J�}</th>
                            <th>�`��J�}</th>
                        </tr>
                        <asp:Repeater ID="rptData" runat="server">
                            <itemtemplate>
                                <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                                    <td>
                                        <asp:HiddenField ID="hdnUNITID" Value='<%# Eval("UNITID")%>' runat="server" />
                                        <asp:HiddenField ID="hdnRENTALPREIOD" Value="" runat="server" />
                                        <asp:HiddenField ID="hdnLLVLNUM" Value="" runat="server" />
                                        <asp:HiddenField ID="hdnACTACCOUNT" Value="" runat="server" />
                                        <asp:HiddenField ID="hdnSPECNOTE" Value="" runat="server" />
                                        <asp:HiddenField ID="hdnRENTYEARS" Value="0" runat="server" />
                                        <asp:HiddenField ID="hdnPREOPENWAY" Value="" runat="server" />
                                        <asp:Label ID="lblISSUE" Text='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUNITID" Text='<%# Eval("UNITID")%>' runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpPREOPENWAY" runat="server">
                                            <asp:ListItem Value="1">�浧�}��</asp:ListItem>
                                            <asp:ListItem Value="2">�妸�}��</asp:ListItem>
                                            <asp:ListItem Value="3">�Ȥ��}��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRENTYEARS" Text='<%# Eval("RENTYEARS")%>' runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPREINVYYYYMM" Text='<%# Eval("PREINVYYYYMM")%>' Style="display: ;"
                                            runat="server"></asp:Label>
                                        <asp:TextBox ID="txtPREINVYYYYMM" onfocus="txtPREINVYYYYMM_onfocus(this);"
                                            onblur="txtPREINVYYYYMM_onblur(this);" Text='<%# Eval("PREINVYYYYMM")%>' Style="display: none;"
                                            CssClass="txt_table" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <input type="button" id="btnINVDESC" class="btn_normal" onclick="return FrmML4004A_1Click(this,'hdnINVDESC','hdnAMOUNT','hdnTAX','hdnPRINCIPAL','hdnINSTAMT','hdnISSUE');"
                                            value="�~�W�]�w" style="padding: 2px;" />
                                        <asp:HiddenField ID="hdnINVDESCTYPE" Value='<%# Eval("INVDESCTYPE")%>' runat="server" />
                                        <asp:HiddenField ID="hdnINVDESC" Value='<%# Eval("INVDESC")%>' runat="server" />
                                        <asp:HiddenField ID="hdnPRINCIPALDESC" Value="" runat="server" />
                                        <asp:HiddenField ID="hdnAMOUNT" Value='<%# Eval("AMOUNT")%>' runat="server" />
                                        <asp:HiddenField ID="hdnTAXForAMOUNT" Value='<%# Eval("TAX")%>' runat="server" />
                                        <asp:HiddenField ID="hdnPRINCIPAL" Value='<%# Eval("RTNAMT")%>' runat="server" />
                                        <asp:HiddenField ID="hdnTAXForPRINCIPAL" Value='<%# Eval("RTNAMTTAX")%>' runat="server" />
                                        <asp:HiddenField ID="hdnINSTAMT" Value='<%# Eval("INSTAMT")%>' runat="server" />
                                        <asp:HiddenField ID="hdnTAXForINSTAMT" Value='<%# Eval("INSTAMTTAX")%>' runat="server" />
                                        <asp:HiddenField ID="hdnMTRCNTRNO" Value='<%# Eval("MTRCNTRNO")%>' runat="server" />
                                        <asp:HiddenField ID="hdnINVDATE" Value='<%# Eval("INVDATE")%>' runat="server" />
                                        <asp:HiddenField ID="hdnINVNO" Value='<%# Eval("INVNO")%>' runat="server" />
                                        <asp:HiddenField ID="hdnISSUE" Value='<%# System.Convert.ToDecimal(Eval("ISSUE")).ToString("#00") %>'
                                            runat="server" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpTAXTYPE" runat="server">
                                            <asp:ListItem Value="1">���|</asp:ListItem>
                                            <asp:ListItem Value="2">�s�|</asp:ListItem>
                                            <asp:ListItem Value="3">�K�|</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblINVDATE" Text='<%# Eval("INVDATE")%>' runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblINVNO" Text='<%# Eval("INVNO")%>' runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTARGETID" Text='<%# Eval("TARGETID")%>' CssClass="txt_table"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTARGETNAME" Text='<%# Eval("TARGETNAME")%>' CssClass="txt_table"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblMONTHPAY" Text='<%# System.Convert.ToDecimal(Eval("MONTHPAY").ToString()).ToString("#,##0")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtINVZIPCODE" Text='<%# Eval("INVZIPCODE")%>' onkeyup="CheckNumber_keyup(this);"
                                            MaxLength="6" runat="server" Width="60px" onblur="PostCodeBlure(this)" CssClass="txt_table">
                                        </asp:TextBox>
                                        <asp:Button ID="btnINVZIPCODE" CssClass="btn_normal" OnClientClick="PostCodeClick(this);"
                                            Style="width: 25px; padding: 2px;" runat="server" Text="&#8230;" />
                                        <asp:TextBox ID="txtINVZIPCODES" Text='<%# Eval("INVZIPCODES")%>' runat="server"
                                            Width="120px" CssClass="txt_table" onfocus="ObjMFocus(this,'txtINVZIPCODES','txtINVOICEADDR');">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtINVOICEADDR" Text='<%# Eval("INVOICEADDR")%>' runat="server"
                                            CssClass="txt_table" Width="150px" MaxLength="100" onblur="CheckMLength(this,'100');">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtORDERDAY" Text='<%# Eval("ORDERDAY")%>' CssClass="txt_table"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpINVKIND" runat="server">
                                            <asp:ListItem Value="2">�G�p��</asp:ListItem>
                                            <asp:ListItem Value="3">�T�p��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Button ID="btnBZ" CssClass="btn_normal" OnClientClick="return FrmML4004A_2Click2(this,'btnBZ','hdnBZ');"
                                            runat="server" Text="�Ƶ�" />
                                        <asp:HiddenField ID="hdnBZ" Value='<%# Eval("BZ")%>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="spanFGSPLIT" Text='<%# Eval("FGSPLITNME")%>' runat="server"></asp:Label>
                                        <asp:HiddenField
                                            ID="hdnFGSPLIT" Value='<%# Eval("FGSPLIT")%>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="spanFGSINGLE" Text='<%# Eval("FGSINGLENME")%>' runat="server"></asp:Label>
                                        <asp:HiddenField
                                            ID="hdnFGSINGLE" Value='<%# Eval("FGSINGLE")%>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="spanFGSUMMARY" Text='<%# Eval("MTRCNTRNO")%>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </itemtemplate>
                        </asp:Repeater>
                    </table>
                    <input type="button" id="btnMdyPreMonth" class="btn_normal" style="width: 85px; padding: 1px; display: none;"
                        onclick="btnMdyPreMonth_onClick(this);" value="�ץ��w�}�o���~��" />
                </div>
            </div>
            <div id="divBlock" style="text-align: center; border-style: solid; border-width: 1px; z-index: 1; position: absolute; top: 63px; left: 21px; height: 375px; width: 98%; background-color: #808080; filter: Alpha(Opacity=80); display: none;">
                <font color="yellow" size="12">�B�z��......</font>
            </div>
            <div class="btn_div">
                <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server"
                    Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
                </asp:DropDownList>
                <asp:Button ID="btnExtInvo" runat="server" Text="�i���T�{" CssClass="btn_normal" OnClientClick="JavaScript: return btnExtInvo_onClick(this);"
                    OnClick="btnExtInvo_Click" />
            </div>
        </div>
    </form>
</body>
</html>
