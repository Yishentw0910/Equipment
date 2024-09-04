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


public partial class FrmML4010B : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.hdnINVNO.Value = Request.QueryString["INVNO"];
        this.hdnPDATE.Value = Request.QueryString["PDATE"];

        GetUsrAndFuncInfo();

        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divMLDINVODETAIL.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4010B";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4010B";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

 
     if (!Page.IsPostBack)
      {
        try
        {
            rptMLDDISINVODETAILLog_Bind();
          
        }
        catch (Exception ex)
        {

          Alert(ex.Message);
        }
       
      }
    }

    private void rptMLDDISINVODETAILLog_Bind()
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
            LSTR_QueryCon = "AND B.INVNO = ''" + this.hdnINVNO.Value + "''";
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

            LVAR_Parameter[0] = "SP_ML4010_Q03";
            LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

            string strSYSDate = System.DateTime.Now.ToString("yyyyMMdd").Substring(0,6) + "01";

            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                Session["MLDDISINVODETAIL"] = objReturnObj.ReturnData;
                this.rptMLDDISINVODETAILLog.DataSource = objReturnObj.ReturnData;
                this.rptMLDDISINVODETAILLog.DataBind();
                Int32 intRowCnt1, intRowCnt2 = 0;
                for (intRowCnt1 = 0; intRowCnt1 < rptMLDDISINVODETAILLog.Items.Count; intRowCnt1++)
                {
                    if (((HiddenField)rptMLDDISINVODETAILLog.Items[intRowCnt1].FindControl("hdnAMOUNTTAX")).Value.Trim().Substring(0, 1) == "-")
                    {
                        ((RadioButton)rptMLDDISINVODETAILLog.Items[intRowCnt1].FindControl("optSelect")).Enabled = false;
                        for (intRowCnt2 = 0; intRowCnt2 < rptMLDDISINVODETAILLog.Items.Count; intRowCnt2++)
                        {
                            if (((RadioButton)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("optSelect")).Enabled && ((HiddenField)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("hdnAMOUNTTAX")).Value.Trim().Substring(0, 1) != "-" && (0 - System.Convert.ToDecimal(((HiddenField)rptMLDDISINVODETAILLog.Items[intRowCnt1].FindControl("hdnAMOUNTTAX")).Value)) == System.Convert.ToDecimal(((HiddenField)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("hdnAMOUNTTAX")).Value))
                            {
                                ((RadioButton)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("optSelect")).Enabled = false;
                                break;
                            }
                            else
                            {
                                if (System.Convert.ToDecimal(((HiddenField)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("hdnPDATE")).Value.Replace("/", "")) < System.Convert.ToDecimal(strSYSDate))
                                {
                                    ((RadioButton)rptMLDDISINVODETAILLog.Items[intRowCnt2].FindControl("optSelect")).Enabled = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                this.rptMLDDISINVODETAILLog.DataSource = null;
                this.rptMLDDISINVODETAILLog.DataBind();
                Alert("查無資料");
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


    protected void rptMLDDISINVODETAILLog_ItemCommand(object source, RepeaterCommandEventArgs e)
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
      //rptMLDDISINVODETAILLog_Bind(dtbMLDINVODETAIL);

    }

    public DataTable updateMLDDISINVODETAIL()
    {
        DataTable dtbMLDDISINVODETAIL = (DataTable)Session["MLDDISINVODETAIL"];
        //先賦值
        for (int i = 0; i < rptMLDDISINVODETAILLog.Items.Count; i++)
        {
            if (((HiddenField)rptMLDDISINVODETAILLog.Items[i].FindControl("hdnOptValue")).Value == "0")
            {
                dtbMLDDISINVODETAIL.Rows[i]["INVDSEQ"] = "";
            }
        }
        Session["MLDINVODETAIL"] = dtbMLDDISINVODETAIL;
        return dtbMLDDISINVODETAIL;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        decimal decDISAMOUNTTTL = 0;
        decimal decDISTAXTTL = 0;
        decimal decDISAMOUNTTAXTTL = 0;

        DataTable dtbMLDINVODETAIL = updateMLDDISINVODETAIL();

        for (int intRowCnt = 0; intRowCnt < dtbMLDINVODETAIL.Rows.Count; intRowCnt++)
        {
            if (dtbMLDINVODETAIL.Rows[intRowCnt]["INVDSEQ"].ToString() != "")
            {
                decDISAMOUNTTTL += System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString());
                decDISTAXTTL += System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString());
                decDISAMOUNTTAXTTL += (System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISAMOUNT"].ToString()) + System.Convert.ToDecimal(dtbMLDINVODETAIL.Rows[intRowCnt]["DISTAX"].ToString()));
            }
        }

        StringBuilder stbSaveFields = new StringBuilder();       
        stbSaveFields.Append("SP_ML4010_I04" + GSTR_ColDelimitChar);
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
            if (dtbMLDINVODETAIL.Rows[intRowCnt]["INVDSEQ"].ToString() != "")
            {
                DataRow dtbTempRow = dtbMLDINVODETAIL.Rows[intRowCnt];
                stbSaveFields.Append("SP_ML4010_I05" + GSTR_ColDelimitChar);
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
