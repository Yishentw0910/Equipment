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
using System.Text.RegularExpressions;

public partial class FrmML5001A : PageBase {
   public string S_SysDate = "";     //UPD BY VICKY 20140225 系統日(沒時間)
   public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
   public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
   public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
   public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
   public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
   public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];

  protected void Page_Load(object sender, EventArgs e) {
    GetUsrAndFuncInfo();
    //===== for 測試Menu =====
    if (GSTR_PROGNM == "") GSTR_PROGNM = "回件作業(營業單位)";
    if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML5001A";
    if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML5001A";
    S_SysDate = DateTime.Now.ToString("yyyy/MM/dd");
    //========================
    if (!Page.IsPostBack) {
      string LSTR_CUSTID = Request.QueryString["custid"].ToString();
      string LSTR_CASEID = Request.QueryString["caseid"].ToString();
      string LSTR_CNTRNO = Request.QueryString["cntrno"].ToString();
      PageDataBind(LSTR_CUSTID, LSTR_CASEID, LSTR_CNTRNO);

      //20120601 MODIFY BY SSF MAUREEN REASON:當已回件時，確認（轉客服及財支）按鈕不可點選
      string LSTR_CASESTATUS = Request.QueryString["casestatus"].ToString();
      if (LSTR_CASESTATUS == "11" || LSTR_CASESTATUS == "12" || LSTR_CASESTATUS == "13")
      {
          this.btnSubmit.Enabled = false;
          //UPD BY VICKY 20140225 加入[列印回件資料表],已回件才可以點
          this.btnPRINT.Enabled = true;
      }
      else
      {
          //UPD BY VICKY 20140225 加入[列印回件資料表],未回件時鎖定
          this.btnPRINT.Enabled = false;
      }
    }

      //UPD BY VICKY 20140225 避免POSTBACK後被清空,故用HD欄位做中介
      txtMEMO.Text = hdMEMO.Value;
      if (txtMEMO.Text != "") txtMEMO.Style.Add("display", "block");


  }
  private void PageDataBind(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID) {
    if (!string.IsNullOrEmpty(LSTR_CUSTID) && !string.IsNullOrEmpty(LSTR_CASEID) && !string.IsNullOrEmpty(LSTR_CONTID)) {
      try {
        ReturnObject<DataSet> LOBJ_ReturnObject = GetCaseDataByID(LSTR_CUSTID, LSTR_CASEID, LSTR_CONTID);
        if (LOBJ_ReturnObject.ReturnSuccess) {
          DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
         //RegisterScript("alert('" + LDST_Data.Tables.Count.ToString() + "');window.close();");

          //征審資料
          //20120601 MODIFY BY SSF MAUREEN REASON:修改casestatus判斷條件
          //if (Request.QueryString["casestatus"].ToString() == "14")
          if (Request.QueryString["casestatus"].ToString() == "11" || Request.QueryString["casestatus"].ToString() == "12" || Request.QueryString["casestatus"].ToString() == "13" || Request.QueryString["casestatus"].ToString() == "14")
          {
            GetMLDCASEAPPENDDOCRejBind(LDST_Data.Tables[0]);
            GetMLDCASEAPPENDDOC2RejBind(LDST_Data.Tables[1]);  //UPD BY VICKY 20140224 擔保文件GRID
            GetMLDCASEAPPENDDOC3RejBind(LDST_Data.Tables[2]);  //UPD BY VICKY 20140224 客戶暨徵信資料GRID
          } else {
            GetMLDCASEAPPENDDOCBind(LDST_Data.Tables[0]);
            GetMLDCASEAPPENDDOC2Bind(LDST_Data.Tables[1]);      //UPD BY VICKY 20140224 擔保文件GRID
            GetMLDCASEAPPENDDOC3Bind(LDST_Data.Tables[2]);      //UPD BY VICKY 20140224 客戶暨徵信資料GRID
          }
          ////決策人
          //GetPoliceManBind(LDST_Data.Tables[1]);
          ////案件
          //GetMLMCONTRACTBind(LDST_Data.Tables[2]);

          //決策人  //UPD BY VICKY 20140224
          GetPoliceManBind(LDST_Data.Tables[3]);
          //案件    //UPD BY VICKY 20140224
          GetMLMCONTRACTBind(LDST_Data.Tables[4]);
          //退件日期歷程    //UPD BY VICKY 20140224
          GetMLMBACKDOCDATEBind(LDST_Data.Tables[5]);
        }
      } catch (Exception ex) {

        Alert(ex.Message);
      }
    }
  }
  private void GetMLMCONTRACTBind(DataTable LOBJ_Data) {
    if (LOBJ_Data.Rows.Count > 0) {
      this.txtCASEID.Text = LOBJ_Data.Rows[0]["CASEID"].ToString();
      this.txtCNTRNO.Text = LOBJ_Data.Rows[0]["CNTRNO"].ToString();
      this.txtSYSDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["VDATE"].ToString());

      this.txtCUSTNAME.Text = LOBJ_Data.Rows[0]["CUSTNAME"].ToString();
      this.txtMAINTYPENM.Text = LOBJ_Data.Rows[0]["MAINTYPENM"].ToString();
      this.txtBUSINESSADDR.Text = LOBJ_Data.Rows[0]["BUSINESSADDRESS"].ToString();
      this.txtPAYDATE.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["PAYDATE"].ToString());
      this.txtRENTSTDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RENTSTDT"].ToString());
      this.txtRENTENDT.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RENTENDT"].ToString());
      this.hidGUANVALUE.Value = LOBJ_Data.Rows[0]["GUANVALUE"].ToString();  //UPD BY VICKY 20140225 配合SP_ML3002_U02擴欄位使用

      this.txtC2.Text = Itg.Community.Util.DefaultZero(LOBJ_Data.Rows[0]["TANOUMTTAX"].ToString());
      this.txtD2.Text = Itg.Community.Util.DefaultZero(LOBJ_Data.Rows[0]["TDISCOUNTAMOUNTTAX"].ToString());

      this.hidRETUNCONFIRM0.Value = LOBJ_Data.Rows[0]["RETUNCONFIRM0"].ToString();
      this.hidRETUNCONFIRMDATE0.Value = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["RETUNCONFIRMDATE0"].ToString());
      //20120717 Modify By Maureen Reason:新增SOURCETYPE欄位，用以判斷01(和潤件)、02(銀行件)
      this.hidSOURCETYPE.Value = LOBJ_Data.Rows[0]["SOURCETYPE"].ToString();

      this.hidDate.Value = Itg.Community.Util.GetRepDate();

      //20120724 Modify By Maureen Reason:新增SOURCETYPE欄位，用以判斷01(和潤件)、02(銀行件)，如為「銀行件」，進項發票確認，不需檢核。
      if (LOBJ_Data.Rows[0]["SOURCETYPE"].ToString() == "02")
      {
          this.chkINVCONFIRM.Enabled = false;
          this.chkINVDCONFIRM.Enabled = false;
      }

      //20120601 MODIFY BY SSF MAUREEN REASON:修改casestatus判斷條件
      //if (LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "14")
      if (LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "11" || LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "12" || LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "13" || LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "14")
      {
          if (LOBJ_Data.Rows[0]["CASESTATUS"].ToString() == "14")
          {
              //this.tblCon.Visible = true;  UPD BY VICKY 20140303 避免出現
              string LSTR_N = ((char)13).ToString() + ((char)10).ToString();
              this.txtCond.Text = Regex.Replace(LOBJ_Data.Rows[0]["VERIFYOPINION"].ToString(), "%&", LSTR_N);
          }

          if (LOBJ_Data.Rows[0]["INVCONFIRM"].ToString() == "1")
          {
              this.chkINVCONFIRM.Checked = true;
              this.txtC1.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["INVCONFIRMDATE"].ToString());
              //this.txtC1.Text = Itg.Community.Util.GetRepDate();
          }

          if (LOBJ_Data.Rows[0]["INVDCONFIRM"].ToString() == "1")
          {
              this.chkINVDCONFIRM.Checked = true;
              this.txtD1.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["INVDCONFIRMDATED"].ToString());
              //this.txtD1.Text = Itg.Community.Util.GetRepDate();
          }

      }
    }
  }
  private void GetPoliceManBind(DataTable LOBJ_Data) {
    if (LOBJ_Data.Rows.Count > 0) {
      this.txtCONTACTNAME.Text = LOBJ_Data.Rows[0]["CONTACTNAME"].ToString();
      this.txtDEPTNAME.Text = LOBJ_Data.Rows[0]["DEPTNAME"].ToString();
      this.txtCONTACTTITLE.Text = LOBJ_Data.Rows[0]["CONTACTTITLE"].ToString();
      this.txtCONTACTTEL.Text = LOBJ_Data.Rows[0]["CONTACTTEL"].ToString();
      this.txtCONTACTTELEXT.Text = LOBJ_Data.Rows[0]["CONTACTTELEXT"].ToString();
      this.txtCONTACTMPHONE.Text = LOBJ_Data.Rows[0]["CONTACTMPHONE"].ToString();
      this.txtCONTACTFAX.Text = LOBJ_Data.Rows[0]["CONTACTFAX"].ToString();
      this.txtCONTACTEMAIL.Text = LOBJ_Data.Rows[0]["CONTACTEMAIL"].ToString();

      this.txtCUSTTELCODE.Text = LOBJ_Data.Rows[0]["CONTACTTELCODE"].ToString();
      this.txtCUSTFAXCODE.Text = LOBJ_Data.Rows[0]["CONTACTFAXCODE"].ToString();
    }
  }
  private void GetMLDCASEAPPENDDOCBind(DataTable LOBJ_Data) {
    //UPD BY VICKY 20140305 已退件未回, 要帶出舊的勾選資料
    //if (LOBJ_Data.Rows.Count > 1) {
      //LOBJ_Data.Rows.RemoveAt(LOBJ_Data.Rows.Count - 1);
    if (LOBJ_Data.Rows.Count > 0) {
      rptMLDCASEAPPENDDOC.DataSource = LOBJ_Data;
      rptMLDCASEAPPENDDOC.DataBind();

      //UPD BY VICKY 20140305 已退件未回, 要帶出舊的勾選資料
      for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++)
      {
          if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
          {
              ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
              //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
              ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
              ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
          }

      }
    }
  }
    private void GetMLDCASEAPPENDDOC2Bind(DataTable LOBJ_Data)
    {
        //if (LOBJ_Data.Rows.Count > 1)
        //{
        //    LOBJ_Data.Rows.RemoveAt(LOBJ_Data.Rows.Count - 1);
        //UPD BY VICKY 20140305 已退件的, 要帶出舊的勾選資料
        if (LOBJ_Data.Rows.Count > 0)
        {
            rptMLDCASEAPPENDDOC2.DataSource = LOBJ_Data;
            rptMLDCASEAPPENDDOC2.DataBind();
        }


        //UPD BY VICKY 20140305 已退件的, 要帶出舊的勾選資料
        for (int i = 0; i < this.rptMLDCASEAPPENDDOC2.Items.Count; i++)
        {
            if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
            {
                ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
                ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
            }
        }

        for (int i = 0; i < rptMLDCASEAPPENDDOC2.Items.Count; i++)
        {
            if (((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblDocName")).Text.Trim() == "保單")
            {
                ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Visible = false;
                ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = "";
                ((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Visible = false;
            }
        }

    }

    private void GetMLDCASEAPPENDDOC3Bind(DataTable LOBJ_Data)
    {
        //if (LOBJ_Data.Rows.Count > 1)
        //{
        //    LOBJ_Data.Rows.RemoveAt(LOBJ_Data.Rows.Count - 1);
        //UPD BY VICKY 20140305 已退件的要帶出舊的勾選資料
        if (LOBJ_Data.Rows.Count > 0)
        {
            rptMLDCASEAPPENDDOC3.DataSource = LOBJ_Data;
            rptMLDCASEAPPENDDOC3.DataBind();


            //UPD BY VICKY 20140305 已退件的要帶出舊的勾選資料
            for (int i = 0; i < this.rptMLDCASEAPPENDDOC3.Items.Count; i++)
            {
                if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
                {
                    ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                    //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
                    ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                    ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
                }

            }
        }
    }

  private void GetMLDCASEAPPENDDOCRejBind(DataTable LOBJ_Data) {
    if (LOBJ_Data.Rows.Count > 1) {
      rptMLDCASEAPPENDDOC.DataSource = LOBJ_Data;
      rptMLDCASEAPPENDDOC.DataBind();
      for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++) {
        if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1") {
          ((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
          //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
          ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
          ((Label)rptMLDCASEAPPENDDOC.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
        }

      }
    }
  }

  //UPD BY VICKY 20140224 加入擔保文件
    private void GetMLDCASEAPPENDDOC2RejBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 1)
        {
            rptMLDCASEAPPENDDOC2.DataSource = LOBJ_Data;
            rptMLDCASEAPPENDDOC2.DataBind();
            for (int i = 0; i < this.rptMLDCASEAPPENDDOC2.Items.Count; i++)
            {
                if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
                {
                    ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                    //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
                    ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                    ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
                }
            }

            for (int i = 0; i < rptMLDCASEAPPENDDOC2.Items.Count; i++)
            {
                if (((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblDocName")).Text.Trim() == "保單")
                {
                    ((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Visible = false;
                    //((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Visible = false;
                    ((Label)rptMLDCASEAPPENDDOC2.Items[i].FindControl("lblRepDate")).Text = "";
                    ((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Visible = false;
                }
            }
        }
    }

    //UPD BY VICKY 20140224 加入客戶暨徵信資料
    private void GetMLDCASEAPPENDDOC3RejBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 1)
        {
            rptMLDCASEAPPENDDOC3.DataSource = LOBJ_Data;
            rptMLDCASEAPPENDDOC3.DataBind();
            for (int i = 0; i < this.rptMLDCASEAPPENDDOC3.Items.Count; i++)
            {
                if (LOBJ_Data.Rows[i]["DOCCONFIRM1"].ToString().Trim() == "1")
                {
                    ((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Checked = true;
                    //20120601 MODIFY BY SS MAUREEN REASON:新增已回件資料，展開明細時，帶出已回件日期
                    ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[i]["RETUNDATE"].ToString());
                    ((Label)rptMLDCASEAPPENDDOC3.Items[i].FindControl("lblRepDate")).Style.Add("display", "block");
                }

            }
        }
    }

    //UPD BY VICKY 20140224 加入退回日期歷程
    private void GetMLMBACKDOCDATEBind(DataTable LOBJ_Data)
    {
        rptMLMBACKDOCDATE.DataSource = LOBJ_Data;
        rptMLMBACKDOCDATE.DataBind();

        for (int i = 0; i < this.rptMLMBACKDOCDATE.Items.Count; i++)
        {
            if (LOBJ_Data.Rows[i]["BACKDOCDATE"].ToString().Trim() == "")
            {
                //沒有回退日期時,不可按內容BTN
                ((Button)rptMLMBACKDOCDATE.Items[i].FindControl("btnMEMO")).Enabled = false;
            }

        }
    }



    private ReturnObject<DataSet> GetCaseDataByID(string LSTR_CUSTID, string LSTR_CASEID, string LSTR_CONTID)
    {
    Comus.HtmlSubmitControl LOBJ_Submit;
    string LSTR_ObjId;
    StringBuilder LSTR_StoreProcedure = new StringBuilder();
    StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
    ReturnObject<DataSet> LOBJ_Return;
    string[] LVAR_Parameter = new string[2];
    try {
      LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
      string LSTR_RETUNID = Request.QueryString["retunid"].ToString();
      //相關文件
      //20120601 MODIFY BY SSF MAUREEN REASON:修改casestatus判斷條件
      //if (Request.QueryString["casestatus"].ToString() == "14")
      if (Request.QueryString["casestatus"].ToString() == "11" || Request.QueryString["casestatus"].ToString() == "12" || Request.QueryString["casestatus"].ToString() == "13" || Request.QueryString["casestatus"].ToString() == "14")
      {
          //LSTR_StoreProcedure.Append("SP_ML5001_Q02" + GSTR_RowDelimitChar);   
          //LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
          //LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

        LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);   //UPD BY VICKY 20140224 合約文件
        LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append("1" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

        LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);  //UPD BY VICKY 20140224 擔保文件
        LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append("2" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

        LSTR_StoreProcedure.Append("SP_ML5001_Q04" + GSTR_RowDelimitChar);  //UPD BY VICKY 20140224 客戶暨徵信資料
        LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
        LSTR_QueryCondition.Append("3" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      } else {
        //LSTR_StoreProcedure.Append("SP_ML5001_Q03" + GSTR_RowDelimitChar);
        //LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

          LSTR_StoreProcedure.Append("SP_ML5001_Q05" + GSTR_RowDelimitChar);  //UPD BY VICKY 20140224 合約文件
          LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar);      //Edit by SEAN 20150813 帶合約編號
          LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
          LSTR_QueryCondition.Append("1" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

          LSTR_StoreProcedure.Append("SP_ML5001_Q05" + GSTR_RowDelimitChar);  //UPD BY VICKY 20140224 擔保文件
          LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar);      //Edit by SEAN 20150813 帶合約編號
          LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
          LSTR_QueryCondition.Append("2" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

          LSTR_StoreProcedure.Append("SP_ML5001_Q05" + GSTR_RowDelimitChar);  //UPD BY VICKY 20140224 客戶暨徵信資料
          LSTR_QueryCondition.Append(LSTR_CONTID + GSTR_ColDelimitChar);      //Edit by SEAN 20150813 帶合約編號
          LSTR_QueryCondition.Append(LSTR_CASEID + GSTR_ColDelimitChar);
          LSTR_QueryCondition.Append("3" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      }
      //決策人
      LSTR_StoreProcedure.Append("SP_ML1002_Q03" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(" AND CONTACTTYPE=''''1'''' AND MLDCASECONTACT.CASEID=''''" + LSTR_CASEID + "'''' " + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
      //合約
      LSTR_StoreProcedure.Append("SP_ML5001_Q01" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(" AND MLMCONTRACT.CNTRNO=''''" + LSTR_CONTID + "'''' " + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      //UPD BY VICKY 201140224 退件歷程
      LSTR_StoreProcedure.Append("SP_ML5001_Q06" + GSTR_RowDelimitChar);
      LSTR_QueryCondition.Append(LSTR_RETUNID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
      LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
      LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
    } catch (Exception ex) {
      throw ex;
    }
    return LOBJ_Return;
  }
  protected void btnSubmit_Click(object sender, EventArgs e) {    
      MLMCASESave(); 
  }

  private void MLMCASESave() {
    StringBuilder LSTR_Data = new StringBuilder();
    string LSTR_RETUNID = "";
    if (Request.QueryString["retunid"] == "") {
      LSTR_RETUNID = Itg.Community.Util.GetIDSequence("MLMRETURNDOC", "14");
    } else {
      LSTR_RETUNID = Request.QueryString["retunid"].ToString();
    }
    //MLMRETURNDOC
    LSTR_Data.Append("SP_ML5001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(this.txtCNTRNO.Text + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
    if (this.chkINVCONFIRM.Checked == true) {
      LSTR_Data.Append("1" + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    } else {
      LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
    }
    if (this.chkINVDCONFIRM.Checked == true) {
      LSTR_Data.Append("1" + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    } else {
      LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
    }
    if (this.hidRETUNCONFIRM0.Value == "") {
      LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
    } else {
      LSTR_Data.Append(this.hidRETUNCONFIRM0.Value + GSTR_TabDelimitChar);
      LSTR_Data.Append(this.hidRETUNCONFIRMDATE0.Value + GSTR_TabDelimitChar);

    }
    LSTR_Data.Append("1" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("2" + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("2" + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("11" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);

    //=========================================================================     
    //MLDRETURNDOCDETAIL
    for (int i = 0; i < this.rptMLDCASEAPPENDDOC.Items.Count; i++) {
      LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
      LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
      string LSTR_RETUNDETAILID = ((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim();
      if (LSTR_RETUNDETAILID.Trim() == "") {
        LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDRETURNDOCDETAIL", "14") + GSTR_TabDelimitChar);
      } else {
        LSTR_Data.Append(LSTR_RETUNDETAILID + GSTR_TabDelimitChar);
      }
      LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);

      if (((CheckBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("chkDOCCONFIRM")).Checked == true) {
        LSTR_Data.Append("1" + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
      } else {
        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
      }
      LSTR_Data.Append("2" + GSTR_TabDelimitChar);
      LSTR_Data.Append("" + GSTR_TabDelimitChar);
      LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
      LSTR_Data.Append(GSTR_U_SYSDT);
      LSTR_Data.Append(GSTR_ColDelimitChar);
      LSTR_Data.Append(GSTR_RowDelimitChar);
    }
    //UPD BY VICKY 20140225 加入[擔保文件]GRID
    for (int i = 0; i < this.rptMLDCASEAPPENDDOC2.Items.Count; i++)
    {
        if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Visible == true)
        {
            LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
            string LSTR_RETUNDETAILID = ((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim();
            if (LSTR_RETUNDETAILID.Trim() == "")
            {
                LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDRETURNDOCDETAIL", "14") + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append(LSTR_RETUNDETAILID + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);

            if (((CheckBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
            {
                LSTR_Data.Append("1" + GSTR_TabDelimitChar);
                LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append("2" + GSTR_TabDelimitChar);
                LSTR_Data.Append("" + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC2.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
        else //UPD BY VICKY 20140227 加入隱藏欄位[保單]的值
        {
            LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
            string LSTR_RETUNDETAILID = ((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim();
            if (LSTR_RETUNDETAILID.Trim() == "")
            {
                LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDRETURNDOCDETAIL", "14") + GSTR_TabDelimitChar);
            }
            else
            {
                LSTR_Data.Append(LSTR_RETUNDETAILID + GSTR_TabDelimitChar);
            }
            LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC2.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);           
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT);
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
        }
    }

    //UPD BY VICKY 20140225 加入[客戶暨徵信資料]GRID
    for (int i = 0; i < this.rptMLDCASEAPPENDDOC3.Items.Count; i++)
    {
        LSTR_Data.Append("SP_ML5001_I02" + GSTR_ColDelimitChar);
        LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
        string LSTR_RETUNDETAILID = ((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidRETUNDETAILID")).Value.Trim();
        if (LSTR_RETUNDETAILID.Trim() == "")
        {
            LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLDRETURNDOCDETAIL", "14") + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append(LSTR_RETUNDETAILID + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append(((HiddenField)rptMLDCASEAPPENDDOC3.Items[i].FindControl("hidDocID")).Value.Trim() + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);

        if (((CheckBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("chkDOCCONFIRM")).Checked == true)
        {
            LSTR_Data.Append("1" + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
        }
        else
        {
            LSTR_Data.Append("2" + GSTR_TabDelimitChar);
            LSTR_Data.Append("" + GSTR_TabDelimitChar);
        }
        LSTR_Data.Append("2" + GSTR_TabDelimitChar);
        LSTR_Data.Append("" + GSTR_TabDelimitChar);
        LSTR_Data.Append(Regex.Replace(((TextBox)rptMLDCASEAPPENDDOC3.Items[i].FindControl("txtNOTE")).Text, "'", "’") + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
        LSTR_Data.Append(GSTR_U_SYSDT);
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);
    }

    LSTR_Data.Append("SP_ML3002_U02" + GSTR_ColDelimitChar);  
    LSTR_Data.Append(this.txtCNTRNO.Text + GSTR_TabDelimitChar);
    LSTR_Data.Append("9A" + GSTR_TabDelimitChar);
    //LSTR_Data.Append(hidGUANVALUE.Value + GSTR_TabDelimitChar);   
    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT);
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);

    //UPD BY VCIKY 20140225 加入歷程記錄
    //UPD BY VICKY 20140306 取消退件歷程
    //LSTR_Data.Append("SP_ML5001_I04" + GSTR_ColDelimitChar);
    //LSTR_Data.Append(this.txtCNTRNO.Text + GSTR_TabDelimitChar);
    //LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
    //LSTR_Data.Append(S_SysDate + GSTR_TabDelimitChar);
    //LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);
    //LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);
    //LSTR_Data.Append(GSTR_U_SYSDT);
    //LSTR_Data.Append(GSTR_ColDelimitChar);
    //LSTR_Data.Append(GSTR_RowDelimitChar);

    //MLVERIFY
    LSTR_Data.Append("SP_ML9001_I01" + GSTR_ColDelimitChar);
    LSTR_Data.Append(Itg.Community.Util.GetIDSequence("MLVERIFY", "14") + GSTR_TabDelimitChar);
    LSTR_Data.Append(LSTR_RETUNID + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);
    LSTR_Data.Append("" + GSTR_TabDelimitChar);
    LSTR_Data.Append("11" + GSTR_TabDelimitChar);
    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);
    LSTR_Data.Append("3");
    LSTR_Data.Append(GSTR_ColDelimitChar);
    LSTR_Data.Append(GSTR_RowDelimitChar);
    //=========================================================================
    LSTR_Data = LSTR_Data.Replace("'", "’");
    LSTR_Data = LSTR_Data.Replace("\"", "”");
    LSTR_Data = LSTR_Data.Replace("--", "－－");
    //=========================================================================
    try {
      ReturnObject<object> LOBJ_ReturnObject = SaveInfo(LSTR_Data.ToString());
      if (LOBJ_ReturnObject.ReturnSuccess) {
          //RegisterScript("alert('確認回件完成！');window.close();");
          //UPD BY VICKY 20140317 回件後，自動跳出列印回件資料表
          RegisterScript("alert('確認回件完成！');cmdPrintA_onClick('cmdPRINT');window.close();");
      } else {
        Alert(LOBJ_ReturnObject.ReturnMessage);
      }
    } catch (Exception ex) {
      Alert(ex.Message);
    }
  }
  private ReturnObject<object> SaveInfo(string LSTR_Data) {
    Comus.HtmlSubmitControl LOBJ_Submit;
    string LSTR_ObjId;
    ReturnObject<object> LOBJ_Return;
    string[] LVAR_Parameter = new string[1];
    try {
      LSTR_ObjId = "ITG.CommDBService.MutiNonQuerySPExec";
      LOBJ_Submit = new Comus.HtmlSubmitControl();
      LOBJ_Submit.VirtualPath = GetComusVirtualPath();
      LVAR_Parameter[0] = LSTR_Data;
      LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
    } catch (Exception ex) {
      throw ex;
    }
    return LOBJ_Return;
  }

    protected void cmdPRINT_OnClick(object sender, EventArgs e)
    {
        RegisterScript("cmdPrintA_onClick('cmdPRINT')");
    }
}
