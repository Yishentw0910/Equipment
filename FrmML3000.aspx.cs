/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3000																					
* 程式功能  : 案件申請維護																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法.
Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，撥差金額計算公式中，由NPV成本計算改成資金成本計算.
Modify 20120528 By SS Gordon. Reason: 檢核客戶資料中，「發票聯絡人」列為必輸入欄位
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
Modify 20120613 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
Modify 20120621 By SS Gordon. Reason: 案件資料另外儲存，以便修改後的檢核
Modify 20120716 By SS Gordon. Reason: 新增承作方式.
Modify 20120716 By SS Gordon. Reason: 新增銀行別.
Modify 20120716 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」
Modify 20120716 By SS Gordon. Reason: 修改若承作方式為「銀行件」時，顯示新增徵審資料項目，否則不顯示
Modify 20120716 By SS Gordon. Reason: 修改若承作方式為「銀行件」時，當修改案件時，承作型態與銀行別不可選擇
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"4F"改成"4X"
Modify 20121115 By SS Gordon. Reason: 將保證人為醫生的代碼由01改成27
Modify 20121108 By SS Steven. Reason: 設備台新策盟案件則有另外的IRR成本
Modify 20121108 By SS Steven. Reason: 修改設備事務機案件的系統保險費成本計算邏輯
Modify 20121112 By SS Steven. Reason: 承作方式為銀行件的情況下，承作型態2選項就選原物料分期並且反灰
Modify 20121112 By SS Steven. Reason: 以下三個條件有一個成立，跳出視窗訊息提醒，假如是作業確認就要發email通知
                                      1.現在撥款金額 >  原案金額
                                      2.現在期數     >  原案期數
                                      3.現在IRR      <= 原案IRR
Modify 20121112 By SS Steven. Reason: 登打保人條件時，系統依個人或法人判別，非必要之登打條件以反灰呈現
Modify 20121123 By SS ADAM. Reason:只要三個條件成立，不需要發MAIL
Modify 20121129 By SS Steven. Reason:輸入保證人ID檢核function修正
Modify 20121224 By SS Gordon. Reason:修正案件資料另外儲存，以便修改後的檢核。檢核資料從PRE資料表取得
Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
Modify 20130114 By    Sean    Reason:營租/AR件，即不檢核第一段期付款輸入需大於 0
Modify 20130326 By SS Eric    Reason:新增保險異常欄
Modify 20130402 By SS Vicky. Reason: 在標的物的頁籤中，是事務機跟營建機具，則保險費(保險異常未勾選時)要必填
Modify 20130411 By SS Vicky. Reason: 動產及不動產將項次改為Textbox  (MOVABLEORDER / IMMOVABLEORDER)
Modify 20130416 By SS Gordon. Reason:存檔確認時，在擔保條件的頁籤中，保證人GRID的法人/個人選項若是選個人的話，則關係人一不可選承租企業
Modify 20130425 By SS Steven. Reason:保證人GRID的法人/個人選項若是選個人的話，則關係人一不可選承租企業語法修改
Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
20130521 ADD BY ADAM Reason.增加權利人欄位IDMEMO處理
Modify 20130528 BY    SEAN.   Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」
20130703 UPD BY BRENT Reason.取消原本資租(02)不能填寫多段式租金的設定
Modify 20130819 BY SEAN    Reason:修改承作型態為「應收帳款受讓」時，交易型態不可選擇，顯示為兩方
20130912 ADD BY SEAN Reason.修改保人為法人時，可輸入戶藉地址
20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
20131001 ADD BY ADAM Reason.營資租與營建機具才可以做保險費的錯誤判斷
Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
Modify 20150121 By SS Eric    Reason:新增「專案別」下拉選單
Modify 20150205 By SS ChrisFu Reason: 承作型態為「應收帳款受讓」時，付款方式預設值為「套票」，付款差異天數與付供應商天數預設值為「0」
Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
Modify 20150205 By SS ChrisFu Reason:新增「建議墊款息」欄位
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
20161130 ADD BY    SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
20170706 ADD BY SS ADAM REASON.欄位調整
20221031 行業別改下拉選單
20221031 標的物金額自動帶各標的物價格總和
20221031 新增第一筆保證人由客戶資料、標的物帶預設值
20221031 徵審資料更改
********************************************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.Collections.Specialized;
using System.IO;

public partial class FrmML3000 : Itg.Community.PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    //案件
    private NameValueCollection NVC_MLMCASE_Data
    {
        get
        {
            NameValueCollection MLMCASE_Data = new NameValueCollection();
            MLMCASE_Data.Add("txtCASEID", "CASEID");
            MLMCASE_Data.Add("drpCOMPID", "COMPID");
            MLMCASE_Data.Add("hidDEPTID", "DEPTID");
            MLMCASE_Data.Add("hidEMPLID", "EMPLID");
            //Modify 20120716 By SS Gordon. Reason: 新增承作方式.
            MLMCASE_Data.Add("drpSOURCETYPE", "SOURCETYPE");
            MLMCASE_Data.Add("drpMAINTYPE", "MAINTYPE");
            //MLMCASE_Data.Add("drpSUBTYPE", "SUBTYPE");
            MLMCASE_Data.Add("drpTRANSTYPE", "TRANSTYPE");
            //Modify 20120716 By SS Gordon. Reason: 新增銀行別.
            MLMCASE_Data.Add("drpBANKCD", "BANKCD");
            MLMCASE_Data.Add("drpUSESTATUS", "USESTATUS");
            MLMCASE_Data.Add("drpCYCLETYPE", "CYCLETYPE");
            MLMCASE_Data.Add("drpCASESOURCE", "CASESOURCE");
            MLMCASE_Data.Add("drpPAYTPE", "PAYTPE");
            MLMCASE_Data.Add("txtPATDAYS", "PATDAYS");
            MLMCASE_Data.Add("txtSUPPILERDAYS", "SUPPILERDAYS");
            MLMCASE_Data.Add("txtIRR", "IRR");
            MLMCASE_Data.Add("txtRECOVERTEST", "RECOVERTEST");
            MLMCASE_Data.Add("txtCAPITALCOST", "CAPITALCOST");


            //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
            MLMCASE_Data.Add("txtNPV0", "NPV0");
            MLMCASE_Data.Add("txtNPVRATECOST0", "NPVRATECOST0");


            MLMCASE_Data.Add("txtNPV", "NPV");
            //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            MLMCASE_Data.Add("txtNPVRATECOST", "NPVRATECOST");
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            MLMCASE_Data.Add("txtNPV2", "NPV2");
            MLMCASE_Data.Add("txtNPVRATECOST2", "NPVRATECOST2");
            //MLMCASE_Data.Add("drpEXPIREPROC", "EXPIREPROC");
            MLMCASE_Data.Add("txtEXPIREPROCDESC", "EXPIREPROCDESC");
            MLMCASE_Data.Add("txtOTHERCOND", "OTHERCOND");
            MLMCASE_Data.Add("txtFILENAME", "FILENAME");
            MLMCASE_Data.Add("drpDEFECTIVE", "DEFECTIVE");
            //john.chen 2011/11/03 增加欄位
            MLMCASE_Data.Add("drpPRINTSTORE", "PRINTSTORE");

            //Modify 20150205 By SS ChrisFu Reason:新增「建議墊款息」欄位
            MLMCASE_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");

            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            MLMCASE_Data.Add("drpPRODCD", "PRODCD");
            //Modify 20121112 By SS Steven. Reason: 案件資料另外儲存，以便修改後的檢核
            //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
            //MLMCASE_Data.Add("hidCheckIRR", "IRR");
            return MLMCASE_Data;
        }
    }
    //客户
    private NameValueCollection NVC_MLMCUSTOMER_Data
    {
        get
        {
            NameValueCollection MLMCUSTOMER_Data = new NameValueCollection();
            MLMCUSTOMER_Data.Add("txtCUSTID", "CUSTID");
            MLMCUSTOMER_Data.Add("txtCUSTNAME", "CUSTNAME");
            MLMCUSTOMER_Data.Add("drpCUTYPE", "CUTYPE");
            MLMCUSTOMER_Data.Add("txtCUSTCREATECAPTIAL", "CUSTCREATECAPTIAL");
            MLMCUSTOMER_Data.Add("txtCUSTNOWCAPTIAL", "CUSTNOWCAPTIAL");
            MLMCUSTOMER_Data.Add("txtCUSTCREATEDATE", "CUSTCREATEDATE");
            MLMCUSTOMER_Data.Add("txtOWNER", "OWNER");
            MLMCUSTOMER_Data.Add("txtOWNERID", "OWNERID");
            MLMCUSTOMER_Data.Add("txtGROUPOWNER", "GROUPOWNER");
            MLMCUSTOMER_Data.Add("txtPARENTCUSTID", "PARENTCUSTID");
            MLMCUSTOMER_Data.Add("txtPARENTCUSTNAME", "PARENTCUSTNAME");
            MLMCUSTOMER_Data.Add("txtCUSTZIPCODE", "CUSTZIPCODE");
            MLMCUSTOMER_Data.Add("txtCUSTZIPCODES", "CUSTZIPCODES");
            MLMCUSTOMER_Data.Add("txtCUSTADDR", "CUSTADDR");
            MLMCUSTOMER_Data.Add("txtCUSTTEL", "CUSTTEL");
            MLMCUSTOMER_Data.Add("txtCUSTFAX", "CUSTFAX");
            MLMCUSTOMER_Data.Add("txtBUSINESSZIPCODE", "BUSINESSZIPCODE");
            MLMCUSTOMER_Data.Add("txtBUSINESSZIPCODES", "BUSINESSZIPCODES");
            MLMCUSTOMER_Data.Add("txtBUSINESSADDR", "BUSINESSADDR");
            MLMCUSTOMER_Data.Add("txtBUSINESSTTEL", "BUSINESSTTEL");
            MLMCUSTOMER_Data.Add("txtBUSINESSFAX", "BUSINESSFAX");
            MLMCUSTOMER_Data.Add("txtBUSINESS", "BUSINESS");
            MLMCUSTOMER_Data.Add("drpCUROUT", "CUROUT");

            MLMCUSTOMER_Data.Add("txtCUSTTELCODE", "CUSTTELCODE");
            MLMCUSTOMER_Data.Add("txtCUSTFAXCODE", "CUSTFAXCODE");
            MLMCUSTOMER_Data.Add("txtBUSINESSTTELCODE", "BUSINESSTTELCODE");
            MLMCUSTOMER_Data.Add("txtBUSINESSFAXCODE", "BUSINESSFAXCODE");

            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            //MLMCUSTOMER_Data.Add("txtINDUID", "INDUID");
            //MLMCUSTOMER_Data.Add("txtINDUNM", "INDUNM");
            //20221031行業別改下拉選單
            MLMCUSTOMER_Data.Add("DrpNDU", "CUROUT");
            return MLMCUSTOMER_Data;
        }
    }
    //應收帳款案件資料
    private NameValueCollection NVC_MLDCASEARDATA_Data
    {
        get
        {
            NameValueCollection MLDCASEARDATA_Data = new NameValueCollection();
            MLDCASEARDATA_Data.Add("txtCASEID", "CASEID");
            MLDCASEARDATA_Data.Add("txtAPLIMIT", "APLIMIT");
            MLDCASEARDATA_Data.Add("txtCREDITFEES", "CREDITFEES");
            MLDCASEARDATA_Data.Add("txtMANAGERFEES", "MANAGERFEES");
            MLDCASEARDATA_Data.Add("txtFINANCIALFEES", "FINANCIALFEES");
            //MLDCASEARDATA_Data.Add("txtPERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("txtACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("drpPAYTIMEA", "PAYTIME");
            MLDCASEARDATA_Data.Add("txtBUYERLIMIT", "BUYERLIMIT");
            MLDCASEARDATA_Data.Add("txtARIRR", "IRR");
            MLDCASEARDATA_Data.Add("txtINTERSET", "INTERSET");
            //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
            MLDCASEARDATA_Data.Add("txtARPERBOND", "ARPERBOND");

            //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
            MLDCASEARDATA_Data.Add("drpPERCENTAGE", "PERCENTAGE");

            //Modify 20121112 By SS Steven. Reason: 案件資料另外儲存，以便修改後的檢核
            //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
            //MLDCASEARDATA_Data.Add("hidCheckARIRR", "IRR");

            return MLDCASEARDATA_Data;
        }
    }
    //Modify 20120621 By SS Gordon. Reason: 案件資料另外儲存，以便修改後的檢核
    private NameValueCollection NVC_preMLDCASEARDATA_Data
    {
        get
        {
            NameValueCollection MLDCASEARDATA_Data = new NameValueCollection();
            MLDCASEARDATA_Data.Add("hidPreAPLIMIT", "APLIMIT");
            MLDCASEARDATA_Data.Add("hidPrePERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("hidPreACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("hidPreBUYERLIMIT", "BUYERLIMIT");
            MLDCASEARDATA_Data.Add("hidPreARIRR", "IRR");

            //Modify 20121112 By SS Steven. Reason: 案件資料另外儲存，以便修改後的檢核
            //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
            MLDCASEARDATA_Data.Add("hidCheckARIRR", "IRR");

            return MLDCASEARDATA_Data;
        }
    }
    //案件申請租賃分期案件分期
    private NameValueCollection NVC_MLDCASEINST_Data
    {
        get
        {
            NameValueCollection MLDCASEINST_Data = new NameValueCollection();
            MLDCASEINST_Data.Add("txtTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("hidTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("txtFEE", "FEE");
            MLDCASEINST_Data.Add("txtCOMMISSION", "COMMISSION");
            MLDCASEINST_Data.Add("txtINSURANCE", "INSURANCE");
            MLDCASEINST_Data.Add("txtFIRSTPAY", "FIRSTPAY");
            MLDCASEINST_Data.Add("txtACTUSLLOANS", "ACTUSLLOANS");
            MLDCASEINST_Data.Add("hidACTUSLLOANS", "ACTUSLLOANS");
            MLDCASEINST_Data.Add("txtOTHERFEES", "OTHERFEES");
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
            MLDCASEINST_Data.Add("txtOTHERFEESNOTAX", "OTHERFEESNOTAX");
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            MLDCASEINST_Data.Add("txtNOINSURANCEFLG", "NOINSURANCEFLG");
            MLDCASEINST_Data.Add("txtPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN");
            MLDCASEINST_Data.Add("txtRESIDUALS", "RESIDUALS");
            MLDCASEINST_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");
            MLDCASEINST_Data.Add("txtPAYMONTH", "PAYMONTH");
            MLDCASEINST_Data.Add("drpPAYTIMET", "PAYTIME");
            return MLDCASEINST_Data;
        }
    }
    //Modify 20120621 By SS Gordon. Reason: 案件資料另外儲存，以便修改後的檢核
    private NameValueCollection NVC_preMLDCASEINST_Data
    {
        get
        {
            NameValueCollection MLDCASEINST_Data = new NameValueCollection();
            MLDCASEINST_Data.Add("hidPreTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("hidPreCONTRACTMONTH", "CONTRACTMONTH");

            //Modify 20121112 By SS Steven. Reason: 案件資料另外儲存，以便修改後的檢核
            //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
            MLDCASEINST_Data.Add("hidCheckTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("hidCheckCONTRACTMONTH", "CONTRACTMONTH");

            // Modify 20130528 BY SEAN. Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」
            MLDCASEINST_Data.Add("hidCheckACTUSLLOANS", "ACTUSLLOANS");

            return MLDCASEINST_Data;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "案件申請維護";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3000";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3000";
        //========================             
        if (!Page.IsPostBack)
        {
            rptContactInit();
            FormDrpBind();
            ViewState["STATUS"] = "INSERT";

            CheckRule();
            //this.txtSYSDT.Text = Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd"));
            this.btnLoadCase.Enabled = false;
            this.btnMLDCASETARGETEmport.Enabled = false;
            this.btnMLDCASETARGETCopy.Enabled = false;
            this.fldMLDCASETARGETEmport.Enabled = false;
            this.btnUpload.Enabled = false;
            this.cmdPrintReportA.Enabled = false;
            //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
            this.drpRECOURSE.Enabled = false;
            this.drpRECOURSE.SelectedIndex = 0;

            RegisterScript("SetDisabled('div_Info', '" + this.btnIRR.ClientID + "','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSelect.ClientID + "');");
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window_onload();", true);
    }
    private void CheckRule()
    {
        //列舉所有需要驗證的欄位

        //客戶業簽
        string LSTR_CUSTID = txtCUSTID.ClientID;
        string LSTR_OWNERID = txtOWNERID.ClientID;
        string LSTR_CUSTFAX = txtCUSTFAX.ClientID;

        string LSTR_BUSINESSFAX = txtBUSINESSFAX.ClientID;
        //案件
        string LSTR_PATDAYS = txtPATDAYS.ClientID;

        string Fields = LSTR_CUSTID + ";" + LSTR_CUSTFAX + ";" + LSTR_BUSINESSFAX;
        string FieldsName = " 客戶統編;公司登記傳真;營業登記傳真";
        string CheckType = "text;text;text";
        string Length = "12;10;10;";
        string IsEmpty = "false;true;true";
        string strCheck = "return checkRule('" + Fields + "','" + FieldsName + "','" + CheckType + "','" + Length + "','" + IsEmpty + "')";
        this.btnSubmit.Attributes.Add("onclick", strCheck);

        //Modify 20121112 By SS Steven. Reason: 以下三個條件有一個成立，跳出視窗訊息提醒，假如是作業確認就要發email通知
        //1.現在撥款金額 >  原案金額
        //2.現在期數     >  原案期數
        //3.現在IRR     <= 原案IRR
        this.btnSave.Attributes.Add("onclick", "return Save_Check('" + Fields + "','" + FieldsName + "','" + CheckType + "','" + Length + "','" + IsEmpty + "')");
    }
    private void FormDrpBind()
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                this.drpCUROUT.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpCUROUT.DataBind();

                this.drpCUTYPE.DataSource = LDST_Data.Tables[1].DefaultView;
                this.drpCUTYPE.DataBind();

                this.drpCOMPID.DataSource = LDST_Data.Tables[2].DefaultView;
                this.drpCOMPID.DataBind();
                this.drpCOMPID.SelectedValue = "02";

                this.drpMAINTYPE.DataSource = LDST_Data.Tables[3].DefaultView;
                this.drpMAINTYPE.DataBind();

                this.drpTRANSTYPE.DataSource = LDST_Data.Tables[4].DefaultView;
                this.drpTRANSTYPE.DataBind();

                this.drpUSESTATUS.DataSource = LDST_Data.Tables[5].DefaultView;
                this.drpUSESTATUS.DataBind();

                this.drpCYCLETYPE.DataSource = LDST_Data.Tables[6].DefaultView;
                this.drpCYCLETYPE.DataBind();
                this.drpCYCLETYPE.SelectedValue = "02";

                this.drpCASESOURCE.DataSource = LDST_Data.Tables[7].DefaultView;
                this.drpCASESOURCE.DataBind();

                this.drpPAYTPE.DataSource = LDST_Data.Tables[8].DefaultView;
                this.drpPAYTPE.DataBind();

                this.drpPAYTIMEA.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpPAYTIMEA.DataBind();

                this.drpPAYTIMET.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpPAYTIMET.DataBind();

                this.drpCODE.DataSource = LDST_Data.Tables[10].DefaultView;
                this.drpCODE.DataBind();

                //this.drpEXPIREPROC.DataSource = LDST_Data.Tables[10].DefaultView;
                //this.drpEXPIREPROC.DataBind();

                //Modify 20120716 By SS Gordon. Reason: 新增承作方式.
                this.drpSOURCETYPE.DataSource = LDST_Data.Tables[11].DefaultView;
                this.drpSOURCETYPE.DataBind();
                //Modify 20120716 By SS Gordon. Reason: 新增銀行別.
                this.drpBANKCD.DataSource = LDST_Data.Tables[12].DefaultView;
                this.drpBANKCD.DataBind();
                this.drpBANKCD.Items.Insert(0, new ListItem("", ""));

                //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
                this.drpPERCENTAGE.DataSource = LDST_Data.Tables[13].DefaultView;
                this.drpPERCENTAGE.DataBind();

                //20160323 ADD BY SS ADAM REASON.增加案件產品別
                this.drpPRODCD.DataSource = LDST_Data.Tables[14].DefaultView;
                this.drpPRODCD.DataBind();

                //20221031行業別改下拉選單
                this.DrpNDU.DataSource = LDST_Data.Tables[15].DefaultView;
                DataView LDVW_DocData = LDST_Data.Tables[15].DefaultView;
                LDVW_DocData.RowFilter = "MCODE NOT IN ('17' , '18'  , '19' , '20')";
                this.DrpNDU.DataBind();

                string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
                SetMAINTYPERDO(LSTR_MAINTYPEID);

                MLDCASEAPPENDDOCBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void getDocListBind()
    {
        //20221031 改為隱藏
        //DataTable LOBJ_DocList = (DataTable)ViewState["DocList"];
        //for (int j = 0; j < rptMLDCASEAPPENDDOC.Items.Count; j++)
        //{
        //    DropDownList LOBJ_LasList = (DropDownList)rptMLDCASEAPPENDDOC.Items[j].FindControl("drpDocName");
        //    if (LOBJ_LasList.Visible == true)
        //    {
        //        for (int i = 0; i < LOBJ_DocList.Rows.Count; i++)
        //        {
        //            LOBJ_LasList.Items.Add(new ListItem(LOBJ_DocList.Rows[i]["DNAME1"].ToString(), LOBJ_DocList.Rows[i]["DCODE"].ToString()));
        //        }
        //        LOBJ_LasList.SelectedValue = ((HiddenField)rptMLDCASEAPPENDDOC.Items[j].FindControl("hidDocID")).Value;
        //    }
        //    LOBJ_LasList = null;
        //}
    }
    private void SetMAINTYPERDO(string LSTR_MAINTYPEID)
    {
        if (LSTR_MAINTYPEID == "04")
        {
            SetPrDisAbled();
            SetPrValueClear();
            ViewState["MLDCASETARGET"] = null;
            rptMLDCASETARGET.DataSource = null;
            rptMLDCASETARGET.DataBind();

            this.rptMLDCASETARGETSTR.DataSource = null;
            this.rptMLDCASETARGETSTR.DataBind();

        }
        else
        {
            SetARDisAbled();
            SetARValueClear();
            //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
            if (drpSOURCETYPE.SelectedValue == "02")
            {
                ViewState["MLDCASETARGET"] = null;
                rptMLDCASETARGET.DataSource = null;
                rptMLDCASETARGET.DataBind();

                this.rptMLDCASETARGETSTR.DataSource = null;
                this.rptMLDCASETARGETSTR.DataBind();
            }
        }
        if (LSTR_MAINTYPEID == "01")
        {
            this.txtPURCHASEMARGIN.Enabled = true;
        }
        else
        {
            this.txtPURCHASEMARGIN.Enabled = false;
            this.txtPURCHASEMARGIN.Text = "0";
        }
        if (LSTR_MAINTYPEID == "04")
        {
            this.txtFIRSTPAY.Enabled = false;
            this.txtFIRSTPAY.Text = "0";
        }
        else
        {
            this.txtFIRSTPAY.Enabled = true;
        }
        Decimal LDBL_TRANSCOST = Convert.ToDecimal(this.hidTRANSCOST.Value);
        Decimal LDBL_FIRSTPAY = Convert.ToDecimal(this.txtFIRSTPAY.Text);
        Decimal LDBL_PURCHASEMARGIN = Convert.ToDecimal(this.txtPURCHASEMARGIN.Text);
        Decimal LDBL_ACTUSLLOANS = LDBL_TRANSCOST - LDBL_FIRSTPAY - LDBL_PURCHASEMARGIN;
        this.txtACTUSLLOANS.Text = LDBL_ACTUSLLOANS.ToString("#,##0");
        this.hidACTUSLLOANS.Value = LDBL_ACTUSLLOANS.ToString("#,##0");
        this.txtTRANSCOST.Text = LDBL_TRANSCOST.ToString("#,##0");
        this.hidTRANSCOST.Value = LDBL_TRANSCOST.ToString("#,##0");
    }
    private void SetPrValueClear()
    {
        this.txtTRANSCOST.Text = "0";
        this.txtFEE.Text = "0";
        this.txtCOMMISSION.Text = "0";
        this.txtINSURANCE.Text = "0";
        this.txtFIRSTPAY.Text = "0";
        this.txtACTUSLLOANS.Text = "0";
        this.txtOTHERFEES.Text = "0";
        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
        this.txtOTHERFEESNOTAX.Text = "0";
        //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
        this.txtNOINSURANCEFLG.Checked = false;
        this.txtPERBOND.Text = "0";
        this.txtPURCHASEMARGIN.Text = "0";
        this.txtRESIDUALS.Text = "0";
        this.txtCONTRACTMONTH.Text = "";
        this.txtPAYMONTH.Text = "";
        this.drpPAYTIMET.SelectedIndex = 0;

        this.txtPRINCIPAL1.Text = "";
        this.txtPRINCIPALTAX1.Text = "";

        this.txtENDPAY1.Text = "";
        this.txtSTARTPAY2.Text = "";
        this.txtENDPAY2.Text = "";
        this.txtPRINCIPAL2.Text = "";
        this.txtPRINCIPALTAX2.Text = "";

        this.txtSTARTPAY3.Text = "";
        this.txtENDPAY3.Text = "";
        this.txtPRINCIPAL3.Text = "";
        this.txtPRINCIPALTAX3.Text = "";

        this.txtSTARTPAY4.Text = "";
        this.txtENDPAY4.Text = "";
        this.txtPRINCIPAL4.Text = "";
        this.txtPRINCIPALTAX4.Text = "";

        this.txtPATDAYS.Text = "0";
        this.txtSUPPILERDAYS.Text = "0";
        this.txtIRR.Text = "0.000";
        this.txtNPV.Text = "0.000";
        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
        this.txtNPVRATECOST.Text = "0";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtNPV2.Text = "0.000";
        this.txtNPVRATECOST2.Text = "0";
        this.txtRECOVERTEST.Text = "0";
        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
        //this.txtCAPITALCOST.Text = "7";
        this.txtCAPITALCOST.Text = "4";
    }
    private void SetARValueClear()
    {
        this.txtAPLIMIT.Text = "0";
        this.txtCREDITFEES.Text = "0";
        this.txtMANAGERFEES.Text = "0";
        this.txtFINANCIALFEES.Text = "0";
        //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
        //this.txtPERCENTAGE.Text = "";
        this.drpPERCENTAGE.SelectedIndex = 0;

        this.txtACCOUNTSTERM.Text = "";
        this.drpPAYTIMEA.SelectedIndex = 0;
        this.txtBUYERLIMIT.Text = "0";
        this.txtARIRR.Text = "";
        this.txtINTERSET.Text = "0";
        //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
        this.txtARPERBOND.Text = "0";

        this.txtPATDAYS.Text = "0";
        this.txtSUPPILERDAYS.Text = "0";
        this.txtIRR.Text = "0.000";
        this.txtNPV.Text = "0.000";
        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
        this.txtNPVRATECOST.Text = "0";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtNPV2.Text = "0.000";
        this.txtNPVRATECOST2.Text = "0";
        this.txtRECOVERTEST.Text = "0";
        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
        //this.txtCAPITALCOST.Text = "7";
        this.txtCAPITALCOST.Text = "4";
    }
    private void SetPrDisAbled()
    {

        rdoMLDCASEARDATA.Checked = true;
        rdoMLDCASEINST.Checked = false;
        chkAr.Checked = true;

        this.txtTRANSCOST.Enabled = false;
        this.txtFEE.Enabled = false;
        this.txtCOMMISSION.Enabled = false;
        //20130903 ADD BY ADAM Reason.取消保險費可輸入金額
        //this.txtINSURANCE.Enabled = false;
        this.txtFIRSTPAY.Enabled = false;
        this.txtACTUSLLOANS.Enabled = false;
        this.txtOTHERFEES.Enabled = false;
        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
        this.txtOTHERFEESNOTAX.Enabled = false;
        //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
        this.txtNOINSURANCEFLG.Enabled = false;
        this.txtPERBOND.Enabled = false;
        this.txtPURCHASEMARGIN.Enabled = false;
        this.txtRESIDUALS.Enabled = false;
        this.txtCONTRACTMONTH.Enabled = false;

        this.txtPAYMONTH.Enabled = false;
        this.drpPAYTIMET.Enabled = false;

        this.txtPRINCIPAL1.Enabled = false;
        this.txtPRINCIPALTAX1.Enabled = false;
        this.txtENDPAY1.Enabled = false;

        this.txtSTARTPAY2.Enabled = false;
        this.txtENDPAY2.Enabled = false;
        this.txtPRINCIPAL2.Enabled = false;
        this.txtPRINCIPALTAX2.Enabled = false;

        this.txtSTARTPAY3.Enabled = false;
        this.txtENDPAY3.Enabled = false;
        this.txtPRINCIPAL3.Enabled = false;
        this.txtPRINCIPALTAX3.Enabled = false;

        this.txtSTARTPAY4.Enabled = false;
        this.txtENDPAY4.Enabled = false;
        this.txtPRINCIPAL4.Enabled = false;
        this.txtPRINCIPALTAX4.Enabled = false;

        this.btnIRR.Enabled = false;

        this.btnMLDCASETARGETEmport.Enabled = false;
        this.btnMLDCASETARGETCopy.Enabled = false;
        this.fldMLDCASETARGETEmport.Enabled = false;
        this.chkOneMLDCASETARGETSTR.Enabled = false;

        this.txtAPLIMIT.CssClass = "txt_must_right";
        //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
        //this.txtPERCENTAGE.CssClass = "txt_must_right";
        this.drpPERCENTAGE.CssClass = "txt_must_right";

        this.txtACCOUNTSTERM.CssClass = "txt_must_right";
        this.drpPAYTIMEA.CssClass = "bg_F5F8BE";
        this.txtBUYERLIMIT.CssClass = "txt_must_right";
        this.txtARIRR.CssClass = "txt_must_right";

        this.txtTRANSCOST.CssClass = "txt_normal_right";
        this.txtCONTRACTMONTH.CssClass = "txt_normal_right";
        this.txtPAYMONTH.CssClass = "txt_normal_right";
        this.drpPAYTIMET.CssClass = "bg_normal";
        this.txtPRINCIPAL1.CssClass = "txt_normal_right";
        this.txtPRINCIPALTAX1.CssClass = "txt_normal_right";
        this.txtENDPAY1.CssClass = "txt_normal_right";

        this.txtAPLIMIT.Enabled = true;
        this.txtCREDITFEES.Enabled = true;
        this.txtMANAGERFEES.Enabled = true;
        this.txtFINANCIALFEES.Enabled = true;
        //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
        //this.txtPERCENTAGE.Enabled = true;
        this.drpPERCENTAGE.Enabled = true;

        this.txtACCOUNTSTERM.Enabled = true;
        this.drpPAYTIMEA.Enabled = true;
        this.txtBUYERLIMIT.Enabled = true;
        this.txtARIRR.Enabled = true;

        this.txtINTERSET.Enabled = true;
        //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
        this.txtARPERBOND.Enabled = true;
        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        chkBANK1.Checked = false;

        //Modify 20150205 By SS ChrisFu Reason:新增「建議墊款息」欄位
        this.txtADVANCESINTEREST.Enabled = true;
    }
    private void SetARDisAbled()
    {
        rdoMLDCASEARDATA.Checked = false;
        rdoMLDCASEINST.Checked = true;
        chkAr.Checked = false;

        this.txtAPLIMIT.Enabled = false;
        this.txtCREDITFEES.Enabled = false;
        this.txtMANAGERFEES.Enabled = false;
        this.txtFINANCIALFEES.Enabled = false;
        //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
        //this.txtPERCENTAGE.Text = "";
        this.drpPERCENTAGE.SelectedIndex = 0;

        this.txtACCOUNTSTERM.Enabled = false;
        this.drpPAYTIMEA.Enabled = false;
        this.txtBUYERLIMIT.Enabled = false;
        this.txtARIRR.Enabled = false;
        this.txtINTERSET.Enabled = false;
        //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
        this.txtARPERBOND.Enabled = false;

        this.txtAPLIMIT.CssClass = "txt_normal_right";
        //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
        //this.txtPERCENTAGE.CssClass = "txt_must_right";
        this.drpPERCENTAGE.CssClass = "txt_must_right";

        this.txtACCOUNTSTERM.CssClass = "txt_normal_right";
        this.drpPAYTIMEA.CssClass = "bg_normal";
        this.txtBUYERLIMIT.CssClass = "txt_normal_right";
        this.txtARIRR.CssClass = "txt_normal_right";

        this.txtTRANSCOST.CssClass = "txt_must_right";
        this.txtCONTRACTMONTH.CssClass = "txt_must_right";
        this.txtPAYMONTH.CssClass = "txt_must_right";
        this.drpPAYTIMET.CssClass = "bg_F5F8BE";
        this.txtPRINCIPAL1.CssClass = "txt_must_right";
        this.txtPRINCIPALTAX1.CssClass = "txt_must_right";
        this.txtENDPAY1.CssClass = "txt_must_right";

        this.txtTRANSCOST.Enabled = true;
        this.txtFEE.Enabled = true;
        this.txtCOMMISSION.Enabled = true;
        //20130903 ADD BY ADAM Reason.取消保險費可輸入金額
        //this.txtINSURANCE.Enabled = true;
        this.txtFIRSTPAY.Enabled = true;
        this.txtACTUSLLOANS.Enabled = true;
        this.txtOTHERFEES.Enabled = true;
        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
        this.txtOTHERFEESNOTAX.Enabled = true;
        //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
        this.txtNOINSURANCEFLG.Enabled = true;
        this.txtPERBOND.Enabled = true;
        this.txtPURCHASEMARGIN.Enabled = true;
        this.txtRESIDUALS.Enabled = true;
        this.txtCONTRACTMONTH.Enabled = true;

        this.txtPAYMONTH.Enabled = true;
        this.drpPAYTIMET.Enabled = true;
        this.txtPRINCIPAL1.Enabled = true;
        this.txtPRINCIPALTAX1.Enabled = true;

        this.txtENDPAY1.Enabled = true;
        this.txtSTARTPAY2.Enabled = true;
        this.txtENDPAY2.Enabled = true;
        this.txtPRINCIPAL2.Enabled = true;
        this.txtPRINCIPALTAX2.Enabled = true;

        this.txtSTARTPAY3.Enabled = true;
        this.txtENDPAY3.Enabled = true;
        this.txtPRINCIPAL3.Enabled = true;
        this.txtPRINCIPALTAX3.Enabled = true;

        this.txtSTARTPAY4.Enabled = true;
        this.txtENDPAY4.Enabled = true;
        this.txtPRINCIPAL4.Enabled = true;
        this.txtPRINCIPALTAX4.Enabled = true;

        this.btnMLDCASETARGETEmport.Enabled = true;
        this.btnMLDCASETARGETCopy.Enabled = true;
        this.fldMLDCASETARGETEmport.Enabled = true;
        this.chkOneMLDCASETARGETSTR.Enabled = true;

        this.btnIRR.Enabled = true;

        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        chkBANK1.Checked = false;
        if (this.drpSOURCETYPE.SelectedValue == "02")
        {
            chkBANK1.Checked = true;
            this.btnMLDCASETARGETEmport.Enabled = false;
            this.btnMLDCASETARGETCopy.Enabled = false;
            this.fldMLDCASETARGETEmport.Enabled = false;
            this.chkOneMLDCASETARGETSTR.Enabled = false;
        }
    }
    private void rptInit()
    {
        this.rptContactC.DataSource = null;
        this.rptContactI.DataSource = null;
        this.rptContactM.DataSource = null;
        this.rptContactC.DataBind();
        this.rptContactI.DataBind();
        this.rptContactM.DataBind();
        rptContactInit();

        MLDCASEAPPENDDOCBind();

        rptMLDCASETARGET.DataSource = null;
        rptMLDCASETARGET.DataBind();
        rptMLDCASETARGETSTR.DataSource = null;
        rptMLDCASETARGETSTR.DataBind();
        ViewState["MLDCASETARGET"] = null;

        rptMLDCASEGUARANTEE.DataSource = null;
        rptMLDCASEGUARANTEE.DataBind();
        ViewState["MLDCASEGUARANTEE"] = null;

        rptMLDCASEMOVABLE.DataSource = null;
        rptMLDCASEMOVABLE.DataBind();
        ViewState["MLDCASEMOVABLE"] = null;

        rptMLDCASEIMMOVABLE.DataSource = null;
        rptMLDCASEIMMOVABLE.DataBind();
        rptMLDHUMANRIGHTS.DataSource = null;
        rptMLDHUMANRIGHTS.DataBind();
        ViewState["MLDCASEIMMOVABLE"] = null;

        rptMLDCASEADEPOSIT.DataSource = null;
        rptMLDCASEADEPOSIT.DataBind();
        ViewState["MLDCASEADEPOSIT"] = null;

        rptMLDCASEBILLNOTE.DataSource = null;
        rptMLDCASEBILLNOTE.DataBind();
        ViewState["MLDCASEBILLNOTE"] = null;

        rptMLDCASESTOCK.DataSource = null;
        rptMLDCASESTOCK.DataBind();
        ViewState["MLDCASESTOCK"] = null;

        this.hidSelHeadTag.Value = "fraTab11Caption";
    }
    private void GetCustomerBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCUSTOMER_Data);
            //drpCUROUTBindbyID(this.drpCUROUT.SelectedValue);
            //this.drpCUROUTF.SelectedValue = LOBJ_Data.Rows[0]["CUROUTF"].ToString().Trim();
            if (this.txtCUSTID.Text == "16844548")
            {
                this.drpCOMPID.SelectedValue = "01";
            }
            if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
            {
                //營租事物機 和 資租事物機 資金成本要固定為 5%
                //其他承作類型 為7%
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                //this.txtCAPITALCOST.Text = "5";
                this.txtCAPITALCOST.Text = "4";
            }
            else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
            {
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                //this.txtCAPITALCOST.Text = "5";
                this.txtCAPITALCOST.Text = "4";
            }
            else
            {
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                //this.txtCAPITALCOST.Text = "7";
                this.txtCAPITALCOST.Text = "4";
            }
            this.UpdatePanelCAP.Update();
            this.txtBUSINESS.Width = 500;
        }
    }
    private void drpCUROUTBindbyID(string LSTR_CUROUT)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBLEASEUNIONDataById(LSTR_CUROUT);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                this.drpCUROUTF.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpCUROUTF.DataBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private ReturnObject<DataSet> GetMLDCASEAPPENDDOCDataById(string LSTR_MAINSUBTYPE)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            LSTR_StoreProcedure.Append("SP_ML1002_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "13" + GSTR_ColDelimitChar + LSTR_MAINSUBTYPE + GSTR_ColDelimitChar + "L" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            LSTR_StoreProcedure.Append("SP_ML1002_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "13" + GSTR_ColDelimitChar + LSTR_MAINSUBTYPE + GSTR_ColDelimitChar + "S" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);


            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetLCBANKMFData()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //母行業別drpLEASEUNIONID
            LSTR_StoreProcedure.Append("SP_ML0001_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetDrpData()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //母行業別drpLEASEUNIONID
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //客戶性質drpCUTYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "03" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //公司別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "04" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //承做形態
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //交易形態
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "06" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //動用情形
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "07" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //循環  
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "08" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //案件來源 20191203 ADD BY SS ADAM REASON.改為預設請選擇
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "09" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //付款方式
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "10" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //付款時間
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "11" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //郵編區號
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);


            //預計期滿處理方式
            //LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            //LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120716 By SS Gordon. Reason: 新增承作方式.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "89" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120716 By SS Gordon. Reason: 新增銀行別.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "90" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A8" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20160323 ADD BY SS ADAM REASON.新增案件產品別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "93" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20221031行業別改下拉選單
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetSUBLEASEUNIONDataById(string LSTR_CUROUT)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //子行業別drpCUROUTF
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + LSTR_CUROUT + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetCustomerDataByID(string LSTR_CUSTID)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML1001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetSUBTYPEDataById(string LSTR_MAINTYPEID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //子行業別drpCUROUTF
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            string LSTR_MAINTYPEName = this.drpMAINTYPE.SelectedItem.Text;
            if (LSTR_MAINTYPEName == "營租")
            {
                LSTR_MAINTYPEName = "01";
            }
            else
            {
                LSTR_MAINTYPEName = "02";
            }
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + LSTR_MAINTYPEName + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<object> SaveCaseInfo(string LSTR_Data)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        ReturnObject<object> LOBJ_Return;
        string[] LVAR_Parameter = new string[1];

        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_Data;
            LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetCaseDataByID(string LSTR_CUSTID, string LSTR_CASEID)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML1001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //联络人
            LSTR_StoreProcedure.Append("SP_ML1002_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLDCASECONTACT.CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //綁定案件
            LSTR_StoreProcedure.Append("SP_ML1002_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //取得案件相關訊息
            //案件申請應收帳款案件資料檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q13" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //案件申請租賃分期案件資料檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q14" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //案件申請租賃分期案件資料檔明細
            LSTR_StoreProcedure.Append("SP_ML1002_Q15" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //相關文件
            LSTR_StoreProcedure.Append("SP_ML1002_Q07" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //MLDCASETARGET標的物
            LSTR_StoreProcedure.Append("SP_ML1002_Q04" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //擔保條件
            //案件申請保證人資料明細檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q05" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //動產設定
            LSTR_StoreProcedure.Append("SP_ML1002_Q08" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //不動產設定
            LSTR_StoreProcedure.Append("SP_ML1002_Q09" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);


            //不定存單質押
            LSTR_StoreProcedure.Append("SP_ML1002_Q10" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //客票
            LSTR_StoreProcedure.Append("SP_ML1002_Q11" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //股票
            LSTR_StoreProcedure.Append("SP_ML1002_Q12" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20121224 By SS Gordon. Reason:修正案件資料另外儲存，以便修改後的檢核。檢核資料從PRE資料表取得
            //案件申請應收帳款案件資料檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q20" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //案件申請租賃分期案件資料檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q21" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
            //案件主檔案件資料檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q22" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CASEID=''''" + LSTR_CASEID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //專案
            LSTR_StoreProcedure.Append("SP_ML1002_Q26" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();

            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetTARGETTYPEData()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //母行業別drpLEASEUNIONID
            LSTR_StoreProcedure.Append("SP_ML0001_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "14" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "15" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetMLDCASEGUARANTEEDrpBind()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        string LSTR_CUSTID = this.txtCUSTID.Text;

        //LSTR_CUSTID = "KKTST";

        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "03" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML1001_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120531 By SS Gordon. Reason:加入關係人一查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "71" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120531 By SS Gordon. Reason:加入關係人二查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "72" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120531 By SS Gordon. Reason:加入職業主類別查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "86" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120531 By SS Gordon. Reason:加入職業查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q10" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "86" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    //Modify 20120531 By SS Gordon. Reason:查詢保證人職業
    private DataTable GetGRTJOBData()
    {
        if (ViewState["GRTJOBData"] == null)
        {
            Comus.HtmlSubmitControl LOBJ_Submit;
            string LSTR_ObjId;
            StringBuilder LSTR_StoreProcedure = new StringBuilder();
            StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
            ReturnObject<DataSet> LOBJ_Return;
            string[] LVAR_Parameter = new string[2];
            try
            {
                LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

                LSTR_StoreProcedure.Append("SP_ML0001_Q10" + GSTR_RowDelimitChar);
                LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "86" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                LOBJ_Submit = new Comus.HtmlSubmitControl();
                LOBJ_Submit.VirtualPath = GetComusVirtualPath();
                LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
                LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
                LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewState["GRTJOBData"] = LOBJ_Return.ReturnData.Tables[0];
        }

        return (DataTable)ViewState["GRTJOBData"];
    }

    //============================================================
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        this.lblStatus.Text = "新增";
        this.btnSave.Enabled = true;
        this.btnSubmit.Enabled = true;
        this.btnInsert.Enabled = false;
        this.btnUpdate.Enabled = false;
        this.btnLoadCase.Enabled = true;
        this.btnSelect.Enabled = false;
        this.btnSelCus.Disabled = false;
        this.txtCUSTID.Enabled = true;
        RegisterScript("SetDisabled('div_Info', '','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSelect.ClientID + "," + this.btnSelCus.ClientID + "," + this.txtCUSTID.ClientID + "');window_onload();SetCustID();");
        this.btnSubmit.Enabled = false;
        this.btnSave.Enabled = false;
        //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
        this.btnRej.Enabled = false;

        Itg.Community.Util.SetDefaultValue(this.Page, NVC_MLMCUSTOMER_Data);
        rptInit();
        FormDrpBind();
        ViewState["STATUS"] = "INSERT";
        CheckRule();
        //this.txtSYSDT.Text = Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd"));
        //RegisterScript("SetDisabled('div_Info', '" + this.txtCUSTID.ClientID + "','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSelect.ClientID + "');window_onload();");
        this.txtCASEID.Text = "";
        DisabledRPRINCIPAL();
        this.UpdatePanel1.Update();
    }
    protected void btnCaseQue_Click(object sender, EventArgs e)
    {
        string LSTR_Type = this.hidCustomer.Value.Substring(0, 1);
        if (LSTR_Type == "U")
        {
            this.lblStatus.Text = "修改";
            this.btnSave.Enabled = true;
            this.btnSubmit.Enabled = true;
            this.txtCASEID.Enabled = false;
            this.btnSelCus.Disabled = false;
            //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
            this.btnRej.Enabled = true;

            this.btnC1.Disabled = false;
            this.btnC2.Disabled = false;
            this.btnC3.Disabled = false;

            this.btnInsert.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnLoadCase.Enabled = false;
            this.btnSelect.Enabled = false;
            this.btnUpload.Enabled = true;

            this.cmdPrintReportA.Enabled = true;
            RegisterScript("SetDisabled('', '" + this.txtCASEID.ClientID + "," + this.btnSelCus.ClientID + "','');");
            rptInit();
            PageDataBind();

            //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕
            btINSURANCE.Enabled = true;
        }
        else if (LSTR_Type == "I")
        {
            this.lblStatus.Text = "新增";
            this.btnSave.Enabled = true;
            this.btnSubmit.Enabled = true;
            this.txtCASEID.Enabled = false;
            this.btnSelCus.Disabled = false;
            //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
            this.btnRej.Enabled = false;

            this.btnC1.Disabled = false;
            this.btnC2.Disabled = false;
            this.btnC3.Disabled = false;

            this.btnInsert.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnLoadCase.Enabled = true;
            this.btnSelect.Enabled = false;
            this.btnUpload.Enabled = true;
            this.cmdPrintReportA.Enabled = true;
            RegisterScript("SetDisabled('', '" + this.txtCASEID.ClientID + "','');");
            rptInit();
            PageDataBind();
        }
        else
        {
            this.lblStatus.Text = "查詢";
            this.btnSave.Enabled = false;
            this.btnSubmit.Enabled = false;
            //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
            this.btnRej.Enabled = false;

            this.btnMLDCASETARGETEmport.Enabled = false;
            this.btnMLDCASETARGETCopy.Enabled = false;
            this.fldMLDCASETARGETEmport.Enabled = false;
            this.chkOneMLDCASETARGETSTR.Enabled = false;

            this.btnInsert.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnLoadCase.Enabled = false;
            this.btnSelect.Enabled = true;
            this.cmdPrintReportA.Enabled = true;
            RegisterScript("SetDisabled('div_Info', '" + this.btnIRR.ClientID + "," + this.btnMLDCASETARGETEmport.ClientID + "," + this.btnMLDCASETARGETCopy.ClientID + "," + this.fldMLDCASETARGETEmport.ClientID + "','" + btnInsert.ClientID + "," + btnUpdate.ClientID + "," + btnSelect.ClientID + "," + btnCaseQue.ClientID + "," + hidCustomer.ClientID + "');");
            rptInit();
            PageDataBind();
            Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
            Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
        }
        if (LSTR_Type == "I")
        {
            this.txtCASEID.Text = "";
            this.hidDEPTID.Value = "";
            this.hidEMPLID.Value = "";
            this.txtFileName.Text = "";
            this.hidFileID.Value = "";
            this.drpDEFECTIVE.SelectedIndex = 0;
            for (int i = 0; i < rptMLDCASEAPPENDDOC.Items.Count; i++)
            {
                ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = false;
            }
        }
        DisabledRPRINCIPAL();

        //Modify 20120716 By SS Gordon. Reason: 修改若承作方式為「銀行件」時，當修改案件時，承作型態與銀行別不可選擇
        if (this.drpSOURCETYPE.SelectedValue == "02")
        {
            this.drpMAINTYPE.Enabled = false;
            this.drpBANKCD.Enabled = false;
        }

        this.UpdatePanel1.Update();
        //JOHN 2011/11/08 營租型事務機 才給選代印店    
        if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
            this.drpPRINTSTORE.Enabled = true;
        else
        {
            this.drpPRINTSTORE.Enabled = false;
            this.drpPRINTSTORE.SelectedValue = "";
        }

        this.UpdatePanelPRINTSTORE.Update();
        //Modify 20130819 By SEAN Reason: 修改承作型態為「應收帳款受讓」時，交易型態不可選擇
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            this.drpTRANSTYPE.Enabled = false;
        }
        this.UpdatePaneldrpTRANSTYPE.Update();
    }
    protected void btnLoadCase_Click(object sender, EventArgs e)
    {
        this.lblStatus.Text = "新增";
        this.btnSave.Enabled = true;
        this.btnSubmit.Enabled = true;
        this.txtCASEID.Enabled = false;
        this.btnSelCus.Disabled = false;
        this.btnUpload.Enabled = true;
        this.cmdPrintReportA.Enabled = true;
        //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
        this.btnRej.Enabled = false;

        if (this.hidCustomer.Value != "")
        {
            rptInit();
            PageDataBind();
            this.btnC1.Disabled = false;
            this.btnC2.Disabled = false;
            this.btnC3.Disabled = false;
        }
        else
        {
            RegisterScript("SetDisabled('div_Info', '','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSelect.ClientID + "');");
            this.btnSubmit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnUpload.Enabled = false;
        }
        DisabledRPRINCIPAL();
        this.hidCustomer.Value = "";
        this.txtCASEID.Text = "";
        this.UpdatePanel1.Update();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
            if (drpMAINTYPE.SelectedValue != "04" && txtNOINSURANCEFLG.Checked == false)
            {
                //20131001 ADD BY ADAM Reason.營資租與營建機具才可以做保險費的錯誤判斷
                string strTARGETTYPE = "";
                if (rptMLDCASETARGET.Items.Count > 0)
                {
                    strTARGETTYPE = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedItem.Text.ToString().Trim();
                }
                if ((strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具") ||
                    (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02"))
                {
                    if (CheckINSUREERR())
                    {
                        return;
                    }
                }
            }
            //Modify 20130402 By SS Vicky. Reason: 在標的物的頁籤中，是事務機跟營建機具，則保險費要必填 start
            if (txtNOINSURANCEFLG.Checked == false && txtINSURANCE.Text.Trim() == "0")
            {
                for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
                {
                    //Modify 20130502 BY SS ADAM Reason:  BUG處理
                    string strMLDCASETARGET = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedItem.Text;
                    string strTARGETTYPE = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedItem.Text;
                    if ((strMLDCASETARGET.Length >= 4 && strMLDCASETARGET.Substring(0, 4).Trim() == "營建機具")
                        || (strTARGETTYPE.Length >= 3 && strTARGETTYPE.Substring(0, 3).Trim() == "事務機") || (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02"))
                    //Modify 20130814 BY CHRIS FU Reason: 新增承作型態1為營租、資租時保險費需大於0
                    {
                        Alert("案件內容中，「保險費」不可為零！");
                        return;
                    }
                }
            }
            //Modify 20130402 By SS Vicky. Reason: 在標的物的頁籤中，是事務機跟營建機具，則保險費要必填 end

            //Modify 20130416 By SS Gordon. Reason:存檔確認時，在擔保條件的頁籤中，保證人GRID的法人/個人選項若是選個人的話，則關係人一不可選承租企業
            for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
            {
                if (((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTTYPE")).SelectedValue == "1")
                {
                    //Modify 20130425 By SS Steven. Reason:保證人GRID的法人/個人選項若是選個人的話，則關係人一不可選承租企業語法修改
                    //if (((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1")).SelectedItem.Text.Substring(0, 4).Trim() == "承租企業")
                    if (((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1")).SelectedItem.Text.Trim() == "承租企業")
                    {
                        Alert("擔保條件中，「保證人」為[個人]時，[關係人一]不可選承租企業！");
                        return;
                    }
                }
            }

            //Modify 20120528 By SS Gordon. Reason: 檢核客戶資料中，「發票聯絡人」列為必輸入欄位
            if (rptContactI.Items.Count == 0)
            {
                Alert("客戶資料中，「發票聯絡人」為必輸入欄位！");
                return;
            }

            //20191203 ADD BY SS ADAM REASON.增加承作對象存檔檢核
            if (this.drpCASESOURCE.SelectedValue == "")
            {
                Alert("請選擇承作對象");
                return;
            }

            //JOHN 2012/1/5 營租型事務機 代印店 必須選擇
            //20221031代印店隱藏
            //if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01" && this.drpPRINTSTORE.SelectedValue == "")
            //{
            //    Alert("請選擇是否為代印店！");
            //    return;
            //}
            if (this.drpMAINTYPE.SelectedValue == "04")
            {
                //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
                if (this.drpRECOURSE.SelectedValue == "")
                {
                    Alert("請選擇附追索權");
                    return;
                }
            }
            else
            {
                double LINT_IRR = IRR_Cal();
                if (LINT_IRR > 100 || LINT_IRR < -100)
                {
                    Alert("試算異常！請檢核金額項目！");
                    this.txtIRR.Text = "0.000";
                    return;
                }
                else
                {
                    this.txtIRR.Text = LINT_IRR.ToString("0.000");
                }
                //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」欄位
                this.txtNPVRATECOST0.Text = "1";
                double LINT_NPV0 = NPV_Cal(txtNPVRATECOST0.Text);
                this.txtNPV0.Text = LINT_NPV0.ToString("0");

                //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
                ////Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
                //double LINT_NPVRATECOST = GET_NPVRATECOST();
                //this.txtNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
                //Modify 20240815 利率成本改4.75%
                //this.txtNPVRATECOST.Text = "4";
                this.txtNPVRATECOST.Text = "4.75";
                //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
                this.txtNPVRATECOST2.Text = "5";
                double LINT_NPV = NPV_Cal(txtNPVRATECOST.Text);
                double LINT_NPV2 = NPV_Cal(txtNPVRATECOST2.Text);
                this.txtNPV.Text = LINT_NPV.ToString("0");
                this.txtNPV2.Text = LINT_NPV2.ToString("0");
            }
        }
        catch (Exception ex)
        {
            Alert("試算異常！請檢核金額項目！！" + EscapeStringForJS(ex.Message));
            this.txtIRR.Text = "0.000";
            return;
        }
        this.UpdatePanelIRR.Update();
        this.UpdatePanelNPV.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPV2.Update();

        //Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNRC.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNRC2.Update();

        if (CheckTARGETRule())
        {
            MLMCASESave("4E");
        }
        this.UpdatePanel1.Update();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        if (drpMAINTYPE.SelectedValue != "04" && txtNOINSURANCEFLG.Checked == false)
        {
            //20131001 ADD BY ADAM Reason.營資租與營建機具才可以做保險費的錯誤判斷
            string strTARGETTYPE = "";
            if (rptMLDCASETARGET.Items.Count > 0)
            {
                strTARGETTYPE = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedItem.Text.ToString().Trim();
            }
            if ((strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具") ||
                (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02"))
            {
                if (CheckINSUREERR())
                {
                    return;
                }
            }
        }

        //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
        this.txtNPVRATECOST0.Text = "1";


        //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
        ////Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        //double LINT_NPVRATECOST = GET_NPVRATECOST();
        //this.txtNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
        //Modify 20240815 利率成本改4.75%
        //this.txtNPVRATECOST.Text = "4";
        this.txtNPVRATECOST.Text = "4.75";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtNPVRATECOST2.Text = "5";

        //Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNRC.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNRC2.Update();

        if (SaveCheckRule())
        {
            MLMCASESave("4D");
        }
        this.UpdatePanel1.Update();
    }

    //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
    protected void btnRej_Click(object sender, EventArgs e)
    {
        //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"4F"改成"4X"
        //MLMCASEREJ("4F");
        MLMCASEREJ("4X");
    }
    private void MLMCASEREJ(string LSTR_SaveType)
    {
        StringBuilder LSTR_Data = new StringBuilder();
        //案件主鍵
        LSTR_Data.Append("SP_ML1002_U03" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        if (LSTR_SaveType == "4")
        {
            LSTR_Data.Append("3" + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append("1");
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        LSTR_Data.Append("ML3000X" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================

        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                RegisterScript("alert('案件撤件完成！'); location.reload();");
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private ReturnObject<object> UpdateCaseInfo(string LSTR_Data)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        ReturnObject<object> LOBJ_Return;
        string[] LVAR_Parameter = new string[1];

        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_Data;
            LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    protected void btnCusQue_Click(object sender, EventArgs e)
    {
        string LSTR_CUSTID = this.hidCustomer.Value.Substring(1).Split(';')[0];
        if (!string.IsNullOrEmpty(LSTR_CUSTID))
        {
            try
            {
                ReturnObject<DataSet> LOBJ_ReturnObject = GetCustomerDataByID(LSTR_CUSTID);
                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                    GetCustomerBind(LDST_Data.Tables[0]);
                    rptInit();
                    rptDataBind();
                }
                else
                {
                    Alert(LOBJ_ReturnObject.ReturnMessage);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
            this.btnC1.Disabled = false;
            this.btnC2.Disabled = false;
            this.btnC3.Disabled = false;
            this.btnSubmit.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnUpload.Enabled = true;
            this.txtCUSTID.Enabled = false;
            this.cmdPrintReportA.Enabled = true;
            //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
            this.btnRej.Enabled = false;
        }
        this.UpdatePanel1.Update();
    }

    //Modify 20120716 By SS Gordon. Reason: 新增承作方式.
    protected void drpSOURCETYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpSOURCETYPE.SelectedValue == "02")
        {
            this.drpMAINTYPE.SelectedValue = "03";
            this.drpMAINTYPE_SelectedIndexChanged(null, null);
            this.drpUSESTATUS.SelectedValue = "01";
            this.drpCYCLETYPE.SelectedValue = "02";
            this.drpBANKCD.SelectedValue = "01";
            this.drpMAINTYPE.Enabled = false;
            this.drpUSESTATUS.Enabled = false;
            this.drpCYCLETYPE.Enabled = false;
            this.drpBANKCD.Enabled = false;

            //Modify 20121112 By SS Steven. Reason: 承作方式為銀行件的情況下，承作型態2選項就選原物料分期並且反灰
            this.drpSUBTYPE.SelectedValue = "01";
            this.drpSUBTYPE.Enabled = false;
        }
        else
        {
            this.drpMAINTYPE.SelectedValue = "01";
            this.drpMAINTYPE_SelectedIndexChanged(null, null);
            this.drpUSESTATUS.SelectedValue = "01";
            this.drpCYCLETYPE.SelectedValue = "02";
            this.drpBANKCD.SelectedValue = "";
            this.drpMAINTYPE.Enabled = true;
            this.drpUSESTATUS.Enabled = true;
            this.drpCYCLETYPE.Enabled = true;
            this.drpBANKCD.Enabled = false;
        }
        this.UpdatePanel1.Update();
    }

    protected void drpMAINTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
        drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
        //drpEXPIREPROCBindbyID(LSTR_MAINTYPEID);
        SetMAINTYPERDO(LSTR_MAINTYPEID);
        DisabledRPRINCIPAL();

        //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            this.drpRECOURSE.Enabled = true;
        }
        else
        {
            this.drpRECOURSE.SelectedValue = "";
            this.drpRECOURSE.Enabled = false;
        }
        this.UpdatePanelRECOURSE.Update();

        //Modify 20130819 By SEAN Reason: 修改承作型態為「應收帳款受讓」時，交易型態固定兩方
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            this.drpTRANSTYPE.Enabled = false;
            this.drpTRANSTYPE.SelectedValue = "01";
        }
        else
        {
            this.drpTRANSTYPE.Enabled = true;
        }
        this.UpdatePaneldrpTRANSTYPE.Update();

        //Modify 20150205 By SS ChrisFu Reason: 承作型態為「應收帳款受讓」時，付款方式預設值為「套票」，付款差異天數與付供應商天數預設值為「0」
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            this.drpPAYTPE.SelectedValue = "03";        //套票(整組還款票據)
            this.txtPATDAYS.Text = "0";                 //付款差異天數
            this.txtSUPPILERDAYS.Text = "0";            //付供應商天數
        }
        this.UpdatePanel8.Update();

        //JOHN 2011/11/08 營租型事務機 才給選代印店    
        if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
            this.drpPRINTSTORE.Enabled = true;
        else
        {
            this.drpPRINTSTORE.Enabled = false;
            this.drpPRINTSTORE.SelectedValue = "";
        }
        this.UpdatePanelPRINTSTORE.Update();


        if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
        {
            //營租事物機 和 資租事物機 資金成本要固定為 5%
            //其他承作類型 為7%
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "5";
            this.txtCAPITALCOST.Text = "4";
        }
        else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
        {
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "5";
            this.txtCAPITALCOST.Text = "4";
        }
        else
        {
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "7";
            this.txtCAPITALCOST.Text = "4";
        }

        //20200213 ADD BY SS ADAM REASON.增加營租鎖定頭期款欄位
        if (this.drpMAINTYPE.SelectedValue == "01")
        {
            this.txtFIRSTPAY.Text = "0";
            this.txtFIRSTPAY.Enabled = false;
        }
        else
        {
            this.txtFIRSTPAY.Enabled = true;
        }

        this.UpdatePanelCAP.Update();
        MLDCASEAPPENDDOCBind();
        this.hidShowTag.Value = "fraTab22Caption";
        this.UpdatePaneldrpSUBTYPE.Update();
        this.UpdatePanel2.Update();
        this.UpdatePanel3.Update();
        this.UpdatePanel4.Update();
        this.UpdatePanel5.Update();
        this.UpdatePanel6.Update();
        this.UpdatePanel7.Update();
        this.UpdatePanelMLDCASEAPPENDDOC.Update();
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }

    protected void drpSUBTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        //JOHN 2011/11/08 營租型事務機 才給選代印店      
        if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
            this.drpPRINTSTORE.Enabled = true;
        else
        {
            this.drpPRINTSTORE.Enabled = false;
            this.drpPRINTSTORE.SelectedValue = "";
        }
        this.UpdatePanelPRINTSTORE.Update();
        if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
        {
            //營租事物機 和 資租事物機 資金成本要固定為 5%
            //其他承作類型 為7%
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "5";
            this.txtCAPITALCOST.Text = "4";
        }
        else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
        {
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "5";
            this.txtCAPITALCOST.Text = "4";
        }
        else
        {
            //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
            //this.txtCAPITALCOST.Text = "7";
            this.txtCAPITALCOST.Text = "4";
        }
        this.UpdatePanelCAP.Update();
        //MLDCASEAPPENDDOCBind();
        //this.UpdatePanelMLDCASEAPPENDDOC.Update();

    }
    protected void drpTRANSTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        //20221031 改為隱藏
        //MLDCASEAPPENDDOCBind();
        //this.UpdatePanelMLDCASEAPPENDDOC.Update();

    }

    private void drpSUBTYPEaEXPIREPROCBindbyID(string LSTR_MAINTYPEID)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                //Modify 20120716 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」
                DataView LDVW = LDST_Data.Tables[0].DefaultView;
                if (this.drpSOURCETYPE.SelectedValue == "02")
                {
                    LDVW.RowFilter = "DCODE IN ('01','03')";
                }
                //this.drpSUBTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpSUBTYPE.DataSource = LDVW;
                this.drpSUBTYPE.DataBind();

                this.drpEXPIREPROC.DataSource = LDST_Data.Tables[1].DefaultView;
                this.drpEXPIREPROC.DataBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void MLMCASESave(string LSTR_SaveType)
    {
        //判斷txtCasetid是否有值，沒有就新生成一個
        string LSTR_CASEID = this.txtCASEID.Text.Trim();
        string LSTR_Status = this.lblStatus.Text;
        if (string.IsNullOrEmpty(LSTR_CASEID))
        {
            //處別暫時無法獲取，且定為A
            string LSTR_COMTYPE = this.drpCOMPID.SelectedValue;
            LSTR_COMTYPE = LSTR_COMTYPE == "01" ? "A" : "B";
            // 因應新增部門, 第二碼超過10就轉換成16進位
            //string LSTR_DEPTID = (Convert.ToInt16(Convert.ToChar(GSTR_DEPTID.Substring(2, 1))) - 64).ToString();
            string LSTR_DEPTID = Convert.ToString((Convert.ToInt16(Convert.ToChar(GSTR_DEPTID.Substring(2, 1))) - 64), 16).ToUpper();
            LSTR_CASEID = LSTR_COMTYPE +
                          LSTR_DEPTID +
                          Itg.Community.Util.GetRepYear(GSTR_U_SYSDT).Substring(0, 4) +
                          Itg.Community.Util.GetRepYear(GSTR_U_SYSDT).Substring(5, 2) +
                          Itg.Community.Util.GetCASEIDSequence("MLMCASE");
            this.txtCASEID.Text = LSTR_CASEID;
        }
        //LSTR_SaveType暫存為4D,提交為4E
        StringBuilder LSTR_Data = new StringBuilder();
        //更新客戶身份ID，傳真信息
        //=========================================================================
        LSTR_Data = new StringBuilder();
        LSTR_Data.Append("SP_ML1002_U01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtOWNERID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCUSTFAX.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtBUSINESSFAX.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCUSTFAXCODE.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtBUSINESSFAXCODE.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
        LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data.Append("SP_ML1002_U02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
        LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        SaveINVZIP();
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        int LINT_ConNum = LOBJ_Contact.Rows.Count;
        if (LINT_ConNum > 0)
        {
            //案件聯絡人
            for (int rowCon = 0; rowCon < LINT_ConNum; rowCon++)
            {
                LSTR_Data.Append("SP_ML1002_I02" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                LSTR_Data.Append(LOBJ_Contact.Rows[rowCon]["CONTACTID"].ToString().Trim() + GSTR_TabDelimitChar);
                LSTR_Data.Append(LOBJ_Contact.Rows[rowCon]["CONTACTTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
                LSTR_Data.Append(LOBJ_Contact.Rows[rowCon]["INVZIPCODE"].ToString().Trim() + GSTR_TabDelimitChar);
                LSTR_Data.Append(LOBJ_Contact.Rows[rowCon]["INVOICEADDR"].ToString().Trim() + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        LSTR_Data.Append("SP_ML1002_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpCOMPID.SelectedValue.Trim() + GSTR_TabDelimitChar);
        if (this.hidDEPTID.Value == "")
        {
            LSTR_Data.Append(GSTR_DEPTID + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(this.hidDEPTID.Value + GSTR_TabDelimitChar);
        }
        if (this.hidEMPLID.Value == "")
        {
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(this.hidEMPLID.Value + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(this.drpDEFECTIVE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        //Modify 20120716 By SS Gordon. Reason: 新增承作方式.
        LSTR_Data.Append(this.drpSOURCETYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpMAINTYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpSUBTYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpTRANSTYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        //Modify 20120716 By SS Gordon. Reason: 新增銀行別.
        LSTR_Data.Append(this.drpBANKCD.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpUSESTATUS.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpCYCLETYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpCASESOURCE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpPAYTPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtPATDAYS.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtSUPPILERDAYS.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtIRR.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRECOVERTEST.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCAPITALCOST.Text.Trim().Replace("%", "") + GSTR_TabDelimitChar);

        //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
        LSTR_Data.Append(this.txtNPV0.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtNPVRATECOST0.Text.Trim() + GSTR_TabDelimitChar);

        LSTR_Data.Append(this.txtNPV.Text.Trim() + GSTR_TabDelimitChar);
        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
        LSTR_Data.Append(this.txtNPVRATECOST.Text.Trim() + GSTR_TabDelimitChar);
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        LSTR_Data.Append(this.txtNPV2.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtNPVRATECOST2.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpEXPIREPROC.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtEXPIREPROCDESC.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidFileID.Value.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(Request.Form.GetValues("txtFileName")[0].Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtOTHERCOND.Text.Trim() + GSTR_TabDelimitChar);
        if (chkOneMLDCASETARGETSTR.Checked == true)
        {
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);//暫存為4D,提交為4E
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        string LSTR_CreateData = hidOldData.Value;
        if (LSTR_CreateData.IndexOf(";") != -1)
        {
            LSTR_Data.Append(LSTR_CreateData.Split(';')[0] + GSTR_TabDelimitChar);
            LSTR_Data.Append(Convert.ToDateTime(LSTR_CreateData.Split(';')[1]).ToString("yyyy/MM/dd HH:mm:ss") + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        //john.chen 2011/11/03 增加欄位
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpPRINTSTORE.SelectedValue);
        //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpRECOURSE.SelectedValue);
        //Modify 20150121 By SS Eric    Reason:新增「專案別」下拉選單
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpPROJCD.SelectedValue);

        //Modify 20150205 By SS ChrisFu Reason:新增「建議墊款息」欄位
        LSTR_Data.Append(GSTR_TabDelimitChar + Itg.Community.Util.NumberToDb(this.txtADVANCESINTEREST.Text.Trim()));
        //20160321 ADD BY SS ADAM REASON.新增案件產品別
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpPRODCD.SelectedValue);
        //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
        LSTR_Data.Append(GSTR_TabDelimitChar + this.hidFileID2.Value.Trim());
        LSTR_Data.Append(GSTR_TabDelimitChar + Request.Form.GetValues("txtFileName2")[0].Trim());
        LSTR_Data.Append(GSTR_TabDelimitChar + this.hidFileID3.Value.Trim());
        LSTR_Data.Append(GSTR_TabDelimitChar + Request.Form.GetValues("txtFileName3")[0].Trim());
        LSTR_Data.Append(GSTR_TabDelimitChar + this.hidFileID4.Value.Trim());
        LSTR_Data.Append(GSTR_TabDelimitChar + Request.Form.GetValues("txtFileName4")[0].Trim());


        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        //20231130 新增專案名稱
        LSTR_Data.Append("SP_ML1002_I19" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpPROJECT.SelectedItem.Text.Trim());
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        if (rdoMLDCASEINST.Checked == true)
        {
            //租賃分期案件資料
            LSTR_Data.Append("SP_ML1002_I03" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.hidTRANSCOST.Value.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtFEE.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtCOMMISSION.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtINSURANCE.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtFIRSTPAY.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.hidACTUSLLOANS.Value.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtOTHERFEES.Text.Trim()) + GSTR_TabDelimitChar);
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtOTHERFEESNOTAX.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPERBOND.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPURCHASEMARGIN.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRESIDUALS.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtCONTRACTMONTH.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtPAYMONTH.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpPAYTIMET.SelectedValue.Trim() + GSTR_TabDelimitChar);
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            if (this.txtNOINSURANCEFLG.Checked == true)
            {
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //=========================================================================
            //租賃分期案件分期明細
            //第一行
            LSTR_Data.Append("SP_ML1002_I04" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDPAY1.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPAL1.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPALTAX1.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第二行
            LSTR_Data.Append("SP_ML1002_I04" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtSTARTPAY2.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDPAY2.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPAL2.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPALTAX2.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第三行
            LSTR_Data.Append("SP_ML1002_I04" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtSTARTPAY3.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDPAY3.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPAL3.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPALTAX3.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第四行
            LSTR_Data.Append("SP_ML1002_I04" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtSTARTPAY4.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDPAY4.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPAL4.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPRINCIPALTAX4.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        else
        {
            //應收帳款案件
            LSTR_Data.Append("SP_ML1002_I05" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtAPLIMIT.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtCREDITFEES.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtMANAGERFEES.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtFINANCIALFEES.Text.Trim()) + GSTR_TabDelimitChar);
            //Modify 20150205 By SS ChrisFu Reason:「成數」由TextBox改為下拉選單
            //LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtPERCENTAGE.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.drpPERCENTAGE.SelectedValue.Trim()) + GSTR_TabDelimitChar);

            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtACCOUNTSTERM.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpPAYTIMEA.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtBUYERLIMIT.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtARIRR.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtINTERSET.Text.Trim()) + GSTR_TabDelimitChar);
            //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtARPERBOND.Text.Trim()) + GSTR_TabDelimitChar);

            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //=========================================================================
        //征審資料
        for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++)
        {
            string LSTR_DocumentID = ((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDocID")).Value.Trim();
            if (LSTR_DocumentID != "")
            {
                LSTR_Data.Append("SP_ML1002_I06" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_APPENDDOCID = ((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidAPPENDDOCID")).Value.ToString().Trim();
                if (LSTR_APPENDDOCID == "" || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEAPPENDDOC", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_APPENDDOCID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(LSTR_DocumentID + GSTR_TabDelimitChar);
                if (((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblDName2")).Text == "")
                {
                    LSTR_Data.Append("2" + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append("1" + GSTR_TabDelimitChar);
                }
                if (((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
                {
                    LSTR_Data.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append("2" + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("txtNOTE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //標的物主檔
        //MLDCASETARGET
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I07" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_TARGETIDID = ((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim();
                if (LSTR_TARGETIDID == "" || LSTR_Status == "新增")
                {
                    string LSTR_GUID = Itg.Community.Util.GetIDSequence("MLDCASETARGET", "14");
                    LSTR_Data.Append(LSTR_GUID + GSTR_TabDelimitChar);
                    ((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value = LSTR_GUID;
                }
                else
                {
                    LSTR_Data.Append(LSTR_TARGETIDID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0] + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMODELNO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMACHINENO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text + GSTR_TabDelimitChar);
                string LSTR_TARGETPRICE = Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text);
                LSTR_Data.Append(LSTR_TARGETPRICE + GSTR_TabDelimitChar);
                if (LSTR_TARGETPRICE == "" || LSTR_TARGETPRICE == "0")
                {
                    LSTR_Data.Append(LSTR_TARGETPRICE + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append((Convert.ToDouble(LSTR_TARGETPRICE) / 1.05).ToString("0") + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("01" + GSTR_TabDelimitChar);

                //Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtMANUFACTURER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETBRAND")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETUNIT")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETCOUNT")).Text + GSTR_TabDelimitChar);

                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //標的物子檔
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            //MLDCASEGUARANTEE
            int LINT_SNum = 0;
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I08" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim() + GSTR_TabDelimitChar);
                if (chkOneMLDCASETARGETSTR.Checked == false)
                {
                    LINT_SNum = i;
                }
                //LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASETARGETSTR", "14") + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim() + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtSTOREDZIPCODE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtSTOREDADDR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtDEPTNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTITLE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTEL")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTELEXT")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTMPHONE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTFAX")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTEMAIL")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTELCODE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTFAXCODE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //案件申請保證人資料明細檔
        if (rptMLDCASEGUARANTEE.Items.Count > 0 && chkMLDCASEGUARANTEE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEGUARANTEE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCODE")).Text.Trim() == "" || ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTNAME")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I09" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_GRTID = ((HiddenField)rptMLDCASEGUARANTEE.Items[i].FindControl("hidGRTID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_GRTID) || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEGUARANTEE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_GRTID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTTYPE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCODE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTNAME")).Text + GSTR_TabDelimitChar);
                //Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTBIRDT")).Text.Replace("/", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTSEX")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTZIP")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTADDR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTZIP")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTADDR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTELCODE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTEL")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTELEXT")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCOMPANY")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION2")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOBCLS")).SelectedValue + GSTR_TabDelimitChar);
                //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILL")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILLTYPE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGUARANTEEANOUNT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //動產設定
        //MLDCASEMOVABLE
        if (rptMLDCASEMOVABLE.Items.Count > 0 && chkMLDCASEMOVABLE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEMOVABLE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENAME")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I10" + GSTR_ColDelimitChar);
                //ADD BY VICKY 20130411 將項次改為TEXTBOX
                //LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEORDER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_MOVABLEID = ((HiddenField)rptMLDCASEMOVABLE.Items[i].FindControl("hidMOVABLEID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_MOVABLEID) || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEMOVABLE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_MOVABLEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEMOVABLE.Items[i].FindControl("drpMOVABLEETARGET")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODE")).Text + GSTR_TabDelimitChar);
                ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODES")).Text = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODES")).Text;
                LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEADDR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENEWAMT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYAMT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESIDUALS")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //不動產設定
        //MLDCASEIMMOVABLE
        if (rptMLDCASEIMMOVABLE.Items.Count > 0 && chkMLDCASEIMMOVABLE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEIMMOVABLE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEOWNER")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I11" + GSTR_ColDelimitChar);
                //ADD BY VICKY 20130411 將項次改為TEXTBOX
                //LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEORDER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_IMMOVABLEID = ((HiddenField)rptMLDCASEIMMOVABLE.Items[i].FindControl("hidIMMOVABLEID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_IMMOVABLEID) || LSTR_Status == "新增")
                {
                    string LSTR_Guid = Itg.Community.Util.GetIDSequence("MLDCASEIMMOVABLE", "12");
                    LSTR_Data.Append(LSTR_Guid + GSTR_TabDelimitChar);
                    ((HiddenField)rptMLDCASEIMMOVABLE.Items[i].FindControl("hidIMMOVABLEID")).Value = LSTR_Guid;
                }
                else
                {
                    LSTR_Data.Append(LSTR_IMMOVABLEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEOWNER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEOWNERID")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEGETDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLESECTOR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILD")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEAREA")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEHOLDER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDNO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEHOUSENUM")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDAREA")).Text + GSTR_TabDelimitChar);
                string LSTR_Area = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDAREA")).Text.ToString();
                double LINT_Area = LSTR_Area == "" ? 0 : Convert.ToDouble(LSTR_Area);
                ((Label)rptMLDCASEIMMOVABLE.Items[i].FindControl("lblIMMOVABLEBUILDAREA")).Text = (LINT_Area * 0.3025).ToString("0.00");
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //1002F_案件申請不動產權利人明細
        //MLDHUMANRIGHTS
        if (rptMLDCASEIMMOVABLE.Items.Count > 0 && chkMLDCASEIMMOVABLE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEIMMOVABLE.Items.Count; i++)
            {
                if (((HiddenField)rptMLDCASEIMMOVABLE.Items[i].FindControl("hidIMMOVABLEID")).Value.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I12" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                // 20130422 ADD BY ADAM REASON.改採用不動產順位設定決定
                LSTR_Data.Append(((HiddenField)rptMLDCASEIMMOVABLE.Items[i].FindControl("hidIMMOVABLEID")).Value.ToString() + GSTR_TabDelimitChar);
                //string txtMLDCASEIMMOVABLE = ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtMLDCASEIMMOVABLE")).Text;
                //LSTR_Data.Append(((HiddenField)rptMLDCASEIMMOVABLE.Items[int.Parse(txtMLDCASEIMMOVABLE)-1].FindControl("hidIMMOVABLEID")).Value.ToString() + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtHUMANRIGHTS")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtSETPRICE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtCREDITOR")).Text + GSTR_TabDelimitChar);
                //20130521 ADD BY ADAM Reason.增加權利人欄位IDMEMO處理
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtMLDCASEIMMOVABLE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //1002F_定存單質押
        //MLDCASEADEPOSIT
        if (rptMLDCASEADEPOSIT.Items.Count > 0 && chkMLDCASEADEPOSIT.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEADEPOSIT.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITNBR")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I13" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_DEPOSITID = ((HiddenField)rptMLDCASEADEPOSIT.Items[i].FindControl("hidDEPOSITID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_DEPOSITID) || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEADEPOSIT", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_DEPOSITID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITBANK")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITNBR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITAMT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITSTARTDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITDUEDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //客票
        //MLDCASEBILLNOTE
        if (rptMLDCASEBILLNOTE.Items.Count > 0 && chkMLDCASEBILLNOTE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEBILLNOTE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTENBR")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I14" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_DEPOSITID = ((HiddenField)rptMLDCASEBILLNOTE.Items[i].FindControl("hidBILLNOTEID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_DEPOSITID) || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASEBILLNOTE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_DEPOSITID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEBANK")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASEBILLNOTE.Items[i].FindControl("drpBILLNOTETYPE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTENBR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtACCOUNT")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTECUSTNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEAMT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTENOTE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEBACKDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //股票
        //MLDCASESTOCK
        if (rptMLDCASESTOCK.Items.Count > 0 && chkMLDCASESTOCK.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASESTOCK.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKNAME")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML1002_I15" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_STOCKID = ((HiddenField)rptMLDCASESTOCK.Items[i].FindControl("hidSTOCKID")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_STOCKID) || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASESTOCK", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_STOCKID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKPROVIDER")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKUNIT")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKQUANTITY")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKTOTAL")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKBEGIN")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKEND")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASESTOCK.Items[i].FindControl("drpSTOCKINSURANCE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKNOTE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================      
        if (Convert.ToDouble(this.txtIRR.Text) != 0 && drpMAINTYPE.SelectedValue != "04")
        {
            //MLDCASECASHFLOW
            //期數
            int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
            Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
            LDBL_VALUE = PPMT_Cal();
            for (int i = 0; i < LDBL_VALUE.GetUpperBound(0) + 1; i++)
            {
                LSTR_Data.Append("SP_ML1002_I16" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCASECASHFLOW", "14") + GSTR_TabDelimitChar);
                //期數[][0] 期付款[][1]	期付款[][2]	利息[][3] 現金流量[][4]	        
                LSTR_Data.Append(LDBL_VALUE[i][0] + GSTR_TabDelimitChar);
                LSTR_Data.Append(LDBL_VALUE[i][2] + GSTR_TabDelimitChar);
                LSTR_Data.Append(LDBL_VALUE[i][3] + GSTR_TabDelimitChar);
                LSTR_Data.Append(LDBL_VALUE[i][4] + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        //=========================================================================
        //CHRIS
        //if (lblStatus.Text == "新增")
        //{
        //    //Alert("SP_ML1002_I17");
        //    LSTR_Data.Append("SP_ML1002_I17" + GSTR_ColDelimitChar);
        //    LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        //    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        //    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        //    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        //    LSTR_Data.Append(GSTR_ColDelimitChar);
        //    LSTR_Data.Append(GSTR_RowDelimitChar);
        //}

        //Modify 20130814 BY CHRIS FU Reason: 新增若保險異常勾選時，資料清除
        if (txtNOINSURANCEFLG.Checked == true)
        {
            txtINSURANCE.Text = "0";
            //Alert("SP_ML1002_D01");
            LSTR_Data.Append("SP_ML1002_D01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //=========================================================================
        //Modify 20121112 By SS Steven. Reason: 以下三個條件有一個成立，跳出視窗訊息提醒，假如是作業確認就要發email通知
        //Modify 20121123 By SS ADAM. Reason:只要三個條件成立，不需要發MAIL
        if (SendEmailCheck() && false)
        {
            LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append("ML3000MSG" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //=========================================================================

        //MLVERIFY
        if (LSTR_SaveType == "4E")
        {
            //MLVERIFY SP_ML9001_I01
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("4D" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("1");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("4E" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("1");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = SaveCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab11Caption";
                if (LSTR_SaveType == "4D")
                {
                    this.hidCustomer.Value = this.hidCustomer.Value.Substring(0, 1) + this.hidCustomer.Value.Substring(1).Split(';')[0] + ";" + LSTR_CASEID;
                    PageDataBind();
                    Alert("暫存成功！");
                    this.lblStatus.Text = "修改";
                }
                else
                {
                    Alert("進件完成！請通知主管至LE3001批准。");
                    this.btnInsert.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnSelect.Enabled = true;
                    this.btnLoadCase.Enabled = false;

                    this.btnSave.Enabled = false;
                    this.btnSubmit.Enabled = false;
                    this.btnUpload.Enabled = false;
                    //Modify 20120607 By SS Gordon. Reason: 新增案件撤件按鈕.
                    this.btnRej.Enabled = false;

                    this.lblStatus.Text = "";
                    this.hidCustomer.Value = this.hidCustomer.Value.Substring(0, 1) + this.hidCustomer.Value.Substring(1).Split(';')[0] + ";" + LSTR_CASEID;
                    PageDataBind();
                    if (LSTR_SaveType == "4D") { }
                    else
                    {
                        this.txtSYSDT.Text = Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd"));
                    }
                    this.btnC1.Disabled = true;
                    this.btnC2.Disabled = true;
                    this.btnC3.Disabled = true;
                    this.btnSelCus.Disabled = true;
                    Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
                    Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
                    RegisterScript("SetDisabled('div_Info', '" + this.btnIRR.ClientID + "," + this.btnMLDCASETARGETEmport.ClientID + "," + this.btnMLDCASETARGETCopy.ClientID + "," + this.fldMLDCASETARGETEmport.ClientID + "','" + btnInsert.ClientID + "," + btnUpdate.ClientID + "," + btnSelect.ClientID + "," + btnCaseQue.ClientID + "," + hidCustomer.ClientID + "');");
                }
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private bool SaveCheckRule()
    {
        if (this.txtCUSTID.Text == "")
        {
            Alert("請選擇一個客戶進行操作！");
            return false;
        }
        return true;
    }
    private void PageDataBind()
    {
        string LSTR_CaseMsg = this.hidCustomer.Value.Substring(1);
        string LSTR_CUSTID = LSTR_CaseMsg.Split(';')[0];
        string LSTR_CASEID = LSTR_CaseMsg.Split(';')[1];
        if (!string.IsNullOrEmpty(LSTR_CUSTID))
        {
            try
            {
                ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByID(LSTR_CUSTID, LSTR_CASEID);
                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                    //绑定客户
                    GetCustomerBind(LDST_Data.Tables[0]);
                    //绑定联络人
                    ViewState["Contact"] = LDST_Data.Tables[1];
                    rptContactMBind();
                    rptContactCBind();
                    rptContactIBind();
                    //綁案件
                    GetCaseBind(LDST_Data.Tables[2]);
                    //判斷案件類型
                    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                    drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
                    drpSUBTYPE.SelectedValue = LDST_Data.Tables[2].Rows[0]["SUBTYPE"].ToString().Trim();

                    drpEXPIREPROC.SelectedValue = LDST_Data.Tables[2].Rows[0]["EXPIREPROC"].ToString().Trim();
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME"].ToString() != "")
                    {
                        //案件下載
                        this.btnOnload.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "');return false;";
                    }
                    //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME2"].ToString() != "")
                    {
                        //案件下載
                        this.btnOnload2.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID2"].ToString().Trim() + "');return false;";
                    }
                    //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME3"].ToString() != "")
                    {
                        //案件下載
                        this.btnOnload3.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID3"].ToString().Trim() + "');return false;";
                    }
                    //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME4"].ToString() != "")
                    {
                        //案件下載
                        this.btnOnload4.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID4"].ToString().Trim() + "');return false;";
                    }
                    //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
                    drpRECOURSE.SelectedValue = LDST_Data.Tables[2].Rows[0]["RECOURSE"].ToString().Trim();
                    //Modify 20150121 By SS Eric    Reason:新增「專案別」下拉選單
                    drpPROJCD.SelectedValue = LDST_Data.Tables[2].Rows[0]["PROJCD"].ToString().Trim();
                    //Modify 20150205 By SS ChrisFu Reason:新增「建議墊款息」欄位
                    txtADVANCESINTEREST.Text = LDST_Data.Tables[2].Rows[0]["ADVANCESINTEREST"].ToString().Trim();


                    if (this.drpMAINTYPE.SelectedValue == "04")
                    {
                        drpRECOURSE.Enabled = true;
                    }
                    else
                    {
                        drpRECOURSE.Enabled = false;
                    }
                    this.UpdatePanelRECOURSE.Update();

                    if (LSTR_MAINTYPEID == "04")
                    {
                        SetPrDisAbled();
                        //綁定應收帳款案件
                        GetMLDCASEARDATABind(LDST_Data.Tables[3]);
                        chkAr.Checked = true;
                    }
                    else
                    {
                        SetARDisAbled();
                        //綁定分期租賃案件
                        GetMLDCASEINSTBind(LDST_Data.Tables[4]);
                        GetMLDCASEINSTDBind(LDST_Data.Tables[5]);
                        chkAr.Checked = false;
                        //標的物
                        GetMLDCASETARGETBind(LDST_Data.Tables[7]);
                    }
                    if (LSTR_MAINTYPEID == "01")
                    {
                        this.txtPURCHASEMARGIN.Enabled = true;

                    }
                    else
                    {
                        this.txtPURCHASEMARGIN.Enabled = false;
                        this.txtPURCHASEMARGIN.Text = "0";
                    }
                    if (LSTR_MAINTYPEID == "04")
                    {
                        this.txtFIRSTPAY.Enabled = false;
                        this.txtFIRSTPAY.Text = "0";
                    }
                    else
                    {
                        this.txtFIRSTPAY.Enabled = true;
                    }
                    //征審資料
                    GetMLDCASEAPPENDDOCBind(LDST_Data.Tables[6]);
                    //保證人
                    GetMLDCASEGUARANTEEBind(LDST_Data.Tables[8]);
                    //動產設定
                    GetMLDCASEMOVABLEBind(LDST_Data.Tables[9]);
                    //不動產設定
                    GetMLDCASEIMMOVABLEBind(LDST_Data.Tables[10]);
                    //定存單質押
                    GetMLDCASEADEPOSITBind(LDST_Data.Tables[11]);
                    //客票
                    GetMLDCASEBILLNOTEBind(LDST_Data.Tables[12]);
                    //股票
                    GetMLDCASESTOCKBind(LDST_Data.Tables[13]);
                    //Modify 20121224 By SS Gordon. Reason:修正案件資料另外儲存，以便修改後的檢核。檢核資料從PRE資料表取得
                    if (LSTR_MAINTYPEID == "04")
                    {

                        //綁定應收帳款案件
                        GetMLPREDCASEARDATABind(LDST_Data.Tables[14]);
                    }
                    else
                    {

                        //綁定分期租賃案件
                        GetMLPREDCASEINSTBind(LDST_Data.Tables[15]);
                    }

                    //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
                    GetMLPREMCASEBind(LDST_Data.Tables[16]);

                    rptDataBind();
                    this.txtBUSINESS.Width = 500;

                    //20231130ADD選定專案
                    btnPROJECT_Click(null, null);
                    drpPROJECT.SelectedValue = LDST_Data.Tables[17].Rows[0]["PROJID"].ToString().Trim();
                    hidPROJECT.SelectedValue = LDST_Data.Tables[17].Rows[0]["DISCAMT"].ToString().Trim();

                    //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
                    hidMAINTYPE.Value = drpMAINTYPE.SelectedValue;
                    hidSUBTYPE.Value = drpSUBTYPE.SelectedValue;
                    hidTARGETPRICE.Value = hidTRANSCOST.Value;
                    if (rptMLDCASETARGET.Items.Count > 0)
                    {
                        hidTARGETTYPE.Value = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.ToString();
                    }

                    //20170706 ADD BY SS ADAM REASON.欄位調整
                    drpPROJCD.Enabled = false;
                    drpCOMPID.Enabled = false;
                    //drpPRINTSTORE.Enabled = false;
                    drpBANKCD.Enabled = false;
                    drpCASESOURCE.Enabled = false;

                    //20200213 ADD BY SS ADAM REASON.增加營租鎖定頭期款欄位
                    if (this.drpMAINTYPE.SelectedValue == "01")
                    {
                        txtFIRSTPAY.Enabled = false;
                    }
                }
                else
                {
                    Alert(LOBJ_ReturnObject.ReturnMessage);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }
    protected void btnPROJECT_Click(object sender, EventArgs e)
    {
        if (this.rptMLDCASETARGET.Items.Count < 1)
        {
            Alert("最少要有一筆標的物！");
            return;
        }
        //20231130新增專案下拉選單
        ReturnObject<DataSet> LOBJ_ReturnObject1 = GetPROJECTData();
        if (LOBJ_ReturnObject1 != null && LOBJ_ReturnObject1.ReturnSuccess)
        {
            DataSet LDST_Data = LOBJ_ReturnObject1.ReturnData;
            if (LDST_Data.Tables.Count > 0 && LDST_Data.Tables[0].Rows.Count > 0)
            {
                this.drpPROJECT.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpPROJECT.DataBind();
                this.hidPROJECT.DataSource = LDST_Data.Tables[0].DefaultView;
                this.hidPROJECT.DataBind();
                this.hidPROJECT.SelectedValue = LDST_Data.Tables[0].Rows[0]["DISCAMT"].ToString().Trim();
                //Alert(LDST_Data.Tables[0].Rows[0]["DISCAMT"].ToString().Trim());
                this.drpPROJECT.Items.Insert(0, new ListItem("請選擇", "0"));
                this.hidPROJECT.Items.Insert(0, new ListItem("0", "0"));
                //Alert("test");
            }
            else
            {
                this.drpPROJECT.Items.Clear();
                this.drpPROJECT.Items.Insert(0, new ListItem("無", "0"));
                //Alert(LOBJ_ReturnObject1.ReturnMessage);
            }
        }
    }
    protected void drpPROJECT_SelectedIndexChanged(object sender, EventArgs e)
    {
        hidPROJECT.SelectedIndex = drpPROJECT.SelectedIndex;
        //Alert(drpPROJECT.SelectedIndex.ToString() +" "+hidPROJECT.SelectedIndex.ToString());
    }
    private ReturnObject<DataSet> GetPROJECTData()
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        string ISCINS;
        ReturnObject<DataSet> LOBJ_Return = null;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //專案選單
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (string.IsNullOrEmpty(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text))
                {
                    Alert("標的物供應商不可為空白！");
                }
                else
                {
                    if (this.txtNOINSURANCEFLG.Checked == true || this.txtINSURANCE.Text == "0")
                    {
                        ISCINS = "0"; //不含險
                    }
                    else
                    {
                        ISCINS = "1"; //含險
                    }
                    LSTR_StoreProcedure.Append("SP_ML1002_Q25" + GSTR_RowDelimitChar);
                    //LSTR_QueryCondition.Append(" AND TARGETTYPE =''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0] + "''" + GSTR_TabDelimitChar);
                    //LSTR_QueryCondition.Append(" AND SUPPLIERID IN('''',''" + ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text + "'')" + GSTR_TabDelimitChar);
                    //LSTR_QueryCondition.Append(" AND MAINTYPE IN('''',''" + this.drpMAINTYPE.SelectedValue + "'')" + GSTR_TabDelimitChar);
                    //LSTR_QueryCondition.Append(" AND PRODTYPE IN('''',''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue + "'')" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
                    LSTR_QueryCondition.Append(" AND TARGETTYPE IN(''''0'''',''''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0] + "'''')" + GSTR_TabDelimitChar);
                    LSTR_QueryCondition.Append(" AND SUPPLIERID IN('''''''',''''" + ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text + "'''')" + GSTR_TabDelimitChar);
                    LSTR_QueryCondition.Append(" AND MAINTYPE IN('''''''',''''" + this.drpMAINTYPE.SelectedValue + "'''') AND ISCINS IN(''''2'''',''''" + ISCINS + "'''')" + GSTR_TabDelimitChar);
                    //LSTR_QueryCondition.Append(" AND ISCINS IN(''''2'''',''''" + ISCINS + "'''')" + GSTR_ColDelimitChar);
                    LSTR_QueryCondition.Append(" AND PRODTYPE IN('''''''',''''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue + "'''')" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
                    LOBJ_Submit = new Comus.HtmlSubmitControl();
                    LOBJ_Submit.VirtualPath = GetComusVirtualPath();
                    LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
                    LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
                    //Alert(LSTR_QueryCondition.ToString());
                    LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    private void GetCaseBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCASE_Data);
            if (lblStatus.Text == "新增")
            {
                this.hidOldData.Value = "";
                this.drpCOMPID.Enabled = true;
            }
            else
            {
                this.hidOldData.Value = LOBJ_Data.Rows[0]["A_USERID"] + ";" + LOBJ_Data.Rows[0]["A_SYSDT"];
                this.drpCOMPID.Enabled = false;
            }
            if (LOBJ_Data.Rows[0]["ONESTR"].ToString().Trim() == "1")
            {
                this.chkOneMLDCASETARGETSTR.Checked = true;
            }
            else
            {
                this.chkOneMLDCASETARGETSTR.Checked = false;
            }
            this.hidFileID.Value = LOBJ_Data.Rows[0]["FileID"].ToString();
            this.txtFileName.Text = LOBJ_Data.Rows[0]["FILENAME"].ToString();
        }
    }
    private void GetMLDCASEINSTDBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count == 4)
        {
            this.txtENDPAY1.Text = LOBJ_Data.Rows[0][3].ToString();
            this.txtPRINCIPAL1.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0][4].ToString());
            this.txtPRINCIPALTAX1.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0][5].ToString());

            this.txtSTARTPAY2.Text = LOBJ_Data.Rows[1][2].ToString();
            this.txtENDPAY2.Text = LOBJ_Data.Rows[1][3].ToString();
            this.txtPRINCIPAL2.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[1][4].ToString());
            this.txtPRINCIPALTAX2.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[1][5].ToString());

            this.txtSTARTPAY3.Text = LOBJ_Data.Rows[2][2].ToString();
            this.txtENDPAY3.Text = LOBJ_Data.Rows[2][3].ToString();
            this.txtPRINCIPAL3.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[2][4].ToString());
            this.txtPRINCIPALTAX3.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[2][5].ToString());

            this.txtSTARTPAY4.Text = LOBJ_Data.Rows[3][2].ToString();
            this.txtENDPAY4.Text = LOBJ_Data.Rows[3][3].ToString();
            this.txtPRINCIPAL4.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[3][4].ToString());
            this.txtPRINCIPALTAX4.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[3][5].ToString());
        }
    }
    private void GetMLDCASEINSTBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCASEINST_Data);
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            if (LOBJ_Data.Rows[0]["NOINSURANCEFLG"].ToString() == "Y")
            {
                this.txtNOINSURANCEFLG.Checked = true;
            }
            else
            {
                this.txtNOINSURANCEFLG.Checked = false;
            }
        }
    }
    private void GetMLDCASEARDATABind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCASEARDATA_Data);
        }
    }
    //Modify 20121224 By SS Gordon. Reason:修正案件資料另外儲存，以便修改後的檢核。檢核資料從PRE資料表取得
    private void GetMLPREDCASEINSTBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            //Modify 20120621 By SS Gordon. Reason: 案件資料另外儲存，以便修改後的檢核
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_preMLDCASEINST_Data);
        }
    }
    //Modify 20121224 By SS Gordon. Reason:修正案件資料另外儲存，以便修改後的檢核。檢核資料從PRE資料表取得
    private void GetMLPREDCASEARDATABind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            //Modify 20120621 By SS Gordon. Reason: 案件資料另外儲存，以便修改後的檢核
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_preMLDCASEARDATA_Data);
        }
    }
    private bool CheckTARGETRule()
    {
        TextBox LOBJ_Txt;
        if (this.rdoMLDCASEINST.Checked)
        {
            if (hidTRANSCOST.Value == "0")
            {
                Alert("標的物金額輸入需大於 0！1");
                txtTRANSCOST.Focus();
                return false;
            }
            if (txtCONTRACTMONTH.Text == "0")
            {
                Alert("總承作月數輸入需大於 0！");
                txtCONTRACTMONTH.Focus();
                return false;
            }
            if (txtPAYMONTH.Text == "0")
            {
                Alert("幾月一付輸入需大於 0！");
                txtPAYMONTH.Focus();
                return false;
            }
            if (txtENDPAY1.Text == "0")
            {
                Alert("第一段結束期別輸入需大於 0！");
                txtENDPAY1.Focus();
                return false;
            }

            // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
            //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
            if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
            {

                if (txtPRINCIPAL1.Text == "0")
                {
                    Alert("第一段期付款輸入需大於 0！");
                    txtPRINCIPAL1.Focus();
                    return false;
                }
            }
            bool LBOL_Checked = false;
            if (txtENDPAY4.Text != "")
            {
                if (txtCONTRACTMONTH.Text != txtENDPAY4.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtENDPAY4.Focus();
                    return false;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
            if (!LBOL_Checked)
            {
                if (txtENDPAY3.Text != "")
                {
                    if (txtCONTRACTMONTH.Text != txtENDPAY3.Text)
                    {
                        Alert("最後一段結束期別輸入需等於總承作月數！");
                        txtENDPAY3.Focus();
                        return false;
                    }
                    else
                    {
                        LBOL_Checked = true;
                    }
                }
            }
            if (!LBOL_Checked)
            {
                if (txtENDPAY2.Text != "")
                {
                    if (txtCONTRACTMONTH.Text != txtENDPAY2.Text)
                    {
                        Alert("最後一段結束期別輸入需等於總承作月數！");
                        txtENDPAY2.Focus();
                        return false;
                    }
                    else
                    {
                        LBOL_Checked = true;
                    }
                }
            }
            if (!LBOL_Checked)
            {
                if (txtENDPAY1.Text != "")
                {
                    if (txtCONTRACTMONTH.Text != txtENDPAY1.Text)
                    {
                        Alert("最後一段結束期別輸入需等於總承作月數！");
                        txtENDPAY1.Focus();
                        return false;
                    }
                    else
                    {
                        LBOL_Checked = true;
                    }
                }
            }
        }
        for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
        {
            LOBJ_Txt = (TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入供應商ID！");
                this.hidShowTag.Value = "fraTab33Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE");
            if (Convert.ToInt32("0" + LOBJ_Txt.Text.Replace(",", "")) <= 0)
            {
                Alert("標的物價格需大於0！4");
                this.hidShowTag.Value = "fraTab33Caption";
                return false;
            }
        }
        return true;
    }
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        string LSTR_SelHead = this.hidSelHeadTag.Value;
        switch (LSTR_SelHead)
        {
            case "rptMLDCASEGUARANTEE":
                AddMLDCASEGUARANTEERow();
                break;
            case "rptMLDCASEMOVABLE":
                AddMLDCASEMOVABLERow();
                break;
            case "rptMLDCASEIMMOVABLE":
                AddMLDCASEIMMOVABLERow();
                break;
            case "rptMLDCASEADEPOSIT":
                AddMLDCASEADEPOSITRow();
                break;
            case "rptMLDCASEBILLNOTE":
                AddMLDCASEBILLNOTERow();
                break;
            case "rptMLDCASESTOCK":
                AddMLDCASESTOCKRow();
                break;
            case "rptMLDCASETARGET":
                AddMLDCASETARGETRow();
                break;
            default:
                this.hidSelHeadTag.Value = "";
                break;
        }
    }
    protected void btnDelRow_Click(object sender, EventArgs e)
    {
        string LSTR_SelRow = this.hidSelRowTag.Value;
        if (LSTR_SelRow.IndexOf(";") != -1)
        {
            string LSTR_Type = LSTR_SelRow.Split(';')[0];
            string LSTR_RowIndex = LSTR_SelRow.Split(';')[1];
            switch (LSTR_Type)
            {
                case "rptMLDCASEGUARANTEE":
                    DelMLDCASEGUARANTEERow(LSTR_RowIndex);
                    break;
                case "rptMLDCASEMOVABLE":
                    DelMLDCASEMOVABLERow(LSTR_RowIndex);
                    break;
                case "rptMLDCASEIMMOVABLE":
                    DelMLDCASEIMMOVABLERow(LSTR_RowIndex);
                    break;
                case "rptMLDCASEADEPOSIT":
                    DelMLDCASEADEPOSITRow(LSTR_RowIndex);
                    break;
                case "rptMLDCASEBILLNOTE":
                    DelMLDCASEBILLNOTERow(LSTR_RowIndex);
                    break;
                case "rptMLDCASESTOCK":
                    DelMLDCASESTOCKRow(LSTR_RowIndex);
                    break;
                case "rptMLDCASETARGET":
                    DelMLDCASETARGETRow(LSTR_RowIndex);
                    break;
                default:
                    break;
            }

        }
        this.hidSelHeadTag.Value = "";
        this.hidSelRowTag.Value = "";
    }
    //表格資料操作
    /*==============================================================================================*/
    //聯絡人
    private void SaveINVZIP()
    {
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];

        for (int rowi = 0; rowi < rptContactI.Items.Count; rowi++)
        {
            string LSTR_INVZIPCODE = ((TextBox)rptContactI.Items[rowi].FindControl("txtINVZIPCODE")).Text;
            string LSTR_INVZIPCODES = ((TextBox)rptContactI.Items[rowi].FindControl("txtINVZIPCODES")).Text;
            string LSTR_INVOICEADDR = ((TextBox)rptContactI.Items[rowi].FindControl("txtINVOICEADDR")).Text.ToString();
            int LINT_VeNum = 0;
            for (int rowC = 0; rowC < LOBJ_Contact.Rows.Count; rowC++)
            {
                if (LOBJ_Contact.Rows[rowC]["CONTACTTYPE"].ToString() == "3")
                {
                    if (LINT_VeNum == rowi)
                    {
                        LOBJ_Contact.Rows[rowC]["INVZIPCODE"] = LSTR_INVZIPCODE;
                        LOBJ_Contact.Rows[rowC]["INVZIPCODES"] = LSTR_INVZIPCODES;
                        LOBJ_Contact.Rows[rowC]["INVOICEADDR"] = LSTR_INVOICEADDR;
                        break;
                    }
                    else
                    {
                        LINT_VeNum++;
                        continue;
                    }
                }
            }
        }
        ViewState["Contact"] = LOBJ_Contact;
    }
    private void rptContactInit()
    {
        DataTable LOBJ_Contact = new DataTable("Contact");
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTID", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTNAME", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("DEPTNAME", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTITLE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTEL", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTELEXT", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTMPHONE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTFAX", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTEMAIL", System.Type.GetType("System.String")));

        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTELCODE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTFAXCODE", System.Type.GetType("System.String")));

        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTYPE", System.Type.GetType("System.String")));

        LOBJ_Contact.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
        ViewState["Contact"] = LOBJ_Contact;
    }
    protected void btnAddCon_Click(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab11Caption";
        string LSTR_Type = this.hidSelRowIndex.Value.Substring(0, 1);
        string LSTR_ConData = this.hidSelRowIndex.Value.Substring(1);
        SaveINVZIP();
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        string[] LVAR_ConDataR = Regex.Split(LSTR_ConData, GSTR_RowDelimitChar);
        for (int row = 0; row < LVAR_ConDataR.Length - 1; row++)
        {
            string[] LVAR_ConDataC = Regex.Split(LVAR_ConDataR[row], GSTR_ColDelimitChar);
            string LSTR_CUSTID = LVAR_ConDataC[0];
            DataRow[] LOBJ_Temp = LOBJ_Contact.Select("CONTACTTYPE=" + LSTR_Type + " AND CONTACTID=" + LSTR_CUSTID);
            if (LOBJ_Temp.Length == 0)
            {
                DataRow LOBJ_ConInfo = null;
                LOBJ_ConInfo = LOBJ_Contact.NewRow();
                LOBJ_ConInfo["CONTACTID"] = LVAR_ConDataC[0];
                LOBJ_ConInfo["CONTACTNAME"] = LVAR_ConDataC[2];
                LOBJ_ConInfo["DEPTNAME"] = LVAR_ConDataC[3];
                LOBJ_ConInfo["CONTACTTITLE"] = LVAR_ConDataC[4];

                LOBJ_ConInfo["CONTACTTEL"] = LVAR_ConDataC[5];
                LOBJ_ConInfo["CONTACTTELEXT"] = LVAR_ConDataC[6];
                LOBJ_ConInfo["CONTACTMPHONE"] = LVAR_ConDataC[7];
                LOBJ_ConInfo["CONTACTFAX"] = LVAR_ConDataC[8];
                LOBJ_ConInfo["CONTACTEMAIL"] = LVAR_ConDataC[9];

                LOBJ_ConInfo["CONTACTTELCODE"] = LVAR_ConDataC[10];
                LOBJ_ConInfo["CONTACTFAXCODE"] = LVAR_ConDataC[11];

                LOBJ_ConInfo["CONTACTTYPE"] = LSTR_Type;

                LOBJ_ConInfo["INVZIPCODE"] = "";
                LOBJ_ConInfo["INVZIPCODES"] = "";
                LOBJ_ConInfo["INVOICEADDR"] = "";
                LOBJ_Contact.Rows.Add(LOBJ_ConInfo);
            }
        }
        ViewState["Contact"] = LOBJ_Contact;
        if (LSTR_Type == "1")
        {
            rptContactMBind();
            this.UpdatePanelContactM.Update();
        }
        else if (LSTR_Type == "2")
        {
            rptContactCBind();
            this.UpdatePanelContactC.Update();
        }
        else if (LSTR_Type == "3")
        {
            rptContactIBind();
            this.UpdatePanelContactI.Update();
        }
    }
    protected void btnDelCon_Click(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab11Caption";
        string LSTR_Type = this.hidSelRowIndex.Value.Substring(0, 1);
        int LINT_SelRow = Convert.ToInt32(this.hidSelRowIndex.Value.Substring(1));

        SaveINVZIP();
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];

        int LINT_VeNum = 0;
        for (int rowCon = 0; rowCon < LOBJ_Contact.Rows.Count; rowCon++)
        {
            if (LOBJ_Contact.Rows[rowCon]["CONTACTTYPE"].ToString() == LSTR_Type)
            {
                if (LINT_VeNum == LINT_SelRow)
                {
                    LOBJ_Contact.Rows.RemoveAt(rowCon);
                    break;
                }
                else
                {
                    LINT_VeNum++;
                    continue;
                }
            }
        }
        ViewState["Contact"] = LOBJ_Contact;
        if (LSTR_Type == "1")
        {
            rptContactMBind();
            this.UpdatePanelContactM.Update();
        }
        else if (LSTR_Type == "2")
        {
            rptContactCBind();
            this.UpdatePanelContactC.Update();
        }
        else if (LSTR_Type == "3")
        {
            rptContactIBind();
            this.UpdatePanelContactI.Update();
        }
    }
    private void rptContactMBind()
    {
        DataTable LOBJ_ContactM = (DataTable)ViewState["Contact"];
        if (LOBJ_ContactM.Select("CONTACTTYPE=1").Length > 0)
        {
            rptContactM.DataSource = LOBJ_ContactM.Select("CONTACTTYPE=1").CopyToDataTable();
        }
        else
        {
            rptContactM.DataSource = null;
        }
        rptContactM.DataBind();
    }
    private void rptContactCBind()
    {
        DataTable LOBJ_ContactC = (DataTable)ViewState["Contact"];
        if (LOBJ_ContactC.Select("CONTACTTYPE=2").Length > 0)
        {
            rptContactC.DataSource = LOBJ_ContactC.Select("CONTACTTYPE=2").CopyToDataTable();
        }
        else
        {
            rptContactC.DataSource = null;
        }
        rptContactC.DataBind();
    }
    private void rptContactIBind()
    {
        DataTable LOBJ_ContactI = (DataTable)ViewState["Contact"];
        if (LOBJ_ContactI.Select("CONTACTTYPE=3").Length > 0)
        {
            rptContactI.DataSource = LOBJ_ContactI.Select("CONTACTTYPE=3").CopyToDataTable();
        }
        else
        {
            rptContactI.DataSource = null;
        }

        rptContactI.DataBind();
    }
    //標的物
    private void MLDCASETARGET_Init()
    {
        if (ViewState["MLDCASETARGET"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASETARGET");
            LOBJ_Data.Columns.Add(new DataColumn("STOREDID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETSTATUS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETMODELNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETMACHINENO", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("SUPPLIERID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUPPLIERIDS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETPRICE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETPRICENOTAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DURABLELIFE", System.Type.GetType("System.String")));

            //Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
            LOBJ_Data.Columns.Add(new DataColumn("MANUFACTURER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETBRAND", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETUNIT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGETCOUNT", System.Type.GetType("System.String")));

            //明細         
            LOBJ_Data.Columns.Add(new DataColumn("STOREDZIPCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOREDZIPCODES", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOREDADDR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTNAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPTNAME", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTITLE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTEL", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTELEXT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTMPHONE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTFAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTEMAIL", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTELCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTFAXCODE", System.Type.GetType("System.String")));

            ViewState["MLDCASETARGET"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASETARGET()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        int LINT_SNum = 0;
        for (int i = 0; i < rptMLDCASETARGET.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["TARGETNAME"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text;
            LOBJ_Data.Rows[i]["TARGETTYPE"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETSTATUS"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETMODELNO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMODELNO")).Text;
            LOBJ_Data.Rows[i]["TARGETMACHINENO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMACHINENO")).Text;
            LOBJ_Data.Rows[i]["SUPPLIERID"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text;
            LOBJ_Data.Rows[i]["SUPPLIERIDS"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERIDS")).Text;
            string LSTR_TARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            LOBJ_Data.Rows[i]["TARGETPRICE"] = LSTR_TARGETPRICE;
            double LINT_TARGETPRICENOTAX = LSTR_TARGETPRICE == "" ? 0 : Convert.ToDouble(LSTR_TARGETPRICE);
            LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = (LINT_TARGETPRICENOTAX / 1.05).ToString("0");
            LOBJ_Data.Rows[i]["DURABLELIFE"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblDURABLELIFE")).Text;

            //Modify 20131004 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
            LOBJ_Data.Rows[i]["MANUFACTURER"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtMANUFACTURER")).Text;
            LOBJ_Data.Rows[i]["TARGETBRAND"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETBRAND")).Text;
            LOBJ_Data.Rows[i]["TARGETUNIT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETUNIT")).Text;
            LOBJ_Data.Rows[i]["TARGETCOUNT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETCOUNT")).Text;

            if (chkOneMLDCASETARGETSTR.Checked == false)
            {
                LINT_SNum = i;
            }
            LOBJ_Data.Rows[i]["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtSTOREDZIPCODE")).Text;
            LOBJ_Data.Rows[i]["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtSTOREDZIPCODES")).Text;
            LOBJ_Data.Rows[i]["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtSTOREDADDR")).Text;
            LOBJ_Data.Rows[i]["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Data.Rows[i]["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtDEPTNAME")).Text;
            LOBJ_Data.Rows[i]["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Data.Rows[i]["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Data.Rows[i]["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Data.Rows[i]["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTEMAIL")).Text;
            LOBJ_Data.Rows[i]["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SNum].FindControl("txtCONTACTFAXCODE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASETARGETRow()
    {
        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        //if (chkAr.Checked == false) {
        if (chkAr.Checked == false && chkBANK1.Checked == false)
        {
            MLDCASETARGET_Init();
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASETARGET();
            //新增一筆資料
            DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
            LOBJ_DataRow["TARGETPRICE"] = "0";
            LOBJ_DataRow["TARGETPRICENOTAX"] = "0";
            LOBJ_Data.Rows.Add(LOBJ_DataRow);
            ViewState["MLDCASETARGET"] = LOBJ_Data;
            MLDCASETARGETBind();
            this.UpdatePanelMLDCASETARGET.Update();
            this.UpdatePanelMLDCASETARGETSTR.Update();
        }
    }
    private void DelMLDCASETARGETRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASETARGET();
        //刪除一筆資料   
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }
    private void GetMLDCASETARGETBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASETARGET"] = null;
        MLDCASETARGET_Init();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
    }
    private void MLDCASETARGETBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        this.rptMLDCASETARGET.DataSource = LOBJ_Data;
        this.rptMLDCASETARGET.DataBind();
        if (LOBJ_Data != null && LOBJ_Data.Rows.Count > 0)
        {
            if (chkOneMLDCASETARGETSTR.Checked == true)
            {
                DataTable LOBJ_DataTemp = LOBJ_Data.Clone();
                LOBJ_DataTemp.ImportRow(LOBJ_Data.Rows[0]);
                this.rptMLDCASETARGETSTR.DataSource = LOBJ_DataTemp;
                this.rptMLDCASETARGETSTR.DataBind();
            }
            else
            {
                this.rptMLDCASETARGETSTR.DataSource = LOBJ_Data;
                this.rptMLDCASETARGETSTR.DataBind();
            }
        }
        else
        {
            this.rptMLDCASETARGETSTR.DataSource = LOBJ_Data;
            this.rptMLDCASETARGETSTR.DataBind();
        }
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetTARGETTYPEData();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                for (int i = 0; i < rptMLDCASETARGET.Items.Count; i++)
                {
                    //((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Attributes.Add("Readonly", "True");
                    ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERIDS")).Attributes.Add("Readonly", "True");
                    DropDownList LOBJ_DrpTARGETTYPE = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE"));
                    LOBJ_DrpTARGETTYPE.DataSource = LDST_Data.Tables[0];
                    LOBJ_DrpTARGETTYPE.DataBind();
                    string LSTR_TARGETTYPE = LOBJ_Data.Rows[i]["TARGETTYPE"].ToString();
                    if (LSTR_TARGETTYPE != "")
                    {
                        LOBJ_DrpTARGETTYPE.SelectedValue = LSTR_TARGETTYPE;
                    }
                    ((Label)rptMLDCASETARGET.Items[i].FindControl("lblDURABLELIFE")).Text = LOBJ_DrpTARGETTYPE.SelectedValue.Split('_')[1];
                    LOBJ_DrpTARGETTYPE = null;

                    DropDownList LOBJ_DrpTARGETSTATUS = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS"));
                    LOBJ_DrpTARGETSTATUS.DataSource = LDST_Data.Tables[1];
                    LOBJ_DrpTARGETSTATUS.DataBind();
                    string LSTR_TARGETSTATUS = LOBJ_Data.Rows[i]["TARGETSTATUS"].ToString();
                    if (LSTR_TARGETSTATUS != "")
                    {
                        LOBJ_DrpTARGETSTATUS.SelectedValue = LSTR_TARGETSTATUS;
                    }
                    LOBJ_DrpTARGETSTATUS = null;
                }
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        //處理存放地             
        if (chkOneMLDCASETARGETSTR.Checked == false)
        {
            for (int i = 0; i < rptMLDCASETARGETSTR.Items.Count; i++)
            {
                DropDownList LOBJ_Drop = (DropDownList)rptMLDCASETARGETSTR.Items[i].FindControl("drpMLDCASETARGET");
                ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDZIPCODES")).Attributes.Add("Readonly", "True");
                for (int j = 0; j < rptMLDCASETARGETSTR.Items.Count; j++)
                {
                    LOBJ_Drop.Items.Add(new ListItem((j + 1).ToString()));
                }
                LOBJ_Drop.SelectedIndex = i;
                LOBJ_Drop = null;
            }
        }
        else
        {
            if (rptMLDCASETARGETSTR.Items.Count > 0)
            {
                ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtSTOREDZIPCODES")).Attributes.Add("Readonly", "True");
            }
        }
    }
    protected void chkOneMLDCASETARGETSTR_CheckedChanged(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab33Caption";
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        for (int i = 0; i < rptMLDCASETARGET.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["TARGETNAME"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text;
            LOBJ_Data.Rows[i]["TARGETTYPE"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETSTATUS"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETMODELNO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMODELNO")).Text;
            LOBJ_Data.Rows[i]["TARGETMACHINENO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMACHINENO")).Text;

            LOBJ_Data.Rows[i]["SUPPLIERID"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text;
            LOBJ_Data.Rows[i]["SUPPLIERIDS"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERIDS")).Text;

            string LSTR_TARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            LOBJ_Data.Rows[i]["TARGETPRICE"] = LSTR_TARGETPRICE;
            double LINT_TARGETPRICENOTAX = LSTR_TARGETPRICE == "" ? 0 : Convert.ToDouble(LSTR_TARGETPRICE);
            LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = (LINT_TARGETPRICENOTAX / 1.05).ToString("0");
            LOBJ_Data.Rows[i]["DURABLELIFE"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblDURABLELIFE")).Text;

            //Modify 20131001 By SS Eric    Reason:在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量
            LOBJ_Data.Rows[i]["MANUFACTURER"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtMANUFACTURER")).Text;
            LOBJ_Data.Rows[i]["TARGETBRAND"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETBRAND")).Text;
            LOBJ_Data.Rows[i]["TARGETUNIT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETUNIT")).Text;
            LOBJ_Data.Rows[i]["TARGETCOUNT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETCOUNT")).Text;

            if (chkOneMLDCASETARGETSTR.Checked == true)
            {
                LOBJ_Data.Rows[i]["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtSTOREDZIPCODE")).Text;
                LOBJ_Data.Rows[i]["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtSTOREDZIPCODES")).Text;
                LOBJ_Data.Rows[i]["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtSTOREDADDR")).Text;
                LOBJ_Data.Rows[i]["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTNAME")).Text;
                LOBJ_Data.Rows[i]["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtDEPTNAME")).Text;

                LOBJ_Data.Rows[i]["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTTITLE")).Text;
                LOBJ_Data.Rows[i]["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTTEL")).Text;
                LOBJ_Data.Rows[i]["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTMPHONE")).Text;
                LOBJ_Data.Rows[i]["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTFAX")).Text;
                LOBJ_Data.Rows[i]["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTEMAIL")).Text;

                LOBJ_Data.Rows[i]["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTTELCODE")).Text;
                LOBJ_Data.Rows[i]["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[0].FindControl("txtCONTACTFAXCODE")).Text;
            }
        }
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }
    protected void btnMLDCASETARGETCopy_Click(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab33Caption";
        int LINT_CopyRowIndex = Convert.ToInt32(this.hidSelRowTag.Value.Split(';')[1]);
        int LINT_CopyCount = Convert.ToInt32(this.hidMLDCASETARGETCopy.Value);
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASETARGET();
        //複製一筆資料
        DataRow LOBJ_RowTemp = LOBJ_Data.Rows[LINT_CopyRowIndex];
        //清空要複製的標的物的 TARGETID
        var LSTR_TARGETID = LOBJ_RowTemp["TARGETID"];
        LOBJ_RowTemp["TARGETID"] = "";
        for (int i = 0; i < LINT_CopyCount; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_RowTemp);
        }
        LOBJ_RowTemp["TARGETID"] = LSTR_TARGETID;
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }
    protected void btnMLDCASETARGETEmport_Click(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab33Caption";
        if (chkAr.Checked == true)
        {
            Alert("AR案件無標的物");
        }
        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        else if (chkBANK1.Checked == true)
        {
            Alert("銀行案件無標的物");
        }
        else
        {
            string LSTR_FilePath = this.fldMLDCASETARGETEmport.FileName;
            if (String.IsNullOrEmpty(LSTR_FilePath))
            {
                Alert("請選擇一筆檔案進行匯入！");
            }
            else
            {
                try
                {
                    //檔案上傳
                    string LSTR_GUID = null;
                    bool LBOL_SaveSucess = false;
                    Itg.Bussness.FileUploads LOBJ_UPComment = null;
                    LOBJ_UPComment = new Itg.Bussness.FileUploads();
                    string LSTR_Attach = "";
                    //上傳文件格式設定(目前不限定上傳格式 )
                    LOBJ_UPComment.FileType = "";
                    //設定上傳路徑
                    LOBJ_UPComment.UploadDirectoryPath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadPath");
                    //指定文件的保存名字
                    LSTR_GUID = Guid.NewGuid().ToString();
                    LOBJ_UPComment.NewFileName = LSTR_GUID;
                    LBOL_SaveSucess = LOBJ_UPComment.FileSave(fldMLDCASETARGETEmport.PostedFile);
                    string LSTR_ExcelPath = "";
                    if (LBOL_SaveSucess)
                    {
                        LSTR_ExcelPath = LOBJ_UPComment.UploadDirectoryPath + LSTR_GUID + System.IO.Path.GetExtension(LSTR_FilePath);
                        ArrayList LOBJ_ArrayList = OleDbExcelHelper.GetSheetNames(LSTR_ExcelPath);
                        int LINT_OldRowNum = LOBJ_ArrayList.Count - 1;
                        MLDCASETARGET_Init();
                        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
                        DataRow LOBJ_RowTemp;
                        for (int i = 0; i < LOBJ_ArrayList.Count; i++)
                        {
                            DataTable dtTemp = OleDbExcelHelper.QueryEx(LSTR_ExcelPath, LOBJ_ArrayList[i].ToString());
                            for (int j = 0; j < dtTemp.Rows.Count; j++)
                            {
                                //20221031 更新匯入所需欄位
                                LOBJ_RowTemp = LOBJ_Data.NewRow();
                                LOBJ_RowTemp["TARGETNAME"] = dtTemp.Rows[j][0].ToString();
                                LOBJ_RowTemp["TARGETMODELNO"] = dtTemp.Rows[j][1].ToString();
                                LOBJ_RowTemp["TARGETMACHINENO"] = dtTemp.Rows[j][2].ToString();
                                LOBJ_RowTemp["SUPPLIERID"] = dtTemp.Rows[j][3].ToString();
                                LOBJ_RowTemp["SUPPLIERIDS"] = dtTemp.Rows[j][4].ToString();
                                LOBJ_RowTemp["TARGETPRICE"] = dtTemp.Rows[j][5].ToString();
                                LOBJ_RowTemp["TARGETPRICENOTAX"] = dtTemp.Rows[j][6].ToString();

                                LOBJ_RowTemp["STOREDZIPCODE"] = dtTemp.Rows[j][7].ToString();
                                LOBJ_RowTemp["STOREDZIPCODES"] = dtTemp.Rows[j][8].ToString();
                                LOBJ_RowTemp["STOREDADDR"] = dtTemp.Rows[j][9].ToString();
                                LOBJ_RowTemp["CONTACTNAME"] = dtTemp.Rows[j][10].ToString();
                                LOBJ_RowTemp["DEPTNAME"] = dtTemp.Rows[j][11].ToString();
                                LOBJ_RowTemp["CONTACTTITLE"] = dtTemp.Rows[j][12].ToString();
                                LOBJ_RowTemp["CONTACTTELCODE"] = dtTemp.Rows[j][13].ToString();
                                LOBJ_RowTemp["CONTACTTEL"] = dtTemp.Rows[j][14].ToString();
                                LOBJ_RowTemp["CONTACTMPHONE"] = dtTemp.Rows[j][15].ToString();
                                LOBJ_RowTemp["CONTACTFAXCODE"] = dtTemp.Rows[j][16].ToString();
                                LOBJ_RowTemp["CONTACTFAX"] = dtTemp.Rows[j][17].ToString();
                                LOBJ_RowTemp["CONTACTEMAIL"] = dtTemp.Rows[j][18].ToString();
                                LOBJ_Data.Rows.Add(LOBJ_RowTemp);
                            }
                        }
                        ViewState["MLDCASETARGET"] = LOBJ_Data;
                        MLDCASETARGETBind();
                    }
                }
                catch (Exception ex)
                {
                    Alert("標的物資料匯入失敗！");
                }
            }
        }
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }
    //保證人
    private void MLDCASEGUARANTEE_Init()
    {
        if (ViewState["MLDCASEGUARANTEE"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASEGUARANTEE");
            LOBJ_Data.Columns.Add(new DataColumn("GRTID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTNAME", System.Type.GetType("System.String")));
            //Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
            LOBJ_Data.Columns.Add(new DataColumn("GRTBIRDT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTSEX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTRESIDENTZIP", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTRESIDENTZIPNM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTRESIDENTADDR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTZIP", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTZIPNM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTADDR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTTELCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTTEL", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTTELEXT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTCOMPANY", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTRELATION1", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTRELATION2", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GRTJOBCLS", System.Type.GetType("System.String")));
            //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            LOBJ_Data.Columns.Add(new DataColumn("GRTJOB", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GUARANTEEBILL", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GUARANTEEBILLTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("GUARANTEEANOUNT", System.Type.GetType("System.String")));
            ViewState["MLDCASEGUARANTEE"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASEGUARANTEE()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEGUARANTEE"];
        //先賦值
        for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["GRTTYPE"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["GRTCODE"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCODE")).Text;
            LOBJ_Data.Rows[i]["GRTNAME"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTNAME")).Text;
            //Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
            LOBJ_Data.Rows[i]["GRTBIRDT"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTBIRDT")).Text;
            LOBJ_Data.Rows[i]["GRTSEX"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTSEX")).SelectedValue;
            LOBJ_Data.Rows[i]["GRTRESIDENTZIP"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTZIP")).Text;
            LOBJ_Data.Rows[i]["GRTRESIDENTZIPNM"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTZIPNM")).Text;
            LOBJ_Data.Rows[i]["GRTRESIDENTADDR"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTADDR")).Text;
            LOBJ_Data.Rows[i]["GRTZIP"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTZIP")).Text;
            LOBJ_Data.Rows[i]["GRTZIPNM"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTZIPNM")).Text;
            LOBJ_Data.Rows[i]["GRTADDR"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTADDR")).Text;
            LOBJ_Data.Rows[i]["GRTTELCODE"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTELCODE")).Text;
            LOBJ_Data.Rows[i]["GRTTEL"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTEL")).Text;
            LOBJ_Data.Rows[i]["GRTTELEXT"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTTELEXT")).Text;
            LOBJ_Data.Rows[i]["GRTCOMPANY"] = ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCOMPANY")).Text;
            LOBJ_Data.Rows[i]["GRTRELATION1"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1")).SelectedValue;
            LOBJ_Data.Rows[i]["GRTRELATION2"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION2")).SelectedValue;
            LOBJ_Data.Rows[i]["GRTJOBCLS"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOBCLS")).SelectedValue;
            //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            LOBJ_Data.Rows[i]["GRTJOB"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).SelectedValue;
            LOBJ_Data.Rows[i]["GUARANTEEBILL"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILL")).SelectedValue;
            LOBJ_Data.Rows[i]["GUARANTEEBILLTYPE"] = ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILLTYPE")).SelectedValue;
            string LSTR_GUARANTEEANOUNT = Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGUARANTEEANOUNT")).Text);
            if (LSTR_GUARANTEEANOUNT == "")
            {
                LOBJ_Data.Rows[i]["GUARANTEEANOUNT"] = DBNull.Value;
            }
            else
            {
                LOBJ_Data.Rows[i]["GUARANTEEANOUNT"] = LSTR_GUARANTEEANOUNT;
            }
        }
        return LOBJ_Data;
    }
    private void AddMLDCASEGUARANTEERow()
    {
        MLDCASEGUARANTEE_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEGUARANTEE();
        //新增一筆資料          
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["GUARANTEEBILL"] = "1";
        LOBJ_DataRow["GUARANTEEBILLTYPE"] = "1";
        LOBJ_DataRow["GUARANTEEANOUNT"] = "0";
        //Modify 20120531 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
        LOBJ_DataRow["GRTBIRDT"] = "";
        LOBJ_DataRow["GRTSEX"] = "";
        LOBJ_DataRow["GRTRESIDENTZIP"] = "";
        LOBJ_DataRow["GRTRESIDENTZIPNM"] = "";
        LOBJ_DataRow["GRTRESIDENTADDR"] = "";
        LOBJ_DataRow["GRTZIP"] = "";
        LOBJ_DataRow["GRTZIPNM"] = "";
        LOBJ_DataRow["GRTADDR"] = "";
        LOBJ_DataRow["GRTTELCODE"] = "";
        LOBJ_DataRow["GRTTEL"] = "";
        LOBJ_DataRow["GRTTELEXT"] = "";
        LOBJ_DataRow["GRTCOMPANY"] = "";
        LOBJ_DataRow["GRTRELATION1"] = "";
        LOBJ_DataRow["GRTRELATION2"] = "";
        LOBJ_DataRow["GRTJOBCLS"] = "";
        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
        LOBJ_DataRow["GRTJOB"] = "";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCASEGUARANTEE"] = LOBJ_Data;
        MLDCASEGUARANTEEBind();
        this.UpdatePanelMLDCASEGUARANTEE.Update();
    }
    private void DelMLDCASEGUARANTEERow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEGUARANTEE();
        //刪除一筆資料   
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASEGUARANTEE"] = LOBJ_Data;
        MLDCASEGUARANTEEBind();
        this.UpdatePanelMLDCASEGUARANTEE.Update();
    }
    private void GetMLDCASEGUARANTEEBind(DataTable LOBJ_Data)
    {
        ViewState["MLDCASEGUARANTEE"] = null;
        MLDCASEGUARANTEE_Init();
        if (LOBJ_Data.Rows.Count > 0)
        {
            chkMLDCASEGUARANTEE.Checked = false;
            ViewState["MLDCASEGUARANTEE"] = LOBJ_Data;
            MLDCASEGUARANTEEBind();
        }
        else
        {
            chkMLDCASEGUARANTEE.Checked = true;
            rptMLDCASEGUARANTEE.DataSource = LOBJ_Data;
            rptMLDCASEGUARANTEE.DataBind();
        }
    }
    private void MLDCASEGUARANTEEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEGUARANTEE"];
        this.rptMLDCASEGUARANTEE.DataSource = LOBJ_Data;
        this.rptMLDCASEGUARANTEE.DataBind();

        //綁定下拉
        DataTable LDTA_Data = (DataTable)ViewState["MLDCASEGUARANTEE"];
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetMLDCASEGUARANTEEDrpBind();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataTable LDST_GRTTYPEData = LOBJ_ReturnObject.ReturnData.Tables[0];
                DataTable LDST_GRTData = LOBJ_ReturnObject.ReturnData.Tables[1];
                //Modify 20120531 By SS Gordon. Reason:加入關係人與職業
                DataTable LDST_GRTRELATION1Data = LOBJ_ReturnObject.ReturnData.Tables[2];
                DataTable LDST_GRTRELATION2Data = LOBJ_ReturnObject.ReturnData.Tables[3];
                DataTable LDST_GRTJOBCLSData = LOBJ_ReturnObject.ReturnData.Tables[4];
                DataTable LDST_GRTJOBData = LOBJ_ReturnObject.ReturnData.Tables[5];
                DataView LDST_GRTJOBView = LDST_GRTJOBData.DefaultView;

                for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
                {
                    DropDownList LOBJ_Grttype = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTTYPE");
                    //DropDownList LOBJ_GRTCODE = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTCODE");
                    //DropDownList LOBJ_GRTNAME = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTNAME");
                    //Modify 20120531 By SS Gordon. Reason:加入關係人與職業
                    DropDownList LOBJ_GRTSEX = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTSEX");
                    DropDownList LOBJ_GRTRELATION1 = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1");
                    DropDownList LOBJ_GRTRELATION2 = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION2");
                    DropDownList LOBJ_GRTJOBCLS = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOBCLS");
                    DropDownList LOBJ_GRTJOB = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB");

                    LOBJ_Grttype.DataSource = LDST_GRTTYPEData;
                    LOBJ_Grttype.DataBind();

                    //Modify 20120531 By SS Gordon. Reason:加入關係人與職業
                    LOBJ_GRTRELATION1.DataSource = LDST_GRTRELATION1Data;
                    LOBJ_GRTRELATION1.DataBind();

                    LOBJ_GRTRELATION2.DataSource = LDST_GRTRELATION2Data;
                    LOBJ_GRTRELATION2.DataBind();

                    LOBJ_GRTJOBCLS.DataSource = LDST_GRTJOBCLSData;
                    LOBJ_GRTJOBCLS.DataBind();

                    LDST_GRTJOBView.RowFilter = "MCODE=''";
                    LOBJ_GRTJOB.DataSource = LDST_GRTJOBView;
                    LOBJ_GRTJOB.DataBind();

                    //LOBJ_GRTCODE.DataSource = LDST_GRTData;
                    //LOBJ_GRTCODE.DataBind();

                    //LOBJ_GRTNAME.DataSource = LDST_GRTData;
                    //LOBJ_GRTNAME.DataBind();

                    if (LDTA_Data.Rows[i]["GRTTYPE"].ToString() != "")
                    {
                        LOBJ_Grttype.SelectedValue = LDTA_Data.Rows[i]["GRTTYPE"].ToString();
                        //LOBJ_GRTNAME.SelectedValue = LDTA_Data.Rows[i]["GRTNAME"].ToString();
                        //LOBJ_GRTCODE.SelectedValue = LDTA_Data.Rows[i]["GRTCODE"].ToString();
                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILL")).SelectedValue = LDTA_Data.Rows[i]["GUARANTEEBILL"].ToString();
                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILLTYPE")).SelectedValue = LDTA_Data.Rows[i]["GUARANTEEBILLTYPE"].ToString();
                        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).SelectedValue = LDTA_Data.Rows[i]["GRTJOB"].ToString();

                        //Modify 20120531 By SS Gordon. Reason:加入關係人與職業
                        if (LDTA_Data.Rows[i]["GRTSEX"].ToString() != "")
                        {
                            LOBJ_GRTSEX.SelectedValue = LDTA_Data.Rows[i]["GRTSEX"].ToString();
                        }
                        if (LDTA_Data.Rows[i]["GRTRELATION1"].ToString() != "")
                        {
                            LOBJ_GRTRELATION1.SelectedValue = LDTA_Data.Rows[i]["GRTRELATION1"].ToString();
                        }
                        if (LDTA_Data.Rows[i]["GRTRELATION2"].ToString() != "")
                        {
                            LOBJ_GRTRELATION2.SelectedValue = LDTA_Data.Rows[i]["GRTRELATION2"].ToString();
                        }
                        if (LDTA_Data.Rows[i]["GRTJOBCLS"].ToString() != "")
                        {
                            LOBJ_GRTJOBCLS.SelectedValue = LDTA_Data.Rows[i]["GRTJOBCLS"].ToString();
                            LDST_GRTJOBView.RowFilter = "MCODE='' OR MCODE='" + LDTA_Data.Rows[i]["GRTJOBCLS"].ToString().Trim() + "'";

                            LOBJ_GRTJOB.DataSource = LDST_GRTJOBView;
                            LOBJ_GRTJOB.DataBind();
                        }
                        if (LDTA_Data.Rows[i]["GRTJOB"].ToString() != "")
                        {
                            LOBJ_GRTJOB.SelectedValue = LDTA_Data.Rows[i]["GRTJOB"].ToString();
                        }

                        //Modify 20121112 By SS Steven. Reason: 登打保人條件時，系統依個人或法人判別，非必要之登打條件以反灰呈現
                        if (LDTA_Data.Rows[i]["GRTTYPE"].ToString() == "2")
                        {
                            ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTBIRDT")).Enabled = false;
                            ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTSEX")).Enabled = false;

                            // 20130912 ADD BY SEAN Reason.修改保人為法人時，可輸入戶藉地址
                            //((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTZIP")).Enabled = false;
                            //((HtmlInputButton)rptMLDCASEGUARANTEE.Items[i].FindControl("btnGRTRESIDENTZIP")).Disabled = true;
                            //((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTZIPNM")).Enabled = false;
                            //((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTRESIDENTADDR")).Enabled = false;

                            ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION2")).Enabled = false;
                            ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOBCLS")).Enabled = false;
                            ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).Enabled = false;
                            ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCOMPANY")).Enabled = false;
                        }
                    }

                    LOBJ_Grttype = null;
                    //LOBJ_GRTCODE = null;
                    //LOBJ_GRTNAME = null;
                }
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }

    //Modify 20121112 By SS Steven. Reason: 登打保人條件時，系統依個人或法人判別，非必要之登打條件以反灰呈現
    protected void drpGRTTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList LDST_GRTTYPE = (DropDownList)sender;
        //Alert(LDST_GRTTYPE.SelectedValue);

        if (LDST_GRTTYPE.SelectedValue == "2")
        {
            TextBox LOBJ_GRTBIRDT = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTBIRDT");
            LOBJ_GRTBIRDT.Text = "";
            LOBJ_GRTBIRDT.Enabled = false;

            DropDownList LOBJ_GRTSEX = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTSEX");
            LOBJ_GRTSEX.SelectedIndex = 0;
            LOBJ_GRTSEX.Enabled = false;

            // 20130912 ADD BY SEAN Reason.修改保人為法人時，可輸入戶藉地址
            TextBox LOBJ_GRTRESIDENTZIP = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIP");
            LOBJ_GRTRESIDENTZIP.Text = "";
            LOBJ_GRTRESIDENTZIP.Enabled = true;

            HtmlInputButton LOBJ_btnGRTRESIDENTZIP = (HtmlInputButton)((DropDownList)sender).NamingContainer.FindControl("btnGRTRESIDENTZIP");
            LOBJ_btnGRTRESIDENTZIP.Disabled = false;

            TextBox LOBJ_GRTRESIDENTZIPNM = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIPNM");
            LOBJ_GRTRESIDENTZIPNM.Text = "";
            LOBJ_GRTRESIDENTZIPNM.Enabled = true;

            TextBox LOBJ_GRTRESIDENTADDR = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTADDR");
            LOBJ_GRTRESIDENTADDR.Text = "";
            LOBJ_GRTRESIDENTADDR.Enabled = true;

            // 20130912 MARK BY SEAN Reason.修改保人為法人時，可輸入戶藉地址
            //TextBox LOBJ_GRTRESIDENTZIP = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIP");
            //LOBJ_GRTRESIDENTZIP.Text = "";
            //LOBJ_GRTRESIDENTZIP.Enabled = false;

            //HtmlInputButton LOBJ_btnGRTRESIDENTZIP = (HtmlInputButton)((DropDownList)sender).NamingContainer.FindControl("btnGRTRESIDENTZIP");
            //LOBJ_btnGRTRESIDENTZIP.Disabled = true;

            //TextBox LOBJ_GRTRESIDENTZIPNM = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIPNM");
            //LOBJ_GRTRESIDENTZIPNM.Text = "";
            //LOBJ_GRTRESIDENTZIPNM.Enabled = false;

            //TextBox LOBJ_GRTRESIDENTADDR = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTADDR");
            //LOBJ_GRTRESIDENTADDR.Text = "";
            //LOBJ_GRTRESIDENTADDR.Enabled = false;

            DropDownList LOBJ_GRTRELATION2 = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTRELATION2");
            LOBJ_GRTRELATION2.SelectedIndex = 0;
            LOBJ_GRTRELATION2.Enabled = false;

            DropDownList LOBJ_GRTJOBCLS = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTJOBCLS");
            LOBJ_GRTJOBCLS.SelectedIndex = 0;
            LOBJ_GRTJOBCLS.Enabled = false;

            DropDownList LOBJ_GRTJOB = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTJOB");
            LOBJ_GRTJOB.SelectedIndex = 0;
            LOBJ_GRTJOB.Enabled = false;

            TextBox LOBJ_GRTCOMPANY = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTCOMPANY");
            LOBJ_GRTCOMPANY.Text = "";
            LOBJ_GRTCOMPANY.Enabled = false;
        }
        else
        {
            TextBox LOBJ_GRTBIRDT = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTBIRDT");
            LOBJ_GRTBIRDT.Text = "";
            LOBJ_GRTBIRDT.Enabled = true;

            DropDownList LOBJ_GRTSEX = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTSEX");
            LOBJ_GRTSEX.SelectedIndex = 0;
            LOBJ_GRTSEX.Enabled = true;

            TextBox LOBJ_GRTRESIDENTZIP = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIP");
            LOBJ_GRTRESIDENTZIP.Text = "";
            LOBJ_GRTRESIDENTZIP.Enabled = true;

            HtmlInputButton LOBJ_btnGRTRESIDENTZIP = (HtmlInputButton)((DropDownList)sender).NamingContainer.FindControl("btnGRTRESIDENTZIP");
            LOBJ_btnGRTRESIDENTZIP.Disabled = false;

            TextBox LOBJ_GRTRESIDENTZIPNM = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTZIPNM");
            LOBJ_GRTRESIDENTZIPNM.Text = "";
            LOBJ_GRTRESIDENTZIPNM.Enabled = true;

            TextBox LOBJ_GRTRESIDENTADDR = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTRESIDENTADDR");
            LOBJ_GRTRESIDENTADDR.Text = "";
            LOBJ_GRTRESIDENTADDR.Enabled = true;

            DropDownList LOBJ_GRTRELATION2 = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTRELATION2");
            LOBJ_GRTRELATION2.SelectedIndex = 0;
            LOBJ_GRTRELATION2.Enabled = true;

            DropDownList LOBJ_GRTJOBCLS = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTJOBCLS");
            LOBJ_GRTJOBCLS.SelectedIndex = 0;
            LOBJ_GRTJOBCLS.Enabled = true;

            DropDownList LOBJ_GRTJOB = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTJOB");
            LOBJ_GRTJOB.SelectedIndex = 0;
            LOBJ_GRTJOB.Enabled = true;

            TextBox LOBJ_GRTCOMPANY = (TextBox)((DropDownList)sender).NamingContainer.FindControl("txtGRTCOMPANY");
            LOBJ_GRTCOMPANY.Text = "";
            LOBJ_GRTCOMPANY.Enabled = true;
        }

        this.UpdatePanelMLDCASEGUARANTEE.Update();

        //Modify 20121129 By SS Steven. Reason:輸入保證人ID檢核function修正
        RegisterScript("CboChanged(document.getElementById('" + LDST_GRTTYPE.ClientID + "'));");
    }

    protected void drpGRTJOBCLS_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable LDST_GRTJOBData = GetGRTJOBData();
        DataView LDST_GRTJOBView = LDST_GRTJOBData.DefaultView;
        DropDownList LOBJ_GRTJOBCLS = (DropDownList)sender;
        DropDownList LOBJ_GRTJOB = (DropDownList)((DropDownList)sender).NamingContainer.FindControl("drpGRTJOB");
        LDST_GRTJOBView.RowFilter = "MCODE='' OR MCODE='" + LOBJ_GRTJOBCLS.SelectedValue + "'";
        LOBJ_GRTJOB.DataSource = LDST_GRTJOBView;
        LOBJ_GRTJOB.DataBind();
    }

    //動產      
    private void MLDCASEMOVABLE_Init()
    {
        if (ViewState["MLDCASEMOVABLE"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASEMOVABLE");
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_Data.Columns.Add(new DataColumn("MOVABLEORDER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLENAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEETARGET", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEZIPCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEZIPCODES", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEADDR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLENO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEYEAR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEBUYDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLENEWAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLEBUYAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLERESIDUALS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("MOVABLERESETPRICE", System.Type.GetType("System.String")));
            ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASEMOVABLE()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEMOVABLE"];
        //先賦值
        for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
        {
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_Data.Rows[i]["MOVABLEORDER"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEORDER")).Text;
            LOBJ_Data.Rows[i]["MOVABLENAME"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENAME")).Text;
            LOBJ_Data.Rows[i]["MOVABLEETARGET"] = ((DropDownList)rptMLDCASEMOVABLE.Items[i].FindControl("drpMOVABLEETARGET")).SelectedValue;

            LOBJ_Data.Rows[i]["MOVABLEZIPCODE"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODE")).Text;
            LOBJ_Data.Rows[i]["MOVABLEZIPCODES"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODES")).Text;
            LOBJ_Data.Rows[i]["MOVABLEADDR"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEADDR")).Text;
            LOBJ_Data.Rows[i]["MOVABLENO"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Text;
            LOBJ_Data.Rows[i]["MOVABLEYEAR"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Text;
            LOBJ_Data.Rows[i]["MOVABLEBUYDATE"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Text;
            LOBJ_Data.Rows[i]["MOVABLENEWAMT"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENEWAMT")).Text;
            LOBJ_Data.Rows[i]["MOVABLEBUYAMT"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYAMT")).Text;
            LOBJ_Data.Rows[i]["MOVABLERESIDUALS"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESIDUALS")).Text;
            LOBJ_Data.Rows[i]["MOVABLERESETPRICE"] = ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Text;
        }
        return LOBJ_Data;
    }

    //UPD BY VICKY 20130402 加入動產複製按鈕事件
    protected void MLDCASEMOVABLE_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int rowcount = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "CopyRowData1")
        {
            MLDCASEMOVABLE_Init();
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASEMOVABLE();
            //新增一筆資料      
            DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_DataRow["MOVABLEORDER"] = LOBJ_Data.Rows[rowcount]["MOVABLEORDER"];
            LOBJ_DataRow["MOVABLENAME"] = LOBJ_Data.Rows[rowcount]["MOVABLENAME"];
            LOBJ_DataRow["MOVABLEETARGET"] = LOBJ_Data.Rows[rowcount]["MOVABLEETARGET"];
            LOBJ_DataRow["MOVABLEZIPCODE"] = LOBJ_Data.Rows[rowcount]["MOVABLEZIPCODE"];
            LOBJ_DataRow["MOVABLEZIPCODES"] = LOBJ_Data.Rows[rowcount]["MOVABLEZIPCODES"];
            LOBJ_DataRow["MOVABLEADDR"] = LOBJ_Data.Rows[rowcount]["MOVABLEADDR"];

            LOBJ_DataRow["MOVABLENO"] = LOBJ_Data.Rows[rowcount]["MOVABLENO"];
            LOBJ_DataRow["MOVABLEYEAR"] = LOBJ_Data.Rows[rowcount]["MOVABLEYEAR"];
            LOBJ_DataRow["MOVABLEBUYDATE"] = LOBJ_Data.Rows[rowcount]["MOVABLEBUYDATE"];
            LOBJ_DataRow["MOVABLENEWAMT"] = LOBJ_Data.Rows[rowcount]["MOVABLENEWAMT"];
            LOBJ_DataRow["MOVABLEBUYAMT"] = LOBJ_Data.Rows[rowcount]["MOVABLEBUYAMT"];

            LOBJ_DataRow["MOVABLERESIDUALS"] = LOBJ_Data.Rows[rowcount]["MOVABLERESIDUALS"];
            LOBJ_DataRow["MOVABLERESETPRICE"] = LOBJ_Data.Rows[rowcount]["MOVABLERESETPRICE"];

            LOBJ_Data.Rows.Add(LOBJ_DataRow);

            ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
            MLDCASEMOVABLEBind();
            this.UpdatePanelMLDCASEMOVABLE.Update();
        }
    }

    private void AddMLDCASEMOVABLERow()
    {
        MLDCASEMOVABLE_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEMOVABLE();
        //新增一筆資料      
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        //LOBJ_DataRow["MOVABLEORDER"] = "1";  //ADD BY VICKY 20130411 將項次改為TEXTBOX
        LOBJ_DataRow["MOVABLEETARGET"] = "";
        LOBJ_DataRow["MOVABLENEWAMT"] = "0";
        LOBJ_DataRow["MOVABLEBUYAMT"] = "0";
        LOBJ_DataRow["MOVABLERESIDUALS"] = "0";
        LOBJ_DataRow["MOVABLERESETPRICE"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);

        ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
        MLDCASEMOVABLEBind();
        this.UpdatePanelMLDCASEMOVABLE.Update();
    }
    private void DelMLDCASEMOVABLERow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEMOVABLE();
        //刪除一筆資料   
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
        MLDCASEMOVABLEBind();
        this.UpdatePanelMLDCASEMOVABLE.Update();
    }
    private void GetMLDCASEMOVABLEBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASEMOVABLE"] = null;
        MLDCASEMOVABLE_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            chkMLDCASEMOVABLE.Checked = false;
            MLDCASEMOVABLE_Init();
            DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEMOVABLE"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }


            ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
            MLDCASEMOVABLEBind();
        }
        else
        {
            chkMLDCASEMOVABLE.Checked = true;
            rptMLDCASEMOVABLE.DataSource = LOBJ_DataTemp;
            rptMLDCASEMOVABLE.DataBind();
        }
    }
    private void MLDCASEMOVABLEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEMOVABLE"];
        this.rptMLDCASEMOVABLE.DataSource = LOBJ_Data;
        this.rptMLDCASEMOVABLE.DataBind();
        for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
        {
            ((DropDownList)rptMLDCASEMOVABLE.Items[i].FindControl("drpMOVABLEETARGET")).SelectedValue = LOBJ_Data.Rows[i]["MOVABLEETARGET"].ToString();

        }
    }
    //不動產      
    private void MLDCASEIMMOVABLE_Init()
    {
        if (ViewState["MLDCASEIMMOVABLE"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASEIMMOVABLE");
            //主表
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEORDER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEOWNER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEOWNERID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEGETDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILDDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLESECTOR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILD", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEAREA", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEHOLDER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILDNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEHOUSENUM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILDAREA", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILDAREAS", System.Type.GetType("System.String")));
            //明細表
            LOBJ_Data.Columns.Add(new DataColumn("HUMANRIGHTS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("REGISTDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SETPRICE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CREDITOR", System.Type.GetType("System.String")));
            //20130521 ADD BY ADAM Reason.增加權利人欄位IDMEMO處理
            LOBJ_Data.Columns.Add(new DataColumn("IDMEMO", System.Type.GetType("System.String")));
            ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
        }
    }

    //UPD BY VICKY 20130402 加入不動產複製按鈕事件
    protected void MLDCASEIMMOVABLE_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int rowcount = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "CopyRowData2")
        {
            MLDCASEIMMOVABLE_Init();
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASEIMMOVABLE();
            //新增一筆資料    
            DataRow LOBJ_DataRow = LOBJ_Data.NewRow();

            //主表
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_DataRow["IMMOVABLEORDER"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEORDER"];

            //LOBJ_DataRow["IMMOVABLEID"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEID"];
            LOBJ_DataRow["IMMOVABLEOWNER"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEOWNER"];
            LOBJ_DataRow["IMMOVABLEOWNERID"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEOWNERID"];
            LOBJ_DataRow["IMMOVABLEGETDATE"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEGETDATE"];
            LOBJ_DataRow["IMMOVABLEBUILDDATE"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEBUILDDATE"];

            LOBJ_DataRow["IMMOVABLESECTOR"] = LOBJ_Data.Rows[rowcount]["IMMOVABLESECTOR"];
            LOBJ_DataRow["IMMOVABLEBUILD"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEBUILD"];
            LOBJ_DataRow["IMMOVABLEAREA"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEAREA"];
            LOBJ_DataRow["IMMOVABLEHOLDER"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEHOLDER"];
            LOBJ_DataRow["IMMOVABLEBUILDNO"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEBUILDNO"];

            LOBJ_DataRow["IMMOVABLEHOUSENUM"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEHOUSENUM"];
            LOBJ_DataRow["IMMOVABLEBUILDAREA"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEBUILDAREA"];
            LOBJ_DataRow["IMMOVABLEBUILDAREAS"] = LOBJ_Data.Rows[rowcount]["IMMOVABLEBUILDAREAS"];

            //明細表
            LOBJ_DataRow["HUMANRIGHTS"] = LOBJ_Data.Rows[rowcount]["HUMANRIGHTS"];
            LOBJ_DataRow["REGISTDATE"] = LOBJ_Data.Rows[rowcount]["REGISTDATE"];
            LOBJ_DataRow["SETPRICE"] = LOBJ_Data.Rows[rowcount]["SETPRICE"];
            LOBJ_DataRow["CREDITOR"] = LOBJ_Data.Rows[rowcount]["CREDITOR"];


            LOBJ_Data.Rows.Add(LOBJ_DataRow);

            ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
            MLDCASEIMMOVABLEBind2();
            this.UpdatePanelMLDCASEIMMOVABLE.Update();
            this.UpdatePanelMLDHUMANRIGHTS.Update();
        }
    }

    private DataTable updateMLDCASEIMMOVABLE()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEIMMOVABLE"];
        //先賦值
        for (int i = 0; i < rptMLDCASEIMMOVABLE.Items.Count; i++)
        {
            //ADD BY VICKY 20130411 將項次改為TEXTBOX
            //LOBJ_Data.Rows[i]["IMMOVABLEORDER"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEORDER")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEOWNER"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEOWNER")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEOWNERID"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEOWNERID")).Text;

            LOBJ_Data.Rows[i]["IMMOVABLEGETDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEGETDATE")).Text);
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDDATE")).Text);
            LOBJ_Data.Rows[i]["IMMOVABLESECTOR"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLESECTOR")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEBUILD"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILD")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEAREA"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEAREA")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEHOLDER"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEHOLDER")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDNO"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDNO")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEHOUSENUM"] = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEHOUSENUM")).Text;

            string LSTR_Area = ((TextBox)rptMLDCASEIMMOVABLE.Items[i].FindControl("txtIMMOVABLEBUILDAREA")).Text.ToString();
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDAREA"] = LSTR_Area;
            double LINT_Area = LSTR_Area == "" ? 0 : Convert.ToDouble(LSTR_Area);
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDAREAS"] = (LINT_Area * 0.3025).ToString("0.00");

            //明細
            LOBJ_Data.Rows[i]["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtHUMANRIGHTS")).Text;
            LOBJ_Data.Rows[i]["REGISTDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Text);
            LOBJ_Data.Rows[i]["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtSETPRICE")).Text;
            LOBJ_Data.Rows[i]["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtCREDITOR")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASEIMMOVABLERow()
    {
        MLDCASEIMMOVABLE_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEIMMOVABLE();
        //新增一筆資料    
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["IMMOVABLEBUILDAREAS"] = "0.0";
        LOBJ_DataRow["SETPRICE"] = "0";
        //LOBJ_DataRow["IMMOVABLEORDER"] = "1";  //ADD BY VICKY 20130411 將項次改為TEXTBOX

        LOBJ_Data.Rows.Add(LOBJ_DataRow);

        ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
        MLDCASEIMMOVABLEBind2();
        this.UpdatePanelMLDCASEIMMOVABLE.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }
    private void DelMLDCASEIMMOVABLERow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEIMMOVABLE();
        //刪除一筆資料    
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
        MLDCASEIMMOVABLEBind();
        this.UpdatePanelMLDCASEIMMOVABLE.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }
    private void GetMLDCASEIMMOVABLEBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASEIMMOVABLE"] = null;
        MLDCASEIMMOVABLE_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            chkMLDCASEIMMOVABLE.Checked = false;
            MLDCASEIMMOVABLE_Init();
            DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEIMMOVABLE"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }

            ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
            MLDCASEIMMOVABLEBind();
        }
        else
        {
            chkMLDCASEIMMOVABLE.Checked = true;
            rptMLDCASEIMMOVABLE.DataSource = LOBJ_DataTemp;
            rptMLDCASEIMMOVABLE.DataBind();
        }
    }
    private void MLDCASEIMMOVABLEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEIMMOVABLE"];
        this.rptMLDCASEIMMOVABLE.DataSource = LOBJ_Data;
        this.rptMLDCASEIMMOVABLE.DataBind();

        this.rptMLDHUMANRIGHTS.DataSource = LOBJ_Data;
        this.rptMLDHUMANRIGHTS.DataBind();

        //綁定下拉
        // 20130422 ADD BY ADAM
        //for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++) {
        //DropDownList LOBJ_Drop = (DropDownList)rptMLDHUMANRIGHTS.Items[i].FindControl("drpMLDCASEIMMOVABLE");
        //TextBox LOBJ_Tbx = (TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtMLDCASEIMMOVABLE");
        //for (int j = 0; j < rptMLDHUMANRIGHTS.Items.Count; j++) {
        //  LOBJ_Drop.Items.Add(new ListItem((j + 1).ToString()));
        //}
        //LOBJ_Drop.SelectedIndex = i;
        //LOBJ_Drop = null;
        //LOBJ_Tbx.Text = (i+1).ToString();
        //}
    }
    //20130425 ADD BY ADAM Reason.區分F8新增的綁定
    private void MLDCASEIMMOVABLEBind2()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEIMMOVABLE"];
        this.rptMLDCASEIMMOVABLE.DataSource = LOBJ_Data;
        this.rptMLDCASEIMMOVABLE.DataBind();

        //string[] MLDCASEIMMOVABLE = new string[rptMLDHUMANRIGHTS.Items.Count];
        string MLDCASEIMMOVABLE = "";
        string[] aMLDCASEIMMOVABLE;
        for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
        {
            TextBox LOBJ_Tbx = (TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtMLDCASEIMMOVABLE");
            MLDCASEIMMOVABLE += LOBJ_Tbx.Text + ",";
        }
        aMLDCASEIMMOVABLE = MLDCASEIMMOVABLE.Split(new char[] { ',' });

        this.rptMLDHUMANRIGHTS.DataSource = LOBJ_Data;
        this.rptMLDHUMANRIGHTS.DataBind();

        for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
        {
            TextBox LOBJ_Tbx = (TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtMLDCASEIMMOVABLE");
            if (i != rptMLDHUMANRIGHTS.Items.Count - 1)
            {
                LOBJ_Tbx.Text = aMLDCASEIMMOVABLE[i];
                //LOBJ_Tbx.Text = (i+1).ToString();
            }
        }
    }
    protected void droIMMOVABLEID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList LOBJ_Drp = (DropDownList)sender;
        RepeaterItem RItem;
        RItem = (RepeaterItem)LOBJ_Drp.Parent;
        int LINT_SelRow = RItem.ItemIndex;
        int LINT_TagRow = Convert.ToInt32(LOBJ_Drp.SelectedValue) - 1;

        if (LOBJ_Drp.ID == "drpMLDCASETARGET")
        {
            this.hidShowTag.Value = "fraTab33Caption";
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASETARGET();
            //首先將目標行的資料轉移
            DataRow LDRW_Tmep = LOBJ_Data.NewRow();
            LDRW_Tmep["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtSTOREDZIPCODE")).Text;
            LDRW_Tmep["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtSTOREDZIPCODES")).Text;
            LDRW_Tmep["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtSTOREDADDR")).Text;
            LDRW_Tmep["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTNAME")).Text;
            LDRW_Tmep["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtDEPTNAME")).Text;

            LDRW_Tmep["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTTITLE")).Text;
            LDRW_Tmep["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTTEL")).Text;
            LDRW_Tmep["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTMPHONE")).Text;
            LDRW_Tmep["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTFAX")).Text;
            LDRW_Tmep["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTEMAIL")).Text;

            LDRW_Tmep["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTTELCODE")).Text;
            LDRW_Tmep["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_TagRow].FindControl("txtCONTACTFAXCODE")).Text;
            //
            LOBJ_Data.Rows[LINT_TagRow]["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtSTOREDZIPCODE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtSTOREDZIPCODES")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtSTOREDADDR")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtDEPTNAME")).Text;

            LOBJ_Data.Rows[LINT_TagRow]["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTEMAIL")).Text;

            LOBJ_Data.Rows[LINT_TagRow]["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[LINT_SelRow].FindControl("txtCONTACTFAXCODE")).Text;
            //
            LOBJ_Data.Rows[LINT_SelRow]["STOREDZIPCODE"] = LDRW_Tmep["STOREDZIPCODE"];
            LOBJ_Data.Rows[LINT_SelRow]["STOREDZIPCODES"] = LDRW_Tmep["STOREDZIPCODES"];
            LOBJ_Data.Rows[LINT_SelRow]["STOREDADDR"] = LDRW_Tmep["STOREDADDR"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTNAME"] = LDRW_Tmep["CONTACTNAME"];
            LOBJ_Data.Rows[LINT_SelRow]["DEPTNAME"] = LDRW_Tmep["DEPTNAME"];

            LOBJ_Data.Rows[LINT_SelRow]["CONTACTTITLE"] = LDRW_Tmep["CONTACTTITLE"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTTEL"] = LDRW_Tmep["CONTACTTEL"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTMPHONE"] = LDRW_Tmep["CONTACTMPHONE"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTFAX"] = LDRW_Tmep["CONTACTFAX"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTEMAIL"] = LDRW_Tmep["CONTACTEMAIL"];

            LOBJ_Data.Rows[LINT_SelRow]["CONTACTTELCODE"] = LDRW_Tmep["CONTACTTELCODE"];
            LOBJ_Data.Rows[LINT_SelRow]["CONTACTFAXCODE"] = LDRW_Tmep["CONTACTFAXCODE"];

            ViewState["MLDCASETARGET"] = LOBJ_Data;
            MLDCASETARGETBind();
        }
        else
        {
            this.hidShowTag.Value = "fraTab44Caption";
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASEIMMOVABLE();
            //首先將目標行的資料轉移
            DataRow LDRW_Tmep = LOBJ_Data.NewRow();
            LDRW_Tmep["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_TagRow].FindControl("txtHUMANRIGHTS")).Text;
            LDRW_Tmep["REGISTDATE"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_TagRow].FindControl("txtREGISTDATE")).Text;
            LDRW_Tmep["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_TagRow].FindControl("txtSETPRICE")).Text;
            LDRW_Tmep["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_TagRow].FindControl("txtCREDITOR")).Text;
            //
            LOBJ_Data.Rows[LINT_TagRow]["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_SelRow].FindControl("txtHUMANRIGHTS")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["REGISTDATE"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_SelRow].FindControl("txtREGISTDATE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_SelRow].FindControl("txtSETPRICE")).Text;
            LOBJ_Data.Rows[LINT_TagRow]["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS.Items[LINT_SelRow].FindControl("txtCREDITOR")).Text;
            //
            LOBJ_Data.Rows[LINT_SelRow]["HUMANRIGHTS"] = LDRW_Tmep["HUMANRIGHTS"];
            LOBJ_Data.Rows[LINT_SelRow]["REGISTDATE"] = LDRW_Tmep["REGISTDATE"];
            LOBJ_Data.Rows[LINT_SelRow]["SETPRICE"] = LDRW_Tmep["SETPRICE"];
            LOBJ_Data.Rows[LINT_SelRow]["CREDITOR"] = LDRW_Tmep["CREDITOR"];
            ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
            MLDCASEIMMOVABLEBind();
        }
        this.UpdatePanelMLDCASEIMMOVABLE.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }
    //定存單質押
    private void MLDCASEADEPOSIT_Init()
    {
        if (ViewState["MLDCASEADEPOSIT"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASEADEPOSIT");
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITBANKS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITNBR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITSTARTDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITDUEDATE", System.Type.GetType("System.String")));
            ViewState["MLDCASEADEPOSIT"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASEADEPOSIT()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEADEPOSIT"];
        //先賦值
        for (int i = 0; i < rptMLDCASEADEPOSIT.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["DEPOSITBANK"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITBANK")).Text;
            LOBJ_Data.Rows[i]["DEPOSITBANKS"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITBANKS")).Text;
            LOBJ_Data.Rows[i]["DEPOSITNBR"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITNBR")).Text;
            LOBJ_Data.Rows[i]["DEPOSITAMT"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITAMT")).Text;
            LOBJ_Data.Rows[i]["DEPOSITSTARTDATE"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITSTARTDATE")).Text;
            LOBJ_Data.Rows[i]["DEPOSITDUEDATE"] = ((TextBox)rptMLDCASEADEPOSIT.Items[i].FindControl("txtDEPOSITDUEDATE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASEADEPOSITRow()
    {
        MLDCASEADEPOSIT_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEADEPOSIT();
        //新增一筆資料             
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["DEPOSITAMT"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCASEADEPOSIT"] = LOBJ_Data;
        MLDCASEADEPOSITBind();
        this.UpdatePanelMLDCASEADEPOSIT.Update();
    }
    private void DelMLDCASEADEPOSITRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEADEPOSIT();
        //刪除一筆資料             
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASEADEPOSIT"] = LOBJ_Data;
        MLDCASEADEPOSITBind();
        this.UpdatePanelMLDCASEADEPOSIT.Update();
    }
    private void GetMLDCASEADEPOSITBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASEADEPOSIT"] = null;
        MLDCASEADEPOSIT_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            chkMLDCASEADEPOSIT.Checked = false;
            MLDCASEADEPOSIT_Init();
            DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEADEPOSIT"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }
            ViewState["MLDCASEADEPOSIT"] = LOBJ_Data;
            MLDCASEADEPOSITBind();
        }
        else
        {
            chkMLDCASEADEPOSIT.Checked = true;
            rptMLDCASEADEPOSIT.DataSource = LOBJ_DataTemp;
            rptMLDCASEADEPOSIT.DataBind();
        }
    }
    private void MLDCASEADEPOSITBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEADEPOSIT"];
        this.rptMLDCASEADEPOSIT.DataSource = LOBJ_Data;
        this.rptMLDCASEADEPOSIT.DataBind();
    }
    //客票
    private void MLDCASEBILLNOTE_Init()
    {
        if (ViewState["MLDCASEBILLNOTE"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASEBILLNOTE");
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEBANKS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTETYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTENBR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ACCOUNT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTECUSTNAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTENOTE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEBACKDATE", System.Type.GetType("System.String")));
            ViewState["MLDCASEBILLNOTE"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASEBILLNOTE()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEBILLNOTE"];
        //先賦值
        for (int i = 0; i < rptMLDCASEBILLNOTE.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["BILLNOTEDATE"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEDATE")).Text;
            LOBJ_Data.Rows[i]["BILLNOTEBANK"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEBANK")).Text;
            LOBJ_Data.Rows[i]["BILLNOTEBANKS"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEBANKS")).Text;
            LOBJ_Data.Rows[i]["BILLNOTETYPE"] = ((DropDownList)rptMLDCASEBILLNOTE.Items[i].FindControl("drpBILLNOTETYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["BILLNOTENBR"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTENBR")).Text;
            LOBJ_Data.Rows[i]["ACCOUNT"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtACCOUNT")).Text;
            LOBJ_Data.Rows[i]["BILLNOTECUSTNAME"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTECUSTNAME")).Text;
            LOBJ_Data.Rows[i]["BILLNOTEAMT"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEAMT")).Text;
            LOBJ_Data.Rows[i]["BILLNOTENOTE"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTENOTE")).Text;
            LOBJ_Data.Rows[i]["BILLNOTEBACKDATE"] = ((TextBox)rptMLDCASEBILLNOTE.Items[i].FindControl("txtBILLNOTEBACKDATE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASEBILLNOTERow()
    {
        MLDCASEBILLNOTE_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEBILLNOTE();
        //新增一筆資料      
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["BILLNOTEAMT"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCASEBILLNOTE"] = LOBJ_Data;
        MLDCASEBILLNOTEBind();
        this.UpdatePanelMLDCASEBILLNOTE.Update();
    }
    private void DelMLDCASEBILLNOTERow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASEBILLNOTE();
        //刪除一筆資料             
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASEBILLNOTE"] = LOBJ_Data;
        MLDCASEBILLNOTEBind();
        this.UpdatePanelMLDCASEBILLNOTE.Update();
    }
    private void GetMLDCASEBILLNOTEBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASEBILLNOTE"] = null;
        MLDCASEBILLNOTE_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            chkMLDCASEBILLNOTE.Checked = false;
            MLDCASEBILLNOTE_Init();
            DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEBILLNOTE"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }
            ViewState["MLDCASEBILLNOTE"] = LOBJ_Data;
            MLDCASEBILLNOTEBind();
        }
        else
        {
            chkMLDCASEBILLNOTE.Checked = true;
            rptMLDCASEBILLNOTE.DataSource = LOBJ_DataTemp;
            rptMLDCASEBILLNOTE.DataBind();
        }
    }
    private void MLDCASEBILLNOTEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEBILLNOTE"];
        this.rptMLDCASEBILLNOTE.DataSource = LOBJ_Data;
        this.rptMLDCASEBILLNOTE.DataBind();
        for (int i = 0; i < rptMLDCASEBILLNOTE.Items.Count; i++)
        {
            DropDownList LOBJ_BILLNOTETYPE = (DropDownList)rptMLDCASEBILLNOTE.Items[i].FindControl("drpBILLNOTETYPE");
            LOBJ_BILLNOTETYPE.SelectedValue = LOBJ_Data.Rows[i]["BILLNOTETYPE"].ToString();
        }
    }
    //股票
    private void MLDCASESTOCK_Init()
    {
        if (ViewState["MLDCASESTOCK"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCASESTOCK");
            LOBJ_Data.Columns.Add(new DataColumn("STOCKID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKNAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKPROVIDER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKUNIT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKQUANTITY", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKTOTAL", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKBEGIN", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKEND", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKINSURANCE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOCKNOTE", System.Type.GetType("System.String")));
            ViewState["MLDCASESTOCK"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDCASESTOCK()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASESTOCK"];
        //先賦值
        for (int i = 0; i < rptMLDCASESTOCK.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["STOCKDATE"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKDATE")).Text;
            LOBJ_Data.Rows[i]["STOCKNAME"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKNAME")).Text;
            LOBJ_Data.Rows[i]["STOCKPROVIDER"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKPROVIDER")).Text;
            LOBJ_Data.Rows[i]["STOCKUNIT"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKUNIT")).Text;
            LOBJ_Data.Rows[i]["STOCKQUANTITY"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKQUANTITY")).Text;
            LOBJ_Data.Rows[i]["STOCKTOTAL"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKTOTAL")).Text;
            LOBJ_Data.Rows[i]["STOCKBEGIN"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKBEGIN")).Text;
            LOBJ_Data.Rows[i]["STOCKEND"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKEND")).Text;
            LOBJ_Data.Rows[i]["STOCKINSURANCE"] = ((DropDownList)rptMLDCASESTOCK.Items[i].FindControl("drpSTOCKINSURANCE")).SelectedValue;
            LOBJ_Data.Rows[i]["STOCKNOTE"] = ((TextBox)rptMLDCASESTOCK.Items[i].FindControl("txtSTOCKNOTE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASESTOCKRow()
    {
        MLDCASESTOCK_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASESTOCK();
        //新增一筆資料   
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCASESTOCK"] = LOBJ_Data;
        MLDCASESTOCKBind();
        this.UpdatePanelMLDCASESTOCK.Update();
    }
    private void DelMLDCASESTOCKRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASESTOCK();
        //刪除一筆資料             
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDCASESTOCK"] = LOBJ_Data;
        MLDCASESTOCKBind();
        this.UpdatePanelMLDCASESTOCK.Update();
    }
    private void GetMLDCASESTOCKBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASESTOCK"] = null;
        MLDCASESTOCK_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            chkMLDCASESTOCK.Checked = false;
            DataTable LOBJ_Data = (DataTable)ViewState["MLDCASESTOCK"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }
            ViewState["MLDCASESTOCK"] = LOBJ_Data;
            MLDCASESTOCKBind();
        }
        else
        {
            chkMLDCASESTOCK.Checked = true;
            rptMLDCASESTOCK.DataSource = LOBJ_DataTemp;
            rptMLDCASESTOCK.DataBind();
        }
    }
    private void MLDCASESTOCKBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASESTOCK"];
        this.rptMLDCASESTOCK.DataSource = LOBJ_Data;
        this.rptMLDCASESTOCK.DataBind();

        for (int i = 0; i < rptMLDCASESTOCK.Items.Count; i++)
        {
            ((DropDownList)rptMLDCASESTOCK.Items[i].FindControl("drpSTOCKINSURANCE")).SelectedValue = LOBJ_Data.Rows[i]["STOCKINSURANCE"].ToString();
        }
    }
    //徵審資料
    private void GetMLDCASEAPPENDDOCBind(DataTable LOBJ_Data)
    {
        ViewState["Doc"] = null;
        //if (LOBJ_Data.Rows.Count > 0)
        //{
        rptMLDCASEAPPENDDOC.DataSource = LOBJ_Data;
        rptMLDCASEAPPENDDOC.DataBind();
        ViewState["Doc"] = LOBJ_Data;
        //    getDocListBind();
        //}
    }
    //20221031 設備系統改版 徵審資料變更
    private void MLDCASEAPPENDDOCBind()
    {
        try
        {
            //20221031徵審資料進件文件相同，先顯示
            ReturnObject<DataSet> LOBJ_ReturnObject1 = GetMLDCASEAPPENDDOCData("L");
            if (LOBJ_ReturnObject1.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject1.ReturnData;

                DataTable LOBJ_DOC = new DataTable("CASEAPPENDDOC");
                LOBJ_DOC.Columns.Add(new DataColumn("APPENDDOCID", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DCODE", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DNAME1", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DNAME2", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DOCCONFIRM", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("NOTE", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("SLABEL", System.Type.GetType("System.String")));

                DataView LDVW_DocData = LDST_Data.Tables[0].DefaultView;
                DataTable LDTA_DocData = LDVW_DocData.ToTable();
                DataRow LOBJ_ConInfo = null;

                for (int i = 0; i < LDTA_DocData.Rows.Count; i++)
                {
                    LOBJ_ConInfo = LOBJ_DOC.NewRow();
                    LOBJ_ConInfo["DCODE"] = LDTA_DocData.Rows[i]["DCODE"].ToString().Trim();
                    LOBJ_ConInfo["DNAME1"] = LDTA_DocData.Rows[i]["DNAME1"].ToString().Trim();
                    LOBJ_ConInfo["DNAME2"] = LDTA_DocData.Rows[i]["DNAME2"].ToString().Trim();
                    LOBJ_ConInfo["DOCCONFIRM"] = "False";
                    LOBJ_ConInfo["NOTE"] = "";
                    LOBJ_ConInfo["SLABEL"] = "True";
                    LOBJ_DOC.Rows.Add(LOBJ_ConInfo);

                }

                ViewState["Doc"] = LOBJ_DOC;
                rptMLDCASEAPPENDDOC.DataSource = LOBJ_DOC;
                rptMLDCASEAPPENDDOC.DataBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject1.ReturnMessage);
            }
            //回件資料
            ReturnObject<DataSet> LOBJ_ReturnObject2 = GetMLDCASEAPPENDDOCData("S");
            if (LOBJ_ReturnObject2.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject2.ReturnData;

                DataTable LOBJ_DOC = new DataTable("CASEAPPENDDOC1");
                LOBJ_DOC.Columns.Add(new DataColumn("APPENDDOCID", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DCODE", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DNAME1", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DNAME2", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("DOCCONFIRM", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("NOTE", System.Type.GetType("System.String")));
                LOBJ_DOC.Columns.Add(new DataColumn("SLABEL", System.Type.GetType("System.String")));

                DataView LDVW_DocData = LDST_Data.Tables[0].DefaultView;
                if (this.drpPRODCD.SelectedValue != "")
                {
                    //20221031承作型態為分期時
                    if (this.drpMAINTYPE.SelectedValue == "03")
                    {
                        //20221031案件產品別為重車時
                        if (this.drpPRODCD.SelectedValue == "03")
                        {
                            LDVW_DocData.RowFilter = "DCODE NOT IN ('10' , '14'  , '17' , '25')";
                        }
                        //20221031案件產品別為重車以外時
                        else
                        {
                            LDVW_DocData.RowFilter = "DCODE NOT IN ('10' , '14'  , '18' , '25')";
                        }
                    }
                    //20221031承作型態為分期以外時
                    else
                    {
                        LDVW_DocData.RowFilter = "DCODE NOT IN ('11' , '17' , '18')";
                    }
                }
                DataTable LDTA_DocData = LDVW_DocData.ToTable();
                DataRow LOBJ_ConInfo = null;

                for (int i = 0; i < LDTA_DocData.Rows.Count; i++)
                {
                    LOBJ_ConInfo = LOBJ_DOC.NewRow();
                    LOBJ_ConInfo["DCODE"] = LDTA_DocData.Rows[i]["DCODE"].ToString().Trim();
                    LOBJ_ConInfo["DNAME1"] = LDTA_DocData.Rows[i]["DNAME1"].ToString().Trim();
                    LOBJ_ConInfo["DNAME2"] = LDTA_DocData.Rows[i]["DNAME2"].ToString().Trim();
                    LOBJ_ConInfo["DOCCONFIRM"] = "False";
                    LOBJ_ConInfo["NOTE"] = "";
                    LOBJ_ConInfo["SLABEL"] = "True";

                    LOBJ_DOC.Rows.Add(LOBJ_ConInfo);
                }
                ViewState["Doc"] = LOBJ_DOC;
                rptMLDCASEAPPENDDOC1.DataSource = LOBJ_DOC;
                rptMLDCASEAPPENDDOC1.DataBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject2.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    protected void droDocMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        //20221031 改為隱藏
        //DropDownList LOBJ_Drp = (DropDownList)sender;
        //RepeaterItem RItem;
        //RItem = (RepeaterItem)LOBJ_Drp.Parent;
        //int LINT_ItemIndex = RItem.ItemIndex;
        //int LINT_SelRow = RItem.ItemIndex;
        //this.hidShowTag.Value = "fraTab55Caption";

        //string LSTR_SeletedValue = LOBJ_Drp.SelectedValue;
        //bool LBOL_Sel = false;
        ////判斷是否有選擇過
        //if (LSTR_SeletedValue != "")
        //{
        //    for (int j = 0; j < rptMLDCASEAPPENDDOC.Items.Count; j++)
        //    {
        //        string LSTR_Code = ((HiddenField)rptMLDCASEAPPENDDOC.Items[j].FindControl("hidDocID")).Value.ToString();
        //        if (LSTR_Code == LSTR_SeletedValue)
        //        {
        //            LBOL_Sel = true;
        //            break;
        //        }
        //    }
        //}

        //if (LBOL_Sel == false)
        //{
        //    //將值填入hidden
        //    ((HiddenField)RItem.FindControl("hidDocID")).Value = LSTR_SeletedValue;

        //    //rptMLDCASEAPPENDDOC
        //    DataTable LOBJ_DocData = (DataTable)ViewState["Doc"];
        //    //先賦值
        //    for (int i = 0; i < rptMLDCASEAPPENDDOC.Items.Count; i++)
        //    {
        //        if (LINT_ItemIndex == i)
        //        {
        //            LOBJ_DocData.Rows[i]["DCODE"] = ((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDocID")).Value.ToString();
        //            LOBJ_DocData.Rows[i]["DOCCONFIRM"] = "false";
        //            LOBJ_DocData.Rows[i]["NOTE"] = "";
        //        }
        //        else
        //        {
        //            LOBJ_DocData.Rows[i]["DCODE"] = ((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDocID")).Value.ToString();
        //            LOBJ_DocData.Rows[i]["DOCCONFIRM"] = ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked.ToString();
        //            LOBJ_DocData.Rows[i]["NOTE"] = ((TextBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("txtNOTE")).Text.ToString();
        //        }

        //    }
        //    ((CheckBox)RItem.FindControl("chkDOCCONFIRM")).Checked = false;
        //    ((TextBox)RItem.FindControl("txtNOTE")).Text = "";
        //    //getDocListBind();
        //    //若是最後一關
        //    if (LINT_SelRow == this.rptMLDCASEAPPENDDOC.Items.Count - 1)
        //    {
        //        DataRow LOBJ_DocInfo = LOBJ_DocData.NewRow();

        //        LOBJ_DocInfo["DOCCONFIRM"] = "False";
        //        LOBJ_DocInfo["SLABEL"] = "False";
        //        LOBJ_DocData.Rows.Add(LOBJ_DocInfo);

        //        rptMLDCASEAPPENDDOC.DataSource = LOBJ_DocData;
        //        rptMLDCASEAPPENDDOC.DataBind();
        //        ViewState["Doc"] = LOBJ_DocData;
        //        getDocListBind();
        //    }
        //}
        //else
        //{

        //    ((DropDownList)rptMLDCASEAPPENDDOC.Items[rptMLDCASEAPPENDDOC.Items.Count - 1].FindControl("drpDocName")).SelectedIndex = 0;
        //    Alert("已選擇該項目！");
        //}
        //this.UpdatePanelMLDCASEAPPENDDOC.Update();
    }
    /*==============================================================================================*/
    protected double IRR_Cal()
    {
        if (hidTRANSCOST.Value == "0")
        {
            Alert("請輸入標的物金額！");
            txtTRANSCOST.Focus();
            return 0;
        }
        if (txtCONTRACTMONTH.Text == "")
        {
            Alert("請輸入總承作月數！");
            txtCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtPAYMONTH.Text == "")
        {
            Alert("請輸入幾月一付！");
            txtPAYMONTH.Focus();
            return 0;
        }
        if (drpPAYTIMET.SelectedIndex == 0)
        {
            Alert("請選擇付款時間！");
            drpPAYTIMET.Focus();
            return 0;
        }
        if (txtENDPAY1.Text == "")
        {
            Alert("請輸入第一段結束期別！");
            txtENDPAY1.Focus();
            return 0;
        }
        if (txtPRINCIPAL1.Text == "")
        {
            Alert("請輸入第一段期付款！");
            txtPRINCIPAL1.Focus();
            return 0;
        }

        if (hidTRANSCOST.Value == "0")
        {
            Alert("標的物金額輸入需大於 0！");
            txtTRANSCOST.Focus();
            return 0;
        }
        if (txtCONTRACTMONTH.Text == "0")
        {
            Alert("總承作月數輸入需大於 0！");
            txtCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtPAYMONTH.Text == "0")
        {
            Alert("幾月一付輸入需大於 0！");
            txtPAYMONTH.Focus();
            return 0;
        }
        if (txtENDPAY1.Text == "0")
        {
            Alert("第一段結束期別輸入需大於 0！");
            txtENDPAY1.Focus();
            return 0;
        }

        // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
        //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
        if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
        {

            if (txtPRINCIPAL1.Text == "0")
            {
                Alert("第一段期付款輸入需大於 0！");
                txtPRINCIPAL1.Focus();
                return 0;
            }
        }
        bool LBOL_Checked = false;
        if (txtENDPAY4.Text != "")
        {
            if (txtCONTRACTMONTH.Text != txtENDPAY4.Text)
            {
                Alert("最後一段結束期別輸入需等於總承作月數！");
                txtENDPAY4.Focus();
                return 0;
            }
            else
            {
                LBOL_Checked = true;
            }
        }
        if (!LBOL_Checked)
        {
            if (txtENDPAY3.Text != "")
            {
                if (txtCONTRACTMONTH.Text != txtENDPAY3.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtENDPAY3.Focus();
                    return 0;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }
        if (!LBOL_Checked)
        {
            if (txtENDPAY2.Text != "")
            {
                if (txtCONTRACTMONTH.Text != txtENDPAY2.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtENDPAY2.Focus();
                    return 0;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }
        if (!LBOL_Checked)
        {
            if (txtENDPAY1.Text != "")
            {
                if (txtCONTRACTMONTH.Text != txtENDPAY1.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtENDPAY1.Focus();
                    return 0;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }
        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(hidTRANSCOST.Value) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFIRSTPAY.Text) / 1.05), 0);
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtPAYMONTH.Text);
        //期數比例
        double LINT_MONTH = 0;
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtENDPAY4.Text);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
        double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PayDiff = Convert.ToInt32(txtPATDAYS.Text) - Convert.ToInt32(txtSUPPILERDAYS.Text);
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
        Decimal LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtPURCHASEMARGIN.Text) - Convert.ToDecimal(txtPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtCAPITALCOST.Text) / 100 / 365, 0);
        //20231130專案扣款金額(扣款金額÷扣款總年數)乘以(期數除12)
        Decimal ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue) * Convert.ToDecimal(LINT_CONTRACTMONTH / 12.0);
        if (ProjectDISCAMT >= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130金額不可超過專案扣款金額
        if (ProjectDISCAMT < 0 && ProjectDISCAMT <= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130負成本金額不可超過專案扣款金額
        //計算第0期的現金流量
        //租購保證金+頭期款(未稅)+履約保證金+手續費收入-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金
        LDBL_VALUE[0] = Convert.ToDouble(Convert.ToDecimal(txtPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                                         + LDCE_FirstPay //頭期款(未稅)
                                         + Convert.ToDecimal(txtPERBOND.Text) //履約保證金txtPERBOND
                                         + Convert.ToDecimal(LDCE_Fee) //手續費收入
                                         - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                                         - Convert.ToDecimal(txtINSURANCE.Text) //保險費txtINSURANCE
                                                                                //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                                //- Convert.ToDecimal(txtOTHERFEES.Text) //作業費用txtOTHERFEES
                                         - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtOTHERFEES.Text) / 1.05), 0)
                                         //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                                         - Convert.ToDecimal(txtOTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
                                         - LDEC_PayDiffAmount                    //撥差金額
                                         - Convert.ToDecimal(txtCOMMISSION.Text)//佣金txtCOMMISSION
                                         - ProjectDISCAMT);//20231130 ADD專案扣款金額
        //20231130將幾月一付加入IRR計算
        //如果是期初收
        if (drpPAYTIMET.SelectedValue == "01")
        {
            LDBL_VALUE[0] += Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
        }
        for (int i = LINT_PAYMONTH; i <= Convert.ToInt32(LINT_CONTRACTMONTH); i += LINT_PAYMONTH)
        {
            //期末付的期數為幾月一付-1
            int j = i - 1;
            //最後一期
            if (i == Convert.ToInt32(LINT_CONTRACTMONTH))//20231130期數除以幾月一付來取得付款次數
            {
                //最後一期付款
                Decimal LDCE_PRINCIPAL = 0;
                if (LINT_ENDPAY1 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL1.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL2.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL3.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL4.Text) * LINT_PAYMONTH;
                }
                if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH == 01)
                {
                    LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                else if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH != 01)
                {
                    LDBL_VALUE[j] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                 + LDCE_Residuals  //殘值
                                                 - Convert.ToDecimal(txtPURCHASEMARGIN.Text)  //租購保證金txtPURCHASEMARGIN
                                                 - Convert.ToDecimal(txtPERBOND.Text));//履約保證金txtPURCHASEMARGIN
            }
            else
            {
                //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
                //期初收
                if (drpPAYTIMET.SelectedValue == "01")
                {
                    if (i >= 1 && i <= LINT_ENDPAY1 - 1)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                }
                else
                {
                    //20231130幾月一付若為1跟著i走
                    if (LINT_PAYMONTH == 01)
                    {
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                    else
                    {
                        //20231130幾月一付不為1時要等於幾月一付-1
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                }
            }

            //Modify 20120613 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
            //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
            if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }
                    //20121112 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
                    double INSU = INSU_Cal((i / 12));
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                     //- (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
                                                     );
                }
            }
            else
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
                                                     );
                }
            }
        }
        double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200;
        //20230725 政策調整 IRR結果-0.5% 
        //20230815取消調整
        //LDBL_IRR -= 0.5;
        return LDBL_IRR;
    }

    //Modify 20121108 By SS Steven. Reason: 修改設備事務機案件的系統保險費成本計算邏輯
    protected double INSU_Cal(int year)
    {
        double INSU = 1;
        if (year > 0)
        {
            for (int i = 0; i < year; i++)
            {
                INSU = INSU * (5.0 / 6.0);
            }
        }
        return INSU;
    }

    protected double NPV_Cal(string NPVRATECOST)
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(hidTRANSCOST.Value) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFIRSTPAY.Text) / 1.05), 0);
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtPAYMONTH.Text);
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtENDPAY4.Text);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
        //期數比例
        double LINT_MONTH = 0;
        double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PayDiff = Convert.ToInt32(txtPATDAYS.Text) - Convert.ToInt32(txtSUPPILERDAYS.Text);
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將資金成本改成NPV利率成本.
        //Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，撥差金額計算公式中，由NPV成本計算改成資金成本計算，所以使用舊的計算方法即可.
        //舊公式->撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
        //新公式->撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * NPV利率成本 / 365天
        Decimal LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtPURCHASEMARGIN.Text) - Convert.ToDecimal(txtPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtCAPITALCOST.Text) / 100 / 365, 0);
        //Decimal LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtPURCHASEMARGIN.Text) - Convert.ToDecimal(txtPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtNPVRATECOST.Text) / 100 / 365, 0);
        //20231130專案扣款金額(扣款金額÷扣款總年數)乘以(期數除12)
        Decimal ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue) * Convert.ToDecimal(LINT_CONTRACTMONTH / 12.0);
        if (ProjectDISCAMT >= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130金額不可超過專案扣款金額
        if (ProjectDISCAMT < 0 && ProjectDISCAMT <= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130負成本金額不可超過專案扣款金額
        //計算第0期的現金流量
        LDBL_VALUE[0] = Convert.ToDouble(Convert.ToDecimal(txtPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                                         + LDCE_FirstPay //頭期款(未稅)
                                         + Convert.ToDecimal(txtPERBOND.Text) //履約保證金txtPERBOND
                                         + Convert.ToDecimal(LDCE_Fee) //手續費收入
                                         - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                                         - Convert.ToDecimal(txtINSURANCE.Text) //保險費txtINSURANCE
                                                                                //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                                //- Convert.ToDecimal(txtOTHERFEES.Text) //作業費用txtOTHERFEES
                                         - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtOTHERFEES.Text) / 1.05), 0)
                                         //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                                         - Convert.ToDecimal(txtOTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
                                         - LDEC_PayDiffAmount                    //撥差金額
                                         - Convert.ToDecimal(txtCOMMISSION.Text)//佣金txtCOMMISSION
                                         - ProjectDISCAMT);//20231130 ADD專案扣款金額
                                                           //20231130將幾月一付加入NPV計算
                                                           //如果是期初收
        if (drpPAYTIMET.SelectedValue == "01")
        {
            LDBL_VALUE[0] += Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
        }
        for (int i = LINT_PAYMONTH; i <= Convert.ToInt32(LINT_CONTRACTMONTH); i += LINT_PAYMONTH)
        {
            //期末付的期數為幾月一付-1
            int j = i - 1;
            //最後一期
            if (i == Convert.ToInt32(LINT_CONTRACTMONTH))//20231130期數除以幾月一付來取得付款次數
            {
                //最後一期付款
                Decimal LDCE_PRINCIPAL = 0;
                if (LINT_ENDPAY1 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL1.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL2.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL3.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL4.Text) * LINT_PAYMONTH;
                }
                if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH == 01)
                {
                    LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                else if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH != 01)
                {
                    LDBL_VALUE[j] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                 + LDCE_Residuals  //殘值
                                                 - Convert.ToDecimal(txtPURCHASEMARGIN.Text)  //租購保證金txtPURCHASEMARGIN
                                                 - Convert.ToDecimal(txtPERBOND.Text));//履約保證金txtPURCHASEMARGIN
            }
            else
            {
                //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
                //期初收
                if (drpPAYTIMET.SelectedValue == "01")
                {
                    if (i >= 1 && i <= LINT_ENDPAY1 - 1)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                }
                else
                {
                    //20231130幾月一付若為1跟著i走
                    if (LINT_PAYMONTH == 01)
                    {
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                    else
                    {
                        //20231130幾月一付不為1時要等於幾月一付-1
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                }
            }

            //Modify 20120613 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
            //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
            if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }
                    //20121112 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
                    double INSU = INSU_Cal((i / 12));
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                     //- (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
                                                     );
                }
            }
            else
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
                                                     );
                }
            }
        }

        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將第0期的流出與其他期的流入分開.
        double[] LDBL_OUT_VALUE = new double[1];
        double[] LDBL_IN_VALUE = new double[LINT_CONTRACTMONTH];
        LDBL_OUT_VALUE[0] = LDBL_VALUE[0];
        for (int i = 0; i < LDBL_IN_VALUE.Length; i++)
        {
            LDBL_IN_VALUE[i] = LDBL_VALUE[i + 1];
        }

        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將資金成本改成NPV利率成本.原本直接帶txtNPVRATECOST.Text改由傳入參數NPVRATECOST
        //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtCAPITALCOST.Text) / 12 / 100, ref LDBL_VALUE);
        //Modify 20141204 By SS Eric    Reason:新增「NPV2」.「NPV2成本」欄位
        //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtNPVRATECOST.Text) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
        double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(NPVRATECOST) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
        return LDBL_NPV;
    }

    private Decimal[][] PPMT_Cal()
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(hidTRANSCOST.Value) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFIRSTPAY.Text) / 1.05), 0);
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtPAYMONTH.Text);
        //期數比例
        double LINT_MONTH = 0;
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtENDPAY4.Text);
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PayDiff = Convert.ToInt32(txtPATDAYS.Text) - Convert.ToInt32(txtSUPPILERDAYS.Text);
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
        Decimal LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtPURCHASEMARGIN.Text) - Convert.ToDecimal(txtPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtCAPITALCOST.Text) / 100 / 365, 0);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
        Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
        //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 現金流量[][4]	        
        //第 0 期 
        LDBL_VALUE[0] = new Decimal[5];
        LDBL_VALUE[0][0] = 0;
        LDBL_VALUE[0][1] = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtFIRSTPAY.Text))); //頭期款(含稅)
        LDBL_VALUE[0][2] = LDCE_TransCost; //標的物金額(未稅)
        LDBL_VALUE[0][3] = 0; //利息
        //租購保證金+頭期款(未稅)+履約保證金-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金
        LDBL_VALUE[0][4] = Convert.ToDecimal(txtPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                         + LDCE_FirstPay //頭期款(未稅)
                         + Convert.ToDecimal(txtPERBOND.Text) //履約保證金txtPERBOND
                         + Convert.ToDecimal(LDCE_Fee) //手續費收入
                         - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                         - Convert.ToDecimal(txtINSURANCE.Text) //保險費txtINSURANCE
                                                                //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                //- Convert.ToDecimal(txtOTHERFEES.Text) //作業費用txtOTHERFEES
                         - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtOTHERFEES.Text) / 1.05), 0)
                         //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                         - Convert.ToDecimal(txtOTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
                         - LDEC_PayDiffAmount                    //撥差金額
                         - Convert.ToDecimal(txtCOMMISSION.Text);//佣金txtCOMMISSION
        //如果是期初收
        if (drpPAYTIMET.SelectedValue == "01")
        {
            LDBL_VALUE[0][4] += Convert.ToDecimal(txtPRINCIPAL1.Text); //月付款
        }
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            //最後一期
            if (i == LINT_CONTRACTMONTH)
            {
                //最後一期付款
                Decimal LDCE_PRINCIPAL = 0;
                if (LINT_ENDPAY1 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL1.Text);
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL2.Text);
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL3.Text);
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtPRINCIPAL4.Text);
                }
                if (drpPAYTIMET.SelectedValue == "02")
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(LDCE_PRINCIPAL)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(LDCE_PRINCIPAL)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(LDCE_PRINCIPAL) //月付款
                                     + LDCE_Residuals //殘值
                                     - Convert.ToDecimal(txtPURCHASEMARGIN.Text)  //租購保證金
                                     - Convert.ToDecimal(txtPERBOND.Text);  //履約保證金
                }
                else
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = 0; //月付款
                    LDBL_VALUE[i][2] = 0; //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    //最後一期=月付款+殘值-租購保證金-履約保證金
                    LDBL_VALUE[i][4] = LDCE_Residuals //殘值
                                     - Convert.ToDecimal(txtPURCHASEMARGIN.Text)  //租購保證金
                                     - Convert.ToDecimal(txtPERBOND.Text);  //履約保證金
                }
            }
            else
            {
                if (i >= 1 && i <= LINT_ENDPAY1)
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtPRINCIPAL1.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtPRINCIPAL1.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtPRINCIPAL1.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtPRINCIPAL2.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtPRINCIPAL2.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtPRINCIPAL2.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtPRINCIPAL3.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtPRINCIPAL3.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtPRINCIPAL3.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtPRINCIPAL4.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtPRINCIPAL4.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtPRINCIPAL4.Text); //月付款
                }
            }

            //Modify 20120613 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
            //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
            if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }

                    //Modify 20121108 By SS Steven. Reason: 修改設備事務機案件的系統保險費成本計算邏輯
                    double INSU = INSU_Cal((i / 12));
                    LDBL_VALUE[i][4] = Convert.ToDecimal(Convert.ToDecimal(LDBL_VALUE[i][4])
                                                      //- (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
                                                      - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                        );
                }
            }
            else
            {
                if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
                {
                    //計算期數比例 不滿一年按比例計算保險費
                    LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                    if (LINT_MONTH > 1)
                    {
                        LINT_MONTH = 1;
                    }
                    LDBL_VALUE[i][4] = Convert.ToDecimal(Convert.ToDecimal(LDBL_VALUE[i][4])
                                                      - (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
                                                        );
                }
            }
        }
        return LDBL_VALUE;
    }
    protected void btnIRR_Click(object sender, EventArgs e)
    {
        try
        {
            //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
            if (drpMAINTYPE.SelectedValue != "04" && txtNOINSURANCEFLG.Checked == false)
            {
                //20131001 ADD BY ADAM Reason.營資租與營建機具才可以做保險費的錯誤判斷
                string strTARGETTYPE = "";
                if (rptMLDCASETARGET.Items.Count > 0)
                {
                    strTARGETTYPE = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedItem.Text.ToString().Trim();
                }
                if ((strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具") ||
                    (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02"))
                {
                    if (CheckINSUREERR())
                    {
                        return;
                    }
                }
            }
            this.hidShowTag.Value = "fraTab22Caption";
            if (this.drpMAINTYPE.SelectedValue == "04")
            {

            }
            else
            {
                double LINT_IRR = IRR_Cal();
                if (LINT_IRR > 100 || LINT_IRR < -100)
                {
                    Alert("試算異常！請檢核金額項目！");
                    this.txtIRR.Text = "0.000";
                }
                else
                {
                    this.txtIRR.Text = LINT_IRR.ToString("0.000");
                }

                //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
                this.txtNPVRATECOST0.Text = "1";
                double LINT_NPV0 = NPV_Cal(txtNPVRATECOST0.Text);
                this.txtNPV0.Text = LINT_NPV0.ToString("0");

                //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
                //Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
                //double LINT_NPVRATECOST = GET_NPVRATECOST();
                //this.txtNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
                //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
                //Modify 20240815 利率成本改4.75%
                //this.txtNPVRATECOST.Text = "4";
                this.txtNPVRATECOST.Text = "4.75";
                this.txtNPVRATECOST2.Text = "5";

                double LINT_NPV = NPV_Cal(txtNPVRATECOST.Text);
                double LINT_NPV2 = NPV_Cal(txtNPVRATECOST2.Text);
                this.txtNPV.Text = LINT_NPV.ToString("0");
                this.txtNPV2.Text = LINT_NPV2.ToString("0");
            }
        }
        catch (Exception ex)
        {
            Alert("試算異常！請檢核金額項目！");
            this.txtIRR.Text = "0.000";
        }
        this.UpdatePanelIRR.Update();
        this.UpdatePanelNPV.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPV2.Update();
        //Modify 20120229 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNRC.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNRC2.Update();
        //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」欄位
        this.UpdatePanelNPV0.Update();
        //Modify 20141204 By SS Eric    Reason:新增「NPV2」.「NPV2成本」欄位
        this.UpdatePanelNRC0.Update();

    }
    public bool btnDelEnable()
    {
        string LSTR_Static = this.lblStatus.Text;
        if (LSTR_Static == "" || LSTR_Static == "查詢")
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    private void DisabledRPRINCIPAL()
    {
        //20130703 UPD BY BRENT Reason.取消原本資租(02)不能填寫多段式租金的設定
        if (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02" || drpMAINTYPE.SelectedValue == "03")
        {
            txtSTARTPAY2.Enabled = true;
            txtSTARTPAY3.Enabled = true;
            txtSTARTPAY4.Enabled = true;

            txtENDPAY2.Enabled = true;
            txtENDPAY3.Enabled = true;
            txtENDPAY4.Enabled = true;

            txtPRINCIPAL2.Enabled = true;
            txtPRINCIPAL3.Enabled = true;
            txtPRINCIPAL4.Enabled = true;

            txtPRINCIPALTAX2.Enabled = true;
            txtPRINCIPALTAX3.Enabled = true;
            txtPRINCIPALTAX4.Enabled = true;
        }
        else
        {
            txtSTARTPAY2.Enabled = false;
            txtSTARTPAY3.Enabled = false;
            txtSTARTPAY4.Enabled = false;

            txtENDPAY2.Enabled = false;
            txtENDPAY3.Enabled = false;
            txtENDPAY4.Enabled = false;

            txtPRINCIPAL2.Enabled = false;
            txtPRINCIPAL3.Enabled = false;
            txtPRINCIPAL4.Enabled = false;

            txtPRINCIPALTAX2.Enabled = false;
            txtPRINCIPALTAX3.Enabled = false;
            txtPRINCIPALTAX4.Enabled = false;

            txtSTARTPAY2.Text = "";
            txtSTARTPAY3.Text = "";
            txtSTARTPAY4.Text = "";

            txtENDPAY2.Text = "";
            txtENDPAY3.Text = "";
            txtENDPAY4.Text = "";

            txtPRINCIPAL2.Text = "";
            txtPRINCIPAL3.Text = "";
            txtPRINCIPAL4.Text = "";

            txtPRINCIPALTAX2.Text = "";
            txtPRINCIPALTAX3.Text = "";
            txtPRINCIPALTAX4.Text = "";
        }
    }

    private void rptDataBind()
    {
        String LSTR_ObjId;
        Comus.HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();

            LVAR_Parameter[0] = "SP_ML6003_Q02";
            LVAR_Parameter[1] = "'" + this.txtCUSTID.Text.Trim() + "','" + Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd")) + "'";
            LVAR_Parameter[1] += ",'1',''";

            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);

            Decimal LDBL_INSURANCET = 0;
            Decimal LDBL_ACTUSLLOANST = 0;
            Decimal LDBL_AMOUNTNT = 0;
            Decimal LDBL_AMOUNTYT = 0;

            Decimal LDBL_SINSURANCET = 0;
            Decimal LDBL_SACTUSLLOANST = 0;
            Decimal LDBL_SAMOUNTNT = 0;
            Decimal LDBL_SAMOUNTYT = 0;

            string LSTR_CTYPE = "";
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                DataTable LDAT_Data = LOBJ_Return.ReturnData;
                DataTable LOBJ_TData = LDAT_Data.Copy();
                DataRow LOBJ_DataRow = null;
                int INT_ICount = 0;
                LSTR_CTYPE = LDAT_Data.Rows[0]["CTYPE"].ToString();
                for (int i = 0; i < LDAT_Data.Rows.Count; i++)
                {
                    string LSTR_CTYPENOW = LDAT_Data.Rows[i]["CTYPE"].ToString();
                    LDBL_SINSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                    LDBL_SACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                    LDBL_SAMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                    LDBL_SAMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());

                    if (LSTR_CTYPE == LSTR_CTYPENOW)
                    {
                        LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                        LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                        LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                        LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
                    }
                    else
                    {
                        LOBJ_DataRow = LOBJ_TData.NewRow();
                        LOBJ_DataRow["CTYPE"] = "小計";
                        LOBJ_DataRow["CNTRNO"] = "";
                        LOBJ_DataRow["TNAME"] = "";
                        LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
                        LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;

                        LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
                        LOBJ_DataRow["CONTRACTMONTH"] = "0";
                        LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                        LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
                        LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
                        INT_ICount += 1;
                        LDBL_INSURANCET = 0;
                        LDBL_ACTUSLLOANST = 0;
                        LDBL_AMOUNTNT = 0;
                        LDBL_AMOUNTYT = 0;

                        LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                        LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                        LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                        LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());

                        LSTR_CTYPE = LSTR_CTYPENOW;
                    }
                    if (i == LDAT_Data.Rows.Count - 1)
                    {
                        LOBJ_DataRow = LOBJ_TData.NewRow();
                        LOBJ_DataRow["CTYPE"] = "小計";
                        LOBJ_DataRow["CNTRNO"] = "";
                        LOBJ_DataRow["TNAME"] = "";
                        LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
                        LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;

                        LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
                        LOBJ_DataRow["CONTRACTMONTH"] = "0";
                        LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                        LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
                        INT_ICount += 1;
                        LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
                        LDBL_INSURANCET = 0;
                        LDBL_ACTUSLLOANST = 0;
                        LDBL_AMOUNTNT = 0;
                        LDBL_AMOUNTYT = 0;

                        LOBJ_DataRow = LOBJ_TData.NewRow();
                        LOBJ_DataRow["CTYPE"] = "合計";
                        LOBJ_DataRow["CNTRNO"] = "";
                        LOBJ_DataRow["TNAME"] = "";
                        LOBJ_DataRow["GUARAMT"] = LDBL_SINSURANCET;
                        LOBJ_DataRow["ACTUSLLOANS"] = LDBL_SACTUSLLOANST;

                        LOBJ_DataRow["AMOUNTN"] = LDBL_SAMOUNTNT;
                        LOBJ_DataRow["CONTRACTMONTH"] = "0";
                        LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                        LOBJ_DataRow["AMOUNTY"] = LDBL_SAMOUNTYT;
                        INT_ICount += 1;
                        LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);

                        LSTR_CTYPE = LSTR_CTYPENOW;
                    }
                }
                this.rptData.DataSource = LOBJ_TData;
                this.rptData.DataBind();
            }
            else
            {
                this.rptData.DataSource = null;
                this.rptData.DataBind();
            }
            this.UpdatePanelrptData.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region NPV利率成本計算
    //***********************************************************************
    protected enum TypeA : int
    {
        NewMachinesThree,
        NewMachinesTwo,
        UsedMachines,
        RawMaterials,
        AR,
        MachinesNotSet
    };

    protected enum TypeB : int
    {
        LessThan300,
        Range300_1000,
        Range1000_3000,
        Exceed3000,
        LISTED
    };

    //產生NPV利率成本
    protected double GET_NPVRATECOST()
    {
        double NPVCOST = 0;
        //==========================================
        //計算NPV所要取得的欄位
        //實收資本額
        //承作型態一
        //承作型態二
        //交易型態
        //供應商
        //上市櫃
        //標的物種類
        //設備狀況
        //保證人是否有醫師證明
        //==========================================
        //設定參數
        string CUSTID = txtCUSTID.Text;
        long CUSTNOWCAPTIAL = Convert.ToInt64(txtCUSTNOWCAPTIAL.Text.Replace(",", ""));            //實收資本額
        string MAINTYPE = drpMAINTYPE.SelectedValue;                                              //承作型態一
        string SUBTYPE = drpSUBTYPE.SelectedValue;                                                //承作型態二
        string TRANSTYPE = drpTRANSTYPE.SelectedValue;                                            //交易型態
        string SUPPLIERID = GetSupplierID();                                                      //供應商
        string LISTED = GetLISTED(txtCUSTID.Text);                                                //上市櫃
        string TARGETSTATUS = GetTARGETSTATUS();                                                  //設備狀況

        //Modify 20121108 By SS Steven. Reason: 設備台新策盟案件則有另外的IRR成本
        string BANKCD = drpBANKCD.SelectedValue;   //銀行別

        SUBTYPE = MAINTYPE + "_" + SUBTYPE;
        //==========================================
        //上市櫃說明
        //1	上市
        //2	上櫃
        //3	無
        //4	興櫃公司
        //==========================================
        //設備狀況說明
        //01	存貨/原物料
        //02	新機
        //03	中古機
        //==========================================
        //交易型態
        //01	兩方
        //02	三方
        //==========================================
        //步驟一：判斷是否為事務機
        //  01_01	營租-事務機
        //  01_02	營租-非事務機
        //  02_01	資租-事務機
        //  02_02	資租-非事務機
        //  03_01	分期-原物料分期
        //  03_02	分期-附條買
        //  03_03	分期-設備動保
        //  03_04	分期-設備無設定
        //  04_01	應收-應收帳款受讓
        //  04_02	應收-新機買賣
        //  04_03	應收-中古機買賣

        if (SUBTYPE == "01_01" || SUBTYPE == "02_01")   //事務機
        {
            if (SUPPLIERID != "")
            {
                //有取得供應商ID
                NPVCOST = GetSupplierNPV(SUPPLIERID);
                if (NPVCOST == 0)
                {
                    Alert("承作型態二為事務機時，標的物需輸入有設定NPV利率成本的供應商！");

                }
                return NPVCOST;
            }
            else
            {
                //2013.03.14 Edit by Sean 設備狀況無資料，預設改以原物料認定
                //若無供應商編號，則以中古機為標準
                //NPVCOST = GetNBMNPVRATECOST(TypeA.UsedMachines, CUSTNOWCAPTIAL, LISTED);
                NPVCOST = GetNBMNPVRATECOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);
                return NPVCOST;
            }
        }
        else    //非事務機
        {
            if (SUBTYPE == "04_01")    //應收帳款-應收帳款受讓
            {
                NPVCOST = GetNBMNPVRATECOST(TypeA.AR, CUSTNOWCAPTIAL, LISTED);
            }
            else if (SUBTYPE == "04_02")    //應收帳款-新機買賣
            {
                NPVCOST = GetNBMNPVRATECOST(TypeA.NewMachinesThree, CUSTNOWCAPTIAL, LISTED);
            }
            else if (SUBTYPE == "04_03")    //應收帳款-中古機買賣
            {
                NPVCOST = GetNBMNPVRATECOST(TypeA.UsedMachines, CUSTNOWCAPTIAL, LISTED);
            }
            else if (SUBTYPE == "03_01")    //分期-原物料分期
            {
                //NPVCOST = GetNBMNPVRATECOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);

                //Modify 20121108 By SS Steven. Reason: 設備台新策盟案件則有另外的IRR成本
                if (BANKCD == "01")
                {
                    NPVCOST = GetTASINCOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);
                }
                else
                {
                    NPVCOST = GetNBMNPVRATECOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);
                }
            }
            else if (SUBTYPE == "03_04")    //分期-設備無設定
            {
                NPVCOST = GetNBMNPVRATECOST(TypeA.MachinesNotSet, CUSTNOWCAPTIAL, LISTED);
            }
            else    //營、資租與分期為非事務機
            {
                if (ChkUsedMachines())    //(設備狀況從嚴認定，無資料時，預設以中古機認定，若有資料，且其一為中古機，則仍以中古機認定。)
                {
                    //2013.03.14 Edit by Sean 設備狀況無資料，預設改以原物料認定
                    //NPVCOST = GetNBMNPVRATECOST(TypeA.UsedMachines, CUSTNOWCAPTIAL, LISTED);
                    if (TARGETSTATUS == "")
                    {
                        NPVCOST = GetNBMNPVRATECOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);
                    }
                    else
                    {
                        NPVCOST = GetNBMNPVRATECOST(TypeA.UsedMachines, CUSTNOWCAPTIAL, LISTED);
                    }
                }
                else if (TARGETSTATUS == "01")         //存貨/原物料
                {
                    NPVCOST = GetNBMNPVRATECOST(TypeA.RawMaterials, CUSTNOWCAPTIAL, LISTED);
                }
                else if (TARGETSTATUS == "02")    //新機
                {
                    if (TRANSTYPE == "01")    //兩方
                    {
                        NPVCOST = GetNBMNPVRATECOST(TypeA.NewMachinesTwo, CUSTNOWCAPTIAL, LISTED);
                    }
                    else if (TRANSTYPE == "02")    //三方
                    {
                        NPVCOST = GetNBMNPVRATECOST(TypeA.NewMachinesThree, CUSTNOWCAPTIAL, LISTED);
                    }
                }
                else if (TARGETSTATUS == "03")    //中古機
                {
                    NPVCOST = GetNBMNPVRATECOST(TypeA.UsedMachines, CUSTNOWCAPTIAL, LISTED);
                }
            }

        }

        return NPVCOST;
    }

    //判斷保證人職業是否為醫師
    protected bool ChkGRTJOB()
    {
        string GRTJOB = GetGRTJOB();        //保證人的職業是否為醫師
        //Modify 20121115 By SS Gordon. Reason: 將保證人為醫生的代碼由01改成27
        if (GRTJOB == "27")
        {
            return true;
        }

        return false;
    }

    //判斷是否為醫療設備
    protected bool ChkTARGETTYPE()
    {
        ArrayList TARGETTYPEArrayList = GetTARGETTYPE();        //標的物種類
        try
        {
            for (int i = 0; i < TARGETTYPEArrayList.Count; i++)
            {
                string TARGETTYPE = TARGETTYPEArrayList[i].ToString();
                ReturnObject<DataSet> LOBJ_ReturnObject = GetTARGETTYPECHECKData(TARGETTYPE);
                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                    if (LDST_Data.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    //Alert(LOBJ_ReturnObject.ReturnMessage);
                }
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }

        return false;
    }

    //判斷是否無資料或有中古機
    protected bool ChkUsedMachines()
    {
        //若多筆時，以第一筆為主
        string TARGETSTATUS = "";
        //標的物主檔
        //MLDCASETARGET
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }

                TARGETSTATUS = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue;
                if (TARGETSTATUS == "03")    //中古機
                {
                    return true;
                }
            }
            if (TARGETSTATUS == "")    //無資料
            {
                return true;
            }
        }
        else    //無資料
        {
            return true;
        }

        return false;
    }

    //取得非事務機的NPV利率成本
    protected double GetNBMNPVRATECOST(TypeA typeA, long CUSTNOWCAPTIAL, string LISTED)
    {
        //將非事務機的NPV利率成本存入陣列
        double[,] NPVRATECOSTLIST = new double[6, 5];
        //新機三方
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.LessThan300] = 5.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Range300_1000] = 5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Range1000_3000] = 4.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Exceed3000] = 4;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.LISTED] = 3;
        //新機兩方
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.LessThan300] = 6;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Range300_1000] = 5.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Range1000_3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Exceed3000] = 4.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.LISTED] = 3;
        //中古機
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.LessThan300] = 6.5;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Range300_1000] = 6;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Range1000_3000] = 5.5;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Exceed3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.LISTED] = 4;
        //原物料
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.LessThan300] = 9;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Range300_1000] = 8;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Range1000_3000] = 7;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Exceed3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.LISTED] = 4;
        //應收帳款
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.LessThan300] = 9;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Range300_1000] = 8;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Range1000_3000] = 7;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Exceed3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.LISTED] = 4;
        //分期-設備無設定
        NPVRATECOSTLIST[(int)TypeA.MachinesNotSet, (int)TypeB.LessThan300] = 9;
        NPVRATECOSTLIST[(int)TypeA.MachinesNotSet, (int)TypeB.Range300_1000] = 8;
        NPVRATECOSTLIST[(int)TypeA.MachinesNotSet, (int)TypeB.Range1000_3000] = 7;
        NPVRATECOSTLIST[(int)TypeA.MachinesNotSet, (int)TypeB.Exceed3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.MachinesNotSet, (int)TypeB.LISTED] = 4;

        double NPVCOST = 0;
        //醫療設備判斷
        if (ChkTARGETTYPE())
        {
            //保證人有職業為醫師的
            if (ChkGRTJOB())
            {
                NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LISTED];
                return NPVCOST;
            }
            else
            {
                NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Exceed3000];
                return NPVCOST;
            }
        }
        //判斷是否為上櫃公司
        if (LISTED == "1" || LISTED == "2")
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LISTED];
            return NPVCOST;
        }
        //判斷資本額
        //未達300萬
        if (CUSTNOWCAPTIAL < 3000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LessThan300];
            return NPVCOST;
        }
        //300(含)~1000萬
        if (CUSTNOWCAPTIAL >= 3000000 && CUSTNOWCAPTIAL < 10000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Range300_1000];
            return NPVCOST;
        }
        //1000(含)~3000萬
        if (CUSTNOWCAPTIAL >= 10000000 && CUSTNOWCAPTIAL < 30000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Range1000_3000];
            return NPVCOST;
        }
        //3000萬(含)以上
        if (CUSTNOWCAPTIAL >= 30000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Exceed3000];
            return NPVCOST;
        }
        return NPVCOST;
    }

    //Modify 20121108 By SS Steven. Reason: 設備台新策盟案件則有另外的IRR成本
    //取得非事務機的NPV利率成本
    protected double GetTASINCOST(TypeA typeA, long CUSTNOWCAPTIAL, string LISTED)
    {
        //將台新策盟的NPV利率成本存入陣列
        double[,] NPVRATECOSTLIST = new double[6, 5];
        //新機三方
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.LessThan300] = 6.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Range300_1000] = 6;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Range1000_3000] = 5.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.Exceed3000] = 5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesThree, (int)TypeB.LISTED] = 4;
        //新機兩方
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.LessThan300] = 7;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Range300_1000] = 6.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Range1000_3000] = 6;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.Exceed3000] = 5.5;
        NPVRATECOSTLIST[(int)TypeA.NewMachinesTwo, (int)TypeB.LISTED] = 4;
        //中古機
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.LessThan300] = 7.5;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Range300_1000] = 7;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Range1000_3000] = 6.5;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.Exceed3000] = 6;
        NPVRATECOSTLIST[(int)TypeA.UsedMachines, (int)TypeB.LISTED] = 5;
        //原物料
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.LessThan300] = 10;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Range300_1000] = 9;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Range1000_3000] = 8;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.Exceed3000] = 6;
        NPVRATECOSTLIST[(int)TypeA.RawMaterials, (int)TypeB.LISTED] = 5;
        //應收帳款
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.LessThan300] = 10;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Range300_1000] = 9;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Range1000_3000] = 8;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.Exceed3000] = 6;
        NPVRATECOSTLIST[(int)TypeA.AR, (int)TypeB.LISTED] = 5;

        double NPVCOST = 0;
        //醫療設備判斷
        if (ChkTARGETTYPE())
        {
            //保證人有職業為醫師的
            if (ChkGRTJOB())
            {
                NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LISTED];
                return NPVCOST;
            }
            else
            {
                NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Exceed3000];
                return NPVCOST;
            }
        }

        //判斷是否為上櫃公司
        if (LISTED == "1" || LISTED == "2")
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LISTED];
            return NPVCOST;
        }

        //判斷資本額
        //未達300萬
        if (CUSTNOWCAPTIAL < 3000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.LessThan300];
            return NPVCOST;
        }
        //300(含)~1000萬
        if (CUSTNOWCAPTIAL >= 3000000 && CUSTNOWCAPTIAL < 10000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Range300_1000];
            return NPVCOST;
        }
        //1000(含)~3000萬
        if (CUSTNOWCAPTIAL >= 10000000 && CUSTNOWCAPTIAL < 30000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Range1000_3000];
            return NPVCOST;
        }
        //3000萬(含)以上
        if (CUSTNOWCAPTIAL >= 30000000)
        {
            NPVCOST = NPVRATECOSTLIST[(int)typeA, (int)TypeB.Exceed3000];
            return NPVCOST;
        }
        return NPVCOST;
    }

    //取得供應商編號
    protected string GetSupplierID()
    {
        //若多筆時，以第一筆為主
        string SupplierID = "";
        //標的物主檔
        //MLDCASETARGET
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }

                SupplierID = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text;
                if (SupplierID != "")
                {
                    return SupplierID;
                }
            }
        }
        return SupplierID;
    }

    //取得標的物類型
    private ArrayList GetTARGETTYPE()
    {
        //需從標的物/標的物種類裡判斷
        //若多筆資料，只要其中一筆是醫療設備，條件即成立
        ArrayList TARGETTYPEArrayList = new ArrayList();
        //標的物主檔
        //MLDCASETARGET
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }

                TARGETTYPEArrayList.Add(((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0]);
            }
        }

        return TARGETTYPEArrayList;
    }

    //取得設備狀態
    private string GetTARGETSTATUS()
    {
        //若多筆時，以第一筆為主
        string TARGETSTATUS = "";
        //標的物主檔
        //MLDCASETARGET
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }

                TARGETSTATUS = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue;
                if (TARGETSTATUS != "")
                {
                    return TARGETSTATUS;
                }
            }
        }
        return TARGETSTATUS;
    }

    //取得保證人職業
    private string GetGRTJOB()
    {
        //需從擔保條件/保證人/職業裡判斷
        //若多筆資料，只要其中一筆是醫師，條件即成立，回傳"27"
        //案件申請保證人資料明細檔
        if (rptMLDCASEGUARANTEE.Items.Count > 0 && chkMLDCASEGUARANTEE.Checked == false)
        {
            for (int i = 0; i < this.rptMLDCASEGUARANTEE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTCODE")).Text.Trim() == "" || ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGRTNAME")).Text.Trim() == "")
                {
                    continue;
                }
                //Modify 20121115 By SS Gordon. Reason: 將保證人為醫生的代碼由01改成27
                if (((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).SelectedValue == "27")
                {
                    return "27";
                }
            }
        }
        return "";
    }

    //取得供應商所對應的NPVRATECOST
    protected double GetSupplierNPV(string COMPID)
    {
        double NPVCOST = 0;
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSupplierNPVData(COMPID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                //this.drpCUROUT.DataSource = LDST_Data.Tables[0].DefaultView;
                //this.drpCUROUT.DataBind();
                if (LDST_Data.Tables[0].Rows.Count > 0)
                {
                    NPVCOST = Convert.ToDouble(LDST_Data.Tables[0].Rows[0]["NPVRATECOST"].ToString());
                }

            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        return NPVCOST;
    }

    //取得上市櫃資料
    protected string GetLISTED(string CUSTID)
    {
        string LISTED = "0";
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetLISTEDData(CUSTID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                //this.drpCUROUT.DataSource = LDST_Data.Tables[0].DefaultView;
                //this.drpCUROUT.DataBind();
                if (LDST_Data.Tables[0].Rows.Count > 0)
                {
                    LISTED = LDST_Data.Tables[0].Rows[0]["LISTED"].ToString();
                }

            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        return LISTED;
    }

    private ReturnObject<DataSet> GetSupplierNPVData(string COMPID)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            LSTR_StoreProcedure.Append("SP_ML1002_Q17" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(COMPID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    private ReturnObject<DataSet> GetLISTEDData(string CUSTID)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            LSTR_StoreProcedure.Append("SP_ML1002_Q18" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    private ReturnObject<DataSet> GetTARGETTYPECHECKData(string TARGETTYPE)
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            LSTR_StoreProcedure.Append("SP_ML1002_Q19" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(TARGETTYPE + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    //***********************************************************************
    #endregion

    //Modify 20121112 By SS Steven. Reason: 以下三個條件有一個成立，跳出視窗訊息提醒，假如是作業確認就要發email通知
    private bool SendEmailCheck()
    {
        // Modify 20130515 BY SEAN. Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」
        if (Convert.ToInt32(txtACTUSLLOANS.Text.Replace(",", "").Trim()) > Convert.ToInt32(hidCheckACTUSLLOANS.Value.ToString().Replace(",", "").Trim()))
        {
            return true;
        }
        //if (Convert.ToInt32(txtTRANSCOST.Text.Replace(",", "").Trim()) > Convert.ToInt32(hidCheckTRANSCOST.Value.ToString().Replace(",", "").Trim()))
        //{
        //    return true;
        //}
        if (Convert.ToInt32(txtCONTRACTMONTH.Text.Replace(",", "").Trim()) > Convert.ToInt32(hidCheckCONTRACTMONTH.Value.ToString().Replace(",", "").Trim()))
        {
            return true;
        }

        if (drpMAINTYPE.SelectedValue.ToString().Trim() == "04")
        {
            if (Convert.ToDecimal(txtARIRR.Text.Replace(",", "").Trim()) <= Convert.ToDecimal(hidCheckARIRR.Value.ToString().Replace(",", "").Trim()))
            {
                return true;
            }
        }
        else
        {
            if (Convert.ToDecimal(txtIRR.Text.Replace(",", "").Trim()) <= Convert.ToDecimal(hidCheckIRR.Value.ToString().Replace(",", "").Trim()))
            {
                return true;
            }
        }


        return false;
    }

    //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
    private void GetMLPREMCASEBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, preMLMCASEDATA_Data);
        }
    }

    //Modify 20121224 By SS Steven. Reason:三大條件之一成立跳出訊息的比對資料修改，資料改從PRE的TABLE取得
    private NameValueCollection preMLMCASEDATA_Data
    {
        get
        {
            NameValueCollection preMLMCASEDATA = new NameValueCollection();
            preMLMCASEDATA.Add("hidCheckIRR", "IRR");
            return preMLMCASEDATA;
        }
    }

    public static string EscapeStringForJS(string s)
    {
        //REF: http://www.javascriptkit.com/jsref/escapesequence.shtml
        return s.Replace(@"\", @"\\")
                .Replace("\b", @"\b")
                .Replace("\f", @"\f")
                .Replace("\n", @"\n")
                .Replace("\0", @"\0")
                .Replace("\r", @"\r")
                .Replace("\t", @"\t")
                .Replace("\v", @"\v")
                .Replace("'", @"\'")
                .Replace(@"""", @"\""");
    }

    //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕開窗、參數設定
    protected void btINSURANCE_Click(object sender, EventArgs e)
    {
        string strSNTYPE = "";
        string strCASEID = txtCASEID.Text.ToString().Trim();
        string strMOD;
        if (lblStatus.Text == "查詢") { strMOD = "N"; }
        else { strMOD = "Y"; }
        string strMAINTYPEV = drpMAINTYPE.SelectedValue.ToString().Trim();
        string strMAINTYPET = drpMAINTYPE.SelectedItem.Text.ToString().Trim();
        string strSUBTYPEV = drpSUBTYPE.SelectedValue.ToString().Trim();
        string strSUBTYPET = drpSUBTYPE.SelectedItem.Text.ToString().Trim();

        string strTARGETTYPEV = "";
        string strTARGETTYPET = "";
        string strTARGETNAME = "";
        string strTARGETPRICE = "";
        int intTARGETPRICE = 0;
        if (drpMAINTYPE.SelectedValue == "" && drpSUBTYPE.SelectedValue == "")
        {
            Alert("請選擇承作型態！");
            return;
        }
        strTARGETPRICE = hidTRANSCOST.Value.ToString().Replace(",", "");
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            strTARGETTYPEV = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0].ToString();
            strTARGETTYPET = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedItem.Text.ToString().Trim();
            strTARGETNAME = ((TextBox)rptMLDCASETARGET.Items[0].FindControl("txtTARGETNAME")).Text.ToString().Trim();
            //strTARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[0].FindControl("txtTARGETPRICE")).Text.ToString().Replace(",", "").Trim();
            //20130904 ADD BY ADAM Reason.增加保險費計算標的物金額加總
            //for (int i=0;i<rptMLDCASETARGET.Items.Count;i++)
            //{
            //	strTARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text.ToString().Replace(",", "").Trim();
            //	intTARGETPRICE += int.Parse(strTARGETPRICE);
            //}
        }
        else
        {
            Alert("請至少新增一筆標的物的資料！");
            return;
        }
        if (strTARGETTYPEV == "")
        {
            Alert("請輸入標的物種類！");
            return;
        }
        if (strTARGETPRICE == "0")
        {
            Alert("請輸入標的物金額！");
            return;
        }
        string strSCRIPT = "";
        string URL = "../LE.NET/ML10/ML1002D.aspx?userid=" + GSTR_A_USERID + "&PROGID=" + GSTR_A_PRGID + "&strSNTYPE=" + strSNTYPE +
            "&strCASEID=" + strCASEID + "&strMOD=" + strMOD + "&strMAINTYPEV=" + strMAINTYPEV +
            "&strMAINTYPET=" + Server.UrlEncode(strMAINTYPET) + "&strSUBTYPEV=" + strSUBTYPEV +
            "&strSUBTYPET=" + Server.UrlEncode(strSUBTYPET) + "&strTARGETTYPEV=" + strTARGETTYPEV +
            "&strTARGETTYPET=" + Server.UrlEncode(strTARGETTYPET) + "&strTARGETNAME=" + Server.UrlEncode(strTARGETNAME) +
            "&strTARGETPRICE=" + strTARGETPRICE + "&strSOURCE=01&strCUSTID=" + txtCUSTID.Text +
            "&strINSUREERR=" + hidINSUREERR.Value;
        strSCRIPT += "var url = window.showModalDialog('" + URL + "', 'title', 'dialogWidth:650px;dialogHeight:550px;scroll:yes;resizable:yes;status:no;');" + "\n";
        //strSCRIPT += "alert(url);" + "\n";
        strSCRIPT += "if (url) {";
        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        strSCRIPT += "var drpMAINTYPE = document.getElementById('" + drpMAINTYPE.ClientID.ToString().Trim() + "')" + "\n";
        strSCRIPT += "var drpSUBTYPE = document.getElementById('" + drpSUBTYPE.ClientID.ToString().Trim() + "')" + "\n";
        strSCRIPT += "var LOBJ_Control = $('tblMLDCASETARGET').rows[1].cells[1].firstChild;" + "\n";
        strSCRIPT += "document.getElementById('" + txtINSURANCE.ClientID.ToString().Trim() + "').value = url;" + "\n";
        strSCRIPT += "MoneyBlur($('txtINSURANCE'));" + "\n";
        strSCRIPT += "document.getElementById('" + hidMAINTYPE.ClientID.ToString().Trim() + "').value = drpMAINTYPE.options[drpMAINTYPE.selectedIndex].value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidSUBTYPE.ClientID.ToString().Trim() + "').value = drpSUBTYPE.options[drpSUBTYPE.selectedIndex].value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidTARGETPRICE.ClientID.ToString().Trim() + "').value = document.getElementById('" + hidTRANSCOST.ClientID.ToString() + "').value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidTARGETTYPE.ClientID.ToString().Trim() + "').value = LOBJ_Control.value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidINSUREERR.ClientID.ToString().Trim() + "').value = 'N';" + "\n";
        strSCRIPT += "}";
        RegisterScript(strSCRIPT);
        txtTRANSCOST.Text = hidTRANSCOST.Value.ToString();
        txtACTUSLLOANS.Text = hidTRANSCOST.Value.ToString();
    }

    //Modify 20130814 BY CHRIS FU Reason: 新增保險異常勾選時，保險費為0
    protected void txtNOINSURANCEFLG_CheckedChanged(object sender, EventArgs e)
    {
        if (txtNOINSURANCEFLG.Checked == true)
        {
            btINSURANCE.Enabled = false;
            txtINSURANCE.Text = "0";
        }
        else
        {
            btINSURANCE.Enabled = true;
        }
    }

    //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
    private bool CheckINSUREERR()
    {
        if (drpMAINTYPE.SelectedValue != hidMAINTYPE.Value ||
            drpSUBTYPE.SelectedValue != hidSUBTYPE.Value ||
            hidTRANSCOST.Value != hidTARGETPRICE.Value)
        {
            hidINSUREERR.Value = "Y";
            btINSURANCE_Click(new object(), EventArgs.Empty);
            return true;
        }

        if (rptMLDCASETARGET.Items.Count > 0)
        {
            if (hidTARGETTYPE.Value != ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.ToString())
            {
                hidINSUREERR.Value = "Y";
                btINSURANCE_Click(new object(), EventArgs.Empty);
                return true;
            }
        }

        return false;
    }
    protected void drpPRODCD_SelectedIndexChanged(object sender, EventArgs e)
    {
        MLDCASEAPPENDDOCBind();
        this.hidShowTag.Value = "fraTab22Caption";
        this.UpdatePanelMLDCASEAPPENDDOC.Update();
    }
    //20221031 設備系統改版 徵審資料變更
    private ReturnObject<DataSet> GetMLDCASEAPPENDDOCData(string TYPE)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            LSTR_StoreProcedure.Append("SP_ML1002_Q24" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "13" + GSTR_ColDelimitChar + TYPE + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

}
