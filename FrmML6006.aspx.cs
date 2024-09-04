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
using Microsoft.VisualBasic;
using System.Text;
using System.IO;


public partial class FrmML6006 : PageBase {
  protected void Page_Load(object sender, EventArgs e) {
    try {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "供應商存借款查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6006";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6006";
      //========================             
      Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
      if (!IsPostBack) {
        //綁定部門別下拉
        drpDeptIDBind();
      } else {
      }
      this.drpQryType.Attributes.Add("onchange", "drpQryType_onChange(this);");
    } catch (Exception ex) {
      Alert(ex.Message);
    }
    txtAgency.Attributes.Add("Readonly", "True");
    txtSipplierName.Attributes.Add("Readonly", "True");
  }
  /// <summary>
  /// 綁定部門別下拉
  /// </summary>
  private void drpDeptIDBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    try {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'ML','16','T'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        this.drpDeptID.DataSource = LOBJ_Return.ReturnData;
        this.drpDeptID.DataValueField = "MCODE";
        this.drpDeptID.DataTextField = "MNAME1";
        this.drpDeptID.DataBind();
      } else {
        //Alert("查無資料");
      }
    } catch (Exception ex) {
      throw ex;
    }
  }
  /// <summary>
  /// 組合畫面的查詢條件
  /// </summary>
  /// <returns></returns>
  private String GenerateQueryCon() {
    String LSTR_QueryCon;
    try {
      LSTR_QueryCon = "";
      //實際起租日-起
      if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim())) {
        LSTR_QueryCon += "'" + this.txtStartDate.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += "''";
      }
      //實際起租日-迄
      if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //承案部門代碼
      if (!String.IsNullOrEmpty(this.drpDeptID.SelectedValue.Trim())) {
        LSTR_QueryCon += ",'" + this.drpDeptID.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //承案員工代碼
      if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtAgencyId.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //供應商代碼
      if (!String.IsNullOrEmpty(this.txtSipplierId.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtSipplierId.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
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

      if (this.drpQryType.SelectedValue == "1") {
        LVAR_Parameter[0] = "SP_ML6006_Q01";
      } else if (this.drpQryType.SelectedValue == "2") {
        LVAR_Parameter[0] = "SP_ML6006_Q02";
      }
      LVAR_Parameter[1] = LSTR_QueryCon;

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        ViewState["Data"] = LOBJ_Return.ReturnData;
        if (this.drpQryType.SelectedValue == "1") {
          this.rptData1.DataSource = LOBJ_Return.ReturnData;
          this.rptData1.DataBind();
        } else if (this.drpQryType.SelectedValue == "2") {
          this.rptData2.DataSource = LOBJ_Return.ReturnData;
          this.rptData2.DataBind();
        }
      } else {
        ViewState["Data"] = null;
        this.rptData1.DataSource = null;
        this.rptData1.DataBind();
        this.rptData2.DataSource = null;
        this.rptData2.DataBind();
        Alert("查無資料");
      }
      RegisterScript("window_onload();");
      this.UpdatePanelDate.Update();
    } catch (Exception ex) {
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
      //查詢並綁定畫面Grid資料      
      rptDataBind();
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
  /// <summary>
  /// 匯出資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdExportExcel_Click(object sender, EventArgs e) {
    try {
      if (ViewState["Data"] != null) {
        string LSTR_Code = Guid.NewGuid().ToString();
        Session[LSTR_Code] = ViewState["Data"];
        Response.Redirect("ExportExcel.aspx" + "?type=" + this.drpQryType.SelectedValue + "&code=" + LSTR_Code);
        //RegisterScript("window.open('" + "ExportExcel.aspx" + "?type=" + this.drpQryType.SelectedValue + "&code=" + LSTR_Code + "');");        
      } else {
        Alert("下載EXCEL資料前，請先查詢出資料!");
      }
      //查詢並綁定畫面Grid資料      
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
  protected void cmdClear_onclick(object sender, EventArgs e) {
    try {
      ViewState["Data"] = null;
      this.rptData1.DataSource = null;
      this.rptData1.DataBind();
      this.rptData2.DataSource = null;
      this.rptData2.DataBind();
      this.UpdatePanelDate.Update();
      RegisterScript("window_onload();");
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
}
