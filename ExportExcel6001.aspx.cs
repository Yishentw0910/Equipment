using System;
using System.Data;
using System.IO;
using System.Text;
using Itg.Community;
using ITG.Community;
using Comus;
using System.Text;
using System.Net;

public partial class ExportExcel6001 : System.Web.UI.Page {

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
	//john 2013/04/17 重新查詢
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    DataTable LDAT_Data = new DataTable();
    String LSTR_QueryCon;
    try
    {
        LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
        //取得查詢條件
        LSTR_QueryCon = Request["QC"];
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

        LVAR_Parameter[0] = "SP_ML6001_Q05";
        LVAR_Parameter[1] = LSTR_QueryCon;

        LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (LOBJ_Return.ReturnSuccess)
        {
           
            LDAT_Data = LOBJ_Return.ReturnData;          
            
            
        }   
    }
    catch (Exception ex)
    {
        throw ex;
    }   
    DataTable LOBJ_DataTable = LDAT_Data;

    LSTR_Data.Append("<STYLE>").Append("\n");
    LSTR_Data.Append("div { text-align:  center; }").Append("\n");
    LSTR_Data.Append("table { border-top: solid 1px #C0C0C0;  border-left: solid 1px #C0C0C0; }").Append("\n");
    LSTR_Data.Append("td {font-family: 細明體; font-size:10pt; vertical-align:top;  text-align:center; border-right: solid 1px #C0C0C0;  border-bottom: solid 1px #C0C0C0; }").Append("\n");
    LSTR_Data.Append("</STYLE>").Append("\n");
    LSTR_Data.Append("<table border=0 cellspacing=0 cellpadding=4>").Append("\n");

    LSTR_Data.Append("<tr>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("案件編號").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("合約編號").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("案件狀態").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("作業流程").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("營業單位").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承業業代").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//20160421 Modify by Sean 新增「CR業代」欄位
	//=================================================================================================
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("CR業代").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//20160421 Modify by Sean 新增「客戶統編」欄位
	//=================================================================================================
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("客戶統編").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("客戶名稱").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作型態").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作型態細分").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("實收資本額").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//20130517 Modify by Sean 新增「上市櫃」、「設備狀態」、「標的物種類」、「保險費 」、「供應商」欄位
	//=================================================================================================
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("上市櫃").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("設備狀態").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");	
	
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("標的物種類").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	//=================================================================================================

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("交易型態").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("標的物金額").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("頭期款").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("租購/履約保證金").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("實貸金額").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("承作月數").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("月付款").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("IRR").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
    
    //20140717 ADD BY SS ADAM REASON.增加NPV
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("NPV").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	//20130517 Modify by Sean 新增「上市櫃」、「設備狀態」、「標的物種類」、「保險費 」、「供應商」欄位
	//=================================================================================================
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("保險費").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("供應商").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");	
	//=================================================================================================
	
    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("進件日").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("核准日").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("合約起租日").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

	LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("合約到期日").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");

    LSTR_Data.Append("<th>").Append("\n");
    LSTR_Data.Append("擔保價值").Append("\n");
    LSTR_Data.Append("</th>").Append("\n");
	
    LSTR_Data.Append("</tr>").Append("\n");
    foreach (DataRow LOBJ_DataRow in LOBJ_DataTable.Rows) {
      LSTR_Data.Append("<tr>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CASEID"].ToString()).Append("</td>").Append("\n");
	  LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CNTRNO"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["STATUS"].ToString()).Append("</td>").Append("\n");      
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CASESTATUSNM"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["DEPTIDNM"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["EMPLNM"].ToString()).Append("</td>").Append("\n");
	  
	  // 20160421 Modify by Sean 新增「CR業代」欄位
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CREMPLNM"].ToString()).Append("</td>").Append("\n");

	  // 20160421 Modify by Sean 新增「客戶統編」欄位
	  LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CUSTID"].ToString()).Append("</td>").Append("\n");

      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CUSTNAME"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["MAINTYPENM"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["SUBTYPENM"].ToString()).Append("</td>").Append("\n");

	  // 20131118 Leo 新增實收資本額
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CUSTNOWCAPTIAL"].ToString()).Append("</td>").Append("\n");
	  
      //20130517 Modify by Sean 新增「上市櫃」、「設備狀態」、「標的物種類」、「保險費 」、「供應商」欄位
      //=================================================================================================
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["LISTEDNM"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["TARGETSTATUS"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["TARGETTYPE"].ToString()).Append("</td>").Append("\n");
      //=================================================================================================

      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["TRANSTYPENM"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["AMOUNT"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["FIRSTPAY"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["PURCHASEMARGIN"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["ACTUALLYAMOUNT"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["CONTRACTMONTH"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["PRINCIPALTAX"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["IRR"].ToString()).Append("</td>").Append("\n");
      //20140717 ADD BY SS ADAM REASON.增加NPV
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["NPV"].ToString()).Append("</td>").Append("\n");
      
      //20130517 Modify by Sean 新增「上市櫃」、「設備狀態」、「標的物種類」、「保險費 」、「供應商」欄位
      //=================================================================================================
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["INSURANCE"].ToString()).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(LOBJ_DataRow["COMPNM"].ToString()).Append("</td>").Append("\n");
      //=================================================================================================

      LSTR_Data.Append("<td>").Append(Util.GetADYear(LOBJ_DataRow["V2DATE"].ToString())).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(Util.GetADYear(LOBJ_DataRow["V5DATE"].ToString())).Append("</td>").Append("\n");
	  
      LSTR_Data.Append("<td>").Append(Util.GetADYear(LOBJ_DataRow["RENTSTDT"].ToString())).Append("</td>").Append("\n");
      LSTR_Data.Append("<td>").Append(Util.GetADYear(LOBJ_DataRow["RENTENDT"].ToString())).Append("</td>").Append("\n");

      // 20131118 Leo 新增擔保價值
      if (LOBJ_DataRow["CNTRNO"].ToString() == "")
        LSTR_Data.Append("<td>").Append(LOBJ_DataRow["GUANVALUE1"].ToString()).Append("</td>").Append("\n");
	  else
          LSTR_Data.Append("<td>").Append(LOBJ_DataRow["GUANVALUE2"].ToString()).Append("</td>").Append("\n");

      LSTR_Data.Append("</tr>").Append("\n");
    }

    LSTR_Data.Append("</table>");

    StringWriter strwriter = new StringWriter();
    FileStream fs = new FileStream(Server.MapPath("Temp\\" + GSTR_U_USERID + ".xls"), FileMode.Create);
    try {
      Byte[] bContent = System.Text.Encoding.GetEncoding("utf-8").GetBytes(LSTR_Data.ToString());
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
