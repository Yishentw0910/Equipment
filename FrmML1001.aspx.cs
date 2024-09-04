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
using System.Text;
using System.Text.RegularExpressions;
using ITG.Community;
using System.IO;

public partial class FrmML1001 : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "客戶資料維護";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "LE1001";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "LE1001";

        //========================             
        if (!Page.IsPostBack)
        {
            rptContactInit();

            //Add 20131028 REASON 增加董監事股東GRID 初始化
            rptDirStockInit();
            //Add 20131028 REASON 增加公司不動產GRID 初始化
            rptIMMOVABLEInit();

            FormDrpBind();

            CheckRule();
            //UPD 20140114 JBLEO tbxMemo、tbxCUSTINTRO 改為Disabled 
            RegisterScript("SetDisabled('div_Info', 'tbxMemo,tbxCUSTINTRO','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
            txtINDUNM.Enabled = false;
        }
    }

    private void CheckRule()
    {
        //取得需要設置驗證的欄位名
        string LSTR_CUSTID = this.txtCUSTID.ClientID;
        string LSTR_CUSTNAME = this.txtCUSTNAME.ClientID;
        string LSTR_CUSTCREATECAPTIAL = this.txtCUSTCREATECAPTIAL.ClientID;
        string LSTR_CUSTNOWCAPTIAL = this.txtCUSTNOWCAPTIAL.ClientID;
        string LSTR_CUSTCREATEDATE = this.txtCUSTCREATEDATE.ClientID;

        string LSTR_EMPLOYEE = this.drpEMPLOYEE.ClientID;
        string LSTR_OWNER = this.txtOWNER.ClientID;
        string LSTR_OWNERID = this.txtOWNERID.ClientID;

        string LSTR_CUSTZIPCODE = this.txtCUSTZIPCODE.ClientID;
        string LSTR_CUSTZIPCODES = this.txtCUSTZIPCODES.ClientID;
        string LSTR_CUSTADDR = this.txtCUSTADDR.ClientID;

        string LSTR_CUSTTEL = this.txtCUSTTEL.ClientID;

        string LSTR_BUSINESSZIPCODE = this.txtBUSINESSZIPCODE.ClientID;
        string LSTR_BUSINESSZIPCODES = this.txtBUSINESSZIPCODES.ClientID;
        string LSTR_BUSINESSADDR = this.txtBUSINESSADDR.ClientID;

        string LSTR_BUSINESSTTEL = this.txtBUSINESSTTEL.ClientID;
        string LSTR_COMPTYPE = this.drpCOMPTYPE.ClientID;
        string LSTR_ORGATYPE = this.drpORGATYPE.ClientID;
        string LSTR_LISTED = this.drpLISTED.ClientID;

        string LSTR_BUSINESS = this.txtBUSINESS.ClientID;
        string LSTR_CUROUT = this.drpCUROUT.ClientID;
        string LSTR_CUROUTF = this.drpCUROUTF.ClientID;

        string LSTR_GROUPOWNER = this.txtGROUPOWNER.ClientID;
        string LSTR_PARENTCUSTID = this.txtPARENTCUSTID.ClientID;
        string LSTR_PARENTCUSTNAME = this.txtPARENTCUSTNAME.ClientID;
        string LSTR_CUSTFAX = this.txtCUSTFAX.ClientID;
        string LSTR_BUSINESSFAX = this.txtBUSINESSFAX.ClientID;

        string LSTR_CUSTTELCODE = this.txtCUSTTELCODE.ClientID;
        string LSTR_BUSINESSTTELCODE = this.txtBUSINESSTTELCODE.ClientID;
        string LSTR_tbxCUSTINTRO = this.tbxCUSTINTRO.ClientID;

        //20160322 ADD BY SS ADAM REASON.增加行業別
        //20221031 行業別改下拉選單
        string LSTR_INDUID = this.DrpNDU.ClientID;
        string LSTR_INDUNM = this.txtINDUNM.ClientID;

        string Fields = LSTR_CUSTID + ";" + LSTR_CUSTNAME + ";" + LSTR_CUSTCREATECAPTIAL + ";" + LSTR_CUSTNOWCAPTIAL + ";" + LSTR_CUSTCREATEDATE + ";" +
                        LSTR_EMPLOYEE + ";" + LSTR_OWNER + ";" + LSTR_OWNERID + ";" + LSTR_COMPTYPE + ";" + LSTR_ORGATYPE + ";" +
                        LSTR_LISTED + ";" + LSTR_CUSTZIPCODE + ";" + LSTR_CUSTZIPCODES + ";" + LSTR_CUSTADDR + ";" + LSTR_CUSTTEL + ";" + LSTR_BUSINESSZIPCODE + ";" + LSTR_BUSINESSZIPCODES + ";" +
                        //20160322 ADD BY SS ADAM REASON.隱藏原本行業別，次行業別
                        //LSTR_BUSINESSADDR + ";" + LSTR_BUSINESSTTEL + ";" + LSTR_BUSINESS + ";" + LSTR_CUROUT + ";" + LSTR_CUROUTF + ";" +
                        LSTR_BUSINESSADDR + ";" + LSTR_BUSINESSTTEL + ";" + LSTR_BUSINESS + ";" +
                        LSTR_GROUPOWNER + ";" + LSTR_PARENTCUSTID + ";" + LSTR_PARENTCUSTNAME + ";" + LSTR_CUSTFAX + ";" + LSTR_BUSINESSFAX + ";" +
                        LSTR_CUSTTELCODE + ";" + LSTR_BUSINESSTTELCODE
                        //ADD 20131029 REASON 增加公司沿革檢核
                        + ";" + LSTR_tbxCUSTINTRO
                        //20160322 ADD BY SS ADAM REASON.增加行業別
                        + ";" + LSTR_INDUID;

        string FieldsName = "客戶統編;客戶名稱;登記資本額;實收資本額;設立日期;" +
                            "員工人數;負責人;身份ID;公司屬性;組織形態;" +
                            "上市櫃;公司登記地址郵編;公司登記地址郵編名稱;公司登記地址;公司登記電話;營業地址郵編;營業地址郵編名稱;" +
                            //20160322 ADD BY SS ADAM REASON.隱藏原本行業別，次行業別
                            //"營業地址;營業電話;主要營業項目;行業別;次行業別;" +
                            "營業地址;營業電話;主要營業項目;" +
                            "集團實際負責人;母公司編號;母公司名稱;公司登記傳真;營業傳真;" +
                            "公司登記電話區碼;營業電話區碼"
                            //ADD 20131029 REASON 增加公司沿革檢核
                            + ";" + "公司沿革"
                            //20160322 ADD BY SS ADAM REASON.增加行業別
                            + ";行業別";

        string CheckType = "text;text;text;text;date;" +
                           "dropdownlist;text;identificationcard;dropdownlist;dropdownlist;" +
                           "dropdownlist;text;text;text;text;text;text;" +
                           //20160322 ADD BY SS ADAM REASON.隱藏原本行業別，次行業別
                           //"text;text;text;dropdownlist;dropdownlist;" +
                           "text;text;text;" +
                           "text;text;text;text;text;text;text"
                           //ADD 20131029 REASON 增加公司沿革檢核
                           + ";text"
                           //20160322 ADD BY SS ADAM REASON.增加行業別
                           + ";text";

        string Length = "10;100; ; ;10;" +
                        " ;10;10; ; ;" +
                        " ;6;100;100;10;6;100;" +
                        //20160322 ADD BY SS ADAM REASON.隱藏原本行業別，次行業別
                        //"100;10;100;;;" +
                        "100;10;100;" +
                        "10;10;100;10;10;;;" +
                        //ADD 20131029 REASON 增加公司沿革檢核
                        "50;"
                        //20160322 ADD BY SS ADAM REASON.增加行業別
                        + "10";

        string IsEmpty = "false;false;false;false;false;" +
                         "false;false;true;false;false;" +
                         "false;false;false;false;false;false;false;" +
                         //20160322 ADD BY SS ADAM REASON.隱藏原本行業別，次行業別
                         //"false;false;false;false;true;" +
                         "false;false;false;" +
                         "true;true;true;true;true;false;false"
                         //ADD 20131029 REASON 增加公司沿革檢核
                         + ";false"
                         //20160322 ADD BY SS ADAM REASON.增加行業別
                         + ";false";

        string strCheck = "return checkdata('" + Fields + "','" + FieldsName + "','" + CheckType + "','" + Length + "','" + IsEmpty + "')";
        this.btnSubmit.Attributes.Add("onclick", strCheck);
        this.btnInsert.Attributes.Add("onclick", "return PageClear('div_Info')");
        this.btnUpdate.Attributes.Add("onclick", "return PageClear('div_Info')");
        this.btnSearch.Attributes.Add("onclick", "return PageClear('div_Info')");
    }

    #region Repeater
    private void rptContactInit()
    {
        DataTable LOBJ_Contact = new DataTable("Contact");
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTID", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTNAME", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("DEPTNAME", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTITLE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTEL", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTELEXT", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTMPHONE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTFAX", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTEMAIL", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTTELCODE", System.Type.GetType("System.String")));
        LOBJ_Contact.Columns.Add(new DataColumn("CONTACTFAXCODE", System.Type.GetType("System.String")));
        ViewState["Contact"] = LOBJ_Contact;
    }
    //ADD 20131028 REASON:新增董監事股東GRID
    private void rptDirStockInit()
    {
        DataTable LOBJ_DirStock = new DataTable("DirStock");
        LOBJ_DirStock.Columns.Add(new DataColumn("TITLENM", System.Type.GetType("System.String")));
        LOBJ_DirStock.Columns.Add(new DataColumn("NAME", System.Type.GetType("System.String")));
        LOBJ_DirStock.Columns.Add(new DataColumn("SEX", System.Type.GetType("System.String")));
        LOBJ_DirStock.Columns.Add(new DataColumn("AGE", System.Type.GetType("System.String")));
        LOBJ_DirStock.Columns.Add(new DataColumn("INVAMT", System.Type.GetType("System.String")));
        LOBJ_DirStock.Columns.Add(new DataColumn("MEMO", System.Type.GetType("System.String")));
        ViewState["DirStock"] = LOBJ_DirStock;
    }
    //ADD 20131030 REASON:新增公司不動產GRID
    private void rptIMMOVABLEInit()
    {
        DataTable LOBJ_IMMOVABLE = new DataTable("IMMOVABLE");
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("OWNER", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("BUYDATE", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("APP", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("LOCATION", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("AREA", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("HOLDER", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("HOLDERAREA", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("PICKSET1", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("BANK1", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("DEBTOR1", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("SETAMT1", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("PICKSET2", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("BANK2", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("DEBTOR2", System.Type.GetType("System.String")));
        LOBJ_IMMOVABLE.Columns.Add(new DataColumn("SETAMT2", System.Type.GetType("System.String")));
        ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
    }
    private void rptContactBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["Contact"];
        rptContact.DataSource = LOBJ_Data;
        rptContact.DataBind();
    }
    //ADD 20131029 REASON:綁定董監事股東GRID
    private void rptDirStockBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["DirStock"];
        rptDirStock.DataSource = LOBJ_Data;
        rptDirStock.DataBind();
    }
    //ADD 20131029 REASON:綁定公司不動產GRID
    private void rptIMMOVABLEBind()
    {
        DataTable LOBJ_Data = (DataTable)ViewState["IMMOVABLE"];
        rptIMMOVABLE.DataSource = LOBJ_Data;
        rptIMMOVABLE.DataBind();
    }
    private void rptContactClear()
    {
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        LOBJ_Contact.Rows.Clear();
        rptContact.DataSource = LOBJ_Contact;
        rptContact.DataBind();
        ViewState["Contact"] = LOBJ_Contact;
        this.txtCUSTID.Text = "";
        this.txtCUSTNAME.Text = "";
    }
    //ADD 20131029 REASON 清除董監事股東GRID
    private void rptDirStockClear()
    {
        DataTable LOBJ_DirStock = (DataTable)ViewState["DirStock"];
        LOBJ_DirStock.Rows.Clear();
        rptDirStock.DataSource = LOBJ_DirStock;
        rptDirStock.DataBind();
        ViewState["DirStock"] = LOBJ_DirStock;
        this.txtCUSTID.Text = "";
        this.txtCUSTNAME.Text = "";
    }
    //ADD 20131029 REASON 清除公司不動產GRID
    private void rptIMMOVABLEClear()
    {
        DataTable LOBJ_IMMOVABLE = (DataTable)ViewState["IMMOVABLE"];
        LOBJ_IMMOVABLE.Rows.Clear();
        rptIMMOVABLE.DataSource = LOBJ_IMMOVABLE;
        rptIMMOVABLE.DataBind();
        ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
        this.txtCUSTID.Text = "";
        this.txtCUSTNAME.Text = "";
    }
    //ADD 20131029 REASON F8新增董監事股東GRID
    private void AddRow_rptDirStock()
    {
        DataTable LOBJ_DirStock = (DataTable)ViewState["DirStock"];
        int LINT_ConNum = rptDirStock.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_DirStock.Rows[LINT_I]["TITLENM"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtTITLENM"));
            LOBJ_DirStock.Rows[LINT_I]["NAME"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtNAME"));
            LOBJ_DirStock.Rows[LINT_I]["SEX"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("ddlSEX"));
            LOBJ_DirStock.Rows[LINT_I]["AGE"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtAGE"));
            LOBJ_DirStock.Rows[LINT_I]["INVAMT"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtINVAMT"));
            LOBJ_DirStock.Rows[LINT_I]["MEMO"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtMEMO"));
        }
        ViewState["DirStock"] = LOBJ_DirStock;
        if (ViewState["STATUS"].ToString() != "SELECT")
        {
            DataRow LOBJ_ConInfo = LOBJ_DirStock.NewRow();
            LOBJ_ConInfo["TITLENM"] = "";
            LOBJ_ConInfo["NAME"] = "";
            LOBJ_ConInfo["SEX"] = "";
            LOBJ_ConInfo["AGE"] = 0;
            LOBJ_ConInfo["INVAMT"] = 0;
            LOBJ_ConInfo["MEMO"] = "";
            LOBJ_DirStock.Rows.Add(LOBJ_ConInfo);
            ViewState["DirStock"] = LOBJ_DirStock;
            rptDirStockBind();
            this.hidSelRowIndex.Value = "-1";
        }
        this.UpdatePanel3.Update();
    }
    //Add 20131029 REASON 增加F9 刪除董監事股東GRID
    private void DelRow_rptDirStock()
    {
        //先把內容存到datatable中
        DataTable LOBJ_DirStock = (DataTable)ViewState["DirStock"];
        int LINT_ConNum = rptDirStock.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_DirStock.Rows[LINT_I]["TITLENM"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtTITLENM"));
            LOBJ_DirStock.Rows[LINT_I]["NAME"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtNAME"));
            LOBJ_DirStock.Rows[LINT_I]["SEX"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("ddlSEX"));
            LOBJ_DirStock.Rows[LINT_I]["AGE"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtAGE"));
            LOBJ_DirStock.Rows[LINT_I]["INVAMT"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtINVAMT"));
            LOBJ_DirStock.Rows[LINT_I]["MEMO"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("txtMEMO"));
        }
        ViewState["DirStock"] = LOBJ_DirStock;
        int LINT_SelIndex = Convert.ToInt32(this.hidSelRowIndex.Value);
        if (ViewState["STATUS"].ToString() != "SELECT" && LINT_SelIndex != -1)
        {
            if (LOBJ_DirStock.Rows.Count > 0)
            {
                LOBJ_DirStock.Rows.RemoveAt(LINT_SelIndex);
                this.hidSelRowIndex.Value = "-1";
            }
            ViewState["DirStock"] = LOBJ_DirStock;
            rptDirStockBind();
        }
        this.UpdatePanel3.Update();
    }
    //ADD 20131029 REASON F8 增加 F8 新增公司不動產GRID
    private void AddRow_rptIMMOVABLE()
    {
        DataTable LOBJ_IMMOVABLE = (DataTable)ViewState["IMMOVABLE"];
        int LINT_ConNum = rptIMMOVABLE.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_IMMOVABLE.Rows[LINT_I]["OWNER"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtOWNER"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BUYDATE"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtBUYDATE"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["APP"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAPP"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["LOCATION"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtLOCATION"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["AREA"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAREA"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDER"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDER"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDERAREA"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDERAREA"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtPICKSET1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BANK1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxPICKSET2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BANK2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT2"));
        }
        ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
        if (ViewState["STATUS"].ToString() != "SELECT")
        {
            DataRow LOBJ_ConInfo = LOBJ_IMMOVABLE.NewRow();
            LOBJ_ConInfo["OWNER"] = "";
            LOBJ_ConInfo["BUYDATE"] = DateTime.Now.ToString("yyyy/MM/dd");
            LOBJ_ConInfo["APP"] = "";
            LOBJ_ConInfo["LOCATION"] = "";
            LOBJ_ConInfo["AREA"] = "";
            LOBJ_ConInfo["HOLDER"] = "";
            LOBJ_ConInfo["HOLDERAREA"] = "";
            LOBJ_ConInfo["PICKSET1"] = "";
            LOBJ_ConInfo["BANK1"] = "";
            LOBJ_ConInfo["DEBTOR1"] = "";
            LOBJ_ConInfo["SETAMT1"] = 0.0;
            LOBJ_ConInfo["PICKSET2"] = "";
            LOBJ_ConInfo["BANK2"] = "";
            LOBJ_ConInfo["DEBTOR2"] = "";
            LOBJ_ConInfo["SETAMT2"] = 0.0;
            LOBJ_IMMOVABLE.Rows.Add(LOBJ_ConInfo);
            ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
            rptIMMOVABLEBind();
            this.hidSelRowIndex.Value = "-1";
        }
        this.UpdatePanel4.Update();
    }
    //Add 20131029 REASON 增加 F9 刪除 公司不動產GRID
    private void DelRow_rptIMMOVABLE()
    {
        //先把內容存到datatable中
        DataTable LOBJ_IMMOVABLE = (DataTable)ViewState["IMMOVABLE"];
        int LINT_ConNum = rptIMMOVABLE.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_IMMOVABLE.Rows[LINT_I]["OWNER"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtOWNER"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BUYDATE"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtBUYDATE"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["APP"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAPP"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["LOCATION"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtLOCATION"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["AREA"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAREA"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDER"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDER"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDERAREA"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDERAREA"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtPICKSET1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BANK1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT1"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT1"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxPICKSET2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["BANK2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR2"));
            LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT2"] = ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT2"));
        }
        ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
        int LINT_SelIndex = Convert.ToInt32(this.hidSelRowIndex.Value);
        if (ViewState["STATUS"].ToString() != "SELECT" && LINT_SelIndex != -1)
        {
            if (LOBJ_IMMOVABLE.Rows.Count > 0)
            {
                LOBJ_IMMOVABLE.Rows.RemoveAt(LINT_SelIndex);
                this.hidSelRowIndex.Value = "-1";
            }
            ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
            rptIMMOVABLEBind();
        }
        this.UpdatePanel4.Update();
    }
    //ADD 20131029 REASON 重構F8新增關係人GRID
    private void AddRow_rptContact()
    {
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        int LINT_ConNum = rptContact.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_Contact.Rows[LINT_I]["CONTACTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Contact.Rows[LINT_I]["DEPTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtDEPTNAME")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTITLE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTEL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTELEXT"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELEXT")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTMPHONE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTFAX"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTEMAIL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTEMAIL")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTELCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTFAXCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAXCODE")).Text;
        }
        ViewState["Contact"] = LOBJ_Contact;
        if (ViewState["STATUS"].ToString() != "SELECT")
        {
            DataRow LOBJ_ConInfo = null;
            LOBJ_ConInfo = LOBJ_Contact.NewRow();
            LOBJ_Contact.Rows.Add(LOBJ_ConInfo);
            ViewState["Contact"] = LOBJ_Contact;
            rptContactBind();
            this.hidSelRowIndex.Value = "-1";
        }
        this.UpdatePanel2.Update();
    }
    //Add 20131029 REASON 重構F9刪除關係人GRID
    private void DelRow_rptContact()
    {
        //先把內容存到datatable中
        DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
        int LINT_ConNum = rptContact.Items.Count;
        for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
        {
            LOBJ_Contact.Rows[LINT_I]["CONTACTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTNAME")).Text;
            LOBJ_Contact.Rows[LINT_I]["DEPTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtDEPTNAME")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTITLE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTITLE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTEL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTEL")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTELEXT"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELEXT")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTMPHONE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTMPHONE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTFAX"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAX")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTEMAIL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTEMAIL")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTTELCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELCODE")).Text;
            LOBJ_Contact.Rows[LINT_I]["CONTACTFAXCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAXCODE")).Text;
        }
        ViewState["Contact"] = LOBJ_Contact;
        int LINT_SelIndex = Convert.ToInt32(this.hidSelRowIndex.Value);
        if (ViewState["STATUS"].ToString() != "SELECT" && LINT_SelIndex != -1)
        {
            if (LOBJ_Contact.Rows.Count > 0)
            {
                LOBJ_Contact.Rows.RemoveAt(LINT_SelIndex);
                this.hidSelRowIndex.Value = "-1";
            }
            ViewState["Contact"] = LOBJ_Contact;
            rptContactBind();
        }
        this.UpdatePanel2.Update();
    }
    private void GetCustContactBind(DataTable LOBJ_Data)
    {
        ViewState["Contact"] = LOBJ_Data;
        rptContactBind();
    }
    //ADD 20131029 REASON 取得董監事股東GRID資料
    private void GetCustDirStockBind(DataTable LOBJ_Data)
    {
        ViewState["DirStock"] = LOBJ_Data;
        rptDirStockBind();
    }
    //ADD 20131029 REASON 取得公司不動產GRID資料
    private void GetCustIMMOVABLEBind(DataTable LOBJ_Data)
    {
        ViewState["IMMOVABLE"] = LOBJ_Data;
        rptIMMOVABLEBind();
    }
    #endregion
    //ADD 20131029 增加控制項回傳副程式
    private string ControlToString(object o)
    {
        string returnStr = "";
        if (o.GetType().Name.Equals("DropDownList"))
        {
            returnStr = (o == null) ? "" : ((DropDownList)o).SelectedValue;
        }
        if (o.GetType().Name.Equals("TextBox"))
        {
            returnStr = (o == null) ? "" : ((TextBox)o).Text; ;
        }
        return returnStr;
    }
    //ADD 20131029 增加控制項回傳副程式
    private int ControlToInt(object o)
    {
        int returnInt = 0;
        if (o.GetType().Name.Equals("TextBox"))
        {
            try
            {
                returnInt = (o == null) ? 0 : Convert.ToInt16(((TextBox)o).Text);
            }
            catch
            {
                returnInt = 0;
            }
        }
        return returnInt;
    }

    private void FormDrpBind()
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();

            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                //公司屬性drpCOMPTYPE
                this.drpCOMPTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpCOMPTYPE.DataBind();
                //組織形態drpORGATYPE
                this.drpORGATYPE.DataSource = LDST_Data.Tables[1].DefaultView;
                this.drpORGATYPE.DataBind();
                //上市櫃drpLISTED
                this.drpLISTED.DataSource = LDST_Data.Tables[2].DefaultView;
                this.drpLISTED.DataBind();
                //母行業別drpCUROUT
                this.drpCUROUT.DataSource = LDST_Data.Tables[3].DefaultView;
                this.drpCUROUT.DataBind();
                //人數drpEMPLOYEE
                this.drpEMPLOYEE.DataSource = LDST_Data.Tables[4].DefaultView;
                this.drpEMPLOYEE.DataBind();
                //客戶性質drpCUTYPE
                this.drpCUTYPE.DataSource = LDST_Data.Tables[5].DefaultView;
                this.drpCUTYPE.DataBind();
                //郵編區號
                this.drpCODE.DataSource = LDST_Data.Tables[6].DefaultView;
                this.drpCODE.DataBind();
                //20221031行業別改下拉選單
                this.DrpNDU.DataSource = LDST_Data.Tables[7].DefaultView;
                DataView LDVW_DocData = LDST_Data.Tables[7].DefaultView;
                LDVW_DocData.RowFilter = "MCODE NOT IN ('17' , '18'  , '19' , '20')";
                this.DrpNDU.DataBind();
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private string CheckCusRule(string LSTR_Type)
    {
        string LSTR_ReturnMessage = "";
        //先判斷客戶是否存在
        string LSTR_CusID = this.txtCUSTID.Text;
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetCustomerDataById(LSTR_CusID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                //ADD ACH資料檢核
                if (ACHBANKCODE.Text != "")
                {
                    if (ACHBANKCODES.Text == "" || ACHACCOUNT.Text == "" || ACHID.Text == "" || ACHNAME.Text == "" || ACHPAYDAY.SelectedValue == "")
                    {
                        LSTR_ReturnMessage = "ACH相關資料不可空白！";
                        return LSTR_ReturnMessage;
                    }
                }
                //20221031行業別改下拉選單必填驗證
                if (this.DrpNDU.SelectedValue.Trim() == "")
                {
                    LSTR_ReturnMessage = "請選擇行業別";
                    return LSTR_ReturnMessage;
                }
                //20221031 公司屬性、組織型態新增驗證
                if (this.drpCOMPTYPE.SelectedValue.Trim() == "")
                {
                    LSTR_ReturnMessage = "請選擇公司屬性";
                    return LSTR_ReturnMessage;
                }
                if (this.drpORGATYPE.SelectedValue.Trim() == "")
                {
                    LSTR_ReturnMessage = "請選擇組織型態";
                    return LSTR_ReturnMessage;
                }

                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                if ((LSTR_Type == "INSERT" && LDST_Data.Tables[0].Rows.Count == 0) || (LSTR_Type == "UPDATE" && LDST_Data.Tables[0].Rows.Count != 0))
                {
                    DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
                    int LINT_ConNum = rptContact.Items.Count;
                    for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
                    {
                        if (LOBJ_Contact.Rows[LINT_I]["CONTACTID"].ToString().Trim() == "")
                        {
                            LOBJ_Contact.Rows[LINT_I]["CONTACTID"] = Itg.Community.Util.GetIDSequence("MLDCUSTCONTACT", "14");
                        }
                        LOBJ_Contact.Rows[LINT_I]["CONTACTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTNAME")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["DEPTNAME"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtDEPTNAME")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTTITLE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTITLE")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTTEL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTEL")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTTELEXT"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELEXT")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTMPHONE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTMPHONE")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTFAX"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAX")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTEMAIL"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTEMAIL")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTTELCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTTELCODE")).Text.Trim();
                        LOBJ_Contact.Rows[LINT_I]["CONTACTFAXCODE"] = ((TextBox)rptContact.Items[LINT_I].FindControl("txtCONTACTFAXCODE")).Text.Trim();
                        if (string.IsNullOrEmpty(LOBJ_Contact.Rows[LINT_I]["CONTACTNAME"].ToString().Trim()))
                        {
                            LSTR_ReturnMessage = "請輸入關係聯絡人姓名！";
                            return LSTR_ReturnMessage;
                        }
                        if (string.IsNullOrEmpty(LOBJ_Contact.Rows[LINT_I]["CONTACTTELCODE"].ToString().Trim()))
                        {
                            LSTR_ReturnMessage = "請輸入關係聯絡人電話區碼！";
                            return LSTR_ReturnMessage;
                        }
                        if (string.IsNullOrEmpty(LOBJ_Contact.Rows[LINT_I]["CONTACTTEL"].ToString().Trim()))
                        {
                            LSTR_ReturnMessage = "請輸入關係聯絡人電話！";
                            return LSTR_ReturnMessage;
                        }
                    }
                    ViewState["Contact"] = LOBJ_Contact;
                    //ADD 20131030 REASON:董監事股東GRID 檢核
                    //20221031隱藏董監事股東GRID
                    DataTable LOBJ_DirStock = (DataTable)ViewState["DirStock"];
                    //for (int LINT_I = 0; LINT_I < rptDirStock.Items.Count; LINT_I++)
                    //{
                    //    //ADD 20140114 JBLEO 新增年齡判斷，需在寫入虛擬表前擋掉，否則會因型別不同產生錯誤
                    //    if (string.IsNullOrEmpty(((TextBox)rptDirStock.Items[LINT_I].FindControl("txtAGE")).Text))
                    //    {
                    //        LSTR_ReturnMessage = "董監事股東年齡不可為空白！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    LOBJ_DirStock.Rows[LINT_I]["TITLENM"] = ((TextBox)rptDirStock.Items[LINT_I].FindControl("txtTITLENM")).Text;
                    //    LOBJ_DirStock.Rows[LINT_I]["NAME"] = ((TextBox)rptDirStock.Items[LINT_I].FindControl("txtNAME")).Text;
                    //    LOBJ_DirStock.Rows[LINT_I]["SEX"] = ControlToString(rptDirStock.Items[LINT_I].FindControl("ddlSEX")).Trim();
                    //    LOBJ_DirStock.Rows[LINT_I]["AGE"] = ((TextBox)rptDirStock.Items[LINT_I].FindControl("txtAGE")).Text;
                    //    LOBJ_DirStock.Rows[LINT_I]["INVAMT"] = ((TextBox)rptDirStock.Items[LINT_I].FindControl("txtINVAMT")).Text.Replace(",", "");
                    //    LOBJ_DirStock.Rows[LINT_I]["MEMO"] = ((TextBox)rptDirStock.Items[LINT_I].FindControl("txtMEMO")).Text;
                    //    if (string.IsNullOrEmpty(LOBJ_DirStock.Rows[LINT_I]["NAME"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入董監事股東姓名！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_DirStock.Rows[LINT_I]["INVAMT"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入投資金額！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //}
                    ViewState["DirStock"] = LOBJ_DirStock;
                    //ADD 20131030 REASON:公司不動產GRID 檢核
                    //20221031隱藏公司不動產GRID
                    DataTable LOBJ_IMMOVABLE = (DataTable)ViewState["IMMOVABLE"];
                    //for (int LINT_I = 0; LINT_I < rptIMMOVABLE.Items.Count; LINT_I++)
                    //{
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["OWNER"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtOWNER")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["BUYDATE"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtBUYDATE")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["APP"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtAPP")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["LOCATION"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtLOCATION")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["AREA"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtAREA")).Text.Replace(",", "");
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDER"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDER")).Text.Replace(",", "");
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDERAREA"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDERAREA")).Text.Replace(",","");
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET1"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("txtPICKSET1")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["BANK1"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK1")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR1"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR1")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT1"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT1")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["PICKSET2"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxPICKSET2")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["BANK2"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK2")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["DEBTOR2"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR2")).Text;
                    //    LOBJ_IMMOVABLE.Rows[LINT_I]["SETAMT2"] = ((TextBox)rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT2")).Text;
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["OWNER"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入所有權人！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["OWNER"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入購入日期！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["APP"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入用途！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["LOCATION"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入座落位置！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["AREA"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入面積(坪)！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDER"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入持分！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //    if (string.IsNullOrEmpty(LOBJ_IMMOVABLE.Rows[LINT_I]["HOLDERAREA"].ToString().Trim()))
                    //    {
                    //        LSTR_ReturnMessage = "請輸入持有面積(坪)！";
                    //        return LSTR_ReturnMessage;
                    //    }
                    //}
                    ViewState["IMMOVABLE"] = LOBJ_IMMOVABLE;
                }
                else
                {
                    if (LSTR_Type == "INSERT")
                    {
                        LSTR_ReturnMessage = Resources.HeRun.H005;
                    }
                    else
                    {
                        LSTR_ReturnMessage = Resources.HeRun.H006;
                    }
                }
            }
            else
            {
                LSTR_ReturnMessage = LOBJ_ReturnObject.ReturnMessage;
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        return LSTR_ReturnMessage;
    }
    protected void drpCUROUT_SelectedIndexChanged(object sender, EventArgs e)
    {
        string LSTR_CUROUT = this.drpCUROUT.SelectedValue;
        drpCUROUTBindbyID(LSTR_CUROUT);
    }
    private void drpCUROUTBindbyID(string LSTR_CUROUT)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBLEASEUNIONDataById(LSTR_CUROUT);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                this.drpCUROUTF.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpCUROUTF.DataBind();
                if (drpCUROUTF.Items.Count == 1)
                {
                    drpCUROUTF.Enabled = false;
                }
                else
                {
                    drpCUROUTF.Enabled = true;
                }
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void GetCustomerBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            this.txtCUSTID.Text = LOBJ_Data.Rows[0]["CUSTID"].ToString().Trim();
            this.txtCUSTNAME.Text = LOBJ_Data.Rows[0]["CUSTNAME"].ToString().Trim();
            try
            {
                this.drpCUTYPE.Text = LOBJ_Data.Rows[0]["CUTYPE"].ToString().Trim();
            }
            catch (Exception ex)
            {
            }
            this.txtCUSTCREATECAPTIAL.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CUSTCREATECAPTIAL"].ToString().Trim());
            this.txtCUSTNOWCAPTIAL.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CUSTNOWCAPTIAL"].ToString().Trim());
            this.txtCUSTCREATEDATE.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["CUSTCREATEDATE"].ToString()).Trim();
            this.drpEMPLOYEE.SelectedValue = LOBJ_Data.Rows[0]["EMPLOYEE"].ToString().Trim();
            this.txtOWNER.Text = LOBJ_Data.Rows[0]["OWNER"].ToString().Trim();
            this.txtOWNERID.Text = LOBJ_Data.Rows[0]["OWNERID"].ToString().Trim();
            this.txtGROUPOWNER.Text = LOBJ_Data.Rows[0]["GROUPOWNER"].ToString().Trim();
            this.txtPARENTCUSTID.Text = LOBJ_Data.Rows[0]["PARENTCUSTID"].ToString().Trim();
            this.txtPARENTCUSTNAME.Text = LOBJ_Data.Rows[0]["PARENTCUSTNAME"].ToString().Trim();
            this.txtCUSTZIPCODE.Text = LOBJ_Data.Rows[0]["CUSTZIPCODE"].ToString().Trim();
            this.txtCUSTZIPCODES.Text = LOBJ_Data.Rows[0]["CUSTZIPCODES"].ToString().Trim();
            this.txtCUSTADDR.Text = LOBJ_Data.Rows[0]["CUSTADDR"].ToString().Trim();
            this.txtCUSTTEL.Text = LOBJ_Data.Rows[0]["CUSTTEL"].ToString().Trim();
            this.txtCUSTFAX.Text = LOBJ_Data.Rows[0]["CUSTFAX"].ToString().Trim();
            this.txtBUSINESSZIPCODE.Text = LOBJ_Data.Rows[0]["BUSINESSZIPCODE"].ToString().Trim();
            this.txtBUSINESSZIPCODES.Text = LOBJ_Data.Rows[0]["BUSINESSZIPCODES"].ToString().Trim();
            this.txtBUSINESSADDR.Text = LOBJ_Data.Rows[0]["BUSINESSADDR"].ToString().Trim();
            this.txtBUSINESSTTEL.Text = LOBJ_Data.Rows[0]["BUSINESSTTEL"].ToString().Trim();
            this.txtBUSINESSFAX.Text = LOBJ_Data.Rows[0]["BUSINESSFAX"].ToString().Trim();
            this.drpCOMPTYPE.SelectedValue = LOBJ_Data.Rows[0]["COMPTYPE"].ToString().Trim();
            this.drpORGATYPE.SelectedValue = LOBJ_Data.Rows[0]["ORGATYPE"].ToString().Trim();
            this.drpLISTED.SelectedValue = LOBJ_Data.Rows[0]["LISTED"].ToString().Trim();
            this.txtBUSINESS.Text = LOBJ_Data.Rows[0]["BUSINESS"].ToString().Trim();
            this.drpCUROUT.SelectedValue = LOBJ_Data.Rows[0]["CUROUT"].ToString().Trim();
            drpCUROUTBindbyID(this.drpCUROUT.SelectedValue);
            this.drpCUROUTF.SelectedValue = LOBJ_Data.Rows[0]["CUROUTF"].ToString().Trim();

            this.txtCUSTTELCODE.Text = LOBJ_Data.Rows[0]["CUSTTELCODE"].ToString().Trim();
            this.txtCUSTFAXCODE.Text = LOBJ_Data.Rows[0]["CUSTFAXCODE"].ToString().Trim();
            this.txtBUSINESSTTELCODE.Text = LOBJ_Data.Rows[0]["BUSINESSTTELCODE"].ToString().Trim();
            this.txtBUSINESSFAXCODE.Text = LOBJ_Data.Rows[0]["BUSINESSFAXCODE"].ToString().Trim();
            //ADD 20131029 REASON 增加備註 公司沿革欄位
            this.tbxMemo.Text = LOBJ_Data.Rows[0]["MEMO"].ToString().Trim();
            this.tbxCUSTINTRO.Text = LOBJ_Data.Rows[0]["CUSTINTRO"].ToString().Trim();
            this.txtBUSINESS.Width = 500;
            //20160322 ADD BY SS ADAM REASON.增加行業別
            this.txtINDUID.Text = LOBJ_Data.Rows[0]["INDUID"].ToString().Trim();
            this.txtINDUNM.Text = LOBJ_Data.Rows[0]["INDUNM"].ToString().Trim();
            //20221031 行業別改下拉選單
            this.DrpNDU.SelectedValue = LOBJ_Data.Rows[0]["CUROUT"].ToString().Trim();
            //20231130 ADD ACH銀行資訊
            this.ACHBANKCODE.Text = LOBJ_Data.Rows[0]["ACHBANKCODE"].ToString().Trim();
            this.ACHBANKCODES.Text = LOBJ_Data.Rows[0]["ACHBANKCODES"].ToString().Trim();
            this.ACHID.Text = LOBJ_Data.Rows[0]["ACHID"].ToString().Trim();
            this.ACHACCOUNT.Text = LOBJ_Data.Rows[0]["ACHACCOUNT"].ToString().Trim();
            this.ACHNAME.Text = LOBJ_Data.Rows[0]["ACHNAME"].ToString().Trim();
            this.ACHPAYDAY.SelectedValue = LOBJ_Data.Rows[0]["ACHPAYDAY"].ToString().Trim();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string LSTR_SelHead = this.hidSelHeadTag.Value;
        switch (LSTR_SelHead)
        {
            case "rptDirStock":
                AddRow_rptDirStock();
                break;
            case "rptContact":
                AddRow_rptContact();
                break;
            case "rptIMMOVABLE":
                AddRow_rptIMMOVABLE();
                break;
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string LSTR_SelHead = this.hidSelHeadTag.Value;
        switch (LSTR_SelHead)
        {
            case "rptDirStock":
                DelRow_rptDirStock();
                break;
            case "rptContact":
                DelRow_rptContact();
                break;
            case "rptIMMOVABLE":
                DelRow_rptIMMOVABLE();
                break;
        }

    }
    protected void btnQue_Click(object sender, EventArgs e)
    {
        string LSTR_CUSTID = this.hidCustomer.Value.Trim();
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetCustomerDataByID(LSTR_CUSTID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                GetCustomerBind(LDST_Data.Tables[0]);
                GetCustContactBind(LDST_Data.Tables[1]);
                //ADD 20131030 REASON 查詢董監事股東GRID
                GetCustDirStockBind(LDST_Data.Tables[2]);
                //ADD 20131030 REASON 查詢公司不動產GRID
                GetCustIMMOVABLEBind(LDST_Data.Tables[3]);
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        if (ViewState["STATUS"].ToString() == "SELECT")
        {
            RegisterScript("SetDisabled('div_Info','" + btnSubmit.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES,btnCUSTZIPCODES,btnBUSINESSZIPCODE','btnSelect')");
        }
        else
        {
            RegisterScript("SetEnabled('div_Info','" + txtCUSTID.ClientID + "," + drpCUTYPE.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES','" + btnSubmit.ClientID + "')");
        }
        this.UpdatePanel1.Update();
    }

    //20221031 若設備無資料從長租帶資料
    protected void btnQue2_Click(object sender, EventArgs e)
    {
        string LSTR_CUSTID = this.hidCustomer.Value.Trim();
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetLLCustomerDataByID(LSTR_CUSTID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                GetLLCustomerBind(LDST_Data.Tables[0]);
            }
            else
            {
                Alert(LOBJ_ReturnObject.ReturnMessage);
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
        if (ViewState["STATUS"].ToString() == "SELECT")
        {
            RegisterScript("SetDisabled('div_Info','" + btnSubmit.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES,btnCUSTZIPCODES,btnBUSINESSZIPCODE','btnSelect')");
        }
        else
        {
            RegisterScript("SetEnabled('div_Info','" + txtCUSTID.ClientID + "," + drpCUTYPE.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES','" + btnSubmit.ClientID + "')");
        }
        this.UpdatePanel1.Update();
    }
    private ReturnObject<DataSet> GetLLCustomerDataByID(string LSTR_CUSTID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML1001_Q08" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private void GetLLCustomerBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            this.txtCUSTID.Text = LOBJ_Data.Rows[0]["CUSTID"].ToString().Trim();
            this.txtCUSTNAME.Text = LOBJ_Data.Rows[0]["CUSTNAME"].ToString().Trim();
            try
            {
            }
            catch (Exception ex)
            {
            }
            this.txtCUSTCREATECAPTIAL.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CUSTCREATECAPTIAL"].ToString().Trim());
            this.txtCUSTNOWCAPTIAL.Text = Itg.Community.Util.NumberFormat(LOBJ_Data.Rows[0]["CUSTNOWCAPTIAL"].ToString().Trim());
            this.txtCUSTCREATEDATE.Text = Itg.Community.Util.GetRepYear(LOBJ_Data.Rows[0]["CUSTCREATEDATE"].ToString()).Trim();
            this.txtCUSTZIPCODE.Text = LOBJ_Data.Rows[0]["CUSTZIPCODE"].ToString().Trim();
            this.txtCUSTADDR.Text = LOBJ_Data.Rows[0]["CUSTADDR"].ToString().Trim();
            this.txtCUSTZIPCODES.Text = LOBJ_Data.Rows[0]["CUSTZIPCODES"].ToString().Trim();
            this.txtCUSTTEL.Text = LOBJ_Data.Rows[0]["CUSTTEL"].ToString().Trim();
            this.txtBUSINESS.Text = LOBJ_Data.Rows[0]["BUSINESS"].ToString().Trim();
            this.txtCUSTTELCODE.Text = LOBJ_Data.Rows[0]["CUSTTELCODE"].ToString().Trim();
            Alert("已從長租系統帶資料");
        }
    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {
        ViewState["STATUS"] = "INSERT";
        rptContactClear();
        //ADD 20131030 REASON 增加董監事股東GRID清除
        rptDirStockClear();
        //ADD 20131030 REASON 增加公司不動產GRID清除
        rptIMMOVABLEClear();
        this.drpCUTYPE.SelectedValue = "2";
        RegisterScript("SetEnabled('div_Info','btnSelect,txtBUSINESSZIPCODES,txtCUSTZIPCODES','" + btnSubmit.ClientID + "')");
        this.txtCUSTID.Enabled = true;
        this.txtCUSTNAME.Enabled = true;

        this.btnInsert.Enabled = false;
        this.btnUpdate.Enabled = false;
        this.btnSearch.Enabled = false;

        this.btnSubmit.Enabled = true;

        this.btnCUSTZIPCODES.Disabled = false;
        this.btnBUSINESSZIPCODE.Disabled = false;
        this.btnACHBANKCODE.Disabled = false;
        this.lblStatus.Text = "新增";
        this.UpdatePanel1.Update();
        //UPD 20140114 JBLEO 將備註、公司簡易沿革改為進處理區分後才啟用
        tbxMemo.Enabled = true;
        tbxCUSTINTRO.Enabled = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ViewState["STATUS"] = "UPDATE";
        rptContactClear();
        //ADD 20131030 REASON 增加董監事股東GRID清除
        rptDirStockClear();
        //ADD 20131030 REASON 增加公司不動產GRID清除
        rptIMMOVABLEClear();
        this.drpCUTYPE.SelectedValue = "2";
        RegisterScript("SetDisabled('div_Info','" + btnSubmit.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES,btnCUSTZIPCODES,btnBUSINESSZIPCODE','btnSelect," + this.txtCUSTID.ClientID + "');txtCUSTID_Enable();");
        this.txtCUSTID.Enabled = true;
        this.txtCUSTNAME.Enabled = true;

        this.btnInsert.Enabled = false;
        this.btnUpdate.Enabled = false;
        this.btnSearch.Enabled = false;

        this.btnSubmit.Enabled = true;

        this.btnSelect.Disabled = false;
        this.btnCUSTZIPCODES.Disabled = false;
        this.btnBUSINESSZIPCODE.Disabled = false;
        this.btnACHBANKCODE.Disabled = false;
        this.lblStatus.Text = "修改";
        this.UpdatePanel1.Update();
        //UPD 20140114 JBLEO 將備註、公司簡易沿革改為進處理區分後才啟用
        tbxMemo.Enabled = true;
        tbxCUSTINTRO.Enabled = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["STATUS"] = "SELECT";
        rptContactClear();
        //ADD 20131030 REASON 增加董監事股東GRID清除
        rptDirStockClear();
        //ADD 20131030 REASON 增加公司不動產GRID清除
        rptIMMOVABLEClear();
        this.drpCUTYPE.SelectedValue = "2";
        RegisterScript("SetDisabled('div_Info','" + btnSubmit.ClientID + ",txtBUSINESSZIPCODES,txtCUSTZIPCODES,btnCUSTZIPCODES,btnBUSINESSZIPCODE','btnSelect')");
        this.btnInsert.Enabled = true;
        this.btnUpdate.Enabled = true;
        this.btnSearch.Enabled = false;

        this.btnSelect.Disabled = false;
        this.lblStatus.Text = "查詢";
        this.UpdatePanel1.Update();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //判斷聯絡人必填
        string LSTR_Type = ViewState["STATUS"].ToString();
        string LSTR_RuleMsg = CheckCusRule(LSTR_Type);
        if (LSTR_RuleMsg == "")
        {
            //拼接信息
            StringBuilder LSTR_Data = new StringBuilder();
            //=========================================================================
            LSTR_Data.Append("SP_ML1001_I01" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTNAME.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpCUTYPE.SelectedValue.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTCREATECAPTIAL.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTNOWCAPTIAL.Text.Trim() + GSTR_TabDelimitChar);

            LSTR_Data.Append(this.txtCUSTCREATEDATE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpEMPLOYEE.SelectedValue.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtOWNER.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtOWNERID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtGROUPOWNER.Text.Trim() + GSTR_TabDelimitChar);

            LSTR_Data.Append(this.txtPARENTCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtPARENTCUSTNAME.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTZIPCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTADDR.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTTEL.Text.Trim() + GSTR_TabDelimitChar);

            LSTR_Data.Append(this.txtCUSTFAX.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSZIPCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSADDR.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSTTEL.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSFAX.Text.Trim() + GSTR_TabDelimitChar);

            LSTR_Data.Append(this.drpCOMPTYPE.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpORGATYPE.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpLISTED.SelectedValue + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESS.Text.Trim() + GSTR_TabDelimitChar);
            //20221031行業別儲存至CUROUT
            LSTR_Data.Append(this.DrpNDU.SelectedValue.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.drpCUROUT.SelectedValue.Trim() + GSTR_TabDelimitChar);
            //LSTR_Data.Append(this.drpCUROUTF.SelectedValue.Trim() + GSTR_TabDelimitChar);

            string CUTYPE = drpCUTYPE.SelectedValue;
            string LSTR_CUSTID = txtCUSTID.Text;
            /*
                       try
                       {
                         ReturnObject<DataSet> LOBJ_ReturnObject = GetLLVLNUMData(LSTR_Type, LSTR_CUSTID);
                         if (LOBJ_ReturnObject.ReturnSuccess)
                         {
                           DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                           LSTR_Data.Append(LDST_Data.Tables[0].Rows[0][0].ToString().Trim() + GSTR_TabDelimitChar);
                           LSTR_Data.Append(LDST_Data.Tables[0].Rows[0][1].ToString().Trim() + GSTR_TabDelimitChar);
                         }
                         else
                         {
                           Alert(LOBJ_ReturnObject.ReturnMessage);
                         }
                       }
                       catch (Exception ex)
                       {
                         Alert(ex.Message);
                       }
                       */

            if (CUTYPE == "1")
            {
                //個人
                string LSTR_CODE = (Convert.ToInt16(Convert.ToChar(LSTR_CUSTID.Substring(1, 1))) - 64).ToString().PadLeft(2, '0');
                LSTR_Data.Append("735" + "" + LSTR_CODE + "" + LSTR_CUSTID + GSTR_TabDelimitChar);  //虛擬帳號_和運
                LSTR_Data.Append("739" + "" + LSTR_CODE + "" + LSTR_CUSTID + GSTR_TabDelimitChar);  //虛擬帳號_和潤
            }
            else if (CUTYPE == "2")
            {
                //法人
                LSTR_Data.Append("735" + "" + LSTR_CUSTID + GSTR_TabDelimitChar);  //虛擬帳號_和運
                LSTR_Data.Append("739" + "" + LSTR_CUSTID + GSTR_TabDelimitChar);  //虛擬帳號_和潤
            }

            else
            {
                LSTR_Data.Append("" + GSTR_TabDelimitChar);  //虛擬帳號_和運
                LSTR_Data.Append("" + GSTR_TabDelimitChar);  //虛擬帳號_和潤
                                                             //LSTR_Data.Append("071540179161" + GSTR_TabDelimitChar);  //虛擬帳號_和運
                                                             //LSTR_Data.Append("071540179145" + GSTR_TabDelimitChar);  //虛擬帳號_和潤
            }

            LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);//A_SYSDT
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//U_SYSDT 
            LSTR_Data.Append(this.txtCUSTTELCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtCUSTFAXCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSTTELCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.txtBUSINESSFAXCODE.Text.Trim() + GSTR_TabDelimitChar);
            //ADD 20131028 REASON:增加備註 公司簡易沿革
            LSTR_Data.Append(this.tbxMemo.Text + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.tbxCUSTINTRO.Text + GSTR_TabDelimitChar);
            //20160322 ADD BY SS ADAM REASON.新增行業別
            //LSTR_Data.Append(this.txtINDUID.Text);
            //20221031行業別改下拉選單
            LSTR_Data.Append(this.DrpNDU.SelectedValue.Trim() + GSTR_TabDelimitChar);

            //20231130 ADD ACH銀行資訊
            LSTR_Data.Append(this.ACHBANKCODE.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.ACHBANKCODES.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.ACHID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.ACHACCOUNT.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.ACHNAME.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(this.ACHPAYDAY.SelectedValue.Trim());

            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //=========================================================================
            LSTR_Data.Append("SP_ML1001_I02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);
            //=========================================================================
            //20140522 ADD BY SS ADAM REASON.修正grid無法刪除的錯誤

            LSTR_Data.Append("SP_ML1001_U02" + GSTR_ColDelimitChar);
            LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
            LSTR_Data.Append(GSTR_ColDelimitChar);
            LSTR_Data.Append(GSTR_RowDelimitChar);

            //=======================================================================
            int LINT_ConNum = rptContact.Items.Count;
            if (LINT_ConNum > 0)
            {
                DataTable LOBJ_Contact = (DataTable)ViewState["Contact"];
                for (int LINT_I = 0; LINT_I < LINT_ConNum; LINT_I++)
                {
                    LSTR_Data.Append("SP_ML1001_I03" + GSTR_ColDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTID"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTNAME"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["DEPTNAME"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTTITLE"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTTEL"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTTELEXT"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTMPHONE"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTFAX"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTEMAIL"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTTELCODE"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(LOBJ_Contact.Rows[LINT_I]["CONTACTFAXCODE"].ToString().Trim() + GSTR_TabDelimitChar);
                    LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
                    LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
                    LSTR_Data.Append(GSTR_A_SYSDT + GSTR_TabDelimitChar);//A_SYSDT
                    LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
                    LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
                    LSTR_Data.Append(GSTR_U_SYSDT);//U_SYSDT 
                    LSTR_Data.Append(GSTR_ColDelimitChar);
                    LSTR_Data.Append(GSTR_RowDelimitChar);
                }
            }
            LSTR_Data = LSTR_Data.Replace("'", "’");
            LSTR_Data = LSTR_Data.Replace("\"", "”");
            LSTR_Data = LSTR_Data.Replace("--", "－－");
            //=========================================================================
            //ADD 20131028 REASON:新增董監事股東GRID
            //if (rptDirStock.Items.Count > 0)
            //{
            //    DataTable LOBJ_DirStock = (DataTable)ViewState["DirStock"];
            //    for (int LINT_I = 0; LINT_I < rptDirStock.Items.Count; LINT_I++)
            //    {
            //        LSTR_Data.Append("SP_ML1001_I04" + GSTR_ColDelimitChar);
            //        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            //        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//A_SYSDT
            //        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            //        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//U_SYSDT 
            //        LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append((LINT_I + 1).ToString().Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptDirStock.Items[LINT_I].FindControl("txtTITLENM")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptDirStock.Items[LINT_I].FindControl("txtNAME")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptDirStock.Items[LINT_I].FindControl("ddlSEX")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToInt(rptDirStock.Items[LINT_I].FindControl("txtAGE")).ToString().Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptDirStock.Items[LINT_I].FindControl("txtINVAMT")).Trim().Replace(",", "") + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptDirStock.Items[LINT_I].FindControl("txtMEMO")).Trim());

            //        //LSTR_Data.Append("SP_ML1001_I04" + GSTR_ColDelimitChar);
            //        //LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            //        //LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            //        //LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//A_SYSDT
            //        //LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            //        //LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            //        //LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//U_SYSDT 
            //        //LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LINT_I.ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["TITLENM"].ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["NAME"].ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["SEX"].ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["AGE"].ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["INVAMT"].ToString().Trim() + GSTR_TabDelimitChar);
            //        //LSTR_Data.Append(LOBJ_DirStock.Rows[LINT_I]["MEMO"].ToString().Trim() );
            //        LSTR_Data.Append(GSTR_ColDelimitChar);
            //        LSTR_Data.Append(GSTR_RowDelimitChar);
            //    }
            //}
            //LSTR_Data = LSTR_Data.Replace("'", "’");
            //LSTR_Data = LSTR_Data.Replace("\"", "”");
            //LSTR_Data = LSTR_Data.Replace("--", "－－");
            //=========================================================================
            //ADD 20131028 REASON:新增董監事股東GRID
            //if (rptIMMOVABLE.Items.Count > 0)
            //{
            //    DataTable LOBJ_IMMOVABLE = (DataTable)ViewState["IMMOVABLE"];
            //    for (int LINT_I = 0; LINT_I < rptIMMOVABLE.Items.Count; LINT_I++)
            //    {
            //        LSTR_Data.Append("SP_ML1001_I05" + GSTR_ColDelimitChar);
            //        LSTR_Data.Append(GSTR_A_PRGID + GSTR_TabDelimitChar);//A_PRGID
            //        LSTR_Data.Append(GSTR_A_USERID + GSTR_TabDelimitChar);//A_USERID 
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//A_SYSDT
            //        LSTR_Data.Append(GSTR_U_PRGID + GSTR_TabDelimitChar);//U_PRGID
            //        LSTR_Data.Append(GSTR_U_USERID + GSTR_TabDelimitChar);//U_USERID
            //        LSTR_Data.Append(GSTR_U_SYSDT + GSTR_TabDelimitChar);//U_SYSDT 
            //        LSTR_Data.Append(this.txtCUSTID.Text.Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append((LINT_I + 1).ToString().Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtOWNER")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtBUYDATE")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAPP")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtLOCATION")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtAREA")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDER")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtHOLDERAREA")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("txtPICKSET1")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK1")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR1")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT1")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxPICKSET2")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxBANK2")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxDEBTOR2")).Trim() + GSTR_TabDelimitChar);
            //        LSTR_Data.Append(ControlToString(rptIMMOVABLE.Items[LINT_I].FindControl("tbxSETAMT2")).Trim());
            //        LSTR_Data.Append(GSTR_ColDelimitChar);
            //        LSTR_Data.Append(GSTR_RowDelimitChar);
            //    }
            //}
            //LSTR_Data = LSTR_Data.Replace("'", "’");
            //LSTR_Data = LSTR_Data.Replace("\"", "”");
            //LSTR_Data = LSTR_Data.Replace("--", "－－");
            //=========================================================================
            try
            {
                ReturnObject<object> LOBJ_ReturnObject = SaveCustomer(LSTR_Data.ToString());
                if (LOBJ_ReturnObject.ReturnSuccess)
                {
                    if (LSTR_Type == "INSERT")
                    {
                        Alert(Resources.HeRun.H001);
                    }
                    else
                    {
                        Alert(Resources.HeRun.H003);
                    }
                    this.btnInsert.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnSearch.Enabled = true;
                    this.btnSubmit.Enabled = false;
                    //UPD 20141014  JBLEO tbxMemo、tbxCUSTINTRO 改為Disabled 
                    RegisterScript("SetDisabled('div_Info', 'btnCUSTZIPCODES,btnBUSINESSZIPCODE,btnSelect,tbxMemo,tbxCUSTINTRO','" + this.btnInsert.ClientID + "," + this.btnUpdate.ClientID + "," + this.btnSearch.ClientID + "');");
                }
                else
                {
                    Alert(LOBJ_ReturnObject.ReturnMessage);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }
        else
        {
            Alert(LSTR_RuleMsg);
        }
        this.UpdatePanel1.Update();

    }

    private ReturnObject<object> SaveCustomer(string LSTR_Data)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        ReturnObject<object> LOBJ_Return;
        string[] LVAR_Parameter = new string[1];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiNonQuerySPExec";
            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_Data;
            LOBJ_Return = LOBJ_Submit.SubmitEx<object>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetCustomerDataByID(string LSTR_CUSTID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML1001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //聯絡人信息
            LSTR_StoreProcedure.Append("SP_ML1001_Q03" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //ADD 20131028 REASON:增加董監事股東GRID
            LSTR_StoreProcedure.Append("SP_ML1001_Q05" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //ADD 20131030 REASON:增加公司不動產GRID
            LSTR_StoreProcedure.Append("SP_ML1001_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetSUBLEASEUNIONDataById(string LSTR_CUROUT)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //子行業別drpCUROUTF
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + LSTR_CUROUT + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetCustomerDataById(string LSTR_CusID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //子行業別drpCUROUTF
            LSTR_StoreProcedure.Append("SP_ML1001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_CusID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetDrpData()
    {

        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //公司屬性drpCOMPTYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "26" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //組織形態drpORGATYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "02" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //上市櫃drpLISTED
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "27" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //母行業別drpCUROUT
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //人數drpEMPLOYEE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "89" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //客戶性質drpCUTYPE
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "03" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //郵編區號
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LC" + GSTR_ColDelimitChar + "01" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            //20221031行業別改下拉選單
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LL" + GSTR_ColDelimitChar + "55" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();

            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);

        }
        catch (Exception ex)
        {

            throw ex;
        }
        return LOBJ_Return;
    }
    private ReturnObject<DataSet> GetLLVLNUMData(string LSTR_Type, string LSTR_CUSTID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML0001_Q05" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(LSTR_Type + GSTR_ColDelimitChar + LSTR_CUSTID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            LOBJ_Submit = new Comus.HtmlSubmitControl();
            LOBJ_Submit.VirtualPath = GetComusVirtualPath();
            LVAR_Parameter[0] = LSTR_StoreProcedure.ToString();
            LVAR_Parameter[1] = LSTR_QueryCondition.ToString();
            LOBJ_Return = LOBJ_Submit.SubmitEx<DataSet>(LSTR_ObjId, LVAR_Parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return LOBJ_Return;
    }


    //!!
    protected void Application_Error(Object sender, EventArgs e)
    {
        string Message = "";
        Exception ex = Server.GetLastError();
        Message = "發生錯誤的網頁:{0}錯誤訊息:{1}堆疊內容:{2}";
        Message = String.Format(Message, Request.Path + Environment.NewLine, ex.GetBaseException().Message + Environment.NewLine, Environment.NewLine + ex.StackTrace);
        //寫入文字檔,方法二
        System.IO.File.AppendAllText(Server.MapPath(string.Format("Log\\{0}.txt", DateTime.Now.Ticks.ToString())), Message);
    }
}