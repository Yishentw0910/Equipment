<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML1014.aspx.cs" Inherits="FrmML1014" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <link rel="stylesheet" href="css/rent.css" />
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5"/>
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT"/>
    <meta http-equiv="Pragma" content="no-cache"/>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />

    <script type="text/javascript" language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>
    <script type="text/javascript" language="javascript">
        function Limit10(obj) {
            var num = obj.value;
            if (num > 100000) {
                obj.value = 100000;
            }
        }
        var $ = document.getElementById;
        function cmdPrintA_onClick(obj) {
            var Result = $("<%=this.rdoINSURANCE.ClientID %>");
            var INSURANCE = "";
            for (var i = 0; i < Result.rows.length; i++) {
                if (Result.rows[0].cells[i].childNodes[i].checked) {
                    INSURANCE = Result.rows[0].cells[i].childNodes[0].value;
                } 
            }
            var LSTR_QUERY = "";
            LSTR_QUERY += ";" + "MAINTYPE=" + $("<%=this.drpMAINTYPE.ClientID %>").value;
            LSTR_QUERY += ";" + "SUBTYPE=" + $("<%=this.drpSUBTYPE.ClientID %>").value;
            LSTR_QUERY += ";" + "OTHERFEES=" + $("<%=this.txtOTHERFEES.ClientID %>").value;
            LSTR_QUERY += ";" + "OTHERFEESNOTAX=" + $("<%=this.txtOTHERFEESNOTAX.ClientID %>").value;
            LSTR_QUERY += ";" + "COMMISSION=" + $("<%=this.txtCOMMISSION.ClientID %>").value;
            LSTR_QUERY += ";" + "RESIDUALS=" + $("<%=this.txtRESIDUALS.ClientID %>").value;
            LSTR_QUERY += ";" + "INSURANCE=" + INSURANCE;
            LSTR_QUERY += ";" + "TARGETTYPE=" + $("<%=this.drpTARGETTYPE.ClientID %>").value.substring(0,2);
            LSTR_QUERY += ";" + "PAYTIMET=" + $("<%=this.drpPAYTIMET.ClientID %>").value;
            LSTR_QUERY += ";" + "CONTRACTMONTH=" + $("<%=this.txtCONTRACTMONTH.ClientID %>").value;
            LSTR_QUERY += ";" + "PAYMONTH=" + $("<%=this.txtPAYMONTH.ClientID %>").value;
            LSTR_QUERY += ";" + "PATDAYS=" + $("<%=this.txtPATDAYS.ClientID %>").value;

            if (parseFloat($("<%=this.IRR1.ClientID %>").value) < parseFloat($("<%=this.IRR2.ClientID %>").value)) {
                LSTR_QUERY += ";" + "IRRSTART=" + $("<%=this.IRR1.ClientID %>").value;
                LSTR_QUERY += ";" + "IRREND=" + $("<%=this.IRR2.ClientID %>").value;
            } else {
                LSTR_QUERY += ";" + "IRRSTART=" + $("<%=this.IRR2.ClientID %>").value;
                LSTR_QUERY += ";" + "IRREND=" + $("<%=this.IRR1.ClientID %>").value;
            }
            LSTR_QUERY += ";" + "arrayString=" + $("<%=this.hidarrayString.ClientID %>").value;

            //alert(LSTR_QUERY)
            //列印
            ReportPrint("<%=this.cRepotr%>" + "/ReportPrint.aspx",
            "<%=this.cUrl%>",
            "<%=this.cPath%>",
            "<%=this.cUserName%>",
            "<%=this.cPass%>",
            "<%=this.cCompany%>",
                "LE",
                "ml1014_1_rpt1",
                LSTR_QUERY);
        }

    </script>

    <%--  <script type="text/javascript" language="javascript">
  </script>--%>
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }

        .auto-style2 {
            height: 22px;
        }
    </style>
</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <script type="text/javascript" language="javascript">
</script>

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
                        <hr />
                    </td>
                </tr>
            </table>
            <div id="fraDispTypeInfo" class="frame_content div_Info " style="height: auto !important;">
                <table cellpadding="1" cellspacing="1" class="tb_Info">
                    <tr>
                        <th>案件類型
                        </th>
                        <td>
                            <asp:DropDownList ID="drpMAINTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" AutoPostBack="true" Height="20px" Width="80px" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpSUBTYPE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" AutoPostBack="true" Height="20px" Width="100px" OnSelectedIndexChanged="drpSUBTYPE_SelectedIndexChanged">
                                <asp:ListItem Value="01">事務機</asp:ListItem>
                                <asp:ListItem Value="02" Selected="True">非事務機</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>作業費用(有發票)
                        </th>
                        <td>
                            <asp:TextBox ID="txtOTHERFEES" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this);" Text="0" onblur="Limit10(this);MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>作業費用(無發票)
                        </th>
                        <td>
                            <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="Limit10(this);MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="auto-style1">佣金
                        </th>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtCOMMISSION" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="Limit10(this);MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>殘值
                        </th>
                        <td>
                            <asp:TextBox ID="txtRESIDUALS" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="Limit10(this);MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="TARGETTYPE" runat="server">
                        <th class="auto-style2">標的物種類</th>
                        <td class="auto-style2">
                            <asp:DropDownList ID="drpTARGETTYPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Height="20px" Width="150px" OnSelectedIndexChanged="drpSUBTYPE_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>保險費</th>
                        <td>
                            <asp:RadioButtonList ID="rdoINSURANCE" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdoINSURANCE_SelectedIndexChanged">
                                <asp:ListItem Text="有" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="無" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:TextBox ID="txtINSURANCE" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="Limit10(this);MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>付款時間</th>
                        <td>
                            <asp:DropDownList ID="drpPAYTIMET" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Height="20px" Width="80px">
                                <asp:ListItem  Value="01">期初付</asp:ListItem>
                                <asp:ListItem  Value="02">期末付</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>期數
                        </th>
                        <td>
                            <asp:TextBox ID="txtCONTRACTMONTH" onkeyup="txtCONTRACTMONTH_KeyUp(this);" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="2" runat="server" CssClass="txt_normal_right">36</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>幾月一付
                        </th>
                        <td>
                            <asp:TextBox ID="txtPAYMONTH" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="2" runat="server" CssClass="txt_normal_right">1</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>付款差異天數
                        </th>
                        <td>
                            <asp:TextBox ID="txtPATDAYS" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" runat="server" MaxLength="3" Text="0" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>期望IRR</th>
                        <td>
                            <asp:DropDownList ID="IRR1" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Height="20px" Width="45px">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>0.5</asp:ListItem>
                                <asp:ListItem>1.0</asp:ListItem>
                                <asp:ListItem>1.5</asp:ListItem>
                                <asp:ListItem>2.0</asp:ListItem>
                                <asp:ListItem>2.5</asp:ListItem>
                                <asp:ListItem>3.0</asp:ListItem>
                                <asp:ListItem>3.5</asp:ListItem>
                                <asp:ListItem>4.0</asp:ListItem>
                                <asp:ListItem>4.5</asp:ListItem>
                                <asp:ListItem>5.0</asp:ListItem>
                                <asp:ListItem>5.5</asp:ListItem>
                                <asp:ListItem>6.0</asp:ListItem>
                                <asp:ListItem>6.5</asp:ListItem>
                                <asp:ListItem>7.0</asp:ListItem>
                                <asp:ListItem>7.5</asp:ListItem>
                                <asp:ListItem>8.0</asp:ListItem>
                                <asp:ListItem>8.5</asp:ListItem>
                                <asp:ListItem>9.0</asp:ListItem>
                                <asp:ListItem>9.5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            %
                            ～
                            <asp:DropDownList ID="IRR2" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Height="20px" Width="45px">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>0.5</asp:ListItem>
                                <asp:ListItem>1.0</asp:ListItem>
                                <asp:ListItem>1.5</asp:ListItem>
                                <asp:ListItem>2.0</asp:ListItem>
                                <asp:ListItem>2.5</asp:ListItem>
                                <asp:ListItem>3.0</asp:ListItem>
                                <asp:ListItem>3.5</asp:ListItem>
                                <asp:ListItem>4.0</asp:ListItem>
                                <asp:ListItem>4.5</asp:ListItem>
                                <asp:ListItem>5.0</asp:ListItem>
                                <asp:ListItem>5.5</asp:ListItem>
                                <asp:ListItem>6.0</asp:ListItem>
                                <asp:ListItem>6.5</asp:ListItem>
                                <asp:ListItem>7.0</asp:ListItem>
                                <asp:ListItem>7.5</asp:ListItem>
                                <asp:ListItem>8.0</asp:ListItem>
                                <asp:ListItem>8.5</asp:ListItem>
                                <asp:ListItem>9.0</asp:ListItem>
                                <asp:ListItem>9.5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            %
                        </td>
                    </tr>
                    <asp:HiddenField ID="hidarrayString" runat="server" Value="" />
                </table>
            </div>
            <div class="btn_div">
                <asp:Button ID="btnSubmit" Enabled="true" runat="server" Text="產出基數表" OnClick="btnSubmit_Click" CssClass="btn_normal" />
            </div>
        </div>
    </form>
</body>
</html>
