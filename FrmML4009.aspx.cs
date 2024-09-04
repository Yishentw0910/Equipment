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


public partial class FrmML4009 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

      try
      {
        GetUsrAndFuncInfo();

        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4009";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4009";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";


        if (!IsPostBack)
        {
            //drpPRODBind();
            this.txtRntYM.Text = System.DateTime.Now.AddMonths(1).ToString("yyyy/MM");
        }
        else
        {
            if (this.Request.Form.GetValues("drpPROCMODE")[0] != "2")
            {
                this.cmdQuery.Attributes.Remove("display:");
                this.cmdQuery.Attributes.Add("style", "display:none");
            }
            else
            {
                this.cmdQuery.Attributes.Remove("display:none");
                this.cmdQuery.Attributes.Add("style", "display:");
            }
        }
        //Vincent-20100817-Add for 畫面控制項屬性設定
        PageInitProcess();

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
        this.txtRntYM.Attributes.Add("style", "ime-mode:disabled;");
        this.txtRntYM.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtRntYM.Attributes.Add("onblur", "txtRntYM_onBlur(this);");
        this.txtRntYM.Attributes.Add("onfocus", "txtRntYM_onFocus(this);");
        this.drpPROCMODE.Attributes.Add("onchange", "drpPROCMODE_onChange(this);");
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

            //承作類型
            if (!String.IsNullOrEmpty(this.txtRntYM.Text.Trim()) && (this.txtRntYM.Text.Trim() != ""))
            {
                strQueryCon += " AND  A.OPYM = ''" + this.txtRntYM.Text.Trim().Replace("/","") + "''";
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
    private void rptMLMMLMBATPLANBind()
    {
      String LSTR_ObjId;
      HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;

      String LSTR_QueryCon = GenerateQueryCon();

      try
      {
        LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
        //取得查詢條件
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

        LVAR_Parameter[0] = "SP_ML4009_Q01";
        LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

        LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (LOBJ_Return.ReturnSuccess)
        {
          //綁定數據
          this.rptMLMMLMBATPLAN.DataSource = LOBJ_Return.ReturnData;
          this.rptMLMMLMBATPLAN.DataBind();
          Session["MLMMLMBATPLAN"] = LOBJ_Return.ReturnData;
          this.drpPROCMODE.SelectedValue = "2";
          for (int i = 0; i < rptMLMMLMBATPLAN.Items.Count; i++)
          {
			  ((DropDownList)rptMLMMLMBATPLAN.Items[i].FindControl("drpOPFLAG")).SelectedValue = LOBJ_Return.ReturnData.Rows[i]["OPFLAG"].ToString();
              ((TextBox)rptMLMMLMBATPLAN.Items[i].FindControl("txtPOPDATE")).Text = LOBJ_Return.ReturnData.Rows[i]["POPDATE"].ToString();
          }

        }
        else
        {
          this.rptMLMMLMBATPLAN.DataSource = null;
          this.rptMLMMLMBATPLAN.DataBind();
          Session["MLMMLMBATPLAN"] = null;
          if (this.drpPROCMODE.SelectedValue == "2")
          {
              Alert("查無資料");
          }
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
        this.rptMLMMLMBATPLANBind();
        
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }

    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        this.rptMLMMLMBATPLAN.DataSource = null;
        this.rptMLMMLMBATPLAN.DataBind();
        Session["MLMMLMBATPLAN"] = null;
        rptMLMMLMBATPLANBind();
        if (this.drpPROCMODE.SelectedValue == "1")
        {
            AddMLMMLMBATPLANRow();
        }
        else
        {
            this.cmdQuery.Attributes.Remove("display:none");
            this.cmdQuery.Attributes.Add("style","display:");
        }
    }

    protected void btnDelRow_Click(object sender, EventArgs e)
    {
    }

    private void MLMMLMBATPLAN_Init()
    {
        if (Session["MLMMLMBATPLAN"] == null)
        {
            //初始化欄位
            DataTable dtbMLMMLMBATPLAN = new DataTable("MLMMLMBATPLAN");
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("COMPNME", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("COMPID", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("OPYM", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("EMPLID", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("EMPLNM", System.Type.GetType("System.String")));
			dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("PDATE", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("POPDATE", System.Type.GetType("System.String")));
            dtbMLMMLMBATPLAN.Columns.Add(new DataColumn("OPFLAG", System.Type.GetType("System.String")));
            Session["MLMMLMBATPLAN"] = dtbMLMMLMBATPLAN;
        }
    }
    private void AddMLMMLMBATPLANRow()
    {
        MLMMLMBATPLAN_Init();
        //更新暫存資料
        DataTable dtbMLMMLMBATPLAN = updateMLMMLMBATPLAN();
        //新增一筆資料          
        DataRow dtrMLMMLMBATPLAN = dtbMLMMLMBATPLAN.NewRow();
        dtrMLMMLMBATPLAN["COMPNME"] = "和運";
        dtrMLMMLMBATPLAN["COMPID"] = "01";
        dtrMLMMLMBATPLAN["OPYM"] = this.txtRntYM.Text.Trim();
        dtrMLMMLMBATPLAN["EMPLID"] = GSTR_A_USERID;
        dtrMLMMLMBATPLAN["PDATE"] = System.DateTime.Now.ToString("yyyy/MM/dd");
        dtrMLMMLMBATPLAN["POPDATE"] = System.DateTime.Now.ToString("yyyy/MM/dd"); ;
        dtrMLMMLMBATPLAN["OPFLAG"] = "2";
        dtbMLMMLMBATPLAN.Rows.Add(dtrMLMMLMBATPLAN);

        dtrMLMMLMBATPLAN = dtbMLMMLMBATPLAN.NewRow();
        dtrMLMMLMBATPLAN["COMPNME"] = "和潤";
        dtrMLMMLMBATPLAN["COMPID"] = "02";
        dtrMLMMLMBATPLAN["OPYM"] = this.txtRntYM.Text.Trim();
        dtrMLMMLMBATPLAN["EMPLID"] = GSTR_A_USERID;
        dtrMLMMLMBATPLAN["PDATE"] = System.DateTime.Now.ToString("yyyy/MM/dd");
        dtrMLMMLMBATPLAN["POPDATE"] = System.DateTime.Now.ToString("yyyy/MM/dd"); ;
        dtrMLMMLMBATPLAN["OPFLAG"] = "2";
        dtbMLMMLMBATPLAN.Rows.Add(dtrMLMMLMBATPLAN);

        if (dtbMLMMLMBATPLAN.Rows.Count != 0)
        {
            this.btnConfirm.Enabled = true;
        }
        else
        {
            this.btnConfirm.Enabled = false;
        }
        Session["MLMMLMBATPLAN"] = dtbMLMMLMBATPLAN;
        MLMMLMBATPLAN_Bind();
    }

    private void MLMMLMBATPLAN_Bind()
    {
        DataTable dtbMLMMLMBATPLAN = (DataTable)Session["MLMMLMBATPLAN"];
        this.rptMLMMLMBATPLAN.DataSource = dtbMLMMLMBATPLAN;
        this.rptMLMMLMBATPLAN.DataBind();
        for (int i = 0; i < rptMLMMLMBATPLAN.Items.Count; i++)
        {
            ((DropDownList)rptMLMMLMBATPLAN.Items[i].FindControl("drpOPFLAG")).SelectedValue = dtbMLMMLMBATPLAN.Rows[i]["OPFLAG"].ToString();
            ((TextBox)rptMLMMLMBATPLAN.Items[i].FindControl("txtPOPDATE")).Text = dtbMLMMLMBATPLAN.Rows[i]["POPDATE"].ToString();
        }
    }

    private void DelMLMMLMBATPLANRow(string strRowIndex)
    {
        //更新暫存資料
        DataTable dtbMLMMLMBATPLAN = updateMLMMLMBATPLAN();
        //刪除一筆資料
        if (dtbMLMMLMBATPLAN.Rows.Count >= Convert.ToInt32(strRowIndex))
        {
            dtbMLMMLMBATPLAN.Rows.RemoveAt(Convert.ToInt32(strRowIndex));
            if (dtbMLMMLMBATPLAN.Rows.Count != 0)
            {
                this.btnConfirm.Enabled = true;
            }
            else
            {
                this.btnConfirm.Enabled = false;
            }
            Session["MLMMLMBATPLAN"] = dtbMLMMLMBATPLAN;
            MLMMLMBATPLAN_Bind();
        }
    }

    public DataTable updateMLMMLMBATPLAN()
    {
        DataTable dtbMLMMLMBATPLAN = (DataTable)Session["MLMMLMBATPLAN"];
        //先賦值
        for (int i = 0; i < rptMLMMLMBATPLAN.Items.Count; i++)
        {
            dtbMLMMLMBATPLAN.Rows[i]["POPDATE"] = ((TextBox)rptMLMMLMBATPLAN.Items[i].FindControl("txtPOPDATE")).Text;
            dtbMLMMLMBATPLAN.Rows[i]["OPFLAG"] = ((DropDownList)rptMLMMLMBATPLAN.Items[i].FindControl("drpOPFLAG")).SelectedValue;
        }
        Session["MLMMLMBATPLAN"] = dtbMLMMLMBATPLAN;
        return dtbMLMMLMBATPLAN;
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        Session["MLMMLMBATPLAN"] = null;
        this.rptMLMMLMBATPLAN.DataSource = null;
        this.rptMLMMLMBATPLAN.DataBind();
        if (this.drpPROCMODE.SelectedValue != "2")
        {
            this.cmdQuery.Attributes.Remove("display:");
            this.cmdQuery.Attributes.Add("style", "display:none");
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        StringBuilder stbSaveFields = new StringBuilder();

        DataTable dtbMLMMLMBATPLAN = updateMLMMLMBATPLAN();

        //拼接信息
        getMLMMLMBATPLANColInf(ref stbSaveFields, dtbMLMMLMBATPLAN);

        try
        {
            ReturnObject<object> objReturnObject = SaveMLMBATPLANSummary(stbSaveFields.ToString());
            if (objReturnObject.ReturnSuccess)
            {
                //                Alert(Resources.HeRun.H001);
                Alert("處理成功！");
                //                RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
                if (this.drpPROCMODE.SelectedValue == "2")
                {
                    this.cmdQuery.Attributes.Remove("display:");
                    this.cmdQuery.Attributes.Add("style", "display:none");
                }
                this.drpPROCMODE.SelectedValue = "";
                this.rptMLMMLMBATPLAN.DataSource = null;
                this.rptMLMMLMBATPLAN.DataBind();
                Page.RegisterStartupScript("Close", "<script>window.close();</script>");
            }
            else
            {
                Alert("處理失敗！錯誤訊息為：" + objReturnObject.ReturnMessage);
                this.btnConfirm.Attributes.Remove("display:none");
                this.btnConfirm.Attributes.Add("style", "display:");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }

    }

    private void getMLMMLMBATPLANColInf(ref StringBuilder stbSaveFields, DataTable dtbMLMMLMBATPLAN)
    {
        for (int intRowCnt = 0; intRowCnt < dtbMLMMLMBATPLAN.Rows.Count; intRowCnt++)
        {
            DataRow dtbTempRow = dtbMLMMLMBATPLAN.Rows[intRowCnt];
            stbSaveFields.Append("SP_ML4009_I01" + GSTR_ColDelimitChar);
            stbSaveFields.Append(dtbTempRow["COMPID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["OPYM"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["EMPLID"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["PDATE"].ToString().Trim().Replace("/","") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["POPDATE"].ToString().Trim().Replace("/", "") + GSTR_TabDelimitChar);
            stbSaveFields.Append(dtbTempRow["OPFLAG"].ToString().Trim() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);
        }
    }

    /// <summary>
    /// SaveMLMBATPLANSummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLMBATPLANSummary(string strProcData)
    {
        Comus.HtmlSubmitControl objSubmitCtl;
        string strObjId;
        ReturnObject<object> objReturnObject;
        string[] aryParameter = new string[1];
        try
        {
            strObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            objSubmitCtl = new Comus.HtmlSubmitControl();
            objSubmitCtl.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = strProcData;
            objReturnObject = objSubmitCtl.SubmitEx<object>(strObjId, aryParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objReturnObject;
    }
}
