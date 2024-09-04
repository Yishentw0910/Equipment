<%--20221031 隱藏客戶性質、集團實際負責人、母公司名稱、董監事股東、公司不動產欄位，行業別改為下拉式選單--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML1001.aspx.cs" inherits="FrmML1001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <link rel="stylesheet" href="css/rent.css" />
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <script language="javascript" src="js/Itg.js"></script>
    <script language="javascript" src="js/UI.js"></script>
    <script language="javascript" src="js/validate.js"></script>
    <script type="text/javascript">
    <!-- #Include file='js/ML1001.js' -->                   
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 269px;
        }

        .auto-style2 {
            height: 24px;
        }

        .auto-style3 {
            height: 22px;
        }
    </style>
</head>
<body onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <progresstemplate>
                <div id="div0" style="z-index: 999; left: 0px; width: 100%; position: absolute; top: 0px; height: 100%">
                    <table width="100%" height="100%">
                        <tr>
                            <td class="auto-style1">
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <contenttemplate>
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
                    <div class="divStatus">
                        <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_normal" OnClick="btnInsert_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn_normal" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" CssClass="btn_normal" Style="display: none"
                            OnClick="btnSearch_Click" />
                        <asp:HiddenField ID="hidSelRowIndex" runat="server" Value="-1" />
                        <asp:HiddenField ID="hidCustomer" runat="server" />
                        <span style="margin-left: 480px;">
                            <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
                        </span>
                    </div>
                    <div id="div_Info" class="div_Info">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="15%">客戶統編
                                </th>
                                <td width="17%">
                                    <asp:TextBox ID="txtCUSTID" onkeypress="OnlyNumDUCase(this);" onblur="CUSTID_onblur(this);"
                                        MaxLength="10" Width="85px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnSelect" runat="server" disabled="true" class="btn_normal"
                                        onclick="CustomerClick();" style="width: 23px; padding: 2px;" value="&#8230;" />
                                </td>
                                <th width="12%">客戶名稱
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCUSTNAME" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="240px">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客戶性質
                                </td>
                                <!--th width="13%">
                
              </th-->
                                <td colspan="1">
                                    <asp:DropDownList ID="drpCUTYPE" runat="server" DataTextField="MNAME1" onchange="CboChanged(this);"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th width="15%" class="auto-style2">登記資本額
                                </th>
                                <td width="16%" class="auto-style2">
                                    <asp:TextBox ID="txtCUSTCREATECAPTIAL" MaxLength="16" Width="112px" Text="" onkeypress="OnlyNum(this);"
                                        runat="server" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must_right">
                                    </asp:TextBox>
                                </td>
                                <td colspan="2" class="auto-style2">&nbsp;&nbsp; 實收資本額<asp:TextBox ID="txtCUSTNOWCAPTIAL" MaxLength="16" Width="112px"
                                    Text="" onkeypress="OnlyNum(this);" runat="server" onfocus="MoneyFocus(this)"
                                    onblur="MoneyBlur(this);" CssClass="txt_must_right"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;設立日期
                                </td>
                                <td colspan="1" class="auto-style2">
                                    <asp:TextBox ID="txtCUSTCREATEDATE" MaxLength="8" Width="77px" onkeypress="OnlyNum(this);"
                                        onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <%--20221031 改為隱藏--%>
                                <%--<th width="11%">
                                員工人數
                            </th>--%>
                                <td colspan="2" class="auto-style2">
                                    <asp:DropDownList ID="drpEMPLOYEE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE" Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>負責人
                                </th>
                                <td>
                                    <asp:TextBox ID="txtOWNER" runat="server" MaxLength="25" CssClass="txt_must"></asp:TextBox>
                                </td>
                                <th>身份ID
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtOWNERID" runat="server" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);"
                                        MaxLength="10" Width="100px" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                                <%--20221031 改為隱藏--%>
                                <%--<td colspan="3">集團實際負責人--%>
                                <asp:TextBox ID="txtGROUPOWNER" MaxLength="10" runat="server" CssClass="txt_normal" Visible="False"></asp:TextBox>
                                <%--</td>--%>
                            </tr>
                            <tr>
                                <th>公司屬性
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpCOMPTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                                <th>組織形態
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpORGATYPE" class="bg_F5F8BE" runat="server" Width="120px"
                                        DataTextField="MNAME1" DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="3">上市櫃
                                <asp:DropDownList ID="drpLISTED" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1"
                                    DataValueField="MCODE">
                                    <asp:ListItem>請選擇</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <%--20221031 改為隱藏--%>
                                    <%--母公司編號--%>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPARENTCUSTID" onkeypress="OnlyNum(this);" onblur="BANBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal" Visible="False">
                                    </asp:TextBox>
                                </td>
                                <th>
                                    <%--母公司名稱--%>
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPARENTCUSTNAME" MaxLength="100" runat="server" CssClass="txt_normal"
                                        Width="244px" Visible="False">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>公司登記地址
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtCUSTZIPCODE" MaxLength="5" onkeypress="OnlyNum(this);" runat="server"
                                        onblur="PostCodeBlure('C',this)" Width="24px" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnCUSTZIPCODES" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('txtCUSTADDR');" onclick="PostCodeClick('C');" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="txtCUSTZIPCODES" Enabled="false" runat="server" Width="120px" CssClass="txt_must"></asp:TextBox>
                                    <%--<input type ="text" id="txtCUSTZIPCODES" disabled ="true" runat="server" width="120px" class="txt_must" />--%>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtCUSTADDR" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="216px">
                                </asp:TextBox>
                                    <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server"
                                        Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>公司登記電話
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        Width="20px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtCUSTTEL" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <th>傳真
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtCUSTFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtCUSTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>營業地址
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtBUSINESSZIPCODE" onkeypress="OnlyNum(this);" MaxLength="5" runat="server"
                                        onblur="PostCodeBlure('B',this)" Width="24px" CssClass="txt_must">
                                    </asp:TextBox>
                                    <input type="button" id="btnBUSINESSZIPCODE" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('txtBUSINESSADDR');" onclick="PostCodeClick('B');" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="txtBUSINESSZIPCODES" Enabled="false" runat="server" Width="120px"
                                        CssClass="txt_must">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtBUSINESSADDR" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="216px">
                                </asp:TextBox>
                                    <%--<asp:CheckBox ID="chkBUSINESSADDRS" runat="server" onClick="chkBusAddClick(this)" />--%>
                                    <br />
                                    <input type="checkbox" id="chkBUSINESSADDRS" name="chkBUSINESSADDRS" value="" onclick="chkBusAddClick(this)">同公司登記地址與電話
                                </td>
                            </tr>
                            <tr>
                                <th>營業電話
                                </th>
                                <td>
                                    <asp:TextBox ID="txtBUSINESSTTELCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_must">
                                    </asp:TextBox>
                                </td>
                                <th>傳真
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtBUSINESSFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="3" Width="20px" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                        MaxLength="10" runat="server" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>主要營業項目
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="txtBUSINESS" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="85%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>行業別
                                </th>
                                <td colspan="6">
                                    <!-- 20160322 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                                    <%-- 20221031 行業別改下拉選單 --%>
                                    <asp:DropDownList ID="DrpNDU" class="bg_F5F8BE" runat="server" Width="200px" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:TextBox ID="txtINDUID" MaxLength="7" class="txt_must" runat="server" onblur="txtINDUID_onblur(this);" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtINDUNM" Enable="false" runat="server" CssClass="txt_normal" Width="200px" Visible="False"></asp:TextBox>
                                    <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="False" />

                                    <!-- 20160322 ADD BY SS ADAM REASON.新增行業別 ====END====-->
                                    <asp:DropDownList ID="drpCUROUT" class="bg_F5F8BE" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE" Style="display: none;">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpCUROUTF" Style="display: none" runat="server" DataTextField="DNAME1"
                                        DataValueField="DCODE">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>備註
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="tbxMemo" runat="server" MaxLength="30"
                                        Width="500px" CssClass="txt_normal">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>ACH扣款銀行代碼
                                </th>
                                <td colspan="6">
                                    <asp:TextBox ID="ACHBANKCODE" MaxLength="5" onkeypress="OnlyNum(this);" runat="server"
                                        onblur="ACHBANKBlure(this)" Width="56px" CssClass="txt_must" Enabled="false">
                                    </asp:TextBox>
                                    <input type="button" id="btnACHBANKCODE" runat="server" disabled="true" class="btn_normal"
                                        onfocus="ObjFocus('ACHBANKCODE');" onclick="ACHBANKClick();" style="width: 25px; padding: 2px;"
                                        value="&#8230;" />
                                    <asp:TextBox ID="ACHBANKCODES" Enabled="false" runat="server" Width="200px" CssClass="txt_must"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ACH扣款帳戶
                                <asp:TextBox ID="ACHACCOUNT" MaxLength="100" runat="server" CssClass="txt_must"
                                    Width="180px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="auto-style3">ACH扣款統編</th>
                                <td colspan="1" class="auto-style3">
                                    <asp:TextBox ID="ACHID" MaxLength="10" Width="100px" runat="server" CssClass="txt_must" onkeypress="OnlyNumDUCase(this);" onblur="CUSTID_onblur(this);>
                                    </asp:TextBox>
                                </td>
                                <th class="auto-style3">ACH扣款戶名</th>
                                <td colspan="6" class="auto-style3">
                                    <asp:TextBox ID="ACHNAME" MaxLength="100" runat="server" CssClass="txt_must"
                                        Width="216px">
                                    </asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;扣款日 
                                        <asp:DropDownList ID="ACHPAYDAY" runat="server">
                                            <asp:ListItem Value="">請選擇</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                            <asp:ListItem Value="27">27</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <%--20221031 改為隱藏--%>
                                <%--<th>
                                公司簡易沿革
                            </th>--%>
                                <td colspan="7">
                                    <asp:TextBox ID="tbxCUSTINTRO" runat="server" MaxLength="50"
                                        Width="500px" CssClass="txt_must" Visible="False">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        </asp:UpdatePanel>
                        <asp:Repeater ID="rptDirStock" runat="server">
                        </asp:Repeater>
                        <%--20221031 改為隱藏--%>
                        <%--<div class="divGrid1001" >
                        <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                            <tr>
                                <td width="5%" align="right">
                                    董監事股東
                                </td>
                                <td width="30%" align="left">
                                    &nbsp; <span style="color: Red">[ 新增請按F8&nbsp;&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style= "overflow:auto;width:100%;height:98%;">
                                    <table class="tb_Contact" width="98%" style="margin: 0 auto; margin-bottom: 5px;">
                                        <tr onclick="changeTag('rptDirStock')">
                                            <th>
                                                職稱
                                            </th>
                                            <th>
                                                姓名
                                            </th>
                                            <th>
                                                性別
                                            </th>
                                            <th>
                                                年齡
                                            </th>
                                            <th>
                                                投資金額
                                            </th>
                                            <th>
                                                備註
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="rptDirStock" runat="server">
                                            <ItemTemplate>
                                                <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                    <td>
                                                        <asp:TextBox ID="txtTITLENM" MaxLength="20" runat="server" Text='<%# Eval("TITLENM")%>'
                                                            CssClass="txt_table" Width="80px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNAME" MaxLength="10" runat="server" Text='<%# Eval("NAME")%>'
                                                            CssClass="txt_must" Width="60px" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSEX" MaxLength="3" runat="server" Text='<%# Eval("SEX")%>'
                                                            Width="65px">
                                                            <asp:ListItem Value="">請選擇</asp:ListItem>
                                                            <asp:ListItem Value="男">男</asp:ListItem>
                                                            <asp:ListItem Value="女">女</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAGE" runat="server" MaxLength="3" Text='<%# Eval("AGE")%>' onkeypress="OnlyNum(this);"
                                                            onblur="OnlyNumBlur(this);"  CssClass="txt_table" Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtINVAMT" runat="server" MaxLength="16" Text='<%# Eval("INVAMT")%>'
                                                           onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must" Width="120px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMEMO" runat="server" MaxLength="50" Text='<%# Eval("MEMO")%>'
                                                            CssClass="txt_table" Width="200px" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                        <div class="divGrid1001">
                            <!--div id="fraOTOutside" style="margin-left: 2px; border-right: #0B79FF 1px solid;
            border-top: #0B79FF 1px solid; z-index: -99999999; visibility: visible; border-left: #0B79FF 1px solid;
            width: 99%; cursor: default; border-bottom: #0B79FF 0px solid; height: 180px; background-color: #ffffff"-->
                            <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                                <tr>
                                    <td width="5%" align="right">關係聯絡人
                                    </td>
                                    <td width="30%" align="left">&nbsp; <span style="color: Red">[ 新增請按F8&nbsp;&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
                                    <div style="overflow: auto; width: 100%; height: 98%;">
                                        <table class="tb_Contact" width="98%" style="margin: 0 auto; margin-bottom: 5px;">
                                            <tr onclick="changeTag('rptContact')">
                                                <th>姓名
                                                </th>
                                                <th>部門
                                                </th>
                                                <th>職稱
                                                </th>
                                                <th>聯絡電話
                                                </th>
                                                <th>手機
                                                </th>
                                                <th>傳真
                                                </th>
                                                <th>Email
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptContact" runat="server">
                                                <itemtemplate>
                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTNAME" MaxLength="10" runat="server" Text='<%# Eval("CONTACTNAME")%>'
                                                                CssClass="txt_must" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDEPTNAME" MaxLength="50" runat="server" Text='<%# Eval("DEPTNAME")%>'
                                                                CssClass="txt_table" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTITLE" MaxLength="10" runat="server" Text='<%# Eval("CONTACTTITLE")%>'
                                                                CssClass="txt_table" Width="60px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTELCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' CssClass="txt_must"
                                                                Width="24px" />
                                                            <asp:TextBox ID="txtCONTACTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTTEL")%>' CssClass="txt_must"
                                                                Width="80px" />
                                                            <asp:TextBox ID="txtCONTACTTELEXT" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="5" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' CssClass="txt_table"
                                                                Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTMPHONE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' CssClass="txt_table"
                                                                Width="80px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTFAXCODE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' CssClass="txt_table"
                                                                Width="24px" />
                                                            <asp:TextBox ID="txtCONTACTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="10" runat="server" Text='<%# Eval("CONTACTFAX")%>' CssClass="txt_table"
                                                                Width="80px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTEMAIL" onblur="EMAILBlur(this);" MaxLength="50" runat="server"
                                                                Text='<%# Eval("CONTACTEMAIL")%>' CssClass="txt_table" />
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        </asp:UpdatePanel>
                        <asp:Repeater ID="rptIMMOVABLE" runat="server">
                        </asp:Repeater>
                        <%--20221031 改為隱藏--%>
                        <%--<div class="divGrid1001">
                        <!--div id="fraOTOutside" style="margin-left: 2px; border-right: #0B79FF 1px solid;
            border-top: #0B79FF 1px solid; z-index: -99999999; visibility: visible; border-left: #0B79FF 1px solid;
            width: 99%; cursor: default; border-bottom: #0B79FF 0px solid; height: 180px; background-color: #ffffff"-->
                        <table cellpadding="1" cellspacing="1" border="0" class="tb_title_Info">
                            <tr>
                                <td width="5%" align="right">
                                    公司不動產
                                </td>
                                <td width="30%" align="left">
                                    &nbsp; <span style="color: Red">[ 新增請按F8&nbsp;&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="overflow: auto; height:95%">
                                    <table class="tb_Contact" width="220%" style="margin: 0 auto; margin-bottom: 5px;">
                                    <tr onclick="changeTag('rptIMMOVABLE')">
                                        <th style="width:5%">所有權人</th>
                                        <th style="width:5%">購入日期</th>
                                        <th style="width:5%">用途</th>
                                        <th style="width:5%">座落位置</th>
                                        <th style="width:5%">面積(坪)</th>
                                        <th style="width:5%">持分</th>
                                        <th style="width:7%">持有面積(坪)</th>
                                        <th style="width:7%">第一順位設定</th>
                                        <th style="width:7%">第一順位銀行	</th>
                                        <th style="width:8%">第一順位債務人</th>
                                        <th style="width:8%">第一順位設定金額</th>
                                        <th style="width:8%">第二順位設定</th>
                                        <th style="width:8%">第二順位銀行</th>
                                        <th style="width:8%">第二順位債務人</th>
                                        <th style="width:8%">第二順位設定金額</th>
                                    </tr>
                                    <asp:Repeater ID="rptIMMOVABLE" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('<%# Container.ItemIndex  %>')">
                                                <td>
                                                    <asp:TextBox ID="txtOWNER" MaxLength="50" runat="server" Text='<%# Eval("OWNER")%>' CssClass="txt_must" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBUYDATE" MaxLength="10" runat="server" Text='<%# Eval("BUYDATE")%>' CssClass="txt_must" Width="80px"  onfocus="dateFocus(this)" onblur="dateBlur(this);" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAPP" MaxLength="50" runat="server" Text='<%# Eval("APP")%>' CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLOCATION" MaxLength="50" runat="server" Text='<%# Eval("LOCATION")%>' CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAREA" MaxLength="50" runat="server" Text='<%# Eval("AREA")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHOLDER" MaxLength="50" runat="server" Text='<%# Eval("HOLDER")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHOLDERAREA" MaxLength="50" runat="server" Text='<%# Eval("HOLDERAREA")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_must" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPICKSET1" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"  MaxLength="3" runat="server" Text='<%# Eval("PICKSET1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxBANK1" MaxLength="100" runat="server" Text='<%# Eval("BANK1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDEBTOR1" MaxLength="50" runat="server" Text='<%# Eval("DEBTOR1")%>' CssClass="txt_table" Width="80px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxSETAMT1" MaxLength="15" runat="server" Text='<%# Eval("SETAMT1")%>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"  CssClass="txt_table" Width="100px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxPICKSET2" MaxLength="50" runat="server" Text='<%# Eval("PICKSET2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxBANK2" MaxLength="100" runat="server" Text='<%# Eval("BANK2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDEBTOR2" MaxLength="50" runat="server" Text='<%# Eval("DEBTOR2")%>' CssClass="txt_table" Width="60px" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxSETAMT2"   MaxLength="15" runat="server" Text='<%# Eval("SETAMT2")%>'  onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"   CssClass="txt_table" Width="100px" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                    </div>
                    <div class="btn_div">
                        <asp:Button ID="btnSubmit" runat="server" Text="儲存確認" Enabled="false" CssClass="btn_normal"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnAdd" Style="display: none" runat="server" Text="" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDel" Style="display: none" runat="server" Text="" OnClick="btnDel_Click" />
                        <asp:Button ID="btnQue" Style="display: none" runat="server" Text="" OnClick="btnQue_Click" />
                        <%-- 20221031 若設備無資料從長租帶資料 --%>
                        <asp:Button ID="btnQue2" Style="display: none" runat="server" Text="" OnClick="btnQue2_Click" />
                    </div>
                </div>
                <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
            </contenttemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
