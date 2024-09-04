using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;

public partial class ExportExcel : System.Web.UI.Page {

  public string GSTR_U_USERID = "";

  protected void Page_Load(object sender, EventArgs e) {
    string LSTR_Type = Request["type"];
    string LSTR_Code = Request["code"];
    if (Session["USERID"] != null) GSTR_U_USERID = Session["USERID"].ToString();
    //===== for 測試Menu =====
    if (GSTR_U_USERID == "") GSTR_U_USERID = "02321";
    //========================             

    string strScript;
    System.Type stType = null;
    stType = typeof(string);
    strScript = "<script language='Javascript'>PrintData();</script>";
    this.ClientScript.RegisterStartupScript(stType, "print", strScript);

    exportDataTableToExcel(LSTR_Type, LSTR_Code);
  }

  private void exportDataTableToExcel(string LSTR_Type, string LSTR_Code) {
    StringBuilder LSTR_Data = new StringBuilder("");
    DataTable LOBJ_DataTable = (DataTable)Session[LSTR_Code];

    if (LSTR_Type == "1") {
      LSTR_Data.Append("<STYLE>").Append("\n");
      LSTR_Data.Append("div { text-align:  center; }").Append("\n");
      LSTR_Data.Append("table { border-top: solid 1px #C0C0C0;  border-left: solid 1px #C0C0C0; }").Append("\n");
      LSTR_Data.Append("td {font-family: 細明體; font-size:10pt; vertical-align:top;  text-align:center; border-right: solid 1px #C0C0C0;  border-bottom: solid 1px #C0C0C0; }").Append("\n");
      LSTR_Data.Append("</STYLE>").Append("\n");
      LSTR_Data.Append("<table border=0 cellspacing=0 cellpadding=4>").Append("\n");

      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("合約編號").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("客戶統編").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("客戶名稱").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("營業單位").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("承案業代").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th colspan='4'>").Append("\n");
      LSTR_Data.Append("供應商").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("存款金額").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("借款金額").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("</tr>").Append("\n");
      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("統一編號").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("公司名稱").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("業代ID").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("業代姓名").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("</tr>").Append("\n");
      foreach (DataRow LOBJ_DataRow in LOBJ_DataTable.Rows) {
        LSTR_Data.Append("<tr>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CNTRNO"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CUSTID"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CUSTNAME"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPTIDNM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["EMPLNM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DSUPPLIER"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERIDS"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERSALE"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERSALENM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPOSITLOANSAMOUNT0"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPOSITLOANSAMOUNT1"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("</tr>").Append("\n");
      }

      LSTR_Data.Append("</table>");
    } else if (LSTR_Type == "2") {
      LSTR_Data.Append("<STYLE>").Append("\n");
      LSTR_Data.Append("div { text-align:  center; }").Append("\n");
      LSTR_Data.Append("table { border-top: solid 1px #C0C0C0;  border-left: solid 1px #C0C0C0; }").Append("\n");
      LSTR_Data.Append("td {font-family: 細明體; font-size:10pt; vertical-align:top;  text-align:center; border-right: solid 1px #C0C0C0;  border-bottom: solid 1px #C0C0C0; }").Append("\n");
      LSTR_Data.Append("</STYLE>").Append("\n");
      LSTR_Data.Append("<table border=0 cellspacing=0 cellpadding=4>").Append("\n");

      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<th colspan='4'>").Append("\n");
      LSTR_Data.Append("供應商").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("營業單位").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("承業業代").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("存款金額").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan='2'>").Append("\n");
      LSTR_Data.Append("借款金額").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th rowspan=2'>").Append("\n");
      LSTR_Data.Append("合計").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("</tr>").Append("\n");
      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("統一編號").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("公司名稱").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("業代ID").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("<th>").Append("\n");
      LSTR_Data.Append("業代姓名").Append("\n");
      LSTR_Data.Append("</th>").Append("\n");
      LSTR_Data.Append("</tr>").Append("\n");
      foreach (DataRow LOBJ_DataRow in LOBJ_DataTable.Rows) {
        LSTR_Data.Append("<tr>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DSUPPLIER"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERIDS"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERSALE"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUPPLIERSALENM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPTIDNM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["EMPLNM"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPOSITLOANSAMOUNT0"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPOSITLOANSAMOUNT1"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPOSITLOANSAMOUNT"].ToString()).Append("</td>").Append("\n");
        LSTR_Data.Append("</tr>").Append("\n");
      }

      LSTR_Data.Append("</table>");
    }
    StringWriter strwriter = new StringWriter();
    FileStream fs = new FileStream(Server.MapPath("Temp\\" + GSTR_U_USERID + ".xls"), FileMode.Create);
    try {
      Byte[] bContent = System.Text.Encoding.GetEncoding("big5").GetBytes(LSTR_Data.ToString());
      fs.Write(bContent, 0, bContent.Length);
    } catch (Exception ex) {
      Response.Write(ex.Message);
    } finally {
      fs.Close();
      fs.Dispose();
    }
    string attachment = "attachment; filename=ExportData.xls";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/vnd.ms-excel";
    Response.WriteFile("Temp\\" + GSTR_U_USERID + ".xls");
    Response.Flush();
    Response.End();
  }
}
