using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      string LSTR_DocPaht = System.Web.Configuration.WebConfigurationManager.AppSettings["UploadPath"] + Request.QueryString["docpath"].ToString();
      Itg.Community.DownLoad.DownLoadText(LSTR_DocPaht);
      //Itg.Community.DownLoad.DownLoadText("c://a.doc");
    }
}
