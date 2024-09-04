<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML6001A																					
* 程式功能  : 案件/合約查詢																			
* 程式作者 	: 																			
* 完成時間 	: 
* 修改事項 	: 
Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.
Modify 20130117 BY    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」
Modify 20130510 By SS Brent.  Reason:加入附追索權下拉選單
Modify 20130703 By SS Eric    Reason:新增保險異常欄位
Modify 20131115 By SS Leo     Reason:新增擔保價值
Modify 20131210 BY    SEAN    Reason:修正不動產項次取號問題
Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏
Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本
20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%)
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML6001A.aspx.cs" Inherits="FrmML6001A" %>

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
    <!-- #Include file='js/ML6001A.js' -->                   
    </script>
</head>
<body onload="window_onload();showTag();">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                            <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                        </td>
                    </tr>
                </table>
                <table class="divStatus" width="50%">
                    <tr>
                        <th>
                            案件編號
                        </th>
                        <td>
                            <asp:TextBox ID="txtCASEID" runat="server" CssClass="txt_readonly" Width="105px"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                        <th>
                            申請日
                        </th>
                        <td>
                            <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div id="fraDispTypeInfo" class="frame_content div_Info H_855">
                    <%--客戶資料Begin --%>
                    <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu">
                        <label class="label_contain">
                            客戶資料</label>
                    </div>
                    <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu T_-24 L_125">
                        <label class="label_contain">
                            案件內容</label>
                    </div>
                    <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu T_-48 L_250">
                        <label class="label_contain">
                            標的物</label>
                    </div>
                    <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu T_-72 L_375">
                        <label class="label_contain">
                            擔保條件</label>
                    </div>
                    <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu T_-96 L_500">
                        <label class="label_contain">
                            徵審資料</label>
                    </div>
                    <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                        class="sheet div_menu W_124 T_-120 L_625">
                        <label class="label_contain">
                            案件報告</label>
                    </div>
                    <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: none">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="15%">
                                    客戶統編
                                </th>
                                <td width="15%">
                                    <asp:TextBox ID="txtCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th width="15%">
                                    客戶名稱
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="230px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 客戶性質
                                    <asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    登記資本額
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                        Width="112px" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    實收資本額
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                        Width="112px" ReadOnly="true"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;設立日期
                                    <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                        Width="81px" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    負責人
                                </th>
                                <td>
                                    <asp:TextBox ID="txtOWNER" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    身份ID
                                </th>
                                <td>
                                    <asp:TextBox ID="txtOWNERID" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="112px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;集團實際負責人
                                    <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    公司屬性
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpCOMPTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false" Width="80px">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th>
                                    組織形態
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpORGATYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Width="120px" Enabled="false">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;上市櫃
                                    <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Width="86px" Enabled="false">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    母公司統編
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    母公司名稱
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="276px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    公司登記地址
                                </th>
                                <td colspan="2">
                                    <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="40px" CssClass="txt_readonly"
                                        ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="276px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    公司登記電話
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                    <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    傳真
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                    <asp:TextBox ID="txtCUSTFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    營業登記地址
                                </th>
                                <td colspan="2">
                                    <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="40px" CssClass="txt_readonly"
                                        ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="276px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    營業登記電話
                                </th>
                                <td>
                                    <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    傳真
                                </th>
                                <td>
                                    <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                    <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    主要營業項目
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="80%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    行業別
                                </th>
                                <td colspan='3'>
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                                    <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px"></asp:TextBox>
                                    <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" CssClass="btn_normal" Enabled="false" />
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ====END====-->
                                    <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false" Width="100%" style="display:none;">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpCUROUTF" Style="display: none" DataTextField="DNAME1" DataValueField="DCODE"
                                        runat="server" Enabled="false" Width="50%">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    票信瑕疵
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpDEFECTIVE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false" Width="100%">
                                        <asp:ListItem Value="">請選擇</asp:ListItem>
                                        <asp:ListItem Value="Y">有</asp:ListItem>
                                        <asp:ListItem Value="N">無</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan='2'>
                                    <span style="color: Red">說明： 此客戶（公司或負責人）近三年有無票信瑕疵</span>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    決策人
                                </th>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                        <table class="tb_Contact" width="100%">
                                            <tr>
                                                <th>
                                                    姓名
                                                </th>
                                                <th>
                                                    部門
                                                </th>
                                                <th>
                                                    職稱
                                                </th>
                                                <th>
                                                    聯絡電話
                                                </th>
                                                <th>
                                                    手機
                                                </th>
                                                <th>
                                                    傳真
                                                </th>
                                                <th>
                                                    Email
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptContactM" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                                Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                                Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                                runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                                runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                                Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    案件聯絡人
                                </th>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                        <table class="tb_Contact" width="100%">
                                            <tr>
                                                <th>
                                                    姓名
                                                </th>
                                                <th>
                                                    部門
                                                </th>
                                                <th>
                                                    職稱
                                                </th>
                                                <th>
                                                    聯絡電話
                                                </th>
                                                <th>
                                                    手機
                                                </th>
                                                <th>
                                                    傳真
                                                </th>
                                                <th>
                                                    Email
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptContactC" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
                                                                Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
                                                                runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAXCODE"
                                                                runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAX" runat="server"
                                                                Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    發票聯絡人
                                </th>
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                        <table class="tb_Contact" width="150%;">
                                            <tr>
                                                <th>
                                                    姓名
                                                </th>
                                                <th>
                                                    部門
                                                </th>
                                                <th>
                                                    職稱
                                                </th>
                                                <th>
                                                    聯絡電話
                                                </th>
                                                <th>
                                                    手機
                                                </th>
                                                <th>
                                                    傳真
                                                </th>
                                                <th>
                                                    Email
                                                </th>
                                                <th>
                                                    發票寄送地
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptContactI" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
                                                                Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                                runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                                Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                                runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
                                                                runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                                runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                                Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                                Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="60px" Enabled="false" CssClass="txt_table"
                                                                Text='<%# Eval("INVZIPCODE")%>'></asp:TextBox>
                                                            <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" Enabled="false" CssClass="txt_table"
                                                                Text='<%# Eval("INVZIPCODES")%>'></asp:TextBox>
                                                            <asp:TextBox ID="txtINVOICEADDR" runat="server" Enabled="false" CssClass="txt_table"
                                                                Width="150px" Text='<%# Eval("INVOICEADDR")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--客戶資料End --%>
                    <%--案件內容Begin --%>
                    <div id="fraTab22" class="div_content padleft_0 T_-120" style="display: none">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <%--Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示--%>
                            <tr>
                                <th>
                                專案別
                                </th>
                                <td colspan="8">
                                    <asp:DropDownList ID="drpPROJCD" runat="server" Enabled="false">
                                        <asp:ListItem Value="01">一般</asp:ListItem>
                                        <asp:ListItem Value="02">重車</asp:ListItem>
                                        <asp:ListItem Value="03">事務機</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th width="12%">
                                    公司名稱
                                </th>
                                <td width="12%">
                                    <asp:DropDownList ID="drpCOMPID" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>和潤</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <%--Modify 20120717 By SS Gordon. Reason: 新增承作方式.--%>
                                <th width="12%">
                                    承作方式
                                </th>
                                <td width="12%">
                                    <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                        Enabled="false">
                                    </asp:DropDownList>
                                </td>
                                <th width="12%">
                                    承做型態
                                </th>
                                <td width="12%">
                                    <asp:DropDownList ID="drpMAINTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>營業型租賃</asp:ListItem>
                                        <asp:ListItem>資本型租賃</asp:ListItem>
                                        <asp:ListItem>附條件買賣</asp:ListItem>
                                        <asp:ListItem>應收帳款受讓</asp:ListItem>
                                        <asp:ListItem>分期付款(無擔)</asp:ListItem>
                                        <asp:ListItem>分期付款(有擔)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="12%">
                                    <asp:DropDownList ID="drpSUBTYPE" DataTextField="DNAME1" DataValueField="DCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>營業型租賃</asp:ListItem>
                                        <asp:ListItem>資本型租賃</asp:ListItem>
                                        <asp:ListItem>附條件買賣</asp:ListItem>
                                        <asp:ListItem>應收帳款受讓</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th width="12%">
                                    交易形態
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpTRANSTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>兩方</asp:ListItem>
                                        <asp:ListItem>三方</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    動用情形
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>單筆動用</asp:ListItem>
                                        <asp:ListItem>多筆動用</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>循環</asp:ListItem>
                                        <asp:ListItem>不循環</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th>
                                    代印店
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem Value="">請選擇</asp:ListItem>
                                        <asp:ListItem Value="Y">是</asp:ListItem>
                                        <asp:ListItem Value="N">否</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <%--Modify 20120717 By SS Gordon. Reason: 新增銀行別.--%>
                                <th>
                                    銀行別
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                        Enabled="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            </tr>
                            <tr>
                                <th>
                                    案件來源
                                </th>
                                <td colspan="2">
                                    <asp:DropDownList ID="drpCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>長租CR</asp:ListItem>
                                        <asp:ListItem>設備CR</asp:ListItem>
                                        <asp:ListItem>供應商介紹</asp:ListItem>
                                        <asp:ListItem>客戶來電</asp:ListItem>
                                        <asp:ListItem>同業介紹</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <%--Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單--%>
                                <th>
                                    附追索權
                                </th>
                                <td colspan="5">
                                    <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="drpRECOURSE" runat="server">
                                                <asp:ListItem Value="">請選擇</asp:ListItem>
                                                <asp:ListItem Value="Y">是</asp:ListItem>
                                                <asp:ListItem Value="N">否</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                          <tr>
                            <th>
                                案件產品別
                            </th>
                            <td colspan="8">
                                <asp:DropDownList ID="drpPRODCD" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false">
                              </asp:DropDownList>
                            </td>
                            </tr>
                            <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 END-->
                        </table>
                        <div>
                            <div class="left_div">
                                <table class="tb_Info" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td colspan="5">
                                            <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />分期、租賃案件
                                        </td>
                                        <td colspan="1">
                                            <%--Modify 20130703 By SS Eric    Reason:新增保險異常欄位--%>
                                            <asp:CheckBox ID="txtNOINSURANCEFLG" Enabled="false" runat="server" />保險異常
                                        </td>
                                    </tr>
                                    <tr>
                                        <th width="20%">
                                            標的物金額
                                        </th>
                                        <td width="12%">
                                            <asp:TextBox ID="txtTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th width="15%">
                                        </th>
                                        <td width="12%">
                                        </td>
                                        <th width="24%">
                                            <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險費按鈕-->
                                            <asp:Button ID="btINSURANCE" CssClass="btn_normal" runat="server" Text="..." OnClick="btINSURANCE_Click" />
                                            保險費
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtINSURANCE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            頭期款
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                            佣金
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCOMMISSION" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <!--Modify 20120529 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                                        <th>
                                            作業費用(有發票)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtOTHERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            租購保證金
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                        </th>
                                        <td>
                                        </td>
                                        <!--Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                                        <th>
                                            作業費用(無發票)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            履約保證金
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                            實貸金額
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtACTUSLLOANS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                            手續費收入
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <th>
                                            殘值
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtRESIDUALS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            總承作月數
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCONTRACTMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                            幾月一付
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPAYMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>
                                            付款時間
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTIMET" DataTextField="MNAME1" DataValueField="MCODE"
                                                runat="server" Width="80px" Enabled="false">
                                                <asp:ListItem>期初付</asp:ListItem>
                                                <asp:ListItem>期末付</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <table class="tb_grid" width="100%">
                                                <tr>
                                                    <td width="13%">
                                                        第 &nbsp; 1 &nbsp; 期
                                                    </td>
                                                    <td width="15%">
                                                        - 第<asp:TextBox ID="txtENDPAY1" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td width="18%">
                                                        期付款(未稅)
                                                    </td>
                                                    <td width="18%">
                                                        <asp:TextBox ID="txtPRINCIPAL1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td width="18%">
                                                        期付款(含稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPALTAX1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        第
                                                        <asp:TextBox ID="txtSTARTPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        - 第<asp:TextBox ID="txtENDPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        期付款(未稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPAL2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        期付款(含稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPALTAX2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        第
                                                        <asp:TextBox ID="txtSTARTPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        - 第<asp:TextBox ID="txtENDPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        期付款(未稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPAL3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        期付款(含稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPALTAX3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        第
                                                        <asp:TextBox ID="txtSTARTPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        - 第<asp:TextBox ID="txtENDPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                        期
                                                    </td>
                                                    <td>
                                                        期付款(未稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPAL4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        期付款(含稅)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPRINCIPALTAX4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="right_div" style="height: 265px;">
                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" />應收帳款案件
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            申請額度
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            徵信費
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            帳務管理費
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            財務顧問費
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!--Modify 20120604 By SS Gordon. Reason: AR新增履約保證金-->
                                    <tr>
                                        <th>
                                            履約保證金
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            成數
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            帳款期限
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>月
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                    <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
                                        <th>
                                            付款時間
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                                Enabled="false" runat="server" Width="80%">
                                                <asp:ListItem>期初付</asp:ListItem>
                                                <asp:ListItem>期末付</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            單一買方限額
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                    <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
                                        <th>
                                            承作真實IRR
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示--%>
                                    <tr>
                                        <th>建議墊款息</th>
                                        <td>
                                            <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true" Text=""></asp:TextBox>%
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="clear: both;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th>
                                        付款方式
                                    </th>
                                    <td colspan="5">
                                        <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                            Enabled="false">
                                            <asp:ListItem>匯款</asp:ListItem>
                                            <asp:ListItem>支票</asp:ListItem>
                                            <asp:ListItem>套票</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        付款差異天數
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPATDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>
                                        付供應商天數
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtSUPPILERDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        預計期滿處理方式
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpEXPIREPROC" DataTextField="DNAME1" DataValueField="DCODE"
                                            runat="server" Enabled="false">
                                            <asp:ListItem>以殘值賣予供應商(客戶第三方)</asp:ListItem>
                                            <asp:ListItem>正常到期</asp:ListItem>
                                            <asp:ListItem>其他</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」-->
                                    <!--Modify 20130117 By    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」-->
                                    <th>
                                        備註
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Style="width: 98%"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                 <tr>
                                  <th>
                                    IRR
                                  </th>
                                  <td>
                                    <asp:TextBox ID="txtIRR" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                  </td>
                                    <%--Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0--%>
                                     <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                                    <th>
                                    NPV
                                  </th>
                                  <td>
                                        <asp:TextBox ID="txtNPV" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                  </td>
                                     <%--20240814 NPV成本隱藏--%>
                                  <%--<th>
                                    NPV成本
                                  </th>--%>
                                  <td>
                                        <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"  style="display: none;"></asp:TextBox>
                                      <%--%--%>
                                  </td>
                                </tr>
                                <tr style="display:none;">
                                    <th>
                                        IRR
                                    </th>
                                    <td>
                                        
                                    </td>
                                    <th>
                                        設備件NPV
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                    <th>
                                        設備件NPV成本
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                <tr style="display:none;">
                                    <th>
                                        資金成本
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCAPITALCOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">7</asp:TextBox>
                                    </td>
                                    <th>
                                        融資件NPV
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtNPV2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>
                                        融資件NPV成本
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="display: none;">
                                        RECOVER TEST
                                    </th>
                                    <td colspan="5" style="display: none;">
                                        <asp:TextBox custprop="100" ID="txtRECOVERTEST" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="text-align: center; height: 30px;">
                                        <asp:Button ID="Button3" runat="server" Enabled="false" CssClass="btn_normal" Text="試算" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <%--案件內容End --%>
                    <%--標的物Begin --%>
                    <div id="fraTab33" class="div_content" style="display: none">
                        <div class="div_table" style="overflow: scroll; height: 200px">
                            <table class="tb_Contact" style="width: 1100px;">
                                <tr>
                                    <th>
                                        項次
                                    </th>
                                    <th>
                                        標的物種類
                                    </th>
                                    <th>
                                        標的物名稱
                                    </th>
                                    <th>
                                        設備狀況
                                    </th>
                                    <th>
                                        型號
                                    </th>
                                    <th>
                                        機號
                                    </th>
                                    <th>
                                        供應商ID
                                    </th>
                                    <th>
                                        供應商
                                    </th>
                                    <th>
                                        價格
                                    </th>
                                    <th>
                                        價格未稅
                                    </th>
                                    <!--th>
                    進項發票金額(未稅)
                  </th>
                  <th>
                    進項發票金額(含稅)
                  </th>
                  <th>
                    進項折讓金額(未稅)
                  </th>
                  <th>
                    進項折讓金額(含稅)
                  </th>
                  <th>
                    業代自付額(含稅)
                  </th-->
                                    <th>
                                        耐用年限
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASETARGET" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpTARGETTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                    class="bg_normal" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTARGETNAME" Text='<%# Eval("TARGETNAME")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpTARGETSTATUS" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                    runat="server">
                                                    <asp:ListItem>新機</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTARGETMODELNO" Text='<%# Eval("TARGETMODELNO")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTARGETMACHINENO" Text='<%# Eval("TARGETMACHINENO")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtSUPPLIERID" Text='<%# Eval("SUPPLIERID")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' runat="server" Width="160px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTARGETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString())%>'
                                                    onblur="txtTARGETPRICE_onblur(this);" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString())%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <!--td>
                        <asp:Label ID="txtPROCEDEINV" Text='<%# Itg.Community.Util.NumberFormat(Eval("PROCEDEINV").ToString())%>'
                          runat="server" style="display:none"></asp:Label>
                      </td>
                      <td>
                        <asp:Label ID="txtPROCEDEINVTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("PROCEDEINVTAX").ToString())%>'
                          runat="server" style="display:none"></asp:Label>
                      </td>
                      <td>
                        <asp:Label ID="txtDISCOUNTINV" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTINV").ToString())%>'
                          runat="server" style="display:none"></asp:Label>
                      </td>
                      <td>
                        <asp:Label ID="txtDISCOUNTINVTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTINVTAX").ToString())%>'
                          runat="server" style="display:none"></asp:Label>
                      </td>
                      <td>
                        <asp:Label ID="txtSALESPAY" Text='<%# Itg.Community.Util.NumberFormat(Eval("SALESPAY").ToString()) %>'
                          runat="server" style="display:none"></asp:Label>
                      </td-->
                                            <td>
                                                <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <asp:CheckBox ID="chkAr" Enabled="false" runat="server" />
                        AR案件無標的物&nbsp;&nbsp;&nbsp;
                        <%--Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.--%>
                        <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" />
                        銀行案件無標的物
                        <br />
                        設備存放地<br />
                        <div class="div_table" style="overflow: scroll; height: 200px">
                            <table class="tb_Contact" style="width: 1000px;">
                                <tr>
                                    <th>
                                        項次
                                    </th>
                                    <th>
                                        存放地
                                    </th>
                                    <th>
                                        聯絡人
                                    </th>
                                    <th>
                                        部門
                                    </th>
                                    <th>
                                        職稱
                                    </th>
                                    <th>
                                        聯絡電話
                                    </th>
                                    <th>
                                        手機
                                    </th>
                                    <th>
                                        傳真
                                    </th>
                                    <th>
                                        E-mail
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td width="250px">
                                                <%# Eval("STOREDZIPCODE")%>
                                                &nbsp;
                                                <%# Eval("STOREDZIPCODES")%>
                                                &nbsp;
                                                <%# Eval("STOREDADDR")%>
                                                <asp:TextBox ID="txtSTOREDZIPCODE" Enabled="false" runat="server" Width="30px" CssClass="txt_table"
                                                    Text='<%# Eval("STOREDZIPCODE")%>' Style="display: none"></asp:TextBox>
                                                <asp:TextBox ID="txtSTOREDZIPCODES" Enabled="false" runat="server" Width="100px"
                                                    CssClass="txt_table" Text='<%# Eval("STOREDZIPCODES")%>' Style="display: none"></asp:TextBox>
                                                <asp:TextBox ID="txtSTOREDADDR" Enabled="false" runat="server" Width="250px" CssClass="txt_table"
                                                    Text='<%# Eval("STOREDADDR")%>' Style="display: none"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTNAME" Text='<%# Eval("CONTACTNAME")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDEPTNAME" Text='<%# Eval("DEPTNAME")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTTITLE" Text='<%# Eval("CONTACTTITLE")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTTELCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' />
                                                <asp:Label ID="txtCONTACTTEL" Text='<%# Eval("CONTACTTEL")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTMPHONE" Text='<%# Eval("CONTACTMPHONE")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTFAXCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' />
                                                <asp:Label ID="txtCONTACTFAX" Text='<%# Eval("CONTACTFAX")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCONTACTEMAIL" Text='<%# Eval("CONTACTEMAIL")%>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <%--標的物End --%>
                    <%--擔保條件Begin --%>
                    <div id="fraTab44" class="div_content T_-130" style="min-height: 730px; display: none;
                        height: auto !important;">
                        <br />
                        <%--20131115 LEO 新增進件條件擔保價值--%>
                        擔保價值
                        <asp:DropDownList ID="drpGuanValue" runat="server" Enabled="false">
                        </asp:DropDownList>
                        <br />
                        保證人<asp:CheckBox ID="chkMLDCASEGUARANTEE" Enabled="false" runat="server" />
                        本案無保證人
                        <div class="div_table" style="overflow: scroll;">
                            <table class="tb_Contact" style="width: 2400px;">
                                <tr>
                                    <th>
                                        法人/個人
                                    </th>
                                    <th>
                                        名稱
                                    </th>
                                    <th>
                                        ID
                                    </th>
                                    <th>
                                        簽訂大本票
                                    </th>
                                    <th>
                                        本票類型
                                    </th>
                                    <th>
                                        <%--20230523本票金額改保人擔保金額--%>
                        <%--本票金額--%>
                          保人擔保金額
                                    </th>
                                    <%--Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
                                    <th>
                                        生日
                                    </th>
                                    <th>
                                        性別
                                    </th>
                                    <th>
                                        戶籍地址/公司登記地址
                                    </th>
                                    <th>
                                        通訊地址
                                    </th>
                                    <th>
                                        聯絡電話
                                    </th>
                                    <th>
                                        關係人一
                                    </th>
                                    <th>
                                        關係人二
                                    </th>
                                    <th>
                                        職業分類
                                    </th>
                                    <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                    <th>
                                        職業
                                    </th>
                                    <th>
                                        任職公司
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="drpGRTTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                    class="bg_normal" runat="server" Width="80%">
                                                    <asp:ListItem>法人</asp:ListItem>
                                                    <asp:ListItem>個人</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' runat="server" CssClass="txt_table"
                                                    Width="80" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                    Width="80" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGUARANTEEBILL" Enabled="false" runat="server" Width="80%">
                                                    <asp:ListItem Value="1">是</asp:ListItem>
                                                    <asp:ListItem Value="2">否</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGUARANTEEBILLTYPE" Enabled="false" runat="server" Width="80%">
                                                    <asp:ListItem Value="1">本票</asp:ListItem>
                                                    <asp:ListItem Value="2">支票</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>'
                                                    Enabled="false" runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <%--Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
                                            <td>
                                                <asp:TextBox ID="txtGRTBIRDT" Enabled="false" Text='<%# Eval("GRTBIRDT") %>' runat="server"
                                                    Width="80px" CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTSEX" Enabled="false" runat="server" Width="50px">
                                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                                    <asp:ListItem Value="1">男</asp:ListItem>
                                                    <asp:ListItem Value="2">女</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTRESIDENTZIP" Enabled="false" Text='<%# Eval("GRTRESIDENTZIP") %>'
                                                    runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <input type="button" id="btnGRTRESIDENTZIP" disabled="disabled" class="btn_normal"
                                                    onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px;
                                                    padding: 2px;" value="&#8230;" />
                                                <asp:TextBox ID="txtGRTRESIDENTZIPNM" Enabled="false" Text='<%# Eval("GRTRESIDENTZIPNM") %>'
                                                    runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTRESIDENTADDR" Enabled="false" Text='<%# Eval("GRTRESIDENTADDR") %>'
                                                    runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');"
                                                    MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTZIP" Enabled="false" Text='<%# Eval("GRTZIP") %>' runat="server"
                                                    Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                    CssClass="txt_table"></asp:TextBox>
                                                <input type="button" id="btnGRTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);"
                                                    onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                                <asp:TextBox ID="txtGRTZIPNM" Enabled="false" Text='<%# Eval("GRTZIPNM") %>' runat="server"
                                                    Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTADDR" Enabled="false" Text='<%# Eval("GRTADDR") %>' runat="server"
                                                    Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');"
                                                    MaxLength="100"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTTELCODE" Enabled="false" Text='<%# Eval("GRTTELCODE") %>'
                                                    runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);"
                                                    onblur="OnlyNumBlur(this);"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTTEL" Enabled="false" Text='<%# Eval("GRTTEL") %>' runat="server"
                                                    Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                                <asp:TextBox ID="txtGRTTELEXT" Enabled="false" Text='<%# Eval("GRTTELEXT") %>' runat="server"
                                                    Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTRELATION1" Enabled="false" runat="server" Width="180px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTRELATION2" Enabled="false" runat="server" Width="105px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpGRTJOBCLS" Enabled="false" runat="server" Width="160px"
                                                    DataTextField="MNAME1" DataValueField="MCODE">
                                                </asp:DropDownList>
                                            </td>
                                            <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                            <td>
                                                <asp:DropDownList ID="drpGRTJOB" Enabled="false" runat="server" Width="220px" DataTextField="DNAME1"
                                                    DataValueField="DCODE">
                                                    <asp:ListItem Value="">非醫師</asp:ListItem>
                                                    <asp:ListItem Value="01">醫師</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTCOMPANY" Enabled="false" Text='<%# Eval("GRTCOMPANY") %>'
                                                    runat="server" Width="200px" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <br />
                        動產設定<asp:CheckBox ID="chkMLDCASEMOVABLE" Enabled="false" runat="server" />
                        本案無動產設定
                        <div class="div_table" style="overflow: scroll;">
                            <table class="tb_Contact" style="width: 1200px;">
                                <tr>
                                    <th>
                                        項次
                                    </th>
                                    <th>
                                        產品設備
                                    </th>
                                    <th>
                                        本案標的
                                    </th>
                                    <th>
                                        所在地
                                    </th>
                                    <th>
                                        機器序號
                                    </th>
                                    <th>
                                        出產年份
                                    </th>
                                    <th>
                                        購買日期
                                    </th>
                                    <th>
                                        新品金額
                                    </th>
                                    <th>
                                        購買金額
                                    </th>
                                    <th>
                                        殘值預估
                                    </th>
                                    <th>
                                        設定金額
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENAME" Enabled="false" Text='<%# Eval("MOVABLENAME")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                    <asp:ListItem Value="1">是</asp:ListItem>
                                                    <asp:ListItem Value="2">否</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEZIPCODE" Enabled="false" runat="server" Width="60px" CssClass="txt_table"
                                                    Text='<%# Eval("MOVABLEZIPCODE")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEZIPCODES" Enabled="false" runat="server" Width="120px"
                                                    CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEADDR" Enabled="false" runat="server" CssClass="txt_table"
                                                    Width="150px" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENO" Enabled="false" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEYEAR" Enabled="false" Text='<%# Eval("MOVABLEYEAR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENEWAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESIDUALS" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESETPRICE" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        不動產設定<asp:CheckBox ID="chkMLDCASEIMMOVABLE" Enabled="false" runat="server" />
                        本案無不動產設定
                        <div class="div_table" style="overflow: scroll;">
                            <table class="tb_Contact" width="1100px" border="1">
                                <tr>
                                    <th>
                                        項次
                                    </th>
                                    <th>
                                        所有人
                                    </th>
                                    <th>
                                        ID
                                    </th>
                                    <th>
                                        取得時間
                                    </th>
                                    <th>
                                        建物完成日
                                    </th>
                                    <th>
                                        土地地段
                                    </th>
                                    <th>
                                        地號
                                    </th>
                                    <th>
                                        土地面積
                                    </th>
                                    <th>
                                        建號
                                    </th>
                                    <th>
                                        門牌號碼
                                    </th>
                                    <th>
                                        建築總面積(平方公尺)
                                    </th>
                                    <th>
                                        建築總面積(坪)
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEIMMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNER" Enabled="false" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNERID" Enabled="false" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEGETDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLESECTOR" Enabled="false" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILD" Enabled="false" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEAREA" Enabled="false" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDNO" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEHOUSENUM" Enabled="false" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                    onblur="areacon(this)" runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <br />
                        <table class="tb_Contact" border="1">
                            <tr>
                                <th>
                                    項次
                                </th>
                                <th>
                                    權利人
                                </th>
                                <th>
                                    登記日期
                                </th>
                                <th>
                                    設定金額
                                </th>
                                <th>
                                    債權人
                                </th>
                                <th>
                                    不動產項次
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDHUMANRIGHTS" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHUMANRIGHTS" Enabled="false" Text='<%# Eval("HUMANRIGHTS") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtREGISTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSETPRICE" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCREDITOR" Enabled="false" Text='<%# Eval("CREDITOR") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <%--2013.12.10 Modify by SEAN. Reason:修正不動產項次取號問題--%>
                                            <%--<asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                      </asp:DropDownList>--%>
                                            <asp:TextBox ID="txtMLDCASEIMMOVABLE" Enabled="false" runat="server" CssClass="txt_table"
                                                Text='<%# Eval("IDMEMO") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <br />
                        定存單質押<asp:CheckBox ID="chkMLDCASEADEPOSIT" Enabled="false" runat="server" />
                        本案無定存單設定
                        <table class="tb_Contact" width="85%">
                            <tr>
                                <th>
                                    銀行
                                </th>
                                <th>
                                    定存單號
                                </th>
                                <th>
                                    金額
                                </th>
                                <th>
                                    定存起日
                                </th>
                                <th>
                                    定存訖日
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEADEPOSIT" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("DEPOSITBANKS") %>'
                                                Width="120px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITNBR" Enabled="false" Text='<%# Eval("DEPOSITNBR") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITAMT" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITSTARTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITDUEDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <br />
                        客票<asp:CheckBox ID="chkMLDCASEBILLNOTE" Enabled="false" runat="server" />
                        本案無客票
                        <table class="tb_Contact" width="80%">
                            <tr>
                                <th>
                                    票據到期日
                                </th>
                                <th>
                                    付款行庫社
                                </th>
                                <th>
                                    票據種類
                                </th>
                                <th>
                                    票據號碼
                                </th>
                                <th>
                                    帳號
                                </th>
                                <th>
                                    發票人名稱
                                </th>
                                <th>
                                    票面金額
                                </th>
                                <th>
                                    備註
                                </th>
                                <th>
                                    還票日
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEBILLNOTE" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("BILLNOTEBANKS") %>'
                                                Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                                <asp:ListItem Value="1">本票</asp:ListItem>
                                                <asp:ListItem Value="2">支票</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENBR" Enabled="false" Text='<%# Eval("BILLNOTENBR") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACCOUNT" Enabled="false" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTECUSTNAME" Enabled="false" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENOTE" Enabled="false" Text='<%# Eval("BILLNOTENOTE") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBACKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table" Width="72px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <br />
                        股票<asp:CheckBox ID="chkMLDCASESTOCK" Enabled="false" runat="server" />
                        本案無股票
                        <table class="tb_Contact" width="70%">
                            <tr>
                                <th>
                                    設定日期
                                </th>
                                <th>
                                    股票名稱
                                </th>
                                <th>
                                    提供人
                                </th>
                                <th>
                                    單位(股)
                                </th>
                                <th>
                                    張數
                                </th>
                                <th>
                                    總數(股)
                                </th>
                                <th>
                                    開始號
                                </th>
                                <th>
                                    截止號
                                </th>
                                <th>
                                    保險箱
                                </th>
                                <th>
                                    備註
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASESTOCK" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNAME" Enabled="false" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKPROVIDER" Enabled="false" Text='<%# Eval("STOCKPROVIDER") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKUNIT" Enabled="false" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" Enabled="false" Text='<%# Eval("STOCKQUANTITY") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" Enabled="false" Text='<%# Eval("STOCKTOTAL") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKBEGIN" Enabled="false" Text='<%# Eval("STOCKBEGIN") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKEND" Enabled="false" Text='<%# Eval("STOCKEND") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                                <asp:ListItem Value="1">集保</asp:ListItem>
                                                <asp:ListItem Value="2">實體</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNOTE" Enabled="false" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <br />
                        其他<br />
                        <asp:TextBox ID="txtOTHERCOND" Enabled="false" runat="server" CssClass="txt_normal"
                            Width="80%"></asp:TextBox>
                    </div>
                    <%--擔保條件End --%>
                    <%--徵審資料Begin --%>
                    <div id="fraTab55" class="div_content" style="display: none">
                        <table class="tb_Text" width="98%">
                            <tr>
                                <th width="5%">
                                    項次
                                </th>
                                <th width="52%">
                                    文件
                                </th>
                                <th width="10%">
                                    必備文件
                                </th>
                                <th width="15%">
                                    進件資料確認
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
                                            <td>
                                                <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(Eval("SLABEL")) %>' runat="server"
                                                    Text='<%# Eval("DNAME2")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>'
                                                    Enabled="false" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNOTE" Text='<%# Eval("NOTE") %>' runat="server" Enabled="false"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%--徵審資料End --%>
                    <%--案件報告Begin --%>
                    <div id="fraTab66" class="div_content" style="display: none">
                        <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal"
                            Text="報告下載" />
                        <%--<asp:Label ID="lblOnload" runat="server" Text="報告下載："></asp:Label>--%>
                        <asp:LinkButton ID="lkbOpenFile" runat="server"></asp:LinkButton>
                    </div>
                    <%--案件報告End --%>
                </div>
                <div class="btn_div">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
