using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.Collections.Specialized;
using System.Globalization;
using System.Data;
using System.Collections;

public partial class FrmML4002_2 : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        try
        {
          DataTable LOBJ_Data = (DataTable)Session["MLDPREINVOPEN"];

          if (LOBJ_Data.Rows.Count > 0)
          {
            //rptMLDPREINVOPENTBind(LOBJ_Data);
            rptMLDPREINVOPENBind(LOBJ_Data);
          }
          
        }
        catch (Exception ex)
        {

          Alert(ex.Message);
        }
       
      }
    }

    private void rptMLDPREINVOPENBind(DataTable dtbMLDPREINVOPEN)
    {
      DataTable dtbMLDPREINVOPENCopy = dtbMLDPREINVOPEN.Clone();
      for (int i = 0; i < dtbMLDPREINVOPEN.Rows.Count; i++)
      {
        if (dtbMLDPREINVOPEN.Rows[i]["OPENCNTRNO"] != "")
        {
          dtbMLDPREINVOPENCopy.ImportRow(dtbMLDPREINVOPEN.Rows[i]);
        }
      }
      this.rptMLDPREINVOPEN.DataSource = dtbMLDPREINVOPENCopy;
      this.rptMLDPREINVOPEN.DataBind();
    }

    protected void rptMLDPREINVOPEN_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      string strOPENCNTRNO = e.CommandArgument.ToString();
      DataTable dtbMLDPREINVOPEN = (DataTable)Session["MLDPREINVOPEN"];
      for (int i = 0; i < dtbMLDPREINVOPEN.Rows.Count; i++)
      {       
        if (dtbMLDPREINVOPEN.Rows[i]["OPENCNTRNO"].ToString() == strOPENCNTRNO)
        {
          dtbMLDPREINVOPEN.Rows[i]["OPENCNTRNO"] = "";
        }
      }
      Session["MLDPREINVOPEN"] = dtbMLDPREINVOPEN;
      rptMLDPREINVOPENBind(dtbMLDPREINVOPEN);

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        this.Dispose();
        Page.RegisterStartupScript("Close", "<script>window.close();</script>");
    }
}
