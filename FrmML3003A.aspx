<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3003  																					
* �{���\��  : ���ڮ֭�(�H��)																			
* �{���@�� 	: 																			
* �����ɶ� 	: 
* �ק�ƶ� 	: 
Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~.
Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v
Modify 20120529 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v
Modify 20120601 By SS Gordon. Reason: ���ڰh�^�אּ���ںM��.
Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.
Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q
Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�
Modify 20120614 By SS Gordon. Reason: �[�J�u�����v
Modify 20120717 By SS Gordon. Reason: �s�W�ӧ@�覡.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.
Modify 20121122 By SS Maureen. Reason: �s�W���Y�H�ˮ֫��s.
Modify 20121210 By SS Steven. Reason: �u���Y�H�ˮ֡v���s�令�u���Y�H�ˮ֦C�L�v�A�åB�����C�L�X��.
Modify 20130117 BY    SEAN.   Reason: ��ץ󤺮e��ñ�N�u�ץ󻡩��v��쪺����W���ܧ󬰡u�Ƶ��v
Modify 20131114 BY SS Leo Reason:�W�[��O�������
Modify 20140127 BY    SEAN.   Reason: �N���ڱ����O�������V�U��
Modify 20141205 By SS Gordon. Reason: �s�WNPV2�PNPV�Q�v����2
Modify 20150204 By SS Vicky   Reason: ���îץ󤺮e���Ҥ��A�k�誺[�I�ڮɶ�]��[�ӧ@�u��IRR]
Modify 20150204 By SS Vicky   Reason: �ӧ@���e�����Ҥ��A�̬O�_��AR����ܤ��P���e
Modify 20150205 By SS Vicky   Reason: �ץ󤺮e,����[��ĳ�Ԯ���],�W�[[��ĳ�Դڮ�]
20160323 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O��ܡA��~�O���
20161125 ADD BY SS ADAM REASON.�W�[�w���R�P
20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����
20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%)
--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML3003A.aspx.cs" inherits="FrmML3003A" %>

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

    <script type="text/javascript" language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>

    <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3003A.js' -->                   
    </script>

</head>
<body onload="window_onload()">
    <form id="form1" runat="server">
        <div id="divBody" class="divBody">
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
            <table class="divStatus" width="60%">
                <tr>
                    <th>�X���s��
                    </th>
                    <td>
                        <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true">
                        </asp:TextBox>
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value="" />
                        <asp:HiddenField ID="HidEMPLID" runat="server" Value="" />
                        <asp:HiddenField ID="HidDEPTID" runat="server" Value="" />
                    </td>
                    <th>�ץ�s��
                    </th>
                    <td>
                        <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true">
                        </asp:TextBox>
                    </td>
                    <!--th>
          �ץ�֭��
        </th-->
                    <td>
                        <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                            ReadOnly="true" Style="display: none">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
            <div id="fraDispTypeInfo" class="frame_content div_Info H_1100">
                <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu">
                    <label class="label_contain">
                        �Ȥ���</label>
                </div>
                <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-24 L_125">
                    <label class="label_contain">
                        �ץ󤺮e</label>
                </div>
                <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-48 L_250">
                    <label class="label_contain">
                        �ӧ@���e</label>
                </div>
                <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-72 L_375">
                    <label class="label_contain">
                        �Ъ���</label>
                </div>
                <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-96 L_500">
                    <label class="label_contain">
                        ��O����</label>
                </div>
                <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu W_124 T_-120 L_625">
                    <label class="label_contain">
                        ���ڸ��</label>
                </div>
                <%--�Ȥ���Begin --%>
                <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: none">
                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                        <tr>
                            <th width="15%">�Ȥ�νs
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="85px">
                                </asp:TextBox>
                            </td>
                            <th width="15%">�Ȥ�W��
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="230px">
                                </asp:TextBox>
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
                                    ReadOnly="true" Width="112px">
                                </asp:TextBox>
                            </td>
                            <th>�ꦬ�ꥻ�B
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Width="112px">
                                </asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�]�ߤ��
                                <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    Width="81px" ReadOnly="true">
                                </asp:TextBox>
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
                                    Width="112px">
                                </asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;���ι�ڭt�d�H
                                <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                    ReadOnly="true">
                                </asp:TextBox>
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
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;�W���d
                                <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false" Width="85px">
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
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>���q�n�O�a�}
                            </th>
                            <td colspan="2">
                                <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                                <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>���q�n�O�q��
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th>�ǯu
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtCUSTFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>��~�n�O�a�}
                            </th>
                            <td colspan="2">
                                <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>��~�n�O�q��
                            </th>
                            <td>
                                <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th>�ǯu
                            </th>
                            <td>
                                <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�D�n��~����
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="81%">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>��~�O
                            </th>
                            <td colspan='3'>
                                <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O ===START===-->
                                <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px"></asp:TextBox>
                                <asp:Button ID="btnINDUPAGE" runat="server" Text="�d�ߦ�~�O" CssClass="btn_normal" Enabled="false" />
                                <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O ====END====-->
                                <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false" Width="100%" style="display: none;">
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" ReadOnly="true" CssClass="txt_table"
                                                            Text='<%# Eval("INVZIPCODE")%>'>
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" ReadOnly="true" CssClass="txt_table"
                                                            Text='<%# Eval("INVZIPCODES")%>'>
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="txtINVOICEADDR" runat="server" ReadOnly="true" CssClass="txt_table"
                                                            Width="150px" Text='<%# Eval("INVOICEADDR")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--�Ȥ���End --%>
                <%--�ץ󤺮eBegin --%>
                <div id="fraTab22" class="div_content padleft_0 T_-120" style="display: none">
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
                            <th width="12%">���q�W��
                            </th>
                            <td width="12%">
                                <asp:DropDownList ID="drpCOMPID" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false">
                                    <asp:ListItem>�M��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <%--Modify 20120717 By SS Gordon. Reason: �s�W�ӧ@�覡.--%>
                            <th width="12%">�ӧ@�覡
                            </th>
                            <td width="12%">
                                <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <th width="12%">�ӧ@���A
                            </th>
                            <td width="12%">
                                <asp:DropDownList ID="drpMAINTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem>��~������</asp:ListItem>
                                    <asp:ListItem>�ꥻ������</asp:ListItem>
                                    <asp:ListItem>������R��</asp:ListItem>
                                    <asp:ListItem>�����b�ڨ���</asp:ListItem>
                                    <asp:ListItem>�����I��(�L��)</asp:ListItem>
                                    <asp:ListItem>�����I��(����)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="12%">
                                <asp:DropDownList ID="drpSUBTYPE" DataTextField="DNAME1" DataValueField="DCODE" runat="server"
                                    Enabled="false">
                                    <asp:ListItem>��~������</asp:ListItem>
                                    <asp:ListItem>�ꥻ������</asp:ListItem>
                                    <asp:ListItem>������R��</asp:ListItem>
                                    <asp:ListItem>�����b�ڨ���</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <th width="12%">����κA
                            </th>
                            <td>
                                <asp:DropDownList ID="drpTRANSTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem>���</asp:ListItem>
                                    <asp:ListItem>�T��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>�ʥα���
                            </th>
                            <td>
                                <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem>�浧�ʥ�</asp:ListItem>
                                    <asp:ListItem>�h���ʥ�</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem>�`��</asp:ListItem>
                                    <asp:ListItem>���`��</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <th>�N�L��
                            </th>
                            <td>
                                <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem Value="">�п��</asp:ListItem>
                                    <asp:ListItem Value="Y">�O</asp:ListItem>
                                    <asp:ListItem Value="N">�_</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.--%>
                            <th>�Ȧ�O
                            </th>
                            <td colspan="3">
                                <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>�ץ�ӷ�
                            </th>
                            <td colspan="2">
                                <asp:DropDownList ID="drpCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false">
                                    <asp:ListItem>����CR</asp:ListItem>
                                    <asp:ListItem>�]��CR</asp:ListItem>
                                    <asp:ListItem>�����Ӥ���</asp:ListItem>
                                    <asp:ListItem>�Ȥ�ӹq</asp:ListItem>
                                    <asp:ListItem>�P�~����</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <th>���l���v
                            </th>
                            <td colspan="5">
                                <asp:DropDownList ID="drpRECOURSE" runat="server">
                                    <asp:ListItem Value="">�п��</asp:ListItem>
                                    <asp:ListItem Value="Y">�O</asp:ListItem>
                                    <asp:ListItem Value="N">�_</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O START-->
                            <th>�ץ󲣫~�O
                            </th>
                            <td colspan="8">
                                <asp:DropDownList ID="drpPRODCD" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O END-->
                        </tr>
                    </table>
                    <div>
                        <div class="left_div">
                            <table class="tb_Info" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td colspan="6">
                                        <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />
                                        �����B����ץ�
                                    </td>
                                </tr>
                                <tr>
                                    <th width="20%">�Ъ������B
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%"></th>
                                    <td width="12%"></td>
                                    <th width="24%">�O�I�O
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtINSURANCE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�Y����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCOMMISSION" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: �ק�u�@�~�O�Ρv���u�@�~�O��(���o��)�v-->
                                    <th>�@�~�O��(���o��)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOTHERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���ʫO�Ҫ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th></th>
                                    <td></td>
                                    <!--Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v-->
                                    <th>�@�~�O��(�L�o��)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�i���O�Ҫ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>��U���B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtACTUSLLOANS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>����O���J
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
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
                                            ReadOnly="true">
                                        </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td width="18%">���I��(�t�|)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>��
                                                    <asp:TextBox ID="txtSTARTPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>���I��(�t�|)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>��
                                                    <asp:TextBox ID="txtSTARTPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>���I��(�t�|)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>��
                                                    <asp:TextBox ID="txtSTARTPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>���I��(�t�|)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
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
                                        <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" />
                                        �����b�ڮץ�
                                    </td>
                                </tr>
                                <tr>
                                    <th>�ӽ��B��
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�x�H�O
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�b�Ⱥ޲z�O
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�]���U�ݶO
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <!--Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�-->
                                <tr>
                                    <th>�i���O�Ҫ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        %
                                    </td>
                                </tr>
                                <tr>
                                    <th>�b�ڴ���
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        ��
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <%--UPD BY VICKY 20150204 ���åI�ڮɶ�--%>
                                    <th>�I�ڮɶ�
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                            Enabled="false" runat="server" Width="80%">
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
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <%--UPD BY VICKY 20150204 �ӧ@�u��IRR--%>
                                    <th>�ӧ@�u��IRR
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <%--UPD BY VICKY 20150205 ��ĳ�Դڮ�--%>
                                    <th>��ĳ�Դڮ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        %
                                    </td>
                            </table>
                        </div>
                    </div>
                    <div style="clear: both;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th>�I�ڤ覡
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>�״�</asp:ListItem>
                                        <asp:ListItem>�䲼</asp:ListItem>
                                        <asp:ListItem>�M��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th>��w�M��
                                </th>
                                <td colspan="2">
                                    <asp:DropDownList ID="drpPROJECT" DataTextField="PRONAME" DataValueField="PROJID" runat="server" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnPROJECT" runat="server" CssClass="btn_normal" Text="�j�M" OnClick="btnPROJECT_Click" style="display: none" />
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
                                    <asp:DropDownList ID="drpEXPIREPROC" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>�H�ݭȽ椩������(�Ȥ�ĤT��)</asp:ListItem>
                                        <asp:ListItem>���`���</asp:ListItem>
                                        <asp:ListItem>��L</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <!--Modify 20120529 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v-->
                                <!--Modify 20130117 By    SEAN.   Reason: ��ץ󤺮e��ñ�N�u�ץ󻡩��v��쪺����W���ܧ󬰡u�Ƶ��v-->
                                <th>�Ƶ�
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="98%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                            <%--20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%) --%>
                            <tr>
                                <th>IRR
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIRR" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                <th>NPV����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                            <tr style="display: none;">
                                <th>IRR
                                </th>
                                <td></td>
                                <th>�]�ƥ�NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                <th>�]�ƥ�NPV����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                            <tr style="display: none;">
                                <th>�������
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCAPITALCOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                        7</asp:TextBox>
                                </td>
                                <th>�ĸ��NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>�ĸ��NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="display: none;">RECOVER TEST
                                </th>
                                <td colspan="5" style="display: none;">
                                    <asp:TextBox custprop="100" ID="txtRECOVERTEST" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="text-align: center; height: 30px;">
                                    <asp:Button ID="Button3" runat="server" Enabled="false" CssClass="btn_normal" Text="�պ�" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--�ץ󤺮eEnd --%>
                <%--�ӧ@���eBegin --%>
                <div id="fraTab33" class="div_content" style="display: none">
                    <div style="width: 97%; border: 1px solid #9FA1AD;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="14%">�ӧ@���A
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtRMAINTYPE" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">������A
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRTRANSTYPE" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>�ʥα���
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRUSESTATUS" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                                <th>�ץ�ӷ�
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpRCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>����CR</asp:ListItem>
                                        <asp:ListItem>�]��CR</asp:ListItem>
                                        <asp:ListItem>�����Ӥ���</asp:ListItem>
                                        <asp:ListItem>�Ȥ�ӹq</asp:ListItem>
                                        <asp:ListItem>�P�~����</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divMainTypeA" runat="server">
                        <%--UPD BY VICKY 20150204 �DAR�󪺩ӧ@���e--%>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="14%">����/�o�����B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRTRANSCOST" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>����O���J
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRFEE" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: �ק�u�@�~�O�Ρv���u�@�~�O��(���o��)�v-->
                                    <th>�@�~�O��(���o��)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtROTHERFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th width="14%">�Y����
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRFIRSTPAY" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th width="12%">�O�I��
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRINSURANCE" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v-->
                                    <th width="16%">�@�~�O��(�L�o��)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtROTHERFEESNOTAX" custprop="100" CssClass="txt_readonly_right"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�i���O�Ҫ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <th>���ʫO�Ҫ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <th>�x�H�O
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCREDITFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>��U���B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRACTUSLLOANS" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>�ݭ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRRESIDUALS" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>�b�Ⱥ޲z�O
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRMANAGERFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th></th>
                                    <td></td>
                                    <!--Modify 20120614 By SS Gordon. Reason: �[�J�u�����v-->
                                    <th>����
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCOMMISSION" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>�]���U�ݶO
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRFINANCIALFEES" custprop="100" CssClass="txt_readonly_right"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkRDEPOSITLOANS2" runat="server" Checked="true" onclick="chkRDEP2_click(this);" />
                                        �L�s�ɴ�
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkRDEPOSITLOANS1" runat="server" onclick="chkRDEP1_click(this);" />
                                        �ɴڵ�������
                                        <asp:CheckBox ID="chkRDEPOSITLOANS0" runat="server" onclick="chkRDEP0_click(this);" />
                                        �s�ڦb�����q
                                    </td>
                                    <td colspan="2">�s�ɴ�<asp:TextBox ID="txtRDEPOSITLOANSAMOUNT" Text="0" onkeypress="OnlyNum(this);"
                                        custprop="100" MaxLength="9" onfocus="MoneyFocus(this)" onblur="OnlyNumBlur(this);MoneyBlur(this);"
                                        CssClass="txt_normal_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">������
                                        <asp:TextBox ID="txtDSUPPLIER" runat="server" MaxLength="10" Width="80px" onkeypress="OnlyNumDUCase(this);"
                                            onblur="DSUPPLIERID_onblur(this);" CssClass="txt_normal">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtDSUPPLIERNM" runat="server" CssClass="txt_normal" Width="160px"></asp:TextBox>
                                        �����ӷ~�NID
                                        <asp:TextBox ID="txtSUPPLIERSALE" runat="server" MaxLength="10" Width="80px" onkeypress="OnlyNumDUCase(this);"
                                            onblur="idBlur(this);" CssClass="txt_normal">
                                        </asp:TextBox>
                                        �����ӷ~�N�m�W
                                        <asp:TextBox ID="txtSUPPLIERSALENM" runat="server" CssClass="txt_normal" Width="81px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th>�ӧ@���
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCONTRACTMONTH" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>�X��@�I
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPAYMONTH" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>�I�ڮɶ�
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpRPAYTIME" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Width="80px">
                                            <asp:ListItem>����I</asp:ListItem>
                                            <asp:ListItem>�����I</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="12%">�� &nbsp; 1 &nbsp; ��
                                    </td>
                                    <td width="13%">- ��<asp:TextBox ID="txtRENDPAY1" runat="server" CssClass="txt_readonly_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td width="13%">���I��(���|)
                                    </td>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRPRINCIPAL1" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <td width="13%">���I��(�t�|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX1" runat="server" custprop="100" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>��
                                        <asp:TextBox ID="txtRSTARTPAY2" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>- ��<asp:TextBox ID="txtRENDPAY2" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>���I��(���|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL2" custprop="100" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>���I��(�t�|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX2" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>��
                                        <asp:TextBox ID="txtRSTARTPAY3" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>- ��<asp:TextBox ID="txtRENDPAY3" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>���I��(���|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL3" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>���I��(�t�|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX3" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>��
                                        <asp:TextBox ID="txtRSTARTPAY4" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>- ��<asp:TextBox ID="txtRENDPAY4" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        ��
                                    </td>
                                    <td>���I��(���|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL4" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>���I��(�t�|)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX4" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="14%">�Ȥ�I�ڤ覡
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpRCUSTPAYTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
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
                                        <asp:TextBox ID="txtRPATDAYS" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�I�����ӤѼ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRSUPPILERDAYS" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="divMainTypeB" runat="server" style="display: none;">
                        <%--UPD BY VICKY 20150204 AR�󪺩ӧ@���e--%>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="15%">�`�������B
                                    </th>
                                    <td width="18%">
                                        <asp:TextBox ID="txtINVOICEAMOUNT_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%">�x�H�O���J
                                    </th>
                                    <td width="18%">
                                        <asp:TextBox ID="txtCREDITFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%">
                                        <%-- 20150319 ADD BY SS ADAM REASON.���éӧ@���e���w�p���ڤ� --%>
                                        <%--�w�p���ڤ�--%>
                                        <%-- 20150326 ADD BY SS ADAM REASON.�W�[���ڪ��B --%>
                                        ���ڪ��B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPAYDATE_AR" custprop="010" CssClass="txt_readonly_right" runat="server"
                                            ReadOnly="true" Visible="false">
                                        </asp:TextBox>
                                        <%-- 20150326 ADD BY SS ADAM REASON.�W�[���ڪ��B --%>
                                        <asp:TextBox ID="txtPAYAMT_AR" runat="server" CssClass="txt_readonly_right" Readonly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�Դڮ�
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtADVANCESINTEREST_AR" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>�b�Ⱥ޲z���J
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMANAGERFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>���ڦ���
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpADVANCESPERCENT_AR" runat="server" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="false">
                                        </asp:DropDownList>
                                        %
                                    </td>
                                    <th>�]���U�ݦ��J
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtFINANCIALFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div class="div_title">AR���� &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                        <div class="div_table" style="overflow-x: scroll; height: 200px">
                            <table id="tblMLDCONTRACTARD" class="tb_Contact" style="width: 1600px;">
                                <tr>
                                    <th>����
                                    </th>
                                    <th>�Φ�
                                    </th>
                                    <th>�o���H
                                    </th>
                                    <th>�I�ڦ�w
                                    </th>
                                    <th>�b��
                                    </th>
                                    <th>���ڸ��X
                                    </th>
                                    <th>�R���H
                                    </th>
                                    <th>���ڨ����
                                    </th>
                                    <th>�ԴڤѼ�
                                    </th>
                                    <th>�����������B
                                    </th>
                                    <th>�Դڦ���
                                    </th>
                                    <th>�Դڪ��B
                                    </th>
                                    <th>�����Դڮ�
                                    </th>
                                    <th>���ڪ��B
                                    </th>
                                    <th>�Ӥ�I��
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCONTRACTARD" runat="server">
                                    <itemtemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpPAYTYPE_AR" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    Enabled="false">
                                                    <asp:ListItem>�䲼</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hidMLDCONTRACTARDID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDRAWER_AR" Text='<%# Eval("DRAWER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="120px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITBANK_AR" Text='<%# Eval("DEPOSITBANK")%>' runat="server"
                                                    CssClass="txt_readonly" ReadOnly="true" Width="240px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtACCOUNT_AR" Text='<%# Eval("ACCOUNT")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="150px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNO_AR" Text='<%# Eval("BILLNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="150px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBUYER_AR" Text='<%# Eval("BUYER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="120px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLEXPIRYDT_AR" Text='<%# Eval("BILLEXPIRYDT")%>' runat="server"
                                                    ReadOnly="true" CssClass="txt_readonly" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESDAYS_AR" runat="server" Text='<%# Eval("ADVANCESDAYS")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLAMT_AR" Text='<%# Eval("BILLAMT")%>' runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESPERCENT_AR" runat="server" Text='<%# Eval("ADVANCESPERCENT")%>'></asp:Label>
                                                <asp:TextBox ID="txtADVANCESPERCENT_AR" runat="server" Text='<%# Eval("ADVANCESPERCENT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESAMT_AR" runat="server" Text='<%# Eval("ADVANCESAMT")%>'></asp:Label>
                                                <asp:TextBox ID="txtADVANCESAMT_AR" runat="server" Text='<%# Eval("ADVANCESAMT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labFINANCIALFEES_AR" runat="server" Text='<%# Eval("FINANCIALFEES")%>'></asp:Label>
                                                <asp:TextBox ID="txtFINANCIALFEES_AR" runat="server" Text='<%# Eval("FINANCIALFEES")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labFINALPAYAMT_AR" runat="server" Text='<%# Eval("FINALPAYAMT")%>'></asp:Label>
                                                <asp:TextBox ID="txtFINALPAYAMT_AR" runat="server" Text='<%# Eval("FINALPAYAMT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkENDORSEMENTFLG" runat="server" Enabled="false" />
                                                <asp:HiddenField ID="hidENDORSEMENTFLG" Value='<%# Eval("ENDORSEMENTFLG") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <br />
                        <div class="div_title">�R���o������ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                        <div class="div_table" style="height: 200px">
                            <table id="tblMLDCONTRACTARBINV" class="tb_Contact" style="width: 600px;">
                                <tr>
                                    <th>����
                                    </th>
                                    <th>�R���H
                                    </th>
                                    <th>�νs
                                    </th>
                                    <th>�o�����X
                                    </th>
                                    <th>�o�����
                                    </th>
                                    <th>�o�����B
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCONTRACTARBINV" runat="server">
                                    <itemtemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBUYER_INV" Text='<%# Eval("BUYER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hidMLDCONTRACTARBINVID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUNIMNO_INV" Text='<%# Eval("UNIMNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVNO_INV" Text='<%# Eval("INVNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px" onkeypress="OnlyNumDUCase(this);">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVDT_INV" Text='<%# Eval("INVDT")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVAMT_INV" Text='<%# Eval("INVAMT")%>' runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="14%">�������J
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtRINCOME" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">���즨��
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtROPENINGCOST" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">�b�l�q
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNETLOSS" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                            <%--20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%) --%>
                            <tr>
                                <th>�u��IRR
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRIRR" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>NPV����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST" runat="server" Text="0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                    %
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <th>�u��IRR
                                </th>
                                <td></td>
                                <th>�]�ƥ�NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV0" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                <th>�]�ƥ�NPV����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST0" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                            <tr style="display: none;">
                                <th>�������
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRCAPITALCOST" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                        Text="7%">
                                    </asp:TextBox>
                                </td>
                                <%--Modify 20141205 By SS Gordon. Reason: �s�WNPV2�PNPV�Q�v����2--%>
                                <th>�ĸ��NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV2" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>�ĸ��NPV����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST2" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <th style="display: none;">RECOVER TEST
                                </th>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtRRECOVERTEST" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <%--UPD BY VICKY 20150204 ���øպ���s--%>
                                <td colspan="6" style="text-align: center; height: 30px;">
                                    <asp:Button ID="btnIRR_Click" runat="server" CssClass="btn_normal" Enabled="false"
                                        Text="�պ�" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--�ӧ@���eEnd --%>
                <%--�Ъ���Begin --%>
                <div id="fraTab44" class="div_content" style="display: none">
                    <%--<asp:Button ID="Button311" runat="server" CssClass="btn_normal" Text="�Ъ����ƻs" />
		  	<asp:Button ID="Button3211" runat="server" CssClass="btn_normal" Text="�Ъ����פJ" />--%>
                    <div class="div_table" style="overflow-x: scroll; height: 200px">
                        <table class="tb_Contact" style="width: 1400px;">
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpTARGETTYPE" Enabled="false" onchange="drpTARGETTYPE_change(this);"
                                                DataTextField="MNAME1" DataValueField="MCODE" class="bg_normal" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                                        </td>
                                        <td width="15%">
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
                                            <asp:Label ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' Width="320px" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtTARGETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>'
                                                onblur="txtTARGETPRICE_onblur(this);" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <asp:CheckBox ID="chkAr1" runat="server" Enabled="false" Checked="true" />
                    AR�ץ�L�Ъ���&nbsp;&nbsp;&nbsp;
                    <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.--%>
                    <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" />
                    �Ȧ�ץ�L�Ъ���
                    <br />
                    <br />
                    �]�Ʀs��a<br />
                    <div class="div_table" style="overflow-x: scroll; height: 200px">
                        <table class="tb_Contact" style="width: 1200px;">
                            <tr>
                                <th>����
                                </th>
                                <th>�s��a
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td width="350px">
                                            <asp:TextBox ID="txtSTOREDZIPCODE" runat="server" Width="24px" CssClass="txt_table"
                                                Text='<%# Eval("STOREDZIPCODE")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtSTOREDZIPCODES" runat="server" Width="120px" CssClass="txt_table"
                                                Text='<%# Eval("STOREDZIPCODES")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtSTOREDADDR" runat="server" CssClass="txt_table" Width="150px"
                                                Text='<%# Eval("STOREDADDR")%>'>
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
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
                                            <asp:Label ID="txtCONTACTFAXCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>' />
                                            <asp:Label ID="txtCONTACTFAX" Text='<%# Eval("CONTACTFAX")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtCONTACTEMAIL" Text='<%# Eval("CONTACTEMAIL")%>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <asp:CheckBox ID="chkAr2" runat="server" Enabled="false" Checked="true" />
                    AR�ץ�L�Ъ����s��a<br />
                    <br />
                    <div class="div_title" style="margin-left: -10px;">
                        AR�ץ�o���[�I�ѤH
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="10%">�o���H
                            </th>
                            <td>
                                <asp:TextBox ID="txtBILLNOTECUSTID" CssClass="txt_normal" Width="120px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtBILLNOTECUST" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�Ȧ�/����
                            </th>
                            <td>
                                <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" Width="427px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtDEPOSITBANK" Style="display: none" Width="427px" runat="server"></asp:TextBox>
                                <%--<asp:TextBox ID="TextBox106" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>�b��
                            </th>
                            <td>
                                <asp:TextBox ID="txtACCOUNT" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�I�ѤH
                            </th>
                            <td>
                                <asp:TextBox ID="txtENDORSERID" CssClass="txt_normal" Width="120px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtENDORSER" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--�Ъ���End --%>
                <%--��O����Begin --%>
                <div id="fraTab55" class="div_content T_-130" style="display: none">
                    <br />
                    <%--20131114 LEO �s�W��O����--%>
                    <%--20131205 �i���O���ȭn�]��������@�A�s�ɥu�ˮּ��ڱ��󪺾�O����--%>
                    �i������O����
                    <asp:DropDownList ID="drpGuanValue" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <%--20140127 EDIT BY SEAN �N���ڱ����O�������V�U��--%>
                    <%--        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                ���ڱ����O����
            <asp:DropDownList ID="drpGuanValue2" runat="server">
                </asp:DropDownList>		--%>
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
                                <th>
                                    <%--20230523�������B��O�H��O���B--%>
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
                                <%--Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                <th>¾�~
                                </th>
                                <th>��¾���q
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="drpGRTTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                class="bg_F5F8BE" runat="server" Width="80%">
                                                <asp:ListItem>�k�H</asp:ListItem>
                                                <asp:ListItem>�ӤH</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' runat="server" CssClass="txt_table"
                                                Width="80" ReadOnly="true">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                Width="80" ReadOnly="true">
                                            </asp:TextBox>
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
                                                ReadOnly="true" runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <%--Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                                        <td>
                                            <asp:TextBox ID="txtGRTBIRDT" Enabled="false" Text='<%# Eval("GRTBIRDT") %>' runat="server"
                                                Width="80px" CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);">
                                            </asp:TextBox>
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
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <input type="button" id="btnGRTRESIDENTZIP" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                            <asp:TextBox ID="txtGRTRESIDENTZIPNM" Enabled="false" Text='<%# Eval("GRTRESIDENTZIPNM") %>'
                                                runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTRESIDENTADDR" Enabled="false" Text='<%# Eval("GRTRESIDENTADDR") %>'
                                                runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');"
                                                MaxLength="100">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTZIP" Enabled="false" Text='<%# Eval("GRTZIP") %>' runat="server"
                                                Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <input type="button" id="btnGRTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);"
                                                onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                            <asp:TextBox ID="txtGRTZIPNM" Enabled="false" Text='<%# Eval("GRTZIPNM") %>' runat="server"
                                                Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTADDR" Enabled="false" Text='<%# Eval("GRTADDR") %>' runat="server"
                                                Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');"
                                                MaxLength="100">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTTELCODE" Enabled="false" Text='<%# Eval("GRTTELCODE") %>'
                                                runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);"
                                                onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTTEL" Enabled="false" Text='<%# Eval("GRTTEL") %>' runat="server"
                                                Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTTELEXT" Enabled="false" Text='<%# Eval("GRTTELEXT") %>' runat="server"
                                                Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
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
                                        <%--Modify 20120223 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                        <td>
                                            <asp:DropDownList ID="drpGRTJOB" Enabled="false" runat="server" Width="220px" DataTextField="DNAME1"
                                                DataValueField="DCODE">
                                                <asp:ListItem Value="">�D��v</asp:ListItem>
                                                <asp:ListItem Value="01">��v</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTCOMPANY" Enabled="false" Text='<%# Eval("GRTCOMPANY") %>'
                                                runat="server" Width="200px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENAME" ReadOnly="true" Text='<%# Eval("MOVABLENAME")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                <asp:ListItem Value="1">�O</asp:ListItem>
                                                <asp:ListItem Value="2">�_</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                Text='<%# Eval("MOVABLEZIPCODE")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtMOVABLEZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtMOVABLEADDR" ReadOnly="true" runat="server" CssClass="txt_table"
                                                Width="150px" Text='<%# Eval("MOVABLEADDR")%>'>
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENO" ReadOnly="true" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEYEAR" ReadOnly="true" Text='<%# Eval("MOVABLEYEAR")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEBUYDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENEWAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEBUYAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLERESIDUALS" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLERESETPRICE" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                                <th>�g�a���n
                                </th>
                                <th>�������n
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEOWNER" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEOWNERID" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEGETDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLESECTOR" ReadOnly="true" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILD" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEHOLDER" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDNO" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                onblur="areacon(this)" runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIMMOVABLEBUILDAREA" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHUMANRIGHTS" ReadOnly="true" Text='<%# Eval("HUMANRIGHTS") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtREGISTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSETPRICE" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                            runat="server" CssClass="txt_table_right">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCREDITOR" ReadOnly="true" Text='<%# Eval("CREDITOR") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("DEPOSITBANKS") %>'
                                            Width="120px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITNBR" ReadOnly="true" Text='<%# Eval("DEPOSITNBR") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITAMT" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                            runat="server" CssClass="txt_table_right">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITSTARTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITDUEDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table" Width="80px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("BILLNOTEBANKS") %>'
                                            Width="100px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                            <asp:ListItem Value="1">����</asp:ListItem>
                                            <asp:ListItem Value="2">�䲼</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTENBR" ReadOnly="true" Text='<%# Eval("BILLNOTENBR") %>'
                                            runat="server" CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtACCOUNT" ReadOnly="true" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                            CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTECUSTNAME" ReadOnly="true" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                            runat="server" CssClass="txt_table" Width="80px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                            runat="server" CssClass="txt_table_right" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTENOTE" ReadOnly="true" Text='<%# Eval("BILLNOTENOTE") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEBACKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table" Width="72px">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKNAME" ReadOnly="true" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKPROVIDER" ReadOnly="true" Text='<%# Eval("STOCKPROVIDER") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKUNIT" ReadOnly="true" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" ReadOnly="true" Text='<%# Eval("STOCKQUANTITY") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" ReadOnly="true" Text='<%# Eval("STOCKTOTAL") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKBEGIN" ReadOnly="true" Text='<%# Eval("STOCKBEGIN") %>'
                                            runat="server" CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKEND" ReadOnly="true" Text='<%# Eval("STOCKEND") %>' runat="server"
                                            CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                            <asp:ListItem Value="1">���O</asp:ListItem>
                                            <asp:ListItem Value="2">����</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKNOTE" ReadOnly="true" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
                        </asp:Repeater>
                    </table>
                    <br />
                    ��L<br />
                    <asp:TextBox ID="txtOTHERCOND" ReadOnly="true" runat="server" CssClass="txt_normal"
                        Width="80%">
                    </asp:TextBox>
                    <%--20140127 EDIT BY SEAN �N���ڱ����O�������V�U��--%>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    ���ڱ����O����
                    <asp:DropDownList ID="drpGuanValue2" runat="server">
                    </asp:DropDownList>
                </div>
                <%--��O����End --%>
                <%--���ڥӽ�Begin --%>
                <div id="fraTab66" class="div_content T_-120" style="display: none">
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="13%">�ץ�_����
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtPRENTSTDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="16%">�Ȥ᭺��ú�Ǥ�
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtCUSTFPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="13%">�w�p���ڤ�
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="12%">����O���J
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�]�ƪ��B
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>�Y����
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>�i���O�Ҫ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>���ʫO�Ҫ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="div_title" style="margin-left: -10px;">
                        �i���o��
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="2200px">
                            <tr>
                                <th>����
                                </th>
                                <th>���Ҹ��X
                                </th>
                                <th>�o�����
                                </th>
                                <th>���|���B
                                </th>
                                <th>�|�B
                                </th>
                                <th>�t�|���B
                                </th>
                                <th>��i���O�Ҫ�
                                </th>
                                <th>�诲�ʫO�Ҫ�
                                </th>
                                <th>���Y����
                                </th>
                                <th>�~�N�ۥI�B
                                </th>
                                <th>�꼷���B
                                </th>
                                <th>�i���O�Ҫ�����
                                </th>
                                <th>���ʫO�Ҫ�����
                                </th>
                                <th>�Y���ڲ���
                                </th>
                                <th>������
                                </th>
                                <th>�״ڶ���
                                </th>
                                <th>�״ڻȦ�
                                </th>
                                <th>����
                                </th>
                                <th>��W
                                </th>
                                <th>�b��
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCONTRACTINV" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCERTIFICATENO" Text='<%# Eval("CERTIFICATENO")%>' runat="server"
                                                Width="96px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtINVDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>'
                                                Width="80px" runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNOTAXAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOTAXAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("TAX").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblANOUMTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                                                runat="server"></asp:Label>
                                            <asp:HiddenField ID="hidANOUMTTAX" Value='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                                                runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERBONDUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHIREPURUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("HIREPURUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFIRSTPAYUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtINVSALESPAY" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("INVSALESPAY").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACTUALLYAMOUNT" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERBONDNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDNOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPURCHASENOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PURCHASENOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFIRSTPAYNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYNOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUPPLIERS" Width="160px" runat="server" CssClass="txt_table"
                                                Text='<%# Eval("SUPPLIERS")%>'>
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hidSUPPLIER" Value='<%# Eval("SUPPLIER") %>' runat="server" />
                                            <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSUPSEQ" Text='<%# Eval("SUPSEQ")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBANKNM" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("BANKNM")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCOMPNM" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("COMPNM")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRV_NAME" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("RV_NAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRVACNT" runat="server" CssClass="txt_table" Width="132px" Text='<%# Eval("RVACNT")%>'></asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <br>
                    <br>
                    <div class="div_title" style="margin-left: -10px;">
                        �i�������o��
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="80%">
                            <tr>
                                <th>����
                                </th>
                                <th>�����o�����X
                                </th>
                                <th>������
                                </th>
                                <th>�������|���B
                                </th>
                                <th>�����|�B
                                </th>
                                <th>�����t�|���B
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCONTRACTINVD" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                            <asp:HiddenField ID="hidDISCOUNTINVOICEID" Value='<%# Eval("DISCOUNTINVOICEID") %>'
                                                runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTINVNUM" Text='<%# Eval("DISCOUNTINVNUM")%>' runat="server"
                                                Width="96px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DISCOUNTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTAMOUNTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P START --%>
                    <div class="div_title" style="margin-left: -10px;">
                        ���w�I�ڥL�H
                    </div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        <table class="tb_Contact" width="1400px">
                            <tr>
                                <th>����
                                </th>
                                <th>���Ҹ��X
                                </th>
                                <th>���ڤH
                                </th>
                                <th>�״ڶ���
                                </th>
                                <th>�״ڻȦ�
                                </th>
                                <th>����
                                </th>
                                <th>��W
                                </th>
                                <th>�b��
                                </th>
                                <th>���B
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDASSPAYMF" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCERTNO" runat="server" Text='<%# Eval("CERTNO") %>'
                                                CssClass="txt_table" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPAYEE" runat="server" Text='<%# Eval("PAYEE") %>'
                                                CssClass="txt_table" Width="110px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                            <asp:TextBox ID="txtPAYEENM" runat="server" Text='<%# Eval("PAYEENM") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUPSEQ" runat="server" Text='<%# Eval("SUPSEQ") %>'
                                                CssClass="txt_table" Width="40px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTRANSBANK" runat="server" Text='<%# Eval("TRANSBANK") %>'
                                                CssClass="txt_table" Width="200px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUBBANK" runat="server" Text='<%# Eval("SUBBANK") %>'
                                                CssClass="txt_table" Width="140px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACCNM" runat="server" Text='<%# Eval("ACCNM") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACC" runat="server" Text='<%# Eval("ACC") %>'
                                                CssClass="txt_table" Width="160px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTRANSAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TRANSAMT").ToString()) %>'
                                                CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        �w���R�P
                    </div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        �e���R�P
                        <asp:Button ID="btnPREPAY" runat="server" CssClass="btn_normal" Text="�d��" Enabled="false" />
                        <br />
                        �����R�P
                        <br />
                        <table class="tb_Contact" width="100%">
                            <tr>
                                <th>����
                                </th>
                                <th>�w����H
                                </th>
                                <th>�֭p�w��
                                </th>
                                <th>�����R�P
                                </th>
                                <th>�Ѿl�w��
                                </th>
                                <th>�����Դڮ�
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDPREPAYWOFF" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPREPAYOBJ" runat="server" Text='<%# Eval("PREPAYOBJ") %>'
                                                CssClass="txt_table" Width="160px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTOTALPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TOTALPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNOWPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOWPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLASTPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("LASTPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADVANCESINTEREST" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("ADVANCESINTEREST").ToString()) %>'
                                                CssClass="txt_table_right" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        ����O���J
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                            <tr>
                                <th>����
                                </th>
                                <th>����
                                </th>
                                <th>�νs
                                </th>
                                <th>��H
                                </th>
                                <th>����O
                                </th>
                                <th>��I�覡
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDFEEINCOME1" runat="server">
                                <itemtemplate>
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
                                                CssClass="txt_table" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                runat="server" CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                                <asp:ListItem Text="�״�" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="����" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        �����ʫO����O���J
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                            <tr>
                                <th>����
                                </th>
                                <th>����
                                </th>
                                <th>�νs
                                </th>
                                <th>��H
                                </th>
                                <th>����O
                                </th>
                                <th>��I�覡
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDFEEINCOME2" runat="server">
                                <itemtemplate>
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
                                                CssClass="txt_table" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                runat="server" CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="�п��" Value=""></asp:ListItem>
                                                <asp:ListItem Text="�״�" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="����" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P END --%>
                    <div class="div_title" style="margin-left: -10px;">
                        ��]�ƴڸ��
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="20%">�i���O�Ҫ���]�ƴ�
                            </th>
                            <td width="12%">
                                <asp:TextBox ID="txtPERBONDUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="15%">�i���O�Ҫ�����
                            </th>
                            <td width="12%">
                                <asp:TextBox ID="txtPERBONDNOTE" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="20%">���ʫO�Ҫ���]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtPURCHASEUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>���ʫO�Ҫ�����
                            </th>
                            <td>
                                <asp:TextBox ID="txtPURCHASENOTE" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>�Y���ک�]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtFIRSTPAYUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>�Y���ڲ���
                            </th>
                            <td>
                                <asp:TextBox ID="txtFIRSTPAYNOTE" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>�~�N�ۥI�B
                            </th>
                            <td>
                                <asp:TextBox ID="txtSALESPAY" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P START --%>
                            <th>����O��]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtFEEAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>�R�w����]�ƴ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtPREPAYWOFFAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.�W�[�w���R�P END --%>
                        </tr>
                    </table>
                    <br />
                    <div class="div_title" style="margin-left: -10px;">
                        ���ڸ��
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="18%">�i���`�B
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtDISCOUNTTOTAL" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="18%">�i���|�B
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtDISCOUNTTAX" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="15%">�꼷���B
                            </th>
                            <td>
                                <asp:TextBox ID="txtACTUALLYAMOUNT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--���ڥӽ�End --%>
            </div>
            <div class="btn_div">
                <asp:Button ID="btnSubmit" runat="server" Text="���ڮ֭�" CssClass="btn_normal" OnClick="btnSubmit_Click"
                    OnClientClick="javascipt:return btnSubmit_Click(this);" />
                <!--Modify 20120601 By SS Gordon. Reason: ���ڰh�^�אּ���ںM��.-->
                <asp:Button ID="btnRegect" runat="server" Text="���ںM��" CssClass="btn_normal" OnClick="btnRegect_Click"
                    Visible="false" />
                <!--Modify 20120601 By SS Gordon. Reason: �s�W�ץ�h�^���s.-->
                <asp:Button ID="btnReturn" runat="server" Text="���ڰh�^" CssClass="btn_normal" OnClick="btnReturn_Click" />
                <!--Modify 20121122 By SS Maureen. Reason: �s�W���Y�H�ˮ֫��s.-->
                <%--Modify 20121210 By SS Steven. Reason: �u���Y�H�ˮ֡v���s�令�u���Y�H�ˮ֦C�L�v�A�åB�����C�L�X��.--%>
                <%--<asp:Button ID="btnRecheck" runat="server" Text="���Y�H�ˮ�" CssClass="btn_normal" OnClientClick="Recheck();return false;" />--%>
                <asp:Button ID="btnRecheck" runat="server" Text="���Y�H�ˮ֦C�L" CssClass="btn_normal" OnClick="btnRecheck_Click" />
                <asp:TextBox ID="hdnPRINTKEY" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnINDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true"
                    Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnTRADEDT" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnCREDITDT" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="SessUSERID" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="SessDEPTNM" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:HiddenField ID="hidCond" runat="server" Value="" />
                <asp:Button ID="btnCond" Style="display: none" runat="server" Text="" OnClick="btnCond_Click" />
            </div>
        </div>
    </form>
</body>
</html>
