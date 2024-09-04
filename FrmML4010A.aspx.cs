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


public partial class FrmML4010A : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.hdnINVNO.Value = Request.QueryString["INVNO"];
        this.hdnPDATE.Value = Request.QueryString["PDATE"];
        this.hdnSUMMARY.Value = Request.QueryString["SUMMARY"];
        this.spanTTLINVSUMMARY.Text = System.Convert.ToDecimal(this.hdnSUMMARY.Value).ToString("##,##0");

        GetUsrAndFuncInfo();

        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divMLDINVODETAIL.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4010A";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4010A";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

 
     if (!Page.IsPostBack)
      {
        try
        {
            Session["MLDDISINVODETAIL"] = null;
            rptMLDDISINVODETAIL_Bind();
          
        }
        catch (Exception ex)
        {

          Alert(ex.Message);
        }
       
      }
    }

    private void rptMLDDISINVODETAIL_Bind()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> objReturnObj;

        String LSTR_QueryCon;

        try
        {
            decimal decDISAMOUNTTTL = 0;
            decimal decDISAMOUNTUTAXTTL = 0;
            decimal decDISAMOUNTTAXTTL = 0;

            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //取得查詢條件
            LSTR_QueryCon = "AND B.INVNO = ''" + this.hdnINVNO.Value + "''";
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

            LVAR_Parameter[0] = "SP_ML4010_Q03";
            LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.rptMLDDISINVODETAILLog.DataSource = objReturnObj.ReturnData;
                this.rptMLDDISINVODETAILLog.DataBind();
                for (int intRowCnt = 0; intRowCnt < objReturnObj.ReturnData.Rows.Count; intRowCnt++)
                {
                    decDISAMOUNTTTL += System.Convert.ToDecimal(objReturnObj.ReturnData.Rows[intRowCnt]["AMOUNTTAX"].ToString());
                    decDISAMOUNTUTAXTTL += System.Convert.ToDecimal(objReturnObj.ReturnData.Rows[intRowCnt]["AMOUNT"].ToString());
                    decDISAMOUNTTAXTTL += System.Convert.ToDecimal(objReturnObj.ReturnData.Rows[intRowCnt]["TAX"].ToString());
                }
                this.spanDISAMOUNTTTL.Text = decDISAMOUNTTTL.ToString("##,##0");
                this.spanDISAMOUNTTAXTTL.Text = decDISAMOUNTUTAXTTL.ToString("##,##0");
                this.spanDISTAXTTL.Text = decDISAMOUNTTAXTTL.ToString("##,##0");
            }

            if (System.Convert.ToDecimal(this.hdnSUMMARY.Value) <= decDISAMOUNTTTL)
            {
                this.btnConfirm.Enabled = false;
            }
            else
            {
                LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
                //取得查詢條件
                LSTR_QueryCon = "AND A.INVNO = ''" + this.hdnINVNO.Value + "''";
                //查詢資料
                LOBJ_Submit = new Comus.HtmlSubmitControl();
                LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

                LVAR_Parameter[0] = "SP_ML4010_Q02";
                LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

                objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
                if (objReturnObj.ReturnSuccess)
                {
                    //綁定數據
                    Session["MLDDISINVODETAIL"] = objReturnObj.ReturnData;
                    this.rptMLDDISINVODETAIL.DataSource = objReturnObj.ReturnData;
                    this.rptMLDDISINVODETAIL.DataBind();
                }
                else
                {
                    this.rptMLDDISINVODETAIL.DataSource = null;
                    this.rptMLDDISINVODETAIL.DataBind();
                    Session["MLDDISINVODETAIL"] = null;
                    Alert("查無資料");
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void rptMLDCONTRACTTARGETBind(DataTable dtbMLDCONTRACTTARGET)
    {
      //this.rptMLDCONTRACTTARGET.DataSource = dtbMLDCONTRACTTARGET;
      //this.rptMLDCONTRACTTARGET.DataBind();
    }


    protected void rptMLDDISINVODETAIL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      //string strOPENCNTRNO = e.CommandArgument.ToString();
      //DataTable dtbMLDINVODETAIL = (DataTable)Session["MLDPREINVOPEN"];
      //for (int i = 0; i < dtbMLDINVODETAIL.Rows.Count; i++)
      //{       
      //  if (dtbMLDINVODETAIL.Rows[i]["OPENCNTRNO"].ToString() == strOPENCNTRNO)
      //  {
      //    dtbMLDINVODETAIL.Rows[i]["OPENCNTRNO"] = "";
      //    dtbMLDINVODETAIL.Rows[i]["OPENCNTRNOB"] = "true";
      //  }
      //}
      //Session["MLDPREINVOPEN"] = dtbMLDINVODETAIL;
      //rptMLDCONTRACTTARGETBind(dtbMLDINVODETAIL);
      //rptMLDDISINVODETAIL_Bind(dtbMLDINVODETAIL);

    }

    public DataTable updateMLDDISINVODETAIL()
    {
        DataTable dtbMLDDISINVODETAIL = (DataTable)Session["MLDDISINVODETAIL"];
        //先賦值
        for (int i = 0; i < rptMLDDISINVODETAIL.Items.Count; i++)
        {
            dtbMLDDISINVODETAIL.Rows[i]["DISAMOUNT"] = ((TextBox)rptMLDDISINVODETAIL.Items[i].FindControl("txtDISAMOUNT")).Text;
            dtbMLDDISINVODETAIL.Rows[i]["DISTAX"] = ((TextBox)rptMLDDISINVODETAIL.Items[i].FindControl("txtDISTAX")).Text;
        }
        Session["MLDINVODETAIL"] = dtbMLDDISINVODETAIL;
        return dtbMLDDISINVODETAIL;
    }

    /// <summary>
    /// GetDrpData
    /// </summary>
    /// <param name=""></param>
    /// <returns>以Dataset傳回下拉選單資料</returns>
    private ReturnObject<DataSet> GetDrpData()
    {

        Comus.HtmlSubmitControl objComusSubmit;
        string strObjID;
        StringBuilder stbStoreProcedure = new StringBuilder();
        StringBuilder stbQueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> dtsRtnObj;
        string[] aryParameter = new string[2];
        try
        {
            strObjID = "ITG.CommDBService.MutiQueryByStoreProcedure";


            //郵編區號
            stbStoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            stbQueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = stbStoreProcedure.ToString();
            aryParameter[1] = stbQueryCondition.ToString();
            dtsRtnObj = objComusSubmit.SubmitEx<DataSet>(strObjID, aryParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtsRtnObj;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        decimal decDISAMOUNTTTL = 0;
        decimal decDISTAXTTL = 0;
        decimal decDISAMOUNTTAXTTL = 0;

        DataTable dtbMLDINVODETAIL = updateMLDDISINVODETAIL();

        for (int intRowCnt = 0; intRowCnt < dtbMLDINVODETAIL.Rows.Count; intRowCnt++)
        {
            decDISAMOUNTTTL += System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString());
            decDISTAXTTL += System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString());
            decDISAMOUNTTAXTTL += (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString()));
        }
        this.spanDISAMOUNT.Text = decDISAMOUNTTTL.ToString("##,##0");
        this.spanDISAMOUNTTAX.Text = decDISTAXTTL.ToString("##,##0");

        if (this.rptMLDDISINVODETAILLog.Items.Count == 0)
        {
            if (System.Convert.ToDecimal(this.hdnSUMMARY.Value) == decDISAMOUNTTAXTTL)
            {
                Alert("全額折讓請以發票異動作業之發票退回處理！");
                this.Dispose();
                Page.RegisterStartupScript("Close", "<script>window.close();</script>");
            }
            else
            {
                StringBuilder stbSaveFields = new StringBuilder();
                stbSaveFields.Append("SP_ML4010_I02" + GSTR_ColDelimitChar);
                stbSaveFields.Append(this.hdnINVNO.Value + GSTR_TabDelimitChar);
                stbSaveFields.Append(this.hdnPDATE.Value + GSTR_TabDelimitChar);
                stbSaveFields.Append(decDISAMOUNTTAXTTL.ToString() + GSTR_TabDelimitChar);
                stbSaveFields.Append(decDISAMOUNTTTL.ToString() + GSTR_TabDelimitChar);
                stbSaveFields.Append(decDISTAXTTL.ToString() + GSTR_TabDelimitChar);
                stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                stbSaveFields.Append(GSTR_ColDelimitChar);
                stbSaveFields.Append(GSTR_RowDelimitChar);

                for (int intRowCnt = 0; intRowCnt < dtbMLDINVODETAIL.Rows.Count; intRowCnt++)
                {
                    //                    if (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString()) > 0)
                    if (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) > 0)
                    {
                        DataRow dtbTempRow = dtbMLDINVODETAIL.Rows[intRowCnt];
                        stbSaveFields.Append("SP_ML4010_I03" + GSTR_ColDelimitChar);
                        stbSaveFields.Append(this.hdnINVNO.Value + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["INVDSEQ"].ToString() + GSTR_TabDelimitChar);
                        decimal TTLAMT = System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString());
                        stbSaveFields.Append(TTLAMT.ToString() + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString().Replace(",","") + GSTR_TabDelimitChar);
                        stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString().Replace(",", "") + GSTR_TabDelimitChar);
                        stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                        stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                        stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                        stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                        stbSaveFields.Append(GSTR_ColDelimitChar);
                        stbSaveFields.Append(GSTR_RowDelimitChar);
                    }
                }

                try
                {
                    ReturnObject<object> objReturnObject = SaveMLDDISINVODETAILSummary(stbSaveFields.ToString());
                    if (objReturnObject.ReturnSuccess)
                    {
                        Alert("處理成功！");
                        this.Dispose();
                        Page.RegisterStartupScript("Close", "<script>window.close();</script>");
                    }
                    else
                    {
                        Alert("處理失敗！錯誤訊息為：" + objReturnObject.ReturnMessage);
                    }
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
                }
            }
        }
        else
        {
            StringBuilder stbSaveFields = new StringBuilder();
            stbSaveFields.Append("SP_ML4010_I02" + GSTR_ColDelimitChar);
            stbSaveFields.Append(this.hdnINVNO.Value + GSTR_TabDelimitChar);
            stbSaveFields.Append(this.hdnPDATE.Value + GSTR_TabDelimitChar);
            stbSaveFields.Append(decDISAMOUNTTAXTTL.ToString() + GSTR_TabDelimitChar);
            stbSaveFields.Append(decDISAMOUNTTTL.ToString() + GSTR_TabDelimitChar);
            stbSaveFields.Append(decDISTAXTTL.ToString() + GSTR_TabDelimitChar);
            stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            stbSaveFields.Append(GSTR_ColDelimitChar);
            stbSaveFields.Append(GSTR_RowDelimitChar);

            for (int intRowCnt = 0; intRowCnt < dtbMLDINVODETAIL.Rows.Count; intRowCnt++)
            {
                //                    if (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString()) > 0)
                if (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) > 0)
                {
                    DataRow dtbTempRow = dtbMLDINVODETAIL.Rows[intRowCnt];
                    stbSaveFields.Append("SP_ML4010_I03" + GSTR_ColDelimitChar);
                    stbSaveFields.Append(this.hdnINVNO.Value + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["INVDSEQ"].ToString() + GSTR_TabDelimitChar);
                    decimal TTLAMT = System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString());
                    stbSaveFields.Append(TTLAMT.ToString() + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString().Replace(",", "") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString().Replace(",", "") + GSTR_TabDelimitChar);
                    stbSaveFields.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    stbSaveFields.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    stbSaveFields.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    stbSaveFields.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                    stbSaveFields.Append(GSTR_ColDelimitChar);
                    stbSaveFields.Append(GSTR_RowDelimitChar);
                }
            }

            try
            {
                ReturnObject<object> objReturnObject = SaveMLDDISINVODETAILSummary(stbSaveFields.ToString());
                if (objReturnObject.ReturnSuccess)
                {
                    Alert("處理成功！");
                    this.Dispose();
                    Page.RegisterStartupScript("Close", "<script>window.close();</script>");
                }
                else
                {
                    Alert("處理失敗！錯誤訊息為：" + objReturnObject.ReturnMessage);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }

    /// <summary>
    /// SaveMLDDISINVODETAILSummary 
    /// </summary>
    /// <param name="strProcData">string</param>
    private ReturnObject<object> SaveMLDDISINVODETAILSummary(string strProcData)
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
