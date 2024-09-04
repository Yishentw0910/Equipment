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
public partial class FrmML5003A : PageBase
{
  public string ASTR_SysDate = "";

  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "客服回件作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5003A";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5003A";
    ASTR_SysDate = DateTime.Now.ToString("yyyy/MM/dd");
    //========================             
    if (!Page.IsPostBack)
    {
      string LSTR_CUSTID = Request.QueryString["custid"].ToString();
      string LSTR_CASEID = Request.QueryString["caseid"].ToString();
      string LSTR_CNTRNO = Request.QueryString["cntrno"].ToString();
      PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);
      for (int i = 0; i < rptMLDCASEAPPENDDOC.Items.Count; i++)
      {
        ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM1")).Attributes.Add("disabled", "true");
        if (this.hidRETUNCONFIRM2.Value == "1")
        {
          ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Attributes.Add("disabled", "true");
          ((TextBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("txtNOTE")).Attributes.Add("disabled", "true");
        }
      }

      for (int i = 0; i < rptMLDCASEAPPENDDOC2.Items.Count; i++)
      {
          ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM1")).Attributes.Add("disabled", "true");
          if (this.hidRETUNCONFIRM2.Value == "1")
          {
              ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Attributes.Add("disabled", "true");
              ((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Attributes.Add("disabled", "true");
          }
      }

      for (int i = 0; i < rptMLDCASEAPPENDDOC3.Items.Count; i++)
      {
          ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM1")).Attributes.Add("disabled", "true");
          if (this.hidRETUNCONFIRM2.Value == "1")
          {
              ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Attributes.Add("disabled", "true");
              ((TextBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("txtNOTE")).Attributes.Add("disabled", "true");
          }
      }

      if (this.hidRETUNCONFIRM2.Value == "1")
      {
        this.btnReject.Enabled = false;
        this.btnSubmit.Enabled = false;
        RegisterScript("SetDisabled('div_Info', '','');");
      }
    }
    txtMEMO.Text = hdMEMO.Value;
    if (txtMEMO.Text != "") txtMEMO.Style.Add("display", "block");
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
          //征審資料
          GetMLDCASEAPPENDDOCBind(LDST_Data.Tables[0]);
          GetMLDCASEAPPENDDOC2Bind(LDST_Data.Tables[1]);    //Modify 20140225 By SS Eric Reason:擔保文件GRID
          GetMLDCASEAPPENDDOC3Bind(LDST_Data.Tables[2]);    //Modify 20140225 By SS Eric Reason:客戶暨徵信資料GRID
          //決策人
          //GetPoliceManBind(LDST_Data.Tables[1]);
          GetPoliceManBind(LDST_Data.Tables[3]);
          //案件
          //GetMLMCONTRACTBind(LDST_Data.Tables[2]);
          GetMLMCONTRACTBind(LDST_Data.Tables[4]);
          //Modify 20140225 By SS Eric Reason:新增退件日期資料
          GetMLMBACKDOCDATEBind(LDST_Data.Tables[5]);
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
      this.txtCNTRNO.Text = LOBJ_Data.Rows[0]["CNTRNO"].ToString();
      this.txtDEPT.Text = LOBJ_Data.Rows[0]["DEPT"].ToString();
      this.txtAgency.Text = LOBJ_Data.Rows[0]["EMPLNM"].ToString();
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
      this.txtBUSINESSADDR.Text = LOBJ_Data.Rows[0]["BUSINESSADDRESS"].ToString();

      this.txtCUSTNAME.Text = LOBJ_Data.Rows[0]["CUSTNAME"].ToString();
      this.txtMAINTYPENM.Text = LOBJ_Data.Rows[0]["MAINTYPENM"].ToString();
      this.txtMPAY.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["MPAY"].ToString());

      this.txtRETUNCONFIRMDATE2.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RETUNCONFIRMDATE2"].ToString());
      this.txtEDATE.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["EDATE"].ToString());
                                  
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
  private void GetPoliceManBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 0)
    {
      this.txtCONTACTNAME.Text = LOBJ_Data.Rows[0]["CONTACTNAME"].ToString();
      this.txtDEPTNAME.Text = LOBJ_Data.Rows[0]["DEPTNAME"].ToString();
      this.txtCONTACTTITLE.Text = LOBJ_Data.Rows[0]["CONTACTTITLE"].ToString();
      this.txtCUSTTELCODE.Text = LOBJ_Data.Rows[0]["CONTACTTELCODE"].ToString();
      this.txtCONTACTTEL.Text = LOBJ_Data.Rows[0]["CONTACTTEL"].ToString();
      this.txtCONTACTMPHONE.Text = LOBJ_Data.Rows[0]["CONTACTMPHONE"].ToString();
      this.txtCUSTFAXCODE.Text = LOBJ_Data.Rows[0]["CONTACTFAXCODE"].ToString();
      this.txtCONTACTFAX.Text = LOBJ_Data.Rows[0]["CONTACTFAX"].ToString();
      this.txtCONTACTEMAIL.Text = LOBJ_Data.Rows[0]["CONTACTEMAIL"].ToString();
    }
  }
  private void GetMLDCASEAPPENDDOCBind(DataTable LOBJ_Data)
  {
    if (LOBJ_Data.Rows.Count > 1)
    {
      rptMLDCASEAPPENDDOC.DataSource = LOBJ_Data;
      rptMLDCASEAPPENDDOC.DataBind();
      for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++)
      {
        if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
        {
          ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM1")).Checked = true;
          //((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
          ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
          ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
        }

		// 2012.06.01 Edit by Sean 修正客服已回件確認無顯示問題 
        if (LOBJ_Data.Rows[i]["DOCCONFIRM2"].ToString().Trim() == "1")
        {
          ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
		}
      }
    }
  }

  //Modify 20140225 By SS Eric Reason:加入擔保文件
  private void GetMLDCASEAPPENDDOC2Bind(DataTable LOBJ_Data)
  {
      if (LOBJ_Data.Rows.Count > 1)
      {
          rptMLDCASEAPPENDDOC2.DataSource = LOBJ_Data;
          rptMLDCASEAPPENDDOC2.DataBind();

          for (int i = 0; i < this.rptMLDCASEAPPENDDOC2.Items.Count; i++)
          {
              if (((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblDocName")).Text.Trim() == "保單")
              {
                  ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Visible = false;
                  ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM1")).Visible = false;
                  ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = "";
                  ((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Visible = false;
              }

              if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
              {
                  ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM1")).Checked = true;
                  //((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                  ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                  ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
              }

              // 2012.06.01 Edit by Sean 修正客服已回件確認無顯示問題
              if (LOBJ_Data.Rows[i]["DOCCONFIRM2"].ToString().Trim() == "1")
              {
                  ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
              }
          }
      }
  }

  //Modify 20140225 By SS Eric Reason:加入客戶暨徵信資料
  private void GetMLDCASEAPPENDDOC3Bind(DataTable LOBJ_Data)
  {
      if (LOBJ_Data.Rows.Count > 1)
      {
          rptMLDCASEAPPENDDOC3.DataSource = LOBJ_Data;
          rptMLDCASEAPPENDDOC3.DataBind();
          for (int i = 0; i < this.rptMLDCASEAPPENDDOC3.Items.Count; i++)
          {
              if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
              {
                  ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM1")).Checked = true;
                  //((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                  ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                  ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
              }

              // 2012.06.01 Edit by Sean 修正客服已回件確認無顯示問題
              if (LOBJ_Data.Rows[i]["DOCCONFIRM2"].ToString().Trim() == "1")
              {
                  ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
              }
          }
      }
  }

  //Modify 20140225 By SS Eric Reason:新增退件日期資料
  private void GetMLMBACKDOCDATEBind(DataTable LOBJ_Data)
  {
      rptMLMBACKDOCDATE.DataSource = LOBJ_Data;
      rptMLMBACKDOCDATE.DataBind();

      for (int i = 0; i < this.rptMLMBACKDOCDATE.Items.Count; i++)
      {
          if (LOBJ_Data.Rows[i]["BACKDOCDATE"].ToString().Trim() == "")
          {
              //沒有回退日期時,不可按內容BTN
              ((Button)rptMLMBACKDOCDATE.Items[i].FindControl("btnMEMO")).Enabled = false;
          }
      }
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
      string LSTR_RETUNID = Request.QueryString["retunid"].ToString();
      //相關文件
      //LSTR_StoreProcedure.Append("SP_ML5001_Q02" + GSTR_RowDelimitChar);
      //LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar + LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      //Modify 20140225 By SS Eric Reason:合約文件
      LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append("1" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //Modify 20140225 By SS Eric Reason:擔保文件
      LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append("2" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //Modify 20140225 By SS Eric Reason:客戶暨徵信資料
      LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
      LSTR_QueryCondition.Append("3" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //決策人
      LSTR_StoreProcedure.Append("SP_ML1002_Q03" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(" AND CONTACTTYPE=''''1'''' AND MLDCASECONTACT.CASEID=''''" + LSTR_CASEID + "'''' " + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      //合約
      LSTR_StoreProcedure.Append("SP_ML5001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(" AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "'''' " + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //Modify 20140225 By SS Eric Reason:新增退件日期資料
      LSTR_StoreProcedure.Append("SP_ML5001_Q06" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
	MLMCASESave("13");
  }
  private void MLMCASESave(string LSTR_CASESTATUS)
  {
    StringBuilder LSTR_Data = new StringBuilder();
    //MLMRETURNDOC
    LSTR_Data.Append("SP_ML5001_U01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
    if (LSTR_CASESTATUS == "13")
    {
      LSTR_Data.Append("1" + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    }
    else
    {
      LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
    }
    LSTR_Data.Append(LSTR_CASESTATUS + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================   
    //MLDRETURNDOCDETAIL   
	for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++)
    {
      LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
      LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim() + GSTR_TabDelimitChar);
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidRETUNDATE")).Value.Trim() + GSTR_TabDelimitChar);
      //if (LSTR_CASESTATUS == "13")
      //{
      //  LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
      //  LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
      //}
      //else
      //{
      //  if (((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM1")).Checked == true)
      //  {
      //    LSTR_Data.Append("1" + GSTR_TabDelimitChar);
      //    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
      //  }
      //  else
      //  {
      //    LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      //    LSTR_Data.Append("" + GSTR_TabDelimitChar);
      //  }
      //}
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);

      if (((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
      {
        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
      }
      else
      {
        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
      }
      LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT);
      LSTR_Data.Append(GSTR_ColDelimitChar);
      LSTR_Data.Append(GSTR_RowDelimitChar);
    }
    //Modify 20140225 By SS Eric Reason:擔保文件
    for (int i = 0; i < this.rptMLDCASEAPPENDDOC2.Items.Count; i++)
    {
        if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Visible == true)
        {
            LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDATE")).Value.Trim() + GSTR_TabDelimitChar);
            //if (LSTR_CASESTATUS == "13")
            //{
            //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
            //}
            //else
            //{
            //    if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM1")).Checked == true)
            //    {
            //        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            //    }
            //    else
            //    {
            //        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            //        LSTR_Data.Append("" + GSTR_TabDelimitChar);
            //    }
            //}
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
            if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
            {
                LSTR_Data.Append("1" + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append("2" + GSTR_TabDelimitChar);
                LSTR_Data.Append("" + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
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
            LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDATE")).Value.Trim() + GSTR_TabDelimitChar);

            //if (LSTR_CASESTATUS == "13")
            //{
            //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
            //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
            //}
            //else
            //{
            //    if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM1")).Checked == true)
            //    {
            //        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            //    }
            //    else
            //    {
            //        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            //        LSTR_Data.Append("" + GSTR_TabDelimitChar);
            //    }
            //}
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
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
    //Modify 20140225 By SS Eric Reason:客戶暨徵信資料
    for (int i = 0; i < this.rptMLDCASEAPPENDDOC3.Items.Count; i++)
    {
        LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidRETUNDATE")).Value.Trim() + GSTR_TabDelimitChar);
        //if (LSTR_CASESTATUS == "13")
        //{
        //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
        //    LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
        //}
        //else
        //{
        //    if (((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM1")).Checked == true)
        //    {
        //        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        //    }
        //    else
        //    {
        //        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        //        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        //    }
        //}
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDOCCONFIRM1")).Value.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDOCCONFIRMDATE1")).Value.Trim() + GSTR_TabDelimitChar);
        if (((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
        {
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
    }
    //Modify 20140225 By SS Eric Reason:退件日期資料
    LSTR_Data.Append("SP_ML5003_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(this.txtCNTRNO.Text + GSTR_TabDelimitChar);
    LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
    LSTR_Data.Append(ASTR_SysDate + GSTR_TabDelimitChar);
    if (LSTR_CASESTATUS == "13")
    {
        LSTR_Data.Append(this.hdMEMO.Value + GSTR_TabDelimitChar);
    }
    else
    {
        LSTR_Data.Append(Regex.Replace(this.hidCond.Value, "'", "’") + GSTR_TabDelimitChar);
    }
    LSTR_Data.Append(LSTR_CASESTATUS + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);

    //MLVERIFY
    LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
    LSTR_Data.Append(this.hidRETUNID.Value + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append(Regex.Replace(this.hidCond.Value, "'", "’") + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_CASESTATUS + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append("3");
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================
    LSTR_Data = LSTR_Data.Replace("'", "’");
    LSTR_Data = LSTR_Data.Replace("\"", "”");
    LSTR_Data = LSTR_Data.Replace("--", "－－");
    //=========================================================================
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = SaveInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        RegisterScript("alert('儲存完成！');window.close();");

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
  protected void btnReject_Click(object sender, EventArgs e)
  {
    MLMCASESave("14");
  }
}
