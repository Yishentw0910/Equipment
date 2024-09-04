<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3003  																					
* 程式功能  : 撥款核准(信管)																			
* 程式作者 	: 																			
* 完成時間 	: 
* 修改事項 	: 
Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」
Modify 20120601 By SS Gordon. Reason: 撥款退回改為撥款撤件.
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120614 By SS Gordon. Reason: 加入「佣金」
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.
Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕.
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
Modify 20130117 BY    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」
Modify 20131114 BY SS Leo Reason:增加擔保價值欄位
Modify 20140127 BY    SEAN.   Reason: 將撥款條件擔保價值欄位向下移
Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
Modify 20150204 By SS Vicky   Reason: 隱藏案件內容頁籤中，右方的[付款時間]及[承作真實IRR]
Modify 20150204 By SS Vicky   Reason: 承作內容的頁籤中，依是否為AR件顯示不同內容
Modify 20150205 By SS Vicky   Reason: 案件內容,隱藏[建議墊息款],增加[建議墊款息]
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
20161125 ADD BY SS ADAM REASON.增加預撥沖銷
20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本
20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%)
--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML3003A.aspx.cs" inherits="FrmML3003A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=this.GSTR_A_PRGID%>
        -<%=this.GSTR_PROGNM%></title>
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
    <!-- #Include file='js/ML3003A.js' -->                   
    </script>

</head>
<body onload="window_onload()">
    <form id="form1" runat="server">
        <div id="divBody" class="divBody">
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
            <table class="divStatus" width="60%">
                <tr>
                    <th>合約編號
                    </th>
                    <td>
                        <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true">
                        </asp:TextBox>
                        <asp:HiddenField ID="hidCASESTATUS" runat="server" Value="" />
                        <asp:HiddenField ID="HidEMPLID" runat="server" Value="" />
                        <asp:HiddenField ID="HidDEPTID" runat="server" Value="" />
                    </td>
                    <th>案件編號
                    </th>
                    <td>
                        <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly"
                            ReadOnly="true">
                        </asp:TextBox>
                    </td>
                    <!--th>
          案件核准日
        </th-->
                    <td>
                        <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                            ReadOnly="true" Style="display: none">
                        </asp:TextBox>
                    </td>
                </tr>
            </table>
            <div id="fraDispTypeInfo" class="frame_content div_Info H_1100">
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
                        承作內容</label>
                </div>
                <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-72 L_375">
                    <label class="label_contain">
                        標的物</label>
                </div>
                <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu T_-96 L_500">
                    <label class="label_contain">
                        擔保條件</label>
                </div>
                <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this);"
                    class="sheet div_menu W_124 T_-120 L_625">
                    <label class="label_contain">
                        撥款資料</label>
                </div>
                <%--客戶資料Begin --%>
                <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: none">
                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                        <tr>
                            <th width="15%">客戶統編
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="85px">
                                </asp:TextBox>
                            </td>
                            <th width="15%">客戶名稱
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="230px">
                                </asp:TextBox>
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
                                    ReadOnly="true" Width="112px">
                                </asp:TextBox>
                            </td>
                            <th>實收資本額
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Width="112px">
                                </asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;設立日期
                                <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    Width="81px" ReadOnly="true">
                                </asp:TextBox>
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
                                    Width="112px">
                                </asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;集團實際負責人
                                <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                    ReadOnly="true">
                                </asp:TextBox>
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
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;上市櫃
                                <asp:DropDownList ID="drpLISTED" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false" Width="85px">
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
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>公司登記地址
                            </th>
                            <td colspan="2">
                                <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                                <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>公司登記電話
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th>傳真
                            </th>
                            <td>
                                <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtCUSTFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>營業登記地址
                            </th>
                            <td colspan="2">
                                <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>營業登記電話
                            </th>
                            <td>
                                <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th>傳真
                            </th>
                            <td>
                                <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"></asp:TextBox>
                                <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>主要營業項目
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="81%">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>行業別
                            </th>
                            <td colspan='3'>
                                <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                                <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px"></asp:TextBox>
                                <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" CssClass="btn_normal" Enabled="false" />
                                <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ====END====-->
                                <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false" Width="100%" style="display: none;">
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
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
                                <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
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
                                            <itemtemplate>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server"
                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server"
                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE"
                                                            runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server"
                                                            Text='<%# Eval("CONTACTTEL")%>' Width="80px">
                                                        </asp:TextBox>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT"
                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE"
                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE"
                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server"
                                                            Text='<%# Eval("CONTACTFAX")%>' Width="80px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server"
                                                            Text='<%# Eval("CONTACTEMAIL")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" ReadOnly="true" CssClass="txt_table"
                                                            Text='<%# Eval("INVZIPCODE")%>'>
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" ReadOnly="true" CssClass="txt_table"
                                                            Text='<%# Eval("INVZIPCODES")%>'>
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="txtINVOICEADDR" runat="server" ReadOnly="true" CssClass="txt_table"
                                                            Width="150px" Text='<%# Eval("INVOICEADDR")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </itemtemplate>
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
                            <th width="12%">公司名稱
                            </th>
                            <td width="12%">
                                <asp:DropDownList ID="drpCOMPID" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                    Enabled="false">
                                    <asp:ListItem>和潤</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <%--Modify 20120717 By SS Gordon. Reason: 新增承作方式.--%>
                            <th width="12%">承作方式
                            </th>
                            <td width="12%">
                                <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <th width="12%">承作型態
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
                            <th width="12%">交易形態
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
                            <th>動用情形
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
                            <th>代印店
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
                            <th>銀行別
                            </th>
                            <td colspan="3">
                                <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>案件來源
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
                            <th>附追索權
                            </th>
                            <td colspan="5">
                                <asp:DropDownList ID="drpRECOURSE" runat="server">
                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                    <asp:ListItem Value="Y">是</asp:ListItem>
                                    <asp:ListItem Value="N">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                            <th>案件產品別
                            </th>
                            <td colspan="8">
                                <asp:DropDownList ID="drpPRODCD" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false">
                                </asp:DropDownList>
                            </td>
                            <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 END-->
                        </tr>
                    </table>
                    <div>
                        <div class="left_div">
                            <table class="tb_Info" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td colspan="6">
                                        <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />
                                        分期、租賃案件
                                    </td>
                                </tr>
                                <tr>
                                    <th width="20%">標的物金額
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%"></th>
                                    <td width="12%"></td>
                                    <th width="24%">保險費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtINSURANCE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>頭期款
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>佣金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCOMMISSION" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                                    <th>作業費用(有發票)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOTHERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>租購保證金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th></th>
                                    <td></td>
                                    <!--Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                                    <th>作業費用(無發票)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>履約保證金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>實貸金額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtACTUSLLOANS" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>手續費收入
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
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
                                            ReadOnly="true">
                                        </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td width="18%">期付款(含稅)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX1" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>第
                                                    <asp:TextBox ID="txtSTARTPAY2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>期付款(含稅)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX2" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>第
                                                    <asp:TextBox ID="txtSTARTPAY3" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>期付款(含稅)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX3" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>第
                                                    <asp:TextBox ID="txtSTARTPAY4" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                        Width="24px">
                                                    </asp:TextBox>
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
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </td>
                                                <td>期付款(含稅)
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPRINCIPALTAX4" custprop="100" runat="server" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
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
                                        <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" />
                                        應收帳款案件
                                    </td>
                                </tr>
                                <tr>
                                    <th>申請額度
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>徵信費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>帳務管理費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>財務顧問費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <!--Modify 20120604 By SS Gordon. Reason: AR新增履約保證金-->
                                <tr>
                                    <th>履約保證金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>成數
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        %
                                    </td>
                                </tr>
                                <tr>
                                    <th>帳款期限
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        月
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <%--UPD BY VICKY 20150204 隱藏付款時間--%>
                                    <th>付款時間
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
                                    <th>單一買方限額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true" Text="">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <%--UPD BY VICKY 20150204 承作真實IRR--%>
                                    <th>承作真實IRR
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <%--UPD BY VICKY 20150205 建議墊款息--%>
                                    <th>建議墊款息
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        %
                                    </td>
                            </table>
                        </div>
                    </div>
                    <div style="clear: both;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th>付款方式
                                </th>
                                <td colspan="3">
                                    <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false">
                                        <asp:ListItem>匯款</asp:ListItem>
                                        <asp:ListItem>支票</asp:ListItem>
                                        <asp:ListItem>套票</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th>選定專案
                                </th>
                                <td colspan="2">
                                    <asp:DropDownList ID="drpPROJECT" DataTextField="PRONAME" DataValueField="PROJID" runat="server" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnPROJECT" runat="server" CssClass="btn_normal" Text="搜尋" OnClick="btnPROJECT_Click" style="display: none" />
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
                                    <asp:DropDownList ID="drpEXPIREPROC" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>以殘值賣予供應商(客戶第三方)</asp:ListItem>
                                        <asp:ListItem>正常到期</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <!--Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」-->
                                <!--Modify 20130117 By    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」-->
                                <th>備註
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                        Width="98%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                            <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                            <tr>
                                <th>IRR
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIRR" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                <th>NPV成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                            <tr style="display: none;">
                                <th>IRR
                                </th>
                                <td></td>
                                <th>設備件NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                <th>設備件NPV成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                            <tr style="display: none;">
                                <th>資金成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCAPITALCOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                        7</asp:TextBox>
                                </td>
                                <th>融資件NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPV2" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>融資件NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="display: none;">RECOVER TEST
                                </th>
                                <td colspan="5" style="display: none;">
                                    <asp:TextBox custprop="100" ID="txtRECOVERTEST" runat="server" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
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
                <%--承作內容Begin --%>
                <div id="fraTab33" class="div_content" style="display: none">
                    <div style="width: 97%; border: 1px solid #9FA1AD;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="14%">承作型態
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtRMAINTYPE" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">交易型態
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRTRANSTYPE" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>動用情形
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRUSESTATUS" CssClass="txt_readonly" runat="server" ReadOnly="true"
                                        Width="112px">
                                    </asp:TextBox>
                                </td>
                                <th>案件來源
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpRCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE"
                                        runat="server" Enabled="false">
                                        <asp:ListItem>長租CR</asp:ListItem>
                                        <asp:ListItem>設備CR</asp:ListItem>
                                        <asp:ListItem>供應商介紹</asp:ListItem>
                                        <asp:ListItem>客戶來電</asp:ListItem>
                                        <asp:ListItem>同業介紹</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divMainTypeA" runat="server">
                        <%--UPD BY VICKY 20150204 非AR件的承作內容--%>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="14%">受讓/發票金額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRTRANSCOST" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>手續費收入
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRFEE" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                                    <th>作業費用(有發票)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtROTHERFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th width="14%">頭期款
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRFIRSTPAY" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th width="12%">保險金
                                    </th>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRINSURANCE" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <!--Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                                    <th width="16%">作業費用(無發票)
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtROTHERFEESNOTAX" custprop="100" CssClass="txt_readonly_right"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>履約保證金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <th>租購保證金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <th>徵信費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCREDITFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>實貸金額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRACTUSLLOANS" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>殘值
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRRESIDUALS" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>帳務管理費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRMANAGERFEES" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th></th>
                                    <td></td>
                                    <!--Modify 20120614 By SS Gordon. Reason: 加入「佣金」-->
                                    <th>佣金
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCOMMISSION" custprop="100" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>財務顧問費
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRFINANCIALFEES" custprop="100" CssClass="txt_readonly_right"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkRDEPOSITLOANS2" runat="server" Checked="true" onclick="chkRDEP2_click(this);" />
                                        無存借款
                                    </td>
                                    <td colspan="3">
                                        <asp:CheckBox ID="chkRDEPOSITLOANS1" runat="server" onclick="chkRDEP1_click(this);" />
                                        借款給供應商
                                        <asp:CheckBox ID="chkRDEPOSITLOANS0" runat="server" onclick="chkRDEP0_click(this);" />
                                        存款在本公司
                                    </td>
                                    <td colspan="2">存借款<asp:TextBox ID="txtRDEPOSITLOANSAMOUNT" Text="0" onkeypress="OnlyNum(this);"
                                        custprop="100" MaxLength="9" onfocus="MoneyFocus(this)" onblur="OnlyNumBlur(this);MoneyBlur(this);"
                                        CssClass="txt_normal_right" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">供應商
                                        <asp:TextBox ID="txtDSUPPLIER" runat="server" MaxLength="10" Width="80px" onkeypress="OnlyNumDUCase(this);"
                                            onblur="DSUPPLIERID_onblur(this);" CssClass="txt_normal">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtDSUPPLIERNM" runat="server" CssClass="txt_normal" Width="160px"></asp:TextBox>
                                        供應商業代ID
                                        <asp:TextBox ID="txtSUPPLIERSALE" runat="server" MaxLength="10" Width="80px" onkeypress="OnlyNumDUCase(this);"
                                            onblur="idBlur(this);" CssClass="txt_normal">
                                        </asp:TextBox>
                                        供應商業代姓名
                                        <asp:TextBox ID="txtSUPPLIERSALENM" runat="server" CssClass="txt_normal" Width="81px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th>承作月數
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRCONTRACTMONTH" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>幾月一付
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRPAYMONTH" CssClass="txt_readonly_right" runat="server"></asp:TextBox>
                                    </td>
                                    <th>付款時間
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpRPAYTIME" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Width="80px">
                                            <asp:ListItem>期初付</asp:ListItem>
                                            <asp:ListItem>期末付</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="12%">第 &nbsp; 1 &nbsp; 期
                                    </td>
                                    <td width="13%">- 第<asp:TextBox ID="txtRENDPAY1" runat="server" CssClass="txt_readonly_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td width="13%">期付款(未稅)
                                    </td>
                                    <td width="12%">
                                        <asp:TextBox ID="txtRPRINCIPAL1" custprop="100" runat="server" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                    <td width="13%">期付款(含稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX1" runat="server" custprop="100" CssClass="txt_readonly_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>第
                                        <asp:TextBox ID="txtRSTARTPAY2" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>- 第<asp:TextBox ID="txtRENDPAY2" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>期付款(未稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL2" custprop="100" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>期付款(含稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX2" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>第
                                        <asp:TextBox ID="txtRSTARTPAY3" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>- 第<asp:TextBox ID="txtRENDPAY3" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>期付款(未稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL3" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>期付款(含稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX3" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>第
                                        <asp:TextBox ID="txtRSTARTPAY4" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>- 第<asp:TextBox ID="txtRENDPAY4" runat="server" CssClass="txt_normal_right" Width="40%"></asp:TextBox>
                                        期
                                    </td>
                                    <td>期付款(未稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPAL4" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                    <td>期付款(含稅)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRPRINCIPALTAX4" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="14%">客戶付款方式
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpRCUSTPAYTYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server">
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
                                        <asp:TextBox ID="txtRPATDAYS" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>付供應商天數
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtRSUPPILERDAYS" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="divMainTypeB" runat="server" style="display: none;">
                        <%--UPD BY VICKY 20150204 AR件的承作內容--%>
                        <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <th width="15%">總受讓金額
                                    </th>
                                    <td width="18%">
                                        <asp:TextBox ID="txtINVOICEAMOUNT_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%">徵信費收入
                                    </th>
                                    <td width="18%">
                                        <asp:TextBox ID="txtCREDITFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <th width="15%">
                                        <%-- 20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日 --%>
                                        <%--預計撥款日--%>
                                        <%-- 20150326 ADD BY SS ADAM REASON.增加撥款金額 --%>
                                        撥款金額
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPAYDATE_AR" custprop="010" CssClass="txt_readonly_right" runat="server"
                                            ReadOnly="true" Visible="false">
                                        </asp:TextBox>
                                        <%-- 20150326 ADD BY SS ADAM REASON.增加撥款金額 --%>
                                        <asp:TextBox ID="txtPAYAMT_AR" runat="server" CssClass="txt_readonly_right" Readonly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>墊款息
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtADVANCESINTEREST_AR" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                    <th>帳務管理收入
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMANAGERFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>執款成數
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpADVANCESPERCENT_AR" runat="server" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="false">
                                        </asp:DropDownList>
                                        %
                                    </td>
                                    <th>財務顧問收入
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtFINANCIALFEES_AR" Text="0" custprop="100" CssClass="txt_readonly_right"
                                            ReadOnly="true" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div class="div_title">AR明細 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                        <div class="div_table" style="overflow-x: scroll; height: 200px">
                            <table id="tblMLDCONTRACTARD" class="tb_Contact" style="width: 1600px;">
                                <tr>
                                    <th>項次
                                    </th>
                                    <th>形式
                                    </th>
                                    <th>發票人
                                    </th>
                                    <th>付款行庫
                                    </th>
                                    <th>帳號
                                    </th>
                                    <th>票據號碼
                                    </th>
                                    <th>買受人
                                    </th>
                                    <th>票據到期日
                                    </th>
                                    <th>墊款天數
                                    </th>
                                    <th>票面受讓金額
                                    </th>
                                    <th>墊款成數
                                    </th>
                                    <th>墊款金額
                                    </th>
                                    <th>應收墊款息
                                    </th>
                                    <th>尾款金額
                                    </th>
                                    <th>申戶背書
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCONTRACTARD" runat="server">
                                    <itemtemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpPAYTYPE_AR" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                                    Enabled="false">
                                                    <asp:ListItem>支票</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hidMLDCONTRACTARDID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDRAWER_AR" Text='<%# Eval("DRAWER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="120px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITBANK_AR" Text='<%# Eval("DEPOSITBANK")%>' runat="server"
                                                    CssClass="txt_readonly" ReadOnly="true" Width="240px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtACCOUNT_AR" Text='<%# Eval("ACCOUNT")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="150px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNO_AR" Text='<%# Eval("BILLNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="150px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBUYER_AR" Text='<%# Eval("BUYER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="120px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLEXPIRYDT_AR" Text='<%# Eval("BILLEXPIRYDT")%>' runat="server"
                                                    ReadOnly="true" CssClass="txt_readonly" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESDAYS_AR" runat="server" Text='<%# Eval("ADVANCESDAYS")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLAMT_AR" Text='<%# Eval("BILLAMT")%>' runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESPERCENT_AR" runat="server" Text='<%# Eval("ADVANCESPERCENT")%>'></asp:Label>
                                                <asp:TextBox ID="txtADVANCESPERCENT_AR" runat="server" Text='<%# Eval("ADVANCESPERCENT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labADVANCESAMT_AR" runat="server" Text='<%# Eval("ADVANCESAMT")%>'></asp:Label>
                                                <asp:TextBox ID="txtADVANCESAMT_AR" runat="server" Text='<%# Eval("ADVANCESAMT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labFINANCIALFEES_AR" runat="server" Text='<%# Eval("FINANCIALFEES")%>'></asp:Label>
                                                <asp:TextBox ID="txtFINANCIALFEES_AR" runat="server" Text='<%# Eval("FINANCIALFEES")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labFINALPAYAMT_AR" runat="server" Text='<%# Eval("FINALPAYAMT")%>'></asp:Label>
                                                <asp:TextBox ID="txtFINALPAYAMT_AR" runat="server" Text='<%# Eval("FINALPAYAMT")%>'
                                                    Style="display: none">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkENDORSEMENTFLG" runat="server" Enabled="false" />
                                                <asp:HiddenField ID="hidENDORSEMENTFLG" Value='<%# Eval("ENDORSEMENTFLG") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <br />
                        <div class="div_title">買受發票明細 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                        <div class="div_table" style="height: 200px">
                            <table id="tblMLDCONTRACTARBINV" class="tb_Contact" style="width: 600px;">
                                <tr>
                                    <th>項次
                                    </th>
                                    <th>買受人
                                    </th>
                                    <th>統編
                                    </th>
                                    <th>發票號碼
                                    </th>
                                    <th>發票日期
                                    </th>
                                    <th>發票金額
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptMLDCONTRACTARBINV" runat="server">
                                    <itemtemplate>
                                        <tr>
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBUYER_INV" Text='<%# Eval("BUYER")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hidMLDCONTRACTARBINVID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUNIMNO_INV" Text='<%# Eval("UNIMNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVNO_INV" Text='<%# Eval("INVNO")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="100px" onkeypress="OnlyNumDUCase(this);">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVDT_INV" Text='<%# Eval("INVDT")%>' runat="server" CssClass="txt_readonly"
                                                    ReadOnly="true" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtINVAMT_INV" Text='<%# Eval("INVAMT")%>' runat="server" CssClass="txt_readonly_right"
                                                    ReadOnly="true" Width="80px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                    <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                        <table cellpadding="1" cellspacing="1" class="tb_Info">
                            <tr>
                                <th width="14%">租金收入
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtRINCOME" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">期初成本
                                </th>
                                <td width="12%">
                                    <asp:TextBox ID="txtROPENINGCOST" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th width="12%">淨損益
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNETLOSS" runat="server" CssClass="txt_readonly_right" Text="0.0"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                            <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                            <tr>
                                <th>真實IRR
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRIRR" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>NPV成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST" runat="server" Text="0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                    %
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <th>真實IRR
                                </th>
                                <td></td>
                                <th>設備件NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV0" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                <th>設備件NPV成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST0" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                            <tr style="display: none;">
                                <th>資金成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRCAPITALCOST" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                        Text="7%">
                                    </asp:TextBox>
                                </td>
                                <%--Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2--%>
                                <th>融資件NPV
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPV2" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <th>融資件NPV成本
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRNPVRATECOST2" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <th style="display: none;">RECOVER TEST
                                </th>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtRRECOVERTEST" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <%--UPD BY VICKY 20150204 隱藏試算按鈕--%>
                                <td colspan="6" style="text-align: center; height: 30px;">
                                    <asp:Button ID="btnIRR_Click" runat="server" CssClass="btn_normal" Enabled="false"
                                        Text="試算" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--承作內容End --%>
                <%--標的物Begin --%>
                <div id="fraTab44" class="div_content" style="display: none">
                    <%--<asp:Button ID="Button311" runat="server" CssClass="btn_normal" Text="標的物複製" />
		  	<asp:Button ID="Button3211" runat="server" CssClass="btn_normal" Text="標的物匯入" />--%>
                    <div class="div_table" style="overflow-x: scroll; height: 200px">
                        <table class="tb_Contact" style="width: 1400px;">
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpTARGETTYPE" Enabled="false" onchange="drpTARGETTYPE_change(this);"
                                                DataTextField="MNAME1" DataValueField="MCODE" class="bg_normal" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                                        </td>
                                        <td width="15%">
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
                                            <asp:Label ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' Width="320px" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtTARGETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>'
                                                onblur="txtTARGETPRICE_onblur(this);" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <asp:CheckBox ID="chkAr1" runat="server" Enabled="false" Checked="true" />
                    AR案件無標的物&nbsp;&nbsp;&nbsp;
                    <%--Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.--%>
                    <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" />
                    銀行案件無標的物
                    <br />
                    <br />
                    設備存放地<br />
                    <div class="div_table" style="overflow-x: scroll; height: 200px">
                        <table class="tb_Contact" style="width: 1200px;">
                            <tr>
                                <th>項次
                                </th>
                                <th>存放地
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td width="350px">
                                            <asp:TextBox ID="txtSTOREDZIPCODE" runat="server" Width="24px" CssClass="txt_table"
                                                Text='<%# Eval("STOREDZIPCODE")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtSTOREDZIPCODES" runat="server" Width="120px" CssClass="txt_table"
                                                Text='<%# Eval("STOREDZIPCODES")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtSTOREDADDR" runat="server" CssClass="txt_table" Width="150px"
                                                Text='<%# Eval("STOREDADDR")%>'>
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
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
                                            <asp:Label ID="txtCONTACTFAXCODE" Width="20px" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>' />
                                            <asp:Label ID="txtCONTACTFAX" Text='<%# Eval("CONTACTFAX")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtCONTACTEMAIL" Text='<%# Eval("CONTACTEMAIL")%>' runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <asp:CheckBox ID="chkAr2" runat="server" Enabled="false" Checked="true" />
                    AR案件無標的物存放地<br />
                    <br />
                    <div class="div_title" style="margin-left: -10px;">
                        AR案件發票暨背書人
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="10%">發票人
                            </th>
                            <td>
                                <asp:TextBox ID="txtBILLNOTECUSTID" CssClass="txt_normal" Width="120px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtBILLNOTECUST" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>銀行/分行
                            </th>
                            <td>
                                <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" Width="427px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtDEPOSITBANK" Style="display: none" Width="427px" runat="server"></asp:TextBox>
                                <%--<asp:TextBox ID="TextBox106" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>帳號
                            </th>
                            <td>
                                <asp:TextBox ID="txtACCOUNT" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>背書人
                            </th>
                            <td>
                                <asp:TextBox ID="txtENDORSERID" CssClass="txt_normal" Width="120px" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtENDORSER" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--標的物End --%>
                <%--擔保條件Begin --%>
                <div id="fraTab55" class="div_content T_-130" style="display: none">
                    <br />
                    <%--20131114 LEO 新增擔保價值--%>
                    <%--20131205 進件擔保價值要設為不能維護，存檔只檢核撥款條件的擔保價值--%>
                    進件條件擔保價值
                    <asp:DropDownList ID="drpGuanValue" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <%--20140127 EDIT BY SEAN 將撥款條件擔保價值欄位向下移--%>
                    <%--        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                撥款條件擔保價值
            <asp:DropDownList ID="drpGuanValue2" runat="server">
                </asp:DropDownList>		--%>
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
                                <th>
                                    <%--20230523本票金額改保人擔保金額--%>
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
                                <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                <th>職業
                                </th>
                                <th>任職公司
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="drpGRTTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                class="bg_F5F8BE" runat="server" Width="80%">
                                                <asp:ListItem>法人</asp:ListItem>
                                                <asp:ListItem>個人</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' runat="server" CssClass="txt_table"
                                                Width="80" ReadOnly="true">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                Width="80" ReadOnly="true">
                                            </asp:TextBox>
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
                                                ReadOnly="true" runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <%--Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
                                        <td>
                                            <asp:TextBox ID="txtGRTBIRDT" Enabled="false" Text='<%# Eval("GRTBIRDT") %>' runat="server"
                                                Width="80px" CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);">
                                            </asp:TextBox>
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
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <input type="button" id="btnGRTRESIDENTZIP" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                            <asp:TextBox ID="txtGRTRESIDENTZIPNM" Enabled="false" Text='<%# Eval("GRTRESIDENTZIPNM") %>'
                                                runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTRESIDENTADDR" Enabled="false" Text='<%# Eval("GRTRESIDENTADDR") %>'
                                                runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');"
                                                MaxLength="100">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTZIP" Enabled="false" Text='<%# Eval("GRTZIP") %>' runat="server"
                                                Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                            <input type="button" id="btnGRTZIP" disabled="disabled" class="btn_normal" onclick="PostCodeClick(this);"
                                                onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                            <asp:TextBox ID="txtGRTZIPNM" Enabled="false" Text='<%# Eval("GRTZIPNM") %>' runat="server"
                                                Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTADDR" Enabled="false" Text='<%# Eval("GRTADDR") %>' runat="server"
                                                Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');"
                                                MaxLength="100">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGRTTELCODE" Enabled="false" Text='<%# Eval("GRTTELCODE") %>'
                                                runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);"
                                                onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTTEL" Enabled="false" Text='<%# Eval("GRTTEL") %>' runat="server"
                                                Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtGRTTELEXT" Enabled="false" Text='<%# Eval("GRTTELEXT") %>' runat="server"
                                                Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);">
                                            </asp:TextBox>
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
                                                runat="server" Width="200px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENAME" ReadOnly="true" Text='<%# Eval("MOVABLENAME")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                <asp:ListItem Value="1">是</asp:ListItem>
                                                <asp:ListItem Value="2">否</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEZIPCODE" ReadOnly="true" runat="server" Width="24px" CssClass="txt_table"
                                                Text='<%# Eval("MOVABLEZIPCODE")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtMOVABLEZIPCODES" ReadOnly="true" runat="server" Width="120px"
                                                CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'>
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtMOVABLEADDR" ReadOnly="true" runat="server" CssClass="txt_table"
                                                Width="150px" Text='<%# Eval("MOVABLEADDR")%>'>
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENO" ReadOnly="true" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEYEAR" ReadOnly="true" Text='<%# Eval("MOVABLEYEAR")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEBUYDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLENEWAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLEBUYAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLERESIDUALS" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMOVABLERESETPRICE" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                                <th>土地面積
                                </th>
                                <th>持分面積
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
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEOWNER" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEOWNERID" ReadOnly="true" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEGETDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLESECTOR" ReadOnly="true" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILD" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEHOLDER" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDNO" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM" ReadOnly="true" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA" ReadOnly="true" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                onblur="areacon(this)" runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIMMOVABLEBUILDAREA" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex +1 %>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHUMANRIGHTS" ReadOnly="true" Text='<%# Eval("HUMANRIGHTS") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtREGISTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSETPRICE" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                            runat="server" CssClass="txt_table_right">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCREDITOR" ReadOnly="true" Text='<%# Eval("CREDITOR") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("DEPOSITBANKS") %>'
                                            Width="120px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITNBR" ReadOnly="true" Text='<%# Eval("DEPOSITNBR") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITAMT" ReadOnly="true" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                            runat="server" CssClass="txt_table_right">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITSTARTDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITDUEDATE" ReadOnly="true" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table" Width="80px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" ReadOnly="true" Text='<%# Eval("BILLNOTEBANKS") %>'
                                            Width="100px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                            <asp:ListItem Value="1">本票</asp:ListItem>
                                            <asp:ListItem Value="2">支票</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTENBR" ReadOnly="true" Text='<%# Eval("BILLNOTENBR") %>'
                                            runat="server" CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtACCOUNT" ReadOnly="true" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                            CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTECUSTNAME" ReadOnly="true" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                            runat="server" CssClass="txt_table" Width="80px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEAMT" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                            runat="server" CssClass="txt_table_right" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTENOTE" ReadOnly="true" Text='<%# Eval("BILLNOTENOTE") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBILLNOTEBACKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table" Width="72px">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
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
                            <itemtemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKDATE" ReadOnly="true" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKNAME" ReadOnly="true" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKPROVIDER" ReadOnly="true" Text='<%# Eval("STOCKPROVIDER") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKUNIT" ReadOnly="true" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" ReadOnly="true" Text='<%# Eval("STOCKQUANTITY") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" ReadOnly="true" Text='<%# Eval("STOCKTOTAL") %>'
                                            runat="server" CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKBEGIN" ReadOnly="true" Text='<%# Eval("STOCKBEGIN") %>'
                                            runat="server" CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKEND" ReadOnly="true" Text='<%# Eval("STOCKEND") %>' runat="server"
                                            CssClass="txt_table" Width="60px">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                            <asp:ListItem Value="1">集保</asp:ListItem>
                                            <asp:ListItem Value="2">實體</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSTOCKNOTE" ReadOnly="true" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                            CssClass="txt_table">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </itemtemplate>
                        </asp:Repeater>
                    </table>
                    <br />
                    其他<br />
                    <asp:TextBox ID="txtOTHERCOND" ReadOnly="true" runat="server" CssClass="txt_normal"
                        Width="80%">
                    </asp:TextBox>
                    <%--20140127 EDIT BY SEAN 將撥款條件擔保價值欄位向下移--%>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    撥款條件擔保價值
                    <asp:DropDownList ID="drpGuanValue2" runat="server">
                    </asp:DropDownList>
                </div>
                <%--擔保條件End --%>
                <%--撥款申請Begin --%>
                <div id="fraTab66" class="div_content T_-120" style="display: none">
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="13%">案件起租日
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtPRENTSTDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="16%">客戶首期繳納日
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtCUSTFPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="13%">預計撥款日
                            </th>
                            <td width="13%">
                                <asp:TextBox ID="txtPAYDATE" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th width="12%">手續費收入
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>設備金額
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRTRANSCOST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>頭期款
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRFIRSTPAY" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>履約保證金
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <th>租購保證金
                            </th>
                            <td>
                                <asp:TextBox ID="txtRRPURCHASEMARGIN" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="div_title" style="margin-left: -10px;">
                        進項發票
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="2200px">
                            <tr>
                                <th>項次
                                </th>
                                <th>憑證號碼
                                </th>
                                <th>發票日期
                                </th>
                                <th>未稅金額
                                </th>
                                <th>稅額
                                </th>
                                <th>含稅金額
                                </th>
                                <th>抵履約保證金
                                </th>
                                <th>抵租購保證金
                                </th>
                                <th>抵頭期款
                                </th>
                                <th>業代自付額
                                </th>
                                <th>實撥金額
                                </th>
                                <th>履約保證金票據
                                </th>
                                <th>租購保證金票據
                                </th>
                                <th>頭期款票據
                                </th>
                                <th>供應商
                                </th>
                                <th>匯款項次
                                </th>
                                <th>匯款銀行
                                </th>
                                <th>分行
                                </th>
                                <th>戶名
                                </th>
                                <th>帳號
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCONTRACTINV" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCERTIFICATENO" Text='<%# Eval("CERTIFICATENO")%>' runat="server"
                                                Width="96px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtINVDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>'
                                                Width="80px" runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNOTAXAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOTAXAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("TAX").ToString()) %>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblANOUMTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                                                runat="server"></asp:Label>
                                            <asp:HiddenField ID="hidANOUMTTAX" Value='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString()) %>'
                                                runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERBONDUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHIREPURUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("HIREPURUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFIRSTPAYUSED" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYUSED").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtINVSALESPAY" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("INVSALESPAY").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACTUALLYAMOUNT" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPERBONDNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDNOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPURCHASENOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("PURCHASENOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFIRSTPAYNOTE" ReadOnly="true" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYNOTE").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUPPLIERS" Width="160px" runat="server" CssClass="txt_table"
                                                Text='<%# Eval("SUPPLIERS")%>'>
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hidSUPPLIER" Value='<%# Eval("SUPPLIER") %>' runat="server" />
                                            <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSUPSEQ" Text='<%# Eval("SUPSEQ")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBANKNM" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("BANKNM")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCOMPNM" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("COMPNM")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRV_NAME" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("RV_NAME")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRVACNT" runat="server" CssClass="txt_table" Width="132px" Text='<%# Eval("RVACNT")%>'></asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <br>
                    <br>
                    <div class="div_title" style="margin-left: -10px;">
                        進項折讓發票
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="80%">
                            <tr>
                                <th>項次
                                </th>
                                <th>折讓發票號碼
                                </th>
                                <th>折讓日
                                </th>
                                <th>折讓未稅金額
                                </th>
                                <th>折讓稅額
                                </th>
                                <th>折讓含稅金額
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDCONTRACTINVD" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                            <asp:HiddenField ID="hidDISCOUNTINVOICEID" Value='<%# Eval("DISCOUNTINVOICEID") %>'
                                                runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTINVNUM" Text='<%# Eval("DISCOUNTINVNUM")%>' runat="server"
                                                Width="96px" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DISCOUNTDATE").ToString()) %>'
                                                runat="server" CssClass="txt_table">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDISCOUNTAMOUNTTAX" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>'
                                                runat="server" CssClass="txt_table_right">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                    <div class="div_title" style="margin-left: -10px;">
                        指定付款他人
                    </div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        <table class="tb_Contact" width="1400px">
                            <tr>
                                <th>項次
                                </th>
                                <th>憑證號碼
                                </th>
                                <th>收款人
                                </th>
                                <th>匯款項次
                                </th>
                                <th>匯款銀行
                                </th>
                                <th>分行
                                </th>
                                <th>戶名
                                </th>
                                <th>帳號
                                </th>
                                <th>金額
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDASSPAYMF" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCERTNO" runat="server" Text='<%# Eval("CERTNO") %>'
                                                CssClass="txt_table" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPAYEE" runat="server" Text='<%# Eval("PAYEE") %>'
                                                CssClass="txt_table" Width="110px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                            <asp:TextBox ID="txtPAYEENM" runat="server" Text='<%# Eval("PAYEENM") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUPSEQ" runat="server" Text='<%# Eval("SUPSEQ") %>'
                                                CssClass="txt_table" Width="40px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTRANSBANK" runat="server" Text='<%# Eval("TRANSBANK") %>'
                                                CssClass="txt_table" Width="200px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSUBBANK" runat="server" Text='<%# Eval("SUBBANK") %>'
                                                CssClass="txt_table" Width="140px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACCNM" runat="server" Text='<%# Eval("ACCNM") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtACC" runat="server" Text='<%# Eval("ACC") %>'
                                                CssClass="txt_table" Width="160px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTRANSAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TRANSAMT").ToString()) %>'
                                                CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        預撥沖銷
                    </div>
                    <div class="div_table" style="overflow: auto; height: 120px">
                        前次沖銷
                        <asp:Button ID="btnPREPAY" runat="server" CssClass="btn_normal" Text="查詢" Enabled="false" />
                        <br />
                        本次沖銷
                        <br />
                        <table class="tb_Contact" width="100%">
                            <tr>
                                <th>項次
                                </th>
                                <th>預撥對象
                                </th>
                                <th>累計預撥
                                </th>
                                <th>本次沖銷
                                </th>
                                <th>剩餘預撥
                                </th>
                                <th>本次墊款息
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDPREPAYWOFF" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPREPAYOBJ" runat="server" Text='<%# Eval("PREPAYOBJ") %>'
                                                CssClass="txt_table" Width="160px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTOTALPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TOTALPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNOWPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOWPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLASTPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("LASTPREPAYAMT").ToString()) %>'
                                                CssClass="txt_table_right" Width="120px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADVANCESINTEREST" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("ADVANCESINTEREST").ToString()) %>'
                                                CssClass="txt_table_right" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        手續費收入
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                            <tr>
                                <th>項次
                                </th>
                                <th>身分
                                </th>
                                <th>統編
                                </th>
                                <th>對象
                                </th>
                                <th>手續費
                                </th>
                                <th>支付方式
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDFEEINCOME1" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCUSTTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                                CssClass="txt_table" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                runat="server" CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="div_title" style="margin-left: -10px;">
                        重車動保手續費收入
                    </div>
                    <div class="div_table" style="overflow: auto; height: 100px">
                        <table class="tb_Contact" width="90%">
                            <tr>
                                <th>項次
                                </th>
                                <th>身分
                                </th>
                                <th>統編
                                </th>
                                <th>對象
                                </th>
                                <th>手續費
                                </th>
                                <th>支付方式
                                </th>
                            </tr>
                            <asp:Repeater ID="rptMLDFEEINCOME2" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1 %>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCUSTTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                                CssClass="txt_table" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                            <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                value="&#8230;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                CssClass="txt_table" Width="180px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFEEAMOUNT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                runat="server" CssClass="txt_table_right" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpPAYTYPE" runat="server" Enabled="false">
                                                <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                                <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                </itemtemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
                    <div class="div_title" style="margin-left: -10px;">
                        抵設備款資料
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="20%">履約保證金抵設備款
                            </th>
                            <td width="12%">
                                <asp:TextBox ID="txtPERBONDUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="15%">履約保證金票據
                            </th>
                            <td width="12%">
                                <asp:TextBox ID="txtPERBONDNOTE" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="20%">租購保證金抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtPURCHASEUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>租購保證金票據
                            </th>
                            <td>
                                <asp:TextBox ID="txtPURCHASENOTE" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>頭期款抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtFIRSTPAYUSED" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>頭期款票據
                            </th>
                            <td>
                                <asp:TextBox ID="txtFIRSTPAYNOTE" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>業代自付額
                            </th>
                            <td>
                                <asp:TextBox ID="txtSALESPAY" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                            <th>手續費抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtFEEAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th>沖預撥抵設備款
                            </th>
                            <td>
                                <asp:TextBox ID="txtPREPAYWOFFAMT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
                        </tr>
                    </table>
                    <br />
                    <div class="div_title" style="margin-left: -10px;">
                        撥款資料
                    </div>
                    <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                        <tr>
                            <th width="18%">進項總額
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtDISCOUNTTOTAL" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="18%">進項稅額
                            </th>
                            <td width="15%">
                                <asp:TextBox ID="txtDISCOUNTTAX" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                            <th width="15%">實撥金額
                            </th>
                            <td>
                                <asp:TextBox ID="txtACTUALLYAMOUNT" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--撥款申請End --%>
            </div>
            <div class="btn_div">
                <asp:Button ID="btnSubmit" runat="server" Text="撥款核准" CssClass="btn_normal" OnClick="btnSubmit_Click"
                    OnClientClick="javascipt:return btnSubmit_Click(this);" />
                <!--Modify 20120601 By SS Gordon. Reason: 撥款退回改為撥款撤件.-->
                <asp:Button ID="btnRegect" runat="server" Text="撥款撤件" CssClass="btn_normal" OnClick="btnRegect_Click"
                    Visible="false" />
                <!--Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.-->
                <asp:Button ID="btnReturn" runat="server" Text="撥款退回" CssClass="btn_normal" OnClick="btnReturn_Click" />
                <!--Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕.-->
                <%--Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.--%>
                <%--<asp:Button ID="btnRecheck" runat="server" Text="關係人檢核" CssClass="btn_normal" OnClientClick="Recheck();return false;" />--%>
                <asp:Button ID="btnRecheck" runat="server" Text="關係人檢核列印" CssClass="btn_normal" OnClick="btnRecheck_Click" />
                <asp:TextBox ID="hdnPRINTKEY" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnINDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true"
                    Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnTRADEDT" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="hdnCREDITDT" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="SessUSERID" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:TextBox ID="SessDEPTNM" custprop="010" runat="server" CssClass="txt_readonly"
                    ReadOnly="true" Style="display: none">
                </asp:TextBox>
                <asp:HiddenField ID="hidCond" runat="server" Value="" />
                <asp:Button ID="btnCond" Style="display: none" runat="server" Text="" OnClick="btnCond_Click" />
            </div>
        </div>
    </form>
</body>
</html>
