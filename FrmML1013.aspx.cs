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
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;

public partial class FrmML1013 : Itg.Community.PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    //案件

    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "合約範本列印";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "LE1013";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "LE1013";
        //========================             
        if (!Page.IsPostBack)
        {
            try
            {
                //判斷案件類型
                ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();
                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                    this.drpMAINTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
                    this.drpMAINTYPE.DataBind();

                    this.drpTRANSTYPE.DataSource = LDST_Data.Tables[1].DefaultView;
                    this.drpTRANSTYPE.DataBind();
                    this.drpTRANSTYPE.SelectedValue = "02";

                    this.drpPRODCD.DataSource = LDST_Data.Tables[2].DefaultView;
                    this.drpPRODCD.DataBind();

                    string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
                    drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);

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
        }
    }
    private ReturnObject<DataSet> GetDrpData()
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
            //承做形態
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //交易形態
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "06" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //案件產品別
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "93" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
    protected void drpMAINTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
        drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
        this.UpdatePanel1.Update();
    }
    private void drpSUBTYPEaEXPIREPROCBindbyID(string LSTR_MAINTYPEID)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                DataView LDVW = LDST_Data.Tables[0].DefaultView;
                this.drpSUBTYPE.DataSource = LDVW;
                this.drpSUBTYPE.DataBind();
                //營資租時預設值為非事務機
                if (this.drpMAINTYPE.SelectedValue != "03")
                {
                    this.drpSUBTYPE.SelectedValue = "02";
                }
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
    }
    private ReturnObject<DataSet> GetSUBTYPEDataById(string LSTR_MAINTYPEID)
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
            //子行業別drpCUROUTF
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            string LSTR_MAINTYPEName = this.drpMAINTYPE.SelectedItem.Text;
            if (LSTR_MAINTYPEName == "營租")
            {
                LSTR_MAINTYPEName = "01";
            }
            else
            {
                LSTR_MAINTYPEName = "02";
            }
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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.drpMAINTYPE.SelectedValue = "01";
        this.drpSUBTYPE.SelectedValue = "02";
        this.drpTRANSTYPE.SelectedValue = "02";
        this.drpPRODCD.SelectedValue = "";
    }
    protected void cmdPrintReportA_Click(object sender, EventArgs e)
    {
        if (this.drpPRODCD.SelectedValue == "")
        {
            Alert("案件產品別不能為空");
            return;
        }
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        RTYPE.Value = "";
        RNAME.Value = "";
        try
        {
            switch (this.drpMAINTYPE.SelectedValue)
            {
                case "01":
                    if (this.drpSUBTYPE.SelectedValue == "01")//營租事務機
                    {
                        RTYPE.Value += "01,";
                        RNAME.Value = "ML1013R01";
                    }
                    else//營租非事務機
                    {
                        RTYPE.Value += "02,";
                        RNAME.Value = "ML1013R02";
                    }
                    break;

                case "02":
                    if (this.drpSUBTYPE.SelectedValue == "01")//資租事務機
                    {
                        RTYPE.Value += "01,";
                        RNAME.Value = "ML1013R01";
                    }
                    else//資租非事務機
                    {
                        RTYPE.Value += "03,";
                        RNAME.Value = "ML1013R03";
                    }
                    break;

                case "03":
                    if (this.drpSUBTYPE.SelectedValue == "01")//分期原物料
                    {
                        RTYPE.Value += "04,";
                        RNAME.Value = "ML1013R04";
                    }
                    else if (this.drpSUBTYPE.SelectedValue == "02")//分期附條買
                    {
                        RTYPE.Value += "05,";
                        RNAME.Value = "ML1013R05";
                    }
                    else if (this.drpSUBTYPE.SelectedValue == "03")//分期設備動保
                    {
                        RTYPE.Value += "04,";
                        RNAME.Value = "ML1013R04";
                    }
                    else//04 設備無設定
                    {
                        RTYPE.Value += "04,";
                        RNAME.Value = "ML1013R04";
                    }
                    break;
            }
            //Alert(RTYPE.Value+" "+ RNAME.Value);
            string url = "window.open('"+"CR/" + RNAME.Value + ".aspx?CASEID=" + "" + "& CNTRNO =" + "" + "& RPTIDX = " + RTYPE.Value + "');";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "PrintRPT", url, true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERR1", "alert('查詢錯誤，請連絡資訊人員!'" + ex.Message + ");", true);
        }
    }
}