<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3003																					
* 程式功能  : 撥款核准(信管)																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20121210 By SS Steven. Reason: 新增「關係人檢核」按鈕.
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
                    <font color="#006699">系統處理中，請稍後...</font>
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
                公司別：
              </th>
              <td width="30%">
                <asp:DropDownList ID="drpCompID" runat="server" Width="80%">
                  <asp:ListItem>請選擇</asp:ListItem>
                </asp:DropDownList>
              </td>
              <th class="align_right" width="20%">
                部門別：
              </th>
              <td>
                <asp:DropDownList ID="drpDeptID" runat="server" Width="80%">
                  <asp:ListItem>北一處</asp:ListItem>
                  <asp:ListItem>北二處</asp:ListItem>
                  <asp:ListItem>北三處</asp:ListItem>
                  <asp:ListItem>桃園處</asp:ListItem>
                  <asp:ListItem>中區處</asp:ListItem>
                  <asp:ListItem>南區處</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                合約編號：
              </th>
              <td>
                <asp:TextBox ID="txtCNTRNO" onkeypress="OnlyNumDUCase(this);" MaxLength="14" runat="server" CssClass="txt_normal" Width="120px"></asp:TextBox>
              </td>
              <th class="align_right" width="20%">
                徵信狀況：
              </th>
              <td>
                <asp:DropDownList ID="drpCreditType" runat="server" Width="80%">
                  <asp:ListItem Value="N">未徵信</asp:ListItem>
                  <asp:ListItem Value="Y">已徵信</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <th class="align_right">
                客戶統編：
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtCustID" MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);GetCustName(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                <asp:TextBox ID="txtCustName" runat="server" CssClass="txt_normal" Width="400px"></asp:TextBox>
                <input type="button" id="Button1" class="btn_normal" onclick="CustomerClick();" style="width: 25px; padding: 2px;" value="&#8230;" />
              </td>
            </tr>
            <tr>
              <th class="align_right">
                撥款申請日起迄：
              </th>
              <td colspan="3">
                <asp:TextBox ID="txtStartDateO" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
                -
                <asp:TextBox ID="txtEndDateO" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_normal" Width="80px"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <th colspan="4" style="text-align: center; height: 30px;">
                <asp:Button ID="cmdQuery" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="javascipt:return cmdQuery_Click(this);" OnClick="cmdQuery_Click" />
                <input type="button" id="cmdClear" class="btn_normal" onclick="cmdClear_onclick(this);" value="清除" />
                <%--Modify 20121210 By SS Steven. Reason: 新增「關係人檢核」按鈕.--%>
                <asp:Button ID="btnRecheck" runat="server" Text="關係人檢核" CssClass="btn_normal" OnClientClick="Recheck();return false;" />
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
                    核准
                  </th>
                  <th>
                    退件
                  </th>
                  <th>
                    展開
                  </th>
                  <th>
                    合約編號
                  </th>
                  <th>
                    客戶名稱
                  </th>
                  <th>
                    承作部門
                  </th>
                  <th>
                    承作業代
                  </th>
                  <th>
                    承作類型
                  </th>
                  <th>
                    交易型態
                  </th>
                  <th>
                    動用情形
                  </th>
                  <th>
                    承作金額
                  </th>
                  <th>
                    期數
                  </th>
                  <th>
                    IRR
                  </th>
                  <th>
                    撥款申請日
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
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>' runat="server" Text="明細" />
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
                        <asp:Button ID="btnSelect" CssClass="btn_normal" OnClientClick='<%# String.Format("return CaseClick(\"{0}\",\"{1}\",\"{2}\",this)", Eval("CASEID"), Eval("CUSTID"), Eval("CNTRNO")) %>' runat="server" Text="明細" />
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
