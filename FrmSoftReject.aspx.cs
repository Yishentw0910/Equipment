using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmSoftReject : System.Web.UI.Page
{
  public string LSTR_CASEID = "";
  protected void Page_Load(object sender, EventArgs e)
  {
    string LSTR_Con = Request.QueryString["con"].ToString();
    LSTR_CASEID = Request.QueryString["caseid"].ToString();  
    this.txtCond.Text = LSTR_Con;
  }
}
