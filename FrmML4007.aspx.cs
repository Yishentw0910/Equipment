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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic; 

public partial class FrmML4007 : PageBase
{
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
          this.txtINVODT.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
          this.hdnSystemDate.Value = System.DateTime.Now.ToString("yyyyMMdd");
          GetUsrAndFuncInfo();
          if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
          if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4007";
          if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4007";
          if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
          if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
          if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

          this.hdnLastMonth.Value = System.DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 7) + "/01").AddDays(-1).ToString("yyyyMMdd");

          //Vincent-20100817-Add for 畫面控制項屬性設定
          PageInitProcess();

          if (!IsPostBack)
          {
              //綁定公司別下拉
              drpCompIDBind();
              drpMainTypeBind();
              this.txtInvMonth.Text = System.DateTime.Now.ToString("yyyyMM");
              this.txtINVODT.Text = System.DateTime.Now.ToString("yyyy/MM/dd");              
          }
          else
          {
              this.txtCNTRNO.Text = Request.Form.GetValues("txtCNTRNO")[0];
              this.txtINVODT.Text = Request.Form.GetValues("txtINVODT")[0];
              if (this.txtCNTRNO.Text.Trim() != "")
              {
                  this.txtINVODT.ReadOnly = false;  
              }
              else
              {
                  this.txtINVODT.ReadOnly = true;
              }
              this.txtInvMonth.Text = Request.Form.GetValues("txtInvMonth")[0];
          }
          if (this.hdnRowCount.Value != "0")
          {
              this.cmdProc.Attributes.Remove("disabled");
              //                this.cmdPrint.Attributes.Add("disabled", "true");
              this.cmdProc.Enabled = true;
          }

      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }

    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtInvMonth.Attributes.Add("onblur", "txtInvMonth_onBlur(this);");
        this.txtInvMonth.Attributes.Add("onfocus", "txtInvMonth_onFocus(this);");
        this.cmdProc.Attributes.Add("disabled", "true");
        this.cmdPrint.Attributes.Add("disabled", "true");
        this.optLevel1.Attributes.Add("onclick", "RadioButton_onClick(this);");
        this.optLevel2.Attributes.Add("onclick", "RadioButton_onClick(this);");
        this.optLevel3.Attributes.Add("onclick", "RadioButton_onClick(this);");
        this.chkAll.Attributes.Add("onclick", "chkAll_onClick(this);");
    }

    /// <summary>
    /// 綁定公司別下拉
    /// </summary>
    private void drpCompIDBind()
    {
        String strObjId;
        HtmlSubmitControl objSubmit;
        String[] aryParameter = new String[2];
        ReturnObject<DataTable> objReturnObj;

        String strSYSID, strDataID;
        try
        {
            strObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            strSYSID = System.Configuration.ConfigurationManager.AppSettings["SYSID"];
            strDataID = System.Configuration.ConfigurationManager.AppSettings["COMP_DATAID"];
            //查詢資料
            objSubmit = new Comus.HtmlSubmitControl();
            objSubmit.VirtualPath = PageBase.GetComusVirtualPath();
            aryParameter[0] = "SP_ML0001_Q02";
            aryParameter[1] = "'" + strSYSID + "','" + strDataID + "','T'";
            objReturnObj = objSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.drpCompID.DataSource = objReturnObj.ReturnData;
                this.drpCompID.DataValueField = "MCODE";
                this.drpCompID.DataTextField = "MNAME1";
                this.drpCompID.DataBind();
            }
            else
            {
                Alert("查無資料!" + objReturnObj.ReturnMessage);
            }

            strObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            objSubmit = new Comus.HtmlSubmitControl();
            objSubmit.VirtualPath = PageBase.GetComusVirtualPath();
            aryParameter[0] = "SP_ML4007_Q00";
            aryParameter[1] = "'01'";
            objReturnObj = objSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.hdnCLSDT01.Value = objReturnObj.ReturnData.Rows[0]["CLSDT"].ToString();
            }
            else
            {
                Alert("無法取得關帳年月!" + objReturnObj.ReturnMessage);
            }

            strObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            objSubmit = new Comus.HtmlSubmitControl();
            objSubmit.VirtualPath = PageBase.GetComusVirtualPath();
            aryParameter[0] = "SP_ML4007_Q00";
            aryParameter[1] = "'02'";
            objReturnObj = objSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.hdnCLSDT02.Value = objReturnObj.ReturnData.Rows[0]["CLSDT"].ToString();
            }
            else
            {
                Alert("無法取得關帳年月!" + objReturnObj.ReturnMessage);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// 綁定承作類型下拉
    /// </summary>
    private void drpMainTypeBind()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> objReturnObj;

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
            LVAR_Parameter[1] = "'LE','05','T'";
            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.drpMainType.DataSource = objReturnObj.ReturnData;
                this.drpMainType.DataValueField = "MCODE";
                this.drpMainType.DataTextField = "MNAME1";
                this.drpMainType.DataBind();
            }
            else
            {
                Alert("查無資料!" + objReturnObj.ReturnMessage);
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
      String strQueryCon;
      try
      {
        strQueryCon = "";
        //以公司別及發票年月取得預開發票檔中公司別及發票年月與查詢條件相符且尚未開立之預開發票資料，至於尚未開立的判斷條件為
        //預開發票檔中，發票號碼，發票日期，傳票日期三個欄位為空白代表尚未開立。

        //公司別
        if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()) && (this.drpCompID.SelectedValue.Trim() != ""))
        {
            strQueryCon += " AND  B.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
        }
        //承作類型
        if (!String.IsNullOrEmpty(this.drpMainType.SelectedValue.Trim()) && (this.drpMainType.SelectedValue.Trim() != ""))
        {
            strQueryCon += " AND  D.MAINTYPE = ''" + this.drpMainType.SelectedValue.Trim() + "''";
        }
        //撥款確認日起迄-起
        if (!String.IsNullOrEmpty(this.txtInvMonth.Text.Trim()) && (this.txtInvMonth.Text.Trim() != ""))
        {
            strQueryCon += " AND  A.PREINVYYYYMM  = ''" + Itg.Community.Util.GetADYear(this.txtInvMonth.Text.Trim()) + "''";
        }
        if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()) && (this.txtCNTRNO.Text.Trim() != ""))
        {
            strQueryCon += " AND  B.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
        }
        //期數 
        if (!String.IsNullOrEmpty(this.hdnLevel.Value.Trim()) && (this.hdnLevel.Value.Trim() != ""))
        {
           if (this.hdnLevel.Value.Trim() == "1")//只有第一期
           {
               strQueryCon += " AND  A.ISSUE  = 1";
           }
           if (this.hdnLevel.Value.Trim() == "2")//不含第一期
           {
               strQueryCon += " AND  A.ISSUE  <> 1";
           }
       }
    }
      catch (Exception ex)
      {
        throw ex;
      }
      return strQueryCon;
    }


  

    /// <summary>
    /// 綁定畫面Grid數據
    /// </summary>
    private void rptDataBind()
    {
      String strObjId;
      HtmlSubmitControl objSubmit;
      String[] aryParameter = new String[2];
      ReturnObject<DataTable> objReturnObj;

      String strQueryCon;

      try
      {
          strObjId = "ITG.CommDBService.QueryByStoreProcedure";
          //取得查詢條件
          strQueryCon = "";
          //查詢資料
          objSubmit = new Comus.HtmlSubmitControl();
          objSubmit.VirtualPath = PageBase.GetComusVirtualPath();

          aryParameter[0] = "SP_ML4008_Q00";
          if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()) && (this.drpCompID.SelectedValue.Trim() != ""))
          {
              strQueryCon += " AND  B1.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
          }
          if (!String.IsNullOrEmpty(this.txtInvMonth.Text.Trim()) && (this.txtInvMonth.Text.Trim() != ""))
          {
              strQueryCon += " AND  B1.PREINVYYYYMM  < ''" + Itg.Community.Util.GetADYear(this.txtInvMonth.Text.Trim()) + "''";
          }
          if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()) && (this.txtCNTRNO.Text.Trim() != ""))
          {
              strQueryCon += " AND  B1.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
          }
          
          aryParameter[1] = "'" + strQueryCon + "'";

          objReturnObj = objSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
          if (objReturnObj.ReturnSuccess)
          {
              if (objReturnObj.ReturnData.Rows[0]["CNTRCNT"].ToString() != "0")
              {
                  Alert("本預開年月前月份尚有發票未開立!");
              }
          }
          else
          {
              Alert(objReturnObj.ReturnMessage);
          }


          strObjId = "ITG.CommDBService.QueryByStoreProcedure";
          //取得查詢條件
          strQueryCon = this.GenerateQueryCon();
          //查詢資料
          objSubmit = new Comus.HtmlSubmitControl();
          objSubmit.VirtualPath = PageBase.GetComusVirtualPath();

          aryParameter[0] = "SP_ML4007_Q01";
          aryParameter[1] = "'" + strQueryCon + "'";

          objReturnObj = objSubmit.SubmitEx<DataTable>(strObjId, aryParameter);
          if (objReturnObj.ReturnSuccess)
          {
              //綁定數據
              this.rptData.DataSource = objReturnObj.ReturnData;
              this.rptData.DataBind();
              this.chkAll.Checked = true;
              this.hdnRowCount.Value = objReturnObj.ReturnData.Rows.Count.ToString("#,##0");
              this.cmdProc.Attributes.Remove("disabled");
              this.cmdProc.Enabled = true;
              ViewState["MLMPREINVOICE"] = objReturnObj.ReturnData;
          }
          else
          {
              this.rptData.DataSource = null;
              this.rptData.DataBind();
              this.cmdProc.Enabled = false;
              this.hdnRowCount.Value = "0";
              Alert("查無資料!" + objReturnObj.ReturnMessage);
          }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }



    /// <summary>
    /// 查詢案件資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cmdQuery_Click(object sender, EventArgs e)
    {
      try
      {
          //UPD BY HANK 20170109 當發票開立項目選本體發票，用原本邏輯查詢結果，改為收入發票的話，則查詢發票是手續費，動保費收入，墊款息收入發票
          if (drpInvType.SelectedItem.Text == "本體發票")
          {
              //查詢並綁定畫面Grid資料
              this.rptDataBind();
          }
          else if(drpInvType.SelectedItem.Text == "收入發票")
          {
              string strCOMPID = this.drpCompID.SelectedValue.Trim();
              string strCNTRNO = this.txtCNTRNO.Text.Trim();
              string strPREINVYYYYMM = this.txtInvMonth.Text.Trim(); 

              String LSTR_ObjId;
              HtmlSubmitControl LOBJ_Submit;
              String[] LVAR_Parameter = new String[2];
              ReturnObject<DataTable> LOBJ_Return;

              LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
              //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
              //查詢資料
              LOBJ_Submit = new Comus.HtmlSubmitControl();
              LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
              LVAR_Parameter[0] = "SP_ML4007_Q04";
              LVAR_Parameter[1] = "'" + strCOMPID + "','" + strCNTRNO + "','" + strPREINVYYYYMM + "'";
              LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);

              if (LOBJ_Return.ReturnSuccess)
              {
                  //綁定數據
                  this.rptData.DataSource = LOBJ_Return.ReturnData;
                  this.rptData.DataBind();
                  this.chkAll.Checked = true;
                  this.hdnRowCount.Value = LOBJ_Return.ReturnData.Rows.Count.ToString("#,##0");
                  this.cmdProc.Attributes.Remove("disabled");
                  this.cmdProc.Enabled = true;
                  ViewState["MLMPREINVOICE"] = LOBJ_Return.ReturnData;
              }
              else
              {
                  this.rptData.DataSource = null;
                  this.rptData.DataBind();
                  this.cmdProc.Enabled = false;
                  this.hdnRowCount.Value = "0";
                  Alert("查無資料!" + LOBJ_Return.ReturnMessage);
              }
          }
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }
    
    /// <summary>
    /// 發票批次開立作業
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cmdProc_Click(object sender, EventArgs e)
    {
        StringBuilder stbSaveFields = new StringBuilder();

        DataTable dtbMLMPREINVOICE = (DataTable)ViewState["MLMPREINVOICE"];

        for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        {
            if (!((CheckBox)rptData.Items[intRowCnt].FindControl("chkCase")).Checked)
            {
                dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"] = "";
            }
//            dtbMLMPREINVOICE.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVDESCTYPE")).Value;
        }


        //拼接信息
        getMLMPREINVOICEColInf(ref stbSaveFields, dtbMLMPREINVOICE);


        try
        {
            ReturnObject<object> objReturnObj = SaveMLMPREINVOICESummary(stbSaveFields.ToString());
            if (objReturnObj.ReturnSuccess)
            {
                this.cmdPrint.Enabled = true;
                this.cmdPrint.Attributes.Remove("disabled");
                //                Alert(Resources.HeRun.H001);
                Alert("處理成功！");
                //                RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
                this.rptData.DataSource = null;
                this.rptData.DataBind();
            }
            else
            {
                Alert("處理失敗！錯誤訊息為：" + objReturnObj.ReturnMessage);
                this.cmdProc.Attributes.Remove("display:none");
                this.cmdProc.Attributes.Add("style", "display:");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }

    }

    /// <summary>
    /// SaveMLMPREINVOICESummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLMPREINVOICESummary(string strProcData)
    {
        Comus.HtmlSubmitControl objSubmitCtl;
        string strObjId;
        ReturnObject<object> objReturnObj;
        string[] aryParameter = new string[1];
        try
        {
            strObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            objSubmitCtl = new Comus.HtmlSubmitControl();
            objSubmitCtl.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = strProcData;
            objReturnObj = objSubmitCtl.SubmitEx<object>(strObjId, aryParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objReturnObj;
    }

    private void getMLMPREINVOICEColInf(ref StringBuilder stbSaveFields, DataTable dtbPREINVOICE)
    {
        stbSaveFields.Append("SP_ML4004_U01" + GSTR_ColDelimitChar);
        stbSaveFields.Append(this.drpMainType.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.txtInvMonth.Text.Trim() + GSTR_TabDelimitChar);
        stbSaveFields.Append(this.drpCompID.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);

        stbSaveFields.Append("SP_ML4004_U02" + GSTR_ColDelimitChar);
        stbSaveFields.Append(this.drpCompID.SelectedValue + GSTR_TabDelimitChar);
        stbSaveFields.Append(GSTR_ColDelimitChar);
        stbSaveFields.Append(GSTR_RowDelimitChar);

        for (int intRowCnt = 0; intRowCnt < dtbPREINVOICE.Rows.Count; intRowCnt++)
        {
            if (dtbPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString().Trim() != "")
            {
                //總體彙開
                if (dtbPREINVOICE.Rows[intRowCnt]["OVERALLOPEN"].ToString() == "1")
                {
                    DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
                    stbSaveFields.Append("SP_ML4007_I02" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["CNTRNO"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["MAINTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(this.drpCompID.SelectedValue + GSTR_TabDelimitChar);
                    string strPREINVYYYYMM = dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
                    string strORDERDAY = System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString()).ToString("00");
                    if (System.Convert.ToDecimal(strPREINVYYYYMM.Trim() + strORDERDAY.Trim()) >= System.Convert.ToDecimal(Request.Form.GetValues("hdnSystemDate")[0].Trim()))
                    {
                        DateTime dtmVaildINVDT = System.DateTime.Now;
                        if (System.DateTime.TryParse(strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY, out dtmVaildINVDT))
                        {
                            stbSaveFields.Append(strPREINVYYYYMM.Trim() + strORDERDAY.Trim() + GSTR_TabDelimitChar);
                        }
                        else
                        {
                            string strVaildINVDT = strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY;
                            strVaildINVDT = System.Convert.ToDateTime(strVaildINVDT.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                            stbSaveFields.Append(strVaildINVDT + GSTR_TabDelimitChar);
                        }
                    }
                    else
                    {
                        stbSaveFields.Append(this.txtINVODT.Text.Trim().Replace("/", "") + GSTR_TabDelimitChar);
                    }
                    stbSaveFields.Append(System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()).ToString("##0") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["TARGETID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
                else if (dtbPREINVOICE.Rows[intRowCnt]["UNITOPEN"].ToString() == "1")
                {
                    DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
                    stbSaveFields.Append("SP_ML4007_I01" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["CNTRNO"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["MAINTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(this.drpCompID.SelectedValue + GSTR_TabDelimitChar);
                    string strPREINVYYYYMM = dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
                    string strORDERDAY = System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString()).ToString("00");
                    if (System.Convert.ToDecimal(strPREINVYYYYMM.Trim() + strORDERDAY.Trim()) >= System.Convert.ToDecimal(Request.Form.GetValues("hdnSystemDate")[0].Trim()))
                    {   
                        DateTime dtmVaildINVDT = System.DateTime.Now;
                        if (System.DateTime.TryParse(strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY, out dtmVaildINVDT))
                        {
                            stbSaveFields.Append(strPREINVYYYYMM.Trim() + strORDERDAY.Trim() + GSTR_TabDelimitChar);
                        }
                        else
                        {
                            string strVaildINVDT = strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY;
                            strVaildINVDT = System.Convert.ToDateTime(strVaildINVDT.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                            stbSaveFields.Append(strVaildINVDT + GSTR_TabDelimitChar);
                        }
                    }
                    else
                    {
                        stbSaveFields.Append(this.txtINVODT.Text.Trim().Replace("/", "") + GSTR_TabDelimitChar);
                    }
                    stbSaveFields.Append(System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()).ToString("##0") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["TARGETID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
                else
                {
                    DataRow dtbTempRow = dtbPREINVOICE.Rows[intRowCnt];
                    stbSaveFields.Append("SP_ML4007_I03" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["CNTRNO"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["MAINTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["INVDESCTYPE"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(this.drpCompID.SelectedValue + GSTR_TabDelimitChar);
                    string strPREINVYYYYMM = dtbPREINVOICE.Rows[intRowCnt]["PREINVYYYYMM"].ToString();
                    string strORDERDAY = System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ORDERDAY"].ToString()).ToString("00");
                    if (System.Convert.ToDecimal(strPREINVYYYYMM.Trim() + strORDERDAY.Trim()) >= System.Convert.ToDecimal(Request.Form.GetValues("hdnSystemDate")[0].Trim()))
                    {
                        DateTime dtmVaildINVDT = System.DateTime.Now;
                        if (System.DateTime.TryParse(strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY, out dtmVaildINVDT))
                        {
                            stbSaveFields.Append(strPREINVYYYYMM.Trim() + strORDERDAY.Trim() + GSTR_TabDelimitChar);
                        }
                        else
                        {
                            string strVaildINVDT = strPREINVYYYYMM.Substring(0, 4) + "/" + strPREINVYYYYMM.Substring(4, 2) + "/" + strORDERDAY;
                            strVaildINVDT = System.Convert.ToDateTime(strVaildINVDT.Substring(0, 8) + "01").AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                            stbSaveFields.Append(strVaildINVDT + GSTR_TabDelimitChar);
                        }
                    }
                    else
                    {
                        stbSaveFields.Append(this.txtINVODT.Text.Trim().Replace("/", "") + GSTR_TabDelimitChar);
                    }
                    stbSaveFields.Append(System.Convert.ToDecimal(dtbPREINVOICE.Rows[intRowCnt]["ISSUE"].ToString()).ToString("##0") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbPREINVOICE.Rows[intRowCnt]["TARGETID"].ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
            }
        }
    }
    /// <summary>
    /// 發票列印作業
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        //ADD BY HANK 20170926 發票列印
        PrintReport(); 
    }
    /// <summary>
    /// 清除畫面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
    }

    //ADD BY HANK 20170926 發票列印改呼叫SSRS電子發票報表
    private void PrintReport()
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

    //ADD BY HANK 20170926 產出ReportParam
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
                    new JProperty("value", "")
                ),
                new JObject(
                    new JProperty("column", "CHECKPRTFLG"),
                    new JProperty("value", "N")
                ),
                new JObject(
                    new JProperty("column", "INVNOS"),
                    new JProperty("value", "")
                ),
                new JObject(
                    new JProperty("column", "INVNOE"),
                    new JProperty("value", "")
                ),
                new JObject(
                    new JProperty("column", "INVDATES"),
                    new JProperty("value", txtINVODT.Text)
                ),
                new JObject(
                    new JProperty("column", "INVDATEE"),
                    new JProperty("value", txtINVODT.Text)
                ))));

        return json;
    }
}
