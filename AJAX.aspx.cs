using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITG.Community;
using Itg.Community;
using System.Text;

//20121015 modify by Brent 修改資料對象
//20121126 Add by Maureen Reason:取得申請書案號

public partial class AJAX : PageBase {
  protected void Page_Load(object sender, EventArgs e) {
    if (IsOutOfBand()) {
      return;
    }
  }
  private bool IsOutOfBand() {
    bool isCallback = false;
    isCallback = String.Equals(Page.Request.QueryString["outofband"], "true", StringComparison.OrdinalIgnoreCase);
    if (isCallback) {
      string LSTR_Param = Request.QueryString["param"].ToString();
      string LSTR_Method = Request.QueryString["method"].ToString();
      string LSTR_Return = "";
      if (LSTR_Method == "GetCustName") {
        LSTR_Return = GetCustName(LSTR_Param);}
       else if (LSTR_Method == "GetCustName2"){
        LSTR_Return = GetCustName2(LSTR_Param);
      }else if (LSTR_Method == "GetACCOMFRV") {
        LSTR_Return = GetACCOMFRV(LSTR_Param);
      } else if (LSTR_Method == "GetSUBTYPEDataById") {
        LSTR_Return = GetSUBTYPEDataById(LSTR_Param);
      } else if (LSTR_Method == "GetCaseInfo") {
        LSTR_Return = GetCaseInfo(LSTR_Param);
      } else if (LSTR_Method == "GetContractInfo") {
        LSTR_Return = GetContractInfo(LSTR_Param);
      } else if (LSTR_Method == "GetSupplier") {
        LSTR_Return = GetSupplier(LSTR_Param);
      } else if (LSTR_Method == "GetINVCode") {
        LSTR_Return = GetINVCode(LSTR_Param);
      } else if (LSTR_Method == "GetINVNOPRT") {
        LSTR_Return = GetINVNOPRT(LSTR_Param);
      } else if (LSTR_Method == "GetML3002Rpt") {
        LSTR_Return = GetML3002Rpt(LSTR_Param);
      } else if (LSTR_Method == "GetCNTRTarget") {
        LSTR_Return = GetCNTRTarget(LSTR_Param);
      }
      //20121015 modify by Brent 修改資料對象
      else if (LSTR_Method == "GetCustomName")  {
          LSTR_Return = GetCustomName(LSTR_Param);
      }
      //20121126 Add by Maureen Reason:取得申請書案號
      else if (LSTR_Method == "GetCaseID")
      {
          LSTR_Return = GetCaseID(LSTR_Param);
      }
        //20160322 ADD BY SS ADAM REASON.增加行業別
      else if (LSTR_Method == "GetInduName")
      {
          LSTR_Return = GetInduName(LSTR_Param);
      }
      Response.Clear();
      Response.Write(LSTR_Return);
      Response.Flush();
      Response.End();
      return true;
    }
    return false;
  }
    private string GetCustName(string LSTR_CUSTID)
    {
        String LSTR_ObjId = "";
        Comus.HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string LSTR_Result;
        String LSTR_ExtraCon;
        try
        {
            LSTR_Result = "";
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            LSTR_ExtraCon = "";
            LSTR_ExtraCon += " AND CUSTID = ''" + LSTR_CUSTID.Trim() + "''";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "dbo.SP_ML1001_Q02";
            LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                LSTR_Result = LOBJ_Return.ReturnData.Rows[0][1].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LSTR_Result;
    }

    //20221031 若長租有資料從長租帶資料
    private string GetCustName2(string LSTR_CUSTID)
    {
        String LSTR_ObjId = "";
        Comus.HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string LSTR_Result;
        String LSTR_ExtraCon;
        try
        {
            LSTR_Result = "";
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            LSTR_ExtraCon = "";
            LSTR_ExtraCon += LSTR_CUSTID.Trim();
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "dbo.SP_ML1001_Q08";
            LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                LSTR_Result = LOBJ_Return.ReturnData.Rows[0][1].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LSTR_Result;
    }


    //20121015 modify by Brent 修改資料對象
    private string GetCustomName(string LSTR_CUSTID)
  {
      String LSTR_ObjId = "";
      Comus.HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;
      string LSTR_Result;
      String LSTR_ExtraCon;
      try
      {
          LSTR_Result = "";
          LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
          LSTR_ExtraCon = "";
          LSTR_ExtraCon += " AND CUSTID = ''" + LSTR_CUSTID.Trim() + "''";
          LOBJ_Submit = new Comus.HtmlSubmitControl();
          LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
          LVAR_Parameter[0] = "dbo.SP_ML6003_Q04";
          LVAR_Parameter[1] = "'" + LSTR_CUSTID + "','" + "" + "','" + "0" + "','" + "0" + "'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              LSTR_Result = LOBJ_Return.ReturnData.Rows[0][1].ToString();
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
      return LSTR_Result;
  }
  private string GetACCOMFRV(string LSTR_ID) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    try {

      string LSTR_DLRCD = LSTR_ID.Split('-')[0];
      string LSTR_COMPID = LSTR_ID.Split('-')[1];

      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "dbo.SP_ML0001_Q08";
      LVAR_Parameter[1] = "'" + LSTR_DLRCD + "','" + LSTR_COMPID + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = "";
        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][0].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][1].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][2].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][3].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][4].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][5].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][6].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_Return.ReturnData.Rows[i][7].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += GSTR_RowDelimitChar;
        }
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetSUBTYPEDataById(string LSTR_MAINTYPEID) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataSet> LOBJ_Return;
    StringBuilder LSTR_StoreProcedure = new StringBuilder();
    StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
    string LSTR_Result;
    string LSTR_MAINTYPE;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
      LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      if (LSTR_MAINTYPEID == "01") {
        LSTR_MAINTYPE = "01";
      } else {
        LSTR_MAINTYPE = "02";
      }
      LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + LSTR_MAINTYPE + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);

      if (LOBJ_Return.ReturnSuccess) {
        DataSet LOBJ_DataSet = LOBJ_Return.ReturnData;
        DataView LOBJ_DataView = LOBJ_DataSet.Tables[0].DefaultView;
        LSTR_Result = "";
        for (int i = 0; i < LOBJ_DataView.Count; i++) {
          LSTR_Result += LOBJ_DataView[i][0].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_DataView[i][1].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += GSTR_RowDelimitChar;
        }
        LSTR_Result += GSTR_ParDelimitChar;
        LOBJ_DataView = LOBJ_DataSet.Tables[1].DefaultView;
        for (int i = 0; i < LOBJ_DataView.Count; i++) {
          LSTR_Result += LOBJ_DataView[i][0].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += LOBJ_DataView[i][1].ToString() + GSTR_ColDelimitChar;
          LSTR_Result += GSTR_RowDelimitChar;
        }
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetCaseInfo(string LSTR_CASEID) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    String LSTR_ExtraCon;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      LSTR_ExtraCon = "";
      LSTR_ExtraCon += " AND CASEID = ''" + LSTR_CASEID.Trim() + "''";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "dbo.SP_ML1002_Q02";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = "";
        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          for (int j = 0; j < LOBJ_Return.ReturnData.Rows[0].ItemArray.Length; j++) {
            LSTR_Result += LOBJ_Return.ReturnData.Rows[i][j].ToString() + GSTR_ColDelimitChar;
          }
          LSTR_Result += GSTR_RowDelimitChar;
        }
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetContractInfo(string LSTR_CNTRNO) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    String LSTR_ExtraCon;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      LSTR_ExtraCon = "";
      LSTR_ExtraCon += " AND CNTRNO = ''" + LSTR_CNTRNO.Trim() + "''";
      LSTR_ExtraCon += " AND MLMCONTRACT.CASESTATUS In(''7'',''8'',''9'',''9A'')";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "dbo.SP_ML3001_Q03";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "',''";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = "";
        for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
          for (int j = 0; j < LOBJ_Return.ReturnData.Rows[0].ItemArray.Length; j++) {
            LSTR_Result += LOBJ_Return.ReturnData.Rows[i][j].ToString() + GSTR_ColDelimitChar;
          }
          LSTR_Result += GSTR_RowDelimitChar;
        }
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetSupplier(string LSTR_SupplierID) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    String LSTR_ExtraCon;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LSTR_ExtraCon = "";
      LSTR_ExtraCon += " AND COMPID = ''" + LSTR_SupplierID + "''";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q07";
      LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = LOBJ_Return.ReturnData.Rows[0]["COMPNM"].ToString();
      } else {
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetINVCode(string LSTR_ID) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    try {
      string LSTR_INVID = LSTR_ID.Split('-')[0];
      string LSTR_INVYM = LSTR_ID.Split('-')[1];
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q09";
      LVAR_Parameter[1] = "'" + LSTR_INVYM + "','" + LSTR_INVID + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = LOBJ_Return.ReturnData.Rows[0]["INVID"].ToString();
      } else {
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetINVNOPRT(string LSTR_INVNO) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML4011_Q01";
      LVAR_Parameter[1] = "'" + LSTR_INVNO + "','','','N'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = LOBJ_Return.ReturnData.Rows[0]["INVNO"].ToString();
      } else {
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetML3002Rpt(string LSTR_Data) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML3005_Q01";
      LVAR_Parameter[1] = LSTR_Data;
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = LOBJ_Return.ReturnData.Rows[0]["CNTRNO"].ToString();
      } else {
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  private string GetCNTRTarget(string LSTR_CNTRNO) {
    String LSTR_ObjId = "";
    Comus.HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;
    string LSTR_Result;
    try {
      LSTR_Result = "";
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML4020_Q03";
      LVAR_Parameter[1] = "'" + LSTR_CNTRNO + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess) {
        LSTR_Result = "";
        if (LSTR_CNTRNO.Length == 14) {
          for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
            string LSTR_UNITID = LOBJ_Return.ReturnData.Rows[i]["UNITID"].ToString().Trim();
            LSTR_Result += LSTR_UNITID + "*";
          }
        } else {
          for (int i = 0; i < LOBJ_Return.ReturnData.Rows.Count; i++) {
            string LSTR_UNITID = LOBJ_Return.ReturnData.Rows[i]["UNITID"].ToString().Trim();
            LSTR_Result += LSTR_CNTRNO + LSTR_UNITID.Substring(LSTR_UNITID.Length - 2, 2) + "*";
          }
        }
      } else {
      }
    } catch (Exception ex) {
      throw ex;
    }
    return LSTR_Result;
  }
  
  //20121126 Add by Maureen Reason:取得申請書案號
  private string GetCaseID(string LSTR_CNTRNO)
  {
      String LSTR_ObjId = "";
      Comus.HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;
      string LSTR_Result;
      String LSTR_ExtraCon;
      try
      {
          LSTR_Result = "";
          LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
          LSTR_ExtraCon = "";
          LSTR_ExtraCon += " AND CNTRNO = ''" + LSTR_CNTRNO.Trim() + "''";
          LOBJ_Submit = new Comus.HtmlSubmitControl();
          LOBJ_Submit.VirtualPath = GetComusVirtualPath();
          LVAR_Parameter[0] = "dbo.SP_ML3001_Q01";
          LVAR_Parameter[1] = "'" + LSTR_ExtraCon + "'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              LSTR_Result = LOBJ_Return.ReturnData.Rows[0][1].ToString();
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
      return LSTR_Result;
  }

    //20160322 ADD BY SS ADAM REASON.取得行業別名稱
  private string GetInduName(string LSTR_INDUID)
  {
      String LSTR_ObjId = "";
      Comus.HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;
      string LSTR_Result;
      try
      {
          LSTR_Result = "";
          LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
          
          LOBJ_Submit = new Comus.HtmlSubmitControl();
          LOBJ_Submit.VirtualPath = GetComusVirtualPath();
          LVAR_Parameter[0] = "dbo.SP_ML1001_Q07";
          LVAR_Parameter[1] = "'" + LSTR_INDUID + "'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              LSTR_Result = LOBJ_Return.ReturnData.Rows[0]["INDUNM"].ToString();
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
      return LSTR_Result;
  }
}
