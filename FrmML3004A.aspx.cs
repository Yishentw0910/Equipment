/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3004																					
* 程式功能  : 撥款確認(財務)																			
* 程式作者 	:																			
* 完成時間 	:
* 修改事項 	: 
Modify 20120601 By SS Gordon. Reason: 新增案件退回按鈕.
Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
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

public partial class FrmML3004A : Itg.Community.PageBase
{
    //Modify 20121210 By SS Steven. Reason: 「關係人檢核」按鈕改成「關係人檢核列印」，並且直接列印出來.
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];

  private NameValueCollection NVC_MLMCONTRACT_Data
  {
    get
    {
      NameValueCollection MLMCONTRACT_Data = new NameValueCollection();
      MLMCONTRACT_Data.Add("txtCNTRNO", "CNTRNO");
      MLMCONTRACT_Data.Add("txtCASEID", "CASEID");
      MLMCONTRACT_Data.Add("txtSYSDT", "A_SYSDT");

      MLMCONTRACT_Data.Add("txtRRFEE", "FEE");
      MLMCONTRACT_Data.Add("txtRRTRANSCOST", "INVOICEAMOUNT");
      MLMCONTRACT_Data.Add("txtRRFIRSTPAY", "FIRSTPAY");

      MLMCONTRACT_Data.Add("txtRRPERBOND", "PERBOND");
      MLMCONTRACT_Data.Add("txtRRPURCHASEMARGIN", "PURCHASEMARGIN");

      MLMCONTRACT_Data.Add("txtPERBONDUSED", "PERBONDUSED");
      MLMCONTRACT_Data.Add("txtPURCHASEUSED", "PURCHASEUSED");
      MLMCONTRACT_Data.Add("txtPERBONDNOTE", "PERBONDNOTE");
      MLMCONTRACT_Data.Add("txtPURCHASENOTE", "PURCHASENOTE");
      MLMCONTRACT_Data.Add("txtFIRSTPAYUSED", "FIRSTPAYUSED");
      MLMCONTRACT_Data.Add("txtFIRSTPAYNOTE", "FIRSTPAYNOTE");
      MLMCONTRACT_Data.Add("txtPRENTSTDT", "PRENTSTDT");
      MLMCONTRACT_Data.Add("txtSALESPAY", "SALESPAY");

      MLMCONTRACT_Data.Add("txtDISCOUNTTOTAL", "DISCOUNTTOTAL");
      MLMCONTRACT_Data.Add("txtDISCOUNTTAX", "DISCOUNTTAX");
      MLMCONTRACT_Data.Add("txtACTUALLYAMOUNT", "ACTUALLYAMOUNT");
      MLMCONTRACT_Data.Add("txtPAYDATE", "PAYDATE");
      MLMCONTRACT_Data.Add("txtCUSTFPAYDATE", "CUSTFPAYDATE");

      //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
      MLMCONTRACT_Data.Add("txtFEEAMT", "PREPAYFEEAMT");
      MLMCONTRACT_Data.Add("txtPREPAYWOFFAMT", "PREPAYWOFFAMT");

      return MLMCONTRACT_Data;
    }
  }
  private NameValueCollection NVC_MLDCONTRACTAR_Data
  {
    get
    {
      NameValueCollection MLDCONTRACTAR_Data = new NameValueCollection();
      MLDCONTRACTAR_Data.Add("txtBILLNOTECUSTID", "BILLNOTECUSTID");
      MLDCONTRACTAR_Data.Add("txtBILLNOTECUST", "BILLNOTECUST");
      MLDCONTRACTAR_Data.Add("txtDEPOSITBANKS", "DEPOSITBANKS");

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
    if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款確認(財務)";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3004A";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3004A";
    //========================             
    if (!Page.IsPostBack)
    {
      string LSTR_CUSTID = Request.QueryString["custid"].ToString();
      string LSTR_CASEID = Request.QueryString["caseid"].ToString();
      string LSTR_CNTRNO = Request.QueryString["cntrno"].ToString();
      PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);
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
          //標的物
          GetMLDCASETARGETBind(LDST_Data.Tables[0]);
          //AR
          GetMLDCONTRACTARBind(LDST_Data.Tables[1]);
          //承做內容
          GetMLMCONTRACTBind(LDST_Data.Tables[2]);
          //MLDCONTRACTINV
          GetMLDCONTRACTINVBind(LDST_Data.Tables[3]);
          //MLDCONTRACTINVD
          GetMLDCONTRACTINVDBind(LDST_Data.Tables[4]);

          //20161125 ADD BY SS ADAM REASON.增加預撥沖銷
          GetMLDASSPAYMFBind(LDST_Data.Tables[5]);
          GetMLDFEEINCOME1Bind(LDST_Data.Tables[6]);
          GetMLDFEEINCOME2Bind(LDST_Data.Tables[7]);
          GetMLDPREPAYWOFFBind(LDST_Data.Tables[8]);
        }
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }
  }
  private void GetMLMCONTRACTBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLMCONTRACT_Data);
    }
  }
  private void GetMLDCONTRACTINVDBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      this.rptMLDCONTRACTINVD.DataSource = LOBJ_Data;
      this.rptMLDCONTRACTINVD.DataBind();
    }
  }
  private void GetMLDCONTRACTINVBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      this.rptMLDCONTRACTINV.DataSource = LOBJ_Data;
      this.rptMLDCONTRACTINV.DataBind();
    }
  }
  private void GetMLDCONTRACTARBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      Itg.Community.Util.SetValue(this.Page, LOBJ_Data, NVC_MLDCONTRACTAR_Data);
    }
  }
  private void GetMLDCASETARGETBind(DataTable LOBJ_Data)
  {

    if (LOBJ_Data.Rows.Count < 1)
    {
      this.chkAr1.Checked = true;
      this.chkAr2.Checked = true;
    }
    else
    {
      this.chkAr1.Checked = false;
      this.chkAr2.Checked = false;
      MLDCASETARGETBind(LOBJ_Data);
    }

  }
  private void MLDCASETARGETBind(DataTable LOBJ_Data)
  {
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

      //MLDCASETARGET標的物
      LSTR_StoreProcedure.Append("SP_ML3001_Q06" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //綁定AR信息
      LSTR_StoreProcedure.Append("SP_ML3001_Q07" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //承做內容
      LSTR_StoreProcedure.Append("SP_ML3001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //MLDCONTRACTINV撥款案件發票明細檔
      LSTR_StoreProcedure.Append("SP_ML3001_Q09" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //MLDCONTRACTINVD撥款案件發票明細檔
      LSTR_StoreProcedure.Append("SP_ML3001_Q10" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND A.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
  protected void btnSubmit_Click(object sender, EventArgs e)
  {
    MLMCASESave("9");
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
      LSTR_Data.Append("SP_ML3002_U02" + GSTR_ColDelimitChar);
      LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
      LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
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
      LSTR_Data.Append("ML3004A" + GSTR_TabDelimitChar);
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
    string LSTR_CNTRNOID = this.txtCNTRNO.Text;
    LSTR_Data.Append("SP_ML3002_U02" + GSTR_ColDelimitChar);
    LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================            
    string LSTR_CASEID = this.txtCASEID.Text;
    LSTR_Data.Append("SP_ML3004_I03" + GSTR_ColDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_CNTRNOID + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID);
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
    LSTR_Data = LSTR_Data.Replace("'", "’");
    LSTR_Data = LSTR_Data.Replace("\"", "”");
    LSTR_Data = LSTR_Data.Replace("--", "－－");
    //========================================================================= 
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = UpdateContractInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        RegisterScript("alert('核准完成！');window.close();");
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
              RegisterScript("cmdPRINT_Click('" + this.txtCNTRNO.Text + "',"
                                          + "'" + this.txtCASEID.Text + "',"
                                          + "'" + GSTR_U_USERID + "',"
                                          + "'" + GSTR_DEPTNAME + "',"
                                          + "'" + this.hdnPRINTKEY.Text + "',"
                                          + "'" + this.hdnINDT.Text + "',"
                                          + "'" + this.hdnTRADEDT.Text + "',"
                                          + "'" + this.hdnCREDITDT.Text + "'" 
                                          + ");");

              //CNTRNO, CASEID, USERNM, DEPTNM, PRINTKEY, CHKDATE1,,CHKDATE2,CHKDATE3
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
