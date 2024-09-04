/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3003  																					
* 程式功能  : 撥款核准(信管)																			
* 程式作者 	:																			
* 完成時間 	: 
* 修改事項 	: 
Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20120601 By SS Gordon. Reason: 撥款退回改為撥款撤件.
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120614 By SS Gordon. Reason: 加入「佣金」
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
Modify 20121205 By SS Gordon. Reason: 案件已核准時，案件退回不可點選
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
Modify 20131114 BY SS Leo Reason:增加擔保價值欄位
Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
Modify 20150204 By SS Vicky   Reason: 增加承作內容AR區塊
Modify 20150205 By SS Vicky   Reason: 案件內容,隱藏[建議墊息款],增加[建議墊款息]
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
20161125 ADD BY SS ADAM REASON.增加預撥沖銷
********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.Collections.Specialized;
using System.Globalization;
using System.Data;

using Itg.Community;
using Comus;

public partial class FrmML3003A : Itg.Community.PageBase
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
            MLMCASE_Data.Add("txtSYSDT", "A_SYSDT");
            MLMCASE_Data.Add("drpCOMPID", "COMPID");
            //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
            MLMCASE_Data.Add("drpSOURCETYPE", "SOURCETYPE");
            MLMCASE_Data.Add("drpMAINTYPE", "MAINTYPE");
            MLMCASE_Data.Add("drpSUBTYPE", "SUBTYPE");
            MLMCASE_Data.Add("drpTRANSTYPE", "TRANSTYPE");
            //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
            MLMCASE_Data.Add("drpBANKCD", "BANKCD");
            MLMCASE_Data.Add("drpUSESTATUS", "USESTATUS");
            MLMCASE_Data.Add("drpCYCLETYPE", "CYCLETYPE");
            MLMCASE_Data.Add("drpCASESOURCE", "CASESOURCE");
            MLMCASE_Data.Add("drpRCASESOURCE", "CASESOURCE");

            MLMCASE_Data.Add("drpPAYTPE", "PAYTPE");
            MLMCASE_Data.Add("drpRCUSTPAYTYPE", "PAYTPE");

            MLMCASE_Data.Add("txtPATDAYS", "PATDAYS");
            MLMCASE_Data.Add("txtRPATDAYS", "PATDAYS");

            MLMCASE_Data.Add("txtSUPPILERDAYS", "SUPPILERDAYS");
            MLMCASE_Data.Add("txtRSUPPILERDAYS", "SUPPILERDAYS");

            MLMCASE_Data.Add("txtIRR", "IRR");
            MLMCASE_Data.Add("txtRECOVERTEST", "RECOVERTEST");
            MLMCASE_Data.Add("txtCAPITALCOST", "CAPITALCOST");
            MLMCASE_Data.Add("txtNPV", "NPV");
            //Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            MLMCASE_Data.Add("txtNPVRATECOST", "NPVRATECOST");
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            MLMCASE_Data.Add("txtNPV2", "NPV2");
            MLMCASE_Data.Add("txtNPVRATECOST2", "NPVRATECOST2");
            MLMCASE_Data.Add("drpEXPIREPROC", "EXPIREPROC");
            MLMCASE_Data.Add("txtEXPIREPROCDESC", "EXPIREPROCDESC");
            MLMCASE_Data.Add("txtOTHERCOND", "OTHERCOND");
            MLMCASE_Data.Add("drpDEFECTIVE", "DEFECTIVE");
            //john.chen 2011/11/03 增加欄位
            MLMCASE_Data.Add("drpPRINTSTORE", "PRINTSTORE");
            //LeoLiao 20131114 增加欄位
            MLMCASE_Data.Add("drpGuanValue", "GUANVALUE");
            //UPD BY VICKY 20150205 補上建議墊款息
            MLMCASE_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");
            //20150310 ADD BY SS ADAM REASON.專案別顯示
            MLMCASE_Data.Add("drpPROJCD", "PROJCD");
            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            MLMCASE_Data.Add("drpPRODCD", "PRODCD");
            //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
            MLMCASE_Data.Add("txtNPV0", "NPV0");
            MLMCASE_Data.Add("txtNPVRATECOST0", "NPVRATECOST0");
            return MLMCASE_Data;
        }
    }
    private NameValueCollection NVC_MLMCONTRACT_Data
    {
        get
        {
            NameValueCollection MLMCONTRACT_Data = new NameValueCollection();
            MLMCONTRACT_Data.Add("txtCNTRNO", "CNTRNO");
            MLMCONTRACT_Data.Add("txtRTRANSCOST", "INVOICEAMOUNT");
            MLMCONTRACT_Data.Add("txtRFEE", "FEE");
            //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
            MLMCONTRACT_Data.Add("txtRCOMMISSION", "COMMISSION");
            MLMCONTRACT_Data.Add("txtROTHERFEES", "OTHERFEES");
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
            MLMCONTRACT_Data.Add("txtROTHERFEESNOTAX", "OTHERFEESNOTAX");
            MLMCONTRACT_Data.Add("txtRFIRSTPAY", "FIRSTPAY");
            MLMCONTRACT_Data.Add("txtRINSURANCE", "INSURANCE");
            MLMCONTRACT_Data.Add("txtRCREDITFEES", "CREDITFEES");
            MLMCONTRACT_Data.Add("txtRPERBOND", "PERBOND");
            MLMCONTRACT_Data.Add("txtRPURCHASEMARGIN", "PURCHASEMARGIN");
            MLMCONTRACT_Data.Add("txtRMANAGERFEES", "MANAGERFEES");
            MLMCONTRACT_Data.Add("txtRACTUSLLOANS", "ACTUSLLOANS");
            MLMCONTRACT_Data.Add("txtRRESIDUALS", "RESIDUALS");
            MLMCONTRACT_Data.Add("txtRFINANCIALFEES", "FINANCIALFEES");

            //MLMCONTRACT_Data.Add("txtDEPOSITLOANS", "DEPOSITLOANS");
            MLMCONTRACT_Data.Add("txtRDEPOSITLOANSAMOUNT", "DEPOSITLOANSAMOUNT");

            MLMCONTRACT_Data.Add("txtRCONTRACTMONTH", "CONTRACTMONTH");
            MLMCONTRACT_Data.Add("txtRPAYMONTH", "PAYMONTH");
            MLMCONTRACT_Data.Add("drpRPAYTIME", "PAYTIME");
            MLMCONTRACT_Data.Add("drpRCUSTPAYTYPE", "CUSTPAYTYPE");
            MLMCONTRACT_Data.Add("txtRPATDAYS", "PATDAYS");
            MLMCONTRACT_Data.Add("txtRSUPPILERDAYS", "SUPPILERDAYS");
            MLMCONTRACT_Data.Add("txtRINCOME", "INCOME");
            MLMCONTRACT_Data.Add("txtROPENINGCOST", "OPENINGCOST");
            MLMCONTRACT_Data.Add("txtRNETLOSS", "NETLOSS");
            MLMCONTRACT_Data.Add("txtPERBONDUSED", "PERBONDUSED");
            MLMCONTRACT_Data.Add("txtPURCHASEUSED", "PURCHASEUSED");
            MLMCONTRACT_Data.Add("txtPERBONDNOTE", "PERBONDNOTE");
            MLMCONTRACT_Data.Add("txtPURCHASENOTE", "PURCHASENOTE");
            MLMCONTRACT_Data.Add("txtFIRSTPAYUSED", "FIRSTPAYUSED");
            MLMCONTRACT_Data.Add("txtFIRSTPAYNOTE", "FIRSTPAYNOTE");
            MLMCONTRACT_Data.Add("txtPRENTSTDT", "PRENTSTDT");
            MLMCONTRACT_Data.Add("txtSALESPAY", "SALESPAY");

            MLMCONTRACT_Data.Add("txtSUPPLIERSALE", "SUPPLIERSALE");
            MLMCONTRACT_Data.Add("txtSUPPLIERSALENM", "SUPPLIERSALENM");


            MLMCONTRACT_Data.Add("txtRRFEE", "FEE");
            MLMCONTRACT_Data.Add("txtRRTRANSCOST", "INVOICEAMOUNT");
            MLMCONTRACT_Data.Add("txtRRFIRSTPAY", "FIRSTPAY");
            MLMCONTRACT_Data.Add("txtRRPERBOND", "PERBOND");
            MLMCONTRACT_Data.Add("txtRRPURCHASEMARGIN", "PURCHASEMARGIN");


            //MLMCONTRACT_Data.Add("txtPRENTENDT", "PRENTENDT");
            //MLMCONTRACT_Data.Add("txtRENTSTDT", "RENTSTDT");
            //MLMCONTRACT_Data.Add("txtRENTENDT", "RENTENDT");
            MLMCONTRACT_Data.Add("txtDISCOUNTTOTAL", "DISCOUNTTOTAL");
            MLMCONTRACT_Data.Add("txtDISCOUNTTAX", "DISCOUNTTAX");
            MLMCONTRACT_Data.Add("txtACTUALLYAMOUNT", "ACTUALLYAMOUNT");
            MLMCONTRACT_Data.Add("txtPAYDATE", "PAYDATE");

            MLMCONTRACT_Data.Add("txtCUSTFPAYDATE", "CUSTFPAYDATE");
            MLMCONTRACT_Data.Add("hidCASESTATUS", "CASESTATUS");
            MLMCONTRACT_Data.Add("txtRIRR", "IRR");
            MLMCONTRACT_Data.Add("txtRNPV", "NPV");
            //Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            MLMCONTRACT_Data.Add("txtRNPVRATECOST", "NPVRATECOST");
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            MLMCONTRACT_Data.Add("txtRNPV2", "NPV2");
            MLMCONTRACT_Data.Add("txtRNPVRATECOST2", "NPVRATECOST2");
            MLMCONTRACT_Data.Add("txtRCAPITALCOST", "CAPITALCOST");

            //LeoLiao 20131114 增加欄位
            MLMCONTRACT_Data.Add("drpGuanValue2", "GUANVALUE");

            //Modify 20150204 By SS VICKY. Reason: 「承作內容」，新增AR[總受讓金額][徵信費收入][預計撥款日][墊款息][帳務管理收入][執款成數][財務顧問收入]欄位
            MLMCONTRACT_Data.Add("txtINVOICEAMOUNT_AR", "INVOICEAMOUNT");
            MLMCONTRACT_Data.Add("txtCREDITFEES_AR", "CREDITFEES");
            MLMCONTRACT_Data.Add("txtPAYDATE_AR", "PAYDATE");
            MLMCONTRACT_Data.Add("txtADVANCESINTEREST_AR", "ADVANCESINTEREST");
            MLMCONTRACT_Data.Add("txtMANAGERFEES_AR", "MANAGERFEES");
            MLMCONTRACT_Data.Add("drpADVANCESPERCENT_AR", "ADVANCESPERCENT");
            MLMCONTRACT_Data.Add("txtFINANCIALFEES_AR", "FINANCIALFEES");

            //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
            MLMCONTRACT_Data.Add("txtFEEAMT", "PREPAYFEEAMT");
            MLMCONTRACT_Data.Add("txtPREPAYWOFFAMT", "PREPAYWOFFAMT");

            //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
            MLMCONTRACT_Data.Add("txtRNPV0", "NPV0");
            MLMCONTRACT_Data.Add("txtRNPVRATECOST0", "NPVRATECOST0");

            return MLMCONTRACT_Data;
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


            MLMCUSTOMER_Data.Add("drpCOMPTYPE", "COMPTYPE");
            MLMCUSTOMER_Data.Add("drpORGATYPE", "ORGATYPE");
            MLMCUSTOMER_Data.Add("drpLISTED", "LISTED");

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
            MLMCUSTOMER_Data.Add("txtINDUID", "INDUID");
            MLMCUSTOMER_Data.Add("txtINDUNM", "INDUNM");
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
            MLDCASEARDATA_Data.Add("txtRFINANCIALFEES", "FINANCIALFEES");
            MLDCASEARDATA_Data.Add("txtPERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("txtACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("drpPAYTIMEA", "PAYTIME");
            MLDCASEARDATA_Data.Add("drpRPAYTIME", "PAYTIME");
            MLDCASEARDATA_Data.Add("txtBUYERLIMIT", "BUYERLIMIT");
            MLDCASEARDATA_Data.Add("txtARIRR", "IRR");
            //Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
            MLDCASEARDATA_Data.Add("txtARPERBOND", "ARPERBOND");


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
            MLDCASEINST_Data.Add("txtFEE", "FEE");
            MLDCASEINST_Data.Add("txtCOMMISSION", "COMMISSION");
            MLDCASEINST_Data.Add("txtINSURANCE", "INSURANCE");
            MLDCASEINST_Data.Add("txtFIRSTPAY", "FIRSTPAY");
            MLDCASEINST_Data.Add("txtACTUSLLOANS", "ACTUSLLOANS");
            MLDCASEINST_Data.Add("txtOTHERFEES", "OTHERFEES");
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
            MLDCASEINST_Data.Add("txtOTHERFEESNOTAX", "OTHERFEESNOTAX");
            MLDCASEINST_Data.Add("txtPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN");
            MLDCASEINST_Data.Add("txtRESIDUALS", "RESIDUALS");
            MLDCASEINST_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");
            MLDCASEINST_Data.Add("txtPAYMONTH", "PAYMONTH");
            MLDCASEINST_Data.Add("drpPAYTIMET", "PAYTIME");
            MLDCASEINST_Data.Add("drpRPAYTIME", "PAYTIME");

            MLDCASEINST_Data.Add("txtRTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("txtRACTUSLLOANS", "ACTUSLLOANS");
            MLDCASEINST_Data.Add("txtRFEE", "FEE");
            MLDCASEINST_Data.Add("txtROTHERFEES", "OTHERFEES");
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
            MLDCASEINST_Data.Add("txtROTHERFEESNOTAX", "OTHERFEESNOTAX");

            MLDCASEINST_Data.Add("txtRFIRSTPAY", "FIRSTPAY");
            MLDCASEINST_Data.Add("txtRINSURANCE", "INSURANCE");
            MLDCASEINST_Data.Add("txtRPURCHASEMARGIN", "PURCHASEMARGIN");
            MLDCASEINST_Data.Add("txtRPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtRRESIDUALS", "RESIDUALS");

            MLDCASEINST_Data.Add("txtRCONTRACTMONTH", "CONTRACTMONTH");
            MLDCASEINST_Data.Add("txtRPAYMONTH", "PAYMONTH");


            MLDCASEINST_Data.Add("txtRRFEE", "FEE");
            MLDCASEINST_Data.Add("txtRRTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("txtRRFIRSTPAY", "FIRSTPAY");
            MLDCASEINST_Data.Add("txtRRPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtRRPURCHASEMARGIN", "PURCHASEMARGIN");


            return MLDCASEINST_Data;
        }
    }
    //案件申請租賃分期案件分期
    private NameValueCollection NVC_MLDCONTRACTAR_Data
    {
        get
        {
            NameValueCollection MLDCONTRACTAR_Data = new NameValueCollection();
            MLDCONTRACTAR_Data.Add("txtBILLNOTECUSTID", "BILLNOTECUSTID");
            MLDCONTRACTAR_Data.Add("txtBILLNOTECUST", "BILLNOTECUST");
            MLDCONTRACTAR_Data.Add("txtDEPOSITBANKS", "DEPOSITBANKS");
            MLDCONTRACTAR_Data.Add("txtDEPOSITBANK", "DEPOSITBANK");
            MLDCONTRACTAR_Data.Add("txtACCOUNT", "ACCOUNT");
            MLDCONTRACTAR_Data.Add("txtENDORSERID", "ENDORSERID");
            MLDCONTRACTAR_Data.Add("txtENDORSER", "ENDORSER");
            return MLDCONTRACTAR_Data;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款核准(信管)";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3003A";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3003A";
        //========================     

        if (!Page.IsPostBack)
        {
            FormDrpBind();
            string LSTR_CUSTID = Request.QueryString["custid"].ToString();
            string LSTR_CASEID = Request.QueryString["caseid"].ToString();
            string LSTR_CNTRNO = Request.QueryString["cntrno"].ToString();

            drpGuanValueBind(ref this.drpGuanValue);
            drpGuanValueBind(ref this.drpGuanValue2);
            PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);
            if (this.hidCASESTATUS.Value == "7")
            {
                //20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
                //this.btnSubmit.Enabled = true;
                this.btnSubmit.Enabled = false;
                this.btnRegect.Enabled = true;
                //Modify 20121205 By SS Gordon. Reason: 案件已核准時，案件退回不可點選
                this.btnReturn.Enabled = true;
                //RegisterScript("SetDisabled('divBody', '','" + btnSubmit.ClientID + "," + this.btnRegect.ClientID + ",Button1," + this.btnCond.ClientID + "," + this.hidCond.ClientID + "')");
            }
            else
            {
                this.btnSubmit.Enabled = true;
                this.btnRegect.Enabled = false;
                //Modify 20121205 By SS Gordon. Reason: 案件已核准時，案件退回不可點選
                this.btnReturn.Enabled = false;
                //RegisterScript("SetDisabled('divBody', '','Button1," + this.btnCond.ClientID + "," + this.hidCond.ClientID + "')");
            }

        }
    }
    private void PageDataBind(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
    {

        this.drpRECOURSE.Enabled = false;
        if (!string.IsNullOrEmpty(LSTR_CUSTID) && !string.IsNullOrEmpty(LSTR_CASEID) && !string.IsNullOrEmpty(LSTR_CONTID))
        {
            try
            {
                string LSTR_Con = Request.QueryString["con"].ToString();
                this.hidCond.Value = LSTR_Con;

                ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByID(LSTR_CUSTID, LSTR_CASEID, LSTR_CONTID);
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
                    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                    drpSUBTYPEBindbyID(LSTR_MAINTYPEID);
                    drpSUBTYPE.SelectedValue = LDST_Data.Tables[2].Rows[0]["SUBTYPE"].ToString().Trim();
                    if (LSTR_MAINTYPEID == "04")
                    {
                        rdoMLDCASEARDATA.Checked = true;
                        rdoMLDCASEINST.Checked = false;
                        //綁定應收帳款案件
                        GetMLDCASEARDATABind(LDST_Data.Tables[3]);
                    }
                    else
                    {
                        rdoMLDCASEARDATA.Checked = false;
                        rdoMLDCASEINST.Checked = true;
                        //綁定分期租賃案件
                        GetMLDCASEINSTBind(LDST_Data.Tables[4]);
                        GetMLDCASEINSTDBind(LDST_Data.Tables[5]);
                    }
                    //MLDCASEGUARANTEE保證人
                    GetMLDCASEGUARANTEEBind(LDST_Data.Tables[6]);
                    //動產設定
                    GetMLDCASEMOVABLEBind(LDST_Data.Tables[7]);
                    //不動產設定
                    GetMLDCASEIMMOVABLEBind(LDST_Data.Tables[8]);
                    //不定存單質押
                    GetMLDCASEADEPOSITBind(LDST_Data.Tables[9]);
                    //客票
                    GetMLDCASEBILLNOTEBind(LDST_Data.Tables[10]);
                    //股票
                    GetMLDCASESTOCKBind(LDST_Data.Tables[11]);
                    //標的物
                    GetMLDCASETARGETBind(LDST_Data.Tables[12]);
                    //承做內容
                    GetMLMCONTRACTBind(LDST_Data.Tables[13]);
                    //分期明細
                    GetMLDCONTRACTINSTBind(LDST_Data.Tables[14]);
                    //AR
                    GetMLDCONTRACTARBind(LDST_Data.Tables[15]);
                    //MLDCONTRACTINV
                    GetMLDCONTRACTINVBind(LDST_Data.Tables[16]);
                    //MLDCONTRACTINVD
                    GetMLDCONTRACTINVDBind(LDST_Data.Tables[17]);
                    this.txtBUSINESS.Width = 500;

                    //MLDCONTRACTARD  UPD BY VICKY 20150204
                    GetMLDCONTRACTARDBind(LDST_Data.Tables[18]);
                    //MLDCONTRACTARBINV  UPD BY VICKY 20150204
                    GetMLDCONTRACTARBINVBind(LDST_Data.Tables[19]);

                    drpRECOURSE.SelectedValue = LDST_Data.Tables[2].Rows[0]["RECOURSE"].ToString().Trim();

                    //UPD BY VICKY 20150203 區分AR件
                    if (drpMAINTYPE.SelectedValue == "04")
                    {
                        this.divMainTypeA.Attributes["style"] = "display:none";
                        this.divMainTypeB.Attributes["style"] = "display:block";

                        //20150330 ADD BY SS ADAM REASON.計算撥款金額
                        CalPAYAMOUNT_AR();
                    }
                    else
                    {
                        this.divMainTypeA.Attributes["style"] = "display:block";
                        this.divMainTypeB.Attributes["style"] = "display:none";
                    }

                    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
                    GetMLDASSPAYMFBind(LDST_Data.Tables[20]);
                    GetMLDFEEINCOME1Bind(LDST_Data.Tables[21]);
                    GetMLDFEEINCOME2Bind(LDST_Data.Tables[22]);
                    GetMLDPREPAYWOFFBind(LDST_Data.Tables[23]);

                    //20231130ADD選定專案
                    btnPROJECT_Click(null, null);
                    drpPROJECT.SelectedValue = LDST_Data.Tables[24].Rows[0]["PROJID"].ToString().Trim();

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
        //20231130新增專案下拉選單
        ReturnObject<DataSet> LOBJ_ReturnObject1 = GetPROJECTData();
        if (LOBJ_ReturnObject1 != null && LOBJ_ReturnObject1.ReturnSuccess)
        {
            DataSet LDST_Data = LOBJ_ReturnObject1.ReturnData;
            if (LDST_Data.Tables.Count > 0 && LDST_Data.Tables[0].Rows.Count > 0)
            {
                this.drpPROJECT.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpPROJECT.DataBind();
                this.drpPROJECT.Items.Insert(0, new ListItem("請選擇", "0"));
            }
            else
            {
                this.drpPROJECT.Items.Clear();
                this.drpPROJECT.Items.Insert(0, new ListItem("無", "0"));
                //Alert(LOBJ_ReturnObject1.ReturnMessage);
            }
        }
    }
    private ReturnObject<DataSet> GetPROJECTData()
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return = null;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //專案選單
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                LSTR_StoreProcedure.Append("SP_ML1002_Q25" + GSTR_RowDelimitChar);
                LSTR_QueryCondition.Append(" AND TARGETTYPE IN(''''0'''',''''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0] + "'''')" + GSTR_TabDelimitChar);
                LSTR_QueryCondition.Append(" AND SUPPLIERID IN('''''''',''''" + ((Label)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text + "'''')" + GSTR_TabDelimitChar);
                LSTR_QueryCondition.Append(" AND MAINTYPE IN('''''''',''''" + this.drpMAINTYPE.SelectedValue + "'''')" + GSTR_TabDelimitChar);
                LSTR_QueryCondition.Append(" AND PRODTYPE IN('''''''',''''" + ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue + "'''')" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
                LOBJ_Submit = new Comus.HtmlSubmitControl();
                LOBJ_Submit.VirtualPath = GetComusVirtualPath();
                LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
                LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
                LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    private void MLDCONTRACTINVDInit()
    {
        if (ViewState["MLDCONTRACTINVD"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCONTRACTINVD");
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTINVOICEID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTINVNUM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTAMOUNT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTTAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTAMOUNTTAX", System.Type.GetType("System.String")));
            ViewState["MLDCONTRACTINVD"] = LOBJ_Data;
        }
    }
    private void ChangeMLDCONTRACTINVDTyep(DataTable LOBJ_DataTemp)
    {
        MLDCONTRACTINVDInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINVD"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTINVD"] = LOBJ_Data;
    }
    private void GetMLDCONTRACTINVDBind(DataTable LOBJ_Data)
    {
        ChangeMLDCONTRACTINVDTyep(LOBJ_Data);
        MLDCONTRACTINVDBind();
    }
    private void GetMLDCONTRACTINVBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ChangeMLDCONTRACTINVTyep(LOBJ_Data);
            MLDCONTRACTINVBind();
        }
    }
    private void MLDCONTRACTINVBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINV"];
        this.rptMLDCONTRACTINV.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTINV.DataBind();

    }
    private void MLDCONTRACTINVDBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINVD"];
        this.rptMLDCONTRACTINVD.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTINVD.DataBind();
    }
    private void MLDCONTRACTINVInit()
    {
        if (ViewState["MLDCONTRACTINV"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCONTRACTINV");
            LOBJ_Data.Columns.Add(new DataColumn("BILLNOTEID", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUPPLIER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUPPLIERS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUPSEQ", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CERTIFICATENO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("INVDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PAYBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BANKNM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("COMPNM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("RV_NAME", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("RVACNT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("NOTAXAMOUNT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ANOUMTTAX", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("PERBONDUSED", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("HIREPURUSED", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FIRSTPAYUSED", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("INVSALESPAY", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ACTUALLYAMOUNT", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("PERBONDNOTE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PURCHASENOTE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FIRSTPAYNOTE", System.Type.GetType("System.String")));
            ViewState["MLDCONTRACTINV"] = LOBJ_Data;
        }
    }
    private void ChangeMLDCONTRACTINVTyep(DataTable LOBJ_DataTemp)
    {
        MLDCONTRACTINVInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINV"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTINV"] = LOBJ_Data;
    }
    private void GetMLDCONTRACTARBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCONTRACTAR_Data);
        }
    }
    private void GetMLDCONTRACTINSTBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count == 4)
        {
            this.txtRENDPAY1.Text = LOBJ_Data.Rows[0][3].ToString();
            this.txtRPRINCIPAL1.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0][4].ToString());
            this.txtRPRINCIPALTAX1.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0][5].ToString());

            this.txtRSTARTPAY2.Text = LOBJ_Data.Rows[1][2].ToString();
            this.txtRENDPAY2.Text = LOBJ_Data.Rows[1][3].ToString();
            this.txtRPRINCIPAL2.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[1][4].ToString());
            this.txtRPRINCIPALTAX2.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[1][5].ToString());

            this.txtRSTARTPAY3.Text = LOBJ_Data.Rows[2][2].ToString();
            this.txtRENDPAY3.Text = LOBJ_Data.Rows[2][3].ToString();
            this.txtRPRINCIPAL3.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[2][4].ToString());
            this.txtRPRINCIPALTAX3.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[2][5].ToString());

            this.txtRSTARTPAY4.Text = LOBJ_Data.Rows[3][2].ToString();
            this.txtRENDPAY4.Text = LOBJ_Data.Rows[3][3].ToString();
            this.txtRPRINCIPAL4.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[3][4].ToString());
            this.txtRPRINCIPALTAX4.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[3][5].ToString());
        }
    }
    private void GetMLMCONTRACTBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCONTRACT_Data);
            if (LOBJ_Data.Rows[0]["DEPOSITLOANS"].ToString().Trim() == "1")
            {
                if (Convert.ToDecimal(Itg.Community.Util.NumberToDb(LOBJ_Data.Rows[0]["DEPOSITLOANSAMOUNT"].ToString().Trim())) > 0)
                {
                    this.chkRDEPOSITLOANS0.Checked = true;
                    this.chkRDEPOSITLOANS1.Checked = false;
                }
                else
                {
                    this.chkRDEPOSITLOANS0.Checked = false;
                    this.chkRDEPOSITLOANS1.Checked = true;
                    this.txtRDEPOSITLOANSAMOUNT.Text = (-1 * Convert.ToDecimal(Itg.Community.Util.NumberToDb(LOBJ_Data.Rows[0]["DEPOSITLOANSAMOUNT"].ToString().Trim()))).ToString("#,##0");
                }
                this.chkRDEPOSITLOANS2.Checked = false;
                this.txtRDEPOSITLOANSAMOUNT.Enabled = true;
                this.txtDSUPPLIER.Enabled = true;
            }
            else
            {
                this.chkRDEPOSITLOANS0.Checked = false;
                this.chkRDEPOSITLOANS1.Checked = false;
                this.chkRDEPOSITLOANS2.Checked = true;
                this.txtRDEPOSITLOANSAMOUNT.Enabled = false;
                this.txtDSUPPLIER.Enabled = false;
            }
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
        }
    }
    private void GetMLDCASEARDATABind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCASEARDATA_Data);

        }
    }
    private void GetCaseBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCASE_Data);
            //---------------------
            this.HidEMPLID.Value = LOBJ_Data.Rows[0]["EMPLID"].ToString();
            this.HidDEPTID.Value = LOBJ_Data.Rows[0]["DEPTID"].ToString();

            this.txtRMAINTYPE.Text = this.drpMAINTYPE.SelectedItem.Text;
            this.txtRTRANSTYPE.Text = this.drpTRANSTYPE.SelectedItem.Text;
            this.txtRUSESTATUS.Text = this.drpUSESTATUS.SelectedItem.Text;

            //Modify by SS Vicky 201150204 區分AR件及非AR件的承作內容 START
            if (this.drpMAINTYPE.SelectedValue == "04")
            {
                divMainTypeA.Attributes["style"] = "display:none";
                divMainTypeB.Attributes["style"] = "display:block";
            }
            else
            {
                divMainTypeA.Attributes["style"] = "display:block";
                divMainTypeB.Attributes["style"] = "display:none";
            }
            //-----------------END--------------------------------------------


            if (rdoMLDCASEARDATA.Checked == true)
            {

            }
            else
            {
                this.txtRTRANSCOST.Text = this.txtTRANSCOST.Text;
                this.txtRFEE.Text = this.txtFEE.Text;
                //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
                this.txtRCOMMISSION.Text = txtCOMMISSION.Text;
                this.txtROTHERFEES.Text = "0";
                //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                this.txtROTHERFEESNOTAX.Text = "0";
                this.txtRFIRSTPAY.Text = this.txtFIRSTPAY.Text;
                this.txtRINSURANCE.Text = this.txtINSURANCE.Text;
                this.txtRCREDITFEES.Text = this.txtCREDITFEES.Text;
                this.txtRPERBOND.Text = this.txtPERBOND.Text;
                this.txtRPURCHASEMARGIN.Text = this.txtPURCHASEMARGIN.Text;

                //UPD BY VICKY 20150204 
                this.txtINVOICEAMOUNT_AR.Text = this.txtTRANSCOST.Text;  //總受讓金額
            }

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
    private void GetCustomerBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCUSTOMER_Data);
            //drpCUROUTBindbyID(this.drpCUROUT.SelectedValue);
            //this.drpCUROUTF.SelectedValue = LOBJ_Data.Rows[0]["CUROUTF"].ToString().Trim();
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
    //===============START
    private void MLDCASETARGETInit()
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
            LOBJ_Data.Columns.Add(new DataColumn("PROCEDEINV", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PROCEDEINVTAX", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTINV", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DISCOUNTINVTAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SALESPAY", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DURABLELIFE", System.Type.GetType("System.String")));

            //明細         
            LOBJ_Data.Columns.Add(new DataColumn("STOREDZIPCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOREDZIPCODES", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("STOREDADDR", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTNAME", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPTNAME", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTITLE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTEL", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTMPHONE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTFAX", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTEMAIL", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("CONTACTTELCODE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CONTACTFAXCODE", System.Type.GetType("System.String")));
            ViewState["MLDCASETARGET"] = LOBJ_Data;
        }
    }
    private void ChangeMLDCASETARGETTyep(DataTable LOBJ_DataTemp)
    {
        MLDCASETARGETInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCASETARGET"] = LOBJ_Data;
    }
    private void GetMLDCASETARGETBind(DataTable LOBJ_Data)
    {
        ChangeMLDCASETARGETTyep(LOBJ_Data);
        if (drpMAINTYPE.SelectedValue == "04")
        {
            this.chkAr1.Checked = true;
            this.chkAr2.Checked = true;
            //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
            this.chkBANK1.Checked = false;
        }
        else
        {
            this.chkAr1.Checked = false;
            this.chkAr2.Checked = false;
            //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
            this.chkBANK1.Checked = false;
            if (this.drpSOURCETYPE.SelectedValue == "02")
            {
                this.chkBANK1.Checked = true;
            }
            MLDCASETARGETBind();
        }

    }
    private void MLDCASETARGETBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        this.rptMLDCASETARGET.DataSource = LOBJ_Data;
        this.rptMLDCASETARGET.DataBind();

        this.rptMLDCASETARGETSTR.DataSource = LOBJ_Data;
        this.rptMLDCASETARGETSTR.DataBind();

        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetTARGETTYPEData();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                for (int i = 0; i < rptMLDCASETARGET.Items.Count; i++)
                {
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
    private void GetMLDCASESTOCKBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDCASESTOCK"] = LOBJ_Data;
            MLDCASESTOCKBind();
        }
        else
        {
            chkMLDCASESTOCK.Checked = true;
            rptMLDCASESTOCK.DataSource = LOBJ_Data;
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
    private void GetMLDCASEBILLNOTEBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDCASEBILLNOTE"] = LOBJ_Data;
            MLDCASEBILLNOTEBind();
        }
        else
        {
            chkMLDCASEBILLNOTE.Checked = true;
            rptMLDCASEBILLNOTE.DataSource = LOBJ_Data;
            rptMLDCASEBILLNOTE.DataBind();
        }
    }
    private void MLDCASEBILLNOTEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEBILLNOTE"];
        this.rptMLDCASEBILLNOTE.DataSource = LOBJ_Data;
        this.rptMLDCASEBILLNOTE.DataBind();

        // 20140127 Edit by Sean 修正客票無帶出票據種類問題
        for (int i = 0; i < rptMLDCASEBILLNOTE.Items.Count; i++)
        {
            DropDownList LOBJ_BILLNOTETYPE = (DropDownList)rptMLDCASEBILLNOTE.Items[i].FindControl("drpBILLNOTETYPE");
            LOBJ_BILLNOTETYPE.SelectedValue = LOBJ_Data.Rows[i]["BILLNOTETYPE"].ToString();
        }
    }
    private void GetMLDCASEADEPOSITBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDCASEADEPOSIT"] = LOBJ_Data;
            MLDCASEADEPOSITBind();
        }
        else
        {
            chkMLDCASEADEPOSIT.Checked = true;
            rptMLDCASEADEPOSIT.DataSource = LOBJ_Data;
            rptMLDCASEADEPOSIT.DataBind();
        }
    }
    private void MLDCASEADEPOSITBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASEADEPOSIT"];
        this.rptMLDCASEADEPOSIT.DataSource = LOBJ_Data;
        this.rptMLDCASEADEPOSIT.DataBind();

    }
    private void GetMLDCASEIMMOVABLEBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDCASEIMMOVABLE"] = LOBJ_Data;
            MLDCASEIMMOVABLEBind();
        }
        else
        {
            chkMLDCASEIMMOVABLE.Checked = true;
            rptMLDCASEIMMOVABLE.DataSource = LOBJ_Data;
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
        for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
        {
            DropDownList LOBJ_Drop = (DropDownList)rptMLDHUMANRIGHTS.Items[i].FindControl("drpMLDCASEIMMOVABLE");
            for (int j = 0; j < rptMLDHUMANRIGHTS.Items.Count; j++)
            {
                LOBJ_Drop.Items.Add(new ListItem((j + 1).ToString()));
            }
            LOBJ_Drop.SelectedIndex = i;
            LOBJ_Drop = null;
        }
    }
    private void GetMLDCASEMOVABLEBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDCASEMOVABLE"] = LOBJ_Data;
            MLDCASEMOVABLEBind();
        }
        else
        {
            chkMLDCASEMOVABLE.Checked = true;
            rptMLDCASEMOVABLE.DataSource = LOBJ_Data;
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
    private void GetMLDCASEGUARANTEEBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
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
        DataTable LDTA_Data = (DataTable)ViewState["MLDCASEGUARANTEE"];
        //Modify 20130726 By SS Gordon. Reason: 保證人中的本票金額，取消自動帶入實貸金額，改為原本輸入金額.
        //string LSTR_PayMoney;
        //if (rdoMLDCASEINST.Checked == true)
        //{
        //  LSTR_PayMoney = (Convert.ToDouble("0" + this.txtACTUSLLOANS.Text) * 1.2).ToString("0");
        //}
        //else
        //{
        //  LSTR_PayMoney = (Convert.ToDouble("0" + this.txtAPLIMIT.Text) * 1.2).ToString("0");
        //}

        //for (int i = 0; i < LDTA_Data.Rows.Count; i++)
        //{
        //  LDTA_Data.Rows[i]["GUARANTEEANOUNT"] = LSTR_PayMoney;
        //}

        this.rptMLDCASEGUARANTEE.DataSource = LDTA_Data;
        this.rptMLDCASEGUARANTEE.DataBind();

        //綁定下拉

        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetMLDCASEGUARANTEEDrpBind();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataTable LDST_GRTTYPEData = LOBJ_ReturnObject.ReturnData.Tables[0];
                DataTable LDST_GRTData = LOBJ_ReturnObject.ReturnData.Tables[1];
                //Modify 20120601 By SS Gordon. Reason:加入關係人與職業
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
                    //Modify 20120601 By SS Gordon. Reason:加入關係人與職業
                    DropDownList LOBJ_GRTSEX = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTSEX");
                    DropDownList LOBJ_GRTRELATION1 = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION1");
                    DropDownList LOBJ_GRTRELATION2 = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTRELATION2");
                    DropDownList LOBJ_GRTJOBCLS = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOBCLS");
                    DropDownList LOBJ_GRTJOB = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB");

                    LOBJ_Grttype.DataSource = LDST_GRTTYPEData;
                    LOBJ_Grttype.DataBind();

                    //Modify 20120601 By SS Gordon. Reason:加入關係人與職業
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
                        //LOBJ_GRTCODE.SelectedValue = LDTA_Data.Rows[i]["GRTNAME"].ToString();
                        //LOBJ_GRTNAME.SelectedValue = LDTA_Data.Rows[i]["GRTCODE"].ToString();

                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILL")).SelectedValue = LDTA_Data.Rows[i]["GUARANTEEBILL"].ToString();
                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGUARANTEEBILLTYPE")).SelectedValue = LDTA_Data.Rows[i]["GUARANTEEBILLTYPE"].ToString();
                        //Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
                        ((DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTJOB")).SelectedValue = LDTA_Data.Rows[i]["GRTJOB"].ToString();

                        //Modify 20120601 By SS Gordon. Reason:加入關係人與職業
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

                    }

                    LOBJ_Grttype = null;
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
    private ReturnObject<DataSet> GetMLDCASEGUARANTEEDrpBind()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        string LSTR_CUSTID = this.txtCUSTID.Text;
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "03" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML1001_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120601 By SS Gordon. Reason:加入關係人一查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "71" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120601 By SS Gordon. Reason:加入關係人二查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "72" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120601 By SS Gordon. Reason:加入職業主類別查詢
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "86" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120601 By SS Gordon. Reason:加入職業查詢
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
    //===============end
    private ReturnObject<DataSet> GetCaseDataByID(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
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
            LSTR_StoreProcedure.Append("SP_ML3001_Q11" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLDCONTRACTCONTACT.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
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

            //MLDCASETARGET標的物
            LSTR_StoreProcedure.Append("SP_ML3001_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //承做內容
            LSTR_StoreProcedure.Append("SP_ML3001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //撥款案件租賃分期明細檔MLDCONTRACTINST
            LSTR_StoreProcedure.Append("SP_ML3001_Q08" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //綁定AR信息
            LSTR_StoreProcedure.Append("SP_ML3001_Q07" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //MLDCONTRACTINV撥款案件發票明細檔
            LSTR_StoreProcedure.Append("SP_ML3001_Q09" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //MLDCONTRACTINVD撥款案件發票明細檔
            LSTR_StoreProcedure.Append("SP_ML3001_Q10" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND A.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //MLDCONTRACTARD撥款案件AR明細檔 Modify by SS Vicky 20150204
            LSTR_StoreProcedure.Append("SP_ML3001_Q12" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLDCONTRACTARD.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //MLDCONTRACTARD撥款案件AR明細檔 Modify by SS Vicky 20150204
            LSTR_StoreProcedure.Append("SP_ML3001_Q13" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLDCONTRACTARBINV.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
            LSTR_StoreProcedure.Append("SP_ML3001_Q14" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML3001_Q15" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar);
            LSTR_QueryCondition.Append("01" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML3001_Q15" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar);
            LSTR_QueryCondition.Append("02" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LSTR_StoreProcedure.Append("SP_ML3001_Q16" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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

                this.drpMAINTYPE.DataSource = LDST_Data.Tables[3].DefaultView;
                this.drpMAINTYPE.DataBind();

                this.drpTRANSTYPE.DataSource = LDST_Data.Tables[4].DefaultView;
                this.drpTRANSTYPE.DataBind();

                this.drpUSESTATUS.DataSource = LDST_Data.Tables[5].DefaultView;
                this.drpUSESTATUS.DataBind();

                this.drpCYCLETYPE.DataSource = LDST_Data.Tables[6].DefaultView;
                this.drpCYCLETYPE.DataBind();

                this.drpCASESOURCE.DataSource = LDST_Data.Tables[7].DefaultView;
                this.drpCASESOURCE.DataBind();

                this.drpRCASESOURCE.DataSource = LDST_Data.Tables[7].DefaultView;
                this.drpRCASESOURCE.DataBind();



                this.drpPAYTPE.DataSource = LDST_Data.Tables[8].DefaultView;
                this.drpPAYTPE.DataBind();

                this.drpRCUSTPAYTYPE.DataSource = LDST_Data.Tables[8].DefaultView;
                this.drpRCUSTPAYTYPE.DataBind();

                this.drpPAYTIMEA.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpPAYTIMEA.DataBind();

                this.drpRPAYTIME.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpRPAYTIME.DataBind();

                this.drpPAYTIMET.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpPAYTIMET.DataBind();

                this.drpEXPIREPROC.DataSource = LDST_Data.Tables[10].DefaultView;
                this.drpEXPIREPROC.DataBind();

                this.drpCOMPTYPE.DataSource = LDST_Data.Tables[11].DefaultView;
                this.drpCOMPTYPE.DataBind();

                this.drpORGATYPE.DataSource = LDST_Data.Tables[12].DefaultView;
                this.drpORGATYPE.DataBind();

                this.drpLISTED.DataSource = LDST_Data.Tables[13].DefaultView;
                this.drpLISTED.DataBind();

                //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
                this.drpSOURCETYPE.DataSource = LDST_Data.Tables[14].DefaultView;
                this.drpSOURCETYPE.DataBind();
                //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
                this.drpBANKCD.DataSource = LDST_Data.Tables[15].DefaultView;
                this.drpBANKCD.DataBind();
                this.drpBANKCD.Items.Insert(0, new ListItem("", ""));

                //Modify by SS Vicky 20150203 墊款成數
                this.drpADVANCESPERCENT_AR.DataSource = LDST_Data.Tables[16].DefaultView;
                this.drpADVANCESPERCENT_AR.DataBind();

                //20160323 ADD BY SS ADAM REASON.增加案件產品別
                this.drpPRODCD.DataSource = LDST_Data.Tables[17].DefaultView;
                this.drpPRODCD.DataBind();

                string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                drpSUBTYPEBindbyID(LSTR_MAINTYPEID);
                SetMAINTYPERDO(LSTR_MAINTYPEID);
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

            //案件來源
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "09" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //付款方式
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "10" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //付款時間
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "11" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //預計期滿處理方式
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //公司屬性drpCOMPTYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "26" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //組織形態drpORGATYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "02" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //上市櫃drpLISTED
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "27" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "89" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "90" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify by SS Vicky 20150204 墊款成數
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A8" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20160321 ADD BY SS ADAM REASON.新增案件產品別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "93" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
    private void drpSUBTYPEBindbyID(string LSTR_MAINTYPEID)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                //Modify 20120717 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」
                DataView LDVW = LDST_Data.Tables[0].DefaultView;
                if (this.drpSOURCETYPE.SelectedValue == "02")
                {
                    LDVW.RowFilter = "DCODE IN ('01','03')";
                }
                //this.drpSUBTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpSUBTYPE.DataSource = LDVW;
                this.drpSUBTYPE.DataBind();
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
    private void SetMAINTYPERDO(string LSTR_MAINTYPEID)
    {
        if (LSTR_MAINTYPEID == "04")
        {
            rdoMLDCASEARDATA.Checked = true;
            rdoMLDCASEINST.Checked = false;
        }
        else
        {
            rdoMLDCASEARDATA.Checked = false;
            rdoMLDCASEINST.Checked = true;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MLMCASESave("8");
    }
    protected void btnRegect_Click(object sender, EventArgs e)
    {
        string LSTR_FromAddress = "";
        string LSTR_ToAddress = "";
        string LSTR_CCAddress = "";
        string LSTR_Subject = "";
        string LSTR_BodyInfo = "";
        string LSTR_Attachment = "";
        LSTR_FromAddress += "設備租賃系統" + GSTR_ColDelimitChar;
        LSTR_FromAddress += "HFC@mail.hotaimotor.com.tw" + GSTR_ColDelimitChar;
        LSTR_FromAddress += GSTR_RowDelimitChar;

        ReturnObject<DataTable> LOBJ_Return;
        LOBJ_Return = GetEmailADDR(this.HidEMPLID.Value, this.HidDEPTID.Value);
        if (LOBJ_Return.ReturnSuccess)
        {
            DataTable LOBJ_Data = LOBJ_Return.ReturnData;
            for (int i = 0; i < LOBJ_Data.Rows.Count; i++)
            {
                if (LOBJ_Data.Rows[i]["EMAILTYPE"].ToString() == "1")
                {
                    LSTR_ToAddress += LOBJ_Data.Rows[i]["EMPLNM"].ToString() + GSTR_ColDelimitChar;
                    LSTR_ToAddress += LOBJ_Data.Rows[i]["EMAIL"].ToString() + GSTR_ColDelimitChar;
                    LSTR_ToAddress += GSTR_RowDelimitChar;
                }
                else if (LOBJ_Data.Rows[i]["EMAILTYPE"].ToString() == "2")
                {
                    LSTR_CCAddress += LOBJ_Data.Rows[i]["EMPLNM"].ToString() + GSTR_ColDelimitChar;
                    LSTR_CCAddress += LOBJ_Data.Rows[i]["EMAIL"].ToString() + GSTR_ColDelimitChar;
                    LSTR_CCAddress += GSTR_RowDelimitChar;
                }
            }
        }
        LSTR_Subject = "徵信撥款退件 [" + this.drpMAINTYPE.SelectedItem.Text + "-" + this.drpSUBTYPE.SelectedItem.Text + "] 合約編號：" + this.txtCNTRNO.Text;
        LSTR_BodyInfo = this.hidCond.Value.ToString().Replace("\r\n", "<br>");
        LSTR_Attachment = "";
        try
        {
            //Itg.Community.Mail.SendMail(LSTR_FromAddress, LSTR_ToAddress, LSTR_CCAddress, LSTR_Subject, LSTR_BodyInfo, LSTR_Attachment);
            Itg.Community.Mail.SendMailByDB(GetComusVirtualPath(), GSTR_U_PRGID, GSTR_U_USERID, LSTR_FromAddress, LSTR_ToAddress, LSTR_CCAddress, LSTR_Subject, LSTR_BodyInfo, LSTR_Attachment);
        }
        catch (System.Exception Exception)
        {
            Alert(Exception.Message);
        }
        MLMCASESave("8A");
    }
    protected void btnWj_Click(object sender, EventArgs e)
    {
        MLMCASESave("8B");
    }
    protected void btnCond_Click(object sender, EventArgs e)
    {
        MLMCASESave("8C");
    }

    //Modify 20120601 By SS Gordon. Reason: 新增案件退回.
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //退回ML3002所以CASESTATUS=6
        MLMCASERETURN("6");
    }
    //Modify 20120601 By SS Gordon. Reason: 新增案件退回.
    private void MLMCASERETURN(string LSTR_SaveType)
    {
        StringBuilder LSTR_Data = new StringBuilder();
        string LSTR_CNTRNOID = this.txtCNTRNO.Text;
        LSTR_Data.Append("SP_ML3003_U01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpGuanValue2.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================            
        LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append("2");
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        LSTR_Data.Append("ML3003A" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //========================================================================= 
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                RegisterScript("alert('案件退回完成！');window.close();");
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
        StringBuilder LSTR_Data = new StringBuilder();
        //案件主鍵
        string LSTR_CNTRNOID = this.txtCNTRNO.Text;
        LSTR_Data.Append("SP_ML3003_U01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpGuanValue2.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================            
        LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidCond.Value.ToString().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append("2");
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //========================================================================= 
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                if (LSTR_SaveType == "8")
                {
                    RegisterScript("alert('撥款核准成功！');window.close();");
                }
                else if (LSTR_SaveType == "8A")
                {
                    //Modify 20120601 By SS Gordon. Reason: 撥款退回改為撥款撤件.
                    //RegisterScript("alert('撥款退回成功！');window.close();");
                    RegisterScript("alert('撥款撤件成功！');window.close();");
                }
                else if (LSTR_SaveType == "8B")
                {
                    RegisterScript("alert('撥款婉拒成功！');window.close();");
                }
                else if (LSTR_SaveType == "8C")
                {
                    RegisterScript("alert('撥款附條件成功！');window.close();");
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
    private ReturnObject<object> UpdateContractInfo(string LSTR_Data)
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
    private ReturnObject<DataTable> GetEmailADDR(string LSTR_USERID, string LSTR_DEPTID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataTable> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML0003_Q04";
            LVAR_Parameter[1] = "'" + LSTR_USERID + "','" + LSTR_DEPTID + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    //Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
    protected void btnRecheck_Click(object sender, EventArgs e)
    {
        if (this.txtCNTRNO.Text == "" && this.txtCASEID.Text == "")
        {
            Alert("合約編號或申請書案號請至少擇一輸入");
            return;
        }

        StringBuilder LSTR_Data = new StringBuilder();
        string LSTR_CNTRNO = this.txtCNTRNO.Text;
        string LSTR_CASEID = this.txtCASEID.Text;
        string LSTR_PRINTKEY = System.DateTime.Now.ToString("yyyyMMdd") + GSTR_U_USERID;
        this.hdnPRINTKEY.Text = LSTR_PRINTKEY;
        this.SessUSERID.Text = GSTR_U_USERID;
        this.SessDEPTNM.Text = GSTR_DEPTNAME;
        //Alert(LSTR_CNTRNO + "','" + LSTR_CASEID + "','" + LSTR_PRINTKEY);

        LSTR_Data.Append("SP_ML3004_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_PRINTKEY + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data.Append("SP_ML3004_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_PRINTKEY + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //========================================================================= 
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                getDATES();
                //RegisterScript("cmdPRINT_Click(document.getElementById('" + this.cmdPRINT.ClientID + "'));");
                //RegisterScript("cmdPRINT_Click('" + this.btnRecheck.ClientID + "');");
                RegisterScript("cmdPRINT_Click('" + this.txtCNTRNO.Text + "',"
                                            + "'" + this.txtCASEID.Text + "',"
                                            + "'" + GSTR_U_USERID + "',"
                                            + "'" + GSTR_DEPTNAME + "',"
                                            + "'" + this.hdnPRINTKEY.Text + "',"
                                            + "'" + this.hdnINDT.Text + "',"
                                            + "'" + this.hdnTRADEDT.Text + "',"
                                            + "'" + this.hdnCREDITDT.Text + "'"
                                            + ");");
                //20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
                //if (this.hidCASESTATUS.Value == "7")
                //{
                this.btnSubmit.Enabled = true;
                //RegisterScript("window_onload();");
                //this.UpdatePanel1.Update();
                //}
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

    //Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
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

    //Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
    // 取得送信管徵審日、營業單位撥款放行日、信管單位撥款放行日日期
    private void getDATES()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string LSTR_CNTRNO = this.txtCNTRNO.Text;
        string LSTR_CASEID = this.txtCASEID.Text;

        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML3004_Q01";
            LVAR_Parameter[1] = "'" + LSTR_CNTRNO + "','" + LSTR_CASEID + "','" + GSTR_USERNM + "','" + GSTR_DEPTNAME + "','','','',''";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                DataTable LOBJ_Data = LOBJ_Return.ReturnData;
                this.hdnINDT.Text = LOBJ_Data.Rows[0]["INDT"].ToString().Replace("/", "").Trim();          //送信管徵審日
                this.hdnTRADEDT.Text = LOBJ_Data.Rows[0]["TRADEDT"].ToString().Replace("/", "").Trim();    //營業單位撥款放行日
                this.hdnCREDITDT.Text = LOBJ_Data.Rows[0]["CREDITDT"].ToString().Replace("/", "").Trim();  //信管單位撥款放行日
                                                                                                           //Alert(this.hdnINDT.Value + "，" + this.hdnTRADEDT.Value + "，" + this.hdnCREDITDT.Value);
            }
            else
            {
                Alert("查無資料");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Leo 2013/11/14  擔保價值下拉
    private void drpGuanValueBind(ref DropDownList GuanValue)
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;

        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML0001_Q02";
            LVAR_Parameter[1] = "'ML','92','T'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                GuanValue.DataSource = LOBJ_Return.ReturnData;
                GuanValue.DataValueField = "MCODE";
                GuanValue.DataTextField = "MNAME1";
                GuanValue.DataBind();
                GuanValue.Items[0].Text = "請選擇";
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region 撥款案件AR明細  Modify by SS Vicky 20150204

    private void MLDCONTRACTARDInit()
    {
        if (ViewState["MLDCONTRACTARD"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCONTRACTARD");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("PAYTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DRAWER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ACCOUNT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLNO", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("BUYER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLEXPIRYDT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ADVANCESDAYS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("BILLAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ADVANCESPERCENT", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("ADVANCESAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FINANCIALFEES", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FINALPAYAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ENDORSEMENTFLG", System.Type.GetType("System.String")));

            ViewState["MLDCONTRACTARD"] = LOBJ_Data;
        }
    }


    private void GetMLDCONTRACTARDBind(DataTable LOBJ_Data)
    {
        ChangeMLDCONTRACTARDTyep(LOBJ_Data);
        MLDCONTRACTARDBind();
    }

    private void ChangeMLDCONTRACTARDTyep(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCONTRACTARD"] = null;
        MLDCONTRACTARDInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARD"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTARD"] = LOBJ_Data;
    }

    private void MLDCONTRACTARDBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARD"];
        this.rptMLDCONTRACTARD.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTARD.DataBind();

        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetMLDCONTRACTARDData();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
                {
                    //形式
                    DropDownList LOBJ_DrpPAYTYPE = ((DropDownList)rptMLDCONTRACTARD.Items[i].FindControl("drpPAYTYPE_AR"));
                    LOBJ_DrpPAYTYPE.DataSource = LDST_Data.Tables[0];
                    LOBJ_DrpPAYTYPE.DataBind();

                    string LSTR_PAYTYPE = LOBJ_Data.Rows[i]["PAYTYPE"].ToString();
                    if (LSTR_PAYTYPE != "")
                    {
                        LOBJ_DrpPAYTYPE.SelectedValue = LSTR_PAYTYPE;
                    }

                    CheckBox LOBJ_ChkENDORSEMENTFLG = ((CheckBox)rptMLDCONTRACTARD.Items[i].FindControl("chkENDORSEMENTFLG"));
                    HiddenField LOBJ_HidENDORSEMENTFLG = ((HiddenField)rptMLDCONTRACTARD.Items[i].FindControl("hidENDORSEMENTFLG"));
                    if (LOBJ_HidENDORSEMENTFLG.Value == "Y")
                    {
                        LOBJ_ChkENDORSEMENTFLG.Checked = true;
                    }
                    else
                    {
                        LOBJ_ChkENDORSEMENTFLG.Checked = false;
                    }

                    ((Label)rptMLDCONTRACTARD.Items[i].FindControl("labADVANCESPERCENT_AR")).Text = drpADVANCESPERCENT_AR.SelectedValue + "%";
                    ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESPERCENT_AR")).Text = drpADVANCESPERCENT_AR.SelectedValue + "%";
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

        //this.UpdatePanelMLDCONTRACTARD.Update();
    }

    private ReturnObject<DataSet> GetMLDCONTRACTARDData()
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

            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A9" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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

    #endregion

    #region 買受發票明細GRID Modify by SS Vicky 20150204

    private void MLDCONTRACTARBINVInit()
    {
        if (ViewState["MLDCONTRACTARBINV"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCONTRACTARBINV");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("BUYER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("UNIMNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("INVNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("INVDT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("INVAMT", System.Type.GetType("System.String")));

            ViewState["MLDCONTRACTARBINV"] = LOBJ_Data;
        }
    }

    private void GetMLDCONTRACTARBINVBind(DataTable LOBJ_Data)
    {
        ChangeMLDCONTRACTARBINVTyep(LOBJ_Data);
        MLDCONTRACTARBINVBind();
    }

    private void ChangeMLDCONTRACTARBINVTyep(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCONTRACTARBINV"] = null;
        MLDCONTRACTARBINVInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARBINV"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTARBINV"] = LOBJ_Data;
    }

    private void MLDCONTRACTARBINVBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARBINV"];

        this.rptMLDCONTRACTARBINV.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTARBINV.DataBind();

        //this.UpdatePanelMLDCONTRACTARBINV.Update();
    }
    //20150326 ADD BY SS ADAM REASON.計算總撥款金額FOR AR
    private void CalPAYAMOUNT_AR()
    {
        Decimal LDBL_PAYAMOUNT_AR = 0;

        int LSTR_RowCount = this.rptMLDCONTRACTARD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_PAYAMOUNT_AR += (Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Replace(",", "")))
                                - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Replace(",", "")))
                                - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text.Replace(",", ""))));
        }

        this.txtPAYAMT_AR.Text = LDBL_PAYAMOUNT_AR.ToString("#,##0");
        //this.UpdatePanelContract_AR.Update();
        //this.UpdatePanelMLDCONTRACTARD.Update();
    }
    #endregion

    #region 20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void GetMLDASSPAYMFBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDASSPAYMF"] = LOBJ_Data;
            MLDASSPAYMFBind();
        }
        else
        {
            rptMLDASSPAYMF.DataSource = LOBJ_Data;
            rptMLDASSPAYMF.DataBind();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void MLDASSPAYMFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDASSPAYMF"];
        this.rptMLDASSPAYMF.DataSource = LOBJ_Data;
        this.rptMLDASSPAYMF.DataBind();
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void GetMLDFEEINCOME1Bind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDFEEINCOME1"] = LOBJ_Data;
            MLDFEEINCOME1Bind();
        }
        else
        {
            rptMLDFEEINCOME1.DataSource = LOBJ_Data;
            rptMLDFEEINCOME1.DataBind();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void MLDFEEINCOME1Bind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME1"];
        this.rptMLDFEEINCOME1.DataSource = LOBJ_Data;
        this.rptMLDFEEINCOME1.DataBind();

        for (int i = 0; i < rptMLDFEEINCOME1.Items.Count; i++)
        {
            ((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpCUSTTYPE")).SelectedValue = LOBJ_Data.Rows[i]["CUSTTYPE"].ToString();
            ((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpPAYTYPE")).SelectedValue = LOBJ_Data.Rows[i]["PAYTYPE"].ToString();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void GetMLDFEEINCOME2Bind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDFEEINCOME2"] = LOBJ_Data;
            MLDFEEINCOME2Bind();
        }
        else
        {
            rptMLDFEEINCOME2.DataSource = LOBJ_Data;
            rptMLDFEEINCOME2.DataBind();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void MLDFEEINCOME2Bind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME2"];
        this.rptMLDFEEINCOME2.DataSource = LOBJ_Data;
        this.rptMLDFEEINCOME2.DataBind();

        for (int i = 0; i < rptMLDFEEINCOME2.Items.Count; i++)
        {
            ((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpCUSTTYPE")).SelectedValue = LOBJ_Data.Rows[i]["CUSTTYPE"].ToString();
            ((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpPAYTYPE")).SelectedValue = LOBJ_Data.Rows[i]["PAYTYPE"].ToString();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void GetMLDPREPAYWOFFBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDPREPAYWOFF"] = LOBJ_Data;
            MLDPREPAYWOFFBind();
        }
        else
        {
            rptMLDPREPAYWOFF.DataSource = LOBJ_Data;
            rptMLDPREPAYWOFF.DataBind();
        }
    }
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void MLDPREPAYWOFFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDPREPAYWOFF"];
        this.rptMLDPREPAYWOFF.DataSource = LOBJ_Data;
        this.rptMLDPREPAYWOFF.DataBind();
    }
    #endregion
}
