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
using ITG.Community;
using Comus;
using System.Text;
using System.Text.RegularExpressions;

public partial class FrmML5002A : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "財務回件作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5002A";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5002A";
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
          //案件
          GetMLMCONTRACTBind(LDST_Data.Tables[0]);
          //MLDCONTRACTINV
          GetMLDCONTRACTINVBind(LDST_Data.Tables[1]);
          //MLDCONTRACTINVD
          GetMLDCONTRACTINVDBind(LDST_Data.Tables[2]);
          ViewState["MLDCONTRACTINVD"] = LDST_Data.Tables[2];
        }
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }
  }
  private void GetMLDCONTRACTINVDBind(DataTable LOBJ_Data)
  {
    this.rptMLDCONTRACTINVD.DataSource = LOBJ_Data;
    this.rptMLDCONTRACTINVD.DataBind();

    double LDBL_TPAY = 0;
    double LDBL_TPAYMAX = 0;
    for (int i = 0; i < LOBJ_Data.Rows.Count; i++)
    {
      LDBL_TPAY += Convert.ToDouble(LOBJ_Data.Rows[i]["DISCOUNTAMOUNT"].ToString());
      LDBL_TPAYMAX += Convert.ToDouble(LOBJ_Data.Rows[i]["DISCOUNTTAX"].ToString());
    }
    this.txtTPAY.Text = Itg.Community.Util.NumberFormat(LDBL_TPAY.ToString());
    this.txtAPAY.Text = Itg.Community.Util.NumberFormat(LDBL_TPAYMAX.ToString());
    this.txtPAYALL.Text = Itg.Community.Util.NumberFormat((LDBL_TPAY + LDBL_TPAYMAX).ToString());
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
      //合約
      LSTR_StoreProcedure.Append("SP_ML5001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(" AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "'''' " + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      LSTR_StoreProcedure.Append("SP_ML3001_Q09" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      //MLDCONTRACTINVD撥款案件發票明細檔
      LSTR_StoreProcedure.Append("SP_ML3001_Q10" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("AND A.CNTRNO=''''" + LSTR_CONTID + "''''" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
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
  private void GetMLDCONTRACTINVBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      this.rptMLDCONTRACTINV.DataSource = LOBJ_Data;
      this.rptMLDCONTRACTINV.DataBind();
    }
  }
  private void GetMLMCONTRACTBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      this.txtCASEID.Text = LOBJ_Data.Rows[0]["CASEID"].ToString();
      this.txtCNTRNO.Text = LOBJ_Data.Rows[0]["CNTRNO"].ToString();
      this.txtSYSDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["VDATE"].ToString());
      
      this.txtMAINTYPENM.Text = LOBJ_Data.Rows[0]["MAINTYPENM"].ToString();
      this.txtPAYDATE.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["PAYCONFIRMDATE"].ToString());
      this.txtRENTSTDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RENTSTDT"].ToString());
      this.txtRENTENDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RENTENDT"].ToString());
      this.txtCONTRACTMONTH.Text = LOBJ_Data.Rows[0]["CONTRACTMONTH"].ToString();
      this.txtACTUALLYAMOUNT.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["ACTUALLYAMOUNT"].ToString());
      this.txtPERBOND.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["PERBOND"].ToString());
      this.txtPURCHASEMARGIN.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["PURCHASEMARGIN"].ToString());
      this.txtIRR.Text = LOBJ_Data.Rows[0]["IRR"].ToString();
      this.txtCUSTPAYTYPE.Text = LOBJ_Data.Rows[0]["CUSTPAYTYPE"].ToString();
      this.txtMAINTYPENM.Text = LOBJ_Data.Rows[0]["MAINTYPENM"].ToString();
      this.txtMPAY.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["MPAY"].ToString());

      this.hidRETUNID.Value = LOBJ_Data.Rows[0]["RETUNID"].ToString();
      this.hidINVCONFIRM.Value = LOBJ_Data.Rows[0]["INVCONFIRM"].ToString();
      this.hidINVCONFIRMDATE.Value = LOBJ_Data.Rows[0]["INVCONFIRMDATE"].ToString();
      this.hidINVDCONFIRM.Value = LOBJ_Data.Rows[0]["INVDCONFIRM"].ToString();
      this.hidINVDCONFIRMDATED.Value = LOBJ_Data.Rows[0]["INVDCONFIRMDATED"].ToString();
      this.hidRETUNCONFIRM1.Value = LOBJ_Data.Rows[0]["RETUNCONFIRM1"].ToString();
      this.hidRETUNCONFIRMDATE1.Value = LOBJ_Data.Rows[0]["RETUNCONFIRMDATE1"].ToString();
      this.hidRETUNCONFIRM2.Value = LOBJ_Data.Rows[0]["RETUNCONFIRM2"].ToString();
      this.hidRETUNCONFIRMDATE2.Value = LOBJ_Data.Rows[0]["RETUNCONFIRMDATE2"].ToString();
      this.hidRETUNCONFIRM3.Value = LOBJ_Data.Rows[0]["RETUNCONFIRM3"].ToString();
      this.hidRETUNCONFIRMDATE3.Value = LOBJ_Data.Rows[0]["RETUNCONFIRMDATE3"].ToString();
    }
  }
  protected void btnSubmit_Click(object sender, EventArgs e)
  {
    MLMCASESave();
  }
  private void MLMCASESave()
  {
    StringBuilder LSTR_Data = new StringBuilder();
    // 2011.10.20 EDD BY SEAN
    string LSTR_CNTRNO = this.txtCNTRNO.Text.Trim();
    //MLMRETURNDOC
    LSTR_Data.Append("SP_ML5001_U02" + GSTR_ColDelimitChar);
    LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
    LSTR_Data.Append("1" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("12" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================   
    //MLVERIFY
    LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
    LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("12" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append("3");
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //MLDCONTRACTINVD
    if (rptMLDCONTRACTINVD.Items.Count > 0)
    {
      DataTable LDAT_MLDCONTRACTINVD = (DataTable)ViewState["MLDCONTRACTINVD"];
      for (int i = 0; i < this.rptMLDCONTRACTINVD.Items.Count; i++)
      {
        LSTR_Data.Append("SP_ML3002_I07" + GSTR_ColDelimitChar);
	// 修改 2011.11.20 by Sean 應先取合約編號 
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
        LSTR_Data.Append(LDAT_MLDCONTRACTINVD.Rows[i][0].ToString() + GSTR_TabDelimitChar);
        LSTR_Data.Append(LDAT_MLDCONTRACTINVD.Rows[i][1].ToString() + GSTR_TabDelimitChar);
        //LSTR_Data.Append(LDAT_MLDCONTRACTINVD.Rows[i][2].ToString() + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTDATE")).Text) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text) + GSTR_TabDelimitChar);
        LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text) + GSTR_TabDelimitChar);
        double LDBL_Sum = Convert.ToDouble(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTAMOUNT")).Text) +
                          Convert.ToDouble(((TextBox)rptMLDCONTRACTINVD.Items[i].FindControl("txtDISCOUNTTAX")).Text);
        LSTR_Data.Append(LDBL_Sum.ToString() + GSTR_TabDelimitChar);
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
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = SaveInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        RegisterScript("alert('確認完成！');window.close();");
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
  private ReturnObject<object> SaveInfo(string LSTR_Data)
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
