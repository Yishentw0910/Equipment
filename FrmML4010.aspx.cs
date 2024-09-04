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


public partial class FrmML4010 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

      try
      {
          this.hdnSysdate.Value = System.DateTime.Now.ToString("yyyy/MM/dd");
          GetUsrAndFuncInfo();
          if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
          if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4010";
          if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4010";
          if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
          if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
          if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";


        if (!IsPostBack)
        {
            drpPRODBind();
        }
         
        //Vincent-20100817-Add for 畫面控制項屬性設定
        PageInitProcess();

      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }

    private void drpPRODBind()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> objReturnObj;

        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML0001_Q02";
            LVAR_Parameter[1] = "'LE','18','F'";
            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                ViewState["dtbPROD"] = (DataTable)objReturnObj.ReturnData;
            }
            else
            {
                Alert("查無資料!" + objReturnObj.ReturnMessage);
            }

            LVAR_Parameter[0] = "SP_ML0001_Q02";
            LVAR_Parameter[1] = "'LE','18','T'";
            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                this.drpPRODQRY.DataSource = objReturnObj.ReturnData;
                this.drpPRODQRY.DataValueField = "MCODE";
                this.drpPRODQRY.DataTextField = "MNAME1";
                this.drpPRODQRY.DataBind();
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
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtINVNO.Attributes.Add("style", "ime-mode:disabled;");
        this.txtINVNO.Attributes.Add("onkeypress", "OnlyNumD(this);");
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
        //發票編號
        if (!String.IsNullOrEmpty(this.txtINVNO.Text.Trim()))
        {
            LSTR_QueryCon += " AND  A.INVNO = ''" + this.txtINVNO.Text.Trim() + "''";
        }
        if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()))
        {
            LSTR_QueryCon += " AND  D.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
        }
        if (!String.IsNullOrEmpty(this.txtCUSTNO.Text.Trim()))
        {
            LSTR_QueryCon += " AND  A.UNIMNO = ''" + this.txtCUSTNO.Text.Trim() + "''";
        }
        if (!String.IsNullOrEmpty(this.drpPRODQRY.Text.Trim()))
        {
            LSTR_QueryCon += " AND  A.PROD = ''" + this.drpPRODQRY.SelectedValue.Trim() + "''";
        }
    }
      catch (Exception ex)
      {
        throw ex;
      }
      return LSTR_QueryCon;
    }


  

    /// <summary>
    /// 綁定畫面Grid數據
    /// </summary>
    private void rptDataBind()
    {
      String LSTR_ObjId;
      HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> objReturnObj;

      String LSTR_QueryCon;

      try
      {
        LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
        //取得查詢條件
        LSTR_QueryCon = this.GenerateQueryCon();
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

        LVAR_Parameter[0] = "SP_ML4010_Q01";
        LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

        objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (objReturnObj.ReturnSuccess)
        {
          //綁定數據
          this.rptData.DataSource = objReturnObj.ReturnData;
          this.rptData.DataBind();
          ViewState["MLMINVOICE"] = objReturnObj.ReturnData;
          DataTable dtbMLMINVOICE = (DataTable)ViewState["MLMINVOICE"];
          for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
          {
              ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPROD")).Value = dtbMLMINVOICE.Rows[intRowCnt]["PROD_OLD"].ToString();
              if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "1")
              {
                  DataTable dtbTemp = new DataTable("dtbTemp");
                  if (dtbMLMINVOICE.Rows[intRowCnt]["MAINTYPE"].ToString() == "02")
                  {
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4')")[i]);
                      }
                  }
                  else
                  {
                      if (System.Convert.ToInt32(dtbMLMINVOICE.Rows[intRowCnt]["INVGRPCNT"].ToString()) > 1)
                      {
                          dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                          dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                          for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4')").Length; i++)
                          {
                              dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4')")[i]);
                          }
                      }
                      else
                      {
                          dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                          dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                          for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4','6')").Length; i++)
                          {
                              dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('1','2','4','6')")[i]);
                          }
                      }
                  }
                  ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
              }
              else if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "2" || dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "3")
              {
                  if ((dtbMLMINVOICE.Rows[intRowCnt]["OPENMONTH"].ToString().Trim()  != "1") && (!String.IsNullOrEmpty(dtbMLMINVOICE.Rows[intRowCnt]["OPENMONTH"].ToString().Trim())))
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('2')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('2')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
                  }
                  else
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('2','3')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('2','3')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
                  }
              }
              else if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "4" || dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "5")
              {
                  if (dtbMLMINVOICE.Rows[intRowCnt]["OPENMONTH"].ToString() != "1")
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('4')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('4')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
                  }
                  else
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('4','5')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('4','5')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
                  }
              }
              else if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "6" || dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "7")
              {
                  if (dtbMLMINVOICE.Rows[intRowCnt]["OPENMONTH"].ToString() != "1")
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('6')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('6')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;
                  }
                  else
                  {
                      DataTable dtbTemp = new DataTable("dtbTemp");
                      dtbTemp.Columns.Add(new DataColumn("MCODE", System.Type.GetType("System.String")));
                      dtbTemp.Columns.Add(new DataColumn("MNAME1", System.Type.GetType("System.String")));
                      for (Int32 i = 0; i < ((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('6','7')").Length; i++)
                      {
                          dtbTemp.ImportRow(((DataTable)ViewState["dtbPROD"]).Select("MCODE In ('6','7')")[i]);
                      }
                      ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataSource = dtbTemp;                      
                  }
              }
              ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).DataBind();
              ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).SelectedValue = dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString();
              if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "6")
              {
                  ((Button)rptData.Items[intRowCnt].FindControl("btnSelect")).Attributes.Remove("display:none");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnSelect")).Attributes.Add("style", "display:");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnSelect")).Attributes.Add("style", "width:50%");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnDisselect")).Attributes.Remove("display:");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnDisselect")).Attributes.Add("style", "display:none");
              }
              else if (dtbMLMINVOICE.Rows[intRowCnt]["PROD"].ToString() == "7")
              {
                  ((Button)rptData.Items[intRowCnt].FindControl("btnSelect")).Attributes.Remove("display:");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnSelect")).Attributes.Add("style", "display:none");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnDisselect")).Attributes.Remove("display:none");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnDisselect")).Attributes.Add("style", "display:");
                  ((Button)rptData.Items[intRowCnt].FindControl("btnDisselect")).Attributes.Add("style", "width:50%");
              }
          }
          ViewState["MLMINVOICE"] = dtbMLMINVOICE;

        }
        else
        {
          this.rptData.DataSource = null;
          this.rptData.DataBind();
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
        //查詢並綁定畫面Grid資料
        this.rptDataBind();
        
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }




    protected void cmdClear_Click(object sender, EventArgs e)
    {
        this.rptData.DataSource = null;
        this.rptData.DataBind();
    }
    protected void btnMdyInvo_Click(object sender, EventArgs e)
    {
        StringBuilder stbSaveFields = new StringBuilder();

        DataTable dtbMLMINVOICE = (DataTable)ViewState["MLMINVOICE"];

        for (int intRowCnt = 0; intRowCnt < rptData.Items.Count; intRowCnt++)
        {
            dtbMLMINVOICE.Rows[intRowCnt]["PREINVID"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPREINVID")).Value;
            dtbMLMINVOICE.Rows[intRowCnt]["INVNO"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnINVNO")).Value;
            dtbMLMINVOICE.Rows[intRowCnt]["PROD"] = ((DropDownList)rptData.Items[intRowCnt].FindControl("drpPROD")).SelectedValue;
            dtbMLMINVOICE.Rows[intRowCnt]["PROD_OLD"] = ((HiddenField)rptData.Items[intRowCnt].FindControl("hdnPROD")).Value;
            dtbMLMINVOICE.Rows[intRowCnt]["PDATE"] = ((TextBox)rptData.Items[intRowCnt].FindControl("txtPDATE")).Text;
        }

        ViewState["MLMINVOICE"] = dtbMLMINVOICE;
        //拼接信息
        getMLMINVOICEColInf(ref stbSaveFields, dtbMLMINVOICE);

        try
        {
            ReturnObject<object> objReturnObj = SaveMLMINVOICESummary(stbSaveFields.ToString());
            if (objReturnObj.ReturnSuccess)
            {
                //                Alert(Resources.HeRun.H001);
                Alert("處理成功！");
                //                RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
                this.rptData.DataSource = null;
                this.rptData.DataBind();
                Page.RegisterStartupScript("Close", "<script>window.close();</script>");
            }
            else
            {
                Alert("處理失敗！錯誤訊息為：" + objReturnObj.ReturnMessage);
                this.btnMdyInvo.Attributes.Remove("display:none");
                this.btnMdyInvo.Attributes.Add("style", "display:");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }

    }

    private void getMLMINVOICEColInf(ref StringBuilder stbSaveFields, DataTable dtbMLMINVOICE)
    {
        for (int intRowCnt = 0; intRowCnt < dtbMLMINVOICE.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbMLMINVOICE.Rows[intRowCnt];
            if (dtbTempRow["PROD"].ToString().Trim() != dtbTempRow["PROD_OLD"].ToString().Trim())
            {
                stbSaveFields.Append("SP_ML4010_I01" + GSTR_ColDelimitChar);
                stbSaveFields.Append(dtbTempRow["INVNO"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["PROD"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["PDATE"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(dtbTempRow["PREINVID"].ToString().Trim() + GSTR_TabDelimitChar);
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);
            }
        }
    }

    /// <summary>
    /// SaveMLMINVOICESummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLMINVOICESummary(string strProcData)
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

}
