using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmML4004A_3 : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string LSTR_Main = Request.QueryString["main"];
        this.txtMain.Text = LSTR_Main;
      }
     
    }
}
