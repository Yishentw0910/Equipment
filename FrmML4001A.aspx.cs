using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.Collections.Specialized;
using System.Globalization;
using System.Data;


public partial class FrmML4001A : Itg.Community.PageBase
{
    //20120704 ADD BY SS MAUREEN REASON:取web.config參數傳至Smart Query
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    
    private string strCustId = "";
    private string strCaseId = "";
    private string strCntrNo = "";
    private string strCompId = "";
    private ArrayList alistRents = new ArrayList();
    private ArrayList alistRtnAmts = new ArrayList();
    private ArrayList alistInstAmts = new ArrayList();

    private enum enm發票類別{租金 = 1, 押金設算息 = 2, 手續費 = 3, 本體 = 4,分差 = 5, 本體加分差 = 6, 補貼款收入 = 7, 手續費收入 = 8, 墊款息收入 = 9 }

    private enum enm承作類型 {營租 = 01, 資租 = 02, 分期 = 03, AR = 04}

    private enum enm本體分差開立方式{拆開=01,不拆開=02}

    private enum enm公司別{ 和運 = 01, 和潤 = 02 }

    //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤-頁籤類型
    private enum enm頁籤類型 { 手續費發票 = 1, 動保費收入發票 = 2, 墊款息收入發票 = 3 }

  /// <summary>
  /// 合約內容資料
  /// </summary>
  private NameValueCollection NVC_MLMCONTRACT_Data
  {
    get
    {
      NameValueCollection MLMCONTRACT_Data = new NameValueCollection();
      MLMCONTRACT_Data.Add("txtCNTRNO", "CNTRNO");                 //合約編號
      MLMCONTRACT_Data.Add("txtMAINTYPENM", "MAINTYPENM");         //主要承作型態
      MLMCONTRACT_Data.Add("txtSUBTYPENM", "SUBTYPENM");           //次要承作型態 
      MLMCONTRACT_Data.Add("txtCUSTNAME", "CUSTNAME");             //客戶名稱
      MLMCONTRACT_Data.Add("txtCUSTID", "CUSTID");                 //客戶編號
      MLMCONTRACT_Data.Add("txtRENTSTDT", "PRENTSTDT");            //案件起租日
      MLMCONTRACT_Data.Add("txtRENTENDT", "RENTENDT");             //案件迄租日
      MLMCONTRACT_Data.Add("txtPERBOND", "PERBOND");               //履約保證金
      MLMCONTRACT_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN"); //租購保證金 
      MLMCONTRACT_Data.Add("txtFIRSTPAY", "FIRSTPAY");             //頭期款 
      MLMCONTRACT_Data.Add("txtCUSTFPAYDATE", "CUSTFPAYDATE");     //客戶首期繳納日
      MLMCONTRACT_Data.Add("txtPAYMONTH", "PAYMONTH");             //幾月一付  
      MLMCONTRACT_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");   //承作月數

      MLMCONTRACT_Data.Add("txtINVZIPCODE", "INVZIPCODE");         //發票郵遞區號
      MLMCONTRACT_Data.Add("txtINVZIPCODES", "INVZIPCODES");         //發票郵遞區號
      MLMCONTRACT_Data.Add("hdnMAINTYPE", "MAINTYPE");             //承作類型  
      MLMCONTRACT_Data.Add("txtINVOICEADDR", "INVOICEADDR");       //發票地址  
      MLMCONTRACT_Data.Add("hdnGUARSETRATE", "GUARSETRATE");       //押金設算利率 
      MLMCONTRACT_Data.Add("hdnPROCEDEINV", "PROCEDEINV");         //進項發票金額含稅
      MLMCONTRACT_Data.Add("txtLLVLNUM01", "LLVLNUM01");           //虛擬帳號
      MLMCONTRACT_Data.Add("txtLLVLNUM02", "LLVLNUM02");           //虛擬帳號
      MLMCONTRACT_Data.Add("txtRVACNT", "RVACNT");                 //實體帳號
      MLMCONTRACT_Data.Add("txtACTUSLLOANS", "ACTUSLLOANS");       //實貸金額
      //UPD 20170110 BY SS Gordon REASON:新增手續費，動保費，墊款息        
      MLMCONTRACT_Data.Add("txtFEEAMT1", "FEEAMT1");               //手續費
      MLMCONTRACT_Data.Add("txtFEEAMT2", "FEEAMT2");               //動保費
      MLMCONTRACT_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");  //墊款息
     //20240316財務要求根據客戶性質判斷發票聯式       
      MLMCONTRACT_Data.Add("txtCUTYPE", "CUTYPE");  //客戶性質

            return MLMCONTRACT_Data;
    }
  }

    private NameValueCollection NVC_MLMPREINVSET_Data
    {
        get
        {
            NameValueCollection MLMPREINVSET_Data = new NameValueCollection();
            MLMPREINVSET_Data.Add("txtRENTSTDTM", "RENTSTDTM");           //發票開立月
            MLMPREINVSET_Data.Add("txtRENTSTDTD", "RENTSTDTD");           //指定日期 
            MLMPREINVSET_Data.Add("txtPAYMONTHK", "PAYMONTHK");           //幾月一開
            MLMPREINVSET_Data.Add("ddlSingle", "UNITOPEN");                 //單體彙開
            MLMPREINVSET_Data.Add("ddlSummary", "OVERALLOPEN");               //總體彙開
            MLMPREINVSET_Data.Add("ddlAplyTyp", "PREOPENWAY");               //預計開立方式
            MLMPREINVSET_Data.Add("ddlBdyDiffTyp", "OPENWAY");         //本體分差開立方式

            return MLMPREINVSET_Data;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4001A";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4001A";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";
        this.hdnSysDate.Value = DateTime.Now.ToString("yyyyMM");
        //取得前頁傳入之客戶編號
        strCustId = Request.QueryString["custid"].ToString();
        //strCustId = "23238913";
        //取得前頁傳入之案件編號
        strCaseId = Request.QueryString["caseid"].ToString();
        //strCaseId = "A22010080035";
        //取得前頁傳入之合約編號
        strCntrNo = Request.QueryString["cntrno"].ToString();
        //取得前頁傳入之公司別
        strCompId = Request.QueryString["compid"].ToString();
        this.txtCUSTID.Text = strCustId;
        this.txtCNTRNO.Text = strCntrNo;
        this.hdnMAINTYPE.Value = Request.QueryString["maintype"].ToString();
        this.txtMAINTYPENM.Text = Request.QueryString["maintypenme"].ToString();
        this.hdnPREINVSETID.Value = Request.QueryString["PREINVSETID"].ToString() + "";

        if (this.hdnPREINVSETID.Value.Trim() != "")
        {
            this.btnUS.Attributes.Remove("display:;");
            this.btnUS.Attributes.Add("style", "display:none;");
            this.spanINVStarus.Attributes.Remove("display:none;");
            this.spanINVStarus.Attributes.Remove("color:#FF0000;");
            this.spanINVStarus.Attributes.Add("style", "display:;");
            this.spanINVStarus.Attributes.Add("style", "color:#FF0000;");
        }
        else
        {
            this.spanINVStarus.Attributes.Remove("display:;");
            this.spanINVStarus.Attributes.Add("style", "display:none;");
        }
        //strCntrNo = "MSA22010080010";
        //string strCon = Request.QueryString["con"].ToString();
        this.hdnCompId.Value = strCompId;
        //Vincent-20100817-Add for 畫面控制項屬性設定
        PageInitProcess();
        
        HtmlTableRowCollection tbrCntrInvRmkInfo = this.tabCntrInvRmkInfo.Rows;

        for (Int32 intRowCnt = 0; intRowCnt < tbrCntrInvRmkInfo.Count; intRowCnt++)
        {
            tbrCntrInvRmkInfo[intRowCnt].Attributes.Remove("display:;");
            tbrCntrInvRmkInfo[intRowCnt].Attributes.Add("style", "display:none;");
        }

        HtmlTableRowCollection tbrCntrInvInfo = this.tabCntrInvInfo.Rows;

        tbrCntrInvInfo[2].Attributes.Remove("display:;");
        tbrCntrInvInfo[2].Attributes.Add("style", "display:none;");

        if (!Page.IsPostBack)
        {
            Session.Contents.Remove("MLDCONTRACTTARGET");
            Session.Contents.Remove("MLDPREINVSPLIT");
            Session.Contents.Remove("MLDCONTRACTTARGET_New");
            Session.Contents.Remove("MLDPREINVOPEN");
            PageDataBind(strCntrNo);
            FormDDLBinding();
            DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
            rptPREINVOICEInit();

            //新增進入
            if (this.hdnPREINVSETID.Value.Trim() == "")
            {
                //資租及營租
                if (!String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
                {
                    tbrCntrInvRmkInfo[0].Attributes.Remove("display:none;");
                    tbrCntrInvRmkInfo[0].Attributes.Add("style", "display:;");
                    this.btn111.Attributes.Remove("display:none;");
                    this.btn111.Attributes.Add("style", "display:;");
                    //營租且月租金為一階才可以執行拆發票設定，其他業種別不行
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
                    {
                        if (this.txtRENDPAY2.Text.Trim() == "")
                        {
                            this.btnSplit.Attributes.Remove("display:none;");
                            this.btnSplit.Attributes.Add("style", "display:;");
                            this.ddlSingle.SelectedIndex = 1;
                            this.ddlSummary.SelectedValue = "2";
                            this.ddlSummary.Enabled = false;
                            this.ddlSingle.SelectedValue = "2";
                            this.ddlSingle.Enabled = true;
                            for (int intRowidx = 0; intRowidx < dtbMLDCONTRACTTARGET.Rows.Count; intRowidx++)
                            {
                                dtbMLDCONTRACTTARGET.Rows[intRowidx]["MONTHPAY"] = System.Convert.ToDecimal(System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intRowidx]["TARGETPRICEA"]) * System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text)).ToString("#,##0");
                            }
                            Session["MLDCONTRACTTARGET"] = dtbMLDCONTRACTTARGET;
                        }
                        else
                        {
                            this.btnSplit.Attributes.Remove("display:;");
                            this.btnSplit.Attributes.Add("style", "display:none;");
                            this.ddlSingle.SelectedIndex = 0;
                            this.ddlSingle.SelectedValue = "1";
                            this.ddlSingle.Enabled = true;
                            this.ddlSummary.SelectedIndex = 1;
                            this.ddlSummary.SelectedValue = "2";
                            this.ddlSummary.Enabled = true;
                        }
                    }
                    else
                    {
                        this.ddlSingle.SelectedIndex = 0;
                        this.ddlSingle.SelectedValue = "1";
                        this.ddlSingle.Enabled = true;
                        this.btnSplit.Attributes.Remove("display:;");
                        this.btnSplit.Attributes.Add("style", "display:none;");
                        this.ddlSummary.SelectedIndex = 1;
                        this.ddlSummary.SelectedValue = "2";
                        this.ddlSummary.Enabled = false;
                        this.btnMerge.Attributes.Remove("display:;");
                        this.btnMerge.Attributes.Add("style", "display:none;");
                        if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租)
                        {
                            this.txtPAYMONTHK.Enabled = false;
                        }
                    }

                    if (this.ddlSingle.SelectedValue == "2" && Session["MLDPREINVSPLIT"] != null && ((DataTable)Session["MLDPREINVSPLIT"]).Rows.Count != 0)
                    {
                        this.btnSplit.Attributes.Remove("display:none;");
                        this.btnSplit.Attributes.Add("style", "display:;");
                        this.btnMerge.Attributes.Remove("display:;");
                        this.btnMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.spanChkMerge.Attributes.Remove("display:;");
                        this.spanChkMerge.Attributes.Add("style", "display:none;");
                        this.ddlSummary.Attributes.Add("Disabled", "true");
                        this.ddlSummary.Enabled = false;
                    }
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
                    {
                        if (this.ddlSummary.SelectedValue == "1" && this.hdnOPENCNTRNO.Value.Trim() !="" )
                        {
                            this.btnSplit.Attributes.Remove("display:;");
                            this.btnSplit.Attributes.Add("style", "display:none;");
                            this.btnMerge.Attributes.Remove("display:none;");
                            this.btnMerge.Attributes.Add("style", "display:;");
                            this.ddlSummary.Enabled = true;
                            this.chkMerge.Attributes.Remove("display:none;");
                            this.chkMerge.Attributes.Add("style", "display:;");
                            this.spanChkMerge.Attributes.Remove("display:none;");
                            this.spanChkMerge.Attributes.Add("style", "display:;");
                            if (this.hdnOPENCNTRNO.Value.Trim() == this.txtCNTRNO.Text.Trim())
                            {
                                this.chkMerge.Checked = true;
                                this.hdnOPENMASTER.Value = "1";
                            }
                            else
                            {
                                this.chkMerge.Checked = false;
                                this.hdnOPENMASTER.Value = "";
                            }
                        }
                    }
                }
                else
                {
                    //營租才可以執行拆發票設定，其他業種別不行
                    this.txtPAYMONTHK.Enabled = false;
                    this.btnSplit.Disabled = true;
                    this.ddlSingle.SelectedIndex = 1;
                    this.ddlSingle.SelectedValue = "2";
                    this.ddlSingle.Enabled = false;
                    this.btnSplit.Attributes.Remove("display:;");
                    this.btnSplit.Attributes.Add("style", "display:none;");
                    this.ddlSummary.SelectedIndex = 1;
                    this.ddlSummary.SelectedValue = "2";
                    this.ddlSummary.Enabled = false;
                    this.chkMerge.Attributes.Remove("display:;");
                    this.chkMerge.Attributes.Add("style", "display:none;");
                    this.spanChkMerge.Attributes.Remove("display:;");
                    this.spanChkMerge.Attributes.Add("style", "display:none;");
                    this.btn111.Attributes.Remove("display:none;");
                    this.btn111.Attributes.Add("style", "display:none;");

                    tbrCntrInvInfo[2].Attributes.Remove("display:none;");
                    tbrCntrInvInfo[2].Attributes.Add("style", "display:;");

                    if (!String.IsNullOrEmpty(this.ddlBdyDiffTyp.SelectedValue) && (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.拆開))
                    {
                        if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
                        {
                            this.btn444.Attributes.Remove("display:none;");
                            this.btn444.Attributes.Add("style", "display:;");
                            this.btn555.Attributes.Remove("display:none;");
                            this.btn555.Attributes.Add("style", "display:;");
                            tbrCntrInvRmkInfo[3].Attributes.Remove("display:none;");
                            tbrCntrInvRmkInfo[3].Attributes.Add("style", "display:;");
                            tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                            tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                        }
                        else
                        {
                            this.btn555.Attributes.Remove("display:none;");
                            this.btn555.Attributes.Add("style", "display:;");
                            tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                            tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                        }
                    }
                    else
                    {
                        this.btn666.Attributes.Remove("display:none;");
                        this.btn666.Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[5].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:;");
                    }
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR)
                    {
                        this.ddlBdyDiffTyp.Enabled = false;
                        this.ddlBdyDiffTyp.SelectedValue = "1";
                        this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                        this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                        tbrCntrInvRmkInfo[4].Attributes.Remove("display:none");
                        tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:");
                        tbrCntrInvRmkInfo[5].Attributes.Remove("display:");
                        tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:none");
                    }
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
                    {
                        this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                        this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                    }

                }
            }
            else//修改模式進入
            {
                if (this.ddlSummary.SelectedValue == "1")
                {
                    this.ddlSingle.SelectedIndex = 0;
                    this.ddlSingle.SelectedValue = "1";
                    this.ddlSingle.Enabled = true;
                    this.btnSplit.Attributes.Remove("display:;");
                    this.btnSplit.Attributes.Add("style", "display:none;");
                    this.ddlSummary.Enabled = true;

                    this.btnMerge.Attributes.Remove("display:none;");
                    this.btnMerge.Attributes.Add("style", "display:;");
                    this.chkMerge.Attributes.Remove("display:none;");
                    this.chkMerge.Attributes.Add("style", "display:;");
                    this.chkMerge.Attributes.Remove("display:none;");
                    this.chkMerge.Attributes.Add("style", "display:;");
                    this.spanChkMerge.Attributes.Remove("display:none;");
                    this.spanChkMerge.Attributes.Add("style", "display:;");
                    if (this.hdnOPENCNTRNO.Value.Trim() == this.txtCNTRNO.Text.Trim())
                    {
                        this.chkMerge.Checked = true;
                        this.hdnOPENMASTER.Value = "1";
                    }
                    else
                    {
                        this.chkMerge.Checked = false;
                        this.hdnOPENMASTER.Value = "";
                    }
                }
                else
                {
                    if (this.ddlSingle.SelectedValue == "2")
                    {
                        if (this.txtRPRINCIPALTAX2.Text.Trim() == "")
                        {
                            this.btnSplit.Attributes.Remove("display:none;");
                            this.btnSplit.Attributes.Add("style", "display:;");
                        }
                        this.ddlSummary.Enabled = false;
                        this.ddlSummary.SelectedValue = "2";
                        this.btnMerge.Attributes.Remove("display:;");
                        this.btnMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.spanChkMerge.Attributes.Remove("display:;");
                        this.spanChkMerge.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        this.btnSplit.Attributes.Remove("display:;");
                        this.btnSplit.Attributes.Add("style", "display:none;");
                        this.ddlSummary.Enabled = true;
                    }
                }
                if ((System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期))
                {
                    this.btnSplit.Attributes.Remove("display:;");
                    this.btnSplit.Attributes.Add("style", "display:none;");
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR)
                    {
                        this.ddlBdyDiffTyp.Enabled = false;
                        this.btn444.Attributes.Remove("display:;");
                        this.btn444.Attributes.Add("style", "display:none;");
                        this.btn555.Attributes.Remove("display:none;");
                        this.btn555.Attributes.Add("style", "display:;");
                        this.btn666.Attributes.Remove("display:;");
                        this.btn666.Attributes.Add("style", "display:none;");
                        this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                        this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Remove("display:");
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Add("style", "display:none");
                        this.tabCntrInvRmkInfo.Rows[4].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[4].Attributes.Add("style", "display:");
                        this.tabCntrInvRmkInfo.Rows[5].Attributes.Remove("display:");
                        this.tabCntrInvRmkInfo.Rows[5].Attributes.Add("style", "display:none");
                    }

                    if ((System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期))
                    {
                        this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                        this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                    }

                    if ((System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期))
                    {
                        this.ddlSingle.SelectedIndex = 0;
                        this.ddlSingle.SelectedValue = "1";
                        this.ddlSingle.Enabled = false;
                    }
                    this.txtPAYMONTHK.Enabled = false;
                }
                else
                {
                    if (this.txtRENDPAY2.Text.Trim() == "")
                    {
                        for (int intRowidx = 0; intRowidx < dtbMLDCONTRACTTARGET.Rows.Count; intRowidx++)
                        {
                            dtbMLDCONTRACTTARGET.Rows[intRowidx]["MONTHPAY"] = System.Convert.ToDecimal(System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intRowidx]["TARGETPRICEA"]) * System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text)).ToString("#,##0");
                        }
                        Session["MLDCONTRACTTARGET"] = dtbMLDCONTRACTTARGET;
                    }
                }
            }
            if (this.txtPERBOND.Text != "0" || this.txtPURCHASEMARGIN.Text != "0")
            {
                tbrCntrInvRmkInfo[1].Attributes.Remove("display:none;");
                tbrCntrInvRmkInfo[1].Attributes.Add("style", "display:;");
                this.btn222.Attributes.Remove("display:none;");
                this.btn222.Attributes.Add("style", "display:;");
            }
            if (this.txtPAYMONTH.Text.Trim() == "1")
            {
                this.txtPAYMONTHK.Text = "1";
                this.txtPAYMONTHK.Enabled = false;  
            }
        }
        else
        {
            //取得承作類別，判斷備註設定內容
            string strMAINTYPE = Request.Form.GetValues("hdnMAINTYPE")[0];
            if (Request.Form.GetValues("drpINVKIND1")[0].Trim() != "")
            {
                this.drpINVKIND1.SelectedValue = Request.Form.GetValues("drpINVKIND1")[0].Trim();
            }
            strMAINTYPE = strMAINTYPE.Replace("0", "").Trim();
            string strSingle = "";
            string strSummary = "";
            if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
            {
                strSingle = Request.Form.GetValues("ddlSingle")[0];
                if (strSingle == "1")
                {
                    strSummary = Request.Form.GetValues("ddlSummary")[0];
                    if (strSummary == "1")
                    {
                        this.ddlSummary.Enabled = true;
                        this.btnMerge.Attributes.Remove("display:none;");
                        this.btnMerge.Attributes.Add("style", "display:;");
                        this.chkMerge.Attributes.Remove("display:none;");
                        this.chkMerge.Attributes.Add("style", "display:;");
                        this.spanChkMerge.Attributes.Remove("display:none;");
                        this.spanChkMerge.Attributes.Add("style", "display:;");
                    }
                    else
                    {
                        this.ddlSummary.Enabled = true;
                        this.btnMerge.Attributes.Remove("display:;");
                        this.btnMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.spanChkMerge.Attributes.Remove("display:;");
                        this.spanChkMerge.Attributes.Add("style", "display:none;");
                    }
                }
                else
                {
                    strSummary = "2";
                }

            }
            else
            {
                if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
                {
                    strSingle = Request.Form.GetValues("ddlSingle")[0];
                }
                else
                {
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租)
                    {
                        strSingle = Request.Form.GetValues("ddlSingle")[0];
                    }
                    else
                    {
                        strSingle = "2";
                    }
                }
            }
            if (strSingle == "1")
            {
                if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租)
                {
                    strSummary = "2";
                }
                else
                {
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
                    {
                        strSummary = "2";
                    }
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR)
                    {
                        strSummary = "2";
                    }
                }
            }
            else
            {
                strSummary = "2";
            }
            //this.ddlSingle.SelectedValue = strSingle;
            //this.ddlSummary.SelectedValue = strSummary; 
            DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];

            if (!String.IsNullOrEmpty(strMAINTYPE) && (System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.資租 || System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.營租))
            {
                tbrCntrInvRmkInfo[0].Attributes.Remove("display:none;");
                tbrCntrInvRmkInfo[0].Attributes.Add("style", "display:;");
                this.btn111.Attributes.Remove("display:none;");
                this.btn111.Attributes.Add("style", "display:;");
                //營租且月租金為一階才可以執行拆發票設定，其他業種別不行
                if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
                {
                    if (this.txtRENDPAY2.Text.Trim() == "")
                    {
                        if (strSingle == "2")
                        {
                            this.btnSplit.Attributes.Remove("display:none;");
                            this.btnSplit.Attributes.Add("style", "display:;");
                        }
                        else
                        {
                            this.btnSplit.Attributes.Remove("display:;");
                            this.btnSplit.Attributes.Add("style", "display:none;");
                        }
                        //                        this.ddlSingle.SelectedIndex = 1;
                        this.ddlSingle.SelectedValue = strSingle;
                        if (strSingle == "1")
                        {
                            this.ddlSummary.Enabled = true;
                            this.chkMerge.Attributes.Remove("display:none;");
                            this.chkMerge.Attributes.Add("style", "display:;");
                            this.btnMerge.Attributes.Remove("display:none;");
                            this.btnMerge.Attributes.Add("style", "display:;");
                        }
                        this.ddlSingle.Enabled = true;
                        for (int intRowidx = 0; intRowidx < dtbMLDCONTRACTTARGET.Rows.Count; intRowidx++)
                        {
                            dtbMLDCONTRACTTARGET.Rows[intRowidx]["MONTHPAY"] = System.Convert.ToDecimal(System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intRowidx]["TARGETPRICEA"]) * System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text)).ToString("#,##0");
                        }
                        if (strSummary == "1")
                        {
                            this.ddlSummary.Enabled = true;
                            this.btnMerge.Attributes.Remove("display:;");
                            this.btnMerge.Attributes.Add("style", "display:;");
                            this.chkMerge.Attributes.Remove("display:none;");
                            this.chkMerge.Attributes.Add("style", "display:;");
                            this.spanChkMerge.Attributes.Remove("display:none;");
                            this.spanChkMerge.Attributes.Add("style", "display:;");
                        }
                        else
                        {
                            if (strSingle == "1")
                            {
                                this.ddlSummary.Enabled = true;
                            }
                            else
                            {
                                this.ddlSummary.Enabled = false;
                            }
                            this.btnMerge.Attributes.Remove("display:;");
                            this.btnMerge.Attributes.Add("style", "display:none;");
                            this.chkMerge.Attributes.Remove("display:none;");
                            this.chkMerge.Attributes.Add("style", "display:none;");
                            this.spanChkMerge.Attributes.Remove("display:;");
                            this.spanChkMerge.Attributes.Add("style", "display:none;");
                        }
                        Session["MLDCONTRACTTARGET"] = dtbMLDCONTRACTTARGET;
                    }
                    else
                    {
                        if (strSingle == "2")
                        {
                            this.btnSplit.Attributes.Remove("display:;");
                            this.btnSplit.Attributes.Add("style", "display:none;");
                        }
                        //                        this.ddlSingle.SelectedIndex = 0;
                        this.ddlSingle.SelectedValue = strSingle;
                    }
                    //                    this.ddlSummary.SelectedIndex = 1;
                    this.ddlSummary.SelectedValue = strSummary;
                    if (strSummary == "1")
                    {
                        this.ddlSummary.Enabled = true;
                        this.btnMerge.Attributes.Remove("display:none;");
                        this.btnMerge.Attributes.Add("style", "display:;");
                        this.chkMerge.Attributes.Remove("display:none;");
                        if (this.hdnOPENCNTRNO.Value.Trim() == this.txtCNTRNO.Text.Trim())
                        {
                            this.chkMerge.Checked = true;
                            this.hdnOPENMASTER.Value = "1";
                        }
                        else
                        {
                            this.chkMerge.Checked = false;
                            this.hdnOPENMASTER.Value = "";
                        }
                        this.chkMerge.Attributes.Add("style", "display:;");
                        this.spanChkMerge.Attributes.Remove("display:none;");
                        this.spanChkMerge.Attributes.Add("style", "display:;");
                    }
                }
                else
                {
          //          this.ddlSingle.SelectedIndex = 0;
                    this.ddlSingle.SelectedValue = strSingle;
                    this.ddlSingle.Enabled = true;
          //          this.ddlSummary.SelectedIndex = 1;
                    this.ddlSummary.SelectedValue = strSummary;
                    this.ddlSummary.Enabled = false;
                    this.btnSplit.Attributes.Remove("display:;");
                    this.btnSplit.Attributes.Add("style", "display:none;");
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租)
                    {
                        this.txtPAYMONTHK.Enabled = false;
                    }
                }
                if (this.txtPAYMONTH.Text.Trim() == "1")
                {
                    this.txtPAYMONTHK.Text = "1";
                    this.txtPAYMONTHK.Enabled = false;
                }
            }
            else
            {
                //營租才可以執行拆發票設定，其他業種別不行
                this.txtPAYMONTHK.Enabled = false;
                this.btnSplit.Disabled = true;
                this.ddlSingle.SelectedIndex = 1;
                this.ddlSingle.SelectedValue = "2";
                this.ddlSingle.Enabled = false;
                this.btnSplit.Attributes.Remove("display:;");
                this.btnSplit.Attributes.Add("style", "display:none;");
                this.ddlSummary.SelectedIndex = 1;
                this.ddlSummary.SelectedValue = "2";
                this.ddlSummary.Enabled = false;
                this.btn111.Attributes.Remove("display:none;");
                this.btn111.Attributes.Add("style", "display:none;");

                tbrCntrInvInfo[2].Attributes.Remove("display:none;");
                tbrCntrInvInfo[2].Attributes.Add("style", "display:;");

                if (!String.IsNullOrEmpty(this.ddlBdyDiffTyp.SelectedValue) && (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.拆開))
                {
                    if (System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.分期)
                    {
                        this.btn444.Attributes.Remove("display:none;");
                        this.btn444.Attributes.Add("style", "display:;");
                        this.btn555.Attributes.Remove("display:none;");
                        this.btn555.Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[3].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[3].Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                    }
                    else
                    {
                        this.btn555.Attributes.Remove("display:none;");
                        this.btn555.Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                    }
                }
                else
                {
                    this.btn666.Attributes.Remove("display:none;");
                    this.btn666.Attributes.Add("style", "display:;");
                    tbrCntrInvRmkInfo[5].Attributes.Remove("display:none;");
                    tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:;");
                }
                if (this.txtPAYMONTH.Text.Trim() == "1")
                {
                    this.txtPAYMONTHK.Text = "1";
                    this.txtPAYMONTHK.Enabled = false;
                }
            }

            if (!String.IsNullOrEmpty(strMAINTYPE) && (System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.分期 || System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.AR))
            {
                //取得本體分差開立方式，判斷備註設定內容
                string strBdyDiffTyp = Request["ddlBdyDiffTyp"];
                if (System.Convert.ToInt32(strMAINTYPE) == (int)enm承作類型.分期)
                {
                    strBdyDiffTyp = strBdyDiffTyp.Replace("0", "").Trim();
                }
                else
                {
                    strBdyDiffTyp = "1";
                }
                //營租才可以執行拆發票設定，其他業種別不行
                this.ddlSingle.SelectedIndex = 1;
                this.ddlSingle.Enabled = false;
                this.ddlSummary.SelectedIndex = 1;
                this.ddlSummary.Enabled = false;
                if (!String.IsNullOrEmpty(strBdyDiffTyp) && System.Convert.ToInt32(strBdyDiffTyp) == (int)enm本體分差開立方式.拆開) 
                {
                    if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
                    {
                        this.btn444.Attributes.Remove("display:none;");
                        this.btn444.Attributes.Add("style", "display:;");
                        this.btn555.Attributes.Remove("display:none;");
                        this.btn555.Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[3].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[3].Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                    }
                    else if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR)
                    {
                        this.btn555.Attributes.Remove("display:none;");
                        this.btn555.Attributes.Add("style", "display:;");
                        tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                        tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                    }
                }
                else
                {
                    this.btn666.Attributes.Remove("display:none;");
                    this.btn666.Attributes.Add("style", "display:;");
                    tbrCntrInvRmkInfo[5].Attributes.Remove("display:none;");
                    tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:;");
                }

                if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR)
                {
                    this.ddlBdyDiffTyp.Enabled = false;
                    this.ddlBdyDiffTyp.SelectedValue = "1";
                    this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                    this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                    tbrCntrInvRmkInfo[4].Attributes.Remove("display:none");
                    tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:");
                    tbrCntrInvRmkInfo[5].Attributes.Remove("display:");
                    tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:none");
                }
                if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
                {
                    this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                    this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                }
            }

            string strPERBOND = Request["txtPERBOND"];
            string strPURCHASEMARGIN = Request["txtPURCHASEMARGIN"];

            if (strPERBOND.Trim() != "0" || strPURCHASEMARGIN.Trim() != "0")
            {
                tbrCntrInvRmkInfo[1].Attributes.Remove("display:none;");
                tbrCntrInvRmkInfo[1].Attributes.Add("style", "display:;");
                this.btn222.Attributes.Remove("display:none;");
                this.btn222.Attributes.Add("style", "display:;");
            }
            if (this.txtPAYMONTH.Text.Trim() == "1")
            {
                this.txtPAYMONTHK.Text = "1";
                this.txtPAYMONTHK.Enabled = false;
            }
        }
        if (this.txtCUTYPE.Text.Trim()== "1")
        {
            this.drpINVKIND1.SelectedValue = "2";
            this.drpINVKIND1_2.SelectedValue = "2";
            this.drpINVKIND1_3.SelectedValue = "2";
            this.drpINVKIND1_4.SelectedValue = "2";
        }
        else
        {
            this.drpINVKIND1.SelectedValue = "3";
            this.drpINVKIND1_2.SelectedValue = "3";
            this.drpINVKIND1_3.SelectedValue = "3";
            this.drpINVKIND1_4.SelectedValue = "3";
        }
        //UPD 20170110 BY SS Gordon 新增頁籤處理
        RegisterScript("window_onload();");
    }

    private void rptPREINVOICEInit()
    {
        if (ViewState["MLMPREINVOICE"] == null)
        {
            DataTable dtbMLMPREINVOICE = new DataTable("MLMPREINVOICE");
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVID", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("COMPID", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESC", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREOPENWAY", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVKIND", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("RENTYEARS", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVYYYYMM", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESCTYPE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAXTYPE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDATE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVNO", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.Decimal")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("DISAMT", System.Type.GetType("System.Decimal")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("AMOUNT", System.Type.GetType("System.Decimal")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAX", System.Type.GetType("System.Decimal")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVOICEAMOUNT", System.Type.GetType("System.Decimal")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("ORDERDAY", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("BZ", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLIT", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLITNME", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLE", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLENME", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSUMMARY", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("MTRCNTRNO", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("MEMO", System.Type.GetType("System.String")));
            dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMTDESC", System.Type.GetType("System.String")));
            ViewState["MLMPREINVOICE"] = dtbMLMPREINVOICE;
        }
    }

    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.ddlSingle.Attributes.Add("onchange", "ddlSingle_onChange(this);");
        this.ddlSingle.SelectedIndex = 1;
        this.ddlSingle.SelectedValue= "2";
        this.ddlSummary.Attributes.Add("onchange", "ddlSummary_onChange(this);");
        this.drpINVKIND1.SelectedIndex = -1;
        //ADD BY HANK 20171102 發票聯式初始設定
        this.drpINVKIND1.Attributes.Add("onchange", "drpINVKIND1_onChange(this);"); 
        this.ddlSummary.SelectedIndex = 1;
        this.ddlSummary.SelectedValue = "2";
        this.txtRENTSTDTM.Attributes.Add("style", "ime-mode:disabled;"); 
        this.txtRENTSTDTM.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRENTSTDTM.Attributes.Add("onblur", "txtRENTSTDTM_onBlur(this);");
        this.txtRENTSTDTM.Attributes.Add("onfocus", "txtRENTSTDTM_onFocus(this);");
        this.ddlAplyTyp.Attributes.Add("onchange", "ddlAplyTyp_onChange(this);");
        this.ddlBdyDiffTyp.Attributes.Add("onchange", "ddlBdyDiffTyp_onChange(this);");
        this.txtPERBOND.Attributes.Add("onchange", "txtPERBOND_onChange(this);");
        this.txtPURCHASEMARGIN.Attributes.Add("onchange", "txtPURCHASEMARGIN_onChange(this);");
        this.txtPAYMONTHK.Attributes.Add("onchange", "txtPAYMONTHK_onChange(this);");
        this.txtPAYMONTHK.Attributes.Add("onkeypress", "OnlyNum(this);");
        this.txtPAYMONTHK.Attributes.Add("onfocus", "MoneyFocus(this);");
        this.txtPAYMONTHK.Attributes.Add("onblur", "txtPAYMONTHK_onBlur(this);");
        this.btnUS.Attributes.Add("onclick", "btnUS_onClick(this);");
        this.btn111.Attributes.Add("onclick", "btn111_onClick(this);");
        this.btn222.Attributes.Add("onclick", "btn222_onClick(this);");
        this.btn333.Attributes.Add("onclick", "btn333_onClick(this);");
        this.btn444.Attributes.Add("onclick", "btn444_onClick(this);");
        this.btn555.Attributes.Add("onclick", "btn555_onClick(this);");
        this.btn111.Attributes.Add("style", "display:none;");
        this.btn222.Attributes.Add("style", "display:none;");
        this.btn333.Attributes.Add("style", "display:none;");
        this.btn444.Attributes.Add("style", "display:none;");
        this.btn555.Attributes.Add("style", "display:none;");
        this.btn666.Attributes.Add("style", "display:none;");
        this.chk42.Attributes.Add("style", "display:none;");
        this.chk43.Attributes.Add("style", "display:none;");
        this.chk44.Attributes.Add("style", "display:none;");
        this.chk46.Attributes.Add("style", "display:none;");
        this.chk52.Attributes.Add("style", "display:none;");
        this.chk53.Attributes.Add("style", "display:none;");
        this.chk54.Attributes.Add("style", "display:none;");
        this.chk56.Attributes.Add("style", "display:none;");
        this.chk62.Attributes.Add("style", "display:none;");
        this.chk63.Attributes.Add("style", "display:none;");
        this.chk64.Attributes.Add("style", "display:none;");
        this.chk66.Attributes.Add("style", "display:none;");
        this.btnUA.Attributes.Add("style", "display:none;");
        this.btnUO.Attributes.Add("style", "display:none;");
        this.chk24.Enabled = false;
        this.chk24.Checked = false;
        this.chk25.Enabled = false;
        this.chk25.Checked = false;
        this.chk26.Enabled = false;
        this.chk26.Checked = false;
        this.btnExtInvo.Attributes.Add("style", "display:none;");
        this.ddlAplyTyp.Attributes.Add("disabled", "true");
        this.btnUS.Attributes.Add("style", "display:;");
        this.chkMerge.Attributes.Add("style", "display:none;");
        this.spanChkMerge.Attributes.Add("style", "display:none;");
        this.chkMerge.Attributes.Add("onclick", "chkMerge_onClick(this);");
        this.chk14.Attributes.Add("onclick", "chk14_onClick(this);");
        this.chk15.Attributes.Add("onclick", "chk15_onClick(this);");
        this.chk44.Attributes.Add("onclick", "chk44_onClick(this);");
        this.chk45.Attributes.Add("onclick", "chk45_onClick(this);");
        this.chk54.Attributes.Add("onclick", "chk54_onClick(this);");
        this.chk55.Attributes.Add("onclick", "chk55_onClick(this);");
        this.chk64.Attributes.Add("onclick", "chk64_onClick(this);");
        this.chk65.Attributes.Add("onclick", "chk65_onClick(this);");
        //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的[發票起始月]、[發票聯式]初始設定
        //this.drpINVKIND1_2.SelectedIndex = -1;
        this.txtRENTSTDTM_2.Attributes.Add("style", "ime-mode:disabled;");
        this.txtRENTSTDTM_2.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRENTSTDTM_2.Attributes.Add("onblur", "txtRENTSTDTM_onBlur(this);");
        this.txtRENTSTDTM_2.Attributes.Add("onfocus", "txtRENTSTDTM_onFocus(this);");
        //this.drpINVKIND1_3.SelectedIndex = -1;
        this.txtRENTSTDTM_3.Attributes.Add("style", "ime-mode:disabled;");
        this.txtRENTSTDTM_3.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRENTSTDTM_3.Attributes.Add("onblur", "txtRENTSTDTM_onBlur(this);");
        this.txtRENTSTDTM_3.Attributes.Add("onfocus", "txtRENTSTDTM_onFocus(this);");
        //this.drpINVKIND1_4.SelectedIndex = -1;
        this.txtRENTSTDTM_4.Attributes.Add("style", "ime-mode:disabled;");
        this.txtRENTSTDTM_4.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRENTSTDTM_4.Attributes.Add("onblur", "txtRENTSTDTM_onBlur(this);");
        this.txtRENTSTDTM_4.Attributes.Add("onfocus", "txtRENTSTDTM_onFocus(this);");
    }

    /// <summary>
    /// PageDataBind
    /// </summary>
    /// <param name="strCntrNo">合約編號</param>
    /// <returns>無</returns>
    private void PageDataBind(string strCntrNo)
    {
        if (!string.IsNullOrEmpty(strCntrNo))
        {
            try
            {
                //以案件編號取的合約案件資料
                ReturnObject<DataSet> dtsReturnDataSet = GetCaseDataByID(strCntrNo);
                if (dtsReturnDataSet.ReturnSuccess)
                {
                    DataSet dtsCntrtInfo = dtsReturnDataSet.ReturnData;
                    //绑定合約
                    GetCntrNoBind(dtsCntrtInfo.Tables[0]);

                    //撥款案件租賃分期明細檔
                    if (!String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租))
                    {
                        GetMLDCONTRACTINSTBind(dtsCntrtInfo.Tables[1], dtsCntrtInfo.Tables[2]);
                    }
                    else
                    {
                        GetMLDCONTRACTCASHFLOWData();
                        DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];
                        GetMLDCONTRACTINSTBind(dtsCntrtInfo.Tables[1], dtbMLDCONTRACTCASHFLOW);
                    }

                    if (!String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
                    {
                        MLDPREINVSPLIT_Init();

                        if (dtsCntrtInfo.Tables[3] != null)
                        {
                            MLDPREINVOPENMAJCNTR_Init(dtsCntrtInfo.Tables[3]);
                        }
                    }
                    
                    //案件起租日
                    string strRentStdt = this.txtRENTSTDT.Text.Trim();
                    //發票開啟月=起租月
                    switch (strRentStdt.Length)
                    {
                        case 7:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的發票設定-發票開起月
                            txtRENTSTDTM_2.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            txtRENTSTDTM_3.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            txtRENTSTDTM_4.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            break;
                        case 8:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的發票設定-發票開起月
                            txtRENTSTDTM_2.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            txtRENTSTDTM_3.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            txtRENTSTDTM_4.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            break;
                        case 9:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的發票設定-發票開起月
                            txtRENTSTDTM_2.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            txtRENTSTDTM_3.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            txtRENTSTDTM_4.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            break;
                        case 10:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的發票設定-發票開起月
                            txtRENTSTDTM_2.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            txtRENTSTDTM_3.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            txtRENTSTDTM_4.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            break;
                    }
                    
                    //標的物設置
                    //GetMLDCONTRACTTARGETData();

                    if (!String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
                    {
                        MLDPREINVSPLIT_Init();

                        if (dtsCntrtInfo.Tables[3] != null)
                        {
                            MLDPREINVOPENMAJCNTR_Init(dtsCntrtInfo.Tables[3]);
                        }
                    }

                    //修改模式
                    if (this.hdnPREINVSETID.Value.Trim() != "")
                    {
                        GetMLMPREINVSETBind(dtsCntrtInfo.Tables[4]);

                        GetMLDPREINVNOTEBind(dtsCntrtInfo.Tables[7]);

                        GetMLMPREINVOICEBind(dtsCntrtInfo.Tables[5]);

                        if (dtsCntrtInfo.Tables[8] != null)
                        {
                            GetMLDPREINVSPLITBind(dtsCntrtInfo.Tables[8]);
                        }
                        if (dtsCntrtInfo.Tables[9] != null)
                        {
                            MLDPREINVOPENCNTRCNTR_Init(dtsCntrtInfo.Tables[9]);
                        }

                        //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤的發票
                        //發票設定
                        GetFEEAMTPREINVSETBind(dtsCntrtInfo.Tables[10], enm頁籤類型.手續費發票);
                        GetFEEAMTPREINVSETBind(dtsCntrtInfo.Tables[11], enm頁籤類型.動保費收入發票);
                        GetFEEAMTPREINVSETBind(dtsCntrtInfo.Tables[12], enm頁籤類型.墊款息收入發票);
                        //發票備註
                        GetFEEAMTPREINVNOTEBind(dtsCntrtInfo.Tables[7]);
                        //展期內容
                        GetFEEAMTPREINVOICEBind(dtsCntrtInfo.Tables[13], enm頁籤類型.手續費發票);
                        GetFEEAMTPREINVOICEBind(dtsCntrtInfo.Tables[14], enm頁籤類型.動保費收入發票);
                        GetFEEAMTPREINVOICEBind(dtsCntrtInfo.Tables[15], enm頁籤類型.墊款息收入發票);
                    }
                }
                if (this.hdnPREINVSETID.Value.Trim() != "")
                {
                    this.btnUS.Attributes.Remove("display:none;");
                    this.btnUS.Attributes.Add("style", "display:;");
                }
            }
            catch (Exception ex)
            {

                Alert(ex.Message);
            }
        }
    }

    /// <summary>
    /// FormDDLBinding
    /// </summary>
    /// <param name=""></param>
    /// <returns>無</returns>
    /// <remark>畫面下拉選單Binding</remark>
    private void FormDDLBinding()
    {
      try
      {
        ReturnObject<DataSet> objReturnDataSet = GetDrpData();
        if (objReturnDataSet.ReturnSuccess)
        {
          DataSet dtsData = objReturnDataSet.ReturnData;

          this.drpCODE.DataSource = dtsData.Tables[0].DefaultView;
          this.drpCODE.DataBind();

          if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) != (int)enm承作類型.AR)
          {
              Session["MLDCONTRACTTARGET"] = dtsData.Tables[1];
          }
        }
        else
        {
          Alert(objReturnDataSet.ReturnMessage);
        }
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }

    /// <summary>
    /// GetDrpData
    /// </summary>
    /// <param name=""></param>
    /// <returns>以Dataset傳回下拉選單資料</returns>
    private ReturnObject<DataSet> GetDrpData()
    {

      Comus.HtmlSubmitControl objComusSubmit;
      string strObjID;
      StringBuilder stbStoreProcedure = new StringBuilder();
      StringBuilder stbQueryCondition = new StringBuilder(); ;
      ReturnObject<DataSet> dtsRtnObj;
      string[] aryParameter = new string[2];
      try
      {
        strObjID = "ITG.CommDBService.MutiQueryByStoreProcedure";
       

        //郵編區號
        stbStoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
        stbQueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        //標的物信息
        if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) != (int)enm承作類型.AR)
        {
            stbStoreProcedure.Append("SP_ML4001_Q03" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        }
        objComusSubmit = new Comus.HtmlSubmitControl();
        objComusSubmit.VirtualPath = GetComusVirtualPath();
        aryParameter[0] = stbStoreProcedure.ToString();
        aryParameter[1] = stbQueryCondition.ToString();
        dtsRtnObj = objComusSubmit.SubmitEx<DataSet>(strObjID, aryParameter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return dtsRtnObj;
    }

    private void GetMLDPREINVSPLITData()
    {
        DataTable dtbMLDPREINVSPLIT = new DataTable("MLDPREINVSPLIT");
        //預開發票彙開設定代碼
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSPLITID", System.Type.GetType("System.String")));
        //預開發票設定代碼
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSETID", System.Type.GetType("System.String")));
        //發票群組
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVGRP", System.Type.GetType("System.String")));
        //單體編號
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
        //對象統編
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
        //對象名稱
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
        //月付款
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
        //發票郵遞區號
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
        //發票地址
        dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
        //DataRow dtrRwTmpl = null;

        //string strCntrNo = this.txtCNTRNO.Text;

        //dtrRwTmpl = dtbMLDPREINVSPLIT.NewRow();
        //dtrRwTmpl["CNTRNO"] = "";
        //dtrRwTmpl["INSTALLMENTSID"] = "true";
        //dtrRwTmpl["ISSUE"] = strCntrNo;
        //dtrRwTmpl["PRINCIPAL"] = "0";
        //dtrRwTmpl["INTEREST"] = "0";
        //dtrRwTmpl["BALANCE"] = "0";
        //dtbMLDPREINVSPLIT.Rows.Add(dtrRwTmpl);

        Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
    }

    private void GetMLDCONTRACTTARGET_NewData()
    {
        DataTable dtbMLDCONTRACTTARGET_New = new DataTable("MLDCONTRACTTARGET_New");
        //單體編號
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
        //擔保品金額比例
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETPRICEA", System.Type.GetType("System.String")));
        //擔保品金額
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
        //DataRow dtrRwTmpl = null;

        //string strCntrNo = this.txtCNTRNO.Text;

        //dtrRwTmpl = dtbMLDPREINVSPLIT.NewRow();
        //dtrRwTmpl["CNTRNO"] = "";
        //dtrRwTmpl["INSTALLMENTSID"] = "true";
        //dtrRwTmpl["ISSUE"] = strCntrNo;
        //dtrRwTmpl["PRINCIPAL"] = "0";
        //dtrRwTmpl["INTEREST"] = "0";
        //dtrRwTmpl["BALANCE"] = "0";
        //dtbMLDPREINVSPLIT.Rows.Add(dtrRwTmpl);

        Session["MLDCONTRACTTARGET_New"] = dtbMLDCONTRACTTARGET_New;
    }

    private void MLDPREINVSPLIT_Init()
    {
        if (Session["MLDPREINVSPLIT"] == null)
        {
            //初始化欄位
            DataTable dtbMLDPREINVSPLIT = new DataTable("MLDPREINVSPLIT");
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSPLITID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSETID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVGRP", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
            Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
        }
    }

    private void GetMLDCONTRACTCASHFLOWData()
    {
        DataTable dtbMLDCONTRACTCASHFLOW = new DataTable("MLDCONTRACTCASHFLOW");
        //合約號碼
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
        //現金流量明細編號
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("INSTALLMENTSID", System.Type.GetType("System.String")));
        //期數
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
        //租金(未稅)
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("RENT", System.Type.GetType("System.String")));
        //租金(含稅)
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("RENTTAX", System.Type.GetType("System.String")));
        //本金
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("PRINCIPAL", System.Type.GetType("System.String")));
        //本金稅
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("PRINCIPALTAX", System.Type.GetType("System.String")));
        //利息
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("INTEREST", System.Type.GetType("System.String")));
        //利息稅
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("INTERESTTAX", System.Type.GetType("System.String")));
        //本金餘額
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("BALANCE", System.Type.GetType("System.String")));
        //DataRow dtrRwTmpl = null;

        //string strCntrNo = this.txtCNTRNO.Text;

        //dtrRwTmpl = dtbMLDCONTRACTCASHFLOW.NewRow();
        //dtrRwTmpl["CNTRNO"] = "";
        //dtrRwTmpl["INSTALLMENTSID"] = "true";
        //dtrRwTmpl["ISSUE"] = strCntrNo;
        //dtrRwTmpl["PRINCIPAL"] = "0";
        //dtrRwTmpl["INTEREST"] = "0";
        //dtrRwTmpl["BALANCE"] = "0";
        //dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrRwTmpl);

        ViewState["MLDCONTRACTCASHFLOW"] = dtbMLDCONTRACTCASHFLOW;
    }

    private void MLDPREINVOPENCNTRCNTR_Init(DataTable dtbMLDPREINVOPENCNTRCNTRTmp)
    {
        //初始化欄位
        DataTable dtbMLDPREINVOPENCNTR = new DataTable("MLDPREINVOPENCNTR");
        //匯開編號
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
        //匯開主約編號
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("OPENCNTRNO", System.Type.GetType("System.String")));
        //匯開主約編號
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("MTRCNTRNO", System.Type.GetType("System.String")));
        //預開發票月份
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
        //預開發票月份
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
        //預開發票月份
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
        //預開發票月份
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("INVOPENMONTH", System.Type.GetType("System.String")));
        //幾月一開
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("OPENMONTH", System.Type.GetType("System.String")));
        //指定日期
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("ORDERDATE", System.Type.GetType("System.String")));
        //期數
        dtbMLDPREINVOPENCNTR.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
        if (dtbMLDPREINVOPENCNTRCNTRTmp != null && dtbMLDPREINVOPENCNTRCNTRTmp.Rows.Count > 0)
        {
            dtbMLDPREINVOPENCNTR = dtbMLDPREINVOPENCNTRCNTRTmp;
        }
        else
        {
            DataRow dtrMLDPREINVOPENCNTRCNTRT = dtbMLDPREINVOPENCNTR.NewRow();
            dtrMLDPREINVOPENCNTRCNTRT["CNTRNO"] = this.txtCNTRNO.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["OPENCNTRNO"] = this.txtCNTRNO.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["MTRCNTRNO"] = this.txtRENTSTDTM.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["TARGETID"] = this.txtPAYMONTHK.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["TARGETNAME"] = this.txtRENTSTDTD.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["INVOICEADDR"] = this.txtCUSTID.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["INVOPENMONTH"] = this.txtCUSTNAME.Text.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["OPENMONTH"] = this.hdnMAINTYPE.Value.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["ORDERDATE"] = this.hdnMAINTYPE.Value.Trim();
            dtrMLDPREINVOPENCNTRCNTRT["ISSUE"] = this.hdnMAINTYPE.Value.Trim();
            dtbMLDPREINVOPENCNTR.Rows.Add(dtrMLDPREINVOPENCNTRCNTRT);
        }
        Session["MLDPREINVOPENCNTR"] = dtbMLDPREINVOPENCNTR;
    }

    private void MLDPREINVOPENMAJCNTR_Init(DataTable dtbMLDPREINVOPENMAJCNTRTmp)
    {
        //初始化欄位
        DataTable dtbMLDPREINVOPENMAJCNTR = new DataTable("MLDPREINVOPENMAJCNTR");
        //匯開主約編號
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
        //發票開立月份
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("RENTSTDTM", System.Type.GetType("System.String")));
        //發票指定日期
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("ORDERDATE", System.Type.GetType("System.String")));
        //幾月一開
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("OPENMONTH", System.Type.GetType("System.String")));
        //客戶編號
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("CUSTID", System.Type.GetType("System.String")));
        //總期數
        dtbMLDPREINVOPENMAJCNTR.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
        if (dtbMLDPREINVOPENMAJCNTRTmp != null && dtbMLDPREINVOPENMAJCNTRTmp.Rows.Count > 0)
        {
            dtbMLDPREINVOPENMAJCNTR = dtbMLDPREINVOPENMAJCNTRTmp;
            //bool bolOPENMASTER = false;
            //if (dtbMLDPREINVOPENMAJCNTR.Rows[intRow]["CNTRNO"].ToString().Trim() == this.txtCNTRNO.Text.Trim())
            //{
            //    bolOPENMASTER = true;
            //    break;
            //}
            //if (bolOPENMASTER)
            //{
            //    this.chkMerge.Attributes.Remove("display:none");
            //    this.chkMerge.Attributes.Remove("display:");
            //    this.chkMerge.Checked = true;
            //    this.hdnOPENMASTER.Value = "1";
            //    this.hdnOPENCNTRNO.Value = this.txtCNTRNO.Text.Trim();
            //}
            //else
            //{
            //    this.chkMerge.Attributes.Remove("display:");
            //    this.chkMerge.Attributes.Remove("display:none");
            //    this.chkMerge.Checked = false;
            //    this.hdnOPENMASTER.Value = "";
            //    this.hdnOPENCNTRNO.Value = "";
            //}
            this.ddlSingle.SelectedValue = "1";
            this.ddlSingle.Enabled = true;
            this.btnSplit.Attributes.Remove("display:");
            this.btnSplit.Attributes.Remove("display:none");
            this.ddlSummary.SelectedValue = "1";
            this.ddlSummary.Enabled = true;
            this.btnMerge.Attributes.Remove("display:none");
            this.btnMerge.Attributes.Remove("display:");
        }
        else
        {
            DataRow dtrMLDPREINVOPENMAJCNTR = dtbMLDPREINVOPENMAJCNTR.NewRow();
            dtrMLDPREINVOPENMAJCNTR["CNTRNO"] = this.txtCNTRNO.Text.Trim();
            dtrMLDPREINVOPENMAJCNTR["RENTSTDTM"] = this.txtRENTSTDTM.Text.Trim();
            dtrMLDPREINVOPENMAJCNTR["ORDERDATE"] = this.txtPAYMONTHK.Text.Trim();
            dtrMLDPREINVOPENMAJCNTR["OPENMONTH"] = this.txtRENTSTDTD.Text.Trim();
            dtrMLDPREINVOPENMAJCNTR["CUSTID"] = this.txtCUSTID.Text.Trim();
            dtrMLDPREINVOPENMAJCNTR["ISSUE"] = this.txtCUSTNAME.Text.Trim();
            dtbMLDPREINVOPENMAJCNTR.Rows.Add(dtrMLDPREINVOPENMAJCNTR);
        }
        Session["MLDPREINVOPENMAJCNTR"] = dtbMLDPREINVOPENMAJCNTR;
    }


    private void GetMLDCONTRACTINSTBind(DataTable dtbMLDCONTRACTINST, DataTable dtbMLDCONTRACTCASHFLOW)
    {

      Decimal decTTLRent = 0;
      if (dtbMLDCONTRACTINST.Rows.Count == 4)
      {
          this.txtRSTARTPAY1.Text = dtbMLDCONTRACTINST.Rows[0][2].ToString();
          this.txtRENDPAY1.Text = dtbMLDCONTRACTINST.Rows[0][3].ToString();
          this.txtRPRINCIPAL1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][4]).ToString("#,##0");
          this.txtRPRINCIPALTAX1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][5]).ToString("#,##0");

          this.hdnFinalLevel.Value = this.txtRENDPAY1.Text;

          if (!String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租))
          {
              for (int intRowCnt = 0; intRowCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intRowCnt++)
              {
                  if (System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) >= System.Convert.ToInt32(this.txtRSTARTPAY1.Text) && System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) <= System.Convert.ToInt32(this.txtRENDPAY1.Text))
                  {
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL1.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
                      decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
                  }
                  else
                  {
                      if (dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString() == "0")
                      {
                          if (this.txtFIRSTPAY.Text != "0")
                          {
                              decimal decFIRSTPAY = System.Convert.ToDecimal(this.txtFIRSTPAY.Text);
                              dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENT"] = System.Convert.ToDecimal(txtFIRSTPAY.Text);
                              dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENTTAX"] = "0";
                          }
                      }
                  }
              }
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtRSTARTPAY1.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
              {
                  for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY1.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY1.Text); intRowCnt++)
                  {
                      DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                      dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                      dtrMLDCONTRACTCASHFLOW["INSTALLMENTSID"] = "";
                      dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                      dtrMLDCONTRACTCASHFLOW["PRINCIPAL"] = "";
                      dtrMLDCONTRACTCASHFLOW["INTEREST"] = "";
                      dtrMLDCONTRACTCASHFLOW["BALANCE"] = "";
                      dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL1.Text); ;
                      dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                  }
                  if (String.IsNullOrEmpty(this.txtRSTARTPAY2.Text))
                  {
                      if (this.hdnPREINVSETID.Value == "")
                      {
                          MLDPREINVSPLIT_Init();
                      }
                  }
              }
              else
              {
                  if (!String.IsNullOrEmpty(this.txtRSTARTPAY1.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR))
                  {
                      for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY1.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY1.Text); intRowCnt++)
                      {
                          decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
                      }
                  }
              }
          }
     

 
          this.txtRSTARTPAY2.Text = dtbMLDCONTRACTINST.Rows[1][2].ToString();
          this.txtRENDPAY2.Text = dtbMLDCONTRACTINST.Rows[1][3].ToString();
          if (this.txtRSTARTPAY2.Text.Trim() != "")
          {
              this.txtRPRINCIPAL2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][4]).ToString("#,##0");
              this.txtRPRINCIPALTAX2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][5]).ToString("#,##0");
              this.hdnFinalLevel.Value = this.txtRENDPAY2.Text;
          }

          if (!String.IsNullOrEmpty(this.txtRSTARTPAY2.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租))
          {
              for (int intRowCnt = 0; intRowCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intRowCnt++)
              {
                  if (System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) >= System.Convert.ToInt32(this.txtRSTARTPAY2.Text) && System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) <= System.Convert.ToInt32(this.txtRENDPAY2.Text))
                  {
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL2.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
                      decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
                  }
              }
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtRSTARTPAY2.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
              {
                  for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY2.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY2.Text); intRowCnt++)
                  {
                      DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                      dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                      dtrMLDCONTRACTCASHFLOW["INSTALLMENTSID"] = "";
                      dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                      dtrMLDCONTRACTCASHFLOW["PRINCIPAL"] = "";
                      dtrMLDCONTRACTCASHFLOW["INTEREST"] = "";
                      dtrMLDCONTRACTCASHFLOW["BALANCE"] = "";
                      dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL2.Text); ;
                      dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                  }
              }
              else
              {
                  if (!String.IsNullOrEmpty(this.txtRSTARTPAY2.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR))
                  {
                      for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY2.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY2.Text); intRowCnt++)
                      {
                          decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
                      }
                  }
              }
          }

          this.txtRSTARTPAY3.Text = dtbMLDCONTRACTINST.Rows[2][2].ToString();
          this.txtRENDPAY3.Text = dtbMLDCONTRACTINST.Rows[2][3].ToString();
          if (this.txtRSTARTPAY3.Text.Trim() != "")
          {
              this.txtRPRINCIPAL3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][4]).ToString("#,##0");
              this.txtRPRINCIPALTAX3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][5]).ToString("#,##0");
              this.hdnFinalLevel.Value = this.txtRENDPAY3.Text;
          }

          if (!String.IsNullOrEmpty(this.txtRSTARTPAY3.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租))
          {
              for (int intRowCnt = 0; intRowCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intRowCnt++)
              {
                  if (System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) >= System.Convert.ToInt32(this.txtRSTARTPAY3.Text) && System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) <= System.Convert.ToInt32(this.txtRENDPAY3.Text))
                  {
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL3.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
                  }
              }
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtRSTARTPAY3.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
              {
                  for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY3.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY3.Text); intRowCnt++)
                  {
                      DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                      dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                      dtrMLDCONTRACTCASHFLOW["INSTALLMENTSID"] = "";
                      dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                      dtrMLDCONTRACTCASHFLOW["PRINCIPAL"] = "";
                      dtrMLDCONTRACTCASHFLOW["INTEREST"] = "";
                      dtrMLDCONTRACTCASHFLOW["BALANCE"] = "";
                      dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL3.Text); ;
                      dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                  }
              }
              else
              {
                  if (!String.IsNullOrEmpty(this.txtRSTARTPAY3.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR))
                  {
                      for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY3.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY3.Text); intRowCnt++)
                      {
                          decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
                      }
                  }
              }
          }

          this.txtRSTARTPAY4.Text = dtbMLDCONTRACTINST.Rows[3][2].ToString();
          this.txtRENDPAY4.Text = dtbMLDCONTRACTINST.Rows[3][3].ToString();
          if (this.txtRSTARTPAY4.Text.Trim() != "")
          {
              this.txtRPRINCIPAL4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][4]).ToString("#,##0");
              this.txtRPRINCIPALTAX4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][5]).ToString("#,##0");
              this.hdnFinalLevel.Value = this.txtRENDPAY4.Text;
          }

          if (!String.IsNullOrEmpty(this.txtRSTARTPAY4.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租))
          {
             for (int intRowCnt = 0; intRowCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intRowCnt++)
             {
                 if (System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) >= System.Convert.ToInt32(this.txtRSTARTPAY4.Text) && System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["ISSUE"].ToString()) <= System.Convert.ToInt32(this.txtRENDPAY4.Text))
                 {
                    dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL4.Text);
                    dtbMLDCONTRACTCASHFLOW.Rows[intRowCnt]["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
                 }
             }
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtRSTARTPAY4.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
              {
                  for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY4.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY4.Text); intRowCnt++)
                  {
                      DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                      dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                      dtrMLDCONTRACTCASHFLOW["INSTALLMENTSID"] = "";
                      dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                      dtrMLDCONTRACTCASHFLOW["PRINCIPAL"] = "";
                      dtrMLDCONTRACTCASHFLOW["INTEREST"] = "";
                      dtrMLDCONTRACTCASHFLOW["BALANCE"] = "";
                      dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL4.Text); ;
                      dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
                      dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                  }
              }
              else
              {
                  if (!String.IsNullOrEmpty(this.txtRSTARTPAY4.Text) && !String.IsNullOrEmpty(this.hdnMAINTYPE.Value) && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR))
                  {
                      for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY4.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY4.Text); intRowCnt++)
                      {
                          decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
                      }
                  }
              }
          }
          this.hdnTTLRent.Value = decTTLRent.ToString("##,##0");
          ViewState["MLDCONTRACTINST"] = dtbMLDCONTRACTINST;
          ViewState["MLDCONTRACTCASHFLOW"] = dtbMLDCONTRACTCASHFLOW;

      }
    }

    private void GetCntrNoBind(DataTable dtbData)
    {
      if (dtbData.Rows.Count > 0)
      {
        Itg.Community.Util.SetValue(this.Page, dtbData, NVC_MLMCONTRACT_Data);
      }
    }

    private void GetMLMPREINVOICEBind(DataTable dtbMLMPREINVOICE)
    {
        if (dtbMLMPREINVOICE.Rows.Count > 0)
        {
            if (ViewState["MLMPREINVOICE"] == null)
            {
                rptPREINVOICEInit();
                this.rptData.DataSource = dtbMLMPREINVOICE;
                this.rptData.DataBind();

                for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
                {
                    if (("" + dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString().Trim()) != "")
                    {
                        this.hdnOPENCNTRNO.Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString().Trim();

                        if (this.hdnOPENCNTRNO.Value.Trim() == this.txtCNTRNO.Text.Trim())
                        {
                            this.chkMerge.Checked = true;
                            this.hdnOPENMASTER.Value = "1";
                        }
                        this.btnMerge.Attributes.Remove("display:none");
                        this.btnMerge.Attributes.Remove("display:");
                        this.chkMerge.Attributes.Remove("display:none");
                        this.chkMerge.Attributes.Remove("display:");
                    }
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
                    this.drpINVKIND1.SelectedValue = ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue;
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpTAXTYPE")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["TAXTYPE"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();

                    //UPD BY HANK 20170926 本體分差發票增加載具號碼，捐贈，跟愛心碼
                    //UPD BY HANK 20171102 客戶有8碼統編者(即發票聯式三聯式)不可V選捐贈
                    this.txtCARRIEID.Text = dtbMLMPREINVOICE.Rows[intRowCnt]["CARRIEID"].ToString().Trim();
                    if (txtCUSTID.Text.Trim().Length == 8)
                    {
                        this.chkDONATEMARK.Attributes.Add("Disabled", "true");
                        this.chkDONATEMARK.Checked = false;
                    }
                    else if (this.drpINVKIND1.SelectedValue == "3")
                    {
                        this.chkDONATEMARK.Attributes.Add("Disabled", "true");
                        this.chkDONATEMARK.Checked = false;
                    }
                    else
                    {
                        if (dtbMLMPREINVOICE.Rows[intRowCnt]["DONATEMARK"].ToString().Trim() == "Y")
                        {
                            this.chkDONATEMARK.Checked = true;
                        }
                        else
                        {
                            this.chkDONATEMARK.Checked = false;
                        }
                    }
                    this.txtNPOBAN.Text = dtbMLMPREINVOICE.Rows[intRowCnt]["NPOBAN"].ToString().Trim();

                    //UPD BY HANK 20170926 勾選捐贈後載具號碼反灰，愛心碼才可以輸入
                    if (this.chkDONATEMARK.Checked)
                    {
                        this.txtCARRIEID.Enabled = false;
                        this.txtNPOBAN.Enabled = true;
                    }
                    else
                    {
                        this.txtCARRIEID.Enabled = true;
                        this.txtNPOBAN.Enabled = false;
                    }
                }
                ViewState["MLMPREINVOICE"] = dtbMLMPREINVOICE;

            }
        }
    }


    private void GetMLDPREINVSPLITBind(DataTable dtbMLDPREINVSPLIT)
    {
        String strPrevINVGRP = "";
        Decimal decMONTHPAY = 0;
        Decimal decMONTHPAYTTL = 0;
        if (dtbMLDPREINVSPLIT.Rows.Count > 0)
        {
            Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
            DataTable dtbMLDCONTRACTTARGET_New = new DataTable("MLDCONTRACTTARGET_New");
            //單體編號
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
            //擔保品金額比例
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETPRICEA", System.Type.GetType("System.String")));
            //擔保品金額 
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
            //郵遞區號
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
            //郵遞區號地址
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
            //發票記送地址
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
            //發票統編
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
            //發票抬頭
            dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));

            for (int i = 0; i < dtbMLDPREINVSPLIT.Rows.Count; i++)
            {
                decMONTHPAYTTL += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"].ToString().Trim());
            }
            for (int i = 0; i < dtbMLDPREINVSPLIT.Rows.Count; i++)
            {
                if (strPrevINVGRP != dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim())
                {
                    decMONTHPAY = 0;
                    decMONTHPAY += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"].ToString().Trim());
                    DataRow dtrMLDCONTRACTTARGET_New = dtbMLDCONTRACTTARGET_New.NewRow();
                    dtrMLDCONTRACTTARGET_New["UNITID"] = dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["TARGETPRICEA"] = (System.Convert.ToDecimal(decMONTHPAY) / decMONTHPAYTTL).ToString();
                    dtrMLDCONTRACTTARGET_New["MONTHPAY"] = decMONTHPAY.ToString("##,##0");
                    dtrMLDCONTRACTTARGET_New["INVZIPCODE"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODE"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["INVZIPCODES"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["INVOICEADDR"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"].ToString().Trim() + dtbMLDPREINVSPLIT.Rows[i]["INVOICEADDR"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["TARGETID"] = dtbMLDPREINVSPLIT.Rows[i]["TARGETID"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["TARGETNAME"] = dtbMLDPREINVSPLIT.Rows[i]["TARGETNAME"].ToString().Trim();
                    dtbMLDCONTRACTTARGET_New.Rows.Add(dtrMLDCONTRACTTARGET_New);
                    strPrevINVGRP = dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim();
                }
                else
                {
                    decMONTHPAY += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"].ToString().Trim());
                    if (dtbMLDCONTRACTTARGET_New.Rows.Count != 0)
                    {
                        DataRow dtrMLDCONTRACTTARGET_New = dtbMLDCONTRACTTARGET_New.Rows[dtbMLDCONTRACTTARGET_New.Rows.Count - 1];
                        dtrMLDCONTRACTTARGET_New["TARGETPRICEA"] = (System.Convert.ToDecimal(decMONTHPAY) / decMONTHPAYTTL).ToString();
                        dtrMLDCONTRACTTARGET_New["MONTHPAY"] = decMONTHPAY.ToString("##,##0");
                    }
                }
            }
            Session["MLDCONTRACTTARGET_New"] = dtbMLDCONTRACTTARGET_New;
        }
    }
    

    private void GetMLMPREINVSETBind(DataTable dtbData)
    {
      if (dtbData.Rows.Count > 0)
      {
        Itg.Community.Util.SetValue(this.Page, dtbData, NVC_MLMPREINVSET_Data);
      }
      if (this.ddlSingle.SelectedValue == "2")
      {
          this.ddlSummary.Enabled = false;
          if (this.txtRSTARTPAY2.Text.Trim() == "")
          {
              this.btnSplit.Attributes.Remove("display:none;");
              this.btnSplit.Attributes.Add("style", "display:;");
          }
      }
    }

    private void GetMLDPREINVNOTEBind(DataTable dtbData)
    {
        if (dtbData.Rows.Count > 0)
        {
            for (Int32 intRowCnt = 0; intRowCnt < dtbData.Rows.Count; intRowCnt++)
            {
                switch (System.Convert.ToInt32(dtbData.Rows[intRowCnt]["INVDESCTYPE"].ToString()))
                {
                    case (int)(enm發票類別.租金):
                        this.hdnPREINVNOTEID1.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[0].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[0].Attributes.Add("style","display:");
                        this.btn111.Attributes.Remove("display:none");
                        this.btn111.Attributes.Add("style", "display:");                        
                        if (dtbData.Rows[intRowCnt]["CONTRACTNO"].ToString() == "1")
                        {
                            this.chk11.Checked = true; 
                        }
                        if (dtbData.Rows[intRowCnt]["ISSUE"].ToString() == "1")
                        {
                            this.chk12.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["RENTALPREIOD"].ToString() == "1")
                        {
                            this.chk13.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["LLVLNUM"].ToString() == "1")
                        {
                            this.chk14.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk15.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk16.Checked = true;
                        }
                        this.hdnSPECNOTE1.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                    case (int)(enm發票類別.押金設算息):
                        this.hdnPREINVNOTEID2.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[1].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[1].Attributes.Add("style","display:");
                        this.btn222.Attributes.Remove("display:none");
                        this.btn222.Attributes.Add("style", "display:");
                        if (dtbData.Rows[intRowCnt]["CONTRACTNO"].ToString() == "1")
                        {
                            this.chk21.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ISSUE"].ToString() == "1")
                        {
                            this.chk22.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["RENTALPREIOD"].ToString() == "1")
                        {
                            this.chk23.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["LLVLNUM"].ToString() == "1")
                        {
                            this.chk24.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk25.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk26.Checked = true;
                        }
                        this.hdnSPECNOTE2.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                    case (int)(enm發票類別.本體):
                        this.hdnPREINVNOTEID4.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Add("style","display:");
                        this.btn444.Attributes.Remove("display:none");
                        this.btn444.Attributes.Add("style", "display:");
                        if (dtbData.Rows[intRowCnt]["CONTRACTNO"].ToString() == "1")
                        {
                            this.chk41.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ISSUE"].ToString() == "1")
                        {
                            this.chk42.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["RENTALPREIOD"].ToString() == "1")
                        {
                            this.chk43.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["LLVLNUM"].ToString() == "1")
                        {
                            this.chk44.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk45.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk46.Checked = true;
                        }
                        this.hdnSPECNOTE4.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                    case (int)(enm發票類別.分差):
                        this.hdnPREINVNOTEID4.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[4].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[4].Attributes.Add("style","display:");
                        this.btn555.Attributes.Remove("display:none");
                        this.btn555.Attributes.Add("style", "display:");
                        if (dtbData.Rows[intRowCnt]["CONTRACTNO"].ToString() == "1")
                        {
                            this.chk51.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ISSUE"].ToString() == "1")
                        {
                            this.chk52.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["RENTALPREIOD"].ToString() == "1")
                        {
                            this.chk53.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["LLVLNUM"].ToString() == "1")
                        {
                            this.chk54.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk55.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk56.Checked = true;
                        }
                        this.hdnSPECNOTE5.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                    case (int)(enm發票類別.本體加分差):
                        this.hdnPREINVNOTEID6.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[5].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[5].Attributes.Add("style","display:");
                        this.btn666.Attributes.Remove("display:none");
                        this.btn666.Attributes.Add("style", "display:");
                        if (dtbData.Rows[intRowCnt]["CONTRACTNO"].ToString() == "1")
                        {
                            this.chk61.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ISSUE"].ToString() == "1")
                        {
                            this.chk62.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["RENTALPREIOD"].ToString() == "1")
                        {
                            this.chk63.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["LLVLNUM"].ToString() == "1")
                        {
                            this.chk64.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk65.Checked = true;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk66.Checked = true;
                        }
                        this.hdnSPECNOTE6.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                }
            }
        }
    }

    
    private ReturnObject<DataSet> GetCaseDataByID(string strCntrNo)
    {

      Comus.HtmlSubmitControl objComusSubmit;
      string strObjID;
      StringBuilder stbStoreProcedure = new StringBuilder();
      StringBuilder stbQueryCondition = new StringBuilder(); ;
      ReturnObject<DataSet> dtsReturnDataSet;
      string[] aryParameter = new string[2];
      try
      {
        strObjID = "ITG.CommDBService.MutiQueryByStoreProcedure";
       
        //綁定合約基本[0]
        stbStoreProcedure.Append("SP_ML4001_Q02" + GSTR_RowDelimitChar);
        stbQueryCondition.Append(" AND MLMCONTRACT.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        //撥款案件租賃分期明細檔[1] MLDCONTRACTINST
        stbStoreProcedure.Append("SP_ML4001_Q04" + GSTR_RowDelimitChar);
        stbQueryCondition.Append(" AND CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        //綁定現金流量[2]
        stbStoreProcedure.Append("SP_ML4001_Q05" + GSTR_RowDelimitChar);
        stbQueryCondition.Append(" AND MLDCONTRACTCASHFLOW.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        //預開發票設定主檔[3]
        stbStoreProcedure.Append("SP_ML4001_Q12" + GSTR_RowDelimitChar);
        stbQueryCondition.Append(" AND D.CUSTID = ''''" + this.txtCUSTID.Text.Trim() + "''''  AND A.OPENMONTH = ''''" + this.txtPAYMONTHK.Text.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        if (this.hdnPREINVSETID.Value.Trim() != "")
        {
            //預開發票設定主檔[4]
            stbStoreProcedure.Append("SP_ML4001_Q11" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //預開發票資料檔[5]
            stbStoreProcedure.Append("SP_ML4001_Q10" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //預開發票品名明細檔[6]
            stbStoreProcedure.Append("SP_ML4001_Q09" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND B.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //預開發票備註設定檔[7]
            stbStoreProcedure.Append("SP_ML4001_Q08" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND A.PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //預開發票拆分設定檔[8]
            stbStoreProcedure.Append("SP_ML4001_Q07" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND A.PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //資料彙開檔[9]
            stbStoreProcedure.Append("SP_ML4001_Q06" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND A.CNTRNO  = ''''" + this.txtCNTRNO.Text + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //UDP 20170110 By SS Gordon Reason:取得手續費，動保費，墊款息的設定資料與展期資料
            //手續費設定資料[10]
            stbStoreProcedure.Append("SP_ML4001_Q16" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + "'',''" + ((int)enm發票類別.補貼款收入).ToString() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //動保費設定資料[11]
            stbStoreProcedure.Append("SP_ML4001_Q16" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + "'',''" + ((int)enm發票類別.手續費收入).ToString() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //墊款息設定資料[12]
            stbStoreProcedure.Append("SP_ML4001_Q16" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + "'',''" + ((int)enm發票類別.墊款息收入).ToString() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //手續費展期資料[13]
            stbStoreProcedure.Append("SP_ML4001_Q14" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + "'',''0" + ((int)enm頁籤類型.手續費發票).ToString() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //動保費展期資料[14]
            stbStoreProcedure.Append("SP_ML4001_Q14" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + "'',''0" + ((int)enm頁籤類型.動保費收入發票).ToString() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //墊款息展期資料[15]
            stbStoreProcedure.Append("SP_ML4001_Q15" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(this.txtCNTRNO.Text + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
        }

        objComusSubmit = new Comus.HtmlSubmitControl();
        objComusSubmit.VirtualPath = GetComusVirtualPath();
        aryParameter[0] = stbStoreProcedure.ToString();
        aryParameter[1] = stbQueryCondition.ToString();
        dtsReturnDataSet = objComusSubmit.SubmitEx<DataSet>(strObjID, aryParameter);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return dtsReturnDataSet;
    }


#region 控件事件

  /// <summary>
  /// 展期按鈕事件
  /// </summary>
  /// <param name="start">object</param>
  /// <param name="start">EventArgs</param>
  protected void btnUS_Click(object sender, EventArgs e)
  {
      DataTable dtbMLMPREINVOICE = new DataTable("MLMPREINVOICE");
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVID", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESC", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMTDESC", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESCTYPE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVKIND", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREOPENWAY", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("RENTYEARS", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVYYYYMM", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAXTYPE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("AMOUNT", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAX", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("DISAMT", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMT", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMTTAX", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INSTAMT", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INSTAMTTAX", System.Type.GetType("System.Decimal")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("ORDERDAY", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("SPECNOTE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("BZ", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLIT", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLITNME", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLE", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLENME", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSUMMARY", System.Type.GetType("System.String")));
      dtbMLMPREINVOICE.Columns.Add(new DataColumn("MTRCNTRNO", System.Type.GetType("System.String")));

      DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
      DataTable dtbMLDPREINVOPEN = (DataTable)Session["MLDPREINVOPEN"];
      DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];

      DateTime dtmRENTSTDT = System.Convert.ToDateTime(this.txtRENTSTDT.Text);
      System.DateTime ThisMonEndDay = new System.DateTime(dtmRENTSTDT.Year, dtmRENTSTDT.Month, 1);
      Boolean bolMonEndDay = false;
      if (ThisMonEndDay.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") == this.txtRENTSTDT.Text)
      {
          bolMonEndDay = true;
      }
      else
      {
          bolMonEndDay = false;
      }

      //發票拆立
      DataTable dtbMLDCONTRACTTARGET_New = (DataTable)Session["MLDCONTRACTTARGET_New"];

      Boolean bolMLDPREINVSPLIT = false;

      if (dtbMLDPREINVSPLIT != null)
      {
          if (dtbMLDPREINVSPLIT.Rows.Count != 0)
          {
              bolMLDPREINVSPLIT = true;
          }
      }

      if (this.ddlSingle.SelectedValue == "1")
      {
          bolMLDPREINVSPLIT = false;
          Session["MLDPREINVSPLIT"] = null;
      }

      DataRow dtrRwTmpl = null;

      string strBZ = "";
      string strSingle = "";
      string strINVKIND = Request.Form.GetValues("drpINVKIND1")[0].Trim();

      if (IsPostBack)
      {
          if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
          {
              strSingle = Request.Form.GetValues("ddlSingle")[0].Trim();
          }
          else
          {
              strSingle = "2";
          }
      }
      else
      {
          strSingle = this.ddlSingle.SelectedValue;
      }
      int intContractMonth = 0;
      if (this.txtCONTRACTMONTH.Text.Trim() == "")
      {
          intContractMonth = 1;
      }
      else
      {
          intContractMonth = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
      }
      string strCntrNo = this.txtCNTRNO.Text;
      //發票開起月
      string strPreInvStdt = this.txtRENTSTDTM.Text + "/01";
      //案件起租日
      string strRentStdt = this.txtRENTSTDT.Text;
      //承作類型
      string strMainType = this.txtMAINTYPENM.Text;


      int intEndPay1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
      int intEndPay2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
      int intEndPay3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
      int intEndPay4 = Convert.ToInt32("0" + txtRENDPAY4.Text);

      //前張發票租金年月
      string strPrevRentYYYYMM = "";
      //目前發票租金年月
      string strCurrRntYM = "";
      //前張預開發票年月
      string strPrevINVYYYYMM = "";
      //目前預開發票年月
      string strCurrINVYM = "";

      string strPrevPayDate = "";

      string strPAYMONTHK = this.txtPAYMONTHK.Text;

      DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];

      if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
      {
          //營租
          Int32 intAplyInvMonth = 0;
          if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
          {
              if (!bolMLDPREINVSPLIT)
              {
                  dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
              }
              else
              {
                  dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET_New"];
              }
              String strRntRngSTdt = "";
              String strRntRngEDdt = "";
              Decimal decMONTHPAYTTL = System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);
              for (int i = 0; i < dtbMLDCONTRACTTARGET.Rows.Count; i++)//依據單體個數逐期產生
              {
                  //計算營租發票金額
                  if (i != dtbMLDCONTRACTTARGET.Rows.Count - 1)
                  {
                      dtbMLDCONTRACTTARGET.Rows[i]["MONTHPAY"] = (System.Math.Round(System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[i]["TARGETPRICEA"]) * decMONTHPAYTTL, 0)).ToString("#,##0");
                      decMONTHPAYTTL -= System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[i]["MONTHPAY"]);
                  }
                  else
                  {
                      dtbMLDCONTRACTTARGET.Rows[i]["MONTHPAY"] = decMONTHPAYTTL.ToString("#,##0");
                  }
                  intAplyInvMonth = 0;
                  String strIssue = "";
                  Int32 intIssueCnt = 0;
                  for (int j = 0; j < dtbMLDCONTRACTCASHFLOW.Rows.Count; j++)
                  {
                      //int intPay = Convert.ToInt32(dtbMLDPREINVOPEN.Rows[j]["RPAY"].ToString());
                      dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                      dtrRwTmpl["ISSUE"] = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["ISSUE"]).ToString("00");
                      if (!bolMLDPREINVSPLIT)
                      {
                          dtrRwTmpl["UNITID"] = dtbMLDCONTRACTTARGET.Rows[i]["TARGETID"].ToString().Replace(this.txtCNTRNO.Text, "").Trim();
                      }
                      else
                      {
                          dtrRwTmpl["UNITID"] = dtbMLDCONTRACTTARGET_New.Rows[i]["UNITID"].ToString().Replace(this.txtCNTRNO.Text, "").Trim();
                      }
                      dtrRwTmpl["INVDESC"] = "租金收入";
                      dtrRwTmpl["INVKIND"] = strINVKIND;
                      dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.租金));
                      if (j == 0)
                      {
                          intIssueCnt++;
                          strIssue = "(" + System.Convert.ToDecimal(1 + (intIssueCnt - 1)).ToString("##0") + " ~ " + System.Convert.ToDecimal((intIssueCnt * System.Convert.ToInt32(this.txtPAYMONTHK.Text))).ToString("##0") + ")";
                          dtrRwTmpl["PREOPENWAY"] = "1";
                          strCurrRntYM = System.Convert.ToDateTime(strRentStdt).AddMonths(j).ToString("yyyy/MM/dd");
                          strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(j).ToString("yyyy/MM/dd");
                          strRntRngSTdt = this.txtRENTSTDT.Text;
                          if (bolMonEndDay)
                          {
                              DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1).AddMonths(1);
                              strRntRngEDdt = dtmRntRngSTdt.AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-2).ToString("yyyy/MM/dd");
                              if (strRntRngEDdt.Substring(5, 2) == "02")
                              {
                                  strRntRngEDdt = dtmRntRngSTdt.AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-2).ToString("yyyy/MM/dd");
                              }
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                          }
                      }
                      else
                      {
                          dtrRwTmpl["PREOPENWAY"] = this.ddlAplyTyp.SelectedValue;
                          strCurrRntYM = System.Convert.ToDateTime(strPrevRentYYYYMM).AddMonths(System.Convert.ToInt32("1")).ToString("yyyy/MM/dd");
                          if (intAplyInvMonth == System.Convert.ToInt32(strPAYMONTHK))
                          {
                              strCurrINVYM = System.Convert.ToDateTime(strPrevINVYYYYMM).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).ToString("yyyy/MM/dd");
                              intAplyInvMonth = 0;
                              intIssueCnt++;
                              strIssue = "(" + System.Convert.ToDecimal(1 + (intIssueCnt - 1) * System.Convert.ToInt32(this.txtPAYMONTHK.Text)).ToString("##0") + " ~ " + System.Convert.ToDecimal((intIssueCnt * System.Convert.ToInt32(this.txtPAYMONTHK.Text))).ToString("##0") + ")";
                              if (bolMonEndDay)
                              {
                                  if (strRntRngEDdt.Substring(5, 2) == "02")
                                  {
                                      strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                                  }
                                  else
                                  {
                                      strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                                  }
                              }
                              else
                              {
                                  if (strRntRngEDdt.Substring(5, 2) == "02")
                                  {
                                      strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                                  }
                                  else
                                  {
                                      strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                                  }

//                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                              }
                              DateTime dtmRntRngSTdtTmp = System.DateTime.Now;
                              if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdtTmp))
                              {
                                  if (bolMonEndDay)
                                  {
                                      DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1);
                                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                                      if (strRntRngSTdt.Substring(5, 2) == "02")
                                      {
                                          strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                      }
                                      else
                                      {
                                          strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + "01";
                                          strRntRngEDdt = System.Convert.ToDateTime(strRntRngEDdt).AddMonths(1).AddDays(-2).ToString("yyyy/MM/dd");
                                      }
                                  }
                                  else
                                  {
                                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");

                                      if (System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) > 28)
                                      {
                                          if (strRntRngSTdt.Substring(5, 2) == "02")
                                          {
                                              strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                          }
                                      }
                                  }
                              }
                              else
                              {
                                  strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                                  if (bolMonEndDay)
                                  {
                                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                                  }
                                  else
                                  {
                                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(0).ToString("yyyy/MM/dd");
                                  }
                              }
                          }
                          else
                          {
                              strCurrINVYM = strPrevINVYYYYMM;   
                          }
                      }
                      intAplyInvMonth++;
                      dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                      strPrevRentYYYYMM = strCurrRntYM;
                      if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                      {
                          dtrRwTmpl["PREOPENWAY"] = "1";
                          dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                      }
                      else
                      {
                          if (strCurrINVYM.Substring(0, 7).Trim().Replace("/", "") == this.txtRENTSTDTM.Text.Trim().Replace("/", ""))
                          {
                              dtrRwTmpl["PREOPENWAY"] = "1";
                          }
                          dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                      }
                      strPrevINVYYYYMM = strCurrINVYM;
                      dtrRwTmpl["TAXTYPE"] = "1";
                      if (!bolMLDPREINVSPLIT)
                      {
                          dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                          dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                      }
                      else
                      {
                          dtrRwTmpl["TARGETID"] = dtbMLDCONTRACTTARGET_New.Rows[i]["TARGETID"].ToString().Trim();
                          dtrRwTmpl["TARGETNAME"] = dtbMLDCONTRACTTARGET_New.Rows[i]["TARGETNAME"].ToString().Trim();
                      }
                      if (!bolMLDPREINVSPLIT)
                      {
                          if (dtbMLDCONTRACTTARGET.Rows.Count == 1)
                          {
                              dtrRwTmpl["MONTHPAY"] = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"]).ToString("#,##0");
                          }
                          else
                          {
                              if (i == dtbMLDCONTRACTTARGET.Rows.Count -1)
                              {
                                  Decimal decTmpMONTHPAYTTL = 0; 
                                  for (int intTmpRow = 0;intTmpRow< dtbMLDCONTRACTTARGET.Rows.Count - 1;intTmpRow++)
                                  {
                                      decTmpMONTHPAYTTL += System.Convert.ToDecimal((System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intTmpRow]["TARGETPRICEA"]) * System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"])).ToString("#,##0"));
                                  }
                                  dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"]) - decTmpMONTHPAYTTL).ToString("#,##0");
                              }
                              else
                              {
                                  dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[i]["TARGETPRICEA"]) * System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"])).ToString("#,##0");
                              }
                          }
                      }
                      else
                      {
                          dtrRwTmpl["MONTHPAY"] = System.Convert.ToDecimal(System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"]) * System.Convert.ToDecimal(dtbMLDCONTRACTTARGET_New.Rows[i]["TARGETPRICEA"])).ToString("#,##0");
                      }
                      dtrRwTmpl["DISAMT"] = "0";
                      decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString());
                      decimal decAMOUNT = (decMONTHPAY * 20) / 21;
                      decAMOUNT = System.Math.Round(decAMOUNT, 0);
                      decimal decTAX = decMONTHPAY - decAMOUNT;
                      dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                      dtrRwTmpl["TAX"] = decTAX.ToString();
                      if (!bolMLDPREINVSPLIT)
                      {
                          dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                          dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                          dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                      }
                      else
                      {
                          dtrRwTmpl["INVZIPCODE"] = dtbMLDCONTRACTTARGET_New.Rows[i]["INVZIPCODE"].ToString().Trim();
                          dtrRwTmpl["INVZIPCODES"] = dtbMLDCONTRACTTARGET_New.Rows[i]["INVZIPCODES"].ToString().Trim();
                          dtrRwTmpl["INVOICEADDR"] = dtbMLDCONTRACTTARGET_New.Rows[i]["INVOICEADDR"].ToString().Replace(dtbMLDCONTRACTTARGET_New.Rows[i]["INVZIPCODES"].ToString().Trim(), "").Trim();
                      }
                      dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                      strBZ = "";
                      if (chk11.Checked)
                      {
                          strBZ += "合約編號:" + txtCNTRNO.Text;
                      }
                      if (chk12.Checked)
                      {
                          if (this.txtPAYMONTHK.Text.Trim() == "1")
                          {
                              strBZ += "<BR>" + "期數:" + dtrRwTmpl["ISSUE"].ToString() + "/" + this.txtCONTRACTMONTH.Text.Trim();
                          }
                          else
                          {
                              strBZ += "<BR>" + "期數:" + strIssue + "/" + this.txtCONTRACTMONTH.Text.Trim();
                          }
                      }
                      if (chk13.Checked)
                      {
                          strBZ += "<BR>" + "期間:" + strRntRngSTdt + "~" + strRntRngEDdt;
                      }
                      if (chk14.Checked)
                      {
                          if (System.Convert.ToInt32(strCompId) == (int)enm公司別.和運)
                          {
                              strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM01.Text;
                          }
                          else
                          {
                              strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM02.Text;
                          }
                      }
                      if (chk15.Checked)
                      {
                          strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
                      }
                      if (chk16.Checked)
                      {
                          if (j == 0)
                          {
                              strBZ += "<BR>" + "繳款日:" + txtCUSTFPAYDATE.Text.Trim();
                              strPrevPayDate = txtCUSTFPAYDATE.Text.Trim();
                          }
                          else
                          {
                              if (intAplyInvMonth == 1)
                              {
                                  strBZ += "<BR>" + "繳款日:" + System.DateTime.Parse(strPrevPayDate).AddMonths(System.Convert.ToInt32(this.txtPAYMONTHK.Text)).ToString("yyyy/MM/dd");
                                  strPrevPayDate = System.DateTime.Parse(strPrevPayDate).AddMonths(System.Convert.ToInt32(this.txtPAYMONTHK.Text)).ToString("yyyy/MM/dd");
                              }
                              else
                              {
                                  strBZ += "<BR>" + "繳款日:" + strPrevPayDate;
                              }
                          }
                      }
                      if (hdnSPECNOTE1.Value.ToString() != "")
                      {
                          strBZ += "<BR>" + "特殊備註:" + hdnSPECNOTE1.Value;
                      }

                      dtrRwTmpl["BZ"] = strBZ;
                      dtrRwTmpl["FGSINGLE"] = strSingle;;
                      if (this.ddlSingle.SelectedValue == "1")
                      {
                          dtrRwTmpl["FGSINGLENME"] = "Y";
                      }
                      dtrRwTmpl["FGSPLIT"] = this.hdnFGSPLIT.Value;
                      if (this.hdnFGSPLIT.Value == "1")
                      {
                          dtrRwTmpl["FGSPLITNME"] = "Y";
                      }
                      dtrRwTmpl["FGSUMMARY"] = this.ddlSummary.SelectedValue;
                      if (dtrRwTmpl["FGSUMMARY"].ToString().Trim() == "1")
                      {
                          if (this.hdnOPENMASTER.Value == "1")
                          {
                              dtrRwTmpl["MTRCNTRNO"] = this.txtCNTRNO.Text;
                          }
                          else
                          {
                              dtrRwTmpl["MTRCNTRNO"] = this.hdnOPENCNTRNO.Value;
                          }
                      }
                      else
                      {
                          dtrRwTmpl["MTRCNTRNO"] = "";
                      }
                      dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
                  }
              }
          }
          else //資租案件
          {   
              //判斷是否有頭款
              if (this.txtFIRSTPAY.Text != "0")
              {
                  strCurrRntYM = System.Convert.ToDateTime(strRentStdt).AddMonths(0).ToString("yyyy/MM/dd");
                  strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
                  dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                  dtrRwTmpl["ISSUE"] = "00";
                  dtrRwTmpl["UNITID"] = "";
                  dtrRwTmpl["INVDESC"] = "本金";
                  dtrRwTmpl["RTNAMTDESC"] = "";
                  dtrRwTmpl["INVKIND"] =strINVKIND;
                  dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.租金));
                  dtrRwTmpl["PREOPENWAY"] = "1";
                  if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) < System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                  }
                  else
                  {
                      dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                  }
                  dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                  dtrRwTmpl["TAXTYPE"] = "1";
                  dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                  dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                  dtrRwTmpl["DISAMT"] = "0";
                  dtrRwTmpl["MONTHPAY"] = System.Convert.ToDecimal(this.txtFIRSTPAY.Text).ToString("#,##0");
                  decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString());
                  decimal decAMOUNT = (decMONTHPAY * 20) / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  decimal decTAX = decMONTHPAY - decAMOUNT;
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = decTAX.ToString();
                  dtrRwTmpl["RTNAMT"] = decAMOUNT.ToString();
                  dtrRwTmpl["RTNAMTTAX"] = decTAX.ToString();
                  dtrRwTmpl["INSTAMT"] = "0";
                  dtrRwTmpl["INSTAMTTAX"] = "0";
                  dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                  dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                  dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                  dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                  strBZ = "";
                  strBZ += "合約編號:" + txtCNTRNO.Text;
                  strBZ += "<BR>" + "頭期款";
                  dtrRwTmpl["BZ"] = strBZ;
                  dtrRwTmpl["FGSINGLE"] = "1"; ;
                  dtrRwTmpl["FGSINGLENME"] = "";
                  dtrRwTmpl["FGSPLIT"] = "2";
                  dtrRwTmpl["FGSPLITNME"] = "";
                  dtrRwTmpl["FGSUMMARY"] = "2";// this.ddlSummary.SelectedValue;
                  dtrRwTmpl["MTRCNTRNO"] = "";
                  dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
              }

              String strRntRngSTdt = "";
              String strRntRngEDdt = "";
              decimal decINVOICEAMOUNT = System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[0]["INVOICEAMOUNT"].ToString());
              for (int j = 0; j < dtbMLDCONTRACTCASHFLOW.Rows.Count; j++)
              {
                  dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                  dtrRwTmpl["ISSUE"] = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["ISSUE"]).ToString("00");
                  dtrRwTmpl["UNITID"] = dtbMLDCONTRACTTARGET.Rows[0]["TARGETID"].ToString();
                  dtrRwTmpl["INVDESC"] = "本金";
                  dtrRwTmpl["RTNAMTDESC"] = "利息";
                  dtrRwTmpl["INVKIND"] =strINVKIND;
                  dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.租金));

                  if (j == 0)
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      strCurrRntYM = System.Convert.ToDateTime(strRentStdt).AddMonths(j).ToString("yyyy/MM/dd");
                      strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(j).ToString("yyyy/MM/dd");
                      strRntRngSTdt = this.txtRENTSTDT.Text;
                      if (bolMonEndDay)
                      {
                          DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1).AddMonths(1);
                          strRntRngEDdt = dtmRntRngSTdt.AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-2).ToString("yyyy/MM/dd");
                          if (strRntRngEDdt.Substring(5, 2) == "02")
                          {
                              strRntRngEDdt = dtmRntRngSTdt.AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-2).ToString("yyyy/MM/dd");
                          }
                      }
                      else
                      {
                          strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                      }
                  }
                  else
                  {
                      dtrRwTmpl["PREOPENWAY"] = this.ddlAplyTyp.SelectedValue;
                      strCurrRntYM = System.Convert.ToDateTime(strPrevRentYYYYMM).AddMonths(System.Convert.ToInt32("1")).ToString("yyyy/MM/dd");
                      if (intAplyInvMonth == System.Convert.ToInt32(strPAYMONTHK))
                      {
                          strCurrINVYM = System.Convert.ToDateTime(strPrevINVYYYYMM).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).ToString("yyyy/MM/dd");
                          intAplyInvMonth = 0;
                          if (bolMonEndDay)
                          {
                              if (strRntRngEDdt.Substring(5, 2) == "02")
                              {
                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                              }
                              else
                              {
                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                              }
                          }
                          else
                          {
                              if (strRntRngEDdt.Substring(5, 2) == "02")
                              {
                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                              }
                              else
                              {
                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                              }

                              //                                  strRntRngSTdt = System.DateTime.Parse(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd");
                          }
                          DateTime dtmRntRngSTdtTmp = System.DateTime.Now;
                          if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdtTmp))
                          {
                              if (bolMonEndDay)
                              {
                                  DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1);
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                                  if (strRntRngSTdt.Substring(5, 2) == "02")
                                  {
                                      strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                  }
                                  else
                                  {
                                      strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + "01";
                                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngEDdt).AddMonths(1).AddDays(-2).ToString("yyyy/MM/dd");
                                  }
                              }
                              else
                              {
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");

                                  if (System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) > 28)
                                  {
                                      if (strRntRngSTdt.Substring(5, 2) == "02")
                                      {
                                          strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                      }
                                  }
                              }
                          }
                          else
                          {
                              strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                              if (bolMonEndDay)
                              {
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(-1).ToString("yyyy/MM/dd");
                              }
                              else
                              {
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(strPAYMONTHK)).AddDays(0).ToString("yyyy/MM/dd");
                              }
                          }
                      }
                      else
                      {
                          strCurrINVYM = strPrevINVYYYYMM;
                      }
                  }
                  intAplyInvMonth++;
                  if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                  }
                  else
                  {
                      if (strCurrINVYM.Substring(0, 7).Trim().Replace("/", "") == this.txtRENTSTDTM.Text.Trim().Replace("/", ""))
                      {
                          dtrRwTmpl["PREOPENWAY"] = "1";
                      }
                      dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                  }
                  strPrevINVYYYYMM = strCurrINVYM;
                  dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                  strPrevRentYYYYMM = strCurrRntYM;
                  dtrRwTmpl["TAXTYPE"] = "1";
                  dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                  dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                  dtrRwTmpl["DISAMT"] = "0";
                  dtrRwTmpl["MONTHPAY"] = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"]).ToString("#,##0");
                  decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString());
                  decimal decAMOUNT = (decMONTHPAY * 20) / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  decimal decTAX = decMONTHPAY - decAMOUNT;
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = decTAX.ToString();
                  dtrRwTmpl["RTNAMT"] = dtbMLDCONTRACTCASHFLOW.Rows[j]["PRINCIPAL"].ToString();
                  dtrRwTmpl["RTNAMTTAX"] = System.Convert.ToString(System.Math.Round(System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["PRINCIPAL"]) / 20,0));
                  dtrRwTmpl["INSTAMT"] = dtbMLDCONTRACTCASHFLOW.Rows[j]["INTEREST"].ToString();
                  decimal decRent = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENT"]);
                  decimal decRentTax = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[j]["RENTTAX"]);
                  dtrRwTmpl["INSTAMTTAX"] = System.Convert.ToString(decRentTax - decRent - System.Convert.ToDecimal(dtrRwTmpl["RTNAMTTAX"]));
                  dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                  dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                  dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                  dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                  if (j == 0)
                  {
                      strBZ = "購入成本(含稅):" + decINVOICEAMOUNT.ToString("#,##0") + "<BR>";
                  }
                  else
                  {
                      strBZ = ""; 
                  }
                  if (chk11.Checked)
                  {
                      strBZ += "合約編號:" + txtCNTRNO.Text;
                  }
                  if (chk12.Checked)
                  {
                      strBZ += "<BR>" + "期數:" + dtrRwTmpl["ISSUE"].ToString() + "/" + this.txtCONTRACTMONTH.Text.Trim();
                  }
                  if (chk13.Checked)
                  {
                      strBZ += "<BR>" + "期間:" + strRntRngSTdt + "~" + strRntRngEDdt;
                  }
                  if (chk14.Checked)
                  {
                      if (System.Convert.ToInt32(strCompId) == (int)enm公司別.和運)
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM01.Text;
                      }
                      else
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM02.Text;
                      }
                  }
                  if (chk15.Checked)
                  {
                      strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
                  }
                  if (chk16.Checked)
                  {
                      strBZ += "<BR>" + "繳款日:" + strCurrINVYM.Substring(0, strCurrINVYM.Length - 3) + txtCUSTFPAYDATE.Text.Substring(7, 3);
                  }
                  if (hdnSPECNOTE1.Value.ToString() != "")
                  {
                      strBZ += "<BR>" + "特殊備註:" + hdnSPECNOTE1.Value;
                  }

                  dtrRwTmpl["BZ"] = strBZ;
                  dtrRwTmpl["FGSINGLE"] = "1";;
                  if (this.ddlSingle.SelectedValue == "1")
                  {
                      dtrRwTmpl["FGSINGLENME"] = "Y";
                  }
                  dtrRwTmpl["FGSPLIT"] = "2";
                  if (this.hdnFGSPLIT.Value == "1")
                  {
                      dtrRwTmpl["FGSPLITNME"] = "Y";
                  }
                  dtrRwTmpl["FGSUMMARY"] = "2";
                  dtrRwTmpl["MTRCNTRNO"] = "";
                  dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
              }
          }

          //押金設算息
          if (this.txtPERBOND.Text != "0" || this.txtPURCHASEMARGIN.Text != "0")
          {
              String strRntRngSTdt = "";
              String strRntRngEDdt = "";
              for (int j = 1; j <= System.Convert.ToInt32(this.hdnFinalLevel.Value); j++)
              {
                  decimal decGRARAMOUNT = 0;
                  decGRARAMOUNT = System.Convert.ToDecimal(this.txtPERBOND.Text) + System.Convert.ToDecimal(this.txtPURCHASEMARGIN.Text);
                  decimal decGUARSETRATE = 0;
                  if (this.hdnGUARSETRATE.Value.Trim() == "")
                  {
                      this.hdnGUARSETRATE.Value = "0";
                  }
                  decGUARSETRATE = System.Convert.ToDecimal(this.hdnGUARSETRATE.Value);
                  decimal decGUARSETINST = 0;
                  decGUARSETINST = (decGRARAMOUNT * decGUARSETRATE) / 1200;
                  dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                  dtrRwTmpl["ISSUE"] = System.Convert.ToDecimal(j).ToString("00");
                  dtrRwTmpl["UNITID"] = "";
                  dtrRwTmpl["INVDESC"] = "押金設算息";
                  dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.押金設算息));
                  dtrRwTmpl["INVKIND"] =strINVKIND;
                  if (j == 1)
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      strRntRngSTdt = this.txtRENTSTDT.Text;
                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                      DateTime dtmRntRngSTdt = System.DateTime.Now;
                      if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdt))
                      {
                          strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                      }
                      else
                      {
                          strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                          if (bolMonEndDay)
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(0).ToString("yyyy/MM/dd");
                          }
                      }

                      strCurrRntYM = System.Convert.ToDateTime(strRentStdt).AddMonths(j - 1).ToString("yyyy/MM/dd");
                      strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(j - 1).ToString("yyyy/MM/dd");
                  }
                  else
                  {
                      dtrRwTmpl["PREOPENWAY"] = this.ddlAplyTyp.SelectedValue;
                      strRntRngSTdt = System.Convert.ToDateTime(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd"); ;
                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32("1")).AddDays(-1).ToString("yyyy/MM/dd");
                      DateTime dtmRntRngSTdtTmp = System.DateTime.Now;
                      if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdtTmp))
                      {
                          if (bolMonEndDay)
                          {
                              DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1);
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                              if (strRntRngSTdt.Substring(5, 2) == "02")
                              {
                                  strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                              }
                              else
                              {
                                  strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + "01";
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngEDdt).AddMonths(1).AddDays(-2).ToString("yyyy/MM/dd");
                              }
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");

                              if (System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) > 28)
                              {
                                  if (strRntRngSTdt.Substring(5, 2) == "02")
                                  {
                                      strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                  }
                              }
                          }
                      }
                      else
                      {
                          strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                          if (bolMonEndDay)
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(0).ToString("yyyy/MM/dd");
                          }
                      }
                      strCurrRntYM = System.Convert.ToDateTime(strPrevRentYYYYMM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
                      strCurrINVYM = System.Convert.ToDateTime(strPrevINVYYYYMM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
                  }
                  if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                  }
                  else
                  {
                      if (System.Convert.ToInt32(strCurrINVYM.Substring(0, 7).Trim().Replace("/", "")) <= System.Convert.ToInt32(this.txtRENTSTDTM.Text.Trim().Replace("/", "")))
                      {
                          dtrRwTmpl["PREOPENWAY"] = "1";
                      }
                      dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                  }
                  strPrevINVYYYYMM = strCurrINVYM;
                  dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                  strPrevRentYYYYMM = strCurrRntYM;
                  dtrRwTmpl["TAXTYPE"] = "1";
                  dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                  dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                  dtrRwTmpl["MONTHPAY"] = decGRARAMOUNT.ToString("#,##0");//decGUARSETINST.ToString("#,##0");
                  dtrRwTmpl["DISAMT"] = "0";
                  decimal decAMOUNT = (System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) * 20) / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  decimal decTAX = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"]) - decAMOUNT;
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = decTAX.ToString();
                  dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                  dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                  dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                  dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                  strBZ = "";

                  if (chk21.Checked)
                  {
                      strBZ += "合約編號:" + txtCNTRNO.Text;
                  }
                  if (chk22.Checked)
                  {
                      strBZ += "<BR>" + "期數:" + dtrRwTmpl["ISSUE"].ToString() + "/" + this.txtCONTRACTMONTH.Text.Trim(); ;
                  }
                  if (chk23.Checked)
                  {
                      strBZ += "<BR>" + "期間:" + strRntRngSTdt + "~" + strRntRngEDdt;
                  }
                  if (chk24.Checked)
                  {
                      if (System.Convert.ToInt32(strCompId) == (int)enm公司別.和運)
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM01.Text;
                      }
                      else
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM02.Text;
                      }
                  }
                  if (chk25.Checked)
                  {
                      strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
                  }
                  if (chk26.Checked)
                  {
                      strBZ += "<BR>" + "繳款日:" + strCurrRntYM.Substring(0, strCurrRntYM.Length - 3) + txtCUSTFPAYDATE.Text.Substring(7, 3);
                  }
                  if (hdnSPECNOTE2.Value.ToString() != "")
                  {
                      strBZ += "<BR>" + "特殊備註:" + hdnSPECNOTE2.Value;
                  }
                  dtrRwTmpl["BZ"] = strBZ;
                  dtrRwTmpl["FGSINGLE"] = strSingle; ;
                  if (this.ddlSingle.SelectedValue == "1")
                  {
                      dtrRwTmpl["FGSINGLENME"] = "Y";
                  }
                  dtrRwTmpl["FGSPLIT"] = this.hdnFGSPLIT.Value;
                  if (this.hdnFGSPLIT.Value == "1")
                  {
                      dtrRwTmpl["FGSPLITNME"] = "Y";
                  }
                  dtrRwTmpl["FGSUMMARY"] = "2";
                  dtrRwTmpl["MTRCNTRNO"] = "";
                  dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
              }
          }
      }
      else
      {
          decimal decPROCEDEINVTTL = 0;
          decimal decINVOICEAMOUNT = 0;
          if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) != (int)enm承作類型.AR)
          {
              decPROCEDEINVTTL = System.Convert.ToDecimal(this.hdnPROCEDEINV.Value);
              decINVOICEAMOUNT = System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[0]["INVOICEAMOUNT"].ToString());
          }
          else
          {
              decPROCEDEINVTTL = System.Convert.ToDecimal(this.hdnPROCEDEINV.Value);
          }
          if (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.不拆開)
          {
              dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
              dtrRwTmpl["ISSUE"] = "01";
              dtrRwTmpl["UNITID"] = "";// dtbMLDCONTRACTTARGET.Rows[i]["TARGETID"].ToString();
              if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
              {
                  dtrRwTmpl["INVDESC"] = "設備一批";
              }
              else
              {
                  dtrRwTmpl["INVDESC"] = "手續費";
              }
              dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.本體加分差));
              dtrRwTmpl["INVKIND"] =strINVKIND;
              dtrRwTmpl["PREOPENWAY"] = "1";
              strCurrRntYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
              strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
              dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
              if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
              {
                  dtrRwTmpl["PREOPENWAY"] = "1";
                  dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
              }
              else
              {
                  dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
              }
              dtrRwTmpl["TAXTYPE"] = "1";
              dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
              dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
              if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
              {
                  dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(this.hdnTTLRent.Value) + System.Convert.ToDecimal(this.txtFIRSTPAY.Text)).ToString("##,##0");
                  dtrRwTmpl["DISAMT"] = "0";
                  decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"]);
                  decimal decAMOUNT = decMONTHPAY * 20 / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = System.Convert.ToDecimal(decMONTHPAY - decAMOUNT).ToString("##,##0");

              }
              else
              {
                  //AR以實貸金額帶入 
                  dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(this.hdnTTLRent.Value) - System.Convert.ToDecimal(this.txtACTUSLLOANS.Text)).ToString("##,##0");
                  dtrRwTmpl["DISAMT"] = "0";
                  decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"]);
                  decimal decAMOUNT = decMONTHPAY * 20 / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = System.Convert.ToDecimal(decMONTHPAY - decAMOUNT).ToString("##,##0");
              }
              dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
              dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
              dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
              dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
              strBZ = "";

              if (chk61.Checked)
              {
                  strBZ += "合約編號:" + txtCNTRNO.Text;
              }
              if (chk65.Checked)
              {
                  strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
              }
              if (this.hdnSPECNOTE6.Value.Trim() != "")
              {
                  strBZ += "<BR>" + "特殊備註:" + this.hdnSPECNOTE6.Value.Trim();
              }

              if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
              {
                  dtrRwTmpl["BZ"] = strBZ + "<BR>內含分差";
              }
              else
              {
                  dtrRwTmpl["BZ"] = strBZ;
              }
              dtrRwTmpl["FGSINGLE"] = this.ddlSingle.SelectedValue;
              if (this.ddlSingle.SelectedValue == "1")
              {
                  dtrRwTmpl["FGSINGLENME"] = "Y";
              }
              dtrRwTmpl["FGSPLIT"] = "2";
              dtrRwTmpl["FGSPLITNME"] = "";
              dtrRwTmpl["FGSUMMARY"] = "2";
              dtrRwTmpl["MTRCNTRNO"] = "";
              dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
          }
          else
          {
              decimal decMONTHPAY = 0;
              decimal decAMOUNT = 0;
              decimal decTAX = 0;
              if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
              {
                  dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                  dtrRwTmpl["ISSUE"] = "01";
                  dtrRwTmpl["UNITID"] = "";//dtbMLDCONTRACTTARGET.Rows[i]["TARGETID"].ToString();
                  dtrRwTmpl["INVDESC"] = "設備一批";
                  dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.本體));
                  dtrRwTmpl["INVKIND"] =strINVKIND;
                  dtrRwTmpl["PREOPENWAY"] = "1";
                  strCurrRntYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
                  strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
                  dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                  if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                  }
                  else
                  {
                      dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                  }
                  dtrRwTmpl["TAXTYPE"] = "1";
                  dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                  dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                  dtrRwTmpl["MONTHPAY"] = decPROCEDEINVTTL.ToString("##,##0");
                  decMONTHPAY = decPROCEDEINVTTL;
                  decAMOUNT = System.Math.Round(decPROCEDEINVTTL * 20 / 21, 0);
                  decTAX = decMONTHPAY - decAMOUNT;
                  dtrRwTmpl["DISAMT"] = "0";
                  dtrRwTmpl["AMOUNT"] = System.Convert.ToDecimal(decAMOUNT).ToString("##,##0");
                  dtrRwTmpl["TAX"] = System.Convert.ToDecimal(decTAX).ToString("##,##0");
                  dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                  dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                  dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                  dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                  strBZ = "";

                  if (chk41.Checked)
                  {
                      strBZ += "合約編號:" + txtCNTRNO.Text;
                  }
                  if (chk45.Checked)
                  {
                      strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
                  }
                  if (this.hdnSPECNOTE4.Value.Trim() != "")
                  {
                      strBZ += "<BR>" + "特殊備註:" + this.hdnSPECNOTE4.Value.Trim();
                  }

                  dtrRwTmpl["BZ"] = strBZ;
                  dtrRwTmpl["FGSINGLE"] = this.ddlSingle.SelectedValue;
                  if (this.ddlSingle.SelectedValue == "1")
                  {
                      dtrRwTmpl["FGSINGLENME"] = "Y";
                  }
                  dtrRwTmpl["FGSPLIT"] = "2";
                  dtrRwTmpl["FGSPLITNME"] = "";
                  dtrRwTmpl["FGSUMMARY"] = "2";
                  dtrRwTmpl["MTRCNTRNO"] = "";
                  dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
              }

              dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
              dtrRwTmpl["ISSUE"] = "01";
              dtrRwTmpl["UNITID"] = "";// dtbMLDCONTRACTTARGET.Rows[i]["TARGETID"].ToString();
              if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期)
              {
                  dtrRwTmpl["INVDESC"] = "分差差額收入";
              }
              else
              {
                  dtrRwTmpl["INVDESC"] = "手續費";
              }
              dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.分差));
              dtrRwTmpl["INVKIND"] =strINVKIND;
              dtrRwTmpl["PREOPENWAY"] = "1";
              strCurrRntYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
              strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
              dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
              if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
              {
                  dtrRwTmpl["PREOPENWAY"] = "1";
                  dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
              }
              else
              {
                  dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
              }
              dtrRwTmpl["TAXTYPE"] = "1";
              dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
              dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
              dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(this.hdnTTLRent.Value) + System.Convert.ToDecimal(this.txtFIRSTPAY.Text) - decPROCEDEINVTTL).ToString("##,##0");
              dtrRwTmpl["DISAMT"] = "0";
              decAMOUNT = System.Math.Round((System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) * 20 / 21), 0);
              decTAX = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) - decAMOUNT;
              dtrRwTmpl["AMOUNT"] = System.Convert.ToDecimal(decAMOUNT).ToString("##,##0");
              dtrRwTmpl["TAX"] = System.Convert.ToDecimal(decTAX);
              dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
              dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
              dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
              dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
              strBZ = "";

              if (chk51.Checked)
              {
                  strBZ += "合約編號:" + txtCNTRNO.Text;
              }
              if (chk55.Checked)
              {
                  strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
              }
              if (this.hdnSPECNOTE5.Value.Trim() != "")
              {
                  strBZ += "<BR>" + "特殊備註:" + this.hdnSPECNOTE5.Value.Trim();
              }

              dtrRwTmpl["BZ"] = strBZ;
              dtrRwTmpl["FGSINGLE"] = this.ddlSingle.SelectedValue;
              if (this.ddlSingle.SelectedValue == "1")
              {
                  dtrRwTmpl["FGSINGLENME"] = "Y";
              }
              dtrRwTmpl["FGSPLIT"] = "2";
              dtrRwTmpl["FGSPLITNME"] = "";
              dtrRwTmpl["FGSUMMARY"] = "2";
              dtrRwTmpl["MTRCNTRNO"] = "";
              dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
          }

          //押金設算息
          if (this.txtPERBOND.Text != "0" || this.txtPURCHASEMARGIN.Text != "0")
          {
              String strRntRngSTdt = "";
              String strRntRngEDdt = "";
              for (int j = 1; j <= System.Convert.ToInt32(this.hdnFinalLevel.Value); j++)
              {
                  decimal decGRARAMOUNT = 0;
                  decGRARAMOUNT = System.Convert.ToDecimal(this.txtPERBOND.Text) + System.Convert.ToDecimal(this.txtPURCHASEMARGIN.Text);
                  decimal decGUARSETRATE = 0;
                  if (this.hdnGUARSETRATE.Value.Trim() == "")
                  {
                      this.hdnGUARSETRATE.Value = "0";
                  }
                  decGUARSETRATE = System.Convert.ToDecimal(this.hdnGUARSETRATE.Value);
                  decimal decGUARSETINST = 0;
                  decGUARSETINST = (decGRARAMOUNT * decGUARSETRATE) / 1200;
                  dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
                  dtrRwTmpl["ISSUE"] = System.Convert.ToDecimal(j).ToString("00");
                  dtrRwTmpl["UNITID"] = "";
                  dtrRwTmpl["INVDESC"] = "押金設算息";
                  dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.押金設算息));
                  dtrRwTmpl["INVKIND"] =strINVKIND;
                  if (j == 1)
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      strRntRngSTdt = this.txtRENTSTDT.Text;
                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                      DateTime dtmRntRngSTdt = System.DateTime.Now;
                      if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdt))
                      {
                          strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                      }
                      else
                      {
                          strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                          if (bolMonEndDay)
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(0).ToString("yyyy/MM/dd");
                          }
                      }

                      strCurrRntYM = System.Convert.ToDateTime(strRentStdt).AddMonths(j-1).ToString("yyyy/MM/dd");
                      strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(j-1).ToString("yyyy/MM/dd");
                  }
                  else
                  {
                      dtrRwTmpl["PREOPENWAY"] = this.ddlAplyTyp.SelectedValue;
                      strRntRngSTdt = System.Convert.ToDateTime(strRntRngEDdt).AddDays(1).ToString("yyyy/MM/dd"); ;
                      strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32("1")).AddDays(-1).ToString("yyyy/MM/dd");
                      DateTime dtmRntRngSTdtTmp = System.DateTime.Now;
                      if (System.DateTime.TryParse(strRntRngSTdt, out dtmRntRngSTdtTmp))
                      {
                          if (bolMonEndDay)
                          {
                              DateTime dtmRntRngSTdt = new System.DateTime(System.Convert.ToDateTime(strRntRngSTdt).Year, System.Convert.ToDateTime(strRntRngSTdt).Month, 1);
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                              if (strRntRngSTdt.Substring(5, 2) == "02")
                              {
                                  strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                              }
                              else
                              {
                                  strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + "01";
                                  strRntRngEDdt = System.Convert.ToDateTime(strRntRngEDdt).AddMonths(1).AddDays(-2).ToString("yyyy/MM/dd");
                              }
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");

                              if (System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) > 28)
                              {
                                  if (strRntRngSTdt.Substring(5, 2) == "02")
                                  {
                                      strRntRngEDdt = strRntRngEDdt.Substring(0, 8) + System.Convert.ToDecimal(System.Convert.ToDecimal(this.txtRENTSTDT.Text.Substring(8, 2)) - 1).ToString();
                                  }
                              }
                          }
                      }
                      else
                      {
                          strRntRngSTdt = System.Convert.ToDateTime(strRntRngSTdt.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                          if (bolMonEndDay)
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(-1).ToString("yyyy/MM/dd");
                          }
                          else
                          {
                              strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(1)).AddDays(0).ToString("yyyy/MM/dd");
                          }
                      }
                      strCurrRntYM = System.Convert.ToDateTime(strPrevRentYYYYMM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
                      strCurrINVYM = System.Convert.ToDateTime(strPrevINVYYYYMM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
                  }
                  if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) <= System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                  {
                      dtrRwTmpl["PREOPENWAY"] = "1";
                      dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                  }
                  else
                  {
                      if (System.Convert.ToInt32(strCurrINVYM.Substring(0, 7).Trim().Replace("/", "")) <= System.Convert.ToInt32(this.txtRENTSTDTM.Text.Trim().Replace("/", "")))
                      {
                          dtrRwTmpl["PREOPENWAY"] = "1";
                      }
                      dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
                  }
                  strPrevINVYYYYMM = strCurrINVYM;
                  dtrRwTmpl["RENTYEARS"] = strCurrRntYM.Substring(0, strCurrRntYM.Length - 3);
                  strPrevRentYYYYMM = strCurrRntYM;
                  dtrRwTmpl["TAXTYPE"] = "1";
                  dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
                  dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;
                  dtrRwTmpl["MONTHPAY"] = decGRARAMOUNT.ToString("#,##0");//decGUARSETINST.ToString("#,##0");
                  dtrRwTmpl["DISAMT"] = "0";
                  decimal decAMOUNT = (System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) * 20) / 21;
                  decAMOUNT = System.Math.Round(decAMOUNT, 0);
                  decimal decTAX = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"]) - decAMOUNT;
                  dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
                  dtrRwTmpl["TAX"] = decTAX.ToString();
                  dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;
                  dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;
                  dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;
                  dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;
                  strBZ = "";

                  if (chk21.Checked)
                  {
                      strBZ += "合約編號:" + txtCNTRNO.Text;
                  }
                  if (chk22.Checked)
                  {
                      strBZ += "<BR>" + "期數:" + dtrRwTmpl["ISSUE"].ToString() + "/" + this.txtCONTRACTMONTH.Text.Trim(); ;
                  }
                  if (chk23.Checked)
                  {
                      strBZ += "<BR>" + "期間:" + strRntRngSTdt + "~" + strRntRngEDdt;
                  }
                  if (chk24.Checked)
                  {
                      if (System.Convert.ToInt32(strCompId) == (int)enm公司別.和運)
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM01.Text;
                      }
                      else
                      {
                          strBZ += "<BR>" + "虛擬帳號:" + txtLLVLNUM02.Text;
                      }
                  }
                  if (chk25.Checked)
                  {
                      strBZ += "<BR>" + "實體帳號:" + txtRVACNT.Text;
                  }
                  if (chk26.Checked)
                  {
                      strBZ += "<BR>" + "繳款日:" + strCurrRntYM.Substring(0, strCurrRntYM.Length - 3) + txtCUSTFPAYDATE.Text.Substring(7, 3);
                  }
                  if (hdnSPECNOTE2.Value.ToString() != "")
                  {
                      strBZ += "<BR>" + "特殊備註:" + hdnSPECNOTE2.Value;
                  }
                  dtrRwTmpl["BZ"] = strBZ;
                  dtrRwTmpl["FGSINGLE"] = strSingle; ;
                  if (this.ddlSingle.SelectedValue == "1")
                  {
                      dtrRwTmpl["FGSINGLENME"] = "Y";
                  }
                  dtrRwTmpl["FGSPLIT"] = this.hdnFGSPLIT.Value;
                  if (this.hdnFGSPLIT.Value == "1")
                  {
                      dtrRwTmpl["FGSPLITNME"] = "Y";
                  }
                  dtrRwTmpl["FGSUMMARY"] = "2";
                  dtrRwTmpl["MTRCNTRNO"] = "";
                  dtbMLMPREINVOICE.Rows.Add(dtrRwTmpl);
              }
          }
      }

      DataView DV_Reorder= dtbMLMPREINVOICE.DefaultView;
      DV_Reorder.Sort = "ISSUE Asc";
      dtbMLMPREINVOICE = DV_Reorder.ToTable();
      rptData.DataSource = dtbMLMPREINVOICE;
      rptData.DataBind();
      for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
      {
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"].ToString();
          ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
          ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnRENTYEARS")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"].ToString();
          ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();
          ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Text = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
          // ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnORDERDAY")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString();
      }

      string strPreIssue = dtbMLMPREINVOICE.Rows[0]["ISSUE"].ToString();
      Decimal decSubTtlMonthPay = System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);
      if ((this.ddlSingle.SelectedValue == "1") && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
      {
          DataView DV = dtbMLMPREINVOICE.DefaultView;
          DV.Sort = "INVDESCTYPE Asc, ISSUE Asc,UNITID Asc";
          dtbMLMPREINVOICE = DV.ToTable();

          for (Int32 intRowCnt = 0; intRowCnt < dtbMLMPREINVOICE.Rows.Count; intRowCnt++)
          {
              if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() == "1")
              {
                  if (System.Convert.ToInt32(strPreIssue) != System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()))
                  {
                      for (Int32 intCnt = 0; intCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intCnt++)
                      {
                          if (System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()) == System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intCnt]["ISSUE"].ToString()))
                          {
                              decSubTtlMonthPay = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[intCnt]["RENTTAX"].ToString());
                              break;
                          }
                      }
                      decSubTtlMonthPay -= System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
                  }
                  else
                  {
                      if (intRowCnt + 1 < dtbMLMPREINVOICE.Rows.Count)
                      {
                          if (System.Convert.ToInt32(strPreIssue) != System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt + 1]["ISSUE"].ToString()))
                          {
                              dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"] = decSubTtlMonthPay.ToString("##,##0");
                              decimal decMONTHPAY = System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
                              decimal decAMOUNT = (decMONTHPAY * 20) / 21;
                              decAMOUNT = System.Math.Round(decAMOUNT, 0);
                              decimal decTAX = decMONTHPAY - decAMOUNT;
                              dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"] = decAMOUNT.ToString();
                              dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"] = decTAX.ToString();
                          }
                          else
                          {
                              decSubTtlMonthPay -= System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
                          }
                      }
                      else
                      {
                          dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"] = decSubTtlMonthPay.ToString("##,##0");
                          decimal decMONTHPAY = System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
                          decimal decAMOUNT = (decMONTHPAY * 20) / 21;
                          decAMOUNT = System.Math.Round(decAMOUNT, 0);
                          decimal decTAX = decMONTHPAY - decAMOUNT;
                          dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"] = decAMOUNT.ToString();
                          dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"] = decTAX.ToString();
                      }
                  }
                  strPreIssue = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
              }
          }

          DV = dtbMLMPREINVOICE.DefaultView;
          DV.Sort = "ISSUE Asc,INVDESCTYPE Asc,UNITID Asc";
          dtbMLMPREINVOICE = DV.ToTable();

          rptData.DataSource = dtbMLMPREINVOICE;
          rptData.DataBind();
          for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
          {
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"].ToString();
              ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
              ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnRENTYEARS")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"].ToString();
              ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Text = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();
              // ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnORDERDAY")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString();
          }
      }

      ViewState["MLMPREINVOICE"] = dtbMLMPREINVOICE;
//      this.btnUA.Enabled = true;
//      this.btnUO.Enabled = true;
      this.btnExtInvo.Attributes.Remove("style:display:none;");
      this.btnExtInvo.Attributes.Add("style", "display:;");
 
  }

#endregion

#region 呼叫後端元件

    /// <summary>
    /// getMLMPREINVOICEColInf-預開發票資料檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
  private void getMLMPREINVOICEColInf(ref StringBuilder stbSaveFields, DataTable dtbPREINVOICE, DataTable dtbFEEAMTPREINVOICE1, DataTable dtbFEEAMTPREINVOICE2, DataTable dtbFEEAMTPREINVOICE3)
    {
        if (this.hdnPREINVSETID.Value.Trim() != "")
        {
            stbSaveFields.Append("SP_ML4001_D00" + GSTR_ColDelimitChar);
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(this.hdnPREINVSETID.Value.Trim());
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
        
        for (int intRowCnt = 0; intRowCnt < dtbPREINVOICE.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4001_I01" + GSTR_ColDelimitChar);
            string strPREINVID = "";
            if (dtbTempRow["PREINVID"].ToString().Trim() == "")
            {
                strPREINVID = Itg.Community.Util.GetIDSequence("MLMPREINVOICE", "14");
                stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(dtbTempRow["PREINVID"].ToString().Trim() + GSTR_TabDelimitChar);
                strPREINVID = dtbTempRow["PREINVID"].ToString().Trim();
            }
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(strCompId + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ISSUE"].ToString().Trim() + GSTR_TabDelimitChar);
            if (dtbTempRow["UNITID"].ToString().Trim() != "")
            {
                dtbTempRow["UNITID"] = this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(), "").Trim();
                stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            }
            stbSaveFields.Append(dtbTempRow["PREOPENWAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVKIND"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENTYEARS"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREINVYYYYMM"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESCTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAXTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETNAME"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",","").Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVZIPCODE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVOICEADDR"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ORDERDAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSPLIT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSINGLE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSUMMARY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MTRCNTRNO"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["BZ"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID

            //UPD BY HANK 20170926 增加載具號碼，捐贈，跟愛心碼
            //stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            string sDONATEMARK = "";
            if (this.chkDONATEMARK.Checked)
            {
                sDONATEMARK = "Y";
            }
            else
            {
                sDONATEMARK = "N";
            }

            stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            stbSaveFields.Append(this.txtCARRIEID.Text.Trim() + GSTR_TabDelimitChar);//CARRIEID
            stbSaveFields.Append(sDONATEMARK + GSTR_TabDelimitChar);//DONATEMARK
            stbSaveFields.Append(this.txtNPOBAN.Text.Trim());//NPOBAN

            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);

            //getMLDPREINVOICEDESCColInf(strPREINVID, ref stbSaveFields);

            //資租品名有兩項，本金及利息
            if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租)
            {
                if (System.Convert.ToInt32(dtbTempRow["ISSUE"].ToString().Trim()) != 0)
                {
                    if (dtbTempRow["INVDESCTYPE"].ToString().Trim() == "2")
                    {
                        //押金設算息
                        stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
                        stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                        stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append("押金設算息" + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                        stbSaveFields.Append(GSTR_ColDelimitChar);
                        stbSaveFields.Append(GSTR_RowDelimitChar);

                    }
                    else
                    {
                        //本金
                        stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
                        stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                        stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(),"").Trim()  + GSTR_TabDelimitChar);
                        stbSaveFields.Append("本金" + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["RTNAMT"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["RTNAMTTAX"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                        stbSaveFields.Append(GSTR_ColDelimitChar);
                        stbSaveFields.Append(GSTR_RowDelimitChar);

                        //利息
                        stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
                        stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                        stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(),"").Trim()  + GSTR_TabDelimitChar);
                        stbSaveFields.Append("利息" + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["INSTAMT"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbTempRow["INSTAMTTAX"].ToString().Trim() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                        stbSaveFields.Append(GSTR_ColDelimitChar);
                        stbSaveFields.Append(GSTR_RowDelimitChar);
                    }
                }
                else
                {
                    //頭款
                    stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append("本金" + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
            }
            else
            {
                stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
                stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(),"").Trim()  + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);                
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);
            }
        }
        
        //UDP 20170110 By SS Gordon Reason:新增[手續費發票]，[動保費收入發票]，[墊款息收入發票]發票預開資料儲存
        //手續費發票
        for (int intRowCnt = 0; intRowCnt < dtbFEEAMTPREINVOICE1.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbFEEAMTPREINVOICE1.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4001_I01" + GSTR_ColDelimitChar);
            string strPREINVID = "";
            if (dtbTempRow["PREINVID"].ToString().Trim() == "")
            {
                strPREINVID = Itg.Community.Util.GetIDSequence("MLMPREINVOICE", "14");
                stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(dtbTempRow["PREINVID"].ToString().Trim() + GSTR_TabDelimitChar);
                strPREINVID = dtbTempRow["PREINVID"].ToString().Trim();
            }
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(strCompId + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ISSUE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREOPENWAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVKIND"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENTYEARS"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREINVYYYYMM"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESCTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAXTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETNAME"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVZIPCODE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVOICEADDR"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ORDERDAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSPLIT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSINGLE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSUMMARY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MTRCNTRNO"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["BZ"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);

            //預開發票明細
            stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
            stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
        //動保費收入發票
        for (int intRowCnt = 0; intRowCnt < dtbFEEAMTPREINVOICE2.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbFEEAMTPREINVOICE2.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4001_I01" + GSTR_ColDelimitChar);
            string strPREINVID = "";
            if (dtbTempRow["PREINVID"].ToString().Trim() == "")
            {
                strPREINVID = Itg.Community.Util.GetIDSequence("MLMPREINVOICE", "14");
                stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(dtbTempRow["PREINVID"].ToString().Trim() + GSTR_TabDelimitChar);
                strPREINVID = dtbTempRow["PREINVID"].ToString().Trim();
            }
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(strCompId + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ISSUE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREOPENWAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVKIND"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENTYEARS"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREINVYYYYMM"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESCTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAXTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETNAME"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVZIPCODE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVOICEADDR"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ORDERDAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSPLIT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSINGLE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSUMMARY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MTRCNTRNO"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["BZ"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);

            //預開發票明細
            stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
            stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
        //墊款息收入發票
        for (int intRowCnt = 0; intRowCnt < dtbFEEAMTPREINVOICE3.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbFEEAMTPREINVOICE3.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4001_I01" + GSTR_ColDelimitChar);
            string strPREINVID = "";
            if (dtbTempRow["PREINVID"].ToString().Trim() == "")
            {
                strPREINVID = Itg.Community.Util.GetIDSequence("MLMPREINVOICE", "14");
                stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(dtbTempRow["PREINVID"].ToString().Trim() + GSTR_TabDelimitChar);
                strPREINVID = dtbTempRow["PREINVID"].ToString().Trim();
            }
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(strCompId + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ISSUE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREOPENWAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVKIND"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENTYEARS"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PREINVYYYYMM"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESCTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAXTYPE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TARGETNAME"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVZIPCODE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVOICEADDR"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["ORDERDAY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSPLIT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSINGLE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["FGSUMMARY"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["MTRCNTRNO"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["BZ"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            //stbSaveFields.Append(GSTR_U_USERID);//U_USERID

            //ADD20230515 必要參數新增
            string sDONATEMARK = "";
            if (this.chkDONATEMARK.Checked)
            {
                sDONATEMARK = "Y";
            }
            else
            {
                sDONATEMARK = "N";
            }

            stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            stbSaveFields.Append(this.txtCARRIEID.Text.Trim() + GSTR_TabDelimitChar);//CARRIEID
            stbSaveFields.Append(sDONATEMARK + GSTR_TabDelimitChar);//DONATEMARK
            stbSaveFields.Append(this.txtNPOBAN.Text.Trim());//NPOBAN

            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);

            //預開發票明細
            stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
            stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }        
    }

    private string getPREINVID()
    {
       string strPREINVID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
       return strPREINVID;
    }

    private string getPREINVSETID()
    {
        string strPREINVSETID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
        return strPREINVSETID;
    }

    private string getPREINVNOTEID()
    {
        string strPREINVNOTEID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
        return strPREINVNOTEID;
    }

    private string getPREINVOPENID()
    {
        string strPREINVOPENID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
        return strPREINVOPENID;
    }

    private string getPREINVDESCID()
    {
        string strPREINVDESCID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
        return strPREINVDESCID;
    }

    private string getPREINVSPLITID()
    {
        string strPREINVSPLITID = Itg.Community.Util.GetIDSequence("MLDCASEINSTD", "14");
        return strPREINVSPLITID;
    }

    
    /// <summary>
    /// getMLDPREINVOICEDESCColInf-預開發票品名明細檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLDPREINVOICEDESCColInf(string strPREINVID, ref StringBuilder stbSaveFields)
    {
        DataTable dtbPREINVOICE = (DataTable)ViewState["MLMPREINVOICE"];
        for (int intRowCnt = 0; intRowCnt < dtbPREINVOICE.Rows.Count; intRowCnt++)
        {
            stbSaveFields.Append("SP_ML4001_I03" + GSTR_ColDelimitChar);
            stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["TAX"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
    }

    /// <summary>
    /// getMLDPREINVNOTEColInf-預開發票備註設定檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLDPREINVNOTEColInf(string strPREINVSETID, ref StringBuilder stbSaveFields)
    {
        if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租 || System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
        {
            stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
            if (this.hdnPREINVNOTEID1.Value.Trim() == "")
            {
                stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(this.hdnPREINVNOTEID1.Value.Trim() + GSTR_TabDelimitChar);
            }
            stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
            stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.租金)) + GSTR_TabDelimitChar);         
            if (this.chk11.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk12.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk13.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk14.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk15.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk16.Checked)
            {
               stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
               stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            stbSaveFields.Append(this.hdnSPECNOTE1.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
        else
        {
            if (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.不拆開)
            {
                stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
                if (this.hdnPREINVNOTEID6.Value.Trim() == "")
                {
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append(this.hdnPREINVNOTEID6.Value.Trim() + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
                stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.本體加分差)) + GSTR_TabDelimitChar);
                if (this.chk61.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk62.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk63.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk64.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk65.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk66.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(this.hdnSPECNOTE6.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);
            }
            else
            {
                stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
                if (this.hdnPREINVNOTEID4.Value.Trim() == "")
                {
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append(this.hdnPREINVNOTEID4.Value.Trim() + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
                stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.本體)) + GSTR_TabDelimitChar);
                if (this.chk41.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk42.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk43.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk44.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk45.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk46.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(this.hdnSPECNOTE4.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);

                stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
                if (this.hdnPREINVNOTEID5.Value.Trim() == "")
                {
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append(this.hdnPREINVNOTEID5.Value.Trim() + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
                stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.分差)) + GSTR_TabDelimitChar);
                if (this.chk51.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk52.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk53.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk54.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk55.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                if (this.chk56.Checked)
                {
                    stbSaveFields.Append("1" + GSTR_TabDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("0" + GSTR_TabDelimitChar);
                }
                stbSaveFields.Append(this.hdnSPECNOTE5.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);
            }
        }
        //押金設算息
        if (this.txtPERBOND.Text != "0" || this.txtPURCHASEMARGIN.Text != "0")
        {
            stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
            if (this.hdnPREINVNOTEID2.Value.Trim() == "")
            {
                stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append(this.hdnPREINVNOTEID2.Value.Trim() + GSTR_TabDelimitChar);
            }
            stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
            stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.押金設算息)) + GSTR_TabDelimitChar);
            if (this.chk21.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk22.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk23.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk24.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk25.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            if (this.chk26.Checked)
            {
                stbSaveFields.Append("1" + GSTR_TabDelimitChar);
            }
            else
            {
                stbSaveFields.Append("0" + GSTR_TabDelimitChar);
            }
            stbSaveFields.Append(this.hdnSPECNOTE2.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }

        //UDP 20170110 By SS Gordon Reason:新增[手續費發票]，[動保費收入發票]，[墊款息收入發票]備註資料儲存
        //手續費發票備註
        stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
        if (this.hdnPREINVNOTEID3_2.Value.Trim() == "")
        {
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append(this.hdnPREINVNOTEID3_2.Value.Trim() + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
        stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.補貼款收入)) + GSTR_TabDelimitChar);
        if (this.chk31_2.Checked)
        {
            stbSaveFields.Append("1" + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.hdnSPECNOTE3_2.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);
        //動保費收入發票備註
        stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
        if (this.hdnPREINVNOTEID3_3.Value.Trim() == "")
        {
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append(this.hdnPREINVNOTEID3_3.Value.Trim() + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
        stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.手續費收入)) + GSTR_TabDelimitChar);
        if (this.chk31_3.Checked)
        {
            stbSaveFields.Append("1" + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.hdnSPECNOTE3_3.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);
        //墊款息收入發票備註
        stbSaveFields.Append("SP_ML4001_I02" + GSTR_ColDelimitChar);
        if (this.hdnPREINVNOTEID3_4.Value.Trim() == "")
        {
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVNOTE", "14") + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append(this.hdnPREINVNOTEID3_4.Value.Trim() + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
        stbSaveFields.Append(System.Convert.ToString((int)(enm發票類別.墊款息收入)) + GSTR_TabDelimitChar);
        if (this.chk31_4.Checked)
        {
            stbSaveFields.Append("1" + GSTR_TabDelimitChar);
        }
        else
        {
            stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        }
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append("0" + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.hdnSPECNOTE3_4.Value.Trim() + GSTR_TabDelimitChar);//SPECNOTE
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);
    }

    /// <summary>
    /// getMLMPREINVSETColInf-預開發票設定主檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLMPREINVSETColInf(ref StringBuilder stbSaveFields)
    {
        DataTable dtbPREINVOICE = (DataTable)ViewState["MLMPREINVOICE"];
        stbSaveFields.Append("SP_ML4001_I06" + GSTR_ColDelimitChar);
        string strPREINVSETID = "";
        if (this.hdnPREINVSETID.Value.Trim() == "")
        {
            strPREINVSETID = Itg.Community.Util.GetIDSequence("MLMPREINVSET", "14");
        }
        else
        {
            strPREINVSETID = this.hdnPREINVSETID.Value.Trim();
        }
        stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTM.Text.Replace("/", "") + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTD.Text + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtPAYMONTHK.Text + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.ddlSingle.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.ddlSummary.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.ddlAplyTyp.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.ddlBdyDiffTyp.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
        stbSaveFields.Append(GSTR_U_USERID);//U_USERID
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);

        if (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租)
        {
            if (this.ddlSummary.SelectedValue == "1" && this.hdnOPENCNTRNO.Value.Trim() != "")
            {
                stbSaveFields.Append("SP_ML4001_I04" + GSTR_ColDelimitChar);
                stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
                stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOPEN", "14") + GSTR_TabDelimitChar);
                stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(this.hdnOPENCNTRNO.Value.Trim().ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);
            }
        }

        //UDP 20170110 By SS Gordon Reason:新增[手續費發票]，[動保費收入發票]，[墊款息收入發票]設定儲存
        //手續費發票設定資料
        stbSaveFields.Append("SP_ML4001_I07" + GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID
        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
        stbSaveFields.Append(((int)enm發票類別.補貼款收入).ToString() + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTM_2.Text.Replace("/", "") + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTD_2.Text + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.drpINVKIND1_2.SelectedValue);       
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);
        //動保費收入發票設定資料
        stbSaveFields.Append("SP_ML4001_I07" + GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID
        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
        stbSaveFields.Append(((int)enm發票類別.手續費收入).ToString() + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTM_3.Text.Replace("/", "") + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTD_3.Text + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.drpINVKIND1_3.SelectedValue);
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);
        //墊款息收入發票設定資料
        stbSaveFields.Append("SP_ML4001_I07" + GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID
        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
        stbSaveFields.Append(((int)enm發票類別.墊款息收入).ToString() + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTM_4.Text.Replace("/", "") + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtRENTSTDTD_4.Text + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.drpINVKIND1_4.SelectedValue);
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);

        getMLDPREINVNOTEColInf(strPREINVSETID, ref stbSaveFields);


        if (this.btnSplit.Attributes.CssStyle["display"] != "none")
        {
            DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];

            if (dtbMLDPREINVSPLIT != null)
            {
                for (Int32 intRowCnt = 0; intRowCnt < dtbMLDPREINVSPLIT.Rows.Count; intRowCnt++)
                {
                    stbSaveFields.Append("SP_ML4001_I05" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVSPLIT", "14") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(strPREINVSETID + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["INVGRP"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["UNITID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["TARGETID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["TARGETNAME"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[intRowCnt]["MONTHPAY"]).ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["INVZIPCODE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDPREINVSPLIT.Rows[intRowCnt]["INVOICEADDR"].ToString() + dtbMLDPREINVSPLIT.Rows[intRowCnt]["INVZIPCODES"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
            }
        }


    }

    /// <summary>
    /// SaveMLMPREINVOICESummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLMPREINVOICESummary(string strProcData)
    {
        Comus.HtmlSubmitControl objSubmitCtl;
        string strObjId;
        ReturnObject<object> objReturnObject;
        string[] aryParameter = new string[1];
        try
        {
            strObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            objSubmitCtl = new Comus.HtmlSubmitControl();
            objSubmitCtl.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = strProcData;
            objReturnObject = objSubmitCtl.SubmitEx<object>(strObjId, aryParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objReturnObject;
    }

    public string getMLDPREINVSPLITRowCount()
    {
        string strRowCount = "0";
        if (Session["MLDPREINVSPLIT"] != null)
        {
            DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
            strRowCount = dtbMLDPREINVSPLIT.Rows.Count.ToString();
        }
        return strRowCount; 
    }

    /// <summary>
    /// btnExtInvo_Click 
    /// </summary>
    protected void btnExtInvo_Click(object sender, EventArgs e)
    {
        StringBuilder stbSaveFields = new StringBuilder();

        DataTable dtbMLMPREINVOICE = (DataTable)ViewState["MLMPREINVOICE"];
        //發票拆立
        DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];

        //DataView DV = dtbMLMPREINVOICE.DefaultView;
        //DV.Sort = "INVDESCTYPE Asc, ISSUE Asc,UNITID Asc";
        //dtbMLMPREINVOICE = DV.ToTable();

        //string strPreIssue = dtbMLMPREINVOICE.Rows[0]["ISSUE"].ToString();
        //Decimal decSubTtlMonthPay = System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);
        //if ((this.ddlSingle.SelectedValue == "1") && (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.營租))
        //{
        //    for (Int32 intRowCnt = 0; intRowCnt < dtbMLMPREINVOICE.Rows.Count; intRowCnt++)
        //    {
        //        if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() == "1" )
        //        {
        //            if (System.Convert.ToInt32(strPreIssue) != System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()))
        //            {
        //                for (Int32 intCnt = 0; intCnt < dtbMLDCONTRACTCASHFLOW.Rows.Count; intCnt++)
        //                {
        //                    if (System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()) == System.Convert.ToInt32(dtbMLDCONTRACTCASHFLOW.Rows[intCnt]["ISSUE"].ToString()))
        //                    {
        //                        decSubTtlMonthPay = System.Convert.ToDecimal(dtbMLDCONTRACTCASHFLOW.Rows[intCnt]["RENTTAX"].ToString());
        //                        break;
        //                    }
        //                }
        //                decSubTtlMonthPay -= System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
        //            }
        //            else
        //            {
        //                if (intRowCnt + 1 < dtbMLMPREINVOICE.Rows.Count)
        //                {
        //                    if (System.Convert.ToInt32(strPreIssue) != System.Convert.ToInt32(dtbMLMPREINVOICE.Rows[intRowCnt + 1]["ISSUE"].ToString()))
        //                    {
        //                        dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"] = decSubTtlMonthPay.ToString("##,##0");
        //                        decimal decMONTHPAY = System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
        //                        decimal decAMOUNT = (decMONTHPAY * 20) / 21;
        //                        decAMOUNT = System.Math.Round(decAMOUNT, 0);
        //                        decimal decTAX = decMONTHPAY - decAMOUNT;
        //                        dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"] = decAMOUNT.ToString();
        //                        dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"] = decTAX.ToString();
        ////                    }
        ////                    else
        ////                    {
        ////                        decSubTtlMonthPay -= System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"] = decSubTtlMonthPay.ToString("##,##0");
        ////                    decimal decMONTHPAY = System.Convert.ToDecimal(dtbMLMPREINVOICE.Rows[intRowCnt]["MONTHPAY"].ToString());
        ////                    decimal decAMOUNT = (decMONTHPAY * 20) / 21;
        ////                    decAMOUNT = System.Math.Round(decAMOUNT, 0);
        ////                    decimal decTAX = decMONTHPAY - decAMOUNT;
        ////                    dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"] = decAMOUNT.ToString();
        ////                    dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"] = decTAX.ToString();
        ////                }
        ////            }
        ////            strPreIssue = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
        ////        }
        ////    }
        ////    rptData.DataSource = dtbMLMPREINVOICE;
        ////    rptData.DataBind();

        //    for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        //    {
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"].ToString();
        //        ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnRENTYEARS")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"].ToString();
        //        ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Text = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
        //        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();
        //        // ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnORDERDAY")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString();
        //    }
        //}

        //UDP 20170110 By SS Gordon Reason:檢核[手續費收入]、[動保費收入]、[墊款息收入]資料
        if (Convert.ToInt32(txtFEEAMT1.Text.Trim().Replace(",", "")) > 0)
        {
            if (rptData_2.Items.Count == 0)
            {
                Alert("手續費收入大於0，請作發票展期。");
                this.btnExtInvo.Attributes.Remove("display:none");
                this.btnExtInvo.Attributes.Add("style", "display:");
                return;
            }
        }
        if (Convert.ToInt32(txtFEEAMT2.Text.Trim().Replace(",", "")) > 0)
        {
            if (rptData_3.Items.Count == 0)
            {
                Alert("動保費收入大於0，請作發票展期。");
                this.btnExtInvo.Attributes.Remove("display:none");
                this.btnExtInvo.Attributes.Add("style", "display:");
                return;
            }
        }
        if (Convert.ToInt32(txtADVANCESINTEREST.Text.Trim().Replace(",", "")) > 0)
        {
            if (rptData_4.Items.Count == 0)
            {
                Alert("墊款息收入大於0，請作發票展期。");
                this.btnExtInvo.Attributes.Remove("display:none");
                this.btnExtInvo.Attributes.Add("style", "display:");
                return;
            }
        }

        for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        {
            dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value;
            if (dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString().Trim().Length == 3 || dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString().Trim().Length == 1)
            {
                dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"] = this.txtCNTRNO.Text.Trim() + ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value;
            }
            dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"] = ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"] = ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value;
            if (((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value.Trim() == "")
            {
                ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = "0";
            }
            if (((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value.Trim() == "")
            {
                ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = "0";
            }
            if (((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value.Trim() == "")
            {
                ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = "0";
            }
            if (((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value.Trim() == "")
            {
                ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = "0";
            }
            dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value;
        }

        //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤-設定資料
        //ViewState與Repeater的資料是同步的
        DataTable dtbFEEAMTPREINVOICE1 = (DataTable)ViewState[GetViewStateIdForFEEAMTPREINVOICE(enm頁籤類型.手續費發票)];
        DataTable dtbFEEAMTPREINVOICE2 = (DataTable)ViewState[GetViewStateIdForFEEAMTPREINVOICE(enm頁籤類型.動保費收入發票)];
        DataTable dtbFEEAMTPREINVOICE3 = (DataTable)ViewState[GetViewStateIdForFEEAMTPREINVOICE(enm頁籤類型.墊款息收入發票)];
        for (int intRowCnt = 0; intRowCnt < rptData_2.Items.Count; intRowCnt++)
        {
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnPREINVID_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["INVDESCTYPE"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnINVDESCTYPE_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["UNITID"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnUNITID_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["BZ"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnBZ_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["PREOPENWAY"] = ((DropDownList)rptData_2.Items[intRowCnt].FindControl("drpPREOPENWAY_2")).SelectedValue;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["INVKIND"] = ((DropDownList)rptData_2.Items[intRowCnt].FindControl("drpINVKIND_2")).SelectedValue;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["INVDESC"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnINVDESC_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["RTNAMTDESC"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnPRINCIPALDESC_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["AMOUNT"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnAMOUNT_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["TAX"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnTAXForAMOUNT_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["ISSUE"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnISSUE_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["SPECNOTE"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnSPECNOTE_2")).Value;
            dtbFEEAMTPREINVOICE1.Rows[intRowCnt]["MTRCNTRNO"] = ((HiddenField)rptData_2.Items[intRowCnt].FindControl("hdnMTRCNTRNO_2")).Value;            
        }
        for (int intRowCnt = 0; intRowCnt < rptData_3.Items.Count; intRowCnt++)
        {
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnPREINVID_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["INVDESCTYPE"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnINVDESCTYPE_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["UNITID"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnUNITID_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["BZ"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnBZ_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["PREOPENWAY"] = ((DropDownList)rptData_3.Items[intRowCnt].FindControl("drpPREOPENWAY_3")).SelectedValue;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["INVKIND"] = ((DropDownList)rptData_3.Items[intRowCnt].FindControl("drpINVKIND_3")).SelectedValue;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["INVDESC"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnINVDESC_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["RTNAMTDESC"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnPRINCIPALDESC_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["AMOUNT"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnAMOUNT_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["TAX"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnTAXForAMOUNT_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["ISSUE"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnISSUE_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["SPECNOTE"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnSPECNOTE_3")).Value;
            dtbFEEAMTPREINVOICE2.Rows[intRowCnt]["MTRCNTRNO"] = ((HiddenField)rptData_3.Items[intRowCnt].FindControl("hdnMTRCNTRNO_3")).Value;
        }
        for (int intRowCnt = 0; intRowCnt < rptData_4.Items.Count; intRowCnt++)
        {
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnPREINVID_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["INVDESCTYPE"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnINVDESCTYPE_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["UNITID"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnUNITID_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["BZ"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnBZ_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["PREOPENWAY"] = ((DropDownList)rptData_4.Items[intRowCnt].FindControl("drpPREOPENWAY_4")).SelectedValue;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["INVKIND"] = ((DropDownList)rptData_4.Items[intRowCnt].FindControl("drpINVKIND_4")).SelectedValue;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["INVDESC"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnINVDESC_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["RTNAMTDESC"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnPRINCIPALDESC_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["AMOUNT"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnAMOUNT_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["TAX"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnTAXForAMOUNT_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["ISSUE"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnISSUE_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["SPECNOTE"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnSPECNOTE_4")).Value;
            dtbFEEAMTPREINVOICE3.Rows[intRowCnt]["MTRCNTRNO"] = ((HiddenField)rptData_4.Items[intRowCnt].FindControl("hdnMTRCNTRNO_4")).Value;
        }
        //若無資料建立空資料表格
        if (rptData_2.Items.Count == 0)
        {
            dtbFEEAMTPREINVOICE1 = FEEAMTPREINVOInit();
        }
        if (rptData_3.Items.Count == 0)
        {
            dtbFEEAMTPREINVOICE2 = FEEAMTPREINVOInit();
        }
        if (rptData_4.Items.Count == 0)
        {
            dtbFEEAMTPREINVOICE3 = FEEAMTPREINVOInit();
        }

        //拼接信息
        getMLMPREINVOICEColInf(ref stbSaveFields, dtbMLMPREINVOICE, dtbFEEAMTPREINVOICE1, dtbFEEAMTPREINVOICE2, dtbFEEAMTPREINVOICE3);

        if (this.ddlSingle.SelectedValue == "2")
        {
            if (this.btnSplit.Attributes.CssStyle["display"] != "none")
            {
                DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
                //if (dtbMLDPREINVSPLIT.Rows.Count == 0)
                //{
                //    Alert("拆發票設定尚未完成！請重新設定完畢後，再執行展期作業。");
                //    return;
                //}
            }
        }

        //預開發票設定主檔
        getMLMPREINVSETColInf(ref stbSaveFields);


        if (this.ddlSummary.SelectedValue == "1")
        {
            if (this.hdnOPENCNTRNO.Value.Trim()=="")
            {
                Alert("彙開發票設定尚未完成！請重新設定完畢後，再執行展期作業。");
                return;
            }
        }
        try
        {
            //stbSaveFields = stbSaveFields.Replace("'", "’");
            //stbSaveFields = stbSaveFields.Replace("\"", "”");
            //stbSaveFields = stbSaveFields.Replace("--", "－－");
            string strPreProcBR = stbSaveFields.ToString().Replace("\r\n","<BR>");
//            ReturnObject<object> objReturnObject = SaveMLMPREINVOICESummary(stbSaveFields.ToString());
            ReturnObject<object> objReturnObject = SaveMLMPREINVOICESummary(strPreProcBR);
            if (objReturnObject.ReturnSuccess)
            {
//                Alert(Resources.HeRun.H001);
                Alert("處理成功！");
                //                RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
                Page.RegisterStartupScript("Close", "<script>window.close();</script>");
            }
            else
            {
                Alert("處理失敗！錯誤訊息為：" + objReturnObject.ReturnMessage);
                this.btnExtInvo.Attributes.Remove("display:none");
                this.btnExtInvo.Attributes.Add("style", "display:");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }

#endregion

    protected void ddlSingle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSingle.SelectedValue == "1")
        {
            Session["MLDPREINVSPLIT"] = null;
        }
    }

    //UDP 20170110 By SS Gordon Reason:新增手續費發票頁籤，動保費收入發票頁籤，墊款息收入發票頁籤
    protected void btnUS_2_Click(object sender, EventArgs e)
    {
        GetFEEAMTPREINVO(txtCNTRNO.Text.Trim(), enm頁籤類型.手續費發票);

        this.btnExtInvo.Attributes.Remove("style:display:none;");
        this.btnExtInvo.Attributes.Add("style", "display:;");
    }
    protected void btnUS_3_Click(object sender, EventArgs e)
    {
        GetFEEAMTPREINVO(txtCNTRNO.Text.Trim(), enm頁籤類型.動保費收入發票);

      this.btnExtInvo.Attributes.Remove("style:display:none;");
      this.btnExtInvo.Attributes.Add("style", "display:;");
    }
    protected void btnUS_4_Click(object sender, EventArgs e)
    {
        GetFEEAMTPREINVO(txtCNTRNO.Text.Trim(), enm頁籤類型.墊款息收入發票);

        this.btnExtInvo.Attributes.Remove("style:display:none;");
        this.btnExtInvo.Attributes.Add("style", "display:;");
    }
    private DataTable FEEAMTPREINVOInit()
    {
        DataTable dtbMLMPREINVOICE = new DataTable("MLMPREINVOICE");        
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVID", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESC", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMTDESC", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDESCTYPE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVKIND", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREOPENWAY", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("RENTYEARS", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("PREINVYYYYMM", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAXTYPE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("AMOUNT", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("TAX", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("DISAMT", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMT", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("RTNAMTTAX", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INSTAMT", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INSTAMTTAX", System.Type.GetType("System.Decimal")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("ORDERDAY", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("SPECNOTE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("BZ", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLIT", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSPLITNME", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSINGLENME", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("FGSUMMARY", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("MTRCNTRNO", System.Type.GetType("System.String")));

        return dtbMLMPREINVOICE;
    }
    private void GetFEEAMTPREINVO(string strCntrNo, enm頁籤類型 enmFeeType)
    {
        try
        {
            Comus.HtmlSubmitControl objComusSubmit;
            string strObjID;
            ReturnObject<DataTable> dtsReturnDataSet;
            string[] aryParameter = new string[2];

            strObjID = "ITG.CommDBService.QueryByStoreProcedure";

            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();

            if (enmFeeType == enm頁籤類型.墊款息收入發票)
            {
                aryParameter[0] = "SP_ML4001_Q15";                
                aryParameter[1] = "'" + strCntrNo + "'";
                
            }
            else
            {
                aryParameter[0] = "SP_ML4001_Q14";
                aryParameter[1] = "'" + strCntrNo + "','" + "0" + ((int)enmFeeType).ToString() + "'";
            }            
            dtsReturnDataSet = objComusSubmit.SubmitEx<DataTable>(strObjID, aryParameter);

            if (dtsReturnDataSet.ReturnSuccess)
            {
                DataTable dt = dtsReturnDataSet.ReturnData;
                SetFEEAMTPREINVOICEBind(dt, enmFeeType);
            }
            else
            {
                if (dtsReturnDataSet.ReturnMessage.Trim() != "")
                {
                    Alert(dtsReturnDataSet.ReturnMessage);
                }                
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void SetFEEAMTPREINVOICEBind(DataTable dtbFEEAMTPREINVOICE, enm頁籤類型 enmFeeType)
    {
        string viewStateID = GetViewStateIdForFEEAMTPREINVOICE(enmFeeType);
        ViewState.Remove(viewStateID);
        DataTable dtbFEEAMTPREINVOICE_New = FEEAMTPREINVOInit();

        if (dtbFEEAMTPREINVOICE.Rows.Count > 0)
        {            
            for (int rowIdx = 0; rowIdx < dtbFEEAMTPREINVOICE.Rows.Count; rowIdx++)
            {
                DataRow newRow = dtbFEEAMTPREINVOICE_New.NewRow();
                DataRow row = dtbFEEAMTPREINVOICE.Rows[rowIdx];
                for (int colIdx = 0; colIdx < dtbFEEAMTPREINVOICE.Columns.Count; colIdx++)
                {
                    DataColumn col = dtbFEEAMTPREINVOICE.Columns[colIdx];
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                dtbFEEAMTPREINVOICE_New.Rows.Add(newRow);
            }

            Repeater _rptData;
            DropDownList _drpINVKIND1;
            CheckBox _chk31;
            HiddenField _hdnSPECNOTE3;
            TextBox _txtRENTSTDTM;
            TextBox _txtRENTSTDTD;
            string _drpPREOPENWAY_ID = "";
            string _drpINVKIND_ID = "";
            string _drpTAXTYPE_ID = "";
            string _hdnBZ_ID = "";
            if (enmFeeType == enm頁籤類型.手續費發票)
            {
                _rptData = this.rptData_2;
                _drpINVKIND1 = this.drpINVKIND1_2;
                _chk31 = this.chk31_2;
                _hdnSPECNOTE3 = this.hdnSPECNOTE3_2;
                _drpPREOPENWAY_ID = "drpPREOPENWAY_2";
                _drpINVKIND_ID = "drpINVKIND_2";
                _drpTAXTYPE_ID = "drpTAXTYPE_2";
                _hdnBZ_ID = "hdnBZ_2";
                _txtRENTSTDTM = txtRENTSTDTM_2;
                _txtRENTSTDTD = txtRENTSTDTD_2;
            }
            else if (enmFeeType == enm頁籤類型.動保費收入發票)
            {
                _rptData = this.rptData_3;
                _drpINVKIND1 = this.drpINVKIND1_3;
                _chk31 = this.chk31_3;
                _hdnSPECNOTE3 = this.hdnSPECNOTE3_3;
                _drpPREOPENWAY_ID = "drpPREOPENWAY_3";
                _drpINVKIND_ID = "drpINVKIND_3";
                _drpTAXTYPE_ID = "drpTAXTYPE_3";
                _hdnBZ_ID = "hdnBZ_3";
                _txtRENTSTDTM = txtRENTSTDTM_3;
                _txtRENTSTDTD = txtRENTSTDTD_3;
            }
            else if (enmFeeType == enm頁籤類型.墊款息收入發票)
            {
                _rptData = this.rptData_4;
                _drpINVKIND1 = this.drpINVKIND1_4;
                _chk31 = this.chk31_4;
                _hdnSPECNOTE3 = this.hdnSPECNOTE3_4;
                _drpPREOPENWAY_ID = "drpPREOPENWAY_4";
                _drpINVKIND_ID = "drpINVKIND_4";
                _drpTAXTYPE_ID = "drpTAXTYPE_4";
                _hdnBZ_ID = "hdnBZ_4";
                _txtRENTSTDTM = txtRENTSTDTM_4;
                _txtRENTSTDTD = txtRENTSTDTD_4;
            }
            else
            {                
                return;
            }

            for (int i = 0; i < dtbFEEAMTPREINVOICE_New.Rows.Count; i++)
            {
                dtbFEEAMTPREINVOICE_New.Rows[i]["RENTYEARS"] = txtRENTSTDT.Text.Substring(0, 7);
                dtbFEEAMTPREINVOICE_New.Rows[i]["PREOPENWAY"] = "1";
                if (System.Convert.ToInt32(_txtRENTSTDTM.Text.Replace("/", "").Substring(0, 6)) < System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
                {
                    dtbFEEAMTPREINVOICE_New.Rows[i]["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
                }
                else
                {
                    dtbFEEAMTPREINVOICE_New.Rows[i]["PREINVYYYYMM"] = _txtRENTSTDTM.Text;
                }                
                dtbFEEAMTPREINVOICE_New.Rows[i]["ORDERDAY"] = _txtRENTSTDTD.Text;
            }

            _rptData.DataSource = dtbFEEAMTPREINVOICE_New;
            _rptData.DataBind();

            //發票備註
            string strBZ = "";
            if (_chk31.Checked)
            {
                strBZ += "合約編號:" + txtCNTRNO.Text;
            }
            if (_hdnSPECNOTE3.Value.ToString() != "")
            {
                strBZ += "<BR>" + "特殊備註:" + _hdnSPECNOTE3.Value;
            }

            for (int intRowCnt = 0; intRowCnt < _rptData.Items.Count; intRowCnt++)
            {
                ((DropDownList)_rptData.Items[intRowCnt].FindControl(_drpPREOPENWAY_ID)).SelectedValue = dtbFEEAMTPREINVOICE_New.Rows[intRowCnt]["PREOPENWAY"].ToString();
                ((DropDownList)_rptData.Items[intRowCnt].FindControl(_drpINVKIND_ID)).SelectedValue = _drpINVKIND1.SelectedValue;
                ((DropDownList)_rptData.Items[intRowCnt].FindControl(_drpTAXTYPE_ID)).SelectedValue = dtbFEEAMTPREINVOICE_New.Rows[intRowCnt]["TAXTYPE"].ToString();
                ((HiddenField)_rptData.Items[intRowCnt].FindControl(_hdnBZ_ID)).Value = strBZ;

            //    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
            //    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
            //    this.drpINVKIND1.SelectedValue = ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue;
            //    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpTAXTYPE")).SelectedValue = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["TAXTYPE"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
            //    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbFEEAMTPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();


                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"].ToString();
                //((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
                //((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnRENTYEARS")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"].ToString();
                //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();
                //((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Text = dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
            }                        
        }

        ViewState[viewStateID] = dtbFEEAMTPREINVOICE_New;
    }
    /// <summary>
    /// 修改-綁定預開發票設定主檔
    /// </summary>
    /// <param name="dtbData"></param>
    /// <param name="enmFeeType"></param>
    private void GetFEEAMTPREINVSETBind(DataTable dtbData, enm頁籤類型 enmFeeType)
    {
        if (dtbData.Rows.Count > 0)
        {
            TextBox _txtRENTSTDTM;
            TextBox _txtRENTSTDTD;
            DropDownList _drpINVKIND1;
            if (enmFeeType == enm頁籤類型.手續費發票)
            {
                _txtRENTSTDTM = txtRENTSTDTM_2;
                _txtRENTSTDTD = txtRENTSTDTD_2;
                _drpINVKIND1 = drpINVKIND1_2;
            }
            else if (enmFeeType == enm頁籤類型.動保費收入發票)
            {
                _txtRENTSTDTM = txtRENTSTDTM_3;
                _txtRENTSTDTD = txtRENTSTDTD_3;
                _drpINVKIND1 = drpINVKIND1_3;
            }
            else if (enmFeeType == enm頁籤類型.墊款息收入發票)
            {
                _txtRENTSTDTM = txtRENTSTDTM_4;
                _txtRENTSTDTD = txtRENTSTDTD_4;
                _drpINVKIND1 = drpINVKIND1_4;
            }
            else 
            {                
                return;
            }
            _txtRENTSTDTM.Text = dtbData.Rows[0]["INVOPENMONTH"].ToString();
            _txtRENTSTDTD.Text = dtbData.Rows[0]["ORDERDATE"].ToString();
            _drpINVKIND1.SelectedValue = dtbData.Rows[0]["INVKIND"].ToString();
        }
    }
    /// <summary>
    /// 修改-綁定預開發票備註設定檔
    /// </summary>
    /// <param name="dtbData"></param>
    private void GetFEEAMTPREINVNOTEBind(DataTable dtbData)
    {
        for (int i = 0; i < dtbData.Rows.Count; i++)
        {
            int intINVDESCTYPE = System.Convert.ToInt32(dtbData.Rows[i]["INVDESCTYPE"].ToString());
            HiddenField _hdnPREINVNOTEID3;
            CheckBox _chk31;
            HiddenField _hdnSPECNOTE3;

            if (intINVDESCTYPE == (int)enm發票類別.補貼款收入)
            {
                _hdnPREINVNOTEID3 = hdnPREINVNOTEID3_2;
                _chk31 = chk31_2;
                _hdnSPECNOTE3 = hdnSPECNOTE3_2;
            }
            else if (intINVDESCTYPE == (int)enm發票類別.手續費收入)
            {
                _hdnPREINVNOTEID3 = hdnPREINVNOTEID3_3;
                _chk31 = chk31_3;
                _hdnSPECNOTE3 = hdnSPECNOTE3_3;
            }
            else if (intINVDESCTYPE == (int)enm發票類別.墊款息收入)
            {
                _hdnPREINVNOTEID3 = hdnPREINVNOTEID3_4;
                _chk31 = chk31_4;
                _hdnSPECNOTE3 = hdnSPECNOTE3_4;
            }
            else
            {
                continue;
            }
            _hdnPREINVNOTEID3.Value = dtbData.Rows[i]["PREINVNOTEID"].ToString();

            if (dtbData.Rows[i]["CONTRACTNO"].ToString() == "1")
            {
                _chk31.Checked = true;
            }
            _hdnSPECNOTE3.Value = dtbData.Rows[i]["SPECNOTE"].ToString();
        }
    }
    /// <summary>
    /// 修改-綁定預開發票資料檔
    /// </summary>
    /// <param name="dtbData"></param>
    /// <param name="enmFeeType"></param>
    private void GetFEEAMTPREINVOICEBind(DataTable dtbData, enm頁籤類型 enmFeeType)
    {
        DataTable dtbData_New = FEEAMTPREINVOInit();
        if (dtbData.Rows.Count > 0)
        {
            for (int rowIdx = 0; rowIdx < dtbData.Rows.Count; rowIdx++)
            {
                DataRow newRow = dtbData_New.NewRow();
                DataRow row = dtbData.Rows[rowIdx];
                for (int colIdx = 0; colIdx < dtbData.Columns.Count; colIdx++)
                {
                    DataColumn col = dtbData.Columns[colIdx];
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                dtbData_New.Rows.Add(newRow);
            }

            Repeater _rptData;
            if (enmFeeType == enm頁籤類型.手續費發票)
            {
                _rptData = rptData_2;
            }
            else if (enmFeeType == enm頁籤類型.動保費收入發票)
            {
                _rptData = rptData_3;
            }
            else if (enmFeeType == enm頁籤類型.墊款息收入發票)
            {
                _rptData = rptData_4;
            }
            else
            {                
                return;
            }
            _rptData.DataSource = dtbData_New;
            _rptData.DataBind();

            string viewStateID = GetViewStateIdForFEEAMTPREINVOICE(enmFeeType);
            ViewState.Remove(viewStateID);
            ViewState[viewStateID] = dtbData_New;
        }
    }
    private string GetViewStateIdForFEEAMTPREINVOICE(enm頁籤類型 enmFeeType)
    {
        string viewStateID = "FEEAMTPREINVOICE" + ((int)enmFeeType).ToString();
        return viewStateID;
    }
}
