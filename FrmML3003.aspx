<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML3003																					
* �{���\��  : ���ڮ֭�(�H��)																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20121210 By SS Steven. Reason: �s�W�u���Y�H�ˮ֡v���s.
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3003.aspx.cs" Inherits="FrmML3003" %>

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
    <!-- #Include file='js/ML3003.js' -->                   
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
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
        <div class="div_Info H_130">
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
              <th class="align_right" width="20%">
                �����O�G
              </th>
              <td>
                <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
                  <asp:ListItem>�_�@�B</asp:ListItem>
                  <asp:ListItem>�_�G�B</asp:ListItem>
                  <asp:ListItem>�_�T�B</asp:ListItem>
                  <asp:ListItem>���B</asp:ListItem>
                  <asp:ListItem>���ϳB</asp:ListItem>
                  <asp:ListItem>�n�ϳB</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                �X���s���G
              </th>
              <td>
                <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" MaxLength="14" runat="server" CssClass="txt_normal" Width="120px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
                �x�H���p�G
              </th>
              <td>
                <asp:DropDownList ID="drpCreditType" runat="server" Width="80%">
                  <asp:ListItem Value="N">���x�H</asp:ListItem>
                  <asp:ListItem Value="Y">�w�x�H</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                �Ȥ�νs�G
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);GetCustName(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px; padding: 2px;" value="&#8230;" />
              </td>
            </tr>
            <tr>
              <th class="align_right">
                ���ڥӽФ�_���G
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtStartDateO" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtEndDateO" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <th colspan="4" style="text-align: center; height: 30px;">
                <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClientClick="javascipt:return cmdQuery_Click(this);" OnClick="cmdQuery_Click" />
                <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);" value="�M��" />
                <%--Modify 20121210 By SS Steven. Reason: �s�W�u���Y�H�ˮ֡v���s.--%>
                <asp:Button ID="btnRecheck" runat="server" Text="���Y�H�ˮ�" CssClass="btn_normal" OnClientClick="Recheck();return false;" />
              </th>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
          <asp:UpdatePanel ID="UpdatePanelDate" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <table width="1100px" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
                <tr>
                  <th>
                    �֭�
                  </th>
                  <th>
                    �h��
                  </th>
                  <th>
                    �i�}
                  </th>
                  <th>
                    �X���s��
                  </th>
                  <th>
                    �Ȥ�W��
                  </th>
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
                    ���ڥӽФ�
                  </th>
                </tr>
                <asp:Repeater ID="rptData" runat="server">
                  <ItemTemplate>
                    <tr class="singleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                      <td>
                        <asp:CheckBox ID="chkApprove" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReject" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>' runat="server" Text="����" />
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value='<%# Eval("CASESTATUS") %>' />
                        <asp:HiddenField ID="HidV8STATUS" runat="server" Value='<%# Eval("V8STATUS") %>' />
                      </td>
                      <td>
                        <asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label>
                      </td>
                      <td width="18%">
                        <%# Eval("CUSTNAME")%>
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
                        <%#  Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
                      </td>
                      <td>
                        <%#Eval("CONTRACTMONTH")%>
                      </td>
                      <td>
                        <%#Eval("IRR") %>
                      </td>
                      <td>
                        <%# Itg.Community.Util.GetRepYear(Eval("V6DATE").ToString())%>
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr class="doubleline" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                      <td>
                        <asp:CheckBox ID="chkApprove" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:CheckBox ID="chkReject" Enabled="false" runat="server" />
                      </td>
                      <td>
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>' runat="server" Text="����" />
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value='<%# Eval("CASESTATUS") %>' />
                        <asp:HiddenField ID="HidV8STATUS" runat="server" Value='<%# Eval("V8STATUS") %>' />
                      </td>
                      <td>
                        <asp:Label ID="lblCNTRNOID" runat="server" Text='<%# Eval("CNTRNO") %>'></asp:Label>
                      </td>
                      <td width="18%">
                        <%# Eval("CUSTNAME")%>
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
                        <%#  Itg.Community.Util.NumberFormat(Eval("Amount").ToString())%>
                      </td>
                      <td>
                        <%#Eval("CONTRACTMONTH")%>
                      </td>
                      <td>
                        <%#Eval("IRR") %>
                      </td>
                      <td>
                        <%# Itg.Community.Util.GetRepYear(Eval("V6DATE").ToString())%>
                      </td>
                    </tr>
                  </AlternatingItemTemplate>
                </asp:Repeater>
              </table>
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
