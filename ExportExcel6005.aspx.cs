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

public partial class ExportExcel6005 : System.Web.UI.Page {

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

    LSTR_Data.Append("<STYLE>").Append("\n");
    LSTR_Data.Append("div { text-align:  center; }").Append("\n");
    LSTR_Data.Append("table { border-top: solid 1px #C0C0C0;  border-left: solid 1px #C0C0C0; }").Append("\n");
    LSTR_Data.Append("td {font-family: 細明體; font-size:10pt; vertical-align:top;  text-align:center; border-right: solid 1px #C0C0C0;  border-bottom: solid 1px #C0C0C0; }").Append("\n");
    LSTR_Data.Append("</STYLE>").Append("\n");
    LSTR_Data.Append("<table border=0 cellspacing=0 cellpadding=4>").Append("\n");

    LSTR_Data.Append("<tr>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("合約編號").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("客戶名稱").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("營業單位").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作業務").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("業代屬性").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("案件類型").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("案件狀況").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    // 20131118 Leo 新增實收資本額
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("實收資本額").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//2013.01.25  Edit by Sean 新增上市櫃公司、設備狀況、標的物種類、保險費欄位
    //=========================================================================
	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("上市櫃公司").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	
	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("設備狀況").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	
	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("標的物種類").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");	
    //=========================================================================

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作標的物").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("發票金額含稅").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("頭期款").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("租購保證金").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("履約保證金").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作期數").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("實撥金額").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("月付款").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("期款總額含稅").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("IRR").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");   

	//2015.11.30 EDIT BY Sean 新增NPV0(NPV)欄位
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("NPV").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//2017.01.06 MARK BY SEAN 移除(設備件NPV)、NPV2(融資件NPV)欄位
    //=========================================================================
	  //2015.02.02 EDIT BY Sean 新增及修改NPV(設備件NPV)、NPV2(融資件NPV)欄位
      //=========================================================================
      //LSTR_Data.Append("<th>").Append("\n");
      //LSTR_Data.Append("NPV").Append("\n");
      //LSTR_Data.Append("</th>").Append("\n");
    //LSTR_Data.Append("<th>").Append("\n");
    //LSTR_Data.Append("設備件NPV").Append("\n");
    //LSTR_Data.Append("</th>").Append("\n");
    //LSTR_Data.Append("<th>").Append("\n");
    //LSTR_Data.Append("融資件NPV").Append("\n");
    //LSTR_Data.Append("</th>").Append("\n");
    //=========================================================================
	
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("其他費用").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
                                              
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("發放佣金").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("殘值").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//2013.01.25  Edit by Sean 新增上市櫃公司、設備狀況、標的物種類、保險費欄位
    //=========================================================================
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("保險費").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
    //=========================================================================

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("撥款日/中止日").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("供應商").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	// 2012.03.06 Edit by Sean 新增交易型態
	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("交易型態").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("擔保價值").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("</tr>").Append("\n");
    foreach (DataRow LOBJ_DataRow in LOBJ_DataTable.Rows) {
      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["合約編號"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["客戶名稱"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["營業單位"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["承作業務"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["業代屬性"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["案件類型I"].ToString()).Append("/").Append(LOBJ_DataRow["案件類型II"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["案件狀況"].ToString()).Append("</td>").Append("\n");
      // 20131118 Leo 新增實收資本額
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["實收資本額"].ToString()).Append("</td>").Append("\n");

	  //2013.01.25  Edit by Sean 新增上市櫃公司、設備狀況、標的物種類、保險費欄位
      //=================================================================================================
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["上市櫃公司"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["設備狀況"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["標的物種類"].ToString()).Append("</td>").Append("\n");
      //=================================================================================================

      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["承作標的物"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["發票金額含稅"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["頭期款"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["租購保證金"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["履約保證金"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["租賃期數"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["實撥金額"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["月付租金"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["期款總額含稅"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["IRR"].ToString()).Append("</td>").Append("\n");

	  //2015.11.30 EDIT BY Sean 新增NPV0(NPV)欄位
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["NPV"].ToString()).Append("</td>").Append("\n");
	  
	  //2017.01.06 MARK BY SEAN 移除(設備件NPV)、NPV2(融資件NPV)欄位
      //=========================================================================
        //2015.02.02 EDIT BY Sean 新增及修改NPV(設備件NPV)、NPV2(融資件NPV)欄位
        //=========================================================================
        //LSTR_Data.Append("<td>").Append(LOBJ_DataRow["NPV"].ToString()).Append("</td>").Append("\n");
      //LSTR_Data.Append("<td>").Append(LOBJ_DataRow["設備件NPV"].ToString()).Append("</td>").Append("\n");
      //LSTR_Data.Append("<td>").Append(LOBJ_DataRow["融資件NPV"].ToString()).Append("</td>").Append("\n");
      //=========================================================================
	 
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["其它費用"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["發放佣金"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["殘值"].ToString()).Append("</td>").Append("\n");

      //2013.01.25  Edit by Sean 新增上市櫃公司、設備狀況、標的物種類、保險費欄位
      //=================================================================================================
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["保險費"].ToString()).Append("</td>").Append("\n");
      //=================================================================================================

      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["撥款日"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["供應商"].ToString()).Append("</td>").Append("\n");
	  // 2012.03.06 Edit by Sean 新增交易型態
	  LSTR_Data.Append("<td>").Append(LOBJ_DataRow["交易型態"].ToString()).Append("</td>").Append("\n");

      // 20131118 Leo 新增擔保價值
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["擔保價值"].ToString()).Append("</td>").Append("\n");

      LSTR_Data.Append("</tr>").Append("\n");
    }

    LSTR_Data.Append("</table>");

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
    //string attachment = "attachment; filename=Performance.xls";
	string attachment = "attachment; filename=SalesReport_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";    //Modify by Sean 2011.11.04
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/vnd.ms-excel";
    Response.WriteFile("Temp\\" + GSTR_U_USERID + ".xls");
    Response.Flush();
    Response.End();
  }
}
