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
using ITG.Community;
using Itg.Community;

public partial class FrmML1001A : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "客戶查詢";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "LE1001A";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "LE1001A";
    //========================             
    try
    {
      if (!IsPostBack)
      {
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  /// <summary>
  /// 綁定DataGrid
  /// </summary>
  private void grdData_Bind()
  {
    DataTable LOBJ_Data;
    try
    {
      LOBJ_Data = GetPostCodeData();
      this.grvData.DataSource = LOBJ_Data;
      this.grvData.DataBind();
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  /// <summary>
  /// 根據條件查詢郵遞區號資料
  /// </summary>
  /// <returns></returns>
  private DataTable GetPostCodeData()
  {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    DataTable LOBJ_Result;
    String LSTR_ExtraCon;
    try
    {
      LOBJ_Result = null;
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LSTR_ExtraCon = "";
      if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim()))
      {
        LSTR_ExtraCon += " AND CUSTID = ''" + this.txtCustID.Text.Trim() + "''";
      }
      if (!String.IsNullOrEmpty(this.txtCustName.Text.Trim()))
      {
        LSTR_ExtraCon += " AND CUSTNAME LIKE ''%" + this.txtCustName.Text.Trim() + "%''";
      }

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "dbo.SP_ML1001_Q02";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        LOBJ_Result = LOBJ_Return.ReturnData;
      }
      else
      {
        Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Result;
  }

  /// <summary>
  /// 查詢郵遞區號資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.txtCustID.Text.Trim() == "" && this.txtCustName.Text.Trim() == "")
      {
        Alert("請輸入查詢條件！");
        return;
      } 
      grdData_Bind();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  /// <summary>
  /// DAtaGrid 新增每一行時,觸發此事件
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
  {
    try
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        e.Row.Attributes.Add("onclick", "Row_Click(this);");
        e.Row.Attributes.Add("ondblclick", "Row_dblClick(this);");
        e.Row.Attributes.Add("style", "cursor:pointer;");
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
   
}
