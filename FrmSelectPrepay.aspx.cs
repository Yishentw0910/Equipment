using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itg.Community;
using ITG.Community;
using System.Data;
using System.Text;

public partial class FrmSelectPrepay : PageBase
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "預撥查詢";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML0001";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML0001";
        //========================             
        if (!Page.IsPostBack)
        {
            hdCASEID.Value = Request.QueryString["CASEID"] == null ? "" : Request.QueryString["CASEID"].ToString();
            hdCNTRNO.Value = Request.QueryString["CNTRNO"] == null ? "" : Request.QueryString["CNTRNO"].ToString();
            hdPRENTSTDT.Value = Request.QueryString["PRENTSTDT"] == null ? "" : Request.QueryString["PRENTSTDT"].ToString();
            hdPAYDATE.Value = Request.QueryString["PAYDATE"] == null ? "" : Request.QueryString["PAYDATE"].ToString();
            PageDataBind(hdCASEID.Value,hdCNTRNO.Value);
            //Alert(hdCASEID.Value);
        }
    }

    private void PageDataBind(string LSTR_CASEID, string LSTR_CONTID)
    {
        if (!string.IsNullOrEmpty(LSTR_CASEID))
        {
            try
            {
                ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByID(LSTR_CASEID,LSTR_CONTID);

                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                    GetMLDPREPAYMFBind(LDST_Data.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
    }

    private ReturnObject<DataSet> GetCaseDataByID(string LSTR_CASEID, string LSTR_CONTID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";

            LSTR_StoreProcedure.Append("SP_ML3001_Q17" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }

    private void GetMLDPREPAYMFBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            ViewState["MLDPREPAYMF"] = LOBJ_Data;
            MLDASSPAYMFBind();
        }
        else
        {
            rptMLDPREPAYMF.DataSource = LOBJ_Data;
            rptMLDPREPAYMF.DataBind();
        }
    }
    private void MLDASSPAYMFBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["MLDPREPAYMF"];
        this.rptMLDPREPAYMF.DataSource = LOBJ_Data;
        this.rptMLDPREPAYMF.DataBind();

        //UpdatePanelMLDASSPAYMF.Update();
    }
    protected void btnSURE_Click(object sender, EventArgs e)
    {
        UpdatePanelMLDPREPAYMF.Update();
        StringBuilder LSTR_Data = new StringBuilder();
        for (int i = 0; i < this.rptMLDPREPAYMF.Items.Count; i++)
        {
            
            LSTR_Data.Append("SP_ML3002_I17" + GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(hdCASEID.Value + GSTR_TabDelimitChar);
            LSTR_Data.Append(hdCNTRNO.Value + GSTR_TabDelimitChar);
            LSTR_Data.Append(((HiddenField)rptMLDPREPAYMF.Items[i].FindControl("hdSEQNO")).Value + GSTR_TabDelimitChar);
            //Alert(((TextBox)rptMLDPREPAYMF.Items[i].FindControl("txtADVANCESINTEREST")).Text.Trim());
            if (((CheckBox)rptMLDPREPAYMF.Items[i].FindControl("chkWRITEOFF")).Checked == true)
            {
                LSTR_Data.Append(((TextBox)rptMLDPREPAYMF.Items[i].FindControl("txtWRITEOFFAMT")).Text.Replace(",", "") + GSTR_TabDelimitChar);
                LSTR_Data.Append(((TextBox)rptMLDPREPAYMF.Items[i].FindControl("txtADVANCESINTEREST")).Text.Replace(",", ""));
            }
            else
            {
                LSTR_Data.Append("0"+ GSTR_TabDelimitChar);
                LSTR_Data.Append("0");
            }

            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            
        }
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //=========================================================================
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = SaveContractInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                //Alert("OK");
                RegisterScript("window.close();");
            }
            else
            {
                Alert("處理失敗!!");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private ReturnObject<object> SaveContractInfo(string LSTR_Data)
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
}