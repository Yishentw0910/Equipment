/********************************************************************************************************
* Database  : ML                                              
* 系    統  : 租賃設備                                          
* 程式名稱  : ML2001A                                         
* 程式功能  : 徵信案件查詢                                      
* 程式作者  :                                       
* 完成時間  : 
* 修改事項  : 
20120217 add BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
20120217 Add BY MAUREEN REASON:新增初審確認時間欄位
20120222 UPD BY MAUREEN REASON:初審確認日期預設值帶系統日
20120309 MODIFY BY MAUREEN REASON:不跑發送MAIL部分
20120309 MODIFY BY MAUREEN REASON:修改僅輸入「初審確認日」時，按下確認鈕後，要可以印報表
20120309 MODIFY BY MAUREEN REASON:修改alert訊息
Modify 20120312 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
20120605 ADD BY MAUREEN REASON:新增開窗選擇徵信建議(附條件or婉拒)
20120608 ADD BY MAUREEN REASON:新增開窗選擇退件原因(資料不齊or條件調整)
Modify 20120618 By SS Gordon. Reason: AR新增履約保證金
Modify 20120620 By SS Gordon. Reason: 徵信核准成功時，將案件資料另外儲存
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
Modify 20121128 By SS Gordon. Reason: 徵信核准成功時，將案件資料另外儲存。原本只有[4]，需將[4B],[4C]也加入
Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
Modify 20130107 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上不動產權利人明細欄位.
Modify 20130107 By SS Maureen. Reason: 不動產設定GRID匯出EXCEL.
Modify 20130108 By SS Maureen. Reason: 只有信管部的能看到徵信報告頁籤畫面中，不動產設定GRID 
Modify 20130117 By SS Adam. Reason: 增加對前案擔保品增加限制的顯示判斷.
Modify 20130131 By SS Maureen. Reason:名稱修改為不動產資料，並移除本案無不動產設定的選項
Modify 20130131 By SS Maureen. Reason:若業代無KEY-IN任何擔保條件的不動產資料，還是可維護(F8、F9)徵信頁簽的不動產抵押資料
Modify 2013709 By SS Chris Hung. Reason:新增案件心得按鍵功能
Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
Modify 20131008 BY    SEAN     Reason:已徵審完成的案件也可上傳徵信檔案
Modify 20131113 BY SS Leo Reason:增加進件條件擔保價值欄位
20140108 ADD BY SS ADAM Reason.增加覆核建議存檔
Modify 20140627 BY SS VICKY Reason:徵信報告頁籤隱藏簽核權限下拉選項，增加徵審人員，實貸金額權限，IRR權限
Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
Modify 20150708 By SS Edward Reason: 設備重車IRR權限調整
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
20160930 ADD BY SS ADAM REASON.增加放審會
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
using System.Globalization;
using System.Reflection;
using System.IO;
using Microsoft.Office.Interop;

using System.Web.UI.HtmlControls;
using Itg.Community;
using Comus;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic;

public partial class FrmML2001B : Itg.Community.PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    public string UploadURL = System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"];
    //20150629 ADD BY SS EDWARD.增加重車專案別
    public static DataTable devTypeTable;
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
            MLMCASE_Data.Add("drpPAYTPE", "PAYTPE");
            MLMCASE_Data.Add("txtPATDAYS", "PATDAYS");
            MLMCASE_Data.Add("txtSUPPILERDAYS", "SUPPILERDAYS");
            MLMCASE_Data.Add("txtIRR", "IRR");
            MLMCASE_Data.Add("txtRECOVERTEST", "RECOVERTEST");
            MLMCASE_Data.Add("txtCAPITALCOST", "CAPITALCOST");
            MLMCASE_Data.Add("txtNPV", "NPV");
            MLMCASE_Data.Add("txtNPV2", "NPV2");
            //Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
            MLMCASE_Data.Add("txtNPVRATECOST", "NPVRATECOST");
            MLMCASE_Data.Add("txtNPVRATECOST2", "NPVRATECOST2");
            MLMCASE_Data.Add("drpEXPIREPROC", "EXPIREPROC");
            MLMCASE_Data.Add("txtEXPIREPROCDESC", "EXPIREPROCDESC");

            MLMCASE_Data.Add("txtCREDITRECDT", "CREDITRECDT");
            MLMCASE_Data.Add("txtCREDITSENDDT", "CREDITSENDDT");
            MLMCASE_Data.Add("txtOTHERCOND", "OTHERCOND");
            MLMCASE_Data.Add("drpDEFECTIVE", "DEFECTIVE");
            MLMCASE_Data.Add("hidCASESTATUS", "CASESTATUS");

            MLMCASE_Data.Add("txtCREDITDT", "CREDITDT");
            MLMCASE_Data.Add("drpPROPOSEDSIGN", "PROPOSEDSIGN");

            //20120217 add BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
            MLMCASE_Data.Add("txtCREDITDTIME", "CREDITDTIME");        //徵信完成時間
            MLMCASE_Data.Add("txtFIRCREDITDT", "FIRCREDITDT");        //初審確認日期
            MLMCASE_Data.Add("txtFIRCREDITDTIME", "FIRCREDITDTIME");  //初審確認時間
            MLMCASE_Data.Add("drpSUGGEST", "CREDITSUGGEST");          //徵信建議

            MLMCASE_Data.Add("txtCREDITDESC", "CREDITDESC");
            //john.chen 2011/11/03 增加欄位
            MLMCASE_Data.Add("drpPRINTSTORE", "PRINTSTORE");

            //Leo 20131113 增加欄位
            MLMCASE_Data.Add("drpGuanValue", "GUANVALUE");

            //UPD BY VICKY 20140630 增加欄位
            MLMCASE_Data.Add("labCREDITER", "CREDITER");
            MLMCASE_Data.Add("drpACTUSLLOANSAUTH", "ACTUSLLOANSAUTH");
            MLMCASE_Data.Add("drpIRRAUTH", "IRRAUTH");
            MLMCASE_Data.Add("tab8_labCREDITER", "CREDITER2");
            MLMCASE_Data.Add("tab8_drpACTUSLLOANSAUTH", "ACTUSLLOANSAUTH2");
            MLMCASE_Data.Add("tab8_drpIRRAUTH", "IRRAUTH2");

            //Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
            MLMCASE_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");

            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            MLMCASE_Data.Add("drpPRODCD", "PRODCD");
            MLMCASE_Data.Add("drpPRODCD_TAB6", "PRODCD");
            MLMCASE_Data.Add("drpPRODCD_TAB8", "PRODCD");
            //20160930 ADD BY SS ADAM REASON.增加放審會
            MLMCASE_Data.Add("drpPRODCD_TAB9", "PRODCD");

            //Modify 20161130 By SEAN Reason:新增「NPV0」.「NPV0成本」隱藏欄位
            MLMCASE_Data.Add("txtNPV0", "NPV0");
            MLMCASE_Data.Add("txtNPVRATECOST0", "NPVRATECOST0");
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
            //MLMCUSTOMER_Data.Add("txtINDUID_TAB6", "INDUID");
            //MLMCUSTOMER_Data.Add("txtINDUNM_TAB6", "INDUNM");
            //MLMCUSTOMER_Data.Add("txtINDUID_TAB8", "INDUID");
            //MLMCUSTOMER_Data.Add("txtINDUNM_TAB8", "INDUNM");

            //20221207 行業別改下拉選單
            MLMCUSTOMER_Data.Add("DrpNDU", "CUROUT");
            MLMCUSTOMER_Data.Add("DrpNDU_TAB6", "CUROUT");
            MLMCUSTOMER_Data.Add("DrpNDU_TAB8", "CUROUT");

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
            MLDCASEARDATA_Data.Add("txtPERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("txtACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("drpPAYTIMEA", "PAYTIME");
            MLDCASEARDATA_Data.Add("txtBUYERLIMIT", "BUYERLIMIT");
            MLDCASEARDATA_Data.Add("txtIRR", "IRR");
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
            return MLDCASEINST_Data;
        }
    }

    private string[,] aryIRR1
    {
        get
        {
            string[,] ary = new string[5, 7];
            ary[1, 1] = "5.0%";
            ary[1, 2] = "5.0%";
            ary[1, 3] = "6.0%";
            ary[1, 4] = "5.0%";
            ary[1, 5] = "6.0%";
            ary[1, 6] = "8.0%";
            ary[2, 1] = "5.5%";
            ary[2, 2] = "5.5%";
            ary[2, 3] = "6.5%";
            ary[2, 4] = "5.5%";
            ary[2, 5] = "6.0%";
            ary[2, 6] = "8.5%";
            ary[3, 1] = "5.0%";
            ary[3, 2] = "5.0%";
            ary[3, 3] = "6.0%";
            ary[3, 4] = "5.0%";
            ary[3, 5] = "6.0%";
            ary[3, 6] = "8.0%";
            ary[4, 1] = "7.0%";
            ary[4, 2] = "7.0%";
            ary[4, 3] = "8.0%";
            ary[4, 4] = "7.0%";
            ary[4, 5] = "8.0%";
            ary[4, 6] = "10.0%";
            return ary;

        }
    }

    private string[,] aryIRR2
    {
        get
        {
            string[,] ary = new string[5, 7];
            ary[1, 1] = "6.0%";
            ary[1, 2] = "6.0%";
            ary[1, 3] = "7.0%";
            ary[1, 4] = "6.0%";
            ary[1, 5] = "7.0%";
            ary[1, 6] = "9.0%";
            ary[2, 1] = "6.5%";
            ary[2, 2] = "6.5%";
            ary[2, 3] = "7.5%";
            ary[2, 4] = "6.5%";
            ary[2, 5] = "7.5%"; //20150210 ADD BY SS ADAM REASON.打錯修正 7.0%=>7.5%
            ary[2, 6] = "9.5%";
            ary[3, 1] = "6.0%";
            ary[3, 2] = "6.0%";
            ary[3, 3] = "7.0%";
            ary[3, 4] = "6.0%";
            ary[3, 5] = "7.0%";
            ary[3, 6] = "9.0%";
            ary[4, 1] = "8.0%";
            ary[4, 2] = "8.0%";
            ary[4, 3] = "9.0%";
            ary[4, 4] = "8.0%";
            ary[4, 5] = "9.0%";
            ary[4, 6] = "11.0%";
            return ary;
        }
    }

    private string[,] aryIRR3
    {
        get
        {
            string[,] ary = new string[6, 5];
            ary[1, 1] = "11.0%";
            ary[1, 2] = "9.0%";
            ary[1, 3] = "8.0%";
            ary[1, 4] = "7.0%";
            ary[2, 1] = "11.0%";
            ary[2, 2] = "9.0%";
            ary[2, 3] = "8.0%";
            ary[2, 4] = "7.0%";
            ary[3, 1] = "13.0%";
            ary[3, 2] = "11.0%";
            ary[3, 3] = "10.0%";
            ary[3, 4] = "9.0%";
            ary[4, 1] = "12.0%";
            ary[4, 2] = "10.0%";
            ary[4, 3] = "9.0%";
            ary[4, 4] = "8.0%";
            ary[5, 1] = "13.0%";
            ary[5, 2] = "11.0%";
            ary[5, 3] = "10.0%";
            ary[5, 4] = "9.0%";
            return ary;
        }
    }

    private string[,] aryIRR4
    {
        get
        {
            string[,] ary = new string[6, 5];
            ary[1, 1] = "12.0%";
            ary[1, 2] = "10.0%";
            ary[1, 3] = "9.0%";
            ary[1, 4] = "8.0%";
            ary[2, 1] = "12.0%";
            ary[2, 2] = "10.0%";
            ary[2, 3] = "9.0%";
            ary[2, 4] = "8.0%";
            ary[3, 1] = "14.0%";
            ary[3, 2] = "12.0%";
            ary[3, 3] = "11.0%";
            ary[3, 4] = "10.0%";
            ary[4, 1] = "13.0%";
            ary[4, 2] = "11.0%";
            ary[4, 3] = "10.0%";
            ary[4, 4] = "9.0%";
            ary[5, 1] = "14.0%";
            ary[5, 2] = "12.0%";
            ary[5, 3] = "11.0%";
            ary[5, 4] = "10.0%";
            return ary;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //Modify 20130108 By SS Maureen. Reason: 只有信管部的能看到徵信報告頁籤畫面中，不動產設定GRID
        //Modify 20130117 By SS Adam. Reason: 增加系統管理人員可以看徵信報告
        //20140306 EDIT BY SEAN 徵審單位由信管部(AG00)-->信用審查部(AI00)
        //if (Session["DEPTID"].ToString() == "AG00" || Session["DEPTID"].ToString() == "AD00")
        //if (Session["DEPTID"].ToString() == "AI00" || Session["DEPTID"].ToString() == "AD00")
        if (GSTR_DEPTID == "AI00" || GSTR_DEPTID == "AD00")
        {
            Panel1.Visible = true;
            //Modify 20130117 By SS Adam. Reason: 增加對前案擔保品增加限制的顯示判斷.
            Panel2.Visible = true;
        }

        //Modify 20130709 By SS Chrus Hung. Reason: 增加對案件心得的按鍵判斷.
        //20140306 EDIT BY SEAN 徵審單位由信管部(AG00)-->信用審查部(AI00)
        //if (Session["DEPTID"].ToString() == "AG00" || Session["DEPTID"].ToString() == "AD00" || Session["DEPTID"].ToString() == "AB00")
        //if (Session["DEPTID"].ToString() == "AI00" || Session["DEPTID"].ToString() == "AD00" || Session["DEPTID"].ToString() == "AB00")
        if (GSTR_DEPTID == "AI00" || GSTR_DEPTID == "AD00" || GSTR_DEPTID == "AB00")
        {
            btnAuditNote.Enabled = true;
        }
        else
        {
            btnAuditNote.Enabled = false;
        }



        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "徵信核准";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML2001B";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML2001B";
        //========================             
        if (!Page.IsPostBack)
        {
            //rptContactInit();
            FormDrpBind();

            PageDataBind();
            //this.lnkDocCredit.OnClientClick = "OpenAttach('Download.aspx?docpath=" + "a.doc" + "');";

            //20131113 ADD BY LEO
            drpGuanValueBind();

            //UPD BY VICKY 20140627 實貸金額權限預設值
            if (this.drpACTUSLLOANSAUTH.SelectedValue.Trim() == "")
            {
                drpACTUSLLOANSAUTHDefault();
            }
            //UPD BY VICKY 20140630 覆核頁簽-實貸金額權限預設值
            if (this.tab8_drpACTUSLLOANSAUTH.SelectedValue.Trim() == "")
            {
                tab8_drpACTUSLLOANSAUTH.SelectedValue = this.drpACTUSLLOANSAUTH.SelectedValue;
            }

            //ADDED BY SS CHRIS HUNG 設定操作模式,設備類型下拉選單
            //txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + ddlOPERATION.SelectedItem.Text + ddlDEVICETYPE.SelectedItem.Text + "案件，IRR應為" + aryIRR1[int.Parse(ddlOPERATION.SelectedValue), int.Parse(ddlDEVICETYPE.SelectedValue)] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "由??簽核權限。";


            //20150722 ADD BY SS ADAM REASON.當專案別為非重車，設備類型移除重車項目
            if (drpPROJCD.SelectedValue != "02")
            {
                ddlDEVICETYPE.Items.Remove(ddlDEVICETYPE.Items.FindByValue("07"));
                ddlDEVICETYPE_R.Items.Remove(ddlDEVICETYPE_R.Items.FindByValue("07"));
                //20160930 ADD BY SS ADAM REASON.增加放審會
                ddlDEVICETYPE_TAB9.Items.Remove(ddlDEVICETYPE_TAB9.Items.FindByValue("07"));
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window_onload();showTag();", true);

    }
    private void PageDataBind()
    {
        string LSTR_CUSTID = Request.QueryString["custid"].ToString();
        string LSTR_CASEID = Request.QueryString["caseid"].ToString();
        string LSTR_Con = Request.QueryString["con"].ToString();

        this.hidCond.Value = LSTR_Con;
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
                    string s = "";
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME"].ToString() != "" && LDST_Data.Tables[2].Rows[0]["FILEID"].ToString() != "")
                    {
                        //案件下載
                        this.lkbOpenFile.Text = LDST_Data.Tables[2].Rows[0]["FILENAME"].ToString().Trim();
                        this.lkbOpenFile.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "');return false;";
                        //this.btnOnload.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "');return false;";
                        s += "window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "','_blank');";
                    }
                    else
                    {
                        this.lblOpenFile.Text = "營業單位無報告！";
                    }
                    //20170104 ADD BY SS ADAM REASON.案件下載改為四個
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME2"].ToString() != "" && LDST_Data.Tables[2].Rows[0]["FILEID2"].ToString() != "")
                    {
                        s += "window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID2"].ToString().Trim() + "','_blank');";
                    }

                    if (LDST_Data.Tables[2].Rows[0]["FILENAME3"].ToString() != "" && LDST_Data.Tables[2].Rows[0]["FILEID3"].ToString() != "")
                    {
                        s += "window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID3"].ToString().Trim() + "','_blank');";
                    }

                    if (LDST_Data.Tables[2].Rows[0]["FILENAME4"].ToString() != "" && LDST_Data.Tables[2].Rows[0]["FILEID4"].ToString() != "")
                    {
                        s += "window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID4"].ToString().Trim() + "','_blank');";
                    }
                    s += "return false;";
                    this.btnOnload.OnClientClick = s;
                    //Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
                    drpPROJCD.SelectedValue = LDST_Data.Tables[2].Rows[0]["PROJCD"].ToString().Trim();

                    //20150629 ADD BY SS EDWARD.增加重車專案別
                    if (drpPROJCD.SelectedValue == "02")      //重車 20150629
                    {
                        chkGRTCAR.Checked = true;
                        chkGRTCAR_R.Checked = true;
                        this.ddlDEVICETYPE.DataSource = devTypeTable;
                        this.ddlDEVICETYPE_R.DataSource = devTypeTable;
                        this.ddlDEVICETYPE.DataBind();
                        this.ddlDEVICETYPE_R.DataBind();

                        if (ddlDEVICETYPE.Items.FindByValue("07") != null)
                            ddlDEVICETYPE.SelectedValue = "07";

                        if (ddlDEVICETYPE_R.Items.FindByValue("07") != null)
                            ddlDEVICETYPE_R.SelectedValue = "07";
                        //ddlDEVICETYPE.SelectedItem.Text = "重車";
                        //ddlDEVICETYPE_R.SelectedItem.Text = "重車";

                        //20160930 ADD BY SS ADAM REASON.增加放審會
                        this.ddlDEVICETYPE_TAB9.DataSource = devTypeTable;
                        this.ddlDEVICETYPE_TAB9.DataBind();

                        if (ddlDEVICETYPE_TAB9.Items.FindByValue("07") != null)
                            ddlDEVICETYPE_TAB9.SelectedValue = "07";
                    }

                    //Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
                    txtADVANCESINTEREST.Text = LDST_Data.Tables[2].Rows[0]["ADVANCESINTEREST"].ToString().Trim();

                    if (LSTR_MAINTYPEID == "04")
                    {
                        rdoMLDCASEARDATA.Checked = true;
                        rdoMLDCASEINST.Checked = false;
                        this.chkAr.Checked = true;
                        //綁定應收帳款案件
                        GetMLDCASEARDATABind(LDST_Data.Tables[3]);
                        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
                        this.chkBANK1.Checked = false;
                    }
                    else
                    {
                        rdoMLDCASEARDATA.Checked = false;
                        rdoMLDCASEINST.Checked = true;
                        this.chkAr.Checked = false;
                        //Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
                        this.chkBANK1.Checked = false;
                        if (this.drpSOURCETYPE.SelectedValue == "02")
                        {
                            this.chkBANK1.Checked = true;
                        }
                        //綁定分期租賃案件
                        GetMLDCASEINSTBind(LDST_Data.Tables[4]);
                        GetMLDCASEINSTDBind(LDST_Data.Tables[5]);
                    }
                    //征審資料
                    GetMLDCASEAPPENDDOCBind(LDST_Data.Tables[6]);
                    //標的物
                    GetMLDCASETARGETBind(LDST_Data.Tables[7]);
                    //MLDCASEGUARANTEE保證人
                    GetMLDCASEGUARANTEEBind(LDST_Data.Tables[8]);
                    //動產設定
                    GetMLDCASEMOVABLEBind(LDST_Data.Tables[9]);
                    //不動產設定
                    GetMLDCASEIMMOVABLEBind(LDST_Data.Tables[10]);
                    //不定存單質押
                    GetMLDCASEADEPOSITBind(LDST_Data.Tables[11]);
                    //客票
                    GetMLDCASEBILLNOTEBind(LDST_Data.Tables[12]);
                    //股票
                    GetMLDCASESTOCKBind(LDST_Data.Tables[13]);

                    //Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
                    GetMLDIMMOVABLEDFBind(LDST_Data.Tables[14]);

                    //Modify 20131025 Reason: 增加覆核報告頁籤
                    GetReviewReportBind(LDST_Data.Tables[15]);

                    //Modify 20140808 Reason: 增加結論登記區塊
                    getConclusionBind(LDST_Data.Tables[16]);
                    getConclusionBind_R(LDST_Data.Tables[17]);


                    //20160930 ADD BY SS ADAM REASON.增加放審會
                    GetExamineReport(LDST_Data.Tables[18]);
                    getConclusionBind_TAB9(LDST_Data.Tables[19]);

                    this.txtBUSINESS.Width = 500;
                    if (this.hidCASESTATUS.Value == "3")
                    {
                        this.btnCond.Enabled = true;
                        this.btnSaveSure.Enabled = true;
                        //this.btnSaveTemp.Enabled = true;
                        //this.btnSubmit.Enabled = true;
                        //this.btnRegect.Enabled = true;
                        //this.btnWj.Enabled = true;
                        //this.btnSelect.Enabled = true;

                        this.txtCREDITDT.Enabled = true;
                        this.drpPROPOSEDSIGN.Enabled = true;

                        //20120217 add BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
                        this.txtCREDITDTIME.Enabled = true;     //徵信完成日期時間
                        this.txtFIRCREDITDT.Enabled = true;     //初審確認日期
                        this.txtFIRCREDITDTIME.Enabled = true;  //初審確認日期時間
                        this.drpSUGGEST.Enabled = true;         //徵信建議

                        this.txtCREDITDESC.Enabled = true;
                        this.btnCREDITFILEID.Enabled = true;
                        this.btnLackComment.Enabled = true;
                        this.cmdPrintReportB.Enabled = false;
                        //20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內
                        this.cmdPrintReportC.Enabled = false;

                        //if (this.txtCREDITDT.Text == "")
                        //{
                        //  this.txtCREDITDT.Text = Itg.Community.Util.GetADYear(GSTR_U_SYSDT);
                        //}

                        //20120222 UPD BY MAUREEN REASON:初審確認日期預設值帶系統日  
                        if (this.txtFIRCREDITDT.Text == "")
                        {
                            this.txtFIRCREDITDT.Text = Itg.Community.Util.GetADYear(GSTR_U_SYSDT);
                        }

                        //20120217 Add BY MAUREEN REASON:新增初審確認時間欄位
                        if (this.txtFIRCREDITDTIME.Text == "")
                        {
                            this.txtFIRCREDITDTIME.Text = DateTime.Now.ToString("HH:mm");
                        }

                        //20140704 ADD BY SS ADAM REASON.新增實貸金額權限
                        this.drpACTUSLLOANSAUTH.Enabled = true;
                        this.drpIRRAUTH.Enabled = true;

                        //20160324 ADD BY SS ADAM REASON.增加行業別跟案件產品別
                        this.txtINDUNM_TAB6.Enabled = false;
                    }
                    else if (this.hidCASESTATUS.Value == "6")
                    {
                    }
                    else if (this.hidCASESTATUS.Value == "7" || this.hidCASESTATUS.Value == "8")
                    {
                    }
                    else
                    {
                        this.btnCond.Enabled = false;
                        this.btnSaveSure.Enabled = false;
                        //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                        this.btnReturnChk.Enabled = false;
                        //this.btnSaveTemp.Enabled = false;
                        //this.btnSubmit.Enabled = false;
                        //this.btnRegect.Enabled = false;
                        //this.btnWj.Enabled = false;
                        //this.btnSelect.Enabled = false;

                        this.txtCREDITDT.Enabled = false;
                        this.drpPROPOSEDSIGN.Enabled = false;

                        //20120217 add BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
                        this.txtCREDITDTIME.Enabled = false;     //徵信完成日期時間
                        this.txtFIRCREDITDT.Enabled = false;     //初審確認日期
                        this.txtFIRCREDITDTIME.Enabled = false;  //初審確認日期時間
                        this.drpSUGGEST.Enabled = false;         //徵信建議

                        this.txtCREDITDESC.Enabled = false;
                        //20131008 Edit by SEAN 已徵審完成的案件也可上傳徵信檔案
                        //this.btnCREDITFILEID.Enabled = false;
                        //
                        this.btnLackComment.Enabled = false;
                        this.cmdPrintReportB.Enabled = true;
                        //20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內
                        //this.cmdPrintReportC.Enabled = true;

                        //20140704 ADD BY SS ADAM REASON.新增實貸金額權限
                        this.drpACTUSLLOANSAUTH.Enabled = false;
                        this.drpIRRAUTH.Enabled = false;

                        //20141218 ADD BY SS ADAM REASON.初審結束後不可以修改初審結論
                        this.txtCREDITAMT.Enabled = false;
                        this.txtCONTRACTMON.Enabled = false;
                        this.txtPERBOND2.Enabled = false;
                        this.chkGRTMV.Enabled = false;
                        this.chkGRTIMV.Enabled = false;
                        this.chkGRTDEPOSIT.Enabled = false;
                        this.chkGRTBILLNOTE.Enabled = false;
                        this.chkGRTSTOCK.Enabled = false;
                        this.chkGRTCAR.Enabled = false;
                        this.txtGRTBAL.Enabled = false;
                        this.txtGRTVAL.Enabled = false;
                        this.ddlFUNDSUSE.Enabled = false;
                        this.ddlECONDITION.Enabled = false;
                        this.ddlOPERATION.Enabled = false;
                        this.ddlDEVICETYPE.Enabled = false;
                        this.txtDEDUCTION.Enabled = false;
                        //rptMLDIMMOVABLEDF
                        this.txtGRTITEM.Enabled = false;
                        this.txtOTHERCONDITION.Enabled = false;
                        this.txtSIGNMEMO.Enabled = false;

                        //20160324 ADD BY SS ADAM REASON.增加行業別跟案件產品別
                        this.txtINDUNM_TAB6.Enabled = false;
                        this.txtINDUID_TAB6.Enabled = false;
                        this.drpPRODCD_TAB6.Enabled = false;
                        this.DrpNDU_TAB6.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {

                Alert(ex.Message);
            }
        }
    }

    private void getConclusionBind(DataTable LOBJ_Data)
    {
        //UPD BY CHRIS HUNG 20140808 增加結論登記區塊欄位
        if (LOBJ_Data.Rows.Count <= 0) return;
        txtCREDITAMT.Text = LOBJ_Data.Rows[0]["CREDITAMT"].ToString();
        txtCONTRACTMON.Text = LOBJ_Data.Rows[0]["CONTRACTMON"].ToString();
        txtPERBOND2.Text = LOBJ_Data.Rows[0]["PERBOND"].ToString();
        txtGRTBAL.Text = LOBJ_Data.Rows[0]["GRTBAL"].ToString();
        txtGRTVAL.Text = LOBJ_Data.Rows[0]["GRTVAL"].ToString();
        txtDEDUCTION.Text = LOBJ_Data.Rows[0]["DEDUCTION"].ToString();
        txtGRTITEM.Text = LOBJ_Data.Rows[0]["GRTITEM"].ToString().Replace("<br>", "\r\n");
        txtOTHERCONDITION.Text = LOBJ_Data.Rows[0]["OTHERCONDIT"].ToString().Replace("<br>", "\r\n");
        txtSIGNMEMO.Text = LOBJ_Data.Rows[0]["PROPOSEDSIGNMEMO"].ToString();

        ddlFUNDSUSE.SelectedValue = LOBJ_Data.Rows[0]["FUNDSUSE"].ToString();
        ddlFUNDSUSE_SelectedIndexChanged(ddlFUNDSUSE, null);
        ddlECONDITION.SelectedValue = LOBJ_Data.Rows[0]["DEVICECONDITION"].ToString();
        ddlOPERATION.SelectedValue = LOBJ_Data.Rows[0]["OPERATION"].ToString();
        ddlDEVICETYPE.SelectedValue = LOBJ_Data.Rows[0]["DEVICETYPE"].ToString();
        if (LOBJ_Data.Rows[0]["GRTMV"].ToString().Trim() == "Y")
            chkGRTMV.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTIMV"].ToString().Trim() == "Y")
            chkGRTIMV.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTDEPOSIT"].ToString().Trim() == "Y")
            chkGRTDEPOSIT.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTBILLNOTE"].ToString().Trim() == "Y")
            chkGRTBILLNOTE.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTSTOCK"].ToString().Trim() == "Y")
            chkGRTSTOCK.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTCAR"].ToString().Trim() == "Y")
            chkGRTCAR.Checked = true;

        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE.SelectedValue == "02" && ddlOPERATION.SelectedValue != "01")
        {
            ddlECONDITION.Enabled = false;
            ddlDEVICETYPE.Enabled = false;
        }

    }
    private void getConclusionBind_R(DataTable LOBJ_Data)
    {
        //UPD BY CHRIS HUNG 20140808 增加結論登記區塊欄位
        if (LOBJ_Data.Rows.Count <= 0) return;
        txtCREDITAMT_R.Text = LOBJ_Data.Rows[0]["CREDITAMT"].ToString();
        txtCONTRACTMON_R.Text = LOBJ_Data.Rows[0]["CONTRACTMON"].ToString();
        txtPERBOND_R.Text = LOBJ_Data.Rows[0]["PERBOND"].ToString();
        txtGRTBAL_R.Text = LOBJ_Data.Rows[0]["GRTBAL"].ToString();
        txtGRTVAL_R.Text = LOBJ_Data.Rows[0]["GRTVAL"].ToString();
        txtDEDUCTION_R.Text = LOBJ_Data.Rows[0]["DEDUCTION"].ToString();
        txtGRTITEM_R.Text = LOBJ_Data.Rows[0]["GRTITEM"].ToString().Replace("<br>", "\r\n");
        txtOTHERCONDITION_R.Text = LOBJ_Data.Rows[0]["OTHERCONDIT"].ToString().Replace("<br>", "\r\n");
        txtSIGNMEMO_R.Text = LOBJ_Data.Rows[0]["PROPOSEDSIGNMEMO"].ToString();

        ddlFUNDSUSE_R.SelectedValue = LOBJ_Data.Rows[0]["FUNDSUSE"].ToString();
        ddlFUNDSUSE_SelectedIndexChanged(ddlFUNDSUSE_R, null);
        ddlCONDITION_R.SelectedValue = LOBJ_Data.Rows[0]["DEVICECONDITION"].ToString();
        ddlOPERATION_R.SelectedValue = LOBJ_Data.Rows[0]["OPERATION"].ToString();
        ddlDEVICETYPE_R.SelectedValue = LOBJ_Data.Rows[0]["DEVICETYPE"].ToString();
        if (LOBJ_Data.Rows[0]["GRTMV"].ToString().Trim() == "Y")
            chkGRTMV_R.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTIMV"].ToString().Trim() == "Y")
            chkGRTIMV_R.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTDEPOSIT"].ToString().Trim() == "Y")
            chkGRTDEPOSIT_R.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTBILLNOTE"].ToString().Trim() == "Y")
            chkGRTBILLNOTE_R.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTSTOCK"].ToString().Trim() == "Y")
            chkGRTSTOCK_R.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTCAR"].ToString().Trim() == "Y")
            chkGRTCAR_R.Checked = true;

        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE_R.SelectedValue == "02" && ddlOPERATION_R.SelectedValue != "01")
        {
            ddlCONDITION_R.Enabled = false;
            ddlDEVICETYPE_R.Enabled = false;
        }

    }
    //20160930 ADD BY SS ADAM REASON.增加放審會
    private void getConclusionBind_TAB9(DataTable LOBJ_Data)
    {
        //UPD BY CHRIS HUNG 20140808 增加結論登記區塊欄位
        if (LOBJ_Data.Rows.Count <= 0) return;
        txtCREDITAMT_TAB9.Text = LOBJ_Data.Rows[0]["CREDITAMT"].ToString();
        txtCONTRACTMON_TAB9.Text = LOBJ_Data.Rows[0]["CONTRACTMON"].ToString();
        txtPERBOND_TAB9.Text = LOBJ_Data.Rows[0]["PERBOND"].ToString();
        txtGRTBAL_TAB9.Text = LOBJ_Data.Rows[0]["GRTBAL"].ToString();
        txtGRTVAL_TAB9.Text = LOBJ_Data.Rows[0]["GRTVAL"].ToString();
        txtDEDUCTION_TAB9.Text = LOBJ_Data.Rows[0]["DEDUCTION"].ToString();
        txtGRTITEM_TAB9.Text = LOBJ_Data.Rows[0]["GRTITEM"].ToString().Replace("<br>", "\r\n");
        txtOTHERCONDITION_TAB9.Text = LOBJ_Data.Rows[0]["OTHERCONDIT"].ToString().Replace("<br>", "\r\n");
        txtSIGNMEMO_TAB9.Text = LOBJ_Data.Rows[0]["PROPOSEDSIGNMEMO"].ToString();

        ddlFUNDSUSE_TAB9.SelectedValue = LOBJ_Data.Rows[0]["FUNDSUSE"].ToString();
        ddlFUNDSUSE_SelectedIndexChanged(ddlFUNDSUSE_TAB9, null);
        ddlCONDITION_TAB9.SelectedValue = LOBJ_Data.Rows[0]["DEVICECONDITION"].ToString();
        ddlOPERATION_TAB9.SelectedValue = LOBJ_Data.Rows[0]["OPERATION"].ToString();
        ddlDEVICETYPE_TAB9.SelectedValue = LOBJ_Data.Rows[0]["DEVICETYPE"].ToString();
        if (LOBJ_Data.Rows[0]["GRTMV"].ToString().Trim() == "Y")
            chkGRTMV_TAB9.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTIMV"].ToString().Trim() == "Y")
            chkGRTIMV_TAB9.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTDEPOSIT"].ToString().Trim() == "Y")
            chkGRTDEPOSIT_TAB9.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTBILLNOTE"].ToString().Trim() == "Y")
            chkGRTBILLNOTE_TAB9.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTSTOCK"].ToString().Trim() == "Y")
            chkGRTSTOCK_TAB9.Checked = true;
        if (LOBJ_Data.Rows[0]["GRTCAR"].ToString().Trim() == "Y")
            chkGRTCAR_TAB9.Checked = true;

        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE_TAB9.SelectedValue == "02" && ddlOPERATION_TAB9.SelectedValue != "01")
        {
            ddlCONDITION_TAB9.Enabled = false;
            ddlDEVICETYPE_TAB9.Enabled = false;
        }

    }
    /// <summary>
    /// 增加覆核報告頁籤
    /// </summary>
    /// <param name="dataTable"></param>
    private void GetReviewReportBind(DataTable dataTable)
    {
        if (dataTable.Rows.Count > 0)
        {

            //覆核確認
            if (dataTable.Rows[0]["CREDITCNFDT"].ToString() != "")
            {
                DateTime CREDITCNFDT = Convert.ToDateTime(dataTable.Rows[0]["CREDITCNFDT"]);
                if (CREDITCNFDT.ToString("yyyy") != "1900")
                {
                    tab8_tbxCREDITCNFDT_YMD.Text = CREDITCNFDT.ToString("yyyy/MM/dd");
                    tab8_tbxCREDITCNFDT_HS.Text = CREDITCNFDT.ToString("HH:mm");
                }
            }
            //覆核完成
            if (dataTable.Rows[0]["CREDITFINDT"].ToString() != "")
            {
                DateTime CREDITFINDT = Convert.ToDateTime(dataTable.Rows[0]["CREDITFINDT"]);
                if (CREDITFINDT.ToString("yyyy") != "1900")
                {
                    tab8_tbxCREDITFINDT_YMD.Text = CREDITFINDT.ToString("yyyy/MM/dd");
                    tab8_tbxCREDITFINDT_HS.Text = CREDITFINDT.ToString("HH:mm");
                }
            }

            if (dataTable.Rows[0]["CREDITSNDDT"].ToString() != "")
            {
                DateTime CREDITSNDDT = Convert.ToDateTime(dataTable.Rows[0]["CREDITSNDDT"]);
                if (CREDITSNDDT.ToString("yyyy") != "1900")
                    tab8_tbxCREDITSNDDT.Text = CREDITSNDDT.ToString("yyyy/MM/dd");

            }

            if (dataTable.Rows[0]["CREDITRCVDT"].ToString() != "")
            {
                DateTime CREDITRCVDT = Convert.ToDateTime(dataTable.Rows[0]["CREDITRCVDT"]);
                if (CREDITRCVDT.ToString("yyyy") != "1900")
                    tab8_tbxCREDITRCVDT.Text = CREDITRCVDT.ToString("yyyy/MM/dd");
            }
            /*




            tab8_tbxCREDITCNFDT_YMD.Text = CREDITCNFDT.ToString("yyyy/MM/dd");
            tab8_tbxCREDITCNFDT_HS.Text = CREDITCNFDT.ToString("HH:mm");
            tab8_tbxCREDITFINDT_YMD.Text = CREDITFINDT.ToString("yyyy/MM/dd");
            tab8_tbxCREDITFINDT_HS.Text = CREDITFINDT.ToString("HH:mm");
            tab8_tbxCREDITSNDDT.Text = CREDITSNDDT.ToString("yyyy/MM/dd");
            tab8_tbxCREDITRCVDT.Text = CREDITRCVDT.ToString("yyyy/MM/dd");
            */
            tab8_ddlPROPOSEDSIGN.Text = dataTable.Rows[0]["PROPOSEDSIGN"].ToString().Trim();
            tab8_ddlCREDITSUGGEST.Text = dataTable.Rows[0]["CREDITSUGGEST"].ToString().Trim();
            tab8_CREDITSALESDESC.Text = dataTable.Rows[0]["CREDITSALESDESC"].ToString().Trim().Replace("<br>", "\r\n");
            tab8_CREDITDESC.Text = dataTable.Rows[0]["CREDITDESC"].ToString().Trim().Replace("<br>", "\r\n");

        }
        tab8_tbxCREDITCNFDT_YMD.Enabled
            = tab8_tbxCREDITCNFDT_HS.Enabled
            = tab8_tbxCREDITFINDT_YMD.Enabled
            = tab8_tbxCREDITFINDT_HS.Enabled
            = tab8_tbxCREDITSNDDT.Enabled
            = tab8_tbxCREDITRCVDT.Enabled
            = tab8_ddlPROPOSEDSIGN.Enabled
            = tab8_ddlCREDITSUGGEST.Enabled
            = tab8_CREDITSALESDESC.Enabled
            = tab8_CREDITDESC.Enabled
            //20141218 ADD BY SS ADAM REASON.增加覆核結論區塊
            = txtCREDITAMT_R.Enabled
            = txtCONTRACTMON_R.Enabled
            = txtPERBOND_R.Enabled
            = chkGRTMV_R.Enabled
            = chkGRTIMV_R.Enabled
            = chkGRTDEPOSIT_R.Enabled
            = chkGRTBILLNOTE_R.Enabled
            = chkGRTSTOCK_R.Enabled
            = chkGRTCAR_R.Enabled
            = txtGRTBAL_R.Enabled
            = txtGRTVAL_R.Enabled
            = ddlFUNDSUSE_R.Enabled
            = ddlCONDITION_R.Enabled
            = ddlOPERATION_R.Enabled
            = ddlDEVICETYPE_R.Enabled
            = txtDEDUCTION_R.Enabled
            = txtGRTITEM_R.Enabled
            = txtOTHERCONDITION_R.Enabled
            = txtSIGNMEMO_R.Enabled
            = btnSaveSureTab8.Enabled
            = cmdPrintReportC.Enabled
            = tab8_drpACTUSLLOANSAUTH.Enabled
            = tab8_drpIRRAUTH.Enabled
            //20130323 ADD BY SS ADAM REASON.新增行業別，案件產品別
            = txtINDUID_TAB8.Enabled
            = btnINDUPAGE_TAB8.Enabled
            = drpPRODCD_TAB8.Enabled
            //20221207 行業別改下拉選單
            = DrpNDU_TAB8.Enabled

            = (dataTable.Rows.Count > 0);

        txtINDUNM_TAB8.Enabled = false;
    }
    //20160930 ADD BY SS ADAM REASON.增加放審會
    /// <summary>
    /// 增加放審會報告頁籤
    /// </summary>
    /// <param name="dataTable"></param>
    private void GetExamineReport(DataTable dataTable)
    {
        if (dataTable.Rows.Count > 0)
        {
            if (dataTable.Rows[0]["CREDITER"].ToString().Trim() == "")
            {
                this.tab9_labCREDITER_ID.Text = Session["USERID"].ToString();
            }
            else
            {
                this.tab9_labCREDITER_ID.Text = dataTable.Rows[0]["CREDITER"].ToString();
            }
            tab9_txtCNFDT.Text = dataTable.Rows[0]["CNFDT"].ToString().Trim();
            tab9_txtFINDT.Text = dataTable.Rows[0]["FINDT"].ToString().Trim();
            tab9_drpACTUSLLOANSAUTH.SelectedValue = dataTable.Rows[0]["ACTUSLLOANSAUTH"].ToString();
            tab9_drpIRRAUTH.SelectedValue = dataTable.Rows[0]["IRRAUTH"].ToString();
            tab9_ddlPROPOSEDSIGN.SelectedValue = dataTable.Rows[0]["CREDITER"].ToString().Trim();
            tab9_ddlCREDITSUGGEST.Text = dataTable.Rows[0]["CREDITSUGGEST"].ToString().Trim();
            tab9_ddlCREDITSUGGEST2.Text = dataTable.Rows[0]["CREDITSUGGEST2"].ToString().Trim();
            tab9_txtSUGGESTDT.Text = dataTable.Rows[0]["SUGGESTDT"].ToString();
            tab9_txtEVALUATE.Text = dataTable.Rows[0]["EVALUATE"].ToString();
            tab9_txtSUGGESTDESC.Text = dataTable.Rows[0]["SUGGESTDESC"].ToString();
            tab9_txtFINDESC.Text = dataTable.Rows[0]["FINDESC"].ToString();

            hdTAB9FILEPATH1.Value = dataTable.Rows[0]["FILEPATH1"].ToString();
            hdTAB9FILEPATH2.Value = dataTable.Rows[0]["FILEPATH2"].ToString();
            hdTAB9FILEPATH3.Value = dataTable.Rows[0]["FILEPATH3"].ToString();
            hdTAB9FILEPATH4.Value = dataTable.Rows[0]["FILEPATH4"].ToString();
        }

        tab9_ddlPROPOSEDSIGN.Enabled
            = tab9_txtCNFDT.Enabled
            = tab9_txtFINDT.Enabled
            = tab9_drpACTUSLLOANSAUTH.Enabled
            = tab9_drpIRRAUTH.Enabled
            = tab9_ddlCREDITSUGGEST.Enabled
            = tab9_ddlCREDITSUGGEST2.Enabled
            = tab9_txtSUGGESTDT.Enabled
            = tab9_txtFINDESC.Enabled
            = tab9_txtEVALUATE.Enabled
            = tab9_txtSUGGESTDESC.Enabled

            = txtCREDITAMT_TAB9.Enabled
            = txtCONTRACTMON_TAB9.Enabled
            = txtPERBOND_TAB9.Enabled
            = chkGRTMV_TAB9.Enabled
            = chkGRTIMV_TAB9.Enabled
            = chkGRTDEPOSIT_TAB9.Enabled
            = chkGRTBILLNOTE_TAB9.Enabled
            = chkGRTSTOCK_TAB9.Enabled
            = chkGRTCAR_TAB9.Enabled
            = txtGRTBAL_TAB9.Enabled
            = txtGRTVAL_TAB9.Enabled
            = ddlFUNDSUSE_TAB9.Enabled
            = ddlCONDITION_TAB9.Enabled
            = ddlOPERATION_TAB9.Enabled
            = ddlDEVICETYPE_TAB9.Enabled
            = txtDEDUCTION_TAB9.Enabled
            = txtGRTITEM_TAB9.Enabled
            = txtOTHERCONDITION_TAB9.Enabled
            = txtSIGNMEMO_TAB9.Enabled
            = btnSaveSureTab9.Enabled
            //= cmdPrintReportC.Enabled
            = tab9_drpACTUSLLOANSAUTH.Enabled
            = tab9_drpIRRAUTH.Enabled

            = txtINDUID_TAB9.Enabled
            = btnINDUPAGE_TAB9.Enabled
            = drpPRODCD_TAB9.Enabled
            //20221207 行業別改下拉選單
            =DrpNDU_TAB9.Enabled
            = (dataTable.Rows.Count > 0);
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

    //Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
    private void GetMLDIMMOVABLEDFBind(DataTable LOBJ_DataTemp)
    {
        ViewState["MLDIMMOVABLEDF"] = null;
        MLDIMMOVABLEDF_Init();
        if (LOBJ_DataTemp.Rows.Count > 0)
        {
            MLDIMMOVABLEDF_Init();
            DataTable LOBJ_Data = (DataTable)ViewState["MLDIMMOVABLEDF"];
            for (int i = 0; i < LOBJ_DataTemp.Rows.Count; i++)
            {
                LOBJ_Data.ImportRow(LOBJ_DataTemp.Rows[i]);
            }

            ViewState["MLDIMMOVABLEDF"] = LOBJ_Data;
            MLDIMMOVABLEDFBind();
        }
        else
        {
            //Modify 20130131 By SS Maureen. Reason:名稱修改為不動產資料，並移除本案無不動產設定的選項
            //chkMLDIMMOVABLEDF.Checked = true;
            rptMLDIMMOVABLEDF.DataSource = LOBJ_DataTemp;
            rptMLDIMMOVABLEDF.DataBind();

            //Modify 20130131 By SS Maureen. Reason:若業代無KEY-IN任何擔保條件的不動產資料，還是可維護(F8、F9)徵信頁簽的不動產抵押資料
            //this.btnSaveImmov.Enabled = false;
            //this.btnExcelImmov.Enabled = false;

        }
    }

    //Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
    private void MLDIMMOVABLEDFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDIMMOVABLEDF"];
        this.rptMLDIMMOVABLEDF.DataSource = LOBJ_Data;
        this.rptMLDIMMOVABLEDF.DataBind();

        //綁定下拉
        for (int i = 0; i < rptMLDIMMOVABLEDF.Items.Count; i++)
        {

            ((DropDownList)rptMLDIMMOVABLEDF.Items[i].FindControl("drpIMMOVABLECASEPAWN_D")).SelectedValue = LOBJ_Data.Rows[i]["IMMOVABLECASEPAWN"].ToString();

        }

        this.rptMLDHUMANRIGHTS_D.DataSource = LOBJ_Data;
        this.rptMLDHUMANRIGHTS_D.DataBind();

        //綁定下拉
        for (int i = 0; i < rptMLDHUMANRIGHTS_D.Items.Count; i++)
        {
            DropDownList LOBJ_Drop = (DropDownList)rptMLDHUMANRIGHTS_D.Items[i].FindControl("drpMLDCASEIMMOVABLE_D");
            for (int j = 0; j < rptMLDHUMANRIGHTS_D.Items.Count; j++)
            {
                LOBJ_Drop.Items.Add(new ListItem((j + 1).ToString()));
            }
            LOBJ_Drop.SelectedIndex = i;
            LOBJ_Drop = null;
        }
    }

    //Modify 20130107 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上不動產權利人明細欄位.
    protected void droIMMOVABLEID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList LOBJ_Drp = (DropDownList)sender;
        RepeaterItem RItem;
        RItem = (RepeaterItem)LOBJ_Drp.Parent;
        int LINT_SelRow = RItem.ItemIndex;
        int LINT_TagRow = Convert.ToInt32(LOBJ_Drp.SelectedValue) - 1;

        this.hidShowTag.Value = "fraTab66Caption";
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDIMMOVABLEDF();
        //首先將目標行的資料轉移
        DataRow LDRW_Tmep = LOBJ_Data.NewRow();
        LDRW_Tmep["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_TagRow].FindControl("txtHUMANRIGHTS_D")).Text;
        LDRW_Tmep["REGISTDATE"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_TagRow].FindControl("txtREGISTDATE_D")).Text;
        LDRW_Tmep["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_TagRow].FindControl("txtSETPRICE_D")).Text;
        LDRW_Tmep["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_TagRow].FindControl("txtCREDITOR_D")).Text;
        //
        LOBJ_Data.Rows[LINT_TagRow]["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_SelRow].FindControl("txtHUMANRIGHTS_D")).Text;
        LOBJ_Data.Rows[LINT_TagRow]["REGISTDATE"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_SelRow].FindControl("txtREGISTDATE_D")).Text;
        LOBJ_Data.Rows[LINT_TagRow]["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_SelRow].FindControl("txtSETPRICE_D")).Text;
        LOBJ_Data.Rows[LINT_TagRow]["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[LINT_SelRow].FindControl("txtCREDITOR_D")).Text;
        //
        LOBJ_Data.Rows[LINT_SelRow]["HUMANRIGHTS"] = LDRW_Tmep["HUMANRIGHTS"];
        LOBJ_Data.Rows[LINT_SelRow]["REGISTDATE"] = LDRW_Tmep["REGISTDATE"];
        LOBJ_Data.Rows[LINT_SelRow]["SETPRICE"] = LDRW_Tmep["SETPRICE"];
        LOBJ_Data.Rows[LINT_SelRow]["CREDITOR"] = LDRW_Tmep["CREDITOR"];
        ViewState["MLDIMMOVABLEDF"] = LOBJ_Data;
        MLDIMMOVABLEDFBind();

        this.UpdatePanelMLDIMMOVABLEDF.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }


    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        string LSTR_SelHead = this.hidSelHeadTag.Value;
        switch (LSTR_SelHead)
        {
            case "rptMLDIMMOVABLEDF":
                AddMLDIMMOVABLEDFRow();
                break;
            default:
                this.hidSelHeadTag.Value = "";
                break;
        }
    }

    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
    protected void btnDelRow_Click(object sender, EventArgs e)
    {
        string LSTR_SelRow = this.hidSelRowTag.Value;
        if (LSTR_SelRow.IndexOf(";") != -1)
        {
            string LSTR_Type = LSTR_SelRow.Split(';')[0];
            string LSTR_RowIndex = LSTR_SelRow.Split(';')[1];
            switch (LSTR_Type)
            {
                case "rptMLDIMMOVABLEDF":
                    DelMLDIMMOVABLEDFRow(LSTR_RowIndex);
                    break;
                default:
                    break;
            }

        }
        this.hidSelHeadTag.Value = "";
        this.hidSelRowTag.Value = "";
    }

    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
    private void AddMLDIMMOVABLEDFRow()
    {
        MLDIMMOVABLEDF_Init();
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDIMMOVABLEDF();
        //新增一筆資料    
        DataRow LOBJ_DataRow = LOBJ_Data.NewRow();
        LOBJ_DataRow["IMMOVABLEBUILDAREAS"] = "0.0";
        //LOBJ_DataRow["SETPRICE"] = "0";

        LOBJ_Data.Rows.Add(LOBJ_DataRow);

        ViewState["MLDIMMOVABLEDF"] = LOBJ_Data;
        MLDIMMOVABLEDFBind();
        this.UpdatePanelMLDIMMOVABLEDF.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }

    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
    private void DelMLDIMMOVABLEDFRow(string LSTR_RowIndex)
    {
        //更新暫存資料
        DataTable LOBJ_Data = updateMLDIMMOVABLEDF();
        //刪除一筆資料    
        LOBJ_Data.Rows.RemoveAt(Convert.ToInt32(LSTR_RowIndex));
        ViewState["MLDIMMOVABLEDF"] = LOBJ_Data;
        MLDIMMOVABLEDFBind();
        this.UpdatePanelMLDIMMOVABLEDF.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
    }


    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.      
    private void MLDIMMOVABLEDF_Init()
    {
        if (ViewState["MLDIMMOVABLEDF"] == null)
        {
            //初始化欄位
            DataTable LOBJ_Data = new DataTable("MLDIMMOVABLEDF");
            //主表
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

            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEBUILDHOLD", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLECASEPAWN", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEPAWNSTATUS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("IMMOVABLEPURPOSE", System.Type.GetType("System.String")));
            //明細表
            LOBJ_Data.Columns.Add(new DataColumn("HUMANRIGHTS", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("REGISTDATE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("SETPRICE", System.Type.GetType("System.String")));
            LOBJ_Data.Columns.Add(new DataColumn("CREDITOR", System.Type.GetType("System.String")));

            ViewState["MLDIMMOVABLEDF"] = LOBJ_Data;
        }
    }

    //Modify 20130104 By SS Maureen. Reason: 在徵信報告頁籤畫面中，不動產GRID加上可F8:新增 F9:刪除功能.
    private DataTable updateMLDIMMOVABLEDF()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDIMMOVABLEDF"];
        //先賦值
        for (int i = 0; i < rptMLDIMMOVABLEDF.Items.Count; i++)
        {
            LOBJ_Data.Rows[i]["IMMOVABLEOWNER"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEOWNER_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEOWNERID"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEOWNERID_D")).Text;

            LOBJ_Data.Rows[i]["IMMOVABLEGETDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEGETDATE_D")).Text); ;
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDDATE_D")).Text);
            LOBJ_Data.Rows[i]["IMMOVABLESECTOR"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLESECTOR_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEBUILD"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILD_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEAREA"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEAREA_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEHOLDER"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEHOLDER_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDNO"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDNO_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEHOUSENUM"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEHOUSENUM_D")).Text;

            string LSTR_Area = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDAREA_D")).Text.ToString();
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDAREA"] = LSTR_Area;
            double LINT_Area = LSTR_Area == "" ? 0 : Convert.ToDouble(LSTR_Area);
            LOBJ_Data.Rows[i]["IMMOVABLEBUILDAREAS"] = (LINT_Area * 0.3025).ToString("0.00");

            LOBJ_Data.Rows[i]["IMMOVABLEBUILDHOLD"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDHOLD_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLECASEPAWN"] = ((DropDownList)rptMLDIMMOVABLEDF.Items[i].FindControl("drpIMMOVABLECASEPAWN_D")).SelectedValue;
            LOBJ_Data.Rows[i]["IMMOVABLEPAWNSTATUS"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEPAWNSTATUS_D")).Text;
            LOBJ_Data.Rows[i]["IMMOVABLEPURPOSE"] = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEPURPOSE_D")).Text;

            //明細
            LOBJ_Data.Rows[i]["HUMANRIGHTS"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtHUMANRIGHTS_D")).Text;
            LOBJ_Data.Rows[i]["REGISTDATE"] = Itg.Community.Util.GetADYear(((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtREGISTDATE_D")).Text);
            LOBJ_Data.Rows[i]["SETPRICE"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtSETPRICE_D")).Text;
            LOBJ_Data.Rows[i]["CREDITOR"] = ((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtCREDITOR_D")).Text;
        }
        return LOBJ_Data;
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

        //LSTR_CUSTID = "KKTST";

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
    private void GetMLDCASETARGETBind(DataTable LOBJ_Data)
    {
        ViewState["MLDCASETARGET"] = LOBJ_Data;
        MLDCASETARGETBind();
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
    private void GetMLDCASEAPPENDDOCBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 1)
        {
            //LOBJ_Data.Rows.RemoveAt(LOBJ_Data.Rows.Count - 1);
            rptMLDCASEAPPENDDOC.DataSource = LOBJ_Data;
            rptMLDCASEAPPENDDOC.DataBind();
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

            this.drpPROPOSEDSIGN.SelectedValue = LOBJ_Data.Rows[0]["PROPOSEDSIGN"].ToString();

            //20120217 add BY SSF MAUREEN REASON:新增徵信報告頁簽欄位
            //徵信完成日期時間
            if (LOBJ_Data.Rows[0]["CREDITDTIME"].ToString() != "")
            {
                if (LOBJ_Data.Rows[0]["CREDITDTIME"].ToString().Substring(2, 1) != ":")
                {
                    this.txtCREDITDTIME.Text = LOBJ_Data.Rows[0]["CREDITDTIME"].ToString().Substring(0, 2) + ":" + LOBJ_Data.Rows[0]["CREDITDTIME"].ToString().Substring(2, 2);
                }
            }

            //初審確認日期
            if (LOBJ_Data.Rows[0]["FIRCREDITDT"].ToString().Trim() != "")
            {
                if (LOBJ_Data.Rows[0]["FIRCREDITDT"].ToString().Substring(0, 4) == "1900")
                {
                    this.txtFIRCREDITDT.Text = "";
                }
                else
                {
                    this.txtFIRCREDITDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["FIRCREDITDT"].ToString());
                }
            }
            else
            {
                this.txtFIRCREDITDT.Text = "";
            }

            //初審確認日期時間
            if (LOBJ_Data.Rows[0]["FIRCREDITDTIME"].ToString() != "")
            {
                if (LOBJ_Data.Rows[0]["FIRCREDITDTIME"].ToString().Substring(2, 1) != ":")
                {
                    this.txtFIRCREDITDTIME.Text = LOBJ_Data.Rows[0]["FIRCREDITDTIME"].ToString().Substring(0, 2) + ":" + LOBJ_Data.Rows[0]["FIRCREDITDTIME"].ToString().Substring(2, 2);
                }
            }

            //徵信建議
            this.drpSUGGEST.SelectedValue = LOBJ_Data.Rows[0]["CREDITSUGGEST"].ToString();

            this.HidEMPLID.Value = LOBJ_Data.Rows[0]["EMPLID"].ToString();
            this.HidDEPTID.Value = LOBJ_Data.Rows[0]["DEPTID"].ToString();

            if (LOBJ_Data.Rows[0]["CREDITDT"].ToString().Trim() != "")
            {
                this.txtCREDITRECDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["CREDITDT"].ToString());
                if (LOBJ_Data.Rows[0]["CREDITDT"].ToString().Substring(0, 4) == "1900")
                {
                    this.txtCREDITDT.Text = "";
                }
                else
                {
                    this.txtCREDITDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["CREDITDT"].ToString());
                }
            }
            else
            {
                this.txtCREDITDT.Text = "";
            }
            this.txtCREDITDESC.Text = LOBJ_Data.Rows[0]["CREDITDESC"].ToString().Replace("<br>", "\r\n");
            this.hidCREDITFILEID.Value = LOBJ_Data.Rows[0]["CREDITFILEID"].ToString();
            this.txtCREDITFILENAME.Text = LOBJ_Data.Rows[0]["CREDITFILENAME"].ToString();
            if (this.txtCREDITFILENAME.Text != "" && this.hidCREDITFILEID.Value != "")
            {
                //案件下載
                this.btnCREDITFILEdownload.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + this.hidCREDITFILEID.Value.Trim() + "');return false;";
                //ADD BY JBLEO 20141212 徵信維護也加上[系統讀取中]的訊息框
                //this.btnCREDITFILEmaintain.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + this.hidCREDITFILEID.Value.Trim() + "');return false;";
            }
            //this.btnCREDITFILEdownload.OnClientClick = "window.showModalDialog('../../ML.NET/ML20/ML2008.aspx?PRGID=ML2008&PROGNM=%e5%be%b5%e4%bf%a1%e5%a0%b1%e5%91%8a%e7%b6%ad%e8%ad%b7&CASEID=" + txtCASEID.Text + "','','dialogHeight:700px;dialogWidth:900px;'); return false;";
            if (LOBJ_Data.Rows[0]["CREDITRECDT"].ToString().Trim() != "")
            {
                if (LOBJ_Data.Rows[0]["CREDITRECDT"].ToString().Substring(0, 4) == "1900")
                {
                    this.txtCREDITRECDT.Text = "";
                }
                else
                {
                    this.txtCREDITRECDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["CREDITRECDT"].ToString());
                }
            }
            else
            {
                this.txtCREDITDT.Text = "";
            }
            if (this.txtCREDITRECDT.Text.Trim() == "")
            {
                try
                {
                    string LSTR_DateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    ReturnObject<object> LOBJ_ReturnObject = UpdateiCREDITRECDT(LSTR_DateNow);
                    if (LOBJ_ReturnObject.ReturnSuccess)
                    {
                        this.txtCREDITRECDT.Text = Itg.Community.Util.GetRepYear(LSTR_DateNow);
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

            //UPD BY VICKY 20140627 徵審人員沒有值時,帶預設,否則鎖定
            if (LOBJ_Data.Rows[0]["CREDITER"].ToString().Trim() == "")
            {
                this.labCREDITER.Text = Session["USERNM"].ToString();
                this.labCREDITER_ID.Text = Session["USERID"].ToString();
            }
            else
            {
                this.labCREDITER.Text = LOBJ_Data.Rows[0]["CREDITER"].ToString();
                this.labCREDITER_ID.Text = LOBJ_Data.Rows[0]["CREDITER_ID"].ToString();
            }

            //20140630 實貸金額權限
            this.drpACTUSLLOANSAUTH.SelectedValue = LOBJ_Data.Rows[0]["ACTUSLLOANSAUTH"].ToString();

            //20140630 IRR權限
            this.drpIRRAUTH.SelectedValue = LOBJ_Data.Rows[0]["IRRAUTH"].ToString();

            //----------覆核頁籤-------------------------------------------------
            //UPD BY VICKY 20140630 徵審人員沒有值時,帶預設
            if (LOBJ_Data.Rows[0]["CREDITER2"].ToString().Trim() == "")
            {
                this.tab8_labCREDITER.Text = Session["USERNM"].ToString();
                this.tab8_labCREDITER_ID.Text = Session["USERID"].ToString();
            }
            else
            {
                this.tab8_labCREDITER.Text = LOBJ_Data.Rows[0]["CREDITER2"].ToString();
                this.tab8_labCREDITER_ID.Text = LOBJ_Data.Rows[0]["CREDITER2_ID"].ToString();
            }

            //20140630 實貸金額權限
            this.tab8_drpACTUSLLOANSAUTH.SelectedValue = LOBJ_Data.Rows[0]["ACTUSLLOANSAUTH2"].ToString();

            //20140630 IRR權限
            this.tab8_drpIRRAUTH.SelectedValue = LOBJ_Data.Rows[0]["IRRAUTH2"].ToString();

        }
    }
    private ReturnObject<object> UpdateiCREDITRECDT(string LSTR_DateNow)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        ReturnObject<object> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];

        StringBuilder LSTR_SaveFields = new StringBuilder();
        LSTR_SaveFields.Append("'");
        LSTR_SaveFields.Append("MLMCASE");
        LSTR_SaveFields.Append("','");
        LSTR_SaveFields.Append("CREDITRECDT" + GSTR_ColDelimitChar);
        LSTR_SaveFields.Append(GSTR_RowDelimitChar);
        LSTR_SaveFields.Append(LSTR_DateNow + GSTR_ColDelimitChar);
        LSTR_SaveFields.Append(GSTR_RowDelimitChar);
        LSTR_SaveFields.Append("','");
        LSTR_SaveFields.Append("CASEID" + GSTR_ColDelimitChar);
        LSTR_SaveFields.Append(this.txtCASEID.Text.Trim() + GSTR_ColDelimitChar);
        LSTR_SaveFields.Append(GSTR_RowDelimitChar);
        LSTR_SaveFields.Append("'");
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiNonQueryByStoreProcedure";

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML0000_U01";
            LVAR_Parameter[1] = LSTR_SaveFields.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
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

            //Modify 20130103 By SS Maureen. Reason: 在徵信報告頁籤畫面中，新增不動產設定GRID.
            LSTR_StoreProcedure.Append("SP_ML2001A_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20131025 Reason:增加覆核報告頁籤
            LSTR_StoreProcedure.Append("SP_ML2001A_Q05" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20140808 Reason:增加結論登記區塊
            LSTR_StoreProcedure.Append("SP_ML2001A_Q07" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //覆核
            LSTR_StoreProcedure.Append("SP_ML2001A_Q08" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            // 20160930 ADD BY SS ADAM REASON.增加放審會
            LSTR_StoreProcedure.Append("SP_ML2001A_Q09" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            LSTR_StoreProcedure.Append("SP_ML2001A_Q10" + GSTR_RowDelimitChar);
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

                this.drpPAYTPE.DataSource = LDST_Data.Tables[8].DefaultView;
                this.drpPAYTPE.DataBind();

                this.drpPAYTIMEA.DataSource = LDST_Data.Tables[9].DefaultView;
                this.drpPAYTIMEA.DataBind();

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

                this.drpPROPOSEDSIGN.DataSource = LDST_Data.Tables[14].DefaultView;
                this.drpPROPOSEDSIGN.DataBind();

                //20120217 add BY SSF MAUREEN REASON:新增徵信建議下拉選項
                this.drpSUGGEST.DataSource = LDST_Data.Tables[15].DefaultView;
                this.drpSUGGEST.DataBind();

                //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
                this.drpSOURCETYPE.DataSource = LDST_Data.Tables[16].DefaultView;
                this.drpSOURCETYPE.DataBind();
                //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
                this.drpBANKCD.DataSource = LDST_Data.Tables[17].DefaultView;
                this.drpBANKCD.DataBind();
                this.drpBANKCD.Items.Insert(0, new ListItem("", ""));

                //ADD 20131031 REASON 覆核報告 簽核權限
                this.tab8_ddlPROPOSEDSIGN.DataSource = LDST_Data.Tables[14].DefaultView;
                this.tab8_ddlPROPOSEDSIGN.DataBind();

                //ADD 20131031 REASON 覆核報告 徵信覆核建議
                this.tab8_ddlCREDITSUGGEST.DataSource = LDST_Data.Tables[15].DefaultView;
                this.tab8_ddlCREDITSUGGEST.DataBind();

                string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                drpSUBTYPEBindbyID(LSTR_MAINTYPEID);
                SetMAINTYPERDO(LSTR_MAINTYPEID);


                //Modify 20140627 By SS VICKY. Reason: 新增實貸金額權限.
                this.drpACTUSLLOANSAUTH.DataSource = LDST_Data.Tables[18].DefaultView;
                this.drpACTUSLLOANSAUTH.DataBind();

                //Modify 20140627 By SS VICKY. Reason: 新增IRR權限.
                this.drpIRRAUTH.DataSource = LDST_Data.Tables[19].DefaultView;
                this.drpIRRAUTH.DataBind();

                //Modify 20140630 By SS Vicky. Reason: 覆核報告 實貸金額權限
                this.tab8_drpACTUSLLOANSAUTH.DataSource = LDST_Data.Tables[18].DefaultView;
                this.tab8_drpACTUSLLOANSAUTH.DataBind();

                //Modify 20140630 By SS VICKY. Reason: 覆核報告 IRR權限.
                this.tab8_drpIRRAUTH.DataSource = LDST_Data.Tables[19].DefaultView;
                this.tab8_drpIRRAUTH.DataBind();

                //Modify 20140807 By SS CHRIS HUNG. Reason: 覆核報告 操作模式.
                this.ddlOPERATION.DataSource = LDST_Data.Tables[20].DefaultView;
                this.ddlOPERATION_R.DataSource = LDST_Data.Tables[20].DefaultView;
                this.ddlOPERATION.DataBind();
                this.ddlOPERATION_R.DataBind();


                //20150721 ADD BY SS ADAM REASON.直接加在CODE TABLE就好
                //20150629 ADD BY SS EDWARD.增加重車專案別
                //devTypeTable = LDST_Data.Tables[21].Copy();
                //DataView newDV = new DataView(devTypeTable);
                //DataRow newrow = newDV.Table.NewRow();
                //newrow["MCODE"] = "07";
                //newrow["MNAME1"] = "重車";
                //newDV.Table.Rows.InsertAt(newrow, 6);

                //Modify 20140807 By SS CHRIS HUNG. Reason: 覆核報告 設備類型.
                this.ddlDEVICETYPE.DataSource = LDST_Data.Tables[21].DefaultView;
                this.ddlDEVICETYPE_R.DataSource = LDST_Data.Tables[21].DefaultView;
                this.ddlDEVICETYPE.DataBind();
                this.ddlDEVICETYPE_R.DataBind();

                //20160323 ADD BY SS ADAM REASON.增加案件產品別
                this.drpPRODCD.DataSource = LDST_Data.Tables[22].DefaultView;
                this.drpPRODCD.DataBind();

                this.drpPRODCD_TAB6.DataSource = LDST_Data.Tables[22].DefaultView;
                this.drpPRODCD_TAB6.DataBind();

                this.drpPRODCD_TAB8.DataSource = LDST_Data.Tables[22].DefaultView;
                this.drpPRODCD_TAB8.DataBind();

                //20221207行業別改下拉選單
                this.DrpNDU.DataSource = LDST_Data.Tables[23].DefaultView;
                DataView LDVW_DocData = LDST_Data.Tables[23].DefaultView;
                LDVW_DocData.RowFilter = "MCODE NOT IN ('17' , '18'  , '19' , '20')";
                this.DrpNDU.DataBind();

                this.DrpNDU_TAB6.DataSource = LDST_Data.Tables[23].DefaultView;
                this.DrpNDU_TAB6.DataBind();

                this.DrpNDU_TAB8.DataSource = LDST_Data.Tables[23].DefaultView;
                this.DrpNDU_TAB8.DataBind();

                //20160930 ADD BY SS ADAM REASON.增加放審會
                this.tab9_ddlPROPOSEDSIGN.DataSource = LDST_Data.Tables[14].DefaultView;
                this.tab9_ddlPROPOSEDSIGN.DataBind();
                this.tab9_ddlCREDITSUGGEST.DataSource = LDST_Data.Tables[15].DefaultView;
                this.tab9_ddlCREDITSUGGEST.DataBind();
                this.tab9_ddlCREDITSUGGEST2.DataSource = LDST_Data.Tables[15].DefaultView;
                this.tab9_ddlCREDITSUGGEST2.DataBind();
                this.tab9_drpACTUSLLOANSAUTH.DataSource = LDST_Data.Tables[18].DefaultView;
                this.tab9_drpACTUSLLOANSAUTH.DataBind();
                this.tab9_drpIRRAUTH.DataSource = LDST_Data.Tables[19].DefaultView;
                this.tab9_drpIRRAUTH.DataBind();
                this.ddlOPERATION_TAB9.DataSource = LDST_Data.Tables[20].DefaultView;
                this.ddlOPERATION_TAB9.DataBind();
                this.ddlDEVICETYPE_TAB9.DataSource = LDST_Data.Tables[21].DefaultView;
                this.ddlDEVICETYPE_TAB9.DataBind();
                this.drpPRODCD_TAB9.DataSource = LDST_Data.Tables[22].DefaultView;
                this.drpPRODCD_TAB9.DataBind();
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


            //征信審核權限drpPROPOSEDSIGN
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "69" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20120217 add BY SSF MAUREEN REASON:新增徵信建議下拉選項
            //徵信建議drpSUGGEST
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "81" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "89" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "90" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20140627 By SS VICKY. Reason: 實貸金額權限.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A4" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20140627 By SS VICKY. Reason: IRR權限.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A3" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20140627 By SS VICKY. Reason: 操作模式.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A5" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //Modify 20140627 By SS VICKY. Reason: 訯備類型.
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A6" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20160323 ADD BY SS ADAM REASON.新增案件產品別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "93" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //20221207行業別改下拉選單
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
    protected void btnDocCreditRepor_Click(object sender, EventArgs e)
    {
        this.hidShowTag.Value = "fraTab66Caption";

        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

        string TemplateFile = Server.MapPath("~/Template/CreditRepor.dot"); ;
        string Fname = DateTime.Now.ToString("yyyymmddhhmmss") + "_" + this.txtCASEID.Text + ".doc";
        string FileName = Server.MapPath("~/Upload/" + Fname);

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
                case "CUSTNAME":
                    bm.Range.Text = this.txtCUSTNAME.Text;
                    break;
                case "CASESOURCE":
                    bm.Range.Text = this.drpCASESOURCE.SelectedItem.Text;
                    break;
                case "OWNER":
                    bm.Range.Text = this.txtOWNER.Text;
                    break;
                case "CUSTADDR":
                    bm.Range.Text = this.txtCUSTZIPCODES.Text + this.txtCUSTADDR.Text;
                    break;
                case "BUSINESSADDR":
                    bm.Range.Text = this.txtBUSINESSZIPCODES.Text + this.txtBUSINESSADDR.Text;
                    break;
                case "CUSTCREATEDATE":
                    bm.Range.Text = Regex.Replace(Itg.Community.Util.GetADYear(this.txtCUSTCREATEDATE.Text).Substring(2, 8), "/", ".");
                    break;
                case "BUSINESS":
                    bm.Range.Text = this.txtBUSINESS.Text;
                    break;
                case "CUSTNOWCAPTIAL":
                    bm.Range.Text = this.txtCUSTNOWCAPTIAL.Text;
                    break;
                case "CUSTCREATECAPTIAL":
                    bm.Range.Text = this.txtCUSTCREATECAPTIAL.Text;
                    break;
                case "MLDCASETARGET":
                    if (rdoMLDCASEARDATA.Checked == true)
                    {
                        bm.Range.Text = "本案係應收帳款受讓額度申請案件，無標的物。";
                    }
                    else
                    {
                        bm.Range.Text = "";
                    }
                    break;
                case "MAINTYPE":
                    bm.Range.Text = this.drpMAINTYPE.SelectedItem.Text;
                    break;
                case "APLIMIT":
                    bm.Range.Text = this.txtAPLIMIT.Text;
                    break;
                case "CREDITFEES":
                    bm.Range.Text = this.txtCREDITFEES.Text;
                    break;
                case "MANAGERFEES":
                    bm.Range.Text = this.txtMANAGERFEES.Text;
                    break;
                case "FINANCIALFEES":
                    bm.Range.Text = this.txtFINANCIALFEES.Text;
                    break;
                case "ACCOUNTSTERM":
                    bm.Range.Text = this.txtACCOUNTSTERM.Text;
                    break;
                case "PAYTIMEA":
                    bm.Range.Text = this.drpPAYTPE.SelectedItem.Text;
                    break;
                case "PAYTPE":
                    bm.Range.Text = this.drpPAYTPE.SelectedItem.Text;
                    break;
                case "PAYTPE2":
                    bm.Range.Text = this.drpPAYTPE.SelectedItem.Text;
                    break;
                case "BUYERLIMIT":
                    bm.Range.Text = this.txtBUYERLIMIT.Text;
                    break;
                case "CONTRACTMONTH":
                    bm.Range.Text = this.txtCONTRACTMONTH.Text;
                    break;
                default:
                    break;
            }
        }
        object IsSave = true;
        doc.Close(ref IsSave, ref missing, ref missing);
        app.Quit(ref IsSave, ref missing, ref missing);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

        RegisterScript("window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');");

        //RegisterScript("OpenAttach('Download.aspx?docpath="+ Fname + "');");
        //RegisterScript("OpenAttach('Download.aspx?docpath=" + "a.doc" + "');");

        //RegisterScript("setTimeout(function(){window.open('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');}, 2000);");


        //RegisterScript("OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');");
        //RegisterScript("OpenAttach('Upload/" + Fname + "');");
        //RegisterScript("OpenAttach('Upload/20104621054618_A2099070018.doc');");
        //RegisterScript("showWord(), 2000);");

        //不回發 this.lnkDocCredit.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + Fname + "');return false;";

        //this.lnkDocCredit.Text = "生成完成，點擊下載！";
        //this.lnkDocCredit.OnClientClick = "OpenAttach('Download.aspx?docpath=" + Fname + "');return false;";

        //window open OK Itg.Community.DownLoad.DownLoadText("c://a.doc");
        //RegisterScript("OpenAttach('Download.aspx');");
    }
    public static string dodownload(string ISTR_Filename)
    {
        string returnValue = "";
        try
        {

            string ISTR_FileFullName = System.Web.Configuration.WebConfigurationManager.AppSettings["UploadPath"] + ISTR_Filename;
            //判斷檔案是否存在
            if (!File.Exists(ISTR_FileFullName))
            {
                returnValue = "0";
            }
            else
            {
                FileStream FileStream = default(FileStream);
                long FileSize = 0;
                FileStream = new FileStream(ISTR_FileFullName, FileMode.Open, FileAccess.Read);
                FileSize = FileStream.Length;

                byte[] Buffer = new byte[(int)FileSize + 1];
                FileStream.Read(Buffer, 0, (int)FileSize);
                FileStream.Close();
                FileStream = null;
                //準備下載檔案 
                System.Web.HttpContext.Current.Response.ClearHeaders();
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Expires = 0;
                System.Web.HttpContext.Current.Response.Buffer = true;

                //透過 Header 設定檔名 
                System.Web.HttpContext.Current.Response.BinaryWrite(Buffer);
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + System.Convert.ToChar(34) + ISTR_Filename + System.Convert.ToChar(34));
                //System.Web.HttpContext.Current.Response.ContentType = "Application/octet-stream";
                System.Web.HttpContext.Current.Response.ContentType = "application/msword";


                //傳出要讓使用者下載的內容 
                System.Web.HttpContext.Current.Response.BinaryWrite(Buffer);
                System.Web.HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            returnValue = ex.Message.ToString();
        }
        finally
        {
            //將目前所有受緩衝的輸出傳送到用戶端,停止網頁的執行,並引發System.Web.HttpApplication.EndRequest事件
            //System.Web.HttpContext.Current.Response.End();
        }
        return returnValue;

    }

    //20120221 ADD BY MAUREEN REASON:新增確認按鈕
    protected void btnSaveSure_Click(object sender, EventArgs e)
    {
        if (this.txtCREDITDT.Text.Trim() == "")
        {
            //20120605 ADD BY MAUREEN REASON:新增開窗選擇徵信建議(附條件or婉拒)
            if (this.drpSUGGEST.SelectedValue == "4B")
            {
                string strScript = "window.showModalDialog(\"FrmML2001B_b.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID + "\", window, \"status:false;help:0;status:0;center:1;dialogWidth:700px;dialogHeight:850px;\");";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", strScript, true);

            }

            if (this.drpSUGGEST.SelectedValue == "4C")
            {
                string strScript = "window.showModalDialog(\"FrmML2001B_a.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID + "\", window, \"status:false;help:0;status:0;center:1;dialogWidth:700px;dialogHeight:850px;\");";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", strScript, true);

            }

            MLMCASESave("3");
        }

        if (this.txtCREDITDT.Text.Trim() != "" && this.drpSUGGEST.SelectedValue == "4")
        {
            MLMCASESave("4");
        }

        if (this.txtCREDITDT.Text.Trim() != "" && this.drpSUGGEST.SelectedValue == "4B")
        {
            //20120309 MODIFY BY MAUREEN REASON:不跑發送MAIL部分
            //btnWj_Click(null,null);

            //20120605 ADD BY MAUREEN REASON:新增開窗選擇徵信建議(附條件or婉拒)
            string strScript = "window.showModalDialog(\"FrmML2001B_b.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID + "\", window, \"status:false;help:0;status:0;center:1;dialogWidth:700px;dialogHeight:850px;\");";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", strScript, true);


            MLMCASESave("4B");
        }

        if (this.txtCREDITDT.Text.Trim() != "" && this.drpSUGGEST.SelectedValue == "4C")
        {
            //20120309 MODIFY BY MAUREEN REASON:不跑發送MAIL部分
            //btnCond_Click(null, null);

            //20120605 ADD BY MAUREEN REASON:新增開窗選擇徵信建議(附條件or婉拒)
            string strScript = "window.showModalDialog(\"FrmML2001B_a.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID + "\", window, \"status:false;help:0;status:0;center:1;dialogWidth:700px;dialogHeight:850px;\");";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", strScript, true);


            MLMCASESave("4C");
        }
    }


    protected void btnSaveTemp_Click(object sender, EventArgs e)
    {
        MLMCASESave("3");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MLMCASESave("4");
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
        LSTR_Subject = "徵信退件 [" + this.drpMAINTYPE.SelectedItem.Text + "-" + this.drpSUBTYPE.SelectedItem.Text + "] 案件編號：" + this.txtCASEID.Text;
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
        MLMCASESave("4A");
    }
    //protected void btnWj_Click(object sender, EventArgs e)
    //{
    //  string LSTR_FromAddress = "";
    //  string LSTR_ToAddress = "";
    //  string LSTR_CCAddress = "";
    //  string LSTR_Subject = "";
    //  string LSTR_BodyInfo = "";
    //  string LSTR_Attachment = "";
    //  LSTR_FromAddress += "設備租賃系統" + GSTR_ColDelimitChar;
    //  LSTR_FromAddress += "HFC@mail.hotaimotor.com.tw" + GSTR_ColDelimitChar;
    //  LSTR_FromAddress += GSTR_RowDelimitChar;

    //  ReturnObject<DataTable> LOBJ_Return;
    //  LOBJ_Return = GetEmailADDR(this.HidEMPLID.Value, this.HidDEPTID.Value);
    //  if (LOBJ_Return.ReturnSuccess)
    //  {
    //    DataTable LOBJ_Data = LOBJ_Return.ReturnData;
    //    for (int i = 0; i < LOBJ_Data.Rows.Count; i++)
    //    {
    //      if (LOBJ_Data.Rows[i]["EMAILTYPE"].ToString() == "1")
    //      {
    //        LSTR_ToAddress += LOBJ_Data.Rows[i]["EMPLNM"].ToString() + GSTR_ColDelimitChar;
    //        LSTR_ToAddress += LOBJ_Data.Rows[i]["EMAIL"].ToString() + GSTR_ColDelimitChar;
    //        LSTR_ToAddress += GSTR_RowDelimitChar;
    //      }
    //      else if (LOBJ_Data.Rows[i]["EMAILTYPE"].ToString() == "2")
    //      {
    //        LSTR_CCAddress += LOBJ_Data.Rows[i]["EMPLNM"].ToString() + GSTR_ColDelimitChar;
    //        LSTR_CCAddress += LOBJ_Data.Rows[i]["EMAIL"].ToString() + GSTR_ColDelimitChar;
    //        LSTR_CCAddress += GSTR_RowDelimitChar;
    //      }
    //    }
    //  }
    //  LSTR_Subject = "徵信婉拒 [" + this.drpMAINTYPE.SelectedItem.Text + "-" + this.drpSUBTYPE.SelectedItem.Text + "] 案件編號：" + this.txtCASEID.Text;
    //  LSTR_BodyInfo = this.hidCond.Value.ToString().Replace("\r\n", "<br>");
    //  LSTR_Attachment = "";
    //  try
    //  {
    //    //Itg.Community.Mail.SendMail(LSTR_FromAddress, LSTR_ToAddress, LSTR_CCAddress, LSTR_Subject, LSTR_BodyInfo, LSTR_Attachment);
    //    Itg.Community.Mail.SendMailByDB(GetComusVirtualPath(), GSTR_U_PRGID, GSTR_U_USERID, LSTR_FromAddress, LSTR_ToAddress, LSTR_CCAddress, LSTR_Subject, LSTR_BodyInfo, LSTR_Attachment);
    //  }
    //  catch (System.Exception Exception)
    //  {
    //    Alert(Exception.Message);
    //  }
    //  MLMCASESave("4B");
    //}
    protected void btnCond_Click(object sender, EventArgs e)
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
        LSTR_Subject = "徵信附條件 [" + this.drpMAINTYPE.SelectedItem.Text + "-" + this.drpSUBTYPE.SelectedItem.Text + "] 案件編號：" + this.txtCASEID.Text;
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
        MLMCASESave("4C");
    }
    protected void btnLackComment_Click(object sender, EventArgs e)
    {
        string LSTR_FromAddress = "";
        string LSTR_ToAddress = "";
        string LSTR_CCAddress = "";
        string LSTR_Subject = "";
        string LSTR_BodyInfo = "";
        string LSTR_Attachment = "";
        this.hidShowTag.Value = "fraTab66Caption";
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
                else if (LOBJ_Data.Rows[i]["EMAILTYPE"].ToString() == "1")
                {
                    LSTR_CCAddress += LOBJ_Data.Rows[i]["EMPLNM"].ToString() + GSTR_ColDelimitChar;
                    LSTR_CCAddress += LOBJ_Data.Rows[i]["EMAIL"].ToString() + GSTR_ColDelimitChar;
                    LSTR_CCAddress += GSTR_RowDelimitChar;
                }
            }
        }
        LSTR_Subject = "缺件通知 [" + this.drpMAINTYPE.SelectedItem.Text + "-" + this.drpSUBTYPE.SelectedItem.Text + "] 案件編號：" + this.txtCASEID.Text;
        LSTR_BodyInfo = this.hidLackComment.Value.ToString().Replace("\r\n", "<br>");
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
    }

    //Modify 20120601 By SS Gordon. Reason: 新增案件退回.
    protected void btnReturnChk_Click(object sender, EventArgs e)
    {
        //20120608 ADD BY MAUREEN REASON:新增開窗選擇退件原因(資料不齊or條件調整)
        //string strScript = "window.showModalDialog(\"FrmML2001A_c.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID + "\", window, \"status:false;help:0;status:0;center:1;dialogWidth:600px;dialogHeight:400px;\");";
        //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", strScript, true);
        string strScript = "FrmML2001B_c.aspx?t=" + DateTime.Now.Millisecond.ToString() + "&CASEID=" + this.txtCASEID.Text + "&CREDITDT=" + this.txtCREDITDT.Text + "&USERID=" + GSTR_U_USERID;
        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OPWIN", "btnReturnChk_Click('" + strScript + "')", true);
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //退回ML1002所以CASESTATUS=1
        MLMCASERETURN("1");
    }
    //Modify 20120601 By SS Gordon. Reason: 新增案件退回.
    private void MLMCASERETURN(string LSTR_SaveType)
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
        LSTR_Data.Append("ML2001A" + GSTR_TabDelimitChar);
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
        //=========================================================================
        LSTR_Data.Append("SP_ML1002_U05" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.drpPROPOSEDSIGN.SelectedValue + GSTR_TabDelimitChar);
        if (this.txtCREDITDT.Text.Trim() == "")
        {
            if (LSTR_SaveType == "3")
            {
                LSTR_Data.Append("" + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            }
        }
        else
        {
            LSTR_Data.Append(Itg.Community.Util.GetADYear(this.txtCREDITDT.Text) + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(this.txtCREDITDESC.Text.Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidCREDITFILEID.Value + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCREDITFILENAME.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        //john 2011/11/04  增加寫入實際徵審單位
        LSTR_Data.Append(GSTR_TabDelimitChar + GSTR_DEPTID);

        //20120221 ADD BY MAUREEN REASON:新增徵信報告頁簽欄位
        LSTR_Data.Append(GSTR_TabDelimitChar + this.txtCREDITDTIME.Text.Replace(":", ""));       //徵信完成日期時間
        LSTR_Data.Append(GSTR_TabDelimitChar + this.txtFIRCREDITDT.Text.Replace("/", ""));       //初審確認日期
        LSTR_Data.Append(GSTR_TabDelimitChar + this.txtFIRCREDITDTIME.Text.Replace(":", ""));    //初審確認日期時間
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpSUGGEST.SelectedValue);  //徵信建議

        //20131113 ADD BY Leo 進件條件擔保價值
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpGuanValue.SelectedValue.Trim());  //進件條件擔保價值

        //UPD BY VICKY 20140630 新增[徵審人員][實貸金額權限][IRR權限]
        LSTR_Data.Append(GSTR_TabDelimitChar + this.labCREDITER_ID.Text.Trim());                  //徵審人員
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpACTUSLLOANSAUTH.SelectedValue.Trim());  //實貸金額權限
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpIRRAUTH.SelectedValue.Trim());          //IRR權限

        //UPD BY VICKY 20140630 新增[覆核徵審人員][覆核實貸金額權限][覆核IRR權限]
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_labCREDITER_ID.Text.Trim());                  //覆核徵審人員
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpACTUSLLOANSAUTH.SelectedValue.Trim());  //覆核實貸金額權限
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpIRRAUTH.SelectedValue.Trim());          //覆核IRR權限

        //20160324 ADD BY SS ADAM REASON.儲存案件產品別
        LSTR_Data.Append(GSTR_TabDelimitChar + this.drpPRODCD_TAB6.SelectedValue.Trim());

        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        if (LSTR_SaveType != "3")
        {
            LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.hidCond.Value.ToString().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append("1");
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //=========================================================================
        //Modify 20120620 By SS Gordon. Reason: 徵信核准成功時，將案件資料另外儲存
        //Modify 20121128 By SS Gordon. Reason: 徵信核准成功時，將案件資料另外儲存。原本只有[4]，需將[4B],[4C]也加入
        if (LSTR_SaveType == "4" || LSTR_SaveType == "4B" || LSTR_SaveType == "4C")
        {
            LSTR_Data.Append("SP_ML2001A_I04" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //20140108 ADD BY SS ADAM Reason.增加覆核建議存檔
        LSTR_Data.Append("SP_ML2001A_I05" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        if (tab8_tbxCREDITCNFDT_YMD.Text != "")
        {
            LSTR_Data.Append(tab8_tbxCREDITCNFDT_YMD.Text + " " + tab8_tbxCREDITCNFDT_HS.Text + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(GSTR_TabDelimitChar);
        }
        if (tab8_tbxCREDITFINDT_YMD.Text != "")
        {
            LSTR_Data.Append(tab8_tbxCREDITFINDT_YMD.Text + " " + tab8_tbxCREDITFINDT_HS.Text + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(tab8_ddlPROPOSEDSIGN.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab8_ddlCREDITSUGGEST.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab8_CREDITDESC.Text.Replace("\r\n", "<br>"));
        //UPD BY VICKY 20140630 新增[覆核徵審人員][覆核實貸金額權限][覆核IRR權限]
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_labCREDITER_ID.Text.Trim());                  //覆核徵審人員
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpACTUSLLOANSAUTH.SelectedValue.Trim());  //覆核實貸金額權限
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpIRRAUTH.SelectedValue.Trim());          //覆核IRR權限

        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        //20140808 ADD BY SS CHRIS HUNG Reason.增加結論區塊存檔--初審
        //if (txtCREDITAMT.Text.Trim() != "" && float.Parse(txtCREDITAMT.Text.Trim()) > 0)
        {
            LSTR_Data.Append("SP_ML2001A_I06" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCREDITAMT.Text.Trim() == "" ? "0" : txtCREDITAMT.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCONTRACTMON.Text.Trim() == "" ? "0" : txtCONTRACTMON.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtPERBOND2.Text.Trim() == "" ? "0" : txtPERBOND2.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            if (chkGRTMV.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTIMV.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTDEPOSIT.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTBILLNOTE.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTSTOCK.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTCAR.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            LSTR_Data.Append((txtGRTBAL.Text.Trim() == "" ? "0" : txtGRTBAL.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtGRTVAL.Text.Trim() == "" ? "0" : txtGRTVAL.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlFUNDSUSE.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlECONDITION.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlOPERATION.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlDEVICETYPE.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtDEDUCTION.Text.Trim() == "" ? "0" : txtDEDUCTION.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtGRTITEM.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtOTHERCONDITION.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtSIGNMEMO.Text.Trim());
            //LSTR_Data.Append(tab8_CREDITDESC.Text.Replace("\r\n", "<br>"));
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //20140811 ADD BY SS CHRIS HUNG Reason.增加結論區塊存檔--覆審
        /*
        if (txtCREDITAMT_R.Text.Trim() != "" && float.Parse(txtCREDITAMT_R.Text.Trim()) > 0)
        {
            LSTR_Data.Append("SP_ML2001A_I07" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCREDITAMT_R.Text.Trim() == "" ? "0" : txtCREDITAMT_R.Text.Trim().Replace(",","")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCONTRACTMON_R.Text.Trim() == "" ? "0" : txtCONTRACTMON_R.Text.Trim().Replace(",","")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtPERBOND_R.Text.Trim() == "" ? "0" : txtPERBOND_R.Text.Trim().Replace(",","")) + GSTR_TabDelimitChar);
            if (chkGRTMV_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTIMV_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTDEPOSIT_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTBILLNOTE_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTSTOCK_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTCAR_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            LSTR_Data.Append((txtGRTBAL_R.Text.Trim() == "" ? "0" : txtGRTBAL_R.Text.Trim().Replace(",","")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtGRTVAL_R.Text.Trim() == "" ? "0" : txtGRTVAL_R.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlFUNDSUSE_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlCONDITION_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlOPERATION_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlDEVICETYPE_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtDEDUCTION_R.Text.Trim() == "" ? "0" : txtDEDUCTION_R.Text.Trim().Replace(",","")) + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtGRTITEM_R.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtOTHERCONDITION_R.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtSIGNMEMO_R.Text.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }*/

        //20160324 ADD BY SS ADAM REASON.初審行業別有更新才存檔
        //20221207行業別改下拉選單
        //if (txtINDUID.Text.Trim() != txtINDUID_TAB6.Text.Trim())
        if(DrpNDU.SelectedValue.Trim() != DrpNDU_TAB6.SelectedValue.Trim())
        {
            LSTR_Data.Append("SP_ML2001A_U05" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            //LSTR_Data.Append(this.txtINDUID_TAB6.Text.Trim());
            LSTR_Data.Append(this.DrpNDU_TAB6.SelectedValue.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab11Caption";
                if (LSTR_SaveType == "3")
                {
                    //20120309 MODIFY BY MAUREEN REASON:修改僅輸入「初審確認日」時，按下確認鈕後，要可以印報表
                    this.cmdPrintReportB.Enabled = true;
                    //20141218 ADD BY SS ADAM REASON.列印徵信報告書改到頁籤內
                    this.cmdPrintReportC.Enabled = false;

                    this.btnSaveSure.Enabled = false;
                    //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                    this.btnReturnChk.Enabled = false;
                    //20120309 MODIFY BY MAUREEN REASON:修改alert訊息
                    //RegisterScript("alert('暫存成功！');");
                    RegisterScript("alert('儲存成功！');");
                }
                else if (LSTR_SaveType == "4")
                {
                    this.cmdPrintReportB.Enabled = true;
                    this.btnSaveSure.Enabled = false;
                    //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                    this.btnReturnChk.Enabled = false;
                    //this.btnSaveTemp.Enabled = false;
                    //this.btnSubmit.Enabled = false;
                    //this.btnRegect.Enabled = false;
                    //this.btnWj.Enabled = false;
                    //this.btnSelect.Enabled = false;
                    //20120309 MODIFY BY MAUREEN REASON:修改alert訊息
                    //RegisterScript("alert('徵信核准成功！');");
                    RegisterScript("alert('儲存成功！');");
                }
                else if (LSTR_SaveType == "4A")
                {
                    this.cmdPrintReportB.Enabled = false;
                    this.btnSaveSure.Enabled = false;
                    //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                    this.btnReturnChk.Enabled = false;
                    //this.btnSaveTemp.Enabled = false;
                    //this.btnSubmit.Enabled = false;
                    //this.btnRegect.Enabled = false;
                    //this.btnWj.Enabled = false;
                    //this.btnSelect.Enabled = false;
                    //20120309 MODIFY BY MAUREEN REASON:修改alert訊息
                    //RegisterScript("alert('徵信退件成功！');");
                    RegisterScript("alert('儲存成功！');");
                }
                else if (LSTR_SaveType == "4B")
                {
                    this.cmdPrintReportB.Enabled = true;
                    this.btnSaveSure.Enabled = false;
                    //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                    this.btnReturnChk.Enabled = false;
                    //this.btnSaveTemp.Enabled = false;
                    //this.btnSubmit.Enabled = false;
                    //this.btnRegect.Enabled = false;
                    //this.btnWj.Enabled = false;
                    //this.btnSelect.Enabled = false;
                    //20120309 MODIFY BY MAUREEN REASON:修改alert訊息
                    //RegisterScript("alert('徵信婉拒成功！');");
                    RegisterScript("alert('儲存成功！');");
                }
                else if (LSTR_SaveType == "4C")
                {
                    this.cmdPrintReportB.Enabled = true;
                    this.btnSaveSure.Enabled = false;
                    //Modify 20130722 BY SS Adam Reason:案件退回跟隨確認按鈕的反灰判斷
                    this.btnReturnChk.Enabled = false;
                    //this.btnSaveTemp.Enabled = false;
                    //this.btnSubmit.Enabled = false;
                    //this.btnRegect.Enabled = false;
                    //this.btnWj.Enabled = false;
                    //this.btnSelect.Enabled = false;
                    //20120309 MODIFY BY MAUREEN REASON:修改alert訊息
                    //RegisterScript("alert('徵信附條件成功！');");
                    RegisterScript("alert('儲存成功！');");
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


    //Modify 20130107 By SS Maureen. Reason: 儲存不動產設定GRID資料.
    protected void btnSaveImmov_Click(object sender, EventArgs e)
    {
        StringBuilder LSTR_Data = new StringBuilder();
        string LSTR_CASEID = this.txtCASEID.Text.Trim();
        //更新刪除註記
        //=========================================================================
        LSTR_Data = new StringBuilder();
        LSTR_Data.Append("SP_ML2001A_U03" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
        LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        //不動產設定
        //MLDIMMOVABLEDF
        if (rptMLDIMMOVABLEDF.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDIMMOVABLEDF.Items.Count; i++)
            {
                if (((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEOWNER_D")).Text.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML2001A_U01" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                string LSTR_IMMOVABLEID = ((HiddenField)rptMLDIMMOVABLEDF.Items[i].FindControl("hidIMMOVABLEID_D")).Value.ToString();
                if (string.IsNullOrEmpty(LSTR_IMMOVABLEID))
                {
                    string LSTR_Guid = Itg.Community.Util.GetIDSequence("MLDIMMOVABLEDF", "12");
                    LSTR_Data.Append(LSTR_Guid + GSTR_TabDelimitChar);
                    ((HiddenField)rptMLDIMMOVABLEDF.Items[i].FindControl("hidIMMOVABLEID_D")).Value = LSTR_Guid;
                }
                else
                {
                    LSTR_Data.Append(LSTR_IMMOVABLEID + GSTR_TabDelimitChar);
                }
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEOWNER_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEOWNERID_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEGETDATE_D")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDDATE_D")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLESECTOR_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILD_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEAREA_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEHOLDER_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDNO_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEHOUSENUM_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDAREA_D")).Text + GSTR_TabDelimitChar);
                string LSTR_Area = ((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDAREA_D")).Text.ToString();
                double LINT_Area = LSTR_Area == "" ? 0 : Convert.ToDouble(LSTR_Area);
                ((Label)rptMLDIMMOVABLEDF.Items[i].FindControl("lblIMMOVABLEBUILDAREA_D")).Text = (LINT_Area * 0.3025).ToString("0.00");

                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEBUILDHOLD_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((DropDownList)rptMLDIMMOVABLEDF.Items[i].FindControl("drpIMMOVABLECASEPAWN_D")).SelectedValue + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEPAWNSTATUS_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDIMMOVABLEDF.Items[i].FindControl("txtIMMOVABLEPURPOSE_D")).Text + GSTR_TabDelimitChar);

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
        //案件申請不動產權利人明細
        //MLDHUMANRIGHTS
        if (rptMLDIMMOVABLEDF.Items.Count > 0)
        {
            for (int i = 0; i < this.rptMLDIMMOVABLEDF.Items.Count; i++)
            {
                if (((HiddenField)rptMLDIMMOVABLEDF.Items[i].FindControl("hidIMMOVABLEID_D")).Value.Trim() == "")
                {
                    continue;
                }
                LSTR_Data.Append("SP_ML2001A_U02" + GSTR_ColDelimitChar);
                LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
                LSTR_Data.Append(((HiddenField)rptMLDIMMOVABLEDF.Items[i].FindControl("hidIMMOVABLEID_D")).Value.ToString() + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtHUMANRIGHTS_D")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtREGISTDATE_D")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtSETPRICE_D")).Text) + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDHUMANRIGHTS_D.Items[i].FindControl("txtCREDITOR_D")).Text + GSTR_TabDelimitChar);
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
            ReturnObject<object> LOBJ_ReturnObject = SaveCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab66Caption";
                PageDataBind();
                Alert("儲存不動產資料成功！");
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
        this.UpdatePanelMLDIMMOVABLEDF.Update();
        this.UpdatePanelMLDHUMANRIGHTS.Update();
        //this.UpdatePanel1.Update();

    }

    //Modify 20130107 By SS Maureen. Reason: 不動產設定GRID匯出EXCEL.
    private ReturnObject<DataTable> GetExcelData(string LSTR_CASEID)
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
            LVAR_Parameter[0] = "SP_ML2001B_Q04";
            LVAR_Parameter[1] = "'" + LSTR_CASEID + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    //Modify 20130107 By SS Maureen. Reason: 不動產設定GRID匯出EXCEL.  
    protected void cmdExport_Click(object sender, EventArgs e)
    {
        try
        {
            string LSTR_IMMOVABLEOWNER = "";
            string LSTR_IMMOVABLECASEPAWN = "";
            string LSTR_LOCATION = "";
            string LSTR_IMMOVABLEBUILDDATE = "";
            string LSTR_IMMOVABLEGETDATE = "";
            string LSTR_MEASURE = "";
            string LSTR_IMMOVABLEPAWNSTATUS = "";
            string LSTR_IMMOVABLEPURPOSE = "";

            ReturnObject<DataTable> LOBJ_Return;
            LOBJ_Return = GetExcelData(this.txtCASEID.Text.Trim());

            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                DataTable LDAT_Data = LOBJ_Return.ReturnData;
                DataTable LOBJ_TData = LDAT_Data.Copy();
                DataRow LOBJ_DataRow = null;
                int INT_ICount = 0;

                if (LDAT_Data.Rows.Count > 0)
                {
                    for (int i = 0; i < LDAT_Data.Rows.Count; i++)
                    {
                        LSTR_IMMOVABLEOWNER += LDAT_Data.Rows[i]["IMMOVABLEOWNER"].ToString();
                        LSTR_IMMOVABLECASEPAWN += LDAT_Data.Rows[i]["IMMOVABLECASEPAWN"].ToString();
                        LSTR_LOCATION += LDAT_Data.Rows[i]["LOCATION"].ToString();
                        LSTR_IMMOVABLEBUILDDATE += LDAT_Data.Rows[i]["IMMOVABLEBUILDDATE"].ToString();
                        LSTR_IMMOVABLEGETDATE += LDAT_Data.Rows[i]["IMMOVABLEGETDATE"].ToString();
                        LSTR_MEASURE += LDAT_Data.Rows[i]["MEASURE"].ToString();
                        LSTR_IMMOVABLEPAWNSTATUS += LDAT_Data.Rows[i]["IMMOVABLEPAWNSTATUS"].ToString();
                        LSTR_IMMOVABLEPURPOSE = LDAT_Data.Rows[i]["IMMOVABLEPURPOSE"].ToString();
                        INT_ICount += 1;
                        //Alert(LSTR_IMMOVABLEOWNER+"；"+LSTR_IMMOVABLECASEPAWN+"；"+LSTR_LOCATION+"；"+LSTR_IMMOVABLEBUILDDATE+"；"+LSTR_IMMOVABLEGETDATE+"；"+LSTR_MEASURE+"；"+LSTR_IMMOVABLEPAWNSTATUS+"；"+LSTR_IMMOVABLEPURPOSE);
                    }

                    LOBJ_DataRow = LOBJ_TData.NewRow();
                    LOBJ_DataRow["IMMOVABLEOWNER"] = "備註";
                    LOBJ_DataRow["IMMOVABLECASEPAWN"] = "";
                    LOBJ_DataRow["LOCATION"] = "";
                    LOBJ_DataRow["IMMOVABLEBUILDDATE"] = "";
                    LOBJ_DataRow["IMMOVABLEGETDATE"] = "";

                    LOBJ_DataRow["MEASURE"] = "";
                    LOBJ_DataRow["IMMOVABLEPAWNSTATUS"] = "";
                    LOBJ_DataRow["IMMOVABLEPURPOSE"] = "";
                    LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, INT_ICount);
                    //INT_ICount += 1;
                }
                else
                {
                    LOBJ_DataRow = LOBJ_TData.NewRow();
                    LOBJ_DataRow["IMMOVABLEOWNER"] = "無資料";
                    LOBJ_DataRow["IMMOVABLECASEPAWN"] = "";
                    LOBJ_DataRow["LOCATION"] = "";
                    LOBJ_DataRow["IMMOVABLEBUILDDATE"] = "";
                    LOBJ_DataRow["IMMOVABLEGETDATE"] = "";

                    LOBJ_DataRow["MEASURE"] = "";
                    LOBJ_DataRow["IMMOVABLEPAWNSTATUS"] = "";
                    LOBJ_DataRow["IMMOVABLEPURPOSE"] = "";
                    INT_ICount += 1;
                    LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, INT_ICount);

                }

                GridView GridView1 = new GridView();
                GridView1.DataSource = LOBJ_TData;
                GridView1.DataBind();

                //設定EXCEL表頭中文
                GridView1.HeaderRow.Cells[0].Text = "所有權人";
                GridView1.HeaderRow.Cells[1].Text = "本案抵押";
                GridView1.HeaderRow.Cells[2].Text = "座落表示";
                GridView1.HeaderRow.Cells[3].Text = "興建日期";
                GridView1.HeaderRow.Cells[4].Text = "取得日期";
                GridView1.HeaderRow.Cells[5].Text = "面積(坪)持分/全部";
                GridView1.HeaderRow.Cells[6].Text = "抵押情形";
                GridView1.HeaderRow.Cells[7].Text = "用途";

                //TableCell oldTc = GridView1.Rows[INT_ICount].Cells[1];
                //oldTc.Visible = false;
                //oldTc.ColumnSpan = 7;


                System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                GridView1.RenderControl(oHtmlTextWriter);
                StreamWriter sw = new StreamWriter(Server.MapPath("ML2001A.xls"));
                sw.Write(oStringWriter.ToString());
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "excel", "location.href='ML2001B.xls'", true);
                sw.Close();
                sw.Dispose();

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

    //Modify 20130107 By SS Maureen. Reason: 不動產設定GRID匯出EXCEL.
    public override void VerifyRenderingInServerForm(Control control)
    { }

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

    // 20131008 Edit by SEAN 已徵審完成的案件也可上傳徵信檔案
    protected void btnUploadSave_Click(object sender, EventArgs e)
    {
        StringBuilder LSTR_Data = new StringBuilder();
        //案件主鍵
        //=========================================================================
        LSTR_Data.Append("SP_ML2001A_U04" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.hidCREDITFILEID.Value + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCREDITFILENAME.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                //  this.hidShowTag.Value = "fraTab11Caption";
                RegisterScript("alert('上傳成功！');");
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

    //Leo 2013/11/13  進件條件擔保價值
    private void drpGuanValueBind()
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
                this.drpGuanValue.DataSource = LOBJ_Return.ReturnData;
                this.drpGuanValue.DataValueField = "MCODE";
                this.drpGuanValue.DataTextField = "MNAME1";
                this.drpGuanValue.DataBind();
                this.drpGuanValue.Items[0].Text = "請選擇";
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

    //UPD BY VICKY 20140627 實貸金額權限
    private void drpACTUSLLOANSAUTHDefault()
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
            LVAR_Parameter[0] = "SP_ML2001A_Q06";
            LVAR_Parameter[1] = this.txtCASEID.Text.Trim();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                DataTable LOBJ_Data = LOBJ_Return.ReturnData;
                this.drpACTUSLLOANSAUTH.SelectedValue = LOBJ_Data.Rows[0]["RTNCODE"].ToString(); //設預設值
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


    protected void btnCREDITFILEmaintain_Click(object sender, EventArgs e)
    {
        string s = "";
        s += "window.showModalDialog('../LE.NET/ML20/ML2008.aspx?PRGID=ML2008&CASEID=" + txtCASEID.Text + "','','dialogHeight:700px;dialogWidth:850px;');";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "open", s, true);
    }


    protected void setMemo(object sender, EventArgs e)
    {
        //20150629 ADD BY SS EDWARD.增加重車專案別
        if (drpIRRAUTH.SelectedValue == "")
        {
            Alert("請先選擇 [IRR權限] !!");
            drpIRRAUTH.Focus();
            return;
        }

        //txtCUSTNOWCAPTIAL
        string[,] aryIRR = null;
        int y = 0;
        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE.SelectedValue == "02" && ddlOPERATION.SelectedValue != "01")
        {
            if (ddlECONDITION.Items.FindByValue("") != null)
                ddlECONDITION.SelectedValue = "";

            if (ddlDEVICETYPE.Items.FindByValue("") != null)
                ddlDEVICETYPE.SelectedValue = "";

            ddlECONDITION.Enabled = false;
            ddlDEVICETYPE.Enabled = false;
        }
        else
        {
            ddlECONDITION.Enabled = true;
            ddlDEVICETYPE.Enabled = true;
        }

        //20150701 ADD BY SS EWD REASON.新增重車交易邏輯
        if (drpPROJCD.SelectedValue == "02")
        {
            if ((ddlFUNDSUSE.SelectedValue == "01" && ddlOPERATION.SelectedValue != "" && ddlDEVICETYPE.SelectedValue != "" && ddlECONDITION.SelectedValue != "") ||
                (ddlFUNDSUSE.SelectedValue == "02" && ddlOPERATION.SelectedValue != ""))
            {
                //txtSIGNMEMO.Text = "本案屬"
                //                  + ((ddlFUNDSUSE == null) ? "" : ddlFUNDSUSE.SelectedItem.Text + "，")
                //                  + ((ddlOPERATION.SelectedIndex == 0) ? "" : ddlOPERATION.SelectedItem.Text)
                //                  + ((ddlECONDITION.SelectedIndex == 0) ? "" : ddlECONDITION.SelectedItem.Text)
                //                  + ((ddlDEVICETYPE.SelectedIndex == 0) ? "" : ddlDEVICETYPE.SelectedItem.Text)
                //                  + ((ddlECONDITION.SelectedIndex == 0) ? "" : ("，IRR應為 " + ((ddlECONDITION.SelectedValue == "01") ? "3.5%" : "4.5%")))     //設備狀態 新機3.5%   中古機4.5% (資金用途與操作模式不影響%)
                //                  + "，分期部門副總經理可減-0.5%，本案IRR " + txtIRR.Text.Trim() + "%"
                //                  + ((drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為" + drpIRRAUTH.SelectedItem.Text + "簽核權限。");

                //20221102 備註文字修正
                txtSIGNMEMO.Text = "本案屬"
                + ((ddlFUNDSUSE == null) ? "" : ddlFUNDSUSE.SelectedItem.Text + "，")
                + ((ddlOPERATION.SelectedIndex == 0) ? "" : ddlOPERATION.SelectedItem.Text)
                + ((ddlECONDITION.SelectedIndex == 0) ? "" : ddlECONDITION.SelectedItem.Text)
                + ((ddlDEVICETYPE.SelectedIndex == 0) ? "" : ddlDEVICETYPE.SelectedItem.Text)
                + ((ddlECONDITION.SelectedIndex == 0) ? "" : ""
                + ((drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為"
                + ((int.Parse(drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(drpIRRAUTH.SelectedValue)) ? drpACTUSLLOANSAUTH.SelectedItem.Text : drpIRRAUTH.SelectedItem.Text)
                + "簽核權限。"));
            }
            else
            {
                txtSIGNMEMO.Text = "";
            }
        }
        else
        {
            //20141218 ADD BY SS ADAM REASON.調整實體交易跟非實體交易邏輯
            // 實體交易
            if (ddlFUNDSUSE.SelectedValue == "01" && ddlOPERATION.SelectedValue != "" && ddlDEVICETYPE.SelectedValue != "" && ddlECONDITION.SelectedValue != "")
            {
                if (ddlECONDITION.SelectedValue == "01")
                    aryIRR = aryIRR1;
                else
                    aryIRR = aryIRR2;
                y = int.Parse(ddlDEVICETYPE.SelectedValue);

                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                //txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + ddlOPERATION.SelectedItem.Text + ddlDEVICETYPE.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + ddlOPERATION.SelectedItem.Text + ddlDEVICETYPE.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + drpIRRAUTH.SelectedItem.Text + "簽核權限。";

                //20221102 比較實貸金額與IRR權限，誰權限大文字帶誰
                //20221102 備註文字修正
                txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + ddlOPERATION.SelectedItem.Text + ddlDEVICETYPE.SelectedItem.Text + "案件，為"
                    + ((int.Parse(drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(drpIRRAUTH.SelectedValue)) ? drpACTUSLLOANSAUTH.SelectedItem.Text : drpIRRAUTH.SelectedItem.Text)
                    + "簽核權限。";
            }
            //非實體交易
            else if (ddlFUNDSUSE.SelectedValue == "02" && ddlOPERATION.SelectedValue != "")
            {
                if (float.Parse(txtGRTVAL.Text.Trim() == "" ? "0" : txtGRTVAL.Text.Trim()) >= 50)
                    aryIRR = aryIRR3;
                else
                    aryIRR = aryIRR4;

                //20150330 ADD BY SS ADAM REASON.INT 改為FLOAT
                float CUSTNOWCAPTIAL = float.Parse(txtCUSTNOWCAPTIAL.Text.Replace(",", ""));
                if (CUSTNOWCAPTIAL < 10000000)
                    y = 1;
                else
                    y = 2;

                if (CUSTNOWCAPTIAL >= 80000000)
                    y = 3;

                if (CUSTNOWCAPTIAL >= 200000000)
                    y = 4;

                //UPD BY JBLEO 20141212 敘述增加資本額為、擔保價值為
                //txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + "，資本額為" +txtCUSTNOWCAPTIAL.Text +"的"+ ddlOPERATION.SelectedItem.Text + "案件，" + "擔保價值為" +txtGRTVAL.Text + "%，IRR應為" + aryIRR[int.Parse(ddlOPERATION.SelectedValue), y] + "，營業主管可減-3%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                //txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + "，資本額為" + txtCUSTNOWCAPTIAL.Text + "的" + ddlOPERATION.SelectedItem.Text + "案件，" + "擔保價值為" + txtGRTVAL.Text + "%，IRR應為" + aryIRR[int.Parse(ddlOPERATION.SelectedValue), y] + "，營業主管可減-3%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + drpIRRAUTH.SelectedItem.Text + "簽核權限。";

                //20221102 比較實貸金額與IRR權限，誰權限大文字帶誰
                //20221102 備註文字修正
                txtSIGNMEMO.Text = "本案屬" + ddlFUNDSUSE.SelectedItem.Text + "，資本額為" + txtCUSTNOWCAPTIAL.Text + "的" + ddlOPERATION.SelectedItem.Text + "案件，" + "擔保價值為" + txtGRTVAL.Text + "%，為"
                    + ((int.Parse(drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(drpIRRAUTH.SelectedValue)) ? drpACTUSLLOANSAUTH.SelectedItem.Text : drpIRRAUTH.SelectedItem.Text)
                    + "簽核權限。";
            }
            else
            {
                txtSIGNMEMO.Text = "";
            }
        }
    }

    protected void setMemo2(object sender, EventArgs e)
    {
        //20150629 ADD BY SS EDWARD.增加重車專案別
        if (tab8_drpIRRAUTH.SelectedValue == "")
        {
            Alert("請先選擇 [IRR權限] !!");
            tab8_drpIRRAUTH.Focus();
            return;
        }

        //txtCUSTNOWCAPTIAL
        string[,] aryIRR = null;
        int y = 0;
        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE_R.SelectedValue == "02" && ddlOPERATION_R.SelectedValue != "01")
        {
            if (ddlCONDITION_R.Items.FindByValue("") != null)
                ddlCONDITION_R.SelectedValue = "";

            if (ddlDEVICETYPE_R.Items.FindByValue("") != null)
                ddlDEVICETYPE_R.SelectedValue = "";

            ddlCONDITION_R.Enabled = false;
            ddlDEVICETYPE_R.Enabled = false;
        }
        else
        {
            ddlCONDITION_R.Enabled = true;
            ddlDEVICETYPE_R.Enabled = true;
        }

        //20150701 ADD BY SS EWD REASON.新增重車交易邏輯
        if (drpPROJCD.SelectedValue == "02")
        {
            if ((ddlFUNDSUSE_R.SelectedValue == "01" && ddlOPERATION_R.SelectedValue != "" && ddlDEVICETYPE_R.SelectedValue != "" && ddlCONDITION_R.SelectedValue != "") ||
                (ddlFUNDSUSE_R.SelectedValue == "02" && ddlOPERATION_R.SelectedValue != ""))
            {
                //txtSIGNMEMO_R.Text = "本案屬"
                //                  + ((ddlFUNDSUSE_R == null) ? "" : ddlFUNDSUSE_R.SelectedItem.Text + "，")
                //                  + ((ddlOPERATION_R.SelectedIndex == 0) ? "" : ddlOPERATION_R.SelectedItem.Text)
                //                  + ((ddlCONDITION_R.SelectedIndex == 0) ? "" : ddlCONDITION_R.SelectedItem.Text)
                //                  + ((ddlDEVICETYPE_R.SelectedIndex == 0) ? "" : ddlDEVICETYPE_R.SelectedItem.Text)
                //                  + ((ddlCONDITION_R.SelectedIndex == 0) ? "" : ("，IRR應為 " + ((ddlCONDITION_R.SelectedValue == "01") ? "3.5%" : "4.5%")))     //設備狀態 新機3.5%   中古機4.5% (資金用途與操作模式不影響%)
                //                  + "，分期部門副總經理可減-0.5%，本案IRR " + txtIRR.Text.Trim() + "%"
                //                  + ((tab8_drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為" + tab8_drpIRRAUTH.SelectedItem.Text + "簽核權限。");

                //20221102 備註文字修正
                txtSIGNMEMO_R.Text = "本案屬"
                      + ((ddlFUNDSUSE_R == null) ? "" : ddlFUNDSUSE_R.SelectedItem.Text + "，")
                      + ((ddlOPERATION_R.SelectedIndex == 0) ? "" : ddlOPERATION_R.SelectedItem.Text)
                      + ((ddlCONDITION_R.SelectedIndex == 0) ? "" : ddlCONDITION_R.SelectedItem.Text)
                      + ((ddlDEVICETYPE_R.SelectedIndex == 0) ? "" : ddlDEVICETYPE_R.SelectedItem.Text)
                      + ((ddlCONDITION_R.SelectedIndex == 0) ? "" : ""
                      + ((tab8_drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為"
                      + ((int.Parse(tab8_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab8_drpIRRAUTH.SelectedValue)) ? tab8_drpACTUSLLOANSAUTH.SelectedItem.Text : tab8_drpIRRAUTH.SelectedItem.Text)
                      + "簽核權限。"));

            }
            else
            {
                txtSIGNMEMO_R.Text = "";
            }
        }
        else
        {

            //20141218 ADD BY SS ADAM REASON.調整實體交易跟非實體交易邏輯
            // 實體交易
            if (ddlFUNDSUSE_R.SelectedValue == "01" && ddlOPERATION_R.SelectedValue != "" && ddlDEVICETYPE_R.SelectedValue != "" && ddlCONDITION_R.SelectedValue != "")
            {

                if (ddlCONDITION_R.SelectedValue == "01")
                    aryIRR = aryIRR1;
                else
                    aryIRR = aryIRR2;
                y = int.Parse(ddlDEVICETYPE_R.SelectedValue);

                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                //txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text + ddlOPERATION_R.SelectedItem.Text + ddlDEVICETYPE_R.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION_R.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab8_drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text + ddlOPERATION_R.SelectedItem.Text + ddlDEVICETYPE_R.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION_R.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab8_drpIRRAUTH.SelectedItem.Text + "簽核權限。";

                //20221102 比較實貸金額與IRR權限，誰權限大文字帶誰
                //20221102 備註文字修正
                txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text + ddlOPERATION_R.SelectedItem.Text + ddlDEVICETYPE_R.SelectedItem.Text + "案件，為"
                    + ((int.Parse(tab8_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab8_drpIRRAUTH.SelectedValue)) ? tab8_drpACTUSLLOANSAUTH.SelectedItem.Text : tab8_drpIRRAUTH.SelectedItem.Text)
                    + "簽核權限。";
            }
            //非實體交易
            else if (ddlFUNDSUSE_R.SelectedValue == "02" && ddlOPERATION_R.SelectedValue != "")
            {
                if (float.Parse(txtGRTVAL_R.Text.Trim() == "" ? "0" : txtGRTVAL_R.Text.Trim()) >= 50)
                    aryIRR = aryIRR3;
                else
                    aryIRR = aryIRR4;

                //20150330 ADD BY SS ADAM REASON.INT 改為FLOAT
                float CUSTNOWCAPTIAL = float.Parse(txtCUSTNOWCAPTIAL.Text.Replace(",", ""));
                if (CUSTNOWCAPTIAL < 10000000)
                    y = 1;
                else
                    y = 2;

                if (CUSTNOWCAPTIAL >= 80000000)
                    y = 3;

                if (CUSTNOWCAPTIAL >= 200000000)
                    y = 4;

                //UPD BY JBLEO 20141212 敘述增加資本額為、擔保價值為
                //txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text +"，資本額為"+ txtCUSTNOWCAPTIAL.Text +"的"+ ddlOPERATION_R.SelectedItem.Text + "案件，" +"擔保價值為" +txtGRTVAL_R.Text + "%，IRR應為" + aryIRR[int.Parse(ddlOPERATION_R.SelectedValue), y] + "，營業主管可減-3%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab8_drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text + "，資本額為" + txtCUSTNOWCAPTIAL.Text + "的" + ddlOPERATION_R.SelectedItem.Text + "案件，" + "擔保價值為" + txtGRTVAL_R.Text + "%，為"
                      + ((int.Parse(tab8_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab8_drpIRRAUTH.SelectedValue)) ? tab8_drpACTUSLLOANSAUTH.SelectedItem.Text : tab8_drpIRRAUTH.SelectedItem.Text)
                      + "簽核權限。";
            }
            else  //都不是則清空
            {
                txtSIGNMEMO_R.Text = "";
            }
        }
    }
    protected void setMemo3(object sender, EventArgs e)
    {
        //20150629 ADD BY SS EDWARD.增加重車專案別
        if (tab9_drpIRRAUTH.SelectedValue == "")
        {
            Alert("請先選擇 [IRR權限] !!");
            tab9_drpIRRAUTH.Focus();
            return;
        }

        //txtCUSTNOWCAPTIAL
        string[,] aryIRR = null;
        int y = 0;
        //20141218 ADD BY SS ADAM REASON.非實體交易且操作模式非設備案件，設備狀態跟設備類型須反灰
        if (ddlFUNDSUSE_TAB9.SelectedValue == "02" && ddlOPERATION_TAB9.SelectedValue != "01")
        {
            if (ddlCONDITION_TAB9.Items.FindByValue("") != null)
                ddlCONDITION_TAB9.SelectedValue = "";

            if (ddlDEVICETYPE_TAB9.Items.FindByValue("") != null)
                ddlDEVICETYPE_TAB9.SelectedValue = "";

            ddlCONDITION_TAB9.Enabled = false;
            ddlDEVICETYPE_TAB9.Enabled = false;
        }
        else
        {
            ddlCONDITION_TAB9.Enabled = true;
            ddlDEVICETYPE_TAB9.Enabled = true;
        }

        //20150701 ADD BY SS EWD REASON.新增重車交易邏輯
        if (drpPROJCD.SelectedValue == "02")
        {
            if ((ddlFUNDSUSE_TAB9.SelectedValue == "01" && ddlOPERATION_TAB9.SelectedValue != "" && ddlDEVICETYPE_TAB9.SelectedValue != "" && ddlCONDITION_TAB9.SelectedValue != "") ||
                (ddlFUNDSUSE_TAB9.SelectedValue == "02" && ddlOPERATION_TAB9.SelectedValue != ""))
            {
                //txtSIGNMEMO_TAB9.Text = "本案屬"
                //                  + ((ddlFUNDSUSE_TAB9 == null) ? "" : ddlFUNDSUSE_TAB9.SelectedItem.Text + "，")
                //                  + ((ddlOPERATION_TAB9.SelectedIndex == 0) ? "" : ddlOPERATION_TAB9.SelectedItem.Text)
                //                  + ((ddlCONDITION_TAB9.SelectedIndex == 0) ? "" : ddlCONDITION_TAB9.SelectedItem.Text)
                //                  + ((ddlDEVICETYPE_TAB9.SelectedIndex == 0) ? "" : ddlDEVICETYPE_TAB9.SelectedItem.Text)
                //                  + ((ddlCONDITION_TAB9.SelectedIndex == 0) ? "" : ("，IRR應為 " + ((ddlCONDITION_TAB9.SelectedValue == "01") ? "3.5%" : "4.5%")))     //設備狀態 新機3.5%   中古機4.5% (資金用途與操作模式不影響%)
                //                  + "，分期部門副總經理可減-0.5%，本案IRR " + txtIRR.Text.Trim() + "%"
                //                  + ((tab9_drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為" + tab9_drpIRRAUTH.SelectedItem.Text + "簽核權限。");

                //20221102 備註文字修正
                txtSIGNMEMO_TAB9.Text = "本案屬"
                        + ((ddlFUNDSUSE_TAB9 == null) ? "" : ddlFUNDSUSE_TAB9.SelectedItem.Text + "，")
                        + ((ddlOPERATION_TAB9.SelectedIndex == 0) ? "" : ddlOPERATION_TAB9.SelectedItem.Text)
                        + ((ddlCONDITION_TAB9.SelectedIndex == 0) ? "" : ddlCONDITION_TAB9.SelectedItem.Text)
                        + ((ddlDEVICETYPE_TAB9.SelectedIndex == 0) ? "" : ddlDEVICETYPE_TAB9.SelectedItem.Text)
                        + ((ddlCONDITION_TAB9.SelectedIndex == 0) ? "" : ""
                        + ((tab9_drpIRRAUTH.SelectedIndex == 0) ? "。" : "，為"
                        + ((int.Parse(tab9_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab9_drpIRRAUTH.SelectedValue)) ? tab9_drpACTUSLLOANSAUTH.SelectedItem.Text : tab9_drpIRRAUTH.SelectedItem.Text)
                        + "簽核權限。"));
            }
            else
            {
                txtSIGNMEMO_TAB9.Text = "";
            }
        }
        else
        {

            //20141218 ADD BY SS ADAM REASON.調整實體交易跟非實體交易邏輯
            // 實體交易
            if (ddlFUNDSUSE_TAB9.SelectedValue == "01" && ddlOPERATION_TAB9.SelectedValue != "" && ddlDEVICETYPE_TAB9.SelectedValue != "" && ddlCONDITION_TAB9.SelectedValue != "")
            {

                if (ddlCONDITION_TAB9.SelectedValue == "01")
                    aryIRR = aryIRR1;
                else
                    aryIRR = aryIRR2;
                y = int.Parse(ddlDEVICETYPE_TAB9.SelectedValue);

                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                //txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text + ddlOPERATION_R.SelectedItem.Text + ddlDEVICETYPE_R.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION_R.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab8_drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //txtSIGNMEMO_TAB9.Text = "本案屬" + ddlFUNDSUSE_TAB9.SelectedItem.Text + ddlOPERATION_TAB9.SelectedItem.Text + ddlDEVICETYPE_TAB9.SelectedItem.Text + "案件，IRR應為" + aryIRR[int.Parse(ddlOPERATION_TAB9.SelectedValue), y] + "，營業主管可減-1.5%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab9_drpIRRAUTH.SelectedItem.Text + "簽核權限。";

                //20221102 比較實貸金額與IRR權限，誰權限大文字帶誰
                //20221102 備註文字修正
                txtSIGNMEMO_TAB9.Text = "本案屬" + ddlFUNDSUSE_TAB9.SelectedItem.Text + ddlOPERATION_TAB9.SelectedItem.Text + ddlDEVICETYPE_TAB9.SelectedItem.Text + "案件，為"
                    + ((int.Parse(tab9_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab9_drpIRRAUTH.SelectedValue)) ? tab9_drpACTUSLLOANSAUTH.SelectedItem.Text : tab9_drpIRRAUTH.SelectedItem.Text)
                    + "簽核權限。";

            }
            //非實體交易
            else if (ddlFUNDSUSE_TAB9.SelectedValue == "02" && ddlOPERATION_TAB9.SelectedValue != "")
            {
                if (float.Parse(txtGRTVAL_TAB9.Text.Trim() == "" ? "0" : txtGRTVAL_TAB9.Text.Trim()) >= 50)
                    aryIRR = aryIRR3;
                else
                    aryIRR = aryIRR4;

                //20150330 ADD BY SS ADAM REASON.INT 改為FLOAT
                float CUSTNOWCAPTIAL = float.Parse(txtCUSTNOWCAPTIAL.Text.Replace(",", ""));
                if (CUSTNOWCAPTIAL < 10000000)
                    y = 1;
                else
                    y = 2;

                if (CUSTNOWCAPTIAL >= 80000000)
                    y = 3;

                if (CUSTNOWCAPTIAL >= 200000000)
                    y = 4;

                //UPD BY JBLEO 20141212 敘述增加資本額為、擔保價值為
                //txtSIGNMEMO_R.Text = "本案屬" + ddlFUNDSUSE_R.SelectedItem.Text +"，資本額為"+ txtCUSTNOWCAPTIAL.Text +"的"+ ddlOPERATION_R.SelectedItem.Text + "案件，" +"擔保價值為" +txtGRTVAL_R.Text + "%，IRR應為" + aryIRR[int.Parse(ddlOPERATION_R.SelectedValue), y] + "，營業主管可減-3%，本案IRR為" + txtIRR.Text.Trim() + "%，為" + tab8_drpACTUSLLOANSAUTH.SelectedItem.Text + "簽核權限。";
                //20150105 ADD BY SS ADAM REASON.原為實貸金額權限改為IRR權限
                txtSIGNMEMO_TAB9.Text = "本案屬" + ddlFUNDSUSE_TAB9.SelectedItem.Text + "，資本額為" + txtCUSTNOWCAPTIAL.Text + "的" + ddlOPERATION_TAB9.SelectedItem.Text + "案件，" + "擔保價值為" + txtGRTVAL_TAB9.Text + "%，為"
                      + ((int.Parse(tab9_drpACTUSLLOANSAUTH.SelectedValue) >= int.Parse(tab9_drpIRRAUTH.SelectedValue)) ? tab9_drpACTUSLLOANSAUTH.SelectedItem.Text : tab9_drpIRRAUTH.SelectedItem.Text)
                      + "簽核權限。";


            }
            else  //都不是則清空
            {
                txtSIGNMEMO_TAB9.Text = "";
            }
        }
    }
    protected void ddlFUNDSUSE_SelectedIndexChanged(object sender, EventArgs e)
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
            DropDownList ddl = (DropDownList)sender;
            if (ddl.SelectedValue == "01")
                LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A5" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            else
                LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "A7" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);

            if (LOBJ_Return.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_Return.ReturnData;
                if (sender.Equals(ddlFUNDSUSE))
                {
                    //20150629 ADD BY SS EDWARD.增加重車專案別
                    DataTable newDT = LDST_Data.Tables[0].Copy();
                    DataView newDV = new DataView(newDT);
                    if (drpPROJCD.SelectedValue == "02" && ddlFUNDSUSE.SelectedValue == "02")   //02重車 02非實體交易 只有一個選項-設備案件
                    {
                        for (int i = newDV.Table.Rows.Count - 1; i > 1; i--)
                        {
                            newDV.Table.Rows.RemoveAt(i);
                        }
                    }
                    this.ddlOPERATION.DataSource = newDV;     // LDST_Data.Tables[0].DefaultView;
                    this.ddlOPERATION.DataBind();

                    if (ddlFUNDSUSE.SelectedValue == "01")
                    {
                        ddlECONDITION.Enabled = true;
                        ddlDEVICETYPE.Enabled = true;
                    }

                    //20150629 ADD BY SS EDWARD.增加重車專案別
                    //if (drpIRRAUTH.SelectedValue == "")
                    //{
                    //    Alert("請先選擇 [IRR權限] !!");
                    //    drpIRRAUTH.Focus();
                    //}
                }
                else if (sender.Equals(ddlFUNDSUSE_R))
                {
                    this.ddlOPERATION_R.DataSource = LDST_Data.Tables[0].DefaultView;
                    this.ddlOPERATION_R.DataBind();

                    if (ddlFUNDSUSE_R.SelectedValue == "01")
                    {
                        ddlCONDITION_R.Enabled = true;
                        ddlDEVICETYPE_R.Enabled = true;
                    }
                }
                else
                {
                    this.ddlOPERATION_TAB9.DataSource = LDST_Data.Tables[0].DefaultView;
                    this.ddlOPERATION_TAB9.DataBind();

                    if (ddlFUNDSUSE_TAB9.SelectedValue == "01")
                    {
                        ddlCONDITION_TAB9.Enabled = true;
                        ddlDEVICETYPE_TAB9.Enabled = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //20141218 ADD BY SS ADAM REASON.增加覆核區塊存檔
    protected void btnSaveSureTab8_Click(object sender, EventArgs e)
    {
        MLMCASESaveTab8();
    }

    protected void MLMCASESaveTab8()
    {
        StringBuilder LSTR_Data = new StringBuilder();

        //20140108 ADD BY SS ADAM Reason.增加覆核建議存檔
        LSTR_Data.Append("SP_ML2001A_I05" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        if (tab8_tbxCREDITCNFDT_YMD.Text != "")
        {
            LSTR_Data.Append(tab8_tbxCREDITCNFDT_YMD.Text + " " + tab8_tbxCREDITCNFDT_HS.Text + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(GSTR_TabDelimitChar);
        }
        if (tab8_tbxCREDITFINDT_YMD.Text != "")
        {
            LSTR_Data.Append(tab8_tbxCREDITFINDT_YMD.Text + " " + tab8_tbxCREDITFINDT_HS.Text + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(tab8_ddlPROPOSEDSIGN.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab8_ddlCREDITSUGGEST.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab8_CREDITDESC.Text.Replace("\r\n", "<br>"));

        //UPD BY VICKY 20140630 新增[覆核徵審人員][覆核實貸金額權限][覆核IRR權限]
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_labCREDITER_ID.Text.Trim());                  //覆核徵審人員
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpACTUSLLOANSAUTH.SelectedValue.Trim());  //覆核實貸金額權限
        LSTR_Data.Append(GSTR_TabDelimitChar + this.tab8_drpIRRAUTH.SelectedValue.Trim());          //覆核IRR權限

        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        //20140811 ADD BY SS CHRIS HUNG Reason.增加結論區塊存檔--覆審
        //if (txtCREDITAMT_R.Text.Trim() != "" && float.Parse(txtCREDITAMT_R.Text.Trim()) > 0)
        {
            LSTR_Data.Append("SP_ML2001A_I07" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCREDITAMT_R.Text.Trim() == "" ? "0" : txtCREDITAMT_R.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtCONTRACTMON_R.Text.Trim() == "" ? "0" : txtCONTRACTMON_R.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtPERBOND_R.Text.Trim() == "" ? "0" : txtPERBOND_R.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            if (chkGRTMV_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTIMV_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTDEPOSIT_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTBILLNOTE_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTSTOCK_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            if (chkGRTCAR_R.Checked)
                LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
            else
                LSTR_Data.Append("N" + GSTR_TabDelimitChar);

            LSTR_Data.Append((txtGRTBAL_R.Text.Trim() == "" ? "0" : txtGRTBAL_R.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtGRTVAL_R.Text.Trim() == "" ? "0" : txtGRTVAL_R.Text.Trim()) + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlFUNDSUSE_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlCONDITION_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlOPERATION_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(ddlDEVICETYPE_R.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append((txtDEDUCTION_R.Text.Trim() == "" ? "0" : txtDEDUCTION_R.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtGRTITEM_R.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtOTHERCONDITION_R.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
            LSTR_Data.Append(txtSIGNMEMO_R.Text.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //20160324 ADD BY SS ADAM REASON.覆核行業別有更新才存檔
        //if (txtINDUID.Text.Trim() != txtINDUID_TAB8.Text.Trim())
        //20221207行業別給下拉選單
        if (DrpNDU.SelectedValue.Trim() != DrpNDU_TAB8.SelectedValue.Trim())
        {
            LSTR_Data.Append("SP_ML2001A_U05" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            //LSTR_Data.Append(this.txtINDUID_TAB8.Text.Trim());
            LSTR_Data.Append(this.DrpNDU_TAB8.SelectedValue.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //20160324 ADD BY SS ADAM REASON.覆核案件產品別有更新才存檔
        if (drpPRODCD.SelectedValue != drpPRODCD_TAB8.SelectedValue)
        {
            LSTR_Data.Append("SP_ML2001A_U06" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpPRODCD_TAB8.SelectedValue.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab88Caption";

                {
                    this.cmdPrintReportC.Enabled = true;

                    this.btnSaveSureTab8.Enabled = false;

                    RegisterScript("alert('儲存成功！');");
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
    protected void btnSaveSureTab9_Click(object sender, EventArgs e)
    {
        MLMCASESaveTab9();
    }
    //20160930 ADD BY SS ADAM REASON.增加放審會
    protected void MLMCASESaveTab9()
    {
        StringBuilder LSTR_Data = new StringBuilder();

        LSTR_Data.Append("SP_ML2001A_I08" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_labCREDITER_ID.Text + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_txtFINDT.Text.ToString() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_drpACTUSLLOANSAUTH.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_drpIRRAUTH.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_ddlCREDITSUGGEST.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_ddlCREDITSUGGEST2.SelectedValue.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_txtSUGGESTDT.Text.ToString() + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_txtSUGGESTDESC.Text.Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
        LSTR_Data.Append(tab9_txtFINDESC.Text.Replace("\r\n", "<br>"));
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        //結論區塊存檔--放審會
        LSTR_Data.Append("SP_ML2001A_I09" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append((txtCREDITAMT_TAB9.Text.Trim() == "" ? "0" : txtCREDITAMT_TAB9.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
        LSTR_Data.Append((txtCONTRACTMON_TAB9.Text.Trim() == "" ? "0" : txtCONTRACTMON_TAB9.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
        LSTR_Data.Append((txtPERBOND_TAB9.Text.Trim() == "" ? "0" : txtPERBOND_TAB9.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
        if (chkGRTMV_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        if (chkGRTIMV_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        if (chkGRTDEPOSIT_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        if (chkGRTBILLNOTE_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        if (chkGRTSTOCK_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        if (chkGRTCAR_TAB9.Checked)
            LSTR_Data.Append("Y" + GSTR_TabDelimitChar);
        else
            LSTR_Data.Append("N" + GSTR_TabDelimitChar);

        LSTR_Data.Append((txtGRTBAL_TAB9.Text.Trim() == "" ? "0" : txtGRTBAL_TAB9.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
        LSTR_Data.Append((txtGRTVAL_TAB9.Text.Trim() == "" ? "0" : txtGRTVAL_TAB9.Text.Trim()) + GSTR_TabDelimitChar);
        LSTR_Data.Append(ddlFUNDSUSE_TAB9.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append(ddlCONDITION_TAB9.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append(ddlOPERATION_TAB9.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append(ddlDEVICETYPE_TAB9.SelectedValue + GSTR_TabDelimitChar);
        LSTR_Data.Append((txtDEDUCTION_TAB9.Text.Trim() == "" ? "0" : txtDEDUCTION_TAB9.Text.Trim().Replace(",", "")) + GSTR_TabDelimitChar);
        LSTR_Data.Append(txtGRTITEM_TAB9.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
        LSTR_Data.Append(txtOTHERCONDITION_TAB9.Text.Trim().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
        LSTR_Data.Append(txtSIGNMEMO_TAB9.Text.Trim());
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);


        //20160324 ADD BY SS ADAM REASON.覆核行業別有更新才存檔
        //20221207行業別改下拉選單
        //if (txtINDUID.Text.Trim() != txtINDUID_TAB9.Text.Trim())
        if (DrpNDU.SelectedValue.Trim() != DrpNDU_TAB9.SelectedValue.Trim())
        {
            LSTR_Data.Append("SP_ML2001A_U05" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            //LSTR_Data.Append(this.txtINDUID_TAB9.Text.Trim());
            LSTR_Data.Append(this.DrpNDU_TAB9.SelectedValue.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //20160324 ADD BY SS ADAM REASON.覆核案件產品別有更新才存檔
        if (drpPRODCD.SelectedValue != drpPRODCD_TAB9.SelectedValue)
        {
            LSTR_Data.Append("SP_ML2001A_U06" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpPRODCD_TAB9.SelectedValue.Trim());
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }

        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        //=========================================================================

        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                this.hidShowTag.Value = "fraTab99Caption";

                {
                    //this.cmdPrintReportC.Enabled = true;

                    this.btnSaveSureTab9.Enabled = false;

                    RegisterScript("alert('儲存成功！');");
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

    protected void btnPrintExamine_Click(object sender, EventArgs e)
    {
        string SSRSAPIUrl = ConfigurationManager.AppSettings["SSRSAPI"].ToString().Trim();
        string PDFMergeUrl = ConfigurationManager.AppSettings["PDFMerge"].ToString().Trim();
        string UPLOADPATH = ConfigurationManager.AppSettings["ML2018_UPLOADPATH"].ToString().Trim();
        string postData = "";

        postData = GetPostData("ML2018A");
        string PDFPATH1 = MERGE_PDF_BY_API(SSRSAPIUrl, postData);
        postData = GetPostData("ML2018B");
        string PDFPATH2 = MERGE_PDF_BY_API(SSRSAPIUrl, postData);
        string PDFPATH3 = "";
        if (tab9_txtSUGGESTDESC.Text != "")
        {
            postData = GetPostData("ML2018B");
            PDFPATH3 = MERGE_PDF_BY_API(SSRSAPIUrl, postData);
        }

        Dictionary<string, List<string>> dicObj = new Dictionary<string, List<string>>();
        List<string> listObj = new List<string>();
        if (PDFPATH1 != "") { listObj.Add(PDFPATH1); }
        if (PDFPATH2 != "") { listObj.Add(PDFPATH2); }
        if (PDFPATH3 != "") { listObj.Add(PDFPATH3); }
        if (hdTAB9FILEPATH1.Value != "") { listObj.Add(UPLOADPATH + hdTAB9FILEPATH1.Value); }
        if (hdTAB9FILEPATH2.Value != "") { listObj.Add(UPLOADPATH + hdTAB9FILEPATH2.Value); }
        if (hdTAB9FILEPATH3.Value != "") { listObj.Add(UPLOADPATH + hdTAB9FILEPATH3.Value); }
        if (hdTAB9FILEPATH4.Value != "") { listObj.Add(UPLOADPATH + hdTAB9FILEPATH4.Value); }
        dicObj.Add("PDFPath", listObj);
        postData = JsonConvert.SerializeObject(dicObj);

        JObject reader = ExeWebApiToJson(PDFMergeUrl, "POST", postData);
        string Result = reader["Result"].ToString();
        string Message = reader["Message"].ToString();
        string FileUrl = reader["PDFPath"].ToString();

        string sScript = "";
        if (Result == "True")
        {
            sScript = "window.open('" + FileUrl + "')";
        }
        else
        {
            sScript = "alert('" + Message + "');";
        }
        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "PrintReport", sScript, true);
    }

    private string MERGE_PDF_BY_API(string url, string param)
    {
        JObject reader = ExeWebApiToJson(url, "POST", param);

        string Result = reader["Result"].ToString();
        string Message = reader["Message"].ToString();
        string FileUrl = reader["FileUrl"][0].ToString();

        return FileUrl;
    }

    public static JObject ExeWebApiToJson(string url, string CallMethod, string param)
    {
        //使用HttpWebRequest
        HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
        string result = null;
        request.Method = "POST";    // 方法
        request.KeepAlive = true; //是否保持連線

        byte[] bs = Encoding.UTF8.GetBytes(param);

        request.ContentType = "application/json";
        request.ContentLength = bs.Length;

        using (Stream reqStream = request.GetRequestStream())
        {
            reqStream.Write(bs, 0, bs.Length);
        }

        using (WebResponse response = request.GetResponse())
        {
            StreamReader sr = new StreamReader(response.GetResponseStream());
            result = sr.ReadToEnd();

            JObject reader = JsonConvert.DeserializeObject<JObject>(result);
            sr.Close();
            return reader;
        }
    }

    private static string JObjectToJson(JObject obj)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.None).ToString();
        json = json.Replace((char)34 + "{", "{");
        json = json.Replace("}" + (char)34, "}");
        return json;
    }

    private string GetPostData(string reportId)
    {
        JObject json = new JObject(
                       new JProperty("reportInfo",
                            new JArray(
                                new JObject(
                                    new JProperty("reportPath", "/ML/Report/"),
                                    new JProperty("reportId", reportId),
                                    new JProperty("reportType", new JArray("PDF")),
                                    new JProperty("reportVar",
                                        new JArray(
                                        new JObject(
                                            new JProperty("column", "MSG"),
                                            new JProperty("value", "")
                                        ),
                                        new JObject(
                                            new JProperty("column", "CASEID"),
                                            new JProperty("value", txtCASEID.Text)
                                        ))))))
                    );

        return JObjectToJson(json);
    }

    protected void btnOnload_Click(object sender, EventArgs e)
    {

    }
}



