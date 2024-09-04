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

public partial class FrmML4002_1 : Itg.Community.PageBase
{
    string strCNTRNO = "";
    string strOPENMONTH = "";
    string strOPENCNTRNO = "";
    string strCUSTID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4002_1";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4002_1";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

        strCNTRNO = Request.QueryString["CNTRNO"];
        strOPENCNTRNO = Request.QueryString["OPENCNTRNO"];
        strOPENMONTH = Request.QueryString["OPENMONTH"];
        strCUSTID = Request.QueryString["CUSTID"];

      if (!Page.IsPostBack)
      {
        try
        {
            DataTable LOBJ_Data = (DataTable)Session["MLDPREINVOPENMAJCNTR"];
            if (LOBJ_Data.Rows.Count == 0 || LOBJ_Data == null)
            {
                //rptMLDPREINVOPENMAJCNTRTBind(LOBJ_Data);
                //rptMLDPREINVOPENMAJCNTRBind(LOBJ_Data);
                rptData_Bind();
            }
            else
            {
                this.rptMLDPREINVOPENMAJCNTR.DataSource = LOBJ_Data;
                this.rptMLDPREINVOPENMAJCNTR.DataBind();
                if (LOBJ_Data.Rows.Count == 1)
                {
                    ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[0].FindControl("optMaster")).Checked = true;
                }
                else
                {
                    for (int intRow = 0; intRow < rptMLDPREINVOPENMAJCNTR.Items.Count; intRow++)
                    {
                        if (((HiddenField)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("hdnCNTRNO")).Value.Trim() == strOPENCNTRNO)
                        {
                            ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("optMaster")).Checked = true;
                            break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

          Alert(ex.Message);
        }
       
      }
    }

    private void rptMLDPREINVOPENMAJCNTRBind(DataTable dtbMLDPREINVOPENMAJCNTR)
    {
      this.rptMLDPREINVOPENMAJCNTR.DataSource = dtbMLDPREINVOPENMAJCNTR;
      this.rptMLDPREINVOPENMAJCNTR.DataBind();
      if (dtbMLDPREINVOPENMAJCNTR.Rows.Count == 1)
      {
          ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[0].FindControl("optMaster")).Checked = true;
      }
      else
      {
          for (int intRow = 0; intRow < rptMLDPREINVOPENMAJCNTR.Items.Count; intRow++)
          {
              if (((HiddenField)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("hdnCNTRNO")).Value.Trim() == strOPENCNTRNO)
              {
                  ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("optMaster")).Checked = true;
                  break;
              }
          }
      }
    }

    private void rptData_Bind()
    {
        String LSTR_ObjId;
        HtmlSubmitControl LOBJ_Submit;
        String[] LVAR_Parameter = new String[2];
        ReturnObject<DataTable> objReturnObj;

        String LSTR_QueryCon;

        try
        {
            decimal decDISAMOUNTTTL = 0;

            LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
            //取得查詢條件
            LSTR_QueryCon = "AND  AND D.CUSTID = ''" + strCUSTID + "'' AND A.OPENMONTH = ''" + strOPENMONTH + "''";
            //查詢資料
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

            LVAR_Parameter[0] = "SP_ML4001_Q12";
            LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

            objReturnObj = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
            if (objReturnObj.ReturnSuccess)
            {
                //綁定數據
                this.rptMLDPREINVOPENMAJCNTR.DataSource = objReturnObj.ReturnData;
                this.rptMLDPREINVOPENMAJCNTR.DataBind();
                if (objReturnObj.ReturnData.Rows.Count == 1)
                {
                    ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[0].FindControl("optMaster")).Checked = true;
                }
                else
                {
                    for (int intRow = 0; intRow < rptMLDPREINVOPENMAJCNTR.Items.Count; intRow++)
                    {
                        if (((HiddenField)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("hdnCNTRNO")).Value.Trim() == strOPENCNTRNO)
                        {
                            ((RadioButton)rptMLDPREINVOPENMAJCNTR.Items[intRow].FindControl("optMaster")).Checked = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                this.rptMLDPREINVOPENMAJCNTR.DataSource = null;
                this.rptMLDPREINVOPENMAJCNTR.DataBind();
                Alert("查無資料");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rptMLDPREINVOPENMAJCNTR_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      string strOPENCNTRNO = e.CommandArgument.ToString();
      DataTable dtbMLDPREINVOPENMAJCNTR = (DataTable)Session["MLDPREINVOPENMAJCNTR"];
      for (int i = 0; i < dtbMLDPREINVOPENMAJCNTR.Rows.Count; i++)
      {       
        if (dtbMLDPREINVOPENMAJCNTR.Rows[i]["OPENCNTRNO"].ToString() == strOPENCNTRNO)
        {
          dtbMLDPREINVOPENMAJCNTR.Rows[i]["OPENCNTRNO"] = "";
        }
      }
      Session["MLDPREINVOPENMAJCNTR"] = dtbMLDPREINVOPENMAJCNTR;
      rptMLDPREINVOPENMAJCNTRBind(dtbMLDPREINVOPENMAJCNTR);

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        this.Dispose();
        Page.RegisterStartupScript("Close", "<script>window.close();</script>");
    }
}
