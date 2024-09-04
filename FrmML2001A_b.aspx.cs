/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML2001A																					
* 程式功能  : 勾選婉拒原因資料存檔																			
* 程式作者 	: MAUREEN																			
* 完成時間 	: 
* 修改事項 	: 
********************************************************************************************************/

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
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection;
using System.IO;
using Microsoft.Office.Interop;

public partial class FrmML2001A_b : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtF999.Enabled = false;

        //判斷SESSION是否過期
        if (Session["UserID"] == null)
        {
            string LSTR_URL = System.Configuration.ConfigurationManager.AppSettings["LoginPP"];
            Response.Redirect(LSTR_URL);
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            PageDataBind();
        }
  
    }


        private void PageDataBind()
    {
        string CASEID = Request.QueryString["CASEID"];
        string CREDITDT = Request.QueryString["CREDITDT"];
        string USERID = Request.QueryString["USERID"];
            
        if (!string.IsNullOrEmpty(CASEID))
        {
            try
            {
                ReturnObject<DataSet> LOBJ_ReturnObject = GetReasonChecked(CASEID);
                if ((LOBJ_ReturnObject.ReturnSuccess) && (LOBJ_ReturnObject.ReturnData.Tables[0].Rows.Count>0))
                {
                    DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

                    //判斷checked
                    if (LDST_Data.Tables[0].Rows[0]["CASEID"].ToString() !="" && LDST_Data.Tables[0].Rows[0]["A_001"].ToString() != "N")
                    {
                        this.A001.Checked = true;
                    }
                    else
                    {
                        this.A001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_002"].ToString() != "N")
                    {
                        this.A002.Checked = true;
                    }
                    else
                    {
                        this.A002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_003"].ToString() != "N")
                    {
                        this.A003.Checked = true;
                    }
                    else
                    {
                        this.A003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_004"].ToString() != "N")
                    {
                        this.A004.Checked = true;
                    }
                    else
                    {
                        this.A004.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_005"].ToString() != "N")
                    {
                        this.A005.Checked = true;
                    }
                    else
                    {
                        this.A005.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_006"].ToString() != "N")
                    {
                        this.A006.Checked = true;
                    }
                    else
                    {
                        this.A006.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_007"].ToString() != "N")
                    {
                        this.A007.Checked = true;
                    }
                    else
                    {
                        this.A007.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_008"].ToString() != "N")
                    {
                        this.A008.Checked = true;
                    }
                    else
                    {
                        this.A008.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_009"].ToString() != "N")
                    {
                        this.A009.Checked = true;
                    }
                    else
                    {
                        this.A009.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["A_010"].ToString() != "N")
                    {
                        this.A010.Checked = true;
                    }
                    else
                    {
                        this.A010.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["B_001"].ToString() != "N")
                    {
                        this.B001.Checked = true;
                    }
                    else
                    {
                        this.B001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["B_002"].ToString() != "N")
                    {
                        this.B002.Checked = true;
                    }
                    else
                    {
                        this.B002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["B_003"].ToString() != "N")
                    {
                        this.B003.Checked = true;
                    }
                    else
                    {
                        this.B003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["B_004"].ToString() != "N")
                    {
                        this.B004.Checked = true;
                    }
                    else
                    {
                        this.B004.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_001"].ToString() != "N")
                    {
                        this.C001.Checked = true;
                    }
                    else
                    {
                        this.C001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_002"].ToString() != "N")
                    {
                        this.C002.Checked = true;
                    }
                    else
                    {
                        this.C002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_003"].ToString() != "N")
                    {
                        this.C003.Checked = true;
                    }
                    else
                    {
                        this.C003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_004"].ToString() != "N")
                    {
                        this.C004.Checked = true;
                    }
                    else
                    {
                        this.C004.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_005"].ToString() != "N")
                    {
                        this.C005.Checked = true;
                    }
                    else
                    {
                        this.C005.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_006"].ToString() != "N")
                    {
                        this.C006.Checked = true;
                    }
                    else
                    {
                        this.C006.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["C_007"].ToString() != "N")
                    {
                        this.C007.Checked = true;
                    }
                    else
                    {
                        this.C007.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_001"].ToString() != "N")
                    {
                        this.D001.Checked = true;
                    }
                    else
                    {
                        this.D001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_002"].ToString() != "N")
                    {
                        this.D002.Checked = true;
                    }
                    else
                    {
                        this.D002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_003"].ToString() != "N")
                    {
                        this.D003.Checked = true;
                    }
                    else
                    {
                        this.D003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_004"].ToString() != "N")
                    {
                        this.D004.Checked = true;
                    }
                    else
                    {
                        this.D004.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_005"].ToString() != "N")
                    {
                        this.D005.Checked = true;
                    }
                    else
                    {
                        this.D005.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_006"].ToString() != "N")
                    {
                        this.D006.Checked = true;
                    }
                    else
                    {
                        this.D006.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_007"].ToString() != "N")
                    {
                        this.D007.Checked = true;
                    }
                    else
                    {
                        this.D007.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_008"].ToString() != "N")
                    {
                        this.D008.Checked = true;
                    }
                    else
                    {
                        this.D008.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_009"].ToString() != "N")
                    {
                        this.D009.Checked = true;
                    }
                    else
                    {
                        this.D009.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["D_010"].ToString() != "N")
                    {
                        this.D010.Checked = true;
                    }
                    else
                    {
                        this.D010.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_001"].ToString() != "N")
                    {
                        this.E001.Checked = true;
                    }
                    else
                    {
                        this.E001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_002"].ToString() != "N")
                    {
                        this.E002.Checked = true;
                    }
                    else
                    {
                        this.E002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_003"].ToString() != "N")
                    {
                        this.E003.Checked = true;
                    }
                    else
                    {
                        this.E003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_004"].ToString() != "N")
                    {
                        this.E004.Checked = true;
                    }
                    else
                    {
                        this.E004.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_005"].ToString() != "N")
                    {
                        this.E005.Checked = true;
                    }
                    else
                    {
                        this.E005.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["E_006"].ToString() != "N")
                    {
                        this.E006.Checked = true;
                    }
                    else
                    {
                        this.E006.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["F_001"].ToString() != "N")
                    {
                        this.F001.Checked = true;
                    }
                    else
                    {
                        this.F001.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["F_002"].ToString() != "N")
                    {
                        this.F002.Checked = true;
                    }
                    else
                    {
                        this.F002.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["F_003"].ToString() != "N")
                    {
                        this.F003.Checked = true;
                    }
                    else
                    {
                        this.F003.Checked = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["F_999"].ToString() != "N")
                    {
                        this.F999.Checked = true;
                        this.txtF999.Enabled = true;
                    }
                    else
                    {
                        this.F999.Checked = false;
                        this.txtF999.Enabled = false;
                    }

                    if (LDST_Data.Tables[0].Rows[0]["F_999_txt"].ToString() != "")
                    {
                        this.txtF999.Text = LDST_Data.Tables[0].Rows[0]["F_999_txt"].ToString().Trim();
                    }
                    else
                    {
                        this.txtF999.Text = "";
                    }
               
                }
            }
            catch (Exception ex)
            {

                Alert(ex.Message);
            }
        }
    }


    private ReturnObject<DataSet> GetReasonChecked(string LSTR_CASEID)
    {
        Comus.HtmlSubmitControl LOBJ_Submit;
        string LSTR_ObjId;
        StringBuilder LSTR_StoreProcedure = new StringBuilder();
        StringBuilder LSTR_QueryCondition = new StringBuilder(); ;
        ReturnObject<DataSet> LOBJ_Return;
        string[] LVAR_Parameter = new string[2];
        string CASEID = Request.QueryString["CASEID"];
        try
        {
            LSTR_ObjId = "ITG.CommDBService.MutiQueryByStoreProcedure";
            //客戶信息
            LSTR_StoreProcedure.Append("SP_ML2001A_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append(CASEID + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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

        // 其他原因
    protected void F999_CheckedChanged(object sender, EventArgs e)
    {
        if (F999.Checked)
        {
            txtF999.Enabled = true;
        }
        else
        {
            txtF999.Text = "";
            txtF999.Enabled = false;
            F999.Checked = false;
        }
    }

    protected void cmdBACK_Click(object sender, EventArgs e)
    {
        string strSCRIPT = "";
        strSCRIPT += "window.opener=null;";
        strSCRIPT += "window.open('','_self');";
        strSCRIPT += "window.close();";

        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "closewindow", strSCRIPT, true);
        return;

    }

    #region 儲存資料
    protected void cmdSURE_Click(object sender, EventArgs e)
    {
        if (this.F999.Checked && this.txtF999.Text == "")
        {
            RegisterScript("alert('請輸入其他原因！');");
            this.txtF999.Enabled = true;
            this.txtF999.Focus();
            return;
        }

        string PROCD = "";
        string CASEID = Request.QueryString["CASEID"];
        string CREDITDT = Request.QueryString["CREDITDT"];
        string USERID = Request.QueryString["USERID"];
        string A_001 = "N";
        string A_002 = "N";
        string A_003 = "N";
        string A_004 = "N";
        string A_005 = "N";
        string A_006 = "N";
        string A_007 = "N";
        string A_008 = "N";
        string A_009 = "N";
        string A_010 = "N";
        string B_001 = "N";
        string B_002 = "N";
        string B_003 = "N";
        string B_004 = "N";
        string C_001 = "N";
        string C_002 = "N";
        string C_003 = "N";
        string C_004 = "N";
        string C_005 = "N";
        string C_006 = "N";
        string C_007 = "N";
        string D_001 = "N";
        string D_002 = "N";
        string D_003 = "N";
        string D_004 = "N";
        string D_005 = "N";
        string D_006 = "N";
        string D_007 = "N";
        string D_008 = "N";
        string D_009 = "N";
        string D_010 = "N";
        string E_001 = "N";
        string E_002 = "N";
        string E_003 = "N";
        string E_004 = "N";
        string E_005 = "N";
        string E_006 = "N";
        string F_001 = "N";
        string F_002 = "N";
        string F_003 = "N";
        string F_999 = "N";

        if (this.A001.Checked)
        {
            A_001 = "Y";
        }
        if (this.A002.Checked)
        {
            A_002 = "Y";
        }
        if (this.A003.Checked)
        {
            A_003 = "Y";
        }
        if (this.A004.Checked)
        {
            A_004 = "Y";
        }
        if (this.A005.Checked)
        {
            A_005 = "Y";
        }
        if (this.A006.Checked)
        {
            A_006 = "Y";
        }
        if (this.A007.Checked)
        {
            A_007 = "Y";
        }
        if (this.A008.Checked)
        {
            A_008 = "Y";
        }
        if (this.A008.Checked)
        {
            A_009 = "Y";
        }
        if (this.A008.Checked)
        {
            A_010 = "Y";
        }
        if (this.B001.Checked)
        {
            B_001 = "Y";
        }
        if (this.B002.Checked)
        {
            B_002 = "Y";
        }
        if (this.B003.Checked)
        {
            B_003 = "Y";
        }
        if (this.B004.Checked)
        {
            B_004 = "Y";
        }
        if (this.C001.Checked)
        {
            C_001 = "Y";
        }
        if (this.C002.Checked)
        {
            C_002 = "Y";
        }
        if (this.C003.Checked)
        {
            C_003 = "Y";
        }
        if (this.C003.Checked)
        {
            C_004 = "Y";
        }
        if (this.C003.Checked)
        {
            C_005 = "Y";
        }
        if (this.C003.Checked)
        {
            C_006 = "Y";
        }
        if (this.C003.Checked)
        {
            C_007 = "Y";
        }
        if (this.D001.Checked)
        {
            D_001 = "Y";
        }
        if (this.D002.Checked)
        {
            D_002 = "Y";
        }
        if (this.D003.Checked)
        {
            D_003 = "Y";
        }
        if (this.D004.Checked)
        {
            D_004 = "Y";
        }
        if (this.D005.Checked)
        {
            D_005 = "Y";
        }
        if (this.D006.Checked)
        {
            D_006 = "Y";
        }
        if (this.D007.Checked)
        {
            D_007 = "Y";
        }
        if (this.D008.Checked)
        {
            D_008 = "Y";
        }
        if (this.D009.Checked)
        {
            D_009 = "Y";
        }
        if (this.D010.Checked)
        {
            D_010 = "Y";
        }
        if (this.E001.Checked)
        {
            E_001 = "Y";
        }
        if (this.E002.Checked)
        {
            E_002 = "Y";
        }
        if (this.E003.Checked)
        {
            E_003 = "Y";
        }
        if (this.E004.Checked)
        {
            E_004 = "Y";
        }
        if (this.E005.Checked)
        {
            E_005 = "Y";
        }
        if (this.E006.Checked)
        {
            E_006 = "Y";
        }
        if (this.F001.Checked)
        {
            F_001 = "Y";
        }
        if (this.F002.Checked)
        {
            F_002 = "Y";
        }
        if (this.F003.Checked)
        {
            F_003 = "Y";
        }
        if (this.F999.Checked)
        {
            F_999 = "Y";
        }


        StringBuilder LSTR_Data = new StringBuilder();

        LSTR_Data.Append("SP_ML2001A_I02" + GSTR_ColDelimitChar);               //sp
        LSTR_Data.Append(PROCD + GSTR_TabDelimitChar);				 			//處理區分(A:新增 ; U:修改)
        LSTR_Data.Append(CASEID + GSTR_TabDelimitChar);							//案件編號
        LSTR_Data.Append(USERID + GSTR_TabDelimitChar);							//USERID
        LSTR_Data.Append(A_001 + GSTR_TabDelimitChar);				 			//借款人-營運衰退
        LSTR_Data.Append(A_002 + GSTR_TabDelimitChar);				 			//借款人-虧損嚴重
        LSTR_Data.Append(A_003 + GSTR_TabDelimitChar);				 			//借款人-成立期短，營收偏低
        LSTR_Data.Append(A_004 + GSTR_TabDelimitChar);				 			//借款人-營運週期過長
        LSTR_Data.Append(A_005 + GSTR_TabDelimitChar);				 			//借款人-過度擴充
        LSTR_Data.Append(A_006 + GSTR_TabDelimitChar);				 			//借款人-誠信問題
        LSTR_Data.Append(A_007 + GSTR_TabDelimitChar);				 			//借款人-重複融資
        LSTR_Data.Append(A_008 + GSTR_TabDelimitChar);				 			//借款人-申戶票/債信異常
        LSTR_Data.Append(A_009 + GSTR_TabDelimitChar);				 			//借款人-申戶不動產有民間設定
        LSTR_Data.Append(A_010 + GSTR_TabDelimitChar);				 			//借款人-申戶不動產有限制登記
        LSTR_Data.Append(B_001 + GSTR_TabDelimitChar);				 			//借款目的-資金流向不明
        LSTR_Data.Append(B_002 + GSTR_TabDelimitChar);				 			//借款目的-資金流向大陸不易評估
        LSTR_Data.Append(B_003 + GSTR_TabDelimitChar);				 			//借款目的-短期租賃同業申辦頻繁
        LSTR_Data.Append(B_004 + GSTR_TabDelimitChar);				 			//借款目的-同業婉拒件
        LSTR_Data.Append(C_001 + GSTR_TabDelimitChar);				 			//還款來源-還款來源不明
        LSTR_Data.Append(C_002 + GSTR_TabDelimitChar);				 			//還款來源-還款能力不足
        LSTR_Data.Append(C_003 + GSTR_TabDelimitChar);				 			//還款來源-分期、租金款佔營收比例高
        LSTR_Data.Append(C_004 + GSTR_TabDelimitChar);				 			//還款來源-同業客票擔保未兌現
        LSTR_Data.Append(C_005 + GSTR_TabDelimitChar);				 			//還款來源-原融(財務欠佳)
        LSTR_Data.Append(C_006 + GSTR_TabDelimitChar);				 			//還款來源-申戶房貸遲繳
        LSTR_Data.Append(C_007 + GSTR_TabDelimitChar);				 			//還款來源-申戶有民間資金借貸
        LSTR_Data.Append(D_001 + GSTR_TabDelimitChar);				 			//債權保障-個人背景複雜、債信瑕疵
        LSTR_Data.Append(D_002 + GSTR_TabDelimitChar);				 			//債權保障-保人卡循嚴重
        LSTR_Data.Append(D_003 + GSTR_TabDelimitChar);				 			//債權保障-保人有現金卡或預借現金
        LSTR_Data.Append(D_004 + GSTR_TabDelimitChar);				 			//債權保障-保人原融(財務欠佳)
        LSTR_Data.Append(D_005 + GSTR_TabDelimitChar);				 			//債權保障-保人信用卡/房貸遲繳
        LSTR_Data.Append(D_006 + GSTR_TabDelimitChar);				 			//債權保障-保人無資產
        LSTR_Data.Append(D_007 + GSTR_TabDelimitChar);				 			//債權保障-保人票/債信異常
        LSTR_Data.Append(D_008 + GSTR_TabDelimitChar);				 			//債權保障-保人不動產有民間設定
        LSTR_Data.Append(D_009 + GSTR_TabDelimitChar);				 			//債權保障-保人不動產有限制登記
        LSTR_Data.Append(D_010 + GSTR_TabDelimitChar);				 			//債權保障-本公司授信異常戶
        LSTR_Data.Append(E_001 + GSTR_TabDelimitChar);				 			//授信展望-業務來源過於集中
        LSTR_Data.Append(E_002 + GSTR_TabDelimitChar);				 			//授信展望-屬夕陽產業
        LSTR_Data.Append(E_003 + GSTR_TabDelimitChar);				 			//授信展望-行業景氣衰退
        LSTR_Data.Append(E_004 + GSTR_TabDelimitChar);				 			//授信展望-市場萎縮
        LSTR_Data.Append(E_005 + GSTR_TabDelimitChar);				 			//授信展望-市場競爭激烈
        LSTR_Data.Append(E_006 + GSTR_TabDelimitChar);				 			//授信展望-負責人資歷有限
        LSTR_Data.Append(F_001 + GSTR_TabDelimitChar);				 			//其他-業務自行撤件(客戶狀況不佳)
        LSTR_Data.Append(F_002 + GSTR_TabDelimitChar);				 			//其他-業務自行撤件(客戶資料不齊)
        LSTR_Data.Append(F_003 + GSTR_TabDelimitChar);				 			//其他-業務自行撤件(操作方式錯誤)
        LSTR_Data.Append(F_999 + GSTR_TabDelimitChar);				 			//其他-其他
        LSTR_Data.Append(this.txtF999.Text.Trim());								//其他-其他：(自行輸入原因)
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                RegisterScript("alert('婉拒原因存檔完成！');window.close();");
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
    #endregion

    private ReturnObject<object> UpdateCaseInfo(string LSTR_Data)
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

}