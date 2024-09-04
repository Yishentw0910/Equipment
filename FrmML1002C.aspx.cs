using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITG.Community;
using System.Data;
public partial class FrmML1002C : Itg.Community.PageBase
{
  string strQueryType = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    strQueryType = Request.QueryString["query"].ToString();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "客戶案件查詢";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML1002C";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML1002C";
    //========================             
    Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
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
  protected void btnQuery_Click(object sender, EventArgs e)
  {
    string LSTR_CustID = this.txtCustomerID.Text;
    string LSTR_CustName = this.txtCustomerName.Text;
    string LSTR_Query = "";
    if (this.txtCustomerID.Text.Trim() == "" && this.txtCustomerName.Text.Trim() == "" && this.txtCaseID.Text.Trim() == "" && this.txtStartDate.Text.Trim() == "" && this.txtEndDate.Text.Trim() == "")
    {
      Alert("請輸入查詢條件！");
      return;
    }

    if (LSTR_CustID != "")
    {
      LSTR_Query += " AND MLMCUSTOMER.CUSTID=''''" + LSTR_CustID + "'''' ";
    }

    if (LSTR_CustName != "")
    {
      LSTR_Query += " AND MLMCUSTOMER.CUSTNAME like ''''%" + LSTR_CustName + "%'''' ";
    }
    //案件編號
    if (!String.IsNullOrEmpty(this.txtCaseID.Text.Trim()))
    {
      LSTR_Query += " AND  MLMCASE.CASEID = ''''" + this.txtCaseID.Text.Trim() + "''''";
    }
    //進件日起迄-起
    if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim()))
    {
      LSTR_Query += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''''2'''' ORDER BY VERIFYID DESC ) >= ''''" + this.txtStartDate.Text.Trim() + "''''";
    }
    //進件日起迄-迄
    if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
    {
      LSTR_Query += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCASE].[CASEID] AND VERIFYSTATUS=''''2'''' ORDER BY VERIFYID DESC ) < ''''" + Itg.Community.Util.AddDay(this.txtEndDate.Text.Trim(), 1) + "''''";
    }
    rptCaseBind(LSTR_Query);
  }

  private void rptCaseBind(string LSTR_Query)
  {
    try
    {
      string LSTR_QueryM = "";
      if (Request.QueryString["query"] == "insert")
      {
      }
      else if (Request.QueryString["query"] == "S")
      {
      }
      else if (Request.QueryString["query"] == "U")
      {
        LSTR_QueryM = " AND CASESTATUS IN (''''1'''',''''4C'''') ";
      }
      else
      {
        LSTR_QueryM = " AND CASESTATUS = ''''" + Request.QueryString["query"] + "'''' ";
        if (Request.QueryString["query"] == "5") {
          LSTR_QueryM += " AND NOT EXISTS(SELECT * FROM MLMCONTRACT A WHERE A.CASEID = MLMCASE.CASEID)";
        }
      }
      //單位類別: A 管理  X: 營業
      if (GSTR_DEPTTYPE == "A")
      {
      }
      else
      {
        //主管等級: X1 協理(A內勤預設) , X2  長租X部經理,   X3 處長(等同助理) , X4 業代
        if (GSTR_MANGLEV == "X1")
        {
        }
        else if (GSTR_MANGLEV == "X2")
        {
		  //2014.04.28 EDIT BY SEAN 修正部經理查部門案件邏輯 
		  //部經理掌管處別字串  
          //GSTR_MANGDEPT.Replace(",", "'''',''''");
          //LSTR_QueryM += "AND MLMCASE.DEPTID IN (''''" + GSTR_U_USERID.Trim() + "'''')";
		  // 一般租賃部
		  if (GSTR_DEPTID.Trim() == "XDG0" || GSTR_DEPTID.Trim() == "XDH0" ||
		      GSTR_DEPTID.Trim() == "XDI0" || GSTR_DEPTID.Trim() == "XDK0" ||
			  GSTR_DEPTID.Trim() == "XDL0")
		  {
			LSTR_QueryM += "AND MLMCASE.DEPTID IN (''''XDG0'''',''''XDH0'''',''''XDI0'''',''''XDK0'''',''''XDL0'''')";
		  }
		  // 長租一部
		  else if (GSTR_DEPTID.Trim() == "XDA0" || GSTR_DEPTID.Trim() == "XDB0" ||
	               GSTR_DEPTID.Trim() == "XDE0" || GSTR_DEPTID.Trim() == "XDF0")
		  {
			LSTR_QueryM += "AND MLMCASE.DEPTID IN (''''XDA0'''',''''XDB0'''',''''XDE0'''',''''XDF0'''')";
		  }
		  // 長租二部
		  else
		  {
			LSTR_QueryM += "AND MLMCASE.DEPTID IN (''''XDC0'''',''''XDD0'''',''''XDJ0'''')";
		  }
          Alert("部門 : "  + GSTR_MANGDEPT);
        }
        else if (GSTR_MANGLEV == "X3")
        {
          LSTR_QueryM += "AND MLMCASE.DEPTID = ''''" + GSTR_DEPTID.Trim() + "''''";
        }
        else if (GSTR_MANGLEV == "X4")
        {
          LSTR_QueryM += "AND MLMCASE.EMPLID = ''''" + GSTR_U_USERID.Trim() + "''''";
        }
      }
      ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByCon(LSTR_QueryM + LSTR_Query);
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
        if (LDST_Data.Tables[0].Rows.Count == 0)
        {
          Alert("查無資料");
        }
        this.rptCase.DataSource = LDST_Data;
        this.rptCase.DataBind();
      }
      else
      {
        this.rptCase.DataSource = null;
        this.rptCase.DataBind();
        Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }

  private ReturnObject<DataSet> GetCaseDataByCon(string LSTR_QueryCon)
  {
    Comus.HtmlSubmitControl LOBJ_Submit;
    string LSTR_ObjId;

    ReturnObject<DataSet> LOBJ_Return;
    string[] LVAR_Parameter = new string[2];
    try
    {
      LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
      //子行業別drpSUBLEASEUNIONID
      string LSTR_StoreProcedure = "SP_ML1002_Q02" + GSTR_RowDelimitChar;
      string LSTR_QueryCondition = LSTR_QueryCon + GSTR_ColDelimitChar + GSTR_RowDelimitChar;

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure;
      LVAR_Parameter[1] = LSTR_QueryCondition;
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LOBJ_Return;
  }
}
