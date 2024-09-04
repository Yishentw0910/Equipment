<%-- 
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3000																					
* 程式功能  : 案件申請維護																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120528 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120528 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」，並將欄位變更為可輸入100個中文字
Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
Modify 20120621 By SS Gordon. Reason: 新增隱藏欄位以儲存案件資料供修改後的檢核
Modify 20120716 By SS Gordon. Reason: 新增承作方式.
Modify 20120716 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.
Modify 20121112 By SS Steven. Reason: 新增隱藏欄位來做判斷
Modify 20121112 By SS Steven. Reason: 新增隱藏欄位來做判斷
Modify 20121112 By SS Steven. Reason: 登打保人條件時，系統依個人或法人判別，非必要之登打條件以反灰呈現
Modify 20130117 BY    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」
Modify 20130326 By SS Eric    Reason:新增保險異常欄位
Modify 20130326 By SS Eric    Reason:將txtEXPIREPROCDESC的 MaxLength="100" onblur="CheckMLength(this,100,'說明');"由100改成150
Modify 20130402 By SS Vicky   Reason: 動產與不動產增加複製按鈕
Modify 20130411 By SS Vicky. Reason: 動產及不動產將項次改為Textbox  (MOVABLEORDER / IMMOVABLEORDER)
Modify 20130425 By SS Steven. Reason: 擔保條件的不動產權利人明細欄位檢核
Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
20130521 ADD BY ADAM Reason.增加權利人欄位IDMEMO處理
Modify 20130913 By    Sean.   Reason:動產設定所在地欄位可輸入50個中文字
20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏
Modify 20150121 By SS Eric.   Reason:新增專案別
Modify 20150205 By SS ChrisFu. Reason:因承作型態變更為「應收帳款受讓」時，欄位內容要做更動，故加上UpdatePanel
Modify 20150205 By SS ChrisFu. Reason:「成數」由TextBox改為下拉選單
Modify 20150205 By SS ChrisFu. Reason:「建議墊息款」設為隱藏，新增「建議墊款息」
Modify 20161130 BY    SEAN    Reason:新增「NPV0」.「NPV0成本」隱藏欄位
20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本
20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%)
20221031 調整「案件內容」、「標的物」位置，隱藏「進件資料」標籤
20221031 隱藏客戶資料內客戶性質、集團實際負責人、母公司名稱欄位，行業別改為下拉式選單
20221031 標的物新增匯入範本下載、隱藏AR案件無標的物、銀行案件無標的物
20221031 案件內容隱藏隱藏專案別、公司名稱、承作方式、動用情況、附追索權、銀行別、應收帳款案件
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML3000.aspx.cs" Inherits="FrmML3000" EnableEventValidation="false" %>

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

  <script type="text/javascript" language="javascript">
    <!-- #Include file='js/ML3000.js' -->                       
  </script>

</head>
<body onload="window_onload();" onkeydown="body_OnKeyDown(event)">
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
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
            </td>
          </tr>
        </table>
        <table class="divStatus" width="98%">
          <tr>
            <td width="36%">
              <asp:Button ID="btnInsert" runat="server" Text="新增" CssClass="btn_normal" OnClick="btnInsert_Click" Visible="false" />
              <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn_normal" OnClientClick="return CaseClick('U')" />
              <asp:Button ID="btnSelect" runat="server" Text="查詢" CssClass="btn_normal" OnClientClick="return CaseClick('S')" Visible="false" />
              <asp:Button ID="btnLoadCase" runat="server" Text="載入舊案" CssClass="btn_normal" OnClientClick="return CaseInsertClick()" OnClick="btnLoadCase_Click" Width="70px" Visible="false" />
              <asp:Button ID="btnCusQue" Style="display: none" runat="server" Text="" OnClick="btnCusQue_Click" />
              <asp:Button ID="btnCaseQue" Style="display: none" runat="server" Text="" OnClick="btnCaseQue_Click" />
              <asp:HiddenField ID="hidCustomer" runat="server" />
              <asp:HiddenField ID="hidShowTag" runat="server" Value="fraTab11Caption" />
              <asp:HiddenField ID="hidSelRowIndex" runat="server" Value="-1" />
              <asp:HiddenField ID="hidOldData" runat="server" Value="" />
              <asp:HiddenField ID="hidSelHeadTag" runat="server" Value="" />
              <asp:HiddenField ID="hidSelRowTag" runat="server" Value="" />
              <asp:HiddenField ID="hidDEPTID" runat="server" Value="" />
              <asp:HiddenField ID="hidEMPLID" runat="server" Value="" />
			  <!--20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動-->
			  <asp:HiddenField ID="hidMAINTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidSUBTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidTARGETPRICE" runat="server" Value="" />
			  <asp:HiddenField ID="hidTARGETTYPE" runat="server" Value="" />
			  <asp:HiddenField ID="hidINSUREERR" runat="server" Value="" />
            </td>
            <th width="11%">
              案件編號
            </th>
            <td width="13%">
              <asp:TextBox ID="txtCASEID" Enabled="false" Width="100px" runat="server" CssClass="txt_normal"></asp:TextBox>
            </td>
            <th width="12%">
              申請日
            </th>
            <td width="12%">
              <asp:TextBox ID="txtSYSDT" Enabled="false" runat="server" CssClass="txt_normal"></asp:TextBox>
            </td>
            <td>
              <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
            </td>
          </tr>
        </table>
        <div id="fraDispTypeInfo" class="frame_content div_Info " style="min-height: 900px; height: auto !important;">
          <div id="fraTab11Caption" tabframe="fraTab11" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu">
            <label class="label_contain">
              客戶資料</label>
          </div>
          <div id="fraTab33Caption" tabframe="fraTab33" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu T_-24 L_125">
            <label class="label_contain">
              標的物</label>
          </div>
          <div id="fraTab22Caption" tabframe="fraTab22" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu  L_250 T_-48">
            <label class="label_contain">
              案件內容</label>
          </div>
          <div id="fraTab44Caption" tabframe="fraTab44" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu L_375 T_-72">
            <label class="label_contain">
              擔保條件</label>
          </div>
          <div id="fraTab55Caption" tabframe="fraTab55" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu L_500 T_-96">
            <label class="label_contain">
              徵審資料</label>
          </div>
            <%--20221031 改為隱藏--%>
<%--          <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu1 L_535 T_-120">
            <label class="label_contain">
              <!--案件報告</label>-->
              <!-- 20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個 -->
              進件資料</label>
          </div>--%>
          <div id="fraTab66Caption" tabframe="fraTab66" container="fraDispTypeInfo" onclick="Caption_onclick(this,'Y');" class="sheet div_menu W_124 T_-120 L_625">
            <label class="label_contain">
              往來查詢</label>
          </div>
          <%--客戶資料Begin --%>
          <div id="fraTab11" class="div_content padleft_0 T_-120" style="display: none;">
            <table cellpadding="1" cellspacing="1" class="tb_Info">
              <tr>
                <th width="15%">
                  客戶統編
                </th>
                <td width="15%">
                  <asp:TextBox ID="txtCUSTID" runat="server" onkeypress="OnlyNumDUCase(this);" CssClass="txt_readonly" MaxLength="10" onblur="CUSTID_onblur(this);"></asp:TextBox>
                  <input type="button" id="btnSelCus" class="btn_normal" disabled="true" runat="server" onclick="CustomerClick();" style="width: 25px; padding: 2px;" value="&#8230;" />
                </td>
                <th width="13%">
                  客戶名稱
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTNAME" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="240px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                    <%--20221031 改為隱藏--%>
                    <%--客戶性質--%><asp:DropDownList ID="drpCUTYPE" Enabled="false" runat="server" DataTextField="MNAME1" DataValueField="MCODE" style="display:none">
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <th>
                  登記資本額
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTCREATECAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" ReadOnly="true" Width="112px"></asp:TextBox>
                </td>
                <th>
                  實收資本額
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTNOWCAPTIAL" custprop="100" runat="server" CssClass="txt_readonly_right" ReadOnly="true" Width="112px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;設立日期
                  <asp:TextBox ID="txtCUSTCREATEDATE" custprop="010" runat="server" CssClass="txt_readonly" Width="81px" ReadOnly="true"></asp:TextBox>
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
                  <asp:TextBox ID="txtOWNERID" runat="server" MaxLength="10" Width="85px" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);" CssClass="txt_normal"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <%--20221031 改為隱藏--%>
                    <%--集團實際負責人--%><asp:TextBox ID="txtGROUPOWNER" runat="server" CssClass="txt_readonly" Width="81px" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                    <%--20221031 改為隱藏--%>
                  <%--母公司編號--%>
                </th>
                <td>
                  <asp:TextBox ID="txtPARENTCUSTID" runat="server" CssClass="txt_readonly" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
                <th>
                  <%--母公司名稱--%>
                </th>
                <td>
                  <asp:TextBox ID="txtPARENTCUSTNAME" runat="server" CssClass="txt_readonly" Width="276px" ReadOnly="true" style="display:none"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  公司登記地址
                </th>
                <td colspan="2">
                  <asp:TextBox ID="txtCUSTZIPCODE" runat="server" Width="24px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTZIPCODES" runat="server" Width="120px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                  <asp:TextBox ID="txtCUSTADDR" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="276px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  公司登記電話
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <th>
                  傳真
                </th>
                <td>
                  <asp:TextBox ID="txtCUSTFAXCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" Width="20px" runat="server" CssClass="txt_normal"></asp:TextBox>
                  <asp:TextBox ID="txtCUSTFAX" runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_normal"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  營業登記地址
                </th>
                <td colspan="2">
                  <asp:TextBox ID="txtBUSINESSZIPCODE" runat="server" Width="24px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSZIPCODES" runat="server" Width="120px" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                  <asp:TextBox ID="txtBUSINESSADDR" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="276px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  營業登記電話
                </th>
                <td>
                  <asp:TextBox ID="txtBUSINESSTTELCODE" MaxLength="3" Width="20px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSTTEL" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
                </td>
                <th>
                  傳真
                </th>
                <td>
                  <asp:TextBox ID="txtBUSINESSFAXCODE" MaxLength="3" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" Width="20px" runat="server" CssClass="txt_normal"></asp:TextBox>
                  <asp:TextBox ID="txtBUSINESSFAX" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_normal"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  主要營業項目
                </th>
                <td colspan="3">
                  <asp:TextBox ID="txtBUSINESS" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="81%"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <th>
                  行業別
                </th>
                <td colspan='3'>
                   <!-- 20160322 ADD BY SS ADAM REASON.新增行業別 ===START===-->
                    <%--20221031 行業別改下拉選單--%>
                                 <asp:DropDownList ID="DrpNDU"  class="bg_readOnly" ReadOnly="true" runat="server" Width="200px" DataTextField="MNAME1"
                                    DataValueField="MCODE" Enabled="False" >
                                    <asp:ListItem>請選擇</asp:ListItem>
                                </asp:DropDownList>

                    <asp:TextBox ID="txtINDUID" runat="server" CssClass="txt_readonly" ReadOnly="true" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtINDUNM" runat="server" CssClass="txt_readonly" ReadOnly="true" Width="200px" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnINDUPAGE" runat="server" Text="查詢行業別" CssClass="btn_normal" Enabled="false" Visible="False" />
                    <!-- 20160322 ADD BY SS ADAM REASON.新增行業別 ====END====-->
                  <asp:DropDownList ID="drpCUROUT" DataTextField="MNAME1" DataValueField="MCODE" runat="server" Enabled="false" style="display:none;">
                    <asp:ListItem>請選擇</asp:ListItem>
                  </asp:DropDownList>
                  <asp:DropDownList ID="drpCUROUTF" Style="display: none" DataTextField="DNAME1" DataValueField="DCODE" runat="server" Enabled="false" Width="50%">
                    <asp:ListItem>請選擇</asp:ListItem>
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <th>
                  票信瑕疵
                </th>
                <td>
                  <asp:DropDownList ID="drpDEFECTIVE" class="bg_F5F8BE" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                    <asp:ListItem Value="Y">有</asp:ListItem>
                    <asp:ListItem Value="N">無</asp:ListItem>
                  </asp:DropDownList>
                </td>
                <td colspan='2'>
                  <span style="color: Red">說明： 此客戶（公司或負責人）近三年有無票信瑕疵</span>
                </td>
              </tr>
              <%--						
              <tr>
                   <th>虛擬帳號_和運</th>
                   <td>
                       <asp:TextBox ID="txtLLVLNUM01" runat="server" CssClass="txt_readonly" Width="50%" ReadOnly></asp:TextBox>
                   </td>
                   <th >虛擬帳號_和潤</th>
                   <td >
                       <asp:TextBox ID="txtLLVLNUM02" runat="server" CssClass="txt_readonly" Width="50%" ReadOnly></asp:TextBox>
                   </td>
                </tr>
                --%>
              <tr>
                <th>
                  決策人
                </th>
                <td colspan="3">
                  <input type="button" id="btnC1" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('1');" value="新增" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactM" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactM" class="tb_Contact" width="100%">
                          <tr>
                            <th>
                              刪除
                            </th>
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
                                  <asp:Button ID="btnMainDel" runat="server" Text="刪" OnClientClick="return ContactDelete('1',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTNAME" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtDEPTNAME" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTTITLE" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELCODE" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTEL" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTELEXT" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTMPHONE" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAXCODE" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTFAX" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="txtCONTACTEMAIL" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
              <tr>
                <th>
                  案件聯絡人
                </th>
                <td colspan="3">
                  <input type="button" id="btnC2" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('2');" value="新增" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactC" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactC" class="tb_Contact" width="100%">
                          <tr>
                            <th>
                              刪除
                            </th>
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
                                  <asp:Button ID="Button1" runat="server" Text="刪" OnClientClick="return ContactDelete('2',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox1" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblDEPTNAME" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTTITLE" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox2" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox3" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox4" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTMPHONE" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAXCODE" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="lblCONTACTFAX" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox5" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
              <tr>
                <th>
                  發票聯絡人
                </th>
                <td colspan="3">
                  <input type="button" id="btnC3" disabled="true" runat="server" class="btn_normal" onclick="ContactClick('3');" value="新增" />
                </td>
              </tr>
              <tr>
                <td colspan="4">
                  <div class="div_table" style="height: 150px; width: 735px; padding: 2px; overflow: scroll;">
                    <asp:UpdatePanel ID="UpdatePanelContactI" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <table id="tblContactI" class="tb_Contact" width="150%;">
                          <tr>
                            <th>
                              刪除
                            </th>
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
                                  <asp:Button ID="Button2" runat="server" Text="刪" OnClientClick="return ContactDelete('3',this)" Enabled='<%# btnDelEnable() %>' CssClass="btn_normal" Width="24px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox6" runat="server" Text='<%# Eval("CONTACTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox7" runat="server" Text='<%# Eval("DEPTNAME")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox8" runat="server" Text='<%# Eval("CONTACTTITLE")%>' Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox9" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox10" runat="server" Text='<%# Eval("CONTACTTEL")%>' Width="80px"></asp:TextBox>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox11" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' Width="40px" />
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox12" runat="server" Text='<%# Eval("CONTACTMPHONE")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox13" runat="server" Text='<%# Eval("CONTACTFAXCODE")%>' Width="24px" />
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox14" runat="server" Text='<%# Eval("CONTACTFAX")%>' Width="80px"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox CssClass="txt_table_readonly" ReadOnly="true" ID="TextBox15" runat="server" Text='<%# Eval("CONTACTEMAIL")%>'></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtINVZIPCODE" runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("INVZIPCODE")%>'></asp:TextBox>
                                  <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                                  <asp:TextBox ID="txtINVZIPCODES" runat="server" Width="120px" onfocus="ObjMFocus(this,'txtINVZIPCODES','txtINVOICEADDR');" CssClass="txt_table" Text='<%# Eval("INVZIPCODES")%>'></asp:TextBox>
                                  <asp:TextBox ID="txtINVOICEADDR" runat="server" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');" Width="150px" MaxLength="100" Text='<%# Eval("INVOICEADDR")%>'></asp:TextBox>
                                </td>
                              </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                        </table>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                </td>
              </tr>
            </table>
          </div>
          <%--客戶資料End --%>
          <%--案件&#61136;容Begin --%>
          <div id="fraTab22" class="div_content padleft_0 T_-120" style="display: none">
            <table cellpadding="1" cellspacing="1" class="tb_Info">
              <tr>
                <%--Modify 20150105 By SS Eric.   Reason:新增專案別--%>
                <th>
                    <%--20221031 改為隱藏--%>
                  <%--專案別--%>
                </th>
                <td >
                    <asp:DropDownList ID="drpPROJCD" class="bg_F5F8BE" runat="server" onchange="drpPROJCD_OnChange(this);" style="display:none">
                    <asp:ListItem Value="01">一般</asp:ListItem>
                    <asp:ListItem Value="02" Enabled="false">重車</asp:ListItem>
                    <asp:ListItem Value="03" Enabled="false">事務機</asp:ListItem>
                    </asp:DropDownList>
                </td>
              </tr>
              <tr>
                  <%--20221031 改為隱藏--%>
                <%--<th >
                  公司名稱
                </th>
                <td>--%>
                  <asp:DropDownList ID="drpCOMPID" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" style="display:none">
                  </asp:DropDownList>
                <%--</td>
                Modify 20120716 By SS Gordon. Reason: 新增承作方式.
                <th >
                  承作方式
                </th>
                <td >--%>
                  <asp:DropDownList ID="drpSOURCETYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpSOURCETYPE_SelectedIndexChanged" AutoPostBack="true" style="display:none">
                  </asp:DropDownList>
                <%--</td>--%>
                <th width="12%">
                  承作型態
                </th>
                <td width="12%">
                  <asp:DropDownList ID="drpMAINTYPE" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpMAINTYPE_SelectedIndexChanged" AutoPostBack="true">
                  </asp:DropDownList>
                </td>
                <td width="12%">
                  <asp:UpdatePanel ID="UpdatePaneldrpSUBTYPE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                      <asp:DropDownList ID="drpSUBTYPE" class="bg_F5F8BE" runat="server" DataTextField="DNAME1" DataValueField="DCODE" OnSelectedIndexChanged="drpSUBTYPE_SelectedIndexChanged" AutoPostBack="true">
                      </asp:DropDownList>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </td >
                <th width="12%">
                  交易形態
                </th>
                <td>
				  <asp:UpdatePanel ID="UpdatePaneldrpTRANSTYPE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="drpTRANSTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" OnSelectedIndexChanged="drpTRANSTYPE_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
				    </ContentTemplate>
                  </asp:UpdatePanel>
                </td>
                <th width="12%">
                    承作對象
                </th>
                <th width="12%">
                    <asp:DropDownList ID="drpCASESOURCE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                  </asp:DropDownList>
                </th>
                  <th width="12%">案件產品別 </th>
                      <th width="12%">
                          <asp:DropDownList ID="drpPRODCD" runat="server" class="bg_F5F8BE" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpPRODCD_SelectedIndexChanged" AutoPostBack="true">
                          </asp:DropDownList>
                      </th>
              </tr>
                <%--20221031 改為隱藏--%>
              <%--<tr>
                <th>
                  動用情形
                </th>
                <td>--%>
                  <asp:DropDownList ID="drpUSESTATUS" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" style="display:none">
                  </asp:DropDownList>
                <%--</td>
                <td >--%>
                  <asp:DropDownList ID="drpCYCLETYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" style="display:none">
                  </asp:DropDownList>
                <%--</td>--%>
<%--                <th>
                  代印店
                </th>
                <td>--%>
                <asp:UpdatePanel ID="UpdatePanelPRINTSTORE" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                      <asp:DropDownList ID="drpPRINTSTORE" DataTextField="MNAME1" DataValueField="MCODE" runat="server" style="display:none">
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                  </asp:DropDownList>
                    </ContentTemplate>
                  </asp:UpdatePanel>                 
                <%--</td>
                Modify 20120716 By SS Gordon. Reason: 新增銀行別.
                    <%--20221031 改為隱藏
                <th>
                  銀行別
                </th>                
                <td colspan="3">--%>
                  <asp:DropDownList ID="drpBANKCD" class="bg_F5F8BE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" Enabled="false" style="display:none">
                  </asp:DropDownList>
                <%--</td>
              </tr>--%>
              <%--<tr>
              <tr>
                  Modify 20130509 By SS Brent. Reason:加入附追索權下拉選單
                  <%--20221031 改為隱藏
                <th>
                  附追索權
                </th>
                <td colspan="2">--%>
                  <asp:UpdatePanel ID="UpdatePanelRECOURSE" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                          <asp:DropDownList ID="drpRECOURSE" runat="server" class="bg_F5F8BE" style="display:none">
                              <asp:ListItem Value="">請選擇</asp:ListItem>
                              <asp:ListItem Value="Y">是</asp:ListItem>
                              <asp:ListItem Value="N">否</asp:ListItem>
                          </asp:DropDownList>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                  <%--</td>
                      </tr>
                  <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 START-->
                  <!-- 20160321 ADD BY SS ADAM REASON.新增案件產品別 END-->
                </tr>--%>
            </table>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <div>
                  <div >
                    <table class="tb_Info" cellpadding="1" cellspacing="1">
                      <tr>
                        <td colspan="5">
                          <asp:RadioButton ID="rdoMLDCASEINST" Enabled="false" runat="server" />分期&#12289;租賃案件
                        </td>
                        <!--Modify 20130326 By SS Eric    Reason:新增保險異常欄位-->
                        <td colspan="1">
                            <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險異常事件-->
                            <asp:CheckBox ID="txtNOINSURANCEFLG" Enabled="false" runat="server" OnCheckedChanged="txtNOINSURANCEFLG_CheckedChanged" AutoPostBack="true" />保險異常
                        </td>
                      </tr>
                      <tr>
                        <th width="20%">
                          標的物金額
                        </th>
                        <td width="12%">
                          <asp:TextBox ID="txtTRANSCOST" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_must_right" ReadOnly="true"></asp:TextBox>
                           <asp:HiddenField ID="hidTRANSCOST" Value='0' runat="server" />
                        </td>
                        <td colspan="2">
                            <span style="color:red">若要更改標的物金額<br />請至「標的物」標籤中調整標的物價格</span>
                        </td>
                        <th width="12%">
                            <!--Modify 20130819 By SS CHRIS FU  Reason:新增保險費按鈕-->
                            <asp:Button ID="btINSURANCE" CssClass="btn_normal" runat="server" Text="..." OnClick="btINSURANCE_Click" Enabled="false" />
                          保險費
                        </th>
                        <td>
                          <asp:TextBox ID="txtINSURANCE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" enabled="false"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          頭期款
                        </th>
                        <td>
                          <asp:TextBox ID="txtFIRSTPAY" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                          佣金
                        </th>
                        <td>
                          <asp:TextBox ID="txtCOMMISSION" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>                          
                        </td>
                        <!--Modify 20120528 By SS Gordon. Reason: 修改「作業費用」為「作業費用(有發票)」-->
                        <th>
                          作業費用(有發票)
                        </th>
                        <td>
                          <asp:TextBox ID="txtOTHERFEES" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          租購保證金
                        </th>
                        <td>
                          <asp:TextBox ID="txtPURCHASEMARGIN" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);CalACTUSLLOANS();" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                        </th>
                        <td>
                        </td>
                        <!--Modify 20120528 By SS Gordon. Reason: 加入「作業費用(無發票)」-->
                        <th>                          
                          作業費用(無發票)
                        </th>
                        <td>
                          <asp:TextBox ID="txtOTHERFEESNOTAX" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>                        
                        </td>
                      </tr>
                      <tr>
                        <th>
                          履約保證金
                        </th>
                        <td>
                          <asp:TextBox ID="txtPERBOND" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                        <th>
                          實貸金額
                        </th>
                        <td>
                          <asp:TextBox ID="txtACTUSLLOANS" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" ReadOnly="true" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                          <%--20221031標的物金額改唯讀--%>
                            <asp:HiddenField ID="hidACTUSLLOANS" Value='0' runat="server" />
                        </td>
                        <th>
                          手續費收入
                        </th>
                        <td>
                          <asp:TextBox ID="txtFEE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" Text="0" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
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
                          <asp:TextBox ID="txtRESIDUALS" custprop="100" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <th>
                          總承作月數
                        </th>
                        <td>
                          <asp:TextBox ID="txtCONTRACTMONTH" onkeyup="txtCONTRACTMONTH_KeyUp(this);" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        </td>
                        <th>
                          幾月一付
                        </th>
                        <td>
                          <asp:TextBox ID="txtPAYMONTH" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        </td>
                        <th>
                          付款時間
                        </th>
                        <td>
                          <asp:DropDownList ID="drpPAYTIMET" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" Width="80px">
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
                                - 第<asp:TextBox ID="txtENDPAY1" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td width="18%">
                                期付款(未稅)
                              </td>
                              <td width="18%">
                                <asp:TextBox ID="txtPRINCIPAL1" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX1');MoneyBlur(this);MoneyNull(this,'txtENDPAY1');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="70px"></asp:TextBox>
                              </td>
                              <td width="18%">
                                期付款(含稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX1" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL1');MoneyBlur(this);MoneyNull(this,'txtENDPAY1');" MaxLength="9" runat="server" CssClass="txt_must_right" Width="70px"> </asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                第
                                <asp:TextBox ID="txtSTARTPAY2" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY1','txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                - 第<asp:TextBox ID="txtENDPAY2" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                期付款(未稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX2');MoneyBlur(this);MoneyNull(this,'txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                期付款(含稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX2" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL2');MoneyBlur(this);MoneyNull(this,'txtENDPAY2');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                第
                                <asp:TextBox ID="txtSTARTPAY3" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY2','txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                - 第<asp:TextBox ID="txtENDPAY3" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                期付款(未稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX3');MoneyBlur(this);MoneyNull(this,'txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                期付款(含稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX3" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL3');MoneyBlur(this);MoneyNull(this,'txtENDPAY3');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td>
                                第
                                <asp:TextBox ID="txtSTARTPAY4" onkeypress="OnlyNum(this);" onblur="checkPayS(this,'txtENDPAY3','txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                - 第<asp:TextBox ID="txtENDPAY4" onkeypress="OnlyNum(this);" onblur="checkPayE(this,'txtSTARTPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right" Width="24px"></asp:TextBox>
                                期
                              </td>
                              <td>
                                期付款(未稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPAL4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="AddTax(this,'txtPRINCIPALTAX4');MoneyBlur(this);MoneyNull(this,'txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                              <td>
                                期付款(含稅)
                              </td>
                              <td>
                                <asp:TextBox ID="txtPRINCIPALTAX4" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MinTax(this,'txtPRINCIPAL4');MoneyBlur(this);MoneyNull(this,'txtENDPAY4');" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                              </td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                      <tr>
                        <td colspan="6">&nbsp;</td>
                      </tr>
                    </table>
                  </div>
                    <%--20221031 改為隱藏--%>
                  <%--<div class="right_div" style="height: 282px;">
                    <table cellpadding="1" cellspacing="1" class="tb_Info">--%>
<%--                      <tr>
                        <td colspan="2">--%>
                          <asp:RadioButton ID="rdoMLDCASEARDATA" Enabled="false" runat="server" Visible="True" style="display:none" /><%--應收帳款案件--%>
<%--                        </td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          申請額度
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtAPLIMIT" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          徵信費
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtCREDITFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          帳務管理費
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtMANAGERFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          財務顧問費
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtFINANCIALFEES" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <!--Modify 20120604 By SS Gordon. Reason: AR新增履約保證金-->
                      <%--<tr>
                        <th>
                          履約保證金
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtARPERBOND" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          成數
                        </th>--%>
                        <%--Modify 20150205 By SS ChrisFu. Reason:「成數」由TextBox改為下拉選單--%>
                        <td>
                          <%--<asp:TextBox ID="txtPERCENTAGE" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right"></asp:TextBox>%--%>
                          <asp:DropDownList ID="drpPERCENTAGE" runat="server" DataTextField="MNAME1" DataValueField="MCODE" CssClass="bg_F5F8BE" Width="80px" Height="25px" style="display:none"></asp:DropDownList><%--%--%>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          帳款期限
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtACCOUNTSTERM" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox><%--月--%>
                        <%--</td>
                      </tr>--%>
                      <%--<tr style="display: none">--%>
                      <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
<%--                        <th>
                          付款時間
                        </th>
                        <td>
                          <asp:DropDownList ID="drpPAYTIMEA" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server" Width="80%">
                            <asp:ListItem>期初付</asp:ListItem>
                            <asp:ListItem>期末付</asp:ListItem>
                          </asp:DropDownList>
                        </td>--%>
                        <%--<td>--%>
                          <asp:DropDownList ID="drpPAYTIMEA" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" Style="display: none" runat="server" Width="80%" >
                            <asp:ListItem>期初付</asp:ListItem>
                            <asp:ListItem>期末付</asp:ListItem>
                          </asp:DropDownList>
                        <%--</td>
                      </tr>--%>
                      <%--<tr>
                        <th>
                          單一買方限額
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtBUYERLIMIT" Text="0" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>--%>
                      <%--<tr style="display: none">--%>
                      <%--Modify 20150120 By SS Eric.   Reason:「付款時間」.「建議承作IRR」設為隱藏--%>
<%--                        <th>
                          建議承作IRR
                        </th>
                        <td>
                          <asp:TextBox ID="txtARIRR" onkeypress="OnlyNumAndSpot(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="6" runat="server" CssClass="txt_must_right"></asp:TextBox>%
                        </td>--%>
                        <%--<td>--%>
                          <asp:TextBox ID="txtARIRR" onkeypress="OnlyNumAndSpot(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="6" Style="display: none" runat="server" CssClass="txt_must_right"></asp:TextBox>
                        <%--</td>--%>
                      <%--</tr>--%>
                      <%--Modify 20150205 By SS ChrisFu. Reason:「建議墊息款」設為隱藏，新增「建議墊款息」--%>
                      <%--<tr style="display: none">
                        <th>
                          建議墊息款
                        </th>
                        <td>--%>
                          <asp:TextBox ID="txtINTERSET" Text="0" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_normal_right" style="display:none"></asp:TextBox>
                        <%--</td>
                      </tr>
                      
                      <tr>
                          <th>建議墊款息</th>
                          <td>--%>
                              <asp:TextBox ID="txtADVANCESINTEREST" custprop="100" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);MoneyNull2(this);" MaxLength="3" runat="server" CssClass="txt_must_right" style="display:none"></asp:TextBox><%--%--%>
                          <%--</td>
                      </tr>--%>
                   <%-- </table>
                  </div>--%>
                </div>
              </ContentTemplate>
            </asp:UpdatePanel>
            <%--Modify 20150205 By SS ChrisFu. Reason:因承作型態變更為「應收帳款受讓」時，欄位內容要做更動，故加上UpdatePanel--%>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div style="clear: both;">
              <table cellpadding="1" cellspacing="1" class="tb_Info">
                <tr>
                  <th>
                    付款方式
                  </th>
                  <td colspan="2">
                    <asp:DropDownList ID="drpPAYTPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                    </asp:DropDownList>
                  </td>
                                                <th>選定專案
                                                </th>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="drpPROJECT" DataTextField="PRONAME" DataValueField="PROJID" runat="server" OnSelectedIndexChanged="drpPROJECT_SelectedIndexChanged"  AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="hidPROJECT" DataTextField="PROJID" DataValueField="DISCAMT" runat="server" AutoPostBack="true" Style="display: none">
                                                    </asp:DropDownList>
                                                    <%--<asp:HiddenField ID="hidPROJECT" runat="server" Value="0" />--%>
                                                    <asp:Button ID="btnPROJECT" runat="server" CssClass="btn_normal" Text="搜尋" OnClick="btnPROJECT_Click" />
                                                </td>
                </tr>
                <tr>
                  <th>
                    付款差異天數
                  </th>
                  <td>
                    <asp:TextBox ID="txtPATDAYS" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" runat="server" MaxLength="4" Text="0" CssClass="txt_must_right"></asp:TextBox>
                  </td>
                  <th>
                    付供應商天數
                  </th>
                  <td colspan="3">
                    <asp:TextBox ID="txtSUPPILERDAYS" onkeypress="OnlyNumAndMinus(this);" onblur="OnlyNumAndMinusBlur(this);MoneyZero(this);checkNum(this);" MaxLength="4" Text="0" runat="server" CssClass="txt_must_right"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <th>
                    預計期滿處理方式
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:DropDownList ID="drpEXPIREPROC" DataTextField="DNAME1" DataValueField="DCODE" runat="server">
                        </asp:DropDownList>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <!--Modify 20120528 By SS Gordon. Reason: 於案件內容頁簽將「說明」欄位的中文名稱變更為「案件說明」，並將欄位變更為可輸入100個中文字-->
                  <!--Modify 20130117 By    SEAN.   Reason: 於案件內容頁簽將「案件說明」欄位的中文名稱變更為「備註」-->
                  <th>
                    備註
                  </th>
                  <td colspan="3">
                  <!--Modify 20130326 By SS Eric    Reason:將txtEXPIREPROCDESC的 MaxLength="100" onblur="CheckMLength(this,100,'說明');"由100改成150-->
                    <asp:TextBox ID="txtEXPIREPROCDESC" MaxLength="150" onblur="CheckMLength(this,300,'說明');" runat="server" CssClass="txt_normal" Style="width: 98%"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <th>
                    IRR
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelIRR" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtIRR" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                    <%--Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0--%>
                    <%--20171012 ADD BY SS ADAM REASON.NPV成本對調(改為顯示4%) --%>
                    <th>
                    NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <%--<th>
                    NPV成本
                  </th>--%>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"  style="display: none;"></asp:TextBox><%--%--%>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
                  
                <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                <tr style="display:none;">
                  <th>
                    資金成本
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelCAP" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtCAPITALCOST" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" runat="server" MaxLength="9" Text="7" ReadOnly="true" CssClass="txt_normal_right"></asp:TextBox>%
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <%--Modify 20141204 By SS Eric    Reason:調整「NPV」.「NPV成本」欄位位置及新增「NPV2」.「NPV2成本」欄位--%>
                  <th>
                    融資件NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV2" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV2" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <th>
                    融資件NPV成本
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC2" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST2" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
				
				
                <%--20170706 ADD BY SS ADAM REASON.隱藏原本設備件融資件NPV,NPV成本  --%>
                <tr style="display:none;">
                  <th>
                  </th>
                  <td>
                  </td>
                  <%--Modify 20141204 By SS Eric    Reason:調整「NPV」.「NPV成本」欄位位置及新增「NPV2」.「NPV2成本」欄位--%>
                  <th>
                    設備件NPV
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNPV0" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPV0" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0.00" ReadOnly="true"></asp:TextBox>
                        <asp:HiddenField ID="hidNPV0" runat="server" Value="" />
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                  <th>
                    設備件NPV成本
                  </th>
                  <td>
                    <asp:UpdatePanel ID="UpdatePanelNRC0" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:TextBox ID="txtNPVRATECOST0" runat="server" MaxLength="5" CssClass="txt_readonly_right" Text="0" ReadOnly="true"></asp:TextBox>%
                        <asp:HiddenField ID="hidNPVRATECOST0" runat="server" Value="" />
					  </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
				
                <tr>
                  <th style="display: none;">
                    RECOVER TEST
                  </th>
                  <td colspan="5" style="display: none;">
                    <asp:TextBox ID="txtRECOVERTEST" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text="0" runat="server" CssClass="txt_readonly_right" ReadOnly="true"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td colspan="6" style="text-align: center; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                        <asp:Button ID="btnIRR" runat="server" CssClass="btn_normal" Text="試算" OnClick="btnIRR_Click" />
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
              </table>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--案件&#61136;容End --%>
          <%--標的物Begin --%>
          <div id="fraTab33" class="div_content T_-120" style="display: none">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:Button ID="btnMLDCASETARGETCopy" runat="server" OnClientClick="return btnMLDCASETARGETCopy_click();" CssClass="btn_normal" Text="標的物複製" OnClick="btnMLDCASETARGETCopy_Click" />
                <asp:HiddenField ID="hidMLDCASETARGETCopy" runat="server" />
                <asp:HiddenField ID="hidTargetFile" runat="server" />
                <asp:FileUpload ID="fldMLDCASETARGETEmport" runat="server" />
                <asp:Button ID="btnMLDCASETARGETEmport" runat="server" CssClass="btn_normal" Text="標的物匯入" OnClientClick="return CheckMLDCASETARGET();" OnClick="btnMLDCASETARGETEmport_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
              </ContentTemplate>
              <Triggers>
                <asp:PostBackTrigger ControlID="btnMLDCASETARGETEmport" />
              </Triggers>
            </asp:UpdatePanel>
            <div class="div_table" style="overflow: scroll; height: 200px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASETARGET" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASETARGET" class="tb_Contact" style="width: 1500px;">
                    <tr onclick="changeTag('rptMLDCASETARGET')">
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
                      <%--Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量--%>
                      <th>
                        製造廠商
                      </th>
                      <th>
                        廠牌
                      </th>
                      <th>
                        單位
                      </th>
                      <th>
                        數量
                      </th>
                      <th width="270px">
                        供應商
                      </th>
                      <th>
                        價格
                      </th>
                      <th>
                        價格未稅
                      </th>
                      <th>
                        耐用年限
                      </th>
                      
                    </tr>
                    <asp:Repeater ID="rptMLDCASETARGET" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpTARGETTYPE" onchange="drpTARGETTYPE_change(this);" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hidTARGETID" Value='<%# Eval("TARGETID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETNAME" Text='<%# Eval("TARGETNAME")%>' Width="120px" runat="server" CssClass="txt_must"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpTARGETSTATUS" DataTextField="MNAME1" DataValueField="MCODE" runat="server">
                              <asp:ListItem>新機</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETMODELNO" onblur="CheckMLength(this,'50');" MaxLength="50" Text='<%# Eval("TARGETMODELNO")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETMACHINENO" onblur="CheckMLength(this,'20');" MaxLength="20" Text='<%# Eval("TARGETMACHINENO")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <%--Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量--%>
                          <td>
                            <asp:TextBox ID="txtMANUFACTURER" Text='<%# Eval("MANUFACTURER")%>' runat="server" Width="160px" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETBRAND" Text='<%# Eval("TARGETBRAND")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETUNIT" Text='<%# Eval("TARGETUNIT")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETCOUNT" Text='<%# Eval("TARGETCOUNT")%>' runat="server" CssClass="txt_table" MaxLength="50"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSUPPLIERID" onkeypress="OnlyNumDUCase(this);" onblur="SUPPLIERID_onblur(this);" MaxLength="10" Text='<%# Eval("SUPPLIERID")%>' Width="80px" runat="server" CssClass="txt_must"></asp:TextBox>
                            <asp:Button ID="btnSUPPLIERID" CssClass="btn_normal" OnClientClick="return SupplierClick(this);" Style="padding: 2px; width: 25px;" runat="server" Text="&#8230;" />
                            <asp:TextBox ID="txtSUPPLIERIDS" Text='<%# Eval("SUPPLIERIDS")%>' runat="server" Width="160px" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtTARGETPRICE" onkeypress="OnlyNum(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICE").ToString()) %>' onfocus="MoneyFocus(this)" onblur="txtTARGETPRICE_onblur(this);txtTARGETPRICE_KeyUp(this);" runat="server" CssClass="txt_must_right"></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                            <asp:Label ID="lblTARGETPRICENOTAX" Text='<%# Itg.Community.Util.NumberFormat(Eval("TARGETPRICENOTAX").ToString()) %>' onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server"></asp:Label>
                          </td>
                          <td>
                            <asp:Label ID="lblDURABLELIFE" Text='<%# Eval("DURABLELIFE")%>' runat="server"></asp:Label>
                          </td>
                          
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:CheckBox ID="chkAr" Enabled="false" runat="server" style="display:none" />
                  <%--20221031 改為隱藏--%>
<%--                AR案件無標的物&nbsp;&nbsp;&nbsp;--%>
                <%--Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的勾選區塊.--%>
                <asp:CheckBox ID="chkBANK1" Enabled="false" runat="server" style="display:none" />
<%--                銀行案件無標的物--%>
              </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            設備存放地 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <br />
            <div class="div_table" style="overflow: scroll; height: 200px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASETARGETSTR" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table class="tb_Contact" style="width: 1200px;">
                    <tr onclick="changeTag('rptMLDCASETARGET')">
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
                      <th>
                        標的物項次
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASETARGETSTR" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASETARGET','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOREDZIPCODE" onkeypress="OnlyNum(this);" MaxLength="6" runat="server" Width="24px" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("STOREDZIPCODE")%>'></asp:TextBox>
                            <input type="button" id="btnCUSTZIPCODES" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtSTOREDZIPCODES" runat="server" Width="112px" CssClass="txt_table" onfocus="ObjMFocus(this,'txtSTOREDZIPCODES','txtSTOREDADDR');" Text='<%# Eval("STOREDZIPCODES")%>'></asp:TextBox>
                            <asp:TextBox ID="txtSTOREDADDR" runat="server" CssClass="txt_table" Width="150px" MaxLength="100" Text='<%# Eval("STOREDADDR")%>'></asp:TextBox>
                            <asp:HiddenField ID="hidSTOREDID" Value='<%# Eval("STOREDID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTNAME" MaxLength="10" Text='<%# Eval("CONTACTNAME")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:Button ID="btnCONTACT" CssClass="btn_normal" onfocus="ObjMFocus(this,'btnCONTACT','txtDEPTNAME');" OnClientClick="return btnCONTACT_click(this);" Style="padding: 2px; width: 25px;" runat="server" Text="&#8230;" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPTNAME" MaxLength="50" Text='<%# Eval("DEPTNAME")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTTITLE" MaxLength="20" Text='<%# Eval("CONTACTTITLE")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTTELCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="3" runat="server" Text='<%# Eval("CONTACTTELCODE")%>' CssClass="txt_table" />
                            <asp:TextBox ID="txtCONTACTTEL" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTTEL")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:TextBox ID="txtCONTACTTELEXT" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="5" runat="server" Text='<%# Eval("CONTACTTELEXT")%>' CssClass="txt_table" Width="40px" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTMPHONE" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTMPHONE")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTFAXCODE" Width="20px" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="3" runat="server" Text='<%# Eval("CONTACTFAXCODE") %>' CssClass="txt_table" />
                            <asp:TextBox ID="txtCONTACTFAX" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" MaxLength="10" Text='<%# Eval("CONTACTFAX")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCONTACTEMAIL" onblur="EMAILBlur(this);" MaxLength="50" Text='<%# Eval("CONTACTEMAIL")%>' runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpMLDCASETARGET" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <asp:CheckBox ID="chkOneMLDCASETARGETSTR" Checked="false" AutoPostBack="true" runat="server" OnCheckedChanged="chkOneMLDCASETARGETSTR_CheckedChanged" />
                標的物存放地僅一處
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--標的務End --%>
          <%--擔保條件Begin --%>
          <div id="fraTab44" class="div_content T_-120" style="min-height: 730px; height: auto !important; display: none">
            保證人<asp:CheckBox ID="chkMLDCASEGUARANTEE" runat="server" Checked="true" />
            本案無保證人 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEGUARANTEE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEGUARANTEE" class="tb_Contact" style="width: 2400px;">
                    <tr onclick="changeTag('rptMLDCASEGUARANTEE')">
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
                      <%--Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
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
                      <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                      <th>
                        職業
                      </th>
                      <th>
                        任職公司
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASEGUARANTEE" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEGUARANTEE','<%# Container.ItemIndex  %>')">
                          <td>
                            <%--Modify 20121112 By SS Steven. Reason: 登打保人條件時，系統依個人或法人判別，非必要之登打條件以反灰呈現--%>
                            <%--<asp:DropDownList ID="drpGRTTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" onchange="CboChanged(this);" runat="server" Width="80%">--%>
                            <asp:DropDownList ID="drpGRTTYPE" DataTextField="MNAME1" DataValueField="MCODE" class="bg_F5F8BE" onchange="CboChanged(this);" runat="server" Width="80%" OnSelectedIndexChanged="drpGRTTYPE_SelectedIndexChanged" AutoPostBack="true">
                              <asp:ListItem>法人</asp:ListItem>
                              <asp:ListItem>個人</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hidGRTID" Value='<%# Eval("GRTID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtGRTNAME" Text='<%# Eval("GRTNAME") %>' MaxLength="20" runat="server" CssClass="txt_must_table" Width="80"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtGRTCODE" Text='<%# Eval("GRTCODE") %>' MaxLength="10" onkeypress="OnlyNumDUCase(this);" onblur="idBlur(this);" runat="server" CssClass="txt_must_table" Width="80"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpGUARANTEEBILL" runat="server" Width="80%">
                              <asp:ListItem Value="1">是</asp:ListItem>
                              <asp:ListItem Value="2">否</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpGUARANTEEBILLTYPE" runat="server" Width="80%">
                              <asp:ListItem Value="1">本票</asp:ListItem>
                              <asp:ListItem Value="2">支票</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtGUARANTEEANOUNT" Text='<%# Itg.Community.Util.NumberFormat(Eval("GUARANTEEANOUNT").ToString()) %>' MaxLength="9" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <%--Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司--%>
                          <td>
                            <asp:TextBox ID="txtGRTBIRDT" Text='<%# Eval("GRTBIRDT") %>' runat="server"  Width="80px"  CssClass="txt_table" onfocus="dateFocus(this)" onblur="dateBlur(this);"></asp:TextBox>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTSEX" runat="server"  Width="50px">
                                <asp:ListItem Value="">請選擇</asp:ListItem>
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="2">女</asp:ListItem>                          
                              </asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTRESIDENTZIP" Text='<%# Eval("GRTRESIDENTZIP") %>' runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                              <input type="button" id="btnGRTRESIDENTZIP" class="btn_normal" onclick="PostCodeClick(this);" runat="server" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                              <asp:TextBox ID="txtGRTRESIDENTZIPNM" Text='<%# Eval("GRTRESIDENTZIPNM") %>' runat="server" Width="120px" onfocus="ObjMFocus(this,'txtGRTRESIDENTZIPNM','txtGRTRESIDENTADDR');" CssClass="txt_table"></asp:TextBox>
                              <asp:TextBox ID="txtGRTRESIDENTADDR" Text='<%# Eval("GRTRESIDENTADDR") %>' runat="server" Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');" MaxLength="100"></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTZIP" Text='<%# Eval("GRTZIP") %>' runat="server"  Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table"></asp:TextBox>
                              <input type="button" id="btnGRTZIP" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                              <asp:TextBox ID="txtGRTZIPNM" Text='<%# Eval("GRTZIPNM") %>' runat="server"  Width="120px" onfocus="ObjMFocus(this,'txtGRTZIPNM','txtGRTADDR');" CssClass="txt_table"></asp:TextBox>
                              <asp:TextBox ID="txtGRTADDR" Text='<%# Eval("GRTADDR") %>' runat="server"  Width="150px" CssClass="txt_table" onblur="CheckMLength(this,'100','發票寄送地');" MaxLength="100"></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTTELCODE" Text='<%# Eval("GRTTELCODE") %>' runat="server" Width="24px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>                              
                              <asp:TextBox ID="txtGRTTEL" Text='<%# Eval("GRTTEL") %>' runat="server" Width="80px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                              <asp:TextBox ID="txtGRTTELEXT" Text='<%# Eval("GRTTELEXT") %>' runat="server" Width="40px" CssClass="txt_table" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);"></asp:TextBox>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTRELATION1" runat="server" Width="180px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTRELATION2" runat="server" Width="105px" DataTextField="MNAME1" DataValueField="MCODE"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="drpGRTJOBCLS" runat="server" Width="160px" DataTextField="MNAME1" DataValueField="MCODE" OnSelectedIndexChanged="drpGRTJOBCLS_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          </td>
                          <%--Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業. --%>
                          <td>
                            <asp:DropDownList ID="drpGRTJOB" runat="server" Width="220px" DataTextField="DNAME1" DataValueField="DCODE">
                              <asp:ListItem Value="">非醫師</asp:ListItem>
                              <asp:ListItem Value="01">醫師</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="txtGRTCOMPANY" Text='<%# Eval("GRTCOMPANY") %>' runat="server" Width="200px" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            動產設定<asp:CheckBox ID="chkMLDCASEMOVABLE" runat="server" Checked="true" />
            本案無動產設定 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEMOVABLE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEMOVABLE" class="tb_Contact" style="width: 1200px;">
                    <tr onclick="changeTag('rptMLDCASEMOVABLE')">
                      <th>
                        項次
                      </th>
                      <th>
                        複製
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
                    <asp:Repeater ID="rptMLDCASEMOVABLE" runat="server" OnItemCommand="MLDCASEMOVABLE_ItemCommand">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
							<%# Container.ItemIndex +1 %>
                            
                          </td>
                          <td>
                              <asp:Button ID="btnCOPY1" runat="server" Text="複製" CommandName="CopyRowData1" CommandArgument='<%# Container.ItemIndex  %>' />
                          </td>                            
                          <td>
                            <asp:TextBox ID="txtMOVABLENAME" Text='<%# Eval("MOVABLENAME")%>' MaxLength="20" onblur="CheckMLength(this,'20');" runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:HiddenField ID="hidMOVABLEID" Value='<%# Eval("MOVABLEID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:DropDownList ID="drpMOVABLEETARGET" runat="server" Width="60px">
                              <asp:ListItem Value="1">是</asp:ListItem>
                              <asp:ListItem Value="2">否</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEZIPCODE" runat="server" Width="24px" MaxLength="6" onkeypress="OnlyNum(this);" onblur="PostCodeBlure(this)" CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODE")%>'></asp:TextBox>
                            <input type="button" id="btnMOVABLEZIPCODE" class="btn_normal" onclick="PostCodeClick(this);" onfocus="ObjFocus(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtMOVABLEZIPCODES" onfocus="ObjMFocus(this,'txtMOVABLEZIPCODES','txtMOVABLEADDR');" runat="server" Width="112px" CssClass="txt_table" Text='<%# Eval("MOVABLEZIPCODES")%>'></asp:TextBox>
                            
							<%-- 2013/09/13 Edit by Sean 動產設定所在地欄位可輸入50個中文字 --%>
                            <%--<asp:TextBox ID="txtMOVABLEADDR" runat="server" CssClass="txt_table" MaxLength="20" Width="150px" onblur="CheckMLength(this,'20');" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>--%>
                            <asp:TextBox ID="txtMOVABLEADDR" runat="server" CssClass="txt_table" MaxLength="50" Width="150px" onblur="CheckMLength(this,'100');" Text='<%# Eval("MOVABLEADDR")%>'></asp:TextBox>
							
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLENO" Text='<%# Eval("MOVABLENO")%>' runat="server" MaxLength="20" onblur="CheckMLength(this,'20');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEYEAR" Text='<%# Eval("MOVABLEYEAR") %>' runat="server" MaxLength="4" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEBUYDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("MOVABLEBUYDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLENEWAMT" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLENEWAMT").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLEBUYAMT" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLEBUYAMT").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLERESIDUALS" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLERESIDUALS").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtMOVABLERESETPRICE" Text='<%# Itg.Community.Util.NumberFormat(Eval("MOVABLERESETPRICE").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            不動產設定<asp:CheckBox ID="chkMLDCASEIMMOVABLE" runat="server" Checked="true" />
            本案無不動產設定 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEIMMOVABLE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEIMMOVABLE" class="tb_Contact" width="1150px" border="1">
                    <tr onclick="changeTag('rptMLDCASEIMMOVABLE')">
                      <th>
                        項次
                      </th>
                      <th>
                        複製
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
                        持分面積
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
                    <asp:Repeater ID="rptMLDCASEIMMOVABLE" runat="server" OnItemCommand="MLDCASEIMMOVABLE_ItemCommand">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEIMMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
							<%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                              <asp:Button ID="btnCOPY2" runat="server" Text="複製" CommandName="CopyRowData2" CommandArgument='<%# Container.ItemIndex  %>' />
                          </td>                           
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEOWNER" Text='<%# Eval("IMMOVABLEOWNER")%>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <asp:HiddenField ID="hidIMMOVABLEID" Value='<%# Eval("IMMOVABLEID") %>' runat="server" />
                          <td>
                            
							<%-- 20131212 Edit by Sean 新增統編及ID判斷 --%>
                            <asp:TextBox ID="txtIMMOVABLEOWNERID" Text='<%# Eval("IMMOVABLEOWNERID")%>' onkeypress="OnlyNumD(this);" onblur="idAndBANBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                            <%-- <asp:TextBox ID="txtIMMOVABLEOWNERID" Text='<%# Eval("IMMOVABLEOWNERID")%>' onkeypress="OnlyNumD(this);" onblur="idBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox> --%>
						  
						  </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEGETDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEGETDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("IMMOVABLEBUILDDATE").ToString()) %>' runat="server" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLESECTOR" Text='<%# Eval("IMMOVABLESECTOR")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILD" Text='<%# Eval("IMMOVABLEBUILD")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEAREA" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" Text='<%# Eval("IMMOVABLEAREA")%>' runat="server" MaxLength="10" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEHOLDER" onkeypress="OnlyNumAndSpot(this);" onblur="OnlyNumAndSpotBlur(this);" Text='<%# Eval("IMMOVABLEHOLDER")%>' runat="server" MaxLength="10" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDNO" Text='<%# Eval("IMMOVABLEBUILDNO")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEHOUSENUM" Text='<%# Eval("IMMOVABLEHOUSENUM")%>' runat="server" MaxLength="50" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtIMMOVABLEBUILDAREA" onkeypress="OnlyNumAndSpot(this);" Text='<%# Eval("IMMOVABLEBUILDAREA")%>' MaxLength="8" onblur="areacon(this)" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td style="text-align: right;">
                            <asp:Label ID="lblIMMOVABLEBUILDAREA" Text='<%# Convert.ToDouble(Eval("IMMOVABLEBUILDAREAS")).ToString("0.00") %>' runat="server"></asp:Label>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDHUMANRIGHTS" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <%--Modify 20130425 By SS Steven. Reason: 擔保條件的不動產權利人明細欄位檢核--%>
                  <%--<table class="tb_Contact" border="1">--%>
                  <table id="tblMLDHUMANRIGHTS" class="tb_Contact" border="1">
                    <tr onclick="changeTag('rptMLDCASEIMMOVABLE')">
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
                        不動產順位設定
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDHUMANRIGHTS" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEIMMOVABLE','<%# Container.ItemIndex  %>')">
                          <td>
                            <%# Container.ItemIndex +1 %>
                          </td>
                          <td>
                            <asp:TextBox ID="txtHUMANRIGHTS" Text='<%# Eval("HUMANRIGHTS") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtREGISTDATE" onkeypress="OnlyNum(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("REGISTDATE").ToString()) %>' MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSETPRICE" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text='<%# Itg.Community.Util.NumberFormat(Eval("SETPRICE").ToString()) %>' runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtCREDITOR" Text='<%# Eval("CREDITOR") %>' runat="server" MaxLength="10" onblur="CheckMLength(this,'10');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <!--<asp:DropDownList ID="drpMLDCASEIMMOVABLE" AutoPostBack="true" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>-->
							<asp:TextBox ID="txtMLDCASEIMMOVABLE" runat="server" MaxLength="2" Width="24px" onkeypress="OnlyNum(this);"  CssClass="txt_table" Text='<%# Eval("IDMEMO") %>' />
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            定存單質押<asp:CheckBox ID="chkMLDCASEADEPOSIT" runat="server" Checked="true" />
            本案無定存單設定 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEADEPOSIT" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEADEPOSIT" class="tb_Contact" width="90%">
                    <tr onclick="changeTag('rptMLDCASEADEPOSIT')">
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
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEADEPOSIT','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtDEPOSITBANKS" onfocus="this.parentNode.childNodes[2].focus()" CssClass="txt_normal" Text='<%# Eval("DEPOSITBANKS") %>' Width="240px" runat="server"></asp:TextBox>
                            <input type="button" id="Button9" class="btn_normal" onclick="BankClick(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtDEPOSITBANK" Style="display: none" Text='<%# Eval("DEPOSITBANK") %>' Width="427px" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidDEPOSITID" Value='<%# Eval("DEPOSITID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITNBR" Text='<%# Eval("DEPOSITNBR") %>' onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);" Width="120px" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITAMT" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" Text='<%#  Itg.Community.Util.NumberFormat(Eval("DEPOSITAMT").ToString()) %>' runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITSTARTDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITSTARTDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtDEPOSITDUEDATE" Text='<%# Itg.Community.Util.GetRepYear(Eval("DEPOSITDUEDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            客票<asp:CheckBox ID="chkMLDCASEBILLNOTE" runat="server" Checked="true" />
            本案無客票 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASEBILLNOTE" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASEBILLNOTE" class="tb_Contact" width="140%">
                    <tr onclick="changeTag('rptMLDCASEBILLNOTE')">
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
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASEBILLNOTE','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtBILLNOTEDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEDATE").ToString()) %>' onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" MaxLength="8" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEBANKS" CssClass="txt_normal" onfocus="this.parentNode.childNodes[2].focus()" Text='<%# Eval("BILLNOTEBANKS") %>' Width="240px" runat="server"></asp:TextBox>
                            <input type="button" id="Button9" class="btn_normal" onclick="BankClick(this);" style="width: 25px; padding: 2px;" value="&#8230;" />
                            <asp:TextBox ID="txtBILLNOTEBANK" Style="display: none" Text='<%# Eval("BILLNOTEBANK") %>' Width="427px" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidBILLNOTEID" Value='<%# Eval("BILLNOTEID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:DropDownList ID="drpBILLNOTETYPE" runat="server" Width="60px">
                              <asp:ListItem Value="1">本票</asp:ListItem>
                              <asp:ListItem Value="2">支票</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTENBR" Text='<%# Eval("BILLNOTENBR") %>' MaxLength="20" onkeypress="OnlyNumD(this);" onblur="OnlyNumDBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtACCOUNT" Text='<%# Eval("ACCOUNT") %>' onkeypress="OnlyNum(this);" Width="128px" onblur="OnlyNumBlur(this);" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTECUSTNAME" Text='<%# Eval("BILLNOTECUSTNAME") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEAMT" Text='<%#  Itg.Community.Util.NumberFormat(Eval("BILLNOTEAMT").ToString())  %>' onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this)" onblur="MoneyBlur(this);" MaxLength="9" runat="server" CssClass="txt_table_right"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTENOTE" Text='<%# Eval("BILLNOTENOTE") %>' runat="server" MaxLength="50" onblur="CheckMLength(this,'50');" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtBILLNOTEBACKDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("BILLNOTEBACKDATE").ToString()) %>' MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            股票<asp:CheckBox ID="chkMLDCASESTOCK" runat="server" Checked="true" />
            本案無股票 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: Red"> [ 新增請按F8&nbsp;&nbsp;&nbsp;刪除請按F9 ]</span>
            <div class="div_table" style="overflow: scroll; height: 100px"">
              <asp:UpdatePanel ID="UpdatePanelMLDCASESTOCK" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table id="tblMLDCASESTOCK" class="tb_Contact" width="100%">
                    <tr onclick="changeTag('rptMLDCASESTOCK')">
                      <th width="10%">
                        設定日期
                      </th>
                      <th width="10%">
                        股票名稱
                      </th>
                      <th width="10%">
                        提供人
                      </th>
                      <th width="10%">
                        單位(股)
                      </th>
                      <th width="10%">
                        張數
                      </th>
                      <th width="10%">
                        總數(股)
                      </th>
                      <th width="10%">
                        開始號
                      </th>
                      <th width="10%">
                        截止號
                      </th>
                      <th width="10%">
                        保險箱
                      </th>
                      <th width="10%">
                        備註
                      </th>
                    </tr>
                    <asp:Repeater ID="rptMLDCASESTOCK" runat="server">
                      <ItemTemplate>
                        <tr onmouseover="MouseOver(event)" onmouseout="MouseOut(event)" onmousedown="MouseDown(event);markSelRow('rptMLDCASESTOCK','<%# Container.ItemIndex  %>')">
                          <td>
                            <asp:TextBox ID="txtSTOCKDATE" Text='<%#  Itg.Community.Util.GetRepYear(Eval("STOCKDATE").ToString()) %>' MaxLength="8" onfocus="dateFocus(this)" onblur="dateBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                            <asp:HiddenField ID="hidSTOCKID" Value='<%# Eval("STOCKID") %>' runat="server" />
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKNAME" Text='<%# Eval("STOCKNAME") %>' onblur="CheckMLength(this,'20');" MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKPROVIDER" Text='<%# Eval("STOCKPROVIDER") %>' MaxLength="20" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKUNIT" Text='<%# Eval("STOCKUNIT") %>' MaxLength="20" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKQUANTITY" onkeypress="OnlyNum(this);" Text='<%# Eval("STOCKQUANTITY") %>' MaxLength="9" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKTOTAL" onkeypress="OnlyNum(this);" Text='<%# Eval("STOCKTOTAL") %>' MaxLength="9" onblur="OnlyNumBlur(this);" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKBEGIN" Text='<%# Eval("STOCKBEGIN") %>' runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKEND" Text='<%# Eval("STOCKEND") %>' runat="server" MaxLength="10" onkeypress="OnlyNum(this);" onblur="OnlyNumBlur(this);" CssClass="txt_table"></asp:TextBox>
                          </td>
                          <td>
                            <asp:DropDownList ID="drpSTOCKINSURANCE" runat="server" Width="60px">
                              <asp:ListItem Value="1">集保</asp:ListItem>
                              <asp:ListItem Value="2">實體</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                          <td>
                            <asp:TextBox ID="txtSTOCKNOTE" Text='<%# Eval("STOCKNOTE") %>' MaxLength="10" onblur="CheckMLength(this,'10');" runat="server" CssClass="txt_table"></asp:TextBox>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
            <br />
            其他<br />
            <asp:TextBox ID="txtOTHERCOND" MaxLength="100" onblur="CheckMLength(this,'100','其他');" runat="server" CssClass="txt_normal" Width="80%"></asp:TextBox>
          </div>
          <%--擔保條件End --%>
          <%--徵審資料Begin --%>
          <div id="fraTab55" class="div_content T_-120" style="display: none">
            <asp:UpdatePanel ID="UpdatePanelMLDCASEAPPENDDOC" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
                <table id="tblMLDCASEAPPENDDOC" class="tb_Text" width="98%">
                  <tr>
                    <th width="5%">
                      項次
                    </th>
                    <th width="52%">
                      文件
                    </th>
                    <th width="15%">
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
                          <asp:Label ID="lblDocName" runat="server" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' Text='<%# Eval("DNAME1")%>'></asp:Label>
<%--                          <asp:DropDownList ID="drpDocName" AutoPostBack="true" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged" Visible='<%# !Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Width="100%">
                          </asp:DropDownList>--%>
                          <asp:HiddenField ID="hidAPPENDDOCID" Value='<%# Eval("APPENDDOCID") %>' runat="server" />
                          <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                        </td>
                        <td>
                          <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                        </td>
                        <td>
                          <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>' runat="server" Visible="true" />
                        </td>
                        <td>
                          <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,'50');" Text='<%# Eval("NOTE") %>' runat="server" CssClass="txt_table" Width="100px" Visible="true"></asp:TextBox>
                        </td>
                      </tr>
                    </ItemTemplate>
                  </asp:Repeater>

                  <asp:Repeater ID="rptMLDCASEAPPENDDOC1" runat="server">
                    <ItemTemplate>
                      <tr>
                        <td>
                          <%# Container.ItemIndex +1 %>
                        </td>
                        <td>
                          <asp:Label ID="lblDocName" runat="server" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' Text='<%# Eval("DNAME1")%>'></asp:Label>
<%--                          <asp:DropDownList ID="drpDocName" AutoPostBack="true" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged" Visible='<%# !Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Width="100%">
                          </asp:DropDownList>--%>
                          <asp:HiddenField ID="hidAPPENDDOCID" Value='<%# Eval("APPENDDOCID") %>' runat="server" />
                          <asp:HiddenField ID="hidDocID" Value='<%# Eval("DCODE") %>' runat="server" />
                        </td>
                        <td>
                          <asp:Label ID="lblDName2" Visible='<%# Convert.ToBoolean(((Eval("SLABEL").ToString())=="") ? "False": Eval("SLABEL")) %>' runat="server" Text='<%# Eval("DNAME2")%>'></asp:Label>
                        </td>
                        <td>
                          <asp:CheckBox ID="chkDOCCONFIRM" Checked='<%# Convert.ToBoolean(Eval("DOCCONFIRM")) %>' runat="server" style="display:none" />
                        </td>
                        <td>
                          <asp:TextBox ID="txtNOTE" MaxLength="50" onblur="CheckMLength(this,'50');" Text='<%# Eval("NOTE") %>' runat="server" CssClass="txt_table" Width="100px" style="display:none"></asp:TextBox>
                        </td>
                      </tr>
                    </ItemTemplate>
                  </asp:Repeater>

                </table>
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
          <%--徵審資料End --%>
          <%--案件報告Begin --%>
          <div id="fraTab77" class="div_content T_-120" style="display: none">
            <!-- 20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個 -->
            <%--<asp:Button ID="btnUpload" OnClientClick="addFile();return false;" runat="server" CssClass="btn_normal" Text="附加檔案" />--%>
            <asp:Button ID="btnUpload" OnClientClick="addFile('1');return false;" runat="server" CssClass="btn_normal" Text="進件資料1" />
            <asp:TextBox ID="txtFileName" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID" runat="server" Value="" />
            <%--<asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="報告下載" />--%>
            <asp:Button ID="btnOnload" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="檔案下載" /> 
            <br />
            <asp:Button ID="btnUpload2" OnClientClick="addFile('2');return false;" runat="server" CssClass="btn_normal" Text="進件資料2" />
            <asp:TextBox ID="txtFileName2" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID2" runat="server" Value="" />
            <asp:Button ID="btnOnload2" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="檔案下載" /> 
            <br />
            <asp:Button ID="btnUpload3" OnClientClick="addFile('3');return false;" runat="server" CssClass="btn_normal" Text="進件資料3" />
            <asp:TextBox ID="txtFileName3" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID3" runat="server" Value="" />
            <asp:Button ID="btnOnload3" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="檔案下載" /> 
            <br />
            <asp:Button ID="btnUpload4" OnClientClick="addFile('4');return false;" runat="server" CssClass="btn_normal" Text="進件資料4" />
            <asp:TextBox ID="txtFileName4" runat="server" ReadOnly="true" CssClass="txt_readonly" Width="260px"></asp:TextBox>
            <asp:HiddenField ID="hidFileID4" runat="server" Value="" />
            <asp:Button ID="btnOnload4" OnClientClick="return false;" runat="server" CssClass="btn_normal" Text="檔案下載" /> 
          </div>
          <%--案件報告End --%>
          <%--往來查詢Begin --%>
          <div id="fraTab66" class="div_content T_-120" style="display: none">
            <div class="div_table" style="overflow: scroll; height: 500px">
              <asp:UpdatePanel ID="UpdatePanelrptData" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <table width="900px" cellpadding="0" cellspacing="0" class="tab_result" style="margin: 4px;">
                    <tr>
                      <th>
                        類型
                      </th>
                      <th>
                        合約編號
                      </th>
                      <th>
                        車型/承作標的
                      </th>
                      <th>
                        保證金
                      </th>
                      <th>
                        實繳總金額
                      </th>
                      <th>
                        未到期租金總額
                      </th>
                      <th>
                        租期
                      </th>
                      <th>
                        已繳期數
                      </th>
                      <th>
                        已繳金額總額
                      </th>
                    </tr>
                    <asp:Repeater ID="rptData" runat="server">
                      <ItemTemplate>
                        <tr>
                          <td>
                            <%#Eval("CTYPE")%>
                          </td>
                          <td>
                            <%#Eval("CNTRNO")%>
                          </td>
                          <td>
                            <%#Eval("TNAME")%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("GUARAMT").ToString())%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("ACTUSLLOANS").ToString())%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTN").ToString())%>
                          </td>
                          <td>
                            <%#Eval("CONTRACTMONTH")%>
                          </td>
                          <td>
                            <%#Eval("CONTRACTMONTHY")%>
                          </td>
                          <td>
                            <%# Itg.Community.Util.NumberFormat(Eval("AMOUNTY").ToString())%>
                          </td>
                        </tr>
                      </ItemTemplate>
                    </asp:Repeater>
                  </table>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>
          </div>
          <%--往來查詢End --%>
        </div>
        <div class="btn_div">
          <asp:Button ID="cmdPrintReportA" runat="server" Text="列印核准書" CssClass="btn_normal" OnClientClick="javascipt:return cmdPrintA_onClick(this);" Width="90" />
          <asp:Button ID="btnSave" Enabled="false" runat="server" Text="暫存" CssClass="btn_normal" OnClick="btnSave_Click" />
          <asp:Button ID="btnSubmit" Enabled="false" runat="server" Text="作業確認" CssClass="btn_normal" OnClick="btnSubmit_Click" />
          <!--Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.-->
          <asp:Button ID="btnRej" Enabled="false" runat="server" Text="案件撤件" CssClass="btn_normal" OnClick="btnRej_Click" />

          <asp:Button ID="btnAddCon" Style="display: none" runat="server" Text="" OnClick="btnAddCon_Click" />
          <asp:Button ID="btnDelCon" Style="display: none" runat="server" Text="" OnClick="btnDelCon_Click" />
          <asp:DropDownList ID="droDocMain" runat="server" Style="display: none" OnSelectedIndexChanged="droDocMain_SelectedIndexChanged">
          </asp:DropDownList>
          <asp:DropDownList ID="droIMMOVABLEID" runat="server" Style="display: none" OnSelectedIndexChanged="droIMMOVABLEID_SelectedIndexChanged">
          </asp:DropDownList>
          <asp:DropDownList ID="drpCODE" Style="display: none;" class="bg_F5F8BE" runat="server" Width="80px" DataTextField="MNAME1" DataValueField="MCODE">
          </asp:DropDownList>
          <asp:Button ID="btnAddRow" Style="display: none" runat="server" Text="" OnClick="btnAddRow_Click" />
          <asp:Button ID="btnDelRow" Style="display: none" runat="server" Text="" OnClick="btnDelRow_Click" />
          <%--Modify 20120621 By SS Gordon. Reason: 新增隱藏欄位以儲存案件資料供修改後的檢核 --%>
          <asp:HiddenField ID="hidPreTRANSCOST" runat="server" Value="" />
          <asp:HiddenField ID="hidPreCONTRACTMONTH" runat="server" Value="" />
          <asp:HiddenField ID="hidPreAPLIMIT" runat="server" Value="" />
          <asp:HiddenField ID="hidPrePERCENTAGE" runat="server" Value="" />
          <asp:HiddenField ID="hidPreACCOUNTSTERM" runat="server" Value="" />
          <asp:HiddenField ID="hidPreBUYERLIMIT" runat="server" Value="" />
          <asp:HiddenField ID="hidPreARIRR" runat="server" Value="" />
          <%--Modify 20121112 By SS Steven. Reason: 新增隱藏欄位來做判斷--%>
          <asp:HiddenField ID="hidCheckCONTRACTMONTH" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckTRANSCOST" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckIRR" runat="server" Value="" />
          <asp:HiddenField ID="hidCheckARIRR" runat="server" Value="" />
			<%--Modify 20130528 BY SEAN. Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」--%>
          <asp:HiddenField ID="hidCheckACTUSLLOANS" runat="server" Value="" />
        </div>
      </div>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>
