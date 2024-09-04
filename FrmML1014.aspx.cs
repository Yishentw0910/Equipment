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
using System.Reflection;

public partial class FrmML1014 : PageBase
{
    public string cRepotr = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_POST_URL"];
    public string cUrl = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_URL"];
    public string cPath = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PATH"];
    public string cUserName = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_USER_NAME"];
    public string cPass = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_PASS"];
    public string cCompany = System.Configuration.ConfigurationManager.AppSettings["SMART_QRY_COMPANY"];
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUsrAndFuncInfo();
        //===== for 測試Menu =====
        if (GSTR_PROGNM == "") GSTR_PROGNM = "產出基數表";
        if (GSTR_A_PRGID == "") GSTR_A_PRGID = "ML1014";
        if (GSTR_U_PRGID == "") GSTR_U_PRGID = "ML1014";
        //========================             
        if (Session["UserID"] == null || Session["UserID"].ToString().Trim() == "")
        {
            string LSTR_URL = System.Configuration.ConfigurationManager.AppSettings["LoginPP"];
            Response.Write("<script language=javascript>alert('閒置過久，請重新登入！'); window.location.replace('" + LSTR_URL + "');</script>");
            Response.End();
        }
        if (!IsPostBack)
        {
            FormDrpBind();
        }
    }
    private void FormDrpBind()
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                this.drpMAINTYPE.DataSource = LDST_Data.Tables[0].DefaultView;
                this.drpMAINTYPE.DataBind();
                this.drpTARGETTYPE.DataSource = LDST_Data.Tables[1].DefaultView;
                this.drpTARGETTYPE.DataBind();

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
            //承作形態
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

            //標的物種類
            LSTR_StoreProcedure.Append("SP_ML0001_Q06" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "14" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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
    protected void rdoINSURANCE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoINSURANCE.SelectedValue == "1") //有保費
        {
            TARGETTYPE.Attributes.Add("style", "display:''");
            this.txtINSURANCE.Attributes.Add("style", "display:''");
        }
        else //無保費
        {
            //string redirectScript = "document.getElementById('TARGETTYPE').style.display = 'none';";
            //ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", redirectScript, true);
            TARGETTYPE.Attributes.Add("style", "display:none");
            this.txtINSURANCE.Attributes.Add("style", "display:none");
        }

        string strTARGETTYPE = drpTARGETTYPE.SelectedItem.Text.ToString().Trim();
        if (strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具")
        {
            txtINSURANCE.Text = "680";
            txtINSURANCE.Enabled = false;
        }
        else if (drpMAINTYPE.SelectedValue != "03" && drpSUBTYPE.SelectedValue == "01")
        {
            txtINSURANCE.Text = "400";
            txtINSURANCE.Enabled = false;
        }
        else
        {
            txtINSURANCE.Text = "0";
            txtINSURANCE.Enabled = true;
        }
    }

    protected void drpMAINTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        string LSTR_MAINTYPEID = this.drpMAINTYPE.SelectedValue;
        drpSUBTYPEaEXPIREPROCBindbyID(LSTR_MAINTYPEID);
        if (drpMAINTYPE.SelectedValue == "03") //分期
        {
            //drpSUBTYPE.Visible = false;
            txtCOMMISSION.Enabled = false;
        }
        else //分期以外
        {
            drpSUBTYPE.Visible = true;
            txtCOMMISSION.Enabled = true;
        }
        drpSUBTYPE_SelectedIndexChanged(null, null);
    }
    protected void drpSUBTYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strTARGETTYPE = drpTARGETTYPE.SelectedItem.Text.ToString().Trim();
        if (strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具")
        {
            txtINSURANCE.Text = "680";
            txtINSURANCE.Enabled = false;
        }
        else if (drpMAINTYPE.SelectedValue != "03" && drpSUBTYPE.SelectedValue == "01")
        {
            txtINSURANCE.Text = "400";
            txtINSURANCE.Enabled = false;
        }
        else
        {
            txtINSURANCE.Text = "0";
            txtINSURANCE.Enabled = true;
        }
    }
    private void drpSUBTYPEaEXPIREPROCBindbyID(string LSTR_MAINTYPEID)
    {
        try
        {
            ReturnObject<DataSet> LOBJ_ReturnObject = GetSUBTYPEDataById(LSTR_MAINTYPEID);
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;
                DataView LDVW = LDST_Data.Tables[0].DefaultView;
                this.drpSUBTYPE.DataSource = LDVW;
                this.drpSUBTYPE.DataBind();

                //20230321 營資租時預設值改為非事務機
                if (this.drpMAINTYPE.SelectedValue != "03")
                {
                    this.drpSUBTYPE.SelectedValue = "02";
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
    private ReturnObject<DataSet> GetSUBTYPEDataById(string LSTR_MAINTYPEID)
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
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "05" + GSTR_ColDelimitChar + LSTR_MAINTYPEID + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);
            string LSTR_MAINTYPEName = this.drpMAINTYPE.SelectedItem.Text;
            if (LSTR_MAINTYPEName == "營租")
            {
                LSTR_MAINTYPEName = "01";
            }
            else
            {
                LSTR_MAINTYPEName = "02";
            }
            LSTR_StoreProcedure.Append("SP_ML0001_Q01" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "12" + GSTR_ColDelimitChar + LSTR_MAINTYPEName + GSTR_ColDelimitChar + "F" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Decimal IRRStart;
        Decimal IRR1 = Convert.ToDecimal(this.IRR1.SelectedValue);
        Decimal IRR2 = Convert.ToDecimal(this.IRR2.SelectedValue);
        long IRRGap;

        //判斷左右IRR哪個為起始值
        if (IRR1 > IRR2)
        {
            IRRStart = IRR2;
            IRRGap = Decimal.ToInt64(Math.Abs((IRR2 - IRR1) / 0.5M)); //IRR差
        }
        else
        {
            IRRStart = IRR1;
            IRRGap = Decimal.ToInt64(Math.Abs((IRR1 - IRR2) / 0.5M)); //IRR差
        }
        Decimal[] IRRCount = new Decimal[IRRGap + 1];   //IRR數量
        string[] RAMT = new string[IRRGap + 1];   //對應IRR數量的期付款數量

        for (int i = 0; i <= IRRGap; i++)
        {
            IRRCount[i] = IRRStart + (i * 0.5M); // 計算不同的IRR值

            //用IRR反推期付款
            try
            {
                double irrate = Convert.ToDouble(IRRCount[i]);
                double RAMT_S = 0;
                double RAMT_E = 0;
                double IRR_S = 0;
                double IRR_E = 0;
                double RAMT_L = 0;

                for (var j = 1; j <= 9999; j++)
                {
                    double IRR = IRR_Cal(Convert.ToDouble(j * 10000));
                    IRR_S = IRR_E;
                    RAMT_S = RAMT_E;
                    RAMT_E = j * 10000 + RAMT_L;
                    if (!double.IsNaN(IRR))
                    {
                        IRR_E = IRR;
                        if (IRR_S <= irrate && irrate <= IRR_E)
                            break;
                    }
                }
                if (IRR_E == irrate)
                {
                    RAMT_S = RAMT_E;
                }

                RAMT_L = RAMT_S;
                RAMT_E = RAMT_S;
                IRR_S = 0;
                IRR_E = 0;
                for (var j = 1; j <= 9999; j++)
                {
                    double IRR = IRR_Cal(Convert.ToDouble(j * 1000 + RAMT_L));
                    IRR_S = IRR_E;
                    RAMT_S = RAMT_E;
                    RAMT_E = j * 1000 + RAMT_L;
                    if (!double.IsNaN(IRR))
                    {
                        IRR_E = IRR;
                        if (IRR_S <= irrate && irrate <= IRR_E)
                            break;
                    }
                }
                if (IRR_E == irrate)
                {
                    RAMT_S = RAMT_E;
                }

                RAMT_L = RAMT_S;
                RAMT_E = RAMT_S;
                IRR_S = 0;
                IRR_E = 0;
                for (var j = 1; j <= 9999; j++)
                {
                    double IRR = IRR_Cal(Convert.ToDouble(j * 100 + RAMT_L));
                    IRR_S = IRR_E;
                    RAMT_S = RAMT_E;
                    RAMT_E = j * 100 + RAMT_L;
                    if (!double.IsNaN(IRR))
                    {
                        IRR_E = IRR;
                        if (IRR_S <= irrate && irrate <= IRR_E)
                            break;
                    }
                }
                if (IRR_E == irrate)
                {
                    RAMT_S = RAMT_E;
                }

                RAMT_L = RAMT_S;
                RAMT_E = RAMT_S;
                IRR_S = 0;
                IRR_E = 0;
                for (var j = 1; j <= 9999; j++)
                {
                    double IRR = IRR_Cal(Convert.ToDouble(j * 10 + RAMT_L));
                    IRR_S = IRR_E;
                    RAMT_S = RAMT_E;
                    RAMT_E = j * 10 + RAMT_L;
                    if (!double.IsNaN(IRR))
                    {
                        IRR_E = IRR;
                        if (IRR_S <= irrate && irrate <= IRR_E)
                            break;
                    }
                }
                if (IRR_E == irrate)
                {
                    RAMT_S = RAMT_E;
                }
                RAMT_L = RAMT_S;
                RAMT_E = RAMT_S;
                IRR_S = 0;
                IRR_E = 0;
                for (var j = 1; j <= 9999; j++)
                {
                    double IRR = IRR_Cal(Convert.ToDouble(j + RAMT_L));
                    IRR_S = IRR_E;
                    RAMT_S = RAMT_E;
                    RAMT_E = j + RAMT_L;
                    if (!double.IsNaN(IRR))
                    {
                        IRR_E = IRR;
                        if (IRR_S <= irrate && irrate <= IRR_E)
                            break;
                    }
                }
                if (IRR_E == irrate)
                {
                    RAMT_S = RAMT_E;
                }
                RAMT_S *= 1.05;
                //Math.Ceiling(RAMT_S);
                RAMT[i] = Math.Ceiling(RAMT_S).ToString();
                //Alert(RAMT_S.ToString());

            }
            catch (Exception ex)
            {
                Alert("試算異常！請檢查金額項目！！");
                return;
            }
        }
        string arrayString = string.Join(",", RAMT);
        hidarrayString.Value = arrayString;
        string script = "<script type='text/javascript'>cmdPrintA_onClick();</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
        //Alert(arrayString);
        //Alert(hidarrayString.Value.ToString() + " " + drpSUBTYPE.SelectedValue.ToString());
        //Alert(IRRCount[20].ToString() + " ");
        //Alert(IRRCount[2].ToString() + " " + IRRCount[3].ToString());

        //Alert(IRRCount[0].ToString() + " " + IRRCount[1].ToString() + " " + IRRCount[2].ToString() + " " + IRRCount[3].ToString() + " " + IRRCount[4].ToString() + " " + IRRCount[5].ToString()
        //    + " " + IRRCount[6].ToString() + " " + IRRCount[7].ToString() + " " + IRRCount[8].ToString() + " " + IRRCount[9].ToString() + " " + IRRCount[10].ToString()
        //    + " " + IRRCount[11].ToString() + " " + IRRCount[12].ToString() + " " + IRRCount[13].ToString() + " " + IRRCount[14].ToString() + " " + IRRCount[15].ToString()
        //    + " " + IRRCount[16].ToString() + " " + IRRCount[17].ToString() + " " + IRRCount[18].ToString() + " " + IRRCount[19].ToString() + " " + IRRCount[20].ToString());
    }

    protected double IRR_Cal(double RAMT)
    {
        try
        {
            string INSURANCE; //保險費
            if (rdoINSURANCE.SelectedValue == "1") //若有保費
            {
                //標的物種類為營建機具 > 標的物價格 * 0.0068(營建機具綜合保險)
                //承作型態為營資租、事務機 > 標的物價格 * 0.0040(事務機商動險)
                //其他則為(商業火災保險)無保費
                string strTARGETTYPE = drpTARGETTYPE.SelectedItem.Text.ToString().Trim();
                if (strTARGETTYPE.Length >= 4 && strTARGETTYPE.Substring(0, 4).Trim() == "營建機具")
                {
                    INSURANCE = "680";
                    txtINSURANCE.Text = "680";
                    txtINSURANCE.Enabled = false;
                }
                else if (drpMAINTYPE.SelectedValue != "03" && drpSUBTYPE.SelectedValue == "01")
                {
                    INSURANCE = "400";
                }
                else
                {
                    INSURANCE = txtINSURANCE.Text;
                }
            }
            else //無保費=0
            {
                INSURANCE = "0";
            }
            //標的物金額(未稅)
            Decimal LDCE_TransCost = Math.Round(Convert.ToDecimal(Convert.ToDouble(100000) / 1.05), 0);
            //殘值(未稅)
            Decimal LDCE_Residuals = Math.Round(Convert.ToDecimal(Convert.ToDouble(txtRESIDUALS.Text) / 1.05), 0);
            //頭期款(未稅)
            Decimal LDCE_FirstPay = Math.Round(Convert.ToDecimal(Convert.ToDouble(0) / 1.05), 0);
            //手續費(未稅)
            Decimal LDCE_Fee = Math.Round(Convert.ToDecimal(Convert.ToDouble(0) / 1.05), 0);
            //幾月一付
            int LINT_PAYMONTH = Convert.ToInt32("0" + txtPAYMONTH.Text);
            //期數比例
            double LINT_MONTH = 0;
            //期別
            int LINT_ENDPAY1 = Convert.ToInt32("0" + txtCONTRACTMONTH.Text);
            int LINT_ENDPAY2 = Convert.ToInt32("0" + txtCONTRACTMONTH.Text);
            int LINT_ENDPAY3 = Convert.ToInt32("0" + txtCONTRACTMONTH.Text);
            int LINT_ENDPAY4 = Convert.ToInt32("0" + txtCONTRACTMONTH.Text);
            //期數
            int LINT_CONTRACTMONTH = Convert.ToInt32(this.txtCONTRACTMONTH.Text);
            double[] LDBL_VALUE = new double[LINT_CONTRACTMONTH + 1];
            //撥差天數 = 付款差異天數 – 付供應商天數
            int LINT_PayDiff = Convert.ToInt32(txtPATDAYS.Text) - Convert.ToInt32(0);
            //2010/12/16 修改撥差金額計算公式，以未稅金額計算撥差
            //撥差金額計算公式  (標的物金額(未稅) – 頭期款(未稅) – 保證金 ) * 撥差天數 * 資金成本 / 365天
            Decimal LDEC_PayDiffAmount = Math.Round((LDCE_TransCost - LDCE_FirstPay - Convert.ToDecimal(0)) * LINT_PayDiff * Convert.ToDecimal(4) / 100 / 365, 0);
            //20231130專案扣款金額(扣款金額÷扣款總年數)乘以(期數除12)
            Decimal ProjectDISCAMT = Convert.ToDecimal(0) * Convert.ToDecimal(LINT_CONTRACTMONTH / 12.0);
            if (ProjectDISCAMT >= Convert.ToDecimal(0)) ProjectDISCAMT = Convert.ToDecimal(0);//20231130金額不可超過專案扣款金額
            if (ProjectDISCAMT < 0 && ProjectDISCAMT <= Convert.ToDecimal(0)) ProjectDISCAMT = Convert.ToDecimal(0);//20231130負成本金額不可超過專案扣款金額
                                                                                                                    //計算第0期的現金流量
                                                                                                                    //租購保證金+頭期款(未稅)+履約保證金+手續費收入-標的物金額(未稅)-保險費-作業費用-撥差金額-佣金
            LDBL_VALUE[0] = Convert.ToDouble(Convert.ToDecimal(0) //租購保證金txtPURCHASEMARGIN
                                             + LDCE_FirstPay //頭期款(未稅)
                                             + Convert.ToDecimal(0) //履約保證金txtPERBOND
                                             + Convert.ToDecimal(LDCE_Fee) //手續費收入
                                             - LDCE_TransCost //標的物金額(未稅)txtTRANSCOST
                                             - Convert.ToDecimal(INSURANCE) //保險費txtINSURANCE
                                                                            //Modify 20120529 By SS Gordon. Reason: 作業費用(有發票)/1.05
                                                                            //- Convert.ToDecimal(txtOTHERFEES.Text) //作業費用txtOTHERFEES
                                             - Math.Round(Convert.ToDecimal(Convert.ToDouble(txtOTHERFEES.Text) / 1.05), 0)
                                             //Modify 20120529 By SS Gordon. Reason: 加入「作業費用(無發票)」欄位
                                             - Convert.ToDecimal(txtOTHERFEESNOTAX.Text) //作業費用(無發票)txtOTHERFEESNOTAX
                                             - LDEC_PayDiffAmount                    //撥差金額
                                             - Convert.ToDecimal(txtCOMMISSION.Text)//佣金txtCOMMISSION
                                             - ProjectDISCAMT);//20231130 ADD專案扣款金額
                                                               //20231130將幾月一付加入IRR計算
                                                               //如果是期初收
            if (drpPAYTIMET.SelectedValue == "01")
            {
                LDBL_VALUE[0] += Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
            }
            for (int i = LINT_PAYMONTH; i <= Convert.ToInt32(LINT_CONTRACTMONTH); i += LINT_PAYMONTH)
            {
                //期末付的期數為幾月一付-1
                int j = i - 1;
                //最後一期
                if (i == Convert.ToInt32(LINT_CONTRACTMONTH))//20231130期數除以幾月一付來取得付款次數
                {
                    //最後一期付款
                    Decimal LDCE_PRINCIPAL = 0;
                    if (LINT_ENDPAY1 != 0)
                    {
                        LDCE_PRINCIPAL = Convert.ToDecimal(RAMT) * LINT_PAYMONTH;
                    }
                    if (LINT_ENDPAY2 != 0)
                    {
                        LDCE_PRINCIPAL = Convert.ToDecimal(RAMT) * LINT_PAYMONTH;
                    }
                    if (LINT_ENDPAY3 != 0)
                    {
                        LDCE_PRINCIPAL = Convert.ToDecimal(RAMT) * LINT_PAYMONTH;
                    }
                    if (LINT_ENDPAY4 != 0)
                    {
                        LDCE_PRINCIPAL = Convert.ToDecimal(RAMT) * LINT_PAYMONTH;
                    }
                    if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH == 01)
                    {
                        LDBL_VALUE[i] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                    }
                    else if (drpPAYTIMET.SelectedValue == "02" && LINT_PAYMONTH != 01)
                    {
                        LDBL_VALUE[j] = Convert.ToDouble(LDCE_PRINCIPAL); //月付款
                    }
                    LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                     + LDCE_Residuals  //殘值
                                                     - Convert.ToDecimal(0)  //租購保證金txtPURCHASEMARGIN
                                                     - Convert.ToDecimal(0));//履約保證金txtPURCHASEMARGIN
                }
                else
                {
                    //Modify 20120829 By SS Gordon. Reason: 修正多段式租金時，期初付款所產生的現金流量.
                    //期初收
                    if (drpPAYTIMET.SelectedValue == "01")
                    {
                        if (i >= 1 && i <= LINT_ENDPAY1 - 1)
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY2 - 1))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY3 - 1))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                        else if ((i > LINT_ENDPAY1 - 1 && i <= LINT_ENDPAY4 - 1))
                        {
                            LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                        }
                    }
                    else
                    {
                        //20231130幾月一付若為1跟著i走
                        if (LINT_PAYMONTH == 01)
                        {
                            if (i >= 1 && i <= LINT_ENDPAY1)
                            {
                                LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                            {
                                LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                            {
                                LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                            {
                                LDBL_VALUE[i] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                        }
                        else
                        {
                            //20231130幾月一付不為1時要等於幾月一付-1
                            if (i >= 1 && i <= LINT_ENDPAY1)
                            {
                                LDBL_VALUE[j] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY2))
                            {
                                LDBL_VALUE[j] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY3))
                            {
                                LDBL_VALUE[j] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                            else if ((i > LINT_ENDPAY1 && i <= LINT_ENDPAY4))
                            {
                                LDBL_VALUE[j] = Convert.ToDouble(RAMT) * LINT_PAYMONTH; //月付款//20231130月付款改月付款乘以幾月一付
                            }
                        }
                    }
                }

                //Modify 20120613 By SS Gordon. Reason: 更新現金流量表以符合現行IRR試算公式
                //承作型態二為事務機時，每年按比例調整，為非事務機時，不需調整
                if ((drpMAINTYPE.SelectedValue == "01" || drpMAINTYPE.SelectedValue == "02") && drpSUBTYPE.SelectedValue == "01")   //事務機
                {
                    if ((i % 12) == 0)//計算保險費=保險費*(第一年=0.8 第二年=0.6 第三年=0.4 第四年=0.2 第五年=0)
                    {
                        //計算期數比例 不滿一年按比例計算保險費
                        LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                        if (LINT_MONTH > 1)
                        {
                            LINT_MONTH = 1;
                        }
                        //20121112 Modify By Maureen Reason:針對設備事務機案件，修改系統保險費成本計算邏輯
                        double INSU = INSU_Cal((i / 12));
                        LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                         - Math.Round((Convert.ToDecimal(INSURANCE) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal(INSU)), 0, MidpointRounding.AwayFromZero)
                                                         //- (Convert.ToDecimal(txtINSURANCE.Text) * Convert.ToDecimal(LINT_MONTH) * Convert.ToDecimal((1 - (0.2 * (i / 12)))))
                                                         );
                    }
                }
                else
                {
                    if ((i % 12) == 0)//計算保險費=保險費*(第一年=1.0 第二年1.0 第三年=1.0 第四年=1.0 第五年=1.0)
                    {
                        //計算期數比例 不滿一年按比例計算保險費
                        LINT_MONTH = Convert.ToDouble(Convert.ToDouble(LINT_CONTRACTMONTH - i) / 12);
                        if (LINT_MONTH > 1)
                        {
                            LINT_MONTH = 1;
                        }
                        LDBL_VALUE[i] = Convert.ToDouble(Convert.ToDecimal(LDBL_VALUE[i])
                                                         - (Convert.ToDecimal(INSURANCE) * Convert.ToDecimal(LINT_MONTH))
                                                         );
                    }
                }
            }
            double LDBL_IRR = Microsoft.VisualBasic.Financial.IRR(ref LDBL_VALUE, 0.001) * 1200;
            //Alert(LDBL_IRR.ToString());
            return LDBL_IRR;
        }
        catch (Exception ex)
        {
            Alert("試算錯誤，請檢查金額項目！");
            return 0.000;
        }
    }
    protected double INSU_Cal(int year)
    {
        double INSU = 1;
        if (year > 0)
        {
            for (int i = 0; i < year; i++)
            {
                INSU = INSU * (5.0 / 6.0);
            }
        }
        return INSU;
    }

}
