<%--20221031 ���ëȤ�ʽ�B���ι�ڭt�d�H�B�����q�W�١B���ʨƪѪF�B���q���ʲ����A��~�O�אּ�U�Ԧ����--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML1001.aspx.cs" inherits="FrmML1001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <link rel="stylesheet" href="css/rent.css" />
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <script language="javascript" src="js/Itg.js"></script>
    <script language="javascript" src="js/UI.js"></script>
    <script language="javascript" src="js/validate.js"></script>
    <script type="text/javascript">
    <!-- #Include file='js/ML1001.js' -->                   
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 269px;
        }

        .auto-style2 {
            height: 24px;
        }

        .auto-style3 {
            height: 22px;
        }
    </style>
</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <progresstemplate>
                <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: absolute; top: 0px; height: 100%">
                    <table width="100%" height="100%">
                        <tr>
                            <td class="auto-style1">
                                <table width="250" height="60" align="center" bgcolor="#F7F7F7" style="border: 1px solid #A6C4E1; font: 12px">
                                    <tr>
                                        <td align="center">
                                            <font color="#006699">�t�γB�z���A�еy��...</font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </progresstemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <contenttemplate>
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
                    <div class="divStatus">
                        <asp:Button ID="btnInsert" runat="server" Text="�s�W" CssClass="btn_normal" OnClick="btnInsert_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="�ק�" CssClass="btn_normal" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="�d��" CssClass="btn_normal" Style="display: none"
                            OnClick="btnSearch_Click" />
                        <asp:HiddenField ID="hidSelRowIndex" runat="server" Value="-1" />
                        <asp:HiddenField ID="hidCustomer" runat="server" />
                        <span style="margin-left: 480px;">
                            <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
                        </span>
                    </div>
                    <div id="div_Info" class="div_Info">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="15%">�Ȥ�νs
                                </th>
                                <td width="17%">
                                    <asp:TextBox ID="txtCUSTID" onkeypress="OnlyNumDUCase(this);" onblur="CUSTID_onblur(this);"
                                        MaxLength="10" Width="85px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnSelect" runat="server" disabled="true" class="btn_normal"
                                        onclick="CustomerClick();" style="width: 23px; padding: 2px;" value="&#8230;" />
                                </td>
                                <th width="12%">�Ȥ�W��
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCUSTNAME" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="240px">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�Ȥ�ʽ�
                                </td>
                                <!--th width="13%">
                
              </th-->
                                <td colspan="1">
                                    <asp:DropDownList ID="drpCUTYPE" runat="server" DataTextField="MNAME1" onchange="CboChanged(this);"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th width="15%" class="auto-style2">�n�O�ꥻ�B
                                </th>
                                <td width="16%" class="auto-style2">
                                    <asp:TextBox ID="txtCUSTCREATECAPTIAL" MaxLength="16" Width="112px" Text="" onkeypress="OnlyNum(this);"
                                        runat="server" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must_right">
                                    </asp:TextBox>
                                </td>
                                <td colspan="2" class="auto-style2">&nbsp;&nbsp; �ꦬ�ꥻ�B<asp:TextBox ID="txtCUSTNOWCAPTIAL" MaxLength="16" Width="112px"
                                    Text="" onkeypress="OnlyNum(this);" runat="server" onfocus="MoneyFocus(this)"
                                    onblur="MoneyBlur(this);" CssClass="txt_must_right"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�]�ߤ��
                                </td>
                                <td colspan="1" class="auto-style2">
                                    <asp:TextBox ID="txtCUSTCREATEDATE" MaxLength="8" Width="77px" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <%--20221031 �אּ����--%>
                                <%--<th width="11%">
                                ���u�H��
                            </th>--%>
                                <td colspan="2" class="auto-style2">
                                    <asp:DropDownList ID="drpEMPLOYEE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE" Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>�t�d�H
                                </th>
                                <td>
                                    <asp:TextBox ID="txtOWNER" runat="server" MaxLength="25" CssClass="txt_must"></asp:TextBox>
                                </td>
                                <th>����ID
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtOWNERID" runat="server" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);"
                                        MaxLength="10" Width="100px" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                                <%--20221031 �אּ����--%>
                                <%--<td colspan="3">���ι�ڭt�d�H--%>
                                <asp:TextBox ID="txtGROUPOWNER" MaxLength="10" runat="server" CssClass="txt_normal" Visible="False"></asp:TextBox>
                                <%--</td>--%>
                            </tr>
                            <tr>
                                <th>���q�ݩ�
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpCOMPTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                                <th>��´�κA
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpORGATYPE" class="bg_F5F8BE" runat="server" Width="120px"
                                        DataTextField="MNAME1" DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="3">�W���d
                                <asp:DropDownList ID="drpLISTED" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1"
                                    DataValueField="MCODE">
                                    <asp:ListItem>�п��</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <%--20221031 �אּ����--%>
                                    <%--�����q�s��--%>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPARENTCUSTID" onkeypress="OnlyNum(this);" onblur="BANBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal" Visible="False">
                                    </asp:TextBox>
                                </td>
                                <th>
                                    <%--�����q�W��--%>
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPARENTCUSTNAME" MaxLength="100" runat="server" CssClass="txt_normal"
                                        Width="244px" Visible="False">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>���q�n�O�a�}
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtCUSTZIPCODE" MaxLength="5" onkeypress="OnlyNum(this);" runat="server"
                                        onblur="PostCodeBlure('C',this)" Width="24px" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnCUSTZIPCODES" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('txtCUSTADDR');" onclick="PostCodeClick('C');" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="txtCUSTZIPCODES" Enabled="false" runat="server" Width="120px" CssClass="txt_must"></asp:TextBox>
                                    <%--<input type ="text" id="txtCUSTZIPCODES" disabled ="true" runat="server" width="120px" class="txt_must" />--%>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtCUSTADDR" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="216px">
                                </asp:TextBox>
                                    <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server"
                                        Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>���q�n�O�q��
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        Width="20px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtCUSTTEL" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <th>�ǯu
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtCUSTFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtCUSTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>��~�a�}
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtBUSINESSZIPCODE" onkeypress="OnlyNum(this);" MaxLength="5" runat="server"
                                        onblur="PostCodeBlure('B',this)" Width="24px" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnBUSINESSZIPCODE" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('txtBUSINESSADDR');" onclick="PostCodeClick('B');" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="txtBUSINESSZIPCODES" Enabled="false" runat="server" Width="120px"
                                        CssClass="txt_must">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtBUSINESSADDR" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="216px">
                                </asp:TextBox>
                                    <%--<asp:CheckBox ID="chkBUSINESSADDRS" runat="server" onClick="chkBusAddClick(this)" />--%>
                                    <br />
                                    <input type="checkbox" id="chkBUSINESSADDRS" name="chkBUSINESSADDRS" value="" onclick="chkBusAddClick(this)">�P���q�n�O�a�}�P�q��
                                </td>
                            </tr>
                            <tr>
                                <th>��~�q��
                                </th>
                                <td>
                                    <asp:TextBox ID="txtBUSINESSTTELCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <th>�ǯu
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtBUSINESSFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>�D�n��~����
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtBUSINESS" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="85%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>��~�O
                                </th>
                                <td colspan="6">
                                    <!-- 20160322 ADD BY SS ADAM REASON.�s�W��~�O ===START===-->
                                    <%-- 20221031 ��~�O��U�Կ�� --%>
                                    <asp:DropDownList ID="DrpNDU" class="bg_F5F8BE" runat="server" Width="200px" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                        <asp:ListItem>�п��</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:TextBox ID="txtINDUID" MaxLength="7" class="txt_must" runat="server" onblur="txtINDUID_onblur(this);" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtINDUNM" Enable="false" runat="server" CssClass="txt_normal" Width="200px" Visible="False"></asp:TextBox>
                                    <asp:Button ID="btnINDUPAGE" runat="server" Text="�d�ߦ�~�O" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="False" />

                                    <!-- 20160322 ADD BY SS ADAM REASON.�s�W��~�O ====END====-->
                                    <asp:DropDownList ID="drpCUROUT" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE" Style="display: none;">
                                        <asp:ListItem>�п��</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpCUROUTF" Style="display: none" runat="server" DataTextField="DNAME1"
                                        DataValueField="DCODE">
                                        <asp:ListItem>�п��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>�Ƶ�
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="tbxMemo" runat="server" MaxLength="30"
                                        Width="500px" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>ACH���ڻȦ�N�X
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="ACHBANKCODE" MaxLength="5" onkeypress="OnlyNum(this);" runat="server"
                                        onblur="ACHBANKBlure(this)" Width="56px" CssClass="txt_must" Enabled="false">
                                    </asp:TextBox>
                                    <input type="button" id="btnACHBANKCODE" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('ACHBANKCODE');" onclick="ACHBANKClick();" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="ACHBANKCODES" Enabled="false" runat="server" Width="200px" CssClass="txt_must"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ACH���ڱb��
                                <asp:TextBox ID="ACHACCOUNT" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="180px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="auto-style3">ACH���ڲνs</th>
                                <td colspan="1" class="auto-style3">
                                    <asp:TextBox ID="ACHID" MaxLength="10" Width="100px" runat="server" CssClass="txt_must" onkeypress="OnlyNumDUCase(this);" onblur="CUSTID_onblur(this);>
                                    </asp:TextBox>
                                </td>
                                <th class="auto-style3">ACH���ڤ�W</th>
                                <td colspan="6" class="auto-style3">
                                    <asp:TextBox ID="ACHNAME" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="216px">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���ڤ� 
                                        <asp:DropDownList ID="ACHPAYDAY" runat="server">
                                            <asp:ListItem Value="">�п��</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="27">27</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <%--20221031 �אּ����--%>
                                <%--<th>
                                ���q²���u��
                            </th>--%>
                                <td colspan="7">
                                    <asp:TextBox ID="tbxCUSTINTRO" runat="server" MaxLength="50"
                                        Width="500px" CssClass="txt_must" Visible="False">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        </asp:UpdatePanel>
                        <asp:Repeater ID="rptDirStock" runat="server">
                        </asp:Repeater>
                        <%--20221031 �אּ����--%>
                        <%--<div class="divGrid1001" >
                        <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                            <tr>
                                <td width="5%" align="right">
                                    ���ʨƪѪF
                                </td>
                                <td width="30%" align="left">
                                    &nbsp; <span style="color: Red">[ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style= "overflow:auto;width:100%;height:98%;">
                                    <table class="tb_Contact" width="98%" style="margin: 0 auto; margin-bottom: 5px;">
                                        <tr onclick="changeTag('rptDirStock')">
                                            <th>
                                                ¾��
                                            </th>
                                            <th>
                                                �m�W
                                            </th>
                                            <th>
                                                �ʧO
                                            </th>
                                            <th>
                                                �~��
                                            </th>
                                            <th>
                                                �����B
                                            </th>
                                            <th>
                                                �Ƶ�
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="rptDirStock" runat="server">
                                            <ItemTemplate>
                                                <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                    <td>
                                                        <asp:TextBox ID="txtTITLENM" MaxLength="20" runat="server" Text='<%# Eval("TITLENM")%>'
                                                            CssClass="txt_table" Width="80px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNAME" MaxLength="10" runat="server" Text='<%# Eval("NAME")%>'
                                                            CssClass="txt_must" Width="60px" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSEX" MaxLength="3" runat="server" Text='<%# Eval("SEX")%>'
                                                            Width="65px">
                                                            <asp:ListItem Value="">�п��</asp:ListItem>
                                                            <asp:ListItem Value="�k">�k</asp:ListItem>
                                                            <asp:ListItem Value="�k">�k</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAGE" runat="server" MaxLength="3" Text='<%# Eval("AGE")%>' onkeypress="OnlyNum(this);"
                                                            onblur="OnlyNumBlur(this);"  CssClass="txt_table" Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtINVAMT" runat="server" MaxLength="16" Text='<%# Eval("INVAMT")%>'
                                                           onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must" Width="120px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMEMO" runat="server" MaxLength="50" Text='<%# Eval("MEMO")%>'
                                                            CssClass="txt_table" Width="200px" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                        <div class="divGrid1001">
                            <!--div id="fraOTOutside" style="margin-left: 2px; border-right: #0B79FF 1px solid;
            border-top: #0B79FF 1px solid; z-index: -99999999; visibility: visible; border-left: #0B79FF 1px solid;
            width: 99%; cursor: default; border-bottom: #0B79FF 0px solid; height: 180px; background-color: #ffffff"-->
                            <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                                <tr>
                                    <td width="5%" align="right">���Y�p���H
                                    </td>
                                    <td width="30%" align="left">&nbsp; <span style="color: Red">[ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
                                    <div style="overflow: auto; width: 100%; height: 98%;">
                                        <table class="tb_Contact" width="98%" style="margin: 0 auto; margin-bottom: 5px;">
                                            <tr onclick="changeTag('rptContact')">
                                                <th>�m�W
                                                </th>
                                                <th>����
                                                </th>
                                                <th>¾��
                                                </th>
                                                <th>�p���q��
                                                </th>
                                                <th>���
                                                </th>
                                                <th>�ǯu
                                                </th>
                                                <th>Email
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptContact" runat="server">
                                                <itemtemplate>
                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTNAME" MaxLength="10" runat="server" Text='<%# Eval("CONTACTNAME")%>'
                                                                CssClass="txt_must" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDEPTNAME" MaxLength="50" runat="server" Text='<%# Eval("DEPTNAME")%>'
                                                                CssClass="txt_table" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTITLE" MaxLength="10" runat="server" Text='<%# Eval("CONTACTTITLE")%>'
                                                                CssClass="txt_table" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTELCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' CssClass="txt_must"
                                                                Width="24px" />
                                                            <asp:TextBox ID="txtCONTACTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTTEL")%>' CssClass="txt_must"
                                                                Width="80px" />
                                                            <asp:TextBox ID="txtCONTACTTELEXT" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="5" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' CssClass="txt_table"
                                                                Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTMPHONE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' CssClass="txt_table"
                                                                Width="80px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' CssClass="txt_table"
                                                                Width="24px" />
                                                            <asp:TextBox ID="txtCONTACTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTFAX")%>' CssClass="txt_table"
                                                                Width="80px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTEMAIL" onblur="EMAILBlur(this);" MaxLength="50" runat="server"
                                                                Text='<%# Eval("CONTACTEMAIL")%>' CssClass="txt_table" />
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        </asp:UpdatePanel>
                        <asp:Repeater ID="rptIMMOVABLE" runat="server">
                        </asp:Repeater>
                        <%--20221031 �אּ����--%>
                        <%--<div class="divGrid1001">
                        <!--div id="fraOTOutside" style="margin-left: 2px; border-right: #0B79FF 1px solid;
            border-top: #0B79FF 1px solid; z-index: -99999999; visibility: visible; border-left: #0B79FF 1px solid;
            width: 99%; cursor: default; border-bottom: #0B79FF 0px solid; height: 180px; background-color: #ffffff"-->
                        <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                            <tr>
                                <td width="5%" align="right">
                                    ���q���ʲ�
                                </td>
                                <td width="30%" align="left">
                                    &nbsp; <span style="color: Red">[ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="overflow: auto; height:95%">
                                    <table class="tb_Contact" width="220%" style="margin: 0 auto; margin-bottom: 5px;">
                                    <tr onclick="changeTag('rptIMMOVABLE')">
                                        <th style="width:5%">�Ҧ��v�H</th>
                                        <th style="width:5%">�ʤJ���</th>
                                        <th style="width:5%">�γ~</th>
                                        <th style="width:5%">�y����m</th>
                                        <th style="width:5%">���n(�W)</th>
                                        <th style="width:5%">����</th>
                                        <th style="width:7%">�������n(�W)</th>
                                        <th style="width:7%">�Ĥ@����]�w</th>
                                        <th style="width:7%">�Ĥ@����Ȧ�	</th>
                                        <th style="width:8%">�Ĥ@����ŰȤH</th>
                                        <th style="width:8%">�Ĥ@����]�w���B</th>
                                        <th style="width:8%">�ĤG����]�w</th>
                                        <th style="width:8%">�ĤG����Ȧ�</th>
                                        <th style="width:8%">�ĤG����ŰȤH</th>
                                        <th style="width:8%">�ĤG����]�w���B</th>
                                    </tr>
                                    <asp:Repeater ID="rptIMMOVABLE" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                <td>
                                                    <asp:TextBox ID="txtOWNER" MaxLength="50" runat="server" Text='<%# Eval("OWNER")%>' CssClass="txt_must" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBUYDATE" MaxLength="10" runat="server" Text='<%# Eval("BUYDATE")%>' CssClass="txt_must" Width="80px"  onfocus="dateFocus(this)" onblur="dateBlur(this);" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAPP" MaxLength="50" runat="server" Text='<%# Eval("APP")%>' CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLOCATION" MaxLength="50" runat="server" Text='<%# Eval("LOCATION")%>' CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAREA" MaxLength="50" runat="server" Text='<%# Eval("AREA")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHOLDER" MaxLength="50" runat="server" Text='<%# Eval("HOLDER")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHOLDERAREA" MaxLength="50" runat="server" Text='<%# Eval("HOLDERAREA")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPICKSET1" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"  MaxLength="3" runat="server" Text='<%# Eval("PICKSET1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxBANK1" MaxLength="100" runat="server" Text='<%# Eval("BANK1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDEBTOR1" MaxLength="50" runat="server" Text='<%# Eval("DEBTOR1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxSETAMT1" MaxLength="15" runat="server" Text='<%# Eval("SETAMT1")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_table" Width="100px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxPICKSET2" MaxLength="50" runat="server" Text='<%# Eval("PICKSET2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxBANK2" MaxLength="100" runat="server" Text='<%# Eval("BANK2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDEBTOR2" MaxLength="50" runat="server" Text='<%# Eval("DEBTOR2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxSETAMT2"   MaxLength="15" runat="server" Text='<%# Eval("SETAMT2")%>'  onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"   CssClass="txt_table" Width="100px" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                    </div>
                    <div class="btn_div">
                        <asp:Button ID="btnSubmit" runat="server" Text="�x�s�T�{" Enabled="false" CssClass="btn_normal"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnAdd" Style="display: none" runat="server" Text="" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDel" Style="display: none" runat="server" Text="" OnClick="btnDel_Click" />
                        <asp:Button ID="btnQue" Style="display: none" runat="server" Text="" OnClick="btnQue_Click" />
                        <%-- 20221031 �Y�]�ƵL��Ʊq�����a��� --%>
                        <asp:Button ID="btnQue2" Style="display: none" runat="server" Text="" OnClick="btnQue2_Click" />
                    </div>
                </div>
                <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
            </contenttemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
