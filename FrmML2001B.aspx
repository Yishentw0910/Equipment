<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML2001B																					
* 程式功能  : 案件/合約查詢																			
* 程式作者 	: 																			
* 完成時間 	: 
* 修改事項 	: 
20120216 MODIFY BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
20120221 UPD BY SSF MAUREEN REASON:修改按鈕
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20120618 By SS Gordon. Reason: AR新增履約保證金
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.
Modify 20121204 By SS Steven. Reason: 新增「相關合約抵押品設定」功能.
Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
Modify 20130117 By SS Adam. Reason: 增加對前案擔保品增加限制的顯示判斷.
Modify 20130131 By SS Maureen. Reason: 修正建築持分面積欄位，顯示正確資料.
Modify 20130131 By SS Maureen. Reason:名稱修改為不動產資料，並移除本案無不動產設定的選項.
Modify 2013709 By SS Chris Hung. Reason:新增案件心得按鍵功能
20131008 Edit by Sean 已徵審完成的案件也可上傳徵信檔案
Modify 20131113 BY SS Leo Reason:增加進件條件擔保價值欄位
Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏
Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本
20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%)
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML2001B.aspx.cs" Inherits="FrmML2001B" %>

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
    <!-- #Include file='js/ML2001A.js' -->                   
    </script>
    <script type="text/javascript" language="javascript">
        function openML2001C() {
            //dialogHeight:600px;dialogWidth:735px
            //20230216 ML改LE
            window.showModalDialog("../../LE.NET/ML20/ML2001C.aspx?CASEID=" + document.getElementById("<%=this.txtCASEID.ClientID %>").value, "", "dialogHeight:700px;dialogWidth:850px;");
            //window.showModalDialog("../../ML.NET/ML20/ML2001C.aspx?CASEID=" + document.getElementById("<%=this.txtCASEID.ClientID %>").value, "", "dialogHeight:700px;dialogWidth:850px;");
        }
        var $ = document.getElementById;

        //報表列印
        function btnPRINT_OnClick(obj) {

            var LSTR_QUERY = "";
            LSTR_QUERY += ";" + "USERNM=" + escape("<%=this.GSTR_USERNM%>");
            LSTR_QUERY += ";" + "CASEID=" + $("<%=this.txtCASEID.ClientID %>").value;

            //傳參數到Smart Query
            ReportPrint("<%=this.cRepotr%>" + "/ReportPrint.aspx",
                "<%=this.cUrl%>",
                "<%=this.cPath%>",
                "<%=this.cUserName%>",
                "<%=this.cPass%>",
                "<%=this.cCompany%>",
                "LE", //**
                "ML2001", //**
                LSTR_QUERY);
        }
    </script>
</head>
<%--Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.--%>
<%--<body onload="window_onload();showTag();">--%>
<body onload="window_onload();showTag();" onkeydown="body_OnKeyDown(event)">
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="divBody2001A" id="div_Info">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="900">
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
                    <table class="divStatus" width="100%">
                        <tr>
                            <th>案件編號
                            </th>
                            <td>
                                <asp:TextBox ID="txtCASEID" runat="server" CssClass="txt_readonly" Width="105px"
                                    ReadOnly="true"></asp:TextBox>
                                <asp:HiddenField ID="hidCASESTATUS" runat="server" Value="" />
                                <asp:HiddenField ID="HidEMPLID" runat="server" Value="" />
                                <asp:HiddenField ID="HidDEPTID" runat="server" Value="" />
                            </td>
                            <th>申請日
                            </th>
                            <td>
                                <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true"></asp:TextBox>
                            </td>
                            <td width="40%"></td>
                        </tr>
                    </table>
                    <div id="fraDispTypeInfo" class="frame_content div_Info5" style="min-height: 1350px; height: auto !important;">
                        <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                        <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8">
                            <label class="label_contain">
                                客戶資料</label>
                        </div>
                        <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_100 T_-24">
                            <label class="label_contain">
                                案件內容</label>
                        </div>
                        <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_200 T_-48">
                            <label class="label_contain">
                                標的物</label>
                        </div>
                        <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_300 T_-72">
                            <label class="label_contain">
                                擔保條件</label>
                        </div>
                        <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_400 T_-96">
                            <label class="label_contain">
                                徵審資料</label>
                        </div>
                        <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_500 T_-120">
                            <label class="label_contain">
                                徵信報告</label>
                        </div>
                        <div id="fraTab77Caption" tabframe="fraTab77" container="fraDispTypeInfo" onclick="Caption_onclick(this);Caption_onclick(document.getElementById('fraTab111Caption'));Caption_onclick(document.getElementById('fraTab1111Caption'))"
                            class="sheet div_menu8 L_600  T_-144">
                            <label class="label_contain">
                                信用查詢</label>
                        </div>
                        <div id="fraTab88Caption" tabframe="fraTab88" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_700 T_-168">
                            <label class="label_contain">
                                覆核報告</label>
                        </div>
                        <div id="fraTab99Caption" tabframe="fraTab99" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                            class="sheet div_menu8 L_800 T_-192">
                            <label class="label_contain">
                                放審會報告</label>
                        </div>

                        <%--客戶資料Begin --%>
                        <div id="fraTab11" class="div_content padleft_0 T_-188" style="display: block; min-height: 800px;">
                            <%-- Change div_content to div_content2 --%>
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="15%">客戶統編
                                    </th>
                                    <td width="15%">
                                        <asp:TextBox ID="txtCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th width="15%">客戶名稱
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" Width="230px"
                                            ReadOnly="true"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 客戶性質
                                    <asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1"
                                        DataValueField="MCODE">
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>登記資本額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            Width="112px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>實收資本額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            Width="112px" ReadOnly="true"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;設立日期
                                    <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                        Width="81px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>負責人
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOWNER" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>身份ID
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOWNERID" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="112px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;集團實際負責人
                                    <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                        ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>公司屬性
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpCOMPTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false" Width="80px">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th>組織形態
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpORGATYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;上市櫃
                                    <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>母公司統編
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>母公司名稱
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="276px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>公司登記地址
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
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
                                    <th>公司登記電話
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>傳真
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCUSTFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>營業登記地址
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
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
                                    <th>營業登記電話
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>傳真
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>主要營業項目
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="81%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>行業別
                                    </th>
                                    <td colspan='3'>
                                        <%--20221207 行業別改下拉選單--%>
                                        <asp:DropDownList ID="DrpNDU" class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="False">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>

                                        <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                                        <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" CssClass="btn_normal" Enabled="false" Visible="False" />
                                        <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ====END====-->

                                        <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                            Enabled="false" Width="100%" Style="display: none;">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpCUROUTF" Style="display: none" DataTextField="DNAME1" DataValueField="DCODE"
                                            runat="server" Enabled="false" Width="50%">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>票信瑕疵
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
                                    <th>決策人
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="100%">
                                                <tr>
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
                                    <th>案件聯絡人
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="100%">
                                                <tr>
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
                                                <asp:Repeater ID="rptContactC" runat="server">
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
                                    <th>發票聯絡人
                                    </th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 100%; padding: 2px; overflow: scroll;">
                                            <table class="tb_Contact" width="150%;">
                                                <tr>
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
                                                    <th>發票寄送地
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
                                                            <td>
                                                                <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" ReadOnly="true" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODE")%>'></asp:TextBox>
                                                                <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" ReadOnly="true" CssClass="txt_table"
                                                                    Text='<%# Eval("INVZIPCODES")%>'></asp:TextBox>
                                                                <asp:TextBox ID="txtINVOICEADDR" runat="server" ReadOnly="true" CssClass="txt_table"
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
                        <div id="fraTab22" class="div_content padleft_0 T_-188" style="display: none">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <%--Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示--%>
                                <tr>
                                    <th>專案別
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
                                    <th width="12%">公司名稱 </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpCOMPID" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>和潤</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                                    <th width="12%">承作方式 </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                    <th width="12%">承作型態 </th>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpMAINTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>營業型租賃</asp:ListItem>
                                            <asp:ListItem>資本型租賃</asp:ListItem>
                                            <asp:ListItem>附條件買賣</asp:ListItem>
                                            <asp:ListItem>應收帳款受讓</asp:ListItem>
                                            <asp:ListItem>分期付款(無擔)</asp:ListItem>
                                            <asp:ListItem>分期付款(有擔)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="12%">
                                        <asp:DropDownList ID="drpSUBTYPE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" Enabled="false">
                                            <asp:ListItem>營業型租賃</asp:ListItem>
                                            <asp:ListItem>資本型租賃</asp:ListItem>
                                            <asp:ListItem>附條件買賣</asp:ListItem>
                                            <asp:ListItem>應收帳款受讓</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th width="12%">交易形態 </th>
                                    <td>
                                        <asp:DropDownList ID="drpTRANSTYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            <asp:ListItem>兩方</asp:ListItem>
                                            <asp:ListItem>三方</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <tr>
                                        <th>動用情形 </th>
                                        <td>
                                            <asp:DropDownList ID="drpUSESTATUS" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>單筆動用</asp:ListItem>
                                                <asp:ListItem>多筆動用</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCYCLETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>循環</asp:ListItem>
                                                <asp:ListItem>不循環</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th>代印店 </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRINTSTORE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem Value="">請選擇</asp:ListItem>
                                                <asp:ListItem Value="Y">是</asp:ListItem>
                                                <asp:ListItem Value="N">否</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <%--Modify 20120717 By SS Gordon. Reason: 新增銀行別.--%>
                                        <th>銀行別 </th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>承作對象<!--20191119 ADD BY SS ADAM REASON.案件來源=>承作對象 -->
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="drpCASESOURCE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                <asp:ListItem>長租CR</asp:ListItem>
                                                <asp:ListItem>設備CR</asp:ListItem>
                                                <asp:ListItem>供應商介紹</asp:ListItem>
                                                <asp:ListItem>客戶來電</asp:ListItem>
                                                <asp:ListItem>同業介紹</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th>附追索權 </th>
                                        <td colspan="5">
                                            <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="drpRECOURSE" runat="server" Enabled="false">
                                                        <asp:ListItem Value="">請選擇</asp:ListItem>
                                                        <asp:ListItem Value="Y">是</asp:ListItem>
                                                        <asp:ListItem Value="N">否</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                                        <tr>
                                            <th>案件產品別 </th>
                                            <td colspan="8">
                                                <asp:DropDownList ID="drpPRODCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 END-->
                            </table>
                            <div>
                                <div class="left_div2001A">
                                    <table class="tb_Info" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td colspan="6">
                                                <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />分期、租賃案件
                                            </td>
                                        </tr>
                                        <tr>
                                            <th width="20%">標的物金額
                                            </th>
                                            <td width="12%">
                                                <asp:TextBox ID="txtTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th width="15%"></th>
                                            <td width="12%"></td>
                                            <th width="24%">保險費
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtINSURANCE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>頭期款
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>佣金
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCOMMISSION" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <!--Modify 20120529 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                                            <th>作業費用(有發票)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOTHERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>租購保證金
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th></th>
                                            <td></td>
                                            <!--Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                                            <th>作業費用(無發票)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>履約保證金
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>實貸金額
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtACTUSLLOANS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>手續費收入
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <th>殘值
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRESIDUALS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>總承作月數
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCONTRACTMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>幾月一付
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPAYMONTH" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <th>付款時間
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
                                                        <td width="13%">第 &nbsp; 1 &nbsp; 期
                                                        </td>
                                                        <td width="15%">- 第<asp:TextBox ID="txtENDPAY1" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td width="18%">期付款(未稅)
                                                        </td>
                                                        <td width="18%">
                                                            <asp:TextBox ID="txtPRINCIPAL1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td width="18%">期付款(含稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>第
                                                        <asp:TextBox ID="txtSTARTPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>- 第<asp:TextBox ID="txtENDPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>期付款(未稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>期付款(含稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>第
                                                        <asp:TextBox ID="txtSTARTPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>- 第<asp:TextBox ID="txtENDPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>期付款(未稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>期付款(含稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPALTAX3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>第
                                                        <asp:TextBox ID="txtSTARTPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>- 第<asp:TextBox ID="txtENDPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                            Width="24px"></asp:TextBox>
                                                            期
                                                        </td>
                                                        <td>期付款(未稅)
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPRINCIPAL4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>期付款(含稅)
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
                                            <th>申請額度
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>徵信費
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>帳務管理費
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>財務顧問費
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <!--Modify 20120618 By SS Gordon. Reason: AR新增履約保證金-->
                                        <tr>
                                            <th>履約保證金
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>成數
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>%
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>帳款期限
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true"></asp:TextBox>月
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
                                            <%--                                        <th>
                                            付款時間
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                                Enabled="false" runat="server" Width="80%">
                                                <asp:ListItem>期初付</asp:ListItem>
                                                <asp:ListItem>期末付</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>
                                            <td>
                                                <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                                    Enabled="false" Style="display: none" runat="server" Width="80%">
                                                    <asp:ListItem>期初付</asp:ListItem>
                                                    <asp:ListItem>期末付</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>單一買方限額
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
                                            <%--                                        <th>
                                            承作真實IRR
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>--%>
                                            <td>
                                                <asp:TextBox ID="txtARIRR" custprop="100" Style="display: none" runat="server" CssClass="txt_readonly_right"
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
                                        <th>付款方式
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
                                        <th>付款差異天數
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPATDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>付供應商天數
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtSUPPILERDAYS" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>預計期滿處理方式
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
                                        <th>案件說明
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                                Style="width: 98%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <tr>
                                        <th>IRR
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtIRR" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <%--Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0--%>
                                        <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                                        <th>NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>NPV成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <tr style="display: none;">
                                        <th></th>
                                        <td></td>
                                        <!--20150109 ADD BY SS ADAM REASON. -->
                                        <th>設備件NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>設備件NPV成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                    <tr style="display: none;">
                                        <th>資金成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCAPITALCOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true">7</asp:TextBox>
                                        </td>
                                        <th>融資件NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>融資件NPV成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th style="display: none;">RECOVER TEST
                                        </th>
                                        <td colspan="5" style="display: none;">
                                            <asp:TextBox custprop="100" ID="txtRECOVERTEST" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="text-align: center; height: 30px;">
                                            <asp:Button ID="Button3" runat="server" Enabled="false" CssClass="btn_normal" Text="試算"
                                                Style="display: none" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%--案件內容End --%>
                        <%--標的物Begin --%>
                        <div id="fraTab33" class="div_content T_-188" style="display: none">
                            <div class="div_table" style="overflow: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 1100px;">
                                    <tr>
                                        <th>項次
                                        </th>
                                        <th>標的物種類
                                        </th>
                                        <th>標的物名稱
                                        </th>
                                        <th>設備狀況
                                        </th>
                                        <th>型號
                                        </th>
                                        <th>機號
                                        </th>
                                        <th>供應商ID
                                        </th>
                                        <th>供應商
                                        </th>
                                        <th>價格
                                        </th>
                                        <th>價格未稅
                                        </th>
                                        <th>耐用年限
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
                                                <td width="17%">
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
                                                    <asp:Label ID="txtSUPPLIERID" Text='<%# Eval("SUPPLIERID")%>' Width="80px" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' Width="160px" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtTARGETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString())%>'
                                                        onblur="txtTARGETPRICE_onblur(this);" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString())%>'
                                                        runat="server"></asp:Label>
                                                </td>
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
                            <div class="div_table" style="overflow-x: scroll; height: 200px">
                                <table class="tb_Contact" style="width: 900px;">
                                    <tr>
                                        <th>項次
                                        </th>
                                        <th width="350px">存放地
                                        </th>
                                        <th>聯絡人
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
                                        <th>E-mail
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Container.ItemIndex +1 %>
                                                </td>
                                                <td width="350px">
                                                    <asp:TextBox ID="txtSTOREDZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDZIPCODE")%>'></asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                        CssClass="txt_table" Text='<%# Eval("STOREDZIPCODES")%>'></asp:TextBox>
                                                    <asp:TextBox ID="txtSTOREDADDR" ReadOnly="true" runat="server" Width="150px" CssClass="txt_table"
                                                        Text='<%# Eval("STOREDADDR")%>'></asp:TextBox>
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
                        <div id="fraTab44" class="div_content T_-188" style="display: none; min-height: 730px; height: auto !important;">
                            <%--20131113 LEO 新增進件條件擔保價值--%>
                        進件條件擔保價值
                        <asp:DropDownList ID="drpGuanValue" runat="server">
                        </asp:DropDownList>
                            <br />
                            保證人<asp:CheckBox ID="chkMLDCASEGUARANTEE" Enabled="false" runat="server" />
                            本案無保證人
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" style="width: 2400px;">
                                <tr>
                                    <th>法人/個人
                                    </th>
                                    <th>名稱
                                    </th>
                                    <th>ID
                                    </th>
                                    <th>簽訂大本票
                                    </th>
                                    <th>本票類型
                                    </th>
                                    <th><%--20230523本票金額改保人擔保金額--%>
                        <%--本票金額--%>
                          保人擔保金額
                                    </th>
                                    <%--Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
                                    <th>生日
                                    </th>
                                    <th>性別
                                    </th>
                                    <th>戶籍地址/公司登記地址
                                    </th>
                                    <th>通訊地址
                                    </th>
                                    <th>聯絡電話
                                    </th>
                                    <th>關係人一
                                    </th>
                                    <th>關係人二
                                    </th>
                                    <th>職業分類
                                    </th>
                                    <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                    <th>職業
                                    </th>
                                    <th>任職公司
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
                                                    Width="80" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                    Width="80" ReadOnly="true"></asp:TextBox>
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
                                                    ReadOnly="true" runat="server" CssClass="txt_table"></asp:TextBox>
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
                                                    onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                    value="&#8230;" />
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
                                            <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
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
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" style="width: 1200px;">
                                <tr>
                                    <th>項次
                                    </th>
                                    <th>產品設備
                                    </th>
                                    <th>本案標的
                                    </th>
                                    <th>所在地
                                    </th>
                                    <th>機器序號
                                    </th>
                                    <th>出產年份
                                    </th>
                                    <th>購買日期
                                    </th>
                                    <th>新品金額
                                    </th>
                                    <th>購買金額
                                    </th>
                                    <th>殘值預估
                                    </th>
                                    <th>設定金額
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENAME" ReadOnly="true" Text='<%# Eval("MOVABLENAME")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                    <asp:ListItem Value="1">是</asp:ListItem>
                                                    <asp:ListItem Value="2">否</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                    Text='<%# Eval("MOVABLEZIPCODE")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                    CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtMOVABLEADDR" ReadOnly="true" runat="server" CssClass="txt_table"
                                                    Width="150px" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENO" ReadOnly="true" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEYEAR" ReadOnly="true" Text='<%# Eval("MOVABLEYEAR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLENEWAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLEBUYAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESIDUALS" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMOVABLERESETPRICE" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                            不動產設定<asp:CheckBox ID="chkMLDCASEIMMOVABLE" Enabled="false" runat="server" />
                            本案無不動產設定
                        <div class="div_table" style="overflow-x: scroll;">
                            <table class="tb_Contact" width="1100px" border="1">
                                <tr>
                                    <th>項次
                                    </th>
                                    <th>所有人
                                    </th>
                                    <th>ID
                                    </th>
                                    <th>取得時間
                                    </th>
                                    <th>建物完成日
                                    </th>
                                    <th>土地地段
                                    </th>
                                    <th>地號
                                    </th>
                                    <th>持分面積
                                    </th>
                                    <th>土地面積
                                    </th>
                                    <th>建號
                                    </th>
                                    <th>門牌號碼
                                    </th>
                                    <th>建築總面積(平方公尺)
                                    </th>
                                    <th>建築總面積(坪)
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCASEIMMOVABLE" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNER" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEOWNERID" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEGETDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLESECTOR" ReadOnly="true" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILD" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEHOLDER" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDNO" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEHOUSENUM" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIMMOVABLEBUILDAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
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
                                    <th>項次
                                    </th>
                                    <th>權利人
                                    </th>
                                    <th>登記日期
                                    </th>
                                    <th>設定金額
                                    </th>
                                    <th>債權人
                                    </th>
                                    <th>不動產項次
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDHUMANRIGHTS" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHUMANRIGHTS" ReadOnly="true" Text='<%# Eval("HUMANRIGHTS") %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtREGISTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSETPRICE" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCREDITOR" ReadOnly="true" Text='<%# Eval("CREDITOR") %>' runat="server"
                                                    CssClass="txt_table"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                                                </asp:DropDownList>
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
                                <th>銀行
                                </th>
                                <th>定存單號
                                </th>
                                <th>金額
                                </th>
                                <th>定存起日
                                </th>
                                <th>定存訖日
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEADEPOSIT" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("DEPOSITBANKS") %>'
                                                Width="120px" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITNBR" ReadOnly="true" Text='<%# Eval("DEPOSITNBR") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITAMT" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITSTARTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDEPOSITDUEDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
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
                                <th>票據到期日
                                </th>
                                <th>付款行庫社
                                </th>
                                <th>票據種類
                                </th>
                                <th>票據號碼
                                </th>
                                <th>帳號
                                </th>
                                <th>發票人名稱
                                </th>
                                <th>票面金額
                                </th>
                                <th>備註
                                </th>
                                <th>還票日
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEBILLNOTE" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("BILLNOTEBANKS") %>'
                                                Width="100px" runat="server"></asp:TextBox>
                                        </td>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                                <asp:ListItem Value="1">本票</asp:ListItem>
                                                <asp:ListItem Value="2">支票</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENBR" ReadOnly="true" Text='<%# Eval("BILLNOTENBR") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACCOUNT" ReadOnly="true" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTECUSTNAME" ReadOnly="true" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                                runat="server" CssClass="txt_table" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTENOTE" ReadOnly="true" Text='<%# Eval("BILLNOTENOTE") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBILLNOTEBACKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
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
                                <th>設定日期
                                </th>
                                <th>股票名稱
                                </th>
                                <th>提供人
                                </th>
                                <th>單位(股)
                                </th>
                                <th>張數
                                </th>
                                <th>總數(股)
                                </th>
                                <th>開始號
                                </th>
                                <th>截止號
                                </th>
                                <th>保險箱
                                </th>
                                <th>備註
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASESTOCK" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNAME" ReadOnly="true" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKPROVIDER" ReadOnly="true" Text='<%# Eval("STOCKPROVIDER") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKUNIT" ReadOnly="true" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" ReadOnly="true" Text='<%# Eval("STOCKQUANTITY") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" ReadOnly="true" Text='<%# Eval("STOCKTOTAL") %>'
                                                runat="server" CssClass="txt_table"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKBEGIN" ReadOnly="true" Text='<%# Eval("STOCKBEGIN") %>'
                                                runat="server" CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKEND" ReadOnly="true" Text='<%# Eval("STOCKEND") %>' runat="server"
                                                CssClass="txt_table" Width="60px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                                <asp:ListItem Value="1">集保</asp:ListItem>
                                                <asp:ListItem Value="2">實體</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSTOCKNOTE" ReadOnly="true" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                                CssClass="txt_table"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                            <br />
                            其他<br />
                            <asp:TextBox ID="txtOTHERCOND" ReadOnly="true" runat="server" CssClass="txt_normal"
                                Width="80%"></asp:TextBox>
                        </div>
                        <%--擔保條件End --%>
                        <%--徵審資料Begin --%>
                        <div id="fraTab55" class="div_content T_-188" style="display: none">
                            <table class="tb_Text" width="98%">
                                <tr>
                                    <th width="5%">項次
                                    </th>
                                    <th width="52%">文件
                                    </th>
                                    <th width="10%">必備文件
                                    </th>
                                    <th width="15%">進件資料確認
                                    </th>
                                    <th>說明
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
                                                    <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL"))  %>'
                                                        runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>'
                                                        Enabled="false" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNOTE" Text='<%# Eval("NOTE") %>' runat="server" ReadOnly="true"
                                                        CssClass="txt_table" Width="120px"></asp:TextBox>
                                                </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <%--徵審資料End --%>
                        <%--20120216 MODIFY BY SSF MAUREEN REASON:新增徵信報告頁簽欄位--%>
                        <%--案件報告Begin --%>
                        <div id="fraTab66" class="div_content T_-188" style="display: none; min-height: 820px;">
                            <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal"
                                Text="營業單位報告下載" Width="170" />
                            <asp:Label ID="lblOpenFile" runat="server" Text=""></asp:Label>
                            <asp:LinkButton ID="lkbOpenFile" Style="display: none;" runat="server"></asp:LinkButton>
                            <br />
                            <div>
                                <asp:Button ID="btnCREDITFILEID" OnClientClick="addFile();return false;" runat="server"
                                    CssClass="btn_normal" Text="徵信案件上傳" Width="170" />
                                <asp:TextBox ID="txtCREDITFILENAME" runat="server" CssClass="txt_readonly" Width="300px"></asp:TextBox>
                                <%-- 20131008 Edit by Sean 已徵審完成的案件也可上傳徵信檔案--%>
                                <asp:Button ID="btnUploadSave" runat="server" Text="上傳確認" CssClass="btn_normal" OnClick="btnUploadSave_Click"
                                    Width="80" />
                            </div>

                            <%-- 20140109 ADD BY SS ADAM Reason.徵信單位報告下載，改為徵信報告維護 並開窗到ML2008 --%>
                            <%-- 20141212 UPD BY SS JBLeo Reason.取消註解徵信報告下載，將徵信報告維護按鈕ID改為btnCREDITFILEmaintain--%>
                            <asp:Button ID="btnCREDITFILEdownload" OnClientClick="return false;" runat="server"
                                CssClass="btn_normal" Text="徵信單位報告下載" Width="170" />
                            <br />
                            <asp:Button ID="btnCREDITFILEmaintain" OnClick="btnCREDITFILEmaintain_Click" runat="server"
                                CssClass="btn_normal" Text="徵信報告維護" Width="170" />
                            <br />
                            <asp:HiddenField ID="hidCREDITFILEID" runat="server" Value="" />
                            <asp:Button ID="btnLackComment" runat="server" OnClientClick="javascipt:return btnLackComment_Click(this);"
                                OnClick="btnLackComment_Click" CssClass="btn_normal" Text="缺件通知" Width="170" /><br />
                            <asp:HiddenField ID="hidLackComment" runat="server" Value="" />
                            <br />
                            <!--
            <asp:Button ID="btnDoc1" runat="server" CssClass="btn_normal" Text="徵信建議書" /><br />
            <br />
            <asp:Button ID="btnDocCreditRepor" runat="server" CssClass="btn_normal" Text="下載案件明細"
              OnClick="btnDocCreditRepor_Click" />
              -->
                            <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                <tr>
                                    <%--徵信簽核日--%>
                                    <th style="nowrap;">初審確認
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRCREDITDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);checkdate(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="100px" style="nowrap;">初審確認時間
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRCREDITDTIME" MaxLength="4" onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)"
                                            onblur="check_keyintime(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="80px" style="nowrap;">徵信完成
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);checkdate(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <th width="100px" style="nowrap;">徵信完成時間
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITDTIME" MaxLength="4" onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)"
                                            onblur="check_keyintime(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="nowrap;">收件日期
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITRECDT" runat="server" custprop="010" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th style="nowrap;">送件日期
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITSENDDT" runat="server" custprop="010" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th style="nowrap;">
                                        <!--簽核權限-->
                                        <!--UPD BY VICKY 20140627 加入徵審人員 -->
                                        徵審人員
                                    </th>
                                    <td>
                                        <asp:Label ID="labCREDITER" runat="server"></asp:Label>
                                        <asp:Label ID="labCREDITER_ID" runat="server" Style="display: none;"></asp:Label>
                                    </td>
                                    <th>&nbsp;
                                    </th>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <!-- UPD BY VICKY 20140627 加入 實貸金額權限,IRR權限-->
                                <tr>
                                    <th style="nowrap;">實貸金額權限
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPROPOSEDSIGN" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Style="display: none">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th style="nowrap;">IRR權限
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th style="nowrap;">徵信建議
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpSUGGEST" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <th>&nbsp;
                                    </th>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 1px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" style="nowrap;">徵信意見：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCREDITDESC" Height="300px" Width="100%" Style="word-wrap: break-word; word-break: break-all;"
                                                TextMode="MultiLine" CssClass="txt_normal" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <%--Modify 20121204 By SS Steven. Reason: 新增「相關合約抵押品設定」功能.--%>
                                <center>
                                    <%--Modify 20130117 By SS Adam. Reason: 增加對前案擔保品增加限制的顯示判斷.--%>
                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <table>
                                            <tr align="center">
                                                <td>
                                                    <th>對前案擔保品增加限制
                                                    </th>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuery" runat="server" Text="查詢相關合約" CssClass="btn_normal" OnClientClick="javascipt:return SHOW_2001(this);" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </center>
                                <br />
                                <%--Modify 20140806 By SS Chris Hung. Reason: 在徵信報告頁籤畫面中，新增結論登記區塊.--%>
                                <div>
                                    <%-- 新增結論登記區塊 begin--%>
                                    <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                        <tr>
                                            <th width="80px" rowspan="11">徵信結論 (初審)
                                            </th>
                                            <th style="width: 110px; nowrap;">建議額度(元)
                                            </th>
                                            <td style="xwidth: 100px; nowrap;">
                                                <asp:TextBox ID="txtCREDITAMT" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                            <th style="width: 120px; nowrap;">期數
                                            </th>
                                            <td style="xwidth: 100px; nowrap;">
                                                <asp:TextBox ID="txtCONTRACTMON" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                            </td>
                                            <th style="width: 100px; nowrap;">履保金(元)
                                            </th>
                                            <td style="width: 100px; nowrap;">
                                                <asp:TextBox ID="txtPERBOND2" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="text-align: center; nowrap;" colspan="6">擔保品
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="text-align: center; nowrap;" width="110px">
                                                <asp:CheckBox ID="chkGRTMV" runat="server" Text="動產" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTIMV" runat="server" Text="不動產" />
                                            </th>
                                            <th style="text-align: center; nowrap;" width="120px">
                                                <asp:CheckBox ID="chkGRTDEPOSIT" runat="server" Text="定存質押" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTBILLNOTE" runat="server" Text="客票" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTSTOCK" runat="server" Text="股票" />
                                            </th>
                                            <th style="text-align: center; nowrap;">
                                                <asp:CheckBox ID="chkGRTCAR" runat="server" Text="車輛" />
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">
                                                <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                                擔保品總餘額<br />
                                                (元，含履保)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtGRTBAL" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                            <th style="nowrap;" width="120px">
                                                <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                                擔保品價值<br />
                                                (含履保)
                                            </th>
                                            <td>
                                                <!--20150109 ADD BY SS ADAM REASON.增加觸發簽核備註 -->
                                                <asp:TextBox ID="txtGRTVAL" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo"></asp:TextBox>
                                            </td>
                                            <td>％
                                            </td>
                                            <td>&nbsp
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">資金用途
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlFUNDSUSE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                    <asp:ListItem Text="實體交易" Value="01"></asp:ListItem>
                                                    <asp:ListItem Text="非實體交易" Value="02"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <th style="nowrap;" width="120px">設備狀態
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlECONDITION" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="新機" Value="01"></asp:ListItem>
                                                    <asp:ListItem Text="中古機" Value="02"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">操作模式
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlOPERATION" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                </asp:DropDownList>
                                            </td>
                                            <th style="nowrap;" width="120px">設備類型
                                            </th>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlDEVICETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    AutoPostBack="True" OnSelectedIndexChanged="setMemo">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">借舊還新扣除額
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtDEDUCTION" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                    onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ===START===-->
                                        <tr>
                                            <th style="nowrap;">行業別
                                            </th>
                                            <td colspan="3">
                                                <%--20221207 行業別改下拉選單--%>
                                                <asp:DropDownList ID="DrpNDU_TAB6" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                    DataValueField="MCODE">
                                                    <asp:ListItem>請選擇</asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:TextBox ID="txtINDUID_TAB6" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB6');" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtINDUNM_TAB6" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                                <asp:Button ID="btnINDUPAGE_TAB6" runat="server" Text="查詢行業別" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="false" />
                                            </td>
                                            <th style="nowrap;">案件產品別
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="drpPRODCD_TAB6" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ====END====-->
                                        <tr>
                                            <th style="nowrap;" width="110px">動產抵押品
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtGRTITEM" MaxLength="500" runat="server" Width="99%" TextMode="MultiLine"
                                                    Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">其他條件
                                            </th>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtOTHERCONDITION" MaxLength="500" runat="server" Width="99%" TextMode="MultiLine"
                                                    Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="nowrap;" width="110px">簽核權限/備註
                                            </th>
                                            <td colspan="5">
                                                <%--20221102備註改為可修改--%>
                                                <asp:TextBox ID="txtSIGNMEMO" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%-- 新增結論登記區塊 end--%>
                                <%--20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內 --%>
                                <br />
                                <center>
                                    <asp:Button ID="cmdPrintReportB" runat="server" Text="列印徵信報告書" CssClass="btn_normal"
                                        OnClientClick="javascipt:return cmdPrintB_onClick(this);" Width="120" />
                                </center>
                                <tr>
                                    <td>
                                        <%--Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.--%>
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <%--Modify 20130131 By SS Maureen. Reason:名稱修改為不動產資料，並移除本案無不動產設定的選項--%>
                                            <%--不動產設定<asp:CheckBox ID="chkMLDIMMOVABLEDF" Enabled="false" runat="server" />
                                         本案無不動產設定 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>--%>
                                        不動產資料&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9
                                            ]</span>
                                            <div class="div_table" style="overflow-x: scroll; width: 700px">

                                                <asp:UpdatePanel ID="UpdatePanelMLDIMMOVABLEDF" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table id="tblMLDIMMOVABLEDF" class="tb_Contact" width="1800px" border="1">
                                                            <tr onclick="changeTag('rptMLDIMMOVABLEDF')">
                                                                <th>項次
                                                                </th>
                                                                <th>所有人
                                                                </th>
                                                                <th>ID
                                                                </th>
                                                                <th>取得時間
                                                                </th>
                                                                <th>建物完成日
                                                                </th>
                                                                <th>土地地段
                                                                </th>
                                                                <th>地號
                                                                </th>
                                                                <th>持分面積
                                                                </th>
                                                                <th>土地面積
                                                                </th>
                                                                <th>建號
                                                                </th>
                                                                <th>門牌號碼
                                                                </th>
                                                                <th>建築總面積(平方公尺)
                                                                </th>
                                                                <th>建築總面積(坪)
                                                                </th>
                                                                <th>建築持分面積(平方公尺)
                                                                </th>
                                                                <th>本案抵押
                                                                </th>
                                                                <th>抵押情形
                                                                </th>
                                                                <th>用途
                                                                </th>
                                                            </tr>
                                                            <asp:Repeater ID="rptMLDIMMOVABLEDF" runat="server">
                                                                <ItemTemplate>
                                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDIMMOVABLEDF','<%# Container.ItemIndex  %>')">
                                                                        <td>
                                                                            <%# Container.ItemIndex +1 %>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEOWNER_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                                                runat="server" MaxLength="10" onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <asp:HiddenField ID="hidIMMOVABLEID_D" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEOWNERID_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                                                runat="server" onkeypress="OnlyNumD(this);" onblur="idBlur(this);" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEGETDATE_D" ReadOnly="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                                                runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                                                onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE_D" ReadOnly="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                                                runat="server" CssClass="txt_table" MaxLength="8" onkeypress="OnlyNum(this);"
                                                                                onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLESECTOR_D" ReadOnly="false" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILD_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEAREA_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);"
                                                                                MaxLength="10" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEHOLDER_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);"
                                                                                MaxLength="10" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDNO_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                                                runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA_D" ReadOnly="false" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                                                onblur="areacon(this)" onkeypress="OnlyNumAndSpot(this);" MaxLength="8" runat="server"
                                                                                CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblIMMOVABLEBUILDAREA_D" Enabled="true" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <%--Modify 20130131 By SS Maureen. Reason: 修正建築持分面積欄位，顯示正確資料.--%>
                                                                            <%--<asp:TextBox ID="txtIMMOVABLEBUILDHOLD_D" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'--%>
                                                                            <asp:TextBox ID="txtIMMOVABLEBUILDHOLD_D" Text='<%# Eval("IMMOVABLEBUILDHOLD")%>'
                                                                                runat="server" onkeypress="OnlyNumAndSpot(this);" MaxLength="8" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpIMMOVABLECASEPAWN_D" runat="server" Enabled="true">
                                                                                <asp:ListItem Value="Y">Y</asp:ListItem>
                                                                                <asp:ListItem Value="N">N</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEPAWNSTATUS_D" Width="200px" Text='<%# Eval("IMMOVABLEPAWNSTATUS")%>'
                                                                                runat="server" MaxLength="100" onblur="CheckMLength(this,'100','抵押情形');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIMMOVABLEPURPOSE_D" Width="200px" Text='<%# Eval("IMMOVABLEPURPOSE")%>'
                                                                                runat="server" MaxLength="60" onblur="CheckMLength(this,'60','用途');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <br />
                                            <div class="div_table" style="overflow: scroll; width: 700px">
                                                <asp:UpdatePanel ID="UpdatePanelMLDHUMANRIGHTS" runat="server" UpdateMode="Conditional"
                                                    Visible="false">
                                                    <ContentTemplate>
                                                        <table class="tb_Contact" border="1">
                                                            <tr onclick="changeTag('rptMLDIMMOVABLEDF')">
                                                                <th>項次
                                                                </th>
                                                                <th>權利人
                                                                </th>
                                                                <th>登記日期
                                                                </th>
                                                                <th>設定金額
                                                                </th>
                                                                <th>債權人
                                                                </th>
                                                                <th>不動產項次
                                                                </th>
                                                            </tr>
                                                            <asp:Repeater ID="rptMLDHUMANRIGHTS_D" runat="server">
                                                                <ItemTemplate>
                                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDIMMOVABLEDF','<%# Container.ItemIndex  %>')">
                                                                        <td>
                                                                            <%# Container.ItemIndex +1 %>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtHUMANRIGHTS_D" Text='<%# Eval("HUMANRIGHTS") %>' MaxLength="10"
                                                                                onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtREGISTDATE_D" onkeypress="OnlyNum(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                                                                MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server"
                                                                                CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSETPRICE_D" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                                onblur="MoneyBlur(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                                                runat="server" CssClass="txt_table_right"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCREDITOR_D" Text='<%# Eval("CREDITOR") %>' runat="server" MaxLength="10"
                                                                                onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpMLDCASEIMMOVABLE_D" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged"
                                                                                runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <center>
                                                <table>
                                                    <tr align="center">
                                                        <td>
                                                            <asp:Button ID="btnSaveImmov" runat="server" Text="儲存" CssClass="btn_normal" OnClick="btnSaveImmov_Click" />
                                                            <asp:Button ID="btnExcelImmov" runat="server" Text="EXCEL下載" OnClick="cmdExport_Click"
                                                                CssClass="btn_normal" />
                                                            <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
                                                            <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
                                                            <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
                                                            <asp:HiddenField ID="hidSelRowTag" runat="server" Value="" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </asp:Panel>
                                    </td>
                                </tr>
                        </div>
                        <%--案件報告End --%>
                        <%--信用查詢Begin --%>
                        <div id="fraTab77" class="div_content T_-168" style="display: none; min-height: 730px; height: auto !important;">
                            <div id="fraDispTypeInfo1" class="frame_content div_Info1" style="border: none; border-top: 1px solid #9FA1AD;">
                                <div id="fraTab111Caption" tabframe="fraTab111" container="fraDispTypeInfo1" onclick="Caption_onclick(this);"
                                    class="sheet div_menu2">
                                    <label class="label_contain">
                                        CCIS</label>
                                </div>
                                <div id="fraTab222Caption" tabframe="fraTab222" container="fraDispTypeInfo1" onclick="Caption_onclick(this);Caption_onclick(document.getElementById('fraTab11111Caption'));"
                                    class="sheet div_menu2 L_251 T_-24">
                                    <label class="label_contain">
                                        JCIC</label>
                                </div>
                                <div id="fraTab333Caption" tabframe="fraTab333" container="fraDispTypeInfo1" onclick="Caption_onclick(this);"
                                    class="sheet div_menu2 L_502 W_247 T_-48">
                                    <label class="label_contain">
                                        往來查詢</label>
                                </div>
                                <div id="fraTab111" class="div_content padleft_0" style="margin-top: 62px;">
                                    <div style="width: 750px;">
                                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                                            <tr>
                                                <td>全部
                                                <asp:CheckBox ID="CheckBox42" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox43" runat="server" /><asp:TextBox ID="TextBox100" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox44" runat="server" /><asp:TextBox ID="TextBox105" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox45" runat="server" /><asp:TextBox ID="TextBox106" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox46" runat="server" /><asp:TextBox ID="TextBox107" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="fraDispTypeInfo2" class="frame_content div_Info2" style="border: none; width: 750px;">
                                        <div id="fraTab1111Caption" tabframe="fraTab1111" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3">
                                            <label class="label_contain">
                                                摘要信息</label>
                                        </div>
                                        <div id="fraTab2222Caption" tabframe="fraTab2222" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_67 T_-24">
                                            <label class="label_contain">
                                                個人拒往</label>
                                        </div>
                                        <div id="fraTab3333Caption" tabframe="fraTab3333" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_134 T_-48">
                                            <label class="label_contain">
                                                公司拒往</label>
                                        </div>
                                        <div id="fraTab4444Caption" tabframe="fraTab4444" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_201 T_-72">
                                            <label class="label_contain">
                                                拒往變更</label>
                                        </div>
                                        <div id="fraTab5555Caption" tabframe="fraTab5555" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_268 T_-96 W_70">
                                            <label class="label_contain">
                                                退票記錄</label>
                                        </div>
                                        <div id="fraTab6666Caption" tabframe="fraTab6666" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_340 T_-120 W_70">
                                            <label class="label_contain">
                                                退票記錄</label>
                                        </div>
                                        <div id="fraTab7777Caption" tabframe="fraTab7777" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_412 T_-144">
                                            <label class="label_contain">
                                                終止本票</label>
                                        </div>
                                        <div id="fraTab8888Caption" tabframe="fraTab8888" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_479 T_-168">
                                            <label class="label_contain">
                                                財產徵信</label>
                                        </div>
                                        <div id="fraTab9999Caption" tabframe="fraTab9999" container="fraDispTypeInfo2" onclick="Caption_onclick(this);"
                                            style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_546 T_-192">
                                            <label class="label_contain">
                                                汽車拍賣</label>
                                        </div>
                                        <div id="fraTab00001Caption" tabframe="fraTab00001" container="fraDispTypeInfo2"
                                            onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_613 T_-216">
                                            <label class="label_contain">
                                                汽貸違約</label>
                                        </div>
                                        <div id="fraTab00002Caption" tabframe="fraTab00002" container="fraDispTypeInfo2"
                                            onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu3 L_680 T_-240 W_69">
                                            <label class="label_contain">
                                                查詢記錄</label>
                                        </div>
                                        <div id="fraTab1111" class="div_content T_-220">
                                            查詢ID
                                        <asp:TextBox CssClass="txt_normal" ID="TextBox29" runat="server"></asp:TextBox>
                                            <table class="tb_Contact" width="98%">
                                                <tr>
                                                    <th>身份證號
                                                    </th>
                                                    <th>個人姓名
                                                    </th>
                                                    <th>公司統編
                                                    </th>
                                                    <th>公司名稱
                                                    </th>
                                                    <th>類別
                                                    </th>
                                                    <th>日期
                                                    </th>
                                                    <th>拒往被查
                                                    </th>
                                                    <th>退票被查
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label123" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label124" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label125" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label126" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label127" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label128" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label130" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label131" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            拒往被查
                                        <table class="tb_Contact" width="98%">
                                            <tr>
                                                <th>查詢條件
                                                </th>
                                                <th>查詢日期
                                                </th>
                                                <th>查詢者
                                                </th>
                                                <th>照會內容
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label132" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label133" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label134" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label135" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                            <br />
                                            退票被查
                                        <table class="tb_Contact" width="98%">
                                            <tr>
                                                <th>查詢條件
                                                </th>
                                                <th>查詢日期
                                                </th>
                                                <th>查詢者
                                                </th>
                                                <th>照會內容
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label136" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label137" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label138" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label139" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        <div id="fraTab2222" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox20" runat="server" Width="98px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox22" runat="server" Width="98px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>票據交換所
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox23" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox24" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">公司名稱
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox30" runat="server" Width="235px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">負責人
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox31" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">身份證號
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox33" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">出生年月日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox32" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>地址
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox34" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>銀行
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox35" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2"></th>
                                                    <th>(分行)帳號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox36" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox37" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox38" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox39" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox40" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox41" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox50" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更原因
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox84" runat="server" Width="152px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>變更內容
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox85" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab3333" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox86" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">公司名稱
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox87" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox88" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2"></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox125" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>票據交換所
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox108" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>統一編號</th>
                          <td><asp:TextBox ID="TextBox109" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>公司名稱</th>
                          <td colspan="2"><asp:TextBox ID="TextBox110" runat="server" Width="275px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th width="12%">負責人
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox111" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">身份證號
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox112" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">出生年月日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox113" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>地址
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox114" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>銀行
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox115" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(分行)帳號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox816" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox117" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox118" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox119" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox120" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox121" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox122" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更原因
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox123" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>變更內容
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox124" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab4444" class="div_content padleft_0 T_-240">
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th>變更內容
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox126" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox127" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>票據交換所
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox128" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox129" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">公司名稱
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox130" runat="server" Width="249px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">負責人
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox131" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">身份證號
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox132" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">出生年月日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox133" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>地址
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox134" runat="server" Width="601px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>銀行
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox135" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(分行)帳號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox136" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox138" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox139" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox140" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox141" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox142" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox143" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更原因
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox144" runat="server" Width="166px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>統一編號</th>
                          <td><asp:TextBox ID="TextBox145" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>公司名稱</th>
                          <td colspan="2"><asp:TextBox ID="TextBox146" runat="server" Width="264px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                            </table>
                                        </div>
                                        <div id="fraTab5555" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>輸入日期
                                                    </th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox147" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox276" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="15%">輸入日期
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="TextBox148" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="15%">退票截止日期
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="TextBox149" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="8%">姓名
                                                    </th>
                                                    <td width="10%">
                                                        <asp:TextBox ID="TextBox150" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">身份證號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox151" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>公司統編
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox152" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>公司名稱
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox153" runat="server" Width="140px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;查詢結果<asp:TextBox ID="TextBox154" runat="server" Width="140px"
                                                            CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox155" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>備註
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox156" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>拒絕往來資訊
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox157" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>拒絕往來，
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox158" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        解除
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>終止本票擔當
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox159" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>終止本票擔當，
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox160" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        解除終止本票擔
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>關係戶戶號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox161" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>關係戶戶名
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox162" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox163" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox164" runat="server" Width="98%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                    <td colspan="6">備註代碼說明：A.清償贖回，B.重提付訖，C.提存備付
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="tb_Contact" style="margin-left: 10px; margin-top: 10px;" width="90%">
                                                <tr>
                                                    <th>退票日期
                                                    </th>
                                                    <th>退票行
                                                    </th>
                                                    <th>帳號
                                                    </th>
                                                    <th>票據號碼
                                                    </th>
                                                    <th>金額
                                                    </th>
                                                    <th>退票理由
                                                    </th>
                                                    <th>清償注記
                                                    </th>
                                                    <th>備註
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label25" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label27" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label28" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label29" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab6666" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>輸入日期
                                                    </th>
                                                    <td colspan="7">
                                                        <asp:TextBox ID="TextBox165" runat="server" Width="83px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="14%"></th>
                                                    <td width="14%">
                                                        <asp:TextBox ID="TextBox166" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="16%">退票截止日期
                                                    </th>
                                                    <td width="14%">
                                                        <asp:TextBox ID="TextBox167" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="6%">姓名
                                                    </th>
                                                    <td width="17%">
                                                        <asp:TextBox ID="TextBox168" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">身份證號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox169" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>公司統編
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox174" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>公司名稱
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox175" runat="server" Width="170px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                        查詢結果<asp:TextBox ID="TextBox176" runat="server" Width="170px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>開戶行代碼
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox177" runat="server" Width="90%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>開戶行帳號
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox178" runat="server" Width="400px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table class="tb_Contact" style="margin-left: 10px;" width="90%">
                                                <tr>
                                                    <th></th>
                                                    <th colspan="2">已清償注記
                                                    </th>
                                                    <th colspan="2">未清償注記
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th>退票理由
                                                    </th>
                                                    <th>張數
                                                    </th>
                                                    <th>金額
                                                    </th>
                                                    <th>張數
                                                    </th>
                                                    <th>金額
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>1.存款不足
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server">1</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server">334500</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>2.發票人簽章不符
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label31" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label36" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>3.擅自指定金融業者為本票之擔當付款人
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label41" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label42" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label44" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>4.本票提示期限經過前撤銷付款委託
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label45" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label46" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label47" runat="server">0</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server">0</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">開戶總數資訊已在台灣地區全體金融業者開立支票款戶共
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label49" runat="server">5</asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            其他重要資訊
                                        <asp:TextBox ID="TextBox179" runat="server" Width="180px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox ID="TextBox180" runat="server" Width="180px" CssClass="txt_readonly"
                                                ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox ID="TextBox181" runat="server" Width="180px" CssClass="txt_readonly"
                                                ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div id="fraTab7777" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox182" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">公司名稱
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox183" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox184" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2"></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox185" runat="server" Width="275px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>票據交換所
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox186" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                          <th>統一編號</th>
                          <td><asp:TextBox ID="TextBox187" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <td></td>
                          <th>公司名稱</th>
                          <td colspan="2"><asp:TextBox ID="TextBox188" runat="server" Width="275px" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th width="12%">負責人
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox189" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">身份證號
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox190" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">出生年月日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox191" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>地址
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox192" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>銀行
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox193" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">(分行)帳號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox194" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox195" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox196" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <th>銀行</th>
                          <td><asp:TextBox ID="TextBox197" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                          <th></th>
                          <td></td>
                          <th>(分行)帳號</th>
                          <td><asp:TextBox ID="TextBox198" runat="server" Width="80%" CssClass="txt_readonly" readonly="true"></asp:TextBox></td>
                        </tr>--%>
                                                <tr>
                                                    <th>拒往日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox199" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox200" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>變更原因
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox201" runat="server" Width="192px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>變更內容
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox202" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab8888" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>備註說明
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox203" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th></th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox204" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>案號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox223" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">徵信日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox225" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>公司統編
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox206" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="2">公司名稱
                                                    </th>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="TextBox207" runat="server" Width="262px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">負責人
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox208" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">身份證號
                                                    </th>
                                                    <td width="20%">
                                                        <asp:TextBox ID="TextBox209" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="12%">出生年月日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox210" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>債權人
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="TextBox211" runat="server" Width="200px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>查封日
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox224" runat="server" Width="179px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>它項權利
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox212" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>備註說明
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox205" runat="server" Width="612px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab9999" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>拍賣車日期
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox213" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox214" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">拍賣車日期
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox235" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">輸入日期
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox236" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">修改日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox237" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox216" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">公司名稱
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox217" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>身份證號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox238" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">負責人
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox239" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>總金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox218" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>萬元
                                                    </td>
                                                    <th>積欠金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox219" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>萬元
                                                    </td>
                                                    <th>車型
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox220" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>車號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox240" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>年份
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox241" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>排氣量
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox242" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>備註說明
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox215" runat="server" Width="579px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab00001" class="div_content padleft_0 T_-240">
                                            <table width="99%" class="tb_Info" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <th>裁定日期
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox221" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox222" runat="server" Width="105px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="12%">裁定日期
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox226" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">輸入日期
                                                    </th>
                                                    <td width="22%">
                                                        <asp:TextBox ID="TextBox227" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th width="10%">修改日期
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox228" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>統一編號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox229" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th colspan="3">公司名稱
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox230" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>身份證號
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox231" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2"></td>
                                                    <th>負責人
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox232" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>分期金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox233" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>萬元
                                                    </td>
                                                    <th>積欠金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox234" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>萬元
                                                    </td>
                                                    <td colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <th>本票裁定
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox244" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>車主/保人
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox245" runat="server" Width="75%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <th>退件
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="TextBox246" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>備註說明
                                                    </th>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="TextBox247" runat="server" Width="579px" CssClass="txt_readonly"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="fraTab00002" class="div_content padleft_0 T_-240">
                                            <table class="tb_Contact" style="margin-left: 10px; margin-top: 10px;" width="90%">
                                                <tr>
                                                    <th>下載批號
                                                    </th>
                                                    <th>下載日期
                                                    </th>
                                                    <th>下載時間
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label50" runat="server">2006062170</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label51" runat="server">95/06/22</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label52" runat="server">10:49:03</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label53" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label54" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label55" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label56" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label57" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label58" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="btn_div">
                                                <asp:Button ID="Button4" runat="server" Text="重送" Enabled="false" CssClass="btn_normal" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="fraTab222" class="div_content padleft_0" style="margin-top: 62px;">
                                    <div style="width: 750px;">
                                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                                            <tr>
                                                <td></td>
                                                <td>申戶
                                                </td>
                                                <td>保人1
                                                </td>
                                                <td>保人2
                                                </td>
                                                <td>保人3
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>全部
                                                <asp:CheckBox ID="CheckBox37" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox38" runat="server" /><asp:TextBox ID="TextBox25" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox39" runat="server" /><asp:TextBox ID="TextBox26" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox40" runat="server" /><asp:TextBox ID="TextBox27" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox41" runat="server" /><asp:TextBox ID="TextBox28" CssClass="txt_normal"
                                                        Width="120px" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="text-align: center;">
                                                    <asp:Button ID="Button8" CssClass="btn_normal" runat="server" Text="查詢" />
                                                    <asp:Button ID="Button7" CssClass="btn_normal" runat="server" Text="列印" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="fraDispTypeInfo3" class="frame_content div_Info2" style="border: none; width: 750px;">
                                            <div id="fraTab11111Caption" tabframe="fraTab11111" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 ">
                                                <label class="label_contain">
                                                    個人綜合信用</label>
                                            </div>
                                            <div id="fraTab22222Caption" tabframe="fraTab22222" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_159 T_-24 ">
                                                <label class="label_contain">
                                                    退票與被查記錄</label>
                                            </div>
                                            <div id="fraTab33333Caption" tabframe="fraTab33333" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_318 T_-48 ">
                                                <label class="label_contain">
                                                    信用卡資訊</label>
                                            </div>
                                            <div id="fraTab44444Caption" tabframe="fraTab44444" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_477 T_-72 ">
                                                <label class="label_contain">
                                                    卡戶基本資料</label>
                                            </div>
                                            <div id="fraTab55555Caption" tabframe="fraTab55555" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu6 L_636 T_-96 W_133">
                                                <label class="label_contain">
                                                    信用卡還款</label>
                                            </div>
                                            <div id="fraTab66666Caption" tabframe="fraTab66666" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-97">
                                                <label class="label_contain">
                                                    貸款還款與逾期</label>
                                            </div>
                                            <div id="fraTab77777Caption" tabframe="fraTab77777" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-121 L_125">
                                                <label class="label_contain">
                                                    通報案件</label>
                                            </div>
                                            <div id="fraTab88888Caption" tabframe="fraTab88888" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-145 L_250">
                                                <label class="label_contain">
                                                    補充注記</label>
                                            </div>
                                            <div id="fraTab99999Caption" tabframe="fraTab99999" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-169 L_375">
                                                <label class="label_contain">
                                                    查詢記錄</label>
                                            </div>
                                            <div id="fraTab00000Caption" tabframe="fraTab00000" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-193 L_500">
                                                <label class="label_contain">
                                                    列印項目</label>
                                            </div>
                                            <div id="fraTab000000Caption" tabframe="fraTab000000" container="fraDispTypeInfo3"
                                                onclick="Caption_onclick(this);" style="border-top: 1px solid #9FA1AD;" class="sheet div_menu7 T_-217 L_625 W_124">
                                                <label class="label_contain">
                                                    往來實積</label>
                                            </div>
                                            <div id="fraTab11111" class="div_content padleft_0 T_-216">
                                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                    <tr>
                                                        <th width="22%">身份證號/姓名：
                                                        </th>
                                                        <td width="35%">
                                                            <asp:TextBox ID="TextBox89" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th width="20%">厲害關係人：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox90" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>英文姓名：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox91" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>出生日期：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox93" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>戶籍地：
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox95" CssClass="txt_readonly" ReadOnly="true" Width="85%" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>資料年月：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox97" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">授信異常注記/日期：</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox99" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>
                                                        </td>
                                                        <th colspan="2"></th>
                                                    </tr>
                                                    <tr>
                                                        <th>訂約金額：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox101" CssClass="txt_readonly" ReadOnly="true" Width="80%"
                                                                runat="server"></asp:TextBox>仟元
                                                        </td>
                                                        <th>無擔保總歸戶餘額：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox102" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>仟元
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>不含餘催呆總餘額：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox103" CssClass="txt_readonly" ReadOnly="true" Width="80%"
                                                                runat="server"></asp:TextBox>仟元
                                                        </td>
                                                        <th>從債務總歸戶餘額：
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox104" CssClass="txt_readonly" ReadOnly="true" Width="82px"
                                                                runat="server"></asp:TextBox>仟元
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">逾期金額：</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox92" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>仟元
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">催收金額：</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox94" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>仟元
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <font class="bold_red">呆帳金額：</font>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox96" CssClass="txt_readonly" ReadOnly="true" Width="80%" runat="server"></asp:TextBox>仟元
                                                        </td>
                                                        <td colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <th>退票或拒往記錄：
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox98" CssClass="txt_readonly" ReadOnly="true" Width="85%" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab22222" class="div_content T_-200">
                                                退票紀錄筆數：<asp:Label ID="Label155" runat="server" Text="Label">1</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th width="16%">未清償總金額
                                                        </th>
                                                        <th width="16%">未清償總張數
                                                        </th>
                                                        <th width="16%">最後一次退票日期
                                                        </th>
                                                        <th width="16%">已清償總金額
                                                        </th>
                                                        <th width="16%">已清償總張數
                                                        </th>
                                                        <th>最近一次清償日期
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td></td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                聊徵資料筆數：<asp:Label ID="Label156" runat="server" Text="Label">3</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th width="12%">查詢日期
                                                        </th>
                                                        <th width="16%">查詢單位名稱
                                                        </th>
                                                        <th width="12%">查詢項目串列
                                                        </th>
                                                        <th width="12%">查詢理由碼
                                                        </th>
                                                        <th width="16%">查詢理由中文註釋
                                                        </th>
                                                        <th>備註
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>遠東國際商業
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>新業務
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>遠東國際商業
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>新業務
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/12/01
                                                        </td>
                                                        <td>遠東國際商業
                                                        </td>
                                                        <td>ABDKS
                                                        </td>
                                                        <td>1
                                                        </td>
                                                        <td>新業務
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab33333" class="div_content T_-200">
                                                信用卡資料筆數：<asp:Label ID="Label157" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th width="10%">發卡機構
                                                        </th>
                                                        <th width="8%">卡名
                                                        </th>
                                                        <th width="8%">卡別
                                                        </th>
                                                        <th width="10%">啟用日期
                                                        </th>
                                                        <th width="10%">額度千元
                                                        </th>
                                                        <th width="6%">綜合
                                                        </th>
                                                        <th width="6%">循環
                                                        </th>
                                                        <th width="6%">擔保
                                                        </th>
                                                        <th width="6%">主附卡
                                                        </th>
                                                        <th width="10%">停用日期
                                                        </th>
                                                        <th width="16%">停用種類/原因
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>玉山銀行
                                                        </td>
                                                        <td>VISA
                                                        </td>
                                                        <td>普卡
                                                        </td>
                                                        <td>93/04/22
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td width="4%">N
                                                        </td>
                                                        <td width="4%">Y
                                                        </td>
                                                        <td>97/04/21
                                                        </td>
                                                        <td>一般停用/申請
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>玉山銀行
                                                        </td>
                                                        <td>VISA
                                                        </td>
                                                        <td>普卡
                                                        </td>
                                                        <td>93/04/22
                                                        </td>
                                                        <td>50
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td>Y
                                                        </td>
                                                        <td>97/04/21
                                                        </td>
                                                        <td>一般停用/申請
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab44444" class="div_content padleft_0 T_-216">
                                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                    <tr>
                                                        <td colspan="6">信用卡戶基本資訊筆數：
                                                        <asp:Label ID="Label166" runat="server" Text="Label">2</asp:Label>
                                                    </tr>
                                                    <tr>
                                                        <th>報送年月
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox264" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th>報送機構
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox265" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true">聯邦銀行</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th></th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox266" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th></th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox267" runat="server" Width="80%" CssClass="txt_readonly" ReadOnly="true">玉山銀行</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>報送年月
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox268" runat="server" CssClass="txt_readonly" ReadOnly="true">97/02</asp:TextBox>
                                                        </td>
                                                        <th>報送機構
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox269" runat="server" CssClass="txt_readonly" ReadOnly="true">聯邦銀行</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th width="12%">中文名稱
                                                        </th>
                                                        <td width="20%">
                                                            <asp:TextBox ID="TextBox270" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th width="10%">出生日期
                                                        </th>
                                                        <td width="20%">
                                                            <asp:TextBox ID="TextBox271" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th width="12%">教育程度
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox272" runat="server" Width="126px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>戶籍地址
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox250" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>通訊地址
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox251" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>居住電話
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox273" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>公司電話
                                                        </th>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="TextBox274" runat="server" Width="569px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>任職機構
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox252" runat="server" Width="276px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <th>任職職稱
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox253" runat="server" Width="126px" CssClass="txt_readonly"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>服務年資
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="TextBox254" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>年
                                                        </td>
                                                        <th>年薪
                                                        </th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="TextBox255" runat="server" CssClass="txt_readonly" ReadOnly="true">200</asp:TextBox>仟元
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab55555" class="div_content T_-200">
                                                信用卡戶繳款記錄筆數：
                                            <asp:Label ID="Label158" runat="server" Text="Label">8</asp:Label>
                                                <table class="tb_Contact" width="98%">
                                                    <tr>
                                                        <th>資料年月
                                                        </th>
                                                        <th>發卡機構代碼
                                                        </th>
                                                        <th>發卡機構
                                                        </th>
                                                        <th>卡名
                                                        </th>
                                                        <th>核定額度
                                                        </th>
                                                        <th>應繳金額級距
                                                        </th>
                                                        <th>預借現金有無
                                                        </th>
                                                        <th>債權狀態
                                                        </th>
                                                        <th>結案注記
                                                        </th>
                                                        <th>繳納狀況
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>聯邦銀行
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>未消費
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>聯邦銀行
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>未消費
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>聯邦銀行
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>未消費
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>聯邦銀行
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>未消費
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/09
                                                        </td>
                                                        <td>803
                                                        </td>
                                                        <td>聯邦銀行
                                                        </td>
                                                        <td>V
                                                        </td>
                                                        <td>20
                                                        </td>
                                                        <td>OL
                                                        </td>
                                                        <td>N
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td>未消費
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab66666" class="div_content T_-200">
                                                個人借款餘額及還款紀錄筆數：
                                            <asp:Label ID="Label159" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>資料年月
                                                        </th>
                                                        <th>行庫名稱
                                                        </th>
                                                        <th>代號/科目
                                                        </th>
                                                        <th>用途別/說明
                                                        </th>
                                                        <th>訂約金額
                                                        </th>
                                                        <th>授信餘額
                                                        </th>
                                                        <th>逾期未還金額
                                                        </th>
                                                        <th>主/從
                                                        </th>
                                                        <th>關係
                                                        </th>
                                                        <th colspan="12">最近12個月還款紀錄
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>98/11
                                                        </td>
                                                        <td>萬泰商業
                                                        </td>
                                                        <td>Y/現金卡
                                                        </td>
                                                        <td>4/周轉金
                                                        </td>
                                                        <td>1,000
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>主債
                                                        </td>
                                                        <td></td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>98/11
                                                        </td>
                                                        <td>萬泰商業
                                                        </td>
                                                        <td>Y/現金卡
                                                        </td>
                                                        <td>4/周轉金
                                                        </td>
                                                        <td>1,000
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>0
                                                        </td>
                                                        <td>主債
                                                        </td>
                                                        <td></td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                        <td>×
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                個人逾期催收或呆帳資料筆數：
                                            <asp:Label ID="Label160" runat="server" Text="Label">2</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>資料年月
                                                        </th>
                                                        <th>銀行/分行
                                                        </th>
                                                        <th>行庫名稱
                                                        </th>
                                                        <th>代號/科目
                                                        </th>
                                                        <th>逾期代號/說明
                                                        </th>
                                                        <th>逾期未還金額
                                                        </th>
                                                        <th>債權轉讓注記
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>96/02
                                                        </td>
                                                        <td>812/0643
                                                        </td>
                                                        <td>台新國際商業銀行復興分行
                                                        </td>
                                                        <td>A/催收款項
                                                        </td>
                                                        <td>2/逾期 6月至未還
                                                        </td>
                                                        <td>21
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>96/02
                                                        </td>
                                                        <td>812/0643
                                                        </td>
                                                        <td>台新國際商業銀行復興分行
                                                        </td>
                                                        <td>A/催收款項
                                                        </td>
                                                        <td>2/逾期 6月至未還
                                                        </td>
                                                        <td>21
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab77777" class="div_content T_-200">
                                                通報案件資料筆數：
                                            <asp:Label ID="Label161" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>通報種類
                                                        </th>
                                                        <th>通報單位
                                                        </th>
                                                        <th>發生日期
                                                        </th>
                                                        <th>通報日期
                                                        </th>
                                                        <th>中文戶名
                                                        </th>
                                                        <th>單據號碼
                                                        </th>
                                                        <th>說明
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                個人身份證更改筆數：
                                            <asp:Label ID="Label162" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="70%">
                                                    <tr>
                                                        <th>原ID
                                                        </th>
                                                        <th>新ID
                                                        </th>
                                                        <th>中文姓名
                                                        </th>
                                                        <th>處理日期
                                                        </th>
                                                        <th>比對代碼
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab88888" class="div_content T_-200">
                                                補充注記/消債條例信用注記資訊筆數：
                                            <asp:Label ID="Label163" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>訊息登錄日期
                                                        </th>
                                                        <th>訊息
                                                        </th>
                                                        <th>種類大項
                                                        </th>
                                                        <th>訊息
                                                        </th>
                                                        <th>種類細項
                                                        </th>
                                                        <th>訊息內容
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                偽造信用狀 & 保證函資料筆數：
                                            <asp:Label ID="Label164" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>案由
                                                        </th>
                                                        <th>通告單位
                                                        </th>
                                                        <th>發生日期
                                                        </th>
                                                        <th>通報日期
                                                        </th>
                                                        <th>中文戶名
                                                        </th>
                                                        <th>單據號碼
                                                        </th>
                                                        <th>說明
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <br />
                                                債權轉讓資料筆數：
                                            <asp:Label ID="Label165" runat="server" Text="Label">0</asp:Label>
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>轉讓年月
                                                        </th>
                                                        <th>原債權行庫名稱
                                                        </th>
                                                        <th>代碼/科目
                                                        </th>
                                                        <th>用途別/說明
                                                        </th>
                                                        <th>訂約金額
                                                        </th>
                                                        <th>授信未逾期
                                                        </th>
                                                        <th>逾期金額
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fraTab99999" class="div_content T_-200">
                                                <table class="tb_Contact" width="90%">
                                                    <tr>
                                                        <th>下載批號
                                                        </th>
                                                        <th>下載日期
                                                        </th>
                                                        <th>下載時間
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label59" runat="server">2010010459</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label60" runat="server">99/01/04</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label61" runat="server">10:49:03</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label62" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label63" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label64" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label65" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label66" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label67" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="btn_div">
                                                    <asp:Button ID="Button6" runat="server" Text="重送" Enabled="false" CssClass="btn_normal" />
                                                </div>
                                            </div>
                                            <div id="fraTab00000" class="div_content T_-200">
                                            </div>
                                            <div id="fraTab000000" class="div_content T_-200">
                                                長租
                                            <div class="div_table">
                                                <table class="tb_Contact" width="97%">
                                                    <tr>
                                                        <th>類型
                                                        </th>
                                                        <th>合約編號
                                                        </th>
                                                        <th>車型/承作標的
                                                        </th>
                                                        <th>保證金
                                                        </th>
                                                        <th>實貸金額
                                                        </th>
                                                        <th>未到期租金總額
                                                        </th>
                                                        <th>租期
                                                        </th>
                                                        <th>已繳期數
                                                        </th>
                                                        <th>合計金額
                                                        </th>
                                                        <th>備註
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>長租
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label68" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label69" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label70" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label71" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label72" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label73" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label74" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label75" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label76" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>小計
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label103" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label104" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label105" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label106" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label107" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label108" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label109" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label110" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label111" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>設備租賃
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label112" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label113" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label114" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label115" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label116" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label117" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label118" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label119" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label120" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>小計
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label121" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label122" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label129" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label140" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label141" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label142" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label143" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label144" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label145" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>合計
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label146" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label147" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label148" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label149" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label150" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label151" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label152" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label153" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label154" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="fraTab333" class="div_content">
                                    <div style="position: relative; left: 10px; top: 70px;">
                                        <div class="div_table">
                                            <table class="tb_Contact" width="97%">
                                                <tr>
                                                    <th>類型
                                                    </th>
                                                    <th>合約編號
                                                    </th>
                                                    <th>車型/承作標的
                                                    </th>
                                                    <th>保證金
                                                    </th>
                                                    <th>實貸金額
                                                    </th>
                                                    <th>未到期租金總額
                                                    </th>
                                                    <th>租期
                                                    </th>
                                                    <th>已繳期數
                                                    </th>
                                                    <th>合計金額
                                                    </th>
                                                    <th>備註
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>長租
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label167" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label168" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label169" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label170" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label171" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label172" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label173" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label174" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label175" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>小計
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label176" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label177" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label178" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label179" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label180" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label181" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label182" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label183" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label184" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>設備租賃
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label185" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label186" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label187" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label188" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label189" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label190" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label191" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label192" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label193" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>小計
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label194" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label195" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label196" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label197" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label198" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label199" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label200" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label201" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label202" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>合計
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label203" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label204" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label205" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label206" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label207" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label208" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label209" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label210" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label211" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--信用查詢End --%>
                        <%--覆核報告BEGIN --%>
                        <div id="fraTab88" class="div_content T_-188" style="display: none; min-height: 780px; height: auto !important;">
                            <table width="100%">
                                <tr>
                                    <td>覆核確認
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITCNFDT_YMD" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>覆核確認時間
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITCNFDT_HS" runat="server" Width="85px" MaxLength="4"
                                            onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)" onblur="check_keyintime(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>覆核完成
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITFINDT_YMD" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>覆核完成時間
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITFINDT_HS" runat="server" Width="85px" MaxLength="4"
                                            onkeypress="OnlyNum(this);" onfocus="TimeFocus(this)" onblur="check_keyintime(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>收件日期
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITSNDDT" runat="server" Width="85px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>送件日期
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab8_tbxCREDITRCVDT" runat="server" Width="85px" CssClass="txt_readonly"
                                            ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <%--<td>簽核權限</td>
                    <td><asp:DropDownList ID="tab8_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList></td>--%>
                                    <!--UPD BY VICKY 20140630 加入徵審人員 -->
                                    <td>徵審人員
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Style="display: none">
                                        </asp:DropDownList>
                                        <asp:Label ID="tab8_labCREDITER" runat="server"></asp:Label>
                                        <asp:Label ID="tab8_labCREDITER_ID" runat="server" Style="display: none"></asp:Label>
                                    </td>
                                    <td>徵信覆核建議
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_ddlCREDITSUGGEST" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <!-- UPD BY VICKY 20140630 加入 實貸金額權限,IRR權限-->
                                <tr>
                                    <td>實貸金額權限
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>IRR權限
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab8_drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">營業單位建議
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:TextBox ID="tab8_CREDITSALESDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">信管覆核意見
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:TextBox ID="tab8_CREDITDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <%--Modify 20140806 By SS Chris Hung. Reason: 在徵信報告頁籤畫面中，新增結論登記區塊.--%>
                            <div>
                                <%-- 新增結論登記區塊 begin--%>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" rowspan="11">徵信結論 (覆審)
                                        </th>
                                        <th style="width: 110px; nowrap;">建議額度(元)
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCREDITAMT_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="width: 120px; nowrap;">期數
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCONTRACTMON_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                        </td>
                                        <th style="width: 100px; nowrap;">履保金(元)
                                        </th>
                                        <td style="width: 100px; nowrap;">
                                            <asp:TextBox ID="txtPERBOND_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" colspan="6">擔保品
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" width="110px">
                                            <asp:CheckBox ID="chkGRTMV_R" runat="server" Text="動產" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTIMV_R" runat="server" Text="不動產" />
                                        </th>
                                        <th style="text-align: center; nowrap;" width="120px">
                                            <asp:CheckBox ID="chkGRTDEPOSIT_R" runat="server" Text="定存質押" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTBILLNOTE_R" runat="server" Text="客票" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTSTOCK_R" runat="server" Text="股票" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTCAR_R" runat="server" Text="車輛" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">
                                            <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                            擔保品總餘額<br />
                                            (元，含履保)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtGRTBAL_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="nowrap;" width="120px">
                                            <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                            擔保品價值<br />
                                            (含履保)
                                        </th>
                                        <td>
                                            <!--20150109 ADD BY SS ADAM REASON.增加觸發簽核備註 -->
                                            <asp:TextBox ID="txtGRTVAL_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo2"></asp:TextBox>
                                        </td>
                                        <td>％
                                        </td>
                                        <td>&nbsp
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">資金用途
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlFUNDSUSE_R" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                <asp:ListItem Text="實體交易" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="非實體交易" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">設備狀態
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlCONDITION_R" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="新機" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="中古機" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">操作模式
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlOPERATION_R" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">設備類型
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDEVICETYPE_R" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo2">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">借舊還新扣除頜
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtDEDUCTION_R" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ===START===-->
                                    <tr>
                                        <th style="nowrap;">行業別
                                        </th>
                                        <td colspan="3">
                                            <%--20221207 行業別改下拉選單--%>
                                            <asp:DropDownList ID="DrpNDU_TAB8" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                DataValueField="MCODE" Enabled="False">
                                                <asp:ListItem>請選擇</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:TextBox ID="txtINDUID_TAB8" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB8');" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtINDUNM_TAB8" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                            <asp:Button ID="btnINDUPAGE_TAB8" runat="server" Text="查詢行業別" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal" Visible="false" />
                                        </td>
                                        <th style="nowrap;">案件產品別
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRODCD_TAB8" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ====END====-->
                                    <tr>
                                        <th style="nowrap;" width="110px">動產抵押品
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtGRTITEM_R" MaxLength="500" runat="server" Width="99%" TextMode="Multiline"
                                                Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">其他條件
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtOTHERCONDITION_R" MaxLength="500" runat="server" Width="99%"
                                                TextMode="Multiline" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">簽核權限/備註
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSIGNMEMO_R" runat="server" ReadOnly="true" Width="99%" TextMode="Multiline"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%-- 新增結論登記區塊 end--%>
                            <%--20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內 --%>
                            <br />
                            <center>
                                <asp:Button ID="btnSaveSureTab8" runat="server" Text="儲存" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSureTab8_Click(this);"
                                    OnClick="btnSaveSureTab8_Click" Width="80" />
                                <asp:Button ID="cmdPrintReportC" runat="server" Text="列印覆核徵信報告書" CssClass="btn_normal"
                                    OnClientClick="javascipt:return cmdPrintC_onClick(this);" Width="120" />
                            </center>
                        </div>
                        <%--覆核報告END --%>
                        <%--放審會報告 BEGIN --%>
                        <div id="fraTab99" class="div_content T_-188" style="display: none; min-height: 780px; height: auto !important;">
                            <table width="100%">
                                <tr>
                                    <td>徵審人員
                                    </td>
                                    <td colspan="5">
                                        <asp:DropDownList ID="tab9_ddlPROPOSEDSIGN" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Style="display: none">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>營業端進件日
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab9_txtCNFDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                    <td>審查日完成日
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="tab9_txtFINDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>實貸金額權限
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_drpACTUSLLOANSAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>IRR權限
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_drpIRRAUTH" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>審查建議
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_ddlCREDITSUGGEST" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                        <asp:Label ID="tab9_labCREDITER_ID" runat="server" Style="display: none"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>審查委員會建議
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tab9_ddlCREDITSUGGEST2" runat="server" Width="90px" DataTextField="MNAME1"
                                            DataValueField="MCODE">
                                        </asp:DropDownList>
                                    </td>
                                    <td>放審會決議日
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tab9_txtSUGGESTDT" runat="server" Width="85px" MaxLength="8"
                                            onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);checkdate(this);"
                                            CssClass="txt_normal"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">審查委員最終決議
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtFINDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">營業單位建議
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtEVALUATE" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">信審審查會建議
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:TextBox ID="tab9_txtSUGGESTDESC" runat="server" TextMode="MultiLine" Width="100%"
                                            Height="200px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <table class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 10px; border: 1px solid #9FA1AD; margin-left: -5px;">
                                    <tr>
                                        <th width="80px" rowspan="11">徵信結論 (放審會)
                                        </th>
                                        <th style="width: 110px; nowrap;">建議額度(元)
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCREDITAMT_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="width: 120px; nowrap;">期數
                                        </th>
                                        <td style="xwidth: 100px; nowrap;">
                                            <asp:TextBox ID="txtCONTRACTMON_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                        </td>
                                        <th style="width: 100px; nowrap;">履保金(元)
                                        </th>
                                        <td style="width: 100px; nowrap;">
                                            <asp:TextBox ID="txtPERBOND_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" colspan="6">擔保品
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center; nowrap;" width="110px">
                                            <asp:CheckBox ID="chkGRTMV_TAB9" runat="server" Text="動產" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTIMV_TAB9" runat="server" Text="不動產" />
                                        </th>
                                        <th style="text-align: center; nowrap;" width="120px">
                                            <asp:CheckBox ID="chkGRTDEPOSIT_TAB9" runat="server" Text="定存質押" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTBILLNOTE_TAB9" runat="server" Text="客票" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTSTOCK_TAB9" runat="server" Text="股票" />
                                        </th>
                                        <th style="text-align: center; nowrap;">
                                            <asp:CheckBox ID="chkGRTCAR_TAB9" runat="server" Text="車輛" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">
                                            <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                            擔保品總餘額<br />
                                            (元，含履保)
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtGRTBAL_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                        <th style="nowrap;" width="120px">
                                            <!--20141218 ADD BY SS ADAM REASON.增加含履保的提示 -->
                                            擔保品價值<br />
                                            (含履保)
                                        </th>
                                        <td>
                                            <!--20150109 ADD BY SS ADAM REASON.增加觸發簽核備註 -->
                                            <asp:TextBox ID="txtGRTVAL_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right" AutoPostBack="True" OnTextChanged="setMemo3"></asp:TextBox>
                                        </td>
                                        <td>％
                                        </td>
                                        <td>&nbsp
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">資金用途
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlFUNDSUSE_TAB9" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFUNDSUSE_SelectedIndexChanged">
                                                <asp:ListItem Text="實體交易" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="非實體交易" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">設備狀態
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlCONDITION_TAB9" runat="server" AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="新機" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="中古機" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">操作模式
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlOPERATION_TAB9" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                            </asp:DropDownList>
                                        </td>
                                        <th style="nowrap;" width="120px">設備類型
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlDEVICETYPE_TAB9" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                AutoPostBack="True" OnSelectedIndexChanged="setMemo3">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">借舊還新扣除頜
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtDEDUCTION_TAB9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right"
                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ===START===-->
                                    <tr>
                                        <th style="nowrap;">行業別
                                        </th>
                                        <td colspan="3">
                                            <%--20221207行業別改下拉選單--%>
                                            <asp:DropDownList ID="DrpNDU_TAB9" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                                DataValueField="MCODE" Enabled="False">
                                                <asp:ListItem>請選擇</asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:TextBox ID="txtINDUID_TAB9" MaxLength="7" class="txt_normal" runat="server" onblur="txtINDUID_onblur(this,'TAB9');" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtINDUNM_TAB9" Enable="false" runat="server" CssClass="txt_normal" Width="150px" Visible="false"></asp:TextBox>
                                            <asp:Button ID="btnINDUPAGE_TAB9" runat="server" Text="查詢行業別" OnClientClick="btnINDUPAGE_Click(); return false;" CssClass="btn_normal"  Visible="false"/>
                                        </td>
                                        <th style="nowrap;">案件產品別
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="drpPRODCD_TAB9" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- 20160323 ADD BY SS ADAM REASON.新增行業別，案件產品別 ====END====-->
                                    <tr>
                                        <th style="nowrap;" width="110px">動產抵押品
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtGRTITEM_TAB9" MaxLength="500" runat="server" Width="99%" TextMode="Multiline"
                                                Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">其他條件
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtOTHERCONDITION_TAB9" MaxLength="500" runat="server" Width="99%"
                                                TextMode="Multiline" Height="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="nowrap;" width="110px">簽核權限/備註
                                        </th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtSIGNMEMO_TAB9" runat="server" ReadOnly="true" Width="99%" TextMode="Multiline"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <center>
                                <asp:Button ID="btnSaveSureTab9" runat="server" Text="儲存" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSureTab9_Click(this);"
                                    OnClick="btnSaveSureTab9_Click" Width="80" />
                                <asp:Button ID="btnPrintExamine" runat="server" Text="列印審查會報告" CssClass="btn_normal" OnClick="btnPrintExamine_Click" Width="120" />
                            </center>
                            <asp:HiddenField ID="hdTAB9FILEPATH1" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH2" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH3" runat="server" Value="" />
                            <asp:HiddenField ID="hdTAB9FILEPATH4" runat="server" Value="" />
                        </div>

                        <%--放審會報告 END --%>
                    </div>
                    <%--20120221 UPD BY SSF MAUREEN REASON:修改按鈕--%>
                    <div class="btn_div">
                        <asp:Button ID="btnSaveSure" runat="server" Text="確認" CssClass="btn_normal" OnClientClick="javascipt:return btnSaveSure_Click(this);"
                            OnClick="btnSaveSure_Click" Width="80" />
                        <%--20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內
                    <asp:Button ID="cmdPrintReportB" runat="server" Text="列印徵信報告書" CssClass="btn_normal"
                        OnClientClick="javascipt:return cmdPrintB_onClick(this);" Width="120" /> --%>&nbsp;&nbsp;
                    <%--<asp:Button ID="btnSaveTemp" runat="server" Text="暫存" CssClass="btn_normal" OnClick="btnSaveTemp_Click" Width="80"/>
          <asp:Button ID="btnSubmit" runat="server" Text="徵信核准" CssClass="btn_normal" OnClientClick="javascipt:return btnSubmit_Click(this);"
            OnClick="btnSubmit_Click" Width="80"/>--%>
                        <%--<asp:Button ID="btnSelect" runat="server" Text="附條件" CssClass="btn_normal" OnClick="btnSelect_Click" Width="80"/>
          <asp:Button ID="btnWj" runat="server" Text="徵信婉拒" CssClass="btn_normal" 
            OnClick="btnWj_Click" Width="80"/>&nbsp;&nbsp;--%>
                        <%--<asp:Button ID="btnRegect" runat="server" Text="徵信退件" CssClass="btn_normal" OnClientClick="javascipt:return btnRegect_Click(this);"
            OnClick="btnRegect_Click" Width="80"/>--%>
                        <!--Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.-->
                        <asp:Button ID="btnReturnChk" runat="server" Text="案件退回" CssClass="btn_normal" OnClick="btnReturnChk_Click" />
                        <asp:Button ID="btnReturn" Style="display: none" runat="server" Text="案件退回" CssClass="btn_normal"
                            OnClick="btnReturn_Click" />
                        <asp:Button ID="btnAuditNote" runat="server" Text="案件心得" CssClass="btn_normal" OnClientClick="if (openML2001C()) return false;" />
                        <asp:HiddenField ID="hidCond" runat="server" Value="" />
                        <asp:Button ID="btnCond" Style="display: none" runat="server" Text="" OnClick="btnCond_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
