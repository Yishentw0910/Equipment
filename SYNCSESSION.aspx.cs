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

public partial class SYNCSESSION : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["USERID"] != null) Session.Add("USERID", Request.QueryString["USERID"]);
        if (Request.QueryString["USERNM"] != null) Session.Add("USERNM", Request.QueryString["USERNM"]);
        if (Request.QueryString["LOGINTIME"] != null) Session.Add("LOGINTIME", Request.QueryString["LOGINTIME"]);
        if (Request.QueryString["EMPLID"] != null) Session.Add("EMPLID", Request.QueryString["EMPLID"]);
        if (Request.QueryString["BRNHCD"] != null) Session.Add("BRNHCD", Request.QueryString["BRNHCD"]);
        if (Request.QueryString["DBNM"] != null) Session.Add("DBNM", Request.QueryString["DBNM"]);
        if (Request.QueryString["MTSSVRNM"] != null) Session.Add("MTSSVRNM", Request.QueryString["MTSSVRNM"]);
        if (Request.QueryString["SQLSVRNM"] != null) Session.Add("SQLSVRNM", Request.QueryString["SQLSVRNM"]);
        if (Request.QueryString["SYSCD"] != null) Session.Add("SYSCD", Request.QueryString["SYSCD"]);
        if (Request.QueryString["GROUPID"] != null) Session.Add("GROUPID", Request.QueryString["GROUPID"]);
        if (Request.QueryString["DATAGP"] != null) Session.Add("DATAGP", Request.QueryString["DATAGP"]);
        if (Request.QueryString["DLRCD"] != null) Session.Add("DLRCD", Request.QueryString["DLRCD"]);
        if (Request.QueryString["DLRNM"] != null) Session.Add("DLRNM", Request.QueryString["DLRNM"]);
        if (Request.QueryString["DEPTID"] != null) Session.Add("DEPTID", Request.QueryString["DEPTID"]);
        if (Request.QueryString["DEPTNM"] != null) Session.Add("DEPTNM", Request.QueryString["DEPTNM"]);

        if (Request.QueryString["FN_DEPTNM"] != null) Session.Add("FN_DEPTNM", Request.QueryString["FN_DEPTNM"]);
        if (Request.QueryString["FN_DEPTID"] != null) Session.Add("FN_DEPTID", Request.QueryString["FN_DEPTID"]);
        if (Request.QueryString["FN_DEPTUID"] != null) Session.Add("FN_DEPTUID", Request.QueryString["FN_DEPTUID"]);
        if (Request.QueryString["GV_DEPTNM"] != null) Session.Add("GV_DEPTNM", Request.QueryString["GV_DEPTNM"]);
        if (Request.QueryString["GV_DEPTID"] != null) Session.Add("GV_DEPTID", Request.QueryString["GV_DEPTID"]);
        if (Request.QueryString["GV_DEPTUID"] != null) Session.Add("GV_DEPTUID", Request.QueryString["GV_DEPTUID"]);

        //20141204 ADD BY SS ADAM REASON.增加同步ML_UL SESSION
        string s = "/LE_UL/SYNCSESSION.aspx?";
        if (Request.QueryString["USERID"] != null) s += "USERID=" + Request.QueryString["USERID"];
        if (Request.QueryString["USERNM"] != null) s += "&USERNM=" + Request.QueryString["USERNM"];
        if (Request.QueryString["LOGINTIME"] != null) s += "&LOGINTIME=" + Request.QueryString["LOGINTIME"];
        if (Request.QueryString["EMPLID"] != null) s += "&EMPLID=" + Request.QueryString["EMPLID"];
        if (Request.QueryString["BRNHCD"] != null) s += "&BRNHCD=" + Request.QueryString["BRNHCD"];
        if (Request.QueryString["DBNM"] != null) s += "&DBNM=" + Request.QueryString["DBNM"];
        if (Request.QueryString["MTSSVRNM"] != null) s += "&MTSSVRNM=" + Request.QueryString["MTSSVRNM"];
        if (Request.QueryString["SQLSVRNM"] != null) s += "&SQLSVRNM=" + Request.QueryString["SQLSVRNM"];
        if (Request.QueryString["SYSCD"] != null) s += "&SYSCD=" + Request.QueryString["SYSCD"];
        if (Request.QueryString["GROUPID"] != null) s += "&GROUPID=" + Request.QueryString["GROUPID"];
        if (Request.QueryString["DATAGP"] != null) s += "&DATAGP=" + Request.QueryString["DATAGP"];
        if (Request.QueryString["DLRCD"] != null) s += "&DLRCD=" + Request.QueryString["DLRCD"];
        if (Request.QueryString["DLRNM"] != null) s += "&DLRNM=" + Request.QueryString["DLRNM"];
        if (Request.QueryString["DEPTID"] != null) s += "&DEPTID=" + Request.QueryString["DEPTID"];
        if (Request.QueryString["DEPTNM"] != null) s += "&DEPTNM=" + Request.QueryString["DEPTNM"];
        if (Request.QueryString["FN_DEPTNM"] != null) s += "&FN_DEPTNM=" + Request.QueryString["FN_DEPTNM"];
        if (Request.QueryString["FN_DEPTID"] != null) s += "&FN_DEPTID=" + Request.QueryString["FN_DEPTID"];
        if (Request.QueryString["FN_DEPTUID"] != null) s += "&FN_DEPTUID=" + Request.QueryString["FN_DEPTUID"];
        if (Request.QueryString["GV_DEPTNM"] != null) s += "&GV_DEPTNM=" + Request.QueryString["GV_DEPTNM"];
        if (Request.QueryString["GV_DEPTID"] != null) s += "&GV_DEPTID=" + Request.QueryString["GV_DEPTID"];
        if (Request.QueryString["GV_DEPTUID"] != null) s += "&GV_DEPTUID=" + Request.QueryString["GV_DEPTUID"];

        Response.Redirect(s);



        Response.Write("OK");
    }
}
