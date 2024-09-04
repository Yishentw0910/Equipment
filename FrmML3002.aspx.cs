/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3002																					
* 程式功能  : 撥款申請維護											
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法.
Modify 20120313 By SS Steven. Reason: 新增SP儲存發票聯絡人及案件聯絡人資訊
Modify 20120516 By SS Steven. Reason: 撥款確認所帶的值會有>7的情況(8:不用徵信核准)
Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，撥差金額計算公式中，由NPV成本計算改成資金成本計算.
Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，AR案件中，標的物金額改成含稅.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120606 By SS Gordon. Reason: 於撥款維護的「承作內容」，新增「變更緣由」、「相關附件」欄位
Modify 20120614 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法，AR案件中，標的物金額改成含稅.
Modify 20120614 By SS Gordon. Reason: 加入「佣金」
Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;新增手續費.
Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;手續費調整為未稅.
Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;加入佣金計算.
Modify 20120615 By SS Gordon. Reason: 新增AR案件的IRR計算，與原本IRR計算分開
Modify 20120618 By SS Gordon. Reason: 新增AR案件的NPV計算，與原本NPV計算分開
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」
Modify 20120717 By SS Gordon. Reason: 修改承作方式為銀行件時，標的物不可維護
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
Modify 20120717 By SS Gordon. Reason: 修改當案件為銀行件時，進項發票的憑證號碼與發票日期可以為空白.
Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕
Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
Modify 20121115 By SS Gordon. Reason: 將保證人為醫生的代碼由01改成27
20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
Modify 20121122 By SS Steven. Reason: 擔保條件的動產資料欄位檢核
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
Modify 20130103 By Sean Reason: 新增一般租賃處/台北營二
Modify 20130114 By Sean Reason: 營租/AR件，即不檢核第一段期付款輸入需大於 0
Modify 20130326 By SS Eric    Reason:新增保險異常欄
Modify 20130402 By SS Vicky. Reason: 在標的物的頁籤中，是事務機跟營建機具，則保險費(保險異常未勾選時)要必填
Modify 20130411 By SS Gordon. Reason: 新增CR部門儲存
Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
Modify 20130528 BY    SEAN.   Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」
20130703 UPD BY BRENT Reason.取消原本資料被叫出後會自動增加1.2倍 
20130703 UPD BY BRENT Reason.取消原本資租(02)不能填寫多段式租金的設定
20130709 UPD BY BRENT Reason.攤提表展開時增加反推IRR邏輯
Modify 20130726 By SS Gordon. Reason: 保證人中的本票金額，取消自動帶入實貸金額，改為原本輸入金額.
Modify 20130726 By SS Gordon. Reason: IRR_Cal_ForPPMT()計算IRR時，加入TRY..CATCH判斷，若發生例外錯誤，則IRR傳回0
Modify 20130726 By    Sean    Reason: 資租現流表改寫在資租攤還表之後
20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
20130925 ADD BY VICKY Reason.改為用[受讓/發票金額]
20131001 ADD BY ADAM Reason.營資租與營建機具才可以做保險費的錯誤判斷
Modify 20131002 By SS Steven. Reason: 需判斷PRGID是否為ML3001A，如果是的話，頁籤承作內容改為預計承作內容，頁籤撥款資料改為預計撥款資料。
Modify 20131002 By SS Steven. Reason: 承上，預計撥款資料只需顯示案件起租日，客戶首期繳納日，預計撥款日，其餘一律隱藏。
Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
Modify 20131002 By SS Steven. Reason: 區分PRGID為ML3001A以及ML3002的處理流程，最下方的按鈕，在PRGID為ML3001A以及ML3002則有對應的顯示方式
Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                                      2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                                      3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
Modify 20131002 By SS Steven. Reason: 確認=暫存功能+業代確認為Y
                                      返回合約修改維護=暫存功能+業代確認為N
Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)
20131125 ADD BY SS ADAM Reason.修正3001A修改造成新增資料的問題
//20131129 ADD BY SS ADAM Reason.修正IRR計算產生的錯誤，主要是第零期的現金流量是負值造成的錯誤
Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印
Modify 20131210 BY SEAN Reason:1.修正不動產項次取號問題
                               2.PRGID若是ML3001A則可開放修改動產設定金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
20141014 ADD BY SS ADAM REASON.調整邏輯，3001A確認增加重新計算IRR NPV
Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
Modify 20150122 By SS Vicky   Reason: 增加承作內容AR區塊
Modify 20150205 By SS Vicky   Reason: 案件內容,隱藏[建議墊息款],增加[建議墊款息]
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
20160808 ADD BY SEAN 新增「付款差異天數」及「付供應商天數」檢核
Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
20161125 ADD BY SS ADAM REASON.增加預撥沖銷
20221031 行業別改下拉選單
20221031 合約期付款日期維護新增驗證
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
using System.IO;
using Microsoft.Office.Interop;
using System.Collections;

using Itg.Community;
using Comus;

public partial class FrmML3002 : Itg.Community.PageBase
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
            MLMCASE_Data.Add("hidDEPTID", "DEPTID");
            MLMCASE_Data.Add("hidEMPLID", "EMPLID");
            MLMCASE_Data.Add("drpCOMPID", "COMPID");
            //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
            MLMCASE_Data.Add("drpSOURCETYPE", "SOURCETYPE");
            MLMCASE_Data.Add("drpMAINTYPE", "MAINTYPE");
            //MLMCASE_Data.Add("drpSUBTYPE", "SUBTYPE");
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

            //Modify 20161130 By SEAN Reason: 新增NPV0與NPV利率成本0
            MLMCASE_Data.Add("txtNPV0", "NPV0");
            MLMCASE_Data.Add("txtNPVRATECOST0", "NPVRATECOST0");

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
            //      MLMCASE_Data.Add("hdnCASESTATUS", "CASESTATUS");
            //john.chen 2011/11/03 增加欄位
            MLMCASE_Data.Add("drpPRINTSTORE", "PRINTSTORE");
            //UPD BY VICKY 20150205 補上建議墊款息
            MLMCASE_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");

            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            MLMCASE_Data.Add("drpPRODCD", "PRODCD");

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
            MLMCONTRACT_Data.Add("hidRACTUSLLOANS", "ACTUSLLOANS");
            MLMCONTRACT_Data.Add("txtRRESIDUALS", "RESIDUALS");
            MLMCONTRACT_Data.Add("txtRFINANCIALFEES", "FINANCIALFEES");

            MLMCONTRACT_Data.Add("txtDEPOSITLOANSAMOUNT", "DEPOSITLOANSAMOUNT");

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
            MLMCONTRACT_Data.Add("txtSALESPAY", "SALESPAY");

            MLMCONTRACT_Data.Add("txtRRFEE", "FEE");
            MLMCONTRACT_Data.Add("txtRRTRANSCOST", "INVOICEAMOUNT");
            MLMCONTRACT_Data.Add("txtRRFIRSTPAY", "FIRSTPAY");
            MLMCONTRACT_Data.Add("txtRRPERBOND", "PERBOND");
            MLMCONTRACT_Data.Add("txtRRPURCHASEMARGIN", "PURCHASEMARGIN");

            MLMCONTRACT_Data.Add("txtPRENTSTDT", "PRENTSTDT");
            MLMCONTRACT_Data.Add("txtDISCOUNTTOTAL", "DISCOUNTTOTAL");
            MLMCONTRACT_Data.Add("txtDISCOUNTTAX", "DISCOUNTTAX");
            MLMCONTRACT_Data.Add("txtACTUALLYAMOUNT", "ACTUALLYAMOUNT");
            MLMCONTRACT_Data.Add("txtPAYDATE", "PAYDATE");
            MLMCONTRACT_Data.Add("txtCUSTFPAYDATE", "CUSTFPAYDATE");

            MLMCONTRACT_Data.Add("txtDSUPPLIER", "DSUPPLIER");
            MLMCONTRACT_Data.Add("txtSUPPLIERSALE", "SUPPLIERSALE");
            MLMCONTRACT_Data.Add("txtSUPPLIERSALENM", "SUPPLIERSALENM");
            MLMCONTRACT_Data.Add("hdnCASESTATUS", "CASESTATUS");

            MLMCONTRACT_Data.Add("txtRRECOVERTEST", "RECOVERTEST");
            MLMCONTRACT_Data.Add("txtRCAPITALCOST", "CAPITALCOST");
            MLMCONTRACT_Data.Add("txtRIRR", "IRR");

            //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
            MLMCONTRACT_Data.Add("txtRNPV0", "NPV0");
            MLMCONTRACT_Data.Add("txtRNPVRATECOST0", "NPVRATECOST0");

            MLMCONTRACT_Data.Add("txtRNPV", "NPV");
            //Modify 20120223 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            MLMCONTRACT_Data.Add("txtRNPVRATECOST", "NPVRATECOST");
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            MLMCONTRACT_Data.Add("txtRNPV2", "NPV2");
            MLMCONTRACT_Data.Add("txtRNPVRATECOST2", "NPVRATECOST2");
            //Modify 20120606 By SS Gordon. Reason: 於撥款維護的「承作內容」，新增「變更緣由」、「相關附件」欄位
            MLMCONTRACT_Data.Add("txtCHANGREASON", "CHANGREASON");
            MLMCONTRACT_Data.Add("txtRELATTACHMENT", "RELATTACHMENT");
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄
            MLMCONTRACT_Data.Add("txtRNOINSURANCEFLG", "NOINSURANCEFLG");

            //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
            MLMCONTRACT_Data.Add("txtSALESFLG", "SALESFLG");

            //Modify 20150122 By SS VICKY. Reason: 「承作內容」，新增AR[總受讓金額][徵信費收入][預計撥款日][墊款息][帳務管理收入][執款成數][財務顧問收入]欄位
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
            MLDCASEARDATA_Data.Add("txtRFINANCIALFEES", "FINANCIALFEES");
            MLDCASEARDATA_Data.Add("txtPERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("txtACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("drpPAYTIMEA", "PAYTIME");
            //MLDCASEARDATA_Data.Add("drpRPAYTIME", "PAYTIME");
            MLDCASEARDATA_Data.Add("txtBUYERLIMIT", "BUYERLIMIT");
            MLDCASEARDATA_Data.Add("txtARIRR", "IRR");
            //MLDCASEARDATA_Data.Add("txtINTERSET", "INTERSET");
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
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            MLDCASEINST_Data.Add("txtNOINSURANCEFLG", "NOINSURANCEFLG");
            MLDCASEINST_Data.Add("txtPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN");
            MLDCASEINST_Data.Add("txtRESIDUALS", "RESIDUALS");
            MLDCASEINST_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");
            MLDCASEINST_Data.Add("txtPAYMONTH", "PAYMONTH");
            MLDCASEINST_Data.Add("drpPAYTIMET", "PAYTIME");
            //MLDCASEINST_Data.Add("drpRPAYTIME", "PAYTIME");

            MLDCASEINST_Data.Add("txtRTRANSCOST", "TRANSCOST");
            MLDCASEINST_Data.Add("txtRACTUSLLOANS", "ACTUSLLOANS");
            MLDCASEINST_Data.Add("txtRFEE", "FEE");
            //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
            MLDCASEINST_Data.Add("txtRCOMMISSION", "COMMISSION");
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
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            MLDCASEINST_Data.Add("txtRNOINSURANCEFLG", "NOINSURANCEFLG");
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
        if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款申請維護";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3002";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3002";
        //========================             
        if (!Page.IsPostBack)
        {
            Session["Maintain"] = "";
            FormDrpBind();
            CheckRule();
            RegisterScript("SetDisabled('div_Info', '','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSelect.ClientID + "');");
        }
        else
        {
            this.txtRACTUSLLOANS.Text = Itg.Community.Util.NumberFormat(this.hidRACTUSLLOANS.Value);
            for (int i = 0; i < rptMLDCONTRACTINV.Items.Count; i++)
            {
                if (((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value != "")
                {
                    GetACCOMFRV(rptMLDCONTRACTINV.Items[i], ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value);
                }
            }

            //UPD BY VICKY 20150127 避免LABEL值跑掉, 再塞入一次
            for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
            {
                ((Label)rptMLDCONTRACTARD.Items[0].FindControl("labADVANCESDAYS_AR")).Text = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtADVANCESDAYS_AR")).Text;
                ((Label)rptMLDCONTRACTARD.Items[0].FindControl("labADVANCESPERCENT_AR")).Text = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtADVANCESPERCENT_AR")).Text;
                ((Label)rptMLDCONTRACTARD.Items[0].FindControl("labADVANCESAMT_AR")).Text = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtADVANCESAMT_AR")).Text;
                ((Label)rptMLDCONTRACTARD.Items[0].FindControl("labFINANCIALFEES_AR")).Text = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtFINANCIALFEES_AR")).Text;
                ((Label)rptMLDCONTRACTARD.Items[0].FindControl("labFINALPAYAMT_AR")).Text = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtFINALPAYAMT_AR")).Text;
            }
        }
        PageInitProcess();
        SetReportScript();
        //Modify 20131002 By SS Steven. Reason: 需判斷PRGID是否為ML3001A，如果是的話，頁籤承作內容改為預計承作內容，頁籤撥款資料改為預計撥款資料。
        //Modify 20131002 By SS Steven. Reason: 區分PRGID為ML3001A以及ML3002的處理流程，最下方的按鈕，在PRGID為ML3001A以及ML3002則有對應的顯示方式
        //GSTR_A_PRGID = "ML3001A";
        txtPRGID.Text = GSTR_A_PRGID;
        if (GSTR_A_PRGID == "LE3001A")
        {

            lblTab33.Text = "預計承作內容";
            lblTab66.Text = "預計撥款資料";

            div_APPRO.Style.Add("display", "none");
            trMONEY1.Style.Add("display", "none");
            trMONEY2.Style.Add("display", "none");
            trMONEY3.Style.Add("display", "none");

            btnListPrint.Style.Add("display", "none");
            btnSubmit.Style.Add("display", "none");
            btnSaveModify.Style.Add("display", "none");
            btnChangePrint.Style.Add("display", "none");
            btnRecheck.Style.Add("display", "none");
            btnBackModify.Style.Add("display", "none");

            //20230213按下確認鈕新增提示
            //this.btnSURE.Attributes.Add("onclick", "event.returnValue=confirm('尚未確定起租日，請使用「暫存」，確認後將無法調整起租日，是否確認？');");
        }
        else
        {
            btnInsert.Style.Add("display", "none");
            btnContractPrint.Style.Add("display", "none");
            btnRej.Style.Add("display", "none");
            btnSURE.Style.Add("display", "none");
            btnPayDate.Style.Add("display", "none");
            btnInsert.Style.Add("display", "none");
            //20240303 LE3001A機號改可編輯(到這時才知道機號為何)
        }
    }
    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtDISCOUNTTOTAL.Attributes.Add("ReadOnly", "true");
        this.txtDISCOUNTTAX.Attributes.Add("ReadOnly", "true");
        this.txtACTUALLYAMOUNT.Attributes.Add("ReadOnly", "true");
        //20150317 ADD BY SS ADAM REASON.調整為可以自行輸入總受讓金額
        //this.txtINVOICEAMOUNT_AR.Attributes.Add("ReadOnly", "true");  //UPD BY VICKY 20150128

        this.btnSaveModify.Attributes.Add("onclick", "javascipt:return btnSaveModify_Click(this)");

        //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
        this.drpRECOURSE.Enabled = false;

        this.txtDEPOSITLOANSAMOUNT.Enabled = false;
        this.chkRDEPOSITLOANS0.Enabled = false;
        this.chkRDEPOSITLOANS1.Enabled = false;
        this.chkRDEPOSITLOANS2.Enabled = false;
        this.txtSUPPLIERSALE.Enabled = false;
        this.txtSUPPLIERSALENM.Enabled = false;
        this.txtDSUPPLIER.Enabled = false;
        this.txtDSUPPLIERNM.Enabled = false;
    }
    private void CheckRule()
    {
        //列舉所有需要驗證的欄位

        string LSTR_CASE = txtCASEID.ClientID;
        string LSTR_RTRANSCOST = txtRTRANSCOST.ClientID;
        string LSTR_RFEE = txtRFEE.ClientID;
        //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
        string LSTR_RCOMMISSION = txtRCOMMISSION.ClientID;
        string LSTR_ROTHERFEES = txtROTHERFEES.ClientID;
        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
        string LSTR_ROTHERFEESNOTAX = txtROTHERFEESNOTAX.ClientID;
        string LSTR_RFIRSTPAY = txtRFIRSTPAY.ClientID;
        string LSTR_RINSURANCE = txtRINSURANCE.ClientID;

        string LSTR_RCREDITFEES = txtRCREDITFEES.ClientID;
        string LSTR_RPERBOND = txtRPERBOND.ClientID;
        string LSTR_RPURCHASEMARGIN = txtRPURCHASEMARGIN.ClientID;
        string LSTR_RMANAGERFEES = txtRMANAGERFEES.ClientID;
        string LSTR_RACTUSLLOANS = txtRACTUSLLOANS.ClientID;

        string LSTR_RRESIDUALS = txtRRESIDUALS.ClientID;
        string LSTR_RFINANCIALFEES = txtRFINANCIALFEES.ClientID;
        string LSTR_RCONTRACTMONTH = txtRCONTRACTMONTH.ClientID;
        string LSTR_RPAYMONTH = txtRPAYMONTH.ClientID;
        string LSTR_RENDPAY1 = txtRENDPAY1.ClientID;

        string LSTR_RPRINCIPAL1 = txtRPRINCIPAL1.ClientID;
        string LSTR_RPRINCIPALTAX1 = txtRPRINCIPALTAX1.ClientID;

        //UPD BY VICKY 20150126 加入AR件區塊
        string LSTR_INVOICEAMOUNT_AR = txtINVOICEAMOUNT_AR.ClientID;
        string LSTR_CREDITFEES_AR = txtCREDITFEES_AR.ClientID;
        string LSTR_PAYDATE_AR = txtPAYDATE_AR.ClientID;
        string LSTR_ADVANCESINTEREST_AR = txtADVANCESINTEREST_AR.ClientID;
        string LSTR_MANAGERFEES_AR = txtMANAGERFEES_AR.ClientID;
        string LSTR_FINANCIALFEES_AR = txtFINANCIALFEES_AR.ClientID;


        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
        //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
        string Fields = LSTR_CASE + ";" + LSTR_RTRANSCOST + ";" + LSTR_RFEE + ";" + LSTR_ROTHERFEES + ";" + LSTR_ROTHERFEESNOTAX + ";" + LSTR_RFIRSTPAY + ";" + LSTR_RINSURANCE + ";" +
                         LSTR_RCREDITFEES + ";" + LSTR_RPERBOND + ";" + LSTR_RPURCHASEMARGIN + ";" + LSTR_RMANAGERFEES + ";" + LSTR_RACTUSLLOANS + ";" + LSTR_ROTHERFEESNOTAX + ";" +
                         LSTR_RRESIDUALS + ";" + LSTR_RFINANCIALFEES + ";" + LSTR_RCONTRACTMONTH + ";" + LSTR_RPAYMONTH + ";" + LSTR_RENDPAY1 + ";" +
                         LSTR_RPRINCIPAL1 + ";" + LSTR_RPRINCIPALTAX1 + ";" + // + LSTR_PRENTSTDT + ";" + LSTR_tBox111 + ";" + LSTR_tBox112 + ";";
                                                                              //UPD BY VICKY 20150126 加入AR件區塊
                         LSTR_INVOICEAMOUNT_AR + ";" + LSTR_CREDITFEES_AR + ";" + LSTR_PAYDATE_AR + ";" + LSTR_ADVANCESINTEREST_AR + ";" + LSTR_MANAGERFEES_AR + ";" + LSTR_FINANCIALFEES_AR;
        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
        //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
        string FieldsName = "案件編號;受讓/發票金額;手續費收入;作業費用(有發票);作業費用(無發票);頭期款;保險金;" +
                            "徵信費;履約保證金;租購保證金;賬務管理費;實貸金額;佣金;" +
                            "殘值;財務顧問費;承作月數;幾月一付;期數;" +
                            "期付款(未稅);期付款(含稅);" + //案件起租日;客戶首期繳納日;預計撥款日;";
                            "總受讓金額;徵信費收入;預計撥款日;墊款息;帳務管理收入;財務顧問收入"; //UPD BY VICKY 20150126 加入AR件區塊

        string CheckType = "text;text;text;text;text;text;text;" +
                          "text;text;text;text;text;text;" +
                          "text;text;text;text;text;" +
                          "text;text" +
                          "text;text;text;text;text;text"; //mindatee;mindatee;mindatee;";

        string Length = "14;11;11;11;11;11;11;" +
                          "11;11;11;11;11;11;" +
                          "11;11;3;3;3;" +
                          "11;11;" +   //7;7;7;";
                          "11;11;10;11;11;11";    //UPD BY VICKY 20150126 加入AR件區塊

        string IsEmpty = "false;false;false;false;false;false;false;" +
                          "false;false;false;false;false;false;" +
                          "false;false;false;false;false;" +
                          "false;false;" +   //false;false;false;";
                          "false;false;false;false;false;false";   //UPD BY VICKY 20150126 加入AR件區塊

        string strCheck = "return checkRule('" + Fields + "','" + FieldsName + "','" + CheckType + "','" + Length + "','" + IsEmpty + "')";

        this.btnSubmit.Attributes.Add("onclick", strCheck);  //ML3002檢核
        //20131024 ADD BY SS ADAM Reason. Ml3001A 確認增加ML3002檢核
        string strCheck2 = "return checkRule2('" + Fields + "','" + FieldsName + "','" + CheckType + "','" + Length + "','" + IsEmpty + "')";
        this.btnSURE.Attributes.Add("onclick", strCheck2);   //ML3001A檢核
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

        //20131210 Modify by SEAN. Reason:修正不動產項次取號問題
        //綁定下拉
        //for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
        //{
        //    DropDownList LOBJ_Drop = (DropDownList)rptMLDHUMANRIGHTS.Items[i].FindControl("drpMLDCASEIMMOVABLE");
        //    for (int j = 0; j < rptMLDHUMANRIGHTS.Items.Count; j++)
        //    {
        //        LOBJ_Drop.Items.Add(new ListItem((j + 1).ToString()));
        //    }
        //    LOBJ_Drop.SelectedIndex = i;
        //    LOBJ_Drop = null;
        //}
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
        //20130703 UPD BY BRENT Reason.取消原本資料被叫出後會自動增加1.2倍 
        //if (rdoMLDCASEINST.Checked == true) {
        //    LSTR_PayMoney = (Convert.ToDouble("0" + this.txtACTUSLLOANS.Text)).ToString("0");
        //    //LSTR_PayMoney = (Convert.ToDouble("0" + this.txtACTUSLLOANS.Text) * 1.2).ToString("0");
        //}
        //else
        //{
        //    LSTR_PayMoney = (Convert.ToDouble("0" + this.txtAPLIMIT.Text)).ToString("0");
        //    //LSTR_PayMoney = (Convert.ToDouble("0" + this.txtAPLIMIT.Text) * 1.2).ToString("0");
        //}

        //for (int i = 0; i < LDTA_Data.Rows.Count; i++) {
        //  LDTA_Data.Rows[i]["GUARANTEEANOUNT"] = LSTR_PayMoney;
        //}

        this.rptMLDCASEGUARANTEE.DataSource = LDTA_Data;
        this.rptMLDCASEGUARANTEE.DataBind();
        ViewState["MLDCASEGUARANTEE"] = LDTA_Data;
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
                        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
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
    private void GetMLDCASEINSTDBind(DataTable LOBJ_Data, bool LBOL_Insert)
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

            //=============================================================
            if (LBOL_Insert)
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
                this.txtRNOINSURANCEFLG.Checked = true;
            }
            else
            {
                this.txtNOINSURANCEFLG.Checked = false;
                this.txtRNOINSURANCEFLG.Checked = false;
            }
        }
    }
    private void GetMLDCASEARDATABind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCASEARDATA_Data);
            this.txtRCREDITFEES.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CREDITFEES"].ToString());
            this.txtRFINANCIALFEES.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["FINANCIALFEES"].ToString());
            this.txtRMANAGERFEES.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["MANAGERFEES"].ToString());

            //Modify by SS Vicky 20150122 加入AR[徵信費收入][財務顧問收入][帳務管理收入]       
            this.txtCREDITFEES_AR.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CREDITFEES"].ToString());
            this.txtFINANCIALFEES_AR.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["FINANCIALFEES"].ToString());
            this.txtMANAGERFEES_AR.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["MANAGERFEES"].ToString());

            txtRTRANSCOST.Text = "0";
            txtRFEE.Text = "0";
            txtRFIRSTPAY.Text = "0";
            txtRINSURANCE.Text = "0";
            txtRPERBOND.Text = "0";
        }
    }
    private void GetMLMCONTRACTBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCONTRACT_Data);
            this.txtRACTUSLLOANS.Text = Itg.Community.Util.NumberFormat(this.hidRACTUSLLOANS.Value);
            if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
            {
                //營租事物機 和 資租事物機 資金成本要固定為 5%
                //其他承作類型 為7%
                //this.txtRCAPITALCOST.Text = "5";
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                this.txtRCAPITALCOST.Text = "4";
            }
            else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
            {
                //this.txtRCAPITALCOST.Text = "5";
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                this.txtRCAPITALCOST.Text = "4";
            }
            else
            {
                //this.txtRCAPITALCOST.Text = "7";
                //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                this.txtRCAPITALCOST.Text = "4";
            }
            CalRACTUSLLOANS();
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
                    this.txtDEPOSITLOANSAMOUNT.Text = (-1 * Convert.ToDecimal(Itg.Community.Util.NumberToDb(LOBJ_Data.Rows[0]["DEPOSITLOANSAMOUNT"].ToString().Trim()))).ToString("#,##0");
                }
                this.chkRDEPOSITLOANS2.Checked = false;
                this.txtDEPOSITLOANSAMOUNT.Enabled = true;
                this.txtDSUPPLIER.Enabled = true;
            }
            else
            {
                this.chkRDEPOSITLOANS0.Checked = false;
                this.chkRDEPOSITLOANS1.Checked = false;
                this.chkRDEPOSITLOANS2.Checked = true;
                this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                this.txtDSUPPLIER.Enabled = false;
            }
            if (LOBJ_Data.Rows[0]["ONESTR"].ToString().Trim() == "1")
            {
                this.chkOneMLDCASETARGETSTR.Checked = true;
            }
            else
            {
                this.chkOneMLDCASETARGETSTR.Checked = false;

            }
            this.hidOldData.Value = LOBJ_Data.Rows[0]["A_USERID"] + ";" + LOBJ_Data.Rows[0]["A_SYSDT"];

            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            if (LOBJ_Data.Rows[0]["NOINSURANCEFLG"].ToString() == "Y")
            {
                this.txtRNOINSURANCEFLG.Checked = true;
            }
            else
            {
                this.txtRNOINSURANCEFLG.Checked = false;
            }
        }
    }
    private void GetCaseBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCASE_Data);
            //---------------------     
            this.txtRMAINTYPE.Text = this.drpMAINTYPE.SelectedItem.Text;
            this.txtRTRANSTYPE.Text = this.drpTRANSTYPE.SelectedItem.Text;
            this.txtRUSESTATUS.Text = this.drpUSESTATUS.SelectedItem.Text;

            //Modify by SS Vicky 20150122 區分AR件及非AR件的承作內容 START
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
                this.txtRFIRSTPAY.Text = this.txtFIRSTPAY.Text;
                this.txtRINSURANCE.Text = this.txtINSURANCE.Text;
                this.txtRPERBOND.Text = this.txtPERBOND.Text;

                //UPD BY VICKY 20150122 
                this.txtINVOICEAMOUNT_AR.Text = this.txtTRANSCOST.Text;  //總受讓金額
            }
        }
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
            LSTR_StoreProcedure.Append("SP_ML1002_Q04" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
            //MLDCONTRACTARD撥款案件AR明細檔 Modify by SS Vicky 20150121
            LSTR_StoreProcedure.Append("SP_ML3001_Q12" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("AND MLDCONTRACTARD.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //MLDCONTRACTARD撥款案件AR明細檔 Modify by SS Vicky 20150121
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

                //this.drpEXPIREPROC.DataSource = LDST_Data.Tables[10].DefaultView;
                //this.drpEXPIREPROC.DataBind();

                this.drpCOMPTYPE.DataSource = LDST_Data.Tables[11].DefaultView;
                this.drpCOMPTYPE.DataBind();

                this.drpORGATYPE.DataSource = LDST_Data.Tables[12].DefaultView;
                this.drpORGATYPE.DataBind();

                this.drpLISTED.DataSource = LDST_Data.Tables[13].DefaultView;
                this.drpLISTED.DataBind();

                this.drpCODE.DataSource = LDST_Data.Tables[14].DefaultView;
                this.drpCODE.DataBind();

                //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
                this.drpSOURCETYPE.DataSource = LDST_Data.Tables[15].DefaultView;
                this.drpSOURCETYPE.DataBind();

                //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
                this.drpBANKCD.DataSource = LDST_Data.Tables[16].DefaultView;
                this.drpBANKCD.DataBind();
                this.drpBANKCD.Items.Insert(0, new ListItem("", ""));

                //Modify by SS Vicky 20150121 墊款成數
                this.drpADVANCESPERCENT_AR.DataSource = LDST_Data.Tables[17].DefaultView;
                this.drpADVANCESPERCENT_AR.DataBind();

                //20160323 ADD BY SS ADAM REASON.增加案件產品別
                this.drpPRODCD.DataSource = LDST_Data.Tables[18].DefaultView;
                this.drpPRODCD.DataBind();

                //20221031行業別改下拉選單
                this.DrpNDU.DataSource = LDST_Data.Tables[19].DefaultView;
                DataView LDVW_DocData = LDST_Data.Tables[19].DefaultView;
                LDVW_DocData.RowFilter = "MCODE NOT IN ('17' , '18'  , '19' , '20')";
                this.DrpNDU.DataBind();

                string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                drpSUBTYPEBindbyID(LSTR_MAINTYPEID);
                SetMAINTYPERDO(LSTR_MAINTYPEID);
                ////Modify by SS Vicky 20150121 型式
                //this.drpPAYTYPE_AR.DataSource = LDST_Data.Tables[18].DefaultView;
                //this.drpPAYTYPE_AR.DataBind();

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
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "11" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
            //郵編區號
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "89" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "90" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify by SS Vicky 20150121 墊款成數
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A8" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20160321 ADD BY SS ADAM REASON.新增案件產品別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "93" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20221031行業別改下拉選單
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify by SS Vicky 20150121 型式
            //LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            //LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A9" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
    protected void droIMMOVABLEID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList LOBJ_Drp = (DropDownList)sender;
        RepeaterItem RItem;
        RItem = (RepeaterItem)LOBJ_Drp.Parent;
        int LINT_SelRow = RItem.ItemIndex;
        int LINT_TagRow = Convert.ToInt32(LOBJ_Drp.SelectedValue) - 1;

        this.hidShowTag.Value = "fraTab44Caption";
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
            //LOBJ_Data.Rows[i]["TARGETPRICE"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            //LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblTARGETPRICENOTAX")).Text;

            string LSTR_TARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            LOBJ_Data.Rows[i]["TARGETPRICE"] = LSTR_TARGETPRICE;
            double LINT_TARGETPRICENOTAX = LSTR_TARGETPRICE == "" ? 0 : Convert.ToDouble(LSTR_TARGETPRICE);
            LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = (LINT_TARGETPRICENOTAX / 1.05).ToString("0");

            LOBJ_Data.Rows[i]["PROCEDEINV"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtPROCEDEINV")).Text;
            LOBJ_Data.Rows[i]["PROCEDEINVTAX"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtPROCEDEINVTAX")).Text;

            LOBJ_Data.Rows[i]["DISCOUNTINV"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtDISCOUNTINV")).Text;
            LOBJ_Data.Rows[i]["DISCOUNTINVTAX"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtDISCOUNTINVTAX")).Text;
            LOBJ_Data.Rows[i]["SALESPAY"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSALESPAY")).Text;
            LOBJ_Data.Rows[i]["DURABLELIFE"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblDURABLELIFE")).Text;

            LOBJ_Data.Rows[i]["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDZIPCODE")).Text;
            LOBJ_Data.Rows[i]["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDZIPCODES")).Text;
            LOBJ_Data.Rows[i]["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDADDR")).Text;
            LOBJ_Data.Rows[i]["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Data.Rows[i]["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtDEPTNAME")).Text;


            LOBJ_Data.Rows[i]["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Data.Rows[i]["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Data.Rows[i]["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Data.Rows[i]["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTEMAIL")).Text;

            LOBJ_Data.Rows[i]["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTFAXCODE")).Text;
        }

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
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        string LSTR_SelHead = this.hidSelHeadTag.Value;

        switch (LSTR_SelHead)
        {
            case "rptMLDCASETARGET":
                this.hidShowTag.Value = "fraTab44Caption";
                AddMLDCASETARGETRow();
                break;
            case "rptMLDCONTRACTINV":
                this.hidShowTag.Value = "fraTab66Caption";
                AddMLDCONTRACTINVRow();
                break;
            case "rptMLDCONTRACTINVD":
                this.hidShowTag.Value = "fraTab66Caption";
                AddMLDCONTRACTINVDRow();
                break;
            case "rptMLDCONTRACTARD":   //Modify by SS Vicky 20150121 AR明細GRID 
                this.hidShowTag.Value = "fraTab33Caption";
                AddMLDCONTRACTARDRow();
                break;
            case "rptMLDCONTRACTARBINV":   //Modify by SS Vicky 20150121 買受發票明細GRID
                this.hidShowTag.Value = "fraTab33Caption";
                AddMLDCONTRACTARBINVRow();
                break;
            //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
            case "rptMLDASSPAYMF":
                this.hidShowTag.Value = "fraTab66Caption";
                AddMLDASSPAYMFRow();
                break;
            case "rptMLDFEEINCOME1":
                this.hidShowTag.Value = "fraTab66Caption";
                AddMLDFEEINCOME1Row();
                break;
            case "rptMLDFEEINCOME2":
                this.hidShowTag.Value = "fraTab66Caption";
                AddMLDFEEINCOME2Row();
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
                case "rptMLDCASETARGET":
                    this.hidShowTag.Value = "fraTab44Caption";
                    DelMLDCASETARGETRow(LSTR_RowIndex);
                    break;
                case "rptMLDCONTRACTINV":
                    this.hidShowTag.Value = "fraTab66Caption";
                    DelMLDCONTRACTINVRow(LSTR_RowIndex);
                    CalDISCOUNTTOTAL();
                    break;
                case "rptMLDCONTRACTINVD":
                    this.hidShowTag.Value = "fraTab66Caption";
                    DelMLDCONTRACTINVDRow(LSTR_RowIndex);
                    CalDISCOUNTTOTAL();
                    break;
                case "rptMLDCONTRACTARD":   //Modify by SS Vicky 20150121 AR明細GRID 
                    this.hidShowTag.Value = "fraTab33Caption";
                    DelMLDCONTRACTARDRow(LSTR_RowIndex);

                    //20150315 ADD BY SS ADAM REASON.調整為可以自行輸入總受讓金額
                    //CalINVOICEAMOUNT_AR();
                    //20150326 ADD BY SS ADAM REASON.增加計算撥款金額
                    CalPAYAMOUNT_AR();
                    break;
                case "rptMLDCONTRACTARBINV":   //Modify by SS Vicky 20150121 買受發票明細GRID
                    this.hidShowTag.Value = "fraTab33Caption";
                    DelMLDCONTRACTARBINVRow(LSTR_RowIndex);
                    break;
                //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
                case "rptMLDASSPAYMF":
                    this.hidShowTag.Value = "fraTab66Caption";
                    DelMLDASSPAYMFRow(LSTR_RowIndex);

                    break;
                case "rptMLDFEEINCOME1":
                    this.hidShowTag.Value = "fraTab66Caption";
                    DelMLDFEEINCOME1Row(LSTR_RowIndex);
                    CalDISCOUNTTOTAL();
                    break;
                case "rptMLDFEEINCOME2":
                    this.hidShowTag.Value = "fraTab66Caption";
                    DelMLDFEEINCOME2Row(LSTR_RowIndex);
                    CalDISCOUNTTOTAL();
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
        }
        else if (LSTR_Type == "2")
        {
            rptContactCBind();
        }
        else if (LSTR_Type == "3")
        {
            rptContactIBind();
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
        }
        else if (LSTR_Type == "2")
        {
            rptContactCBind();
        }
        else if (LSTR_Type == "3")
        {
            rptContactIBind();
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
        this.UpdatePanelContactM.Update();
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
        this.UpdatePanelContactC.Update();
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
        this.UpdatePanelContactI.Update();
    }
    //標的物
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
            LOBJ_Data.Columns.Add(new DataColumn("DURABLELIFE", System.Type.GetType("System.String")));

            //Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)
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
        //先賦值
        for (int i = 0; i < rptMLDCASETARGET.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["TARGETNAME"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text;
            LOBJ_Data.Rows[i]["TARGETTYPE"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETSTATUS"] = ((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue;
            LOBJ_Data.Rows[i]["TARGETMODELNO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMODELNO")).Text;
            LOBJ_Data.Rows[i]["TARGETMACHINENO"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMACHINENO")).Text;

            //Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)
            LOBJ_Data.Rows[i]["MANUFACTURER"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtMANUFACTURER")).Text;
            LOBJ_Data.Rows[i]["TARGETBRAND"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETBRAND")).Text;
            LOBJ_Data.Rows[i]["TARGETUNIT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETUNIT")).Text;
            LOBJ_Data.Rows[i]["TARGETCOUNT"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETCOUNT")).Text;


            LOBJ_Data.Rows[i]["SUPPLIERID"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text;
            LOBJ_Data.Rows[i]["SUPPLIERIDS"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERIDS")).Text;

            LOBJ_Data.Rows[i]["TARGETPRICE"] = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblTARGETPRICENOTAX")).Text;

            string LSTR_TARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text;
            LOBJ_Data.Rows[i]["TARGETPRICE"] = LSTR_TARGETPRICE;
            double LINT_TARGETPRICENOTAX = LSTR_TARGETPRICE == "" ? 0 : Convert.ToDouble(LSTR_TARGETPRICE);
            LOBJ_Data.Rows[i]["TARGETPRICENOTAX"] = (LINT_TARGETPRICENOTAX / 1.05).ToString("0");
            LOBJ_Data.Rows[i]["DURABLELIFE"] = ((Label)rptMLDCASETARGET.Items[i].FindControl("lblDURABLELIFE")).Text;

            LOBJ_Data.Rows[i]["STOREDZIPCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDZIPCODE")).Text;
            LOBJ_Data.Rows[i]["STOREDZIPCODES"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDZIPCODES")).Text;
            LOBJ_Data.Rows[i]["STOREDADDR"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtSTOREDADDR")).Text;
            LOBJ_Data.Rows[i]["CONTACTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Data.Rows[i]["DEPTNAME"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtDEPTNAME")).Text;

            LOBJ_Data.Rows[i]["CONTACTTITLE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Data.Rows[i]["CONTACTTEL"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Data.Rows[i]["CONTACTTELEXT"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTELEXT")).Text;
            LOBJ_Data.Rows[i]["CONTACTMPHONE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAX"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Data.Rows[i]["CONTACTEMAIL"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTEMAIL")).Text;

            LOBJ_Data.Rows[i]["CONTACTTELCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Data.Rows[i]["CONTACTFAXCODE"] = ((TextBox)rptMLDCASETARGETSTR.Items[i].FindControl("txtCONTACTFAXCODE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCASETARGETRow()
    {
        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        //if (chkAr1.Checked == false) {
        if (chkAr1.Checked == false && chkBANK1.Checked == false)
        {
            MLDCASETARGETInit();
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCASETARGET();
            //新增一筆資料
            DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
            LOBJ_DataRow["TARGETPRICE"] = "0";
            LOBJ_DataRow["TARGETPRICENOTAX"] = "0";
            LOBJ_Data.Rows.Add(LOBJ_DataRow);
            ViewState["MLDCASETARGET"] = LOBJ_Data;
            MLDCASETARGETBind();

        }
    }
    private void DelMLDCASETARGETRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCASETARGET();
        //刪除一筆資料   
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        }
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
    }
    private void GetMLDCASETARGETBind(DataTable LOBJ_Data)
    {
        ChangeMLDCASETARGETTyep(LOBJ_Data);
        if (drpMAINTYPE.SelectedValue == "04")
        {
            this.chkAr1.Checked = true;
            this.chkAr2.Checked = true;
        }
        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
        else if (drpSOURCETYPE.SelectedValue == "02")
        {
            chkBANK1.Checked = true;
        }
        else
        {
            this.chkAr1.Checked = false;
            this.chkAr2.Checked = false;
            //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
            chkBANK1.Checked = false;
            MLDCASETARGETBind();
        }
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
        this.UpdatePanelMLDCASETARGET.Update();
        this.UpdatePanelMLDCASETARGETSTR.Update();
    }
    private void ChangeMLDCASETARGETTyep(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCASETARGET"] = null;
        MLDCASETARGETInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCASETARGET"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCASETARGET"] = LOBJ_Data;
    }
    protected void chkOneMLDCASETARGETSTR_CheckedChanged(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab44Caption";
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
    //進項發票
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
            LOBJ_Data.Columns.Add(new DataColumn("PAYData", System.Type.GetType("System.String")));
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
    private DataTable updateMLDCONTRACTINV()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINV"];
        //先賦值
        for (int i = 0; i < rptMLDCONTRACTINV.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["SUPPLIER"] = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value;
            LOBJ_Data.Rows[i]["SUPPLIERS"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtSUPPLIERS")).Text;
            LOBJ_Data.Rows[i]["SUPSEQ"] = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPSEQ")).Value;
            LOBJ_Data.Rows[i]["CERTIFICATENO"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text;
            LOBJ_Data.Rows[i]["INVDATE"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVDATE")).Text;

            LOBJ_Data.Rows[i]["PAYBANK"] = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidPAYBANK")).Value;
            LOBJ_Data.Rows[i]["PAYData"] = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidPAYData")).Value;
            LOBJ_Data.Rows[i]["BANKNM"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtBANKNM")).Text;
            LOBJ_Data.Rows[i]["COMPNM"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCOMPNM")).Text;
            LOBJ_Data.Rows[i]["RV_NAME"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRV_NAME")).Text;
            LOBJ_Data.Rows[i]["RVACNT"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRVACNT")).Text;
            LOBJ_Data.Rows[i]["NOTAXAMOUNT"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text;
            LOBJ_Data.Rows[i]["TAX"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtTAX")).Text;
            LOBJ_Data.Rows[i]["ANOUMTTAX"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text;

            LOBJ_Data.Rows[i]["PERBONDUSED"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDUSED")).Text;
            LOBJ_Data.Rows[i]["HIREPURUSED"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtHIREPURUSED")).Text;
            LOBJ_Data.Rows[i]["FIRSTPAYUSED"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYUSED")).Text;
            LOBJ_Data.Rows[i]["INVSALESPAY"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Text;
            LOBJ_Data.Rows[i]["ACTUALLYAMOUNT"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtACTUALLYAMOUNT")).Text;

            LOBJ_Data.Rows[i]["PERBONDNOTE"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDNOTE")).Text;
            LOBJ_Data.Rows[i]["PURCHASENOTE"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPURCHASENOTE")).Text;
            LOBJ_Data.Rows[i]["FIRSTPAYNOTE"] = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYNOTE")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCONTRACTINVRow()
    {
        MLDCONTRACTINVInit();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTINV();
        //新增一筆資料 
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["NOTAXAMOUNT"] = "0";
        LOBJ_DataRow["TAX"] = "0";
        LOBJ_DataRow["ANOUMTTAX"] = "0";

        LOBJ_DataRow["PERBONDUSED"] = "0";
        LOBJ_DataRow["HIREPURUSED"] = "0";
        LOBJ_DataRow["FIRSTPAYUSED"] = "0";
        LOBJ_DataRow["INVSALESPAY"] = "0";
        LOBJ_DataRow["ACTUALLYAMOUNT"] = "0";

        LOBJ_DataRow["PERBONDNOTE"] = "0";
        LOBJ_DataRow["PURCHASENOTE"] = "0";
        LOBJ_DataRow["FIRSTPAYNOTE"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCONTRACTINV"] = LOBJ_Data;
        MLDCONTRACTINVBind();
    }
    private void DelMLDCONTRACTINVRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTINV();
        //刪除一筆資料  
        if (rptMLDCONTRACTINV.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        }
        ViewState["MLDCONTRACTINV"] = LOBJ_Data;
        MLDCONTRACTINVBind();
    }
    private void GetMLDCONTRACTINVBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ChangeMLDCONTRACTINVTyep(LOBJ_Data);
            MLDCONTRACTINVBind();
        }
    }
    private void ChangeMLDCONTRACTINVTyep(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCONTRACTINV"] = null;
        MLDCONTRACTINVInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINV"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTINV"] = LOBJ_Data;
    }
    private void MLDCONTRACTINVBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINV"];
        this.rptMLDCONTRACTINV.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTINV.DataBind();
        //鎖定供應商名稱 稅額 含稅金額 不能輸入
        for (int i = 0; i < rptMLDCONTRACTINV.Items.Count; i++)
        {
            if (((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value != "")
            {
                GetACCOMFRV(rptMLDCONTRACTINV.Items[i], ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value);
            }
            ((DropDownList)rptMLDCONTRACTINV.Items[i].FindControl("drpSUPSEQ")).SelectedValue = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPSEQ")).Value;
            ((DropDownList)rptMLDCONTRACTINV.Items[i].FindControl("drpSUPSEQ")).Attributes.Add("onchange", "drpSUPSEQ_onchange(this);");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtSUPPLIERS")).Attributes.Add("Readonly", "True");
            //((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtTAX")).Attributes.Add("Readonly", "True");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtACTUALLYAMOUNT")).Attributes.Add("Readonly", "True");
            //((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Attributes.Add("Readonly", "True");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtBANKNM")).Attributes.Add("Readonly", "True");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCOMPNM")).Attributes.Add("Readonly", "True");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRV_NAME")).Attributes.Add("Readonly", "True");
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRVACNT")).Attributes.Add("Readonly", "True");
            string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
            if (LSTR_MAINTYPEID == "04")
            {
                ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Attributes.Add("Readonly", "True");
            }
        }
        this.UpdatePanelMLDCONTRACTINV.Update();
    }
    //進項折讓發票
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
    private DataTable updateMLDCONTRACTINVD()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINVD"];
        //先賦值
        for (int i = 0; i < rptMLDCONTRACTINVD.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["DISCOUNTINVNUM"] = ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text;
            LOBJ_Data.Rows[i]["DISCOUNTDATE"] = ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTDATE")).Text;
            LOBJ_Data.Rows[i]["DISCOUNTAMOUNT"] = ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text;
            LOBJ_Data.Rows[i]["DISCOUNTTAX"] = ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text;
            LOBJ_Data.Rows[i]["DISCOUNTAMOUNTTAX"] = ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text;
        }
        return LOBJ_Data;
    }
    private void AddMLDCONTRACTINVDRow()
    {
        MLDCONTRACTINVDInit();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTINVD();
        //刪除一筆資料   
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["DISCOUNTAMOUNT"] = "0";
        LOBJ_DataRow["DISCOUNTTAX"] = "0";
        LOBJ_DataRow["DISCOUNTAMOUNTTAX"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCONTRACTINVD"] = LOBJ_Data;
        MLDCONTRACTINVDBind();
    }
    private void DelMLDCONTRACTINVDRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTINVD();
        //刪除一筆資料   
        if (rptMLDCONTRACTINVD.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        }
        ViewState["MLDCONTRACTINVD"] = LOBJ_Data;
        MLDCONTRACTINVDBind();
    }
    private void GetMLDCONTRACTINVDBind(DataTable LOBJ_Data)
    {
        ChangeMLDCONTRACTINVDTyep(LOBJ_Data);
        MLDCONTRACTINVDBind();
    }
    private void ChangeMLDCONTRACTINVDTyep(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDCONTRACTINVD"] = null;
        MLDCONTRACTINVDInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINVD"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDCONTRACTINVD"] = LOBJ_Data;
    }
    private void MLDCONTRACTINVDBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTINVD"];
        this.rptMLDCONTRACTINVD.DataSource = LOBJ_Data;
        this.rptMLDCONTRACTINVD.DataBind();
        //鎖定 稅額 含稅金額 不能輸入
        for (int i = 0; i < rptMLDCONTRACTINVD.Items.Count; i++)
        {
            //((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Attributes.Add("Readonly", "True");
            //((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Attributes.Add("Readonly", "True");
        }
        this.UpdatePanelMLDCONTRACTINVD.Update();
    }

    /*==============================================================================================*/
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //JOHN 2013/10/14 非3001A 確認 都N
        if (GSTR_A_PRGID == "LE3001A")
            txtSALESFLG.Text = "N";
        else
            txtSALESFLG.Text = "Y";
        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        if (drpMAINTYPE.SelectedValue != "04" && txtRNOINSURANCEFLG.Checked == false)
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

        //Modify 20161130 By SEAN Reason: 新增NPV0與NPV利率成本0
        this.txtRNPVRATECOST0.Text = "1";

        //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV的值固定帶4.
        ////Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        //double LINT_NPVRATECOST = GET_NPVRATECOST();
        //this.txtRNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
        //Modify 20240815 利率成本改4.75%
        //this.txtRNPVRATECOST.Text = "4";
        this.txtRNPVRATECOST.Text = "4.75";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtRNPVRATECOST2.Text = "5";

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPVRATECOST0.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNPVRATECOST.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPVRATECOST2.Update();

        //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
        //MLMCONTRACTSave("6");
        MLMCONTRACTSave("6", txtSALESFLG.Text.ToString().Trim());
        this.UpdatePanel1.Update();
        if (GSTR_A_PRGID == "LE3001A" && txtPRENTSTDT.Text != "" && txtCUSTFPAYDATE.Text != "" && txtPAYDATE.Text != "")
        {
            //john chen 2013/10//11  取得合約號碼號可以按
            if (drpMAINTYPE.SelectedValue == "03")
                this.btnPayDate.Enabled = true;
            //Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印
            btnRmainPrint.Enabled = true;
        }
        else if (GSTR_A_PRGID == "LE3002")
        {
            //john chen 2013/10//11  取得合約號碼號可以按
            if (drpMAINTYPE.SelectedValue == "03")
                this.btnPayDate.Enabled = true;
            //Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印
            btnRmainPrint.Enabled = true;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        if (drpMAINTYPE.SelectedValue != "04" && txtRNOINSURANCEFLG.Checked == false)
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
        if (txtRNOINSURANCEFLG.Checked == false && txtRINSURANCE.Text.Trim() == "0")
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
                    Alert("承作內容中，「保險金」不可為零！");
                    return;
                }
            }
        }
        //Modify 20130402 By SS Vicky. Reason: 在標的物的頁籤中，是事務機跟營建機具，則保險費要必填 end



        //Modify 20121126 By SS Adam. Reason: 增加分期_設備動保檢核
        if ((this.drpMAINTYPE.SelectedValue == "03" && this.drpSUBTYPE.SelectedValue == "02") || (this.drpMAINTYPE.SelectedValue == "03" && this.drpSUBTYPE.SelectedValue == "03"))
        {

            //Modify 20121122 By SS Steven. Reason: 擔保條件的動產資料欄位檢核
            if (check_MLDCASEMOVABLE() == false)
            {
                return;
            }
        }

        //20150330 ADD BY SS ADAM REASON.檢核實撥金額
        //if (this.drpMAINTYPE.SelectedValue == "04")
        //{
        //    if (txtACTUALLYAMOUNT.Text.Replace(",", "") != txtPAYAMT_AR.Text.Replace(",", ""))
        //    {
        //        Alert("承作內容的撥款金額不等於撥款資料的實撥金額！");
        //        return;
        //    }
        //}

        //20160808 ADD BY SEAN 新增「付款差異天數」及「付供應商天數」檢核
        if (txtRPATDAYS.Text != "0")
        {
            if (drpRPAYTIME.SelectedValue == "01")
            {
                TimeSpan DIFF_PATDAYS_FIRST = Convert.ToDateTime(txtCUSTFPAYDATE.Text) - Convert.ToDateTime(txtPRENTSTDT.Text);
                if (Convert.ToInt32(txtRPATDAYS.Text) < Convert.ToInt32(DIFF_PATDAYS_FIRST.Days.ToString()))
                {
                    Alert("「付款差異天數」需 ≧ 「客戶首期繳納日」- 案件應繳款日！");
                    return;
                }
            }
            else
            {

                TimeSpan DIFF_PATDAYS_LAST = Convert.ToDateTime(txtCUSTFPAYDATE.Text) - (Convert.ToDateTime(txtPRENTSTDT.Text).AddDays(30));
                if (Convert.ToInt32(txtRPATDAYS.Text) < Convert.ToInt32(DIFF_PATDAYS_LAST.Days.ToString()))
                {
                    Alert("「付款差異天數」需 ≧ 「客戶首期繳納日」- 案件應繳款日！");
                    return;
                }
            }
        }

        if (txtRSUPPILERDAYS.Text != "0")
        {
            TimeSpan DIFF_SUPPILERDAYS = Convert.ToDateTime(txtPAYDATE.Text) - Convert.ToDateTime(txtPRENTSTDT.Text);
            if (Convert.ToInt32(txtRSUPPILERDAYS.Text) < Convert.ToInt32(DIFF_SUPPILERDAYS.Days.ToString()))
            {
                Alert("「付供應商天數」需 >=「預計撥款日」- 「案件起租日」！");
                return;
            }
        }



        //Modify 20120615 By SS Gordon. Reason: 新增AR案件的IRR計算，與原本IRR計算分開
        //double LINT_IRR = IRR_Cal();
        double LINT_IRR = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            LINT_IRR = IRR_Cal_AR();
        }
        else
        {
            LINT_IRR = IRR_Cal();
            if (LINT_IRR == 0) return;
        }
        this.txtRIRR.Text = LINT_IRR.ToString("0.000");

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.txtRNPVRATECOST0.Text = "1";

        //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV的值固定帶4.
        ////Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        //double LINT_NPVRATECOST = GET_NPVRATECOST();
        //this.txtRNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
        //Modify 20240815 利率成本改4.75%
        //this.txtRNPVRATECOST.Text = "4";
        this.txtRNPVRATECOST.Text = "4.75";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtRNPVRATECOST2.Text = "5";

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        double LINT_NPV0 = 0;

        //Modify 20120618 By SS Gordon. Reason: 新增AR案件的NPV計算，與原本NPV計算分開
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        //double LINT_NPV = NPV_Cal();
        double LINT_NPV = 0;
        double LINT_NPV2 = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            LINT_NPV0 = NPV_Cal_AR(txtRNPVRATECOST0.Text);

            LINT_NPV = NPV_Cal_AR(txtRNPVRATECOST.Text);
            LINT_NPV2 = NPV_Cal_AR(txtRNPVRATECOST2.Text);
        }
        else
        {
            LINT_NPV0 = NPV_Cal(txtRNPVRATECOST0.Text);

            LINT_NPV = NPV_Cal(txtRNPVRATECOST.Text);
            LINT_NPV2 = NPV_Cal(txtRNPVRATECOST2.Text);
        }

        this.txtRNPV0.Text = LINT_NPV0.ToString("0");

        this.txtRNPV.Text = LINT_NPV.ToString("0");
        this.txtRNPV2.Text = LINT_NPV2.ToString("0");
        this.UpdatePanelIRR.Update();

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPV0.Update();

        this.UpdatePanelNPV.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPV2.Update();

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPVRATECOST0.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNPVRATECOST.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPVRATECOST2.Update();

        //一般租賃處要判斷核決權限
        //20110610 cathy 加上南區一般租賃處XDH0
        //20120430 Sean  加上一般租賃/桃園處XDI0
        //20120515 Sean  加上一般租質/中區處XDK0
        //20130103 Sean  加上一般租質/台北營二XDL0
        //if (GSTR_DEPTID == "XDG0" || GSTR_DEPTID == "XDH0") {
        //if (GSTR_DEPTID == "XDG0" || GSTR_DEPTID == "XDH0"  || GSTR_DEPTID == "XDI0" ) {
        //if (GSTR_DEPTID == "XDG0" || GSTR_DEPTID == "XDH0"  || GSTR_DEPTID == "XDI0" || GSTR_DEPTID == "XDK0" ) {
        if (GSTR_DEPTID == "XDG0" || GSTR_DEPTID == "XDH0" || GSTR_DEPTID == "XDI0" || GSTR_DEPTID == "XDK0" || GSTR_DEPTID == "XDL0")
        {
            string LSTR_SaveType = GetSaveType();
            if (LSTR_SaveType == "")
            {
                Alert("無法取得核決權限資料！");
            }
            else
            {
                //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
                //MLMCONTRACTSave(LSTR_SaveType);
                MLMCONTRACTSave(LSTR_SaveType, txtSALESFLG.Text.ToString().Trim());
                this.UpdatePanel1.Update();
            }
        }
        else
        {
            //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
            MLMCONTRACTSave("7", txtSALESFLG.Text.ToString().Trim());
            this.UpdatePanel1.Update();
        }
    }
    private string GetSaveType()
    {
        String LSTR_ObjId = "";
        Comus.HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string LSTR_Result = "";
        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = "dbo.SP_ML0003_Q02";
            LVAR_Parameter[1] = "'" + this.drpMAINTYPE.SelectedValue + "',";
            LVAR_Parameter[1] += "'" + this.drpSUBTYPE.SelectedValue + "',";
            LVAR_Parameter[1] += "'" + this.txtRIRR.Text + "',";
            LVAR_Parameter[1] += "'" + this.txtRCONTRACTMONTH.Text + "',";
            LVAR_Parameter[1] += "'" + Itg.Community.Util.NumberToDb(this.txtRTRANSCOST.Text) + "',";
            LVAR_Parameter[1] += "'" + GSTR_U_SYSDT + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                LSTR_Result = Convert.ToInt16(LOBJ_Return.ReturnData.Rows[0][0]).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LSTR_Result;
    }
    private bool CheckTARGETRule()
    {
        TextBox LOBJ_Txt;
        if (this.rptContactI.Items.Count < 1)
        {
            Alert("請至少輸入一筆發票聯絡人！");
            return false;
        }

        for (int i = 0; i < this.rptContactI.Items.Count; i++)
        {
            LOBJ_Txt = (TextBox)rptContactI.Items[i].FindControl("txtINVOICEADDR");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入發票聯絡人地址！");
                this.hidShowTag.Value = "fraTab11Caption";
                return false;
            }
        }

        if (txtRTRANSCOST.Text == "0")
        {
            Alert("受讓/發票金額輸入需大於 0！");
            txtRTRANSCOST.Focus();
            return false;
        }
        if (txtRCONTRACTMONTH.Text == "0")
        {
            Alert("總承作月數輸入需大於 0！");
            txtRCONTRACTMONTH.Focus();
            return false;
        }
        if (txtRPAYMONTH.Text == "0")
        {
            Alert("幾月一付輸入需大於 0！");
            txtRPAYMONTH.Focus();
            return false;
        }
        if (txtRENDPAY1.Text == "0")
        {
            Alert("第一段結束期別輸入需大於 0！");
            txtRENDPAY1.Focus();
            return false;
        }

        // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
        //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
        if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
        {

            if (txtRPRINCIPAL1.Text == "0")
            {
                Alert("第一段期付款輸入需大於 0！");
                txtRPRINCIPAL1.Focus();
                return false;
            }
        }
        if (txtRSTARTPAY2.Text != "" || txtRENDPAY2.Text != "" || txtRPRINCIPAL2.Text != "")
        {
            if (txtRSTARTPAY2.Text == "")
            {
                Alert("請輸入第二段開始期別！");
                txtRSTARTPAY2.Focus();
                return false;
            }
            if (txtRENDPAY2.Text == "")
            {
                Alert("請輸入第二段結束期別！");
                txtRENDPAY2.Focus();
                return false;
            }
            if (txtRPRINCIPAL2.Text == "")
            {
                Alert("請輸入第二段期付款！");
                txtRPRINCIPAL2.Focus();
                return false;
            }
        }
        if (txtRSTARTPAY3.Text != "" || txtRENDPAY3.Text != "" || txtRPRINCIPAL3.Text != "")
        {
            if (txtRSTARTPAY3.Text == "")
            {
                Alert("請輸入第三段開始期別！");
                txtRSTARTPAY3.Focus();
                return false;
            }
            if (txtRENDPAY3.Text == "")
            {
                Alert("請輸入第三段結束期別！");
                txtRENDPAY3.Focus();
                return false;
            }
            if (txtRPRINCIPAL3.Text == "")
            {
                Alert("請輸入第三段期付款！");
                txtRPRINCIPAL3.Focus();
                return false;
            }
        }
        if (txtRSTARTPAY4.Text != "" || txtRENDPAY4.Text != "" || txtRPRINCIPAL4.Text != "")
        {
            if (txtRSTARTPAY4.Text == "")
            {
                Alert("請輸入第四段開始期別！");
                txtRSTARTPAY4.Focus();
                return false;
            }
            if (txtRENDPAY4.Text == "")
            {
                Alert("請輸入第四段結束期別！");
                txtRENDPAY4.Focus();
                return false;
            }
            if (txtRPRINCIPAL4.Text == "")
            {
                Alert("請輸入第四段期付款！");
                txtRPRINCIPAL4.Focus();
                return false;
            }
        }
        bool LBOL_Checked = false;
        if (txtRENDPAY4.Text != "")
        {
            if (txtRCONTRACTMONTH.Text != txtRENDPAY4.Text)
            {
                Alert("最後一段結束期別輸入需等於總承作月數！");
                txtRENDPAY4.Focus();
                return false;
            }
            else
            {
                LBOL_Checked = true;
            }
        }
        if (!LBOL_Checked)
        {
            if (txtRENDPAY3.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY3.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY3.Focus();
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
            if (txtRENDPAY2.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY2.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY2.Focus();
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
            if (txtRENDPAY1.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY1.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY1.Focus();
                    return false;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }
        if (Convert.ToDouble(txtRIRR.Text) == 0)
        {
            Alert("IRR 不可為 0！請先試算 IRR");
            this.hidShowTag.Value = "fraTab33Caption";
            return false;
        }

        // Modify 20130528 BY    SEAN.   Reason: 修改現在限制存檔的條件，「標的物金額小於或等於原案的標的物金額」→「實貸金額要小於或等於原案的實貸金額」
        if (Convert.ToDouble(txtRACTUSLLOANS.Text) > Convert.ToDouble(txtACTUSLLOANS.Text))
        {
            Alert("實貸金額要小於或等於原案的實貸金額！");
            this.hidShowTag.Value = "fraTab33Caption";
            return false;
        }
        //if (Convert.ToDouble(txtRTRANSCOST.Text) > Convert.ToDouble(txtTRANSCOST.Text)) {
        //  Alert("撥款金額要小於或等於原案的撥款金額！");
        //  this.hidShowTag.Value = "fraTab33Caption";
        //  return false;
        //}
        if (Convert.ToDouble(txtRCONTRACTMONTH.Text) > Convert.ToDouble(txtCONTRACTMONTH.Text))
        {
            Alert("期數要小於或等於原案的期數！");
            this.hidShowTag.Value = "fraTab33Caption";
            return false;
        }
        if (Convert.ToDouble(txtRIRR.Text) < Convert.ToDouble(txtIRR.Text))
        {
            Alert("IRR要大於原案的IRR！");
            this.hidShowTag.Value = "fraTab33Caption";
            return false;
        }
        for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
        {
            LOBJ_Txt = (TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入供應商ID！");
                this.hidShowTag.Value = "fraTab44Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE");
            if (Convert.ToInt32("0" + LOBJ_Txt.Text.Replace(",", "")) <= 0)
            {
                Alert("標的物價格需大於0！");
                this.hidShowTag.Value = "fraTab44Caption";
                return false;
            }
        }
        for (int i = 0; i < this.rptMLDCONTRACTINV.Items.Count; i++)
        {
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入憑證號碼！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVDATE");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入發票日期！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT");
            if (Convert.ToInt32("0" + LOBJ_Txt.Text.Replace(",", "")) <= 0)
            {
                Alert("未稅金額需大於0！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
        }

        for (int i = 0; i < this.rptMLDCONTRACTINVD.Items.Count; i++)
        {
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入折讓發票號碼！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTDATE");
            if (LOBJ_Txt.Text == "")
            {
                Alert("請輸入折讓日！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
            LOBJ_Txt = (TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT");
            if (Convert.ToInt32("0" + LOBJ_Txt.Text.Replace(",", "")) <= 0)
            {
                Alert("折讓未稅金額需大於0！");
                this.hidShowTag.Value = "fraTab66Caption";
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// ADD 首期繳納日若為ACH案件要檢核付款日
    /// </summary>
    /// <param name="LSTR_CUSTID"></param>
    private ReturnObject<DataSet> ACHCHECK(string LSTR_CUSTID)
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
            LSTR_StoreProcedure.Append("SP_ML1002_Q28" + GSTR_RowDelimitChar);
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="LSTR_CASESTATUS">
    /// 6=新增撥款，撥款尚未送出審核。
    /// 7=撥款送出審核，徵信主管待核准。
    /// </param>
    //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
    //private void MLMCONTRACTSave(string LSTR_CASESTATUS)
    private void MLMCONTRACTSave(string LSTR_CASESTATUS, string LSTR_SALESFLG)
    {
        //20231130 新增分期非重車才檢核
        //20221031 新增首期付款日檢核
        if (txtPRGID.Text.ToString().Trim() == "LE3001A" && LSTR_CASESTATUS == "6" && this.drpMAINTYPE.SelectedValue == "03" && this.drpPRODCD.SelectedValue != "03")
        {
            if (txtPRENTSTDT.Text == "")
            {
                Alert("請填寫案件起租日！");
                txtPRENTSTDT.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab66Caption'));", true);
                return;
            }
            if (txtCUSTFPAYDATE.Text == "")
            {
                Alert("請填寫客戶首期繳納日！");
                txtCUSTFPAYDATE.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab66Caption'));", true);
                return;
            }
            if (txtPAYDATE.Text == "")
            {
                Alert("請填寫預計撥款日！");
                txtPAYDATE.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab66Caption'));", true);
                return;
            }
        }
        //20221031新增合約期付款日期維護驗證
        if (txtPRGID.Text.ToString().Trim() == "LE3001A" && Convert.ToString(Session["Maintain"]) != "true" && drpMAINTYPE.SelectedValue == "03" && btnPayDate.Enabled == true && LSTR_SALESFLG != "T")
        {
            Alert("合約期付款日期尚未維護！");
            LSTR_SALESFLG = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab11Caption'));", true);
            return;
        }
        string LSTR_CASEID = this.txtCASEID.Text.Trim();
        string LSTR_CNTRNO = this.txtCNTRNO.Text.Trim();
        string LSTR_CUSTID = this.txtCUSTID.Text.Trim();

        // ADD 首期繳納日若為ACH案件要檢核付款日
        if (txtPRGID.Text.ToString().Trim() == "LE3001A" && drpPAYTPE.SelectedValue.ToString() == "04")
        {
            Comus.HtmlSubmitControl LOBJ_Submit;
            string LSTR_ObjId;
            StringBuilder LSTR_StoreProcedure = new StringBuilder();
            StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
            string[] LVAR_Parameter = new string[2];
            ReturnObject<DataSet> LOBJ_ReturnObject = ACHCHECK(LSTR_CUSTID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                //Alert(LDST_Data.Tables[0].Rows[0]["ACHPAYDAY"].ToString().Trim() +" "+ txtCUSTFPAYDATE.Text.Substring(8, 2));
                if (txtCUSTFPAYDATE.Text.Substring(8, 2) != LDST_Data.Tables[0].Rows[0]["ACHPAYDAY"].ToString().Trim())
                {
                    Alert("若為ACH案件，客戶首期繳款日需與ACH扣款日相同！");
                    txtCUSTFPAYDATE.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab66Caption'));", true);
                    return;
                }
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }

        string LSTR_Status = this.lblStatus.Text;
        if (string.IsNullOrEmpty(LSTR_CNTRNO))
        {
            string LSTR_MAINTYPE = "";
            switch (drpMAINTYPE.SelectedValue)
            {
                case "01":
                    LSTR_MAINTYPE = "ML";
                    break;
                case "02":
                    LSTR_MAINTYPE = "MF";
                    break;
                case "03":
                    LSTR_MAINTYPE = "MS";
                    break;
                case "04":
                    LSTR_MAINTYPE = "MR";
                    break;
                default:
                    break;
            }
            LSTR_CNTRNO = LSTR_MAINTYPE +
                          LSTR_CASEID.Substring(0, 2) +
                          Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd")).Substring(0, 4) +
                          Itg.Community.Util.GetRepYear(DateTime.Now.ToString("yyyy/MM/dd")).Substring(5, 2) +
                          Itg.Community.Util.GetCASEIDSequence("MLMCONTRACT");
            this.txtCNTRNO.Text = LSTR_CNTRNO;
        }

        CalDISCOUNTTOTAL();

        //Alert(rptMLDCONTRACTARD.Items.Count.ToString());
        //return;
        if (rptMLDCONTRACTARD.Items.Count > 0) //UPD BY VICKY 20150311 避免GRID沒資料時錯誤
        {
            CalRACTUSLLOANS();
        }

        //LSTR_SaveType暫存為1,提交為2
        //新增撥款信息
        StringBuilder LSTR_Data = new StringBuilder();
        //=========================================================================
        LSTR_Data.Append("SP_ML3002_U01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
        LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================     
        //MLMCONTRACT
        LSTR_Data.Append("SP_ML3002_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpCOMPID.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidDEPTID.Value + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidEMPLID.Value + GSTR_TabDelimitChar);
        //Modify 20130411 By SS Gordon. Reason: 新增CR部門儲存
        LSTR_Data.Append(this.hidDEPTID.Value + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidEMPLID.Value + GSTR_TabDelimitChar);
        if (drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150123 區分是否為AR件
        {
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRTRANSCOST.Text.Trim()) + GSTR_TabDelimitChar);  //受讓/發票金額
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRFEE.Text.Trim()) + GSTR_TabDelimitChar);        //手續費收入
                                                                                                                    //Modify 20120614 By SS Gordon. Reason: 加入「佣金」
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRCOMMISSION.Text.Trim()) + GSTR_TabDelimitChar);  //佣金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtROTHERFEES.Text.Trim()) + GSTR_TabDelimitChar);   //作業費用(有發票)
                                                                                                                     //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtROTHERFEESNOTAX.Text.Trim()) + GSTR_TabDelimitChar);  //作業費用(無發票)
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRFIRSTPAY.Text.Trim()) + GSTR_TabDelimitChar);        //頭期款
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRINSURANCE.Text.Trim()) + GSTR_TabDelimitChar);      //保險金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRCREDITFEES.Text.Trim()) + GSTR_TabDelimitChar);     //徵信費
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPERBOND.Text.Trim()) + GSTR_TabDelimitChar);        //履約保證金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPURCHASEMARGIN.Text.Trim()) + GSTR_TabDelimitChar); //租購保證金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRMANAGERFEES.Text.Trim()) + GSTR_TabDelimitChar);    //帳務管理費
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.hidRACTUSLLOANS.Value.Trim()) + GSTR_TabDelimitChar);   //實貸金額
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRRESIDUALS.Text.Trim()) + GSTR_TabDelimitChar);      //殘值
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRFINANCIALFEES.Text.Trim()) + GSTR_TabDelimitChar);  //財務顧問費
            LSTR_Data.Append(this.drpEXPIREPROC.SelectedValue.Trim() + GSTR_TabDelimitChar);                            //預計期滿處理方式
            LSTR_Data.Append(this.txtEXPIREPROCDESC.Text.Trim() + GSTR_TabDelimitChar);       //預計期滿處理方式_備註
            if (chkRDEPOSITLOANS0.Checked == true || chkRDEPOSITLOANS1.Checked == true)
            {
                LSTR_Data.Append("1" + GSTR_TabDelimitChar);                        //存借款
                if (chkRDEPOSITLOANS0.Checked == true)
                {
                    LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtDEPOSITLOANSAMOUNT.Text.Trim()) + GSTR_TabDelimitChar);  //存借款
                }
                else
                {
                    LSTR_Data.Append(Itg.Community.Util.NumberToDb("-" + this.txtDEPOSITLOANSAMOUNT.Text.Trim()) + GSTR_TabDelimitChar);  //存借款金額
                }
            }
            else
            {
                LSTR_Data.Append("2" + GSTR_TabDelimitChar);   //存借款
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtDEPOSITLOANSAMOUNT.Text.Trim()) + GSTR_TabDelimitChar);  //存借款金額
            }
            LSTR_Data.Append(this.txtDSUPPLIER.Text.Trim() + GSTR_TabDelimitChar);     //供應商
            LSTR_Data.Append(this.txtSUPPLIERSALE.Text.Trim() + GSTR_TabDelimitChar);   //供應商業代ID
            LSTR_Data.Append(this.txtSUPPLIERSALENM.Text.Trim() + GSTR_TabDelimitChar);  //供應商業代姓名
            if (this.txtRCONTRACTMONTH.Text.Trim() == "")   //承作月數
            {
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append(this.txtRCONTRACTMONTH.Text.Trim() + GSTR_TabDelimitChar);
            }
            if (this.txtRPAYMONTH.Text.Trim() == "")    //幾月一付
            {
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append(this.txtRPAYMONTH.Text.Trim() + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append(this.drpRPAYTIME.Text.Trim() + GSTR_TabDelimitChar);   //付款時間
            LSTR_Data.Append(this.drpRCUSTPAYTYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);  //客戶付款方式
            LSTR_Data.Append(this.txtRPATDAYS.Text.Trim() + GSTR_TabDelimitChar);    //付款差異天數
            LSTR_Data.Append(this.txtRSUPPILERDAYS.Text.Trim() + GSTR_TabDelimitChar);  //付供應商天數
            LSTR_Data.Append(this.txtRINCOME.Text.Trim() + GSTR_TabDelimitChar);      //租金收入
            LSTR_Data.Append(this.txtROPENINGCOST.Text.Trim() + GSTR_TabDelimitChar);  //期初成本
            LSTR_Data.Append(this.txtRNETLOSS.Text.Trim() + GSTR_TabDelimitChar);      //淨損益

        }
        else
        {
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtINVOICEAMOUNT_AR.Text.Trim()) + GSTR_TabDelimitChar);  //受讓/發票金額
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //手續費收入
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //佣金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //作業費用(有發票)
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //作業費用(無發票)
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //頭期款
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //保險金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtCREDITFEES_AR.Text.Trim()) + GSTR_TabDelimitChar);     //徵信費收入
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //履約保證金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //租購保證金
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtMANAGERFEES_AR.Text.Trim()) + GSTR_TabDelimitChar);    //帳務管理收入
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.hidRACTUSLLOANS.Value.Trim()) + GSTR_TabDelimitChar);     //實貸金額
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //殘值
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtFINANCIALFEES_AR.Text.Trim()) + GSTR_TabDelimitChar);  //財務顧問收入
            LSTR_Data.Append(this.drpEXPIREPROC.SelectedValue.Trim() + GSTR_TabDelimitChar);                            //預計期滿處理方式
            LSTR_Data.Append(this.txtEXPIREPROCDESC.Text.Trim() + GSTR_TabDelimitChar);       //預計期滿處理方式_備註
            LSTR_Data.Append("" + GSTR_TabDelimitChar);   //存借款
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //存借款金額
            LSTR_Data.Append("" + GSTR_TabDelimitChar);   //供應商
            LSTR_Data.Append("" + GSTR_TabDelimitChar);   //供應商業代ID
            LSTR_Data.Append("" + GSTR_TabDelimitChar);   //供應商業代姓名
            LSTR_Data.Append(this.rptMLDCONTRACTARD.Items.Count + GSTR_TabDelimitChar);  //承作月數
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //幾月一付
            LSTR_Data.Append("" + GSTR_TabDelimitChar);   //付款時間
            LSTR_Data.Append(this.drpPAYTPE.SelectedValue.Trim() + GSTR_TabDelimitChar);   //客戶付款方式
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);    //付款差異天數
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);   //付供應商天數
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);   //租金收入
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);   //期初成本
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);   //淨損益
        }

        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPERBONDUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPURCHASEUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPERBONDNOTE")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPURCHASENOTE")[0].Trim()) + GSTR_TabDelimitChar);

        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtFIRSTPAYUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtFIRSTPAYNOTE")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtSALESPAY")[0].Trim()) + GSTR_TabDelimitChar);
        //20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日
        //if (drpMAINTYPE.SelectedValue != "04") //UPD BY VICKY 20150123 分區AR件
        //{
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);     //案件起租日
                                                                                                                 //}
                                                                                                                 //else
                                                                                                                 //{
                                                                                                                 //    LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE_AR.Text.Trim()) + GSTR_TabDelimitChar);     //案件起租日
                                                                                                                 //}
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtCUSTFPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);  //客戶首期繳納日
        if (drpMAINTYPE.SelectedValue != "04") //UPD BY VICKY 20150123 分區AR件
        {
            if (this.txtPRENTSTDT.Text.Trim() != "")  //案件起租日
            {
                DateTime LDAT_StartDate = Convert.ToDateTime(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text));  //案件起租日
                int LINT_CONTRACTMONTH = 0;
                if (drpMAINTYPE.SelectedValue != "04")
                {
                    LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);                               //承作月數
                }
                string LSTR_RENTENDT = Itg.Community.Util.GetRepYear(((LDAT_StartDate.AddMonths(LINT_CONTRACTMONTH)).AddDays(-1)).ToString());  //實際迄租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(LSTR_RENTENDT) + GSTR_TabDelimitChar);   //預計迄租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);  //實際起租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(LSTR_RENTENDT) + GSTR_TabDelimitChar);   //實際迄租日
            }
            else
            {
                LSTR_Data.Append("" + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);
                LSTR_Data.Append("" + GSTR_TabDelimitChar);
            }
        }
        else
        {
            if (rptMLDCONTRACTARD.Items.Count > 0)
            {
                string strBILLEXPIRYDT1 = ((TextBox)rptMLDCONTRACTARD.Items[0].FindControl("txtBILLEXPIRYDT_AR")).Text;
                for (int j = 0; j < rptMLDCONTRACTARD.Items.Count; j++)
                {
                    string strBILLEXPIRYDT2 = ((TextBox)rptMLDCONTRACTARD.Items[j].FindControl("txtBILLEXPIRYDT_AR")).Text;
                    if (strBILLEXPIRYDT1 != "" && strBILLEXPIRYDT2 != "")
                    {
                        DateTime d1 = Convert.ToDateTime(strBILLEXPIRYDT1);
                        DateTime d2 = Convert.ToDateTime(strBILLEXPIRYDT2);
                        if (d1 < d2) strBILLEXPIRYDT1 = strBILLEXPIRYDT2;
                    }
                }

                LSTR_Data.Append(Itg.Community.Util.GetADYear(strBILLEXPIRYDT1.Trim()) + GSTR_TabDelimitChar);           //預計迄租日 
                                                                                                                         //20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日
                                                                                                                         //LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE_AR.Text.Trim()) + GSTR_TabDelimitChar);   //實際起租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);   //實際起租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(strBILLEXPIRYDT1.Trim()) + GSTR_TabDelimitChar);          //實際迄租日 
            }
            else  //UPD BY VICKY 20150311 若AR明細GRID無資料時
            {
                LSTR_Data.Append("" + GSTR_TabDelimitChar);           //預計迄租日 
                                                                      //20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日
                                                                      //LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE_AR.Text.Trim()) + GSTR_TabDelimitChar);   //實際起租日
                LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);   //實際起租日
                LSTR_Data.Append("" + GSTR_TabDelimitChar);          //實際迄租日
            }
        }
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtDISCOUNTTOTAL")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtDISCOUNTTAX")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtACTUALLYAMOUNT")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);
        if (chkOneMLDCASETARGETSTR.Checked == true)
        {
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(LSTR_CASESTATUS + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRRECOVERTEST.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRCAPITALCOST.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRIRR.Text + GSTR_TabDelimitChar);

        //if (Convert.ToDouble(this.txtRIRR.Text) != 0)
        if (Convert.ToDouble(this.txtRIRR.Text) != 0 && this.drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150128 AR件帶0
        {
            double LINT_IRR = IRR_Cal_ForPPMT();
            LSTR_Data.Append(LINT_IRR.ToString("0.000") + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("0.000" + GSTR_TabDelimitChar);
        }
        if (Convert.ToDouble(this.txtRIRR.Text) != 0)
        {
            double LINT_RIRR_AR = IRR_Cal_ForPPMT_AR();
            LSTR_Data.Append(LINT_RIRR_AR.ToString("0.000") + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("0.000" + GSTR_TabDelimitChar);
        }

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        LSTR_Data.Append(this.txtRNPV0.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRNPVRATECOST0.Text + GSTR_TabDelimitChar);

        LSTR_Data.Append(this.txtRNPV.Text + GSTR_TabDelimitChar);
        //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
        LSTR_Data.Append(this.txtRNPVRATECOST.Text + GSTR_TabDelimitChar);
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        LSTR_Data.Append(this.txtRNPV2.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtRNPVRATECOST2.Text + GSTR_TabDelimitChar);

        if (drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150123 分別是否為AR件
        {
            //Modify 20120606 By SS Gordon. Reason: 於撥款維護的「承作內容」，新增「變更緣由」、「相關附件」欄位
            LSTR_Data.Append(this.txtCHANGREASON.Text + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRELATTACHMENT.Text + GSTR_TabDelimitChar);
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            if (this.txtRNOINSURANCEFLG.Checked == true)
            {
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);
            }
        }
        else
        {
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
        }

        //Modify 20131002 By SS Steven. Reason: 在合約主檔需要新增一個欄位，用來區分業代確認，待點選確認後，再把業代確認設為Y
        LSTR_Data.Append(LSTR_SALESFLG + GSTR_TabDelimitChar);

        //UPD BY VICKY 20150123 合約主檔新增欄位[墊款息][執款成數]
        if (drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150123 分別是否為AR件
        {
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("0") + GSTR_TabDelimitChar);  //墊款息
            LSTR_Data.Append(Itg.Community.Util.NumberToDb("100") + GSTR_TabDelimitChar);  //墊款成數
        }
        else
        {
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtADVANCESINTEREST_AR.Text.Trim()) + GSTR_TabDelimitChar);  //墊款息
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.drpADVANCESPERCENT_AR.SelectedValue) + GSTR_TabDelimitChar);  //墊款成數
        }

        //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(txtFEEAMT.Text) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(txtPREPAYWOFFAMT.Text) + GSTR_TabDelimitChar);

        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================     
        if (drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150126 AR案件不計
        {
            //MLDCONTRACTINST
            //第一行
            LSTR_Data.Append("SP_ML3002_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINST", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRENDPAY1.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPAL1.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPALTAX1.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第二行
            LSTR_Data.Append("SP_ML3002_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINST", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRSTARTPAY2.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRENDPAY2.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPAL2.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPALTAX2.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第三行
            LSTR_Data.Append("SP_ML3002_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINST", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRSTARTPAY3.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRENDPAY3.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPAL3.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPALTAX3.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //第四行
            LSTR_Data.Append("SP_ML3002_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINST", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRSTARTPAY4.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtRENDPAY4.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPAL4.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.NumberToDb(this.txtRPRINCIPALTAX4.Text.Trim()) + GSTR_TabDelimitChar);
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
        //MLDCONTRACTTARGET標的物主檔
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            int LINT_Num = 0;
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML3002_I03" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_TARGETIDID = ((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim();
                if (LSTR_TARGETIDID == "" || LSTR_Status == "新增")
                {
                    string LSTR_GUID = Itg.Community.Util.GetIDSequence("MLDCONTRACTTARGET", "14");
                    ((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value = LSTR_GUID;
                    LSTR_Data.Append(LSTR_GUID + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_TARGETIDID + GSTR_TabDelimitChar);
                }
                LINT_Num += 1;
                string LSTR_UNITID = LSTR_CNTRNO + (LINT_Num.ToString()).PadLeft(3, '0');
                LSTR_Data.Append(LSTR_UNITID + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETNAME")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0] + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDCASETARGET.Items[i].FindControl("drpTARGETSTATUS")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMODELNO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETMACHINENO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtSUPPLIERID")).Text + GSTR_TabDelimitChar);
                string LSTR_TARGETPRICE = Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICE")).Text);
                LSTR_Data.Append(LSTR_TARGETPRICE + GSTR_TabDelimitChar);
                string LSTR_TARGETPRICENOTAX = Itg.Community.Util.NumberToDb(((TextBox)rptMLDCASETARGET.Items[i].FindControl("txtTARGETPRICENOTAX")).Text);
                LSTR_Data.Append(LSTR_TARGETPRICENOTAX + GSTR_TabDelimitChar);
                /*
                if (LSTR_TARGETPRICE == "" || LSTR_TARGETPRICE == "0") {
                  LSTR_Data.Append(LSTR_TARGETPRICE + GSTR_TabDelimitChar);
                } else {
                  LSTR_Data.Append((Convert.ToDouble(LSTR_TARGETPRICE) / 1.05).ToString("0") + GSTR_TabDelimitChar);
                }*/
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                LSTR_Data.Append("01" + GSTR_TabDelimitChar);

                //Modify 20131002 By SS Steven. Reason: 在標的物頁籤中，標的物的GRID增加製造廠商，廠牌，單位，數量。(置於耐用年限之後)
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
        //MLDCONTRACTTARGET標的物子檔
        if (rptMLDCASETARGET.Items.Count > 0)
        {
            //MLDCONTRACTTARGETSTR
            int LINT_SNum = 0;
            for (int i = 0; i < this.rptMLDCASETARGET.Items.Count; i++)
            {
                if (((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML3002_I04" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCASETARGET.Items[i].FindControl("hidTARGETID")).Value.Trim() + GSTR_TabDelimitChar);
                if (chkOneMLDCASETARGETSTR.Checked == false)
                {
                    LINT_SNum = i;
                }
                //LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTTARGETSTR", "14") + GSTR_TabDelimitChar);
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
        //MLDCONTRACTAR撥款案件AR案件資料檔
        if (this.chkAr1.Checked == true)
        {
            //MLDCONTRACTAR
            LSTR_Data.Append("SP_ML3002_I05" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBILLNOTECUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBILLNOTECUST.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtDEPOSITBANK.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtACCOUNT.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDORSERID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtENDORSER.Text.Trim() + GSTR_TabDelimitChar);
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
        //MLDCONTRACTINV撥款案件發票明細檔
        if (rptMLDCONTRACTINV.Items.Count > 0)
        {
            //MLDCONTRACTINV
            for (int i = 0; i < this.rptMLDCONTRACTINV.Items.Count; i++)
            {
                //Modify 20120717 By SS Gordon. Reason: 修改當案件為銀行件時，進項發票的憑證號碼與發票日期可以為空白.
                //if (this.drpMAINTYPE.SelectedValue != "04") {
                if (this.drpMAINTYPE.SelectedValue != "04" && this.drpSOURCETYPE.SelectedValue != "02")
                {
                    if (((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text.Trim() == "")
                    {
                        continue;
                    }
                }
                LSTR_Data.Append("SP_ML3002_I06" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_BILLNOTEID = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidBILLNOTEID")).Value.Trim();
                if (LSTR_BILLNOTEID == "" || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINV", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_BILLNOTEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPSEQ")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidPAYBANK")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRV_NAME")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRVACNT")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtHIREPURUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtACTUALLYAMOUNT")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDNOTE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPURCHASENOTE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYNOTE")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtTAX")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text) + GSTR_TabDelimitChar);

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
        //MLDCONTRACTINVD撥款案件發票明細檔
        if (rptMLDCONTRACTINV.Items.Count > 0)
        {
            //MLDCONTRACTINVD
            for (int i = 0; i < this.rptMLDCONTRACTINVD.Items.Count; i++)
            {
                if (((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text.Trim() == "")
                {
                    continue;
                }
                if (((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text.Trim() == "0")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML3002_I07" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_DISCOUNTINVOICEID = ((HiddenField)rptMLDCONTRACTINVD.Items[i].FindControl("hidDISCOUNTINVOICEID")).Value.Trim();
                if (LSTR_DISCOUNTINVOICEID == "" || LSTR_Status == "新增")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINVD", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_DISCOUNTINVOICEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text) + GSTR_TabDelimitChar);

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
        //20231130 新增專案名稱
        LSTR_Data.Append("SP_ML1002_I19" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpPROJECT.SelectedItem.Text.Trim());
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
                LSTR_Data.Append("SP_ML3002_I09" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
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



        //Modify 20120313 By SS Steven. Reason: 新增SP儲存發票聯絡人及案件聯絡人資訊
        //Modify 20120516 By SS Steven. Reason: 撥款確認所帶的值會有>7的情況(8:不用徵信核准)
        //if (LSTR_CASESTATUS == "7")
        if (Convert.ToInt16(LSTR_CASESTATUS) >= 7)
        {
            if (LINT_ConNum > 0)
            {
                //案件聯絡人
                for (int rowCon = 0; rowCon < LINT_ConNum; rowCon++)
                {
                    LSTR_Data.Append("SP_ML3002_I11" + GSTR_ColDelimitChar);
                    LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
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
        }

        //=========================================================================
        //資租要計算本攤表    
        //MLDCONTRACTCASHFLOW
        Decimal LDCE_TransCost = 0;
        int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        if (drpMAINTYPE.SelectedValue == "02")
        {

            //  20130726 Mark By Sean Reason: 資租現流表改寫在資租攤還表之後
            //==============================================================
            //for (var i = 0; i < LSTR_RowCount; i++) {
            //  LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
            //}
            //if (Convert.ToDouble(this.txtRIRR.Text) != 0 && LDCE_TransCost != 0) {
            //  //期數
            //  int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
            //  Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
            //  double LDBL_IRR = IRR_Cal_ForPPMT();
            //  LDBL_IRR = Convert.ToDouble(LDBL_IRR.ToString("0.0000000000"));
            //  LDBL_VALUE = PPMT_Cal(LDBL_IRR);
            //  for (int i = 0; i < LDBL_VALUE.GetUpperBound(0) + 1; i++) {
            //    LSTR_Data.Append("SP_ML3002_I08" + GSTR_ColDelimitChar);
            //    LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTCASHFLOW", "14") + GSTR_TabDelimitChar);
            //    //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
            //    LSTR_Data.Append(LDBL_VALUE[i][0] + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(LDBL_VALUE[i][2] + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(LDBL_VALUE[i][3] + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(LDBL_VALUE[i][4] + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(GSTR_U_SYSDT);
            //    LSTR_Data.Append(GSTR_ColDelimitChar);
            //    LSTR_Data.Append(GSTR_RowDelimitChar);
            //  }
            //}
            //==============================================================

        }
        else
        {
            if (drpMAINTYPE.SelectedValue != "04")
            {
                if (Convert.ToDouble(this.txtRIRR.Text) != 0)
                {
                    //期數
                    int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
                    Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
                    LDBL_VALUE = PPMT_Cal2();
                    for (int i = 0; i < LDBL_VALUE.GetUpperBound(0) + 1; i++)
                    {
                        LSTR_Data.Append("SP_ML3002_I08" + GSTR_ColDelimitChar);
                        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                        LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTCASHFLOW", "14") + GSTR_TabDelimitChar);
                        //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
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
            }
        }
        //=========================================================================
        //計算本攤表    
        //MLDCONTRACTAMORTIZE
        LDCE_TransCost = 0;
        LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
        }
        if (drpMAINTYPE.SelectedValue != "04")  //UPD BY VICKY 20150126 AR件不計本攤表
        {
            if (Convert.ToDouble(this.txtRIRR.Text) != 0 && LDCE_TransCost != 0)
            {
                //期數
                int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
                Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
                double LDBL_IRR = 0;
                if (this.drpMAINTYPE.SelectedValue == "04")
                {
                    LDBL_IRR = IRR_Cal_ForPPMT_AR();
                    LDBL_IRR = Convert.ToDouble(LDBL_IRR.ToString("0.000"));
                    LDBL_VALUE = PPMT_Cal_AR(LDBL_IRR);
                }
                //20130709 UPD BY BRENT Reason.攤提表展開時增加反推IRR邏輯
                else //if (this.drpMAINTYPE.SelectedValue == "02") //20161110 ADD BY SS ADAM REASON.分期也走多段式
                {
                    LDBL_IRR = IRR_Cal_ForPPMT();
                    LDBL_IRR = Convert.ToDouble(ReGetIRR(LDBL_IRR.ToString("0.000")));
                    LDBL_VALUE = PPMT_Cal(LDBL_IRR);
                }
                //else //20161110 ADD BY SS ADAM REASON.分期也走多段式
                //{
                //    LDBL_IRR = IRR_Cal_ForPPMT();
                //    LDBL_IRR = Convert.ToDouble(LDBL_IRR.ToString("0.000"));
                //    LDBL_VALUE = PPMT_Cal(LDBL_IRR);
                //}
                for (int i = 0; i < LDBL_VALUE.GetUpperBound(0) + 1; i++)
                {
                    LSTR_Data.Append("SP_ML3002_I10" + GSTR_ColDelimitChar);
                    LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTAMORTIZE", "14") + GSTR_TabDelimitChar);
                    DateTime LDAT_StartDate;
                    if (this.txtPRENTSTDT.Text == "")
                    {
                        LDAT_StartDate = DateTime.Now;
                    }
                    else
                    {
                        LDAT_StartDate = Convert.ToDateTime(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text));
                    }
                    string LSTR_RENTENDT = Itg.Community.Util.GetRepYear(((LDAT_StartDate.AddMonths(i))).ToString());
                    LSTR_Data.Append(LSTR_RENTENDT + GSTR_TabDelimitChar);//日期
                                                                          //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
                    LSTR_Data.Append(LDBL_VALUE[i][0] + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LDBL_VALUE[i][1] + GSTR_TabDelimitChar);
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

                //  20130726 Mark By Sean Reason: 資租現流表改寫在資租攤還表之後
                //==============================================================
                if (drpMAINTYPE.SelectedValue == "02")
                {
                    if (Convert.ToDouble(this.txtRIRR.Text) != 0 && LDCE_TransCost != 0)
                    {
                        //期數
                        for (int i = 0; i < LDBL_VALUE.GetUpperBound(0) + 1; i++)
                        {
                            LSTR_Data.Append("SP_ML3002_I08" + GSTR_ColDelimitChar);
                            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTCASHFLOW", "14") + GSTR_TabDelimitChar);
                            //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
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
                }
                //==============================================================

            }
        }
        //=========================================================================
        //Modify 20130814 BY CHRIS FU Reason: 新增若為新增時將TEMPTABLE的資料存人正式TABLE
        if (lblStatus.Text == "新增")
        {
            //Alert("SP_ML1002_I17");
            LSTR_Data.Append("SP_ML1002_I17" + GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
            //LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CUSTID);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

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
        if (LSTR_CASESTATUS == "7" || LSTR_CASESTATUS == "8")
        {
            //MLVERIFY
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("6" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("2");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);

            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_CASESTATUS + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("2");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //=========================================================================
        //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
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

                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_MOVABLEID = ((HiddenField)rptMLDCASEMOVABLE.Items[i].FindControl("hidMOVABLEID")).Value.ToString();
                //20131125 ADD BY SS ADAM Reason.修正3001A修改造成新增資料的問題
                //if (string.IsNullOrEmpty(LSTR_MOVABLEID) || LSTR_Status == "新增")
                if (string.IsNullOrEmpty(LSTR_MOVABLEID))
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
        //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
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
                //20131125 ADD BY SS ADAM Reason.修正3001A修改造成新增資料的問題
                //if (string.IsNullOrEmpty(LSTR_GRTID) || LSTR_Status == "新增")
                if (string.IsNullOrEmpty(LSTR_GRTID))
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
        //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
        //                              3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
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
                LSTR_Data.Append(((HiddenField)rptMLDCASEIMMOVABLE.Items[i].FindControl("hidIMMOVABLEID")).Value.ToString() + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtHUMANRIGHTS")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtSETPRICE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtCREDITOR")).Text + GSTR_TabDelimitChar);
                //20131210 Modify by SEAN. Reason:修正不動產項次取號問題
                //LSTR_Data.Append(((DropDownList)rptMLDHUMANRIGHTS.Items[i].FindControl("drpMLDCASEIMMOVABLE")).SelectedValue + GSTR_TabDelimitChar);
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


        //=========================================================================
        //Modify 20150123 By SS Vicky. Reason: 1.加入MLDCONTRACTARD存檔功能
        //                              2.PRGID若是ML3001A，[帳號][票據號碼][買受人]則為非必填，反之則為必填。
        //3002_撥款案件AR明細檔
        //MLDCONTRACTARD
        if (rptMLDCONTRACTARD.Items.Count > 0 && drpMAINTYPE.SelectedValue == "04")
        {
            for (int i = 0; i < this.rptMLDCONTRACTARD.Items.Count; i++)
            {

                //if (((HiddenField)rptMLDCONTRACTARD.Items[i].FindControl("hidMLDCONTRACTARDID")).Value.Trim() == "")
                //{
                //    continue;
                //}

                LSTR_Data.Append("SP_ML3002_I12" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_MLDCONTRACTARDID = ((HiddenField)rptMLDCONTRACTARD.Items[i].FindControl("hidMLDCONTRACTARDID")).Value.Trim();
                if (LSTR_MLDCONTRACTARDID == "")
                {
                    LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_MLDCONTRACTARDID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((DropDownList)rptMLDCONTRACTARD.Items[i].FindControl("drpPAYTYPE_AR")).SelectedValue.ToString() + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtDRAWER_AR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtDEPOSITID_AR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtACCOUNT_AR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLNO_AR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBUYER_AR")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLEXPIRYDT_AR")).Text).Replace("/", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text).Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text).Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESAMT_AR")).Text).Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text).Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text).Replace(",", "") + GSTR_TabDelimitChar);
                if (((CheckBox)rptMLDCONTRACTARD.Items[i].FindControl("chkENDORSEMENTFLG")).Checked)
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
            }
        }
        //=========================================================================

        //Alert("rptMLDCONTRACTARD NOT");
        //=========================================================================
        //Modify 20150123 By SS Vicky. Reason: 1.加入MLDCONTRACTARD存檔功能
        //                              2.PRGID若是ML3001A，[帳號][票據號碼][買受人]則為非必填，反之則為必填。
        //3002_撥款案件AR明細檔
        //MLDCONTRACTARD
        if (rptMLDCONTRACTARBINV.Items.Count > 0 && drpMAINTYPE.SelectedValue == "04")
        {
            for (int i = 0; i < this.rptMLDCONTRACTARBINV.Items.Count; i++)
            {
                //if (((HiddenField)rptMLDCONTRACTARBINV.Items[i].FindControl("hidMLDCONTRACTARBINVID")).Value.Trim() == "")
                //{
                //    continue;
                //}

                LSTR_Data.Append("SP_ML3002_I13" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_MLDCONTRACTARBINVID = ((HiddenField)rptMLDCONTRACTARBINV.Items[i].FindControl("hidMLDCONTRACTARBINVID")).Value.Trim();
                if (LSTR_MLDCONTRACTARBINVID == "")
                {
                    LSTR_Data.Append("0" + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_MLDCONTRACTARBINVID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtBUYER_INV")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtUNIMNO_INV")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVNO_INV")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVDT_INV")).Text.Replace("/", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVAMT_INV")).Text).Replace(",", "") + GSTR_TabDelimitChar);


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


        //=========================================================================
        //Modify 20150126 By SS Vicky. Reason: 1.加入AR現流表存檔
        //3002_撥款案件現金流量明細檔_AR
        //MLDCONTRACTARCASHFLOW
        if (rptMLDCONTRACTARD.Items.Count > 0 && drpMAINTYPE.SelectedValue == "04")
        {
            for (int i = 0; i < this.rptMLDCONTRACTARD.Items.Count; i++)
            {
                LSTR_Data.Append("SP_ML3002_I14" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);

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

        //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
        if (rptMLDASSPAYMF.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDASSPAYMF.Items.Count; i++)
            {
                LSTR_Data.Append("SP_ML3002_I15" + GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hdSEQNO")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEE")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEENM")).Text + GSTR_TabDelimitChar);
               //20240626 修正匯款項次第二筆會帶空白的問題
                if (((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidSUPSEQ")).Value=="")
                {
                    //若空白重新抓一次
                    ((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidSUPSEQ")).Value = ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpSUPSEQ")).SelectedValue;
                }
                LSTR_Data.Append(((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidSUPSEQ")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtTRANSBANK")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtSUBBANK")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtACCNM")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtACC")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtTRANSAMT")).Text.Replace(",", ""));
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
                //Alert(((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidSUPSEQ")).Value);
            }
        }

        if (rptMLDFEEINCOME1.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDFEEINCOME1.Items.Count; i++)
            {
                LSTR_Data.Append("SP_ML3002_I16" + GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDFEEINCOME1.Items[i].FindControl("hdSEQNO")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append("01" + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtUNIMNO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtTARGET")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtFEEAMT")).Text.Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpPAYTYPE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpCUSTTYPE")).SelectedValue);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }
        if (rptMLDFEEINCOME2.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDFEEINCOME2.Items.Count; i++)
            {
                LSTR_Data.Append("SP_ML3002_I16" + GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDFEEINCOME2.Items[i].FindControl("hdSEQNO")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append("02" + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtUNIMNO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtTARGET")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtFEEAMT")).Text.Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpPAYTYPE")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpCUSTTYPE")).SelectedValue);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);
            }
        }

        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");

        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = SaveContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab11Caption";
                if (LSTR_CASESTATUS == "6")
                {
                    //20221031 LE3001A新增驗證
                    if (txtPRGID.Text.ToString().Trim() == "LE3001A" && Convert.ToString(Session["Maintain"]) == "true" && LSTR_SALESFLG == "T") { }
                    else if (LSTR_SALESFLG == "Y" && txtPRGID.Text.ToString().Trim() == "LE3001A")
                    {
                        Alert("確認成功！");
                        btnSURE.Enabled = false;

                        //20150323 ADD BY SS ADAM REASON.存檔完成後，暫存跟確認都要反灰
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        Alert("暫存成功！");
                    }
                    this.lblStatus.Text = "修改";
                    this.btnInsert.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnSelect.Enabled = true;
                    this.btnContractPrint.Enabled = true;
                    this.btnListPrint.Enabled = true;
                    //Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕
                    this.btnChangePrint.Enabled = true;
                    //Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
                    this.btnRej.Enabled = true;
                    //Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕
                    this.btnRecheck.Enabled = true;
                    //20221031新增驗證
                    if (Convert.ToString(Session["Maintain"]) == "true")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Caption_onclick($('fraTab11Caption'));", true);
                    }
                    else
                    {
                        RegisterScript("window_onload();");
                    }
                }
                else
                {
                    Alert("撥款申請完成！");
                    this.btnContractPrint.Enabled = true;
                    this.btnListPrint.Enabled = true;
                    //Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕
                    this.btnChangePrint.Enabled = true;
                    //Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
                    this.btnRej.Enabled = false;
                    //Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕
                    //20160331 ADD BY SS ADAM REASON.撥款申請完成就不能再列印關係人檢核
                    this.btnRecheck.Enabled = false;

                    this.btnInsert.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnSelect.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.btnSURE.Enabled = false;
                    this.btnSubmit.Enabled = false;
                    this.btnIRR.Enabled = false;
                    this.lblStatus.Text = "";

                    PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);
                    Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
                    Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
                    Itg.Community.Util.DisabledRepeater(rptMLDCONTRACTINV, "btnSUPPLIERID");
                    RegisterScript("SetDisabled('div_Info', '" + btnIRR.ClientID + "','');window_onload();");
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
    private ReturnObject<object> SaveContractInfo(string LSTR_Data)
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
    protected void btnContractQue_Click(object sender, EventArgs e)
    {
        string LSTR_Type = this.hidCONTRACT.Value.Substring(0, 1);
        string LSTR_CONTACTMsg = this.hidCONTRACT.Value.Substring(1);
        string LSTR_CUSTID = LSTR_CONTACTMsg.Split(';')[0];
        string LSTR_CASEID = LSTR_CONTACTMsg.Split(';')[1];
        string LSTR_CONTID = LSTR_CONTACTMsg.Split(';')[2];
        if (LSTR_Type == "U")
        {
            this.lblStatus.Text = "修改";
            this.btnSave.Enabled = true;
            //john 2013/10/14 修改按鈕權限設定
            this.btnSURE.Enabled = true;
            if (GSTR_A_PRGID != "LE3001A")
                btnBackModify.Enabled = true;
            //20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
            this.btnSubmit.Enabled = true;

            this.btnInsert.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnSelect.Enabled = false;
            this.btnContractPrint.Enabled = true;
            this.btnListPrint.Enabled = true;
            this.drpPROJECT.Enabled = false;

            //Modify 20120808 By SS Maureen. Reason: 新增授信變更書列印按鈕
            this.btnChangePrint.Enabled = true;
            //Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
            this.btnRej.Enabled = true;
            //Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕
            this.btnRecheck.Enabled = true;

            this.btnC1.Disabled = false;
            this.btnC2.Disabled = false;
            this.btnC3.Disabled = false;

            PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CONTID);
            if (this.hdnCASESTATUS.Value == "6")
            {
                RegisterScript("window_onload();");
            }
            else if (this.hdnCASESTATUS.Value == "7" || this.hdnCASESTATUS.Value == "8")
            {
                RegisterScript("SetDisabled('div_Info', '" + btnContractPrint.ClientID + "','" + btnInsert.ClientID + "," + btnUpdate.ClientID + "," + btnSelect.ClientID + "," + txtPRENTSTDT.ClientID + "," + txtCUSTFPAYDATE.ClientID + "," + txtPAYDATE.ClientID + "');window_onload();SetModify();");
                Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
                Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
            }
            DisabledRPRINCIPAL();
            CalDISCOUNTTOTAL();

            //20150315 ADD BY SS ADAM REASON.調整為可以自行輸入總受讓金額
            //CalINVOICEAMOUNT_AR(); //UPD BY VICKY 20150128 查詢後先計算一次總受讓金額
            //20150326 ADD BY SS ADAM REASON.增加計算撥款金額
            CalPAYAMOUNT_AR();
            //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕
            btINSURANCE.Enabled = true;

        }
        else
        {
            this.lblStatus.Text = "查詢";
            this.btnInsert.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnSelect.Enabled = true;
            this.btnContractPrint.Enabled = true;
            this.btnListPrint.Enabled = true;
            this.btnIRR.Enabled = false;
            //Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕
            this.btnRecheck.Enabled = true;
            PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CONTID);
            RegisterScript("SetDisabled('div_Info', '" + btnIRR.ClientID + "','" + btnInsert.ClientID + "," + btnUpdate.ClientID + "," + btnSelect.ClientID + "');window_onload();");
            CalDISCOUNTTOTAL();
            //20150315 ADD BY SS ADAM REASON.調整為可以自行輸入總受讓金額
            //CalINVOICEAMOUNT_AR(); //UPD BY VICKY 20150128 查詢後先計算一次總受讓金額
            //20150326 ADD BY SS ADAM REASON.增加計算撥款金額
            CalPAYAMOUNT_AR();
            Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
            Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
            //Itg.Community.Util.DisabledRepeater(rptMLDCONTRACTINV, "btnSUPPLIERID");
        }
        this.UpdatePanel1.Update();

        //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕
        btINSURANCE.Enabled = true;
    }
    protected void btnCaseQue_Click(object sender, EventArgs e)
    {
        string LSTR_CASEMsg = this.hidCONTRACT.Value;
        string LSTR_CUSTID = LSTR_CASEMsg.Split(';')[0];
        string LSTR_CASEID = LSTR_CASEMsg.Split(';')[1];

        //PageDataBind(LSTR_CUSTID, LSTR_CASEID);
        this.lblStatus.Text = "新增";
        RegisterScript("window_onload();");
        this.btnSave.Enabled = true;
        this.btnSURE.Enabled = true;
        //20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
        this.btnSubmit.Enabled = true;

        this.btnInsert.Enabled = false;
        this.btnUpdate.Enabled = false;
        this.btnSelect.Enabled = false;
        this.btnContractPrint.Enabled = false;
        //Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
        this.btnRej.Enabled = true;
        //Modify 20121122 By SS Maureen. Reason: 新增關係人檢核按鈕
        this.btnRecheck.Enabled = true;

        this.btnC1.Disabled = false;
        this.btnC2.Disabled = false;
        this.btnC3.Disabled = false;

        PageDataBind(LSTR_CUSTID, LSTR_CASEID);
        //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
        this.txtACTUALLYAMOUNT.Text = (Convert.ToDouble("0" + txtRRTRANSCOST.Text) -
                                       Convert.ToDouble("0" + txtRRFIRSTPAY.Text) -
                                       //Convert.ToDouble("0" + txtRRPURCHASEMARGIN.Text)).ToString();
                                       Convert.ToDouble("0" + txtRRPURCHASEMARGIN.Text) -
                                       Convert.ToDouble("0" + txtFEEAMT.Text) -
                                       Convert.ToDouble("0" + txtPREPAYWOFFAMT.Text)).ToString();
        DisabledRPRINCIPAL();
        this.UpdatePanel1.Update();

        //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕
        btINSURANCE.Enabled = true;
    }
    private void GetMLDCONTRACTARBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCONTRACTAR_Data);
            //20130626 ADD BY ADAM Reason.把程式mark掉，原因此table根本無保險異常欄位。
            //Modify 20130326 By SS Eric    Reason:新增保險異常欄位
            //if (LOBJ_Data.Rows[0]["NOINSURANCEFLG"].ToString() == "Y")
            //{
            //    this.txtNOINSURANCEFLG.Checked = true;
            //}
            //else
            //{
            //    this.txtNOINSURANCEFLG.Checked = false;
            //}
        }
    }
    private void PageDataBind(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
    {
        if (!string.IsNullOrEmpty(LSTR_CUSTID) && !string.IsNullOrEmpty(LSTR_CASEID) && !string.IsNullOrEmpty(LSTR_CONTID))
        {
            try
            {
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

                    //Modify 20130510 By SS Brent. Reason:加入附追索權下拉選單
                    drpRECOURSE.SelectedValue = LDST_Data.Tables[2].Rows[0]["RECOURSE"].ToString().Trim();

                    //Modify 20150310 By SS VICKY    Reason:新增「專案別」下拉選單
                    drpPROJCD.SelectedValue = LDST_Data.Tables[2].Rows[0]["PROJCD"].ToString().Trim();

                    this.UpdatePanelRECOURSE.Update();

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
                        GetMLDCASEINSTDBind(LDST_Data.Tables[5], false);
                        //
                        this.txtBILLNOTECUSTID.Enabled = false;
                        this.txtBILLNOTECUST.Enabled = false;
                        this.txtDEPOSITBANKS.Enabled = false;
                        this.txtACCOUNT.Enabled = false;
                        this.txtENDORSERID.Enabled = false;
                        this.txtENDORSER.Enabled = false;
                        this.btnBank.Disabled = true;
                    }
                    if (LSTR_MAINTYPEID == "01")
                    {
                        this.txtRPURCHASEMARGIN.Enabled = true;
                    }
                    else
                    {
                        this.txtRPURCHASEMARGIN.Enabled = false;
                        this.txtRPURCHASEMARGIN.Text = "0";
                    }
                    if (LSTR_MAINTYPEID == "04")
                    {
                        this.txtRFIRSTPAY.Enabled = false;
                        this.txtRFIRSTPAY.Text = "0";
                    }
                    else
                    {
                        this.txtRFIRSTPAY.Enabled = true;
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
                    //承作內容
                    GetMLMCONTRACTBind(LDST_Data.Tables[13]);
                    //標的物
                    GetMLDCASETARGETBind(LDST_Data.Tables[12]);
                    //分期明細
                    GetMLDCONTRACTINSTBind(LDST_Data.Tables[14]);
                    //AR
                    GetMLDCONTRACTARBind(LDST_Data.Tables[15]);
                    //MLDCONTRACTINV
                    GetMLDCONTRACTINVBind(LDST_Data.Tables[16]);
                    //MLDCONTRACTINVD
                    GetMLDCONTRACTINVDBind(LDST_Data.Tables[17]);

                    //MLDCONTRACTARD  UPD BY VICKY 20150128
                    GetMLDCONTRACTARDBind(LDST_Data.Tables[18]);
                    //MLDCONTRACTARBINV  UPD BY VICKY 20150128
                    GetMLDCONTRACTARBINVBind(LDST_Data.Tables[19]);

                    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
                    GetMLDASSPAYMFBind(LDST_Data.Tables[20]);
                    GetMLDFEEINCOME1Bind(LDST_Data.Tables[21]);
                    GetMLDFEEINCOME2Bind(LDST_Data.Tables[22]);
                    GetMLDPREPAYWOFFBind(LDST_Data.Tables[23]);

                    //20231130ADD選定專案
                    btnPROJECT_Click(null, null);
                    drpPROJECT.SelectedValue = LDST_Data.Tables[24].Rows[0]["PROJID"].ToString().Trim();
                    hidPROJECT.SelectedValue = LDST_Data.Tables[24].Rows[0]["DISCAMT"].ToString().Trim();

                    if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
                    {
                        //營租事物機 和 資租事物機 資金成本要固定為 5%
                        //其他承作類型 為7%
                        //this.txtRCAPITALCOST.Text = "5";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
                    {
                        //this.txtRCAPITALCOST.Text = "5";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    else
                    {
                        //this.txtRCAPITALCOST.Text = "7";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    //營租&資租的事務機且標的物為單一供應商
                    if (LSTR_MAINTYPEID == "01" || LSTR_MAINTYPEID == "02")
                    {
                        if (drpSUBTYPE.SelectedValue == "01")
                        {
                            if (LDST_Data.Tables[12].Rows.Count > 0)
                            {
                                this.chkRDEPOSITLOANS0.Enabled = true;
                                this.chkRDEPOSITLOANS1.Enabled = true;
                                this.chkRDEPOSITLOANS2.Enabled = true;
                                if (this.chkRDEPOSITLOANS1.Checked)
                                {
                                    this.txtDEPOSITLOANSAMOUNT.Enabled = true;
                                    this.txtSUPPLIERSALE.Enabled = true;
                                    this.txtSUPPLIERSALENM.Enabled = true;
                                }
                                else
                                {
                                    this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                                    this.txtSUPPLIERSALE.Enabled = false;
                                    this.txtSUPPLIERSALENM.Enabled = false;
                                }
                            }
                            else
                            {
                                this.chkRDEPOSITLOANS0.Checked = false;
                                this.chkRDEPOSITLOANS1.Checked = false;
                                this.chkRDEPOSITLOANS2.Checked = true;
                                this.txtDEPOSITLOANSAMOUNT.Text = "0";
                                this.txtSUPPLIERSALE.Text = "";
                                this.txtSUPPLIERSALENM.Text = "";

                                this.chkRDEPOSITLOANS0.Enabled = false;
                                this.chkRDEPOSITLOANS1.Enabled = false;
                                this.chkRDEPOSITLOANS2.Enabled = false;
                                this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                                this.txtSUPPLIERSALE.Enabled = false;
                                this.txtSUPPLIERSALENM.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.chkRDEPOSITLOANS0.Checked = false;
                        this.chkRDEPOSITLOANS1.Checked = false;
                        this.chkRDEPOSITLOANS2.Checked = true;
                        this.txtDEPOSITLOANSAMOUNT.Text = "0";
                        this.txtSUPPLIERSALE.Text = "";
                        this.txtSUPPLIERSALENM.Text = "";

                        this.chkRDEPOSITLOANS0.Enabled = false;
                        this.chkRDEPOSITLOANS1.Enabled = false;
                        this.chkRDEPOSITLOANS2.Enabled = false;
                        this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                        this.txtSUPPLIERSALE.Enabled = false;
                        this.txtSUPPLIERSALENM.Enabled = false;
                    }
                    this.txtBUSINESS.Width = 500;
                    this.btnIRR.Enabled = true;

                    //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
                    hidMAINTYPE.Value = drpMAINTYPE.SelectedValue;
                    hidSUBTYPE.Value = drpSUBTYPE.SelectedValue;
                    //hidTARGETPRICE.Value = txtTRANSCOST.Text;
                    hidTARGETPRICE.Value = txtRTRANSCOST.Text;  //20130925 Modify by SS Vicky 改為用[受讓/發票金額]
                    if (rptMLDCASETARGET.Items.Count > 0)
                    {
                        hidTARGETTYPE.Value = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.ToString();
                    }
                }
                if (this.hdnCASESTATUS.Value == "6")
                {
                    //this.btnSaveModify.Attributes.Remove("display:");
                    //this.btnSaveModify.Attributes.Add("style", "display:none");
                }
                else if (this.lblStatus.Text == "查詢" && (this.hdnCASESTATUS.Value == "7" || this.hdnCASESTATUS.Value == "8"))
                {
                    //this.btnSaveModify.Attributes.Remove("display:");
                    //this.btnSaveModify.Attributes.Add("style", "display:none");
                    this.btnIRR.Enabled = false;
                    this.drpPROJECT.Enabled = false;
                }
                else if (this.lblStatus.Text == "修改" && (this.hdnCASESTATUS.Value == "7" || this.hdnCASESTATUS.Value == "8"))
                {
                    this.btnSaveModify.Enabled = true;
                    this.btnSave.Attributes.Remove("display:");
                    this.btnSave.Attributes.Add("style", "display:none");
                    this.btnSubmit.Attributes.Remove("display:");
                    this.btnSubmit.Attributes.Add("style", "display:none");
                    //this.btnSaveModify.Attributes.Remove("display:");
                    //this.btnSaveModify.Attributes.Add("style", "display:block");
                    this.btnIRR.Enabled = false;
                    this.drpPROJECT.Enabled = false;
                }

                //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                //2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                //3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
                if (txtPRGID.Text == "LE3001A")
                {
                    for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
                    {
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Enabled = true;
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Enabled = true;
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Enabled = true;
                        //Modify 20131210 BY SEAN Reason:PRGID若是ML3001A則可開放修改動產設定金額，承作內容為分期付條買的話，則為非必填，反之則為必填
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Enabled = true;
                    }

                    for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
                    {
                        ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGUARANTEEANOUNT")).Enabled = true;
                    }

                    for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
                    {
                        ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Enabled = true;
                    }

                    //20131021 ADD BY SS ADAM Reason.
                    if (drpMAINTYPE.SelectedValue == "03")
                        this.btnPayDate.Enabled = true;
                }

                //UPD BY VICKY 20150127 區分AR件
                if (drpMAINTYPE.SelectedValue == "04")
                {
                    this.divMainTypeA.Attributes["style"] = "display:none";
                    this.divMainTypeB.Attributes["style"] = "display:block";
                }
                else
                {
                    this.divMainTypeA.Attributes["style"] = "display:block";
                    this.divMainTypeB.Attributes["style"] = "display:none";
                }
            }
            catch (Exception ex)
            {

                Alert(ex.Message);
            }
        }
    }
    private void PageDataBind(string LSTR_CUSTID, string LSTR_CASEID)
    {
        if (!string.IsNullOrEmpty(LSTR_CUSTID) && !string.IsNullOrEmpty(LSTR_CASEID))
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
                    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                    drpSUBTYPEBindbyID(LSTR_MAINTYPEID);
                    drpSUBTYPE.SelectedValue = LDST_Data.Tables[2].Rows[0]["SUBTYPE"].ToString().Trim();
                    this.drpRCUSTPAYTYPE.SelectedIndex = this.drpPAYTPE.SelectedIndex;
                    //Modify 20150310 By SS VICKY    Reason:新增「專案別」下拉選單
                    drpPROJCD.SelectedValue = LDST_Data.Tables[2].Rows[0]["PROJCD"].ToString().Trim();

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
                        GetMLDCASEINSTDBind(LDST_Data.Tables[5], true);
                        this.txtBILLNOTECUSTID.Enabled = false;
                        this.txtBILLNOTECUST.Enabled = false;
                        this.txtDEPOSITBANKS.Enabled = false;
                        this.txtACCOUNT.Enabled = false;
                        this.txtENDORSERID.Enabled = false;
                        this.txtENDORSER.Enabled = false;
                        this.btnBank.Disabled = true;
                    }
                    if (LSTR_MAINTYPEID == "01")
                    {
                        this.txtRPURCHASEMARGIN.Enabled = true;
                    }
                    else
                    {
                        this.txtRPURCHASEMARGIN.Enabled = false;
                        this.txtRPURCHASEMARGIN.Text = "0";
                    }
                    if (LSTR_MAINTYPEID == "04")
                    {
                        this.txtRFIRSTPAY.Enabled = false;
                        this.txtRFIRSTPAY.Text = "0";
                    }
                    else
                    {
                        this.txtRFIRSTPAY.Enabled = true;
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

                    //20231130ADD選定專案
                    btnPROJECT_Click(null, null);
                    drpPROJECT.SelectedValue = LDST_Data.Tables[13].Rows[0]["PROJID"].ToString().Trim();
                    hidPROJECT.SelectedValue = LDST_Data.Tables[13].Rows[0]["DISCAMT"].ToString().Trim();

                    if (this.drpMAINTYPE.SelectedValue == "01" && this.drpSUBTYPE.SelectedValue == "01")
                    {
                        //營租事物機 和 資租事物機 資金成本要固定為 5%
                        //其他承作類型 為7%
                        //this.txtRCAPITALCOST.Text = "5";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    else if (this.drpMAINTYPE.SelectedValue == "02" && this.drpSUBTYPE.SelectedValue == "01")
                    {
                        //this.txtRCAPITALCOST.Text = "5";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    else
                    {
                        //this.txtRCAPITALCOST.Text = "7";
                        //20170726 ADD BY SS ADAM REASON.東軒要求改為4%
                        this.txtRCAPITALCOST.Text = "4";
                    }
                    if (LSTR_MAINTYPEID == "01" || LSTR_MAINTYPEID == "02")
                    {
                        if (drpSUBTYPE.SelectedValue == "01")
                        {
                            if (LDST_Data.Tables[12].Rows.Count > 0)
                            {
                                this.chkRDEPOSITLOANS0.Enabled = true;
                                this.chkRDEPOSITLOANS1.Enabled = true;
                                this.chkRDEPOSITLOANS2.Enabled = true;
                                if (this.chkRDEPOSITLOANS1.Checked)
                                {
                                    this.txtDEPOSITLOANSAMOUNT.Enabled = true;
                                    this.txtSUPPLIERSALE.Enabled = true;
                                    this.txtSUPPLIERSALENM.Enabled = true;
                                }
                                else
                                {
                                    this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                                    this.txtSUPPLIERSALE.Enabled = false;
                                    this.txtSUPPLIERSALENM.Enabled = false;
                                }
                            }
                            else
                            {
                                this.chkRDEPOSITLOANS0.Checked = false;
                                this.chkRDEPOSITLOANS1.Checked = false;
                                this.chkRDEPOSITLOANS2.Checked = true;
                                this.txtDEPOSITLOANSAMOUNT.Text = "0";
                                this.txtSUPPLIERSALE.Text = "";
                                this.txtSUPPLIERSALENM.Text = "";

                                this.chkRDEPOSITLOANS0.Enabled = false;
                                this.chkRDEPOSITLOANS1.Enabled = false;
                                this.chkRDEPOSITLOANS2.Enabled = false;
                                this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                                this.txtSUPPLIERSALE.Enabled = false;
                                this.txtSUPPLIERSALENM.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.chkRDEPOSITLOANS0.Checked = false;
                        this.chkRDEPOSITLOANS1.Checked = false;
                        this.chkRDEPOSITLOANS2.Checked = true;
                        this.txtDEPOSITLOANSAMOUNT.Text = "0";
                        this.txtSUPPLIERSALE.Text = "";
                        this.txtSUPPLIERSALENM.Text = "";

                        this.chkRDEPOSITLOANS0.Enabled = false;
                        this.chkRDEPOSITLOANS1.Enabled = false;
                        this.chkRDEPOSITLOANS2.Enabled = false;
                        this.txtDEPOSITLOANSAMOUNT.Enabled = false;
                        this.txtSUPPLIERSALE.Enabled = false;
                        this.txtSUPPLIERSALENM.Enabled = false;

                    }
                    this.txtBUSINESS.Width = 500;
                    this.btnIRR.Enabled = true;

                    //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
                    hidMAINTYPE.Value = drpMAINTYPE.SelectedValue;
                    hidSUBTYPE.Value = drpSUBTYPE.SelectedValue;
                    hidTARGETPRICE.Value = txtTRANSCOST.Text;
                    if (rptMLDCASETARGET.Items.Count > 0)
                    {
                        hidTARGETTYPE.Value = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.ToString();
                    }

                    //20150508 ADD BY SS ADAM REASON.修正當新增時，無載入hidRACTUSLLOANS的問題
                    hidRACTUSLLOANS.Value = txtRACTUSLLOANS.Text;
                }
                if (this.hdnCASESTATUS.Value == "6")
                {
                    this.btnSaveModify.Attributes.Remove("display:");
                    this.btnSaveModify.Attributes.Add("style", "display:none");
                }
                else if (this.hdnCASESTATUS.Value == "7" || this.hdnCASESTATUS.Value == "8")
                {
                    this.btnSave.Attributes.Remove("display:");
                    this.btnSave.Attributes.Add("style", "display:none");
                    this.btnSubmit.Attributes.Remove("display:");
                    this.btnSubmit.Attributes.Add("style", "display:none");
                    if (this.hdnCASESTATUS.Value == "8")
                    {
                        this.btnIRR.Enabled = false;
                    }
                }
                //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                //2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
                //3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
                if (txtPRGID.Text == "LE3001A")
                {
                    for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
                    {
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Enabled = true;
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Enabled = true;
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Enabled = true;
                        //Modify 20131210 BY SEAN Reason:PRGID若是ML3001A則可開放修改動產設定金額，承作內容為分期付條買的話，則為非必填，反之則為必填
                        ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Enabled = true;
                    }

                    for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
                    {
                        ((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGUARANTEEANOUNT")).Enabled = true;
                    }

                    for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
                    {
                        ((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Enabled = true;
                    }
                }

                //UPD BY VICKY 20150127 區分AR件
                if (drpMAINTYPE.SelectedValue == "04")
                {
                    this.divMainTypeA.Attributes["style"] = "display:none";
                    this.divMainTypeB.Attributes["style"] = "display:block";
                }
                else
                {
                    this.divMainTypeA.Attributes["style"] = "display:block";
                    this.divMainTypeB.Attributes["style"] = "display:none";
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
        this.drpPROJECT.Items.Clear();
        this.drpPROJECT.Items.Insert(0, new ListItem("無", "0"));
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
        //Alert(hidPROJECT.SelectedValue.ToString());
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

    private void DisabledRPRINCIPAL()
    {
        //20130703 UPD BY BRENT Reason.取消原本資租(02)不能填寫多段式租金的設定
        //if (drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "03" || drpMAINTYPE.SelectedValue == "04")
        //{
        txtRSTARTPAY2.Enabled = true;
        txtRSTARTPAY3.Enabled = true;
        txtRSTARTPAY4.Enabled = true;

        txtRENDPAY2.Enabled = true;
        txtRENDPAY3.Enabled = true;
        txtRENDPAY4.Enabled = true;

        txtRPRINCIPAL2.Enabled = true;
        txtRPRINCIPAL3.Enabled = true;
        txtRPRINCIPAL4.Enabled = true;

        txtRPRINCIPALTAX2.Enabled = true;
        txtRPRINCIPALTAX3.Enabled = true;
        txtRPRINCIPALTAX4.Enabled = true;
        //} else {
        //  txtRSTARTPAY2.Enabled = false;
        //  txtRSTARTPAY3.Enabled = false;
        //  txtRSTARTPAY4.Enabled = false;

        //  txtRENDPAY2.Enabled = false;
        //  txtRENDPAY3.Enabled = false;
        //  txtRENDPAY4.Enabled = false;

        //  txtRPRINCIPAL2.Enabled = false;
        //  txtRPRINCIPAL3.Enabled = false;
        //  txtRPRINCIPAL4.Enabled = false;

        //  txtRPRINCIPALTAX2.Enabled = false;
        //  txtRPRINCIPALTAX3.Enabled = false;
        //  txtRPRINCIPALTAX4.Enabled = false;
        //}
    }
    protected double IRR_Cal()
    {
        if (txtRTRANSCOST.Text == "")
        {
            Alert("請輸入受讓/發票金額！");
            txtRTRANSCOST.Focus();
            return 0;
        }
        if (txtRCONTRACTMONTH.Text == "")
        {
            Alert("請輸入總承作月數！");
            txtRCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtRPAYMONTH.Text == "")
        {
            Alert("請輸入幾月一付！");
            txtRPAYMONTH.Focus();
            return 0;
        }
        if (drpRPAYTIME.SelectedIndex == 0)
        {
            Alert("請選擇付款時間！");
            drpRPAYTIME.Focus();
            return 0;
        }
        if (txtRENDPAY1.Text == "")
        {
            Alert("請輸入第一段結束期別！");
            txtRENDPAY1.Focus();
            return 0;
        }
        if (txtRPRINCIPAL1.Text == "")
        {
            Alert("請輸入第一段期付款！");
            txtRPRINCIPAL1.Focus();
            return 0;
        }

        if (txtRTRANSCOST.Text == "0")
        {
            Alert("受讓/發票金額輸入需大於 0！");
            txtRTRANSCOST.Focus();
            return 0;
        }
        if (txtRCONTRACTMONTH.Text == "0")
        {
            Alert("總承作月數輸入需大於 0！");
            txtRCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtRPAYMONTH.Text == "0")
        {
            Alert("幾月一付輸入需大於 0！");
            txtRPAYMONTH.Focus();
            return 0;
        }
        if (txtRENDPAY1.Text == "0")
        {
            Alert("第一段結束期別輸入需大於 0！");
            txtRENDPAY1.Focus();
            return 0;
        }

        // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
        //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
        if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
        {

            if (txtRPRINCIPAL1.Text == "0")
            {
                Alert("第一段期付款輸入需大於 0！");
                txtRPRINCIPAL1.Focus();
                return 0;
            }
        }
        bool LBOL_Checked = false;
        if (txtRENDPAY4.Text != "")
        {
            if (txtRCONTRACTMONTH.Text != txtRENDPAY4.Text)
            {
                Alert("最後一段結束期別輸入需等於總承作月數！");
                txtRENDPAY4.Focus();
                return 0;
            }
            else
            {
                LBOL_Checked = true;
            }
        }
        if (!LBOL_Checked)
        {
            if (txtRENDPAY3.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY3.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY3.Focus();
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
            if (txtRENDPAY2.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY2.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY2.Focus();
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
            if (txtRENDPAY1.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY1.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY1.Focus();
                    return 0;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }

        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        //Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;新增手續費.
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtRPAYMONTH.Text);
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //期數比例
        double LINT_MONTH = 0;
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PATDAYS = 0;
        int LINT_SUPPILERDAYS = 0;
        if (txtRPATDAYS.Text.Trim() != "")
        {
            LINT_PATDAYS = Convert.ToInt32(txtRPATDAYS.Text);
        }
        if (txtRSUPPILERDAYS.Text.Trim() != "")
        {
            LINT_SUPPILERDAYS = Convert.ToInt32(txtRSUPPILERDAYS.Text);
        }
        int LINT_PayDiff = LINT_PATDAYS - LINT_SUPPILERDAYS;
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        Decimal LDEC_PayDiffAmount = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            //撥差金額計算公式  (標的物金額 – 頭期款 – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((Convert.ToDecimal(txtRTRANSCOST.Text) - Convert.ToDecimal(txtRFIRSTPAY.Text) - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
            //Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法，AR案件中，標的物金額改成含稅.
            LDCE_TransCost = Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text));
        }
        else
        {
            //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
        }
        //20231130專案扣款金額(扣款金額÷扣款總年數)乘以(期數除12)
        Decimal ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue) * Convert.ToDecimal(LINT_CONTRACTMONTH / 12.0);
        if (ProjectDISCAMT >= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130金額不可超過專案扣款金額
        if (ProjectDISCAMT < 0 && ProjectDISCAMT <= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130負成本金額不可超過專案扣款金額
        //計算第0期的現金流量
        //租購保證金+頭期款(未稅)+履約保證金+手續費收入-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金
        LDBL_VALUE[0] = Convert.ToDouble(Convert.ToDecimal(txtRPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                        + LDCE_FirstPay //頭期款(未稅)
                        + Convert.ToDecimal(txtRPERBOND.Text) //履約保證金txtPERBOND
                                                              //Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;手續費調整為未稅.
                                                              //+ Convert.ToDecimal(txtRFEE.Text) //手續費收入txtRFEE
                        + Convert.ToDecimal(LDCE_Fee) //手續費收入
                        - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                        - Convert.ToDecimal(txtRINSURANCE.Text) //保險費txtINSURANCE
                                                                //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                //- Convert.ToDecimal(txtROTHERFEES.Text) //作業費用txtOTHERFEES
                        - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtROTHERFEES.Text) / 1.05), 0)
                        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                        - Convert.ToDecimal(txtROTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
                        - LDEC_PayDiffAmount                //撥差金額
                                                            //Modify 20120614 By SS Gordon. Reason: 修改IRR計算方法;加入佣金計算.
                        - Convert.ToDecimal(txtRCOMMISSION.Text)// - 佣金txtCOMMISSION
                      - ProjectDISCAMT);//20231130 ADD專案扣款金額
        //20231130將幾月一付加入IRR計算
        //如果是期初收
        if (drpRPAYTIME.SelectedValue == "01")
        {
            LDBL_VALUE[0] += Convert.ToDouble(txtPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
        }
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
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
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text) * LINT_PAYMONTH;
                }
                if (drpRPAYTIME.SelectedValue == "02" && LINT_PAYMONTH == 01)
                {
                    LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                else if (drpRPAYTIME.SelectedValue == "02" && LINT_PAYMONTH != 01)
                {
                    LDBL_VALUE[j] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                 + LDCE_Residuals  //殘值
                                                 - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                                                 - Convert.ToDecimal(txtRPERBOND.Text));//履約保證金txtPURCHASEMARGIN
            }
            else
            {
                //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
                //期初收
                if (drpRPAYTIME.SelectedValue == "01")
                {
                    if (i >= 1 && i <= LINT_ENDPAY1 - 1)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                }
                else
                {
                    //20231130幾月一付若為1跟著i走
                    if (LINT_PAYMONTH == 01)
                    {
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                    else
                    {
                        //20231130幾月一付不為1時要等於幾月一付-1
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                }
            }

            //Modify 20120614 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
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
                    //20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
                    double INSU = INSU_Cal((i / 12));
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                     //- (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
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
                                                     - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
                                                     );
                }
            }
        }
        ////20131129 ADD BY SS ADAM Reason.修正IRR計算產生的錯誤，主要是第零期的現金流量是負值造成的錯誤
        //if (LDBL_VALUE[0] < 0)
        //    return -999;

        double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200;
        return LDBL_IRR;
    }

    //20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
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

    //UPD BY VICKY 20150123 MARK起來, 重寫公式
    #region MARK IRR_Cal_AR
    //Modify 20120615 By SS Gordon. Reason: 新增AR案件的IRR計算，與原本IRR計算分開
    //protected double IRR_Cal_AR()
    //{
    //    if (txtRTRANSCOST.Text == "")
    //    {
    //        Alert("請輸入受讓/發票金額！");
    //        txtRTRANSCOST.Focus();
    //        return 0;
    //    }
    //    if (txtRCONTRACTMONTH.Text == "")
    //    {
    //        Alert("請輸入總承作月數！");
    //        txtRCONTRACTMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRPAYMONTH.Text == "")
    //    {
    //        Alert("請輸入幾月一付！");
    //        txtRPAYMONTH.Focus();
    //        return 0;
    //    }
    //    if (drpRPAYTIME.SelectedIndex == 0)
    //    {
    //        Alert("請選擇付款時間！");
    //        drpRPAYTIME.Focus();
    //        return 0;
    //    }
    //    if (txtRENDPAY1.Text == "")
    //    {
    //        Alert("請輸入第一段結束期別！");
    //        txtRENDPAY1.Focus();
    //        return 0;
    //    }
    //    if (txtRPRINCIPAL1.Text == "")
    //    {
    //        Alert("請輸入第一段期付款！");
    //        txtRPRINCIPAL1.Focus();
    //        return 0;
    //    }

    //    if (txtRTRANSCOST.Text == "0")
    //    {
    //        Alert("受讓/發票金額輸入需大於 0！");
    //        txtRTRANSCOST.Focus();
    //        return 0;
    //    }
    //    if (txtRCONTRACTMONTH.Text == "0")
    //    {
    //        Alert("總承作月數輸入需大於 0！");
    //        txtRCONTRACTMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRPAYMONTH.Text == "0")
    //    {
    //        Alert("幾月一付輸入需大於 0！");
    //        txtRPAYMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRENDPAY1.Text == "0")
    //    {
    //        Alert("第一段結束期別輸入需大於 0！");
    //        txtRENDPAY1.Focus();
    //        return 0;
    //    }

    //    // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
    //    //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
    //    if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
    //    {

    //        if (txtRPRINCIPAL1.Text == "0")
    //        {
    //            Alert("第一段期付款輸入需大於 0！");
    //            txtRPRINCIPAL1.Focus();
    //            return 0;
    //        }
    //    }
    //    bool LBOL_Checked = false;
    //    if (txtRENDPAY4.Text != "")
    //    {
    //        if (txtRCONTRACTMONTH.Text != txtRENDPAY4.Text)
    //        {
    //            Alert("最後一段結束期別輸入需等於總承作月數！");
    //            txtRENDPAY4.Focus();
    //            return 0;
    //        }
    //        else
    //        {
    //            LBOL_Checked = true;
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY3.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY3.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY3.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY2.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY2.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY2.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY1.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY1.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY1.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }

    //    //標的物金額
    //    Decimal LDCE_TransCost = Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text));
    //    //殘值(未稅)
    //    Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRRESIDUALS.Text) / 1.05), 0);
    //    //頭期款(未稅)
    //    Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
    //    //手續費(未稅)
    //    Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFEE.Text) / 1.05), 0);
    //    //期別
    //    int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
    //    int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
    //    int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
    //    int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
    //    //期數比例
    //    double LINT_MONTH = 0;
    //    //期數
    //    int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
    //    double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
    //    //撥差天數 = 付款差異天數 – 付供應商天數
    //    int LINT_PATDAYS = 0;
    //    int LINT_SUPPILERDAYS = 0;
    //    if (txtRPATDAYS.Text.Trim() != "")
    //    {
    //        LINT_PATDAYS = Convert.ToInt32(txtRPATDAYS.Text);
    //    }
    //    if (txtRSUPPILERDAYS.Text.Trim() != "")
    //    {
    //        LINT_SUPPILERDAYS = Convert.ToInt32(txtRSUPPILERDAYS.Text);
    //    }
    //    int LINT_PayDiff = LINT_PATDAYS - LINT_SUPPILERDAYS;
    //    //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
    //    Decimal LDEC_PayDiffAmount = 0;

    //    //撥差金額計算公式  (標的物金額 – 頭期款 – 保證金 ) * 撥差天數 * 資金成本 / 365天
    //    LDEC_PayDiffAmount = Math.Round((Convert.ToDecimal(txtRTRANSCOST.Text) - Convert.ToDecimal(txtRFIRSTPAY.Text) - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);

    //    //銷項稅額      
    //    Decimal LDEC_RPRINCIPAL_TAX_SUM = 0;
    //    Decimal LDEC_TAX_AMOUNT = 0;
    //    for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
    //    {
    //        if (i >= 1 && i <= LINT_ENDPAY1)
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
    //        }
    //    }
    //    LDEC_TAX_AMOUNT = (LDEC_RPRINCIPAL_TAX_SUM - LDCE_TransCost) - Math.Round(Convert.ToDecimal(Convert.ToDouble(LDEC_RPRINCIPAL_TAX_SUM - LDCE_TransCost) / 1.05), 0);

    //    //計算第0期的現金流量
    //    //租購保證金+頭期款(未稅)+履約保證金+手續費收入-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金-銷項稅額
    //    LDBL_VALUE[0] = Convert.ToDouble(Convert.ToDecimal(txtRPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
    //                    + LDCE_FirstPay //頭期款(未稅)
    //                    + Convert.ToDecimal(txtRPERBOND.Text) //履約保證金txtPERBOND
    //                    + Convert.ToDecimal(LDCE_Fee) //手續費收入
    //                    - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
    //                    - Convert.ToDecimal(txtRINSURANCE.Text) //保險費txtINSURANCE
    //                    - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtROTHERFEES.Text) / 1.05), 0)
    //                    - Convert.ToDecimal(txtROTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
    //                    - LDEC_PayDiffAmount                //撥差金額
    //                    - Convert.ToDecimal(txtRCOMMISSION.Text)      // - 佣金txtCOMMISSION
    //                    - LDEC_TAX_AMOUNT);          //銷項稅額

    //    //如果是期初收
    //    if (drpRPAYTIME.SelectedValue == "01")
    //    {
    //        LDBL_VALUE[0] += Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //    }
    //    for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
    //    {
    //        //最後一期
    //        if (i == LINT_CONTRACTMONTH)
    //        {
    //            //最後一期付款
    //            Decimal LDCE_PRINCIPAL = 0;
    //            if (LINT_ENDPAY1 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
    //            }
    //            if (LINT_ENDPAY2 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
    //            }
    //            if (LINT_ENDPAY3 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
    //            }
    //            if (LINT_ENDPAY4 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
    //            }
    //            if (drpRPAYTIME.SelectedValue == "02")
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
    //            }
    //            LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
    //                                             + LDCE_Residuals  //殘值
    //                                             - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
    //                                             - Convert.ToDecimal(txtRPERBOND.Text));//履約保證金txtPURCHASEMARGIN
    //        }
    //        else
    //        {
    //            //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
    //            //期初收
    //            if (drpRPAYTIME.SelectedValue == "01")
    //            {
    //                if (i >= 1 && i <= LINT_ENDPAY1 - 1)
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX2.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX3.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX4.Text); //月付款
    //                }
    //            }
    //            else
    //            {
    //                if (i >= 1 && i <= LINT_ENDPAY1)
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX2.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX3.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX4.Text); //月付款
    //                }
    //            }
    //        }

    //        //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
    //        if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
    //        {
    //            if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
    //            {
    //                //計算期數比例 不滿一年按比例計算保險費
    //                LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
    //                if (LINT_MONTH > 1)
    //                {
    //                    LINT_MONTH = 1;
    //                }
    //                //20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
    //                double INSU = INSU_Cal((i / 12));
    //                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
    //                                                 - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
    //                    //- (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
    //                                                 );
    //            }
    //        }
    //        else
    //        {
    //            if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
    //            {
    //                //計算期數比例 不滿一年按比例計算保險費
    //                LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
    //                if (LINT_MONTH > 1)
    //                {
    //                    LINT_MONTH = 1;
    //                }
    //                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
    //                                                 - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
    //                                                 );
    //            }
    //        }
    //    }
    //    ////20131129 ADD BY SS ADAM Reason.修正IRR計算產生的錯誤，主要是第零期的現金流量是負值造成的錯誤
    //    //if (LDBL_VALUE[0] < 0)
    //    //    return -999;

    //    double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200;
    //    return LDBL_IRR;
    //}
    #endregion

    //UPD BY VICKY 20150125 AR件 IRR計算
    protected double IRR_Cal_AR()
    {

        DataTable dt = new DataTable();
        DataColumn col1 = new DataColumn("ADVANCESDAYS", Type.GetType("System.Int32"));
        DataColumn col2 = new DataColumn("ADVANCESAMT", Type.GetType("System.Int32"));
        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        int sumBILLAMT = 0;
        int sumFINANCIALFEES = 0;
        int sumFINALPAYAMT = 0;


        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            DataRow row01 = dt.NewRow();
            row01[0] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));  //墊款天數
            row01[1] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESAMT_AR")).Text.Replace(",", ""));    //墊款金額
            dt.Rows.Add(row01);

            sumBILLAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Replace(",", ""));
            sumFINANCIALFEES += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Replace(",", ""));
            sumFINALPAYAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text.Replace(",", ""));
        }

        int EndDay1 = 0; //最後一張票據墊款天數
        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            int EndDay2 = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));
            if (EndDay1 < EndDay2) EndDay1 = EndDay2; //最後一張票據墊款天數

        }

        double[] LDBL_VALUE = new double[EndDay1 + 1];

        for (int i = 0; i < LDBL_VALUE.Length; i++)
        {
            LDBL_VALUE[i] = 0;
        }

        LDBL_VALUE[0] = -1 * (sumBILLAMT - sumFINANCIALFEES - sumFINALPAYAMT);  //撥款金額
        //20150326 ADD BY SS ADAM REASON.第0期漏掉其他收入
        LDBL_VALUE[0] += (Convert.ToInt32(txtCREDITFEES_AR.Text.Replace(",", "")) + Convert.ToInt32(txtMANAGERFEES_AR.Text.Replace(",", "")) + Convert.ToInt32(txtFINANCIALFEES_AR.Text.Replace(",", "")));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            LDBL_VALUE[(int)dt.Rows[i][0]] = LDBL_VALUE[(int)dt.Rows[i][0]] + (int)dt.Rows[i][1];        //現金流(墊款金額)
        }

        double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0) * 365 * 100;
        return LDBL_IRR;
    }

    protected double NPV_Cal(string strNPVRATECOST)
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;新增手續費.
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtRPAYMONTH.Text);
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //期數比例
        double LINT_MONTH = 0;
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
        //撥差天數 = 付款差異天數 – 付供應商天數
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PATDAYS = 0;
        int LINT_SUPPILERDAYS = 0;
        if (txtRPATDAYS.Text.Trim() != "")
        {
            LINT_PATDAYS = Convert.ToInt32(txtRPATDAYS.Text);
        }
        if (txtRSUPPILERDAYS.Text.Trim() != "")
        {
            LINT_SUPPILERDAYS = Convert.ToInt32(txtRSUPPILERDAYS.Text);
        }
        int LINT_PayDiff = LINT_PATDAYS - LINT_SUPPILERDAYS;
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        Decimal LDEC_PayDiffAmount = 0;

        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;都以未稅計算.
        //Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，撥差金額計算公式中，由NPV成本計算改成資金成本計算，且AR的算法與其他不同，所以使用舊的計算方法即可.
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            //撥差金額計算公式  (標的物金額 – 頭期款 – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((Convert.ToDecimal(txtRTRANSCOST.Text) - Convert.ToDecimal(txtRFIRSTPAY.Text) - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
            //Modify 20120524 By SS Gordon. Reason: 修改NPV計算方法，AR案件中，標的物金額改成含稅.
            //標的物金額(含稅)
            LDCE_TransCost = Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text));
        }
        else
        {
            //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
        }
        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將資金成本改成NPV利率成本.
        //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * NPV利率成本 / 365天
        //LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRNPVRATECOST.Text) / 100 / 365, 0);
        //20231130專案扣款金額(扣款金額÷扣款總年數)乘以(期數除12)
        Decimal ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue) * Convert.ToDecimal(LINT_CONTRACTMONTH / 12.0);
        if (ProjectDISCAMT >= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130金額不可超過專案扣款金額
        if (ProjectDISCAMT < 0 && ProjectDISCAMT <= Convert.ToDecimal(hidPROJECT.SelectedValue)) ProjectDISCAMT = Convert.ToDecimal(hidPROJECT.SelectedValue);//20231130負成本金額不可超過專案扣款金額
        //計算第0期的現金流量
        LDBL_VALUE[0] = Convert.ToDouble(Math.Round(Convert.ToDecimal(txtRPURCHASEMARGIN.Text) // + 租購保證金txtPURCHASEMARGIN
                        + LDCE_FirstPay // + 頭期款(未稅)
                        + Convert.ToDecimal(txtRPERBOND.Text) // + 履約保證金txtPERBOND
                                                              //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;手續費調整為未稅.
                                                              //+ Convert.ToDecimal(txtRFEE.Text) //手續費收入txtRFEE
                        + Convert.ToDecimal(LDCE_Fee) //手續費收入
                        - LDCE_TransCost // - 標的物金額(未稅)txtTRANSCOST
                        - Convert.ToDecimal(txtRINSURANCE.Text) // - 保險費txtINSURANCE
                                                                //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                //- Convert.ToDecimal(txtROTHERFEES.Text) // - 作業費用txtOTHERFEES
                        - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtROTHERFEES.Text) / 1.05), 0)
                        //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                        - Convert.ToDecimal(txtROTHERFEESNOTAX.Text) // - 作業費用(無發票)txtOTHERFEESNOTAX
                        - LDEC_PayDiffAmount                // - 撥差金額
                                                            //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;加入佣金計算.
                        - Convert.ToDecimal(txtRCOMMISSION.Text), 0)// - 佣金txtCOMMISSION
        - ProjectDISCAMT);// 20231130 ADD專案扣款金額
                          //20231130將幾月一付加入NPV計算
                          //如果是期初收
        if (drpRPAYTIME.SelectedValue == "01")
        {
            LDBL_VALUE[0] += Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
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
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text) * LINT_PAYMONTH;
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text) * LINT_PAYMONTH;
                }
                if (drpRPAYTIME.SelectedValue == "02" && LINT_PAYMONTH == 01)
                {
                    LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                else if (drpRPAYTIME.SelectedValue == "02" && LINT_PAYMONTH != 01)
                {
                    LDBL_VALUE[j] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                }
                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i]) +
                                                 LDCE_Residuals - //殘值
                                                 Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - // + 租購保證金txtPURCHASEMARGIN
                                                 Convert.ToDecimal(txtRPERBOND.Text));// + 履約保證金txtPURCHASEMARGIN
            }
            else
            {
                //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
                //期初收
                if (drpRPAYTIME.SelectedValue == "01")
                {
                    if (i >= 1 && i <= LINT_ENDPAY1 - 1)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                }
                else
                {
                    if (i >= 1 && i <= LINT_ENDPAY1)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                    }
                    else
                    {
                        //20231130幾月一付不為1時要等於幾月一付-1
                        if (i >= 1 && i <= LINT_ENDPAY1)
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL1.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL2.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL3.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                        {
                            LDBL_VALUE[j] = Convert.ToDouble(txtRPRINCIPAL4.Text) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                }
            }

            //Modify 20120614 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
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
                    //20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
                    double INSU = INSU_Cal((i / 12));
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                     //- (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
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
                                                     - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
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

        //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將資金成本改成NPV利率成本.
        //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtRCAPITALCOST.Text) / 12 / 100, ref LDBL_VALUE);
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2;原本直接帶txtRNPVRATECOST.Text改由傳入參數strNPVRATECOST
        //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtRNPVRATECOST.Text) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
        double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(strNPVRATECOST) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
        return LDBL_NPV;
    }
    //Modify 20120618 By SS Gordon. Reason: 新增AR案件的NPV計算，與原本NPV計算分開
    #region UPD BY VICKY 20150126 MARK 起來, 重設公式
    //protected double NPV_Cal_AR(string strNPVRATECOST)
    //{
    //    //標的物金額
    //    Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text)), 0);
    //    //殘值(未稅)
    //    Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRRESIDUALS.Text) / 1.05), 0);
    //    //頭期款(未稅)
    //    Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
    //    //手續費(未稅)
    //    Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFEE.Text) / 1.05), 0);
    //    //期別
    //    int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
    //    int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
    //    int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
    //    int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
    //    //期數比例
    //    double LINT_MONTH = 0;
    //    //期數
    //    int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
    //    double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
    //    //撥差天數 = 付款差異天數 – 付供應商天數
    //    //撥差天數 = 付款差異天數 – 付供應商天數
    //    int LINT_PATDAYS = 0;
    //    int LINT_SUPPILERDAYS = 0;
    //    if (txtRPATDAYS.Text.Trim() != "")
    //    {
    //        LINT_PATDAYS = Convert.ToInt32(txtRPATDAYS.Text);
    //    }
    //    if (txtRSUPPILERDAYS.Text.Trim() != "")
    //    {
    //        LINT_SUPPILERDAYS = Convert.ToInt32(txtRSUPPILERDAYS.Text);
    //    }
    //    int LINT_PayDiff = LINT_PATDAYS - LINT_SUPPILERDAYS;
    //    //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
    //    Decimal LDEC_PayDiffAmount = 0;

    //    //撥差金額計算公式  (標的物金額 – 頭期款 – 保證金 ) * 撥差天數 * 資金成本 / 365天
    //    LDEC_PayDiffAmount = Math.Round((Convert.ToDecimal(txtRTRANSCOST.Text) - Convert.ToDecimal(txtRFIRSTPAY.Text) - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);

    //    //銷項稅額      
    //    Decimal LDEC_RPRINCIPAL_TAX_SUM = 0;
    //    Decimal LDEC_TAX_AMOUNT = 0;
    //    for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
    //    {
    //        if (i >= 1 && i <= LINT_ENDPAY1)
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
    //        }
    //        else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
    //        {
    //            LDEC_RPRINCIPAL_TAX_SUM += Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
    //        }
    //    }
    //    LDEC_TAX_AMOUNT = (LDEC_RPRINCIPAL_TAX_SUM - LDCE_TransCost) - Math.Round(Convert.ToDecimal(Convert.ToDouble(LDEC_RPRINCIPAL_TAX_SUM - LDCE_TransCost) / 1.05), 0);

    //    //計算第0期的現金流量
    //    LDBL_VALUE[0] = Convert.ToDouble(Math.Round(Convert.ToDecimal(txtRPURCHASEMARGIN.Text) // + 租購保證金txtPURCHASEMARGIN
    //                    + LDCE_FirstPay // + 頭期款(未稅)
    //                    + Convert.ToDecimal(txtRPERBOND.Text) // + 履約保證金txtPERBOND
    //                    + Convert.ToDecimal(LDCE_Fee) //手續費收入
    //                    - LDCE_TransCost // - 標的物金額(未稅)txtTRANSCOST
    //                    - Convert.ToDecimal(txtRINSURANCE.Text) // - 保險費txtINSURANCE
    //                    - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtROTHERFEES.Text) / 1.05), 0)
    //                    - Convert.ToDecimal(txtROTHERFEESNOTAX.Text) // - 作業費用(無發票)txtOTHERFEESNOTAX
    //                    - LDEC_PayDiffAmount                // - 撥差金額          
    //                    - Convert.ToDecimal(txtRCOMMISSION.Text), 0)      // - 佣金txtCOMMISSION
    //                    - LDEC_TAX_AMOUNT);          //銷項稅額

    //    //如果是期初收
    //    if (drpRPAYTIME.SelectedValue == "01")
    //    {
    //        LDBL_VALUE[0] += Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //    }
    //    for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
    //    {
    //        //最後一期
    //        if (i == LINT_CONTRACTMONTH)
    //        {
    //            //最後一期付款
    //            Decimal LDCE_PRINCIPAL = 0;
    //            if (LINT_ENDPAY1 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
    //            }
    //            if (LINT_ENDPAY2 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
    //            }
    //            if (LINT_ENDPAY3 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
    //            }
    //            if (LINT_ENDPAY4 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
    //            }
    //            if (drpRPAYTIME.SelectedValue == "02")
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
    //            }
    //            LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i]) +
    //                                             LDCE_Residuals - //殘值
    //                                             Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - // + 租購保證金txtPURCHASEMARGIN
    //                                             Convert.ToDecimal(txtRPERBOND.Text));// + 履約保證金txtPURCHASEMARGIN
    //        }
    //        else
    //        {
    //            //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
    //            //期初收
    //            if (drpRPAYTIME.SelectedValue == "01")
    //            {
    //                if (i >= 1 && i <= LINT_ENDPAY1 - 1)
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX2.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX3.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX4.Text); //月付款
    //                }
    //            }
    //            else
    //            {
    //                if (i >= 1 && i <= LINT_ENDPAY1)
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX2.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX3.Text); //月付款
    //                }
    //                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
    //                {
    //                    LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX4.Text); //月付款
    //                }
    //            }
    //        }

    //        //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
    //        if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
    //        {
    //            if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
    //            {
    //                //計算期數比例 不滿一年按比例計算保險費
    //                LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
    //                if (LINT_MONTH > 1)
    //                {
    //                    LINT_MONTH = 1;
    //                }
    //                //20121114 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
    //                double INSU = INSU_Cal((i / 12));
    //                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
    //                                                 - Math.Round((Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
    //                    //- (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
    //                                                 );
    //            }
    //        }
    //        else
    //        {
    //            if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
    //            {
    //                //計算期數比例 不滿一年按比例計算保險費
    //                LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
    //                if (LINT_MONTH > 1)
    //                {
    //                    LINT_MONTH = 1;
    //                }
    //                LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
    //                                                 - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
    //                                                 );
    //            }
    //        }
    //    }

    //    //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將第0期的流出與其他期的流入分開.
    //    double[] LDBL_OUT_VALUE = new double[1];
    //    double[] LDBL_IN_VALUE = new double[LINT_CONTRACTMONTH];
    //    LDBL_OUT_VALUE[0] = LDBL_VALUE[0];
    //    for (int i = 0; i < LDBL_IN_VALUE.Length; i++)
    //    {
    //        LDBL_IN_VALUE[i] = LDBL_VALUE[i + 1];
    //    }

    //    //Modify 20120301 By SS Gordon. Reason: 修改NPV計算方法;將資金成本改成NPV利率成本.
    //    //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtRCAPITALCOST.Text) / 12 / 100, ref LDBL_VALUE);
    //    //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2;原本直接帶txtNPVRATECOST.Text改由傳入參數strNPVRATECOST
    //    //double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(txtRNPVRATECOST.Text) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
    //    double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(strNPVRATECOST) / 12 / 100, ref LDBL_IN_VALUE) + LDBL_OUT_VALUE[0];
    //    return LDBL_NPV;
    //}
    #endregion

    //UPD BY VICKY 20150126 重設公式
    protected double NPV_Cal_AR(string strNPVRATECOST)
    {
        DataTable dt = new DataTable();
        DataColumn col1 = new DataColumn("ADVANCESDAYS", Type.GetType("System.Int32"));
        DataColumn col2 = new DataColumn("ADVANCESAMT", Type.GetType("System.Int32"));
        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        int sumBILLAMT = 0;
        int sumFINANCIALFEES = 0;
        int sumFINALPAYAMT = 0;

        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            DataRow row01 = dt.NewRow();
            row01[0] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));  //墊款天數
            row01[1] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESAMT_AR")).Text.Replace(",", ""));    //墊款金額
            dt.Rows.Add(row01);

            sumBILLAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Replace(",", ""));
            sumFINANCIALFEES += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Replace(",", ""));
            sumFINALPAYAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text.Replace(",", ""));
        }


        int EndDay1 = 0; //最後一張票據墊款天數
        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            int EndDay2 = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));
            if (EndDay1 < EndDay2) EndDay1 = EndDay2; //最後一張票據墊款天數

        }

        double[] LDBL_VALUE = new double[EndDay1 + 1];

        for (int i = 0; i < LDBL_VALUE.Length; i++)
        {
            LDBL_VALUE[i] = 0;
        }

        LDBL_VALUE[0] = -1 * (sumBILLAMT - sumFINANCIALFEES - sumFINALPAYAMT);       //撥款金額
        //20150326 ADD BY SS ADAM REASON.第0期漏掉其他收入
        LDBL_VALUE[0] += (Convert.ToInt32(txtCREDITFEES_AR.Text.Replace(",", "")) + Convert.ToInt32(txtMANAGERFEES_AR.Text.Replace(",", "")) + Convert.ToInt32(txtFINANCIALFEES_AR.Text.Replace(",", "")));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //20150325 ADD BY SS ADAM REASON.要加上原本的數值，修正到期日相同的票會造成錯誤的情況
            LDBL_VALUE[(int)dt.Rows[i][0]] = LDBL_VALUE[(int)dt.Rows[i][0]] + (int)dt.Rows[i][1];
        }

        double LDBL_NPV = Microsoft.VisualBasic.Financial.NPV(Convert.ToDouble(strNPVRATECOST) / 365 / 100, ref LDBL_VALUE);
        return LDBL_NPV;
    }


    protected void btnIRR_Click(object sender, EventArgs e)
    {
        try
        {
            //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
            if (drpMAINTYPE.SelectedValue != "04" && txtRNOINSURANCEFLG.Checked == false)
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
            this.hidShowTag.Value = "fraTab33Caption";
            //Modify 20120615 By SS Gordon. Reason: 新增AR案件的IRR計算，與原本IRR計算分開
            //double LINT_IRR = IRR_Cal();
            double LINT_IRR = 0;
            if (this.drpMAINTYPE.SelectedValue == "04")
            {
                if (!chkMLDCONTRACTARD()) return;  //20150127 加入AR明細必填欄位檢核
                LINT_IRR = IRR_Cal_AR();

            }
            else
            {
                LINT_IRR = IRR_Cal();
            }
            if (LINT_IRR > 100 || LINT_IRR < -100)
            {
                Alert("試算異常！請檢核金額項目！");
                this.txtRIRR.Text = "0.000";
            }
            else
            {
                this.txtRIRR.Text = LINT_IRR.ToString("0.000");
            }
            this.txtRIRR.Text = LINT_IRR.ToString("0.000");

            //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
            this.txtRNPVRATECOST0.Text = "1";

            //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV成本的值固定帶4.
            ////Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
            //double LINT_NPVRATECOST = GET_NPVRATECOST();
            //this.txtRNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
            //Modify 20240815 利率成本改4.75%
            //this.txtRNPVRATECOST.Text = "4";
            this.txtRNPVRATECOST.Text = "4.75";
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            this.txtRNPVRATECOST2.Text = "5";

            //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
            double LINT_NPV0 = 0;

            //Modify 20120618 By SS Gordon. Reason: 新增AR案件的NPV計算，與原本NPV計算分開
            //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
            //double LINT_NPV = NPV_Cal();
            double LINT_NPV = 0;
            double LINT_NPV2 = 0;
            if (this.drpMAINTYPE.SelectedValue == "04")
            {
                if (!chkMLDCONTRACTARD()) return;  //20150127 加入AR明細必填欄位檢核
                LINT_NPV0 = NPV_Cal_AR(txtRNPVRATECOST0.Text);

                LINT_NPV = NPV_Cal_AR(txtRNPVRATECOST.Text);
                LINT_NPV2 = NPV_Cal_AR(txtRNPVRATECOST2.Text);
            }
            else
            {
                LINT_NPV0 = NPV_Cal(txtRNPVRATECOST0.Text);

                LINT_NPV = NPV_Cal(txtRNPVRATECOST.Text);
                LINT_NPV2 = NPV_Cal(txtRNPVRATECOST2.Text);
            }

            this.txtRNPV0.Text = LINT_NPV0.ToString("0");

            this.txtRNPV.Text = LINT_NPV.ToString("0");
            this.txtRNPV2.Text = LINT_NPV2.ToString("0");
        }
        catch (Exception ex)
        {
            Alert(ex.Message.Replace("'", "").Replace("\n", ""));
        }
        this.UpdatePanelIRR.Update();

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPV0.Update();

        this.UpdatePanelNPV.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPV2.Update();

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPVRATECOST0.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNPVRATECOST.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPVRATECOST2.Update();
    }

    static string GetChineseNumber(string number)
    {
        string[] chineseNumber = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        string[] unit = { "", "十", "百", "千", "萬", "十萬", "百萬", "千萬", "億", "十億", "百億", "千億", "兆", "十兆", "百兆", "千兆" };
        StringBuilder ret = new StringBuilder();
        string inputNumber = number.ToString();
        int idx = inputNumber.Length;
        bool needAppendZero = false;
        foreach (char c in inputNumber)
        {
            idx--;
            if (c > '0')
            {
                if (needAppendZero)
                {
                    ret.Append(chineseNumber[0]);
                    needAppendZero = false;
                }
                ret.Append(chineseNumber[(int)(c - '0')] + unit[idx]);
            }
            else
                needAppendZero = true;
        }
        return ret.Length == 0 ? chineseNumber[0] : ret.ToString();
    }
    private void Report(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
    {
        try
        {
            DataSet LDST_Data = null;
            ReturnObject<DataSet> LOBJ_ReturnObject = GetReportDataByID(LSTR_CUSTID, LSTR_CASEID, LSTR_CONTID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                LDST_Data = LOBJ_ReturnObject.ReturnData;
            }
            //承做類型
            string LSTR_MAINTYPE = LDST_Data.Tables[2].Rows[0]["MAINTYPE"].ToString();
            string LSTR_Type = LSTR_MAINTYPE;
            if (LSTR_Type == "03")
            {
                string LSTR_SUBTYPE = LDST_Data.Tables[2].Rows[0]["SUBTYPE"].ToString();
                LSTR_Type += LSTR_SUBTYPE;
            }
            //表格信息
            //客戶信息
            string LSTR_CUSTNAME = LDST_Data.Tables[0].Rows[0]["CUSTNAME"].ToString(); //客戶名稱
            string LSTR_PARENTCUSTNAME = LDST_Data.Tables[0].Rows[0]["PARENTCUSTNAME"].ToString();  //公司名稱
            string LSTR_PARENTCUSTID = LDST_Data.Tables[0].Rows[0]["PARENTCUSTID"].ToString();      //公司編號
            string LSTR_CUSTZIPADD = LDST_Data.Tables[0].Rows[0]["CUSTZIPCODES"].ToString().Trim() + LDST_Data.Tables[0].Rows[0]["CUSTADDR"].ToString().Trim(); //公司地址
            string LSTR_CUSTTEL = LDST_Data.Tables[0].Rows[0]["CUSTTELCODE"].ToString().Trim() + "-" + LDST_Data.Tables[0].Rows[0]["CUSTTEL"].ToString().Trim(); //公司電話
            string LSTR_CUSTFAX = LDST_Data.Tables[0].Rows[0]["CUSTFAXCODE"].ToString().Trim() + "-" + LDST_Data.Tables[0].Rows[0]["CUSTFAX"].ToString().Trim(); //公司電話

            string LSTR_OWNER = LDST_Data.Tables[0].Rows[0]["OWNER"].ToString(); //負責人

            //申請金額
            string LSTR_APLIMIT = "";
            string LSTR_FINANCIALFEES = "";
            string LSTR_TRANSCOST = "";
            string LSTR_OTHERFEES = "";
            //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
            string LSTR_OTHERFEESNOTAX = "";
            string LSTR_TOTALPAY = "";
            if (LSTR_Type == "04")
            {
                LSTR_APLIMIT = LDST_Data.Tables[3].Rows[0]["APLIMIT"].ToString();
                LSTR_FINANCIALFEES = LDST_Data.Tables[3].Rows[0]["FINANCIALFEES"].ToString();
            }
            else
            {
                //TRANSCOST標的物購買價格
                LSTR_TRANSCOST = LDST_Data.Tables[4].Rows[0]["TRANSCOST"].ToString();
                LSTR_OTHERFEES = LDST_Data.Tables[4].Rows[0]["OTHERFEES"].ToString();
                //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
                LSTR_OTHERFEESNOTAX = LDST_Data.Tables[4].Rows[0]["OTHERFEESNOTAX"].ToString();
                LSTR_OTHERFEES = (Convert.ToDouble("0" + LSTR_OTHERFEES) + Convert.ToDouble("0" + LSTR_OTHERFEESNOTAX)).ToString();

                LSTR_TOTALPAY = (Convert.ToDouble("0" + LSTR_TRANSCOST) + Convert.ToDouble("0" + LSTR_OTHERFEES)).ToString();
            }
            //當前日
            string LSTR_DATENOW = Itg.Community.Util.GetRocYear(DateTime.Now.ToString("yyyy/MM/dd"));
            string LSTR_DATENOWY = LSTR_DATENOW.Substring(0, 3);
            string LSTR_DATENOWM = LSTR_DATENOW.Substring(3, 2);
            string LSTR_DATENOWD = LSTR_DATENOW.Substring(5, 2);
            //承做信息
            //起租日
            string LSTR_RENTSTDT = Itg.Community.Util.GetRocYear(LDST_Data.Tables[7].Rows[0]["RENTSTDT"].ToString());
            string LSTR_RENTSTDTY = LSTR_RENTSTDT.Substring(0, 3);
            string LSTR_RENTSTDTM = LSTR_RENTSTDT.Substring(3, 2);
            string LSTR_RENTSTDTD = LSTR_RENTSTDT.Substring(5, 2);
            //承做月數
            string LSTR_CONTRACTMONTH = LDST_Data.Tables[7].Rows[0]["CONTRACTMONTH"].ToString();
            //迄租日
            DateTime LDAT_RENTSTDT = Convert.ToDateTime(LDST_Data.Tables[7].Rows[0]["RENTSTDT"].ToString());
            DateTime LDAT_RENTENDT = LDAT_RENTSTDT.AddMonths(Convert.ToInt32(LSTR_CONTRACTMONTH));
            string LSTR_RENTENDT = Itg.Community.Util.GetRocYear(LDAT_RENTENDT.ToString("yyyy/MM/dd"));
            string LSTR_RENTENDTY = LSTR_RENTENDT.Substring(0, 3);
            string LSTR_RENTENDTM = LSTR_RENTENDT.Substring(3, 2);
            string LSTR_RENTENDTD = LSTR_RENTENDT.Substring(5, 2);
            //付款方式
            string LSTR_CUSTPAYTYPE = LDST_Data.Tables[7].Rows[0]["CUSTPAYTYPE"].ToString();
            string LSTR_CUSTPAYTYPEName = "";
            foreach (ListItem temp in drpRCUSTPAYTYPE.Items)
            {
                if (temp.Value == LSTR_CUSTPAYTYPE)
                {
                    LSTR_CUSTPAYTYPEName = temp.Text;
                    break;
                }
            }
            //幾月一付
            string LSTR_PAYMONTH = LDST_Data.Tables[7].Rows[0]["PAYMONTH"].ToString();
            //每月_日繳納
            string LDAT_CUSTFPAYDATE = Itg.Community.Util.GetRocYear(LDST_Data.Tables[7].Rows[0]["CUSTFPAYDATE"].ToString());
            string LSTR_CUSTFPAYDATED = LDAT_CUSTFPAYDATE.Substring(5, 2);
            //保證金
            string LSTR_PERBOND = Itg.Community.Util.NumberFormat((Convert.ToDouble("0" + LDST_Data.Tables[7].Rows[0]["PERBOND"].ToString()) +
                                                                   Convert.ToDouble("0" + LDST_Data.Tables[7].Rows[0]["PURCHASEMARGIN"].ToString())).ToString());
            string LSTR_FIRSTPAY = LDST_Data.Tables[7].Rows[0]["FIRSTPAY"].ToString();
            string LSTR_FEE = LDST_Data.Tables[7].Rows[0]["FEE"].ToString();
            //撥款案件租賃分期明細檔
            //STARTPAY
            string LSTR_STARTPAY1 = LDST_Data.Tables[8].Rows[0]["STARTPAY"].ToString();
            string LSTR_STARTPAY2 = LDST_Data.Tables[8].Rows[1]["STARTPAY"].ToString();
            string LSTR_STARTPAY3 = LDST_Data.Tables[8].Rows[2]["STARTPAY"].ToString();
            string LSTR_STARTPAY4 = LDST_Data.Tables[8].Rows[3]["STARTPAY"].ToString();
            //ENDPAY
            string LSTR_ENDPAY1 = LDST_Data.Tables[8].Rows[0]["ENDPAY"].ToString();
            string LSTR_ENDPAY2 = LDST_Data.Tables[8].Rows[1]["ENDPAY"].ToString();
            string LSTR_ENDPAY3 = LDST_Data.Tables[8].Rows[2]["ENDPAY"].ToString();
            string LSTR_ENDPAY4 = LDST_Data.Tables[8].Rows[3]["ENDPAY"].ToString();
            //PRINCIPALTAX
            string LSTR_PRINCIPALTAX1 = Itg.Community.Util.NumberFormat(LDST_Data.Tables[8].Rows[0]["PRINCIPALTAX"].ToString());
            string LSTR_PRINCIPALTAX2 = Itg.Community.Util.NumberFormat(LDST_Data.Tables[8].Rows[1]["PRINCIPALTAX"].ToString());
            string LSTR_PRINCIPALTAX3 = Itg.Community.Util.NumberFormat(LDST_Data.Tables[8].Rows[2]["PRINCIPALTAX"].ToString());
            string LSTR_PRINCIPALTAX4 = Itg.Community.Util.NumberFormat(LDST_Data.Tables[8].Rows[3]["PRINCIPALTAX"].ToString());
            //標的物
            DataTable LDAT_MLDCONTRACTTARGET = LDST_Data.Tables[6];
            string LSTR_STOREDADDR = "";
            if (LDAT_MLDCONTRACTTARGET.Rows.Count > 0)
            {
                LSTR_STOREDADDR = LDAT_MLDCONTRACTTARGET.Rows[0]["STOREDZIPCODES"].ToString().Trim() + LDAT_MLDCONTRACTTARGET.Rows[0]["STOREDADDR"].ToString().Trim();
            }
            //案件申請保證人
            DataTable MLDCASEGUARANTEE = LDST_Data.Tables[1];
            string FileName = "";
            string Fname = "";
            string TemplateFile = "";
            if (LSTR_Type == "01")//營租
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                object collapseStart = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;
                TemplateFile = Server.MapPath("~/Template/CreditRepor_YZ.dot"); ;
                Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCNTRNO.Text + ".doc";

                //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
                //FileName = Server.MapPath("~/Upload/" + Fname);
                FileName = Server.MapPath("~/MLUPLOAD/CNTRNO/" + Fname);

                File.Copy(TemplateFile, FileName);
                object Obj_FileName = FileName;
                object Visible = false;
                object ReadOnly = false;
                object missing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                                         ref missing, ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref Visible,
                                         ref missing, ref missing, ref missing,
                                         ref missing);
                doc.Activate();
                object cou8 = 8;
                object cou2 = 2;
                object cou3 = 3;
                object num1 = 1;
                //將光標移動到標的物的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou8, ref missing);
                for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                {
                    //標的物名稱
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETNAME"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //規格/型式/機號
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMODELNO"].ToString() + "/" + LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMACHINENO"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //製造廠商/廠牌
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDS"].ToString() + "/" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //單位
                    doc.Application.Selection.TypeText("");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //數量
                    doc.Application.Selection.TypeText("1");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        //換行
                        doc.Application.Selection.InsertRows(ref num1);
                        doc.Application.Selection.Collapse(ref collapseStart);
                    }
                }
                //將光標移動到標的物出售人的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou2, ref missing);
                doc.Application.Selection.MoveLeft(ref missing, ref num1, ref missing);
                ArrayList LVAR_SUPPLIER = new ArrayList();
                for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                {
                    string LSTR_SUPPLIERID = LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString();
                    if (!LVAR_SUPPLIER.Contains(LSTR_SUPPLIERID))
                    {
                        doc.Application.Selection.TypeText("公司名稱：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDS"].ToString());
                        doc.Application.Selection.TypeParagraph();
                        doc.Application.Selection.TypeText("公司統編：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString());
                        doc.Application.Selection.TypeParagraph();
                        //doc.Application.Selection.TypeText("營業地址：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDADD"].ToString());
                        if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                        {
                            doc.Application.Selection.TypeParagraph();
                            doc.Application.Selection.TypeParagraph();
                        }
                        LVAR_SUPPLIER.Add(LSTR_SUPPLIERID);
                    }
                }
                //將光標移動到連帶保證人的位置
                object objwdStory = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                doc.Application.Selection.EndKey(ref objwdStory, ref missing);
                doc.Application.Selection.MoveUp(ref missing, ref cou3, ref missing);
                for (int i = 0; i < MLDCASEGUARANTEE.Rows.Count; i++)
                {
                    doc.Application.Selection.TypeText("連帶保證人：" + LSTR_CUSTNAME);
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("法定代理人：" + MLDCASEGUARANTEE.Rows[i]["GRTNAME"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("地　　　址：" + LSTR_CUSTZIPADD);
                    doc.Application.Selection.TypeParagraph();
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        doc.Application.Selection.TypeParagraph();
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        //編號
                        case "CNTRNO":
                            bm.Range.Text = LSTR_CONTID;
                            break;
                        //承租人
                        case "CUSTNAME":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        case "CUSTNAME2":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //公司名稱
                        case "PARENTCUSTNAME":
                            bm.Range.Text = LSTR_PARENTCUSTNAME;
                            break;
                        //公司編號
                        case "PARENTCUSTID":
                            bm.Range.Text = LSTR_PARENTCUSTID;
                            break;
                        //公司地址
                        case "BUSINESSADDR":
                            bm.Range.Text = LSTR_CUSTZIPADD;
                            break;
                        //起租日
                        case "RENTSTDTY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "RENTSTDTM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "RENTSTDTD":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //承做月數
                        case "CONTRACTMONTH":
                            bm.Range.Text = LSTR_CONTRACTMONTH;
                            break;
                        case "CONTRACTMONTH2":
                            bm.Range.Text = LSTR_CONTRACTMONTH;
                            break;
                        //撥款案件租賃分期明細檔
                        case "STARTPAY1":
                            bm.Range.Text = LSTR_STARTPAY1;
                            break;
                        case "STARTPAY2":
                            bm.Range.Text = LSTR_STARTPAY2;
                            break;
                        case "STARTPAY3":
                            bm.Range.Text = LSTR_STARTPAY3;
                            break;
                        case "STARTPAY4":
                            bm.Range.Text = LSTR_STARTPAY4;
                            break;
                        case "ENDPAY1":
                            bm.Range.Text = LSTR_ENDPAY1;
                            break;
                        case "ENDPAY2":
                            bm.Range.Text = LSTR_ENDPAY2;
                            break;
                        case "ENDPAY3":
                            bm.Range.Text = LSTR_ENDPAY3;
                            break;
                        case "ENDPAY4":
                            bm.Range.Text = LSTR_ENDPAY4;
                            break;
                        case "PRINCIPALTAX1":
                            bm.Range.Text = LSTR_PRINCIPALTAX1;
                            break;
                        case "PRINCIPALTAX2":
                            bm.Range.Text = LSTR_PRINCIPALTAX2;
                            break;
                        case "PRINCIPALTAX3":
                            bm.Range.Text = LSTR_PRINCIPALTAX3;
                            break;
                        case "PRINCIPALTAX4":
                            bm.Range.Text = LSTR_PRINCIPALTAX4;
                            break;
                        //付款方式
                        case "CUSTPAYTYPE":
                            bm.Range.Text = LSTR_CUSTPAYTYPEName;
                            break;
                        //每月_日繳納
                        case "PAYDATEM":
                            bm.Range.Text = LSTR_CUSTFPAYDATED;
                            break;
                        //保證金
                        case "PERBOND":
                            bm.Range.Text = LSTR_PERBOND;
                            break;
                        //負責人  
                        case "OWNER":
                            bm.Range.Text = LSTR_OWNER;
                            break;
                        //標的物存放地
                        case "STOREDADDR":
                            bm.Range.Text = LSTR_STOREDADDR;
                            break;
                        //
                        case "DATENOWY":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        default:
                            break;
                    }
                }
                object IsSave = true;
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref IsSave, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            else if (LSTR_Type == "02")
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                object collapseStart = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

                TemplateFile = Server.MapPath("~/Template/CreditRepor_ZZ.dot"); ;
                Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCNTRNO.Text + ".doc";

                //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
                //FileName = Server.MapPath("~/Upload/" + Fname);
                FileName = Server.MapPath("~/MLUPLOAD/CNTRNO/" + Fname);

                File.Copy(TemplateFile, FileName);
                object Obj_FileName = FileName;
                object Visible = false;
                object ReadOnly = false;
                object missing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                                         ref missing, ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref Visible,
                                         ref missing, ref missing, ref missing,
                                         ref missing);
                doc.Activate();
                object cou5 = 5;
                object num18 = 18;
                object num1 = 1;
                object cou2 = 2;
                //將光標移動到標的物的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou5, ref missing);
                doc.Application.Selection.MoveRight(ref missing, ref num18, ref missing);
                for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                {
                    //標的物名稱
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETNAME"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //規格
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMODELNO"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //製造廠商
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDS"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //廠牌
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //單位
                    doc.Application.Selection.TypeText("");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //數量
                    doc.Application.Selection.TypeText("1");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        //換行
                        doc.Application.Selection.InsertRows(ref num1);
                        doc.Application.Selection.Collapse(ref collapseStart);
                    }
                }
                //將光標移動到標的物出售人的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou2, ref missing);
                ArrayList LVAR_SUPPLIER = new ArrayList();
                for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                {
                    string LSTR_SUPPLIERID = LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString();
                    if (!LVAR_SUPPLIER.Contains(LSTR_SUPPLIERID))
                    {
                        doc.Application.Selection.TypeText("公司名稱：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDS"].ToString());
                        doc.Application.Selection.TypeParagraph();
                        doc.Application.Selection.TypeText("公司統編：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString());
                        doc.Application.Selection.TypeParagraph();
                        //doc.Application.Selection.TypeText("營業地址：" + LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDADD"].ToString());
                        if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                        {
                            doc.Application.Selection.TypeParagraph();
                            doc.Application.Selection.TypeParagraph();
                        }
                        LVAR_SUPPLIER.Add(LSTR_SUPPLIERID);
                    }
                }
                //將光標移動到連帶人的位置
                object objwdStory = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                doc.Application.Selection.EndKey(ref objwdStory, ref missing);
                doc.Application.Selection.MoveUp(ref missing, ref num1, ref missing);
                for (int i = 0; i < MLDCASEGUARANTEE.Rows.Count; i++)
                {
                    doc.Application.Selection.TypeText("承租人連帶保證人：" + MLDCASEGUARANTEE.Rows[i]["GRTNAME"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("　　地　　　　址：" + LSTR_CUSTZIPADD);
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("身分證統一編號：" + MLDCASEGUARANTEE.Rows[i]["GRTCODE"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        doc.Application.Selection.TypeParagraph();
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        //編號
                        case "CNTRNO":
                            bm.Range.Text = LSTR_CONTID;
                            break;
                        //承租人
                        case "CUSTNAME":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        case "CUSTNAME2":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //負責人  
                        case "OWNER":
                            bm.Range.Text = LSTR_OWNER;
                            break;
                        //公司地址
                        case "BUSINESSADDR":
                            bm.Range.Text = LSTR_CUSTZIPADD;
                            break;
                        //預定交付日
                        case "PAYDATEY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "PAYDATEM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "PAYDATED":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //起租日
                        case "RENTSTDTY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "RENTSTDTM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "RENTSTDTD":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //起租日
                        case "RENTSTDTY2":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "RENTSTDTM2":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "RENTSTDTD2":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //標的物處所
                        case "STOREDADDR":
                            bm.Range.Text = LSTR_STOREDADDR;
                            break;
                        //標的物購買價格
                        case "TARGETPRICENOTAX":
                            bm.Range.Text = GetChineseNumber(LSTR_TRANSCOST);
                            break;
                        //標的物其他價格
                        case "SALESPAY":
                            bm.Range.Text = GetChineseNumber(LSTR_OTHERFEES);
                            break;
                        //總價
                        case "TOTALPAY":
                            bm.Range.Text = GetChineseNumber(LSTR_TOTALPAY);
                            break;
                        //幾月一付
                        case "PAYMONTH":
                            bm.Range.Text = LSTR_PAYMONTH;
                            break;
                        //承做月數
                        case "CONTRACTMONTH":
                            bm.Range.Text = LSTR_CONTRACTMONTH;
                            break;
                        case "CONTRACTMONTH2":
                            bm.Range.Text = LSTR_CONTRACTMONTH;
                            break;
                        //撥款案件租賃分期明細檔
                        case "STARTPAY1":
                            bm.Range.Text = LSTR_STARTPAY1;
                            break;
                        case "STARTPAY2":
                            bm.Range.Text = LSTR_STARTPAY2;
                            break;
                        case "STARTPAY3":
                            bm.Range.Text = LSTR_STARTPAY3;
                            break;
                        case "STARTPAY4":
                            bm.Range.Text = LSTR_STARTPAY4;
                            break;
                        case "ENDPAY1":
                            bm.Range.Text = LSTR_ENDPAY1;
                            break;
                        case "ENDPAY2":
                            bm.Range.Text = LSTR_ENDPAY2;
                            break;
                        case "ENDPAY3":
                            bm.Range.Text = LSTR_ENDPAY3;
                            break;
                        case "ENDPAY4":
                            bm.Range.Text = LSTR_ENDPAY4;
                            break;
                        case "PRINCIPALTAX1":
                            bm.Range.Text = LSTR_PRINCIPALTAX1;
                            break;
                        case "PRINCIPALTAX2":
                            bm.Range.Text = LSTR_PRINCIPALTAX2;
                            break;
                        case "PRINCIPALTAX3":
                            bm.Range.Text = LSTR_PRINCIPALTAX3;
                            break;
                        case "PRINCIPALTAX4":
                            bm.Range.Text = LSTR_PRINCIPALTAX4;
                            break;
                        //起租日
                        case "PAYTIMEY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "PAYTIMEM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "PAYTIMED":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //付款方式
                        case "CUSTPAYTYPE":
                            bm.Range.Text = LSTR_CUSTPAYTYPEName;
                            break;
                        //每月_日
                        case "PAYDATEMD":
                            bm.Range.Text = LSTR_CUSTFPAYDATED;
                            break;
                        //頭期款
                        case "FIRSTPAY":
                            bm.Range.Text = GetChineseNumber(LSTR_FIRSTPAY);
                            break;
                        //手續費收入
                        case "FEE":
                            bm.Range.Text = GetChineseNumber(LSTR_FEE);
                            break;
                        //
                        case "DATENOWY":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        default:
                            break;
                    }
                }
                object IsSave = true;
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref IsSave, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            else if (LSTR_Type == "0301")
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

                object collapseStart = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

                TemplateFile = Server.MapPath("~/Template/CreditRepor_FQ1.dot"); ;
                Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCNTRNO.Text + ".doc";

                //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
                //FileName = Server.MapPath("~/Upload/" + Fname);
                FileName = Server.MapPath("~/MLUPLOAD/CNTRNO/" + Fname);

                File.Copy(TemplateFile, FileName);
                object Obj_FileName = FileName;
                object Visible = false;
                object ReadOnly = false;
                object missing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                                         ref missing, ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref Visible,
                                         ref missing, ref missing, ref missing,
                                         ref missing);
                doc.Activate();
                //將光標移動到標的物的位置
                object cou1 = 1;
                object cou2 = 2;
                object cou3 = 3;
                object cou4 = 4;
                object cou6 = 6;
                object cou7 = 7;
                object cou8 = 8;
                object cou10 = 10;
                if (LDAT_MLDCONTRACTTARGET.Rows.Count == 0)
                {
                    doc.Application.Selection.MoveDown(ref missing, ref cou10, ref missing);
                }
                else if (LDAT_MLDCONTRACTTARGET.Rows.Count == 1)
                {
                    doc.Application.Selection.MoveDown(ref missing, ref cou7, ref missing);
                    doc.Application.Selection.MoveRight(ref missing, ref cou6, ref missing);
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[0]["TARGETNAME"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    doc.Application.Selection.MoveDown(ref missing, ref cou1, ref missing);
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[0]["TARGETID"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[0]["TARGETMODELNO"].ToString() + "/" + LDAT_MLDCONTRACTTARGET.Rows[0]["TARGETMACHINENO"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    doc.Application.Selection.TypeText("1");
                    doc.Application.Selection.MoveRight(ref missing, ref cou3, ref missing);
                }
                else if (LDAT_MLDCONTRACTTARGET.Rows.Count > 1)
                {
                    object objwdExtend = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
                    Microsoft.Office.Interop.Word.WdRecoveryType objwdPasteDefault = Microsoft.Office.Interop.Word.WdRecoveryType.wdPasteDefault;
                    doc.Application.Selection.MoveDown(ref missing, ref cou7, ref missing);
                    //copy表格
                    doc.Application.Selection.MoveDown(ref missing, ref cou2, ref objwdExtend);
                    doc.Application.Selection.MoveRight(ref missing, ref cou3, ref objwdExtend);
                    doc.Application.Selection.Copy();
                    doc.Application.Selection.MoveLeft(ref missing, ref cou1, ref missing);
                    doc.Application.Selection.MoveRight(ref missing, ref cou6, ref missing);

                    for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                    {
                        doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETNAME"].ToString());
                        doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                        doc.Application.Selection.MoveDown(ref missing, ref cou1, ref missing);
                        doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETID"].ToString());
                        doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                        doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMODELNO"].ToString() + "/" + LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMACHINENO"].ToString());
                        doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                        doc.Application.Selection.TypeText("1");
                        doc.Application.Selection.MoveRight(ref missing, ref cou3, ref missing);
                        if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                        {
                            doc.Application.Selection.PasteAndFormat(objwdPasteDefault);
                            doc.Application.Selection.MoveUp(ref missing, ref cou3, ref missing);
                            doc.Application.Selection.MoveRight(ref missing, ref cou6, ref missing);
                        }
                    }
                }
                //將光標移動到標的物的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou8, ref missing);
                int LINT_CONTRACTMONTH = Convert.ToInt32(LSTR_CONTRACTMONTH);
                int LINT_LoopNum = LINT_CONTRACTMONTH / 3;
                if (LINT_CONTRACTMONTH % 3 != 0)
                {
                    LINT_LoopNum += 1;
                }
                //生成數組
                ArrayList LVAR_NUM = new ArrayList();
                ArrayList LVAR_Date = new ArrayList();
                ArrayList LVAR_PAY = new ArrayList();
                //期別
                int LINT_ENDPAY1 = Convert.ToInt32("0" + LSTR_ENDPAY1);
                int LINT_ENDPAY2 = Convert.ToInt32("0" + LSTR_ENDPAY2);
                int LINT_ENDPAY3 = Convert.ToInt32("0" + LSTR_ENDPAY3);
                int LINT_ENDPAY4 = Convert.ToInt32("0" + LSTR_ENDPAY4);
                for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
                {
                    LVAR_NUM.Add(i);
                    LVAR_Date.Add(Itg.Community.Util.GetRocYear((LDAT_RENTSTDT.AddMonths(i)).ToString("yyyy/MM/dd")));
                    if (i >= 1 && i <= LINT_ENDPAY1)
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX1);
                    }
                    else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX2);
                    }
                    else if ((i > LINT_ENDPAY2 && i <= LINT_ENDPAY3))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX3);
                    }
                    else if ((i > LINT_ENDPAY3 && i <= LINT_ENDPAY4))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX4);
                    }
                }
                for (int j = 0; j < LINT_LoopNum; j++)
                {
                    int LINT_N1 = j * 3;
                    int LINT_N2 = j * 3 + 1;
                    int LINT_N3 = j * 3 + 2;
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N1].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N1].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N1].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N1].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N2].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N2].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N2].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N2].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N3].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N3].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N3].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N3].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    if (j != LINT_LoopNum - 1)
                    {
                        //換行
                        doc.Application.Selection.InsertRows(ref cou1);
                        doc.Application.Selection.Collapse(ref collapseStart);
                    }
                }
                //將光標移動到連帶保證人的位置
                object objwdStory = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                doc.Application.Selection.EndKey(ref objwdStory, ref missing);
                doc.Application.Selection.MoveUp(ref missing, ref cou4, ref missing);
                for (int i = 0; i < MLDCASEGUARANTEE.Rows.Count; i++)
                {
                    doc.Application.Selection.TypeText("連帶保證人 :" + MLDCASEGUARANTEE.Rows[i]["GRTNAME"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("身分證字號 :" + MLDCASEGUARANTEE.Rows[i]["GRTCODE"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("電       話:" + LSTR_CUSTTEL);
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("地       址:" + LSTR_CUSTZIPADD);
                    doc.Application.Selection.TypeParagraph();
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        doc.Application.Selection.TypeParagraph();
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        //編號
                        case "CNTRNO":
                            bm.Range.Text = LSTR_CONTID;
                            break;
                        //承租人
                        case "CUSTNAME":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //總價
                        case "ACTUSLLOANS":
                            bm.Range.Text = GetChineseNumber(LSTR_TOTALPAY);
                            break;
                        //頭期款
                        case "FIRSTPAY":
                            bm.Range.Text = GetChineseNumber(LSTR_FIRSTPAY);
                            break;
                        //手續費收入
                        case "FEE":
                            bm.Range.Text = GetChineseNumber(LSTR_FEE);
                            break;
                        //乙方-----------------------
                        case "CUSTNAME2":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //乙方統一編號
                        case "CUSTID":
                            bm.Range.Text = LSTR_CUSTID;
                            break;
                        //法定代理人
                        case "OWNER":
                            bm.Range.Text = LSTR_OWNER;
                            break;
                        //地址
                        case "BUSINESSADDR":
                            bm.Range.Text = LSTR_CUSTZIPADD;
                            break;
                        //起租日
                        case "RENTSTDTY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "RENTSTDTM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "RENTSTDTD":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //迄租日
                        case "RENTENDTY":
                            bm.Range.Text = LSTR_RENTENDTY;
                            break;
                        case "RENTENDTM":
                            bm.Range.Text = LSTR_RENTENDTM;
                            break;
                        case "RENTENDTD":
                            bm.Range.Text = LSTR_RENTENDTD;
                            break;
                        //
                        case "DATENOWY":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY1":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM1":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD1":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY2":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM2":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD2":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY3":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM3":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD3":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        default:
                            break;
                    }
                }
                object IsSave = true;
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref IsSave, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            else if (LSTR_Type == "0302")
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

                object collapseStart = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

                TemplateFile = Server.MapPath("~/Template/CreditRepor_FQ2.dot"); ;
                Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCNTRNO.Text + ".doc";

                //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
                //FileName = Server.MapPath("~/Upload/" + Fname);
                FileName = Server.MapPath("~/MLUPLOAD/CNTRNO/" + Fname);

                File.Copy(TemplateFile, FileName);
                object Obj_FileName = FileName;
                object Visible = false;
                object ReadOnly = false;
                object missing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                                         ref missing, ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref Visible,
                                         ref missing, ref missing, ref missing,
                                         ref missing);
                doc.Activate();
                object cou7 = 7;
                object num1 = 1;
                object num30 = 30;
                //將光標移動到標的物的位置
                doc.Application.Selection.MoveDown(ref missing, ref cou7, ref missing);
                doc.Application.Selection.MoveRight(ref missing, ref num30, ref missing);
                for (int i = 0; i < LDAT_MLDCONTRACTTARGET.Rows.Count; i++)
                {
                    //標的物名稱
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETNAME"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //規格
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["TARGETMODELNO"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //製造廠商
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERIDS"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //廠牌
                    doc.Application.Selection.TypeText(LDAT_MLDCONTRACTTARGET.Rows[i]["SUPPLIERID"].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //單位
                    doc.Application.Selection.TypeText("");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    //數量
                    doc.Application.Selection.TypeText("1");
                    doc.Application.Selection.MoveRight(ref missing, ref num1, ref missing);
                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        //換行
                        doc.Application.Selection.InsertRows(ref num1);
                        doc.Application.Selection.Collapse(ref collapseStart);
                    }
                }
                object cou11 = 11;
                object cou1 = 1;
                object cou2 = 2;
                object cou3 = 3;
                object num2 = 2;
                doc.Application.Selection.MoveDown(ref missing, ref cou11, ref missing);
                doc.Application.Selection.MoveRight(ref missing, ref num2, ref missing);
                doc.Application.Selection.MoveDown(ref missing, ref num2, ref missing);

                int LINT_CONTRACTMONTH = Convert.ToInt32(LSTR_CONTRACTMONTH);
                int LINT_LoopNum = LINT_CONTRACTMONTH / 3;
                if (LINT_CONTRACTMONTH % 3 != 0)
                {
                    LINT_LoopNum += 1;
                }

                //生成數組
                ArrayList LVAR_NUM = new ArrayList();
                ArrayList LVAR_Date = new ArrayList();
                ArrayList LVAR_PAY = new ArrayList();

                //期別
                int LINT_ENDPAY1 = Convert.ToInt32("0" + LSTR_ENDPAY1);
                int LINT_ENDPAY2 = Convert.ToInt32("0" + LSTR_ENDPAY2);
                int LINT_ENDPAY3 = Convert.ToInt32("0" + LSTR_ENDPAY3);
                int LINT_ENDPAY4 = Convert.ToInt32("0" + LSTR_ENDPAY4);

                for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
                {
                    LVAR_NUM.Add(i);
                    LVAR_Date.Add(Itg.Community.Util.GetRocYear((LDAT_RENTSTDT.AddMonths(i)).ToString("yyyy/MM/dd")));
                    if (i >= 1 && i <= LINT_ENDPAY1)
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX1);
                    }
                    else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX2);
                    }
                    else if ((i > LINT_ENDPAY2 && i <= LINT_ENDPAY3))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX3);
                    }
                    else if ((i > LINT_ENDPAY3 && i <= LINT_ENDPAY4))
                    {
                        LVAR_PAY.Add("$" + LSTR_PRINCIPALTAX4);
                    }
                }
                for (int j = 0; j < LINT_LoopNum; j++)
                {
                    int LINT_N1 = j * 3;
                    int LINT_N2 = j * 3 + 1;
                    int LINT_N3 = j * 3 + 2;
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N1].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N1].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N1].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N1].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N2].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N2].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N2].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N2].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //期別
                    doc.Application.Selection.TypeText(LVAR_NUM[LINT_N3].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 年
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N3].ToString().Substring(0, 3));
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    //付款日 月
                    doc.Application.Selection.TypeText(LVAR_Date[LINT_N3].ToString().Substring(3, 2));
                    doc.Application.Selection.MoveRight(ref missing, ref cou2, ref missing);
                    //金額
                    doc.Application.Selection.TypeText(LVAR_PAY[LINT_N3].ToString());
                    doc.Application.Selection.MoveRight(ref missing, ref cou1, ref missing);
                    if (j != LINT_LoopNum - 1)
                    {
                        //換行
                        doc.Application.Selection.InsertRows(ref cou1);
                        doc.Application.Selection.Collapse(ref collapseStart);
                    }
                }
                //將光標移動到連帶人的位置
                object objwdStory = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                doc.Application.Selection.EndKey(ref objwdStory, ref missing);
                doc.Application.Selection.MoveUp(ref missing, ref cou3, ref missing);
                for (int i = 0; i < MLDCASEGUARANTEE.Rows.Count; i++)
                {
                    doc.Application.Selection.TypeText("乙方連帶保證人：" + MLDCASEGUARANTEE.Rows[i]["GRTNAME"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("身分證統一編號：" + MLDCASEGUARANTEE.Rows[i]["GRTCODE"].ToString());
                    doc.Application.Selection.TypeParagraph();
                    doc.Application.Selection.TypeText("地       址:" + LSTR_CUSTZIPADD);
                    doc.Application.Selection.TypeParagraph();

                    if (i != LDAT_MLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        doc.Application.Selection.TypeParagraph();
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        //編號
                        case "CNTRNO":
                            bm.Range.Text = LSTR_CONTID;
                            break;
                        //承租人
                        case "CUSTNAME":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //頭期款
                        case "FIRSTPAY":
                            bm.Range.Text = GetChineseNumber(LSTR_FIRSTPAY);
                            break;
                        //其餘金額(標的物金額-頭期款)
                        case "OTHERFEES":
                            bm.Range.Text = GetChineseNumber((Convert.ToDouble("0" + LSTR_TRANSCOST) - Convert.ToDouble("0" + LSTR_FIRSTPAY)).ToString());
                            break;
                        //保證金
                        //case "PERBOND":
                        //  bm.Range.Text = GetChineseNumber(LSTR_PERBOND);
                        //  break;
                        case "STOREDADDR":
                            bm.Range.Text = LSTR_STOREDADDR;
                            break;
                        //乙方-----------------------
                        case "CUSTNAME2":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //乙方統一編號
                        case "CUSTID":
                            bm.Range.Text = LSTR_CUSTID;
                            break;
                        //法定代理人
                        case "OWNER":
                            bm.Range.Text = LSTR_OWNER;
                            break;
                        //地址
                        case "BUSINESSADDR":
                            bm.Range.Text = LSTR_CUSTZIPADD;
                            break;
                        //起租日
                        case "RENTSTDTY":
                            bm.Range.Text = LSTR_RENTSTDTY;
                            break;
                        case "RENTSTDTM":
                            bm.Range.Text = LSTR_RENTSTDTM;
                            break;
                        case "RENTSTDTD":
                            bm.Range.Text = LSTR_RENTSTDTD;
                            break;
                        //迄租日
                        case "RENTENDTY":
                            bm.Range.Text = LSTR_RENTENDTY;
                            break;
                        case "RENTENDTM":
                            bm.Range.Text = LSTR_RENTENDTM;
                            break;
                        case "RENTENDTD":
                            bm.Range.Text = LSTR_RENTENDTD;
                            break;
                        //
                        case "DATENOWY":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY1":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM1":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD1":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY2":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM2":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD2":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        //
                        case "DATENOWY3":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM3":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD3":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        default:
                            break;
                    }
                }
                object IsSave = true;
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref IsSave, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            else if (LSTR_Type == "04")
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                object collapseStart = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

                TemplateFile = Server.MapPath("~/Template/CreditRepor_AR.dot"); ;
                Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCNTRNO.Text + ".doc";

                //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
                //FileName = Server.MapPath("~/Upload/" + Fname);
                FileName = Server.MapPath("~/MLUPLOAD/CNTRNO/" + Fname);

                File.Copy(TemplateFile, FileName);
                object Obj_FileName = FileName;
                object Visible = false;
                object ReadOnly = false;
                object missing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                                         ref missing, ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref Visible,
                                         ref missing, ref missing, ref missing,
                                         ref missing);
                doc.Activate();
                foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
                {
                    switch (bm.Name)
                    {
                        //承租人
                        case "CUSTNAME":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //最高收買額度
                        case "APLIMIT":
                            bm.Range.Text = GetChineseNumber(LSTR_APLIMIT);
                            break;
                        //財務諮詢費
                        case "FINANCIALFEES":
                            bm.Range.Text = GetChineseNumber(LSTR_FINANCIALFEES);
                            break;
                        ////乙方銀行
                        //case "DEPOSITBANK":
                        //  bm.Range.Text = "高新區支行";
                        //  break;
                        ////乙方帳號
                        //case "ACCOUNT":
                        //  bm.Range.Text = "36111000000";
                        //  break;
                        //
                        //甲方-----------------------
                        case "CUSTNAME2":
                            bm.Range.Text = LSTR_CUSTNAME;
                            break;
                        //法定代理人
                        case "OWNER":
                            bm.Range.Text = LSTR_OWNER;
                            break;
                        //地址
                        case "BUSINESSADDR":
                            bm.Range.Text = LSTR_CUSTZIPADD;
                            break;
                        //電話
                        case "CUSTTEL":
                            bm.Range.Text = LSTR_CUSTTEL;
                            break;
                        //傳真
                        case "CUSTFAX":
                            bm.Range.Text = LSTR_CUSTFAX;
                            break;
                        case "DATENOWY":
                            bm.Range.Text = LSTR_DATENOWY;
                            break;
                        //
                        case "DATENOWM":
                            bm.Range.Text = LSTR_DATENOWM;
                            break;
                        //
                        case "DATENOWD":
                            bm.Range.Text = LSTR_DATENOWD;
                            break;
                        default:
                            break;
                    }
                }
                object IsSave = true;
                doc.Close(ref IsSave, ref missing, ref missing);
                app.Quit(ref IsSave, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }

            //2013.03.20 Edit by SEAN 修正產生合約書列印路徑
            //RegisterScript("window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');");
            RegisterScript("window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["Upload_CNTRNO_URL"] + Fname + "');");

        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    protected void btnContractPrint_Click(object sender, EventArgs e)
    {
        /*
        string FileName = "";
        string Fname = "";
        string TemplateFile = "";        
        if (this.drpMAINTYPE.SelectedValue == "01")//營租
        {
          TemplateFile = Server.MapPath("~/Template/CreditRepor_YZ.dot"); ;
          Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
          FileName = Server.MapPath("~/Upload/" + Fname);     
          File.Copy(TemplateFile, FileName);
        }
        else if (this.drpMAINTYPE.SelectedValue == "02")//營租
        {
          TemplateFile = Server.MapPath("~/Template/CreditRepor_ZZ.dot"); ;
          Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
          FileName = Server.MapPath("~/Upload/" + Fname); 
          File.Copy(TemplateFile, FileName);
        }
        else if (this.drpMAINTYPE.SelectedValue == "03")//營租
        {
          if (this.drpSUBTYPE.SelectedValue == "01")
          {
            TemplateFile = Server.MapPath("~/Template/CreditRepor_FQ1.dot"); ;
            Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
            FileName = Server.MapPath("~/Upload/" + Fname);    
            File.Copy(TemplateFile, FileName);         
          }
          else
          {
            TemplateFile = Server.MapPath("~/Template/CreditRepor_FQ2.dot"); ;
            Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
            FileName = Server.MapPath("~/Upload/" + Fname); 
            File.Copy(TemplateFile, FileName);        
          }
        }
        else if (this.drpMAINTYPE.SelectedValue == "04")//營租
        {
          TemplateFile = Server.MapPath("~/Template/CreditRepor_AR.dot"); ;
          Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
          FileName = Server.MapPath("~/Upload/" + Fname);     
          File.Copy(TemplateFile, FileName);
        }
        RegisterScript("window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');");
        */
        /*
ML3008R01 租賃契約書 營租事務機
ML3008R02 租賃契約書 營租非事務機
ML3008R03 租賃契約書 資租非事務機
ML3008R04 分期付款契約書 分期合約書
ML3008R05 附條件買賣契約書 分期附條買合約書
ML3008R06 國內應收帳款收買合約書 AR附追索權合約書
ML3008R07 國內應收帳款收買合約書 AR無附追索權合約書
ML3008R08 交貨與驗收證明書(營/資租)
ML3008R09 非AR保證人保證書
ML3008R10 AR保證人保證書
ML3008R11 訂購契約書(三方)
ML3008R12 訂購契約書(兩方)
ML3008R13 租賃物返還同意書
ML3008R14 擔保品提供證書
ML3008R15 動產抵押契約書
ML3008R16 應收帳款債權轉讓通知書
ML3008R17 保險切結書
ML3008R18 應收帳款管理同意書
ML3008R19 支付價金申請書
ML3008R20 讓與明細表
ML3008R21 買賣契約書
ML3008R22 本票
ML3008R23 指定付款同意書
ML3008R24 全額付款確認書(兩方版本)-確認客戶已取得產權
ML3008R25 全額付款確認書(三方版本)-客戶發票與實撥金額有落差
ML3008R26 全額付款確認書(三方版本)-客戶訂金抵頭款
ML3008R27 車輛動產抵押契約書
ML3008R28 交貨與驗收證明書(分期)
ML3008R29 切  結  書
ML3008R30 動產擔保交易(附條件買賣) 登記申請書
ML3008R31 動產擔保交易登記標的物明細表
ML3008R32 租賃契約書 資租事務機
ML3008R33 動產擔保交易(動產抵押) 登記申請書
 */

        //john 2013/10/09 修改列印方式
        if (txtPRGID.Text.ToString().Trim() == "LE3001A")
        {
            StringBuilder LSTR_Data = new StringBuilder();
            LSTR_Data.Append("SP_ML3008R01_LOG" + GSTR_ColDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCNTRNO.Text + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID);//U_USERID
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            ReturnObject<object> LOBJ_ReturnObject = SaveContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                string rv = "";
                String LSTR_ObjId = "";
                Comus.HtmlSubmitControl LOBJ_Submit;
                String[] LVAR_Parameter = new String[2];
                ReturnObject<DataTable> LOBJ_Return;
                try
                {
                    LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
                    LOBJ_Submit = new Comus.HtmlSubmitControl();
                    LOBJ_Submit.VirtualPath = GetComusVirtualPath();
                    LVAR_Parameter[0] = "dbo.SP_ML3008_Q02";
                    LVAR_Parameter[1] = "'','" + this.txtCASEID.Text + "','" + this.txtCNTRNO.Text + "','',''";
                    LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
                    if (LOBJ_Return.ReturnSuccess)
                    {
                        DataTable dt = LOBJ_Return.ReturnData;

                        string hfCASEID = dt.Rows[0]["CASEID"].ToString();
                        string mainType = dt.Rows[0]["MAINTYPE"].ToString();
                        string subType = dt.Rows[0]["SUBTYPE"].ToString();
                        string transType = dt.Rows[0]["TRANSTYPE"].ToString();
                        //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                        int INSURANCE = int.Parse(dt.Rows[0]["INSURANCE"].ToString());
                        //20231130 ADD 設備系統優化 增加條件 & 文件
                        string EXPIREPROC = dt.Rows[0]["EXPIREPROC"].ToString();  //期滿處理方式 01:供應商買回 02:客戶第三方買回 03:其他 04:供應商買回(批次約定)
                        string RESIDUALS = dt.Rows[0]["RESIDUALS"].ToString();  //殘值
                        string PAYMENT = dt.Rows[0]["PAYMENT"].ToString();  //有無頭期款或保證金
                        string GUARANTEEBILL = dt.Rows[0]["GUARANTEEBILL"].ToString();  //1:有保證人且「簽訂大本票為是」
                        string PRODCD = dt.Rows[0]["PRODCD"].ToString();  //案件產品別

                        //RegisterScript("alert('" + dt.Rows[0]["CASEID"].ToString().Trim() + "');");

                        //20231130 設備系統優化
                        switch (mainType)
                        {
                            case "01":

                                if (subType == "01")   //營租事務機
                                {
                                    rv += "01,";
                                    //20200213 ADD BY SS ADAM REASON.事務機增加交貨與驗收證明書
                                    rv += "08,";
                                    if (transType == "02") //三方
                                    {
                                        rv += "11,";
                                    }
                                    else//兩方
                                    {
                                        rv += "12,";
                                        //20231130 ADD 全額付款確認書
                                    }
                                    //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                                    if (INSURANCE == 0)
                                    {
                                        rv += "17,";
                                    }
                                }
                                else
                                {
                                    //20231130 3.	取消「保證人保證書」，條文併入主約。
                                    //this.ddlDocuments.Items.Add(new ListItem("保證人保證書", "ML3008R09"));
                                    //rv+="02,08,09,";
                                    rv += "02,08,";
                                    if (transType == "02") //三方
                                    {
                                        rv += "11,";
                                        //20231130 ADD 全額付款確認書
                                    }
                                    else//兩方
                                    {
                                        rv += "12,";
                                    }
                                    //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                                    if (INSURANCE == 0)
                                    {
                                        rv += "17,";
                                    }
                                }
                                //20231130 ADD 期滿處理方式
                                if (EXPIREPROC == "01" || EXPIREPROC == "02") //期滿處理方式為「供應商買回」或「客戶第三方買回」
                                {
                                    rv += "21,";
                                }
                                //20231130 ADD 大本票
                                if (GUARANTEEBILL == "1") //有保證人且「簽訂大本票為是」
                                {
                                    rv += "22,";
                                }
                                //20231130 ADD 指定付款同意書
                                rv += "23,";
                                break;
                            case "02":
                                if (subType == "01")   //資租事務機
                                {
                                    rv += "32,";
                                    //20200213 ADD BY SS ADAM REASON.事務機增加交貨與驗收證明書
                                    rv += "08,";

                                    //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                                    if (INSURANCE == 0)
                                    {
                                        rv += "17,";
                                    }
                                }
                                else
                                {
                                    //20231130 取消「保證人保證書」，條文併入主約
                                    //rv+="02,08,09,";
                                    rv += "03,08,";
                                    //rv += "13,";
                                    //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                                    if (INSURANCE == 0)
                                    {
                                        rv += "17,";
                                    }
                                    //20231130 ADD 全額付款確認書
                                }
                                if (transType == "02") //三方
                                {
                                    rv += "11,";
                                    //20231130 ADD 全額付款確認書
                                }
                                else//兩方
                                {
                                    rv += "12,";
                                }
                                //20231130 ADD 殘值
                                if (RESIDUALS != "0") //殘值不為0
                                {
                                    rv += "21,";
                                }
                                //20231130 ADD 大本票
                                if (GUARANTEEBILL == "1") //有保證人且「簽訂大本票為是」
                                {
                                    rv += "22,";
                                }
                                //20231130 ADD 指定付款同意書
                                rv += "23,";
                                break;
                            case "03":
                                switch (subType)
                                {
                                    case "01":   //分期原物料
                                        rv += "04,";
                                        rv += "14,";
                                        break;
                                    case "02":   //分期附條買
                                        rv += "05,";
                                        break;
                                    case "03":  //設備動保
                                        rv += "04,";
                                        rv += "14,";
                                        break;
                                    //20131107 ADD BY SS ADAM Reason.增加設備無設定的合約書
                                    case "04":  //設備無設定
                                        rv += "04,";
                                        rv += "14,";
                                        break;
                                }
                                if (PRODCD == "03")//重車
                                {
                                    rv += "27,";
                                }
                                else if (subType == "02" && PRODCD != "03")
                                {
                                    //this.ddlDocuments.Items.Add(new ListItem("動產抵押契約書", "ML3008R15"));
                                    //rv += "15,";
                                    rv += "30,";
                                    rv += "29,";
                                    rv += "31,";
                                }
                                else if (subType != "02" && PRODCD != "03")
                                {
                                    rv += "15,";
                                    rv += "33,";
                                    rv += "29,";
                                    rv += "31,";
                                }
                                //20231130 取消「保證人保證書」，條文併入主約，交貨與驗收證明書改分期專用
                                //this.ddlDocuments.Items.Add(new ListItem("保證人保證書部", "ML3008R09"));
                                //rv+="08,09,";
                                rv += "28,";
                                if (transType == "02") //三方
                                {
                                    rv += "11,";
                                }
                                else//兩方
                                {
                                    rv += "12,";
                                }
                                //20130613 ADD BY ADAM Reason. 增加保險費的判斷邏輯
                                //20231130 改分期時不顯示
                                //20240301 尚未跟回件組溝通先改回來
                                if (INSURANCE == 0)
                                {
                                    rv += "17,";
                                }
                                //20231130 ADD 大本票
                                if (GUARANTEEBILL == "1") //有保證人且「簽訂大本票為是」
                                {
                                    rv += "22,";
                                }
                                //20231130 ADD 指定付款同意書
                                rv += "23,";
                                break;
                            case "04":
                                if (dt.Rows[0]["RECOURSE"].ToString() == "Y")    //AR附追索權
                                {
                                    rv += "06,10,";
                                }
                                else
                                {
                                    rv += "07,";
                                }
                                //20150309 ADD BY SS ADAM REASON.增加報表
                                rv += "16,18,19,20,";
                                break;
                            default:
                                rv += "";
                                break;
                        }
                        string url = "";
                        //string url = "window.open('../ML.NET/ML30/ML3008R00.aspx?SOURCE=02&CASEID=" + this.txtCASEID.Text + "&CNTRNO=" + this.txtCNTRNO.Text + "&RPTIDX=" + rv + "');";
                        if (mainType == "03")
                        {
                            url = "window.open('FrmML3002D.aspx?CASEID=" + this.txtCASEID.Text + "&CNTRNO=" + this.txtCNTRNO.Text + "&RPTIDX=" + rv + "','','height=150, width=330, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=n o, status=no');";
                        }
                        else
                        {
                            url = "window.open('../LE.NET/ML30/ML3008R00.aspx?SOURCE=02&CASEID=" + this.txtCASEID.Text + "&CNTRNO=" + this.txtCNTRNO.Text + "&RPTIDX=" + rv + "');";
                        }


                        RegisterScript(url);
                    }
                    else
                    {


                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    RegisterScript("alert('" + ex.Message + "');");
                }

            }
            else RegisterScript("alert('個資LOG新增失敗，請連絡資訊人員!');");
            //ss.Dispose();
        }
        else Report(this.txtCUSTID.Text, this.txtCASEID.Text, this.txtCNTRNO.Text);

    }
    private ReturnObject<DataSet> GetReportDataByID(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
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
            ////联络人
            //LSTR_StoreProcedure.Append("SP_ML1002_Q03" + GSTR_RowDelimitChar);
            //LSTR_QueryCondition.Append("AND MLDCASECONTACT.CASEID=''''" + LSTR_CASEID + "'''' AND MLDCASECONTACT.CONTACTTYPE=''''1''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //案件申請保證人資料明細檔
            LSTR_StoreProcedure.Append("SP_ML1002_Q05" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
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
    private void GetACCOMFRV(RepeaterItem LOBJ_Data, string LSTR_COMPID)
    {
        String LSTR_ObjId = "";
        Comus.HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = "dbo.SP_ML0001_Q08";
            LVAR_Parameter[1] = "'" + this.drpCOMPID.SelectedValue.Trim() + "','" + LSTR_COMPID + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                string LSTR_Result = "";
                for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++)
                {
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][0].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][1].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][2].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][3].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][4].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][5].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][6].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += LOBJ_Return.ReturnData.Rows[i][7].ToString() + GSTR_ColDelimitChar;
                    LSTR_Result += GSTR_RowDelimitChar;
                }
                ((HiddenField)LOBJ_Data.FindControl("hidPAYData")).Value = LSTR_Result;
                //綁定數據
                ((DropDownList)LOBJ_Data.FindControl("drpSUPSEQ")).DataSource = LOBJ_Return.ReturnData;
                ((DropDownList)LOBJ_Data.FindControl("drpSUPSEQ")).DataValueField = "RV_SEQ";
                ((DropDownList)LOBJ_Data.FindControl("drpSUPSEQ")).DataTextField = "RV_SEQ";
                ((DropDownList)LOBJ_Data.FindControl("drpSUPSEQ")).DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected double IRR_Cal_ForPPMT()
    {
        if (txtRTRANSCOST.Text == "")
        {
            Alert("請輸入受讓/發票金額！");
            txtRTRANSCOST.Focus();
            return 0;
        }
        if (txtRCONTRACTMONTH.Text == "")
        {
            Alert("請輸入總承作月數！");
            txtRCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtRPAYMONTH.Text == "")
        {
            Alert("請輸入幾月一付！");
            txtRPAYMONTH.Focus();
            return 0;
        }
        if (drpRPAYTIME.SelectedIndex == 0)
        {
            Alert("請選擇付款時間！");
            drpRPAYTIME.Focus();
            return 0;
        }
        if (txtRENDPAY1.Text == "")
        {
            Alert("請輸入第一段結束期別！");
            txtRENDPAY1.Focus();
            return 0;
        }
        if (txtRPRINCIPAL1.Text == "")
        {
            Alert("請輸入第一段期付款！");
            txtRPRINCIPAL1.Focus();
            return 0;
        }

        if (txtRTRANSCOST.Text == "0")
        {
            Alert("受讓/發票金額輸入需大於 0！");
            txtRTRANSCOST.Focus();
            return 0;
        }
        if (txtRCONTRACTMONTH.Text == "0")
        {
            Alert("總承作月數輸入需大於 0！");
            txtRCONTRACTMONTH.Focus();
            return 0;
        }
        if (txtRPAYMONTH.Text == "0")
        {
            Alert("幾月一付輸入需大於 0！");
            txtRPAYMONTH.Focus();
            return 0;
        }
        if (txtRENDPAY1.Text == "0")
        {
            Alert("第一段結束期別輸入需大於 0！");
            txtRENDPAY1.Focus();
            return 0;
        }

        // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
        //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
        if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
        {

            if (txtRPRINCIPAL1.Text == "0")
            {
                Alert("第一段期付款輸入需大於 0！");
                txtRPRINCIPAL1.Focus();
                return 0;
            }
        }
        bool LBOL_Checked = false;
        if (txtRENDPAY4.Text != "")
        {
            if (txtRCONTRACTMONTH.Text != txtRENDPAY4.Text)
            {
                Alert("最後一段結束期別輸入需等於總承作月數！");
                txtRENDPAY4.Focus();
                return 0;
            }
            else
            {
                LBOL_Checked = true;
            }
        }
        if (!LBOL_Checked)
        {
            if (txtRENDPAY3.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY3.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY3.Focus();
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
            if (txtRENDPAY2.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY2.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY2.Focus();
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
            if (txtRENDPAY1.Text != "")
            {
                if (txtRCONTRACTMONTH.Text != txtRENDPAY1.Text)
                {
                    Alert("最後一段結束期別輸入需等於總承作月數！");
                    txtRENDPAY1.Focus();
                    return 0;
                }
                else
                {
                    LBOL_Checked = true;
                }
            }
        }

        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text) / 1.05), 0);
        Decimal LDCE_TransCostTax = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text)), 0);

        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        //期付款未稅
        Decimal LDCE_PRINCIPAL = 0;
        //平均期付款未稅
        Decimal LDEC_AVGRPRINCIPAL = 0;
        //平均期付款未稅
        Decimal LDEC_AVGRPRINCIPALTAX = 0;
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];

        //資租計算PPMT時的IRR需以發票金額為計算基準
        LDCE_TransCost = 0;
        LDCE_TransCostTax = 0;
        int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
            LDCE_TransCostTax += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text));
        }
        //折讓未稅金額
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        Decimal LDBL_DISCOUNTAMOUNTTAX = 0;
        LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text));
            LDBL_DISCOUNTAMOUNTTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text));
        }
        LDCE_TransCost = LDCE_TransCost - LDBL_DISCOUNTAMOUNT;
        LDCE_TransCostTax = LDCE_TransCostTax - LDBL_DISCOUNTAMOUNTTAX;

        //如果是 AR 案件，標的物金額不用計算成未稅
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            LDCE_TransCost = LDCE_TransCostTax;
        }
        //計算平均期付款未稅
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            if (i >= 1 && i <= LINT_ENDPAY1)
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX1.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX2.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX3.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX4.Text); //月付款
            }
        }
        LDEC_AVGRPRINCIPAL = Math.Round((LDEC_AVGRPRINCIPAL / LINT_CONTRACTMONTH), 0);
        LDEC_AVGRPRINCIPALTAX = Math.Round((LDEC_AVGRPRINCIPALTAX / LINT_CONTRACTMONTH), 0);

        //計算第0期的現金流量
        LDBL_VALUE[0] = Convert.ToDouble(LDCE_FirstPay //頭期款(未稅)
                      - LDCE_TransCost); //標的物金額(未稅)
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            //最後一期
            if (i == LINT_CONTRACTMONTH)
            {
                //最後一期付款
                if (LINT_ENDPAY1 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text);
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text);
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text);
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text);
                }
                if (this.drpMAINTYPE.SelectedValue == "03")
                {
                    LDCE_PRINCIPAL = LDEC_AVGRPRINCIPAL;
                }
                LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
            }
            else
            {
                if (i >= 1 && i <= LINT_ENDPAY1)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
                }
                if (this.drpMAINTYPE.SelectedValue == "03")
                {
                    LDCE_PRINCIPAL = LDEC_AVGRPRINCIPAL;
                }
                LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
            }
        }
        ////20131129 ADD BY SS ADAM Reason.修正IRR計算產生的錯誤，主要是第零期的現金流量是負值造成的錯誤
        //if (LDBL_VALUE[0] < 0)
        //    return -999;

        //Modify 20130726 By SS Gordon. Reason: IRR_Cal_ForPPMT()計算IRR時，加入TRY..CATCH判斷，若發生例外錯誤，則IRR傳回0
        //double LDBL_IRR = System.Math.Abs(Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200);
        double LDBL_IRR = 0;
        try
        {
            LDBL_IRR = System.Math.Abs(Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200);
        }
        catch
        {
            LDBL_IRR = 0;
        }
        return LDBL_IRR;
    }
    private Decimal[][] PPMT_Cal(double LDBL_IRR)
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = 0;
        Decimal LDCE_TransCostTax = 0;
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        Decimal LDCE_FirstPayTax = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text)), 0);
        //利率
        LDBL_IRR = Convert.ToDouble((LDBL_IRR / 1200).ToString("0.0000000000"));
        //期付款未稅
        Decimal LDEC_RPRINCIPAL = Convert.ToDecimal(this.txtRPRINCIPAL1.Text);
        //期付款含稅
        Decimal LDEC_RPRINCIPALTAX = Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);
        //平均期付款未稅
        Decimal LDEC_AVGRPRINCIPAL = 0;
        //平均期付款未稅
        Decimal LDEC_AVGRPRINCIPALTAX = 0;
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];

        int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
            LDCE_TransCostTax += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text));
        }
        //折讓未稅金額
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        Decimal LDBL_DISCOUNTAMOUNTTAX = 0;
        LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text));
            LDBL_DISCOUNTAMOUNTTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text));
        }
        LDCE_TransCost = LDCE_TransCost - LDBL_DISCOUNTAMOUNT;
        LDCE_TransCostTax = LDCE_TransCostTax - LDBL_DISCOUNTAMOUNTTAX;
        //本金總額
        Decimal LDCE_TPrincipal = 0;
        //利息總額
        Decimal LDCE_TInterest = 0;
        //總月付款
        Decimal LDCE_TMonthPay = 0;
        //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
        //第 0 期 
        LDBL_VALUE[0] = new Decimal[5];
        LDBL_VALUE[0][0] = 0;
        LDBL_VALUE[0][1] = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text))); //頭期款(含稅)
        LDBL_VALUE[0][2] = LDCE_FirstPay; //本金
        LDBL_VALUE[0][3] = 0; //利息
        LDBL_VALUE[0][4] = (LDCE_TransCost - LDCE_FirstPay); //未攤本金 = 標的物金額(未稅) - 頭期款(未稅)  
        LDCE_TPrincipal += LDBL_VALUE[0][2];
        LDCE_TInterest += LDBL_VALUE[0][3];

        //計算平均期付款未稅
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            if (i >= 1 && i <= LINT_ENDPAY1)
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX1.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX2.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX3.Text); //月付款
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
            {
                LDEC_AVGRPRINCIPAL += Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
                LDEC_AVGRPRINCIPALTAX += Convert.ToDecimal(txtRPRINCIPALTAX4.Text); //月付款
            }
        }
        LDEC_AVGRPRINCIPAL = Math.Round((LDEC_AVGRPRINCIPAL / LINT_CONTRACTMONTH), 0);
        LDEC_AVGRPRINCIPALTAX = Math.Round((LDEC_AVGRPRINCIPALTAX / LINT_CONTRACTMONTH), 0);

        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            //20161110 ADD BY SS ADAM REASON.分期也走多段式
            //if (this.drpMAINTYPE.SelectedValue == "03")
            //{
            //    LDEC_RPRINCIPAL = LDEC_AVGRPRINCIPAL;
            //    LDEC_RPRINCIPALTAX = LDEC_AVGRPRINCIPALTAX;
            //}
            //else
            //{
            if (i >= 1 && i <= LINT_ENDPAY1)
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX1.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX2.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX3.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX4.Text); //月付款(含稅)
            }
            //}
            LDBL_VALUE[i] = new Decimal[5];
            LDBL_VALUE[i][0] = i;
            LDBL_VALUE[i][1] = Math.Round(LDEC_RPRINCIPAL); //期付款未稅
            //20130709 UPD BY BRENT Reason.攤提表展開時增加反推IRR邏輯
            //if (this.drpMAINTYPE.SelectedValue == "02")//20161110 ADD BY SS ADAM REASON.分期也走多段式
            {
                LDBL_VALUE[i][3] = Math.Round(Convert.ToDecimal(Microsoft.VisualBasic.Financial.IPmt(LDBL_IRR, 1, LINT_CONTRACTMONTH, -1 * Convert.ToDouble(LDBL_VALUE[i - 1][4]), 0, Microsoft.VisualBasic.DueDate.EndOfPeriod)), 0); //利息
                LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(LDBL_VALUE[i][1]) - Convert.ToDecimal(LDBL_VALUE[i][3]), 0); //本金
            }
            //else//20161110 ADD BY SS ADAM REASON.分期也走多段式
            //{
            //    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(Microsoft.VisualBasic.Financial.PPmt(LDBL_IRR, i, LINT_CONTRACTMONTH, -1 * Convert.ToDouble(LDBL_VALUE[0][4]), 0, Microsoft.VisualBasic.DueDate.EndOfPeriod)), 0); //本金
            //    LDBL_VALUE[i][3] = Math.Round(Convert.ToDecimal(Microsoft.VisualBasic.Financial.IPmt(LDBL_IRR, i, LINT_CONTRACTMONTH, -1 * Convert.ToDouble(LDBL_VALUE[0][4]), 0, Microsoft.VisualBasic.DueDate.EndOfPeriod)), 0); //利息
            //}
            LDBL_VALUE[i][4] = Math.Round(LDBL_VALUE[i - 1][4] - LDBL_VALUE[i][2], 0); //未攤本金 = 未攤本金(前一期) - 本金(本期)

            LDCE_TMonthPay += LDEC_RPRINCIPALTAX;//總月付款(含稅)
            //調整利息
            //本金+利息 需等於期付款未稅 如果不等 則將 期付款未稅-(本金+利息) 算出差額，所算出的差額加到本期利息裡
            LDBL_VALUE[i][3] = Math.Round((LDEC_RPRINCIPAL - (LDBL_VALUE[i][2] + LDBL_VALUE[i][3])) + LDBL_VALUE[i][3], 0);

            if (i == LINT_CONTRACTMONTH)
            {
                if (this.drpMAINTYPE.SelectedValue == "03")
                {
                    LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                    LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
                    //計算分差收入差額尾差
                    //分差收入差額 = (((總月付款(含稅) – (本體(含稅) – 頭款(含稅)))/1.05) - 利息總額
                    Decimal LDEC_Revenue = (Math.Round(Convert.ToDecimal(Convert.ToDouble(LDCE_TMonthPay - (LDCE_TransCostTax - LDCE_FirstPayTax)) / 1.05), 0)) - LDCE_TInterest;
                    //將分差收入的尾差加到利息裡
                    LDBL_VALUE[i][3] = LDBL_VALUE[i][3] + LDEC_Revenue;
                }
                else
                {
                    if (LDBL_VALUE[i][4] != 0)
                    {
                        //將未償本金的尾差加到利息裡
                        LDBL_VALUE[i][3] = LDBL_VALUE[i][3] + LDBL_VALUE[i][4];
                        LDBL_VALUE[i][2] = LDBL_VALUE[i][2] - LDBL_VALUE[i][4];
                        LDBL_VALUE[i][4] = 0;

                        LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                        LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
                        //將本金總額與標的物金額(未稅)相減算出尾差
                        //本金
                        LDBL_VALUE[i][2] = LDBL_VALUE[i][2] + (LDCE_TransCost - LDCE_TPrincipal);
                        //利息
                        LDBL_VALUE[i][3] = LDBL_VALUE[i][3] - (LDCE_TransCost - LDCE_TPrincipal);
                    }
                }
            }
            else
            {
                LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
            }
        }
        return LDBL_VALUE;
    }
    private void CalDISCOUNTTOTAL()
    {
        //計算
        //進項發票
        Decimal LDBL_INVPERBONDUSED = 0;
        Decimal LDBL_INVHIREPURUSED = 0;
        Decimal LDBL_INVFIRSTPAYUSED = 0;
        Decimal LDBL_INVSALESPAY = 0;
        Decimal LSTR_INVAMOUNT = 0;
        Decimal LSTR_INVTAX = 0;
        Decimal LSTR_INVAMOUNTTAX = 0;
        Decimal LDBL_INVDAMOUNTTAX = 0;

        Decimal LDBL_PERBONDNOTE = 0;
        Decimal LDBL_PURCHASENOTE = 0;
        Decimal LDBL_FIRSTPAYNOTE = 0;

        Decimal LDBL_TRANSAMT_D = 0;
        Decimal LDBL_FEEAMT_D1 = 0;
        Decimal LDBL_FEEAMT_D2 = 0;
        Decimal LDBL_PREPAYWOFFAMT_D = 0;

        int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LSTR_INVAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
            LSTR_INVTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtTAX")).Text));
            LSTR_INVAMOUNTTAX = Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text));

            //計算[抵設備款]
            LDBL_INVPERBONDUSED += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDUSED")).Text));
            LDBL_INVHIREPURUSED += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtHIREPURUSED")).Text));
            LDBL_INVFIRSTPAYUSED += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYUSED")).Text));
            LDBL_INVSALESPAY += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Text));
            //計算[抵設備款票據]
            LDBL_PERBONDNOTE += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDNOTE")).Text));
            LDBL_PURCHASENOTE += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPURCHASENOTE")).Text));
            LDBL_FIRSTPAYNOTE += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYNOTE")).Text));
            //計算單筆發票實撥金額
            //實撥金額＝(進項發票未稅總額+進項發票稅額)-(進項折讓未稅總額+折讓發票稅額)-[抵設備款]履約保證金抵設備款-[抵設備款]租購保證金抵設備款-[抵設備款]頭期款抵設備款-業代自付額
            string LSTR_INVNUM = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text.ToUpper();
            LDBL_INVDAMOUNTTAX = CalINVDAmount(LSTR_INVNUM);
            //指定付款
            LDBL_TRANSAMT_D = CalPAYMFAmount(LSTR_INVNUM);
            //預撥沖銷
            string LDBL_INVSUPPLIERID = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSUPPLIERID")).Text;
            LDBL_PREPAYWOFFAMT_D = CalPAYWOFFAmount(LDBL_INVSUPPLIERID);
            //手續費收入
            LDBL_FEEAMT_D1 = CalFEEINCOME1Amount(LDBL_INVSUPPLIERID);
            ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtACTUALLYAMOUNT")).Text = (LSTR_INVAMOUNTTAX
                                                                                          - LDBL_INVDAMOUNTTAX
                                                                                          - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDUSED")).Text))
                                                                                          - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtHIREPURUSED")).Text))
                                                                                          - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYUSED")).Text))
                                                                                          - Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Text))
                                                                                          - LDBL_TRANSAMT_D
                                                                                          - LDBL_PREPAYWOFFAMT_D
                                                                                          - LDBL_FEEAMT_D1
                                                                                          ).ToString("#,##0");
        }
        //折讓未稅金額
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        Decimal LDBL_DISCOUNTTAX = 0;
        LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text));
            LDBL_DISCOUNTTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text));
        }
        this.txtPERBONDUSED.Text = LDBL_INVPERBONDUSED.ToString("#,##0");
        this.txtPURCHASEUSED.Text = LDBL_INVHIREPURUSED.ToString("#,##0");
        this.txtFIRSTPAYUSED.Text = LDBL_INVFIRSTPAYUSED.ToString("#,##0");
        this.txtSALESPAY.Text = LDBL_INVSALESPAY.ToString("#,##0");

        this.txtPERBONDNOTE.Text = LDBL_PERBONDNOTE.ToString("#,##0");
        this.txtPURCHASENOTE.Text = LDBL_PURCHASENOTE.ToString("#,##0");
        this.txtFIRSTPAYNOTE.Text = LDBL_FIRSTPAYNOTE.ToString("#,##0");

        //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
        Decimal LDBL_FEEAMT = 0;
        Decimal LDBL_PREPAYWOFFAMT = 0;

        //計算預撥沖銷
        for (var i = 0; i < this.rptMLDPREPAYWOFF.Items.Count; i++)
        {
            LDBL_PREPAYWOFFAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDPREPAYWOFF.Items[i].FindControl("txtNOWPREPAYAMT")).Text));
        }
        txtPREPAYWOFFAMT.Text = LDBL_PREPAYWOFFAMT.ToString("#,##0");

        //計算手續費
        for (var i = 0; i < this.rptMLDFEEINCOME1.Items.Count; i++)
        {
            //20170124 ADD BY SS ADAM REASON.增加匯款不內扣判斷
            if (((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpPAYTYPE")).SelectedValue.Trim() != "01")
            {
                LDBL_FEEAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtFEEAMT")).Text));
            }
        }
        //for (var i = 0; i < this.rptMLDFEEINCOME2.Items.Count; i++)
        //{
        //    LDBL_FEEAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtFEEAMT")).Text));
        //}
        txtFEEAMT.Text = LDBL_FEEAMT.ToString("#,##0");

        //進項總額＝進項發票未稅金額－折讓未稅金額－業代自付額
        this.txtDISCOUNTTOTAL.Text = (LSTR_INVAMOUNT - LDBL_DISCOUNTAMOUNT - LDBL_INVSALESPAY).ToString("#,##0");
        //進項稅額＝進項發票稅額－折讓發票稅額
        this.txtDISCOUNTTAX.Text = (LSTR_INVTAX - LDBL_DISCOUNTTAX).ToString("#,##0");
        //實撥金額＝(進項發票未稅總額+進項發票稅額)-(進項折讓未稅總額+折讓發票稅額)-[抵設備款]履約保證金抵設備款-[抵設備款]租購保證金抵設備款-[抵設備款]頭期款抵設備款-業代自付額
        //20161125 ADD BY SS ADAM REASON.實撥金額=(進項發票未稅總額+進項發票稅額)-(進項折讓未稅總額+折讓發票稅額)-[抵設備款]履約保證金抵設備款-[抵設備款]租購保證金抵設備款-[抵設備款]頭期款抵設備款-業代自付額-[抵設備款]手續費-[抵設備款]預撥沖銷
        //this.txtACTUALLYAMOUNT.Text = ((LSTR_INVAMOUNT + LSTR_INVTAX) - (LDBL_DISCOUNTAMOUNT + LDBL_DISCOUNTTAX) - LDBL_INVPERBONDUSED - LDBL_INVHIREPURUSED - LDBL_INVFIRSTPAYUSED - LDBL_INVSALESPAY).ToString("#,##0");
        this.txtACTUALLYAMOUNT.Text = ((LSTR_INVAMOUNT + LSTR_INVTAX) - (LDBL_DISCOUNTAMOUNT + LDBL_DISCOUNTTAX) - LDBL_INVPERBONDUSED - LDBL_INVHIREPURUSED - LDBL_INVFIRSTPAYUSED - LDBL_INVSALESPAY - LDBL_FEEAMT - LDBL_PREPAYWOFFAMT).ToString("#,##0");
        this.UpdatePanelMLDCONTRACTINV.Update();
        this.UpdatePanelMLDCONTRACTINVD.Update();

        this.UpdatePanelMLDASSPAYMF.Update();
        this.UpdatePanelMLDPREPAYWOFF.Update();
        this.UpdatePanelMLDFEEINCOME1.Update();
        this.UpdatePanelMLDFEEINCOME2.Update();

        this.UpdatePanel2.Update();
        this.UpdatePanel3.Update();
    }
    private Decimal CalINVDAmount(string LSTR_DISCOUNTINVNUM)
    {
        //計算相同進項折讓發票金額
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        int LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            if (LSTR_DISCOUNTINVNUM == ((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text.ToUpper())
            {
                LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text));
            }
        }
        return LDBL_DISCOUNTAMOUNT;
    }

    private Decimal CalPAYMFAmount(string LSTR_DISCOUNTINVNUM)
    {
        //指定付款
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        int LSTR_RowCount = this.rptMLDASSPAYMF.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            if (LSTR_DISCOUNTINVNUM == ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).Text.ToUpper())
            {
                LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtTRANSAMT")).Text));
            }
        }
        return LDBL_DISCOUNTAMOUNT;
    }

    private Decimal CalPAYWOFFAmount(string LSTR_ID)
    {
        //預撥沖銷
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        int LSTR_RowCount = this.rptMLDPREPAYWOFF.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            //if (LSTR_ID == ((TextBox)rptMLDPREPAYWOFF.Items[i].FindControl("txtPREPAYID")).Text.ToUpper())
            //{
            LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDPREPAYWOFF.Items[i].FindControl("txtNOWPREPAYAMT")).Text));
            //}
        }
        return LDBL_DISCOUNTAMOUNT;
    }

    private Decimal CalFEEINCOME1Amount(string LSTR_ID)
    {
        //手續費收入
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        int LSTR_RowCount = this.rptMLDFEEINCOME1.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            if (LSTR_ID == ((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtUNIMNO")).Text.ToUpper()
                //20170124 ADD BY SS ADAM REASON.增加匯款不內扣判斷
                && ((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpPAYTYPE")).SelectedValue.Trim() != "01")
            {
                LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtFEEAMT")).Text));
            }
        }
        return LDBL_DISCOUNTAMOUNT;
    }

    private Decimal[][] PPMT_Cal2()
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text) / 1.05), 0);
        //殘值(未稅)
        Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRRESIDUALS.Text) / 1.05), 0);
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        //Modify 20120614 By SS Gordon. Reason: 修改現金流量計算方法;新增手續費.
        //手續費(未稅)
        Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFEE.Text) / 1.05), 0);
        //幾月一付
        int LINT_PAYMONTH = Convert.ToInt32("0" + txtRPAYMONTH.Text);
        //期數比例
        double LINT_MONTH = 0;
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //撥差天數 = 付款差異天數 – 付供應商天數
        int LINT_PayDiff = Convert.ToInt32(txtRPATDAYS.Text) - Convert.ToInt32(txtRSUPPILERDAYS.Text);
        //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
        Decimal LDEC_PayDiffAmount = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            //撥差金額計算公式  (標的物金額 – 頭期款 – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((Convert.ToDecimal(txtRTRANSCOST.Text) - Convert.ToDecimal(txtRFIRSTPAY.Text) - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
            //Modify 20120614 By SS Gordon. Reason: 修改現金流量計算方法，AR案件中，標的物金額改成含稅.
            LDCE_TransCost = Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text));
        }
        else
        {
            //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
            LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(txtRPURCHASEMARGIN.Text) - Convert.ToDecimal(txtRPERBOND.Text)) * LINT_PayDiff * Convert.ToDecimal(txtRCAPITALCOST.Text) / 100 / 365, 0);
        }
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];
        //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 現金流量[][4]	        
        //第 0 期 
        LDBL_VALUE[0] = new Decimal[5];
        LDBL_VALUE[0][0] = 0;
        LDBL_VALUE[0][1] = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text))); //頭期款(含稅)
        LDBL_VALUE[0][2] = LDCE_TransCost; //標的物金額(未稅)
        LDBL_VALUE[0][3] = 0; //利息
        //租購保證金+頭期款(未稅)+履約保證金-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金
        LDBL_VALUE[0][4] = Convert.ToDecimal(txtRPURCHASEMARGIN.Text) //租購保證金txtPURCHASEMARGIN
                         + LDCE_FirstPay //頭期款(未稅)
                         + Convert.ToDecimal(txtRPERBOND.Text) //履約保證金txtPERBOND
                                                               //Modify 20120614 By SS Gordon. Reason: 修改現金流量計算方法;手續費調整為未稅.
                                                               //+ Convert.ToDecimal(txtRFEE.Text) //手續費收入txtRFEE
                         + Convert.ToDecimal(LDCE_Fee) //手續費收入
                         - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                         - Convert.ToDecimal(txtRINSURANCE.Text) //保險費txtINSURANCE
                                                                 //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                 //- Convert.ToDecimal(txtROTHERFEES.Text) //作業費用txtOTHERFEES
                         - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtROTHERFEES.Text) / 1.05), 0)
                         //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                         - Convert.ToDecimal(txtROTHERFEESNOTAX.Text) // - 作業費用(無發票)txtOTHERFEESNOTAX
                         - LDEC_PayDiffAmount                //撥差金額
                                                             //Modify 20120614 By SS Gordon. Reason: 修改現金流量計算方法;加入佣金計算.
                         - Convert.ToDecimal(txtRCOMMISSION.Text);//佣金txtCOMMISSION

        //如果是期初收
        if (drpPAYTIMET.SelectedValue == "01")
        {
            LDBL_VALUE[0][4] += Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
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
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text);
                }
                if (LINT_ENDPAY2 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text);
                }
                if (LINT_ENDPAY3 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text);
                }
                if (LINT_ENDPAY4 != 0)
                {
                    LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text);
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
                                     - Convert.ToDecimal(txtRPURCHASEMARGIN.Text)  //租購保證金
                                     - Convert.ToDecimal(txtRPERBOND.Text);  //履約保證金
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
                                     - Convert.ToDecimal(txtRPURCHASEMARGIN.Text)  //租購保證金
                                     - Convert.ToDecimal(txtRPERBOND.Text);  //履約保證金
                }
            }
            else
            {
                if (i >= 1 && i <= LINT_ENDPAY1)
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL1.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL1.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL2.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL2.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL3.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL3.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                }
                else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                {
                    LDBL_VALUE[i] = new Decimal[5];
                    LDBL_VALUE[i][0] = i;
                    LDBL_VALUE[i][1] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL4.Text)); //月付款
                    LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(txtRPRINCIPAL4.Text)); //月付款
                    LDBL_VALUE[i][3] = 0; //利息
                    LDBL_VALUE[i][4] = Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
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
                    LDBL_VALUE[i][4] = Convert.ToDecimal(Convert.ToDecimal(LDBL_VALUE[i][4])
                                                     - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
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
                                                     - (Convert.ToDecimal(txtRINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH))
                                                     );
                }
            }
        }
        return LDBL_VALUE;
    }
    private void CalRACTUSLLOANS()
    {
        //UPD BY VICKY 20150123 區分是否為AR件
        if (this.drpMAINTYPE.SelectedValue != "04")    //非AR件
        {
            //實貸金額=受讓/發票金額 - 頭期款-  租購保證金
            Decimal LDBL_RTRANSCOST = Convert.ToDecimal(this.txtRTRANSCOST.Text);
            Decimal LDBL_RFIRSTPAY = Convert.ToDecimal(this.txtRFIRSTPAY.Text);
            Decimal LDBL_RPURCHASEMARGIN = Convert.ToDecimal(this.txtRPURCHASEMARGIN.Text);
            Decimal LDBL_ACTUSLLOANS = LDBL_RTRANSCOST - LDBL_RFIRSTPAY - LDBL_RPURCHASEMARGIN;
            this.txtRACTUSLLOANS.Text = Itg.Community.Util.NumberFormat(LDBL_ACTUSLLOANS.ToString());
            this.hidRACTUSLLOANS.Value = LDBL_ACTUSLLOANS.ToString();
            this.txtRACTUSLLOANS_AR.Text = Itg.Community.Util.NumberFormat(LDBL_ACTUSLLOANS.ToString());  //UPD BY VICKY 20150123 AR實際撥款額 (隱藏)
        }
        else
        {
            //UPD BY VICKY 20150123 AR件
            //AR件的實貸金額=實際撥款額=(AR案件試算表)受讓金額合計-應收墊款息合計-尾款金額合計

            Decimal LDBL_BILLAMT = 0;       //受讓金額合計
            Decimal LDBL_FINANCIALFEES = 0; //應收墊款息合計
            Decimal LDBL_FINALPAYAMT = 0;   //尾款金額合計
            Decimal LDBL_ACTUSLLOANS = 0;   //實貸金額
            int LSTR_RowCount = this.rptMLDCONTRACTARD.Items.Count;
            for (var i = 0; i < LSTR_RowCount; i++)
            {
                LDBL_BILLAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text));
                LDBL_FINANCIALFEES += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text));
                LDBL_FINALPAYAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text));
            }
            LDBL_ACTUSLLOANS = LDBL_BILLAMT - LDBL_FINANCIALFEES - LDBL_FINALPAYAMT;
            this.txtRACTUSLLOANS.Text = Itg.Community.Util.NumberFormat(LDBL_ACTUSLLOANS.ToString());
            this.hidRACTUSLLOANS.Value = LDBL_ACTUSLLOANS.ToString();
            this.txtRACTUSLLOANS_AR.Text = Itg.Community.Util.NumberFormat(LDBL_ACTUSLLOANS.ToString());  //UPD BY VICKY 20150123 AR實際撥款額 (顯示)
        }
    }
    protected void btnSaveModify_Click(object sender, EventArgs e)
    {
        string LSTR_CASEID = this.txtCASEID.Text.Trim();
        string LSTR_CNTRNO = this.txtCNTRNO.Text.Trim();
        string LSTR_CUSTID = this.txtCUSTID.Text.Trim();

        //新增撥款信息
        StringBuilder LSTR_Data = new StringBuilder();  //MLMCONTRACT
        LSTR_Data.Append("SP_ML3002_U03" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);

        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPERBONDUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPURCHASEUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPERBONDNOTE")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtPURCHASENOTE")[0].Trim()) + GSTR_TabDelimitChar);

        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtFIRSTPAYUSED")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtFIRSTPAYNOTE")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtSALESPAY")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtCUSTFPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);
        if (this.txtPRENTSTDT.Text.Trim() != "")
        {
            DateTime LDAT_StartDate = Convert.ToDateTime(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text));
            int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
            string LSTR_RENTENDT = Itg.Community.Util.GetRepYear(((LDAT_StartDate.AddMonths(LINT_CONTRACTMONTH)).AddDays(-1)).ToString());
            LSTR_Data.Append(Itg.Community.Util.GetADYear(LSTR_RENTENDT) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetADYear(LSTR_RENTENDT) + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPRENTSTDT.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
        }

        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtDISCOUNTTOTAL")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtDISCOUNTTAX")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(Request.Form.GetValues("txtACTUALLYAMOUNT")[0].Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtPAYDATE.Text.Trim()) + GSTR_TabDelimitChar);

        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        if (rptMLDCONTRACTINV.Items.Count > 0)
        {
            //MLDCONTRACTINV
            for (int i = 0; i < this.rptMLDCONTRACTINV.Items.Count; i++)
            {
                if (((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML3002_I06" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_BILLNOTEID = ((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidBILLNOTEID")).Value.Trim();
                if (LSTR_BILLNOTEID == "")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINV", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_BILLNOTEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPPLIER")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPSEQ")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidSUPSEQ")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDCONTRACTINV.Items[i].FindControl("hidPAYBANK")).Value + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRV_NAME")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtRVACNT")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtHIREPURUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYUSED")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtINVSALESPAY")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtACTUALLYAMOUNT")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPERBONDNOTE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtPURCHASENOTE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtFIRSTPAYNOTE")).Text) + GSTR_TabDelimitChar);

                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtTAX")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text) + GSTR_TabDelimitChar);

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
        //MLDCONTRACTINVD撥款案件發票明細檔
        if (rptMLDCONTRACTINV.Items.Count > 0)
        {
            //MLDCONTRACTINVD
            for (int i = 0; i < this.rptMLDCONTRACTINVD.Items.Count; i++)
            {
                if (((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text.Trim() == "")
                {
                    continue;
                }
                if (((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text.Trim() == "0")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML3002_I07" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
                string LSTR_DISCOUNTINVOICEID = ((HiddenField)rptMLDCONTRACTINVD.Items[i].FindControl("hidDISCOUNTINVOICEID")).Value.Trim();
                if (LSTR_DISCOUNTINVOICEID == "")
                {
                    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDCONTRACTINVD", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    LSTR_Data.Append(LSTR_DISCOUNTINVOICEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTINVNUM")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTDATE")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text) + GSTR_TabDelimitChar);

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
        SaveINVZIP();
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        int LINT_ConNum = LOBJ_Contact.Rows.Count;
        if (LINT_ConNum > 0)
        {
            //案件聯絡人
            for (int rowCon = 0; rowCon < LINT_ConNum; rowCon++)
            {
                LSTR_Data.Append("SP_ML3002_I09" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
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
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = SaveContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab66Caption";
                Alert("存檔完成！");
                PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);
                this.btnContractPrint.Enabled = true;
                this.btnListPrint.Enabled = true;

                this.btnInsert.Enabled = true;
                this.btnUpdate.Enabled = true;
                this.btnSelect.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnSURE.Enabled = false;
                this.btnSubmit.Enabled = false;
                this.btnIRR.Enabled = false;
                this.btnSaveModify.Enabled = false;
                this.lblStatus.Text = "";

                Itg.Community.Util.DisabledRepeater(rptMLDCASETARGET, "btnSUPPLIERID");
                Itg.Community.Util.DisabledRepeater(rptMLDCASETARGETSTR, "btnCONTACT");
                Itg.Community.Util.DisabledRepeater(rptMLDCONTRACTINV, "btnSUPPLIERID");
                RegisterScript("SetDisabled('div_Info', '" + btnIRR.ClientID + "," + btnSaveModify.ClientID + "','" + btnInsert.ClientID + "," + btnUpdate.ClientID + "," + btnSelect.ClientID + "');window_onload();");
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

    //UPD BY VICKY 20150127 MARK起來,重設公式
    #region UPD BY VICKY 20150127 MARK起來,重設公式
    //protected double IRR_Cal_ForPPMT_AR()
    //{
    //    if (txtRTRANSCOST.Text == "")
    //    {
    //        Alert("請輸入受讓/發票金額！");
    //        txtRTRANSCOST.Focus();
    //        return 0;
    //    }
    //    if (txtRCONTRACTMONTH.Text == "")
    //    {
    //        Alert("請輸入總承作月數！");
    //        txtRCONTRACTMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRPAYMONTH.Text == "")
    //    {
    //        Alert("請輸入幾月一付！");
    //        txtRPAYMONTH.Focus();
    //        return 0;
    //    }
    //    if (drpRPAYTIME.SelectedIndex == 0)
    //    {
    //        Alert("請選擇付款時間！");
    //        drpRPAYTIME.Focus();
    //        return 0;
    //    }
    //    if (txtRENDPAY1.Text == "")
    //    {
    //        Alert("請輸入第一段結束期別！");
    //        txtRENDPAY1.Focus();
    //        return 0;
    //    }
    //    if (txtRPRINCIPAL1.Text == "")
    //    {
    //        Alert("請輸入第一段期付款！");
    //        txtRPRINCIPAL1.Focus();
    //        return 0;
    //    }

    //    if (txtRTRANSCOST.Text == "0")
    //    {
    //        Alert("受讓/發票金額輸入需大於 0！");
    //        txtRTRANSCOST.Focus();
    //        return 0;
    //    }
    //    if (txtRCONTRACTMONTH.Text == "0")
    //    {
    //        Alert("總承作月數輸入需大於 0！");
    //        txtRCONTRACTMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRPAYMONTH.Text == "0")
    //    {
    //        Alert("幾月一付輸入需大於 0！");
    //        txtRPAYMONTH.Focus();
    //        return 0;
    //    }
    //    if (txtRENDPAY1.Text == "0")
    //    {
    //        Alert("第一段結束期別輸入需大於 0！");
    //        txtRENDPAY1.Focus();
    //        return 0;
    //    }

    //    // 20130114 營租/AR件，即不檢核第一段期付款輸入需大於 0 !
    //    //if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03") {
    //    if (this.drpMAINTYPE.SelectedValue != "01" && this.drpMAINTYPE.SelectedValue != "03" && this.drpMAINTYPE.SelectedValue != "04")
    //    {

    //        if (txtRPRINCIPAL1.Text == "0")
    //        {
    //            Alert("第一段期付款輸入需大於 0！");
    //            txtRPRINCIPAL1.Focus();
    //            return 0;
    //        }
    //    }
    //    bool LBOL_Checked = false;
    //    if (txtRENDPAY4.Text != "")
    //    {
    //        if (txtRCONTRACTMONTH.Text != txtRENDPAY4.Text)
    //        {
    //            Alert("最後一段結束期別輸入需等於總承作月數！");
    //            txtRENDPAY4.Focus();
    //            return 0;
    //        }
    //        else
    //        {
    //            LBOL_Checked = true;
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY3.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY3.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY3.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY2.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY2.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY2.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }
    //    if (!LBOL_Checked)
    //    {
    //        if (txtRENDPAY1.Text != "")
    //        {
    //            if (txtRCONTRACTMONTH.Text != txtRENDPAY1.Text)
    //            {
    //                Alert("最後一段結束期別輸入需等於總承作月數！");
    //                txtRENDPAY1.Focus();
    //                return 0;
    //            }
    //            else
    //            {
    //                LBOL_Checked = true;
    //            }
    //        }
    //    }
    //    //AR 案件全部以含稅計算
    //    //標的物金額(含稅)
    //    Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text)), 0);
    //    //頭期款(含稅)
    //    Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text)), 0);
    //    //期別
    //    int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
    //    int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
    //    int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
    //    int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
    //    //期數
    //    int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
    //    double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
    //    //計算第0期的現金流量
    //    LDBL_VALUE[0] = Convert.ToDouble(LDCE_FirstPay //頭期款(含稅)
    //                                   - LDCE_TransCost); //標的物金額(含稅)
    //    for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
    //    {
    //        //最後一期
    //        if (i == LINT_CONTRACTMONTH)
    //        {
    //            //最後一期付款
    //            Decimal LDCE_PRINCIPAL = 0;
    //            if (LINT_ENDPAY1 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
    //            }
    //            if (LINT_ENDPAY2 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
    //            }
    //            if (LINT_ENDPAY3 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
    //            }
    //            if (LINT_ENDPAY4 != 0)
    //            {
    //                LDCE_PRINCIPAL = Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
    //            }
    //            LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款(含稅)
    //        }
    //        else
    //        {
    //            if (i >= 1 && i <= LINT_ENDPAY1)
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX1.Text); //月付款(含稅)
    //            }
    //            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX2.Text); //月付款(含稅)
    //            }
    //            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX3.Text); //月付款(含稅)
    //            }
    //            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
    //            {
    //                LDBL_VALUE[i] = Convert.ToDouble(txtRPRINCIPALTAX4.Text); //月付款(含稅)
    //            }
    //        }
    //    }
    //    ////20131129 ADD BY SS ADAM Reason.修正IRR計算產生的錯誤，主要是第零期的現金流量是負值造成的錯誤
    //    //if (LDBL_VALUE[0] < 0)
    //    //    return -999;

    //    double LDBL_IRR = System.Math.Abs(Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200);
    //    return LDBL_IRR;
    //}
    #endregion

    protected double IRR_Cal_ForPPMT_AR()
    {
        DataTable dt = new DataTable();
        DataColumn col1 = new DataColumn("ADVANCESDAYS", Type.GetType("System.Int32"));
        DataColumn col2 = new DataColumn("ADVANCESAMT", Type.GetType("System.Int32"));
        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        int sumBILLAMT = 0;
        int sumFINANCIALFEES = 0;
        int sumFINALPAYAMT = 0;

        if (rptMLDCONTRACTARD.Items.Count > 0)  //UPD BY VICKY 20150311 GRID有資料才計算,沒資料帶0
        {
            for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
            {
                DataRow row01 = dt.NewRow();
                row01[0] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));  //墊款天數
                row01[1] = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESAMT_AR")).Text.Replace(",", ""));    //墊款金額
                dt.Rows.Add(row01);

                sumBILLAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Replace(",", ""));
                sumFINANCIALFEES += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Replace(",", ""));
                sumFINALPAYAMT += Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text.Replace(",", ""));
            }

            int EndDay1 = 0; //最後一張票據墊款天數
            for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
            {
                int EndDay2 = Convert.ToInt32(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Replace(",", ""));
                if (EndDay1 < EndDay2) EndDay1 = EndDay2; //最後一張票據墊款天數

            }

            double[] LDBL_VALUE = new double[EndDay1 + 1];

            for (int i = 0; i < LDBL_VALUE.Length; i++)
            {
                LDBL_VALUE[i] = 0;
            }

            LDBL_VALUE[0] = -1 * (sumBILLAMT - sumFINANCIALFEES - sumFINALPAYAMT);  //撥款金額
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LDBL_VALUE[(int)dt.Rows[i][0]] = (int)dt.Rows[i][1];        //現金流(墊款金額)
            }

            double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0) * 365 * 100;
            return LDBL_IRR;
        }
        else
        {
            return 0;
        }
    }


    private Decimal[][] PPMT_Cal_AR(double LDBL_IRR)
    {
        //標的物金額(未稅)
        Decimal LDCE_TransCost = 0;
        //標的物金額(含稅)
        Decimal LDCE_TransCostTax = 0;
        //頭期款(未稅)
        Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text) / 1.05), 0);
        //頭期款(含稅)
        Decimal LDCE_FirstPayTax = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text)), 0);
        //利率
        LDBL_IRR = Convert.ToDouble((LDBL_IRR / 1200).ToString("0.000000"));
        //期付款未稅
        Decimal LDEC_RPRINCIPAL = Convert.ToDecimal(this.txtRPRINCIPAL1.Text);
        //期付款含稅
        Decimal LDEC_RPRINCIPALTAX = Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);
        //期別
        int LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        int LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        int LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        int LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text);
        //期數
        int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtRCONTRACTMONTH.Text);
        Decimal[][] LDBL_VALUE = new Decimal[LINT_CONTRACTMONTH + 1][];

        int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
            LDCE_TransCostTax += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text));
        }
        //折讓未稅金額
        Decimal LDBL_DISCOUNTAMOUNT = 0;
        //折讓含稅金額
        Decimal LDBL_DISCOUNTAMOUNTTAX = 0;
        LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text));
            LDBL_DISCOUNTAMOUNTTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text));
        }
        LDCE_TransCost = LDCE_TransCost - LDBL_DISCOUNTAMOUNT;
        LDCE_TransCostTax = LDCE_TransCostTax - LDBL_DISCOUNTAMOUNTTAX;
        //本金總額
        Decimal LDCE_TPrincipal = 0;
        //利息總額
        Decimal LDCE_TInterest = 0;
        //總月付款
        Decimal LDCE_TMonthPay = 0;
        //期數[][0] 期付款[][1]	本金[][2]	利息[][3] 未攤本金[][4]	        
        //第 0 期 
        LDBL_VALUE[0] = new Decimal[5];
        LDBL_VALUE[0][0] = 0;
        LDBL_VALUE[0][1] = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text))); //頭期款(含稅)
        LDBL_VALUE[0][2] = LDCE_FirstPay; //本金
        LDBL_VALUE[0][3] = 0; //利息
        LDBL_VALUE[0][4] = (LDCE_TransCostTax - LDCE_FirstPayTax); //未攤本金 = 標的物金額(含稅) - 頭期款(含稅)  
        LDCE_TPrincipal += LDBL_VALUE[0][2];
        LDCE_TInterest += LDBL_VALUE[0][3];
        for (int i = 1; i <= LINT_CONTRACTMONTH; i++)
        {
            if (i >= 1 && i <= LINT_ENDPAY1)
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL1.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX1.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL2.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX2.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL3.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX3.Text); //月付款(含稅)
            }
            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
            {
                LDEC_RPRINCIPAL = Convert.ToDecimal(txtRPRINCIPAL4.Text); //月付款
                LDEC_RPRINCIPALTAX = Convert.ToDecimal(txtRPRINCIPALTAX4.Text); //月付款(含稅)
            }
            LDBL_VALUE[i] = new Decimal[5];
            LDBL_VALUE[i][0] = i;
            LDBL_VALUE[i][1] = Math.Round(LDEC_RPRINCIPALTAX); //期付款(含稅)
            LDBL_VALUE[i][2] = Math.Round(Convert.ToDecimal(Microsoft.VisualBasic.Financial.PPmt(LDBL_IRR, i, LINT_CONTRACTMONTH, -1 * Convert.ToDouble(LDBL_VALUE[0][4]), 0, Microsoft.VisualBasic.DueDate.EndOfPeriod)), 0); //本金
            LDBL_VALUE[i][3] = Math.Round(Convert.ToDecimal(Microsoft.VisualBasic.Financial.IPmt(LDBL_IRR, i, LINT_CONTRACTMONTH, -1 * Convert.ToDouble(LDBL_VALUE[0][4]), 0, Microsoft.VisualBasic.DueDate.EndOfPeriod)), 0); //利息
            LDBL_VALUE[i][4] = Math.Round(LDBL_VALUE[i - 1][4] - LDBL_VALUE[i][2], 0); //未攤本金 = 未攤本金(前一期) - 本金(本期)

            LDCE_TMonthPay += LDEC_RPRINCIPALTAX;//總月付款(含稅)
            //調整利息
            //本金+利息 需等於期付款(含稅) 如果不等 則將 期付款(含稅)-(本金+利息) 算出差額，所算出的差額加到本期利息裡
            LDBL_VALUE[i][3] = Math.Round((LDEC_RPRINCIPALTAX - (LDBL_VALUE[i][2] + LDBL_VALUE[i][3])) + LDBL_VALUE[i][3], 0);

            if (i == LINT_CONTRACTMONTH)
            {
                if (this.drpMAINTYPE.SelectedValue == "03")
                {
                    LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                    LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
                    //計算分差收入差額尾差
                    //分差收入差額 = (((總月付款(含稅) – (本體(含稅) – 頭款(含稅)))) - 利息總額
                    Decimal LDEC_Revenue = (Math.Round(Convert.ToDecimal(Convert.ToDouble(LDCE_TMonthPay - (LDCE_TransCostTax - LDCE_FirstPayTax))), 0)) - LDCE_TInterest;
                    //將分差收入的尾差加到利息裡
                    LDBL_VALUE[i][3] = LDBL_VALUE[i][3] + LDEC_Revenue;
                }
                else
                {
                    if (LDBL_VALUE[i][4] != 0)
                    {
                        //將未償本金的尾差加到利息裡
                        LDBL_VALUE[i][3] = LDBL_VALUE[i][3] + LDBL_VALUE[i][4];
                        LDBL_VALUE[i][2] = LDBL_VALUE[i][2] - LDBL_VALUE[i][4];
                        LDBL_VALUE[i][4] = 0;

                        LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                        LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
                        //將本金總額與標的物金額(含稅)相減算出尾差
                        //本金
                        LDBL_VALUE[i][2] = LDBL_VALUE[i][2] + (LDCE_TransCostTax - LDCE_TPrincipal);
                        //利息
                        LDBL_VALUE[i][3] = LDBL_VALUE[i][3] - (LDCE_TransCostTax - LDCE_TPrincipal);
                    }
                }
            }
            else
            {
                LDCE_TPrincipal += LDBL_VALUE[i][2];//本金總額
                LDCE_TInterest += LDBL_VALUE[i][3];//利息總額
            }
            LDBL_VALUE[i][3] = Math.Round(Convert.ToDecimal(Convert.ToDouble(LDBL_VALUE[i][3]) / 1.05), 0);
        }
        return LDBL_VALUE;
    }

    //Modify 20120918 By SS Gordon. Reason: 新增案件撤件按鈕.
    protected void btnRej_Click(object sender, EventArgs e)
    {
        //新增後可以點選
        //暫存後可以點選
        //撥款確認後不可點選

        //已有合約編號時，狀態為6X，更新MLMCONTRACT
        //沒有合約編號時，狀態為5X，更新MLMCASE
        if (txtCNTRNO.Text != "")
        {
            MLMCASEREJ("6X");
        }
        else
        {
            MLMCASEREJ("5X");
        }
    }
    private void MLMCASEREJ(string LSTR_SaveType)
    {
        StringBuilder LSTR_Data = new StringBuilder();
        //=========================================================================
        if (LSTR_SaveType == "6X")
        {
            //案件主鍵          
            LSTR_Data.Append("SP_ML3002_U02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(txtCNTRNO.Text + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        else
        {
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
        }
        //=========================================================================
        if (LSTR_SaveType == "6X")
        {
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtCNTRNO.Text + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("2");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        else
        {
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("1");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //=========================================================================
        if (LSTR_SaveType == "6X")
        {
            LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            LSTR_Data.Append("ML3002X" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        else
        {
            LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append("ML3002X" + GSTR_TabDelimitChar);
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
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateContractInfo(LSTR_Data.ToString());
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

    #region NPV利率成本計算
    //***********************************************************************
    protected enum TypeA : int
    {
        NewMachinesThree,
        NewMachinesTwo,
        UsedMachines,
        RawMaterials,
        AR,
        MachinesNotSet,
        //20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
        Bank
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
        SUBTYPE = MAINTYPE + "_" + SUBTYPE;
        //20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
        string SOURCETYPE = drpSOURCETYPE.SelectedValue;                                      //承作方式
        string BANKCD = drpBANKCD.SelectedValue;                                              //銀行別
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
                //20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
                if (SOURCETYPE == "02" && BANKCD == "01") //承作方式="02"且銀行別="01"
                {

                    NPVCOST = GetNBMNPVRATECOST(TypeA.Bank, CUSTNOWCAPTIAL, LISTED);
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
        //double[,] NPVRATECOSTLIST = new double[6, 5];
        //20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
        double[,] NPVRATECOSTLIST = new double[7, 5];
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

        //20121114 Modify By Maureen Reason:針對設備台新策盟案件，修改NPV計算成本
        //承作方式為銀行件時，承作型態固定為分期-原物料
        NPVRATECOSTLIST[(int)TypeA.Bank, (int)TypeB.LessThan300] = 10;
        NPVRATECOSTLIST[(int)TypeA.Bank, (int)TypeB.Range300_1000] = 9;
        NPVRATECOSTLIST[(int)TypeA.Bank, (int)TypeB.Range1000_3000] = 8;
        NPVRATECOSTLIST[(int)TypeA.Bank, (int)TypeB.Exceed3000] = 6;
        NPVRATECOSTLIST[(int)TypeA.Bank, (int)TypeB.LISTED] = 5;

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
        //若多筆資料，只要其中一筆是醫師，條件即成立，回傳"01"
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

    #region 檢核動產資料
    //Modify 20121122 By SS Steven. Reason: 擔保條件的動產資料欄位檢核
    private bool check_MLDCASEMOVABLE()
    {
        if (rptMLDCASEMOVABLE.Items.Count < 1)
        {
            Alert("請至少輸入一筆動產資料！");
            return false;
        }
        for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
        {
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENAME")).Text == "")
            {
                Alert("動產設定中，「產品設備」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEZIPCODE")).Text == "")
            {
                Alert("動產設定中，請輸入完整「所在地」，其為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEADDR")).Text == "")
            {
                Alert("動產設定中，請輸入完整「所在地」，其為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Text == "")
            {
                Alert("動產設定中，「機器序號」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Text == "")
            {
                Alert("動產設定中，「出產年份」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Text == "")
            {
                Alert("動產設定中，「購買日期」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENEWAMT")).Text == "" || ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENEWAMT")).Text == "0")
            {
                Alert("動產設定中，「新品金額」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYAMT")).Text == "" || ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYAMT")).Text == "0")
            {
                Alert("動產設定中，「購買金額」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESIDUALS")).Text == "" || ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESIDUALS")).Text == "0")
            {
                Alert("動產設定中，「殘值預估」為必輸入欄位！");
                return false;
            }
            if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Text == "" || ((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLERESETPRICE")).Text == "0")
            {
                Alert("動產設定中，「設定金額」為必輸入欄位");
                return false;
            }
        }
        return true;

    }
    #endregion

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
                RegisterScript("setTimeout('window_onload()',1000);cmdPRINT_Click('" + this.txtCNTRNO.Text + "',"
                                            + "'" + this.txtCASEID.Text + "',"
                                            + "'" + GSTR_U_USERID + "',"
                                            + "'" + GSTR_DEPTNAME + "',"
                                            + "'" + this.hdnPRINTKEY.Text + "',"
                                            + "'" + this.hdnINDT.Text + "',"
                                            + "'" + this.hdnTRADEDT.Text + "',"
                                            + "'" + this.hdnCREDITDT.Text + "'"
                                            + ");");

                //20130731 ADD BY ADAM REASON.修改關係人檢核必先點，才能做撥款確認
                //20160331 ADD BY ADAM REASON.在查詢案件時不可打開撥款確認
                if (lblStatus.Text != "查詢")
                {
                    //this.btnSubmit.Enabled = true;
                }
                //RegisterScript("window_onload();");
                this.UpdatePanel1.Update();
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

    //20130709 UPD BY BRENT Reason.攤提表展開時增加反推IRR邏輯
    private string ReGetIRR(string IRR)
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string IRR_Return = "";
        try
        {
            //標的物金額(未稅)
            Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text) / 1.05), 0);
            Decimal LDCE_TransCostTax = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRTRANSCOST.Text)), 0);

            //頭期款(未稅)
            string LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRFIRSTPAY.Text)), 0).ToString();
            //期別
            string LINT_ENDPAY1 = Convert.ToInt32("0" + txtRENDPAY1.Text).ToString();
            string LINT_ENDPAY2 = Convert.ToInt32("0" + txtRENDPAY2.Text).ToString();
            string LINT_ENDPAY3 = Convert.ToInt32("0" + txtRENDPAY3.Text).ToString();
            string LINT_ENDPAY4 = Convert.ToInt32("0" + txtRENDPAY4.Text).ToString();
            //期數
            string LINT_CONTRACTMONTH = this.txtRCONTRACTMONTH.Text;

            //資租計算PPMT時的IRR需以發票金額為計算基準
            LDCE_TransCost = 0;
            LDCE_TransCostTax = 0;
            int LSTR_RowCount = this.rptMLDCONTRACTINV.Items.Count;
            for (var i = 0; i < LSTR_RowCount; i++)
            {
                LDCE_TransCost += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtNOTAXAMOUNT")).Text));
                LDCE_TransCostTax += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtANOUMTTAX")).Text));
            }
            //折讓未稅金額
            Decimal LDBL_DISCOUNTAMOUNT = 0;
            Decimal LDBL_DISCOUNTAMOUNTTAX = 0;
            LSTR_RowCount = this.rptMLDCONTRACTINVD.Items.Count;
            for (var i = 0; i < LSTR_RowCount; i++)
            {
                LDBL_DISCOUNTAMOUNT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text));
                LDBL_DISCOUNTAMOUNTTAX += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNTTAX")).Text));
            }
            LDCE_TransCost = LDCE_TransCost - LDBL_DISCOUNTAMOUNT;
            LDCE_TransCostTax = LDCE_TransCostTax - LDBL_DISCOUNTAMOUNTTAX;

            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML3002_Q01 ";
            LVAR_Parameter[1] = "'" + LDCE_TransCost.ToString() + "','" + LDCE_FirstPay + "','" + (Convert.ToDecimal(IRR) / 100).ToString() + "','" + LINT_CONTRACTMONTH + "','0.05','" + LINT_ENDPAY1 + "','" + LINT_ENDPAY2 + "','" + LINT_ENDPAY3 + "','" + LINT_ENDPAY4 + "','" + this.txtRPRINCIPAL1.Text.Replace(",", "") + "','" + this.txtRPRINCIPAL2.Text.Replace(",", "") + "','" + this.txtRPRINCIPAL3.Text.Replace(",", "") + "','" + this.txtRPRINCIPAL4.Text.Replace(",", "") + "','" + this.txtCNTRNO.Text + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                DataTable LOBJ_Data = LOBJ_Return.ReturnData;
                IRR_Return = LOBJ_Data.Rows[0]["IRR"].ToString().Trim();     //反推IRR
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return IRR_Return;
        return IRR_Return;
    }

    //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕開窗、參數設定
    protected void btINSURANCE_Click(object sender, EventArgs e)
    {
        string strSNTYPE = "";
        string strCASEID = txtCASEID.Text.ToString().Trim();
        string strCNTRNO = txtCNTRNO.Text.ToString().Trim();
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

        if (drpMAINTYPE.SelectedValue == "" && drpSUBTYPE.SelectedValue == "")
        {
            Alert("請選擇承作型態！");
            return;
        }

        if (rptMLDCASETARGET.Items.Count > 0)
        {
            strTARGETTYPEV = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.Split('_')[0].ToString();
            strTARGETTYPET = ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedItem.Text.ToString().Trim();
            strTARGETNAME = ((TextBox)rptMLDCASETARGET.Items[0].FindControl("txtTARGETNAME")).Text.ToString().Trim();
            strTARGETPRICE = ((TextBox)rptMLDCASETARGET.Items[0].FindControl("txtTARGETPRICE")).Text.ToString().Replace(",", "").Trim();

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
            "&strCASEID=" + strCASEID + "&strMOD=N&strMAINTYPEV=" + strMAINTYPEV +
            "&strMAINTYPET=" + Server.UrlEncode(strMAINTYPET) + "&strSUBTYPEV=" + strSUBTYPEV +
            "&strSUBTYPET=" + Server.UrlEncode(strSUBTYPET) + "&strTARGETTYPEV=" + strTARGETTYPEV +
            "&strTARGETTYPET=" + Server.UrlEncode(strTARGETTYPET) + "&strTARGETNAME=" + Server.UrlEncode(strTARGETNAME) +
            "&strTARGETPRICE=" + strTARGETPRICE + "&strSOURCE=01&strCUSTID=" + txtCUSTID.Text;

        strSCRIPT += "var url = window.showModalDialog('" + URL + "', 'title', 'dialogWidth:600px;dialogHeight:550px;scroll:yes;resizable:yes;status:no;');" + "\n";
        //strSCRIPT += "alert(url);" + "\n";
        //strSCRIPT += "document.getElementById('" + txtINSURANCE.ClientID.ToString().Trim() + "').value = url;" + "\n";
        RegisterScript(strSCRIPT);
    }

    //Modify 20130814 BY CHRIS FU Reason: 新增保險費按鈕開窗、參數設定
    protected void btINSURANCE2_Click(object sender, EventArgs e)
    {
        string strSNTYPE = "";
        string strCASEID = txtCASEID.Text.ToString().Trim();
        string strCNTRNO = txtCNTRNO.Text.ToString().Trim();
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
        //20130925 Modify by SS Vicky 改為用[受讓/發票金額]
        strTARGETPRICE = txtRTRANSCOST.Text.ToString().Replace(",", "");
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
        string URL = "";
        if (strCNTRNO == "")
        {
            URL = "../LE.NET/ML10/ML1002D.aspx?userid=" + GSTR_A_USERID + "&PROGID=" + GSTR_A_PRGID + "&strSNTYPE=" + strSNTYPE +
                "&strCASEID=" + strCASEID + "&strMOD=" + strMOD + "&strMAINTYPEV=" + strMAINTYPEV +
                "&strMAINTYPET=" + Server.UrlEncode(strMAINTYPET) + "&strSUBTYPEV=" + strSUBTYPEV +
                "&strSUBTYPET=" + Server.UrlEncode(strSUBTYPET) + "&strTARGETTYPEV=" + strTARGETTYPEV +
                "&strTARGETTYPET=" + Server.UrlEncode(strTARGETTYPET) + "&strTARGETNAME=" + Server.UrlEncode(strTARGETNAME) +
                "&strTARGETPRICE=" + strTARGETPRICE + "&strSOURCE=02&strCUSTID=" + txtCUSTID.Text +
                "&strINSUREERR=" + hidINSUREERR.Value;
            strSCRIPT += "var url = window.showModalDialog('" + URL + "', 'title', 'dialogWidth:600px;dialogHeight:550px;scroll:yes;resizable:yes;status:no;');" + "\n";
        }
        else
        {
            URL = "../LE.NET/ML10/ML1002D.aspx?userid=" + GSTR_A_USERID + "&PROGID=" + GSTR_A_PRGID + "&strSNTYPE=" + strSNTYPE +
                "&strCASEID=" + strCASEID + "&strCNTRNO=" + strCNTRNO + "&strMOD=" + strMOD + "&strMAINTYPEV=" + strMAINTYPEV +
                "&strMAINTYPET=" + Server.UrlEncode(strMAINTYPET) + "&strSUBTYPEV=" + strSUBTYPEV +
                "&strSUBTYPET=" + Server.UrlEncode(strSUBTYPET) + "&strTARGETTYPEV=" + strTARGETTYPEV +
                "&strTARGETTYPET=" + Server.UrlEncode(strTARGETTYPET) + "&strTARGETNAME=" + Server.UrlEncode(strTARGETNAME) +
                "&strTARGETPRICE=" + strTARGETPRICE + "&strSOURCE=02&strCUSTID=" + txtCUSTID.Text +
                "&strINSUREERR=" + hidINSUREERR.Value;

            strSCRIPT += "var url = window.showModalDialog('" + URL + "', 'title', 'dialogWidth:600px;dialogHeight:550px;scroll:yes;resizable:yes;status:no;');" + "\n";
        }
        //strSCRIPT += "alert(url);" + "\n";
        //20130904 ADD BY ADAM Reason.
        strSCRIPT += "if (url) {";
        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        strSCRIPT += "var drpMAINTYPE = document.getElementById('" + drpMAINTYPE.ClientID.ToString().Trim() + "')" + "\n";
        strSCRIPT += "var drpSUBTYPE = document.getElementById('" + drpSUBTYPE.ClientID.ToString().Trim() + "')" + "\n";
        strSCRIPT += "var LOBJ_Control = $('tblMLDCASETARGET').rows[1].cells[1].firstChild;" + "\n";
        strSCRIPT += "document.getElementById('" + txtRINSURANCE.ClientID.ToString().Trim() + "').value = url;" + "\n";
        strSCRIPT += "MoneyBlur($('txtRINSURANCE'));" + "\n";
        strSCRIPT += "document.getElementById('" + hidMAINTYPE.ClientID.ToString().Trim() + "').value = drpMAINTYPE.options[drpMAINTYPE.selectedIndex].value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidSUBTYPE.ClientID.ToString().Trim() + "').value = drpSUBTYPE.options[drpSUBTYPE.selectedIndex].value;" + "\n";
        //20130925 Modify by SS Vicky 改為用[受讓/發票金額]
        strSCRIPT += "document.getElementById('" + hidTARGETPRICE.ClientID.ToString().Trim() + "').value = document.getElementById('" + txtRTRANSCOST.ClientID.ToString() + "').value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidTARGETTYPE.ClientID.ToString().Trim() + "').value = LOBJ_Control.value;" + "\n";
        strSCRIPT += "document.getElementById('" + hidINSUREERR.ClientID.ToString().Trim() + "').value = 'N';" + "\n";
        strSCRIPT += "}";
        RegisterScript(strSCRIPT);
    }

    //Modify 20130814 BY CHRIS FU Reason: 新增保險異常勾選時，保險費為0
    protected void txtNOINSURANCEFLG_CheckedChanged(object sender, EventArgs e)
    {
        if (txtRNOINSURANCEFLG.Checked == true)
        {
            btINSURANCE2.Enabled = false;
            txtRINSURANCE.Text = "0";
        }
        else
        {
            btINSURANCE2.Enabled = true;
        }
    }

    //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
    private bool CheckINSUREERR()
    {
        if (drpMAINTYPE.SelectedValue != hidMAINTYPE.Value ||
            drpSUBTYPE.SelectedValue != hidSUBTYPE.Value ||
            //txtTRANSCOST.Text != hidTARGETPRICE.Value)
            txtRTRANSCOST.Text != hidTARGETPRICE.Value)  //Modify by SS Vicky 20130925 改為用[受讓/發票金額]
        {
            hidINSUREERR.Value = "Y";
            //RegisterScript("alert('" + hidMAINTYPE.Value + "," + hidSUBTYPE.Value + "," + hidTARGETPRICE.Value + "');");
            btINSURANCE2_Click(new object(), EventArgs.Empty);
            return true;
        }

        if (rptMLDCASETARGET.Items.Count > 0)
        {
            if (hidTARGETTYPE.Value != ((DropDownList)rptMLDCASETARGET.Items[0].FindControl("drpTARGETTYPE")).SelectedValue.ToString())
            {
                hidINSUREERR.Value = "Y";
                btINSURANCE2_Click(new object(), EventArgs.Empty);
                return true;
            }
        }

        return false;
    }

    //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
    //Modify 20131002 By SS Steven. Reason: 確認=暫存功能+業代確認為Y
    protected void btnSURE_Click(object sender, EventArgs e)
    {
        if (txtPRGID.Text.ToString().Trim() == "LE3001A")
        {
            if ((this.drpMAINTYPE.SelectedValue != "03" || this.drpSUBTYPE.SelectedValue != "02"))
            {
                if (check_3001MLDCASEMOVABLE() == false)
                {
                    return;
                }
            }
            //JOHN 2013/10/09 確認的話業代確認為Y
            this.txtSALESFLG.Text = "Y";
        }
        else this.txtSALESFLG.Text = "N";


        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        if (drpMAINTYPE.SelectedValue != "04" && txtRNOINSURANCEFLG.Checked == false)
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

        //20141014 ADD BY SS ADAM REASON.調整邏輯，3001A確認增加重新計算IRR NPV        
        double LINT_IRR = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            LINT_IRR = IRR_Cal_AR();
        }
        else
        {
            LINT_IRR = IRR_Cal();
        }
        this.txtRIRR.Text = LINT_IRR.ToString("0.000");

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        double LINT_NPV0 = 0;

        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        double LINT_NPV = 0;
        double LINT_NPV2 = 0;
        if (this.drpMAINTYPE.SelectedValue == "04")
        {
            LINT_NPV0 = NPV_Cal_AR(txtRNPVRATECOST0.Text);

            LINT_NPV = NPV_Cal_AR(txtRNPVRATECOST.Text);
            LINT_NPV2 = NPV_Cal_AR(txtRNPVRATECOST2.Text);
        }
        else
        {
            LINT_NPV0 = NPV_Cal(txtRNPVRATECOST0.Text);

            LINT_NPV = NPV_Cal(txtRNPVRATECOST.Text);
            LINT_NPV2 = NPV_Cal(txtRNPVRATECOST2.Text);
        }
        this.txtRNPV0.Text = LINT_NPV0.ToString("0");

        this.txtRNPV.Text = LINT_NPV.ToString("0");
        this.txtRNPV2.Text = LINT_NPV2.ToString("0");
        this.UpdatePanelIRR.Update();

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPV0.Update();

        this.UpdatePanelNPV.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPV2.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        //double LINT_NPVRATECOST = GET_NPVRATECOST();
        //this.txtRNPVRATECOST.Text = LINT_NPVRATECOST.ToString();

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.txtRNPVRATECOST0.Text = "1";

        //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV的值固定帶4.
        //Modify 20240815 利率成本改4.75%
        //this.txtRNPVRATECOST.Text = "4";
        this.txtRNPVRATECOST.Text = "4.75";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtRNPVRATECOST2.Text = "5";

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPVRATECOST0.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNPVRATECOST.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPVRATECOST2.Update();

        MLMCONTRACTSave("6", "Y");
        this.UpdatePanel1.Update();

    }

    //Modify 20131002 By SS Steven. Reason: 1.PRGID若是ML3001A則可開放修改動產設定的機器序號、出產年份、購買日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
    //2.PRGID若是ML3001A則可開放修改不動產設定的登記日期，承作內容為分期付條買的話，則為非必填，反之則為必填。
    //3.PRGID若是ML3001A則可開放修改保證人的本票金額，承作內容為分期付條買的話，則為非必填，反之則為必填。
    private bool check_3001MLDCASEMOVABLE()
    {
        if (rptMLDCASEMOVABLE.Items.Count > 0)
        {
            for (int i = 0; i < rptMLDCASEMOVABLE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLENO")).Text == "")
                {
                    Alert("動產設定中，「機器序號」為必輸入欄位！");
                    return false;
                }
                if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEYEAR")).Text == "")
                {
                    Alert("動產設定中，「出產年份」為必輸入欄位！");
                    return false;
                }
                if (((TextBox)rptMLDCASEMOVABLE.Items[i].FindControl("txtMOVABLEBUYDATE")).Text == "")
                {
                    Alert("動產設定中，「購買日期」為必輸入欄位！");
                    return false;
                }
            }
        }

        if (rptMLDCASEGUARANTEE.Items.Count > 0)
        {
            for (int i = 0; i < rptMLDCASEGUARANTEE.Items.Count; i++)
            {
                if (((TextBox)rptMLDCASEGUARANTEE.Items[i].FindControl("txtGUARANTEEANOUNT")).Text == "")
                {
                    Alert("擔保條件裡的「本票金額」為必輸入欄位！");
                    return false;
                }
            }
        }

        if (rptMLDHUMANRIGHTS.Items.Count > 0)
        {
            for (int i = 0; i < rptMLDHUMANRIGHTS.Items.Count; i++)
            {
                if (((TextBox)rptMLDHUMANRIGHTS.Items[i].FindControl("txtREGISTDATE")).Text == "")
                {
                    Alert("不動產設定的「登記日期」為必輸入欄位！");
                    return false;
                }
            }
        }
        return true;
    }

    //Modify 20131002 By SS Steven. Reason: 返回合約修改維護=暫存功能+業代確認為N
    protected void btnBackModify_Click(object sender, EventArgs e)
    {
        if (txtPRGID.Text.ToString().Trim() == "LE3001A")
        {
            if ((this.drpMAINTYPE.SelectedValue != "03" || this.drpSUBTYPE.SelectedValue != "02"))
            {
                if (check_3001MLDCASEMOVABLE() == false)
                {
                    return;
                }
            }
            //john 2013/10/09 退回為N
            this.txtSALESFLG.Text = "N";
        }

        //20130914 ADD BY ADAM Reason.增加判斷保險金額是否需要異動
        if (drpMAINTYPE.SelectedValue != "04" && txtRNOINSURANCEFLG.Checked == false)
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

        //Modify 20161130 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.txtRNPVRATECOST0.Text = "1";

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        //double LINT_NPVRATECOST = GET_NPVRATECOST();
        //this.txtRNPVRATECOST.Text = LINT_NPVRATECOST.ToString();
        //Modify 20140428 By SS Chris Fu. Reason: 試算與存檔點選後NPV的值固定帶4.
        //Modify 20240815 利率成本改4.75%
        //this.txtRNPVRATECOST.Text = "4";
        this.txtRNPVRATECOST.Text = "4.75";
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.txtRNPVRATECOST2.Text = "5";

        //Modify 20161215 By SEAN. Reason: 新增NPV0與NPV利率成本0
        this.UpdatePanelNPVRATECOST0.Update();

        //Modify 20120301 By SS Gordon. Reason: 新增NPV利率成本計算方法.
        this.UpdatePanelNPVRATECOST.Update();
        //Modify 20141205 By SS Gordon. Reason: 新增NPV2與NPV利率成本2
        this.UpdatePanelNPVRATECOST2.Update();

        MLMCONTRACTSave("6", "N");
        this.UpdatePanel1.Update();
    }
    //20221031新增驗證
    protected void btnPayDate_Click(object sender, EventArgs e)
    {
        //20221031新增驗證
        Session["Maintain"] = "true";
        MLMCONTRACTSave("6", "T");
        string url;
        url = "funcRet=window.showModalDialog(";
        url += "'../LE.NET/ML30/ML3002D.aspx?CNTRNO=" + Server.UrlEncode(this.txtCNTRNO.Text.Trim());
        //url += "')";
        url += "','','dialogHeight=600px;dialogWidth=800px;');";
        //url = "funcRet=window.open(";
        //url += "'../LE.NET/ML30/ML3002D.aspx?CNTRNO=" + Server.UrlEncode(this.txtCNTRNO.Text.Trim());
        //url += "','_blank','dialogHeight=500px;dialogWidth=600px;');";
        RegisterScript(url);
    }

    //Modify 20131202 By SS Leo     Reason: 增加承作內容核准書列印
    public void SetReportScript()
    {
        string strScript = "";
        strScript += "var cRepotr='" + cRepotr + "';" + "\n";
        strScript += "var cUrl='" + cUrl + "';" + "\n";
        strScript += "var cPath='" + cPath + "';" + "\n";
        strScript += "var cUserName='" + cUserName + "';" + "\n";
        strScript += "var cPass='" + cPass + "';" + "\n";
        strScript += "var cCompany='" + cCompany + "';" + "\n";
        strScript += "var txtCNTRNO='" + txtCNTRNO.ClientID.ToString() + "';" + "\n";
        strScript += "var GSTR_A_USERID='" + GSTR_A_USERID + "';" + "\n";

        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "SetReportScript", strScript, true);
    }

    #region 撥款案件AR明細  Modify by SS Vicky 20150122

    private void MLDCONTRACTARDInit()
    {
        if (ViewState["MLDCONTRACTARD"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDCONTRACTARD");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));

            LOBJ_Data.Columns.Add(new DataColumn("PAYTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DRAWER", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("DEPOSITID", System.Type.GetType("System.String")));  //UPD BY VICKY 20150203 付款行庫ID
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

    private DataTable updateMLDCONTRACTARD()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARD"];
        //先賦值
        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["PAYTYPE"] = ((DropDownList)rptMLDCONTRACTARD.Items[i].FindControl("drpPAYTYPE_AR")).SelectedValue;
            LOBJ_Data.Rows[i]["DRAWER"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtDRAWER_AR")).Text;
            LOBJ_Data.Rows[i]["DEPOSITID"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtDEPOSITID_AR")).Text;  //UPD BY VICKY 20150203 付款行庫ID
            LOBJ_Data.Rows[i]["DEPOSITBANK"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtDEPOSITBANK_AR")).Text;
            LOBJ_Data.Rows[i]["ACCOUNT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtACCOUNT_AR")).Text;
            LOBJ_Data.Rows[i]["BILLNO"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLNO_AR")).Text;

            LOBJ_Data.Rows[i]["BUYER"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBUYER_AR")).Text;
            LOBJ_Data.Rows[i]["BILLEXPIRYDT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLEXPIRYDT_AR")).Text;
            LOBJ_Data.Rows[i]["ADVANCESDAYS"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text;
            LOBJ_Data.Rows[i]["BILLAMT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text;
            LOBJ_Data.Rows[i]["ADVANCESPERCENT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESPERCENT_AR")).Text;

            LOBJ_Data.Rows[i]["ADVANCESAMT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESAMT_AR")).Text;
            LOBJ_Data.Rows[i]["FINANCIALFEES"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text;
            LOBJ_Data.Rows[i]["FINALPAYAMT"] = ((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text;
            LOBJ_Data.Rows[i]["ENDORSEMENTFLG"] = (((CheckBox)rptMLDCONTRACTARD.Items[i].FindControl("chkENDORSEMENTFLG")).Checked == true ? "Y" : "N");
        }
        return LOBJ_Data;
    }

    private void AddMLDCONTRACTARDRow()
    {
        if (txtCREDITFEES_AR.Text.Trim() == "")
        {
            Alert("請輸入徵信費收入!");
            return;
        }

        //20150319 ADD BY SS ADAM REASON.隱藏承作內容的預計撥款日
        //if (txtPAYDATE_AR.Text.Trim() == "")
        if (txtPAYDATE.Text.Trim() == "")
        {
            Alert("請輸入預計撥款日!");
            return;
        }

        if (txtADVANCESINTEREST_AR.Text.Trim() == "")
        {
            Alert("請輸入墊款息!");
            return;
        }

        if (txtMANAGERFEES_AR.Text.Trim() == "")
        {
            Alert("請輸入帳務管理收入!");
            return;
        }

        if (txtFINANCIALFEES_AR.Text.Trim() == "")
        {
            Alert("請輸入財務顧問收入!");
            return;
        }

        MLDCONTRACTARDInit();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTARD();
        //新增一筆資料 
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();

        LOBJ_DataRow["BILLAMT"] = "0";
        LOBJ_DataRow["ADVANCESPERCENT"] = this.drpADVANCESPERCENT_AR.SelectedValue;

        LOBJ_DataRow["ADVANCESAMT"] = "0";
        LOBJ_DataRow["FINANCIALFEES"] = "0";
        LOBJ_DataRow["FINALPAYAMT"] = "0";

        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCONTRACTARD"] = LOBJ_Data;
        MLDCONTRACTARDBind();
    }

    private void DelMLDCONTRACTARDRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTARD();
        //刪除一筆資料   
        if (rptMLDCONTRACTARD.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));

        }
        ViewState["MLDCONTRACTARD"] = LOBJ_Data;
        MLDCONTRACTARDBind();


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

        this.UpdatePanelMLDCONTRACTARD.Update();
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

    //20150327 ADD BY SS ADAM REASON.增加複製功能
    protected void MLDCONTRACTARD_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int rowcount = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "CopyRowData1")
        {
            MLDCONTRACTARDInit();
            //更新暫存資料
            DataTable LOBJ_Data = updateMLDCONTRACTARD();
            //新增一筆資料      
            DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
            LOBJ_DataRow["PAYTYPE"] = LOBJ_Data.Rows[rowcount]["PAYTYPE"];
            LOBJ_DataRow["DRAWER"] = LOBJ_Data.Rows[rowcount]["DRAWER"];
            LOBJ_DataRow["DEPOSITID"] = LOBJ_Data.Rows[rowcount]["DEPOSITID"];
            LOBJ_DataRow["DEPOSITBANK"] = LOBJ_Data.Rows[rowcount]["DEPOSITBANK"];
            LOBJ_DataRow["ACCOUNT"] = LOBJ_Data.Rows[rowcount]["ACCOUNT"];
            LOBJ_DataRow["BILLNO"] = LOBJ_Data.Rows[rowcount]["BILLNO"];
            LOBJ_DataRow["BUYER"] = LOBJ_Data.Rows[rowcount]["BUYER"];
            LOBJ_DataRow["BILLEXPIRYDT"] = LOBJ_Data.Rows[rowcount]["BILLEXPIRYDT"];
            LOBJ_DataRow["ADVANCESDAYS"] = LOBJ_Data.Rows[rowcount]["ADVANCESDAYS"];
            LOBJ_DataRow["BILLAMT"] = LOBJ_Data.Rows[rowcount]["BILLAMT"];
            LOBJ_DataRow["ADVANCESPERCENT"] = LOBJ_Data.Rows[rowcount]["ADVANCESPERCENT"];
            LOBJ_DataRow["ADVANCESAMT"] = LOBJ_Data.Rows[rowcount]["ADVANCESAMT"];
            LOBJ_DataRow["FINANCIALFEES"] = LOBJ_Data.Rows[rowcount]["FINANCIALFEES"];
            LOBJ_DataRow["FINALPAYAMT"] = LOBJ_Data.Rows[rowcount]["FINALPAYAMT"];
            LOBJ_DataRow["ENDORSEMENTFLG"] = LOBJ_Data.Rows[rowcount]["ENDORSEMENTFLG"];

            LOBJ_Data.Rows.Add(LOBJ_DataRow);
            ViewState["MLDCONTRACTARD"] = LOBJ_Data;

            MLDCONTRACTARDBind();
            this.UpdatePanelMLDCONTRACTARD.Update();
        }

    }
    #endregion

    #region 買受發票明細GRID Modify by SS Vicky 20150122

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

    private DataTable updateMLDCONTRACTARBINV()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDCONTRACTARBINV"];
        //先賦值
        for (int i = 0; i < rptMLDCONTRACTARBINV.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["SEQNO"] = ((HiddenField)rptMLDCONTRACTARBINV.Items[i].FindControl("hidMLDCONTRACTARBINVID")).Value;
            LOBJ_Data.Rows[i]["BUYER"] = ((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtBUYER_INV")).Text;
            LOBJ_Data.Rows[i]["UNIMNO"] = ((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtUNIMNO_INV")).Text;
            LOBJ_Data.Rows[i]["INVNO"] = ((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVNO_INV")).Text;
            LOBJ_Data.Rows[i]["INVDT"] = ((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVDT_INV")).Text;
            LOBJ_Data.Rows[i]["INVAMT"] = ((TextBox)rptMLDCONTRACTARBINV.Items[i].FindControl("txtINVAMT_INV")).Text;

        }
        return LOBJ_Data;
    }

    private void AddMLDCONTRACTARBINVRow()
    {
        MLDCONTRACTARBINVInit();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTARBINV();
        //刪除一筆資料   
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["INVAMT"] = "0";
        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDCONTRACTARBINV"] = LOBJ_Data;
        MLDCONTRACTARBINVBind();
    }

    private void DelMLDCONTRACTARBINVRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDCONTRACTARBINV();
        //刪除一筆資料   
        if (rptMLDCONTRACTARBINV.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));

        }
        ViewState["MLDCONTRACTARBINV"] = LOBJ_Data;
        MLDCONTRACTARBINVBind();
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

        this.UpdatePanelMLDCONTRACTARBINV.Update();
    }

    #endregion

    private bool chkMLDCONTRACTARD()
    {
        if (rptMLDCONTRACTARD.Items.Count < 1)
        {
            Alert("請至少輸入一筆AR明細!");
            return false;
        }

        for (int i = 0; i < rptMLDCONTRACTARD.Items.Count; i++)
        {
            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLEXPIRYDT_AR")).Text.Trim() == "")
            {
                Alert("票據到期日不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESDAYS_AR")).Text.Trim() == "")
            {
                Alert("墊款天數不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Trim() == "")
            {
                Alert("票面受讓金額不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Trim() == "0")
            {
                Alert("票面受讓金額不可為零!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtADVANCESPERCENT_AR")).Text.Trim() == "")
            {
                Alert("墊款成數不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Trim() == "")
            {
                Alert("墊款金額不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINANCIALFEES_AR")).Text.Trim() == "")
            {
                Alert("應收墊款息不可空白!");
                return false;
            }

            if (((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtFINALPAYAMT_AR")).Text.Trim() == "")
            {
                Alert("尾款金額不可空白!");
                return false;
            }
        }
        return true;
    }

    //UPD BY VICKY 20150128 計算總受讓金額
    private void CalINVOICEAMOUNT_AR()
    {
        //計算
        //總受讓金額
        Decimal LDBL_NVOICEAMOUNT_AR = 0;

        int LSTR_RowCount = this.rptMLDCONTRACTARD.Items.Count;
        for (var i = 0; i < LSTR_RowCount; i++)
        {
            LDBL_NVOICEAMOUNT_AR += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTARD.Items[i].FindControl("txtBILLAMT_AR")).Text.Replace(",", "")));
        }

        this.txtINVOICEAMOUNT_AR.Text = LDBL_NVOICEAMOUNT_AR.ToString("#,##0");
        this.UpdatePanelContract_AR.Update();
        this.UpdatePanelMLDCONTRACTARD.Update();
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
        this.UpdatePanelContract_AR.Update();
        this.UpdatePanelMLDCONTRACTARD.Update();
    }

    #region 20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
    private void AddMLDASSPAYMFRow()
    {
        MLDASSPAYMFInit();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDASSPAYMF();
        //新增一筆資料 
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();

        LOBJ_DataRow["SEQNO"] = "0";
        LOBJ_DataRow["CERTNO"] = "";
        LOBJ_DataRow["PAYEE"] = "";
        LOBJ_DataRow["PAYEENM"] = "";
        LOBJ_DataRow["SUPSEQ"] = "";
        LOBJ_DataRow["TRANSBANK"] = "";
        LOBJ_DataRow["SUBBANK"] = "";
        LOBJ_DataRow["ACCNM"] = "";
        LOBJ_DataRow["ACC"] = "";
        LOBJ_DataRow["TRANSAMT"] = "0";

        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDASSPAYMF"] = LOBJ_Data;
        MLDASSPAYMFBind();
    }
    private void DelMLDASSPAYMFRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDASSPAYMF();
        //刪除一筆資料   
        if (rptMLDASSPAYMF.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));

        }
        ViewState["MLDASSPAYMF"] = LOBJ_Data;
        MLDASSPAYMFBind();
    }
    private void MLDASSPAYMFInit()
    {
        if (ViewState["MLDASSPAYMF"] == null)
        {
            DataTable LOBJ_Data = new DataTable("MLDASSPAYMF");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CERTNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PAYEE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PAYEENM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUPSEQ", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TRANSBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SUBBANK", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ACCNM", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("ACC", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TRANSAMT", System.Type.GetType("System.String")));

            ViewState["MLDASSPAYMF"] = LOBJ_Data;
        }
    }
    private DataTable updateMLDASSPAYMF()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDASSPAYMF"];
        //先賦值
        for (int i = 0; i < rptMLDASSPAYMF.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["SEQNO"] = ((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hdSEQNO")).Value;
            LOBJ_Data.Rows[i]["CERTNO"] = ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).Text;
            LOBJ_Data.Rows[i]["PAYEE"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEE")).Text;
            LOBJ_Data.Rows[i]["PAYEENM"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEENM")).Text;
            LOBJ_Data.Rows[i]["SUPSEQ"] = ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpSUPSEQ")).SelectedValue;
            LOBJ_Data.Rows[i]["TRANSBANK"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtTRANSBANK")).Text;
            LOBJ_Data.Rows[i]["SUBBANK"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtSUBBANK")).Text;
            LOBJ_Data.Rows[i]["ACCNM"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtACCNM")).Text;
            LOBJ_Data.Rows[i]["ACC"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtACC")).Text;
            LOBJ_Data.Rows[i]["TRANSAMT"] = ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtTRANSAMT")).Text;
        }
        return LOBJ_Data;
    }
    private void GetMLDASSPAYMFBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ChangeMLDASSPAYMFType(LOBJ_Data);
            MLDASSPAYMFBind();
        }
        else
        {
            rptMLDASSPAYMF.DataSource = LOBJ_Data;
            rptMLDASSPAYMF.DataBind();
        }
    }
    private void ChangeMLDASSPAYMFType(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDASSPAYMF"] = null;
        MLDASSPAYMFInit();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDASSPAYMF"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDASSPAYMF"] = LOBJ_Data;
    }
    private void MLDASSPAYMFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDASSPAYMF"];
        this.rptMLDASSPAYMF.DataSource = LOBJ_Data;
        this.rptMLDASSPAYMF.DataBind();

        //取得憑證清單
        DataTable CERTIFICATENO = new DataTable();
        CERTIFICATENO.Columns.Add(new DataColumn("TEXT", typeof(string)));
        CERTIFICATENO.Columns.Add(new DataColumn("VALUE", typeof(string)));
        for (int i = 0; i < rptMLDCONTRACTINV.Items.Count; i++)
        {
            string CERTNO = ((TextBox)rptMLDCONTRACTINV.Items[i].FindControl("txtCERTIFICATENO")).Text;
            DataRow dr = CERTIFICATENO.NewRow();
            dr["TEXT"] = CERTNO;
            dr["VALUE"] = CERTNO;
            CERTIFICATENO.Rows.Add(dr);
        }

        for (int i = 0; i < rptMLDASSPAYMF.Items.Count; i++)
        {
            if (((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEE")).Text != "")
            {
                GetACCOMFRV(rptMLDASSPAYMF.Items[i], ((TextBox)rptMLDASSPAYMF.Items[i].FindControl("txtPAYEE")).Text);
            }
            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpSUPSEQ")).SelectedValue = ((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidSUPSEQ")).Value;
            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpSUPSEQ")).Attributes.Add("onchange", "drpSUPSEQ2_onchange(this);");

            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).DataSource = CERTIFICATENO;
            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).DataTextField = "TEXT";
            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).DataValueField = "VALUE";
            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).DataBind();

            ((DropDownList)rptMLDASSPAYMF.Items[i].FindControl("drpCERTNO")).SelectedValue = ((HiddenField)rptMLDASSPAYMF.Items[i].FindControl("hidCERTNO")).Value;
        }

        UpdatePanelMLDASSPAYMF.Update();
    }
    private void AddMLDFEEINCOME1Row()
    {
        MLDFEEINCOME1Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDFEEINCOME1();
        //新增一筆資料 
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();

        LOBJ_DataRow["SEQNO"] = "0";
        LOBJ_DataRow["UNIMNO"] = "";
        LOBJ_DataRow["TARGET"] = "";
        LOBJ_DataRow["FEEAMT"] = "0";
        LOBJ_DataRow["PAYTYPE"] = "";
        LOBJ_DataRow["CUSTTYPE"] = "";

        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDFEEINCOME1"] = LOBJ_Data;
        MLDFEEINCOME1Bind();
    }
    private void DelMLDFEEINCOME1Row(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDFEEINCOME1();
        //刪除一筆資料   
        if (rptMLDFEEINCOME1.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        }
        ViewState["MLDFEEINCOME1"] = LOBJ_Data;
        MLDFEEINCOME1Bind();
    }
    private DataTable updateMLDFEEINCOME1()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME1"];

        for (int i = 0; i < rptMLDFEEINCOME1.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["SEQNO"] = ((HiddenField)rptMLDFEEINCOME1.Items[i].FindControl("hdSEQNO")).Value;
            LOBJ_Data.Rows[i]["UNIMNO"] = ((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtUNIMNO")).Text;
            LOBJ_Data.Rows[i]["TARGET"] = ((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtTARGET")).Text;
            LOBJ_Data.Rows[i]["FEEAMT"] = ((TextBox)rptMLDFEEINCOME1.Items[i].FindControl("txtFEEAMT")).Text;
            LOBJ_Data.Rows[i]["PAYTYPE"] = ((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpPAYTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["CUSTTYPE"] = ((DropDownList)rptMLDFEEINCOME1.Items[i].FindControl("drpCUSTTYPE")).SelectedValue;
        }
        return LOBJ_Data;
    }
    private void MLDFEEINCOME1Init()
    {
        if (ViewState["MLDFEEINCOME1"] == null)
        {
            DataTable LOBJ_Data = new DataTable("MLDFEEINCOME1");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("UNIMNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGET", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FEEAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PAYTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CUSTTYPE", System.Type.GetType("System.String")));

            ViewState["MLDFEEINCOME1"] = LOBJ_Data;
        }
    }
    private void GetMLDFEEINCOME1Bind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ChangeMLDFEEINCOME1Type(LOBJ_Data);
            MLDFEEINCOME1Bind();
        }
        else
        {
            rptMLDFEEINCOME1.DataSource = LOBJ_Data;
            rptMLDFEEINCOME1.DataBind();
        }
    }
    private void ChangeMLDFEEINCOME1Type(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDFEEINCOME1"] = null;
        MLDFEEINCOME1Init();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME1"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDFEEINCOME1"] = LOBJ_Data;
    }
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

        UpdatePanelMLDFEEINCOME1.Update();
    }
    private void AddMLDFEEINCOME2Row()
    {
        MLDFEEINCOME2Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDFEEINCOME2();
        //新增一筆資料 
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();

        LOBJ_DataRow["SEQNO"] = "0";
        LOBJ_DataRow["UNIMNO"] = "";
        LOBJ_DataRow["TARGET"] = "";
        LOBJ_DataRow["FEEAMT"] = "0";
        LOBJ_DataRow["PAYTYPE"] = "";
        LOBJ_DataRow["CUSTTYPE"] = "";

        LOBJ_Data.Rows.Add(LOBJ_DataRow);
        ViewState["MLDFEEINCOME2"] = LOBJ_Data;
        MLDFEEINCOME2Bind();
    }
    private void DelMLDFEEINCOME2Row(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDFEEINCOME2();
        //刪除一筆資料   
        if (rptMLDFEEINCOME2.Items.Count > 0)
        {
            LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        }
        ViewState["MLDFEEINCOME2"] = LOBJ_Data;
        MLDFEEINCOME2Bind();
    }
    private DataTable updateMLDFEEINCOME2()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME2"];

        for (int i = 0; i < rptMLDFEEINCOME2.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["SEQNO"] = ((HiddenField)rptMLDFEEINCOME2.Items[i].FindControl("hdSEQNO")).Value;
            LOBJ_Data.Rows[i]["UNIMNO"] = ((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtUNIMNO")).Text;
            LOBJ_Data.Rows[i]["TARGET"] = ((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtTARGET")).Text;
            LOBJ_Data.Rows[i]["FEEAMT"] = ((TextBox)rptMLDFEEINCOME2.Items[i].FindControl("txtFEEAMT")).Text;
            LOBJ_Data.Rows[i]["PAYTYPE"] = ((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpPAYTYPE")).SelectedValue;
            LOBJ_Data.Rows[i]["CUSTTYPE"] = ((DropDownList)rptMLDFEEINCOME2.Items[i].FindControl("drpCUSTTYPE")).SelectedValue;
        }
        return LOBJ_Data;
    }
    private void MLDFEEINCOME2Init()
    {
        if (ViewState["MLDFEEINCOME2"] == null)
        {
            DataTable LOBJ_Data = new DataTable("MLDFEEINCOME2");
            LOBJ_Data.Columns.Add(new DataColumn("SEQNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("UNIMNO", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("TARGET", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("FEEAMT", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("PAYTYPE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CUSTTYPE", System.Type.GetType("System.String")));

            ViewState["MLDFEEINCOME2"] = LOBJ_Data;
        }
    }
    private void GetMLDFEEINCOME2Bind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ChangeMLDFEEINCOME2Type(LOBJ_Data);
            MLDFEEINCOME2Bind();
        }
        else
        {
            rptMLDFEEINCOME2.DataSource = LOBJ_Data;
            rptMLDFEEINCOME2.DataBind();
        }
    }
    private void ChangeMLDFEEINCOME2Type(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDFEEINCOME2"] = null;
        MLDFEEINCOME2Init();
        DataTable LOBJ_Data = (DataTable)ViewState["MLDFEEINCOME2"];
        for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
        {
            LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
        }
        ViewState["MLDFEEINCOME2"] = LOBJ_Data;
    }
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

        UpdatePanelMLDFEEINCOME2.Update();
    }
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

        UpdatePanelMLDPREPAYWOFF.Update();
    }
    private void MLDPREPAYWOFFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDPREPAYWOFF"];
        this.rptMLDPREPAYWOFF.DataSource = LOBJ_Data;
        this.rptMLDPREPAYWOFF.DataBind();
    }

    protected void btnPrePay_OnClick(object sender, EventArgs e)
    {
        string url;
        url = "funcRet=window.showModalDialog(";
        url += "'FrmSelectPrePay.aspx?CASEID=" + Server.UrlEncode(this.txtCASEID.Text.Trim()) +
            "&CNTRNO=" + Server.UrlEncode(this.txtCNTRNO.Text.Trim()) +
            "&PRENTSTDT=" + Server.UrlEncode(this.txtPRENTSTDT.Text.Trim()) +
            "&PAYDATE=" + Server.UrlEncode(this.txtPAYDATE.Text.Trim());
        //url += "')";
        url += "','','dialogHeight=300px;dialogWidth=800px;');";
        url += "$(\"" + this.btnQryPrePay.ClientID.ToString() + "\").click();";
        //url += "

        RegisterScript(url);
    }


    protected void btnQryPrePay_Click(object sender, EventArgs e)
    {
        ReturnObject<DataSet> LOBJ_ReturnObject = GetPrePayCount(this.txtCASEID.Text, this.txtCNTRNO.Text);
        if (LOBJ_ReturnObject.ReturnSuccess)
        {
            try
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                GetMLDPREPAYWOFFBind(LDST_Data.Tables[0]);

                Decimal LDBL_PREPAYWOFFAMT = 0;
                //整理沖預撥抵設備款
                for (int i = 0; i < rptMLDPREPAYWOFF.Items.Count; i++)
                {
                    LDBL_PREPAYWOFFAMT += Convert.ToDecimal(Itg.Community.Util.NumberToDb(((TextBox)rptMLDPREPAYWOFF.Items[i].FindControl("txtNOWPREPAYAMT")).Text.Replace(",", "")));
                }
                txtPREPAYWOFFAMT.Text = LDBL_PREPAYWOFFAMT.ToString();

                //重新計算實撥金額
                CalDISCOUNTTOTAL();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
        else
        {
            txtPREPAYWOFFAMT.Text = "0";
        }
    }

    private ReturnObject<DataSet> GetPrePayCount(string LSTR_CASEID, string LSTR_CNTRNO)
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
            LSTR_StoreProcedure.Append("SP_ML3001_Q16" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CNTRNO + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
}
