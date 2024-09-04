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
using System.Reflection;

public partial class FrmML3005 : PageBase
{
   public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
  public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
  public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
  public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
  public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
  public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
 protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款一覽表列印作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "LE3005";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "LE3005";

    //========================             
    if (!IsPostBack)
    {
      //綁定公司別下拉
      drpCompIDBind();
      drpDeptIDBind();
      drpMainTypeBind();
      this.rdoRECFMDT.Attributes.Add("onclick", "rdoDT_onclick(this);");
      this.rdoAPCFMDT.Attributes.Add("onclick", "rdoDT_onclick(this);");
      this.rdoCNTRNO.Attributes.Add("onclick", "rdoDT_onclick(this);");
      this.rdoCNTRNO.Checked = true;
      //20170306 ADD BY SS ADAM REASON.公司別指定和運
      drpCompID.SelectedValue = "01";
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
  /// 綁定部門別下拉
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
        //綁定數據
        this.drpMAINTYPE.DataSource = LOBJ_Return.ReturnData;
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
}
