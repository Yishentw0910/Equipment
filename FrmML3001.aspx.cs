/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML3001																					
* 程式功能  : 案件核准																			
* 程式作者 	: 																			
* 完成時間 	: 
* 修改事項 	: 
Modify 20120622 By SS Gordon. Reason: 修正查詢條件，CASESTATUS的條件由「4,4B,4C」調整為「4E」
Modify 20120622 By SS Gordon. Reason: 修正查詢條件，VERIFYSTATUS的條件由「4」調整為「4E」
Modify 20120709 By SS Gordon. Reason: 新增撤件寄MAIL通知
Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"5A"改成"5X"
Modify 20121114 By SS Steven. Reason: 新增「退回」的checkbox控制項，選取後儲存可退回至ML3000，並且發送EMAIL通知業代
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
using ITG.Community;
using Comus;
using System.Text;

public partial class FrmML3001 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "案件核准";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3001";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3001";
    //========================             
    Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
    try
    {
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        drpDeptIDBind();
        this.btnSave.Enabled = false;
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
    txtAgency.Attributes.Add("Readonly", "True");
    //txtCustID.Attributes.Add("Readonly", "True");
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
      //業代名
      if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.U_USERID = ''" + this.txtAgencyId.Text.Trim() + "''";
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
      //征信核准日
      if (!String.IsNullOrEmpty(this.txtApproveDate.Text.Trim()))
      {
        //Modify 20120622 By SS Gordon. Reason: 修正查詢條件，VERIFYSTATUS的條件由「4」調整為「4E」
        //LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''4'' ORDER BY VERIFYID DESC ) >= ''" + Itg.Community.Util.GetADYear(this.txtApproveDate.Text.Trim()) + "''";
        //LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''4'' ORDER BY VERIFYID DESC ) < ''" + Itg.Community.Util.AddDay(this.txtApproveDate.Text.Trim(), 1) + "''";
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''4E'' ORDER BY VERIFYID DESC ) >= ''" + Itg.Community.Util.GetADYear(this.txtApproveDate.Text.Trim()) + "''";
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''4E'' ORDER BY VERIFYID DESC ) < ''" + Itg.Community.Util.AddDay(this.txtApproveDate.Text.Trim(), 1) + "''";
      }
      //流程關卡(本畫面對應關卡: 案件審核完成，案件核准，主管待核准。)
      //Modify 20120622 By SS Gordon. Reason: 修正查詢條件，CASESTATUS的條件由「4,4B,4C」調整為「4E」
      //LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN (''4'',''4B'',''4C'') ";
      LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS] IN (''4E'') ";
      //單位類別: A 管理  X: 營業
      if (GSTR_DEPTTYPE == "A")
      {
      }
      else
      {
        //主管等級: X1 協理(A內勤預設) , X2  長租X部經理,   X3 處長(等同助理) , X4 業代
        if (GSTR_MANGLEV == "X1")
        {
        }
        else if (GSTR_MANGLEV == "X2")
        {
          //部經理掌管處別字串  
          GSTR_MANGDEPT.Replace(",", "'',''");
          LSTR_QueryCon += "AND MLMCASE.DEPTID IN (''" + GSTR_U_USERID.Trim() + "'')";
        }
        else if (GSTR_MANGLEV == "X3")
        {
          LSTR_QueryCon += "AND MLMCASE.DEPTID = ''" + GSTR_DEPTID.Trim() + "''";
        }
        else if (GSTR_MANGLEV == "X4")
        {
          LSTR_QueryCon += "AND MLMCASE.EMPLID = ''" + GSTR_U_USERID.Trim() + "''";
        }
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
        this.btnSave.Enabled = true;
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        this.btnSave.Enabled = false;
        Alert("查無資料");
      }
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
        MLMCASESave("5", i);
        LBOL_Save = true;
      }
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkRej")).Checked == true)
      {
        //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"5A"改成"5X"
        //MLMCASESave("5A", i);
        MLMCASESave("5X", i);
        LBOL_Save = true;
      }
      //Modify 20121114 By SS Steven. Reason: 新增「退回」的checkbox控制項，選取後儲存可退回至ML3000，並且發送EMAIL通知業代
      // Mark by Sean 2012/11/30 處長不可退回
      else if (((HtmlInputCheckBox)rptData.Items[i].FindControl("chkReturn")).Checked == true)
      {
          MLMCASERETURN("4D", i);
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
    LSTR_Data.Append("SP_ML1002_U04" + GSTR_ColDelimitChar);
    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================            
    LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append("1");
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================
    //Modify 20120709 By SS Gordon. Reason: 新增撤件寄MAIL通知
    //Modify 20120918 By SS Gordon. Reason: 將撤件狀態由"5A"改成"5X"
    //if (LSTR_SaveType == "5A")
    if (LSTR_SaveType == "5X")
    {
        LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        LSTR_Data.Append("ML3001X" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
    }
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

  //Modify 20121114 By SS Steven. Reason: 新增「退回」的checkbox控制項，選取後儲存可退回至ML3000，並且發送EMAIL通知業代
  private void MLMCASERETURN(string LSTR_SaveType, int LINT_RptIndex)
  {
      StringBuilder LSTR_Data = new StringBuilder();
      //案件主鍵
      string LSTR_CASEID = ((Label)rptData.Items[LINT_RptIndex].FindControl("lblCASEID")).Text;
      LSTR_Data.Append("SP_ML1002_U04" + GSTR_ColDelimitChar);
      LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
      LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT);
      LSTR_Data.Append(GSTR_ColDelimitChar);
      LSTR_Data.Append(GSTR_RowDelimitChar);
      //=========================================================================            
      LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
      LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
      LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
      LSTR_Data.Append(LSTR_SaveType + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append("1");
      LSTR_Data.Append(GSTR_ColDelimitChar);
      LSTR_Data.Append(GSTR_RowDelimitChar);
      //=========================================================================
      LSTR_Data.Append("SP_ML9001_I02" + GSTR_ColDelimitChar);
      LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
      LSTR_Data.Append("1" + GSTR_TabDelimitChar);
      LSTR_Data.Append("ML3001A" + GSTR_TabDelimitChar);
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
}