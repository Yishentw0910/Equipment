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
using System.Collections.Specialized;
using System.IO;


public partial class FrmML5001 : PageBase
{
  public string ASTR_SysDate = "";  //UPD BY VICKY 20140221 系統日(有時間)
  public string S_SysDate = "";     //UPD BY VICKY 20140221 系統日(沒時間)

  public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
  public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
  public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
  public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
  public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
  public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];

  
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      ASTR_SysDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); //UPD BY VICKY 20140221 系統日
      S_SysDate = DateTime.Now.ToString("yyyy/MM/dd");
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "回件作業(營業單位)";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5001";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5001";
      //========================             
      Itg.Community.Util.GetUserRights(GSTR_U_USERID, GSTR_DEPTID);
      if (!IsPostBack)
      {
          //綁定公司別下拉
          drpCompIDBind();
          //綁定部門別下拉
          //drpDeptIDBind();       
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
    txtAgency.Attributes.Add("Readonly", "True");
    txtCustName.Attributes.Add("Readonly", "True");
    drpTransStatus.Attributes["onchange"] = "TransStatusChange();";   //UPD BY VICKY 20140221 [傳遞狀態]連動[列印回件簽收單] js function
    if (this.drpTransStatus.SelectedValue == "Y") this.cmdPRINT.Enabled = true;
    
    if (this.drpTransStatus.SelectedValue == "N") 
	{
		this.txtTRANSDATE.Enabled = false;
		this.txtTRANSDATE1.Enabled = false;
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
              Alert("'" + LOBJ_Return.ReturnErrNum + "':" + LOBJ_Return.ReturnMessage);
              //            Alert(LOBJ_Return.ReturnErrNum);

              //          Alert("查無資料");
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
  }

  /*   
  private void drpDeptIDBind()
  {
    String LSTR_ObjId;
    HtmlSubmitControl LOBJ_Submit;
    String[] LVAR_Parameter = new String[2];
    ReturnObject<DataTable> LOBJ_Return;

    try
    {
      LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
      //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
      LVAR_Parameter[0] = "SP_ML0001_Q02";
      LVAR_Parameter[1] = "'ML','16','T'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.drpDeptID.DataSource = LOBJ_Return.ReturnData;
        this.drpDeptID.DataValueField = "MCODE";
        this.drpDeptID.DataTextField = "MNAME1";
        this.drpDeptID.DataBind();
      }
      else
      {
        //Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  } 
  */
  
  /// <summary>
  /// 查詢案件資料
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      //查詢並綁定畫面Grid資料
      this.rptDataBind();
      if (drpTransStatus.SelectedValue == "Y") { cmdPRINT.Enabled = true; }
      else { cmdPRINT.Enabled = false; }

    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }


    protected void cmdALL_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptData.Items.Count; i++)
        {
            CheckBox chk = rptData.Items[i].FindControl("chkcheckDate") as CheckBox;
            Label lbl = rptData.Items[i].FindControl("lblTRANSDATE") as Label;


            chk.Checked = true;
            lbl.Text = S_SysDate;
        }
    }

    protected void cmdNOTALL_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptData.Items.Count; i++)
        {
            CheckBox chk = rptData.Items[i].FindControl("chkcheckDate") as CheckBox;
            Label lbl = rptData.Items[i].FindControl("lblTRANSDATE") as Label;


            chk.Checked = false;
            lbl.Text = "";
        }
    }

    /// <summary>
    /// 綁定畫面Grid數據
    /// </summary>
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
      LSTR_QueryCon = this.GenerateQueryCon();
      //查詢資料
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

      LVAR_Parameter[0] = "SP_ML5001_Q01";
      LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        this.rptData.DataSource = LOBJ_Return.ReturnData;
        this.rptData.DataBind();

        DataTable LDAT_Data = LOBJ_Return.ReturnData;
        string strCASESTATUS = "";

        for (int i = 0; i < LDAT_Data.Rows.Count; i++)
        {
          if (LDAT_Data.Rows[i]["PAYCONFIRMDATE"].ToString() != "")
          {
            DateTime LDAT_RENTSTDT = Convert.ToDateTime(LDAT_Data.Rows[i]["PAYCONFIRMDATE"].ToString());
            TimeSpan LDAT_Time = DateTime.Now - LDAT_RENTSTDT;
            ((Label)this.rptData.Items[i].FindControl("lblMDAY")).Text = LDAT_Time.Days.ToString();
          }

          //UPD BY VICKY 20140221 GRID傳遞日確認
          strCASESTATUS = LDAT_Data.Rows[i]["CASESTATUS"].ToString();
          if (strCASESTATUS == "11" || strCASESTATUS == "12" || strCASESTATUS == "13" || LDAT_Data.Rows[i]["CNTRCASESTATUS"].ToString()=="9A")  //已回件
          {
              if (LDAT_Data.Rows[i]["TRANSCONFIRM"].ToString() == "1")  //已傳遞確認
              {
                  ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked = true;
                  ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled = false;
              }
              else
              {
                  ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked = false;
                  ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled = true;
              }
          }
          else  //未回件
          {
             ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked = false;
             ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled = false;
          }
        }

        if (drpCaseStatus.SelectedValue == "Y" && drpTransStatus.SelectedValue=="N")  //UPD BY VICKY 20140221 已回件且未傳遞才可選擇下方[全選][取消全選]
        {
            cmdALL.Enabled = true;
            cmdNOTALL.Enabled = true;
            cmdSURE.Enabled = true;
        }
        else
        {
            cmdALL.Enabled = false;
            cmdNOTALL.Enabled = false;
            cmdSURE.Enabled = false;
        }
      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();

        //UPD BY VICKY 20140221 查無資料時,無作用故鎖定
        cmdALL.Enabled = false;
        cmdNOTALL.Enabled = false;
        cmdSURE.Enabled = false;

        Alert("查無資料");
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  /// <summary>
  /// 組合畫面的查詢條件
  /// </summary>
  /// <returns></returns>
  private String GenerateQueryCon()
  {
    String LSTR_QueryCon;
    try
    {
      LSTR_QueryCon = "";

      //部門別
      if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()))
      {
          LSTR_QueryCon += " AND  MLMCONTRACT.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
      }
      //業代名
      if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.EMPLID = ''" + this.txtAgency.Text.Trim() + "''";
      }
      //合約編號
      if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCONTRACT.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
      }
      //客戶統編
      if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.CUSTID = ''" + this.txtCustID.Text.Trim() + "''";
      }
      //客戶名稱
      if (!String.IsNullOrEmpty(this.txtCustName.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCUSTOMER.CUSTNAME LIKE ''" + this.txtCustName.Text.Trim() + "%''";
      }
      //撥款日
      if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
      {
        LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) >= ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
        LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) <= ''" + this.txtCNTRNODATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
          if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()))
          {
            LSTR_QueryCon += " AND CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) = ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
              {
                LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),(SELECT TOP 1 VERIFDATE FROM MLVERIFY WHERE CASEIDID=[MLMCONTRACT].[CNTRNO] AND VERIFYSTATUS=''9'' ORDER BY VERIFYID DESC ),112) = ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
              }
          }
      }
      //起租日
      if (!String.IsNullOrEmpty(this.txtRENTSTDT.Text.Trim()))
      {
        LSTR_QueryCon += " AND MLMCONTRACT.RENTSTDT = ''" + Itg.Community.Util.GetADYear(this.txtRENTSTDT.Text.Trim()) + "''";
      }
      //案件核准日
      if (!String.IsNullOrEmpty(this.txtCASEDATE.Text.Trim()))
      {
        LSTR_QueryCon += " AND MLMCASE.U_SYSDT = ''" + Itg.Community.Util.GetADYear(this.txtCASEDATE.Text.Trim()) + "''";
      }

      //20120531 MODIFY BY SSF MAUREEN REASON:修改查詢條件(已回件或未回件)
      //LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''10'',''14'') OR MLMCONTRACT.CASESTATUS = ''9'')";

      if (this.drpCaseStatus.SelectedValue.Trim() == "Y")//已回件
      {
          LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') OR MLMCONTRACT.CASESTATUS = ''9A'')";
      }
      else if (this.drpCaseStatus.SelectedValue.Trim() == "N")//未回件
      {
          LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''10'',''14'') OR MLMCONTRACT.CASESTATUS = ''9'')";
      }
      else if (this.drpCaseStatus.SelectedValue.Trim() == "")//已回件&未回件
      {
          LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''10'',''11'',''12'',''13'',''14'') OR MLMCONTRACT.CASESTATUS IN (''9'',''9A''))";
      }

      //UPD BY VICKY 20140221 新增[傳遞狀態]查詢欄位
      if (this.drpTransStatus.SelectedValue.Trim() == "Y")//已傳遞
      {
          LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM = ''1'')";
      }
      else //未傳遞
      {
          LSTR_QueryCon += " AND (ISNULL(MLMRETURNDOC.TRANSCONFIRM,'''')='''' OR MLMRETURNDOC.TRANSCONFIRM=''2'')";
      }

	  //UPD BY SEAN 20140505 新增[傳遞日]查詢欄位
      //傳遞日
      if (!String.IsNullOrEmpty(this.txtTRANSDATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtTRANSDATE1.Text.Trim()))
      {
        LSTR_QueryCon += " AND CONVERT(VARCHAR(8),MLMRETURNDOC.TRANSDATE,112) >= ''" + this.txtTRANSDATE.Text.Trim().Replace("/", "") + "''";
        LSTR_QueryCon += " AND CONVERT(VARCHAR(8),MLMRETURNDOC.TRANSDATE,112) <= ''" + this.txtTRANSDATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
          if (!String.IsNullOrEmpty(this.txtTRANSDATE.Text.Trim()))
          {
            LSTR_QueryCon += " AND CONVERT(VARCHAR(8),MLMRETURNDOC.TRANSDATE,112) = ''" + this.txtTRANSDATE.Text.Trim().Replace("/", "") + "''";
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtTRANSDATE1.Text.Trim()))
              {
                LSTR_QueryCon += " AND CONVERT(VARCHAR(8),MLMRETURNDOC.TRANSDATE,112) = ''" + this.txtTRANSDATE1.Text.Trim().Replace("/", "") + "''";
              }
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
          //部經理掌管處別字串  
          GSTR_MANGDEPT.Replace(",", "'',''");
          LSTR_QueryCon += "AND MLMCONTRACT.DEPTID IN (''" + GSTR_U_USERID.Trim() + "'')";
        }
        else if (GSTR_MANGLEV == "X3")
        {
          LSTR_QueryCon += "AND MLMCONTRACT.DEPTID = ''" + GSTR_DEPTID.Trim() + "''";
        }
        else if (GSTR_MANGLEV == "X4")
        {
          LSTR_QueryCon += "AND MLMCONTRACT.CREMPLID = ''" + GSTR_U_USERID.Trim() + "''";
        }
      }

    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }

    //UPD BY VICKY 20140221 傳遞狀態及傳遞日期存檔
    protected void cmdSURE_Click(object sender, EventArgs e)
    {
        if (CHECK_DATA())
        {
            SAVE_DATA();
        }
    }

    //檢核至少勾選一筆傳遞日確認
    private bool CHECK_DATA()
    {
        int chkcount = 0;
        for (int i = 0; i < rptData.Items.Count; i++)
        {
            if (((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked == true && ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled == true) chkcount += 1;
        }

        if (chkcount == 0) { RegisterScript("alert('請至少選擇一筆！');"); return false; } //沒有勾選
        return true;
    }

    private void SAVE_DATA()
    {
        StringBuilder LSTR_Data = new StringBuilder();
        string strCNTRNO = ""; //UPD BY VICKY 20140317 串起合約編號,列印用

        for (int i = 0; i < this.rptData.Items.Count; i++)
        {
            if (((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked == true && ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled == true)
            {
                LSTR_Data.Append("SP_ML5001_U04" + GSTR_ColDelimitChar);
                LSTR_Data.Append(((Label)rptData.Items[i].FindControl("lblRETUNID")).Text + GSTR_TabDelimitChar);
                LSTR_Data.Append(ASTR_SysDate + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT);
                LSTR_Data.Append(GSTR_ColDelimitChar);
                LSTR_Data.Append(GSTR_RowDelimitChar);

                strCNTRNO += ((Label)rptData.Items[i].FindControl("lblCNTRNO")).Text + ",";  //UPD BY VICKY 20140317 串起合約編號,列印用
            }
        }

         //=========================================================================
            LSTR_Data = LSTR_Data.Replace("'", "’");
            LSTR_Data = LSTR_Data.Replace("\"", "”");
            LSTR_Data = LSTR_Data.Replace("--", "－－");
        //=========================================================================
        try 
        {
            ReturnObject<object> LOBJ_ReturnObject = SaveInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess) 
            {
               //RegisterScript("alert('傳遞日確認完成！');window.close();");
               //UPD BY VICKY 20140317 存檔後自動列印
               strCNTRNO = strCNTRNO.Substring(0, strCNTRNO.Length - 1);
               //RegisterScript("alert('" + strCNTRNO + "')");
               RegisterScript("alert('傳遞日確認完成！');cmdPrintA_onClick('cmdPRINT', '" + strCNTRNO + "');window.close();");
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

        try
        {
            //查詢並綁定畫面Grid資料
            this.rptDataBind();
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }

    private ReturnObject<object> SaveInfo(string LSTR_Data)
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

    protected void cmdPRINT_OnClick(object sender, EventArgs e)
    {
        //RegisterScript("cmdPrintA_onClick('cmdPRINT')");

        //UPD BY VICKY 20140317 因為合約編號要帶有勾選傳遞日期的合約編號,故必須先查詢
        if (rptData.Items.Count == 0)
        {
            RegisterScript("alert('列印前請先查詢！');");
        }
        else
        {
            string strCNTRNO = "";
            for (int i = 0; i < rptData.Items.Count; i++)
            {
                if (((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked == true)
                {
                    strCNTRNO += ((Label)rptData.Items[i].FindControl("lblCNTRNO")).Text+ ",";
                }
            }
            strCNTRNO = strCNTRNO.Substring(0, strCNTRNO.Length - 1);
            //RegisterScript("alert('" + strCNTRNO + "')");
            RegisterScript("cmdPrintA_onClick('cmdPRINT', '" + strCNTRNO + "')");
        }
    }
}
