<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3002D.aspx.cs" Inherits="FrmML3002D" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>期付款與付款時間內容顯示</title>
    <link rel="stylesheet" href="css/rent.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div>
                    <table align="center" width="300" class="tb_Info">
                        <tr>
                            <th style="width: 120px;text-align: center;">
                            </th>
                            <th style="width: 60px;text-align: center;">
                                顯示</th>
                            <th style="width: 60px;text-align: center;">
                                不顯示</th>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                期付款內容</td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optY1" runat="server" GroupName="SHOWMONEY" Checked="true"/></td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optN1" runat="server" GroupName="SHOWMONEY" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                付款時間內容</td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optY2" runat="server" GroupName="PAYDATE" Checked="true"/></td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optN2" runat="server" GroupName="PAYDATE" /></td>
                        </tr>
                        <!-- 20140714 ADD BY SS ADAM REASON.增加動產設定單位 -->
                        <tr>
                            <td style="text-align: center;">
                                動產設定單位</td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optIMVSETUP1" runat="server" GroupName="IMVSETUP" Text="經濟部中辦" /></td>
                            <td style="text-align: center;">
                                <asp:RadioButton ID="optIMVSETUP2" runat="server" GroupName="IMVSETUP" Text="五都經發局" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right">
                                <asp:Button ID="cmdPRTSURE" runat="server" Text="確認" OnClick="cmdPRTSURE_Click" />
                                <asp:Button ID="cmdPRTCANCEL" runat="server" Text="取消" OnClick="cmdPRTCANCEL_Click" /></td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hdCASEID" runat="server" />
                <asp:HiddenField ID="hdCNTRNO" runat="server" />
                <asp:HiddenField ID="hdRPTIDX" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
