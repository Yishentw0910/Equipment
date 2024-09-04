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

public partial class FrmML7002 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "進項發票轉應付立帳轉檔作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML7002";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML7002";
    //========================             
    if (!IsPostBack)
    {
      //綁定公司別下拉
      drpCompIDBind();
      this.txtSysDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
      //this.txtSysDate.Attributes.Add("Readonly", "True");
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
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  protected void cmdProc_Click(object sender, EventArgs e)
  {
    try
    {
      TransData();
    }
    catch (Exception ex)
    {
    }
  }
  private void TransData()
  {
    StringBuilder LSTR_Data = new StringBuilder();
    //案件主鍵
    LSTR_Data.Append("SP_ML7002_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(this.drpCompID.SelectedValue.Trim() + GSTR_TabDelimitChar);
    LSTR_Data.Append(this.txtSysDate.Text.Replace("/", "") + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        if (LOBJ_ReturnObject.ReturnData.ToString().Substring(0, 1) == "0")
        {
          if (Convert.ToInt16(LOBJ_ReturnObject.ReturnData.ToString().Substring(1)) > 0)
          {
            RegisterScript("alert('批次轉檔完成！共" + LOBJ_ReturnObject.ReturnData.ToString().Substring(1) + "筆資料轉檔完成');");
          }
          else
          {
            RegisterScript("alert('無任何資料轉檔！');");
          }
        }
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
  private ReturnObject<object> UpdateCaseInfo(string LSTR_Data)
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
