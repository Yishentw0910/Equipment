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
using System.IO;
using System.Drawing;

//Modify 20121106 SS Brent. Reason: [實貸金額]小計計算錯誤修正

public partial class FrmML6003 : PageBase
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GetUsrAndFuncInfo();
    this.hdnSysDate.Value = System.DateTime.Now.ToString("yyyy/MM/dd");
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "往來查詢";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML6003";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML6003";
    //========================             
    txtCustName.Attributes.Add("Readonly", "True");

    if (!IsPostBack)
    {
        this.txtBASEDT.Text = System.DateTime.Now.ToString("yyyy/MM/dd");
        this.hdnSysDate.Value = this.txtBASEDT.Text;
    }
    else
    {
    }

    this.txtBASEDT.Attributes.Add("style", "ime-mode:disabled;");
    this.txtBASEDT.Attributes.Add("onkeydown", "OnlyNum(this);");
    this.txtBASEDT.Attributes.Add("onblur", "txtBASEDT_onBlur(this);");
    this.txtBASEDT.Attributes.Add("onfocus", "txtBASEDT_onFocus(this);");

  }
  protected void cmdQuery_Click(object sender, EventArgs e)
  {
    try
    {
      //查詢並綁定畫面Grid資料
      rptDataBind();
    }
    catch (Exception ex)
    {
      Alert(ex.Message);
    }
  }

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

      LVAR_Parameter[0] = "SP_ML6003_Q02";
      LVAR_Parameter[1] = "'" + this.txtCustID.Text.Trim() + "','" + this.txtBASEDT.Text.Replace("/","").Trim() + "'";
      if (this.txtBASEDT.Text == this.hdnSysDate.Value)
      {
          LVAR_Parameter[1] += ",'1',''";
      }
      else
      {
          LVAR_Parameter[1] += ",'2',''";
      }
      LVAR_Parameter[1] += ",'" + ddlSOURCE.SelectedValue.ToString() + "'" + ",'" + ddlCUST.SelectedValue.ToString() + "'";
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);

      Decimal LDBL_INSURANCET = 0;
      Decimal LDBL_ACTUSLLOANST = 0;
      Decimal LDBL_ACTLOANT = 0;
      Decimal LDBL_AMOUNTNT = 0;
      Decimal LDBL_AMOUNTYT = 0;

      Decimal LDBL_SINSURANCET = 0;
      Decimal LDBL_SACTLOANT = 0;
      Decimal LDBL_SACTUSLLOANST = 0;
      Decimal LDBL_SAMOUNTNT = 0;
      Decimal LDBL_SAMOUNTYT = 0;

      string LSTR_CTYPE = "";
      if (LOBJ_Return.ReturnSuccess)
      {
        //綁定數據
        DataTable LDAT_Data = LOBJ_Return.ReturnData;
        DataTable LOBJ_TData = LDAT_Data.Copy();
        DataRow LOBJ_DataRow = null;
        int INT_ICount = 0;
        LSTR_CTYPE = LDAT_Data.Rows[0]["CTYPE"].ToString();
        for (int i = 0; i < LDAT_Data.Rows.Count; i++)
        {
          string LSTR_CTYPENOW = LDAT_Data.Rows[i]["CTYPE"].ToString();
          LDBL_SINSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
          LDBL_SACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
          LDBL_SAMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
          LDBL_SAMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
          LDBL_SACTLOANT += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTLOAN"].ToString());
          if (LSTR_CTYPE == LSTR_CTYPENOW)
          {
            LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
            LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
            LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
            LDBL_ACTLOANT += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTLOAN"].ToString());
            LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
          }
          else
          {
            LOBJ_DataRow = LOBJ_TData.NewRow();
            LOBJ_DataRow["PAYDATE"] = "";
            LOBJ_DataRow["CTYPE"] = "小計";
            LOBJ_DataRow["CNTRNO"] = "";
            LOBJ_DataRow["TNAME"] = "";
            LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
            LOBJ_DataRow["ACTLOAN"] = LDBL_ACTLOANT;
            LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;
  
            LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
            LOBJ_DataRow["CONTRACTMONTH"] = "0";
            LOBJ_DataRow["CONTRACTMONTHY"] = "0";
            LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
            LOBJ_DataRow["IRR"] = "";
            LOBJ_DataRow["RELATIONSHIP"] = "";
            LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
            INT_ICount += 1;
            LDBL_INSURANCET = 0;
            LDBL_ACTUSLLOANST = 0;
            LDBL_AMOUNTNT = 0;
            LDBL_AMOUNTYT = 0;
            LDBL_ACTLOANT = 0;

            LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
            LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
            LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
            LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
            //Modify 20121106 SS Brent. Reason: [實貸金額]小計計算錯誤修正
            LDBL_ACTLOANT += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTLOAN"].ToString());

            LSTR_CTYPE = LSTR_CTYPENOW;
          }
          if (i == LDAT_Data.Rows.Count - 1)
          {
            LOBJ_DataRow = LOBJ_TData.NewRow();
            LOBJ_DataRow["PAYDATE"] = "";
            LOBJ_DataRow["CTYPE"] = "小計";
            LOBJ_DataRow["CNTRNO"] = "";
            LOBJ_DataRow["TNAME"] = "";
            LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
            LOBJ_DataRow["ACTLOAN"] = LDBL_ACTLOANT;
            LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;

            LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
            LOBJ_DataRow["CONTRACTMONTH"] = "0";
            LOBJ_DataRow["CONTRACTMONTHY"] = "0";
            LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
            LOBJ_DataRow["IRR"] = "";
            LOBJ_DataRow["RELATIONSHIP"] = "";
            INT_ICount += 1;
            LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
            LDBL_INSURANCET = 0;
            LDBL_ACTLOANT = 0;
            LDBL_ACTUSLLOANST = 0;
            LDBL_AMOUNTNT = 0;
            LDBL_AMOUNTYT = 0;

            LOBJ_DataRow = LOBJ_TData.NewRow();
            LOBJ_DataRow["PAYDATE"] = "";
            LOBJ_DataRow["CTYPE"] = "合計";
            LOBJ_DataRow["CNTRNO"] = "";
            LOBJ_DataRow["TNAME"] = "";
            LOBJ_DataRow["GUARAMT"] = LDBL_SINSURANCET;
            LOBJ_DataRow["ACTLOAN"] = LDBL_SACTLOANT;
            LOBJ_DataRow["ACTUSLLOANS"] = LDBL_SACTUSLLOANST;

            LOBJ_DataRow["AMOUNTN"] = LDBL_SAMOUNTNT;
            LOBJ_DataRow["CONTRACTMONTH"] = "0";
            LOBJ_DataRow["CONTRACTMONTHY"] = "0";
            LOBJ_DataRow["IRR"] = "";
            LOBJ_DataRow["RELATIONSHIP"] = "";
            LOBJ_DataRow["AMOUNTY"] = LDBL_SAMOUNTYT;
            INT_ICount += 1;
            LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);

            LSTR_CTYPE = LSTR_CTYPENOW;
          }
        }
        this.rptData.DataSource = LOBJ_TData;
        this.rptData.DataBind();
        
        //開放EXCEL下載
        cmdExport.Enabled = true;
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

  private String GenerateQueryCon()
  {
    String LSTR_QueryCon;
    try
    {
      LSTR_QueryCon = "";

      //客戶統編
      if (!String.IsNullOrEmpty(this.txtCustID.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCASE.CUSTID = ''" + this.txtCustID.Text.Trim() + "''";
      }
      //客戶名稱
      if (!String.IsNullOrEmpty(this.txtCustName.Text.Trim()))
      {
        LSTR_QueryCon += " AND  MLMCUSTOMER.CUSTNAME LIKE ''%" + this.txtCustName.Text.Trim() + "%''";
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return LSTR_QueryCon;
  }


  protected void cmdExport_Click(object sender, EventArgs e)
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

          LVAR_Parameter[0] = "SP_ML6003_Q02";
          LVAR_Parameter[1] = "'" + this.txtCustID.Text.Trim() + "','" + this.txtBASEDT.Text.Replace("/", "").Trim() + "'";
          if (this.txtBASEDT.Text == this.hdnSysDate.Value)
          {
              LVAR_Parameter[1] += ",'1',''";
          }
          else
          {
              LVAR_Parameter[1] += ",'2',''";
          }
          LVAR_Parameter[1] += ",'" + ddlSOURCE.SelectedValue.ToString() + "'" + ",'" + ddlCUST.SelectedValue.ToString() + "'";

          LOBJ_Return = LOBJ_Submit.SubmitEx<DataTable>(LSTR_ObjId, LVAR_Parameter);

          Decimal LDBL_INSURANCET = 0;
          Decimal LDBL_ACTUSLLOANST = 0;
          Decimal LDBL_ACTLOANT = 0;
          Decimal LDBL_AMOUNTNT = 0;
          Decimal LDBL_AMOUNTYT = 0;

          Decimal LDBL_SINSURANCET = 0;
          Decimal LDBL_SACTLOANT = 0;
          Decimal LDBL_SACTUSLLOANST = 0;
          Decimal LDBL_SAMOUNTNT = 0;
          Decimal LDBL_SAMOUNTYT = 0;

          string LSTR_CTYPE = "";
          if (LOBJ_Return.ReturnSuccess)
          {
              //綁定數據
              DataTable LDAT_Data = LOBJ_Return.ReturnData;
              DataTable LOBJ_TData = LDAT_Data.Copy();
              DataRow LOBJ_DataRow = null;
              int INT_ICount = 0;
              LSTR_CTYPE = LDAT_Data.Rows[0]["CTYPE"].ToString();
              for (int i = 0; i < LDAT_Data.Rows.Count; i++)
              {
                  string LSTR_CTYPENOW = LDAT_Data.Rows[i]["CTYPE"].ToString();
                  LDBL_SINSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                  LDBL_SACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                  LDBL_SAMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                  LDBL_SAMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
                  LDBL_SACTLOANT += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTLOAN"].ToString());
                  if (LSTR_CTYPE == LSTR_CTYPENOW)
                  {
                      LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                      LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                      LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                      LDBL_ACTLOANT += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTLOAN"].ToString());
                      LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());
                  }
                  else
                  {
                      LOBJ_DataRow = LOBJ_TData.NewRow();
                      LOBJ_DataRow["PAYDATE"] = "";
                      LOBJ_DataRow["CTYPE"] = "小計";
                      LOBJ_DataRow["CNTRNO"] = "";
                      LOBJ_DataRow["TNAME"] = "";
                      LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
                      LOBJ_DataRow["ACTLOAN"] = LDBL_ACTLOANT;
                      LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;

                      LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
                      LOBJ_DataRow["CONTRACTMONTH"] = "0";
                      LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                      LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
                      LOBJ_DataRow["IRR"] = "";
                      LOBJ_DataRow["RELATIONSHIP"] = "";
                      LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
                      INT_ICount += 1;
                      LDBL_INSURANCET = 0;
                      LDBL_ACTUSLLOANST = 0;
                      LDBL_AMOUNTNT = 0;
                      LDBL_AMOUNTYT = 0;
                      LDBL_ACTLOANT = 0;

                      LDBL_INSURANCET += Convert.ToDecimal(LDAT_Data.Rows[i]["GUARAMT"].ToString());
                      LDBL_ACTUSLLOANST += Convert.ToDecimal(LDAT_Data.Rows[i]["ACTUSLLOANS"].ToString());
                      LDBL_AMOUNTNT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTN"].ToString());
                      LDBL_AMOUNTYT += Convert.ToDecimal(LDAT_Data.Rows[i]["AMOUNTY"].ToString());

                      LSTR_CTYPE = LSTR_CTYPENOW;
                  }
                  if (i == LDAT_Data.Rows.Count - 1)
                  {
                      LOBJ_DataRow = LOBJ_TData.NewRow();
                      LOBJ_DataRow["PAYDATE"] = "";
                      LOBJ_DataRow["CTYPE"] = "小計";
                      LOBJ_DataRow["CNTRNO"] = "";
                      LOBJ_DataRow["TNAME"] = "";
                      LOBJ_DataRow["GUARAMT"] = LDBL_INSURANCET;
                      LOBJ_DataRow["ACTLOAN"] = LDBL_ACTLOANT;
                      LOBJ_DataRow["ACTUSLLOANS"] = LDBL_ACTUSLLOANST;

                      LOBJ_DataRow["AMOUNTN"] = LDBL_AMOUNTNT;
                      LOBJ_DataRow["CONTRACTMONTH"] = "0";
                      LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                      LOBJ_DataRow["AMOUNTY"] = LDBL_AMOUNTYT;
                      LOBJ_DataRow["IRR"] = "";
                      LOBJ_DataRow["RELATIONSHIP"] = "";
                      INT_ICount += 1;
                      LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);
                      LDBL_INSURANCET = 0;
                      LDBL_ACTLOANT = 0;
                      LDBL_ACTUSLLOANST = 0;
                      LDBL_AMOUNTNT = 0;
                      LDBL_AMOUNTYT = 0;

                      LOBJ_DataRow = LOBJ_TData.NewRow();
                      LOBJ_DataRow["PAYDATE"] = "";
                      LOBJ_DataRow["CTYPE"] = "合計";
                      LOBJ_DataRow["CNTRNO"] = "";
                      LOBJ_DataRow["TNAME"] = "";
                      LOBJ_DataRow["GUARAMT"] = LDBL_SINSURANCET;
                      LOBJ_DataRow["ACTLOAN"] = LDBL_SACTLOANT;
                      LOBJ_DataRow["ACTUSLLOANS"] = LDBL_SACTUSLLOANST;

                      LOBJ_DataRow["AMOUNTN"] = LDBL_SAMOUNTNT;
                      LOBJ_DataRow["CONTRACTMONTH"] = "0";
                      LOBJ_DataRow["CONTRACTMONTHY"] = "0";
                      LOBJ_DataRow["IRR"] = "";
                      LOBJ_DataRow["RELATIONSHIP"] = "";
                      LOBJ_DataRow["AMOUNTY"] = LDBL_SAMOUNTYT;
                      INT_ICount += 1;
                      LOBJ_TData.Rows.InsertAt(LOBJ_DataRow, i + INT_ICount);

                      LSTR_CTYPE = LSTR_CTYPENOW;
                  }
              }
              //this.rptData.DataSource = LOBJ_TData;
              //this.rptData.DataBind();

              GridView GridView1 = new GridView();
              GridView1.DataSource = LOBJ_TData;
              GridView1.DataBind();
              
              //設定EXCEL表頭中文
              GridView1.HeaderRow.Cells[0].Text = "撥款日期";
              GridView1.HeaderRow.Cells[1].Text = "類型";
              GridView1.HeaderRow.Cells[2].Text = "合約編號";
              GridView1.HeaderRow.Cells[3].Text = "車型/承作標的";
              GridView1.HeaderRow.Cells[4].Text = "保證金";
              GridView1.HeaderRow.Cells[5].Text = "實貸金額";
              GridView1.HeaderRow.Cells[6].Text = "實繳總金額";
              GridView1.HeaderRow.Cells[7].Text = "未到期租金總額";
              GridView1.HeaderRow.Cells[8].Text = "租期";
              GridView1.HeaderRow.Cells[9].Text = "已繳期數";
              GridView1.HeaderRow.Cells[10].Text = "已繳金額總額";
              GridView1.HeaderRow.Cells[11].Text = "IRR";
              GridView1.HeaderRow.Cells[12].Text = "案件關係";

              Response.Clear();
              Response.Buffer = true;
              Response.Charset = "UTF-8";
              Response.AppendHeader("Content-Disposition", "attachment;filename=ML6003.xls");
              Response.ContentEncoding = System.Text.Encoding.UTF8;
              Response.ContentType = "application/ms-excel";
              System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
              System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
              GridView1.RenderControl(oHtmlTextWriter);
              Response.Output.Write(oStringWriter.ToString());
              Response.Flush();
              Response.End();

          }
          else
          {
              //this.rptData.DataSource = null;
              //this.rptData.DataBind();
              Alert("查無資料");
          }

      }
      catch (Exception ex)
      {
          throw ex;
      }

  }

  public override void VerifyRenderingInServerForm(Control control)
  { }
 

}
