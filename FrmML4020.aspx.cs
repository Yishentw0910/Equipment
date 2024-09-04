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

public partial class FrmML4020 : PageBase {
  public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
  public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
  public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
  public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
  public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
  public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
  protected void Page_Load(object sender, EventArgs e) {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "繳款單查詢列印作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4020";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4020";
    //========================             
    try {
      if (!IsPostBack) {
          //JOHN 2012/2/1 增加DDL
          chopaytypeBind();
      }
    } catch (Exception ex) {
      Alert(ex.Message);
    }
    txtCustName.Attributes.Add("Readonly", "True");
    //cmdPrint.Enabled = false;
    //cmdPrintThank.Enabled = false;
    UpdatePanelButton.Update();
  }

  private String GenerateQueryCon() {
    String LSTR_QueryCon;
    try {
      LSTR_QueryCon = "";
      //發票開立日-起
      if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim())) {
        LSTR_QueryCon += "'" + this.txtStartDate.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += "''";
      }
      //發票開立日-迄
      if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //客戶統編
      if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCustID.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //合約編號
      if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCNTRNO.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //合約列印條碼
      if (!String.IsNullOrEmpty(this.txtCNTRNO_CODE.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCNTRNO_CODE.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //JOHN 2012/2/1 付款條件
      LSTR_QueryCon += ",'" + this.cboPayType.SelectedValue.ToString().Trim() + "'";
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_QueryCon;
  }

  /// <summary>
  /// 綁定畫面Grid數據
  /// </summary>
  private void rptDataBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    String LSTR_QueryCon;
    try {
      //取得查詢條件
      LSTR_QueryCon = this.GenerateQueryCon();	  
      //查詢資料
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML4020_Q01";
      LVAR_Parameter[1] = LSTR_QueryCon;

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
     
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();
        //if (this.cboQueryType.SelectedValue == "2") {
          //for (int i = 0; i < rptData.Items.Count; i++) {
          //  ((CheckBox)rptData.Items[i].FindControl("chkPrintAll")).Attributes.Add("style", "display:none;");
          //  ((CheckBox)rptData.Items[i].FindControl("chkPrintSub")).Attributes.Add("style", "display:none;");
          //  ((TextBox)rptData.Items[i].FindControl("txtPrintIssueS")).Attributes.Add("style", "display:none;");
          //  ((TextBox)rptData.Items[i].FindControl("txtPrintIssueE")).Attributes.Add("style", "display:none;");
          //  ((TextBox)rptData.Items[i].FindControl("txtRENTYEARS")).Attributes.Add("style", "display:none;");
          //  ((TextBox)rptData.Items[i].FindControl("txtRENTYEARE")).Attributes.Add("style", "display:none;");
          //}
        //}
        cmdPrint.Enabled = true;
        cmdPrintThank.Enabled = true;
        UpdatePanelButton.Update();
      } else {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        Alert("查無資料");
      }
      this.UpdatePanelDate.Update();
      this.txtCustName.Width = 400;
    } catch (Exception ex) {
      throw ex;
    }
  }
  //JOHN 2012/2/1 增加DDL
  private void chopaytypeBind()
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
          LVAR_Parameter[1] = "'ML','10','A'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              //綁定數據
              this.cboPayType.DataSource = LOBJ_Return.ReturnData;
              this.cboPayType.DataValueField = "MCODE";
              this.cboPayType.DataTextField = "MNAME1";
              this.cboPayType.DataBind();
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
  /// 查詢案件資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdQuery_Click(object sender, EventArgs e) {
    try {
      rptDataBind();
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
  protected void cmdClear_onclick(object sender, EventArgs e) {
    try {
      this.rptData.DataSource = null;
      this.rptData.DataBind();
      cmdPrint.Enabled = false;
      cmdPrintThank.Enabled = false;
      this.UpdatePanelDate.Update();
      this.UpdatePanelButton.Update();
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
}
