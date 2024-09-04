<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmSelectPrepay.aspx.cs" Inherits="FrmSelectPrepay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <base target="_self" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>選擇預撥沖銷</title>
    <link rel="stylesheet" href="css/rent.css" />
    <script type="text/javascript" language="javascript" src="js/UI.js"></script>

    <script language="javascript" src="js/Itg.js"></script>

    <script language="javascript" src="js/validate.js"></script>
    <script type="text/javascript" src="js/SelectPrepay.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <div class="div_table" style="overflow: auto; height: 100px">
            <asp:UpdatePanel ID="UpdatePanelMLDPREPAYMF" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table class="tb_Contact" width="80%">
                <tr>
                    <th>
                        項次
                    </th>
                    <th>
                        預撥ID
                    </th>
                    <th>
                        預撥對象
                    </th>
                    <th>
                        預撥金額
                    </th>
                    <th>
                        預撥日
                    </th>
                    <th>
                        沖銷
                    </th>
                    <th>
                        沖銷金額
                    </th>
                    <th>
                        墊款息
                    </th>
                </tr>
                <asp:Repeater ID="rptMLDPREPAYMF" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Container.ItemIndex +1 %>
                                <asp:HiddenField ID="hdSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="txtPREPAYMFID" runat="server" Text='<%# Eval("PREPAYID") %>' 
                                    CssClass="txt_table" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPREPAYMF" runat="server" Text='<%# Eval("PREPAYOBJ") %>' 
                                    CssClass="txt_table" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("PREPAYAMT").ToString()) %>' 
                                    CssClass="txt_table_right" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPREPAYDATE" runat="server" Text='<%# Eval("PREPAYDATE") %>' 
                                    CssClass="txt_table" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkWRITEOFF" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtWRITEOFFAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("WRITEOFFAMT").ToString()) %>' 
                                    CssClass="txt_table_right" Width="100px" onblur="txtWRITEOFFAMT_onblur(this);MoneyBlur(this);" onkeypress="OnlyNum(this);"></asp:TextBox>
                                <asp:HiddenField ID="hdMAXWRITEOFFAMT" runat="server" Value='<%# Eval("MAXWRITEOFFAMT") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="txtADVANCESINTEREST" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("ADVANCESINTEREST").ToString())  %>' 
                                    CssClass="txt_table_right" Width="100px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <div style="text-align:center;">
                <asp:Button ID="btnSURE" runat="server" Text="確認" OnClick="btnSURE_Click" />
                <asp:HiddenField ID="hdCASEID" runat="server" />
                <asp:HiddenField ID="hdCNTRNO" runat="server" />
                <asp:HiddenField ID="hdPRENTSTDT" runat="server" />
                <asp:HiddenField ID="hdPAYDATE" runat="server" />
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
