<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML2001B																					
* �{���\��  : �ץ�/�X���d��																			
* �{���@�� 	: 																			
* �����ɶ� 	: 
* �ק�ƶ� 	: 
20120216 MODIFY BY SSF MAUREEN REASON:�s�W�x�H���i��ñ���
20120221 UPD BY SSF MAUREEN REASON:�ק���s
Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~.
Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v
Modify 20120529 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v
Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q
Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.
Modify 20120618 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�
Modify 20120717 By SS Gordon. Reason: �s�W�ӧ@�覡.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.
Modify 20121204 By SS Steven. Reason: �s�W�u�����X�����~�]�w�v�\��.
Modify 20130103 By SS Maureen. Reason: �b�x�H���i���ҵe�����A�s�W���ʲ��]�wGRID.
Modify 20130104 By SS Maureen. Reason: �b�x�H���i���ҵe�����A���ʲ�GRID�[�W�iF8:�s�W F9:�R���\��.
Modify 20130117 By SS Adam. Reason: �W�[��e�׾�O�~�W�[�����ܧP�_.
Modify 20130131 By SS Maureen. Reason: �ץ��ؿv�������n���A��ܥ��T���.
Modify 20130131 By SS Maureen. Reason:�W�٭קאּ���ʲ���ơA�ò������׵L���ʲ��]�w���ﶵ.
Modify 2013709 By SS Chris Hung. Reason:�s�W�ץ�߱o����\��
20131008 Edit by Sean �w�x�f�������ץ�]�i�W�Ǽx�H�ɮ�
Modify 20131113 BY SS Leo Reason:�W�[�i������O�������
Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������
Modify 20150126 By SS ChrisFu. Reason:�s�W�M�קO���
Modify 20150205 By SS ChrisFu. Reason:�s�W�u��ĳ�Դڮ��v���
20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����
20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%)
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B.aspx.cs" Inherits="FrmML2001B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />
    <script type="text/javascript" language="javascript" src="js/UI.js"></script>
    <script language="javascript" src="js/Itg.js"></script>
    <script language="javascript" src="js/validate.js"></script>
    <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML2001A.js' -->                   
    </script>
    <script type="text/javascript" language="javascript">
        function openML2001C() {
            //dialogHeight:600px;dialogWidth:735px
            //20230216 ML��LE
            window.showModalDialog("../../LE.NET/ML20/ML2001C.aspx?CASEID=" + document.getElementById("<%=this.txtCASEID.ClientID %>").value, "", "dialogHeight:700px;dialogWidth:850px;");
            //window.showModalDialog("../../ML.NET/ML20/ML2001C.aspx?CASEID=" + document.getElementById("<%=this.txtCASEID.ClientID %>").value, "", "dialogHeight:700px;dialogWidth:850px;");
        }
        var $ = document.getElementById;

        //����C�L
        function btnPRINT_OnClick(obj) {

            var LSTR_QUERY = "";
            LSTR_QUERY += ";" + "USERNM=" + escape("<%=this.GSTR_USERNM%>");
            LSTR_QUERY += ";" + "CASEID=" + $("<%=this.txtCASEID.ClientID %>").value;

            //�ǰѼƨ�Smart Query
            ReportPrint("<%=this.cRepotr%>" + "/ReportPrint.aspx",
                "<%=this.cUrl%>",
                "<%=this.cPath%>",
                "<%=this.cUserName%>",
                "<%=this.cPass%>",
                "<%=this.cCompany%>",
                "LE", //**
                "ML2001", //**
                LSTR_QUERY);
        }
    </script>
</head>
<%--Modify 20130104 By SS Maureen. Reason: �b�x�H���i���ҵe�����A���ʲ�GRID�[�W�iF8:�s�W F9:�R���\��.--%>
<%--<body onload="window_onload();showTag();">--%>
<body onload="window_onload();showTag();" onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: fixed; top: 0px; height: 100%">
                    <table width="100%" height="100%">
                        <tr>
                            <td>
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
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="divBody2001A" id="div_Info">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="900">
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
                    <table class="divStatus" width="100%">
                        <tr>
                            <th>�ץ�s��
                            </th>
                            <td>
                                <asp:TextBox ID="txtCASEID" runat="server" CssClass="txt_readonly" Width="105px"
                                    ReadOnly="true"></asp:TextBox>
                                <asp:HiddenField ID="hidCASESTATUS" runat="server" Value="" />
                                <asp:HiddenField ID="HidEMPLID" runat="server" Value="" />
                                <asp:HiddenField ID="HidDEPTID" runat="server" Value="" />
                            </td>
                            <th>�ӽФ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true"></asp:TextBox>
                            </td>
                            <td width="40%"></td>
                        </tr>
                    </table>
                    <div id="fraDispTypeInfo" class="frame_content div_Info5" style="min-height: 1350px; height: auto !important;">
                        <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                        <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8">
                            <label class="label_contain">
                                �Ȥ���</label>
                        </div>
                        <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_100 T_-24">
                            <label class="label_contain">
                                �ץ󤺮e</label>
                        </div>
                        <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_200 T_-48">
                            <label class="label_contain">
                                �Ъ���</label>
                        </div>
                        <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_300 T_-72">
                            <label class="label_contain">
                                ��O����</label>
                        </div>
                        <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_400 T_-96">
                            <label class="label_contain">
                                �x�f���</label>
                        </div>
                        <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_500 T_-120">
                            <label class="label_contain">
                                �x�H���i</label>
                        </div>
                        <div id="fraTab77Caption" tabframe="fraTab77" container="fraDispTypeInfo" onclick="Caption_onclick(this);Caption_onclick(document.getElementById('fraTab111Caption'));Caption_onclick(document.getElementById('fraTab1111Caption'))"
                            class="sheet div_menu8 L_600  T_-144">
                            <label class="label_contain">
                                �H�άd��</label>
                        </div>
                        <div id="fraTab88Caption" tabframe="fraTab88" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_700 T_-168">
                            <label class="label_contain">
                                �Юֳ��i</label>
                        </div>
                        <div id="fraTab99Caption" tabframe="fraTab99" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_800 T_-192">
                            <label class="label_contain">
                                ��f�|���i</label>
                        </div>

                        <%--�Ȥ���Begin --%>
                        <div id="fraTab11" class="div_content padleft_0 T_-188" style="display: block; min-height: 800px;">
                            <%-- Change div_content to div_content2 --%>
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="15%">�Ȥ�νs
                                    </th>
                                    <td width="15%">
                                        <asp:TextBox ID="txtCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th width="15%">�Ȥ�W��
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" Width="230px"
                                            ReadOnly="true"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �Ȥ�ʽ�
                                    <asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�n�O�ꥻ�B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            Width="112px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>�ꦬ�ꥻ�B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            Width="112px" ReadOnly="true"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�]�ߤ��
                                    <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                        Width="81px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�t�d�H
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOWNER" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>����ID
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOWNERID" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="112px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���ι�ڭt�d�H
                                    <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                        ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���q�ݩ�
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpCOMPTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Width="80px">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th>��´�κA
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpORGATYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�W���d
                                    <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>�п��</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�����q�νs
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>�����q�W��
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="276px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���q�n�O�a�}
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="276px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���q�n�O�q��
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>�ǯu
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCUSTFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>��~�n�O�a�}
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="276px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>��~�n�O�q��
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>�ǯu
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�D�n��~����
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="81%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>��~�O
                                    </th>
                                    <td colspan='3'>
                                        <%--20221207 ��~�O��U�Կ��--%>
                                        <asp:DropDownList ID="DrpNDU" class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="False">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>

                                        <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O ===START===-->
                                        <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnINDUPAGE" runat="server" Text="�d�ߦ�~�O" CssClass="btn_normal" Enabled="false" Visible="False" />
                                        <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O ====END====-->

                                        <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                            Enabled="false" Width="100%" Style="display: none;">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpCUROUTF" Style="display: none" DataTextField="DNAME1" DataValueField="DCODE"
                                            runat="server" Enabled="false" Width="50%">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���H�岫
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpDEFECTIVE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Width="100%">
                                            <asp:ListItem Value="">�п��</asp:ListItem>
                                            <asp:ListItem Value="Y">��</asp:ListItem>
                                            <asp:ListItem Value="N">�L</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan='2'>
                                        <span style="color: Red">�����G ���Ȥ�]���q�έt�d�H�^��T�~���L���H�岫</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�M���H
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="100%">
                                                <tr>
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
                                                <asp:Repeater ID="rptContactM" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                    Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                                    Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                                    Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                    Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                    runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                                    runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                                    Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                    Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�ץ��p���H
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="100%">
                                                <tr>
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
                                                <asp:Repeater ID="rptContactC" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                    Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                                    Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                                    Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                    Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                    runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                                    runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                                    Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                    Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�o���p���H
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="150%;">
                                                <tr>
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
                                                    <th>�o���H�e�a
                                                    </th>
                                                </tr>
                                                <asp:Repeater ID="rptContactI" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                    Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                                    Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                                    Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                    Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                    runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                                    runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                                    Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                    Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" ReadOnly="true" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODE")%>'></asp:TextBox>
                                                                <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" ReadOnly="true" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODES")%>'></asp:TextBox>
                                                                <asp:TextBox ID="txtINVOICEADDR" runat="server" ReadOnly="true" CssClass="txt_table"
                                                                    Width="150px" Text='<%# Eval("INVOICEADDR")%>'></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--�Ȥ���End --%>
                        <%--�ץ󤺮eBegin --%>
                        <div id="fraTab22" class="div_content padleft_0 T_-188" style="display: none">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <%--Modify 20150126 By SS ChrisFu. Reason:�s�W�M�קO���--%>
                                <tr>
                                    <th>�M�קO
                                    </th>
                                    <td colspan="8">
                                        <asp:DropDownList ID="drpPROJCD" runat="server" Enabled="false">
                                            <asp:ListItem Value="01">�@��</asp:ListItem>
                                            <asp:ListItem Value="02">����</asp:ListItem>
                                            <asp:ListItem Value="03">�ưȾ�</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th width="12%">���q�W�� </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpCOMPID" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>�M��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O START-->
                                    <th width="12%">�ӧ@�覡 </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                    <th width="12%">�ӧ@���A </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpMAINTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>��~������</asp:ListItem>
                                            <asp:ListItem>�ꥻ������</asp:ListItem>
                                            <asp:ListItem>������R��</asp:ListItem>
                                            <asp:ListItem>�����b�ڨ���</asp:ListItem>
                                            <asp:ListItem>�����I��(�L��)</asp:ListItem>
                                            <asp:ListItem>�����I��(����)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpSUBTYPE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" Enabled="false">
                                            <asp:ListItem>��~������</asp:ListItem>
                                            <asp:ListItem>�ꥻ������</asp:ListItem>
                                            <asp:ListItem>������R��</asp:ListItem>
                                            <asp:ListItem>�����b�ڨ���</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th width="12%">����κA </th>
                                    <td>
                                        <asp:DropDownList ID="drpTRANSTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>���</asp:ListItem>
                                            <asp:ListItem>�T��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <tr>
                                        <th>�ʥα��� </th>
                                        <td>
                                            <asp:DropDownList ID="drpUSESTATUS" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>�浧�ʥ�</asp:ListItem>
                                                <asp:ListItem>�h���ʥ�</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCYCLETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>�`��</asp:ListItem>
                                                <asp:ListItem>���`��</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th>�N�L�� </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRINTSTORE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem Value="">�п��</asp:ListItem>
                                                <asp:ListItem Value="Y">�O</asp:ListItem>
                                                <asp:ListItem Value="N">�_</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.--%>
                                        <th>�Ȧ�O </th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>�ӧ@��H<!--20191119 ADD BY SS ADAM REASON.�ץ�ӷ�=>�ӧ@��H -->
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="drpCASESOURCE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>����CR</asp:ListItem>
                                                <asp:ListItem>�]��CR</asp:ListItem>
                                                <asp:ListItem>�����Ӥ���</asp:ListItem>
                                                <asp:ListItem>�Ȥ�ӹq</asp:ListItem>
                                                <asp:ListItem>�P�~����</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th>���l���v </th>
                                        <td colspan="5">
                                            <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="drpRECOURSE" runat="server" Enabled="false">
                                                        <asp:ListItem Value="">�п��</asp:ListItem>
                                                        <asp:ListItem Value="Y">�O</asp:ListItem>
                                                        <asp:ListItem Value="N">�_</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O START-->
                                        <tr>
                                            <th>�ץ󲣫~�O </th>
                                            <td colspan="8">
                                                <asp:DropDownList ID="drpPRODCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O END-->
                            </table>
                            <div>
                                <div class="left_div2001A">
                                    <table class="tb_Info" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td colspan="6">
                                                <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />�����B����ץ�
                                            </td>
                                        </tr>
                                        <tr>
                                            <th width="20%">�Ъ������B
                                            </th>
                                            <td width="12%">
                                                <asp:TextBox ID="txtTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th width="15%"></th>
                                            <td width="12%"></td>
                                            <th width="24%">�O�I�O
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtINSURANCE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�Y����
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>����
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCOMMISSION" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <!--Modify 20120529 By SS Gordon. Reason: �ק�u�@�~�O�Ρv���u�@�~�O��(���o��)�v-->
                                            <th>�@�~�O��(���o��)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOTHERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>���ʫO�Ҫ�
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th></th>
                                            <td></td>
                                            <!--Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v-->
                                            <th>�@�~�O��(�L�o��)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�i���O�Ҫ�
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>��U���B
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtACTUSLLOANS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>����O���J
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <th>�ݭ�
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRESIDUALS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�`�ӧ@���
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCONTRACTMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>�X��@�I
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPAYMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>�I�ڮɶ�
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drpPAYTIMET" DataTextField="MNAME1" DataValueField="MCODE"
                                                    runat="server" Width="80px" Enabled="false">
                                                    <asp:ListItem>����I</asp:ListItem>
                                                    <asp:ListItem>�����I</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table class="tb_grid" width="100%">
                                                    <tr>
                                                        <td width="13%">�� &nbsp; 1 &nbsp; ��
                                                        </td>
                                                        <td width="15%">- ��<asp:TextBox ID="txtENDPAY1" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td width="18%">���I��(���|)
                                                        </td>
                                                        <td width="18%">
                                                            <asp:TextBox ID="txtPRINCIPAL1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td width="18%">���I��(�t�|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>��
                                                        <asp:TextBox ID="txtSTARTPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>- ��<asp:TextBox ID="txtENDPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>���I��(���|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>���I��(�t�|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>��
                                                        <asp:TextBox ID="txtSTARTPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>- ��<asp:TextBox ID="txtENDPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>���I��(���|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>���I��(�t�|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>��
                                                        <asp:TextBox ID="txtSTARTPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>- ��<asp:TextBox ID="txtENDPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            ��
                                                        </td>
                                                        <td>���I��(���|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>���I��(�t�|)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="right_div" style="height: 265px;">
                                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" />�����b�ڮץ�
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�ӽ��B��
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�x�H�O
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�b�Ⱥ޲z�O
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�]���U�ݶO
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <!--Modify 20120618 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�-->
                                        <tr>
                                            <th>�i���O�Ҫ�
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>����
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>%
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�b�ڴ���
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>��
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
                                            <%--                                        <th>
                                            �I�ڮɶ�
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                                Enabled="false" runat="server" Width="80%">
                                                <asp:ListItem>����I</asp:ListItem>
                                                <asp:ListItem>�����I</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>
                                            <td>
                                                <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                                    Enabled="false" Style="display: none" runat="server" Width="80%">
                                                    <asp:ListItem>����I</asp:ListItem>
                                                    <asp:ListItem>�����I</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>��@�R�譭�B
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
                                            <%--                                        <th>
                                            �ӧ@�u��IRR
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtARIRR" custprop="100" Style="display: none" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <%--Modify 20150205 By SS ChrisFu. Reason:�s�W�u��ĳ�Դڮ��v���--%>
                                        <tr>
                                            <th>��ĳ�Դڮ�</th>
                                            <td>
                                                <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>%
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div style="clear: both;">
                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                    <tr>
                                        <th>�I�ڤ覡
                                        </th>
                                        <td colspan="5">
                                            <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                                Enabled="false">
                                                <asp:ListItem>�״�</asp:ListItem>
                                                <asp:ListItem>�䲼</asp:ListItem>
                                                <asp:ListItem>�M��</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>�I�ڮt���Ѽ�
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPATDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>�I�����ӤѼ�
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtSUPPILERDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>�w�p�����B�z�覡
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpEXPIREPROC" DataTextField="DNAME1" DataValueField="DCODE"
                                                runat="server" Enabled="false">
                                                <asp:ListItem>�H�ݭȽ椩������(�Ȥ�ĤT��)</asp:ListItem>
                                                <asp:ListItem>���`���</asp:ListItem>
                                                <asp:ListItem>��L</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <!--Modify 20120529 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v-->
                                        <th>�ץ󻡩�
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                                Style="width: 98%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                                    <tr>
                                        <th>IRR
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtIRR" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <%--Modify 20161130 By SEAN. Reason: �s�WNPV0�PNPV�Q�v����0--%>
                                        <%--20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%) --%>
                                        <th>NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>NPV����
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                                    <tr style="display: none;">
                                        <th></th>
                                        <td></td>
                                        <!--20150109 ADD BY SS ADAM REASON. -->
                                        <th>�]�ƥ�NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>�]�ƥ�NPV����
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                                    <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                    <tr style="display: none;">
                                        <th>�������
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCAPITALCOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true">7</asp:TextBox>
                                        </td>
                                        <th>�ĸ��NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>�ĸ��NPV����
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th style="display: none;">RECOVER TEST
                                        </th>
                                        <td colspan="5" style="display: none;">
                                            <asp:TextBox custprop="100" ID="txtRECOVERTEST" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="text-align: center; height: 30px;">
                                            <asp:Button ID="Button3" runat="server" Enabled="false" CssClass="btn_normal" Text="�պ�"
                                                Style="display: none" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%--�ץ󤺮eEnd --%>
                        <%--�Ъ���Begin --%>
                        <div id="fraTab33" class="div_content T_-188" style="display: none">
                            <div class="div_table" style="overflow: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 1100px;">
                                    <tr>
                                        <th>����
                                        </th>
                                        <th>�Ъ�������
                                        </th>
                                        <th>�Ъ����W��
                                        </th>
                                        <th>�]�ƪ��p
                                        </th>
                                        <th>����
                                        </th>
                                        <th>����
                                        </th>
                                        <th>������ID
                                        </th>
                                        <th>������
                                        </th>
                                        <th>����
                                        </th>
                                        <th>���楼�|
                                        </th>
                                        <th>�@�Φ~��
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
                                                </td>
                                                <td width="17%">
                                                    <asp:Label ID="txtTARGETNAME" Text='<%# Eval("TARGETNAME")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpTARGETSTATUS" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                        runat="server">
                                                        <asp:ListItem>�s��</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTARGETMODELNO" Text='<%# Eval("TARGETMODELNO")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTARGETMACHINENO" Text='<%# Eval("TARGETMACHINENO")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtSUPPLIERID" Text='<%# Eval("SUPPLIERID")%>' Width="80px" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' Width="160px" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTARGETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString())%>'
                                                        onblur="txtTARGETPRICE_onblur(this);" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString())%>'
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
                            <asp:CheckBox ID="chkAr" Enabled="false" runat="server" />
                            AR�ץ�L�Ъ���&nbsp;&nbsp;&nbsp;
                        <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.--%>
                            <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" />
                            �Ȧ�ץ�L�Ъ���
                        <br />
                            �]�Ʀs��a<br />
                            <div class="div_table" style="overflow-x: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 900px;">
                                    <tr>
                                        <th>����
                                        </th>
                                        <th width="350px">�s��a
                                        </th>
                                        <th>�p���H
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
                                        <th>E-mail
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Container.ItemIndex +1 %>
                                                </td>
                                                <td width="350px">
                                                    <asp:TextBox ID="txtSTOREDZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDZIPCODE")%>'></asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                        CssClass="txt_table" Text='<%# Eval("STOREDZIPCODES")%>'></asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDADDR" ReadOnly="true" runat="server" Width="150px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDADDR")%>'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTNAME" Text='<%# Eval("CONTACTNAME")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtDEPTNAME" Text='<%# Eval("DEPTNAME")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTTITLE" Text='<%# Eval("CONTACTTITLE")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTTELCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' />
                                                    <asp:Label ID="txtCONTACTTEL" Text='<%# Eval("CONTACTTEL")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTMPHONE" Text='<%# Eval("CONTACTMPHONE")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTFAXCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' />
                                                    <asp:Label ID="txtCONTACTFAX" Text='<%# Eval("CONTACTFAX")%>' runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtCONTACTEMAIL" Text='<%# Eval("CONTACTEMAIL")%>' runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                        <%--�Ъ���End --%>
                        <%--��O����Begin --%>
                        <div id="fraTab44" class="div_content T_-188" style="display: none; min-height: 730px; height: auto !important;">
                            <%--20131113 LEO �s�W�i������O����--%>
                        �i������O����
                        <asp:DropDownList ID="drpGuanValue" runat="server">
                        </asp:DropDownList>
                            <br />
                            �O�ҤH<asp:CheckBox ID="chkMLDCASEGUARANTEE" Enabled="false" runat="server" />
                            ���׵L�O�ҤH
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" style="width: 2400px;">
                                <tr>
                                    <th>�k�H/�ӤH
                                    </th>
                                    <th>�W��
                                    </th>
                                    <th>ID
                                    </th>
                                    <th>ñ�q�j����
                                    </th>
                                    <th>��������
                                    </th>
                                    <th><%--20230523�������B��O�H��O���B--%>
                        <%--�������B--%>
                          �O�H��O���B
                                    </th>
                                    <%--Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                                    <th>�ͤ�
                                    </th>
                                    <th>�ʧO
                                    </th>
                                    <th>���y�a�}/���q�n�O�a�}
                                    </th>
                                    <th>�q�T�a�}
                                    </th>
                                    <th>�p���q��
                                    </th>
                                    <th>���Y�H�@
                                    </th>
                                    <th>���Y�H�G
                                    </th>
                                    <th>¾�~����
                                    </th>
                                    <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                    <th>¾�~
                                    </th>
                                    <th>��¾���q
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="drpGRTTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                    class="bg_normal" runat="server" Width="80%">
                                                    <asp:ListItem>�k�H</asp:ListItem>
                                                    <asp:ListItem>�ӤH</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' runat="server" CssClass="txt_table"
                                                    Width="80" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                    Width="80" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGUARANTEEBILL" Enabled="false" runat="server" Width="80%">
                                                    <asp:ListItem Value="1">�O</asp:ListItem>
                                                    <asp:ListItem Value="2">�_</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGUARANTEEBILLTYPE" Enabled="false" runat="server" Width="80%">
                                                    <asp:ListItem Value="1">����</asp:ListItem>
                                                    <asp:ListItem Value="2">�䲼</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>'
                                                    ReadOnly="true" runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <%--Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                                            <td>
                                                <asp:TextBox ID="txtGRTBIRDT" Enabled="false" Text='<%# Eval("GRTBIRDT") %>' runat="server"
                                                    Width="80px" CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTSEX" Enabled="false" runat="server" Width="50px">
                                                    <asp:ListItem Value="">�п��</asp:ListItem>
                                                    <asp:ListItem Value="1">�k</asp:ListItem>
                                                    <asp:ListItem Value="2">�k</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTRESIDENTZIP" Enabled="false" Text='<%# Eval("GRTRESIDENTZIP") %>'
                                                    runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <input type="button" id="btnGRTRESIDENTZIP" disabled="disabled" class="btn_normal"
                                                    onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                    value="&#8230;" />
                                                <asp:TextBox ID="txtGRTRESIDENTZIPNM" Enabled="false" Text='<%# Eval("GRTRESIDENTZIPNM") %>'
                                                    runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTRESIDENTADDR" Enabled="false" Text='<%# Eval("GRTRESIDENTADDR") %>'
                                                    runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');"
                                                    MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTZIP" Enabled="false" Text='<%# Eval("GRTZIP") %>' runat="server"
                                                    Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <input type="button" id="btnGRTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);"
                                                    onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                                <asp:TextBox ID="txtGRTZIPNM" Enabled="false" Text='<%# Eval("GRTZIPNM") %>' runat="server"
                                                    Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTADDR" Enabled="false" Text='<%# Eval("GRTADDR") %>' runat="server"
                                                    Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');"
                                                    MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTTELCODE" Enabled="false" Text='<%# Eval("GRTTELCODE") %>'
                                                    runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);"
                                                    onblur="OnlyNumBlur(this);"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTTEL" Enabled="false" Text='<%# Eval("GRTTEL") %>' runat="server"
                                                    Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTTELEXT" Enabled="false" Text='<%# Eval("GRTTELEXT") %>' runat="server"
                                                    Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTRELATION1" Enabled="false" runat="server" Width="180px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTRELATION2" Enabled="false" runat="server" Width="105px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTJOBCLS" Enabled="false" runat="server" Width="160px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                            <td>
                                                <asp:DropDownList ID="drpGRTJOB" Enabled="false" runat="server" Width="220px" DataTextField="DNAME1"
                                                    DataValueField="DCODE">
                                                    <asp:ListItem Value="">�D��v</asp:ListItem>
                                                    <asp:ListItem Value="01">��v</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTCOMPANY" Enabled="false" Text='<%# Eval("GRTCOMPANY") %>'
                                                    runat="server" Width="200px" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                            <br />
                            �ʲ��]�w<asp:CheckBox ID="chkMLDCASEMOVABLE" Enabled="false" runat="server" />
                            ���׵L�ʲ��]�w
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" style="width: 1200px;">
                                <tr>
                                    <th>����
                                    </th>
                                    <th>���~�]��
                                    </th>
                                    <th>���׼Ъ�
                                    </th>
                                    <th>�Ҧb�a
                                    </th>
                                    <th>�����Ǹ�
                                    </th>
                                    <th>�X���~��
                                    </th>
                                    <th>�ʶR���
                                    </th>
                                    <th>�s�~���B
                                    </th>
                                    <th>�ʶR���B
                                    </th>
                                    <th>�ݭȹw��
                                    </th>
                                    <th>�]�w���B
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENAME" ReadOnly="true" Text='<%# Eval("MOVABLENAME")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                    <asp:ListItem Value="1">�O</asp:ListItem>
                                                    <asp:ListItem Value="2">�_</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                    Text='<%# Eval("MOVABLEZIPCODE")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                    CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEADDR" ReadOnly="true" runat="server" CssClass="txt_table"
                                                    Width="150px" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENO" ReadOnly="true" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEYEAR" ReadOnly="true" Text='<%# Eval("MOVABLEYEAR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENEWAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESIDUALS" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESETPRICE" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                            ���ʲ��]�w<asp:CheckBox ID="chkMLDCASEIMMOVABLE" Enabled="false" runat="server" />
                            ���׵L���ʲ��]�w
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" width="1100px" border="1">
                                <tr>
                                    <th>����
                                    </th>
                                    <th>�Ҧ��H
                                    </th>
                                    <th>ID
                                    </th>
                                    <th>���o�ɶ�
                                    </th>
                                    <th>�ت�������
                                    </th>
                                    <th>�g�a�a�q
                                    </th>
                                    <th>�a��
                                    </th>
                                    <th>�������n
                                    </th>
                                    <th>�g�a���n
                                    </th>
                                    <th>�ظ�
                                    </th>
                                    <th>���P���X
                                    </th>
                                    <th>�ؿv�`���n(���褽��)
                                    </th>
                                    <th>�ؿv�`���n(�W)
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEIMMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNER" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNERID" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEGETDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLESECTOR" ReadOnly="true" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILD" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEHOLDER" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDNO" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEHOUSENUM" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                    onblur="areacon(this)" runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                            <br />
                            <table class="tb_Contact" border="1">
                                <tr>
                                    <th>����
                                    </th>
                                    <th>�v�Q�H
                                    </th>
                                    <th>�n�O���
                                    </th>
                                    <th>�]�w���B
                                    </th>
                                    <th>���v�H
                                    </th>
                                    <th>���ʲ�����
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDHUMANRIGHTS" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHUMANRIGHTS" ReadOnly="true" Text='<%# Eval("HUMANRIGHTS") %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtREGISTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSETPRICE" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCREDITOR" ReadOnly="true" Text='<%# Eval("CREDITOR") %>' runat="server"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <br />
                            �w�s����<asp:CheckBox ID="chkMLDCASEADEPOSIT" Enabled="false" runat="server" />
                            ���׵L�w�s��]�w
                        <table class="tb_Contact" width="85%">
                            <tr>
                                <th>�Ȧ�
                                </th>
                                <th>�w�s�渹
                                </th>
                                <th>���B
                                </th>
                                <th>�w�s�_��
                                </th>
                                <th>�w�s�W��
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEADEPOSIT" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("DEPOSITBANKS") %>'
                                                Width="120px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITNBR" ReadOnly="true" Text='<%# Eval("DEPOSITNBR") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITAMT" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITSTARTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITDUEDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                            <br />
                            �Ȳ�<asp:CheckBox ID="chkMLDCASEBILLNOTE" Enabled="false" runat="server" />
                            ���׵L�Ȳ�
                        <table class="tb_Contact" width="80%">
                            <tr>
                                <th>���ڨ����
                                </th>
                                <th>�I�ڦ�w��
                                </th>
                                <th>���ں���
                                </th>
                                <th>���ڸ��X
                                </th>
                                <th>�b��
                                </th>
                                <th>�o���H�W��
                                </th>
                                <th>�������B
                                </th>
                                <th>�Ƶ�
                                </th>
                                <th>�ٲ���
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEBILLNOTE" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("BILLNOTEBANKS") %>'
                                                Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                                <asp:ListItem Value="1">����</asp:ListItem>
                                                <asp:ListItem Value="2">�䲼</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENBR" ReadOnly="true" Text='<%# Eval("BILLNOTENBR") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACCOUNT" ReadOnly="true" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTECUSTNAME" ReadOnly="true" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENOTE" ReadOnly="true" Text='<%# Eval("BILLNOTENOTE") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBACKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table" Width="72px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                            <br />
                            �Ѳ�<asp:CheckBox ID="chkMLDCASESTOCK" Enabled="false" runat="server" />
                            ���׵L�Ѳ�
                        <table class="tb_Contact" width="70%">
                            <tr>
                                <th>�]�w���
                                </th>
                                <th>�Ѳ��W��
                                </th>
                                <th>���ѤH
                                </th>
                                <th>���(��)
                                </th>
                                <th>�i��
                                </th>
                                <th>�`��(��)
                                </th>
                                <th>�}�l��
                                </th>
                                <th>�I�
                                </th>
                                <th>�O�I�c
                                </th>
                                <th>�Ƶ�
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASESTOCK" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNAME" ReadOnly="true" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKPROVIDER" ReadOnly="true" Text='<%# Eval("STOCKPROVIDER") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKUNIT" ReadOnly="true" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" ReadOnly="true" Text='<%# Eval("STOCKQUANTITY") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" ReadOnly="true" Text='<%# Eval("STOCKTOTAL") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKBEGIN" ReadOnly="true" Text='<%# Eval("STOCKBEGIN") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKEND" ReadOnly="true" Text='<%# Eval("STOCKEND") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                                <asp:ListItem Value="1">���O</asp:ListItem>
                                                <asp:ListItem Value="2">����</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNOTE" ReadOnly="true" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                            <br />
                            ��L<br />
                            <asp:TextBox ID="txtOTHERCOND" ReadOnly="true" runat="server" CssClass="txt_normal"
                                Width="80%"></asp:TextBox>
                        </div>
                        <%--��O����End --%>
                        <%--�x�f���Begin --%>
                        <div id="fraTab55" class="div_content T_-188" style="display: none">
                            <table class="tb_Text" width="98%">
                                <tr>
                                    <th width="5%">����
                                    </th>
                                    <th width="52%">���
                                    </th>
                                    <th width="10%">���Ƥ��
                                    </th>
                                    <th width="15%">�i���ƽT�{
                                    </th>
                                    <th>����
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEAPPENDDOC" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("DNAME1")%>'></asp:Label>
                                                <td>
                                                    <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL"))  %>'
                                                        runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>'
                                                        Enabled="false" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNOTE" Text='<%# Eval("NOTE") %>' runat="server" ReadOnly="true"
                                                        CssClass="txt_table" Width="120px"></asp:TextBox>
                                                </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <%--�x�f���End --%>
                        <%--20120216 MODIFY BY SSF MAUREEN REASON:�s�W�x�H���i��ñ���--%>
                        <%--�ץ���iBegin --%>
                        <div id="fraTab66" class="div_content T_-188" style="display: none; min-height: 820px;">
                            <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal"
                                Text="��~�����i�U��" Width="170" />
                            <asp:Label ID="lblOpenFile" runat="server" Text=""></asp:Label>
                            <asp:LinkButton ID="lkbOpenFile" Style="display: none;" runat="server"></asp:LinkButton>
                            <br />
                            <div>
                                <asp:Button ID="btnCREDITFILEID" OnClientClick="addFile();return false;" runat="server"
                                    CssClass="btn_normal" Text="�x�H�ץ�W��" Width="170" />
                                <asp:TextBox ID="txtCREDITFILENAME" runat="server" CssClass="txt_readonly" Width="300px"></asp:TextBox>
                                <%-- 20131008 Edit by Sean �w�x�f�������ץ�]�i�W�Ǽx�H�ɮ�--%>
                                <asp:Button ID="btnUploadSave" runat="server" Text="�W�ǽT�{" CssClass="btn_normal" OnClick="btnUploadSave_Click"
                                    Width="80" />
                            </div>

                            <%-- 20140109 ADD BY SS ADAM Reason.�x�H�����i�U���A�אּ�x�H���i���@ �ö}����ML2008 --%>
                            <%-- 20141212 UPD BY SS JBLeo Reason.�������Ѽx�H���i�U���A�N�x�H���i���@���sID�אּbtnCREDITFILEmaintain--%>
                            <asp:Button ID="btnCREDITFILEdownload" OnClientClick="return false;" runat="server"
                                CssClass="btn_normal" Text="�x�H�����i�U��" Width="170" />
                            <br />
                            <asp:Button ID="btnCREDITFILEmaintain" OnClick="btnCREDITFILEmaintain_Click" runat="server"
                                CssClass="btn_normal" Text="�x�H���i���@" Width="170" />
                            <br />
                            <asp:HiddenField ID="hidCREDITFILEID" runat="server" Value="" />
                            <asp:Button ID="btnLackComment" runat="server" OnClientClick="javascipt:return btnLackComment_Click(this);"
                                OnClick="btnLackComment_Click" CssClass="btn_normal" Text="�ʥ�q��" Width="170" /><br />
                            <asp:HiddenField ID="hidLackComment" runat="server" Value="" />
                            <br />
                            <!--
            <asp:Button ID="btnDoc1" runat="server" CssClass="btn_normal" Text="�x�H��ĳ��" /><br />
            <br />
            <asp:Button ID="btnDocCreditRepor" runat="server" CssClass="btn_normal" Text="�U���ץ����"
              OnClick="btnDocCreditRepor_Click" />
              -->
                            <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                <tr>
                                    <%--�x�Hñ�֤�--%>
                                    <th style="nowrap;">��f�T�{
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRCREDITDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);checkdate(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="100px" style="nowrap;">��f�T�{�ɶ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRCREDITDTIME" MaxLength="4" onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)"
                                            onblur="check_keyintime(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="80px" style="nowrap;">�x�H����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);checkdate(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="100px" style="nowrap;">�x�H�����ɶ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITDTIME" MaxLength="4" onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)"
                                            onblur="check_keyintime(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="nowrap;">������
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITRECDT" runat="server" custprop="010" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th style="nowrap;">�e����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITSENDDT" runat="server" custprop="010" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th style="nowrap;">
                                        <!--ñ���v��-->
                                        <!--UPD BY VICKY 20140627 �[�J�x�f�H�� -->
                                        �x�f�H��
                                    </th>
                                    <td>
                                        <asp:Label ID="labCREDITER" runat="server"></asp:Label>
                                        <asp:Label ID="labCREDITER_ID" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                    <th>&nbsp;
                                    </th>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <!-- UPD BY VICKY 20140627 �[�J ��U���B�v��,IRR�v��-->
                                <tr>
                                    <th style="nowrap;">��U���B�v��
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPROPOSEDSIGN" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Style="display: none">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th style="nowrap;">IRR�v��
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th style="nowrap;">�x�H��ĳ
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpSUGGEST" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th>&nbsp;
                                    </th>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 1px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" style="nowrap;">�x�H�N���G
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCREDITDESC" Height="300px" Width="100%" Style="word-wrap: break-word; word-break: break-all;"
                                                TextMode="MultiLine" CssClass="txt_normal" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <%--Modify 20121204 By SS Steven. Reason: �s�W�u�����X�����~�]�w�v�\��.--%>
                                <center>
                                    <%--Modify 20130117 By SS Adam. Reason: �W�[��e�׾�O�~�W�[�����ܧP�_.--%>
                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <table>
                                            <tr align="center">
                                                <td>
                                                    <th>��e�׾�O�~�W�[����
                                                    </th>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuery" runat="server" Text="�d�߬����X��" CssClass="btn_normal" OnClientClick="javascipt:return SHOW_2001(this);" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </center>
                                <br />
                                <%--Modify 20140806 By SS Chris Hung. Reason: �b�x�H���i���ҵe�����A�s�W���׵n�O�϶�.--%>
                                <div>
                                    <%-- �s�W���׵n�O�϶� begin--%>
                                    <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                        <tr>
                                            <th width="80px" rowspan="11">�x�H���� (��f)
                                            </th>
                                            <th style="width: 110px; nowrap;">��ĳ�B��(��)
                                            </th>
                                            <td style="xwidth: 100px; nowrap;">
                                                <asp:TextBox ID="txtCREDITAMT" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                            <th style="width: 120px; nowrap;">����
                                            </th>
                                            <td style="xwidth: 100px; nowrap;">
                                                <asp:TextBox ID="txtCONTRACTMON" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                            </td>
                                            <th style="width: 100px; nowrap;">�i�O��(��)
                                            </th>
                                            <td style="width: 100px; nowrap;">
                                                <asp:TextBox ID="txtPERBOND2" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="text-align: center; nowrap;" colspan="6">��O�~
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="text-align: center; nowrap;" width="110px">
                                                <asp:CheckBox ID="chkGRTMV" runat="server" Text="�ʲ�" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTIMV" runat="server" Text="���ʲ�" />
                                            </th>
                                            <th style="text-align: center; nowrap;" width="120px">
                                                <asp:CheckBox ID="chkGRTDEPOSIT" runat="server" Text="�w�s���" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTBILLNOTE" runat="server" Text="�Ȳ�" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTSTOCK" runat="server" Text="�Ѳ�" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTCAR" runat="server" Text="����" />
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">
                                                <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                                ��O�~�`�l�B<br />
                                                (���A�t�i�O)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtGRTBAL" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                            <th style="nowrap;" width="120px">
                                                <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                                ��O�~����<br />
                                                (�t�i�O)
                                            </th>
                                            <td>
                                                <!--20150109 ADD BY SS ADAM REASON.�W�[Ĳ�oñ�ֳƵ� -->
                                                <asp:TextBox ID="txtGRTVAL" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo"></asp:TextBox>
                                            </td>
                                            <td>�H
                                            </td>
                                            <td>&nbsp
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">����γ~
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlFUNDSUSE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                    <asp:ListItem Text="������" Value="01"></asp:ListItem>
                                                    <asp:ListItem Text="�D������" Value="02"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <th style="nowrap;" width="120px">�]�ƪ��A
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlECONDITION" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                    <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="�s��" Value="01"></asp:ListItem>
                                                    <asp:ListItem Text="���j��" Value="02"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">�ާ@�Ҧ�
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlOPERATION" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                </asp:DropDownList>
                                            </td>
                                            <th style="nowrap;" width="120px">�]������
                                            </th>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlDEVICETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">�����ٷs�����B
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtDEDUCTION" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ===START===-->
                                        <tr>
                                            <th style="nowrap;">��~�O
                                            </th>
                                            <td colspan="3">
                                                <%--20221207 ��~�O��U�Կ��--%>
                                                <asp:DropDownList ID="DrpNDU_TAB6" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                    DataValueField="MCODE">
                                                    <asp:ListItem>�п��</asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:TextBox ID="txtINDUID_TAB6" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB6');" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtINDUNM_TAB6" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                                <asp:Button ID="btnINDUPAGE_TAB6" runat="server" Text="�d�ߦ�~�O" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="false" />
                                            </td>
                                            <th style="nowrap;">�ץ󲣫~�O
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drpPRODCD_TAB6" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ====END====-->
                                        <tr>
                                            <th style="nowrap;" width="110px">�ʲ����~
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtGRTITEM" MaxLength="500" runat="server" Width="99%" TextMode="MultiLine"
                                                    Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">��L����
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtOTHERCONDITION" MaxLength="500" runat="server" Width="99%" TextMode="MultiLine"
                                                    Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">ñ���v��/�Ƶ�
                                            </th>
                                            <td colspan="5">
                                                <%--20221102�Ƶ��אּ�i�ק�--%>
                                                <asp:TextBox ID="txtSIGNMEMO" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%-- �s�W���׵n�O�϶� end--%>
                                <%--20141218 ADD BY SS ADAM REASON.�C�L�x�H���i�ѧ�쭶�Ҥ� --%>
                                <br />
                                <center>
                                    <asp:Button ID="cmdPrintReportB" runat="server" Text="�C�L�x�H���i��" CssClass="btn_normal"
                                        OnClientClick="javascipt:return cmdPrintB_onClick(this);" Width="120" />
                                </center>
                                <tr>
                                    <td>
                                        <%--Modify 20130103 By SS Maureen. Reason: �b�x�H���i���ҵe�����A�s�W���ʲ��]�wGRID.--%>
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <%--Modify 20130131 By SS Maureen. Reason:�W�٭קאּ���ʲ���ơA�ò������׵L���ʲ��]�w���ﶵ--%>
                                            <%--���ʲ��]�w<asp:CheckBox ID="chkMLDIMMOVABLEDF" Enabled="false" runat="server" />
                                         ���׵L���ʲ��]�w &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>--%>
                                        ���ʲ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9
                                            ]</span>
                                            <div class="div_table" style="overflow-x: scroll; width: 700px">

                                                <asp:UpdatePanel ID="UpdatePanelMLDIMMOVABLEDF" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table id="tblMLDIMMOVABLEDF" class="tb_Contact" width="1800px" border="1">
                                                            <tr onclick="changeTag('rptMLDIMMOVABLEDF')">
                                                                <th>����
                                                                </th>
                                                                <th>�Ҧ��H
                                                                </th>
                                                                <th>ID
                                                                </th>
                                                                <th>���o�ɶ�
                                                                </th>
                                                                <th>�ت�������
                                                                </th>
                                                                <th>�g�a�a�q
                                                                </th>
                                                                <th>�a��
                                                                </th>
                                                                <th>�������n
                                                                </th>
                                                                <th>�g�a���n
                                                                </th>
                                                                <th>�ظ�
                                                                </th>
                                                                <th>���P���X
                                                                </th>
                                                                <th>�ؿv�`���n(���褽��)
                                                                </th>
                                                                <th>�ؿv�`���n(�W)
                                                                </th>
                                                                <th>�ؿv�������n(���褽��)
                                                                </th>
                                                                <th>���ש��
                                                                </th>
                                                                <th>��㱡��
                                                                </th>
                                                                <th>�γ~
                                                                </th>
                                                            </tr>
                                                            <asp:Repeater ID="rptMLDIMMOVABLEDF" runat="server">
                                                                <ItemTemplate>
                                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDIMMOVABLEDF','<%# Container.ItemIndex  %>')">
                                                                        <td>
                                                                            <%# Container.ItemIndex +1 %>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEOWNER_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                                                runat="server" MaxLength="10" onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <asp:HiddenField ID="hidIMMOVABLEID_D" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEOWNERID_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                                                runat="server" onkeypress="OnlyNumD(this);" onblur="idBlur(this);" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEGETDATE_D" ReadOnly="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                                                runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                                                onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE_D" ReadOnly="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                                                runat="server" CssClass="txt_table" MaxLength="8" onkeypress="OnlyNum(this);"
                                                                                onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLESECTOR_D" ReadOnly="false" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILD_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEAREA_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);"
                                                                                MaxLength="10" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEHOLDER_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);"
                                                                                MaxLength="10" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDNO_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                                                onblur="areacon(this)" onkeypress="OnlyNumAndSpot(this);" MaxLength="8" runat="server"
                                                                                CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblIMMOVABLEBUILDAREA_D" Enabled="true" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <%--Modify 20130131 By SS Maureen. Reason: �ץ��ؿv�������n���A��ܥ��T���.--%>
                                                                            <%--<asp:TextBox ID="txtIMMOVABLEBUILDHOLD_D" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'--%>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDHOLD_D" Text='<%# Eval("IMMOVABLEBUILDHOLD")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" MaxLength="8" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpIMMOVABLECASEPAWN_D" runat="server" Enabled="true">
                                                                                <asp:ListItem Value="Y">Y</asp:ListItem>
                                                                                <asp:ListItem Value="N">N</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEPAWNSTATUS_D" Width="200px" Text='<%# Eval("IMMOVABLEPAWNSTATUS")%>'
                                                                                runat="server" MaxLength="100" onblur="CheckMLength(this,'100','��㱡��');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEPURPOSE_D" Width="200px" Text='<%# Eval("IMMOVABLEPURPOSE")%>'
                                                                                runat="server" MaxLength="60" onblur="CheckMLength(this,'60','�γ~');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <br />
                                            <div class="div_table" style="overflow: scroll; width: 700px">
                                                <asp:UpdatePanel ID="UpdatePanelMLDHUMANRIGHTS" runat="server" UpdateMode="Conditional"
                                                    Visible="false">
                                                    <ContentTemplate>
                                                        <table class="tb_Contact" border="1">
                                                            <tr onclick="changeTag('rptMLDIMMOVABLEDF')">
                                                                <th>����
                                                                </th>
                                                                <th>�v�Q�H
                                                                </th>
                                                                <th>�n�O���
                                                                </th>
                                                                <th>�]�w���B
                                                                </th>
                                                                <th>���v�H
                                                                </th>
                                                                <th>���ʲ�����
                                                                </th>
                                                            </tr>
                                                            <asp:Repeater ID="rptMLDHUMANRIGHTS_D" runat="server">
                                                                <ItemTemplate>
                                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDIMMOVABLEDF','<%# Container.ItemIndex  %>')">
                                                                        <td>
                                                                            <%# Container.ItemIndex +1 %>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtHUMANRIGHTS_D" Text='<%# Eval("HUMANRIGHTS") %>' MaxLength="10"
                                                                                onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtREGISTDATE_D" onkeypress="OnlyNum(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                                                MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server"
                                                                                CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSETPRICE_D" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                                onblur="MoneyBlur(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCREDITOR_D" Text='<%# Eval("CREDITOR") %>' runat="server" MaxLength="10"
                                                                                onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpMLDCASEIMMOVABLE_D" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged"
                                                                                runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <center>
                                                <table>
                                                    <tr align="center">
                                                        <td>
                                                            <asp:Button ID="btnSaveImmov" runat="server" Text="�x�s" CssClass="btn_normal" OnClick="btnSaveImmov_Click" />
                                                            <asp:Button ID="btnExcelImmov" runat="server" Text="EXCEL�U��" OnClick="cmdExport_Click"
                                                                CssClass="btn_normal" />
                                                            <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
                                                            <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
                                                            <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
                                                            <asp:HiddenField ID="hidSelRowTag" runat="server" Value="" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </asp:Panel>
                                    </td>
                                </tr>
                        </div>
                        <%--�ץ���iEnd --%>
                        <%--�H�άd��Begin --%>
                        <div id="fraTab77" class="div_content T_-168" style="display: none; min-height: 730px; height: auto !important;">
                            <div id="fraDispTypeInfo1" class="frame_content div_Info1" style="border: none; border-top: 1px solid #9FA1AD;">
                                <div id="fraTab111Caption" tabframe="fraTab111" container="fraDispTypeInfo1" onclick="Caption_onclick(this);"
                                    class="sheet div_menu2">
                                    <label class="label_contain">
                                        CCIS</label>
                                </div>
                                <div id="fraTab222Caption" tabframe="fraTab222" container="fraDispTypeInfo1" onclick="Caption_onclick(this);Caption_onclick(document.getElementById('fraTab11111Caption'));"
                                    class="sheet div_menu2 L_251 T_-24">
                                    <label class="label_contain">
                                        JCIC</label>
                                </div>
                                <div id="fraTab333Caption" tabframe="fraTab333" container="fraDispTypeInfo1" onclick="Caption_onclick(this);"
                                    class="sheet div_menu2 L_502 W_247 T_-48">
                                    <label class="label_contain">
                                        ���Ӭd��</label>
                                </div>
                                <div id="fraTab111" class="div_content padleft_0" style="margin-top: 62px;">
                                    <div style="width: 750px;">
                                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                                            <tr>
                                                <td>����
                                                <asp:CheckBox ID="CheckBox42" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox43" runat="server" /><asp:TextBox ID="TextBox100" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox44" runat="server" /><asp:TextBox ID="TextBox105" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox45" runat="server" /><asp:TextBox ID="TextBox106" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox46" runat="server" /><asp:TextBox ID="TextBox107" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="fraDispTypeInfo2" class="frame_content div_Info2" style="border: none; width: 750px;">
                                        <div id="fraTab1111Caption" tabframe="fraTab1111" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3">
                                            <label class="label_contain">
                                                �K�n�H��</label>
                                        </div>
                                        <div id="fraTab2222Caption" tabframe="fraTab2222" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_67 T_-24">
                                            <label class="label_contain">
                                                �ӤH�ک�</label>
                                        </div>
                                        <div id="fraTab3333Caption" tabframe="fraTab3333" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_134 T_-48">
                                            <label class="label_contain">
                                                ���q�ک�</label>
                                        </div>
                                        <div id="fraTab4444Caption" tabframe="fraTab4444" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_201 T_-72">
                                            <label class="label_contain">
                                                �ک��ܧ�</label>
                                        </div>
                                        <div id="fraTab5555Caption" tabframe="fraTab5555" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_268 T_-96 W_70">
                                            <label class="label_contain">
                                                �h���O��</label>
                                        </div>
                                        <div id="fraTab6666Caption" tabframe="fraTab6666" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_340 T_-120 W_70">
                                            <label class="label_contain">
                                                �h���O��</label>
                                        </div>
                                        <div id="fraTab7777Caption" tabframe="fraTab7777" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_412 T_-144">
                                            <label class="label_contain">
                                                �פ��</label>
                                        </div>
                                        <div id="fraTab8888Caption" tabframe="fraTab8888" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_479 T_-168">
                                            <label class="label_contain">
                                                �]���x�H</label>
                                        </div>
                                        <div id="fraTab9999Caption" tabframe="fraTab9999" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_546 T_-192">
                                            <label class="label_contain">
                                                �T�����</label>
                                        </div>
                                        <div id="fraTab00001Caption" tabframe="fraTab00001" container="fraDispTypeInfo2"
                                            onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_613 T_-216">
                                            <label class="label_contain">
                                                �T�U�H��</label>
                                        </div>
                                        <div id="fraTab00002Caption" tabframe="fraTab00002" container="fraDispTypeInfo2"
                                            onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_680 T_-240 W_69">
                                            <label class="label_contain">
                                                �d�߰O��</label>
                                        </div>
                                        <div id="fraTab1111" class="div_content T_-220">
                                            �d��ID
                                        <asp:TextBox CssClass="txt_normal" ID="TextBox29" runat="server"></asp:TextBox>
                                            <table class="tb_Contact" width="98%">
                                                <tr>
                                                    <th>�����Ҹ�
                                                    </th>
                                                    <th>�ӤH�m�W
                                                    </th>
                                                    <th>���q�νs
                                                    </th>
                                                    <th>���q�W��
                                                    </th>
                                                    <th>���O
                                                    </th>
                                                    <th>���
                                                    </th>
                                                    <th>�ک��Q�d
                                                    </th>
                                                    <th>�h���Q�d
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label123" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label124" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label125" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label126" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label127" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label128" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label130" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label131" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            �ک��Q�d
                                        <table class="tb_Contact" width="98%">
                                            <tr>
                                                <th>�d�߱���
                                                </th>
                                                <th>�d�ߤ��
                                                </th>
                                                <th>�d�ߪ�
                                                </th>
                                                <th>�ӷ|���e
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label132" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label133" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label134" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label135" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                            <br />
                                            �h���Q�d
                                        <table class="tb_Contact" width="98%">
                                            <tr>
                                                <th>�d�߱���
                                                </th>
                                                <th>�d�ߤ��
                                                </th>
                                                <th>�d�ߪ�
                                                </th>
                                                <th>�ӷ|���e
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label136" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label137" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label138" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label139" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        <div id="fraTab2222" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox20" runat="server" Width="98px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox22" runat="server" Width="98px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���ڥ洫��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox23" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox24" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">���q�W��
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox30" runat="server" Width="235px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">�t�d�H
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox31" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�����Ҹ�
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox33" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�X�ͦ~���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox32" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�a�}
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox34" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ȧ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox35" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2"></th>
                                                    <th>(����)�b��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox36" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox37" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox38" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox39" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox40" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox41" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox50" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ��]
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox84" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�ܧ󤺮e
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox85" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab3333" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox86" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">���q�W��
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox87" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox88" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2"></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox125" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���ڥ洫��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox108" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Τ@�s��</th>
                          <td><asp:TextBox ID="TextBox109" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>���q�W��</th>
                          <td colspan="2"><asp:TextBox ID="TextBox110" runat="server" Width="275px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th width="12%">�t�d�H
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox111" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�����Ҹ�
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox112" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�X�ͦ~���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox113" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�a�}
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox114" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ȧ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox115" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(����)�b��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox816" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox117" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox118" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox119" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox120" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox121" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox122" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ��]
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox123" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�ܧ󤺮e
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox124" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab4444" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>�ܧ󤺮e
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox126" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox127" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���ڥ洫��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox128" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox129" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">���q�W��
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox130" runat="server" Width="249px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">�t�d�H
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox131" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�����Ҹ�
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox132" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�X�ͦ~���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox133" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�a�}
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox134" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ȧ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox135" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(����)�b��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox136" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox138" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox139" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox140" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox141" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox142" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox143" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ��]
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox144" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Τ@�s��</th>
                          <td><asp:TextBox ID="TextBox145" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>���q�W��</th>
                          <td colspan="2"><asp:TextBox ID="TextBox146" runat="server" Width="264px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                            </table>
                                        </div>
                                        <div id="fraTab5555" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>��J���
                                                    </th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox147" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox276" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="15%">��J���
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="TextBox148" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="15%">�h���I����
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="TextBox149" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="8%">�m�W
                                                    </th>
                                                    <td width="10%">
                                                        <asp:TextBox ID="TextBox150" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�����Ҹ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox151" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���q�νs
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox152" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>���q�W��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox153" runat="server" Width="140px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;�d�ߵ��G<asp:TextBox ID="TextBox154" runat="server" Width="140px"
                                                            CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox155" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�Ƶ�
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox156" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�ڵ����Ӹ�T
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox157" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ڵ����ӡA
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox158" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        �Ѱ�
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�פ�����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox159" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�פ�����A
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox160" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        �Ѱ��פ����
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���Y��ḹ
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox161" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>���Y���W
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox162" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox163" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox164" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                    <td colspan="6">�Ƶ��N�X�����GA.�M�vū�^�AB.�����I�W�AC.���s�ƥI
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="tb_Contact" style="margin-left: 10px; margin-top: 10px;" width="90%">
                                                <tr>
                                                    <th>�h�����
                                                    </th>
                                                    <th>�h����
                                                    </th>
                                                    <th>�b��
                                                    </th>
                                                    <th>���ڸ��X
                                                    </th>
                                                    <th>���B
                                                    </th>
                                                    <th>�h���z��
                                                    </th>
                                                    <th>�M�v�`�O
                                                    </th>
                                                    <th>�Ƶ�
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label25" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label27" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label28" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label29" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab6666" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>��J���
                                                    </th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox165" runat="server" Width="83px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="14%"></th>
                                                    <td width="14%">
                                                        <asp:TextBox ID="TextBox166" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="16%">�h���I����
                                                    </th>
                                                    <td width="14%">
                                                        <asp:TextBox ID="TextBox167" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="6%">�m�W
                                                    </th>
                                                    <td width="17%">
                                                        <asp:TextBox ID="TextBox168" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�����Ҹ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox169" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���q�νs
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox174" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>���q�W��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox175" runat="server" Width="170px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                        �d�ߵ��G<asp:TextBox ID="TextBox176" runat="server" Width="170px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�}���N�X
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox177" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�}���b��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox178" runat="server" Width="400px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table class="tb_Contact" style="margin-left: 10px;" width="90%">
                                                <tr>
                                                    <th></th>
                                                    <th colspan="2">�w�M�v�`�O
                                                    </th>
                                                    <th colspan="2">���M�v�`�O
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th>�h���z��
                                                    </th>
                                                    <th>�i��
                                                    </th>
                                                    <th>���B
                                                    </th>
                                                    <th>�i��
                                                    </th>
                                                    <th>���B
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>1.�s�ڤ���
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server">1</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server">334500</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>2.�o���Hñ������
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label31" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label36" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>3.�զ۫��w���ķ~�̬����������I�ڤH
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label41" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label42" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label44" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>4.�������ܴ����g�L�e�M�P�I�کe�U
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label45" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label46" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label47" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">�}���`�Ƹ�T�w�b�x�W�a�ϥ�����ķ~�̶}�ߤ䲼�ڤ�@
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label49" runat="server">5</asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            ��L���n��T
                                        <asp:TextBox ID="TextBox179" runat="server" Width="180px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox ID="TextBox180" runat="server" Width="180px" CssClass="txt_readonly"
                                                ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox ID="TextBox181" runat="server" Width="180px" CssClass="txt_readonly"
                                                ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div id="fraTab7777" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox182" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">���q�W��
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox183" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox184" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2"></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox185" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���ڥ洫��
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox186" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>�Τ@�s��</th>
                          <td><asp:TextBox ID="TextBox187" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>���q�W��</th>
                          <td colspan="2"><asp:TextBox ID="TextBox188" runat="server" Width="275px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th width="12%">�t�d�H
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox189" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�����Ҹ�
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox190" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�X�ͦ~���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox191" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�a�}
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox192" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ȧ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox193" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(����)�b��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox194" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox195" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox196" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>�Ȧ�</th>
                          <td><asp:TextBox ID="TextBox197" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(����)�b��</th>
                          <td><asp:TextBox ID="TextBox198" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>�ک����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox199" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox200" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�ܧ��]
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox201" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�ܧ󤺮e
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox202" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab8888" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>�Ƶ�����
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox203" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox204" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�׸�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox223" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">�x�H���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox225" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���q�νs
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox206" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">���q�W��
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox207" runat="server" Width="262px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">�t�d�H
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox208" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�����Ҹ�
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox209" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">�X�ͦ~���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox210" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>���v�H
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="TextBox211" runat="server" Width="200px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�d�ʤ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox224" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�����v�Q
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox212" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ƶ�����
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox205" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab9999" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>��樮���
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox213" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox214" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">��樮���
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox235" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">��J���
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox236" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�ק���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox237" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox216" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">���q�W��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox217" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�����Ҹ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox238" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">�t�d�H
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox239" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�`���B
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox218" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>�U��
                                                    </td>
                                                    <th>�n����B
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox219" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>�U��
                                                    </td>
                                                    <th>����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox220" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>����
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox240" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�~��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox241" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�Ʈ�q
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox242" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ƶ�����
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox215" runat="server" Width="579px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab00001" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>���w���
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox221" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox222" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">���w���
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox226" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">��J���
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox227" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">�ק���
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox228" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Τ@�s��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox229" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">���q�W��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox230" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�����Ҹ�
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox231" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2"></td>
                                                    <th>�t�d�H
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox232" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�������B
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox233" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>�U��
                                                    </td>
                                                    <th>�n����B
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox234" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>�U��
                                                    </td>
                                                    <td colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <th>�������w
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox244" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>���D/�O�H
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox245" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>�h��
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox246" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>�Ƶ�����
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox247" runat="server" Width="579px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab00002" class="div_content padleft_0 T_-240">
                                            <table class="tb_Contact" style="margin-left: 10px; margin-top: 10px;" width="90%">
                                                <tr>
                                                    <th>�U���帹
                                                    </th>
                                                    <th>�U�����
                                                    </th>
                                                    <th>�U���ɶ�
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label50" runat="server">2006062170</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label51" runat="server">95/06/22</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label52" runat="server">10:49:03</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label53" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label54" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label55" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label56" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label57" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label58" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="btn_div">
                                                <asp:Button ID="Button4" runat="server" Text="���e" Enabled="false" CssClass="btn_normal" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="fraTab222" class="div_content padleft_0" style="margin-top: 62px;">
                                    <div style="width: 750px;">
                                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                                            <tr>
                                                <td></td>
                                                <td>�Ӥ�
                                                </td>
                                                <td>�O�H1
                                                </td>
                                                <td>�O�H2
                                                </td>
                                                <td>�O�H3
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>����
                                                <asp:CheckBox ID="CheckBox37" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox38" runat="server" /><asp:TextBox ID="TextBox25" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox39" runat="server" /><asp:TextBox ID="TextBox26" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox40" runat="server" /><asp:TextBox ID="TextBox27" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox41" runat="server" /><asp:TextBox ID="TextBox28" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="text-align: center;">
                                                    <asp:Button ID="Button8" CssClass="btn_normal" runat="server" Text="�d��" />
                                                    <asp:Button ID="Button7" CssClass="btn_normal" runat="server" Text="�C�L" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="fraDispTypeInfo3" class="frame_content div_Info2" style="border: none; width: 750px;">
                                            <div id="fraTab11111Caption" tabframe="fraTab11111" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 ">
                                                <label class="label_contain">
                                                    �ӤH��X�H��</label>
                                            </div>
                                            <div id="fraTab22222Caption" tabframe="fraTab22222" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_159 T_-24 ">
                                                <label class="label_contain">
                                                    �h���P�Q�d�O��</label>
                                            </div>
                                            <div id="fraTab33333Caption" tabframe="fraTab33333" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_318 T_-48 ">
                                                <label class="label_contain">
                                                    �H�Υd��T</label>
                                            </div>
                                            <div id="fraTab44444Caption" tabframe="fraTab44444" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_477 T_-72 ">
                                                <label class="label_contain">
                                                    �d��򥻸��</label>
                                            </div>
                                            <div id="fraTab55555Caption" tabframe="fraTab55555" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_636 T_-96 W_133">
                                                <label class="label_contain">
                                                    �H�Υd�ٴ�</label>
                                            </div>
                                            <div id="fraTab66666Caption" tabframe="fraTab66666" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-97">
                                                <label class="label_contain">
                                                    �U���ٴڻP�O��</label>
                                            </div>
                                            <div id="fraTab77777Caption" tabframe="fraTab77777" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-121 L_125">
                                                <label class="label_contain">
                                                    �q���ץ�</label>
                                            </div>
                                            <div id="fraTab88888Caption" tabframe="fraTab88888" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-145 L_250">
                                                <label class="label_contain">
                                                    �ɥR�`�O</label>
                                            </div>
                                            <div id="fraTab99999Caption" tabframe="fraTab99999" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-169 L_375">
                                                <label class="label_contain">
                                                    �d�߰O��</label>
                                            </div>
                                            <div id="fraTab00000Caption" tabframe="fraTab00000" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-193 L_500">
                                                <label class="label_contain">
                                                    �C�L����</label>
                                            </div>
                                            <div id="fraTab000000Caption" tabframe="fraTab000000" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-217 L_625 W_124">
                                                <label class="label_contain">
                                                    ���ӹ�n</label>
                                            </div>
                                            <div id="fraTab11111" class="div_content padleft_0 T_-216">
                                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                    <tr>
                                                        <th width="22%">�����Ҹ�/�m�W�G
                                                        </th>
                                                        <td width="35%">
                                                            <asp:TextBox ID="TextBox89" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th width="20%">�F�`���Y�H�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox90" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>�^��m�W�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox91" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>�X�ͤ���G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox93" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>���y�a�G
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox95" CssClass="txt_readonly" ReadOnly="true" Width="85%" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>��Ʀ~��G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox97" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">�«H���`�`�O/����G</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox99" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>�q�����B�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox101" CssClass="txt_readonly" ReadOnly="true" Width="80%"
                                                                runat="server"></asp:TextBox>�a��
                                                        </td>
                                                        <th>�L��O�`�k��l�B�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox102" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>�a��
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>���t�l�ʧb�`�l�B�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox103" CssClass="txt_readonly" ReadOnly="true" Width="80%"
                                                                runat="server"></asp:TextBox>�a��
                                                        </td>
                                                        <th>�q�Ű��`�k��l�B�G
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox104" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>�a��
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">�O�����B�G</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox92" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>�a��
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">�ʦ����B�G</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox94" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>�a��
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">�b�b���B�G</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox96" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>�a��
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>�h���Ωک��O���G
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox98" CssClass="txt_readonly" ReadOnly="true" Width="85%" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab22222" class="div_content T_-200">
                                                �h���������ơG<asp:Label ID="Label155" runat="server" Text="Label">1</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th width="16%">���M�v�`���B
                                                        </th>
                                                        <th width="16%">���M�v�`�i��
                                                        </th>
                                                        <th width="16%">�̫�@���h�����
                                                        </th>
                                                        <th width="16%">�w�M�v�`���B
                                                        </th>
                                                        <th width="16%">�w�M�v�`�i��
                                                        </th>
                                                        <th>�̪�@���M�v���
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td></td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                ��x��Ƶ��ơG<asp:Label ID="Label156" runat="server" Text="Label">3</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th width="12%">�d�ߤ��
                                                        </th>
                                                        <th width="16%">�d�߳��W��
                                                        </th>
                                                        <th width="12%">�d�߶��ئ�C
                                                        </th>
                                                        <th width="12%">�d�߲z�ѽX
                                                        </th>
                                                        <th width="16%">�d�߲z�Ѥ������
                                                        </th>
                                                        <th>�Ƶ�
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>���F��ڰӷ~
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>�s�~��
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>���F��ڰӷ~
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>�s�~��
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>���F��ڰӷ~
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>�s�~��
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab33333" class="div_content T_-200">
                                                �H�Υd��Ƶ��ơG<asp:Label ID="Label157" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th width="10%">�o�d���c
                                                        </th>
                                                        <th width="8%">�d�W
                                                        </th>
                                                        <th width="8%">�d�O
                                                        </th>
                                                        <th width="10%">�ҥΤ��
                                                        </th>
                                                        <th width="10%">�B�פd��
                                                        </th>
                                                        <th width="6%">��X
                                                        </th>
                                                        <th width="6%">�`��
                                                        </th>
                                                        <th width="6%">��O
                                                        </th>
                                                        <th width="6%">�D���d
                                                        </th>
                                                        <th width="10%">���Τ��
                                                        </th>
                                                        <th width="16%">���κ���/��]
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>�ɤs�Ȧ�
                                                        </td>
                                                        <td>VISA
                                                        </td>
                                                        <td>���d
                                                        </td>
                                                        <td>93/04/22
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td width="4%">N
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td>97/04/21
                                                        </td>
                                                        <td>�@�백��/�ӽ�
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>�ɤs�Ȧ�
                                                        </td>
                                                        <td>VISA
                                                        </td>
                                                        <td>���d
                                                        </td>
                                                        <td>93/04/22
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>97/04/21
                                                        </td>
                                                        <td>�@�백��/�ӽ�
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab44444" class="div_content padleft_0 T_-216">
                                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                    <tr>
                                                        <td colspan="6">�H�Υd��򥻸�T���ơG
                                                        <asp:Label ID="Label166" runat="server" Text="Label">2</asp:Label>
                                                    </tr>
                                                    <tr>
                                                        <th>���e�~��
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox264" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th>���e���c
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox265" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true">�p���Ȧ�</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th></th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox266" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th></th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox267" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true">�ɤs�Ȧ�</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>���e�~��
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox268" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th>���e���c
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox269" runat="server" CssClass="txt_readonly" ReadOnly="true">�p���Ȧ�</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th width="12%">����W��
                                                        </th>
                                                        <td width="20%">
                                                            <asp:TextBox ID="TextBox270" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th width="10%">�X�ͤ��
                                                        </th>
                                                        <td width="20%">
                                                            <asp:TextBox ID="TextBox271" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th width="12%">�Ш|�{��
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox272" runat="server" Width="126px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>���y�a�}
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox250" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>�q�T�a�}
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox251" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>�~��q��
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox273" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>���q�q��
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox274" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>��¾���c
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox252" runat="server" Width="276px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th>��¾¾��
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox253" runat="server" Width="126px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>�A�Ȧ~��
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox254" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>�~
                                                        </td>
                                                        <th>�~�~
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox255" runat="server" CssClass="txt_readonly" ReadOnly="true">200</asp:TextBox>�a��
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab55555" class="div_content T_-200">
                                                �H�Υd��ú�ڰO�����ơG
                                            <asp:Label ID="Label158" runat="server" Text="Label">8</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th>��Ʀ~��
                                                        </th>
                                                        <th>�o�d���c�N�X
                                                        </th>
                                                        <th>�o�d���c
                                                        </th>
                                                        <th>�d�W
                                                        </th>
                                                        <th>�֩w�B��
                                                        </th>
                                                        <th>��ú���B�ŶZ
                                                        </th>
                                                        <th>�w�ɲ{�����L
                                                        </th>
                                                        <th>���v���A
                                                        </th>
                                                        <th>���ת`�O
                                                        </th>
                                                        <th>ú�Ǫ��p
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>�p���Ȧ�
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>�����O
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>�p���Ȧ�
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>�����O
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>�p���Ȧ�
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>�����O
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>�p���Ȧ�
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>�����O
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>�p���Ȧ�
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>�����O
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab66666" class="div_content T_-200">
                                                �ӤH�ɴھl�B���ٴڬ������ơG
                                            <asp:Label ID="Label159" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>��Ʀ~��
                                                        </th>
                                                        <th>��w�W��
                                                        </th>
                                                        <th>�N��/���
                                                        </th>
                                                        <th>�γ~�O/����
                                                        </th>
                                                        <th>�q�����B
                                                        </th>
                                                        <th>�«H�l�B
                                                        </th>
                                                        <th>�O�����٪��B
                                                        </th>
                                                        <th>�D/�q
                                                        </th>
                                                        <th>���Y
                                                        </th>
                                                        <th colspan="12">�̪�12�Ӥ��ٴڬ���
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/11
                                                        </td>
                                                        <td>�U���ӷ~
                                                        </td>
                                                        <td>Y/�{���d
                                                        </td>
                                                        <td>4/�P���
                                                        </td>
                                                        <td>1,000
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>�D��
                                                        </td>
                                                        <td></td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/11
                                                        </td>
                                                        <td>�U���ӷ~
                                                        </td>
                                                        <td>Y/�{���d
                                                        </td>
                                                        <td>4/�P���
                                                        </td>
                                                        <td>1,000
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>�D��
                                                        </td>
                                                        <td></td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                        <td>��
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                �ӤH�O���ʦ��Χb�b��Ƶ��ơG
                                            <asp:Label ID="Label160" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>��Ʀ~��
                                                        </th>
                                                        <th>�Ȧ�/����
                                                        </th>
                                                        <th>��w�W��
                                                        </th>
                                                        <th>�N��/���
                                                        </th>
                                                        <th>�O���N��/����
                                                        </th>
                                                        <th>�O�����٪��B
                                                        </th>
                                                        <th>���v�����`�O
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>96/02
                                                        </td>
                                                        <td>812/0643
                                                        </td>
                                                        <td>�x�s��ڰӷ~�Ȧ�_������
                                                        </td>
                                                        <td>A/�ʦ��ڶ�
                                                        </td>
                                                        <td>2/�O�� 6��ܥ���
                                                        </td>
                                                        <td>21
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>96/02
                                                        </td>
                                                        <td>812/0643
                                                        </td>
                                                        <td>�x�s��ڰӷ~�Ȧ�_������
                                                        </td>
                                                        <td>A/�ʦ��ڶ�
                                                        </td>
                                                        <td>2/�O�� 6��ܥ���
                                                        </td>
                                                        <td>21
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab77777" class="div_content T_-200">
                                                �q���ץ��Ƶ��ơG
                                            <asp:Label ID="Label161" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>�q������
                                                        </th>
                                                        <th>�q�����
                                                        </th>
                                                        <th>�o�ͤ��
                                                        </th>
                                                        <th>�q�����
                                                        </th>
                                                        <th>�����W
                                                        </th>
                                                        <th>��ڸ��X
                                                        </th>
                                                        <th>����
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                �ӤH�����ҧ�ﵧ�ơG
                                            <asp:Label ID="Label162" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="70%">
                                                    <tr>
                                                        <th>��ID
                                                        </th>
                                                        <th>�sID
                                                        </th>
                                                        <th>����m�W
                                                        </th>
                                                        <th>�B�z���
                                                        </th>
                                                        <th>���N�X
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab88888" class="div_content T_-200">
                                                �ɥR�`�O/���ű��ҫH�Ϊ`�O��T���ơG
                                            <asp:Label ID="Label163" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>�T���n�����
                                                        </th>
                                                        <th>�T��
                                                        </th>
                                                        <th>�����j��
                                                        </th>
                                                        <th>�T��
                                                        </th>
                                                        <th>�����Ӷ�
                                                        </th>
                                                        <th>�T�����e
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                ���y�H�Ϊ� & �O�Ҩ��Ƶ��ơG
                                            <asp:Label ID="Label164" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>�ץ�
                                                        </th>
                                                        <th>�q�i���
                                                        </th>
                                                        <th>�o�ͤ��
                                                        </th>
                                                        <th>�q�����
                                                        </th>
                                                        <th>�����W
                                                        </th>
                                                        <th>��ڸ��X
                                                        </th>
                                                        <th>����
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                ���v������Ƶ��ơG
                                            <asp:Label ID="Label165" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>�����~��
                                                        </th>
                                                        <th>����v��w�W��
                                                        </th>
                                                        <th>�N�X/���
                                                        </th>
                                                        <th>�γ~�O/����
                                                        </th>
                                                        <th>�q�����B
                                                        </th>
                                                        <th>�«H���O��
                                                        </th>
                                                        <th>�O�����B
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab99999" class="div_content T_-200">
                                                <table class="tb_Contact" width="90%">
                                                    <tr>
                                                        <th>�U���帹
                                                        </th>
                                                        <th>�U�����
                                                        </th>
                                                        <th>�U���ɶ�
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label59" runat="server">2010010459</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label60" runat="server">99/01/04</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label61" runat="server">10:49:03</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label62" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label63" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label64" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label65" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label66" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label67" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="btn_div">
                                                    <asp:Button ID="Button6" runat="server" Text="���e" Enabled="false" CssClass="btn_normal" />
                                                </div>
                                            </div>
                                            <div id="fraTab00000" class="div_content T_-200">
                                            </div>
                                            <div id="fraTab000000" class="div_content T_-200">
                                                ����
                                            <div class="div_table">
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>����
                                                        </th>
                                                        <th>�X���s��
                                                        </th>
                                                        <th>����/�ӧ@�Ъ�
                                                        </th>
                                                        <th>�O�Ҫ�
                                                        </th>
                                                        <th>��U���B
                                                        </th>
                                                        <th>����������`�B
                                                        </th>
                                                        <th>����
                                                        </th>
                                                        <th>�wú����
                                                        </th>
                                                        <th>�X�p���B
                                                        </th>
                                                        <th>�Ƶ�
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>����
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label68" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label69" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label70" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label71" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label72" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label73" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label74" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label75" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label76" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>�p�p
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label103" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label104" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label105" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label106" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label107" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label108" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label109" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label110" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label111" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>�]�Ư���
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label112" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label113" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label114" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label115" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label116" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label117" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label118" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label119" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label120" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>�p�p
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label121" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label122" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label129" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label140" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label141" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label142" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label143" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label144" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label145" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>�X�p
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label146" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label147" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label148" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label149" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label150" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label151" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label152" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label153" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label154" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="fraTab333" class="div_content">
                                    <div style="position: relative; left: 10px; top: 70px;">
                                        <div class="div_table">
                                            <table class="tb_Contact" width="97%">
                                                <tr>
                                                    <th>����
                                                    </th>
                                                    <th>�X���s��
                                                    </th>
                                                    <th>����/�ӧ@�Ъ�
                                                    </th>
                                                    <th>�O�Ҫ�
                                                    </th>
                                                    <th>��U���B
                                                    </th>
                                                    <th>����������`�B
                                                    </th>
                                                    <th>����
                                                    </th>
                                                    <th>�wú����
                                                    </th>
                                                    <th>�X�p���B
                                                    </th>
                                                    <th>�Ƶ�
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>����
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label167" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label168" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label169" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label170" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label171" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label172" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label173" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label174" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label175" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>�p�p
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label176" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label177" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label178" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label179" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label180" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label181" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label182" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label183" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label184" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>�]�Ư���
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label185" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label186" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label187" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label188" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label189" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label190" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label191" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label192" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label193" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>�p�p
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label194" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label195" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label196" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label197" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label198" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label199" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label200" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label201" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label202" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>�X�p
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label203" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label204" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label205" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label206" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label207" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label208" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label209" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label210" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label211" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--�H�άd��End --%>
                        <%--�Юֳ��iBEGIN --%>
                        <div id="fraTab88" class="div_content T_-188" style="display: none; min-height: 780px; height: auto !important;">
                            <table width="100%">
                                <tr>
                                    <td>�ЮֽT�{
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITCNFDT_YMD" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>�ЮֽT�{�ɶ�
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITCNFDT_HS" runat="server" Width="85px" MaxLength="4"
                                            onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)" onblur="check_keyintime(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>�Ю֧���
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITFINDT_YMD" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>�Ю֧����ɶ�
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITFINDT_HS" runat="server" Width="85px" MaxLength="4"
                                            onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)" onblur="check_keyintime(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>������
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITSNDDT" runat="server" Width="85px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>�e����
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITRCVDT" runat="server" Width="85px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <%--<td>ñ���v��</td>
                    <td><asp:DropDownList ID="tab8_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList></td>--%>
                                    <!--UPD BY VICKY 20140630 �[�J�x�f�H�� -->
                                    <td>�x�f�H��
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Style="display: none">
                                        </asp:DropDownList>
                                        <asp:Label ID="tab8_labCREDITER" runat="server"></asp:Label>
                                        <asp:Label ID="tab8_labCREDITER_ID" runat="server" Style="display: none"></asp:Label>
                                    </td>
                                    <td>�x�H�Ю֫�ĳ
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_ddlCREDITSUGGEST" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <!-- UPD BY VICKY 20140630 �[�J ��U���B�v��,IRR�v��-->
                                <tr>
                                    <td>��U���B�v��
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>IRR�v��
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">��~����ĳ
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:TextBox ID="tab8_CREDITSALESDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">�H���ЮַN��
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:TextBox ID="tab8_CREDITDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <%--Modify 20140806 By SS Chris Hung. Reason: �b�x�H���i���ҵe�����A�s�W���׵n�O�϶�.--%>
                            <div>
                                <%-- �s�W���׵n�O�϶� begin--%>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" rowspan="11">�x�H���� (�мf)
                                        </th>
                                        <th style="width: 110px; nowrap;">��ĳ�B��(��)
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCREDITAMT_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="width: 120px; nowrap;">����
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCONTRACTMON_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                        </td>
                                        <th style="width: 100px; nowrap;">�i�O��(��)
                                        </th>
                                        <td style="width: 100px; nowrap;">
                                            <asp:TextBox ID="txtPERBOND_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" colspan="6">��O�~
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" width="110px">
                                            <asp:CheckBox ID="chkGRTMV_R" runat="server" Text="�ʲ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTIMV_R" runat="server" Text="���ʲ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;" width="120px">
                                            <asp:CheckBox ID="chkGRTDEPOSIT_R" runat="server" Text="�w�s���" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTBILLNOTE_R" runat="server" Text="�Ȳ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTSTOCK_R" runat="server" Text="�Ѳ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTCAR_R" runat="server" Text="����" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">
                                            <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                            ��O�~�`�l�B<br />
                                            (���A�t�i�O)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtGRTBAL_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="nowrap;" width="120px">
                                            <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                            ��O�~����<br />
                                            (�t�i�O)
                                        </th>
                                        <td>
                                            <!--20150109 ADD BY SS ADAM REASON.�W�[Ĳ�oñ�ֳƵ� -->
                                            <asp:TextBox ID="txtGRTVAL_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo2"></asp:TextBox>
                                        </td>
                                        <td>�H
                                        </td>
                                        <td>&nbsp
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">����γ~
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlFUNDSUSE_R" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                <asp:ListItem Text="������" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="�D������" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">�]�ƪ��A
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlCONDITION_R" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                                <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                                <asp:ListItem Text="�s��" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="���j��" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">�ާ@�Ҧ�
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlOPERATION_R" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">�]������
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDEVICETYPE_R" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">�����ٷs�����g
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtDEDUCTION_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ===START===-->
                                    <tr>
                                        <th style="nowrap;">��~�O
                                        </th>
                                        <td colspan="3">
                                            <%--20221207 ��~�O��U�Կ��--%>
                                            <asp:DropDownList ID="DrpNDU_TAB8" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                DataValueField="MCODE" Enabled="False">
                                                <asp:ListItem>�п��</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:TextBox ID="txtINDUID_TAB8" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB8');" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtINDUNM_TAB8" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                            <asp:Button ID="btnINDUPAGE_TAB8" runat="server" Text="�d�ߦ�~�O" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="false" />
                                        </td>
                                        <th style="nowrap;">�ץ󲣫~�O
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRODCD_TAB8" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ====END====-->
                                    <tr>
                                        <th style="nowrap;" width="110px">�ʲ����~
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtGRTITEM_R" MaxLength="500" runat="server" Width="99%" TextMode="Multiline"
                                                Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">��L����
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtOTHERCONDITION_R" MaxLength="500" runat="server" Width="99%"
                                                TextMode="Multiline" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">ñ���v��/�Ƶ�
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSIGNMEMO_R" runat="server" ReadOnly="true" Width="99%" TextMode="Multiline"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%-- �s�W���׵n�O�϶� end--%>
                            <%--20141218 ADD BY SS ADAM REASON.�C�L�x�H���i�ѧ�쭶�Ҥ� --%>
                            <br />
                            <center>
                                <asp:Button ID="btnSaveSureTab8" runat="server" Text="�x�s" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSureTab8_Click(this);"
                                    OnClick="btnSaveSureTab8_Click" Width="80" />
                                <asp:Button ID="cmdPrintReportC" runat="server" Text="�C�L�Юּx�H���i��" CssClass="btn_normal"
                                    OnClientClick="javascipt:return cmdPrintC_onClick(this);" Width="120" />
                            </center>
                        </div>
                        <%--�Юֳ��iEND --%>
                        <%--��f�|���i BEGIN --%>
                        <div id="fraTab99" class="div_content T_-188" style="display: none; min-height: 780px; height: auto !important;">
                            <table width="100%">
                                <tr>
                                    <td>�x�f�H��
                                    </td>
                                    <td colspan="5">
                                        <asp:DropDownList ID="tab9_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Style="display: none">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>��~�ݶi���
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab9_txtCNFDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>�f�d�駹����
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="tab9_txtFINDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>��U���B�v��
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>IRR�v��
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>�f�d��ĳ
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_ddlCREDITSUGGEST" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                        <asp:Label ID="tab9_labCREDITER_ID" runat="server" Style="display: none"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>�f�d�e���|��ĳ
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_ddlCREDITSUGGEST2" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                    </td>
                                    <td>��f�|�Mĳ��
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab9_txtSUGGESTDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">�f�d�e���̲רMĳ
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtFINDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">��~����ĳ
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtEVALUATE" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">�H�f�f�d�|��ĳ
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtSUGGESTDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="200px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" rowspan="11">�x�H���� (��f�|)
                                        </th>
                                        <th style="width: 110px; nowrap;">��ĳ�B��(��)
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCREDITAMT_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="width: 120px; nowrap;">����
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCONTRACTMON_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                        </td>
                                        <th style="width: 100px; nowrap;">�i�O��(��)
                                        </th>
                                        <td style="width: 100px; nowrap;">
                                            <asp:TextBox ID="txtPERBOND_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" colspan="6">��O�~
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" width="110px">
                                            <asp:CheckBox ID="chkGRTMV_TAB9" runat="server" Text="�ʲ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTIMV_TAB9" runat="server" Text="���ʲ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;" width="120px">
                                            <asp:CheckBox ID="chkGRTDEPOSIT_TAB9" runat="server" Text="�w�s���" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTBILLNOTE_TAB9" runat="server" Text="�Ȳ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTSTOCK_TAB9" runat="server" Text="�Ѳ�" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTCAR_TAB9" runat="server" Text="����" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">
                                            <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                            ��O�~�`�l�B<br />
                                            (���A�t�i�O)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtGRTBAL_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="nowrap;" width="120px">
                                            <!--20141218 ADD BY SS ADAM REASON.�W�[�t�i�O������ -->
                                            ��O�~����<br />
                                            (�t�i�O)
                                        </th>
                                        <td>
                                            <!--20150109 ADD BY SS ADAM REASON.�W�[Ĳ�oñ�ֳƵ� -->
                                            <asp:TextBox ID="txtGRTVAL_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo3"></asp:TextBox>
                                        </td>
                                        <td>�H
                                        </td>
                                        <td>&nbsp
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">����γ~
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlFUNDSUSE_TAB9" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                <asp:ListItem Text="������" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="�D������" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">�]�ƪ��A
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlCONDITION_TAB9" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                                <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                                <asp:ListItem Text="�s��" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="���j��" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">�ާ@�Ҧ�
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlOPERATION_TAB9" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">�]������
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDEVICETYPE_TAB9" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">�����ٷs�����g
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtDEDUCTION_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ===START===-->
                                    <tr>
                                        <th style="nowrap;">��~�O
                                        </th>
                                        <td colspan="3">
                                            <%--20221207��~�O��U�Կ��--%>
                                            <asp:DropDownList ID="DrpNDU_TAB9" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                DataValueField="MCODE" Enabled="False">
                                                <asp:ListItem>�п��</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:TextBox ID="txtINDUID_TAB9" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB9');" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtINDUNM_TAB9" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                            <asp:Button ID="btnINDUPAGE_TAB9" runat="server" Text="�d�ߦ�~�O" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal"  Visible="false"/>
                                        </td>
                                        <th style="nowrap;">�ץ󲣫~�O
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRODCD_TAB9" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O�A�ץ󲣫~�O ====END====-->
                                    <tr>
                                        <th style="nowrap;" width="110px">�ʲ����~
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtGRTITEM_TAB9" MaxLength="500" runat="server" Width="99%" TextMode="Multiline"
                                                Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">��L����
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtOTHERCONDITION_TAB9" MaxLength="500" runat="server" Width="99%"
                                                TextMode="Multiline" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">ñ���v��/�Ƶ�
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSIGNMEMO_TAB9" runat="server" ReadOnly="true" Width="99%" TextMode="Multiline"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <center>
                                <asp:Button ID="btnSaveSureTab9" runat="server" Text="�x�s" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSureTab9_Click(this);"
                                    OnClick="btnSaveSureTab9_Click" Width="80" />
                                <asp:Button ID="btnPrintExamine" runat="server" Text="�C�L�f�d�|���i" CssClass="btn_normal" OnClick="btnPrintExamine_Click" Width="120" />
                            </center>
                            <asp:HiddenField ID="hdTAB9FILEPATH1" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH2" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH3" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH4" runat="server" Value="" />
                        </div>

                        <%--��f�|���i END --%>
                    </div>
                    <%--20120221 UPD BY SSF MAUREEN REASON:�ק���s--%>
                    <div class="btn_div">
                        <asp:Button ID="btnSaveSure" runat="server" Text="�T�{" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSure_Click(this);"
                            OnClick="btnSaveSure_Click" Width="80" />
                        <%--20141218 ADD BY SS ADAM REASON.�C�L�x�H���i�ѧ�쭶�Ҥ�
                    <asp:Button ID="cmdPrintReportB" runat="server" Text="�C�L�x�H���i��" CssClass="btn_normal"
                        OnClientClick="javascipt:return cmdPrintB_onClick(this);" Width="120" /> --%>&nbsp;&nbsp;
                    <%--<asp:Button ID="btnSaveTemp" runat="server" Text="�Ȧs" CssClass="btn_normal" OnClick="btnSaveTemp_Click" Width="80"/>
          <asp:Button ID="btnSubmit" runat="server" Text="�x�H�֭�" CssClass="btn_normal" OnClientClick="javascipt:return btnSubmit_Click(this);"
            OnClick="btnSubmit_Click" Width="80"/>--%>
                        <%--<asp:Button ID="btnSelect" runat="server" Text="������" CssClass="btn_normal" OnClick="btnSelect_Click" Width="80"/>
          <asp:Button ID="btnWj" runat="server" Text="�x�H����" CssClass="btn_normal" 
            OnClick="btnWj_Click" Width="80"/>&nbsp;&nbsp;--%>
                        <%--<asp:Button ID="btnRegect" runat="server" Text="�x�H�h��" CssClass="btn_normal" OnClientClick="javascipt:return btnRegect_Click(this);"
            OnClick="btnRegect_Click" Width="80"/>--%>
                        <!--Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.-->
                        <asp:Button ID="btnReturnChk" runat="server" Text="�ץ�h�^" CssClass="btn_normal" OnClick="btnReturnChk_Click" />
                        <asp:Button ID="btnReturn" Style="display: none" runat="server" Text="�ץ�h�^" CssClass="btn_normal"
                            OnClick="btnReturn_Click" />
                        <asp:Button ID="btnAuditNote" runat="server" Text="�ץ�߱o" CssClass="btn_normal" OnClientClick="if (openML2001C()) return false;" />
                        <asp:HiddenField ID="hidCond" runat="server" Value="" />
                        <asp:Button ID="btnCond" Style="display: none" runat="server" Text="" OnClick="btnCond_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
