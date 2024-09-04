<%--********************************************************************************************************--%>
<%--* Database 	: ML																						--%>	
<%--* 系    統 	: 租賃設備																					--%>
<%--* 程式名稱 	: FrmML2001A_a																				--%>
<%--* 程式功能  : 附條件原因             																	--%>
<%--* 程式作者 	: MAUREEN       																			--%>	
<%--* 新增時間 	: 2012/06/04																				--%>	
<%--                                                                                                        --%>
<%--********************************************************************************************************--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B_a.aspx.cs" Inherits="FrmML2001B_a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>附條件原因</title>
    <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />
  <link rel="stylesheet" href="css/rent.css" />
    <style type="text/css">
        .style6
        {
            width: 165px;
        }
        .style7
        {
            width: 852px;
        }
        .style8
        {
            width: 216px;
        }
    </style>
      <script type="text/javascript" language="javascript" src="js/UI.js"></script>

      <script language="javascript" src="js/Itg.js"></script>

      <script language="javascript" src="js/validate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <center style="margin-top:4px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
              <table style="margin:0 auto; background-color:#add8e6" border="1" cellpadding="1" cellspacing="1"width="500">
                  <tr>
                      <td style="background-color: #ffcc99; text-align: center" colspan="2"><B>附條件原因(可複選)</B></td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">借款人</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="A001" runat="server" AutoPostBack="True"   Text="營運衰退"/><br/>
                          <asp:CheckBox ID="A002" runat="server" AutoPostBack="True"   Text="虧損嚴重"/><br/>
                          <asp:CheckBox ID="A003" runat="server" AutoPostBack="True"   Text="成立期短，營收偏低"/><br/>
                          <asp:CheckBox ID="A004" runat="server" AutoPostBack="True"   Text="營運週期過長"/><br/>
                          <asp:CheckBox ID="A005" runat="server" AutoPostBack="True"   Text="申戶票/債信異常"/><br/>
                          <asp:CheckBox ID="A006" runat="server" AutoPostBack="True"   Text="申戶不動產有民間設定記錄"/><br/>
                          <asp:CheckBox ID="A007" runat="server" AutoPostBack="True"   Text="申戶不動產有限制登記記錄"/><br/>
                          <asp:CheckBox ID="A008" runat="server" AutoPostBack="True"   Text="申戶負債偏高、財務結構不佳"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">借款目的</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="B001" runat="server" AutoPostBack="True"   Text="資金用途不明"/><br/>
                          <asp:CheckBox ID="B002" runat="server" AutoPostBack="True"   Text="距前案時間太短、餘額仍高"/><br/>
                          <asp:CheckBox ID="B003" runat="server" AutoPostBack="True"   Text="短期租賃同業申辦頻繁"/><br/>
                          <asp:CheckBox ID="B004" runat="server" AutoPostBack="True"   Text="同業婉拒件"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">還款來源</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="C001" runat="server" AutoPostBack="True"   Text="還款來源不明"/><br/>
                          <asp:CheckBox ID="C002" runat="server" AutoPostBack="True"   Text="還款能力不足"/><br/>
                          <asp:CheckBox ID="C003" runat="server" AutoPostBack="True"   Text="分期、租金款佔營收比例高"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">債權保障</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="D001" runat="server" AutoPostBack="True"   Text="實際經營者不任保"/><br/>
                          <asp:CheckBox ID="D002" runat="server" AutoPostBack="True"   Text="擔保力不足"/><br/>
                          <asp:CheckBox ID="D003" runat="server" AutoPostBack="True"   Text="標的物性質不佳或適用性/二手性有限"/><br/>
                          <asp:CheckBox ID="D004" runat="server" AutoPostBack="True"   Text="標的物無二手性"/><br/>
                          <asp:CheckBox ID="D005" runat="server" AutoPostBack="True"   Text="保人卡循"/><br/>
                          <asp:CheckBox ID="D006" runat="server" AutoPostBack="True"   Text="保人預借現金"/><br/>
                          <asp:CheckBox ID="D007" runat="server" AutoPostBack="True"   Text="保人無資產"/><br/>
                          <asp:CheckBox ID="D008" runat="server" AutoPostBack="True"   Text="保人票/債信異常"/><br/>
                          <asp:CheckBox ID="D009" runat="server" AutoPostBack="True"   Text="保人不動產有民間設定記錄"/><br/>
                          <asp:CheckBox ID="D010" runat="server" AutoPostBack="True"   Text="保人不動產有限制登記記錄"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">授信展望</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="E001" runat="server" AutoPostBack="True"   Text="業務來源過於集中"/><br/>
                          <asp:CheckBox ID="E002" runat="server" AutoPostBack="True"   Text="屬夕陽產業"/><br/>
                          <asp:CheckBox ID="E003" runat="server" AutoPostBack="True"   Text="行業景氣衰退"/><br/>
                          <asp:CheckBox ID="E004" runat="server" AutoPostBack="True"   Text="市場萎縮"/><br/>
                          <asp:CheckBox ID="E005" runat="server" AutoPostBack="True"   Text="市場競爭激烈"/><br/>
                      </td>
                  </tr>
                  <tr>
                      <td style="text-align: center" class="style8">其他</td>
                      <td style="text-align: left" class="style7">
                          <asp:CheckBox ID="F001" runat="server" AutoPostBack="True"   Text="供應商額度明訂徵提文件、客戶限制條件及標的物條件"/><br/>
                          <asp:CheckBox ID="F002" runat="server" AutoPostBack="True"   Text="操作方式有誤或架構(申辦金額/成數/期數)不合理"/><br/>
                          <asp:CheckBox ID="F003" runat="server" AutoPostBack="True"   Text="與政策不符，會簽其他部門"/><br/>
                          <asp:CheckBox ID="F999" runat="server" AutoPostBack="True" oncheckedchanged="F999_CheckedChanged"  Text="其他："/>
                          <asp:TextBox ID="txtF999" runat="server" Width="250px" ></asp:TextBox><br/>
                      </td>
                  </tr>
              </table>                    
              <table>
                  <tr>      
	        	    <td>				
                    <asp:Button ID="cmdSURE" runat="server" Text="確定" OnClick="cmdSURE_Click"/>
                    <asp:Button ID="cmdBACK" runat="server" Text="關閉"  OnClick="cmdBACK_Click" />
                    </td>
                  </tr>    
             </table>
           
            <asp:HiddenField ID="SessUSERID" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTUID" runat="server" />
            <asp:HiddenField ID="SessUSERNM" runat="server" />
            <asp:HiddenField ID="SessLOGINTIME" runat="server" />
            <asp:HiddenField ID="SessEMPLID" runat="server" />
            <asp:HiddenField ID="SessBRNHCD" runat="server" />
            <asp:HiddenField ID="SessDBNM" runat="server" />
            <asp:HiddenField ID="SessMTSSVRNM" runat="server" />
            <asp:HiddenField ID="SessSQLSVRNM" runat="server" />
            <asp:HiddenField ID="SessSYSCD" runat="server" />
            <asp:HiddenField ID="SessGROUPID" runat="server" />
            <asp:HiddenField ID="SessDATAGP" runat="server" />
            <asp:HiddenField ID="SessDLRCD" runat="server" />
            <asp:HiddenField ID="SessDLRNM" runat="server" />
            <asp:HiddenField ID="SessDEPTID" runat="server" />
            <asp:HiddenField ID="SessDEPTNM" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTNM" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTID" runat="server" />
            <asp:HiddenField ID="SessFN_DEPTUID" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTNM" runat="server" />
            <asp:HiddenField ID="SessGV_DEPTID" runat="server" />
            <asp:HiddenField ID="REMOTEHOST" runat="server" />
            <asp:HiddenField ID="SUBSCD" runat="server" />
            <asp:HiddenField ID="PROGID" runat="server" />
            <asp:HiddenField ID="SessionString" runat="server" />           
           	
            </ContentTemplate>
        </asp:UpdatePanel>     
        </center>
    </form>
</body>
</html>
