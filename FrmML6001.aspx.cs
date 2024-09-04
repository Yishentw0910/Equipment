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
using System.Net;
/*
修改日期：
UPD BY BRENT 20130408新增查詢條件
UPD BY BRENT 20130408 承作型態II增加全部項目
UPD BY BRENT 20130408 新增案件狀態下拉事件
UPD BY Eric  20130416 將有效區分的欄位取消
UPD BY STEVEN 20130425 點選完成撥款，不需要系統自動帶出進件日期20010101~系統日(問題單)
UPD BY STEVEN 20130425 承作類型II預設值設定"全部"(冠廷要求)
*/
public partial class FrmML6001 : PageBase {
  protected void Page_Load(object sender, EventArgs e) {
    try {
      GetUsrAndFuncInfo();
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "案件/合約查詢";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6001";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6001";
      //========================             
      Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
      if (!IsPostBack) {
        //綁定公司別下拉
        drpCompIDBind();
        this.drpCompID.SelectedIndex = 2;
        //綁定部門別下拉
        drpDeptIDBind();
        //綁定承作類型I下拉
        drpMainTypeBind();
        if (this.drpMAINTYPE.SelectedValue == "*") {
          this.drpSUBTYPE.Enabled = false;
        } else {
          this.drpSUBTYPE.Enabled = true;
        }
        //綁定案件狀態下拉
        drpCASESTATUSBind();
      } else {
        this.txtCaseID.Enabled = true;
        this.txtCNTRNO.Enabled = true;
      }      
    } catch (Exception ex) {
      Alert(ex.Message);
    }
    txtAgency.Attributes.Add("Readonly", "True");
    txtCustName.Attributes.Add("Readonly", "True");
        Alert(GSTR_MANGLEV + " "+GSTR_DEPTTYPE);
  }
  /// <summary>
  /// 綁定公司別下拉
  /// </summary>
  private void drpCompIDBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    String LSTR_SYSID, LSTR_DataID;
    try {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
      LSTR_SYSID = System.Configuration.ConfigurationManager.AppSettings["SYSID"];
      LSTR_DataID = System.Configuration.ConfigurationManager.AppSettings["COMP_DATAID"];
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'" + LSTR_SYSID + "','" + LSTR_DataID + "','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LOBJ_DataTable = LOBJ_Return.ReturnData.Clone();
        DataRow LOBJ_DataRow;
        LOBJ_DataTable.Rows.Clear();
        LOBJ_DataRow = LOBJ_DataTable.NewRow();
        LOBJ_DataRow["MNAME1"] = "全部";
        LOBJ_DataRow["MCODE"] = "";
        LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["MCODE"] = LOBJ_Return.ReturnData.Rows[i]["MCODE"];
          LOBJ_DataRow["MNAME1"] = LOBJ_Return.ReturnData.Rows[i]["MNAME1"];
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);
        }
        this.drpCompID.DataSource = LOBJ_DataTable; 
        this.drpCompID.DataValueField = "MCODE";
        this.drpCompID.DataTextField = "MNAME1";
        this.drpCompID.DataBind();
      } else {
        //Alert("查無資料");
      }
    } catch (Exception ex) {
      throw ex;
    }
  }
  /// <summary>
  /// 綁定部門別下拉
  /// </summary>
  private void drpDeptIDBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    try {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'LE','16','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LOBJ_DataTable = LOBJ_Return.ReturnData.Clone();
        DataRow LOBJ_DataRow;
        LOBJ_DataTable.Rows.Clear();
        LOBJ_DataRow = LOBJ_DataTable.NewRow();
        LOBJ_DataRow["MNAME1"] = "全部";
        LOBJ_DataRow["MCODE"] = "";
        LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["MCODE"] = LOBJ_Return.ReturnData.Rows[i]["MCODE"];
          LOBJ_DataRow["MNAME1"] = LOBJ_Return.ReturnData.Rows[i]["MNAME1"];
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);
        }
        this.drpDeptID.DataSource = LOBJ_DataTable; 
        this.drpDeptID.DataValueField = "MCODE";
        this.drpDeptID.DataTextField = "MNAME1";
        this.drpDeptID.DataBind();
      } else {
        //Alert("查無資料");
      }
    } catch (Exception ex) {
      throw ex;
    }
  }
  /// <summary>
  /// 綁定承作類型I下拉
  /// </summary>
  private void drpMainTypeBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    try {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'LE','05','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LOBJ_DataTable = LOBJ_Return.ReturnData.Clone();
        DataRow LOBJ_DataRow;
        LOBJ_DataTable.Rows.Clear();
        LOBJ_DataRow = LOBJ_DataTable.NewRow();
        LOBJ_DataRow["MNAME1"] = "全部";
        LOBJ_DataRow["MCODE"] = "";
        LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["MCODE"] = LOBJ_Return.ReturnData.Rows[i]["MCODE"];
          LOBJ_DataRow["MNAME1"] = LOBJ_Return.ReturnData.Rows[i]["MNAME1"];
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);
        }
        this.drpMAINTYPE.DataSource = LOBJ_DataTable;
        this.drpMAINTYPE.DataValueField = "MCODE";
        this.drpMAINTYPE.DataTextField = "MNAME1";
        this.drpMAINTYPE.DataBind();
      } else {
        //Alert("查無資料");
      }
    } catch (Exception ex) {
      throw ex;
    }
  }
  /// <summary>
  /// 綁定承作類型I下拉
  /// </summary>
  private void drpCASESTATUSBind() {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    try {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'LE','21','F'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LOBJ_DataTable = LOBJ_Return.ReturnData.Clone();
        DataRow LOBJ_DataRow;
        LOBJ_DataTable.Rows.Clear();
        LOBJ_DataRow = LOBJ_DataTable.NewRow();
        LOBJ_DataRow["MNAME1"] = "全部";
        LOBJ_DataRow["MCODE"] = "";
        LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["MCODE"] = LOBJ_Return.ReturnData.Rows[i]["MCODE"];
          LOBJ_DataRow["MNAME1"] = LOBJ_Return.ReturnData.Rows[i]["MNAME1"];
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);
        }
        this.drpCASESTATUS.DataSource = LOBJ_DataTable;
        this.drpCASESTATUS.DataValueField = "MCODE";
        this.drpCASESTATUS.DataTextField = "MNAME1";
        this.drpCASESTATUS.DataBind();
      } else {
        //Alert("查無資料");
      }
    } catch (Exception ex) {
      throw ex;
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
      //公司別
      if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim())) {
        LSTR_QueryCon += "'" + this.drpCompID.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += "''";
      }
      //部門別
      if (!String.IsNullOrEmpty(this.drpDeptID.SelectedValue.Trim())) {
        LSTR_QueryCon += ",'" + this.drpDeptID.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //業代名
      if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtAgencyId.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //客戶名稱
      if (!String.IsNullOrEmpty(this.txtCustName.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCustName.Text.Trim() + "%'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //案件編號
      if (!String.IsNullOrEmpty(this.txtCaseID.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCaseID.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //合約編號
      if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtCNTRNO.Text.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }

      //進件日期-起
      if (!String.IsNullOrEmpty(this.txtStartDate1.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtStartDate1.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //進件日期-迄
      if (!String.IsNullOrEmpty(this.txtEndDate1.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate1.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //核准日期-起
      if (!String.IsNullOrEmpty(this.txtStartDate5.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtStartDate5.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //核准日期-迄
      if (!String.IsNullOrEmpty(this.txtEndDate5.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate5.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //合約到期日-起
      if (!String.IsNullOrEmpty(this.txtStartDate9.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtStartDate9.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }
      //合約到期日-迄
      if (!String.IsNullOrEmpty(this.txtEndDate9.Text.Trim())) {
        LSTR_QueryCon += ",'" + this.txtEndDate9.Text.Trim().Replace("/", "") + "'";
      } else {
        LSTR_QueryCon += ",''";
      }

      //承作類型I
      if (!String.IsNullOrEmpty(this.drpMAINTYPE.SelectedValue.Trim())) {
        LSTR_QueryCon += ",'" + this.drpMAINTYPE.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }

      //承作類型II
      if (!String.IsNullOrEmpty(this.drpSUBTYPE.SelectedValue.Trim())) {
        LSTR_QueryCon += ",'" + this.drpSUBTYPE.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }

      //案件狀態
      if (!String.IsNullOrEmpty(this.drpCASESTATUS.SelectedValue.Trim())) {
        LSTR_QueryCon += ",'" + this.drpCASESTATUS.SelectedValue.Trim() + "'";
      } else {
        LSTR_QueryCon += ",''";
      }


      LSTR_QueryCon += ",'" + GSTR_DEPTTYPE + "'";
      LSTR_QueryCon += ",'" + GSTR_MANGLEV + "'";
      LSTR_QueryCon += ",'" + GSTR_U_USERID.Trim() + "'";
      if (GSTR_MANGLEV == "X2") {
        GSTR_MANGDEPT.Replace(",", "''','''");
        LSTR_QueryCon += ",'" + GSTR_MANGDEPT.Trim() + "'";
      } else {
        LSTR_QueryCon += ",'" + GSTR_DEPTID.Trim() + "'";
      }
	  //UPD BY BRENT 20130408新增查詢條件 
      //財務撥款日-起
      if (!String.IsNullOrEmpty(this.txtSTVerifDate.Text.Trim()))
      {
          LSTR_QueryCon += ",'" + this.txtSTVerifDate.Text.Trim().Replace("/", "") + "'";
      }
      else
      {
          LSTR_QueryCon += ",''";
      }
      //財務撥款日-迄
      if (!String.IsNullOrEmpty(this.txtENVerifDate.Text.Trim()))
      {
          LSTR_QueryCon += ",'" + this.txtENVerifDate.Text.Trim().Replace("/", "") + "'";
      }
      else
      {
          LSTR_QueryCon += ",''";
      }
      //承作方式
      if (!String.IsNullOrEmpty(this.drpSOURCETYPE.SelectedValue.Trim()))
      {
          LSTR_QueryCon += ",'" + this.drpSOURCETYPE.SelectedValue.Trim() + "'";
      }
      else
      {
          LSTR_QueryCon += ",''";
      }
      //UPD BY Eric  20130416 將有效區分的欄位取消
      //有效區分
      //if (!String.IsNullOrEmpty(this.drpVALID.SelectedValue.Trim()))
      //{
      //    LSTR_QueryCon += ",'" + this.drpVALID.SelectedValue.Trim() + "'";
      //}
      //else
      //{
      //    LSTR_QueryCon += ",''";
      //}

    }
    catch (Exception ex)
    {
      throw ex;
    }

    //Alert(LSTR_QueryCon);
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

      LVAR_Parameter[0] = "SP_ML6001_Q01";
      LVAR_Parameter[1] = LSTR_QueryCon;

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        //綁定數據
        DataTable LDAT_Data = LOBJ_Return.ReturnData;
        //合約編號
        if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim())) {
          DataTable LDAT_Temp = LDAT_Data.Clone();
          DataRow[] LOBJ_Temp = LDAT_Data.Select("CNTRNO='" + this.txtCNTRNO.Text.Trim() + "'");
          foreach (DataRow LDRO_Temp in LOBJ_Temp) {
            LDAT_Temp.ImportRow(LDRO_Temp);
          }
          this.rptData.DataSource = LDAT_Temp;
          ViewState["Data"] = LDAT_Temp;

        } else {
          this.rptData.DataSource = LDAT_Data;
          ViewState["Data"] = LDAT_Data;
        }

        this.rptData.DataBind();


        //20130124 Modify by Maureen. Reason:新增掃描文件欄位

        string Files_Location = System.Configuration.ConfigurationManager.AppSettings["ML6001_Files"];

        for (int i = 0; i < LDAT_Data.Rows.Count; i++)
        {
            string LSTR_RENTYEAR = LDAT_Data.Rows[i]["RENTYEAR"].ToString();
            string LSTR_CNTRNO = LDAT_Data.Rows[i]["CNTRNO"].ToString();
            string SITE1 = Files_Location+LSTR_RENTYEAR+"/"+LSTR_CNTRNO+"-1.tif";
            string SITE2 = Files_Location+LSTR_RENTYEAR+"/"+LSTR_CNTRNO+"-2.tif";
            string SITE3 = Files_Location+LSTR_RENTYEAR+"/"+LSTR_CNTRNO+"-3.tif";
			
            //合約文件 		
			try
			{
				//20130412 ADD BY ADAM 為了減輕loadinad 把偵測動作移到js上處理
				//WebRequest request1 = WebRequest.Create(SITE1);
				//HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
				//if (response1.StatusCode == HttpStatusCode.OK)
				{
					((HiddenField)rptData.Items[i].FindControl("hdnEXIST1")).Value = SITE1;
					
				}
			}
			catch
			{
			
			}
			
            //擔保文件 		
			try
			{
				//20130412 ADD BY ADAM 為了減輕loadinad 把偵測動作移到js上處理
				//WebRequest request2 = WebRequest.Create(SITE2);
				//HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
				//if (response2.StatusCode == HttpStatusCode.OK)
				{
					((HiddenField)rptData.Items[i].FindControl("hdnEXIST2")).Value = SITE2;
				}
			}
			catch
			{
			
			}

            //客戶暨徵信資料 		
			try
			{
				//20130412 ADD BY ADAM 為了減輕loadinad 把偵測動作移到js上處理
				//WebRequest request3 = WebRequest.Create(SITE3);
				//HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
				//if (response3.StatusCode == HttpStatusCode.OK)
				{
					((HiddenField)rptData.Items[i].FindControl("hdnEXIST3")).Value = SITE3;
				}
			}
			catch
			{
			
			}
        }

        if (rptData.Items.Count == 0) {
          ViewState["Data"] = null;
          Alert("查無資料");
        }
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
  public string GetCOMPID(string LSTR_COMPID) {
    string LSTR_COMPName = "";
    for (int i = 0; i < drpCompID.Items.Count; i++) {
      if (drpCompID.Items[i].Value == LSTR_COMPID) {
        LSTR_COMPName = drpCompID.Items[i].Text;
      }
    }
    return LSTR_COMPName;
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
		//john 2013/4/17 加上查詢條件
        Response.Redirect("ExportExcel6001.aspx" + "?type=" + "1" + "&code=" + LSTR_Code+"&QC=" + Server.UrlEncode(this.GenerateQueryCon()));
        //RegisterScript("window.open('" + "ExportExcel.aspx" + "?type=" + this.drpQryType.SelectedValue + "&code=" + LSTR_Code + "');");        
      } else {
        Alert("下載EXCEL資料前，請先查詢出資料!");
      }
      //查詢並綁定畫面Grid資料      
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }

  protected void drpQryType_SelectedIndexChanged(object sender, EventArgs e) {
    drpCASESTATUSBind();
    ViewState["Data"] = null;
    this.rptData.DataSource = null;
    this.rptData.DataBind();
  }
  //UPD BY BRENT 20130408 新增案件狀態下拉事件
  protected void drpCASESTATUS_SelectedIndexChanged(object sender, EventArgs e)
  {
      if (drpCASESTATUS.SelectedValue == "4")
      {
          //UPD BY STEVEN 20130425 點選完成撥款，不需要系統自動帶出進件日期20010101~系統日(問題單)
          //this.txtStartDate1.Text = "2001/01/01";
          //this.txtEndDate1.Text = DateTime.Today.ToString("yyyy/MM/dd");
      }
      ViewState["Data"] = null;
      this.rptData.DataSource = null;
      this.rptData.DataBind();
  }
  protected void drpMAINTYPE_SelectedIndexChanged(object sender, EventArgs e)
  {
    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
    drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
    if (LSTR_MAINTYPEID == "*") {
      this.drpSUBTYPE.Enabled = false;
    } else {
      this.drpSUBTYPE.Enabled = true;
        //UPD BY STEVEN 20130425 承作類型II預設值設定"全部"(冠廷要求)
      this.drpSUBTYPE.SelectedValue = "";
    }
    ViewState["Data"] = null;
    this.rptData.DataSource = null;
    this.rptData.DataBind();
  }
  private void drpSUBTYPEaEXPIREPROCBindbyID(string LSTR_MAINTYPEID) {
    try {
      ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
      if (LOBJ_ReturnObject.ReturnSuccess) {
          DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

          //UPD BY BRENT 20130408 承作型態II增加全部項目
          DataTable LOBJ_DataTable = LDST_Data.Tables[0];
          DataRow LOBJ_DataRow;
          LOBJ_DataRow = LOBJ_DataTable.NewRow();
          LOBJ_DataRow["DNAME1"] = "全部";
          LOBJ_DataRow["DCODE"] = "";
          LOBJ_DataTable.Rows.Add(LOBJ_DataRow);

          this.drpSUBTYPE.DataSource = LOBJ_DataTable;
        this.drpSUBTYPE.DataBind();
      } else {
        Alert(LOBJ_ReturnObject.ReturnMessage);
      }
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
  private ReturnObject<DataSet> GetSUBTYPEDataById(string LSTR_MAINTYPEID) {

    Comus.HtmlSubmitControl LOBJ_Submit;
    string LSTR_ObjId;
    StringBuilder LSTR_StoreProcedure = new StringBuilder();
    StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
    ReturnObject<DataSet> LOBJ_Return;
    string[] LVAR_Parameter = new string[2];
    try {
      LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

      LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
    } catch (Exception ex) {
      throw ex;
    }
    return LOBJ_Return;
  }
  public string Handler(string LSTR_CASEID, string LSTR_CNTRNO)
  {
    if (LSTR_CNTRNO == "")
        {
            return LSTR_CASEID;
        }
        else
        {
            return LSTR_CNTRNO;
        }
  }
}
