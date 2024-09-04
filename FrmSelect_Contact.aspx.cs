using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itg.Community;
using System.Data;
using ITG.Community;

public partial class FrmSelect_Contact : PageBase
{
  String ASTR_CustID;

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "聯絡人查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML0003";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML0003";
      //========================             
      //從主畫面傳入客戶編號
      ASTR_CustID = Request.QueryString["custid"];
      if (!IsPostBack)
      {
        grdData_Bind();
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
      if (!String.IsNullOrEmpty(ASTR_CustID))
      {
        LSTR_ExtraCon += " AND CUSTID = ''" + ASTR_CustID + "''";
      }
      if (!String.IsNullOrEmpty(this.txtContactTitle.Text.Trim()))
      {
        LSTR_ExtraCon += " AND CONTACTTITLE LIKE ''" + this.txtContactTitle.Text.Trim() + "%''";
      }
      if (!String.IsNullOrEmpty(this.txtContactName.Text.Trim()))
      {
        LSTR_ExtraCon += " AND CONTACTNAME LIKE ''" + this.txtContactName.Text.Trim() + "%''";
      }
      LSTR_ExtraCon += " AND DELMARK = ''N''";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML1001_Q04";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        LOBJ_Result = LOBJ_Return.ReturnData;
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
        LSTR_ExtraData += LOBJ_Row["CONTACTID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CUSTID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTNAME"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["DEPTNAME"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTTITLE"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTTEL"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTTELEXT"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTMPHONE"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTFAX"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTEMAIL"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTTELCODE"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["CONTACTFAXCODE"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["A_PRGID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["A_USERID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["A_SYSDT"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["U_PRGID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["U_USERID"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += LOBJ_Row["U_SYSDT"].ToString() + GSTR_ColDelimitChar;
        LSTR_ExtraData += GSTR_RowDelimitChar;

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
