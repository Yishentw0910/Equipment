<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5001A.aspx.cs" Inherits="FrmML5001A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>
        -<%=this.GSTR_PROGNM%></title>
    <base target="_self" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />

    <script type="text/javascript" language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>

    <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML5001A.js' -->                   
    </script>

</head>
<body onload="window_onload()" onkeydown="body_OnKeyDown(event)">
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
            <table class="divStatus" width="68%">
                <tr>
                    <!--th>
          案件編號
        </th-->
                    <td>
                        <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true" Style="display: none"></asp:TextBox>
                    </td>
                    <th>
                        合約編號
                    </th>
                    <td>
                        <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                    <th>
                        案件核准日
                    </th>
                    <td>
                        <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
                        <asp:HiddenField ID="hidGUANVALUE" runat="server" /> <%--UPD BY VICKY 20140225 配合SP_ML3002_U02擴欄位使用--%>
                    </td>
                </tr>
            </table>
            <div class="div_Info H_970" style="height: auto">
                <asp:HiddenField ID="hidRETUNCONFIRM0" runat="server" Value="" />
                <asp:HiddenField ID="hidRETUNCONFIRMDATE0" runat="server" Value="" />
                <div class="div_title">
                    客戶相關資料</div>
                <table class="tb_Info" cellpadding="1" cellspacing="1" width="98%">
                    <tr>
                        <th>
                            客戶名稱
                        </th>
                        <td colspan="7">
                            <asp:TextBox ID="txtCUSTNAME" CssClass="txt_readonly" ReadOnly="true" Width="241px"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th width="12%">
                            決策人
                        </th>
                        <td width="30%">
                            <asp:TextBox ID="txtCONTACTNAME" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th width="10%">
                            部門
                        </th>
                        <td width="10%">
                            <asp:TextBox ID="txtDEPTNAME" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th width="10%">
                            職稱
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtCONTACTTITLE" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            電話
                        </th>
                        <td>
                            <asp:TextBox ID="txtCUSTTELCODE" CssClass="txt_readonly" ReadOnly="true" Width="24px"
                                runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtCONTACTTEL" CssClass="txt_readonly" ReadOnly="true" runat="server"
                                Width="80px"></asp:TextBox>
                            <asp:TextBox ID="txtCONTACTTELEXT" CssClass="txt_readonly" ReadOnly="true" runat="server"
                                Width="40px"></asp:TextBox>
                        </td>
                        <th>
                            手機
                        </th>
                        <td>
                            <asp:TextBox ID="txtCONTACTMPHONE" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th>
                            傳真
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtCUSTFAXCODE" Width="20px" runat="server" CssClass="txt_readonly"
                                ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="txtCONTACTFAX" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            地址
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtBUSINESSADDR" CssClass="txt_readonly" ReadOnly="true" Width="99%"
                                runat="server"></asp:TextBox>
                        </td>
                        <th>
                            E-Mail
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtCONTACTEMAIL" CssClass="txt_readonly" ReadOnly="true" Width="98%"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="div_title" style="margin-top: 10px;">
                    案件資料</div>
                <table class="tb_Info" cellpadding="1" cellspacing="1">
                    <tr>
                        <th width="12%">
                            承作類型
                        </th>
                        <td width="15%">
                            <asp:TextBox ID="txtMAINTYPENM" CssClass="txt_readonly" ReadOnly="true" runat="server"
                                Width="120px"></asp:TextBox>
                        </td>
                        <th width="10%">
                            撥款日
                        </th>
                        <td width="10%">
                            <asp:TextBox ID="txtPAYDATE" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th width="10%">
                            起租日
                        </th>
                        <td width="10%">
                            <asp:TextBox ID="txtRENTSTDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th width="10%">
                            迄租日
                        </th>
                        <td>
                            <asp:TextBox ID="txtRENTENDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="div_title" style="margin-top: 10px;">
                    進項發票資料</div>
                <table class="tb_Info" cellpadding="1" cellspacing="1">
                    <tr>
                        <th width="5%">
                            <asp:CheckBox ID="chkINVCONFIRM" runat="server" onClick="chkConfirmClick(this,'1')" />
                            <%--20120717 Modify By Maureen Reason:新增SOURCETYPE欄位，用以判斷01(和潤件)、02(銀行件)--%>
                            <asp:HiddenField ID="hidSOURCETYPE" runat="server" Value="" />
                        </th>
                        <td width="17%">
                            進項發票確認
                        </td>
                        <th width="10%">
                            回件日期
                        </th>
                        <td width="10%">
                            <asp:TextBox ID="txtC1" Text="" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidDate" runat="server" Value="" />
                        </td>
                        <th width="15%">
                            發票總金額
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtC2" Text="0" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="div_title" style="margin-top: 10px;">
                    進項折讓資料</div>
                <table class="tb_Info" cellpadding="1" cellspacing="1">
                    <tr>
                        <th width="5%">
                            <asp:CheckBox ID="chkINVDCONFIRM" runat="server" onClick="chkConfirmClick(this,'2')" />
                        </th>
                        <td width="17%">
                            進項折讓發票確認
                        </td>
                        <th width="10%">
                            回件日期
                        </th>
                        <td width="10%">
                            <asp:TextBox ID="txtD1" Text="" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <th width="15%">
                            折讓總金額
                        </th>
                        <td colspan="3">
                            <asp:TextBox ID="txtD2" Text="0" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="div_title" style="margin-top: 10px;">
                    回件細項資料</div>
                <%--<div  id="fraDispTypeInfo1"  class="frame_content div_Info3" style="width:100%;border:none;border-top:1px solid #427CBB;">--%>
                <%--客戶資料Begin --%>
                <%--<table id="tblMLDCASEAPPENDDOC" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
        width="98%">
        <tr>
          <th width="5%">
            項次
          </th>
          <th width="55%">
            文件
          </th>
          <th width="10%">
            回件日期
          </th>
          <th width="15%">
            回件資料確認
          </th>
          <th>
            說明
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
                <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
              </td>
              <td>
                <asp:Label ID="lblRepDate" Style="display: none;" runat="server" Text='<%# Itg.Community.Util.GetRepDate() %>'></asp:Label>
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM" runat="server" onClick="DOCCONFIRMClick(this,'chkDOCCONFIRM','lblRepDate')" />
              </td>
              <td>
                <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,50);" Text='<%# Eval("NOTE")%>'
                  runat="server" CssClass="txt_table"></asp:TextBox>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>--%>
                <%--UPD BY VICKY 20140224 修正細項顯示內容--%>
                <table id="tblMLDCASEAPPENDDOC" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
                    width="98%">
                    <tr>
                        <th width="5%">
                            項次
                        </th>
                        <th width="55%">
                            合約文件
                        </th>
                        <th width="15%">
                            營業處回件<asp:CheckBox ID="chkALL1" runat="server" onClick="selectAll(this,'tblMLDCASEAPPENDDOC')" />
                        </th>
                        <th width="10%">
                            回件日期
                        </th>
                        <th>
                            說明
                        </th>
                        <th style="display: none">
                            必勾欄位
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
                                    <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                                    <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkDOCCONFIRM" runat="server" onClick="DOCCONFIRMClick(this,'chkDOCCONFIRM','lblRepDate')" />
                                </td>
                                <td>
                                    <asp:Label ID="lblRepDate" Style="display: none;" runat="server" Text='<%# Itg.Community.Util.GetRepDate() %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,50);" Text='<%# Eval("NOTE")%>'
                                        runat="server" CssClass="txt_table"></asp:TextBox>
                                </td>
                                <%--UPD BY VICKY 20140225 加入必勾判斷欄位--%>
                                <td style="display: none">
                                    <asp:TextBox ID="txtDNAME2" MaxLength="50" Text='<%# Eval("DNAME2")%>' runat="server"
                                        CssClass="txt_table"></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <table id="tblMLDCASEAPPENDDOC2" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
                    width="98%">
                    <tr>
                        <th width="5%">
                            項次
                        </th>
                        <th width="55%">
                            擔保文件
                        </th>
                        <th width="15%">
                            營業處回件<asp:CheckBox ID="chkALL2" runat="server" onClick="selectAll(this,'tblMLDCASEAPPENDDOC2')" />
                        </th>
                        <th width="10%">
                            回件日期
                        </th>
                        <th>
                            說明
                        </th>
                        <th style="display: none">
                            必勾欄位
                        </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEAPPENDDOC2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Container.ItemIndex +1 %>
                                </td>
                                <td>
                                    <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("DNAME1")%>'></asp:Label>
                                    <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                                    <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkDOCCONFIRM" runat="server" onClick="DOCCONFIRMClick(this,'chkDOCCONFIRM','lblRepDate')" />
                                </td>
                                <td>
                                    <asp:Label ID="lblRepDate" Style="display: none;" runat="server" Text='<%# Itg.Community.Util.GetRepDate() %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,50);" Text='<%# Eval("NOTE")%>'
                                        runat="server" CssClass="txt_table"></asp:TextBox>
                                </td>
                                <%--UPD BY VICKY 20140225 加入必勾判斷欄位--%>
                                <td style="display: none">
                                    <asp:TextBox ID="txtDNAME2" MaxLength="50" Text='<%# Eval("DNAME2")%>' runat="server"
                                        CssClass="txt_table"></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <table id="tblMLDCASEAPPENDDOC3" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
                    width="98%">
                    <tr>
                        <th width="5%">
                            項次
                        </th>
                        <th width="55%">
                            客戶暨徵信資料
                        </th>
                        <th width="15%">
                            營業處回件<asp:CheckBox ID="chkALL3" runat="server" onClick="selectAll(this,'tblMLDCASEAPPENDDOC3')" />
                        </th>
                        <th width="10%">
                            回件日期
                        </th>
                        <th>
                            說明
                        </th>
                        <th style="display: none">
                            必勾欄位
                        </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEAPPENDDOC3" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Container.ItemIndex +1 %>
                                </td>
                                <td>
                                    <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("DNAME1")%>'></asp:Label>
                                    <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                                    <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkDOCCONFIRM" runat="server" onClick="DOCCONFIRMClick(this,'chkDOCCONFIRM','lblRepDate')" />
                                </td>
                                <td>
                                    <asp:Label ID="lblRepDate" Style="display: none;" runat="server" Text='<%# Itg.Community.Util.GetRepDate() %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,50);" Text='<%# Eval("NOTE")%>'
                                        runat="server" CssClass="txt_table"></asp:TextBox>
                                </td>
                                <%--UPD BY VICKY 20140225 加入必勾判斷欄位--%>
                                <td style="display: none">
                                    <asp:TextBox ID="txtDNAME2" MaxLength="50" Text='<%# Eval("DNAME2")%>' runat="server"
                                        CssClass="txt_table"></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="div_title" style="margin-top: 10px;">
                    退件日期資料</div>
                <table id="tbMLMBACKDOCDATE" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
                    width="98%">
                    <tr>
                        <th width="5%">
                            項次
                        </th>
                        <th width="25%">
                            營業處回件日
                        </th>
                        <th width="20%">
                            傳遞日
                        </th>
                        <th width="25%">
                            客服回退日
                        </th>
                        <th>
                            回退意見內容
                        </th>
                        <th style="display: none;">
                            回退意見內容
                        </th>
                    </tr>
                    <asp:Repeater ID="rptMLMBACKDOCDATE" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Container.ItemIndex +1 %>
                                </td>
                                <td>
                                    <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("CONFIRMDATE")%>'></asp:Label>
                                    <asp:HiddenField ID="hidRETUNID" Value='<%# Eval("RETUNID") %>' runat="server" />
                                    <asp:HiddenField ID="hidRETUNSEQ" Value='<%# Eval("RETUNSEQ") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblTRANSDATE" runat="server" Text='<%# Eval("TRANSDATE")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBACKDOCDATE" runat="server" Text='<%# Eval("BACKDOCDATE")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnMEMO" CssClass="btn_normal" OnClientClick='<%# String.Format("BackMemo_OnClick(\"{0}\")", Eval("MEMO")) %>'
                                        runat="server" Text="內容" />
                                </td>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtMEMO" MaxLength="50" Text='<%# Eval("MEMO")%>' runat="server"
                                        CssClass="txt_table"></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <%--</div>   --%>
                <table width="90%" id="tblCon" runat="server" visible="false" style="margin: 10px;">
                    <tr>
                        <th width="20%">
                            回退意見內容：
                        </th>
                        <td>
                            <asp:TextBox ID="txtCond" TextMode="MultiLine" Enabled="false" CssClass="txt_normal"
                                MaxLength="100" Width="600px" Height="100px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <%--UPD BY VICKY 20140225 按下歷程的內容BUTTON時,會帶出其內容值--%>
                <asp:Panel ID="panMEMO" runat="server">
                    <asp:TextBox ID="txtMEMO" TextMode="MultiLine" Enabled="false" CssClass="txt_normal"
                        MaxLength="100" Height="100px" Style="margin-left: 5px; margin-top: 5px; display: none;"
                        Width="98%" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdMEMO" runat="server" />
                </asp:Panel>
            </div>
            <div class="btn_div">
                <input type="button" id="Button1" class="btn_normal" disabled="disabled" onclick="ML4001AClick();"
                    value="發票及繳款方式維護" />
                <asp:Button ID="btnSubmit" runat="server" Text="確認（轉客服及財支）" CssClass="btn_normal"
                    OnClientClick="javascipt:return btnSubmit_Click(this);" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnPRINT" runat="server" Text="列印回件資料表" CssClass="btn_normal" OnClick="cmdPRINT_OnClick" />
            </div>
        </div>
    </form>
</body>
</html>
