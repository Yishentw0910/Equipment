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

public partial class FrmML4003 : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        GetUsrAndFuncInfo();
        if (GSTR_PROGNM == "") GSTR_PROGNM = "拆發票設定";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML4003";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML4003";
        if (GSTR_DEPTID == "") GSTR_DEPTID = "XDB0";
        if (GSTR_A_USERID == "") GSTR_A_USERID = "20321";
        if (GSTR_U_USERID == "") GSTR_U_USERID = "20321";

        this.hdnCUSTNO.Value = Request.QueryString["custid"];
        this.hdnCUSTNME.Value = Request.QueryString["custnme"];
        String strChgSingle = Request.QueryString["ChgSingle"];
        String strRPRINCIPALTAX = Request.QueryString["RPRINCIPALTAX"];
 
     if (!Page.IsPostBack)
      {
        try
        {
  //          Session["MLDPREINVSPLIT"] = null;
  //          MLDPREINVSPLIT_Init();
            FormDDLBinding();
            DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
            DataTable dtbMLDPREINVSPLIT;
            if (strChgSingle == "Y")
            {
                dtbMLDPREINVSPLIT = new DataTable("MLDPREINVSPLIT");
                //預開發票彙開設定代碼
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSPLITID", System.Type.GetType("System.String")));
                //預開發票設定代碼
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSETID", System.Type.GetType("System.String")));
                //發票群組
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVGRP", System.Type.GetType("System.String")));
                //單體編號
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
                //對象統編
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
                //對象名稱
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
                //月付款
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
                //發票郵遞區號
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
                //發票郵遞區號
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
                //發票地址
                dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
                Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
            }
            else
            {
                dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
            }

            this.hdnMLDCONTRACTTARGETRowCount.Value = dtbMLDCONTRACTTARGET.Rows.Count.ToString();
            if (dtbMLDCONTRACTTARGET.Rows.Count > 0)
            {
                decimal decMONTHPAYTTL = System.Convert.ToDecimal(strRPRINCIPALTAX.Replace(",","").Trim());                
                for (int intRowCnt = 0; intRowCnt < dtbMLDCONTRACTTARGET.Rows.Count; intRowCnt++)
                {
                    if (intRowCnt != dtbMLDCONTRACTTARGET.Rows.Count - 1)
                    {
                        dtbMLDCONTRACTTARGET.Rows[intRowCnt]["MONTHPAY"] = (System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETPRICEA"]) * System.Convert.ToDecimal(strRPRINCIPALTAX.Replace(",", "").Trim())).ToString("#,##0");
                        decMONTHPAYTTL -= System.Convert.ToDecimal(dtbMLDCONTRACTTARGET.Rows[intRowCnt]["MONTHPAY"]);
                    }
                    else
                    {
                        dtbMLDCONTRACTTARGET.Rows[intRowCnt]["MONTHPAY"] = decMONTHPAYTTL.ToString("#,##0");
                    }
                    this.hdnUNITID.Value += "," + dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETID"];
                }
                this.hdnUNITID.Value += ",";
                this.hdnMONTHPAYTTL.Value = strRPRINCIPALTAX.Replace(",","");
                this.spanMONTHPAYTTL.Text = strRPRINCIPALTAX;
                rptMLDCONTRACTTARGETBind(dtbMLDCONTRACTTARGET);
                rptMLDPREINVSPLIT_Bind(dtbMLDPREINVSPLIT);
                if (dtbMLDPREINVSPLIT.Rows.Count != 0)
                {
                    this.btnConfirm.Enabled = true;
                }
                else
                {
                    this.btnConfirm.Enabled = false;
                }
            }
          
        }
        catch (Exception ex)
        {

          Alert(ex.Message);
        }
       
      }
    }

    private void rptMLDPREINVSPLIT_Bind(DataTable dtbMLDPREINVSPLITCopy)
    {
      DataTable dtbMLDPREINVSPLIT = dtbMLDPREINVSPLITCopy.Clone();
      decimal decTTLAMT = 0;
      for (int i = 0; i < dtbMLDPREINVSPLITCopy.Rows.Count; i++)
      {
       // if (dtbMLDPREINVSPLITCopy.Rows[i]["OPENCNTRNO"] != "")
      //  {
          dtbMLDPREINVSPLIT.ImportRow(dtbMLDPREINVSPLITCopy.Rows[i]);
       // }
      }
      for (int i = 0; i < dtbMLDPREINVSPLIT.Rows.Count; i++)
      {
          dtbMLDPREINVSPLIT.Rows[i]["INVOICEADDR"] = dtbMLDPREINVSPLIT.Rows[i]["INVOICEADDR"].ToString().Trim().Replace(dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"].ToString().Trim(), "");
          decTTLAMT += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"]);
      }
      this.spanSPLTMONTHPAYTTL.Text = decTTLAMT.ToString("##,##0");
      this.rptMLDPREINVSPLIT.DataSource = dtbMLDPREINVSPLIT;
      this.rptMLDPREINVSPLIT.DataBind();
    }

    private void rptMLDCONTRACTTARGETBind(DataTable dtbMLDCONTRACTTARGET)
    {
      this.rptMLDCONTRACTTARGET.DataSource = dtbMLDCONTRACTTARGET;
      this.rptMLDCONTRACTTARGET.DataBind();
    }


    protected void rptMLDPREINVSPLIT_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      //string strOPENCNTRNO = e.CommandArgument.ToString();
      //DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVOPEN"];
      //for (int i = 0; i < dtbMLDPREINVSPLIT.Rows.Count; i++)
      //{       
      //  if (dtbMLDPREINVSPLIT.Rows[i]["OPENCNTRNO"].ToString() == strOPENCNTRNO)
      //  {
      //    dtbMLDPREINVSPLIT.Rows[i]["OPENCNTRNO"] = "";
      //    dtbMLDPREINVSPLIT.Rows[i]["OPENCNTRNOB"] = "true";
      //  }
      //}
      //Session["MLDPREINVOPEN"] = dtbMLDPREINVSPLIT;
      //rptMLDCONTRACTTARGETBind(dtbMLDPREINVSPLIT);
      //rptMLDPREINVSPLIT_Bind(dtbMLDPREINVSPLIT);

    }
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        AddMLDPREINVSPLITRow();
    }

    protected void btnDelRow_Click(object sender, EventArgs e)
    {
        if (this.hdnSelectedRow.Value.Trim() != "")
        {
            DelMLDPREINVSPLITRow(this.hdnSelectedRow.Value);
        }
    }

    private void AddMLDPREINVSPLITRow()
    {
        MLDPREINVSPLIT_Init();
        //更新暫存資料
        DataTable dtbMLDPREINVSPLIT = updateMLDPREINVSPLIT();
        DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
        //新增一筆資料          
        DataRow dtrMLDPREINVSPLIT = dtbMLDPREINVSPLIT.NewRow();
        dtrMLDPREINVSPLIT["PREINVSPLITID"] = "";
        dtrMLDPREINVSPLIT["PREINVSETID"] = "";
        dtrMLDPREINVSPLIT["INVGRP"] = "";
        dtrMLDPREINVSPLIT["UNITID"] = dtbMLDCONTRACTTARGET.Rows[0]["TARGETID"];
        dtrMLDPREINVSPLIT["TARGETID"] = "";
        dtrMLDPREINVSPLIT["TARGETNAME"] = "";
        dtrMLDPREINVSPLIT["MONTHPAY"] = "0";
        dtrMLDPREINVSPLIT["INVZIPCODE"] = "";
        dtrMLDPREINVSPLIT["INVZIPCODES"] = "";
        dtrMLDPREINVSPLIT["INVOICEADDR"] = "";
        dtbMLDPREINVSPLIT.Rows.Add(dtrMLDPREINVSPLIT);
        if (dtbMLDPREINVSPLIT.Rows.Count != 0)
        {
            this.btnConfirm.Enabled = true;
        }
        else
        {
            this.btnConfirm.Enabled = false;
        }
        this.hdnMLDPREINVSPLITRowCount.Value = dtbMLDPREINVSPLIT.Rows.Count.ToString();
        Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
        MLDPREINVSPLIT_Bind();
    }

    private void DelMLDPREINVSPLITRow(string strRowIndex)
    {
        //更新暫存資料
        DataTable dtbMLDPREINVSPLIT = updateMLDPREINVSPLIT();
        //刪除一筆資料
        if (dtbMLDPREINVSPLIT.Rows.Count >= Convert.ToInt32(strRowIndex))
        {
            dtbMLDPREINVSPLIT.Rows.RemoveAt(Convert.ToInt32(strRowIndex));
            if (dtbMLDPREINVSPLIT.Rows.Count != 0)
            {
                this.btnConfirm.Enabled = true;
            }
            else
            {
                this.btnConfirm.Enabled = false;
            }
            this.hdnMLDPREINVSPLITRowCount.Value = dtbMLDPREINVSPLIT.Rows.Count.ToString();
            this.hdnSelectedRow.Value = "";
            Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
            MLDPREINVSPLIT_Bind();
        }
    }

    public DataTable updateMLDPREINVSPLIT()
    {
        DataTable dtbMLDCONTRACTTARGET_New = new DataTable("MLDCONTRACTTARGET_New");
        //單體編號
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
        //擔保品金額比例
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETPRICEA", System.Type.GetType("System.String")));
        //擔保品金額 
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
        //郵遞區號
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
        //郵遞區號地址
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
        //發票記送地址
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
        //發票統編
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
        //發票抬頭
        dtbMLDCONTRACTTARGET_New.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
        
        Decimal decMONTHPAY = 0;
        DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
        //先賦值
        
        for (int i = 0; i < rptMLDPREINVSPLIT.Items.Count; i++)
        {
            dtbMLDPREINVSPLIT.Rows[i]["INVGRP"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtINVGRP")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["UNITID"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtUNITID")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["TARGETID"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtTARGETID")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["TARGETNAME"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtTARGETNAME")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtMONTHPAY")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODE"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtINVZIPCODE")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtINVZIPCODES")).Text;
            dtbMLDPREINVSPLIT.Rows[i]["INVOICEADDR"] = ((TextBox)rptMLDPREINVSPLIT.Items[i].FindControl("txtINVOICEADDR")).Text;
        }

        DataView DV = dtbMLDPREINVSPLIT.DefaultView;
        DV.Sort = "INVGRP Asc";
        dtbMLDPREINVSPLIT = DV.ToTable();

        if (rptMLDPREINVSPLIT.Items.Count > 0)
        {
            string strPrevINVGRP = "";// dtbMLDPREINVSPLIT.Rows[0]["INVGRP"].ToString().Trim();
            decMONTHPAY = 0;

            for (int i = 0; i < dtbMLDPREINVSPLIT.Rows.Count; i++)
            {
                if (strPrevINVGRP != dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim())
                {
                    decMONTHPAY = 0;
                    decMONTHPAY += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"].ToString());

                    DataRow dtrMLDCONTRACTTARGET_New = dtbMLDCONTRACTTARGET_New.NewRow();
                    dtrMLDCONTRACTTARGET_New["UNITID"] = dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim(); //dtbMLDPREINVSPLIT.Rows[i]["UNITID"].ToString();
                    dtrMLDCONTRACTTARGET_New["TARGETPRICEA"] = (System.Convert.ToDecimal(decMONTHPAY) / System.Convert.ToDecimal(this.hdnMONTHPAYTTL.Value)).ToString();
                    dtrMLDCONTRACTTARGET_New["MONTHPAY"] = decMONTHPAY.ToString("##,##0");
                    dtrMLDCONTRACTTARGET_New["INVZIPCODE"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODE"].ToString();
                    dtrMLDCONTRACTTARGET_New["INVZIPCODES"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"].ToString();
                    dtrMLDCONTRACTTARGET_New["INVOICEADDR"] = dtbMLDPREINVSPLIT.Rows[i]["INVZIPCODES"].ToString().Trim() + dtbMLDPREINVSPLIT.Rows[i]["INVOICEADDR"].ToString().Trim();
                    dtrMLDCONTRACTTARGET_New["TARGETID"] = dtbMLDPREINVSPLIT.Rows[i]["TARGETID"].ToString();
                    dtrMLDCONTRACTTARGET_New["TARGETNAME"] = dtbMLDPREINVSPLIT.Rows[i]["TARGETNAME"].ToString();
                    dtbMLDCONTRACTTARGET_New.Rows.Add(dtrMLDCONTRACTTARGET_New);

                    strPrevINVGRP = dtbMLDPREINVSPLIT.Rows[i]["INVGRP"].ToString().Trim();

                }
                else
                {
                    decMONTHPAY += System.Convert.ToDecimal(dtbMLDPREINVSPLIT.Rows[i]["MONTHPAY"].ToString());

                    if ((dtbMLDCONTRACTTARGET_New != null) && (rptMLDPREINVSPLIT.Items.Count != 0))
                    {
                        if (i == dtbMLDPREINVSPLIT.Rows.Count - 1)
                        {
                            if (dtbMLDCONTRACTTARGET_New.Rows.Count != 0)
                            {
                                DataRow dtrMLDCONTRACTTARGET_New = dtbMLDCONTRACTTARGET_New.Rows[dtbMLDCONTRACTTARGET_New.Rows.Count - 1];
                                dtrMLDCONTRACTTARGET_New["TARGETPRICEA"] = (System.Convert.ToDecimal(decMONTHPAY) / System.Convert.ToDecimal(this.hdnMONTHPAYTTL.Value)).ToString();
                                dtrMLDCONTRACTTARGET_New["MONTHPAY"] = decMONTHPAY.ToString("##,##0");
                            }
                        }
                        else
                        {
                            if (dtbMLDCONTRACTTARGET_New.Rows.Count != 0)
                            {
                                DataRow dtrMLDCONTRACTTARGET_New = dtbMLDCONTRACTTARGET_New.Rows[dtbMLDCONTRACTTARGET_New.Rows.Count - 1];
                                dtrMLDCONTRACTTARGET_New["TARGETPRICEA"] = (System.Convert.ToDecimal(decMONTHPAY) / System.Convert.ToDecimal(this.hdnMONTHPAYTTL.Value)).ToString();
                                dtrMLDCONTRACTTARGET_New["MONTHPAY"] = decMONTHPAY.ToString("##,##0");
                            }
                        }
                    }
                }

            }
        }
        Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
        Session["MLDCONTRACTTARGET_New"] = dtbMLDCONTRACTTARGET_New;
        this.hdnMLDPREINVSPLITtoJSON.Value = GetJSONString(dtbMLDPREINVSPLIT);
        return dtbMLDPREINVSPLIT;
    }

    private void MLDPREINVSPLIT_Init()
    {
        if (Session["MLDPREINVSPLIT"] == null)
        {
            //初始化欄位
            DataTable dtbMLDPREINVSPLIT = new DataTable("MLDPREINVSPLIT");
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSPLITID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("PREINVSETID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVGRP", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("UNITID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETID", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("TARGETNAME", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("MONTHPAY", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODE", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVZIPCODES", System.Type.GetType("System.String")));
            dtbMLDPREINVSPLIT.Columns.Add(new DataColumn("INVOICEADDR", System.Type.GetType("System.String")));
            Session["MLDPREINVSPLIT"] = dtbMLDPREINVSPLIT;
        }
    }

    private void MLDPREINVSPLIT_Bind()
    {
        DataTable dtbMLDPREINVSPLIT = (DataTable)Session["MLDPREINVSPLIT"];
        this.rptMLDPREINVSPLIT.DataSource = dtbMLDPREINVSPLIT;
        this.rptMLDPREINVSPLIT.DataBind();
    }

    //對象統編
    public string GenTARGETIDInnerHtml()
    {
        StringBuilder stbInnerHTML = new StringBuilder();
        //ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this);" onkeypress="OnlyUCase(this);" CssClass="txt_table"
        stbInnerHTML.Append("<INPUT TYPE='TEXT'  runat='server' ID='txtTARGETID' VALUE='' style='width:90%' MaxLength='10' onblur='txtTARGETID_onBlur(this);' CssClass='txt_table'></INPUT>");
        return stbInnerHTML.ToString();
    }

    //對象名稱
    public string GenTARGETNAMEInnerHtml()
    {
        StringBuilder stbInnerHTML = new StringBuilder();
        //ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this);" onkeypress="OnlyUCase(this);" CssClass="txt_table"
        stbInnerHTML.Append("<INPUT TYPE='TEXT'  runat='server' ID='txtTARGETNAME' VALUE='' style='width:90%' MaxLength='100' onblur='CheckMLength(this);'  CssClass='txt_table'></INPUT>");
        return stbInnerHTML.ToString();
    }

    //發票群組
    public string GenINVGRPInnerHtml()
    {
        StringBuilder stbInnerHTML = new StringBuilder();
        //ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this);" onkeypress="OnlyUCase(this);" CssClass="txt_table"
        stbInnerHTML.Append("<INPUT TYPE='TEXT' runat='server' ID='txtINVGRP' VALUE='' style='width:90%' MaxLength='100' onblur='CheckMLength(this);'  onkeypress='OnlyUCase(this);' CssClass='txt_table'></INPUT>");
        return stbInnerHTML.ToString();
    }

    //月付款
    public string GenMONTHPAYInnerHtml()
    {
        StringBuilder stbInnerHTML = new StringBuilder();
        //ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this);" onkeypress="OnlyUCase(this);" CssClass="txt_table"
        stbInnerHTML.Append("<INPUT TYPE='TEXT' runat='server' ID='txtMONTHPAY' VALUE='' style='text-align:right;width:90%;' MaxLength='11' onkeypress='OnlyNumD(this);' onfocus='MoneyFocus(this);' onblur='txtMONTHPAY_onBlur(this);' CssClass='txt_table'></INPUT>");
        return stbInnerHTML.ToString();
    }

    //發票地址
    public string GenINVOADDRInnerHtml()
    {
        StringBuilder stbInnerHTML = new StringBuilder();
        //ID="txtINVGRP"  width="95%" Text='<%# Eval("INVGRP")%>'  MaxLength="100" runat="server" onblur="CheckMLength(this);" onkeypress="OnlyUCase(this);" CssClass="txt_table"
        stbInnerHTML.Append("<INPUT TYPE='TEXT' runat='server' ID='txtINVZIPCODE' VALUE='' MaxLength='6' style='width:10%;'  onkeyup='CheckNumber_keyup(this);' onblur='PostCodeBlure(this);' CssClass='txt_table'></INPUT>");
        stbInnerHTML.Append("<INPUT TYPE='BUTTON' runat='server' ID='btnINVZIPCODE' class='btn_normal' onclick='PostCodeClick(this);'  style='width:25px;padding:2px;' value='&#8230;'</INPUT>");
        stbInnerHTML.Append("<INPUT TYPE='TEXT' runat='server' ID='txtINVZIPCODES' VALUE='' style='width:20%' onkeyup='CheckNumber_keyup(this);' MaxLength='6' onblur='PostCodeBlure(this);'  CssClass='txt_table'></INPUT>");
        stbInnerHTML.Append("<INPUT TYPE='TEXT'  runat='server' ID='txtINVOICEADDR' VALUE='' style='width:50%' CssClass='txt_table' MaxLength='100'  onblur='CheckMLength(this);'></INPUT>");
        return stbInnerHTML.ToString();
    }

    //單體清單
    public string GenUNITIDInnerHtml()
    {
        DataTable dtbMLDCONTRACTTARGET = (DataTable)Session["MLDCONTRACTTARGET"];
        StringBuilder stbInnerHTML = new StringBuilder();
        stbInnerHTML.Append("<INPUT TYPE='HIDDEN' runat='server' ID='hdnUNITID' VALUE='" + dtbMLDCONTRACTTARGET.Rows[0]["TARGETID"].ToString().Trim() + "'</INPUT><SELECT ID='ddlTargetLst' runat='server' onclick='ddlTargetLst_onClick(this);'  onchange='ddlTargetLst_onChange(this);'>");
        for (Int32 intRowCnt = 0; intRowCnt < dtbMLDCONTRACTTARGET.Rows.Count; intRowCnt++)
        {
            if (intRowCnt == 0)
            {
                stbInnerHTML.Append("<OPTION selected VALUE='" + dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETID"].ToString().Trim() + "'>" + dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETID"].ToString().Trim() + "</OPTION>");
            }
            else
            {
                stbInnerHTML.Append("<OPTION VALUE='" + dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETID"].ToString().Trim() + "'>" + dtbMLDCONTRACTTARGET.Rows[intRowCnt]["TARGETID"].ToString().Trim() + "</OPTION>");
            }
        }
        stbInnerHTML.Append("</SELECT>");
        return stbInnerHTML.ToString();
    }

    private static List<Dictionary<string, object>>
        RowsToDictionary(DataTable table)
    {
        List<Dictionary<string, object>> objs =
            new List<Dictionary<string, object>>();
        foreach (DataRow dr in table.Rows)
        {
            Dictionary<string, object> drow = new Dictionary<string, object>();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                drow.Add(table.Columns[i].ColumnName, dr[i]);
            }
            objs.Add(drow);
        }

        return objs;
    }

    public static Dictionary<string, object> ToJson(DataTable table)
    {
        Dictionary<string, object> d = new Dictionary<string, object>();
        d.Add(table.TableName, RowsToDictionary(table));
        return d;
    }

    public static Dictionary<string, object> ToJson(DataSet data)
    {
        Dictionary<string, object> d = new Dictionary<string, object>();
        foreach (DataTable table in data.Tables)
        {
            d.Add(table.TableName, RowsToDictionary(table));
        }
        return d;
    }

    public string JSON_DataTable(DataTable dtbProcTable)
    {
        /****************************************************************************
         * Without goingin to the depth of the functioning of this Method, i will try to give an overview
         * As soon as this method gets a DataTable it starts to convert it into JSON String,
         * it takes each row and ineach row it creates an array of cells and in each cell is having its data
         * on the client side it is very usefull for direct binding of object to  TABLE.
         * * Values Can be Access on clien in this way. OBJ.TABLE[0].ROW[0].CELL[0].DATA 
         * NOTE: One negative point. by this method user will not be able to call any cell by its name.
         * *************************************************************************/

        StringBuilder JsonString = new StringBuilder();

        JsonString.Append("{ ");
        JsonString.Append("\'TABLE\':[{ ");
        JsonString.Append("\'ROW\':[ ");

        for (int i = 0; i < dtbProcTable.Rows.Count; i++)
        {
            JsonString.Append("{ ");
            JsonString.Append("\'COL\':[ ");

            for (int j = 0; j < dtbProcTable.Columns.Count; j++)
            {
                if (j < dtbProcTable.Columns.Count - 1)
                {
                    JsonString.Append("{" + "\'" + dtbProcTable.Columns[j].ColumnName + "\':\'" + dtbProcTable.Rows[i][j].ToString() + "\'},");
                }
                else if (j == dtbProcTable.Columns.Count - 1)
                {
                    JsonString.Append("{" + "\'" + dtbProcTable.Columns[j].ColumnName + "\':\'" + dtbProcTable.Rows[i][j].ToString() + "\'}");
                }
            }

            /*end Of String*/
            if (i == dtbProcTable.Rows.Count - 1)
            {
                JsonString.Append("]} ");
            }
            else
            {
                JsonString.Append("]}, ");
            }
        }
        JsonString.Append("]}]}");
        return JsonString.ToString();
    }

    public string CreateJsonParameters(DataTable dtbProcTable)
    {
        /* /****************************************************************************
         * Without goingin to the depth of the functioning of this Method, i will try to give an overview
         * As soon as this method gets a DataTable it starts to convert it into JSON String,
         * it takes each row and in each row it grabs the cell name and its data.
         * This kind of JSON is very usefull when developer have to have Column name of the .
         * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName>
         * NOTE: One negative point. by this method user will not be able to call any cell by its index.
         * *************************************************************************/

        StringBuilder JsonString = new StringBuilder();

        //Exception Handling        

        if (dtbProcTable != null && dtbProcTable.Rows.Count > 0)
        {
            JsonString.Append("{ ");
            JsonString.Append("\"Head\":[ ");

            for (int i = 0; i < dtbProcTable.Rows.Count; i++)
            {
                JsonString.Append("{ ");

                for (int j = 0; j < dtbProcTable.Columns.Count; j++)
                {
                    if (j < dtbProcTable.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dtbProcTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dtbProcTable.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == dtbProcTable.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dtbProcTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dtbProcTable.Rows[i][j].ToString() + "\"");
                    }
                }
                /*end Of String*/
                if (i == dtbProcTable.Rows.Count - 1)
                {
                    JsonString.Append("} ");
                }
                else
                {
                    JsonString.Append("}, ");
                }
            }
            JsonString.Append("]}");
            return JsonString.ToString();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// FormDDLBinding
    /// </summary>
    /// <param name=""></param>
    /// <returns>無</returns>
    /// <remark>畫面下拉選單Binding</remark>
    private void FormDDLBinding()
    {
        try
        {
            ReturnObject<DataSet> objReturnDataSet = GetDrpData();
            if (objReturnDataSet.ReturnSuccess)
            {
                DataSet dtsData = objReturnDataSet.ReturnData;

                this.drpCODE.DataSource = dtsData.Tables[0].DefaultView;
                this.drpCODE.DataBind();
            }
            else
            {
                Alert(objReturnDataSet.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }

    /// <summary>
    /// GetDrpData
    /// </summary>
    /// <param name=""></param>
    /// <returns>以Dataset傳回下拉選單資料</returns>
    private ReturnObject<DataSet> GetDrpData()
    {

        Comus.HtmlSubmitControl objComusSubmit;
        string strObjID;
        StringBuilder stbStoreProcedure = new StringBuilder();
        StringBuilder stbQueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> dtsRtnObj;
        string[] aryParameter = new string[2];
        try
        {
            strObjID = "ITG.CommDBService.MutiQueryByStoreProcedure";


            //郵編區號
            stbStoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            stbQueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            objComusSubmit = new Comus.HtmlSubmitControl();
            objComusSubmit.VirtualPath = GetComusVirtualPath();
            aryParameter[0] = stbStoreProcedure.ToString();
            aryParameter[1] = stbQueryCondition.ToString();
            dtsRtnObj = objComusSubmit.SubmitEx<DataSet>(strObjID, aryParameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtsRtnObj;
    }

    public static string GetJSONString(DataTable dtbProcData)
    {
        if (dtbProcData == null)
        {
            return ""; 
        }

        string[] StrDc = new string[dtbProcData.Columns.Count];
        string HeadStr = string.Empty;

        for (int i = 0; i < dtbProcData.Columns.Count; i++)
        {

            StrDc[i] = dtbProcData.Columns[i].Caption;

            HeadStr += "'" + StrDc[i] + "' : '" + StrDc[i] + i.ToString() + "¾" + "',";
        }

        HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);

        StringBuilder Sb = new StringBuilder();
        Sb.Append("{'Rows' : [");

        for (int i = 0; i < dtbProcData.Rows.Count; i++)
        {

            string TempStr = HeadStr;
            Sb.Append("{");

            for (int j = 0; j < dtbProcData.Columns.Count; j++)
            {

                TempStr = TempStr.Replace(dtbProcData.Columns[j] + j.ToString() + "¾", dtbProcData.Rows[i][j].ToString());
            }

            Sb.Append(TempStr + "},");
        }

        Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
        Sb.Append("]}");

        return Sb.ToString();
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        DataTable dtbMLDPREINVSPLIT = updateMLDPREINVSPLIT();
        this.Dispose();
        Page.RegisterStartupScript("Close", "<script>window.close();</script>");
    }
}
