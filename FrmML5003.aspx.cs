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


public partial class FrmML5003 : PageBase
{
  public string ASTR_SysDate = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      GetUsrAndFuncInfo();
      ASTR_SysDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
      //===== for 測試Menu =====
      if (GSTR_PROGNM == "") GSTR_PROGNM = "客服回件作業";
      if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5003";
      if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5003";
      //========================             
      if (!IsPostBack)
      {
        //綁定公司別下拉
        drpCompIDBind();
        //綁定部門別下拉
        ddlDEPTIDBind();
        ddlBACKMODE.Enabled = false;
      }
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
    //txtCustID.Attributes.Add("Readonly", "True");
    txtCustName.Attributes.Add("Readonly", "True");
    //Modify 20140224 By SS Eric Reason:增加退件狀態檢核條件
    ddlBACKMODE.Attributes["onchange"] = "ddlBACKMODEChange();";
    drpReturn.Attributes["onchange"] = "drpReturnChange();";

    //txtCHECKDATE1.Attributes["onchange"] = "txtCHECKDATE1Change();";
    //txtCNTRNODATE1.Attributes["onchange"] = "txtCNTRNODATE1Change();";
    //txtSALESDATE1.Attributes["onblur"] = "txtSALESDATE1Change();";
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
        //Modify 20140220 By SS Eric Reason:增加檢核條件
        if (drpCheckDate.SelectedValue == "0")
        {
            if ((txtCHECKDATE.Text == "" && txtCHECKDATE1.Text == "") && (txtCNTRNODATE.Text == "" && txtCNTRNODATE1.Text == "") && (txtSALESDATE.Text == "" && txtSALESDATE1.Text == ""))
            {
                Alert("客服點件日起迄、客服回件日起迄、營業處傳遞日起迄需3擇一必填!!");
                return;
            }
        }
        if (drpReturn.SelectedValue == "0")
        {
            if ((txtCHECKDATE.Text == "" && txtCHECKDATE1.Text == "") && (txtCNTRNODATE.Text == "" && txtCNTRNODATE1.Text == "") && (txtSALESDATE.Text == "" && txtSALESDATE1.Text == ""))
            {
                Alert("客服點件日起迄、客服回件日起迄、營業處傳遞日起迄需3擇一必填!!");
                return;
            }
        }
      //查詢並綁定畫面Grid資料
      this.rptDataBind();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
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
        for (int i = 0; i < LDAT_Data.Rows.Count; i++)
        {
		  // 2014.04.02 EDIT BY SEAN 修改回件天數為(營業單位傳遞日-撥款確認日)
		  if (LDAT_Data.Rows[i]["XDRETUNCONFIRMDATE"].ToString() != "" )
          {
            ((Label)this.rptData.Items[i].FindControl("lblMDAY")).Text = LDAT_Data.Rows[i]["XDRETUNCONFIRMDATE"].ToString();
          }
          /*
		  if (LDAT_Data.Rows[i]["RENTSTDT"].ToString() != "")
          {
            DateTime LDAT_RENTSTDT = Convert.ToDateTime(LDAT_Data.Rows[i]["RENTSTDT"].ToString());
            TimeSpan LDAT_Time = DateTime.Now - LDAT_RENTSTDT;
            ((Label)this.rptData.Items[i].FindControl("lblMDAY")).Text = LDAT_Time.Days.ToString();
          }
          */

          if (LDAT_Data.Rows[i]["RETUNCONFIRM0"].ToString() == "1" && LDAT_Data.Rows[i]["RETUNCONFIRM2"].ToString() == "2")
          {
            ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked = true;
            ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled = false;
          }
          else if (LDAT_Data.Rows[i]["RETUNCONFIRM2"].ToString() == "1")
          {
            if (LDAT_Data.Rows[i]["RETUNCONFIRM0"].ToString() == "1")
            {
              ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked = true;
            }
            ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled = false;
          }
          else
          {
          }
        }
        if (drpCheckDate.SelectedValue == "2")//未點件
        {
          btnSave.Enabled = true;
        }
        else
        {
          btnSave.Enabled = false;

        }

      }
      else
      {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
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
      //客服回件
      if (!String.IsNullOrEmpty(this.drpReturn.SelectedValue.Trim()))
      {
          //20140331 EDIT BY SEAN 修改客服邏輯
		  if (this.drpReturn.SelectedValue.Trim() == "2")
		  {
		      LSTR_QueryCon += " AND RETUNCONFIRM2 = ''" + this.drpReturn.SelectedValue.Trim() + "''";
			  LSTR_QueryCon += " AND MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') ";
          	  //增加排除掉未傳遞的案件檢核
          	  LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM=''1'') ";
		  }
		  else
		  {
              //20140331 EDIT BY SEAN 修改退件狀態邏輯
			  if (!String.IsNullOrEmpty(this.ddlBACKMODE.SelectedValue.Trim()))
              {
                  if (this.ddlBACKMODE.SelectedValue.Trim() == "1")
                  {
					  LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS=''9A'' AND MLMRETURNDOC.RETUNCONFIRM2 = '''')";
                  }
                  else if (this.ddlBACKMODE.SelectedValue.Trim() == "2")
                  {
                      LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') AND MLMRETURNDOC.RETUNCONFIRM1 = ''1'')";
					  //增加排除掉未傳遞的案件檢核
					  LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM=''1'') ";
				  }
              }
			  else
			  {
				  LSTR_QueryCon += " AND RETUNCONFIRM2 = ''" + this.drpReturn.SelectedValue.Trim() + "''";
				  LSTR_QueryCon += " AND MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') ";
				  //增加排除掉未傳遞的案件檢核  
				  LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM=''1'') "; 
			  }
			  
		  }

		  //20140331 MARK BY SEAN 修改退件狀態邏輯
		  //LSTR_QueryCon += " AND  RETUNCONFIRM2 = ''" + this.drpReturn.SelectedValue.Trim() + "''";
	  }
	  //20140331 EDIT BY SEAN 修改客服邏輯
	  else
	  {
	  	  LSTR_QueryCon += " AND MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') ";
	  	  //20140331 MARK BY SEAN 修改退件狀態邏輯
	  	  //增加排除掉未傳遞的案件檢核
	  	  LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM=''1'') ";
	  }
	  
      //客服點件
      if (!String.IsNullOrEmpty(this.drpCheckDate.SelectedValue.Trim()))
      {
          LSTR_QueryCon += " AND  RETUNCONFIRM0 = ''" + this.drpCheckDate.SelectedValue.Trim() + "''";
      }
      //回件申請日
      if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
      {
          LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE1,112) >= ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
          LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE1,112) <= ''" + this.txtCNTRNODATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
          if (!String.IsNullOrEmpty(this.txtCNTRNODATE.Text.Trim()))
          {
              LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE1,112)  = ''" + this.txtCNTRNODATE.Text.Trim().Replace("/", "") + "''";
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtCNTRNODATE1.Text.Trim()))
              {
                  LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE1,112) = ''" + this.txtCNTRNODATE1.Text.Trim().Replace("/", "") + "''";
              }
          }
      }
      
      //20140331 MARK BY SEAN 修改退件狀態邏輯
	  //LSTR_QueryCon += " AND MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'') ";

      //Modify 20140221 By SS Eric Reason:增加查詢條件
      //部門別
      if (!String.IsNullOrEmpty(this.ddlDEPTID.SelectedValue.Trim()))
      {
          LSTR_QueryCon += " AND  MLMCONTRACT.DEPTID = ''" + this.ddlDEPTID.SelectedValue.Trim() + "''";
      }
      //客服點件日起迄
      if (!String.IsNullOrEmpty(this.txtCHECKDATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtCHECKDATE1.Text.Trim()))
      {
          LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE0,112) >= ''" + this.txtCHECKDATE.Text.Trim().Replace("/", "") + "''";
          LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE0,112) <= ''" + this.txtCHECKDATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
          if (!String.IsNullOrEmpty(this.txtCHECKDATE.Text.Trim()))
          {
              LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE0,112)  = ''" + this.txtCHECKDATE.Text.Trim().Replace("/", "") + "''";
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtCHECKDATE1.Text.Trim()))
              {
                  LSTR_QueryCon += " AND  CONVERT(VARCHAR(8),RETUNCONFIRMDATE0,112) = ''" + this.txtCHECKDATE1.Text.Trim().Replace("/", "") + "''";
              }
          }
      }
      //20140331 MARK BY SEAN 修改退件狀態邏輯
	  //退件狀態
      //if (!String.IsNullOrEmpty(this.ddlBACKMODE.SelectedValue.Trim()))
      //{
      //    if (this.ddlBACKMODE.SelectedValue.Trim() == "1")
      //    {
      //        LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS=''14'' AND MLMRETURNDOC.RETUNCONFIRM2 = ''2'')";
      //    }
      //    else if (this.ddlBACKMODE.SelectedValue.Trim() == "2")
      //    {
      //        LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS=''11'' AND MLMRETURNDOC.RETUNCONFIRM1 = ''1'')";
      //    }
      //    else
      //    {
      //        LSTR_QueryCon += " AND (MLMRETURNDOC.CASESTATUS IN (''11'',''12'',''13'',''14'') AND MLMRETURNDOC.RETUNCONFIRM1 = ''1'' AND MLMRETURNDOC.RETUNCONFIRM2 = ''2'')";
      //    }
      //}
      //營業處傳遞日起迄
      if (!String.IsNullOrEmpty(this.txtSALESDATE.Text.Trim()) && !String.IsNullOrEmpty(this.txtSALESDATE1.Text.Trim()))
      {
          LSTR_QueryCon += " AND CONVERT(VARCHAR(8),TRANSDATE,112) >= ''" + this.txtSALESDATE.Text.Trim().Replace("/", "") + "''";
          LSTR_QueryCon += " AND CONVERT(VARCHAR(8),TRANSDATE,112) <= ''" + this.txtSALESDATE1.Text.Trim().Replace("/", "") + "''";
      }
      else
      {
          if (!String.IsNullOrEmpty(this.txtSALESDATE.Text.Trim()))
          {
              LSTR_QueryCon += " AND (SELECT MAX(TRANSDATE) FROM MLMRETURNDOC WHERE CNTRNO=[MLMCONTRACT].[CNTRNO])  = ''" + this.txtSALESDATE.Text.Trim().Replace("/", "") + "''";
          }
          else
          {
              if (!String.IsNullOrEmpty(this.txtSALESDATE1.Text.Trim()))
              {
                  LSTR_QueryCon += " AND (SELECT MAX(TRANSDATE) FROM MLMRETURNDOC WHERE CNTRNO=[MLMCONTRACT].[CNTRNO]) = ''" + this.txtSALESDATE1.Text.Trim().Replace("/", "") + "''";
              }
          }
      }

      //20140331 MARK BY SEAN 修改退件狀態邏輯
      //增加排除掉未傳遞的案件檢核
      //LSTR_QueryCon += " AND (MLMRETURNDOC.TRANSCONFIRM=''1'') ";
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }
  protected void btnSave_Click(object sender, EventArgs e)
  {
    string LSTR_Data = GetUpdateDate();
    try
    {
      ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess)
      {
        Alert("點件完成！");
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
  private string GetUpdateDate()
  {
    bool LBOL_Save = false;
    StringBuilder LSTR_Data = new StringBuilder();
    for (int i = 0; i < this.rptData.Items.Count; i++)
    {
      if (((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Checked == true && ((CheckBox)rptData.Items[i].FindControl("chkcheckDate")).Enabled == true)
      {
        //案件主鍵
        string LSTR_RETUNID = ((HiddenField)rptData.Items[i].FindControl("hidRETUNID")).Value;
        LSTR_Data.Append("SP_ML5001_U03" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        LSTR_Data.Append(ASTR_SysDate + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        LBOL_Save = true;
      }
    }
    if (!LBOL_Save)
    {
      Alert("請至少選擇一筆合約處理！");
      return "";
    }
    //=========================================================================            
    LSTR_Data = LSTR_Data.Replace("'", "’");
    LSTR_Data = LSTR_Data.Replace("\"", "”");
    LSTR_Data = LSTR_Data.Replace("--", "－－");
    //========================================================================= 
    return LSTR_Data.ToString();
  }

  /// <summary>
  /// 綁定部門別下拉
  /// </summary>
  private void ddlDEPTIDBind()
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
          LVAR_Parameter[1] = "'LE','16','T'";
          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
          if (LOBJ_Return.ReturnSuccess)
          {
              //綁定數據
              this.ddlDEPTID.DataSource = LOBJ_Return.ReturnData;
              this.ddlDEPTID.DataValueField = "MCODE";
              this.ddlDEPTID.DataTextField = "MNAME1";
              this.ddlDEPTID.DataBind();
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

  //Modify 20140224 By SS Eric Reason:增加下載excel按鈕
  protected void btnExport_Click(object sender, EventArgs e)
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

          LVAR_Parameter[0] = "SP_ML5003_Q01";
          LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);

          if (LOBJ_Return.ReturnSuccess)
          {
              //綁定數據
              DataTable LDAT_Data = LOBJ_Return.ReturnData;
              DataTable LOBJ_TData = LDAT_Data.Copy();

              GridView GridView1 = new GridView();
              GridView1.DataSource = LOBJ_TData;
              GridView1.DataBind();

              //設定EXCEL表頭中文
              GridView1.HeaderRow.Cells[0].Text = "傳遞日";
              GridView1.HeaderRow.Cells[1].Text = "點件日";
              GridView1.HeaderRow.Cells[2].Text = "客服回件日";
              GridView1.HeaderRow.Cells[3].Text = "合約編號";
              GridView1.HeaderRow.Cells[4].Text = "客戶名稱";
              GridView1.HeaderRow.Cells[5].Text = "部門";
              GridView1.HeaderRow.Cells[6].Text = "業代";
              GridView1.HeaderRow.Cells[7].Text = "承作類型";
              GridView1.HeaderRow.Cells[8].Text = "標的物種類";
              GridView1.HeaderRow.Cells[9].Text = "承作金額";
              GridView1.HeaderRow.Cells[10].Text = "月付租金";
              GridView1.HeaderRow.Cells[11].Text = "起租日";
              GridView1.HeaderRow.Cells[12].Text = "迄租日";
              GridView1.HeaderRow.Cells[13].Text = "撥款確認日";
              GridView1.HeaderRow.Cells[14].Text = "營業處回件天數";
              GridView1.HeaderRow.Cells[15].Text = "客服回件天數";
              GridView1.HeaderRow.Cells[16].Text = "客服上次退件日";
              GridView1.HeaderRow.Cells[17].Text = "退件回件日";
              GridView1.HeaderRow.Cells[18].Text = "期數";

              Response.Clear();
              Response.Buffer = true;
              Response.Charset = "UTF-8";
              Response.AppendHeader("Content-Disposition", "attachment;filename=ML5003.xls");
              Response.ContentEncoding = System.Text.Encoding.UTF8;
              Response.ContentType = "application/ms-excel";
              System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
              System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
              GridView1.RenderControl(oHtmlTextWriter);
              Response.Output.Write(oStringWriter.ToString());
              Response.Flush();
              Response.End();
          }
          else
          {
              Alert("查無資料");
          }
      }
      catch (Exception ex)
      {
          throw ex;
      }
  }
}
