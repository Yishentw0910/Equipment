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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic; 

public partial class FrmML4011 : PageBase
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
    if (GSTR_PROGNM == "") GSTR_PROGNM = "發票重印作業";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4011";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4011";
    //========================             
    if (!IsPostBack)
    {
        //2011/12/21 ADD by SS Maureen 新增發票年月欄位
        this.txtInvYM.Attributes.Add("style", "ime-mode:disabled;");
        this.txtInvYM.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtInvYM.Attributes.Add("onblur", "txtInvYM_onBlur(this);");
        this.txtInvYM.Attributes.Add("onfocus", "txtInvYM_onFocus(this);");
    }
  }

  //2011/11/25 Add發票日期 by SS Maureen
  /// <summary>
  /// 發票日期的查詢條件
  /// </summary>
  /// <returns></returns>
  private String GenerateQueryCon()
  {
      String LSTR_QueryCon;
      try
      {
          LSTR_QueryCon = "";

          //發票日期起迄-起
          if (!String.IsNullOrEmpty(this.txtINVDATES.Text.Trim()))
          {
              LSTR_QueryCon += ",";
              LSTR_QueryCon += "'" + Itg.Community.Util.GetADYear(this.txtINVDATES.Text.Trim().Replace("/", "")) + "'";
          }
          else
          {
              LSTR_QueryCon += ",";
              LSTR_QueryCon += "'20010101'";
          }
          //發票日期起迄-迄
          if (!String.IsNullOrEmpty(this.txtINVDATEE.Text.Trim()))
          {
              LSTR_QueryCon += ",";
              LSTR_QueryCon += " '" + Itg.Community.Util.GetADYear(this.txtINVDATEE.Text.Trim().Replace("/", "")) + "'";
          }
          else
          {
              LSTR_QueryCon += ",";
              LSTR_QueryCon += "'99991231'";
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
      return LSTR_QueryCon;
  }

  /// <summary>
  /// 清除畫面
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdClear_Click(object sender, EventArgs e)
  {
      this.txtINVNOS.Text = "";
      this.txtINVNOE.Text = "";
      this.txtINVDATES.Text = "";
      this.txtINVDATEE.Text = "";
      this.txtInvYM.Text = "";
  }

  //ADD BY HANK 20170328 列印報表(新)
  protected void cmdPrintReportNew_Click(object sender, EventArgs e)
  {
      JObject reader;

      try
      {
          JObject objML4011_E = null;
          objML4011_E = GetPostData("ML4011_E");

          List<JObject> objList = new List<JObject>();
          if (objML4011_E != null) { objList.Add(objML4011_E); }

          //執行報表產生API
          SSRSReport report = new SSRSReport();
          reader = report.GetRPTPDF_BY_API(objList);

          if (reader["Result"].ToString() == "True")
          {
              string fileUrl = reader["FileUrl"].ToString();
              JArray PDFPATH = JsonConvert.DeserializeObject<JArray>(fileUrl);

              RegisterScript("window.open('" + PDFPATH[0] + "');");
          }
          else
          {
              Alert(reader["Message"].ToString());
              return;
          }
      }
      catch (Exception ex)
      {
          Alert(ex.Message);
      }
  }

  //ADD BY HANK 20170328 產出ReportParam
  private JObject GetPostData(string reportId)
  {
      JObject json = new JObject(
          new JProperty("reportPath", "/LE/Report/"),
          new JProperty("reportId", reportId),
          new JProperty("reportType", new JArray("PDF")),
          new JProperty("reportVar",
              new JArray(
              new JObject(
                  new JProperty("column", "INVYYYYMM"),
                  new JProperty("value", txtInvYM.Text.Replace("/", ""))
              ),
              new JObject(
                  new JProperty("column", "CHECKPRTFLG"),
                  new JProperty("value", "N")
              ),
              new JObject(
                  new JProperty("column", "INVNOS"),
                  new JProperty("value", txtINVNOS.Text)
              ),
              new JObject(
                  new JProperty("column", "INVNOE"),
                  new JProperty("value", txtINVNOE.Text)
              ),
              new JObject(
                  new JProperty("column", "INVDATES"),
                  new JProperty("value", txtINVDATES.Text)
              ),
              new JObject(
                  new JProperty("column", "INVDATEE"),
                  new JProperty("value", txtINVDATEE.Text)
              ))));

      return json;
  }
  protected void txtInvYM_TextChanged(object sender, EventArgs e)
  {
      //20171215 ADD BY SS ADAM REASON.增加判斷是否可以列印
      if (txtInvYM.Text != "")
      {
          if (int.Parse(txtInvYM.Text.Replace("/", "")) <= 201712)
          {
              cmdPrintReport.Enabled = true;
              cmdPrintReportNew.Enabled = false;
          }
          else
          {
              cmdPrintReport.Enabled = false;
              cmdPrintReportNew.Enabled = true;
          }
      }
  }
}
