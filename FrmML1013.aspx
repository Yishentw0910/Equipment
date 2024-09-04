<%@ page language="C#" autoeventwireup="true" codefile="FrmML1013.aspx.cs" inherits="FrmML1013" %>

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

</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <script type="text/javascript" language="javascript">                   
</script>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <progresstemplate>
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
            </progresstemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
                    <div id="fraDispTypeInfo" class="frame_content div_Info " style="min-height: 30px; height: auto !important;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="12%">承作型態
                                </th>
                                <td width="12%">
                                    <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <th width="12%">
                                    <asp:UpdatePanel ID="UpdatePaneldrpSUBTYPE" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </th>
                                <th width="12%">交易形態
                                </th>
                                <td width="12%">
                                    <asp:UpdatePanel ID="UpdatePaneldrpTRANSTYPE" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <asp:DropDownList ID="drpTRANSTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <th width="12%">案件產品別 </th>
                                <th width="12%">
                                    <asp:DropDownList ID="drpPRODCD" runat="server" class="bg_F5F8BE" DataTextField="MNAME1" DataValueField="MCODE"  AutoPostBack="true">
                                    </asp:DropDownList>
                                </th>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:HiddenField ID="RNAME" runat="server" Value="" />
                <asp:HiddenField ID="RTYPE" runat="server" Value="" />
            </contenttemplate>
        </asp:UpdatePanel>

        <div class="btn_div">
            <asp:Button ID="cmdPrintReportA" runat="server" Text="列印" CssClass="btn_normal" OnClick="cmdPrintReportA_Click" />
            <asp:Button ID="btnClear" runat="server" Text="清除" CssClass="btn_normal" OnClick="btnClear_Click" />
        </div>
    </form>
</body>
</html>
