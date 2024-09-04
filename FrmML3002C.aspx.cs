using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITG.Community;
using System.Data;
public partial class FrmML3002C : Itg.Community.PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "撥款案件查詢";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML3002C";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML3002C";
    //========================             
    Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
  }
  protected void btnQuery_Click(object sender, EventArgs e)
  {
    string LSTR_CustID = this.txtCustomerID.Text;
    string LSTR_CustName = this.txtCustomerName.Text;
    string LSTR_Query = "";
    if (this.txtCustomerID.Text.Trim() == "" && this.txtCustomerName.Text.Trim() == "" && this.txtCaseID.Text.Trim() == "" && this.txtCNTRNO.Text.Trim() == "" && this.txtStartDate.Text.Trim() == "" && this.txtEndDate.Text.Trim() == "")
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
    //合約編號
    if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()))
    {
      LSTR_Query += " AND  MLMCONTRACT.CNTRNO = ''''" + this.txtCNTRNO.Text.Trim() + "''''";
    }
    ///撥款核准日起迄-起
    if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim()))
    {
      LSTR_Query += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''''9'''' ORDER BY VERIFYID DESC ) >= ''''" + this.txtStartDate.Text.Trim() + "''''";
    }
    ///撥款核准日起迄-迄
    if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
    {
      LSTR_Query += " AND  (SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''''9'''' ORDER BY VERIFYID DESC ) < ''''" + Itg.Community.Util.AddDay(this.txtEndDate.Text.Trim(), 1) + "''''";
    }
    if (Request.QueryString["query"] == "S")
    {
      LSTR_Query += " AND MLMCONTRACT.CASESTATUS IN (''''7'''',''''8'''',''''9'''',''''9A'''') ";
    }
    else if (Request.QueryString["query"] == "U")
    {
        LSTR_Query += " AND MLMCONTRACT.CASESTATUS IN (''''6'''',''''7'''',''''8'''') ";
    }
    else
    {
        LSTR_Query += " AND MLMCONTRACT.CASESTATUS IN (''''6'''',''''8C'''') ";
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
        //部經理掌管處別字串  
        GSTR_MANGDEPT.Replace(",", "'''',''''");
        LSTR_Query += "AND MLMCONTRACT.DEPTID IN (''''" + GSTR_U_USERID.Trim() + "'''')";
      }
      else if (GSTR_MANGLEV == "X3")
      {
        LSTR_Query += "AND MLMCONTRACT.DEPTID = ''''" + GSTR_DEPTID.Trim() + "''''";
      }
      else if (GSTR_MANGLEV == "X4")
      {
        LSTR_Query += "AND MLMCONTRACT.CREMPLID = ''''" + GSTR_U_USERID.Trim() + "''''";
      }
    }
    rptCaseBind(LSTR_Query);
  }
  private void rptCaseBind(string LSTR_Query)
  {
    try
    {
      ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByCon(LSTR_Query);
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
        if (LDST_Data.Tables[0].Rows.Count == 0)
        {
          this.rptCase.DataSource = null;
          this.rptCase.DataBind();
          Alert("查無資料");
        }
        else
        {
          this.rptCase.DataSource = LDST_Data;
          this.rptCase.DataBind();
        }
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
      string LSTR_StoreProcedure = "SP_ML3001_Q02" + GSTR_RowDelimitChar;
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
