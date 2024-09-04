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


public partial class FrmML5002 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "財務回件作業";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5002";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5002";
      //========================             
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        //drpDeptIDBind();
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
    txtAgency.Attributes.Add("Readonly", "True");
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
        Alert("'" + LOBJ_Return.ReturnErrNum + "':" + LOBJ_Return.ReturnMessage);
        //            Alert(LOBJ_Return.ReturnErrNum);

        //          Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  /*
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
        LVAR_Parameter[1] = "'ML','16','T'";
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
  */

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

      //20120530 MODIFY BY SSF MAUREEN REASON:修改為呼叫SP_ML5002_Q01
      //LVAR_Parameter[0] = "SP_ML5001_Q01";
      LVAR_Parameter[0] = "SP_ML5002_Q01";

      LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();
        DataTable LDAT_Data = LOBJ_Return.ReturnData;
        for (int i = 0; i < LDAT_Data.Rows.Count; i++)
        {
          if (LDAT_Data.Rows[i]["RENTSTDT"].ToString() != "")
          {
            DateTime LDAT_RENTSTDT = Convert.ToDateTime(LDAT_Data.Rows[i]["RENTSTDT"].ToString());
            TimeSpan LDAT_Time = DateTime.Now - LDAT_RENTSTDT;
            ((Label)this.rptData.Items[i].FindControl("lblMDAY")).Text = LDAT_Time.Days.ToString();
          }
        }
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        Alert("查無資料");
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
      //部門別
      if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
      }
      //業代名
      if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.EMPLID = ''" + this.txtAgency.Text.Trim() + "''";
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
        LSTR_QueryCon += " AND  MLMCUSTOMER.CUSTNAME LIKE ''" + this.txtCustName.Text.Trim() + "%''";
      }
      //撥款日
      if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
      {
        LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) >= ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
        LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) <= ''" + this.txtCNTRNODATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
        if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()))
        {
          LSTR_QueryCon += " AND CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) = ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
        }
        else
        {
          if (!String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
          {
            LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) = ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
          }
        }
      }
      //起租日
      if (!String.IsNullOrEmpty(this.txtRENTSTDT.Text.Trim()))
      {
        LSTR_QueryCon += " AND MLMCONTRACT.RENTSTDT = ''" + Itg.Community.Util.GetADYear(this.txtRENTSTDT.Text.Trim()) + "''";
      }
      //案件核准日
      if (!String.IsNullOrEmpty(this.txtCASEDATE.Text.Trim()))
      {
        LSTR_QueryCon += " AND MLMCASE.U_SYSDT = ''" + Itg.Community.Util.GetADYear(this.txtCASEDATE.Text.Trim()) + "''";
      }
      LSTR_QueryCon += " AND MLMRETURNDOC.CASESTATUS IN (''11'',''13'',''14'') AND RETUNCONFIRM3 = ''2''";
      //20120717 Modify By Maureen Reason:財務回件查詢要排除銀行件
      LSTR_QueryCon += " AND MLMCASE.SOURCETYPE NOT IN (''02'')";

    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }
}
