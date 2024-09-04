using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ITG.Community;
using Itg.Community;
using Comus;
using System.Text;

/*********************************************
* 程式名稱 : FrmML3003A_a.ASPX.CS
* 程式功能 : 關係人合約撥款檢核
* 作    者 : Maureen
* 新增日期 : 2012/11/21
* 修改日期 : 
Modify 20121217 By SS Steven. Reason: 輸入完合約編號，不要帶出申請書編號.
*********************************************/

public partial class FrmML3003A_a : Itg.Community.PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    
    protected void Page_Load(object sender, EventArgs e)
    {
        iniScript();
        //判斷SESSION是否過期
        if (Session["UserID"] == null)
        {
            string LSTR_URL = System.Configuration.ConfigurationManager.AppSettings["LoginPP"];
            Response.Redirect(LSTR_URL);
            Response.End();
        }

        if (IsPostBack) return;

        SESSION_SET();
    }

    #region 初始設定============================================
    public void iniScript()
    {
        this.txtCNTRNO.Attributes.Add("style", "ime-mode:disabled");
        this.txtCNTRNO.Attributes.Add("onblur", "txt_Toupper(this)");

        //Modify 20121217 By SS Steven. Reason: 輸入完合約編號，不要帶出申請書編號。
        //this.txtCNTRNO.Attributes.Add("onblur", "GetCaseID(this)");
        this.txtCASEID.Attributes.Add("style", "ime-mode:disabled");
        this.txtCASEID.Attributes.Add("onblur", "txt_Toupper(this)");
    }
    #endregion

    protected void cmdPRINT_Click(object sender, EventArgs e)
    {
        if (this.txtCNTRNO.Text == "" && this.txtCASEID.Text == "") {
            Alert("合約編號或申請書案號請至少擇一輸入");
            return;
        }
        
        StringBuilder LSTR_Data = new StringBuilder();
        string LSTR_CNTRNO = this.txtCNTRNO.Text;
        string LSTR_CASEID = this.txtCASEID.Text;
        string LSTR_PRINTKEY = System.DateTime.Now.ToString("yyyyMMdd") + SessUSERID.Value;
        this.hdnPRINTKEY.Value = LSTR_PRINTKEY;
        //Alert(LSTR_CNTRNO + "','" + LSTR_CASEID + "','" + LSTR_PRINTKEY);

        LSTR_Data.Append("SP_ML3004_I01" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_CNTRNO + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_CASEID + GSTR_TabDelimitChar);
        LSTR_Data.Append(LSTR_PRINTKEY + GSTR_TabDelimitChar);
        LSTR_Data.Append(SessUSERID.Value);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data.Append("SP_ML3004_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_PRINTKEY + GSTR_TabDelimitChar);
        LSTR_Data.Append(SessUSERID.Value);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
        //=========================================================================
        LSTR_Data = LSTR_Data.Replace("'", "’");
        LSTR_Data = LSTR_Data.Replace("\"", "”");
        LSTR_Data = LSTR_Data.Replace("--", "－－");
        //========================================================================= 
        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                getDATES();
                //RegisterScript("cmdPRINT_Click(document.getElementById('" + this.cmdPRINT.ClientID + "'));");
                RegisterScript("cmdPRINT_Click('" + this.cmdPRINT.ClientID + "');");
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


    // 取得送信管徵審日、營業單位撥款放行日、信管單位撥款放行日日期
    private void getDATES()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> LOBJ_Return;
        string LSTR_CNTRNO = this.txtCNTRNO.Text;
        string LSTR_CASEID = this.txtCASEID.Text;

        try
        {
            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
            LVAR_Parameter[0] = "SP_ML3004_Q01";
            LVAR_Parameter[1] = "'" + LSTR_CNTRNO + "','" + LSTR_CASEID + "','" + SessUSERNM.Value + "','" + SessDEPTNM.Value + "','','','',''";

            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                DataTable LOBJ_Data = LOBJ_Return.ReturnData;
                this.hdnINDT.Value = LOBJ_Data.Rows[0]["INDT"].ToString().Replace("/", "").Trim();          //送信管徵審日
                this.hdnTRADEDT.Value = LOBJ_Data.Rows[0]["TRADEDT"].ToString().Replace("/", "").Trim();    //營業單位撥款放行日
                this.hdnCREDITDT.Value = LOBJ_Data.Rows[0]["CREDITDT"].ToString().Replace("/", "").Trim();  //信管單位撥款放行日
                //Alert(this.hdnINDT.Value + "，" + this.hdnTRADEDT.Value + "，" + this.hdnCREDITDT.Value);
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

    protected void cmdCLEAR_Click(object sender, EventArgs e)
    {
        this.txtCNTRNO.Text = "";
        this.txtCASEID.Text = "";
    }


    #region SESSION設定
    public void SESSION_SET()
    {
        SessUSERID.Value = Session["UserID"].ToString().Trim();
        SessUSERNM.Value = Session["USERNM"].ToString().Trim();
        SessLOGINTIME.Value = Session["LOGINTIME"].ToString().Trim();
        SessEMPLID.Value = Session["EMPLID"].ToString().Trim();
        SessBRNHCD.Value = Session["BRNHCD"].ToString().Trim();
        SessDBNM.Value = Session["DBNM"].ToString().Trim();
        SessMTSSVRNM.Value = Session["MTSSVRNM"].ToString().Trim();
        SessSQLSVRNM.Value = Session["SQLSVRNM"].ToString().Trim();
        SessSYSCD.Value = Session["SYSCD"].ToString().Trim();
        SessGROUPID.Value = Session["GROUPID"].ToString().Trim();
        SessDATAGP.Value = Session["DATAGP"].ToString().Trim();
        SessDLRCD.Value = Session["DLRCD"].ToString().Trim();
        SessDLRNM.Value = Session["DLRNM"].ToString().Trim();
        SessDEPTID.Value = Session["DEPTID"].ToString().Trim();
        SessDEPTNM.Value = Session["DEPTNM"].ToString().Trim();
        SessFN_DEPTNM.Value = Session["FN_DEPTNM"].ToString().Trim();
        SessFN_DEPTID.Value = Session["FN_DEPTID"].ToString().Trim();
        SessFN_DEPTUID.Value = Session["FN_DEPTUID"].ToString().Trim();
        SessGV_DEPTNM.Value = Session["GV_DEPTNM"].ToString().Trim();
        SessGV_DEPTID.Value = Session["GV_DEPTID"].ToString().Trim();
        SessGV_DEPTUID.Value = Session["GV_DEPTUID"].ToString().Trim();
        REMOTEHOST.Value = Request.ServerVariables["REMOTE_HOST"].ToString();

        SessionString.Value = SessUSERID.Value.Trim() + "^P^";
        SessionString.Value += SessUSERNM.Value.Trim() + "^P^";
        SessionString.Value += SessLOGINTIME.Value.Trim() + "^P^";
        SessionString.Value += SessEMPLID.Value.Trim() + "^P^";
        SessionString.Value += SessBRNHCD.Value.Trim() + "^P^";
        SessionString.Value += SessDBNM.Value.Trim() + "^P^";
        SessionString.Value += SessMTSSVRNM.Value.Trim() + "^P^";
        SessionString.Value += SessSQLSVRNM.Value.Trim() + "^P^";
        SessionString.Value += SessSYSCD.Value.Trim() + "^P^";
        SessionString.Value += SessGROUPID.Value.Trim() + "^P^";
        SessionString.Value += SessDATAGP.Value.Trim() + "^P^";
        SessionString.Value += SessDLRCD.Value.Trim() + "^P^";
        SessionString.Value += SessDLRNM.Value.Trim() + "^P^";
        SessionString.Value += SessDEPTID.Value.Trim() + "^P^";
        SessionString.Value += SessDEPTNM.Value.Trim() + "^P^";
        SessionString.Value += SessFN_DEPTNM.Value.Trim() + "^P^";
        SessionString.Value += SessFN_DEPTID.Value.Trim() + "^P^";
        SessionString.Value += SessFN_DEPTUID.Value.Trim() + "^P^";
        SessionString.Value += SessGV_DEPTNM.Value.Trim() + "^P^";
        SessionString.Value += SessGV_DEPTID.Value.Trim() + "^P^";
        SessionString.Value += SessGV_DEPTUID.Value.Trim() + "^P^";
        SessionString.Value += SUBSCD.Value.Trim() + "^P^";
        SessionString.Value += PROGID.Value.Trim() + "^P^";
        SessionString.Value += REMOTEHOST.Value;
        SessionString.Value = Server.UrlEncode(SessionString.Value);
    }
    #endregion
}