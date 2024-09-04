using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itg.Community;
using ITG.Community;
using System.Data;

public partial class FrmSelect_Agency : PageBase
{                     
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "業代查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML0002";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML0002";
      //========================             
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
      LOBJ_Data = GetData();
      this.grvData.DataSource = LOBJ_Data;
      this.grvData.DataBind();
      this.txtAgencyID.Width = 160;
      this.txtAgencyName.Width = 160;
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  /// <summary>
  /// 根據條件查詢業代資料
  /// </summary>
  /// <returns></returns>
  private DataTable GetData()
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
      if (!String.IsNullOrEmpty(this.txtAgencyID.Text.Trim()))
      {
        LSTR_ExtraCon += " AND EMPLID LIKE ''" + this.txtAgencyID.Text.Trim() + "''";
      }
      if (!String.IsNullOrEmpty(this.txtAgencyName.Text.Trim()))
      {
        LSTR_ExtraCon += " AND EMPLNM LIKE ''" + this.txtAgencyName.Text.Trim() + "%''";
      }              
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q04";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        LOBJ_Result = LOBJ_Return.ReturnData;
      }
      else
      {
        LOBJ_Result = null;
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
  /// 查詢業代資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.txtAgencyID.Text.Trim() == "" && this.txtAgencyName.Text.Trim() == "")
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
    GridView gd;
    DataTable dt;
    DataRow LOBJ_Row;
    String LSTR_ExtraData;
    try
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        gd = (GridView)sender;
        dt = (DataTable)gd.DataSource;
        LOBJ_Row = dt.Rows[e.Row.RowIndex];
        LSTR_ExtraData = "";
        LSTR_ExtraData += LOBJ_Row["EMPLID"].ToString() + Common.GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["EMPLNM"].ToString() + Common.GSTR_ColDelimitChar; 

        e.Row.Attributes.Add("onmouseover", "MouseOver(event);");
        e.Row.Attributes.Add("onMouseOut", "MouseOut(event);");
        e.Row.Attributes.Add("onclick", "MouseDown(event);Row_Click(this);");
        e.Row.Attributes.Add("ondblclick", "Row_dblClick(this);");
        e.Row.Attributes.Add("style", "cursor:pointer;");
        e.Row.Attributes.Add("extraData", LSTR_ExtraData);
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
}
