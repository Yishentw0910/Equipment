<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5001.aspx.cs" Inherits="FrmML5001" %>

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

    <script language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>

    <script type="text/javascript">
    <!-- #Include file='js/ML5001.js' -->                   
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
                    <div class="div_Info">
                        <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
                            <tr>
                                <th class="align_right" width="25%">
                                    ���q�O�G
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpCompID" runat="server" Width="25%">
                                        <asp:ListItem Value="">�п��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
							<%--20120531 MODIFY BY SSF MAUREEN REASON:�s�W�^�󪬺A�d�����--%>
                            <tr>
                                <th class="align_right" width="25%">
                                    �^�󪬺A�G
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpCaseStatus" runat="server" Width="25%">
                                        <asp:ListItem Value="">�п��</asp:ListItem>
                                        <asp:ListItem Value="Y">�w�^��</asp:ListItem>
                                        <asp:ListItem Value="N">���^��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <%--UPD BY VICKY 20140220 �s�W[�ǻ����A]--%>
                                <th class="align_right" width="25%">
                                    �ǻ����A�G
                                </th>
                                <td width="25%">
                                    <asp:DropDownList ID="drpTransStatus" runat="server" Width="78%">
                                        <asp:ListItem Value="N">���ǻ�</asp:ListItem>
                                        <asp:ListItem Value="Y">�w�ǻ�</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th width="20%">
                                    �ǻ���_���G
                                </th>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtTRANSDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="40%"></asp:TextBox>��<asp:TextBox
                                            ID="txtTRANSDATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                            onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="40%"></asp:TextBox>
                                </td>
                            </tr>
                            <%--UPD BY VICKY 20140220 �վ�TABLE,�N���ê�TD,�W�ߥX��,��J����TR��--%>
                            <tr style="display: none;">
                                <th style="display: none;" class="align_right" width="25%">
                                    �~�N�W�G
                                </th>
                                <td style="display: none;" width="25%">
                                    <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                    <input type="button" id="Button6" class="btn_normal" onclick="AgencyClick();" style="width: 25px;
                                        padding: 2px;" value="&#8230;" />
                                </td>
                                <th style="display: none;" class="align_right" width="25%">
                                    &nbsp; �ץ�֭��G
                                </th>
                                <td style="display: none;" width="25%">
                                    &nbsp;
                                    <asp:TextBox ID="txtCASEDATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    �X���s���G
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" MaxLength="14"
                                        CssClass="txt_normal" Width="30%"></asp:TextBox>
                                </td>
                            </tr>
                            <%--UPD BY VICKY 20140220 �վ�TABLE,�N���ê�TD,�W�ߥX��,��J����TR��--%>
                            <tr style="display: none;">
                                <th style="display: none;" class="align_right" width="25%">
                                    &nbsp; �_����G
                                </th>
                                <td style="display: none;" width="25%">
                                    &nbsp;
                                    <asp:TextBox ID="txtRENTSTDT" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="80%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    �]�ȼ��ڽT�{��_���G
                                </th>
                                <td style="text-align: left;" colspan="3">
                                    <asp:TextBox ID="txtCNTRNODATE" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>��<asp:TextBox
                                            ID="txtCNTRNODATE1" runat="server" MaxLength="8" onkeypress="OnlyNum(this);"
                                            onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_normal" Width="20%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="align_right" width="25%">
                                    �Ȥ�νs�G
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
                                        runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                                    <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                                    <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
                                        padding: 2px;" value="&#8230;" />
                                </td>
                            </tr>
                            <tr>
                                <th colspan="4" style="text-align: center; height: 30px;">
                                    <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClick="cmdQuery_Click" />
                                    <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
                                        value="�M��" />
                                    <%--UPD BY VICKY 20140220 �s�W[�C�L�^��ñ����]--%>
                                    <asp:Button ID="cmdPRINT" runat="server" Text="�C�L�^��ñ����" CssClass="btn_normal" Width="110"
                                         Enabled="false" OnClick="cmdPRINT_OnClick"/>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
                        <table id="tblMLDCASEAPPENDDOC" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px; width: 1200px;">
                            <tr>
                                <th style="width: 7%;">
                                    <!--ADD BY VICKY 20140221 �s�W��� -->
                                    �ǻ���T�{
                                </th>
                                <th style="width: 6%;">
                                    <!--ADD BY VICKY 20140221 �s�W��� -->
                                    �ǻ����
                                </th>
                                <th style="width: 5%;">
                                    �i�}
                                </th>
                                <th style="width: 10%;">
                                    �X���s��
                                </th>
                                <th style="width: 17%;">
                                    �Ȥ�W��
                                </th>
                                <th style="width: 10%;">
                                    ����
                                </th>
                                <th style="width: 6%;">
                                    �~�N
                                </th>
                                <th style="width: 8%;">
                                    �ӧ@����
                                </th>
                                <th style="display: none;">
                                    ������A
                                </th>
                                <th style="width: 6%;">
                                    �ӧ@���B
                                </th>
                                <th style="width: 4%;">
                                    ����
                                </th>
                                <th style="display: none;">
                                    IRR
                                </th>
                                <th style="display: none;">
                                    ��I����
                                </th>
                                <th style="display: none;">
                                    �_����
                                </th>
                                <th style="display: none;">
                                    ������
                                </th>
                                <th style="width: 7%;">
                                    ���ڽT�{��
                                </th>
                                <th style="width: 7%;">
                                    ���^��Ѽ�
                                </th>
                                <th style="display: none;">
                                    <!--ADD BY VICKY 20140221 �x�s�D�ɻݥΨ쪺KEY�� -->
                                    �^���ƥN�X
                                </th>
                            </tr>
                            <asp:Repeater ID="rptData" runat="server">
                                <ItemTemplate>
                                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                                        onclick="MouseDown(event);">
                                        <td>
                                            <!--ADD BY VICKY 20140221 �s�W��� -->
                                            <asp:CheckBox ID="chkcheckDate" runat="server" onClick="TRANSCONFIRMClick(this,'chkcheckDate','lblTRANSDATE')" />
                                        </td>
                                        <td>
                                            <!--ADD BY VICKY 20140221 �s�W��� -->
                                            <asp:Label ID="lblTRANSDATE" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("TRANSDATE").ToString()) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID"),Eval("CASESTATUS")) %>'
                                                runat="server" Text="����" />
                                        </td>
                                        <td>
                                            <%--<%#Eval("CNTRNO")%>--%>
                                            <!--ADD BY VICKY 20140317 �n��X�H�K�C�L -->
                                            <asp:Label ID="lblCNTRNO" runat="server" Text='<%#Eval("CNTRNO")%>'></asp:Label>
                                            
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("CUSTNAME")%>
                                            <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                                                ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <%#Eval("DEPT")%>
                                        </td>
                                        <td>
                                            <%#Eval("EMPLNM")%>
                                        </td>
                                        <td>
                                            <%#Eval("MAINTYPENM")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("TRANSTYPENM")%>
                                        </td>
                                        <td style="text-align: right;">
                                            <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
                                        </td>
                                        <td>
                                            <%#Eval("CONTRACTMONTH")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("IRR")%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
                                        </td>
                                        <td>
                                            <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="display: none;">
                                            <!--ADD BY VICKY 20140221 �x�s�D�ɻݥΨ쪺KEY�� -->
                                            <asp:Label ID="lblRETUNID" runat="server" Text='<%#Eval("RETUNID")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                                        onclick="MouseDown(event);">
                                        <td>
                                            <!--ADD BY VICKY 20140221 �s�W��� -->
                                            <asp:CheckBox ID="chkcheckDate" runat="server" onClick="TRANSCONFIRMClick(this,'chkcheckDate','lblTRANSDATE')" />
                                        </td>
                                        <td>
                                            <!--ADD BY VICKY 20140221 �s�W��� -->
                                            <asp:Label ID="lblTRANSDATE" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("TRANSDATE").ToString()) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO"), Eval("RETUNID"),Eval("CASESTATUS")) %>'
                                                runat="server" Text="����" />
                                        </td>
                                        <td>
                                            <%--<%#Eval("CNTRNO")%>--%>
                                            <!--ADD BY VICKY 20140317 �n��X�H�K�C�L -->
                                            <asp:Label ID="lblCNTRNO" runat="server" Text='<%#Eval("CNTRNO")%>'></asp:Label>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("CUSTNAME")%>
                                            <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                                                ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <%#Eval("DEPT")%>
                                        </td>
                                        <td>
                                            <%#Eval("EMPLNM")%>
                                        </td>
                                        <td>
                                            <%#Eval("MAINTYPENM")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("TRANSTYPENM")%>
                                        </td>
                                        <td style="text-align: right;">
                                            <%#Itg.Community.Util.DefaultZero(Eval("ACTUALLYAMOUNT").ToString())%>
                                        </td>
                                        <td>
                                            <%#Eval("CONTRACTMONTH")%>
                                        </td>
                                        <td style="display: none;">
                                            <%#Eval("IRR")%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.DefaultZero(Eval("MPAY").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTSTDT").ToString())%>
                                        </td>
                                        <td style="display: none;">
                                            <%# Itg.Community.Util.GetRepYear(Eval("RENTENDT").ToString())%>
                                        </td>
                                        <td>
                                            <%# Itg.Community.Util.GetRepYear(Eval("PAYCONFIRMDATE").ToString())%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMDAY" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="display: none;">
                                            <!--ADD BY VICKY 20140221 �x�s�D�ɻݥΨ쪺KEY�� -->
                                            <asp:Label ID="lblRETUNID" runat="server" Text='<%#Eval("RETUNID")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%--<div class="btn_div">
           <input type="button" id="Button3" class="btn_normal" onclick="CaseClick();" value="�^���ƺ��@" />
        </div>--%>
                    <%--UPD BY VICKY 20140220 �s�W[����][��������][�T�{]--%>
                    <div class="btn_div">
                        <asp:Button ID="cmdALL" runat="server" Text="����" CssClass="btn_normal" OnClick="cmdALL_Click" Enabled="false" />
                        <asp:Button ID="cmdNOTALL" runat="server" Text="��������" CssClass="btn_normal" OnClick="cmdNOTALL_Click" Enabled="false" />
                        <asp:Button ID="cmdSURE" runat="server" Text="�T�{" CssClass="btn_normal" OnClick="cmdSURE_Click" Enabled="false" />
                    </div>
                </div>
    </form>
</body>
</html>
