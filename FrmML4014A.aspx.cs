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

public partial class FrmML4014A : Itg.Community.PageBase
{
    private string strCustId = "";
    private string strCaseId = "";
    private string strCntrNo = "";
    private string strCompId = "";
    private ArrayList alistRents = new ArrayList();
    private ArrayList alistRtnAmts = new ArrayList();
    private ArrayList alistInstAmts = new ArrayList();

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


            return MLMCONTRACT_Data;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4014A";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4014A";
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
        //this.hdnPREINVSETID.Value = Request.QueryString["PREINVSETID"].ToString() + "";
        this.hdnBANKEXPAND.Value = Request.QueryString["BANKEXPAND"].ToString() + "";

        if (this.hdnBANKEXPAND.Value.Trim() != "")
        {
            this.btnUS.Attributes.Remove("display:;");
            this.btnUS.Attributes.Add("style", "display:none;");
            //btnUS.Enabled = false;
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

        if (!Page.IsPostBack)
        {
            PageDataBind(strCntrNo);
        }
    }

    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtPERBOND.Attributes.Add("onchange", "txtPERBOND_onChange(this);");
        this.txtPURCHASEMARGIN.Attributes.Add("onchange", "txtPURCHASEMARGIN_onChange(this);");
        //this.btnUS.Attributes.Add("onclick", "btnUS_onClick(this);");
        this.btnExtInvo.Attributes.Add("style", "display:none;");
        this.btnUS.Attributes.Add("style", "display:;");
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
                    GetMLDCONTRACTCASHFLOWData();
                    DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];
                    GetMLDCONTRACTINSTBind(dtsCntrtInfo.Tables[1], dtbMLDCONTRACTCASHFLOW);

                    if (this.hdnBANKEXPAND.Value.Trim() != "")
                    {
                        this.btnUS.Attributes.Remove("display:;");
                        this.btnUS.Attributes.Add("style", "display:none;");
                        GetMLDCONTRACTBANKEXPANDBind(dtsCntrtInfo.Tables[2]);
                    }                
                }
            }
            catch (Exception ex)
            {

                Alert(ex.Message);
            }
        }
    }

    private void GetMLDCONTRACTCASHFLOWData()
    {
        DataTable dtbMLDCONTRACTCASHFLOW = new DataTable("MLDCONTRACTCASHFLOW");
        //合約號碼
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("CNTRNO", System.Type.GetType("System.String")));
        //繳款日
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("PAYDATE", System.Type.GetType("System.String")));
        //期數
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("ISSUE", System.Type.GetType("System.String")));
        //租金(未稅)
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("RENT", System.Type.GetType("System.String")));
        //租金(含稅)
        dtbMLDCONTRACTCASHFLOW.Columns.Add(new DataColumn("RENTTAX", System.Type.GetType("System.String")));

        ViewState["MLDCONTRACTCASHFLOW"] = dtbMLDCONTRACTCASHFLOW;
    }

    private void GetMLDCONTRACTINSTBind(DataTable dtbMLDCONTRACTINST, DataTable dtbMLDCONTRACTCASHFLOW)
    {

        Decimal decTTLRent = 0;
        if (dtbMLDCONTRACTINST.Rows.Count == 4)
        {
            //判斷合約首期繳款日是否為月底
            DateTime dtmCUSTFPAYDATE = System.Convert.ToDateTime(this.txtCUSTFPAYDATE.Text);
            System.DateTime ThisMonEndDay = new System.DateTime(dtmCUSTFPAYDATE.Year, dtmCUSTFPAYDATE.Month, 1);
            Boolean bolMonEndDay = false;
            if (ThisMonEndDay.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") == this.txtCUSTFPAYDATE.Text)
            {
                bolMonEndDay = true;
            }
            else
            {
                bolMonEndDay = false;
            }
            //期付款繳款日
            string strPayDate = "";

            //第一段期付款
            this.txtRSTARTPAY1.Text = dtbMLDCONTRACTINST.Rows[0][2].ToString();
            this.txtRENDPAY1.Text = dtbMLDCONTRACTINST.Rows[0][3].ToString();
            this.txtRPRINCIPAL1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][4]).ToString("#,##0");
            this.txtRPRINCIPALTAX1.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[0][5]).ToString("#,##0");

            this.hdnFinalLevel.Value = this.txtRENDPAY1.Text;

            if (!String.IsNullOrEmpty(this.txtRSTARTPAY1.Text))
            {
                for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY1.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY1.Text); intRowCnt++)
                {
                    if (bolMonEndDay)
                    {
                        strPayDate = (new System.DateTime(dtmCUSTFPAYDATE.Year, dtmCUSTFPAYDATE.Month, 1)).AddMonths(intRowCnt).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        strPayDate = (System.Convert.ToDateTime(this.txtCUSTFPAYDATE.Text)).AddMonths(intRowCnt - 1).ToString("yyyy/MM/dd");
                    }

                    DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                    dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                    dtrMLDCONTRACTCASHFLOW["PAYDATE"] = strPayDate;
                    dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                    dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL1.Text).ToString("#,##0");
                    dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX1.Text).ToString("#,##0");
                    dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                }
            }

            //第二段期付款
            this.txtRSTARTPAY2.Text = dtbMLDCONTRACTINST.Rows[1][2].ToString();
            this.txtRENDPAY2.Text = dtbMLDCONTRACTINST.Rows[1][3].ToString();
            if (this.txtRSTARTPAY2.Text.Trim() != "")
            {
                this.txtRPRINCIPAL2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][4]).ToString("#,##0");
                this.txtRPRINCIPALTAX2.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[1][5]).ToString("#,##0");
                this.hdnFinalLevel.Value = this.txtRENDPAY2.Text;
            }

            if (!String.IsNullOrEmpty(this.txtRSTARTPAY2.Text))
            {
                for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY2.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY2.Text); intRowCnt++)
                {
                    if (bolMonEndDay)
                    {
                        strPayDate = (new System.DateTime(dtmCUSTFPAYDATE.Year, dtmCUSTFPAYDATE.Month, 1)).AddMonths(intRowCnt).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        strPayDate = (System.Convert.ToDateTime(this.txtCUSTFPAYDATE.Text)).AddMonths(intRowCnt - 1).ToString("yyyy/MM/dd");
                    }

                    DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                    dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                    dtrMLDCONTRACTCASHFLOW["PAYDATE"] = strPayDate;
                    dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                    dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL2.Text).ToString("#,##0");
                    dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX2.Text).ToString("#,##0");
                    dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                }
            }

            //第三段期付款
            this.txtRSTARTPAY3.Text = dtbMLDCONTRACTINST.Rows[2][2].ToString();
            this.txtRENDPAY3.Text = dtbMLDCONTRACTINST.Rows[2][3].ToString();
            if (this.txtRSTARTPAY3.Text.Trim() != "")
            {
                this.txtRPRINCIPAL3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][4]).ToString("#,##0");
                this.txtRPRINCIPALTAX3.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[2][5]).ToString("#,##0");
                this.hdnFinalLevel.Value = this.txtRENDPAY3.Text;
            }

            if (!String.IsNullOrEmpty(this.txtRSTARTPAY3.Text))
            {
                for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY3.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY3.Text); intRowCnt++)
                {
                    if (bolMonEndDay)
                    {
                        strPayDate = (new System.DateTime(dtmCUSTFPAYDATE.Year, dtmCUSTFPAYDATE.Month, 1)).AddMonths(intRowCnt).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        strPayDate = (System.Convert.ToDateTime(this.txtCUSTFPAYDATE.Text)).AddMonths(intRowCnt - 1).ToString("yyyy/MM/dd");
                    }

                    DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                    dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                    dtrMLDCONTRACTCASHFLOW["PAYDATE"] = strPayDate;
                    dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                    dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL3.Text).ToString("#,##0");
                    dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX3.Text).ToString("#,##0");
                    dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                }
            }

            //第四段期付款
            this.txtRSTARTPAY4.Text = dtbMLDCONTRACTINST.Rows[3][2].ToString();
            this.txtRENDPAY4.Text = dtbMLDCONTRACTINST.Rows[3][3].ToString();
            if (this.txtRSTARTPAY4.Text.Trim() != "")
            {
                this.txtRPRINCIPAL4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][4]).ToString("#,##0");
                this.txtRPRINCIPALTAX4.Text = System.Convert.ToDecimal(dtbMLDCONTRACTINST.Rows[3][5]).ToString("#,##0");
                this.hdnFinalLevel.Value = this.txtRENDPAY4.Text;
            }

            if (!String.IsNullOrEmpty(this.txtRSTARTPAY4.Text))
            {
                for (int intRowCnt = System.Convert.ToInt32(this.txtRSTARTPAY4.Text); intRowCnt <= System.Convert.ToInt32(this.txtRENDPAY4.Text); intRowCnt++)
                {
                    if (bolMonEndDay)
                    {
                        strPayDate = (new System.DateTime(dtmCUSTFPAYDATE.Year, dtmCUSTFPAYDATE.Month, 1)).AddMonths(intRowCnt).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        strPayDate = (System.Convert.ToDateTime(this.txtCUSTFPAYDATE.Text)).AddMonths(intRowCnt - 1).ToString("yyyy/MM/dd");
                    }

                    DataRow dtrMLDCONTRACTCASHFLOW = dtbMLDCONTRACTCASHFLOW.NewRow();
                    dtrMLDCONTRACTCASHFLOW["CNTRNO"] = "";
                    dtrMLDCONTRACTCASHFLOW["PAYDATE"] = strPayDate;
                    dtrMLDCONTRACTCASHFLOW["ISSUE"] = intRowCnt;
                    dtrMLDCONTRACTCASHFLOW["RENT"] = System.Convert.ToDecimal(txtRPRINCIPAL4.Text).ToString("#,##0");
                    dtrMLDCONTRACTCASHFLOW["RENTTAX"] = System.Convert.ToDecimal(txtRPRINCIPALTAX4.Text).ToString("#,##0");
                    dtbMLDCONTRACTCASHFLOW.Rows.Add(dtrMLDCONTRACTCASHFLOW);
                }
            }

            //幾月一繳
            int intPAYMONTH = Convert.ToInt32(txtPAYMONTH.Text);
            if (intPAYMONTH > 1)
            {
                int Mon = 1;
                string strReSetPayDate = "";
                foreach (DataRow row in dtbMLDCONTRACTCASHFLOW.Rows)
                {
                    if (Mon == 1)
                    {
                        strReSetPayDate = row["PAYDATE"].ToString();
                    }
                    if (intPAYMONTH - Mon >= 0)
                    {
                        row["PAYDATE"] = strReSetPayDate;
                    }
                    if (intPAYMONTH - Mon == 0)
                    {
                        Mon = 1;
                    }
                    else
                    {
                        Mon += 1;
                    }
                }
            }

            this.hdnTTLRent.Value = decTTLRent.ToString("##,##0");
            ViewState["MLDCONTRACTINST"] = dtbMLDCONTRACTINST;
            ViewState["MLDCONTRACTCASHFLOW"] = dtbMLDCONTRACTCASHFLOW;

        }
    }

    private void GetMLDCONTRACTBANKEXPANDBind(DataTable dtbMLDCONTRACTBANKEXPAND)
    {
        if (dtbMLDCONTRACTBANKEXPAND.Rows.Count > 0)
        {
            if (ViewState["dtbMLDCONTRACTBANKEXPAND"] == null)
            {
                //rptPREINVOICEInit();
                this.rptData.DataSource = dtbMLDCONTRACTBANKEXPAND;
                this.rptData.DataBind();

                ViewState["MLMPREINVOICE"] = dtbMLDCONTRACTBANKEXPAND;

            }
        }
    }

    private void GetCntrNoBind(DataTable dtbData)
    {
        if (dtbData.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, dtbData, NVC_MLMCONTRACT_Data);
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

            //綁定合約基本
            stbStoreProcedure.Append("SP_ML4001_Q02" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND MLMCONTRACT.CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //撥款案件租賃分期明細檔MLDCONTRACTINST
            stbStoreProcedure.Append("SP_ML4001_Q04" + GSTR_RowDelimitChar);
            stbQueryCondition.Append(" AND CNTRNO = ''''" + strCntrNo + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            if (this.hdnBANKEXPAND.Value.Trim() != "")
            {
                //銀行件展期資料[2]
                stbStoreProcedure.Append("SP_ML4014_Q02" + GSTR_RowDelimitChar);
                stbQueryCondition.Append(strCntrNo + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
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
        DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];
        rptData.DataSource = dtbMLDCONTRACTCASHFLOW;
        rptData.DataBind();

        this.btnExtInvo.Attributes.Remove("display:none;");
        this.btnExtInvo.Attributes.Add("style", "display:;");

        //this.btnUS.Attributes.Remove("display:;");
        //this.btnUS.Attributes.Add("style", "display:none;");
        //this.btnUS.Enabled = false;
    }

    /// <summary>
    /// btnExtInvo_Click 
    /// </summary>
    protected void btnExtInvo_Click(object sender, EventArgs e)
    {
        StringBuilder stbSaveFields = new StringBuilder();

        DataTable dtbMLDCONTRACTCASHFLOW = (DataTable)ViewState["MLDCONTRACTCASHFLOW"];

        getMLMPREINVOICEColInf(ref stbSaveFields, dtbMLDCONTRACTCASHFLOW);

        try
        {
            //stbSaveFields = stbSaveFields.Replace("'", "’");
            //stbSaveFields = stbSaveFields.Replace("\"", "”");
            //stbSaveFields = stbSaveFields.Replace("--", "－－");
            string strPreProcBR = stbSaveFields.ToString().Replace("\r\n", "<BR>");
            //ReturnObject<object> objReturnObject = SaveMLMPREINVOICESummary(stbSaveFields.ToString());
            ReturnObject<object> objReturnObject = SaveMLDCONTRACTBANKEXPAND(strPreProcBR);
            if (objReturnObject.ReturnSuccess)
            {
                //Alert(Resources.HeRun.H001);
                Alert("處理成功！");
                //RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
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

    #region 呼叫後端元件

    /// <summary>
    /// getMLMPREINVOICEColInf-預開發票資料檔
    /// </summary>
    /// <param name="stbSaveFields">StringBuilder</param>
    private void getMLMPREINVOICEColInf(ref StringBuilder stbSaveFields, DataTable dtbPREINVOICE)
    {
        for (int intRowCnt = 0; intRowCnt < dtbPREINVOICE.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4014_I01" + GSTR_ColDelimitChar);

            stbSaveFields.Append(this.txtCNTRNO.Text.Trim() + GSTR_TabDelimitChar);            
            stbSaveFields.Append(dtbTempRow["ISSUE"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PAYDATE"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENT"].ToString().Trim().Replace(",", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["RENTTAX"].ToString().Trim().Replace(",", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);            
        }
    }

    /// <summary>
    /// SaveMLDCONTRACTBANKEXPAND 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLDCONTRACTBANKEXPAND(string strProcData)
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

    #endregion
}