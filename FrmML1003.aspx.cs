/*
//20131231 ADD BY SS ADAM Reason.流程關卡增加必須要在案件異常報告先有資料才可以做處長核准

*/

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
using System.IO;

public partial class FrmML1003 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
        try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "進件核准查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML1003";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML1003";
      //========================             
      Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
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
        LSTR_QueryCon += " AND  MLVERIFY.VERIFYPERSON = ''" + this.txtAgencyId.Text.Trim() + "''";
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
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''2'' ORDER BY VERIFYID DESC ) >= ''" + this.txtStartDate.Text.Trim() + "''";
      }
      //進件日起迄-迄
      if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''2'' ORDER BY VERIFYID DESC ) < ''" + Itg.Community.Util.AddDay(this.txtEndDate.Text.Trim(), 1) + "''";
      }
      //流程關卡(本畫面對應關卡: 2=案件送出審核，營業主管待核准。)
      LSTR_QueryCon += " AND [MLMCASE].[CASESTATUS]=''2'' ";

      //20131231 ADD BY SS ADAM Reason.流程關卡增加必須要在案件異常報告先有資料才可以做處長核准
      LSTR_QueryCon += " AND [MLMCASE].[CASEID] IN (SELECT CASEID FROM MLDCASEEXCEPTION WITH(NOLOCK) WHERE CASEID=[MLMCASE].[CASEID])";

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
      }
      else
      {
        Alert("查無資料");
        this.rptData.DataSource = null;
        this.rptData.DataBind();
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
}
