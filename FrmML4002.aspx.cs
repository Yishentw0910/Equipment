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


public partial class FrmML4002 : Itg.Community.PageBase
{
    string strOPENCNTRNO = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4002";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4002";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

        strOPENCNTRNO = Request.QueryString["OPENCNTRNO"];

        if (!Page.IsPostBack)
        {
            try
            {
               rptMLDPREINVOPENCNTRBind();
            }
            catch (Exception ex)
            {

              Alert(ex.Message);
            }
        }
    }


    private void rptMLDPREINVOPENCNTRBind()
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
            LSTR_QueryCon = "AND B.OPENCNTRNO = ''" + strOPENCNTRNO + "''";
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

            LVAR_Parameter[0] = "SP_ML4001_Q06";
            LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

            LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (LOBJ_Return.ReturnSuccess)
            {
                //綁定數據
                this.rptMLDPREINVOPENCNTR.DataSource = LOBJ_Return.ReturnData;
                this.rptMLDPREINVOPENCNTR.DataBind();
            }
            else
            {
                this.rptMLDPREINVOPENCNTR.DataSource = null;
                this.rptMLDPREINVOPENCNTR.DataBind();
                Alert("查無資料");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rptMLDPREINVOPENCNTR_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        rptMLDPREINVOPENCNTRBind();
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        this.Dispose();
    }
}
