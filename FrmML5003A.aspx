<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5003A.aspx.cs" Inherits="FrmML5003A" %>

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
    <!-- #Include file='js/ML5003A.js' -->                   
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
	<br>
    <div class="div_Info H_970" style="height: auto">
      <asp:HiddenField ID="hidRETUNID" runat="server" Value="" />
      <asp:HiddenField ID="hidINVCONFIRM" runat="server" Value="" />
      <asp:HiddenField ID="hidINVCONFIRMDATE" runat="server" Value="" />
      <asp:HiddenField ID="hidINVDCONFIRM" runat="server" Value="" />
      <asp:HiddenField ID="hidINVDCONFIRMDATED" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM1" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE1" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM2" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE2" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM3" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE3" runat="server" Value="" />
      <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px;">
        <tr>
          <th width="12%">
            合約編號
          </th>
          <td width="15%">
            <asp:TextBox ID="txtCNTRNO" Width="120px" runat="server" CssClass="txt_readonly"
              ReadOnly="true"></asp:TextBox>
          </td>
          <th width="15%">
            承作部門
          </th>
          <td width="15%">
            <asp:TextBox ID="txtDEPT" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="150px"></asp:TextBox>
          </td>
          <th width="15%">
            承作業務
          </th>
          <td >
            <asp:TextBox ID="txtAgency" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
          </td>
        </tr>
      </table>
      <div class="div_title" style="margin-top: 10px;">
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
          <td width="20%">
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
            <asp:TextBox ID="txtCUSTTELCODE" Width="20px" CssClass="txt_readonly" ReadOnly="true"
              runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCONTACTTEL" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
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
          <th width="15%">
            承作類型
          </th>
          <td width="10%">
            <asp:TextBox ID="txtMAINTYPENM" CssClass="txt_readonly" ReadOnly="true" runat="server" Width="150px"></asp:TextBox>
          </td>
          <th width="15%">
            撥款日
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtPAYDATE" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            合約起日
          </th>
          <td>
            <asp:TextBox ID="txtRENTSTDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            合約迄日
          </th>
          <td>
            <asp:TextBox ID="txtRENTENDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th width="17%">
            期數
          </th>
          <td >
            <asp:TextBox ID="txtCONTRACTMONTH" CssClass="txt_readonly_right" ReadOnly="true"
              runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            承作金額
          </th>
          <td>
            <asp:TextBox ID="txtACTUALLYAMOUNT" CssClass="txt_readonly_right" ReadOnly="true"
              runat="server"></asp:TextBox>
          </td>
          <th>
            履約保證金
          </th>
          <td>
            <asp:TextBox ID="txtPERBOND" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            租購保證金
          </th>
          <td >
            <asp:TextBox ID="txtPURCHASEMARGIN" CssClass="txt_readonly_right" ReadOnly="true"
              runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th width="12%">
            每期租金
          </th>
          <td width="10%">
            <asp:TextBox ID="txtMPAY" CssClass="txt_readonly_right" Text="0" ReadOnly="true"
              runat="server"></asp:TextBox>
          </td>
          <th width="15%">
            IRR
          </th>
          <td width="10%">
            <asp:TextBox ID="txtIRR" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <!--th width="15%">
            收款方式
          </th-->
		  <th width="15%">
            付款方式
          </th>
          <td width="115%">
            <asp:TextBox ID="txtD1" CssClass="txt_readonly" ReadOnly="true" runat="server" style="display:none"></asp:TextBox>
			<asp:TextBox ID="txtCUSTPAYTYPE" CssClass="txt_readonly" ReadOnly="true" runat="server" Width="150px"></asp:TextBox>
          </td>
          <!--th width="15%">
            付款方式
          </th>
          <td>
            
          </td-->
        </tr>
      </table>
      <div class="div_title" style="margin-top: 10px;">
        回件細項資料</div>
        <table cellpadding="1" cellspacing="1" class="tb_Info">
          <tr>
            <th width="18%">
              客服回件日
            </th>
            <td width="15%">
              <asp:TextBox ID="txtRETUNCONFIRMDATE2" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="18%">
              上次退件日
            </th>
            <td width="15%">
              <asp:TextBox ID="txtEDATE" ReadOnly="true" custprop="100" MaxLength="9" runat="server"
                CssClass="txt_normal_right"></asp:TextBox>
            </td>
            <th width="15%">
            </th>
            <td>
            </td>
          </tr>
        </table>   
      <%--<div  id="fraDispTypeInfo1"  class="frame_content div_Info3" style="width:100%;border:none;border-top:1px solid #427CBB;">--%>
      <%--客戶資料Begin --%>
      <%--<table id="tblMLDCASEAPPENDDOC" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
        width="98%">
        <tr>
          <th width="5%">
            項次
          </th>
          <th width="50%">
            文件
          </th>
          <th width="10%">
            營業回件
          </th>
          <th width="10%">
            回件日期
          </th>
          <th width="11%">
            回件確認
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
                <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                <asp:HiddenField ID="hidRETUNDATE" Value='<%# Itg.Community.Util.GetRepYear(Eval("RETUNDATE").ToString()) %>'
                  runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRM1" Value='<%# Eval("DOCCONFIRM1") %>' runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRMDATE1" Value='<%# Itg.Community.Util.GetRepYear(Eval("DOCCONFIRMDATE1").ToString()) %>'
                  runat="server" />
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM1" runat="server" />
              </td>
              <td>
                <asp:Label ID="lblRepDate" Style="display: none;" runat="server" Text='<%# Itg.Community.Util.GetRepYear(Eval("RETUNDATE").ToString()) %>'></asp:Label>
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM" runat="server" onClick="DOCCONFIRMClick(this,'chkDOCCONFIRM','lblRepDate')" />
              </td>
              <td>
                <asp:TextBox ID="txtNOTE" MaxLength="50" Width="120px" onblur="CheckMLength(this,50);" runat="server"
                  Text='<%# Eval("NOTE")%>' CssClass="txt_table"></asp:TextBox>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>--%>

      <%--Modify 20140224 By SS Eric Reason:修正細項顯示內容--%>
      <table id="tblMLDCASEAPPENDDOC" class="tb_Text" style="margin-left: 5px; margin-top: 5px;"
        width="98%">
        <tr>
          <th width="5%">
            項次
          </th>
          <th width="45%">
            合約文件
          </th>
          <th width="10%">
            營業回件
          </th>          
          <th width="10%">
            回件日期
          </th>
          <th width="15%">
            回件確認<asp:CheckBox ID="chkALL1" runat="server" onClick="selectAll1(this)"/>
          </th>
          <th width="20%">
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
                <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                <asp:HiddenField ID="hidRETUNDATE" Value='<%# Itg.Community.Util.GetRepYear(Eval("RETUNDATE").ToString()) %>'
                  runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRM1" Value='<%# Eval("DOCCONFIRM1") %>' runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRMDATE1" Value='<%# Itg.Community.Util.GetRepYear(Eval("DOCCONFIRMDATE1").ToString()) %>'
                  runat="server" />
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM1" runat="server" />
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
              <%--Modify 20140225 By SS Eric Reason:加入必勾判斷欄位--%>
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
          <th width="45%">
            擔保文件
          </th>
          <th width="10%">
            營業回件
          </th>          
          <th width="10%">
            回件日期
          </th>
          <th width="15%">
            回件確認<asp:CheckBox ID="chkALL2" runat="server" onClick="selectAll2(this)"/>
          </th>
          <th width="20%">
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
                <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                <asp:HiddenField ID="hidRETUNDATE" Value='<%# Itg.Community.Util.GetRepYear(Eval("RETUNDATE").ToString()) %>'
                  runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRM1" Value='<%# Eval("DOCCONFIRM1") %>' runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRMDATE1" Value='<%# Itg.Community.Util.GetRepYear(Eval("DOCCONFIRMDATE1").ToString()) %>'
                  runat="server" />
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM1" runat="server" />
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
              <%--Modify 20140225 By SS Eric Reason:加入必勾判斷欄位--%>
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
          <th width="45%">
            客戶暨徵信資料
          </th>
          <th width="10%">
            營業回件
          </th>          
          <th width="10%">
            回件日期
          </th>
          <th width="15%">
            回件確認<asp:CheckBox ID="chkALL3" runat="server" onClick="selectAll3(this)"/>
          </th>
          <th width="20%">
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
                <asp:HiddenField ID="hidRETUNDETAILID" Value='<%# Eval("RETUNDETAILID") %>' runat="server" />
                <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                <asp:HiddenField ID="hidRETUNDATE" Value='<%# Itg.Community.Util.GetRepYear(Eval("RETUNDATE").ToString()) %>'
                  runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRM1" Value='<%# Eval("DOCCONFIRM1") %>' runat="server" />
                <asp:HiddenField ID="hidDOCCONFIRMDATE1" Value='<%# Itg.Community.Util.GetRepYear(Eval("DOCCONFIRMDATE1").ToString()) %>'
                  runat="server" />
              </td>
              <td>
                <asp:CheckBox ID="chkDOCCONFIRM1" runat="server"/>
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
              <%--Modify 20140225 By SS Eric Reason:加入必勾判斷欄位--%>
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
      <table id="tbMLMBACKDOCDATE" class="tb_Text" style="margin-left: 5px; margin-top: 5px;" width="98%">
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
              <th style="display:none;">
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
      <%--Modify 20140225 By SS Eric Reason:按下退件日期資料的內容BUTTON時,會帶出其內容值--%>
      <asp:Panel ID="panMEMO" runat="server">
          <asp:TextBox ID="txtMEMO" TextMode="MultiLine" Enabled="false" CssClass="txt_normal"
              MaxLength="100" Height="100px" Style="margin-left: 5px; margin-top: 5px; display: none;"
              Width="98%" runat="server"></asp:TextBox>
          <asp:HiddenField ID="hdMEMO" runat="server" />
    </asp:Panel>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSubmit" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="return checkRule();"
        OnClick="btnSubmit_Click" />
      <asp:Button ID="btnReject" runat="server" Text="退回" CssClass="btn_normal" OnClientClick="return RejectComment();"
        OnClick="btnReject_Click" />
      <asp:HiddenField ID="hidCond" runat="server" Value="" />
    </div>
  </div>
  </form>
</body>
</html>
