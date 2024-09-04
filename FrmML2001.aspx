<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001.aspx.cs" Inherits="FrmML2001" %>

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

  <script language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>
  <script type="text/javascript">
    <!-- #Include file='js/ML2001.js' -->                   
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
      <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: fixed; top: 0px;
        height: 100%">
        <table width="100%" height="100%">
          <tr>
            <td>
              <table width="250" height="60" align="center" bgcolor="#F7F7F7" style="border: 1px solid #A6C4E1;
                font: 12px">
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
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
    <ContentTemplate>
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
        <div class="div_Info H_175">
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
              <th class="align_right" width="20%">
                ���q�O�G
              </th>
              <td width="30%">
                <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
                  <asp:ListItem>�п��</asp:ListItem>
                </asp:DropDownList>
              </td>
              <th >
                �x�f���G
              </th>
              <td>
                <asp:DropDownList ID="drpCreditChecking" runat="server" Width="80%">
                    <%-- 20231130ADD��~���ۼf�y�{ --%>
<%--                  <asp:ListItem Value="">����</asp:ListItem>
                  <asp:ListItem Value="AI00">�ȪA�f�֥�</asp:ListItem>
                  <asp:ListItem Value="A">��~���ۼf��</asp:ListItem>--%>
                </asp:DropDownList>
              </td>         
            </tr>
            <tr>
              <th class="align_right">
                �ץ�s���G
              </th>
              <td>
                <asp:TextBox ID="txtCaseID" MaxLength="12" onkeypress="OnlyNumDUCase(this);" runat="server"
                  CssClass="txt_normal" Width="120px"></asp:TextBox>
              </td>     
              <th >
                �����O�G
              </th>
              <td>
                <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
                </asp:DropDownList>
              </td>         
            </tr>
           
            <tr>
              <th class="align_right">
                �i��֭��_���G
              </th>
              <td >
                <asp:TextBox ID="txtStartDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtEndDate" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
                �x�H���p�G
              </th>
              <td>
                <asp:DropDownList ID="drpCreditType" runat="server" Width="80%">
                  <asp:ListItem Value="N">���x�H</asp:ListItem>
                  <asp:ListItem Value="Y">�w�x�H</asp:ListItem>
                  <asp:ListItem Value="W">���Ю�</asp:ListItem>
                  <asp:ListItem Value="S">�Ю֧���</asp:ListItem>
                <%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�| --%>
                  <asp:ListItem Value="T">�ݩ�f</asp:ListItem>
                  <asp:ListItem Value="G">�f�d�|����</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                �Ю֭֮��_���G
              </th>
              <td >
                <asp:TextBox ID="txtReviewDTS" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                   runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtReviewDTE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                   runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
              </th>
              <td>
              </td>
            </tr>
              <%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�| START--%>
            <tr>
              <th class="align_right">
                �f�d�|�֭��_���G
              </th>
              <td >
                <asp:TextBox ID="txtEXAMDT1" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                   runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtEXAMDT2" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                   runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
              </th>
              <td>
              </td>
            </tr><%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�| END --%>
             <tr>
              <th class="align_right">
                �Ȥ�νs�G
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);GetCustName(this);"
                  runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                <input type="button" id="Button5" class="btn_normal" onclick="CustomerClick();" style="width: 25px;
                  padding: 2px;" value="&#8230;" />
              </td>
            </tr>
            <tr>
              <th colspan="4" style="text-align: center; height: 30px;">
                <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClick="cmdQuery_Click" />
                <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);"
                  value="�M��" />
              </th>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow: auto; margin: 10px; margin-top:20px;">
          <%--<table cellpadding="0" cellspacing="0" class="tab_result" width="1200px" style="margin:4px;">--%>
          <asp:UpdatePanel ID="UpdatePanelDate" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <table cellpadding="0" cellspacing="0" class="tab_result" width="210%" style="margin: 4px;">
                <tr>
                    <%-- 20170104 ADD BY SS ADAM REASON.�W�[�ץ���i�A�åB���|����첾��̫e�� --%>
                    <th>

                    </th>
                    <th>
                    �i�}
                  </th>
                  <th>
                    �ץ�s��
                  </th>
                  <th>
                    �Ȥ�W��
                  </th>
                  <th>
                    �֭�
                  </th>
                  <th>
                    ������
                  </th>
                  <th>
                    ����
                  </th>
                  <th>
                    �h��
                  </th>
                  <th>
                    ��
                  </th>
                  <th>
                    ���Ю�
                  </th>
                  <th>
                    �Ю֧���
                  </th>
                  <%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�|  --%>
                    <th>
                        �ݩ�f
                    </th>
                    <th>
                        �f�d�|����
                    </th>
                  <%-- 20170104 ADD BY SS ADAM REASON.�W�[�ץ���i�A�åB���|����첾��̫e��
                  <th>
                    �i�}
                  </th>
                  <th>
                    �ץ�s��
                  </th>
                  <th>
                    �Ȥ�W��
                  </th>--%>
                  <th>
                    �ӧ@����
                  </th>
                  <th>
                    �ӧ@�~�N
                  </th>
                  <th>
                    �ӧ@����
                  </th>
                  <th>
                    ������A
                  </th>
                  <th>
                    �ʥα���
                  </th>
                  <th>
                    �ӧ@���B
                  </th>
                  <th>
                    ����
                  </th>
                  <th>
                    IRR
                  </th>
                  <th>
                    �i����
                  </th>
                  <th>
                    �i��֭���
                  </th>
                </tr>
                <asp:Repeater ID="rptData" runat="server">
                  <ItemTemplate>
                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                        <%-- 20170104 ADD BY SS ADAM REASON.�W�[�ץ���i�A�åB���|����첾��̫e�� --%>
                        <td>
                            <asp:Button ID="btnREPORT" CssClass="btn_normal" runat="server" Text="�ץ���i" Width="100px" OnClientClick='<%# String.Format("return ReportClick(\"{0}\",this)", Eval("CASEID")) %>' />
                        </td>
                        <td>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",this)", Eval("CASEID"), Eval("CUSTID")) %>'
                          runat="server" Text="����" />
                          <asp:HiddenField ID="hIdREVIEWSTATUS" runat="server" Value='<%# Eval("REVIEWSTATUS") %>' />
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value='<%# Eval("CASESTATUS") %>' />
                        <asp:HiddenField ID="HidV4STATUS" runat="server" Value='<%# Eval("V4STATUS") %>' />
                          <asp:HiddenField ID="hidEXAMINE" runat="server" Value='<%# Eval("EXAMINE") %>' /><%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�|  --%>
                      </td>
                      <td>
                        <asp:Label ID="lblCASEID" runat="server" Text='<%# Eval("CASEID") %>'></asp:Label>
                      </td>
                      <td width="15%">
                        <%# Eval("CUSTNAME")%>
                        <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                          ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                      </td>
                      <td>
                        <asp:CheckBox ID="chkApprove" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkAddCon" Enabled="false" runat="server" />
                        <asp:HiddenField ID="hidAddCon" Value="" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkDecline" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReject" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkNoReview" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkWait" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReviewOK" Enabled="false" runat="server" />
                      </td>
                      <%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�|  --%>
                        <td>
                            <asp:CheckBox ID="chkExamine1" Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkExamine2" Enabled="false" runat="server" />
                        </td>
                      
                      <td>
                        <%#Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%#Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%#Eval("MAINTYPENM")%>
                      </td>
                      <td>
                        <%#Eval("TRANSTYPENM")%>
                      </td>
                      <td>
                        <%#Eval("USESTATUSNM")%>
                      </td>
                      <td>
                        <%# Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
                      </td>
                      <td>
                        <%#Eval("CONTRACTMONTH")%>
                      </td>
                      <td>
                        <%#Eval("IRR") %>
                      </td>
                      <td>
                        <%#  Itg.Community.Util.GetRepYear(Eval("CASEINDATE").ToString())%>
                      </td>
                      <td>
                        <%#  Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <td>
                            <asp:Button ID="btnREPORT" CssClass="btn_normal" runat="server" Text="�ץ���i" Width="100px" OnClientClick='<%# String.Format("return ReportClick(\"{0}\",this)", Eval("CASEID")) %>' />
                        </td>
                        <td>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",this)", Eval("CASEID"), Eval("CUSTID")) %>'
                          runat="server" Text="����" />
                         <asp:HiddenField ID="hIdREVIEWSTATUS" runat="server" Value='<%# Eval("REVIEWSTATUS") %>' />
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value='<%# Eval("CASESTATUS") %>' />
                        <asp:HiddenField ID="HidV4STATUS" runat="server" Value='<%# Eval("V4STATUS") %>' />
                          <asp:HiddenField ID="hidEXAMINE" runat="server" Value='<%# Eval("EXAMINE") %>' /><%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�|  --%>
                      </td>
                         <td>
                        <asp:Label ID="lblCASEID" runat="server" Text='<%# Eval("CASEID") %>'></asp:Label>
                      </td>
                      <td width="15%">
                        <%# Eval("CUSTNAME")%>
                        <asp:TextBox CssClass="txt_table_readonly" Style="display: none;" ReadOnly="true"
                          ID="lblCONTACTNAME" runat="server" Width="160px" Text='<%# Eval("CUSTNAME")%>'></asp:TextBox>
                      </td>
                      <td>
                        <asp:CheckBox ID="chkApprove" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkAddCon" Enabled="false" runat="server" />
                        <asp:HiddenField ID="hidAddCon" Value="" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkDecline" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReject" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkNoReview" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkWait" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReviewOK" Enabled="false" runat="server" />
                      </td>
                        <%-- 20160930 ADD BY SS ADAM REASON.�W�[��f�|  --%>
                        <td>
                            <asp:CheckBox ID="chkExamine1" Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkExamine2" Enabled="false" runat="server" />
                        </td>
                      
                     
                      <td>
                        <%#Eval("DEPTIDNM")%>
                      </td>
                      <td>
                        <%#Eval("EMPLNM")%>
                      </td>
                      <td>
                        <%#Eval("MAINTYPENM")%>
                      </td>
                      <td>
                        <%#Eval("TRANSTYPENM")%>
                      </td>
                      <td>
                        <%#Eval("USESTATUSNM")%>
                      </td>
                      <td>
                        <%# Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
                      </td>
                      <td>
                        <%#Eval("CONTRACTMONTH")%>
                      </td>
                      <td>
                        <%#Eval("IRR") %>
                      </td>
                      <td>
                        <%#  Itg.Community.Util.GetRepYear(Eval("CASEINDATE").ToString())%>
                      </td>
                      <td>
                        <%#  Itg.Community.Util.GetRepYear(Eval("EDATE").ToString())%>
                      </td>
                    </tr>
                  </AlternatingItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
          </asp:UpdatePanel>
          </table>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
