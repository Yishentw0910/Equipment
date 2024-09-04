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
using System.Reflection;

public partial class FrmML6019 : PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];

    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "應收帳款遞延利息彙總表";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6019";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6019";

        //========================             
        if (!IsPostBack)
        {
            //綁定公司別下拉
            //drpCompIDBind();
            //drpDeptIDBind();
            //drpMainTypeBind();
            this.rdoDateSE.Attributes.Add("onclick", "rdoDT_onclick(this);");

            this.rdoCNTRNO.Attributes.Add("onclick", "rdoDT_onclick(this);");
            this.rdoCNTRNO.Checked = true;
        }
    }
}