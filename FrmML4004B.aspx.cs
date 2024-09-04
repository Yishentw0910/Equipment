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


public partial class FrmML4004B : Itg.Community.PageBase
{
    private string strCustId = "";
    private string strCaseId = "";
    private string strCntrNo = "";
    private string strCompId = "";
    private ArrayList alistRents = new ArrayList();
    private ArrayList alistRtnAmts = new ArrayList();
    private ArrayList alistInstAmts = new ArrayList();

    private enum enm發票類別 { 租金 = 1, 押金設算息 = 2, 手續費 = 3, 本體 = 4, 分差 = 5, 本體加分差 = 6 }

    private enum enm承作類型 { 營租 = 01, 資租 = 02, 分期 = 03, AR = 04 }

    private enum enm本體分差開立方式 { 拆開 = 01, 不拆開 = 02 }

    private enum enm公司別 { 和運 = 01, 和潤 = 02 }
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
            MLMCONTRACT_Data.Add("txtRENTSTDT", "RENTSTDT");             //案件起租日   (抓ML3002的預計撥款日)
            MLMCONTRACT_Data.Add("txtRENTENDT", "RENTENDT");             //案件迄租日   (抓AR明細最後一期的票據到期日)
            MLMCONTRACT_Data.Add("txtPERBOND", "PERBOND");               //履約保證金
            MLMCONTRACT_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN"); //租購保證金 
            MLMCONTRACT_Data.Add("txtFIRSTPAY", "FIRSTPAY");             //頭期款 
            MLMCONTRACT_Data.Add("txtCUSTFPAYDATE", "CUSTFPAYDATE");     //客戶首期繳納日 (抓AR明細第一期的票據到期日)
            MLMCONTRACT_Data.Add("txtPAYMONTH", "PAYMONTH");             //幾月一付  
            MLMCONTRACT_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");   //承作月數  (抓AR明細票據張數)

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

            MLMCONTRACT_Data.Add("txtBILLAMT", "BILLAMT");               //總受讓期款金額  UPD BY VICKY 20150202
            MLMCONTRACT_Data.Add("txtCONTRACTMONTH1", "CONTRACTMONTH");  //總受讓張(期)數  UPD BY VICKY 20150202
            MLMCONTRACT_Data.Add("txtSUMFINANCIALFEES", "SUMFINANCIALFEES");     //手續費  UPD BY VICKY 20150202  

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
            MLMPREINVSET_Data.Add("ddlSingle", "UNITOPEN");               //單體彙開
            MLMPREINVSET_Data.Add("ddlSummary", "OVERALLOPEN");           //總體彙開
            MLMPREINVSET_Data.Add("ddlAplyTyp", "PREOPENWAY");            //預計開立方式
            MLMPREINVSET_Data.Add("ddlBdyDiffTyp", "OPENWAY");            //本體分差開立方式

            return MLMPREINVSET_Data;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4004B";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4004B";
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

            if (this.hdnPREINVSETID.Value.Trim() != "")
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
                }
                else
                {
                    if (this.ddlSummary.SelectedValue == "2")
                    {
                        this.ddlSummary.Enabled = false;
                        this.btnMerge.Attributes.Remove("display:;");
                        this.btnMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.chkMerge.Attributes.Remove("display:;");
                        this.chkMerge.Attributes.Add("style", "display:none;");
                        this.spanChkMerge.Attributes.Remove("display:;");
                        this.spanChkMerge.Attributes.Add("style", "display:none;");
                        if (this.ddlSingle.SelectedValue == "2")
                        {
                            //UPD BY VICKY 20150130 MARK
                            //this.ddlSingle.Enabled = true;
                            //if (this.txtRPRINCIPALTAX2.Text.Trim() == "")
                            //{
                            //    this.btnSplit.Attributes.Remove("display:none;");
                            //    this.btnSplit.Attributes.Add("style", "display:;");
                            //}
                        }
                        else
                        {
                            //UPD BY VICKY 20150130 MARK
                            //this.ddlSummary.Enabled = true;
                            this.btnSplit.Attributes.Remove("display:;");
                            this.btnSplit.Attributes.Add("style", "display:none;");
                        }
                    }
                    else
                    {
                        //UPD BY VICKY 2015030 MARK
                        //this.ddlSingle.Enabled = true;
                        //if (this.txtRPRINCIPALTAX2.Text.Trim() == "")
                        //{
                        //    this.btnSplit.Attributes.Remove("display:none;");
                        //    this.btnSplit.Attributes.Add("style", "display:;");
                        //}
                        //this.ddlSummary.Enabled = true;
                        this.btnMerge.Attributes.Remove("display:none;");
                        this.btnMerge.Attributes.Add("style", "display:;");
                        this.chkMerge.Attributes.Remove("display:none;");
                        this.chkMerge.Attributes.Add("style", "display:;");
                        this.chkMerge.Attributes.Remove("display:none;");
                        this.chkMerge.Attributes.Add("style", "display:;");
                        this.spanChkMerge.Attributes.Remove("display:none;");
                        this.spanChkMerge.Attributes.Add("style", "display:;");
                    }
                }

                if ((System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.資租) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.AR) || (System.Convert.ToInt32(this.hdnMAINTYPE.Value) == (int)enm承作類型.分期))
                {
                    this.btnSplit.Attributes.Remove("display:;");
                    this.btnSplit.Attributes.Add("style", "display:none;");

                    this.ddlBdyDiffTyp.Enabled = false;
                    this.ddlBdyDiffTyp.SelectedValue = "1";  //UPD BY VICKY 20150130
                    this.btn555.Attributes.Remove("display:none;");
                    this.btn555.Attributes.Add("style", "display:;");
                    this.btn666.Attributes.Remove("display:;");
                    this.btn666.Attributes.Add("style", "display:none;");
                    this.btn444.Attributes.Remove("display:;");
                    this.btn444.Attributes.Add("style", "display:none;");
                    this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                    this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");
                    this.tabCntrInvRmkInfo.Rows[4].Attributes.Remove("display:none");
                    this.tabCntrInvRmkInfo.Rows[4].Attributes.Add("style", "display:");
                    this.tabCntrInvRmkInfo.Rows[3].Attributes.Remove("display:");
                    this.tabCntrInvRmkInfo.Rows[3].Attributes.Add("style", "display:none");
                    this.tabCntrInvRmkInfo.Rows[5].Attributes.Remove("display:");
                    this.tabCntrInvRmkInfo.Rows[5].Attributes.Add("style", "display:none");

                    this.tabCntrInvInfo.Rows[2].Attributes.Remove("display:none");
                    this.tabCntrInvInfo.Rows[2].Attributes.Add("style", "display:");

                    this.ddlSingle.SelectedIndex = 0;
                    this.ddlSingle.SelectedValue = "1";
                    this.ddlSingle.Enabled = false;

                    this.ddlSummary.SelectedIndex = 1;
                    this.ddlSummary.SelectedValue = "2";
                    this.ddlSummary.Enabled = false;
                    this.txtPAYMONTHK.Enabled = false;
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
            strMAINTYPE = strMAINTYPE.Replace("0", "").Trim();
            string strSingle = "";

            strSingle = "2";
            //string strAplyTyp = Request.Form.GetValues("ddlAplyTyp")[0];
            //this.ddlAplyTyp.SelectedValue = strAplyTyp;
            string strSummary = "";
            if (strSingle == "1")
            {
                this.btnSplit.Attributes.Remove("display:;");
                this.btnSplit.Attributes.Add("style", "display:none;");
                if (Request.Form.GetValues("ddlSummary") == null)
                {
                    this.ddlSummary.Enabled = true;
                    strSummary = "2";
                }
                else
                {
                    strSummary = Request.Form.GetValues("ddlSummary")[0];
                }
            }
            else
            {
                this.btnSplit.Attributes.Remove("display:none;");
                this.btnSplit.Attributes.Add("style", "display:;");
                strSummary = "2";
            }

            DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];

            //營租才可以執行拆發票設定，其他業種別不行
            this.ddlBdyDiffTyp.SelectedValue = "1";
            this.btn444.Attributes.Remove("display:;");
            this.btn444.Attributes.Add("style", "display:none;");
            tbrCntrInvRmkInfo[3].Attributes.Remove("display:;");
            tbrCntrInvRmkInfo[3].Attributes.Add("style", "display:none;");
            tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
            tbrCntrInvRmkInfo[4].Attributes.Remove("display:;");
            tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:;");
            tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:none;");
            this.btn666.Attributes.Remove("display:;");
            this.btn666.Attributes.Add("style", "display:none;");

            this.txtPAYMONTHK.Enabled = false;
            this.btnSplit.Disabled = true;
            //this.ddlSingle.SelectedIndex = 1;
            //this.ddlSingle.SelectedValue = "2";
            //this.ddlSingle.Enabled = false;
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
                this.btn555.Attributes.Remove("display:none;");
                this.btn555.Attributes.Add("style", "display:;");
                tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
            }

            if (this.txtPAYMONTH.Text.Trim() == "1")
            {
                this.txtPAYMONTHK.Text = "1";
                this.txtPAYMONTHK.Enabled = false;
            }

            //取得本體分差開立方式，判斷備註設定內容
            string strBdyDiffTyp = Request["ddlBdyDiffTyp"];

            strBdyDiffTyp = "2";

            //營租才可以執行拆發票設定，其他業種別不行
            this.ddlSingle.SelectedIndex = 0;
            this.ddlSingle.SelectedValue = "1";
            this.ddlSingle.Enabled = false;
            if (!String.IsNullOrEmpty(strBdyDiffTyp) && System.Convert.ToInt32(strBdyDiffTyp) == (int)enm本體分差開立方式.拆開)
            {
                this.btn444.Attributes.Remove("display:;");
                this.btn444.Attributes.Add("style", "display:none;");
                this.btn555.Attributes.Remove("display:none;");
                this.btn555.Attributes.Add("style", "display:;");
                tbrCntrInvRmkInfo[3].Attributes.Remove("display:;");
                tbrCntrInvRmkInfo[3].Attributes.Add("style", "display:none;");
                tbrCntrInvRmkInfo[4].Attributes.Remove("display:none;");
                tbrCntrInvRmkInfo[4].Attributes.Add("style", "display:;");
                //UPD BY VICKY 20150202 AR件不顯示
                tbrCntrInvRmkInfo[5].Attributes.Remove("display:;");
                tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:none;");
            }
            else
            {
                this.btn666.Attributes.Remove("display:none;");
                this.btn666.Attributes.Add("style", "display:;");
                //tbrCntrInvRmkInfo[5].Attributes.Remove("display:none;");
                //tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:;");
                //UPD BY VICKY 20150202 AR件不顯示
                tbrCntrInvRmkInfo[5].Attributes.Remove("display:;");
                tbrCntrInvRmkInfo[5].Attributes.Add("style", "display:none;");
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
        }
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
        this.ddlSummary.Attributes.Add("onchange", "ddlSummary_onChange(this);");
        this.ddlAplyTyp.Attributes.Add("onchange", "ddlAplyTyp_onChange(this);");
        this.ddlBdyDiffTyp.Attributes.Add("onchange", "ddlBdyDiffTyp_onChange(this);");
        this.txtPERBOND.Attributes.Add("onchange", "txtPERBOND_onChange(this);");
        this.txtPURCHASEMARGIN.Attributes.Add("onchange", "txtPURCHASEMARGIN_onChange(this);");
        this.txtPAYMONTHK.Attributes.Add("onchange", "txtPAYMONTHK_onChange(this);");
        this.txtPAYMONTHK.Attributes.Add("onkeypress", "OnlyNum(this);");
        this.txtPAYMONTHK.Attributes.Add("onfocus", "MoneyFocus(this);");
        this.txtPAYMONTHK.Attributes.Add("onblur", "txtPAYMONTHK_onBlur(this);");
        this.txtRENTSTDTM.Attributes.Add("style", "ime-mode:disabled;");
        this.txtRENTSTDTM.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRENTSTDTM.Attributes.Add("onblur", "txtRENTSTDTM_onBlur(this);");
        this.txtRENTSTDTM.Attributes.Add("onfocus", "txtRENTSTDTM_onFocus(this);");
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
        this.btnExtInvo.Attributes.Add("style", "display:;");
        this.btnUS.Attributes.Add("style", "display:none;");
        //this.btnUA.Attributes.Add("style", "display:none;");
        this.btnUO.Attributes.Add("style", "display:none;");
        this.chk25.Enabled = false;
        this.chk26.Enabled = false;
        this.btnSplit.Attributes.Remove("display:;");
        this.btnSplit.Attributes.Add("style", "display:none;");
        this.btnMerge.Attributes.Remove("display:;");
        this.btnMerge.Attributes.Add("style", "display:none;");
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
        this.spanINVStarus.Attributes.Remove("display:none;color:#FF0000;");
        this.spanINVStarus.Attributes.Add("style", "display:;color:#FF0000;");
        this.spanINVAPLY.Attributes.Remove("display:;color:#990099;");
        this.spanINVAPLY.Attributes.Add("style", "display:none;color:#990099;");
        this.ddlAplyTyp.Attributes.Add("disabled", "true"); //UPD BY VICKY 20150202 加入鎖定
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

                    GetMLDCONTRACTCASHFLOWData();
                    DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];
                    GetMLDCONTRACTINSTBind(dtsCntrtInfo.Tables[1], dtbMLDCONTRACTCASHFLOW);

                    //案件起租日
                    string strRentStdt = this.txtRENTSTDT.Text.Trim();
                    //發票開啟月=起租月
                    switch (strRentStdt.Length)
                    {
                        case 7:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            break;
                        case 8:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 2);
                            break;
                        case 9:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            break;
                        case 10:
                            txtRENTSTDTM.Text = strRentStdt.Substring(0, txtRENTSTDT.Text.Length - 3);
                            break;
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
                    }

                    this.btnUA.Enabled = true;
                    this.btnUA.Attributes.Remove("display:none;");
                    this.btnUA.Attributes.Add("style", "display:;");
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
        string strObjId;
        StringBuilder stbStoreProcedure = new StringBuilder();
        StringBuilder stbQueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> dtsRtnObj;
        ReturnObject<DataTable> dtbRtnObj;
        string[] aryParameter = new string[2];
        try
        {
            strObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";


            //郵編區號
            stbStoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            stbQueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = stbStoreProcedure.ToString();
            aryParameter[1] = stbQueryCondition.ToString();
            dtsRtnObj = objComusSubmit.SubmitEx<DataSet>(strObjId, aryParameter);

            strObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = "SP_ML4007_Q00";
            aryParameter[1] = "'01'";
            dtbRtnObj = objComusSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
            if (dtbRtnObj.ReturnSuccess)
            {
                //綁定數據
                this.hdnCLSDT01.Value = dtbRtnObj.ReturnData.Rows[0]["CLSDT"].ToString();
            }
            else
            {
                Alert("無法取得關帳年月");
            }

            strObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = "SP_ML4007_Q00";
            aryParameter[1] = "'02'";
            dtbRtnObj = objComusSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
            if (dtbRtnObj.ReturnSuccess)
            {
                //綁定數據
                this.hdnCLSDT02.Value = dtbRtnObj.ReturnData.Rows[0]["CLSDT"].ToString();
            }
            else
            {
                Alert("無法取得關帳年月");
            }
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
        //本金餘額
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("RENTYM", System.Type.GetType("System.String")));
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
            this.hdnOPENMASTER.Value = "";
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
            //for (int intRow = 0; intRow < dtbMLDPREINVOPENMAJCNTR.Rows.Count; intRow++)
            //{
            //    if (dtbMLDPREINVOPENMAJCNTR.Rows[intRow]["CNTRNO"].ToString().Trim() == this.txtCNTRNO.Text.Trim())
            //    {
            //        bolOPENMASTER = true;
            //        break;
            //    }
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
            //this.ddlSingle.SelectedValue = "1";
            //this.ddlSingle.Enabled = true;
            //this.btnSplit.Attributes.Remove("display:");
            //this.btnSplit.Attributes.Remove("display:none");
            //this.ddlSummary.SelectedValue = "1";
            //this.ddlSummary.Enabled = true;
            //this.btnMerge.Attributes.Remove("display:none");
            //this.btnMerge.Attributes.Remove("display:");
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

    private void MLDPREINVOPEN_Init(DataTable dtbMLDPREINVOPENTmp)
    {
        //初始化欄位
        DataTable dtbMLDPREINVOPEN = new DataTable("MLDPREINVOPEN");
        //匯開編號
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("OPENCNTRNO", System.Type.GetType("System.String")));
        //匯開編號
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
        //預開發票月份
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("INVOPENMONTH", System.Type.GetType("System.String")));
        //幾月一開
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("OPENMONTH", System.Type.GetType("System.String")));
        //指定日期
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("ORDERDATE", System.Type.GetType("System.String")));
        //發票統編
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
        //發票抬頭
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
        //承作類型
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("MAINTYPES", System.Type.GetType("System.String")));
        //期數
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("RPAY", System.Type.GetType("System.String")));
        //總期數
        dtbMLDPREINVOPEN.Columns.Add(new DataColumn("CONTRACTMONTH", System.Type.GetType("System.String")));
        if (dtbMLDPREINVOPENTmp != null && dtbMLDPREINVOPENTmp.Rows.Count > 0)
        {
            dtbMLDPREINVOPEN = dtbMLDPREINVOPENTmp;

        }
        else
        {
            DataRow dtrDPREINVOPEN = dtbMLDPREINVOPEN.NewRow();
            dtrDPREINVOPEN["OPENCNTRNO"] = this.txtCNTRNO.Text.Trim();
            dtrDPREINVOPEN["CNTRNO"] = this.txtCNTRNO.Text.Trim();
            dtrDPREINVOPEN["INVOPENMONTH"] = this.txtRENTSTDTM.Text.Trim();
            dtrDPREINVOPEN["OPENMONTH"] = this.txtPAYMONTHK.Text.Trim();
            dtrDPREINVOPEN["ORDERDATE"] = this.txtRENTSTDTD.Text.Trim();
            dtrDPREINVOPEN["TARGETID"] = this.txtCUSTID.Text.Trim();
            dtrDPREINVOPEN["TARGETNAME"] = this.txtCUSTNAME.Text.Trim();
            dtrDPREINVOPEN["MAINTYPES"] = this.hdnMAINTYPE.Value.Trim();
            dtbMLDPREINVOPEN.Rows.Add(dtrDPREINVOPEN);
            this.hdnOPENMASTER.Value = "";
        }
        Session["MLDPREINVOPEN"] = dtbMLDPREINVOPEN;
    }

    private void GetMLDCONTRACTINSTBind(DataTable dtbMLDCONTRACTINST, DataTable dtbMLDCONTRACTCASHFLOW)
    {
        Decimal decTTLRent = 0;
        if (dtbMLDCONTRACTINST.Rows.Count == 4)
        {
            //UPD BY VICKY 20150130
            //this.txtRSTARTPAY1.Text = dtbMLDCONTRACTINST.Rows[0][2].ToString();
            //this.txtRENDPAY1.Text = dtbMLDCONTRACTINST.Rows[0][3].ToString();
            //this.txtRPRINCIPAL1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][4]).ToString("#,##0");
            //this.txtRPRINCIPALTAX1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][5]).ToString("#,##0");

            //this.hdnFinalLevel.Value = this.txtRENDPAY1.Text;

            //for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY1.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY1.Text); intRowCnt++)
            //{
            //    decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text);
            //}

            //this.txtRSTARTPAY2.Text = dtbMLDCONTRACTINST.Rows[1][2].ToString();
            //this.txtRENDPAY2.Text = dtbMLDCONTRACTINST.Rows[1][3].ToString();
            //if (this.txtRSTARTPAY2.Text.Trim() != "")
            //{
            //    this.txtRPRINCIPAL2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][4]).ToString("#,##0");
            //    this.txtRPRINCIPALTAX2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][5]).ToString("#,##0");
            //    this.hdnFinalLevel.Value = this.txtRENDPAY2.Text;
            //}

            //for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY2.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY2.Text); intRowCnt++)
            //{
            //    decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text);
            //}

            //this.txtRSTARTPAY3.Text = dtbMLDCONTRACTINST.Rows[2][2].ToString();
            //this.txtRENDPAY3.Text = dtbMLDCONTRACTINST.Rows[2][3].ToString();
            //if (this.txtRSTARTPAY3.Text.Trim() != "")
            //{
            //    this.txtRPRINCIPAL3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][4]).ToString("#,##0");
            //    this.txtRPRINCIPALTAX3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][5]).ToString("#,##0");
            //    this.hdnFinalLevel.Value = this.txtRENDPAY3.Text;
            //}

            //for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY3.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY3.Text); intRowCnt++)
            //{
            //    decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX3.Text);
            //}

            //this.txtRSTARTPAY4.Text = dtbMLDCONTRACTINST.Rows[3][2].ToString();
            //this.txtRENDPAY4.Text = dtbMLDCONTRACTINST.Rows[3][3].ToString();
            //if (this.txtRSTARTPAY4.Text.Trim() != "")
            //{
            //    this.txtRPRINCIPAL4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][4]).ToString("#,##0");
            //    this.txtRPRINCIPALTAX4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][5]).ToString("#,##0");
            //    this.hdnFinalLevel.Value = this.txtRENDPAY4.Text;
            //}

            //for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY4.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY4.Text); intRowCnt++)
            //{
            //    decTTLRent += System.Convert.ToDecimal(txtRPRINCIPALTAX4.Text);
            //}

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

                Boolean bolHasINVNO = false;
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
                        else
                        {
                            this.hdnOPENMASTER.Value = "";
                        }
                        this.btnMerge.Attributes.Remove("display:none");
                        this.btnMerge.Attributes.Remove("display:");
                        this.chkMerge.Attributes.Remove("display:none");
                        this.chkMerge.Attributes.Remove("display:");
                    }
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
                    ((DropDownList)rptData.Items[intRowCnt].FindControl("drpTAXTYPE")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["TAXTYPE"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
                    ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();
                    if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVNO"].ToString() != "" && dtbMLMPREINVOICE.Rows[intRowCnt]["INVDATE"].ToString() != "")
                    {
                        bolHasINVNO = true;
                        if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() == System.Convert.ToString((int)(enm發票類別.租金)))
                        {
                            this.hdnMAXINVRENTYM.Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
                        }
                        //rptData.Items[intRowCnt].TemplateControl.ApplyStyleSheetSkin=
                        ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREOPENWAY")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
                        ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).Enabled = false;
                        ((DropDownList)rptData.Items[intRowCnt].FindControl("drpTAXTYPE")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtTARGETID")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtTARGETNAME")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVZIPCODES")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVOICEADDR")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVZIPCODE")).Enabled = false;
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtORDERDAY")).Enabled = false;
                        ((Button)rptData.Items[intRowCnt].FindControl("btnINVZIPCODE")).Enabled = false;
                        ((Button)rptData.Items[intRowCnt].FindControl("btnBZ")).Enabled = false;
                    }
                    else
                    {
                        ((Label)rptData.Items[intRowCnt].FindControl("lblPREINVYYYYMM")).Attributes.Remove("display:");
                        ((Label)rptData.Items[intRowCnt].FindControl("lblPREINVYYYYMM")).Attributes.Add("style", "display:none");
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Attributes.Remove("display:none");
                        ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Attributes.Add("style", "display:");
                    }
                    //20230221 因進件需要 比照ML4004A新增本體分差發票增加載具號碼，捐贈，跟愛心碼
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

                    //20171204 ADD BY SS ADAM REASON.愛心碼跟載具要載入
                    if (intRowCnt == 0)
                    {
                        txtCARRIEID.Text = dtbMLMPREINVOICE.Rows[intRowCnt]["CARRIEID"].ToString().Trim();
                        chkDONATEMARK.Checked = dtbMLMPREINVOICE.Rows[intRowCnt]["DONATEMARK"].ToString().Trim() == "Y" ? true : false;
                        txtNPOBAN.Text = dtbMLMPREINVOICE.Rows[intRowCnt]["NPOBAN"].ToString().Trim();
                    }

                }
                ViewState["MLMPREINVOICE"] = dtbMLMPREINVOICE;

                if (IsPostBack)
                {
                    if (Request.Form.GetValues("hdnMAXINVRENTYM")[0].ToString().Trim() != "")
                    {
                        bolHasINVNO = false;
                    }
                }

                if (bolHasINVNO)
                {
                    this.txtRENTSTDTM.Attributes.Remove("diabled");
                    this.txtRENTSTDTM.Attributes.Add("diabled", "true");
                    this.txtRENTSTDTM.Enabled = false;
                    this.spanINVStarus.Attributes.Remove("display:;color:#FF0000;");
                    this.spanINVStarus.Attributes.Add("style", "display:none;color:#FF0000;");
                    this.spanINVAPLY.Attributes.Remove("display:none;color:#990099;");
                    this.spanINVAPLY.Attributes.Add("style", "display:;color:#990099;");
                }
                else
                {
                    this.spanINVStarus.Attributes.Remove("display:none;color:#FF0000;");
                    this.spanINVStarus.Attributes.Add("style", "display:;color:#FF0000;");
                    this.spanINVAPLY.Attributes.Remove("display:;color:#990099;");
                    this.spanINVAPLY.Attributes.Add("style", "display:none;color:#990099;");
                }
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
            //if (this.txtRSTARTPAY2.Text.Trim() == "")
            //{
            //    this.btnSplit.Attributes.Remove("display:none;");
            //    this.btnSplit.Attributes.Add("style", "display:;");
            //}
        }
        if (this.ddlSummary.SelectedValue == "1")
        {
            this.ddlSummary.Enabled = true;
            this.chkMerge.Attributes.Remove("display:none;");
            this.chkMerge.Attributes.Add("style", "display:;");
            this.spanChkMerge.Attributes.Remove("display:none;");
            this.spanChkMerge.Attributes.Add("style", "display:;");
            this.btnMerge.Attributes.Remove("display:none;");
            this.btnMerge.Attributes.Add("style", "display:;");
            DataTable dtbMLDPREINVOPEN = (DataTable)Session["MLDPREINVOPEN"];
            //if (dtbMLDPREINVOPEN.Rows[0]["OPENCNTRNO"].ToString().Trim() == this.txtCNTRNO.Text.Trim())
            //{
            //    this.chkMerge.Checked = true;
            //}
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
                        this.tabCntrInvRmkInfo.Rows[0].Attributes.Add("style", "display:");
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
                        this.tabCntrInvRmkInfo.Rows[1].Attributes.Add("style", "display:");
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
                            this.chk24.Checked = false;
                        }
                        if (dtbData.Rows[intRowCnt]["ACTACCOUNT"].ToString() == "1")
                        {
                            this.chk25.Checked = false;
                        }
                        if (dtbData.Rows[intRowCnt]["PAYDATE"].ToString() == "1")
                        {
                            this.chk26.Checked = false;
                        }
                        this.hdnSPECNOTE2.Value = dtbData.Rows[intRowCnt]["SPECNOTE"].ToString();
                        break;
                    case (int)(enm發票類別.本體):
                        this.hdnPREINVNOTEID4.Value = dtbData.Rows[intRowCnt]["PREINVNOTEID"].ToString();
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Remove("display:none");
                        this.tabCntrInvRmkInfo.Rows[3].Attributes.Add("style", "display:");
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
                        this.tabCntrInvRmkInfo.Rows[4].Attributes.Add("style", "display:");
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
                        this.tabCntrInvRmkInfo.Rows[5].Attributes.Add("style", "display:");
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
        string strObjId;
        StringBuilder stbStoreProcedure = new StringBuilder();
        StringBuilder stbQueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> dtsReturnDataSet;
        string[] aryParameter = new string[2];
        try
        {
            strObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            //綁定合約基本
            stbStoreProcedure.Append("SP_ML4004_Q13" + GSTR_RowDelimitChar);  //UPD BY VICKY 20150202 改用這支SP
            stbQueryCondition.Append(" AND MLMCONTRACT.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //撥款案件租賃分期明細檔MLDCONTRACTINST
            stbStoreProcedure.Append("SP_ML4004_Q04" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //綁定現金流量
            stbStoreProcedure.Append("SP_ML4004_Q05" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND MLDCONTRACTCASHFLOW.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //同一客戶營租資料彙開檔
            stbStoreProcedure.Append("SP_ML4004_Q12" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND D.CUSTID = ''''" + this.txtCUSTID.Text.Trim() + "''''  AND A.OPENMONTH = ''''" + this.txtPAYMONTHK.Text.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            if (this.hdnPREINVSETID.Value.Trim() != "")
            {
                //預開發票設定主檔[4]
                stbStoreProcedure.Append("SP_ML4004_Q11" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                //預開發票資料檔[5]
                stbStoreProcedure.Append("SP_ML4004_Q10" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                //預開發票品名明細檔[6]
                stbStoreProcedure.Append("SP_ML4004_Q09" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND B.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                //預開發票備註設定檔[7]
                stbStoreProcedure.Append("SP_ML4004_Q08" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND A.PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                //預開發票拆分設定檔[8]
                stbStoreProcedure.Append("SP_ML4004_Q07" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND A.PREINVSETID = ''''" + this.hdnPREINVSETID.Value.Trim() + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

                //資料彙開檔
                stbStoreProcedure.Append("SP_ML4004_Q06" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(" AND A.CNTRNO  = ''''" + this.txtCNTRNO.Text + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            }

            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = stbStoreProcedure.ToString();
            aryParameter[1] = stbQueryCondition.ToString();
            dtsReturnDataSet = objComusSubmit.SubmitEx<DataSet>(strObjId, aryParameter);
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
    protected void btnUA_Click(object sender, EventArgs e)
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
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVDATE", System.Type.GetType("System.String")));
        dtbMLMPREINVOICE.Columns.Add(new DataColumn("INVNO", System.Type.GetType("System.String")));

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
        strSingle = "1";  //UPD BY VICKY 20150202 鎖定在Y
        this.ddlSingle.SelectedValue = strSingle;  //UPD BY VICKY 20150202 鎖定在Y
                                                   //this.ddlSummary.SelectedValue = strSingle; //UPD BY VICKY 20150202 鎖定在N
                                                   //if (IsPostBack)
                                                   //{
                                                   //    strSingle = "2";
                                                   //}
                                                   //else
                                                   //{
                                                   //    strSingle = this.ddlSingle.SelectedValue;
                                                   //}

        int intContractMonth = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
        string strCntrNo = this.txtCNTRNO.Text;
        //發票開起月
        string strPreInvStdt = this.txtRENTSTDTM.Text + "/01";
        //案件起租日
        string strRentStdt = this.txtRENTSTDT.Text;
        //承作類型
        string strMainType = this.txtMAINTYPENM.Text;

        //UPD BY VICKY 20150130
        //int intEndPay1 = Convert.ToInt32("0" + txtRENDPAY1.Text);
        //int intEndPay2 = Convert.ToInt32("0" + txtRENDPAY2.Text);
        //int intEndPay3 = Convert.ToInt32("0" + txtRENDPAY3.Text);
        //int intEndPay4 = Convert.ToInt32("0" + txtRENDPAY4.Text);

        //前張發票租金年月
        string strPrevRentYYYYMM = "";
        //目前發票租金年月
        string strCurrRentYM = "";
        //前張預開發票年月
        string strPrevINVYM = "";
        //目前預開發票年月
        string strCurrINVYM = "";

        string strPAYMONTHK = this.txtPAYMONTHK.Text;

        DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];

        decimal decPROCEDEINVTTL = 0;
        decimal decINVOICEAMOUNT = 0;

        decPROCEDEINVTTL = System.Convert.ToDecimal(this.hdnPROCEDEINV.Value);

        if (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.不拆開)
        {
            dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
            dtrRwTmpl["ISSUE"] = "01";
            dtrRwTmpl["UNITID"] = "";

            dtrRwTmpl["INVDESC"] = "手續費";

            dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.本體加分差));
            dtrRwTmpl["INVKIND"] = strINVKIND;
            dtrRwTmpl["PREOPENWAY"] = "1";
            strCurrRentYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
            strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
            dtrRwTmpl["RENTYEARS"] = strCurrRentYM.Substring(0, strCurrRentYM.Length - 3);
            if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) < System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
            {
                dtrRwTmpl["PREOPENWAY"] = Request.Form.GetValues("ddlAplyTyp")[0];
                dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");
            }
            else
            {
                dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
            }
            dtrRwTmpl["TAXTYPE"] = "1";
            dtrRwTmpl["TARGETID"] = txtCUSTID.Text;
            dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;

            //AR以實貸金額帶入 
            dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(this.hdnTTLRent.Value) - System.Convert.ToDecimal(this.txtACTUSLLOANS.Text)).ToString("##,##0");
            dtrRwTmpl["DISAMT"] = "0";
            decimal decMONTHPAY = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"]);
            decimal decAMOUNT = decMONTHPAY * 20 / 21;
            decAMOUNT = System.Math.Round(decAMOUNT, 0);
            dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
            dtrRwTmpl["TAX"] = System.Convert.ToDecimal(decMONTHPAY - decAMOUNT).ToString("##,##0");

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
        else
        {
            decimal decMONTHPAY = 0;
            decimal decAMOUNT = 0;
            decimal decTAX = 0;

            dtrRwTmpl = dtbMLMPREINVOICE.NewRow();
            dtrRwTmpl["ISSUE"] = "01";  //期數
            dtrRwTmpl["UNITID"] = "";   //單體編號

            dtrRwTmpl["INVDESC"] = "手續費";  //品名設定內HiddenField

            dtrRwTmpl["INVDESCTYPE"] = System.Convert.ToString((int)(enm發票類別.分差));  //品名設定內HiddenField
            dtrRwTmpl["INVKIND"] = strINVKIND;   //發票聯式
            dtrRwTmpl["PREOPENWAY"] = "1";       //預計開立方式  1:單筆開立  2:批次開立   3:暫不開立
            strCurrRentYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");  //strPreInvStdt = 發票開起月
            strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(0).ToString("yyyy/MM/dd");
            dtrRwTmpl["RENTYEARS"] = strCurrRentYM.Substring(0, strCurrRentYM.Length - 3);   //租金年月
            if (System.Convert.ToInt32(strCurrINVYM.Replace("/", "").Substring(0, 6)) < System.Convert.ToInt32(this.hdnSysDate.Value.Trim()))
            {
                dtrRwTmpl["PREOPENWAY"] = "1";  //預計開立方式  1:單筆開立 
                dtrRwTmpl["PREINVYYYYMM"] = DateTime.Now.ToString("yyyy/MM");  //預開發票年月
            }
            else
            {
                dtrRwTmpl["PREINVYYYYMM"] = strCurrINVYM.Substring(0, strCurrINVYM.Length - 3);
            }
            dtrRwTmpl["TAXTYPE"] = "1";     //稅率   1:應稅  2:零稅  3:免稅
            dtrRwTmpl["TARGETID"] = txtCUSTID.Text;        //對象統編
            dtrRwTmpl["TARGETNAME"] = txtCUSTNAME.Text;    //對象名稱
                                                           //dtrRwTmpl["MONTHPAY"] = (System.Convert.ToDecimal(this.hdnTTLRent.Value) + System.Convert.ToDecimal(this.txtFIRSTPAY.Text) - decPROCEDEINVTTL).ToString("##,##0");
                                                           //UPD BY VICKY 20150130 直接帶總受讓期款金額
            dtrRwTmpl["MONTHPAY"] = System.Convert.ToDecimal(this.txtSUMFINANCIALFEES.Text).ToString("##,##0");
            dtrRwTmpl["DISAMT"] = "0";
            decAMOUNT = System.Math.Round((System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) * 20 / 21), 0);
            decTAX = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString()) - decAMOUNT;
            //UPD BY VICKY 20150202 不知未稅及應稅怎麼區分,稅額先帶0
            //decAMOUNT = System.Convert.ToDecimal(dtrRwTmpl["MONTHPAY"].ToString());
            //decTAX = 0;
            dtrRwTmpl["AMOUNT"] = decAMOUNT.ToString();
            dtrRwTmpl["TAX"] = decTAX.ToString("##,##0");

            dtrRwTmpl["INVZIPCODE"] = this.txtINVZIPCODE.Text;    //發票地址
            dtrRwTmpl["INVZIPCODES"] = this.txtINVZIPCODES.Text;  //發票地址
            dtrRwTmpl["INVOICEADDR"] = this.txtINVOICEADDR.Text;  //發票地址
            dtrRwTmpl["ORDERDAY"] = txtRENTSTDTD.Text;            //指定日
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

            dtrRwTmpl["BZ"] = strBZ;  //備註 HiddenField
            dtrRwTmpl["FGSINGLE"] = this.ddlSingle.SelectedValue;  //拆發票
            if (this.ddlSingle.SelectedValue == "1")
            {
                dtrRwTmpl["FGSINGLENME"] = "Y";
            }
            dtrRwTmpl["FGSPLIT"] = "2";    //單體彙開
            dtrRwTmpl["FGSPLITNME"] = "";
            dtrRwTmpl["FGSUMMARY"] = "2";
            dtrRwTmpl["MTRCNTRNO"] = "";   //總體彙開
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
                dtrRwTmpl["INVKIND"] = strINVKIND;
                if (j == 1)
                {
                    dtrRwTmpl["PREOPENWAY"] = Request.Form.GetValues("ddlAplyTyp")[0];
                    strRntRngSTdt = this.txtRENTSTDT.Text;
                    strRntRngEDdt = System.Convert.ToDateTime(strRntRngSTdt).AddMonths(System.Convert.ToInt32(j - 1)).AddDays(-1).ToString("yyyy/MM/dd");
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


                    strCurrRentYM = System.Convert.ToDateTime(strRentStdt).AddMonths(j - 1).ToString("yyyy/MM/dd");
                    strCurrINVYM = System.Convert.ToDateTime(strPreInvStdt).AddMonths(j - 1).ToString("yyyy/MM/dd");
                }
                else
                {
                    dtrRwTmpl["PREOPENWAY"] = Request.Form.GetValues("ddlAplyTyp")[0];
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
                    strCurrRentYM = System.Convert.ToDateTime(strPrevRentYYYYMM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
                    strCurrINVYM = System.Convert.ToDateTime(strPrevINVYM).AddMonths(System.Convert.ToInt32(1)).ToString("yyyy/MM/dd");
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
                strPrevINVYM = strCurrINVYM;
                dtrRwTmpl["RENTYEARS"] = strCurrRentYM.Substring(0, strCurrRentYM.Length - 3);
                strPrevRentYYYYMM = strCurrRentYM;
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
                    strBZ += "<BR>" + "繳款日:" + strCurrRentYM.Substring(0, strCurrRentYM.Length - 3) + txtCUSTFPAYDATE.Text.Substring(7, 3);
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

        DataTable dtbMLMPREINVOICE_Old = (DataTable)ViewState["MLMPREINVOICE"];

        DataView DV_Reorder = dtbMLMPREINVOICE.DefaultView;
        DV_Reorder.Sort = "ISSUE Asc";
        dtbMLMPREINVOICE = DV_Reorder.ToTable();

        for (int intRowCnt1 = 0; intRowCnt1 < dtbMLMPREINVOICE.Rows.Count; intRowCnt1++)
        {
            DataRow dtrMLMPREINVOICE = dtbMLMPREINVOICE.Rows[intRowCnt1];
            for (int intRowCnt2 = 0; intRowCnt2 < dtbMLMPREINVOICE_Old.Rows.Count; intRowCnt2++)
            {
                DataRow dtrMLMPREINVOICE_Old = dtbMLMPREINVOICE_Old.Rows[intRowCnt2];
                if (System.Convert.ToInt32(dtrMLMPREINVOICE["ISSUE"].ToString().Trim()) == System.Convert.ToInt32(dtrMLMPREINVOICE_Old["ISSUE"].ToString().Trim()) &&
                    dtrMLMPREINVOICE["INVDESCTYPE"].ToString().Trim() == dtrMLMPREINVOICE_Old["INVDESCTYPE"].ToString().Trim() &&
                    dtrMLMPREINVOICE["RENTYEARS"].ToString().Trim() == dtrMLMPREINVOICE_Old["RENTYEARS"].ToString().Trim() &&
                    dtrMLMPREINVOICE["UNITID"].ToString().Replace(this.txtCNTRNO.Text, "").Trim() == dtrMLMPREINVOICE_Old["UNITID"].ToString().Replace(this.txtCNTRNO.Text, "").Trim())
                {
                    dtrMLMPREINVOICE["PREINVID"] = dtrMLMPREINVOICE_Old["PREINVID"].ToString().Trim();
                    dtrMLMPREINVOICE["INVNO"] = dtrMLMPREINVOICE_Old["INVNO"].ToString().Trim();
                    dtrMLMPREINVOICE["INVDATE"] = dtrMLMPREINVOICE_Old["INVDATE"].ToString().Trim();
                    dtrMLMPREINVOICE["PREOPENWAY"] = dtrMLMPREINVOICE_Old["PREOPENWAY"].ToString().Trim();
                    dtrMLMPREINVOICE["INVKIND"] = dtrMLMPREINVOICE_Old["INVKIND"].ToString().Trim();
                }
            }
        }

        rptData.DataSource = dtbMLMPREINVOICE;
        rptData.DataBind();
        Boolean bolHasINVNO = false;

        for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        {
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVNO"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDATE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDATE"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnUNITID")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["UNITID"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnBZ")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["BZ"].ToString();
            if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVNO"].ToString() == "" && dtbMLMPREINVOICE.Rows[intRowCnt]["INVDATE"].ToString() == "")
            {
                //((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = Request.Form.GetValues("ddlAplyTyp")[0];
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = this.ddlAplyTyp.SelectedValue;
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = Request.Form.GetValues("drpINVKIND1")[0];
            }
            else
            {
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["PREOPENWAY"].ToString();
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).SelectedValue = dtbMLMPREINVOICE.Rows[intRowCnt]["INVKIND"].ToString();
            }

            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPALDESC")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTDESC"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["TAX"].ToString();
            //UPD BY VICKY 20150202 帶入算出的手續費金額及稅金
            //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnAMOUNT")).Value = System.Convert.ToDecimal(this.txtSUMFINANCIALFEES.Text).ToString("##,##0");
            //((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForAMOUNT")).Value = "0";
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMT"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForPRINCIPAL")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RTNAMTTAX"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMT"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnTAXForINSTAMT")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["INSTAMTTAX"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnISSUE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnRENTYEARS")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["RENTYEARS"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnSPECNOTE")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["SPECNOTE"].ToString();
            ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnMTRCNTRNO")).Value = dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"].ToString();

            if (dtbMLMPREINVOICE.Rows[intRowCnt]["INVNO"].ToString() != "" && dtbMLMPREINVOICE.Rows[intRowCnt]["INVDATE"].ToString() != "")
            {
                bolHasINVNO = true;
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPREOPENWAY")).Enabled = false;
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpINVKIND")).Enabled = false;
                ((DropDownList)rptData.Items[intRowCnt].FindControl("drpTAXTYPE")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtTARGETID")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtTARGETNAME")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVZIPCODES")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVOICEADDR")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtINVZIPCODE")).Enabled = false;
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtORDERDAY")).Enabled = false;
                ((Button)rptData.Items[intRowCnt].FindControl("btnINVZIPCODE")).Enabled = false;
                ((Button)rptData.Items[intRowCnt].FindControl("btnBZ")).Enabled = false;
            }
            else
            {
                ((Label)rptData.Items[intRowCnt].FindControl("lblPREINVYYYYMM")).Attributes.Remove("display:");
                ((Label)rptData.Items[intRowCnt].FindControl("lblPREINVYYYYMM")).Attributes.Add("style", "display:none");
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Attributes.Remove("display:none");
                ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Attributes.Add("style", "display:");
            }
        }

        string strPreIssue = dtbMLMPREINVOICE.Rows[0]["ISSUE"].ToString();
        //Decimal decSubTtlMonthPay = System.Convert.ToDecimal(this.txtRPRINCIPALTAX1.Text);

        if (bolHasINVNO)
        {
            this.txtRENTSTDTM.Attributes.Remove("diabled");
            this.txtRENTSTDTM.Attributes.Add("diabled", "true");
            this.txtRENTSTDTM.Enabled = false;
            this.spanINVStarus.Attributes.Remove("display:;color:#FF0000;");
            this.spanINVStarus.Attributes.Add("style", "display:none;color:#FF0000;");
            this.spanINVAPLY.Attributes.Remove("display:none;color:#990099;");
            this.spanINVAPLY.Attributes.Add("style", "display:;color:#990099;");
        }
        else
        {
            this.spanINVStarus.Attributes.Remove("display:none;color:#FF0000;");
            this.spanINVStarus.Attributes.Add("style", "display:;color:#FF0000;");
            this.spanINVAPLY.Attributes.Remove("display:;color:#990099;");
            this.spanINVAPLY.Attributes.Add("style", "display:none;color:#990099;");
        }

        if (this.hdnMAXINVRENTYM.Value.Trim() != "")
        {
        }

        ViewState["MLMPREINVOICE"] = dtbMLMPREINVOICE;

        this.btnExtInvo.Attributes.Remove("style:display:none;");
        this.btnExtInvo.Attributes.Add("style", "display:;");

    }

    #endregion

    #region 呼叫後端元件

    /// <summary>
    /// getMLMPREINVOICEColInf-預開發票資料檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLMPREINVOICEColInf(ref StringBuilder stbSaveFields, DataTable dtbPREINVOICE)
    {
        if (this.hdnPREINVSETID.Value.Trim() != "")
        {
            stbSaveFields.Append("SP_ML4001_D00" + GSTR_ColDelimitChar);
            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(this.hdnPREINVSETID.Value.Trim());
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }

        if (this.hdnMAXINVRENTYM.Value.Replace("/", "").Trim() == "")
        {
            this.hdnMAXINVRENTYM.Value = "0";
        }

        for (int intRowCnt = 0; intRowCnt < dtbPREINVOICE.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
            if (dtbTempRow["INVNO"].ToString().Trim() == "" && dtbTempRow["INVDATE"].ToString().Trim() == "")
            {
                if (dtbTempRow["INVDESCTYPE"].ToString().Trim() == System.Convert.ToString((int)(enm發票類別.租金)))
                {
                    stbSaveFields.Append("SP_ML4004_I01" + GSTR_ColDelimitChar);
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
                    stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
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


                    stbSaveFields.Append("SP_ML4004_I03" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(), "").Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar); stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
                else
                {
                    stbSaveFields.Append("SP_ML4004_I01" + GSTR_ColDelimitChar);
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
                        stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(), "").Trim() + GSTR_TabDelimitChar);
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
                    stbSaveFields.Append(dtbTempRow["MONTHPAY"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["DISAMT"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
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
                    //20230221 因進件需要 比照ML4004A新增本體分差發票增加載具號碼，捐贈，跟愛心碼
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

                    stbSaveFields.Append("SP_ML4004_I03" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
                    stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + dtbTempRow["UNITID"].ToString().Replace(this.txtCNTRNO.Text.Trim(), "").Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["AMOUNT"].ToString().Trim() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbTempRow["TAX"].ToString().Trim() + GSTR_TabDelimitChar); stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
            }
            else
            {
            }
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
            stbSaveFields.Append("SP_ML4004_I03" + GSTR_ColDelimitChar);
            stbSaveFields.Append(strPREINVID + GSTR_TabDelimitChar);
            stbSaveFields.Append(Itg.Community.Util.GetIDSequence("MLDPREINVOICEDESC", "14") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["UNITID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["INVDESC"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["AMOUNT"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["TAX"].ToString().Replace(",", "").Trim() + GSTR_TabDelimitChar);
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
        if (System.Convert.ToInt32(this.ddlBdyDiffTyp.SelectedValue) == (int)enm本體分差開立方式.不拆開)
        {
            stbSaveFields.Append("SP_ML4004_I02" + GSTR_ColDelimitChar);
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
            stbSaveFields.Append("SP_ML4004_I02" + GSTR_ColDelimitChar);
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

            stbSaveFields.Append("SP_ML4004_I02" + GSTR_ColDelimitChar);
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

        //押金設算息
        if (this.txtPERBOND.Text != "0" || this.txtPURCHASEMARGIN.Text != "0")
        {
            stbSaveFields.Append("SP_ML4004_I02" + GSTR_ColDelimitChar);
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
    }

    /// <summary>
    /// getMLMPREINVSETColInf-預開發票設定主檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLMPREINVSETColInf(ref StringBuilder stbSaveFields)
    {
        DataTable dtbPREINVOICE = (DataTable)ViewState["MLMPREINVOICE"];
        stbSaveFields.Append("SP_ML4004_I06" + GSTR_ColDelimitChar);
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

        getMLDPREINVNOTEColInf(strPREINVSETID, ref stbSaveFields);


        if (this.btnSplit.Attributes.CssStyle["display"] != "none")
        {
            if (Session["MLDPREINVSPLIT"] != null)
            {
                DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];

                if (dtbMLDPREINVSPLIT != null)
                {
                    for (Int32 intRowCnt = 0; intRowCnt < dtbMLDPREINVSPLIT.Rows.Count; intRowCnt++)
                    {
                        stbSaveFields.Append("SP_ML4004_I05" + GSTR_ColDelimitChar);
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
    }

    /// <summary>
    /// getMLDPREINVOPENColInf-預開發票合約彙開設定檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private string getMLDPREINVOPENColInf()
    {
        string strMLDPREINVOPENColInf = "";
        return strMLDPREINVOPENColInf;
    }

    /// <summary>
    /// getMLDPREINVSPLITColInf-預開發票拆分設定檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLDPREINVSPLITColInf(ref StringBuilder stbSaveFields)
    {

    }

    /// <summary>
    /// SaveMLMPREINVOICESummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLMPREINVOICESummary(string strProcData)
    {
        Comus.HtmlSubmitControl objComusSubmitCtl;
        string strObjId;
        ReturnObject<object> objReturnObject;
        string[] aryParameter = new string[1];
        try
        {
            strObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            objComusSubmitCtl = new Comus.HtmlSubmitControl();
            objComusSubmitCtl.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = strProcData;
            objReturnObject = objComusSubmitCtl.SubmitEx<object>(strObjId, aryParameter);
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
        if (ViewState["MLDPREINVSPLIT"] != null)
        {
            DataTable dtbMLDPREINVSPLIT = (DataTable)ViewState["MLDPREINVSPLIT"];
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

        for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        {
            dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"] = ((TextBox)rptData.Items[intRowCnt].FindControl("txtPREINVYYYYMM")).Text;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVNO"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVNO")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVDATE"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDATE")).Value;
            dtbMLMPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value;
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
            dtbMLMPREINVOICE.Rows[intRowCnt]["MTRCNTRNO"] = this.hdnOPENCNTRNO.Value;
        }

        //拼接信息
        getMLMPREINVOICEColInf(ref stbSaveFields, dtbMLMPREINVOICE);

        if (this.ddlSingle.SelectedValue == "2")
        {
            if (this.btnSplit.Attributes.CssStyle["display"] != "none")
            {
                DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
            }
        }

        if (this.ddlSummary.SelectedValue == "1")
        {
            if (this.hdnOPENCNTRNO.Value.Trim() == "")
            {
                Alert("彙開發票設定尚未完成！請重新設定完畢後，再執行展期作業。");
                return;
            }
        }

        //預開發票設定主檔
        getMLMPREINVSETColInf(ref stbSaveFields);
        string strPreprocBR = stbSaveFields.ToString().Replace("<BR>", "\r\n");

        try
        {
            ReturnObject<object> objReturnObject = SaveMLMPREINVOICESummary(stbSaveFields.ToString());
            if (objReturnObject.ReturnSuccess)
            {

                Alert("處理成功！");

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

}
