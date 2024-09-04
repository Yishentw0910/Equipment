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

public partial class FrmML3004 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款確認(財務)";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3004";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3004";
      //========================             
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        drpDeptIDBind();
        GetDrpData();
		//20121230 EDIT BY SEAN 新增預計撥款日迄日查詢條件
        this.txtEndPayDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
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
      //承做形態
      LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        DataSet LDST_Data = LOBJ_Return.ReturnData;
        this.drpMAINTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
        this.drpMAINTYPE.DataBind();
      }
      else
      {
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Return;
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
      //流程關卡(本畫面對應關卡: 2=案件送出審核，營業主管待核准。)
      //LSTR_QueryCon += " AND  MLMCASE.CASESTATUS = ''2''";
      //公司別
      if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
      }

      //部門別
      if (!String.IsNullOrEmpty(this.drpDeptID.SelectedValue.Trim()))
      {
          LSTR_QueryCon += " AND  MLMCASE.DEPTID = ''" + this.drpDeptID.SelectedValue.Trim() + "''";
      }
      //承作類型
      if (!String.IsNullOrEmpty(this.drpMAINTYPE.SelectedValue.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.MAINTYPE = ''" + this.drpMAINTYPE.SelectedValue.Trim() + "''";
      }
      LSTR_QueryCon += " AND MLMCONTRACT.CASESTATUS =''8'' ";
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
      //進件日起迄-起
      if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  V6DATE >= ''" + Itg.Community.Util.GetADYear(this.txtStartDate.Text.Trim()) + "''";
      }
      //進件日起迄-迄
      if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  V6DATE < ''" + Itg.Community.Util.AddDay(Itg.Community.Util.GetADYear(this.txtEndDate.Text.Trim()), 1) + "''";
      }
	  
	  //20131230 新增預計撥款日迄日查詢
      //撥款日迄日
      if (!String.IsNullOrEmpty(this.txtEndPayDate.Text.Trim()))
      {
        LSTR_QueryCon += " AND  PAYDATE  < ''" + Itg.Community.Util.AddDay(Itg.Community.Util.GetADYear(this.txtEndPayDate.Text.Trim()), 1) + "''";
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
      }
      else
      {
        Alert("查無資料");
        this.rptData.DataSource = null;
        this.rptData.DataBind();
      }
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
