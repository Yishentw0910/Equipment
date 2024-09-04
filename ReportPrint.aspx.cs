using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class ReportPrint : Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (IsOutOfBand())
    {
      return;
    }
  }
  private bool IsOutOfBand()
  {
    bool isCallback = false;
    isCallback = String.Equals(Page.Request.QueryString["outofband"], "true", StringComparison.OrdinalIgnoreCase);
    if (isCallback)
    {
      string cUrl = Request.QueryString["cUrl"].ToString();
      string cPath = Request.QueryString["cPath"].ToString();
      string cUserName = Request.QueryString["cUserName"].ToString();
      string cPass = Request.QueryString["cPass"].ToString();
      string cCompany = Request.QueryString["cCompany"].ToString();
      string cSys = Request.QueryString["cSys"].ToString();
      string cLog = Request.QueryString["cLog"].ToString();
      string cQuery = Request.QueryString["cQuery"].ToString().Replace(';', '&');
      string LSTR_Return = "";
      LSTR_Return = Print(cUrl, cPath, cUserName, cPass, cCompany, cSys, cLog, cQuery);
      Response.Clear();
      Response.Write(LSTR_Return);
      Response.Flush();
      Response.End();
      return true;
    }
    return false;
  }
    public string Print(string cUrl, string cPath, string cUserName, string cPass, string cCompany, string cSys, string cLog, string txtQUERY)
    {
        try
        {
            string cGUID = "";
            string txtURL = "";
            string txtGUID = "";

            //System.Type oType = System.Type.GetTypeFromProgID("LcloginP.lclogin");
            //object objPrint = System.Activator.CreateInstance(oType);
            //oType.InvokeMember("Init", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { "lc16888" });
            //cGUID = oType.InvokeMember("Login", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { cUrl, cPath, cUserName, cPass, cLog, cCompany }).ToString();

            //txtGUID = cGUID;
            //txtURL = cUrl.Trim() + "/Default.aspx?GUID=" + cGUID + "&sys=" + cSys.Trim() + "&Page=" + cLog.Trim() + "&SQ_AutoLogout=true&Project=" + cPath.Trim() + txtQUERY.Trim();
            //oType.InvokeMember("LogoutSession", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { cUrl.Trim(), txtGUID.Trim() });
            txtURL = "http://wbxhfc18/LLAPP/SMARTQ?" + "path=" + cPath.Trim() + "&filename=" + cLog.Trim() + "&sys=" + cSys.Trim() + "&Type = squery&AutoLogout=true&URL=" + cUrl + "&" +txtQUERY.Trim() + "&IsDirect=True";
            return txtURL;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    //public string Print(string cUrl, string cPath, string cUserName, string cPass, string cCompany, string cSys, string cLog, string txtQUERY)
    //{
    //  try
    //  {
    //    string cGUID = "";
    //    string txtURL = "";
    //    string txtGUID = "";

    //    System.Type oType = System.Type.GetTypeFromProgID("LcloginP.lclogin");
    //    object objPrint = System.Activator.CreateInstance(oType);
    //    oType.InvokeMember("Init", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { "lc16888" });
    //    cGUID = oType.InvokeMember("Login", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { cUrl, cPath, cUserName, cPass, cLog, cCompany }).ToString();

    //    txtGUID = cGUID;
    //    txtURL = cUrl.Trim() + "/Squery.aspx?GUID=" + cGUID + "&sys=" + cSys.Trim() + "&filename=" + cLog.Trim() + "&SQ_AutoLogout=true&Path=" + cPath.Trim() + txtQUERY.Trim();
    //    oType.InvokeMember("LogoutSession", System.Reflection.BindingFlags.InvokeMethod, null, objPrint, new object[] { cUrl.Trim(), txtGUID.Trim() });
    //    return txtURL;
    //  }
    //  catch (Exception ex)
    //  {
    //    return ex.Message;
    //  }
    //}
}
