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


public partial class FrmML4006 : PageBase
{
  public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
  public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
  public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
  public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
  public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
  public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      if (Session["USERID"] != null) GSTR_A_USERID = Session["USERID"].ToString();
      if (Session["USERID"] != null) GSTR_U_USERID = Session["USERID"].ToString();
      if (Session["USERNM"] != null) GSTR_USERNM = Session["USERNM"].ToString();
      if (Session["LOGINTIME"] != null) GSTR_LOGINTIME = Session["LOGINTIME"].ToString();
      if (Session["DEPTID"] != null) GSTR_DEPTID = Session["DEPTID"].ToString();
      if (Session["DEPTNM"] != null) GSTR_DEPTNAME = Session["DEPTNM"].ToString();
      if (Session["DLRCD"] != null) GSTR_DLRCD = Session["DLRCD"].ToString();
      if (Session["DLRNM"] != null) GSTR_DLRNM = Session["DLRNM"].ToString();
      if (Request.QueryString["PROGID"] != null) GSTR_A_PRGID = Request.QueryString["PROGID"].ToString();
      if (Request.QueryString["PROGID"] != null) GSTR_U_PRGID = Request.QueryString["PROGID"].ToString();
      if (Request.QueryString["PROGNM"] != null) GSTR_PROGNM = Request.QueryString["PROGNM"].ToString();
      GSTR_A_SYSDT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
      GSTR_U_SYSDT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "銷貨發票明細表";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4006";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4006";
      //========================            
      if (!IsPostBack)
      {
        drpCompIDBind();
        //drpINVOSTUSBind();
        drpMainTypeBind();
      }
      PageInitProcess();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
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
      LVAR_Parameter[1] = "'" + LSTR_SYSID + "','" + LSTR_DataID + "','F'";
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
  private void drpINVOSTUSBind()
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
      LVAR_Parameter[1] = "'LE','18','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.drpINVOSTUS.DataSource = LOBJ_Return.ReturnData;
        this.drpINVOSTUS.DataValueField = "MCODE";
        this.drpINVOSTUS.DataTextField = "MNAME1";
        this.drpINVOSTUS.DataBind();
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
  /// 綁定承作類型下拉
  /// </summary>
  private void drpMainTypeBind()
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
      LVAR_Parameter[1] = "'LE','05','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
		// 20151214 EDIT BY SEAN 新增承作類型-全部選項
        //綁定數據
        DataTable LOBJ_DataTable = LOBJ_Return.ReturnData.Clone();
        DataRow LOBJ_DataRow;
        LOBJ_DataTable.Rows.Clear();
        LOBJ_DataRow = LOBJ_DataTable.NewRow();
        LOBJ_DataRow["MNAME1"] = "全部";
        LOBJ_DataRow["MCODE"] = "";
        LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["MCODE"] = LOBJ_Return.ReturnData.Rows[i]["MCODE"];
          LOBJ_DataRow["MNAME1"] = LOBJ_Return.ReturnData.Rows[i]["MNAME1"];
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);
        }
        this.drpMAINTYPE.DataSource = LOBJ_DataTable;

        //this.drpMAINTYPE.DataSource = LOBJ_Return.ReturnData;
		this.drpMAINTYPE.DataValueField = "MCODE";
        this.drpMAINTYPE.DataTextField = "MNAME1";
        this.drpMAINTYPE.DataBind();
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
  /// 畫面初始屬性設定
  /// </summary>
  private void PageInitProcess()
  {
    this.cmdPrint.Enabled = false;
	
    // 20141020 Edit by Sean 新增客戶下載銷貨發票明細表相關資料(含發票寄送地址)
	this.cmdPrint2.Enabled = false;
	
    this.drpINVOSTUS.Attributes.Add("onchange", "drpINVOSTUS_onChange(this);");
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
        LSTR_QueryCon += "'" + this.drpCompID.SelectedValue.Trim() + "'";
      }
      //承作類型
      if (!String.IsNullOrEmpty(this.drpMAINTYPE.SelectedValue.Trim()))
      {
        LSTR_QueryCon += ",";
        LSTR_QueryCon += "'" + this.drpMAINTYPE.SelectedValue.Trim() + "'";
      }
	  // 20151214 EDIT BY SEAN 新增承作類型-全部選項
	  else
      {
        LSTR_QueryCon += ",''";
      }
	  
      //發票狀態
      if (!String.IsNullOrEmpty(this.drpINVOSTUS.SelectedValue.Trim()))
      {
        LSTR_QueryCon += ",";
        if (this.drpINVOSTUS.SelectedValue.Trim() == "1")
        {
            LSTR_QueryCon += "'" + this.drpINVOSTUS.SelectedValue.Trim() + "'";
        }
        else
        {
            LSTR_QueryCon += "'2'";
        }
      }
      //傳票期間起迄-起
      if (!String.IsNullOrEmpty(this.txtINVDATES.Text.Trim()))
      {
        LSTR_QueryCon += ",";
        LSTR_QueryCon += "'" + Itg.Community.Util.GetADYear(this.txtINVDATES.Text.Trim().Replace("/", "")) + "'";
      }
      //傳票期間起迄-迄
      if (!String.IsNullOrEmpty(this.txtINVDATEE.Text.Trim()))
      {
        LSTR_QueryCon += ",";
        LSTR_QueryCon += " '" + Itg.Community.Util.GetADYear(this.txtINVDATEE.Text.Trim().Replace("/", "")) + "'";
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
    try
    {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //取得查詢條件
      string LSTR_QueryCon = GenerateQueryCon();
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML4006_Q01";
      LVAR_Parameter[1] = LSTR_QueryCon;
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();
        this.cmdPrint.Enabled = true;
		//20141020 Edit by Sean 新增客戶下載銷貨發票明細表相關資料(含發票寄送地址)
        this.cmdPrint2.Enabled = true;
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        this.cmdPrint.Enabled = false;
		//20141020 Edit by Sean 新增客戶下載銷貨發票明細表相關資料(含發票寄送地址)
		this.cmdPrint2.Enabled = false;
        Alert("查無資料");
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
      this.UpdatePanelDate.Update();
      this.UpdatePanel2.Update();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  protected void cmdClear_Click(object sender, EventArgs e)
  {
    this.rptData.DataSource = null;
    this.rptData.DataBind();
  }
}
