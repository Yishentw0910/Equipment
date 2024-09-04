/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML1003A																					
* 程式功能  : 進件核准查詢																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120224 By SS Gordon. Reason: 新增NPV利率成本與保證人職業.
Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」
Modify 20120601 By SS Gordon. Reason: 保證人擴欄位：生日、性別、與申戶關係、戶籍地址、通訊地址、聯絡電話、職業、任職公司
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20120601 By SS Gordon. Reason: 案件退回改為案件撤件.
Modify 20120604 By SS Gordon. Reason: AR新增履約保證金
Modify 20120709 By SS Gordon. Reason: 新增撤件寄MAIL通知
Modify 20120717 By SS Gordon. Reason: 新增承作方式.
Modify 20120717 By SS Gordon. Reason: 新增銀行別.
Modify 20120717 By SS Gordon. Reason: 修改「分期」的「承作型態二」的顯示，若為「銀行件」則為「原物料分期」和「設備動保」.
Modify 20120717 By SS Gordon. Reason: 新增銀行件無標的物的判斷.
Modify 20120820 By SS Gordon. Reason: 將撤件時顯示文字「退回完成」改成「撤件完成」
Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"3A"改成"3X"
Modify 20130104 By SS Maureen. Reason: 在ML1003核准時複製一份不動產資料至MLDIMMOVABLEDF不動產資料明細檔
Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
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
using Itg.Community;
using System.Text;
using ITG.Community;
using System.Collections.Specialized;
using System.Globalization;

public partial class FrmML1003A : PageBase
{
    //案件
    private NameValueCollection NVC_MLMCASE_Data
    {
        get
        {
            NameValueCollection MLMCASE_Data = new NameValueCollection();
            MLMCASE_Data.Add("txtCASEID", "CASEID");
            MLMCASE_Data.Add("txtSYSDT", "CASEINDATE");
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
            MLMCASE_Data.Add("txtOTHERCOND", "OTHERCOND");
            MLMCASE_Data.Add("drpDEFECTIVE", "DEFECTIVE");
            //john 2011/11/03 增加欄位
            MLMCASE_Data.Add("drpPRINTSTORE", "PRINTSTORE");
            //Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
            MLMCASE_Data.Add("txtADVANCESINTEREST", "ADVANCESINTEREST");
            //20160323 ADD BY SS ADAM REASON.新增案件產品別顯示，行業別顯示
            MLMCASE_Data.Add("drpPRODCD", "PRODCD");

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
            MLDCASEARDATA_Data.Add("txtPERCENTAGE", "PERCENTAGE");
            MLDCASEARDATA_Data.Add("txtACCOUNTSTERM", "ACCOUNTSTERM");
            MLDCASEARDATA_Data.Add("drpPAYTIMEA", "PAYTIME");
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
            MLDCASEINST_Data.Add("txtPERBOND", "PERBOND");
            MLDCASEINST_Data.Add("txtPURCHASEMARGIN", "PURCHASEMARGIN");
            MLDCASEINST_Data.Add("txtRESIDUALS", "RESIDUALS");
            MLDCASEINST_Data.Add("txtCONTRACTMONTH", "CONTRACTMONTH");
            MLDCASEINST_Data.Add("txtPAYMONTH", "PAYMONTH");
            MLDCASEINST_Data.Add("drpPAYTIMET", "PAYTIME");
            return MLDCASEINST_Data;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetUsrAndFuncInfo();
            //===== for 測試Menu =====
            if (GSTR_PROGNM == "") GSTR_PROGNM = "進件查詢核准";
            if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML1003A";
            if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML1003A";
            //========================             
            if (!IsPostBack)
            {
                //綁定畫面下拉
                FormDrpBind();
                //取得客戶資料
                PageDataBind();
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window_onload();showTag();", true);
    }
    private void PageDataBind()
    {
        string LSTR_CUSTID = Request.QueryString["custid"].ToString();
        string LSTR_CASEID = Request.QueryString["caseid"].ToString();
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
                    if (LDST_Data.Tables[2].Rows[0]["FILENAME"].ToString() != "")
                    {
                        //案件下載
                        this.lkbOpenFile.Text = LDST_Data.Tables[2].Rows[0]["FILENAME"].ToString().Trim();
                        this.lkbOpenFile.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "');return false;";
                        this.btnOnload.OnClientClick = "OpenAttach('" + System.Web.Configuration.WebConfigurationManager.AppSettings["UploadURL"] + LDST_Data.Tables[2].Rows[0]["FILEID"].ToString().Trim() + "');return false;";
                    }

                    //Modify 20150126 By SS ChrisFu. Reason:新增專案別顯示
                    drpPROJCD.SelectedValue = LDST_Data.Tables[2].Rows[0]["PROJCD"].ToString().Trim();

                    //Modify 20150205 By SS ChrisFu. Reason:新增「建議墊款息」顯示
                    txtADVANCESINTEREST.Text = LDST_Data.Tables[2].Rows[0]["ADVANCESINTEREST"].ToString().Trim();

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

                    SetMAINTYPERDO(this.drpMAINTYPE.SelectedValue);
                    this.txtBUSINESS.Width = 500;

                    //20231130ADD選定專案
                    btnPROJECT_Click(null, null);
                    drpPROJECT.SelectedValue = LDST_Data.Tables[14].Rows[0]["PROJID"].ToString().Trim();
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
                    DropDownList LOBJ_GRTCODE = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTCODE");
                    DropDownList LOBJ_GRTNAME = (DropDownList)rptMLDCASEGUARANTEE.Items[i].FindControl("drpGRTNAME");
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
            LOBJ_Data.Rows.RemoveAt(LOBJ_Data.Rows.Count - 1);
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
    /// <summary>
    /// 綁定下拉資料
    /// </summary>
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

                this.drpCOMPTYPE.DataSource = LDST_Data.Tables[10].DefaultView;
                this.drpCOMPTYPE.DataBind();

                this.drpORGATYPE.DataSource = LDST_Data.Tables[11].DefaultView;
                this.drpORGATYPE.DataBind();

                this.drpLISTED.DataSource = LDST_Data.Tables[12].DefaultView;
                this.drpLISTED.DataBind();

                //Modify 20120717 By SS Gordon. Reason: 新增承作方式.
                this.drpSOURCETYPE.DataSource = LDST_Data.Tables[13].DefaultView;
                this.drpSOURCETYPE.DataBind();
                //Modify 20120717 By SS Gordon. Reason: 新增銀行別.
                this.drpBANKCD.DataSource = LDST_Data.Tables[14].DefaultView;
                this.drpBANKCD.DataBind();
                this.drpBANKCD.Items.Insert(0, new ListItem("", ""));

                //20160323 ADD BY SS ADAM REASON.增加案件產品別
                this.drpPRODCD.DataSource = LDST_Data.Tables[15].DefaultView;
                this.drpPRODCD.DataBind();

                string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                drpSUBTYPEBindbyID(LSTR_MAINTYPEID);

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
            this.chkAr.Checked = true;
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
            //LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            //LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
            //20160323 ADD BY SS ADAM REASON.新增案件產品別
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
            LVAR_Parameter[0] = "dbo.SP_ML0003_Q03";
            LVAR_Parameter[1] = "'" + this.txtCUSTID.Text + "',";
            LVAR_Parameter[1] += "'" + this.drpMAINTYPE.SelectedValue + "',";
            LVAR_Parameter[1] += "'" + this.drpSUBTYPE.SelectedValue + "',";
            LVAR_Parameter[1] += "'" + this.drpDEFECTIVE.SelectedValue + "',";
            if (this.drpMAINTYPE.SelectedValue == "04")
            {
                LVAR_Parameter[1] += "'" + Itg.Community.Util.NumberToDb(this.txtAPLIMIT.Text) + "',";
            }
            else
            {
                LVAR_Parameter[1] += "'" + Itg.Community.Util.NumberToDb(this.txtTRANSCOST.Text) + "',";
            }
            LVAR_Parameter[1] += "'" + this.txtSYSDT.Text + "'";
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
    protected void btnSub_Click(object sender, EventArgs e)
    {
        //john 2011/11/03 修正一律傳3
        //string LSTR_SaveType = GetSaveType();
        string LSTR_SaveType = "3";
        if (LSTR_SaveType == "")
        {
            Alert("無法取得核決權限資料！");
        }
        else
        {
            MLMCASESave(LSTR_SaveType);
        }
    }
    protected void btnRej_Click(object sender, EventArgs e)
    {
        //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"3A"改成"3X"
        //MLMCASESave("3A");
        MLMCASESave("3X");
    }

    //Modify 20120601 By SS Gordon. Reason: 新增案件退回.
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
        LSTR_Data.Append("ML1003A" + GSTR_TabDelimitChar);
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
        //john 2011/11/03 增加兩新欄位 新的徵信設定
        LSTR_Data.Append("SP_ML1003_U01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim());
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        //Modify 20120709 By SS Gordon. Reason: 新增撤件寄MAIL通知
        //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"3A"改成"3X"
        //if (LSTR_SaveType == "3A")
        if (LSTR_SaveType == "3X")
        {
            LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append("ML1003X" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        //==========================================================================
        //Modify 20130104 By SS Maureen. Reason: 在ML1003核准時複製一份不動產資料至MLDIMMOVABLEDF不動產資料明細檔
        LSTR_Data.Append("SP_ML1003_U02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.txtCASEID.Text.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
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
                this.hidShowTag.Value = "fraTab11Caption";
                //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"3A"改成"3X"
                //if (LSTR_SaveType == "3A")
                if (LSTR_SaveType == "3X")
                {
                    //Modify 20120820 By SS Gordon. Reason: 將撤件時顯示文字「退回完成」改成「撤件完成」
                    //RegisterScript("alert('退回完成！');window.close();");
                    RegisterScript("alert('撤件完成！');window.close();");
                }
                else
                {
                    //ADD 20231130 營業單位自審判斷
                    try
                    {
                        ReturnObject<DataSet> LOBJ_ReturnObject1 = SELFEXAM();
                        if (LOBJ_ReturnObject1.ReturnSuccess)
                        {
                            DataSet LDST_Data = LOBJ_ReturnObject1.ReturnData;
                            GetSELFEXAMBind(LDST_Data.Tables[0]);
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
                    if (this.hidORGDEPID.Value== "AI00")
                    {
                    RegisterScript("alert('核准完成！此案件為客服徵審件 ');window.close();");
                    }
                    else
                    {
                        RegisterScript("alert('核准完成！此案件為營業單位自審件 ');window.close();");
                    }
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

    private ReturnObject<DataSet> SELFEXAM()
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
            LSTR_StoreProcedure.Append("SP_ML1003_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(this.txtCASEID.Text.Trim() + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
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
    private void GetSELFEXAMBind(DataTable LOBJ_Data) 
    {
        this.hidORGDEPID.Value = LOBJ_Data.Rows[0][0].ToString(); ;
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
}
