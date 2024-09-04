<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3002																					
* 程式功能  : 撥款申請維護																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120224 By SS Steven. Reason: 存檔時不可再觸發其他控制項功能
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120529 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120606 By SS Gordon. Reason: 於ML3002撥款維護的「承作內容」，新增「變更緣由」、「相關附件」欄位
Modify 20120614 By SS Gordon. Reason: 加入「佣金」
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.
Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕
Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
Modify 20121017 By SS Gordon. Reason: AR案件發票暨背書人-發票人不檢核身分證字號.
Modify 20121121 By SS Steven. Reason: 進件確認檢核新增:承作型態為分期-附條買時，擔保條件的動產一定要有資料
Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕.
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
Modify 20130117 BY    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」
Modify 20130326 By SS Eric    Reason:新增保險異常欄位
Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
Modify 20130823 BY    SEAN.   Reason: 隱藏合約列印鈕 
20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
Modify 20131002 By SS Steven. Reason: 需判斷PRGID是否為ML3001A，如果是的話，頁籤承作內容改為預計承作內容，頁籤撥款資料改為預計撥款資料。
Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。
Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
Modify 20131002 By SS Steven. Reason: 區分PRGID為ML3001A以及ML3002的處理流程，最下方的按鈕，在PRGID為ML3001A以及ML3002則有對應的顯示方式
Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                                      2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                                      3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)
Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印
Modify 20131210 BY    SEAN    Reason: 1.修改輸入日期不可超過1年
                                      2.修正不動產項次取號問題
									  3.PRGID若是ML3001A則可開放修改動產設定金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
Modify 20150120 By SS Vicky   Reason: 隱藏案件內容頁籤中，右方的[付款時間]及[承作真實IRR]
Modify 20150121 By SS Vicky   Reason: 承作內容的頁籤中，依是否為AR件顯示不同內容
Modify 20150203 By SS Vicky   Reason: 承作內容的頁籤中，AR明細的付款行庫改為使用開窗
Modify 20150205 By SS Vicky   Reason: 案件內容,隱藏[建議墊息款],增加[建議墊款息]
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
20161125 ADD BY SS ADAM REASON.增加預撥沖銷
20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%)
20221031 調整「案件內容」、「標的物」位置，隱藏「進件資料」標籤
20221031 隱藏客戶資料內客戶性質、集團實際負責人、母公司名稱欄位，行業別改為下拉式選單
20221031 標的物隱藏AR案件無標的物、銀行案件無標的物
20221031 案件內容隱藏隱藏專案別、公司名稱、承作方式、動用情況、附追索權、銀行別、應收帳款案件
--%>

<%@ page language="C#" autoeventwireup="true" codefile="FrmML3002.aspx.cs" inherits="FrmML3002"
    enableeventvalidation="false" %>

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

    <%--Modify 20120224 By SS Steven. Reason: 移至ScriptManager下面，必須先觸發ScriptManager
      不然JS理會找不到SYS定義--%>
    <%--  <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3002.js' -->                   
  </script>--%>
</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
    <form id="form1" runat="server">
        <%--Modify 20120224 By SS Steven. Reason: 存檔時不可再觸發其他控制項功能 START--%>
        <div id="ctl00_pnlTITLE">
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3002.js' -->                   
        </script>

        <%--Modify 20130923 BY SS ADAM Reason.解除原本mark掉的情況，測試後似乎不影響功能 --%>
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
        <%--Modify 20120224 By SS Steven. Reason: 存檔時不可再觸發其他控制項功能 END--%>
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
                    <table class="divStatus" width="98%">
                        <tr>
                            <td width="25%">
                                <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_normal" OnClientClick="return CaseClick();" />
                                <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn_normal" OnClientClick="return MLMCONTRACTClick('U');" />
                                <asp:Button ID="btnSelect" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="return MLMCONTRACTClick('S');" />
                                <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
                                <asp:HiddenField ID="hidSelRowIndex" runat="server" Value="-1" />
                                <asp:HiddenField ID="hidOldData" runat="server" Value="" />
                                <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
                                <asp:HiddenField ID="hidSelRowTag" runat="server" Value="" />
                                <asp:HiddenField ID="hidCONTRACT" runat="server" />
                                <asp:HiddenField ID="hidDEPTID" runat="server" Value="" />
                                <asp:HiddenField ID="hdnCASESTATUS" runat="server" Value="" />
                                <asp:HiddenField ID="hidEMPLID" runat="server" Value="" />
                                <asp:Button ID="btnContractQue" Style="display: none" runat="server" Text="" OnClick="btnContractQue_Click" />
                                <asp:Button ID="btnCaseQue" Style="display: none" runat="server" Text="" OnClick="btnCaseQue_Click" />
                                <!--20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動-->
                                <asp:HiddenField ID="hidMAINTYPE" runat="server" Value="" />
                                <asp:HiddenField ID="hidSUBTYPE" runat="server" Value="" />
                                <asp:HiddenField ID="hidTARGETPRICE" runat="server" Value="" />
                                <asp:HiddenField ID="hidTARGETTYPE" runat="server" Value="" />
                                <asp:HiddenField ID="hidINSUREERR" runat="server" Value="" />
                            </td>
                            <td align="right" width="12%">
                                <b>合約編號</b>
                            </td>
                            <td width="17%">
                                <asp:TextBox ID="txtCNTRNO" Width="125px" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td align="right" width="15%">案件編號
                            </td>
                            <td width="17%">
                                <asp:TextBox ID="txtCASEID" Width="110px" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <%--20221031 改為隱藏--%>
                            <!--th>
              案件核准日
            </th-->
                            <td>
                                <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly"
                                    ReadOnly="true" Style="display: none">
                                </asp:TextBox>
                            </td>
                            <td>&nbsp;&nbsp;
                                <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div id="fraDispTypeInfo" class="frame_content div_Info H_1100">
                        <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu">
                            <label class="label_contain">
                                客戶資料</label>
                        </div>
                        <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu T_-24 L_125">
                            <label class="label_contain">
                                案件內容</label>
                        </div>
                        <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu T_-48 L_250">
                            <label class="label_contain">
                                <%--Modify 20131002 By SS Steven. Reason: 需判斷PRGID是否為ML3001A，如果是的話，頁籤承作內容改為預計承作內容，頁籤撥款資料改為預計撥款資料。--%>
                                <%--承作內容--%>
                                <asp:Label ID="lblTab33" runat="server" Text="承作內容"></asp:Label>
                            </label>
                        </div>
                        <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu T_-72 L_375">
                            <label class="label_contain">
                                標的物</label>
                        </div>
                        <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu T_-96 L_500">
                            <label class="label_contain">
                                擔保條件</label>
                        </div>
                        <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');"
                            class="sheet div_menu W_124 T_-120 L_625">
                            <label class="label_contain">
                                <%--Modify 20131002 By SS Steven. Reason: 需判斷PRGID是否為ML3001A，如果是的話，頁籤承作內容改為預計承作內容，頁籤撥款資料改為預計撥款資料。--%>
                                <%--撥款資料--%>
                                <asp:Label ID="lblTab66" runat="server" Text="撥款資料"></asp:Label>
                            </label>
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
                                        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 客戶性質--%>
                                        <asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1"
                                            DataValueField="MCODE" Visible="false">
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
                                        <%--&nbsp;&nbsp;&nbsp;&nbsp;集團實際負責人--%>
                                        <asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px"
                                            ReadOnly="true" Visible="false">
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
                                            Enabled="false">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--20221031 改為隱藏--%>
                                <%--<tr>
                                    <th>
                                        母公司統編
                                    </th>
                                    <td>--%>
                                <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="false"></asp:TextBox>
                                <%--</td>
                                    <th>
                                        母公司名稱
                                    </th>
                                    <td>--%>
                                <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                    Width="276px" Visible="false">
                                </asp:TextBox>
                                <%--</td>
                                </tr>--%>
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
                                        <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>傳真
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true">
                                        </asp:TextBox>
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
                                        <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <th>傳真
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtBUSINESSFAX" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>主要營業項目
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                            Width="80%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>行業別
                                    </th>
                                    <td colspan='3'>
                                        <!-- 20160323 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                                        <%-- 20221031 行業別改下拉選單 --%>
                                        <asp:DropDownList ID="DrpNDU" class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                            DataValueField="MCODE" Enabled="False">
                                            <asp:ListItem>請選擇</asp:ListItem>
                                        </asp:DropDownList>


                                        <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true" style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px" style="display: none"></asp:TextBox>
                                        <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" CssClass="btn_normal" Enabled="false" style="display: none" />
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
                                    <td colspan="3">
                                        <input type="button" id="btnC1" disabled="true" runat="server" class="btn_normal"
                                            onclick="ContactClick('1');" value="新增" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                            <asp:UpdatePanel ID="UpdatePanelContactM" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <table id="tblContactM" class="tb_Contact" width="100%">
                                                        <tr>
                                                            <th>刪除
                                                            </th>
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
                                                                        <asp:Button ID="btnMainDel" runat="server" Text="刪" OnClientClick="return ContactDelete('1',this)"
                                                                            Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                                                    </td>
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
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>案件聯絡人
                                    </th>
                                    <td colspan="3">
                                        <input type="button" id="btnC2" disabled="true" runat="server" class="btn_normal"
                                            onclick="ContactClick('2');" value="新增" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                            <asp:UpdatePanel ID="UpdatePanelContactC" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <table id="tblContactC" class="tb_Contact" width="100%">
                                                        <tr>
                                                            <th>刪除
                                                            </th>
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
                                                                        <asp:Button ID="btnMainDel" runat="server" Text="刪" OnClientClick="return ContactDelete('2',this)"
                                                                            Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
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
                                                                            runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="24px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
                                                                            runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAXCODE"
                                                                            runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAX" runat="server"
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
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>發票聯絡人
                                    </th>
                                    <td colspan="3">
                                        <input type="button" id="btnC3" disabled="true" runat="server" class="btn_normal"
                                            onclick="ContactClick('3');" value="新增" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                                            <asp:UpdatePanel ID="UpdatePanelContactI" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <table id="tblContactI" class="tb_Contact" width="150%;">
                                                        <tr>
                                                            <th>刪除
                                                            </th>
                                                            <th>姓名
                                                            </th>
                                                            <th>部門
                                                            </th>
                                                            <th>職稱
                                                            </th>
                                                            <th>發票寄送地
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
                                                        <asp:Repeater ID="rptContactI" runat="server">
                                                            <itemtemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnMainDel" runat="server" Text="刪" OnClientClick="return ContactDelete('3',this)"
                                                                            Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server"
                                                                            Text='<%# Eval("CONTACTNAME")%>' Width="60px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server"
                                                                            Text='<%# Eval("DEPTNAME")%>' Width="60px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server"
                                                                            Text='<%# Eval("CONTACTTITLE")%>' Width="60px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);"
                                                                            onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("INVZIPCODE")%>'>
                                                                        </asp:TextBox>
                                                                        <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onclick="PostCodeClick(this);"
                                                                            onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                                                        <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" onfocus="ObjMFocus(this,'txtINVZIPCODES','txtINVOICEADDR');"
                                                                            CssClass="txt_table" Text='<%# Eval("INVZIPCODES")%>'>
                                                                        </asp:TextBox>
                                                                        <asp:TextBox ID="txtINVOICEADDR" runat="server" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');"
                                                                            Width="150px" MaxLength="100" Text='<%# Eval("INVOICEADDR")%>'>
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
                                                                        <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE"
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
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--客戶資料End --%>
                        <%--案件內容Begin --%>
                        <div id="fraTab22" class="div_content padleft_0 T_-120" style="display: none">
                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                <tr>
                                    <%--Modify 20150310 By SS VICKY.   Reason:新增專案別--%>
                                    <%--20221031 改為隱藏--%>
                                    <%--<th>專案別
                                    </th>
                                    <td colspan="8">--%>
                                    <asp:DropDownList ID="drpPROJCD" runat="server" Enabled="False" style="display: none">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="01">一般</asp:ListItem>
                                        <asp:ListItem Value="02">重車</asp:ListItem>
                                        <asp:ListItem Value="03">事務機</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--</td>--%>
                                    <%--</tr>--%>
                                    <%--<tr>
                                    <th width="12%">公司名稱
                                    </th>
                                    <td width="12%">--%>
                                    <asp:DropDownList ID="drpCOMPID" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                        Enabled="false" style="display: none">
                                        <asp:ListItem>和潤</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--</td>--%>
                                    <%--Modify 20120717 By SS Gordon. Reason: 新增承作方式.--%>
                                    <%--<th width="12%">承作方式
                                    </th>--%>
                                    <%--<td width="12%">--%>
                                    <asp:DropDownList ID="drpSOURCETYPE" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                        Enabled="false" style="display: none">
                                    </asp:DropDownList>
                                    <%--</td>--%>
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

                                    <th>承作對象<!--20191119 ADD BY SS ADAM REASON.案件來源=>承作對象 -->
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE"
                                            runat="server" Enabled="false">
                                            <asp:ListItem>長租CR</asp:ListItem>
                                            <asp:ListItem>設備CR</asp:ListItem>
                                            <asp:ListItem>供應商介紹</asp:ListItem>
                                            <asp:ListItem>客戶來電</asp:ListItem>
                                            <asp:ListItem>同業介紹</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th>案件產品別
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpPRODCD" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--20221031 改為隱藏--%>
                                <%--<tr>
                                    <th>動用情形
                                    </th>
                                    <td>--%>
                                <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false" style="display: none">
                                    <asp:ListItem>單筆動用</asp:ListItem>
                                    <asp:ListItem>多筆動用</asp:ListItem>
                                </asp:DropDownList>
                                <%--</td>
                                    <td>--%>
                                <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false" style="display: none">
                                    <asp:ListItem>循環</asp:ListItem>
                                    <asp:ListItem>不循環</asp:ListItem>
                                </asp:DropDownList>
                                <%--</td>
                                    <th>代印店
                                    </th>
                                    <td>--%>
                                <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE"
                                    runat="server" Enabled="false" style="display: none">
                                    <asp:ListItem Value="">請選擇</asp:ListItem>
                                    <asp:ListItem Value="Y">是</asp:ListItem>
                                    <asp:ListItem Value="N">否</asp:ListItem>
                                </asp:DropDownList>
                                <%--</td>--%>
                                <%--Modify 20120717 By SS Gordon. Reason: 新增銀行別.--%>
                                <%--20221031 改為隱藏--%>
                                <%--  <th>銀行別
                                    </th>
                                    <td colspan="3">--%>
                                <asp:DropDownList ID="drpBANKCD" runat="server" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false" style="display: none">
                                </asp:DropDownList>
                                <%--</td>
                                </tr>--%>
                                <tr>
                                    <%--Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單--%>
                                    <%--<th>附追索權
                                    </th>--%>
                                    <%--<td colspan="5">--%>
                                    <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <asp:DropDownList ID="drpRECOURSE" runat="server" style="display: none">
                                                <asp:ListItem Value="">請選擇</asp:ListItem>
                                                <asp:ListItem Value="Y">是</asp:ListItem>
                                                <asp:ListItem Value="N">否</asp:ListItem>
                                            </asp:DropDownList>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                    <%--</td>--%>
                                </tr>
                                <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                                <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 END-->
                            </table>
                            <div>
                                <div>
                                    <table class="tb_Info" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td colspan="5">
                                                <asp:RadioButton ID="rdoMLDCASEINST" runat="server" Enabled="false" />
                                                分期、租賃案件
                                            </td>
                                            <!--Modify 20130326 By SS Eric    Reason:新增保險異常欄位-->
                                            <td colspan="1">
                                                <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險異常事件-->
                                                <asp:CheckBox ID="txtNOINSURANCEFLG" Enabled="false" runat="server" OnCheckedChanged="txtNOINSURANCEFLG_CheckedChanged"
                                                    AutoPostBack="true" />
                                                保險異常
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
                                            <th width="24%">
                                                <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險費按鈕-->
                                                <asp:Button ID="btINSURANCE" CssClass="btn_normal" runat="server" Text="..." OnClick="btINSURANCE_Click"
                                                    Enabled="false" />
                                                保險費
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
                                <%--20221031 改為隱藏--%>
                                <%--<div class="right_div" style="height: 265px;">
                                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                                        <tr>
                                            <td colspan="2">--%>
                                <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" width="0px" Height="0px" />
                                <%--應收帳款案件--%>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>申請額度
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtAPLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>徵信費
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtCREDITFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>帳務管理費
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtMANAGERFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>財務顧問費
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtFINANCIALFEES" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>--%>
                                <!--Modify 20120604 By SS Gordon. Reason: AR新增履約保證金-->
                                <%--<tr>
                                            <th>履約保證金
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtARPERBOND" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>成數
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtPERCENTAGE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%--%
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>帳款期限
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%--月
                                            </td>
                                        </tr>
                                        <tr style="display: none">--%>
                                <%--UPD BY VICKY 20150120 隱藏付款時間--%>
                                <%--<th>付款時間
                                            </th>
                                            <td>--%>
                                <asp:DropDownList ID="drpPAYTIMEA" custprop="100" DataTextField="MNAME1" DataValueField="MCODE"
                                    Enabled="false" runat="server" Width="80%" style="display: none">
                                    <asp:ListItem>期初付</asp:ListItem>
                                    <asp:ListItem>期末付</asp:ListItem>
                                </asp:DropDownList>
                                <%--</td>
                                        </tr>
                                        <tr>
                                            <th>單一買方限額
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtBUYERLIMIT" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" Text="" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr style="display: none">--%>
                                <%--UPD BY VICKY 20150120 承作真實IRR--%>
                                <%--<th>承作真實IRR
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtARIRR" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%--</td>
                                        </tr>
                                        <tr>--%>
                                <%--UPD BY VICKY 20150205 建議墊款息--%>
                                <%--<th>建議墊款息
                                            </th>
                                            <td>--%>
                                <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" runat="server" CssClass="txt_readonly_right"
                                    ReadOnly="true" style="display: none">
                                </asp:TextBox>
                                <%-- %
                                            </td>
                                        </tr>
                                    </table>--%>
                                <%--</div>--%>
                            </div>
                            <div style="clear: both;">
                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                    <tr>
                                        <th>付款方式
                                        </th>
                                        <td colspan="2">
                                            <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" runat="server"
                                                Enabled="false">
                                                <asp:ListItem>匯款</asp:ListItem>
                                                <asp:ListItem>支票</asp:ListItem>
                                                <asp:ListItem>套票</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th>選定專案
                                        </th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="drpPROJECT" DataTextField="PRONAME" DataValueField="PROJID" runat="server" OnSelectedIndexChanged="drpPROJECT_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="hidPROJECT" DataTextField="PROJID" DataValueField="DISCAMT" runat="server" AutoPostBack="true" Style="display: none">
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:HiddenField ID="hidPROJECT" runat="server" Value="0" />--%>
                                            <asp:Button ID="btnPROJECT" runat="server" CssClass="btn_normal" Text="搜尋" OnClick="btnPROJECT_Click" />
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
                                        <!--Modify 20130117 By    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」-->
                                        <th>備註
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtEXPIREPROCDESC" runat="server" CssClass="txt_readonly" ReadOnly="true"
                                                Style="width: 98%">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <%--Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                    <tr style="display: none;">
                                        <th>IRR
                                        </th>
                                        <td></td>
                                        <th>設備件NPV
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPV0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <th>設備件NPV成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST0" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <%--Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2--%>
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
                                        <th>融資件NPV成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST2" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0--%>
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
                                        <%--<th>NPV成本
                                        </th>--%>
                                        <td>
                                            <asp:TextBox ID="txtNPVRATECOST" custprop="001" runat="server" CssClass="txt_readonly_right"
                                                ReadOnly="true" style="display: none;">
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
                                        <td width="15%">
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
                                <%--UPD BY VICKY 20150120 非AR件的承作內容--%>
                                <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                                    <asp:UpdatePanel ID="UpdatePanelINSURE" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th width="14%">受讓/發票金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRTRANSCOST" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalRACTUSLLOANS(this);" custprop="100"
                                                            CssClass="txt_must_right" runat="server" Style="disabled: disabled;">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th>手續費收入
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRFEE" Text="0" onkeypress="OnlyNum(this);" MaxLength="9" onfocus="MoneyFocus(this)"
                                                            onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <!--Modify 20120529 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                                                    <th>作業費用<br />
                                                        (有發票)
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtROTHERFEES" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <!--Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                                                    <th>作業費用<br />
                                                        (無發票)
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtROTHERFEESNOTAX" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th width="14%">頭期款
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRFIRSTPAY" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalRACTUSLLOANS(this);" custprop="100"
                                                            CssClass="txt_must_right" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th width="12%">
                                                        <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險費按鈕-->
                                                        <asp:Button ID="btINSURANCE2" CssClass="btn_normal" runat="server" Text="..." OnClick="btINSURANCE2_Click" />
                                                        保險金
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="txtRINSURANCE" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server" Enabled="false">
                                                        </asp:TextBox>
                                                    </td>
                                                    <!--Modify 20130326 By SS Eric    Reason:新增保險異常欄位-->
                                                    <th width="12%">
                                                        <asp:CheckBox ID="txtRNOINSURANCEFLG" runat="server" OnCheckedChanged="txtNOINSURANCEFLG_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        保險異常
                                                    </th>
                                                    <td></td>
                                                    <th width="12%"></th>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <th>租購保證金
                                                    </th>
                                                    <td width="12%">
                                                        <asp:TextBox ID="txtRPURCHASEMARGIN" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalRACTUSLLOANS(this);" custprop="100"
                                                            runat="server" CssClass="txt_must_right">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th>殘值
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRRESIDUALS" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th>徵信費
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRCREDITFEES" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th></th>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <th>履約保證金
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRPERBOND" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalRRPERBOND();" custprop="100"
                                                            runat="server" CssClass="txt_must_right">
                                                        </asp:TextBox>
                                                    </td>
                                                    <!--Modify 20120614 By SS Gordon. Reason: 加入「佣金」-->
                                                    <th>佣金
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRCOMMISSION" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th>帳務管理費
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRMANAGERFEES" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th></th>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <th>實貸金額
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRACTUSLLOANS" Text="0" MaxLength="9" ReadOnly="true" custprop="100"
                                                            CssClass="txt_normal_right" runat="server">
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="hidRACTUSLLOANS" Value='0' runat="server" />
                                                    </td>
                                                    <th></th>
                                                    <td></td>
                                                    <th>財務顧問費
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRFINANCIALFEES" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th></th>
                                                    <td></td>
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
                                                    <td colspan="4">存借款<asp:TextBox ID="txtDEPOSITLOANSAMOUNT" Text="0" onkeypress="OnlyNum(this);" custprop="100"
                                                        MaxLength="9" onfocus="MoneyFocus(this)" onblur="OnlyNumBlur(this);MoneyBlur(this);"
                                                        CssClass="txt_normal_right" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="8">供應商
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
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                                        <tr>
                                            <th>承作月數
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRCONTRACTMONTH" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" CssClass="txt_must_right"
                                                    runat="server">
                                                </asp:TextBox>
                                            </td>
                                            <th>幾月一付
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRPAYMONTH" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" CssClass="txt_must_right"
                                                    runat="server">
                                                </asp:TextBox>
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
                                            <td width="12%">- 第<asp:TextBox ID="txtRENDPAY1" runat="server" onkeypress="OnlyNum(this);" MaxLength="3"
                                                oonblur="checkPayE(this,'');" CssClass="txt_must_right" Width="24px"></asp:TextBox>
                                                期
                                            </td>
                                            <td width="13%">期付款(未稅)
                                            </td>
                                            <td width="12%">
                                                <asp:TextBox ID="txtRPRINCIPAL1" onkeypress="OnlyNum(this);" custprop="100" onfocus="MoneyFocus(this)"
                                                    onblur="AddTax(this,'txtRPRINCIPALTAX1');MoneyBlur(this);MoneyNull(this,'txtRENDPAY1');"
                                                    MaxLength="9" runat="server" CssClass="txt_must_right">
                                                </asp:TextBox>
                                            </td>
                                            <td width="13%">期付款(含稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPALTAX1" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MinTax(this,'txtRPRINCIPAL1');MoneyBlur(this);MoneyNull(this,'txtRENDPAY1');"
                                                    MaxLength="9" runat="server" custprop="100" CssClass="txt_must_right">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>第
                                                <asp:TextBox ID="txtRSTARTPAY2" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtRENDPAY1','txtRENDPAY2');"
                                                    MaxLength="3" runat="server" CssClass="txt_normal_right" Width="24px">
                                                </asp:TextBox>
                                                期
                                            </td>
                                            <td>- 第<asp:TextBox ID="txtRENDPAY2" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtRSTARTPAY2');"
                                                MaxLength="3" runat="server" CssClass="txt_normal_right" Width="24px"></asp:TextBox>
                                                期
                                            </td>
                                            <td>期付款(未稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPAL2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="AddTax(this,'txtRPRINCIPALTAX2');MoneyBlur(this);MoneyNull(this,'txtRENDPAY2');"
                                                    MaxLength="9" custprop="100" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>期付款(含稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPALTAX2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MinTax(this,'txtRPRINCIPAL2');MoneyBlur(this);MoneyNull(this,'txtRENDPAY2');"
                                                    MaxLength="9" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>第
                                                <asp:TextBox ID="txtRSTARTPAY3" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtRENDPAY2','txtRENDPAY3');"
                                                    MaxLength="3" runat="server" CssClass="txt_normal_right" Width="24px">
                                                </asp:TextBox>
                                                期
                                            </td>
                                            <td>- 第<asp:TextBox ID="txtRENDPAY3" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtRSTARTPAY3');"
                                                MaxLength="3" runat="server" CssClass="txt_normal_right" Width="24px"></asp:TextBox>
                                                期
                                            </td>
                                            <td>期付款(未稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPAL3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="AddTax(this,'txtRPRINCIPALTAX3');MoneyBlur(this);MoneyNull(this,'txtRENDPAY3');"
                                                    MaxLength="9" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>期付款(含稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPALTAX3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MinTax(this,'txtRPRINCIPAL3');MoneyBlur(this);MoneyNull(this,'txtRENDPAY3');"
                                                    MaxLength="9" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>第
                                                <asp:TextBox ID="txtRSTARTPAY4" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtRENDPAY3','txtRENDPAY4');"
                                                    MaxLength="3" runat="server" CssClass="txt_normal_right" Width="24px">
                                                </asp:TextBox>
                                                期
                                            </td>
                                            <td>- 第<asp:TextBox ID="txtRENDPAY4" onkeypress="OnlyNum(this);" MaxLength="3" onblur="checkPayE(this,'txtRSTARTPAY4');"
                                                runat="server" CssClass="txt_normal_right" Width="24px"></asp:TextBox>
                                                期
                                            </td>
                                            <td>期付款(未稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPAL4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="AddTax(this,'txtRPRINCIPALTAX4');MoneyBlur(this);MoneyNull(this,'txtRENDPAY4');"
                                                    MaxLength="9" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>期付款(含稅)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRPRINCIPALTAX4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                    onblur="MinTax(this,'txtRPRINCIPAL4');MoneyBlur(this);MoneyNull(this,'txtRENDPAY4');"
                                                    MaxLength="9" runat="server" CssClass="txt_normal_right">
                                                </asp:TextBox>
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
                                                <asp:TextBox ID="txtRPATDAYS" MaxLength="4" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);"
                                                    runat="server" Text="0" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>付供應商天數
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRSUPPILERDAYS" MaxLength="4" onkeypress="OnlyNumAndMinus(this);"
                                                    onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" runat="server"
                                                    Text="0" CssClass="txt_normal_right">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!--Modify 20120606 By SS Gordon. Reason: 於撥款維護的「承作內容」，新增「變更緣由」、「相關附件」欄位-->
                                <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                                    <table cellpadding="1" cellspacing="1" class="tb_Info">
                                        <tr>
                                            <th width="14%">變更緣由
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtCHANGREASON" MaxLength="100" onblur="CheckMLength(this,100,'變更緣由');"
                                                    runat="server" CssClass="txt_normal" Style="width: 98%">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>相關附件
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtRELATTACHMENT" MaxLength="100" onblur="CheckMLength(this,100,'相關附件');"
                                                    runat="server" CssClass="txt_normal" Style="width: 98%">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="divMainTypeB" runat="server" style="display: none">
                                <%--UPD BY VICKY 20150120 AR件的承作內容--%>
                                <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                                    <asp:UpdatePanel ID="UpdatePanelContract_AR" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table cellpadding="1" cellspacing="1" class="tb_Info">
                                                <tr>
                                                    <th width="15%">總受讓金額
                                                    </th>
                                                    <td width="18%">
                                                        <asp:TextBox ID="txtINVOICEAMOUNT_AR" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th width="15%">徵信費收入
                                                    </th>
                                                    <td width="18%">
                                                        <asp:TextBox ID="txtCREDITFEES_AR" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <th width="15%">
                                                        <%-- 20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日 --%>
                                                        <!--預計撥款日-->
                                                        <%-- 20150326 ADD BY SS ADAM REASON.增加撥款金額 --%>
                                                        撥款金額
                                                    </th>
                                                    <td>
                                                        <%-- 20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日 --%>
                                                        <asp:TextBox ID="txtPAYDATE_AR" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                            onblur="dateBlur(this);CalMLDCONTRACTARD();" custprop="010" CssClass="txt_must"
                                                            runat="server" Visible="false">
                                                        </asp:TextBox>
                                                        <%-- 20150326 ADD BY SS ADAM REASON.增加撥款金額 --%>
                                                        <asp:TextBox ID="txtPAYAMT_AR" runat="server" CssClass="txt_readonly_right" Readonly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>墊款息
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtADVANCESINTEREST_AR" onkeypress="OnlyNumAndSpot(this);" runat="server"
                                                            MaxLength="8" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalMLDCONTRACTARD();"
                                                            CssClass="txt_must_right">
                                                        </asp:TextBox>
                                                        %
                                                    </td>
                                                    <th>帳務管理收入
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtMANAGERFEES_AR" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>墊款成數
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="drpADVANCESPERCENT_AR" runat="server" DataTextField="MNAME1"
                                                            DataValueField="MCODE" onblur="CalMLDCONTRACTARD();">
                                                        </asp:DropDownList>
                                                        %
                                                    </td>
                                                    <th>財務顧問收入
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtFINANCIALFEES_AR" Text="0" onkeypress="OnlyNum(this);" MaxLength="9"
                                                            onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" custprop="100" CssClass="txt_must_right"
                                                            runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div class="div_title">
                                    AR明細 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8 &nbsp;&nbsp;刪除請按F9
                                    ]</span>
                                </div>
                                <div class="div_table" style="overflow-x: scroll; height: 200px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDCONTRACTARD" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDCONTRACTARD" class="tb_Contact" style="width: 1600px;">
                                                <tr onclick="changeTag('rptMLDCONTRACTARD')">
                                                    <th>項次
                                                    </th>
                                                    <th></th>
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
                                                <asp:Repeater ID="rptMLDCONTRACTARD" runat="server" OnItemCommand="MLDCONTRACTARD_ItemCommand">
                                                    <itemtemplate>
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCONTRACTARD','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnARDCopy" runat="server" Text="複製" CommandName="CopyRowData1" CommandArgument='<%# Container.ItemIndex  %>' />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpPAYTYPE_AR" runat="server" DataTextField="MNAME1" DataValueField="MCODE">
                                                                    <asp:ListItem>支票</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hidMLDCONTRACTARDID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDRAWER_AR" MaxLength="20" onblur="CheckMLength(this,'20');" Text='<%# Eval("DRAWER")%>'
                                                                    runat="server" CssClass="txt_normal" Width="120px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--UPD BY VICKY 20150203 改為開窗--%>
                                                                <asp:TextBox ID="txtDEPOSITBANK_AR" onfocus="this.parentNode.childNodes[2].focus()"
                                                                    Text='<%# Eval("DEPOSITBANK")%>' runat="server" CssClass="txt_normal" Width="240px">
                                                                </asp:TextBox>
                                                                <input type="button" id="Button9" class="btn_normal" onclick="BankClick_AR(this);"
                                                                    style="width: 25px; padding: 2px;" value="&#8230;" />
                                                                <asp:TextBox ID="txtDEPOSITID_AR" Text='<%# Eval("DEPOSITID")%>' runat="server" Style="display: none"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtACCOUNT_AR" MaxLength="20" onblur="CheckMLength(this,'20');"
                                                                    Text='<%# Eval("ACCOUNT")%>' runat="server" CssClass="txt_normal" onkeypress="OnlyNum(this);"
                                                                    Width="150px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBILLNO_AR" MaxLength="20" onblur="CheckMLength(this,'20');" Text='<%# Eval("BILLNO")%>'
                                                                    runat="server" CssClass="txt_normal" onkeypress="OnlyNumDUCase(this);" Width="150px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBUYER_AR" MaxLength="20" onblur="CheckMLength(this,'20');" Text='<%# Eval("BUYER")%>'
                                                                    runat="server" CssClass="txt_normal" Width="120px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBILLEXPIRYDT_AR" MaxLength="10" Text='<%# Eval("BILLEXPIRYDT")%>'
                                                                    runat="server" CssClass="txt_must" Width="80px" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                                    onblur="CheckMLength(this,'10');dateBlur(this);txtBILLEXPIRYDT_AR_onblur(this);CalMLDCONTRACTARD();">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="labADVANCESDAYS_AR" runat="server" Text='<%# Eval("ADVANCESDAYS")%>'></asp:Label>
                                                                <asp:TextBox ID="txtADVANCESDAYS_AR" runat="server" Text='<%# Eval("ADVANCESDAYS")%>'
                                                                    Style="display: none">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBILLAMT_AR" MaxLength="9" onblur="CheckMLength(this,'9');MoneyBlur(this);CalMLDCONTRACTARD();"
                                                                    Text='<%# Eval("BILLAMT")%>' runat="server" CssClass="txt_must_right" onkeypress="OnlyNum(this);"
                                                                    Width="100px" onfocus="MoneyFocus(this)">
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
                                                                <asp:CheckBox ID="chkENDORSEMENTFLG" runat="server" />
                                                                <asp:HiddenField ID="hidENDORSEMENTFLG" Value='<%# Eval("ENDORSEMENTFLG") %>' runat="server" />
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div class="div_title">
                                    買受發票明細 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8 &nbsp;&nbsp;刪除請按F9
                                    ]</span>
                                </div>
                                <div class="div_table" style="overflow-x: scroll; height: 200px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDCONTRACTARBINV" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDCONTRACTARBINV" class="tb_Contact" style="width: 600px;">
                                                <tr onclick="changeTag('rptMLDCONTRACTARBINV')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCONTRACTARBINV','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBUYER_INV" MaxLength="20" onblur="CheckMLength(this,'20');" Text='<%# Eval("BUYER")%>'
                                                                    runat="server" CssClass="txt_must" Width="100px">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hidMLDCONTRACTARBINVID" Value='<%# Eval("SEQNO") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUNIMNO_INV" MaxLength="10" onblur="CheckMLength(this,'10');"
                                                                    Text='<%# Eval("UNIMNO")%>' runat="server" CssClass="txt_must" Width="100px"
                                                                    onkeypress="OnlyNumDUCase(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVNO_INV" MaxLength="10" onblur="CheckMLength(this,'10');" Text='<%# Eval("INVNO")%>'
                                                                    runat="server" CssClass="txt_must" Width="100px" onkeypress="OnlyNumDUCase(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVDT_INV" MaxLength="10" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                                    onblur="CheckMLength(this,'10');dateBlur(this);" Text='<%# Eval("INVDT")%>' runat="server"
                                                                    CssClass="txt_must" Width="80px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVAMT_INV" MaxLength="18" onblur="CheckMLength(this,'18');MoneyBlur(this);"
                                                                    Text='<%# Eval("INVAMT")%>' runat="server" CssClass="txt_must_right" Width="80px"
                                                                    onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <br />
                            <div style="width: 97%; border: 1px solid #9FA1AD; margin-top: 10px;">
                                <table cellpadding="1" cellspacing="1" class="tb_Info">
                                    <tr style="display: none;">
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
                                    <tr style="display: none;">
                                        <th>真實IRR
                                        </th>
                                        <td></td>
                                        <th>設備件NPV
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPV0" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPV0" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                                        <th>設備件NPV成本
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPVRATECOST0" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPVRATECOST0" runat="server" Text="0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                    %
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                                    <tr style="display: none;">
                                        <th>資金成本
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtRCAPITALCOST" runat="server" CssClass="txt_readonly_right" ReadOnly="true"
                                                Text="7">
                                            </asp:TextBox>
                                            %
                                        </td>
                                        <%--Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2--%>
                                        <th>融資件NPV
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPV2" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPV2" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <th>融資件NPV成本
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPVRATECOST2" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPVRATECOST2" runat="server" Text="0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                    %
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--Modify 20161210 By SEAN. Reason: 新增NPV0與NPV利率成本0--%>
                                        <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                                        <th>真實IRR
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelIRR" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRIRR" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <th>NPV
                                        </th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPV" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPV" runat="server" Text="0.0" CssClass="txt_readonly_right"
                                                        ReadOnly="true">
                                                    </asp:TextBox>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <%--<th>NPV成本
                                        </th>--%>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanelNPVRATECOST" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
                                                    <asp:TextBox ID="txtRNPVRATECOST" runat="server" Text="0" CssClass="txt_readonly_right"
                                                        ReadOnly="true" style="display: none;">
                                                    </asp:TextBox>
                                                    <%--%--%>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr runat="SERVER" id="trRACTUSLLOANS" style="display: none;">
                                        <%--UPD BY VICKY 20150123 加入實際撥款額--%>
                                        <th>實際撥款額</th>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtRACTUSLLOANS_AR" custprop="001" runat="server" CssClass="txt_readonly_right"
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
                                    <tr>
                                        <td colspan="6" style="text-align: center; height: 30px;">
                                            <asp:Button ID="btnIRR" runat="server" CssClass="btn_normal" Enabled="false" Text="試算"
                                                OnClick="btnIRR_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <%--承作內容End --%>
                        <%--標的物Begin --%>
                        <div id="fraTab44" class="div_content" style="display: none">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8 &nbsp;&nbsp;刪除請按F9
                                ]</span>
                            <div class="div_table" style="overflow-x: scroll; height: 200px">
                                <asp:UpdatePanel ID="UpdatePanelMLDCASETARGET" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <table id="tblMLDCASETARGET" class="tb_Contact" style="width: 1600px;">
                                            <tr onclick="changeTag('rptMLDCASETARGET')">
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
                                                <%--Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)--%>
                                                <th>製造廠商
                                                </th>
                                                <th>廠牌
                                                </th>
                                                <th>單位
                                                </th>
                                                <th>數量
                                                </th>
                                                <th width="270px">供應商
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
                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                                                        <td>
                                                            <%# Container.ItemIndex +1 %>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpTARGETTYPE" onchange="drpTARGETTYPE_change(this);" DataTextField="MNAME1"
                                                                DataValueField="MCODE" class="bg_F5F8BE" runat="server" CssClass="bg_readonly" Enabled="false">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETNAME" onblur="CheckMLength(this,'100');" MaxLength="100"
                                                                Width="150px" Text='<%# Eval("TARGETNAME")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpTARGETSTATUS" DataTextField="MNAME1" DataValueField="MCODE"
                                                                runat="server" CssClass="bg_readonly" Enabled="false">
                                                                <asp:ListItem>新機</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETMODELNO" onblur="CheckMLength(this,'50');" MaxLength="50"
                                                                Width="100px" Text='<%# Eval("TARGETMODELNO")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETMACHINENO" onblur="CheckMLength(this,'20');" MaxLength="20"
                                                                Width="100px" Text='<%# Eval("TARGETMACHINENO")%>' runat="server" CssClass="txt_table" >
                                                            </asp:TextBox>
                                                        </td>
                                                        <%--Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)--%>
                                                        <td>
                                                            <asp:TextBox ID="txtMANUFACTURER" Text='<%# Eval("MANUFACTURER")%>' runat="server"
                                                                CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETBRAND" Text='<%# Eval("TARGETBRAND")%>' runat="server"
                                                                CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETUNIT" Text='<%# Eval("TARGETUNIT")%>' runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETCOUNT" Text='<%# Eval("TARGETCOUNT")%>' runat="server"
                                                                CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSUPPLIERID" Text='<%# Eval("SUPPLIERID")%>' onkeypress="OnlyNumDUCase(this);"
                                                                onblur="SUPPLIERID_onblur(this);" MaxLength="10" runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                            <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnSUPPLIERID','txtTARGETPRICE');"
                                                                OnClientClick="return SupplierClick(this);" Style="padding: 2px; width: 25px;"
                                                                runat="server" Text="&#8230;" Enabled="false" />
                                                            <asp:TextBox ID="txtSUPPLIERIDS" onfocus="ObjMFocus(this,'txtSUPPLIERIDS','txtTARGETPRICE');"
                                                                Width="160px" Text='<%# Eval("SUPPLIERIDS")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETPRICE" onkeypress="OnlyNum(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>'
                                                                onfocus="MoneyFocus(this)" onblur="txtTARGETPRICE_onblur(this);" runat="server"
                                                                CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTARGETPRICENOTAX" onkeypress="OnlyNum(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>'
                                                                onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                            <!--
                            <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>' onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server"></asp:Label>
                            -->
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:CheckBox ID="chkAr1" Enabled="false" runat="server" style="display: none" />
                            <%--AR案件無標的物--%>&nbsp;&nbsp;&nbsp;
                            <%--Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.--%>
                            <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" style="display: none" />
                            <%--銀行案件無標的物--%>
                            <br />
                            <br />
                            設備存放地 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8 &nbsp;&nbsp;刪除請按F9
                                ]</span><br />
                            <div class="div_table" style="overflow-x: scroll; height: 200px">
                                <asp:UpdatePanel ID="UpdatePanelMLDCASETARGETSTR" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <table class="tb_Contact" style="width: 1200px;">
                                            <tr onclick="changeTag('rptMLDCASETARGET')">
                                                <th>項次
                                                </th>
                                                <th>存放地
                                                </th>
                                                <th>聯絡人
                                                </th>
                                                <th></th>
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
                                                <th>標的物項次
                                                </th>
                                            </tr>
                                            <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                                                <itemtemplate>
                                                    <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                                                        <td>
                                                            <%# Container.ItemIndex +1 %>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSTOREDZIPCODE" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)"
                                                                MaxLength="6" runat="server" Width="24px" CssClass="txt_readonly" ReadOnly="true" Text='<%# Eval("STOREDZIPCODE")%>'>
                                                            </asp:TextBox>
                                                            <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onfocus="ObjFocus(this);"
                                                                onclick="PostCodeClick(this);" style="width: 25px; padding: 2px;" value="&#8230;" enabled="false" />
                                                            <asp:TextBox ID="txtSTOREDZIPCODES" runat="server" Width="120px" CssClass="txt_readonly" ReadOnly="true"
                                                                onfocus="ObjMFocus(this,'txtSTOREDZIPCODES','txtSTOREDADDR');" Text='<%# Eval("STOREDZIPCODES")%>'>
                                                            </asp:TextBox>
                                                            <asp:TextBox ID="txtSTOREDADDR" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="150px"
                                                                MaxLength="100" onblur="CheckMLength(this,'100');" Text='<%# Eval("STOREDADDR")%>'>
                                                            </asp:TextBox>
                                                            <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTNAME" MaxLength="10" onblur="CheckMLength(this,'10');"
                                                                Text='<%# Eval("CONTACTNAME")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCONTACT" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnCONTACT','txtDEPTNAME');"
                                                                OnClientClick="return btnCONTACT_click(this);" Style="padding: 2px; width: 25px;"
                                                                runat="server" Text="&#8230;" Enabled="false" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDEPTNAME" MaxLength="50" onblur="CheckMLength(this,'50');" Text='<%# Eval("DEPTNAME")%>'
                                                                runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTITLE" MaxLength="20" onblur="CheckMLength(this,'20');"
                                                                Text='<%# Eval("CONTACTTITLE")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTTELCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' CssClass="txt_readonly" ReadOnly="true" />
                                                            <asp:TextBox ID="txtCONTACTTEL" onkeypress="OnlyNum(this);" MaxLength="10" onblur="OnlyNumBlur(this);"
                                                                Text='<%# Eval("CONTACTTEL")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                            <asp:TextBox ID="txtCONTACTTELEXT" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="5" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' CssClass="txt_readonly" ReadOnly="true"
                                                                Width="40px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTMPHONE" onkeypress="OnlyNum(this);" MaxLength="10" onblur="OnlyNumBlur(this);"
                                                                Text='<%# Eval("CONTACTMPHONE")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTFAXCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"
                                                                MaxLength="3" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>' CssClass="txt_readonly" ReadOnly="true" />
                                                            <asp:TextBox ID="txtCONTACTFAX" onkeypress="OnlyNum(this);" MaxLength="10" onblur="OnlyNumBlur(this);"
                                                                Text='<%# Eval("CONTACTFAX")%>' runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCONTACTEMAIL" onblur="EMAILBlur(this);" MaxLength="50" Text='<%# Eval("CONTACTEMAIL")%>'
                                                                runat="server" CssClass="txt_readonly" ReadOnly="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpMLDCASETARGET" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged"
                                                                runat="server" CssClass="bg_readonly" Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </itemtemplate>
                                            </asp:Repeater>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                <contenttemplate>
                                    <asp:CheckBox ID="chkOneMLDCASETARGETSTR" Checked="false" AutoPostBack="true" runat="server"
                                        OnCheckedChanged="chkOneMLDCASETARGETSTR_CheckedChanged" />
                                    標的物存放地僅一處
                                </contenttemplate>
                            </asp:UpdatePanel>
                            <asp:CheckBox ID="chkAr2" runat="server" Style="display: none" Enabled="false" Checked="true" />
                            <!--
            AR案件無標的物存放地<br />
            -->
                            <br />
                            <div class="div_title" style="margin-left: -10px;">
                                AR案件發票暨背書人
                            </div>
                            <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                                <tr>
                                    <th width="10%">發票人
                                    </th>
                                    <td>
                                        <%--Modify 20121017 By SS Gordon. Reason: AR案件發票暨背書人-發票人不檢核身分證字號.拿掉onblur="idBlur(this);" --%>
                                        <asp:TextBox ID="txtBILLNOTECUSTID" MaxLength="10" CssClass="txt_normal" onkeypress="OnlyNumDUCase(this);"
                                            Width="120px" runat="server">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtBILLNOTECUST" MaxLength="10" CssClass="txt_normal" Width="300px"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>銀行/分行
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtDEPOSITBANKS" ReadOnly="true" CssClass="txt_normal" Width="427px"
                                            runat="server">
                                        </asp:TextBox>
                                        <input type="button" id="btnBank" runat="server" onfocus="ObjMFocus(this,'btnBank','txtACCOUNT');"
                                            class="btn_normal" onclick="BankClick();" style="width: 25px; padding: 2px;"
                                            value="&#8230;" />
                                        <asp:TextBox ID="txtDEPOSITBANK" Style="display: none" Width="427px" runat="server"></asp:TextBox>
                                        <%--<asp:TextBox ID="TextBox106" CssClass="txt_normal" Width="300px" runat="server"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>帳號
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtACCOUNT" onblur="CheckMLength(this,'20');" MaxLength="20" CssClass="txt_normal"
                                            Width="300px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>背書人
                                    </th>
                                    <td>
                                        <%--Modify 20121022 By SS Gordon. Reason: AR案件發票暨背書人-背書人不檢核身分證字號.拿掉onblur="idBlur(this);" --%>
                                        <asp:TextBox ID="txtENDORSERID" MaxLength="10" CssClass="txt_normal" onkeypress="OnlyNumDUCase(this);"
                                            Width="120px" runat="server">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtENDORSER" MaxLength="10" CssClass="txt_normal" Width="300px"
                                            runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--標的物End --%>
                        <%--擔保條件Begin --%>
                        <div id="fraTab55" class="div_content T_-130" style="display: none">
                            <br />
                            保證人<asp:CheckBox ID="chkMLDCASEGUARANTEE" Enabled="false" runat="server" />
                            本案無保證人
                            <div class="div_table" style="overflow: scroll;">
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
                                        <itemtemplate>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="drpGRTTYPE" Enabled="false" DataTextField="MNAME1" DataValueField="MCODE"
                                                        runat="server" Width="80%">
                                                        <asp:ListItem>法人</asp:ListItem>
                                                        <asp:ListItem>個人</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hidGRTID" Value='<%# Eval("GRTID") %>' runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' runat="server" CssClass="txt_table"
                                                        Width="80" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' runat="server" CssClass="txt_table"
                                                        Width="80" Enabled="false">
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
                                                    <%--Modify 20131002 By SS Steven. Reason:3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <%--<asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>' Enabled="false" runat="server" CssClass="txt_table_right"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>'
                                                        Enabled="false" onkeypress="OnlyNum(this)" onblur="MoneyBlur(this)" runat="server"
                                                        CssClass="txt_table_right">
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
                                <%--Modify 20121121 By SS Steven. Reason: 進件確認檢核新增:承作型態為分期-附條買時，擔保條件的動產一定要有資料--%>
                                <table id="tblMLDCASEMOVABLE" class="tb_Contact" style="width: 1200px;">
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
                                                    <asp:TextBox ID="txtMOVABLENAME" Enabled="false" Text='<%# Eval("MOVABLENAME")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                    <%--Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <asp:HiddenField ID="hidMOVABLEID" Value='<%# Eval("MOVABLEID") %>' runat="server" />
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpMOVABLEETARGET" Enabled="false" runat="server" Width="60px">
                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                        <asp:ListItem Value="2">否</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMOVABLEZIPCODE" Enabled="false" runat="server" Width="24px" CssClass="txt_table"
                                                        Text='<%# Eval("MOVABLEZIPCODE")%>'>
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtMOVABLEZIPCODES" Enabled="false" runat="server" Width="120px"
                                                        CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'>
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="txtMOVABLEADDR" Enabled="false" runat="server" CssClass="txt_table"
                                                        Width="150px" Text='<%# Eval("MOVABLEADDR")%>'>
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <%--Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <%--<asp:TextBox ID="txtMOVABLENO" Enabled="false" Text='<%# Eval("MOVABLENO")%>' runat="server" CssClass="txt_table"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtMOVABLENO" Enabled="false" Text='<%# Eval("MOVABLENO")%>' runat="server"
                                                        CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <%--Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <%--<asp:TextBox ID="txtMOVABLEYEAR" Enabled="false" Text='<%# Eval("MOVABLEYEAR")%>' runat="server" CssClass="txt_table"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtMOVABLEYEAR" onkeypress="OnlyNum(this)" MaxLength="4" Enabled="false"
                                                        Text='<%# Eval("MOVABLEYEAR")%>' runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <%--Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <%--<asp:TextBox ID="txtMOVABLEBUYDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>' runat="server" CssClass="txt_table"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtMOVABLEBUYDATE" onkeypress="OnlyNum(this)" onblur="dateBlur(this)"
                                                        Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMOVABLENEWAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMOVABLEBUYAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMOVABLERESIDUALS" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <%--20131210 MODIFY BY SEAN Reason:PRGID若是ML3001A則可開放修改動產設定金額，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                    <%--<asp:TextBox ID="txtMOVABLERESETPRICE" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtMOVABLERESETPRICE" onkeypress="OnlyNum(this)" Enabled="false"
                                                        Text='<%#  Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
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
                                                    <asp:TextBox ID="txtIMMOVABLEOWNER" Enabled="false" Text='<%# Eval("IMMOVABLEOWNER")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <%--Modify 20131002 By SS Steven. Reason: 2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                <asp:HiddenField ID="hidIMMOVABLEID" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEOWNERID" Enabled="false" Text='<%# Eval("IMMOVABLEOWNERID")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEGETDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEBUILDDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLESECTOR" Enabled="false" Text='<%# Eval("IMMOVABLESECTOR")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEBUILD" Enabled="false" Text='<%# Eval("IMMOVABLEBUILD")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEAREA" Enabled="false" Text='<%# Eval("IMMOVABLEAREA")%>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEHOLDER" Enabled="false" Text='<%# Eval("IMMOVABLEHOLDER")%>'
                                                        runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEBUILDNO" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDNO")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEHOUSENUM" Enabled="false" Text='<%# Eval("IMMOVABLEHOUSENUM")%>'
                                                        runat="server" CssClass="txt_table">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Eval("IMMOVABLEBUILDAREA")%>'
                                                        onblur="areacon(this)" runat="server" CssClass="txt_table_right">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblIMMOVABLEBUILDAREA" Enabled="false" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>'
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
                                            <asp:HiddenField ID="hidIMMOVABLEID" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                                            <td>
                                                <%# Container.ItemIndex +1 %>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHUMANRIGHTS" Enabled="false" Text='<%# Eval("HUMANRIGHTS") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <%--Modify 20131002 By SS Steven. Reason:2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。--%>
                                                <%--<asp:TextBox ID="txtREGISTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>' runat="server" CssClass="txt_table"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtREGISTDATE" Enabled="false" onkeypress="OnlyNum(this)" onblur="dateBlur(this)"
                                                    Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSETPRICE" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCREDITOR" Enabled="false" Text='<%# Eval("CREDITOR") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <%--20131210 Modify by SEAN. Reason:修正不動產項次取號問題--%>
                                                <%--<asp:DropDownList ID="drpMLDCASEIMMOVABLE" Enabled="false" runat="server">
                                            </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtMLDCASEIMMOVABLE" Enabled="false" runat="server" CssClass="txt_table"
                                                    Text='<%# Eval("IDMEMO") %>' />
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
                                                <asp:TextBox ID="txtDEPOSITBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("DEPOSITBANKS") %>'
                                                    Width="120px" runat="server">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITNBR" Enabled="false" Text='<%# Eval("DEPOSITNBR") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITAMT" Enabled="false" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITSTARTDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDEPOSITDUEDATE" Enabled="false" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>'
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
                                                <asp:TextBox ID="txtBILLNOTEDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>'
                                                    Width="80px" runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" Enabled="false" Text='<%# Eval("BILLNOTEBANKS") %>'
                                                    Width="80px" runat="server">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpBILLNOTETYPE" Enabled="false" runat="server" Width="60px">
                                                    <asp:ListItem Value="1">本票</asp:ListItem>
                                                    <asp:ListItem Value="2">支票</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTENBR" Enabled="false" Text='<%# Eval("BILLNOTENBR") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtACCOUNT" Enabled="false" Text='<%# Eval("ACCOUNT") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTECUSTNAME" Enabled="false" Text='<%# Eval("BILLNOTECUSTNAME") %>'
                                                    Width="80px" runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTEAMT" Enabled="false" Text='<%# Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString()) %>'
                                                    runat="server" CssClass="txt_table_right">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTENOTE" Enabled="false" Text='<%# Eval("BILLNOTENOTE") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBILLNOTEBACKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                            <br />
                            股票<asp:CheckBox ID="chkMLDCASESTOCK" Enabled="false" runat="server" />
                            本案無股票
                            <table class="tb_Contact" width="80%">
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
                                                <asp:TextBox ID="txtSTOCKDATE" Enabled="false" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKNAME" Enabled="false" Text='<%# Eval("STOCKNAME") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKPROVIDER" Enabled="false" Text='<%# Eval("STOCKPROVIDER") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKUNIT" Enabled="false" Text='<%# Eval("STOCKUNIT") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKQUANTITY" Width="50px" Enabled="false" Text='<%# Eval("STOCKQUANTITY") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKTOTAL" Width="60px" Enabled="false" Text='<%# Eval("STOCKTOTAL") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKBEGIN" Enabled="false" Text='<%# Eval("STOCKBEGIN") %>'
                                                    runat="server" CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKEND" Enabled="false" Text='<%# Eval("STOCKEND") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpSTOCKINSURANCE" Enabled="false" runat="server">
                                                    <asp:ListItem Value="1">集保</asp:ListItem>
                                                    <asp:ListItem Value="2">實體</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSTOCKNOTE" Enabled="false" Text='<%# Eval("STOCKNOTE") %>' runat="server"
                                                    CssClass="txt_table">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:Repeater>
                            </table>
                            <br />
                            其他<br />
                            <asp:TextBox ID="txtOTHERCOND" Enabled="false" runat="server" CssClass="txt_normal"
                                Width="80%">
                            </asp:TextBox>
                        </div>
                        <%--擔保條件End --%>
                        <%--撥款申請Begin --%>
                        <div id="fraTab66" class="div_content T_-120" style="display: none">
                            <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                                <tr>
                                    <th width="13%">案件起租日
                                    </th>
                                    <td width="13%">
                                        <%--20131210 修改輸入日期不可超過1年--%>
                                        <%--20141024 因為特殊案件案件起租日有可能超過1年，將此檢核拿掉--%>
                                        <asp:TextBox ID="txtPRENTSTDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);" CssClass="txt_must" custprop="010" runat="server">
                                        </asp:TextBox>
                                        <%--<asp:TextBox ID="txtPRENTSTDT" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                        onblur="dateBlur2(this);" CssClass="txt_must" custprop="010" runat="server"></asp:TextBox>--%>
                                    </td>
                                    <th width="16%">客戶首期繳納日
                                    </th>
                                    <td width="13%">
                                        <%--20131210 修改輸入日期不可超過1年--%>
                                        <%--20141009 因為AR件繳款日有可能超過1年，將此檢核拿掉--%>
                                        <asp:TextBox ID="txtCUSTFPAYDATE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);" custprop="010" CssClass="txt_must" runat="server">
                                        </asp:TextBox>
                                        <%--<asp:TextBox ID="txtCUSTFPAYDATE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                        onblur="dateBlur2(this);" custprop="010" CssClass="txt_must" runat="server"></asp:TextBox>--%>
                                    </td>
                                    <th width="13%">預計撥款日
                                    </th>
                                    <td width="13%">
                                        <%--20131210 修改輸入日期不可超過1年--%>
                                        <%--20141024 因為特殊案件預計撥款日有可能超過1年，將此檢核拿掉--%>
                                        <asp:TextBox ID="txtPAYDATE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                            onblur="dateBlur(this);txtPAYDATE_onblur(this);" custprop="010" CssClass="txt_must" runat="server">
                                        </asp:TextBox>
                                        <%--<asp:TextBox ID="txtPAYDATE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                        onblur="dateBlur2(this);" custprop="010" CssClass="txt_must" runat="server"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtPAYDATES" Style="display: none" Width="427px" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtPAYDATEE" Style="display: none" Width="427px" runat="server"></asp:TextBox>
                                        <%--Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y--%>
                                        <asp:TextBox ID="txtSALESFLG" runat="server" Visible="false"></asp:TextBox>
                                    </td>
                                    <%--Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。--%>
                                    <%--<th width="12%">--%>
                                    <th width="12%" id="trMONEY1" runat="server">手續費收入
                                    </th>
                                    <%--<td>--%>
                                    <td id="trMONEY2" runat="server">
                                        <asp:TextBox ID="txtRRFEE" custprop="100" runat="server" CssClass="txt_readonly_right"
                                            ReadOnly="true">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <%--Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。--%>
                                <%--<tr>--%>
                                <tr id="trMONEY3" runat="server">
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
                            <br />
                            <%--Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。--%>
                            <div id="div_APPRO" runat="server">
                                <div class="div_title" style="margin-left: -10px;">
                                    進項發票&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="color: #990000">[ 新增請按F8 &nbsp;&nbsp;&nbsp; 刪除請按F9 ]</span>
                                </div>
                                <div id="divMLDCONTRACTINV" class="div_table" style="overflow: auto; height: 100px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDCONTRACTINV" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDCONTRACTINV" class="tb_Contact" width="2200px">
                                                <tr onclick="changeTag('rptMLDCONTRACTINV')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCONTRACTINV','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCERTIFICATENO" Text='<%# Eval("CERTIFICATENO")%>' MaxLength="10"
                                                                    Width="96px" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);UpperCase(this);CheckCERTIFICATENO(this);"
                                                                    runat="server" CssClass="txt_table">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString())%>'
                                                                    Width="80px" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)"
                                                                    onblur="dateBlur(this);CheckINVDate(this);" runat="server" CssClass="txt_table">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNOTAXAMOUNT" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="AddTAX2(this,'txtNOTAXAMOUNT','txtANOUMTTAX','txtTAX');" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOTAXAMOUNT").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTAX" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("TAX").ToString()) %>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtANOUMTTAX" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="DelTAX2(this,'txtNOTAXAMOUNT','txtANOUMTTAX','txtTAX');" Text='<%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPERBONDUSED" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDUSED").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtHIREPURUSED" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("HIREPURUSED").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFIRSTPAYUSED" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYUSED").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVSALESPAY" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("INVSALESPAY").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtACTUALLYAMOUNT" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPERBONDNOTE" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("PERBONDNOTE").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPURCHASENOTE" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("PURCHASENOTE").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFIRSTPAYNOTE" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYNOTE").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtINVSUPPLIERID" Text='<%# Eval("SUPPLIER")%>' onkeypress="OnlyNumDUCase(this);"
                                                                    onblur="INVSUPPLIERID_onblur(this);" MaxLength="10" runat="server" CssClass="txt_must">
                                                                </asp:TextBox>
                                                                <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnSUPPLIERID','txtCERTIFICATENO');"
                                                                    OnClientClick="return SupplierRClick(this);" Style="padding: 2px; width: 25px;"
                                                                    runat="server" Text="&#8230;" />
                                                                <asp:TextBox ID="txtSUPPLIERS" runat="server" CssClass="txt_table" MaxLength="20"
                                                                    Width="160px" Text='<%# Eval("SUPPLIERS")%>'>
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hidSUPPLIER" Value='<%# Eval("SUPPLIER") %>' runat="server" />
                                                                <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpSUPSEQ" runat="server">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hidSUPSEQ" Value='<%# Eval("SUPSEQ") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBANKNM" runat="server" CssClass="txt_table" Width="160px" Text='<%# Eval("BANKNM")%>'></asp:TextBox>
                                                                <asp:HiddenField ID="hidPAYBANK" Value='<%# Eval("PAYBANK") %>' runat="server" />
                                                                <asp:HiddenField ID="hidPAYData" Value='' runat="server" />
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
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br>
                                <br>
                                <div class="div_title" style="margin-left: -10px;">
                                    進項折讓發票&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #990000"> [ 新增請按F8 &nbsp;&nbsp;&nbsp;
                                        刪除請按F9 ]</span>
                                </div>
                                <div id="divMLDCONTRACTINVD" class="div_table" style="overflow: auto; height: 100px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDCONTRACTINVD" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDCONTRACTINVD" class="tb_Contact" width="80%">
                                                <tr onclick="changeTag('rptMLDCONTRACTINVD')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCONTRACTINVD','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                                <asp:HiddenField ID="hidDISCOUNTINVOICEID" Value='<%# Eval("DISCOUNTINVOICEID") %>'
                                                                    runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDISCOUNTINVNUM" Text='<%# Eval("DISCOUNTINVNUM")%>' MaxLength="10"
                                                                    Width="96px" onkeypress="OnlyNumDUCase(this);" onblur="OnlyNumDBlur(this);checkDISCOUNTINVNUM(this);UpperCase(this);"
                                                                    runat="server" CssClass="txt_table">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDISCOUNTDATE" MaxLength="8" Width="80px" onkeypress="OnlyNum(this);"
                                                                    onfocus="dateFocus(this)" onblur="dateBlur(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("DISCOUNTDATE").ToString()) %>'
                                                                    runat="server" CssClass="txt_table">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDISCOUNTAMOUNT" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="checkDISCOUNTAMOUNT(this);AddTAX2(this,'txtDISCOUNTAMOUNT','txtDISCOUNTAMOUNTTAX','txtDISCOUNTTAX');"
                                                                    Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDISCOUNTTAX" MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)"
                                                                    onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDISCOUNTAMOUNTTAX" MaxLength="9" onkeypress="OnlyNum(this);"
                                                                    onfocus="MoneyFocus(this)" onblur="DelTAX2(this,'txtDISCOUNTAMOUNT','txtDISCOUNTAMOUNTTAX','txtDISCOUNTTAX');checkDISCOUNTAMOUNTTAX(this);"
                                                                    Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                                <%--<div style="display: none;">--%>
                                <div class="div_title" style="margin-left: -10px;">
                                    指定付款他人&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="color: #990000">[ 新增請按F8 &nbsp;&nbsp;&nbsp; 刪除請按F9 ]</span>
                                </div>
                                <div id="divMLDASSPAYMF" class="div_table" style="overflow: auto; height: 120px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDASSPAYMF" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDASSPAYMF" class="tb_Contact" width="1400px">
                                                <tr onclick="changeTag('rptMLDASSPAYMF')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDASSPAYMF','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                                <asp:HiddenField ID="hdSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpCERTNO" runat="server"></asp:DropDownList>
                                                                <asp:HiddenField ID="hidCERTNO" Value='<%# Eval("CERTNO") %>' runat="server" />
                                                                <%--<asp:TextBox ID="txtCERTNO" runat="server" Text='<%# Eval("CERTNO") %>'
                                                            CssClass="txt_table" Width="120px" onblur="txtCERTNO_OnChange(this);"></asp:TextBox>--%>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPAYEE" runat="server" Text='<%# Eval("PAYEE") %>'
                                                                    CssClass="txt_table" Width="110px" onblur="txtPAYEE_OnChange(this);">
                                                                </asp:TextBox>
                                                                <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnSUPPLIERID','txtPAYEE');"
                                                                    OnClientClick="return SupplierPREPAYClick(this);" Style="padding: 2px; width: 25px;"
                                                                    runat="server" Text="&#8230;" />
                                                                <asp:TextBox ID="txtPAYEENM" runat="server" Text='<%# Eval("PAYEENM") %>'
                                                                    CssClass="txt_table" Width="180px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpSUPSEQ" runat="server"></asp:DropDownList>
                                                                <asp:HiddenField ID="hidSUPSEQ" Value='<%# Eval("SUPSEQ") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTRANSBANK" runat="server" Text='<%# Eval("TRANSBANK") %>'
                                                                    CssClass="txt_table" Width="200px" Enabled="false">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hidPAYData" Value='' runat="server" />
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
                                                                    CssClass="txt_table_right" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="CalDISCOUNTTOTAL(this);txtTRANSAMT_OnChange(this);MoneyBlur(this);">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="div_title" style="margin-left: -10px;">
                                    預撥沖銷
                                </div>
                                <div class="div_table" style="overflow: auto; height: 100px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDPREPAYWOFF" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            前次沖銷
                                                <asp:Button ID="btnPREPAY" runat="server" CssClass="btn_normal" Text="查詢" OnClientClick="return btnPrePay_OnClick(this);" OnClick="btnPrePay_OnClick" />
                                            <br />
                                            本次沖銷
                                    <br />
                                            <table id="tblMLDPREPAYWOFF" class="tb_Contact" width="80%">
                                                <tr>
                                                    <th>項次
                                                    </th>
                                                    <th>預撥ID
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
                                                                <asp:TextBox ID="txtPREPAYID" runat="server" Text='<%# Eval("PREPAYID") %>'
                                                                    CssClass="txt_table" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPREPAYOBJ" runat="server" Text='<%# Eval("PREPAYOBJ") %>'
                                                                    CssClass="txt_table" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTOTALPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("TOTALPREPAYAMT").ToString()) %>'
                                                                    CssClass="txt_table_right" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNOWPREPAYAMT" runat="server" onblur="CalDISCOUNTTOTAL(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("NOWPREPAYAMT").ToString()) %>'
                                                                    CssClass="txt_table_right" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtLASTPREPAYAMT" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("LASTPREPAYAMT").ToString()) %>'
                                                                    CssClass="txt_table_right" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtADVANCESINTEREST" runat="server" Text='<%# Itg.Community.Util.NumberFormat(Eval("ADVANCESINTEREST").ToString()) %>'
                                                                    CssClass="txt_table_right" Width="80px" Enabled="false">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="div_title" style="margin-left: -10px;">
                                    手續費收入&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="color: #990000">[ 新增請按F8 &nbsp;&nbsp;&nbsp; 刪除請按F9 ]</span>

                                </div>
                                <div class="div_table" style="overflow: auto; height: 100px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDFEEINCOME1" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDFEEINCOME1" class="tb_Contact" width="90%">
                                                <tr onclick="changeTag('rptMLDFEEINCOME1')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDFEEINCOME1','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                                <asp:HiddenField ID="hdSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpCUSTTYPE" runat="server">
                                                                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                                                    CssClass="txt_table" Width="100px" onblur="txtUNIMNO_OnChange(this);">
                                                                </asp:TextBox>
                                                                <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnSUPPLIERID','drpCUSTTYPE');"
                                                                    OnClientClick="return SupplierFEEClick(this);" Style="padding: 2px; width: 25px;"
                                                                    runat="server" Text="&#8230;" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                                    CssClass="txt_table" Width="180px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFEEAMT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right" onblur="CalDISCOUNTTOTAL(this);txtFEEAMT_onchange(this);"
                                                                    onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpPAYTYPE" runat="server" onchange="drpPAYTYPE_OnChange(this);">
                                                                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="div_title" style="margin-left: -10px;">
                                    重車動保手續費收入&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span style="color: #990000">[ 新增請按F8 &nbsp;&nbsp;&nbsp; 刪除請按F9 ]</span>

                                </div>
                                <div class="div_table" style="overflow: auto; height: 100px">
                                    <asp:UpdatePanel ID="UpdatePanelMLDFEEINCOME2" runat="server" UpdateMode="Conditional">
                                        <contenttemplate>
                                            <table id="tblMLDFEEINCOME2" class="tb_Contact" width="90%">
                                                <tr onclick="changeTag('rptMLDFEEINCOME2')">
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
                                                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDFEEINCOME2','<%# Container.ItemIndex  %>')">
                                                            <td>
                                                                <%# Container.ItemIndex +1 %>
                                                                <asp:HiddenField ID="hdSEQNO" runat="server" Value='<%# Eval("SEQNO") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpCUSTTYPE" runat="server">
                                                                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="法人" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="個人" Value="02"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUNIMNO" runat="server" Text='<%# Eval("UNIMNO") %>'
                                                                    CssClass="txt_table" Width="100px" onblur="txtUNIMNO_OnChange(this);">
                                                                </asp:TextBox>
                                                                <input type="button" id="btnACC" disabled="disabled" class="btn_normal"
                                                                    onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;"
                                                                    value="&#8230;" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTARGET" runat="server" Text='<%# Eval("TARGET") %>'
                                                                    CssClass="txt_table" Width="180px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFEEAMT" custprop="100" Text='<%# Itg.Community.Util.NumberFormat(Eval("FEEAMT").ToString())%>'
                                                                    runat="server" CssClass="txt_table_right"
                                                                    onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpPAYTYPE" runat="server" onchange="drpPAYTYPE_OnChange(this);">
                                                                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                                    <asp:ListItem Text="匯款" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="內扣" Value="02"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                    </itemtemplate>
                                                </asp:Repeater>
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <%--</div>--%>
                                <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
                                <br />
                                <div class="div_title" style="margin-left: -10px;">
                                    抵設備款資料
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                                            <tr>
                                                <th width="20%">履約保證金抵設備款
                                                </th>
                                                <td width="12%">
                                                    <asp:TextBox ID="txtPERBONDUSED" Text="0" custprop="100" onfocus="MoneyFocus(this)"
                                                        ReadOnly="true" MaxLength="9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th width="15%">履約保證金票據
                                                </th>
                                                <td width="12%">
                                                    <asp:TextBox ID="txtPERBONDNOTE" MaxLength="20" Text="0" custprop="100" runat="server"
                                                        ReadOnly="true" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th width="20%">租購保證金抵設備款
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtPURCHASEUSED" Text="0" custprop="100" onfocus="MoneyFocus(this)"
                                                        ReadOnly="true" MaxLength="9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>租購保證金票據
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtPURCHASENOTE" MaxLength="20" Text="0" custprop="100" runat="server"
                                                        ReadOnly="true" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th>頭期款抵設備款
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtFIRSTPAYUSED" custprop="100" Text="0" onfocus="MoneyFocus(this)"
                                                        ReadOnly="true" MaxLength="9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th>頭期款票據
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtFIRSTPAYNOTE" MaxLength="20" Text="0" custprop="100" runat="server"
                                                        ReadOnly="true" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>業代自付額
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtSALESPAY" custprop="100" Text="0" onfocus="MoneyFocus(this)"
                                                        ReadOnly="true" MaxLength="9" onkeypress="OnlyNum(this);" runat="server" CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 START --%>
                                                <th>手續費抵設備款
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtFEEAMT" Text="0" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"
                                                        onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);">
                                                    </asp:TextBox>
                                                </td>
                                                <th>沖預撥抵設備款
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtPREPAYWOFFAMT" Text="0" custprop="100" MaxLength="9" runat="server" CssClass="txt_normal_right"
                                                        onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);">
                                                    </asp:TextBox>
                                                </td>
                                                <%-- 20161125 ADD BY SS ADAM REASON.增加預撥沖銷 END --%>
                                            </tr>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                                <br />
                                <div class="div_title" style="margin-left: -10px;">
                                    撥款資料
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <table cellpadding="1" cellspacing="1" class="tb_Info" style="margin-left: -5px;">
                                            <tr>
                                                <th width="18%">進項總額
                                                </th>
                                                <td width="15%">
                                                    <asp:TextBox ID="txtDISCOUNTTOTAL" Text="0" custprop="100" onkeypress="OnlyNum(this);"
                                                        onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server"
                                                        CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th width="18%">進項稅額
                                                </th>
                                                <td width="15%">
                                                    <asp:TextBox ID="txtDISCOUNTTAX" Text="0" custprop="100" onkeypress="OnlyNum(this);"
                                                        onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server"
                                                        CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                                <th width="15%">實撥金額
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtACTUALLYAMOUNT" Text="0" custprop="100" onkeypress="OnlyNum(this);"
                                                        onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server"
                                                        CssClass="txt_normal_right">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%--Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。--%>
                        </div>
                        <%--撥款申請End --%>
                    </div>
                    <div>
                        &nbsp;
                    </div>
                    <div class="btn_div">
                        <asp:DropDownList ID="droIMMOVABLEID" runat="server" Style="display: none" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server"
                            DataTextField="MNAME1" DataValueField="MCODE">
                        </asp:DropDownList>
                        <asp:Button ID="btnAddCon" Style="display: none" runat="server" Text="" OnClick="btnAddCon_Click" />
                        <asp:Button ID="btnDelCon" Style="display: none" runat="server" Text="" OnClick="btnDelCon_Click" />
                        <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
                        <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
                        <asp:Button ID="btnQryPrePay" Style="display: none;" runat="server" Text="" OnClick="btnQryPrePay_Click" />
                        <asp:Button ID="btnSave" Enabled="false" runat="server" Text="暫存" CssClass="btn_normal"
                            OnClick="btnSave_Click" />
                        <asp:Button ID="btnListPrint" Enabled="false" runat="server" Text="撥款一覽表" CssClass="btn_normal"
                            OnClientClick="javascipt:return btnListPrint_onClick(this);" />
                        <!--Modify 20130823 By SEAN. Reason: 隱藏合約列印鈕.-->
                        <asp:Button ID="btnContractPrint" Enabled="false" runat="server" Text="合約書列印" CssClass="btn_normal"
                            OnClick="btnContractPrint_Click" />
                        <asp:Button ID="btnSubmit" Enabled="false" runat="server" Text="撥款確認" CssClass="btn_normal"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnSaveModify" Enabled="false" runat="server" Text="修改存檔" CssClass="btn_normal"
                            OnClientClick="javascipt:return btnSaveModify_Click(this);" OnClick="btnSaveModify_Click" />
                        <%--Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕--%>
                        <asp:Button ID="btnChangePrint" Enabled="false" runat="server" Text="授信變更書列印" CssClass="btn_normal"
                            OnClientClick="javascipt:return btnChangePrint_onClick(this);" />
                        <!--Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.-->
                        <asp:Button ID="btnRej" Enabled="false" runat="server" Text="案件撤件" CssClass="btn_normal"
                            OnClick="btnRej_Click" />
                        <!--Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕.-->
                        <%--Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.--%>
                        <%--<asp:Button ID="btnRecheck" Enabled="false" runat="server" Text="關係人檢核" align="left" CssClass="btn_normal" OnClientClick="Recheck();" />--%>
                        <asp:Button ID="btnRecheck" Enabled="false" runat="server" Text="關係人檢核列印" align="left"
                            CssClass="btn_normal" OnClick="btnRecheck_Click" />
                        <%--Modify 20131002 By SS Steven. Reason: 區分PRGID為ML3001A以及ML3002的處理流程，最下方的按鈕，在PRGID為ML3001A以及ML3002則有對應的顯示方式--%>
                        <asp:Button ID="btnSURE" Enabled="false" runat="server" Text="確認" CssClass="btn_normal"
                            OnClick="btnSURE_Click" />
                        <asp:Button ID="btnPayDate" Enabled="false" runat="server" Text="合約期付款日期維護" CssClass="btn_normal"
                            OnClick="btnPayDate_Click" OnClientClick="return checkIRR();" />
                        <asp:Button ID="btnBackModify" Enabled="false" runat="server" Text="返回合約修改維護" CssClass="btn_normal"
                            OnClick="btnBackModify_Click" />
                        <!--Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印-->
                        <asp:Button ID="btnRmainPrint" Enabled="false" runat="server" Text="承作內容核准書列印" CssClass="btn_normal"
                            OnClientClick="btnRmainPrint_onClick(this)" />
                        <asp:TextBox ID="txtPRGID" custprop="010" runat="server" CssClass="txt_readonly"
                            ReadOnly="true" Style="display: none">
                        </asp:TextBox>
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
                    </div>
                </div>
            </contenttemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
