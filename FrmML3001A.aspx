<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3001A																					
* �{���\��  : �ץ�/�X���d��																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~.
Modify 20120529 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v
Modify 20120529 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v
Modify 20120601 By SS Gordon. Reason: �ץ�h�^�אּ�ץ�M��.
Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q
Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�
Modify 20120717 By SS Gordon. Reason: �s�W�ӧ@�覡.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.
Modify 20121108 By SS Steven. Reason: �s�W�ץ�h�^���s
Modify 20130117 BY    SEAN.   Reason: ��ץ󤺮e��ñ�N�u�ץ󻡩��v��쪺����W���ܧ󬰡u�Ƶ��v
Modify 20131210 BY    SEAN    Reason: �ץ����ʲ������������D
Modify 20141205 By SS Gordon. Reason: �s�WNPV2�PNPV�Q�v����2
Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������
Modify 20150126 By SS ChrisFu. Reason:�s�W�M�קO���
Modify 20150205 By SS ChrisFu. Reason:�s�W�u��ĳ�Դڮ��v���
20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����
20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%)
20221031 �վ�u�ץ󤺮e�v�B�u�Ъ����v��m�A���áu�i���ơv����
20221031 ���ëȤ��Ƥ��Ȥ�ʽ�B���ι�ڭt�d�H�B�����q�W�����A��~�O�אּ�U�Ԧ����
20221031 �Ъ�������AR�ץ�L�Ъ����B�Ȧ�ץ�L�Ъ���
20221031 �ץ󤺮e�������ñM�קO�B���q�W�١B�ӧ@�覡�B�ʥα��p�B���l���v�B�Ȧ�O�B�����b�ڮץ�
--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML3001A.aspx.cs" inherits="FrmML3001A" %>

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
    <!-- #Include file='js/ML3001A.js' -->                   
    </script>

</head>
<body onload="window_onload();showTag();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <progresstemplate>
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
            </progresstemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
                <div class="divBody" id="div_Info">
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
                    <table class="divStatus" width="80%">
                        <tr>
                            <th>�ץ�s��
                            </th>
                            <td>
                                <asp:TextBox ID="txtCASEID" runat="server" CssClass="txt_readonly" Width="100px"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>�ӽФ�
                            </th>
                            <td>
                                <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td width="40%"></td>
                        </tr>
                    </table>
                    <div id="fraDispTypeInfo" class="frame_content div_Info " style="min-height: 855px; height: auto !important;">
                        <%--�Ȥ���Begin --%>
                        <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu">
                            <label class="label_contain">
                                �Ȥ���</label>
                        </div>
                        <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu T_-24 L_125">
                            <label class="label_contain">
                                �Ъ���</label>
                        </div>
                        <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu T_-48 L_250">
                            <label class="label_contain">
                                �ץ󤺮e</label>
                        </div>

                        <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu T_-72 L_375">
                            <label class="label_contain">
                                ��O����</label>
                        </div>
                        <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu T_-96 L_500">
                            <label class="label_contain">
                                �x�f���</label>
                        </div>
                        <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu W_124 T_-120 L_625">
                            <label class="label_contain">
                                �ץ���i</label>
                        </div>
                        <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                        <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: block">
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
                                        <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="230px">
                                        </asp:TextBox>
                                        <%--                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �Ȥ�ʽ�--%>
                                        <asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1"
                                            DataValueField="MCODE" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>�n�O�ꥻ�B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" Width="112px"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>�ꦬ�ꥻ�B
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" Width="112px"
                                            ReadOnly="true">
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
                                        <asp:TextBox ID="txtOWNERID" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="112px"></asp:TextBox>
                                        <%--                  &nbsp;&nbsp;&nbsp;&nbsp;���ι�ڭt�d�H--%>
                                        <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                            ReadOnly="true" Visible="False">
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
                                            runat="server" Width="120px" Enabled="false">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�W���d
                  <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                      Width="86px" Enabled="false">
                      <asp:ListItem>�п��</asp:ListItem>
                  </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--20221031 �אּ����--%>
                                <%--<tr>
                <th>
                  �����q�νs
                </th>
                <td>--%>
                                <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="False"></asp:TextBox>
                                <%--</td>
                <th>
                  �����q�W��
                </th>
                <td>--%>
                                <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px" Visible="False">
                                </asp:TextBox>
                                <%--</td>
              </tr>--%>
                                <tr>
                                    <th>���q�n�O�a�}
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="40px" CssClass="txt_readonly"
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
                                        <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="40px" CssClass="txt_readonly"
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
                                            Width="80%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>��~�O
                                    </th>
                                    <td colspan='3'>
                                        <!-- 20160323 ADD BY SS ADAM REASON.�s�W��~�O ===START===-->
                                        <asp:DropDownList ID="DrpNDU" class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="False">
                                            <asp:ListItem>�п��</asp:ListItem>
                                        </asp:DropDownList>

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
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                    Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
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
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
                                                                    runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAXCODE"
                                                                    runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAX" runat="server"
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
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                    Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
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
                                                                <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
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
                                                                <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="60px" Enabled="false" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODE")%>'>
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" Enabled="false" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODES")%>'>
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="txtINVOICEADDR" runat="server" Enabled="false" CssClass="txt_table"
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
                        <%--�ץ�&#61136;�eBegin --%>
                        <div id="fraTab33" class="div_content padleft_0 T_-120" style="display: none">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <%--Modify 20150126 By SS ChrisFu. Reason:�s�W�M�קO���--%>
                                <%--20221031 �אּ����--%>
                                <%--<tr>
                    <th>
                    �M�קO
                    </th>
                    <td colspan="8">--%>
                                <asp:DropDownList ID="drpPROJCD" runat="server" Enabled="false" Visible="False">
                                    <asp:ListItem Value="01">�@��</asp:ListItem>
                                    <asp:ListItem Value="02">����</asp:ListItem>
                                    <asp:ListItem Value="03">�ưȾ�</asp:ListItem>
                                </asp:DropDownList>
                                <%--</td>
                </tr>--%>
                                <tr>
                                    <%--<th width="12%">
                  ���q�W��
                </th>
                <td width="12%">--%>
                                    <asp:DropDownList ID="drpCOMPID" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false" Visible="False">
                                        <asp:ListItem>�M��</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--                </td>--%>
                                    <%--Modify 20120717 By SS Gordon. Reason: �s�W�ӧ@�覡.--%>
                                    <%--20221031 �אּ����--%>
                                    <%--<th width="12%">
                  �ӧ@�覡
                </th>
                <td width="12%">--%>
                                    <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false" Visible="False">
                                    </asp:DropDownList>
                                    <%--                </td>--%>
                                    <th width="12%">�Ӱ����A
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
                                    <th>�ӧ@��H
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
                                    <th>�ץ󲣫~�O
                                    </th>
                                    <td colspan="8">
                                        <asp:DropDownList ID="drpPRODCD" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%--20221031 �אּ����--%>
                                        <%--�ʥα���--%>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Visible="False">
                                            <asp:ListItem>�浧�ʥ�</asp:ListItem>
                                            <asp:ListItem>�h���ʥ�</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Visible="False">
                                            <asp:ListItem>�`��</asp:ListItem>
                                            <asp:ListItem>���`��</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th>
                                        <%--20221031 �אּ����--%>
                                        <%--�N�L��--%>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Visible="False">
                                            <asp:ListItem Value="">�п��</asp:ListItem>
                                            <asp:ListItem Value="Y">�O</asp:ListItem>
                                            <asp:ListItem Value="N">�_</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ�O.--%>
                                    <th>
                                        <%--�Ȧ�O--%>
                                    </th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%--���l���v--%>
                                    </th>
                                    <td colspan="5">
                                        <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                                            <contenttemplate>
                                                <asp:DropDownList ID="drpRECOURSE" runat="server" Enabled="false" Visible="False">
                                                    <asp:ListItem Value="">�п��</asp:ListItem>
                                                    <asp:ListItem Value="Y">�O</asp:ListItem>
                                                    <asp:ListItem Value="N">�_</asp:ListItem>
                                                </asp:DropDownList>
                                            </contenttemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>

                                <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O START-->
                                <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O END-->

                            </table>
                            <div>
                                <div>
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
                                <%--20221031 �אּ����--%>
                                <%--                                <div class="right_div" style="height: 265px;">
                                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                                        <tr>
                                            <td colspan="2">--%>
                                <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" Width="0px" Height="0px" />
                                <%--�����b�ڮץ�--%>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�ӽ��B��
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Visible="False">
                                </asp:TextBox>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�x�H�O
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Visible="False">
                                </asp:TextBox>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�b�Ⱥ޲z�O
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" Visible="False">
                                </asp:TextBox>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�]���U�ݶO
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" Visible="False">
                                </asp:TextBox>
                                <%--                                            </td>
                                        </tr>--%>
                                <!--Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�-->
                                <%--                                        <tr>
                                            <th>�i���O�Ҫ�
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" Visible="False">
                                </asp:TextBox>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>����
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Visible="False">
                                </asp:TextBox>
                                <%--%--%>
                                <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>�b�ڴ���
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Visible="False">
                                </asp:TextBox>
                                <%--��--%>
                                <%--</td>
                                        </tr>--%>
                                <tr style="display: none">
                                    <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
                                    <%--                    <th>
                      �I�ڮɶ�
                    </th>
                    <td>
                      <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                        Enabled="false" runat="server" Width="80%">
                        <asp:ListItem>����I</asp:ListItem>
                        <asp:ListItem>�����I</asp:ListItem>
                      </asp:DropDownList>
                    </td>--%>
                                    <%--                                            <td>--%>
                                    <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                        Enabled="false" Style="display: none" runat="server" Width="80%" Visible="False">
                                        <asp:ListItem>����I</asp:ListItem>
                                        <asp:ListItem>�����I</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--                                            </td>
                                        </tr>
                                        <tr>
                                            <th>��@�R�譭�B
                                            </th>
                                            <td>--%>
                                    <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true" Text="" Visible="False">
                                    </asp:TextBox>
                                    <%--                                            </td>
                                        </tr>--%>
                                    <tr style="display: none">
                                        <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
                                        <%--                    <th>
                      �ӧ@�u��IRR
                    </th>
                    <td>
                      <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                        ReadOnly="true"></asp:TextBox>
                    </td>--%>
                                        <%--                                            <td>--%>
                                        <asp:TextBox ID="txtARIRR" custprop="100" Style="display: none" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Visible="False">
                                        </asp:TextBox>
                                        <%--                                            </td>
                                        </tr>--%>
                                        <%--Modify 20150205 By SS ChrisFu. Reason:�s�W�u��ĳ�Դڮ��v���--%>
                                        <%--                                        <tr>
                                            <th>��ĳ�Դڮ�</th>
                                            <td>--%>
                                        <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="" Visible="False">
                                        </asp:TextBox>
                                        <%--%--%>
                                        <%--                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>
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
                                            <asp:DropDownList ID="drpEXPIREPROC" DataTextField="DNAME1" DataValueField="DCODE"
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
                                            <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="width: 98%"></asp:TextBox>
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
                                            <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>
                                            %
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <th></th>
                                        <td></td>
                                        <th>�]�ƥ�NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                        <th>�]�ƥ�NPV����
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
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
                                        <%--Modify 20141205 By SS Gordon. Reason: �s�WNPV2�PNPV�Q�v����2--%>
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
                        <%--�ץ�&#61136;�eEnd --%>
                        <%--�Ъ���Begin --%>
                        <div id="fraTab22" class="div_content" style="display: none">
                            <div class="div_table" style="overflow: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 1000px;">
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
                                                    <asp:DropDownList ID="drpTARGETTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
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
                                        </itemtemplate>
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
                            <div class="div_table" style="overflow: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 900px;">
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
                                                    <asp:TextBox ID="txtSTOREDZIPCODE" Enabled="false" runat="server" Width="60px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDZIPCODE")%>'>
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDZIPCODES" Enabled="false" runat="server" Width="120px"
                                                        CssClass="txt_table" Text='<%# Eval("STOREDZIPCODES")%>'>
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDADDR" Enabled="false" runat="server" Width="150px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDADDR")%>'>
                                                    </asp:TextBox>
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
                                        </itemtemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                        <%--�Ъ���End --%>
                        <%--��O����Begin --%>
                        <div id="fraTab44" class="div_content T_-130" style="min-height: 730px; display: none; height: auto !important;">
                            <br />
                            �O�ҤH<asp:CheckBox ID="chkMLDCASEGUARANTEE" Enabled="false" runat="server" />
                            ���׵L�O�ҤH
            <div class="div_table" style="overflow: scroll;">
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
                        <itemtemplate>
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
                                        Width="80" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                        Width="80" Enabled="false">
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
                                        Enabled="false" runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <%--Modify 20120601 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                                <td>
                                    <asp:TextBox ID="txtGRTBIRDT" Enabled="false" Text='<%# Eval("GRTBIRDT") %>' runat="server" Width="80px" CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGRTSEX" Enabled="false" runat="server" Width="50px">
                                        <asp:ListItem Value="">�п��</asp:ListItem>
                                        <asp:ListItem Value="1">�k</asp:ListItem>
                                        <asp:ListItem Value="2">�k</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGRTRESIDENTZIP" Enabled="false" Text='<%# Eval("GRTRESIDENTZIP") %>' runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                                    <input type="button" id="btnGRTRESIDENTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                    <asp:TextBox ID="txtGRTRESIDENTZIPNM" Enabled="false" Text='<%# Eval("GRTRESIDENTZIPNM") %>' runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');" CssClass="txt_table"></asp:TextBox>
                                    <asp:TextBox ID="txtGRTRESIDENTADDR" Enabled="false" Text='<%# Eval("GRTRESIDENTADDR") %>' runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGRTZIP" Enabled="false" Text='<%# Eval("GRTZIP") %>' runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                                    <input type="button" id="btnGRTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                    <asp:TextBox ID="txtGRTZIPNM" Enabled="false" Text='<%# Eval("GRTZIPNM") %>' runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table"></asp:TextBox>
                                    <asp:TextBox ID="txtGRTADDR" Enabled="false" Text='<%# Eval("GRTADDR") %>' runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGRTTELCODE" Enabled="false" Text='<%# Eval("GRTTELCODE") %>' runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                    <asp:TextBox ID="txtGRTTEL" Enabled="false" Text='<%# Eval("GRTTEL") %>' runat="server" Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                    <asp:TextBox ID="txtGRTTELEXT" Enabled="false" Text='<%# Eval("GRTTELEXT") %>' runat="server" Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGRTRELATION1" Enabled="false" runat="server" Width="180px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGRTRELATION2" Enabled="false" runat="server" Width="105px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGRTJOBCLS" Enabled="false" runat="server" Width="160px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                                </td>
                                <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                                <td>
                                    <asp:DropDownList ID="drpGRTJOB" Enabled="false" runat="server" Width="220px" DataTextField="DNAME1" DataValueField="DCODE">
                                        <asp:ListItem Value="">�D��v</asp:ListItem>
                                        <asp:ListItem Value="01">��v</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGRTCOMPANY" Enabled="false" Text='<%# Eval("GRTCOMPANY") %>' runat="server" Width="200px" CssClass="txt_table"></asp:TextBox>
                                </td>
                            </tr>
                        </itemtemplate>
                    </asp:Repeater>
                </table>
            </div>
                            <br />
                            �ʲ��]�w<asp:CheckBox ID="chkMLDCASEMOVABLE" Enabled="false" runat="server" />
                            ���׵L�ʲ��]�w
            <div class="div_table" style="overflow: scroll;">
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
                                    <asp:TextBox ID="txtMOVABLENAME" Enabled="false" Text='<%# Eval("MOVABLENAME")%>'
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
                                    <asp:TextBox ID="txtMOVABLEZIPCODE" Enabled="false" runat="server" Width="60px" CssClass="txt_table"
                                        Text='<%# Eval("MOVABLEZIPCODE")%>'>
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtMOVABLEZIPCODES" Enabled="false" runat="server" Width="120px"
                                        CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'>
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtMOVABLEADDR" Enabled="false" runat="server" CssClass="txt_table"
                                        Width="150px" Text='<%# Eval("MOVABLEADDR")%>'>
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLENO" Enabled="false" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                        CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLEYEAR" Enabled="false" Text='<%# Eval("MOVABLEYEAR")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLEBUYDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLENEWAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                        runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLEBUYAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                        runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLERESIDUALS" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                        runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMOVABLERESETPRICE" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
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
            <div class="div_table" style="overflow: scroll;">
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
                                    <asp:TextBox ID="txtIMMOVABLEOWNER" Enabled="false" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEOWNERID" Enabled="false" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEGETDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEBUILDDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLESECTOR" Enabled="false" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEBUILD" Enabled="false" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEAREA" Enabled="false" Text='<%# Eval("IMMOVABLEAREA")%>'
                                        runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEHOLDER" Enabled="false" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                        runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEBUILDNO" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEHOUSENUM" Enabled="false" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                        runat="server" CssClass="txt_table">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                        onblur="areacon(this)" runat="server" CssClass="txt_table_right">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
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
                                                <asp:TextBox ID="txtHUMANRIGHTS" Enabled="false" Text='<%# Eval("HUMANRIGHTS") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtREGISTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSETPRICE" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCREDITOR" Enabled="false" Text='<%# Eval("CREDITOR") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <%--2013.12.10 Modify by SEAN. Reason:�ץ����ʲ������������D--%>
                                                <%--<asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                      </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtMLDCASEIMMOVABLE" Enabled="false" runat="server" CssClass="txt_table" Text='<%# Eval("IDMEMO") %>' />
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
                                <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("DEPOSITBANKS") %>'
                                    Width="120px" runat="server">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDEPOSITNBR" Enabled="false" Text='<%# Eval("DEPOSITNBR") %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDEPOSITAMT" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                    runat="server" CssClass="txt_table_right">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDEPOSITSTARTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDEPOSITDUEDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
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
                                <asp:TextBox ID="txtBILLNOTEDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                    runat="server" CssClass="txt_table" Width="80px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("BILLNOTEBANKS") %>'
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
                                <asp:TextBox ID="txtBILLNOTENBR" Enabled="false" Text='<%# Eval("BILLNOTENBR") %>'
                                    runat="server" CssClass="txt_table" Width="60px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtACCOUNT" Enabled="false" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                    CssClass="txt_table" Width="60px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBILLNOTECUSTNAME" Enabled="false" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                    runat="server" CssClass="txt_table" Width="80px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBILLNOTEAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                    runat="server" CssClass="txt_table_right" Width="60px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBILLNOTENOTE" Enabled="false" Text='<%# Eval("BILLNOTENOTE") %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBILLNOTEBACKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
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
                                <asp:TextBox ID="txtSTOCKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKNAME" Enabled="false" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                    CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKPROVIDER" Enabled="false" Text='<%# Eval("STOCKPROVIDER") %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKUNIT" Enabled="false" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                    CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" Enabled="false" Text='<%# Eval("STOCKQUANTITY") %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" Enabled="false" Text='<%# Eval("STOCKTOTAL") %>'
                                    runat="server" CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKBEGIN" Enabled="false" Text='<%# Eval("STOCKBEGIN") %>'
                                    runat="server" CssClass="txt_table" Width="60px">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSTOCKEND" Enabled="false" Text='<%# Eval("STOCKEND") %>' runat="server"
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
                                <asp:TextBox ID="txtSTOCKNOTE" Enabled="false" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                    CssClass="txt_table">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </itemtemplate>
                </asp:Repeater>
            </table>
                            <br />
                            ��L<br />
                            <asp:TextBox ID="txtOTHERCOND" Enabled="false" runat="server" CssClass="txt_normal"
                                Width="80%">
                            </asp:TextBox>
                        </div>
                        <%--��O����End --%>
                        <%--�x�f���Begin --%>
                        <div id="fraTab55" class="div_content" style="display: none">
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
                                    <itemtemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("DNAME1")%>'></asp:Label>
                                                <td>
                                                    <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL"))  %>' runat="server"
                                                        Text='<%# Eval("DNAME2")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>'
                                                        Enabled="false" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNOTE" Text='<%# Eval("NOTE") %>' runat="server" Enabled="false"
                                                        CssClass="txt_table" Width="120px">
                                                    </asp:TextBox>
                                                </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <%--�x�f���End --%>
                        <%--�ץ���iBegin --%>
                        <div id="fraTab66" class="div_content" style="display: none">
                            <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal"
                                Text="���i�U��" />
                            <%--<asp:Label ID="Label102" runat="server" Text="Label">���i��.doc</asp:Label>--%>
                            <asp:LinkButton ID="lkbOpenFile" runat="server"></asp:LinkButton>
                        </div>
                        <%--�ץ���iEnd --%>
                    </div>
                    <div class="btn_div">
                        <asp:Button ID="btnSub" runat="server" Text="�֡@��" CssClass="btn_normal" OnClick="btnSub_Click" Width="90px" />
                        &nbsp;
          <!--Modify 20120601 By SS Gordon. Reason: �ץ�h�^�אּ�ץ�M��.-->
                        <asp:Button ID="btnRej" runat="server" Text="�ץ�M��" CssClass="btn_normal" OnClick="btnRej_Click" Width="90px" />
                        <!--Modify 20121108 By SS Steven. Reason: �s�W�ץ�h�^���s.-->
                        <%--Mark by Sean 20121130 �B�����i�h�^--%>
                        <asp:Button ID="btnReturn" runat="server" Text="�ץ�h�^" CssClass="btn_normal" OnClick="btnReturn_Click" Width="90px" />

                    </div>
                </div>
            </contenttemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
