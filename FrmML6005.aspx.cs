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


public partial class FrmML6005 : PageBase {
  protected void Page_Load(object sender, EventArgs e) {
    try {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "業績查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6005";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6005";
      //========================             
      Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
      if (!IsPostBack) {
      } else {
      }
    } catch (Exception ex) {
      Alert(ex.Message);
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
      //進件日期-起
      if (!String.IsNullOrEmpty(this.txtStartDate1.Text.Trim())) {
        LSTR_QueryCon += "'" + this.txtStartDate1.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += "''";
      }
      //進件日期-迄
      if (!String.IsNullOrEmpty(this.txtEndDate1.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate1.Text.Trim().Replace("/", "") + "'";
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
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //取得查詢條件
      LSTR_QueryCon = this.GenerateQueryCon();
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML6005_Q01";
      LVAR_Parameter[1] = LSTR_QueryCon;
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LDAT_Data = LOBJ_Return.ReturnData;
        //合約編號
        this.rptData.DataSource = LDAT_Data;
        ViewState["Data"] = LDAT_Data;
        this.rptData.DataBind();
      } else {
        Alert("查無資料");
        ViewState["Data"] = null;
        this.rptData.DataSource = null;
        this.rptData.DataBind();
      }
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
      this.rptDataBind();
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
        Response.Redirect("ExportExcel6005.aspx" + "?type=&code=" + LSTR_Code);
        //RegisterScript("window.open('" + "Expor1tExcel.aspx" + "?type=" + this.drpQryType.SelectedValue + "&code=" + LSTR_Code + "');");        
      } else {
        Alert("下載EXCEL資料前，請先查詢出資料!");
      }
      //查詢並綁定畫面Grid資料      
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
}
