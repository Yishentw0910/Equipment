<%-- 
* Database 	: ML																							
* �t    �� 	: ����]��																					
* �{���W�� 	: ML4005																					
* �{���\��  : �o���}�ߪ��A���Ӫ�																			
* �{���@�� 	:																			
* �����ɶ� 	:
* �ק�ƶ� 	: 
Modify 20120615 By SS Gordon. Reason: �s�W�νs�d�߶s.
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4005.aspx.cs" Inherits="FrmML4005" %>

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

  <script language="javascript" type="text/javascript" src="js/UI.js"></script>

  <script language="javascript" type="text/javascript" src="js/ITG.js"></script>

  <script language="javascript" type="text/javascript" src="js/validate.js"></script>

  <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML4005.js' -->
  </script>

</head>
<body onkeydown="body_OnKeyDown(event)">
  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
      <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: absolute; top: 0px;
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
        <div class="div_Info H_110">
          <table width="100%" cellpadding="1" cellspacing="1" class="tab_query">
            <tr>
              <th class="align_right" width="25%">
                ���q�O�G
              </th>
              <td width="25%">
                <asp:DropDownList ID="drpCompID" runat="server">
                </asp:DropDownList>
              </td>
              <th class="align_right">
                �ӧ@�����G
              </th>
              <td>
                <asp:DropDownList ID="drpMAINTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE">
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
                <th class="align_right">
                    �Ȥ�νs�G
                </th>
                <td width="25%">
                    <asp:TextBox ID="txtCustID" runat="server" CssClass="txt_normal" MaxLength="10" Width="80%"></asp:TextBox>
                    <input type="button" id="btnSelCus" class="btn_normal" runat="server" onclick="CustomerClick();" style="width: 25px; padding: 2px;" value="&#8230;" />
                </td>
                <th class="align_right">
                �X���s���G
              </th>
              <td width="25%">
                <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" runat="server" CssClass="txt_normal"
                  MaxLength="14" Width="80%"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <th class="align_right">�o������_���G</th>
              <td colspan="3">
                <asp:TextBox ID="txtINVDATES" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtINVDATEE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                  onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
            </tr>
            
            <tr>
              <td colspan="4" style="text-align: center; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
                    <asp:Button ID="cmdQuery" runat="server" Text="�d��" CssClass="btn_normal" OnClientClick="JavaScript: return cmdQuery_onClick(this);"
                      OnClick="cmdQuery_Click" />
                    <asp:Button ID="cmdClear" runat="server" Text="�M��" CssClass="btn_normal" OnClientClick="JavaScript: return cmdClear_onClick(this);"
                      OnClick="cmdClear_Click" />
                    <asp:Button ID="cmdPrint" runat="server" Text="�C�L" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrintP_onClick(this);" />
                  </ContentTemplate>
                </asp:UpdatePanel>
              </td>
            </tr>
          </table>
        </div>
        <div class="div_Info H_260" style="overflow: auto; margin: 10px;">
          <asp:UpdatePanel ID="UpdatePanelDate" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <table width="145%" cellpadding="0" cellspacing="0" class="tab_result" id="tabQryResultInfo"
                style="margin: 4px;">
                <tr>
                  <!--th>
                    &nbsp;
                  </th-->
                  <th>
                    �X���s��
                  </th>
                  <th>
                    ����
                  </th>
                  <th>
                    �~�W
                  </th>
                  <th>
                    �Ȥ�νs
                  </th>
				  <th>
                    �o�����X
                  </th>
                  <th>
                    �o�����Y
                  </th>
                  <th>
                    �ǲ����
                  </th>
                  <th>
                    �o�����
                  </th>
                  <th nowrap>
                    ���A
                  </th>
                  <th>
                    �P���B
                  </th>
                  <th>
                    �|�B
                  </th>
                  <th nowrap>
                    �P��X�p
                  </th>
                  <th nowrap>
                    ����
                  </th>
                </tr>
                <asp:Repeater ID="rptData" runat="server">
                  <ItemTemplate>
                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onclick="MouseDown(event);">
                      <!--td>
                       <input type="button" id="cmdPrint1" class="btn_normal" onclick="cmdPrint_onClick(this);"  style="padding:2px;" value="�C�L" />
                      </td-->
                      <td>
                        <%#Eval("CNTRNO")%>
                      </td>
                      <td>
                        <%#Eval("UNITNAME")%>
                      </td>
                      <td>
                        <%#Eval("INVDESC")%>
                      </td>
                      <td>
                        <%#Eval("CUSTID")%>
                      </td>
                      <td>
                        <%#Eval("INVNO")%>
                      </td>
					  <td>
                        <%#Eval("INVTITLE")%>
                      </td>
                      <td>
                        <%#Itg.Community.Util.GetRepYear(Eval("VECHDT").ToString())%>
                      </td>
                      <td>
                        <%#Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>
                      </td>
                      <td nowrap>&nbsp;
                        <%#Eval("INVOSTUS")%>&nbsp;
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("AMOUNT").ToString()) %>
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("TAX").ToString())%>
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("SUMMARY").ToString())%>
                      </td>
                      <td>
                        <%#Eval("ISSUE") %>
                      </td>
                    </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                    <tr style="background-color: #E5E5E5" onmouseover="MouseOver(event)" onmouseout="MouseOut(event)"
                      onclick="MouseDown(event);">
                      <!--td>
                       <input type="button" id="cmdPrint1" class="btn_normal" onclick="cmdPrint_onClick(this);"  style="padding:2px;" value="�C�L" />
                      </td-->
                      <td>
                        <%#Eval("CNTRNO")%>
                      </td>
                      <td>
                        <%#Eval("UNITNAME")%>
                      </td>
                      <td>
                        <%#Eval("INVDESC")%>
                      </td>
                      <td>
                        <%#Eval("CUSTID")%>
                      </td>
					  <td>
                        <%#Eval("INVNO")%>
                      </td>
                      <td>
                        <%#Eval("INVTITLE")%>
                      </td>
                      <td>
                        <%#Itg.Community.Util.GetRepYear(Eval("VECHDT").ToString())%>
                      </td>
                      <td>
                        <%#Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>
                      </td>
                      <td nowrap>&nbsp;
                        <%#Eval("INVOSTUS")%>&nbsp;
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("AMOUNT").ToString())%>
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("TAX").ToString())%>
                      </td>
                      <td style="text-align: right;">
                        <%#Itg.Community.Util.NumberFormat(Eval("SUMMARY").ToString())%>
                      </td>
                      <td>
                        <%#Eval("ISSUE") %>
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
