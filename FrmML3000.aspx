<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3000																					
* �{���\��  : �ץ�ӽк��@																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~.
Modify 20120528 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v
Modify 20120528 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v�A�ñN����ܧ󬰥i��J100�Ӥ���r
Modify 20120531 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q
Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�
Modify 20120607 By SS Gordon. Reason: �s�W�ץ�M����s.
Modify 20120621 By SS Gordon. Reason: �s�W�������H�x�s�ץ��ƨѭק�᪺�ˮ�
Modify 20120716 By SS Gordon. Reason: �s�W�ӧ@�覡.
Modify 20120716 By SS Gordon. Reason: �s�W�Ȧ�O.
Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.
Modify 20121112 By SS Steven. Reason: �s�W�������Ӱ��P�_
Modify 20121112 By SS Steven. Reason: �s�W�������Ӱ��P�_
Modify 20121112 By SS Steven. Reason: �n���O�H����ɡA�t�Ψ̭ӤH�Ϊk�H�P�O�A�D���n���n������H�Ϧǧe�{
Modify 20130117 BY    SEAN.   Reason: ��ץ󤺮e��ñ�N�u�ץ󻡩��v��쪺����W���ܧ󬰡u�Ƶ��v
Modify 20130326 By SS Eric    Reason:�s�W�O�I���`���
Modify 20130326 By SS Eric    Reason:�NtxtEXPIREPROCDESC�� MaxLength="100" onblur="CheckMLength(this,100,'����');"��100�令150
Modify 20130402 By SS Vicky   Reason: �ʲ��P���ʲ��W�[�ƻs���s
Modify 20130411 By SS Vicky. Reason: �ʲ��Τ��ʲ��N�����אּTextbox  (MOVABLEORDER / IMMOVABLEORDER)
Modify 20130425 By SS Steven. Reason: ��O���󪺤��ʲ��v�Q�H��������ˮ�
Modify 20130510 By SS Brent. Reason:�[�J���l���v�U�Կ��
20130521 ADD BY ADAM Reason.�W�[�v�Q�H���IDMEMO�B�z
Modify 20130913 By    Sean.   Reason:�ʲ��]�w�Ҧb�a���i��J50�Ӥ���r
20130914 ADD BY ADAM Reason.�W�[�P�_�O�I���B�O�_�ݭn����
Modify 20131001 By SS Eric    Reason:�b�Ъ������Ҥ��A�Ъ�����GRID�W�[�s�y�t�ӡA�t�P�A���A�ƶq
Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������
Modify 20150121 By SS Eric.   Reason:�s�W�M�קO
Modify 20150205 By SS ChrisFu. Reason:�]�ӧ@���A�ܧ󬰡u�����b�ڨ����v�ɡA��줺�e�n����ʡA�G�[�WUpdatePanel
Modify 20150205 By SS ChrisFu. Reason:�u���ơv��TextBox�אּ�U�Կ��
Modify 20150205 By SS ChrisFu. Reason:�u��ĳ�Ԯ��ڡv�]�����áA�s�W�u��ĳ�Դڮ��v
Modify 20161130 BY    SEAN    Reason:�s�W�uNPV0�v.�uNPV0�����v�������
20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����
20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%)
20221031 �վ�u�ץ󤺮e�v�B�u�Ъ����v��m�A���áu�i���ơv����
20221031 ���ëȤ��Ƥ��Ȥ�ʽ�B���ι�ڭt�d�H�B�����q�W�����A��~�O�אּ�U�Ԧ����
20221031 �Ъ����s�W�פJ�d���U���B����AR�ץ�L�Ъ����B�Ȧ�ץ�L�Ъ���
20221031 �ץ󤺮e�������ñM�קO�B���q�W�١B�ӧ@�覡�B�ʥα��p�B���l���v�B�Ȧ�O�B�����b�ڮץ�
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3000.aspx.cs" Inherits="FrmML3000" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3000.js' -->                       
  </script>

</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
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
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
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
        <table class="divStatus" width="98%">
          <tr>
            <td width="36%">
              <asp:Button ID="btnInsert" runat="server" Text="�s�W" CssClass="btn_normal" OnClick="btnInsert_Click" Visible="false" />
              <asp:Button ID="btnUpdate" runat="server" Text="�ק�" CssClass="btn_normal" OnClientClick="return CaseClick('U')" />
              <asp:Button ID="btnSelect" runat="server" Text="�d��" CssClass="btn_normal" OnClientClick="return CaseClick('S')" Visible="false" />
              <asp:Button ID="btnLoadCase" runat="server" Text="���J�®�" CssClass="btn_normal" OnClientClick="return CaseInsertClick()" OnClick="btnLoadCase_Click" Width="70px" Visible="false" />
              <asp:Button ID="btnCusQue" Style="display: none" runat="server" Text="" OnClick="btnCusQue_Click" />
              <asp:Button ID="btnCaseQue" Style="display: none" runat="server" Text="" OnClick="btnCaseQue_Click" />
              <asp:HiddenField ID="hidCustomer" runat="server" />
              <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
              <asp:HiddenField ID="hidSelRowIndex" runat="server" Value="-1" />
              <asp:HiddenField ID="hidOldData" runat="server" Value="" />
              <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
              <asp:HiddenField ID="hidSelRowTag" runat="server" Value="" />
              <asp:HiddenField ID="hidDEPTID" runat="server" Value="" />
              <asp:HiddenField ID="hidEMPLID" runat="server" Value="" />
			  <!--20130914 ADD BY ADAM Reason.�W�[�P�_�O�I���B�O�_�ݭn����-->
			  <asp:HiddenField ID="hidMAINTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidSUBTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidTARGETPRICE" runat="server" Value="" />
			  <asp:HiddenField ID="hidTARGETTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidINSUREERR" runat="server" Value="" />
            </td>
            <th width="11%">
              �ץ�s��
            </th>
            <td width="13%">
              <asp:TextBox ID="txtCASEID" Enabled="false" Width="100px" runat="server" CssClass="txt_normal"></asp:TextBox>
            </td>
            <th width="12%">
              �ӽФ�
            </th>
            <td width="12%">
              <asp:TextBox ID="txtSYSDT" Enabled="false" runat="server" CssClass="txt_normal"></asp:TextBox>
            </td>
            <td>
              <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
            </td>
          </tr>
        </table>
        <div id="fraDispTypeInfo" class="frame_content div_Info " style="min-height: 900px; height: auto !important;">
          <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu">
            <label class="label_contain">
              �Ȥ���</label>
          </div>
          <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu T_-24 L_125">
            <label class="label_contain">
              �Ъ���</label>
          </div>
          <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu  L_250 T_-48">
            <label class="label_contain">
              �ץ󤺮e</label>
          </div>
          <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu L_375 T_-72">
            <label class="label_contain">
              ��O����</label>
          </div>
          <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu L_500 T_-96">
            <label class="label_contain">
              �x�f���</label>
          </div>
            <%--20221031 �אּ����--%>
<%--          <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu1 L_535 T_-120">
            <label class="label_contain">
              <!--�ץ���i</label>-->
              <!-- 20161229 ADD BY SS ADAM REASON.�אּ�i���ơA�W�ǼW�[��4�� -->
              �i����</label>
          </div>--%>
          <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu W_124 T_-120 L_625">
            <label class="label_contain">
              ���Ӭd��</label>
          </div>
          <%--�Ȥ���Begin --%>
          <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: none;">
            <table cellpadding="1" cellspacing="1" class="tb_Info">
              <tr>
                <th width="15%">
                  �Ȥ�νs
                </th>
                <td width="15%">
                  <asp:TextBox ID="txtCUSTID" runat="server" onkeypress="OnlyNumDUCase(this);" CssClass="txt_readonly" MaxLength="10" onblur="CUSTID_onblur(this);"></asp:TextBox>
                  <input type="button" id="btnSelCus" class="btn_normal" disabled="true" runat="server" onclick="CustomerClick();" style="width: 25px; padding: 2px;" value="&#8230;" />
                </td>
                <th width="13%">
                  �Ȥ�W��
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="240px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                    <%--20221031 �אּ����--%>
                    <%--�Ȥ�ʽ�--%><asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1" DataValueField="MCODE" style="display:none">
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <th>
                  �n�O�ꥻ�B
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" ReadOnly="true" Width="112px"></asp:TextBox>
                </td>
                <th>
                  �ꦬ�ꥻ�B
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" ReadOnly="true" Width="112px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�]�ߤ��
                  <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly" Width="81px" ReadOnly="true"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  �t�d�H
                </th>
                <td>
                  <asp:TextBox ID="txtOWNER" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <th>
                  ����ID
                </th>
                <td>
                  <asp:TextBox ID="txtOWNERID" runat="server" MaxLength="10" Width="85px" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);" CssClass="txt_normal"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <%--20221031 �אּ����--%>
                    <%--���ι�ڭt�d�H--%><asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                    <%--20221031 �אּ����--%>
                  <%--�����q�s��--%>
                </th>
                <td>
                  <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
                <th>
                  <%--�����q�W��--%>
                </th>
                <td>
                  <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" Width="276px" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  ���q�n�O�a�}
                </th>
                <td colspan="2">
                  <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                  <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="276px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  ���q�n�O�q��
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <th>
                  �ǯu
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" Width="20px" runat="server" CssClass="txt_normal"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTFAX" runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_normal"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  ��~�n�O�a�}
                </th>
                <td colspan="2">
                  <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                  <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="276px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  ��~�n�O�q��
                </th>
                <td>
                  <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <th>
                  �ǯu
                </th>
                <td>
                  <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" Width="20px" runat="server" CssClass="txt_normal"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSFAX" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  �D�n��~����
                </th>
                <td colspan="3">
                  <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="81%"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  ��~�O
                </th>
                <td colspan='3'>
                   <!-- 20160322 ADD BY SS ADAM REASON.�s�W��~�O ===START===-->
                    <%--20221031 ��~�O��U�Կ��--%>
                                 <asp:DropDownList ID="DrpNDU"  class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                    DataValueField="MCODE" Enabled="False" >
                                    <asp:ListItem>�п��</asp:ListItem>
                                </asp:DropDownList>

                    <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnINDUPAGE" runat="server" Text="�d�ߦ�~�O" CssClass="btn_normal" Enabled="false" Visible="False" />
                    <!-- 20160322 ADD BY SS ADAM REASON.�s�W��~�O ====END====-->
                  <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false" style="display:none;">
                    <asp:ListItem>�п��</asp:ListItem>
                  </asp:DropDownList>
                  <asp:DropDownList ID="drpCUROUTF" Style="display: none" DataTextField="DNAME1" DataValueField="DCODE" runat="server" Enabled="false" Width="50%">
                    <asp:ListItem>�п��</asp:ListItem>
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <th>
                  ���H�岫
                </th>
                <td>
                  <asp:DropDownList ID="drpDEFECTIVE" class="bg_F5F8BE" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                    <asp:ListItem Value="">�п��</asp:ListItem>
                    <asp:ListItem Value="Y">��</asp:ListItem>
                    <asp:ListItem Value="N">�L</asp:ListItem>
                  </asp:DropDownList>
                </td>
                <td colspan='2'>
                  <span style="color: Red">�����G ���Ȥ�]���q�έt�d�H�^��T�~���L���H�岫</span>
                </td>
              </tr>
              <%--						
              <tr>
                   <th>�����b��_�M�B</th>
                   <td>
                       <asp:TextBox ID="txtLLVLNUM01" runat="server" CssClass="txt_readonly" Width="50%" ReadOnly></asp:TextBox>
                   </td>
                   <th >�����b��_�M��</th>
                   <td >
                       <asp:TextBox ID="txtLLVLNUM02" runat="server" CssClass="txt_readonly" Width="50%" ReadOnly></asp:TextBox>
                   </td>
                </tr>
                --%>
              <tr>
                <th>
                  �M���H
                </th>
                <td colspan="3">
                  <input type="button" id="btnC1" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('1');" value="�s�W" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactM" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactM" class="tb_Contact" width="100%">
                          <tr>
                            <th>
                              �R��
                            </th>
                            <th>
                              �m�W
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
                              Email
                            </th>
                          </tr>
                          <asp:Repeater ID="rptContactM" runat="server">
                            <ItemTemplate>
                              <tr>
                                <td>
                                  <asp:Button ID="btnMainDel" runat="server" Text="�R" OnClientClick="return ContactDelete('1',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
              <tr>
                <th>
                  �ץ��p���H
                </th>
                <td colspan="3">
                  <input type="button" id="btnC2" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('2');" value="�s�W" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactC" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactC" class="tb_Contact" width="100%">
                          <tr>
                            <th>
                              �R��
                            </th>
                            <th>
                              �m�W
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
                              Email
                            </th>
                          </tr>
                          <asp:Repeater ID="rptContactC" runat="server">
                            <ItemTemplate>
                              <tr>
                                <td>
                                  <asp:Button ID="Button1" runat="server" Text="�R" OnClientClick="return ContactDelete('2',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox1" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox2" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox3" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox4" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAXCODE" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAX" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox5" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
              <tr>
                <th>
                  �o���p���H
                </th>
                <td colspan="3">
                  <input type="button" id="btnC3" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('3');" value="�s�W" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactI" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactI" class="tb_Contact" width="150%;">
                          <tr>
                            <th>
                              �R��
                            </th>
                            <th>
                              �m�W
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
                              Email
                            </th>
                            <th>
                              �o���H�e�a
                            </th>
                          </tr>
                          <asp:Repeater ID="rptContactI" runat="server">
                            <ItemTemplate>
                              <tr>
                                <td>
                                  <asp:Button ID="Button2" runat="server" Text="�R" OnClientClick="return ContactDelete('3',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox6" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox7" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox8" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox9" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox10" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox11" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox12" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox13" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox14" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox15" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("INVZIPCODE")%>'></asp:TextBox>
                                  <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                  <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" onfocus="ObjMFocus(this,'txtINVZIPCODES','txtINVOICEADDR');" CssClass="txt_table" Text='<%# Eval("INVZIPCODES")%>'></asp:TextBox>
                                  <asp:TextBox ID="txtINVOICEADDR" runat="server" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');" Width="150px" MaxLength="100" Text='<%# Eval("INVOICEADDR")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
            </table>
          </div>
          <%--�Ȥ���End --%>
          <%--�ץ�&#61136;�eBegin --%>
          <div id="fraTab22" class="div_content padleft_0 T_-120" style="display: none">
            <table cellpadding="1" cellspacing="1" class="tb_Info">
              <tr>
                <%--Modify 20150105 By SS Eric.   Reason:�s�W�M�קO--%>
                <th>
                    <%--20221031 �אּ����--%>
                  <%--�M�קO--%>
                </th>
                <td >
                    <asp:DropDownList ID="drpPROJCD" class="bg_F5F8BE" runat="server" onchange="drpPROJCD_OnChange(this);" style="display:none">
                    <asp:ListItem Value="01">�@��</asp:ListItem>
                    <asp:ListItem Value="02" Enabled="false">����</asp:ListItem>
                    <asp:ListItem Value="03" Enabled="false">�ưȾ�</asp:ListItem>
                    </asp:DropDownList>
                </td>
              </tr>
              <tr>
                  <%--20221031 �אּ����--%>
                <%--<th >
                  ���q�W��
                </th>
                <td>--%>
                  <asp:DropDownList ID="drpCOMPID" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" style="display:none">
                  </asp:DropDownList>
                <%--</td>
                Modify 20120716 By SS Gordon. Reason: �s�W�ӧ@�覡.
                <th >
                  �ӧ@�覡
                </th>
                <td >--%>
                  <asp:DropDownList ID="drpSOURCETYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpSOURCETYPE_SelectedIndexChanged" AutoPostBack="true" style="display:none">
                  </asp:DropDownList>
                <%--</td>--%>
                <th width="12%">
                  �ӧ@���A
                </th>
                <td width="12%">
                  <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged" AutoPostBack="true">
                  </asp:DropDownList>
                </td>
                <td width="12%">
                  <asp:UpdatePanel ID="UpdatePaneldrpSUBTYPE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                      <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" OnSelectedIndexChanged="drpSUBTYPE_SelectedIndexChanged" AutoPostBack="true">
                      </asp:DropDownList>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </td >
                <th width="12%">
                  ����κA
                </th>
                <td>
				  <asp:UpdatePanel ID="UpdatePaneldrpTRANSTYPE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="drpTRANSTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" OnSelectedIndexChanged="drpTRANSTYPE_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
				    </ContentTemplate>
                  </asp:UpdatePanel>
                </td>
                <th width="12%">
                    �ӧ@��H
                </th>
                <th width="12%">
                    <asp:DropDownList ID="drpCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                  </asp:DropDownList>
                </th>
                  <th width="12%">�ץ󲣫~�O </th>
                      <th width="12%">
                          <asp:DropDownList ID="drpPRODCD" runat="server" class="bg_F5F8BE" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpPRODCD_SelectedIndexChanged" AutoPostBack="true">
                          </asp:DropDownList>
                      </th>
              </tr>
                <%--20221031 �אּ����--%>
              <%--<tr>
                <th>
                  �ʥα���
                </th>
                <td>--%>
                  <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" style="display:none">
                  </asp:DropDownList>
                <%--</td>
                <td >--%>
                  <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" style="display:none">
                  </asp:DropDownList>
                <%--</td>--%>
<%--                <th>
                  �N�L��
                </th>
                <td>--%>
                <asp:UpdatePanel ID="UpdatePanelPRINTSTORE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                      <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE" runat="server" style="display:none">
                    <asp:ListItem Value="">�п��</asp:ListItem>
                    <asp:ListItem Value="Y">�O</asp:ListItem>
                    <asp:ListItem Value="N">�_</asp:ListItem>
                  </asp:DropDownList>
                    </ContentTemplate>
                  </asp:UpdatePanel>                 
                <%--</td>
                Modify 20120716 By SS Gordon. Reason: �s�W�Ȧ�O.
                    <%--20221031 �אּ����
                <th>
                  �Ȧ�O
                </th>                
                <td colspan="3">--%>
                  <asp:DropDownList ID="drpBANKCD" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false" style="display:none">
                  </asp:DropDownList>
                <%--</td>
              </tr>--%>
              <%--<tr>
              <tr>
                  Modify 20130509 By SS Brent. Reason:�[�J���l���v�U�Կ��
                  <%--20221031 �אּ����
                <th>
                  ���l���v
                </th>
                <td colspan="2">--%>
                  <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                          <asp:DropDownList ID="drpRECOURSE" runat="server" class="bg_F5F8BE" style="display:none">
                              <asp:ListItem Value="">�п��</asp:ListItem>
                              <asp:ListItem Value="Y">�O</asp:ListItem>
                              <asp:ListItem Value="N">�_</asp:ListItem>
                          </asp:DropDownList>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                  <%--</td>
                      </tr>
                  <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O START-->
                  <!-- 20160321 ADD BY SS ADAM REASON.�s�W�ץ󲣫~�O END-->
                </tr>--%>
            </table>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <div>
                  <div >
                    <table class="tb_Info" cellpadding="1" cellspacing="1">
                      <tr>
                        <td colspan="5">
                          <asp:RadioButton ID="rdoMLDCASEINST" Enabled="false" runat="server" />����&#12289;����ץ�
                        </td>
                        <!--Modify 20130326 By SS Eric    Reason:�s�W�O�I���`���-->
                        <td colspan="1">
                            <!--Modify 20130819 By SS CHRIS FU  Reason:�s�W�O�I���`�ƥ�-->
                            <asp:CheckBox ID="txtNOINSURANCEFLG" Enabled="false" runat="server" OnCheckedChanged="txtNOINSURANCEFLG_CheckedChanged" AutoPostBack="true" />�O�I���`
                        </td>
                      </tr>
                      <tr>
                        <th width="20%">
                          �Ъ������B
                        </th>
                        <td width="12%">
                          <asp:TextBox ID="txtTRANSCOST" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_must_right" ReadOnly="true"></asp:TextBox>
                           <asp:HiddenField ID="hidTRANSCOST" Value='0' runat="server" />
                        </td>
                        <td colspan="2">
                            <span style="color:red">�Y�n���Ъ������B<br />�Цܡu�Ъ����v���Ҥ��վ�Ъ�������</span>
                        </td>
                        <th width="12%">
                            <!--Modify 20130819 By SS CHRIS FU  Reason:�s�W�O�I�O���s-->
                            <asp:Button ID="btINSURANCE" CssClass="btn_normal" runat="server" Text="..." OnClick="btINSURANCE_Click" Enabled="false" />
                          �O�I�O
                        </th>
                        <td>
                          <asp:TextBox ID="txtINSURANCE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" enabled="false"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          �Y����
                        </th>
                        <td>
                          <asp:TextBox ID="txtFIRSTPAY" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                          ����
                        </th>
                        <td>
                          <asp:TextBox ID="txtCOMMISSION" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>                          
                        </td>
                        <!--Modify 20120528 By SS Gordon. Reason: �ק�u�@�~�O�Ρv���u�@�~�O��(���o��)�v-->
                        <th>
                          �@�~�O��(���o��)
                        </th>
                        <td>
                          <asp:TextBox ID="txtOTHERFEES" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          ���ʫO�Ҫ�
                        </th>
                        <td>
                          <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                        </th>
                        <td>
                        </td>
                        <!--Modify 20120528 By SS Gordon. Reason: �[�J�u�@�~�O��(�L�o��)�v-->
                        <th>                          
                          �@�~�O��(�L�o��)
                        </th>
                        <td>
                          <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>                        
                        </td>
                      </tr>
                      <tr>
                        <th>
                          �i���O�Ҫ�
                        </th>
                        <td>
                          <asp:TextBox ID="txtPERBOND" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                          ��U���B
                        </th>
                        <td>
                          <asp:TextBox ID="txtACTUSLLOANS" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" ReadOnly="true" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                          <%--20221031�Ъ������B���Ū--%>
                            <asp:HiddenField ID="hidACTUSLLOANS" Value='0' runat="server" />
                        </td>
                        <th>
                          ����O���J
                        </th>
                        <td>
                          <asp:TextBox ID="txtFEE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <th>
                          �ݭ�
                        </th>
                        <td>
                          <asp:TextBox ID="txtRESIDUALS" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          �`�ӧ@���
                        </th>
                        <td>
                          <asp:TextBox ID="txtCONTRACTMONTH" onkeyup="txtCONTRACTMONTH_KeyUp(this);" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        </td>
                        <th>
                          �X��@�I
                        </th>
                        <td>
                          <asp:TextBox ID="txtPAYMONTH" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        </td>
                        <th>
                          �I�ڮɶ�
                        </th>
                        <td>
                          <asp:DropDownList ID="drpPAYTIMET" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" Width="80px">
                            <asp:ListItem>����I</asp:ListItem>
                            <asp:ListItem>�����I</asp:ListItem>
                          </asp:DropDownList>
                        </td>
                      </tr>
                      <tr>
                        <td colspan="6">
                          <table class="tb_grid" width="100%">
                            <tr>
                              <td width="13%">
                                �� &nbsp; 1 &nbsp; ��
                              </td>
                              <td width="15%">
                                - ��<asp:TextBox ID="txtENDPAY1" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td width="18%">
                                ���I��(���|)
                              </td>
                              <td width="18%">
                                <asp:TextBox ID="txtPRINCIPAL1" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX1');MoneyBlur(this);MoneyNull(this,'txtENDPAY1');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="70px"></asp:TextBox>
                              </td>
                              <td width="18%">
                                ���I��(�t�|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX1" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL1');MoneyBlur(this);MoneyNull(this,'txtENDPAY1');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="70px"> </asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                ��
                                <asp:TextBox ID="txtSTARTPAY2" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY1','txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                - ��<asp:TextBox ID="txtENDPAY2" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                ���I��(���|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX2');MoneyBlur(this);MoneyNull(this,'txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                ���I��(�t�|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL2');MoneyBlur(this);MoneyNull(this,'txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                ��
                                <asp:TextBox ID="txtSTARTPAY3" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY2','txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                - ��<asp:TextBox ID="txtENDPAY3" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                ���I��(���|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX3');MoneyBlur(this);MoneyNull(this,'txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                ���I��(�t�|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL3');MoneyBlur(this);MoneyNull(this,'txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                ��
                                <asp:TextBox ID="txtSTARTPAY4" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY3','txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                - ��<asp:TextBox ID="txtENDPAY4" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                ��
                              </td>
                              <td>
                                ���I��(���|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX4');MoneyBlur(this);MoneyNull(this,'txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                ���I��(�t�|)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL4');MoneyBlur(this);MoneyNull(this,'txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                      <tr>
                        <td colspan="6">&nbsp;</td>
                      </tr>
                    </table>
                  </div>
                    <%--20221031 �אּ����--%>
                  <%--<div class="right_div" style="height: 282px;">
                    <table cellpadding="1" cellspacing="1" class="tb_Info">--%>
<%--                      <tr>
                        <td colspan="2">--%>
                          <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" Visible="True" style="display:none" /><%--�����b�ڮץ�--%>
<%--                        </td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          �ӽ��B��
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtAPLIMIT" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          �x�H�O
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtCREDITFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          �b�Ⱥ޲z�O
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtMANAGERFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          �]���U�ݶO
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtFINANCIALFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <!--Modify 20120604 By SS Gordon. Reason: AR�s�W�i���O�Ҫ�-->
                      <%--<tr>
                        <th>
                          �i���O�Ҫ�
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtARPERBOND" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          ����
                        </th>--%>
                        <%--Modify 20150205 By SS ChrisFu. Reason:�u���ơv��TextBox�אּ�U�Կ��--%>
                        <td>
                          <%--<asp:TextBox ID="txtPERCENTAGE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>%--%>
                          <asp:DropDownList ID="drpPERCENTAGE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" CssClass="bg_F5F8BE" Width="80px" Height="25px" style="display:none"></asp:DropDownList><%--%--%>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          �b�ڴ���
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox><%--��--%>
                        <%--</td>
                      </tr>--%>
                      <%--<tr style="display: none">--%>
                      <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
<%--                        <th>
                          �I�ڮɶ�
                        </th>
                        <td>
                          <asp:DropDownList ID="drpPAYTIMEA" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" Width="80%">
                            <asp:ListItem>����I</asp:ListItem>
                            <asp:ListItem>�����I</asp:ListItem>
                          </asp:DropDownList>
                        </td>--%>
                        <%--<td>--%>
                          <asp:DropDownList ID="drpPAYTIMEA" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" Style="display: none" runat="server" Width="80%" >
                            <asp:ListItem>����I</asp:ListItem>
                            <asp:ListItem>�����I</asp:ListItem>
                          </asp:DropDownList>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          ��@�R�譭�B
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtBUYERLIMIT" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr style="display: none">--%>
                      <%--Modify 20150120 By SS Eric.   Reason:�u�I�ڮɶ��v.�u��ĳ�ӧ@IRR�v�]������--%>
<%--                        <th>
                          ��ĳ�ӧ@IRR
                        </th>
                        <td>
                          <asp:TextBox ID="txtARIRR" onkeypress="OnlyNumAndSpot(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_must_right"></asp:TextBox>%
                        </td>--%>
                        <%--<td>--%>
                          <asp:TextBox ID="txtARIRR" onkeypress="OnlyNumAndSpot(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="6" Style="display: none" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        <%--</td>--%>
                      <%--</tr>--%>
                      <%--Modify 20150205 By SS ChrisFu. Reason:�u��ĳ�Ԯ��ڡv�]�����áA�s�W�u��ĳ�Դڮ��v--%>
                      <%--<tr style="display: none">
                        <th>
                          ��ĳ�Ԯ���
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtINTERSET" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>
                      
                      <tr>
                          <th>��ĳ�Դڮ�</th>
                          <td>--%>
                              <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox><%--%--%>
                          <%--</td>
                      </tr>--%>
                   <%-- </table>
                  </div>--%>
                </div>
              </ContentTemplate>
            </asp:UpdatePanel>
            <%--Modify 20150205 By SS ChrisFu. Reason:�]�ӧ@���A�ܧ󬰡u�����b�ڨ����v�ɡA��줺�e�n����ʡA�G�[�WUpdatePanel--%>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div style="clear: both;">
              <table cellpadding="1" cellspacing="1" class="tb_Info">
                <tr>
                  <th>
                    �I�ڤ覡
                  </th>
                  <td colspan="2">
                    <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                    </asp:DropDownList>
                  </td>
                                                <th>��w�M��
                                                </th>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="drpPROJECT" DataTextField="PRONAME" DataValueField="PROJID" runat="server" OnSelectedIndexChanged="drpPROJECT_SelectedIndexChanged"  AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="hidPROJECT" DataTextField="PROJID" DataValueField="DISCAMT" runat="server" AutoPostBack="true" Style="display: none">
                                                    </asp:DropDownList>
                                                    <%--<asp:HiddenField ID="hidPROJECT" runat="server" Value="0" />--%>
                                                    <asp:Button ID="btnPROJECT" runat="server" CssClass="btn_normal" Text="�j�M" OnClick="btnPROJECT_Click" />
                                                </td>
                </tr>
                <tr>
                  <th>
                    �I�ڮt���Ѽ�
                  </th>
                  <td>
                    <asp:TextBox ID="txtPATDAYS" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" runat="server" MaxLength="4" Text="0" CssClass="txt_must_right"></asp:TextBox>
                  </td>
                  <th>
                    �I�����ӤѼ�
                  </th>
                  <td colspan="3">
                    <asp:TextBox ID="txtSUPPILERDAYS" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" MaxLength="4" Text="0" runat="server" CssClass="txt_must_right"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <th>
                    �w�p�����B�z�覡
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:DropDownList ID="drpEXPIREPROC" DataTextField="DNAME1" DataValueField="DCODE" runat="server">
                        </asp:DropDownList>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <!--Modify 20120528 By SS Gordon. Reason: ��ץ󤺮e��ñ�N�u�����v��쪺����W���ܧ󬰡u�ץ󻡩��v�A�ñN����ܧ󬰥i��J100�Ӥ���r-->
                  <!--Modify 20130117 By    SEAN.   Reason: ��ץ󤺮e��ñ�N�u�ץ󻡩��v��쪺����W���ܧ󬰡u�Ƶ��v-->
                  <th>
                    �Ƶ�
                  </th>
                  <td colspan="3">
                  <!--Modify 20130326 By SS Eric    Reason:�NtxtEXPIREPROCDESC�� MaxLength="100" onblur="CheckMLength(this,100,'����');"��100�令150-->
                    <asp:TextBox ID="txtEXPIREPROCDESC" MaxLength="150" onblur="CheckMLength(this,300,'����');" runat="server" CssClass="txt_normal" Style="width: 98%"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <th>
                    IRR
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelIRR" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtIRR" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                    <%--Modify 20161130 By SEAN. Reason: �s�WNPV0�PNPV�Q�v����0--%>
                    <%--20171012 ADD BY SS ADAM REASON.NPV�������(�אּ���4%) --%>
                    <th>
                    NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <%--<th>
                    NPV����
                  </th>--%>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"  style="display: none;"></asp:TextBox><%--%--%>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
                  
                <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                <tr style="display:none;">
                  <th>
                    �������
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelCAP" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtCAPITALCOST" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" runat="server" MaxLength="9" Text="7" ReadOnly="true" CssClass="txt_normal_right"></asp:TextBox>%
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <%--Modify 20141204 By SS Eric    Reason:�վ�uNPV�v.�uNPV�����v����m�ηs�W�uNPV2�v.�uNPV2�����v���--%>
                  <th>
                    �ĸ��NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV2" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV2" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <th>
                    �ĸ��NPV����
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC2" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST2" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
				
				
                <%--20170706 ADD BY SS ADAM REASON.���í쥻�]�ƥ�ĸ��NPV,NPV����  --%>
                <tr style="display:none;">
                  <th>
                  </th>
                  <td>
                  </td>
                  <%--Modify 20141204 By SS Eric    Reason:�վ�uNPV�v.�uNPV�����v����m�ηs�W�uNPV2�v.�uNPV2�����v���--%>
                  <th>
                    �]�ƥ�NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV0" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV0" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                        <asp:HiddenField ID="hidNPV0" runat="server" Value="" />
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <th>
                    �]�ƥ�NPV����
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC0" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST0" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                        <asp:HiddenField ID="hidNPVRATECOST0" runat="server" Value="" />
					  </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
				
                <tr>
                  <th style="display: none;">
                    RECOVER TEST
                  </th>
                  <td colspan="5" style="display: none;">
                    <asp:TextBox ID="txtRECOVERTEST" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text="0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td colspan="6" style="text-align: center; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:Button ID="btnIRR" runat="server" CssClass="btn_normal" Text="�պ�" OnClick="btnIRR_Click" />
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
              </table>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--�ץ�&#61136;�eEnd --%>
          <%--�Ъ���Begin --%>
          <div id="fraTab33" class="div_content T_-120" style="display: none">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:Button ID="btnMLDCASETARGETCopy" runat="server" OnClientClick="return btnMLDCASETARGETCopy_click();" CssClass="btn_normal" Text="�Ъ����ƻs" OnClick="btnMLDCASETARGETCopy_Click" />
                <asp:HiddenField ID="hidMLDCASETARGETCopy" runat="server" />
                <asp:HiddenField ID="hidTargetFile" runat="server" />
                <asp:FileUpload ID="fldMLDCASETARGETEmport" runat="server" />
                <asp:Button ID="btnMLDCASETARGETEmport" runat="server" CssClass="btn_normal" Text="�Ъ����פJ" OnClientClick="return CheckMLDCASETARGET();" OnClick="btnMLDCASETARGETEmport_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
              </ContentTemplate>
              <Triggers>
                <asp:PostBackTrigger ControlID="btnMLDCASETARGETEmport" />
              </Triggers>
            </asp:UpdatePanel>
            <div class="div_table" style="overflow: scroll; height: 200px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASETARGET" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASETARGET" class="tb_Contact" style="width: 1500px;">
                    <tr onclick="changeTag('rptMLDCASETARGET')">
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
                      <%--Modify 20131001 By SS Eric    Reason:�b�Ъ������Ҥ��A�Ъ�����GRID�W�[�s�y�t�ӡA�t�P�A���A�ƶq--%>
                      <th>
                        �s�y�t��
                      </th>
                      <th>
                        �t�P
                      </th>
                      <th>
                        ���
                      </th>
                      <th>
                        �ƶq
                      </th>
                      <th width="270px">
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
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpTARGETTYPE" onchange="drpTARGETTYPE_change(this);" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETNAME" Text='<%# Eval("TARGETNAME")%>' Width="120px" runat="server" CssClass="txt_must"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpTARGETSTATUS" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                              <asp:ListItem>�s��</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETMODELNO" onblur="CheckMLength(this,'50');" MaxLength="50" Text='<%# Eval("TARGETMODELNO")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETMACHINENO" onblur="CheckMLength(this,'20');" MaxLength="20" Text='<%# Eval("TARGETMACHINENO")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <%--Modify 20131001 By SS Eric    Reason:�b�Ъ������Ҥ��A�Ъ�����GRID�W�[�s�y�t�ӡA�t�P�A���A�ƶq--%>
                          <td>
                            <asp:TextBox ID="txtMANUFACTURER" Text='<%# Eval("MANUFACTURER")%>' runat="server" Width="160px" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETBRAND" Text='<%# Eval("TARGETBRAND")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETUNIT" Text='<%# Eval("TARGETUNIT")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETCOUNT" Text='<%# Eval("TARGETCOUNT")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSUPPLIERID" onkeypress="OnlyNumDUCase(this);" onblur="SUPPLIERID_onblur(this);" MaxLength="10" Text='<%# Eval("SUPPLIERID")%>' Width="80px" runat="server" CssClass="txt_must"></asp:TextBox>
                            <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" OnClientClick="return SupplierClick(this);" Style="padding: 2px; width: 25px;" runat="server" Text="&#8230;" />
                            <asp:TextBox ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' runat="server" Width="160px" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETPRICE" onkeypress="OnlyNum(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>' onfocus="MoneyFocus(this)" onblur="txtTARGETPRICE_onblur(this);txtTARGETPRICE_KeyUp(this);" runat="server" CssClass="txt_must_right"></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                            <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>' onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server"></asp:Label>
                          </td>
                          <td>
                            <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                          </td>
                          
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:CheckBox ID="chkAr" Enabled="false" runat="server" style="display:none" />
                  <%--20221031 �אּ����--%>
<%--                AR�ץ�L�Ъ���&nbsp;&nbsp;&nbsp;--%>
                <%--Modify 20120717 By SS Gordon. Reason: �s�W�Ȧ��L�Ъ������Ŀ�϶�.--%>
                <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" style="display:none" />
<%--                �Ȧ�ץ�L�Ъ���--%>
              </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            �]�Ʀs��a &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <br />
            <div class="div_table" style="overflow: scroll; height: 200px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASETARGETSTR" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table class="tb_Contact" style="width: 1200px;">
                    <tr onclick="changeTag('rptMLDCASETARGET')">
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
                      <th>
                        �Ъ�������
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOREDZIPCODE" onkeypress="OnlyNum(this);" MaxLength="6" runat="server" Width="24px" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("STOREDZIPCODE")%>'></asp:TextBox>
                            <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtSTOREDZIPCODES" runat="server" Width="112px" CssClass="txt_table" onfocus="ObjMFocus(this,'txtSTOREDZIPCODES','txtSTOREDADDR');" Text='<%# Eval("STOREDZIPCODES")%>'></asp:TextBox>
                            <asp:TextBox ID="txtSTOREDADDR" runat="server" CssClass="txt_table" Width="150px" MaxLength="100" Text='<%# Eval("STOREDADDR")%>'></asp:TextBox>
                            <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTNAME" MaxLength="10" Text='<%# Eval("CONTACTNAME")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:Button ID="btnCONTACT" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnCONTACT','txtDEPTNAME');" OnClientClick="return btnCONTACT_click(this);" Style="padding: 2px; width: 25px;" runat="server" Text="&#8230;" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPTNAME" MaxLength="50" Text='<%# Eval("DEPTNAME")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTTITLE" MaxLength="20" Text='<%# Eval("CONTACTTITLE")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTTELCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="3" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' CssClass="txt_table" />
                            <asp:TextBox ID="txtCONTACTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTTEL")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:TextBox ID="txtCONTACTTELEXT" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="5" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' CssClass="txt_table" Width="40px" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTMPHONE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTMPHONE")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTFAXCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="3" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>' CssClass="txt_table" />
                            <asp:TextBox ID="txtCONTACTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTFAX")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTEMAIL" onblur="EMAILBlur(this);" MaxLength="50" Text='<%# Eval("CONTACTEMAIL")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpMLDCASETARGET" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:CheckBox ID="chkOneMLDCASETARGETSTR" Checked="false" AutoPostBack="true" runat="server" OnCheckedChanged="chkOneMLDCASETARGETSTR_CheckedChanged" />
                �Ъ����s��a�Ȥ@�B
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--�Ъ���End --%>
          <%--��O����Begin --%>
          <div id="fraTab44" class="div_content T_-120" style="min-height: 730px; height: auto !important; display: none">
            �O�ҤH<asp:CheckBox ID="chkMLDCASEGUARANTEE" runat="server" Checked="true" />
            ���׵L�O�ҤH &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEGUARANTEE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEGUARANTEE" class="tb_Contact" style="width: 2400px;">
                    <tr onclick="changeTag('rptMLDCASEGUARANTEE')">
                      <th>
                        �k�H/�ӤH
                      </th>
                      <th>
                        �W��
                      </th>
                      <th>
                        ID
                      </th>
                      <th>
                        ñ�q�j����
                      </th>
                      <th>
                        ��������
                      </th>
                      <th>
                        <%--20230523�������B��O�H��O���B--%>
                        <%--�������B--%>
                          �O�H��O���B
                      </th>
                      <%--Modify 20120531 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                      <th>
                        �ͤ�
                      </th>
                      <th>
                        �ʧO
                      </th>
                      <th>
                        ���y�a�}/���q�n�O�a�}
                      </th>
                      <th>
                        �q�T�a�}
                      </th>
                      <th>
                        �p���q��
                      </th>
                      <th>
                        ���Y�H�@
                      </th>
                      <th>
                        ���Y�H�G
                      </th>
                      <th>
                        ¾�~����
                      </th>
                      <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                      <th>
                        ¾�~
                      </th>
                      <th>
                        ��¾���q
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEGUARANTEE','<%# Container.ItemIndex  %>')">
                          <td>
                            <%--Modify 20121112 By SS Steven. Reason: �n���O�H����ɡA�t�Ψ̭ӤH�Ϊk�H�P�O�A�D���n���n������H�Ϧǧe�{--%>
                            <%--<asp:DropDownList ID="drpGRTTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" onchange="CboChanged(this);" runat="server" Width="80%">--%>
                            <asp:DropDownList ID="drpGRTTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" onchange="CboChanged(this);" runat="server" Width="80%" OnSelectedIndexChanged="drpGRTTYPE_SelectedIndexChanged" AutoPostBack="true">
                              <asp:ListItem>�k�H</asp:ListItem>
                              <asp:ListItem>�ӤH</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hidGRTID" Value='<%# Eval("GRTID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' MaxLength="20" runat="server" CssClass="txt_must_table" Width="80"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);" runat="server" CssClass="txt_must_table" Width="80"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpGUARANTEEBILL" runat="server" Width="80%">
                              <asp:ListItem Value="1">�O</asp:ListItem>
                              <asp:ListItem Value="2">�_</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpGUARANTEEBILLTYPE" runat="server" Width="80%">
                              <asp:ListItem Value="1">����</asp:ListItem>
                              <asp:ListItem Value="2">�䲼</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>' MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <%--Modify 20120531 By SS Gordon. Reason: �O�ҤH�X���G�ͤ�B�ʧO�B�P�Ӥ����Y�B���y�a�}�B�q�T�a�}�B�p���q�ܡB¾�~�B��¾���q--%>
                          <td>
                            <asp:TextBox ID="txtGRTBIRDT" Text='<%# Eval("GRTBIRDT") %>' runat="server"  Width="80px"  CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTSEX" runat="server"  Width="50px">
                                <asp:ListItem Value="">�п��</asp:ListItem>
                                <asp:ListItem Value="1">�k</asp:ListItem>
                                <asp:ListItem Value="2">�k</asp:ListItem>                          
                              </asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTRESIDENTZIP" Text='<%# Eval("GRTRESIDENTZIP") %>' runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                              <input type="button" id="btnGRTRESIDENTZIP" class="btn_normal" onclick="PostCodeClick(this);" runat="server" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                              <asp:TextBox ID="txtGRTRESIDENTZIPNM" Text='<%# Eval("GRTRESIDENTZIPNM") %>' runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');" CssClass="txt_table"></asp:TextBox>
                              <asp:TextBox ID="txtGRTRESIDENTADDR" Text='<%# Eval("GRTRESIDENTADDR") %>' runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');" MaxLength="100"></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTZIP" Text='<%# Eval("GRTZIP") %>' runat="server"  Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                              <input type="button" id="btnGRTZIP" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                              <asp:TextBox ID="txtGRTZIPNM" Text='<%# Eval("GRTZIPNM") %>' runat="server"  Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table"></asp:TextBox>
                              <asp:TextBox ID="txtGRTADDR" Text='<%# Eval("GRTADDR") %>' runat="server"  Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','�o���H�e�a');" MaxLength="100"></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTTELCODE" Text='<%# Eval("GRTTELCODE") %>' runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>                              
                              <asp:TextBox ID="txtGRTTEL" Text='<%# Eval("GRTTEL") %>' runat="server" Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                              <asp:TextBox ID="txtGRTTELEXT" Text='<%# Eval("GRTTELEXT") %>' runat="server" Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTRELATION1" runat="server" Width="180px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTRELATION2" runat="server" Width="105px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTJOBCLS" runat="server" Width="160px" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpGRTJOBCLS_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          </td>
                          <%--Modify 20120224 By SS Gordon. Reason: �s�WNPV�Q�v�����P�O�ҤH¾�~. --%>
                          <td>
                            <asp:DropDownList ID="drpGRTJOB" runat="server" Width="220px" DataTextField="DNAME1" DataValueField="DCODE">
                              <asp:ListItem Value="">�D��v</asp:ListItem>
                              <asp:ListItem Value="01">��v</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTCOMPANY" Text='<%# Eval("GRTCOMPANY") %>' runat="server" Width="200px" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            �ʲ��]�w<asp:CheckBox ID="chkMLDCASEMOVABLE" runat="server" Checked="true" />
            ���׵L�ʲ��]�w &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEMOVABLE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEMOVABLE" class="tb_Contact" style="width: 1200px;">
                    <tr onclick="changeTag('rptMLDCASEMOVABLE')">
                      <th>
                        ����
                      </th>
                      <th>
                        �ƻs
                      </th>                        
                      <th>
                        ���~�]��
                      </th>
                      <th>
                        ���׼Ъ�
                      </th>
                      <th>
                        �Ҧb�a
                      </th>
                      <th>
                        �����Ǹ�
                      </th>
                      <th>
                        �X���~��
                      </th>
                      <th>
                        �ʶR���
                      </th>
                      <th>
                        �s�~���B
                      </th>
                      <th>
                        �ʶR���B
                      </th>
                      <th>
                        �ݭȹw��
                      </th>
                      <th>
                        �]�w���B
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEMOVABLE" runat="server" OnItemCommand="MLDCASEMOVABLE_ItemCommand">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
							<%# Container.ItemIndex +1 %>
                            
                          </td>
                          <td>
                              <asp:Button ID="btnCOPY1" runat="server" Text="�ƻs" CommandName="CopyRowData1" CommandArgument='<%# Container.ItemIndex  %>' />
                          </td>                            
                          <td>
                            <asp:TextBox ID="txtMOVABLENAME" Text='<%# Eval("MOVABLENAME")%>' MaxLength="20" onblur="CheckMLength(this,'20');" runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:HiddenField ID="hidMOVABLEID" Value='<%# Eval("MOVABLEID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:DropDownList ID="drpMOVABLEETARGET" runat="server" Width="60px">
                              <asp:ListItem Value="1">�O</asp:ListItem>
                              <asp:ListItem Value="2">�_</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEZIPCODE" runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODE")%>'></asp:TextBox>
                            <input type="button" id="btnMOVABLEZIPCODE" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtMOVABLEZIPCODES" onfocus="ObjMFocus(this,'txtMOVABLEZIPCODES','txtMOVABLEADDR');" runat="server" Width="112px" CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'></asp:TextBox>
                            
							<%-- 2013/09/13 Edit by Sean �ʲ��]�w�Ҧb�a���i��J50�Ӥ���r --%>
                            <%--<asp:TextBox ID="txtMOVABLEADDR" runat="server" CssClass="txt_table" MaxLength="20" Width="150px" onblur="CheckMLength(this,'20');" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>--%>
                            <asp:TextBox ID="txtMOVABLEADDR" runat="server" CssClass="txt_table" MaxLength="50" Width="150px" onblur="CheckMLength(this,'100');" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>
							
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLENO" Text='<%# Eval("MOVABLENO")%>' runat="server" MaxLength="20" onblur="CheckMLength(this,'20');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEYEAR" Text='<%# Eval("MOVABLEYEAR") %>' runat="server" MaxLength="4" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEBUYDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLENEWAMT" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEBUYAMT" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLERESIDUALS" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLERESETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            ���ʲ��]�w<asp:CheckBox ID="chkMLDCASEIMMOVABLE" runat="server" Checked="true" />
            ���׵L���ʲ��]�w &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEIMMOVABLE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEIMMOVABLE" class="tb_Contact" width="1150px" border="1">
                    <tr onclick="changeTag('rptMLDCASEIMMOVABLE')">
                      <th>
                        ����
                      </th>
                      <th>
                        �ƻs
                      </th>                       
                      <th>
                        �Ҧ��H
                      </th>
                      <th>
                        ID
                      </th>
                      <th>
                        ���o�ɶ�
                      </th>
                      <th>
                        �ت�������
                      </th>
                      <th>
                        �g�a�a�q
                      </th>
                      <th>
                        �a��
                      </th>
                      <th>
                        �g�a���n
                      </th>
                      <th>
                        �������n
                      </th>
                      <th>
                        �ظ�
                      </th>
                      <th>
                        ���P���X
                      </th>
                      <th>
                        �ؿv�`���n(���褽��)
                      </th>
                      <th>
                        �ؿv�`���n(�W)
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEIMMOVABLE" runat="server" OnItemCommand="MLDCASEIMMOVABLE_ItemCommand">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEIMMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
							<%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                              <asp:Button ID="btnCOPY2" runat="server" Text="�ƻs" CommandName="CopyRowData2" CommandArgument='<%# Container.ItemIndex  %>' />
                          </td>                           
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEOWNER" Text='<%# Eval("IMMOVABLEOWNER")%>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <asp:HiddenField ID="hidIMMOVABLEID" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                          <td>
                            
							<%-- 20131212 Edit by Sean �s�W�νs��ID�P�_ --%>
                            <asp:TextBox ID="txtIMMOVABLEOWNERID" Text='<%# Eval("IMMOVABLEOWNERID")%>' onkeypress="OnlyNumD(this);" onblur="idAndBANBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                            <%-- <asp:TextBox ID="txtIMMOVABLEOWNERID" Text='<%# Eval("IMMOVABLEOWNERID")%>' onkeypress="OnlyNumD(this);" onblur="idBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox> --%>
						  
						  </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEGETDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLESECTOR" Text='<%# Eval("IMMOVABLESECTOR")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILD" Text='<%# Eval("IMMOVABLEBUILD")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEAREA" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" Text='<%# Eval("IMMOVABLEAREA")%>' runat="server" MaxLength="10" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEHOLDER" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" Text='<%# Eval("IMMOVABLEHOLDER")%>' runat="server" MaxLength="10" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDNO" Text='<%# Eval("IMMOVABLEBUILDNO")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM" Text='<%# Eval("IMMOVABLEHOUSENUM")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA" onkeypress="OnlyNumAndSpot(this);" Text='<%# Eval("IMMOVABLEBUILDAREA")%>' MaxLength="8" onblur="areacon(this)" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                            <asp:Label ID="lblIMMOVABLEBUILDAREA" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>' runat="server"></asp:Label>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDHUMANRIGHTS" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <%--Modify 20130425 By SS Steven. Reason: ��O���󪺤��ʲ��v�Q�H��������ˮ�--%>
                  <%--<table class="tb_Contact" border="1">--%>
                  <table id="tblMLDHUMANRIGHTS" class="tb_Contact" border="1">
                    <tr onclick="changeTag('rptMLDCASEIMMOVABLE')">
                      <th>
                        ����
                      </th>
                      <th>
                        �v�Q�H
                      </th>
                      <th>
                        �n�O���
                      </th>
                      <th>
                        �]�w���B
                      </th>
                      <th>
                        ���v�H
                      </th>
                      <th>
                        ���ʲ�����]�w
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDHUMANRIGHTS" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEIMMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:TextBox ID="txtHUMANRIGHTS" Text='<%# Eval("HUMANRIGHTS") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtREGISTDATE" onkeypress="OnlyNum(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>' MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSETPRICE" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>' runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCREDITOR" Text='<%# Eval("CREDITOR") %>' runat="server" MaxLength="10" onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <!--<asp:DropDownList ID="drpMLDCASEIMMOVABLE" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>-->
							<asp:TextBox ID="txtMLDCASEIMMOVABLE" runat="server" MaxLength="2" Width="24px" onkeypress="OnlyNum(this);"  CssClass="txt_table" Text='<%# Eval("IDMEMO") %>' />
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            �w�s����<asp:CheckBox ID="chkMLDCASEADEPOSIT" runat="server" Checked="true" />
            ���׵L�w�s��]�w &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEADEPOSIT" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEADEPOSIT" class="tb_Contact" width="90%">
                    <tr onclick="changeTag('rptMLDCASEADEPOSIT')">
                      <th>
                        �Ȧ�
                      </th>
                      <th>
                        �w�s�渹
                      </th>
                      <th>
                        ���B
                      </th>
                      <th>
                        �w�s�_��
                      </th>
                      <th>
                        �w�s�W��
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEADEPOSIT" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEADEPOSIT','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtDEPOSITBANKS" onfocus="this.parentNode.childNodes[2].focus()" CssClass="txt_normal" Text='<%# Eval("DEPOSITBANKS") %>' Width="240px" runat="server"></asp:TextBox>
                            <input type="button" id="Button9" class="btn_normal" onclick="BankClick(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtDEPOSITBANK" Style="display: none" Text='<%# Eval("DEPOSITBANK") %>' Width="427px" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidDEPOSITID" Value='<%# Eval("DEPOSITID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITNBR" Text='<%# Eval("DEPOSITNBR") %>' onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);" Width="120px" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITAMT" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>' runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITSTARTDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITDUEDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            �Ȳ�<asp:CheckBox ID="chkMLDCASEBILLNOTE" runat="server" Checked="true" />
            ���׵L�Ȳ� &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEBILLNOTE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEBILLNOTE" class="tb_Contact" width="140%">
                    <tr onclick="changeTag('rptMLDCASEBILLNOTE')">
                      <th>
                        ���ڨ����
                      </th>
                      <th>
                        �I�ڦ�w��
                      </th>
                      <th>
                        ���ں���
                      </th>
                      <th>
                        ���ڸ��X
                      </th>
                      <th>
                        �b��
                      </th>
                      <th>
                        �o���H�W��
                      </th>
                      <th>
                        �������B
                      </th>
                      <th>
                        �Ƶ�
                      </th>
                      <th>
                        �ٲ���
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEBILLNOTE" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEBILLNOTE','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtBILLNOTEDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" MaxLength="8" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" onfocus="this.parentNode.childNodes[2].focus()" Text='<%# Eval("BILLNOTEBANKS") %>' Width="240px" runat="server"></asp:TextBox>
                            <input type="button" id="Button9" class="btn_normal" onclick="BankClick(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtBILLNOTEBANK" Style="display: none" Text='<%# Eval("BILLNOTEBANK") %>' Width="427px" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:DropDownList ID="drpBILLNOTETYPE" runat="server" Width="60px">
                              <asp:ListItem Value="1">����</asp:ListItem>
                              <asp:ListItem Value="2">�䲼</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTENBR" Text='<%# Eval("BILLNOTENBR") %>' MaxLength="20" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtACCOUNT" Text='<%# Eval("ACCOUNT") %>' onkeypress="OnlyNum(this);" Width="128px" onblur="OnlyNumBlur(this);" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTECUSTNAME" Text='<%# Eval("BILLNOTECUSTNAME") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEAMT" Text='<%#  Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString())  %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTENOTE" Text='<%# Eval("BILLNOTENOTE") %>' runat="server" MaxLength="50" onblur="CheckMLength(this,'50');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEBACKDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            �Ѳ�<asp:CheckBox ID="chkMLDCASESTOCK" runat="server" Checked="true" />
            ���׵L�Ѳ� &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ �s�W�Ы�F8&nbsp;&nbsp;&nbsp;�R���Ы�F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASESTOCK" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASESTOCK" class="tb_Contact" width="100%">
                    <tr onclick="changeTag('rptMLDCASESTOCK')">
                      <th width="10%">
                        �]�w���
                      </th>
                      <th width="10%">
                        �Ѳ��W��
                      </th>
                      <th width="10%">
                        ���ѤH
                      </th>
                      <th width="10%">
                        ���(��)
                      </th>
                      <th width="10%">
                        �i��
                      </th>
                      <th width="10%">
                        �`��(��)
                      </th>
                      <th width="10%">
                        �}�l��
                      </th>
                      <th width="10%">
                        �I�
                      </th>
                      <th width="10%">
                        �O�I�c
                      </th>
                      <th width="10%">
                        �Ƶ�
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASESTOCK" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASESTOCK','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtSTOCKDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>' MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:HiddenField ID="hidSTOCKID" Value='<%# Eval("STOCKID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKNAME" Text='<%# Eval("STOCKNAME") %>' onblur="CheckMLength(this,'20');" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKPROVIDER" Text='<%# Eval("STOCKPROVIDER") %>' MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKUNIT" Text='<%# Eval("STOCKUNIT") %>' MaxLength="20" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKQUANTITY" onkeypress="OnlyNum(this);" Text='<%# Eval("STOCKQUANTITY") %>' MaxLength="9" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKTOTAL" onkeypress="OnlyNum(this);" Text='<%# Eval("STOCKTOTAL") %>' MaxLength="9" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKBEGIN" Text='<%# Eval("STOCKBEGIN") %>' runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKEND" Text='<%# Eval("STOCKEND") %>' runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpSTOCKINSURANCE" runat="server" Width="60px">
                              <asp:ListItem Value="1">���O</asp:ListItem>
                              <asp:ListItem Value="2">����</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKNOTE" Text='<%# Eval("STOCKNOTE") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            ��L<br />
            <asp:TextBox ID="txtOTHERCOND" MaxLength="100" onblur="CheckMLength(this,'100','��L');" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </div>
          <%--��O����End --%>
          <%--�x�f���Begin --%>
          <div id="fraTab55" class="div_content T_-120" style="display: none">
            <asp:UpdatePanel ID="UpdatePanelMLDCASEAPPENDDOC" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <table id="tblMLDCASEAPPENDDOC" class="tb_Text" width="98%">
                  <tr>
                    <th width="5%">
                      ����
                    </th>
                    <th width="52%">
                      ���
                    </th>
                    <th width="15%">
                      ���Ƥ��
                    </th>
                    <th width="15%">
                      �i���ƽT�{
                    </th>
                    <th>
                      ����
                    </th>
                  </tr>
                  <asp:Repeater ID="rptMLDCASEAPPENDDOC" runat="server">
                    <ItemTemplate>
                      <tr>
                        <td>
                          <%# Container.ItemIndex +1 %>
                        </td>
                        <td>
                          <asp:Label ID="lblDocName" runat="server" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' Text='<%# Eval("DNAME1")%>'></asp:Label>
<%--                          <asp:DropDownList ID="drpDocName" AutoPostBack="true" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged" Visible='<%# !Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Width="100%">
                          </asp:DropDownList>--%>
                          <asp:HiddenField ID="hidAPPENDDOCID" Value='<%# Eval("APPENDDOCID") %>' runat="server" />
                          <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                        </td>
                        <td>
                          <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                        </td>
                        <td>
                          <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>' runat="server" Visible="true" />
                        </td>
                        <td>
                          <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,'50');" Text='<%# Eval("NOTE") %>' runat="server" CssClass="txt_table" Width="100px" Visible="true"></asp:TextBox>
                        </td>
                      </tr>
                    </ItemTemplate>
                  </asp:Repeater>

                  <asp:Repeater ID="rptMLDCASEAPPENDDOC1" runat="server">
                    <ItemTemplate>
                      <tr>
                        <td>
                          <%# Container.ItemIndex +1 %>
                        </td>
                        <td>
                          <asp:Label ID="lblDocName" runat="server" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' Text='<%# Eval("DNAME1")%>'></asp:Label>
<%--                          <asp:DropDownList ID="drpDocName" AutoPostBack="true" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged" Visible='<%# !Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Width="100%">
                          </asp:DropDownList>--%>
                          <asp:HiddenField ID="hidAPPENDDOCID" Value='<%# Eval("APPENDDOCID") %>' runat="server" />
                          <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                        </td>
                        <td>
                          <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                        </td>
                        <td>
                          <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>' runat="server" style="display:none" />
                        </td>
                        <td>
                          <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,'50');" Text='<%# Eval("NOTE") %>' runat="server" CssClass="txt_table" Width="100px" style="display:none"></asp:TextBox>
                        </td>
                      </tr>
                    </ItemTemplate>
                  </asp:Repeater>

                </table>
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--�x�f���End --%>
          <%--�ץ���iBegin --%>
          <div id="fraTab77" class="div_content T_-120" style="display: none">
            <!-- 20161229 ADD BY SS ADAM REASON.�אּ�i���ơA�W�ǼW�[��4�� -->
            <%--<asp:Button ID="btnUpload" OnClientClick="addFile();return false;" runat="server" CssClass="btn_normal" Text="���[�ɮ�" />--%>
            <asp:Button ID="btnUpload" OnClientClick="addFile('1');return false;" runat="server" CssClass="btn_normal" Text="�i����1" />
            <asp:TextBox ID="txtFileName" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID" runat="server" Value="" />
            <%--<asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="���i�U��" />--%>
            <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="�ɮפU��" /> 
            <br />
            <asp:Button ID="btnUpload2" OnClientClick="addFile('2');return false;" runat="server" CssClass="btn_normal" Text="�i����2" />
            <asp:TextBox ID="txtFileName2" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID2" runat="server" Value="" />
            <asp:Button ID="btnOnload2" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="�ɮפU��" /> 
            <br />
            <asp:Button ID="btnUpload3" OnClientClick="addFile('3');return false;" runat="server" CssClass="btn_normal" Text="�i����3" />
            <asp:TextBox ID="txtFileName3" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID3" runat="server" Value="" />
            <asp:Button ID="btnOnload3" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="�ɮפU��" /> 
            <br />
            <asp:Button ID="btnUpload4" OnClientClick="addFile('4');return false;" runat="server" CssClass="btn_normal" Text="�i����4" />
            <asp:TextBox ID="txtFileName4" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID4" runat="server" Value="" />
            <asp:Button ID="btnOnload4" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="�ɮפU��" /> 
          </div>
          <%--�ץ���iEnd --%>
          <%--���Ӭd��Begin --%>
          <div id="fraTab66" class="div_content T_-120" style="display: none">
            <div class="div_table" style="overflow: scroll; height: 500px">
              <asp:UpdatePanel ID="UpdatePanelrptData" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table width="900px" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
                    <tr>
                      <th>
                        ����
                      </th>
                      <th>
                        �X���s��
                      </th>
                      <th>
                        ����/�ӧ@�Ъ�
                      </th>
                      <th>
                        �O�Ҫ�
                      </th>
                      <th>
                        ��ú�`���B
                      </th>
                      <th>
                        ����������`�B
                      </th>
                      <th>
                        ����
                      </th>
                      <th>
                        �wú����
                      </th>
                      <th>
                        �wú���B�`�B
                      </th>
                    </tr>
                    <asp:Repeater ID="rptData" runat="server">
                      <ItemTemplate>
                        <tr>
                          <td>
                            <%#Eval("CTYPE")%>
                          </td>
                          <td>
                            <%#Eval("CNTRNO")%>
                          </td>
                          <td>
                            <%#Eval("TNAME")%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("GUARAMT").ToString())%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("ACTUSLLOANS").ToString())%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTN").ToString())%>
                          </td>
                          <td>
                            <%#Eval("CONTRACTMONTH")%>
                          </td>
                          <td>
                            <%#Eval("CONTRACTMONTHY")%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTY").ToString())%>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
          </div>
          <%--���Ӭd��End --%>
        </div>
        <div class="btn_div">
          <asp:Button ID="cmdPrintReportA" runat="server" Text="�C�L�֭��" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrintA_onClick(this);" Width="90" />
          <asp:Button ID="btnSave" Enabled="false" runat="server" Text="�Ȧs" CssClass="btn_normal" OnClick="btnSave_Click" />
          <asp:Button ID="btnSubmit" Enabled="false" runat="server" Text="�@�~�T�{" CssClass="btn_normal" OnClick="btnSubmit_Click" />
          <!--Modify 20120607 By SS Gordon. Reason: �s�W�ץ�M����s.-->
          <asp:Button ID="btnRej" Enabled="false" runat="server" Text="�ץ�M��" CssClass="btn_normal" OnClick="btnRej_Click" />

          <asp:Button ID="btnAddCon" Style="display: none" runat="server" Text="" OnClick="btnAddCon_Click" />
          <asp:Button ID="btnDelCon" Style="display: none" runat="server" Text="" OnClick="btnDelCon_Click" />
          <asp:DropDownList ID="droDocMain" runat="server" Style="display: none" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged">
          </asp:DropDownList>
          <asp:DropDownList ID="droIMMOVABLEID" runat="server" Style="display: none" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged">
          </asp:DropDownList>
          <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
          <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
          <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
          <%--Modify 20120621 By SS Gordon. Reason: �s�W�������H�x�s�ץ��ƨѭק�᪺�ˮ� --%>
          <asp:HiddenField ID="hidPreTRANSCOST" runat="server" Value="" />
          <asp:HiddenField ID="hidPreCONTRACTMONTH" runat="server" Value="" />
          <asp:HiddenField ID="hidPreAPLIMIT" runat="server" Value="" />
          <asp:HiddenField ID="hidPrePERCENTAGE" runat="server" Value="" />
          <asp:HiddenField ID="hidPreACCOUNTSTERM" runat="server" Value="" />
          <asp:HiddenField ID="hidPreBUYERLIMIT" runat="server" Value="" />
          <asp:HiddenField ID="hidPreARIRR" runat="server" Value="" />
          <%--Modify 20121112 By SS Steven. Reason: �s�W�������Ӱ��P�_--%>
          <asp:HiddenField ID="hidCheckCONTRACTMONTH" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckTRANSCOST" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckIRR" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckARIRR" runat="server" Value="" />
			<%--Modify 20130528 BY SEAN. Reason: �ק�{�b����s�ɪ�����A�u�Ъ������B�p��ε����ת��Ъ������B�v���u��U���B�n�p��ε����ת���U���B�v--%>
          <asp:HiddenField ID="hidCheckACTUSLLOANS" runat="server" Value="" />
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
