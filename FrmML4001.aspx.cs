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


public partial class FrmML4001 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
          GetUsrAndFuncInfo();
          if (GSTR_PROGNM == "") GSTR_PROGNM = this.divTitle.InnerText.Trim();
          if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4001";
          if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4001";
          if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
          if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
          if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

        if (!IsPostBack)
        {
          //綁定公司別下拉
          drpCompIDBind();
          //綁定部門別下拉
          drpDeptIDBind();
        }

        //Vincent-20100817-Add for 畫面控制項屬性設定
        PageInitProcess();

      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }

    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtStartDate.Attributes.Add("style", "ime-mode:disabled;"); 
        this.txtStartDate.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtStartDate.Attributes.Add("onblur", "txtStartDate_onBlur(this);");
        this.txtStartDate.Attributes.Add("onfocus", "txtStartDate_onFocus(this);");
        this.txtEndDate.Attributes.Add("style", "ime-mode:disabled;");
        this.txtEndDate.Attributes.Add("onkeydown", "OnlyNum(this);");
        this.txtEndDate.Attributes.Add("onblur", "txtEndDate_onBlur(this);");
        this.txtEndDate.Attributes.Add("onfocus", "txtEndDate_onFocus(this);");
    }

    /// <summary>
    /// 綁定公司別下拉
    /// </summary>
    private void drpCompIDBind()
    {
      String LSTR_ObjId;
      HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;

      String LSTR_SYSID, LSTR_DataID;
      try
      {
        LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
        //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
        LSTR_SYSID = System.Configuration.ConfigurationManager.AppSettings["SYSID"];
        LSTR_DataID = System.Configuration.ConfigurationManager.AppSettings["COMP_DATAID"];
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
        LVAR_Parameter[0] = "SP_ML0001_Q02";
        LVAR_Parameter[1] = "'" + LSTR_SYSID + "','" + LSTR_DataID + "','T'";
        LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (LOBJ_Return.ReturnSuccess)
        {
          //綁定數據
          this.drpCompID.DataSource = LOBJ_Return.ReturnData;
          this.drpCompID.DataValueField = "MCODE";
          this.drpCompID.DataTextField = "MNAME1";
          this.drpCompID.DataBind();
        }
        else
        {
            Alert("'" + LOBJ_Return.ReturnErrNum + "':" + LOBJ_Return.ReturnMessage);
//            Alert(LOBJ_Return.ReturnErrNum);
   
//          Alert("查無資料");
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// 綁定部門別下拉
    /// </summary>
    private void drpDeptIDBind()
    {
      String LSTR_ObjId;
      HtmlSubmitControl LOBJ_Submit;
      String[] LVAR_Parameter = new String[2];
      ReturnObject<DataTable> LOBJ_Return;

      try
      {
        LSTR_ObjId = "ITG.CommDBService.QueryByStoreProcedure";
        //從配置檔(Web.Config)中取得設定好的代碼表的SYSID和DATAID
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();
        LVAR_Parameter[0] = "SP_ML0001_Q02";
        LVAR_Parameter[1] = "'LE','16','T'";
        LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (LOBJ_Return.ReturnSuccess)
        {
          //綁定數據
          this.drpDeptID.DataSource = LOBJ_Return.ReturnData;
          this.drpDeptID.DataValueField = "MCODE";
          this.drpDeptID.DataTextField = "MNAME1";
          this.drpDeptID.DataBind();
        }
        else
        {
          //Alert("查無資料");
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// 組合畫面的查詢條件
    /// </summary>
    /// <returns></returns>
    private String GenerateQueryCon()
    {
      String LSTR_QueryCon;
      try
      {
        LSTR_QueryCon = "";
        //流程關卡(本畫面對應關卡: 2=案件送出審核，營業主管待核准。)
        //LSTR_QueryCon += " AND  MLMCASE.CASESTATUS = ''2''";
        //公司別
        if (!String.IsNullOrEmpty(this.drpCompID.SelectedValue.Trim()))
        {
          LSTR_QueryCon += " AND  MLMCASE.COMPID = ''" + this.drpCompID.SelectedValue.Trim() + "''";
        }

        //部門別
        if (!String.IsNullOrEmpty(this.drpDeptID.SelectedValue.Trim()))
        {
          LSTR_QueryCon += " AND  MLMCASE.DEPTID = ''" + this.drpDeptID.SelectedValue.Trim() + "''";
        }
        //業代名
        if (!String.IsNullOrEmpty(this.txtAgency.Text.Trim()))
        {
            LSTR_QueryCon += " AND  MLMCASE.EMPLID = ''" + this.txtAgency.Text.Trim() + "''";
        }
        //客戶統編
        if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim()))
        {
            LSTR_QueryCon += " AND  MLMCASE.CUSTID = ''" + Request.Form.GetValues("txtCustID")[0].ToString().Trim() + "''";
        }
        //合約編號
        if (!String.IsNullOrEmpty(this.txtCNTRNO.Text.Trim()))
        {
          LSTR_QueryCon += " AND  MLMCONTRACT.CNTRNO = ''" + this.txtCNTRNO.Text.Trim() + "''";
        }

        //撥款確認日起迄-起
        if (!String.IsNullOrEmpty(this.txtStartDate.Text.Trim()))
        {
            LSTR_QueryCon += " AND  VDATE  >= ''" + Itg.Community.Util.GetADYear(this.txtStartDate.Text.Trim()) + "''";
        }
        //撥款確認日起迄-迄
        if (!String.IsNullOrEmpty(this.txtEndDate.Text.Trim()))
        {
            LSTR_QueryCon += " AND  VDATE  <= ''" + Itg.Community.Util.GetADYear(this.txtEndDate.Text.Trim()) + "''";
        }

      }
      catch (Exception ex)
      {
        throw ex;
      }
      return LSTR_QueryCon;
    }


  

    /// <summary>
    /// 綁定畫面Grid數據
    /// </summary>
    private void rptDataBind()
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
        LSTR_QueryCon = this.GenerateQueryCon();
        //查詢資料
        LOBJ_Submit = new Comus.HtmlSubmitControl();
        LOBJ_Submit.VirtualPath = PageBase.GetComusVirtualPath();

        LVAR_Parameter[0] = "SP_ML4001_Q01";
        LVAR_Parameter[1] = "'" + LSTR_QueryCon + "'";

        LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);
        if (LOBJ_Return.ReturnSuccess)
        {
          //綁定數據
          this.rptData.DataSource = LOBJ_Return.ReturnData;
          this.rptData.DataBind();
        }
        else
        {
          this.rptData.DataSource = null;
          this.rptData.DataBind();
          Alert("查無資料");
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }



    /// <summary>
    /// 查詢案件資料
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cmdQuery_Click(object sender, EventArgs e)
    {
      try
      {
        //查詢並綁定畫面Grid資料
        this.rptDataBind();
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }
    }
    

   

}
