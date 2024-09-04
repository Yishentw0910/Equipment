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

public partial class FrmML3003 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款核准（信管）";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3003";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3003";
      //========================             
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        drpDeptIDBind();
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
        //Alert("查無資料");
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
        //Alert("查無資料");
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
      //合約編號
      if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
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
      //流程關卡(本畫面對應關卡: 撥款送出審核，徵信主管待核准。)
      if (this.drpCreditType.SelectedValue == "Y") {
        LSTR_QueryCon += " AND MLMCONTRACT.CASESTATUS IN (''8'',''8A'',''9'') ";
      } else {
        LSTR_QueryCon += " AND MLMCONTRACT.CASESTATUS IN (''7'') ";
      }       
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }
  private String GenerateQueryCon2()
  {
    String LSTR_QueryCon;
    try
    {
      LSTR_QueryCon = "";
      //徵信核准日起迄-起
      if (!String.IsNullOrEmpty(this.txtStartDateO.Text.Trim()))
      {
        LSTR_QueryCon += " AND  V6DATE >= ''" + Itg.Community.Util.GetADYear(this.txtStartDateO.Text.Trim()) + "''";
      }
      //徵信核准日起-迄
      if (!String.IsNullOrEmpty(this.txtEndDateO.Text.Trim()))
      {
        LSTR_QueryCon += " AND  V6DATE < ''" + Itg.Community.Util.AddDay(Itg.Community.Util.GetADYear(this.txtEndDateO.Text.Trim()), 1) + "''";
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
    String LSTR_QueryCon2;

    try
    {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //取得查詢條件
      LSTR_QueryCon = this.GenerateQueryCon();
      LSTR_QueryCon2 = this.GenerateQueryCon2();
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML3001_Q03";
      LVAR_Parameter[1] = "'" + LSTR_QueryCon + "','" + LSTR_QueryCon2 + "'";

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();
        for (int i = 0; i < rptData.Items.Count; i++)
        {
          string LSTR_CASESTATUS = ((HiddenField)rptData.Items[i].FindControl("hidCASESTATUS")).Value.ToString().Trim();
          if (LSTR_CASESTATUS == "7")
          {
          }
          else
          {
            string LSTR_V8STATUS = ((HiddenField)rptData.Items[i].FindControl("HidV8STATUS")).Value.ToString().Trim();
            if (LSTR_V8STATUS == "8A")
            {
              ((CheckBox)rptData.Items[i].FindControl("chkReject")).Checked = true;
            }
            else if (LSTR_V8STATUS == "8")
            {
              ((CheckBox)rptData.Items[i].FindControl("chkApprove")).Checked = true;
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
      //查詢並綁定畫面Grid資料
      this.rptDataBind();
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
        MLMCASESave("8", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkAddCon")).Checked == true)
      {
        MLMCASESave("8C", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkReject")).Checked == true)
      {
        MLMCASESave("8A", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkDecline")).Checked == true)
      {
        MLMCASESave("8B", i);
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
    string LSTR_CNTRNOID = ((Label)rptData.Items[LINT_RptIndex].FindControl("lblCNTRNOID")).Text;

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
    LSTR_Data.Append(((HiddenField)rptData.Items[LINT_RptIndex].FindControl("hidAddCon")).Value.ToString() + GSTR_TabDelimitChar);
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
}
