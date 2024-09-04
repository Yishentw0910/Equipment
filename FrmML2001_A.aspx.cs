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

public partial class FrmML2001 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
      this.txtStartDate.Attributes.Add("onBlur", "setDate(this,'" + txtStartDate.ClientID.ToString().Trim() + "','" + txtEndDate.ClientID.ToString().Trim() + "','進件核准日迄','進件核准日起')");
      this.txtEndDate.Attributes.Add("onBlur", "setDate(this,'" + txtStartDate.ClientID.ToString().Trim() + "','" + txtEndDate.ClientID.ToString().Trim() + "','進件核准日迄','進件核准日起')");
      this.txtReviewDTS.Attributes.Add("onBlur", "setDate(this,'" + txtReviewDTS.ClientID.ToString().Trim() + "','" + txtReviewDTE.ClientID.ToString().Trim() + "','覆核核准日迄','覆核核准日起')");
      this.txtReviewDTE.Attributes.Add("onBlur", "setDate(this,'" + txtReviewDTS.ClientID.ToString().Trim() + "','" + txtReviewDTE.ClientID.ToString().Trim() + "','覆核核准日迄','覆核核准日起')");
    
      GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "徵信案件查詢";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML2001";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML2001";
    //========================             
    try
    {
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        drpDeptIDBind();
        //john 2011/11/04  增加徵審單位 並且做控制
        //GSTR_DEPTID = "AG00";
		//20140306 EDIT BY SEAN 徵審單位由信管部(AG00)-->信用審查部(AI00)
        drpCreditCheckingBind();
        //if (GSTR_DEPTID != "AG00")
        if (GSTR_DEPTID != "AI00")
        {
            this.drpCreditChecking.Enabled = false;
            this.drpCreditChecking.SelectedValue = GSTR_DEPTID;           
        }

      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
    txtCustName.Attributes.Add("Readonly", "True");
  }
  /// <summary>
  /// 綁定公司別下拉
  /// </summary>
  private void drpCompIDBind()
  {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    String LSTR_SYSID, LSTR_DataID;
    try
    {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
      LSTR_SYSID = System.Configuration.ConfigurationManager.AppSettings["SYSID"];
      LSTR_DataID = System.Configuration.ConfigurationManager.AppSettings["COMP_DATAID"];
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'" + LSTR_SYSID + "','" + LSTR_DataID + "','T'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.drpCompID.DataSource = LOBJ_Return.ReturnData;
        this.drpCompID.DataValueField = "MCODE";
        this.drpCompID.DataTextField = "MNAME1";
        this.drpCompID.DataBind();
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
  /// <summary>
  /// 綁定部門別下拉
  /// </summary>
  private void drpDeptIDBind()
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
      LVAR_Parameter[1] = "'LE','16','T'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.drpDeptID.DataSource = LOBJ_Return.ReturnData;
        this.drpDeptID.DataValueField = "MCODE";
        this.drpDeptID.DataTextField = "MNAME1";
        this.drpDeptID.DataBind();
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
  //john 2011/11/04  增加徵審單位
  private void drpCreditCheckingBind()
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
          LVAR_Parameter[1] = "'LE','80','T'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              //綁定數據
              this.drpCreditChecking.DataSource = LOBJ_Return.ReturnData;
              this.drpCreditChecking.DataValueField = "MCODE";
              this.drpCreditChecking.DataTextField = "MNAME1";
              this.drpCreditChecking.DataBind();
              this.drpCreditChecking.Items[0].Text = "全部";
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
  /// <summary>
  /// 組合畫面的查詢條件
  /// </summary>
  /// <returns></returns>
  private String GenerateQueryCon()
  {
    String LSTR_QueryCon;
    try
    {
      LSTR_QueryCon = "";
      //公司別
      if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
      }
      //部門別
      if (!String.IsNullOrEmpty(this.drpDeptID.SelectedValue.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.DEPTID = ''" + this.drpDeptID.SelectedValue.Trim() + "''";
      }
      //案件編號
      if (!String.IsNullOrEmpty(this.txtCaseID.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.CASEID = ''" + this.txtCaseID.Text.Trim() + "''";
      }
      //客戶統編
      if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.CUSTID = ''" + this.txtCustID.Text.Trim() + "''";
      }
      //客戶名稱
      if (!String.IsNullOrEmpty(this.txtCustName.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCUSTOMER.CUSTNAME LIKE ''%" + this.txtCustName.Text.Trim() + "%''";
      }
      //進件日起迄-起
      if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''3'' ORDER BY VERIFYID DESC ) >= ''" + Itg.Community.Util.GetADYear(this.txtStartDate.Text.Trim()) + "''";
      }
      //進件日起迄-迄
      if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''3'' ORDER BY VERIFYID DESC ) < ''" + Itg.Community.Util.AddDay(this.txtEndDate.Text.Trim(), 1) + "''";
      }
      //john 2011/11/04  增加徵審單位
      if (!String.IsNullOrEmpty(this.drpCreditChecking.SelectedValue.Trim()))
      {
          LSTR_QueryCon += " AND  [MLMCASE].[ORGDEPID]= ''" + this.drpCreditChecking.SelectedValue.Trim() + "''";
      }
      //流程關卡(本畫面對應關卡: 3=營業主管審核完成，案件核准，徵審待核准。)
      if (this.drpCreditType.SelectedValue == "Y" || this.drpCreditType.SelectedValue == "S" || this.drpCreditType.SelectedValue == "W")
      {
        //2013/08/23 Edit by SEAN 新增案件核准維護狀態
		LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''4'',''4A'',''4B'',''4C'',''4D'',''4E'',''5'') ";
		//LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''4'',''4A'',''4B'',''4C'',''5'') ";
      }
      else
      {
          //LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''4'',''4A'',''4B'',''4C'',''4D'',''4E'',''5'') ";
          LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''3'') ";
      }

      if(this.drpCreditType.SelectedValue == "S") //覆核完成
      {
          //LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''4'',''4A'',''4B'',''4C'',''5'') ";
          LSTR_QueryCon += " AND (SELECT TOP 1 REVIEWSTATUS FROM MLDCASECREDITREVIEW WHERE CASEID=[MLMCASE].[CASEID] ORDER BY SEQNO DESC)=''04'' ";
      }
      else if (this.drpCreditType.SelectedValue == "W") //待覆核
      {
          //LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN(''4'',''4A'',''4B'',''4C'',''5'') ";
          LSTR_QueryCon += " AND (SELECT TOP 1 REVIEWSTATUS FROM MLDCASECREDITREVIEW WHERE CASEID=[MLMCASE].[CASEID] ORDER BY SEQNO DESC)=''03'' ";
      }

      if (this.drpCreditType.SelectedValue == "T") //待放審
      {
          LSTR_QueryCon += " AND (SELECT COUNT(*) FROM MLDEXAMINE WITH(NOLOCK) WHERE CASEID=[MLMCASE].[CASEID] AND FINDT='')>0 ";
      }
      else if (this.drpCreditType.SelectedValue == "G") //審查會完成
      {
          LSTR_QueryCon += " AND (SELECT COUNT(*) FROM MLDEXAMINE WITH(NOLOCK) WHERE CASEID=[MLMCASE].[CASEID] AND FINDT<>'')>0 ";
      }
      
      //2013/10/28 Edit by SS Leo 新增覆核日期條件
      //覆核日期起迄
      if (!String.IsNullOrEmpty(this.txtReviewDTS.Text.Trim()))
      {
          LSTR_QueryCon += " AND  (SELECT TOP 1 CREDITFINDT FROM MLDCASECREDITREVIEW WHERE CASEID=[MLMCASE].[CASEID] ORDER BY CREDITFINDT DESC ) >= ''" + Itg.Community.Util.GetADYear(this.txtReviewDTS.Text.Trim()) + "''";
      }
      
      if (!String.IsNullOrEmpty(this.txtReviewDTE.Text.Trim()))
      {
          LSTR_QueryCon += " AND  (SELECT TOP 1 CREDITFINDT FROM MLDCASECREDITREVIEW WHERE CASEID=[MLMCASE].[CASEID] ORDER BY CREDITFINDT DESC ) < ''" + Itg.Community.Util.AddDay(this.txtReviewDTE.Text.Trim(), 1) + "''";
      }

        //20160930 ADD BY SS ADAM REASON.增加放審會
      if (!String.IsNullOrEmpty(this.txtEXAMDT1.Text.Trim()))
      {
          LSTR_QueryCon += " AND (SELECT TOP 1 SUGGESTDT FROM MLDEXAMINE WITH(NOLOCK) WHERE CASEID=[MLMCASE].[CASEID]) >= ''" + Itg.Community.Util.GetADYear(this.txtEXAMDT1.Text.Trim()) + "''";
      }

      if (!String.IsNullOrEmpty(this.txtEXAMDT2.Text.Trim()))
      {
          LSTR_QueryCon += " AND (SELECT TOP 1 SUGGESTDT FROM MLDEXAMINE WITH(NOLOCK) WHERE CASEID=[MLMCASE].[CASEID]) < ''" + Itg.Community.Util.GetADYear(this.txtEXAMDT2.Text.Trim()) + "''";
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }

  /// <summary>
  /// 綁定畫面Grid數據
  /// </summary>
  private void rptDataBind()
  {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    String LSTR_QueryCon;
    try
    {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //取得查詢條件
      LSTR_QueryCon = this.GenerateQueryCon();
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML1002_Q02";
      LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();

        for (int i = 0; i < rptData.Items.Count; i++)
        {
            string LSTR_CASESTATUS = ((HiddenField)rptData.Items[i].FindControl("hidCASESTATUS")).Value.ToString().Trim();
            if (LSTR_CASESTATUS == "3")
            {
            }
            else
            {
                string LSTR_V4STATUS = ((HiddenField)rptData.Items[i].FindControl("HidV4STATUS")).Value.ToString().Trim();
                if (LSTR_V4STATUS == "4A")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkReject")).Checked = true;
                }
                else if (LSTR_V4STATUS == "4B")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkDecline")).Checked = true;
                }
                else if (LSTR_V4STATUS == "4C")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkAddCon")).Checked = true;
                }
                else if (LSTR_V4STATUS == "4")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkApprove")).Checked = true;
                }
            }

            //2013/10/28 Edit by SS Leo 覆核狀態
            string LSTR_REVIEWSTATUS = ((HiddenField)rptData.Items[i].FindControl("HIdREVIEWSTATUS")).Value.ToString().Trim();
            {
                //20140227 ADD BY SS ADAM Reason.增加無覆核狀態的處理
                if (LSTR_REVIEWSTATUS == "")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkNoReview")).Checked = true;
                }
                if (LSTR_REVIEWSTATUS == "01" || LSTR_REVIEWSTATUS == "02")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkNoReview")).Checked = true;
                }
                //else if (LSTR_REVIEWSTATUS == "02" || LSTR_REVIEWSTATUS == "03")
                else if (LSTR_REVIEWSTATUS == "03")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkWait")).Checked = true;
                }
                else if (LSTR_REVIEWSTATUS == "04")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkReviewOK")).Checked = true;
                }
            }

            //20160930 ADD BY SS ADAM REASON.增加放審會
            string LSTR_EXAMINE = ((HiddenField)rptData.Items[i].FindControl("hidEXAMINE")).Value.ToString().Trim();
            {
                if (LSTR_EXAMINE == "00")
                {

                }
                if (LSTR_EXAMINE == "01")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkExamine1")).Checked = true;
                }
                if (LSTR_EXAMINE == "02")
                {
                    ((CheckBox)rptData.Items[i].FindControl("chkExamine2")).Checked = true;
                }
            }
        }
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        Alert("查無資料");
      }
      this.UpdatePanelDate.Update();
      this.txtCustName.Width = 400;
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  /// <summary>
  /// 查詢案件資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      // 2013.08.19 Edit BY SEAN 徵信狀況已徵信並輸入案件編號，進件核准日可不輸入查詢
	  if ((this.drpCreditType.SelectedValue == "Y") && (String.IsNullOrEmpty(this.txtCaseID.Text.Trim())) &&
	      (String.IsNullOrEmpty(this.txtStartDate.Text.Trim()) || String.IsNullOrEmpty(this.txtEndDate.Text.Trim())))
	  //if ((this.drpCreditType.SelectedValue == "Y") && (String.IsNullOrEmpty(this.txtStartDate.Text.Trim()) || String.IsNullOrEmpty(this.txtEndDate.Text.Trim())))
      {
        Alert("請輸入進件日起迄!");
      } else {
        //查詢並綁定畫面Grid資料
        this.rptDataBind();
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  protected void btnSave_Click(object sender, EventArgs e)
  {
    bool LBOL_Save = false;
    for (int i = 0; i < this.rptData.Items.Count; i++)
    {
      if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkApprove")).Checked == true)
      {
        MLMCASESave("4", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkAddCon")).Checked == true)
      {
        MLMCASESave("4C", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkReject")).Checked == true)
      {
        MLMCASESave("4A", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkDecline")).Checked == true)
      {
        MLMCASESave("4B", i);
        LBOL_Save = true;
      }
    }
    if (!LBOL_Save)
    {
      Alert("請至少選擇一筆案件處理!");
    }
    try
    {
      //查詢並綁定畫面Grid資料
      this.rptDataBind();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  private void MLMCASESave(string LSTR_SaveType, int LINT_RptIndex)
  {
    StringBuilder LSTR_Data = new StringBuilder();
    //案件主鍵
    string LSTR_CASEID = ((Label)rptData.Items[LINT_RptIndex].FindControl("lblCASEID")).Text;
    LSTR_Data.Append("SP_ML1002_U05" + GSTR_ColDelimitChar);
    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    //john 2011/11/04  增加寫入實際徵審單位
    LSTR_Data.Append(GSTR_TabDelimitChar + GSTR_DEPTID);

    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================            
    LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append(((HiddenField)rptData.Items[LINT_RptIndex].FindControl("hidAddCon")).Value.ToString().Replace("\r\n", "<br>") + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append("1");
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
        Alert("操作完成！");
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
}
