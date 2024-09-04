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

public partial class FrmML6002 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款權限維護";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6002";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6002";
    //========================             
    if (!Page.IsPostBack)
    {
      FormDrpBind();
    }
  }
  private void FormDrpBind()
  {
    try
    {
      ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

        this.drpMAINTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
        this.drpMAINTYPE.DataBind();

        string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
        drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
      }
      else
      {
        Alert(LOBJ_ReturnObject.ReturnMessage);
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  private void drpSUBTYPEaEXPIREPROCBindbyID(string LSTR_MAINTYPEID)
  {
    try
    {
      ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
        this.drpSUBTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
        this.drpSUBTYPE.DataBind();
      }
      else
      {
        Alert(LOBJ_ReturnObject.ReturnMessage);
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  private ReturnObject<DataSet> GetSUBTYPEDataById(string LSTR_MAINTYPEID)
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

      LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Return;
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
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Return;
  }
  protected void drpMAINTYPE_SelectedIndexChanged(object sender, EventArgs e)
  {
    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
    drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
    this.rptData.DataSource = null;
    this.rptData.DataBind();
  }
  public void ClearrptData()
  {
    this.rptData.DataSource = null;
    this.rptData.DataBind();
  }
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      //查詢並綁定畫面Grid資料
      rptDataBind();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
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
      LSTR_QueryCon = "";

      LSTR_QueryCon += " AND PP.dbo.PPMCODE.MCODE = ''" + this.drpMAINTYPE.SelectedValue + "''";
      LSTR_QueryCon += " AND PP.dbo.PPDCODE.DCODE = ''" + this.drpSUBTYPE.SelectedValue + "''";

      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML0003_Q01";
      LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();
        this.btnSave.Enabled = true;
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
        this.btnSave.Enabled = false;
        Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  protected void btnSave_Click(object sender, EventArgs e)
  {
    if (rptData.Items.Count > 0)
    {
      MLMGRANTRIGHTSave();
    }
    else
    {
      Alert("沒有資料！");
    }
  }
  private void MLMGRANTRIGHTSave()
  {
    StringBuilder LSTR_Data = new StringBuilder();
    for (int i = 0; i < this.rptData.Items.Count; i++)
    {
      LSTR_Data.Append("SP_ML0003_I01" + GSTR_ColDelimitChar);
      LSTR_Data.Append(((HiddenField)rptData.Items[i].FindControl("hidMCODE")).Value + GSTR_TabDelimitChar);
      LSTR_Data.Append(((HiddenField)rptData.Items[i].FindControl("hidDCODE")).Value + GSTR_TabDelimitChar);
      LSTR_Data.Append(((TextBox)rptData.Items[i].FindControl("txtIRR")).Text + GSTR_TabDelimitChar);
      LSTR_Data.Append(((TextBox)rptData.Items[i].FindControl("txtCONTRACTMONTH")).Text + GSTR_TabDelimitChar);
      LSTR_Data.Append(Itg.Community.Util.NumberToDb(((TextBox)rptData.Items[i].FindControl("txtAMOUNT")).Text) + GSTR_TabDelimitChar);
      LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptData.Items[i].FindControl("txtEFFSDT")).Text) + GSTR_TabDelimitChar);
      LSTR_Data.Append(Itg.Community.Util.GetADYear(((TextBox)rptData.Items[i].FindControl("txtEFFEDT")).Text) + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT);
      LSTR_Data.Append(GSTR_ColDelimitChar);
      LSTR_Data.Append(GSTR_RowDelimitChar);
    }
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = SaveData(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        RegisterScript("alert('資料儲存完成！');");
      }
      else
      {
        Alert(LOBJ_ReturnObject.ReturnMessage);
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }
  private ReturnObject<object> SaveData(string LSTR_Data)
  {
    Comus.HtmlSubmitControl LOBJ_Submit;
    string LSTR_ObjId;
    ReturnObject<object> LOBJ_Return;
    string[] LVAR_Parameter = new string[1];
    try
    {
      LSTR_ObjId = "ITG.CommDBService.MutiNonQuerySPExec";

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_Data;
      LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Return;
  }
}
