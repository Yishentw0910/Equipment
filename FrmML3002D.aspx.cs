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

public partial class FrmML3002D : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdCASEID.Value = Request["CASEID"].ToString().Trim(); 
        hdCNTRNO.Value = Request["CNTRNO"].ToString().Trim(); 
        hdRPTIDX.Value = Request["RPTIDX"].ToString().Trim(); 
    }
    protected void cmdPRTSURE_Click(object sender, EventArgs e)
    {
        string showMONEY = "Y";
        string showDAY = "Y";
        if (optN1.Checked == true)
        {
            showMONEY = "N";
        }

        if (optN2.Checked == true)
        {
            showDAY = "N";
        }

        //20140715 ADD BY SS ADAM REASON.增加動產設定單位
        string showIMVSETUP = "";
        if (optIMVSETUP2.Checked) { showIMVSETUP = "01"; } else { showIMVSETUP = "02"; }

        //string url = "window.open('../ML.NET/ML30/ML3008R00.aspx?SOURCE=02&CASEID=" + hdCASEID.Value + "&CNTRNO=" + hdCNTRNO.Value + "&RPTIDX=" + hdRPTIDX.Value + "&showMONEY=" + showMONEY + "&showDAY=" + showDAY + "');window.close();";
        //20140715 ADD BY SS ADAM REASON.增加動產設定單位
        string url = "window.open('../LE.NET/ML30/ML3008R00.aspx?SOURCE=02&CASEID=" + hdCASEID.Value + "&CNTRNO=" + hdCNTRNO.Value + "&RPTIDX=" + hdRPTIDX.Value + "&showMONEY=" + showMONEY + "&showDAY=" + showDAY + "&showIMVSETUP=" + showIMVSETUP + "');window.close();";
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "cmdPRTSURE_Click", url, true);
    }
    protected void cmdPRTCANCEL_Click(object sender, EventArgs e)
    {
        string url ="window.close();";
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "cmdPRTCANCEL_Click", url, true);

    }
}
