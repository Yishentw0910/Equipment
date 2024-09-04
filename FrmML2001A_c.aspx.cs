/********************************************************************************************************
* Database 	: ML																							
* 系    統 	: 租賃設備																					
* 程式名稱 	: ML2001A																					
* 程式功能  : 選擇退件原因																			
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

public partial class FrmML2001A_c : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判斷SESSION是否過期
        if (Session["UserID"] == null)
        {
            string LSTR_URL = System.Configuration.ConfigurationManager.AppSettings["LoginPP"];
            Response.Redirect(LSTR_URL);
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            FormDrpBind();
        }
    }

    private NameValueCollection REASON_Data
    {
        get
        {
            NameValueCollection REASON_Data = new NameValueCollection();
            REASON_Data.Add("drpREASON", "REASON");
            return REASON_Data;
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
            //退件原因drpREASON
            LSTR_StoreProcedure.Append("SP_ML0001_Q02" + GSTR_RowDelimitChar);
            LSTR_QueryCondition.Append("LE" + GSTR_ColDelimitChar + "88" + GSTR_ColDelimitChar + "T" + GSTR_ColDelimitChar + GSTR_RowDelimitChar);

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


    private void FormDrpBind()
    {
        try
        {
          ReturnObject<DataSet> LOBJ_ReturnObject = GetDrpData();
          if (LOBJ_ReturnObject.ReturnSuccess)
          {
            DataSet LDST_Data = LOBJ_ReturnObject.ReturnData;

            this.drpREASON.DataSource = LDST_Data.Tables[0].DefaultView;
            this.drpREASON.DataBind();

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


    private void GetCaseBind(DataTable LOBJ_Data)
    {
        if (LOBJ_Data.Rows.Count > 0)
        {
            Itg.Community.Util.SetValue(this.Page, LOBJ_Data, REASON_Data);
            this.drpREASON.SelectedValue = LOBJ_Data.Rows[0]["REASON"].ToString(); 
        }

    }


    #region 儲存資料
    protected void cmdSURE_Click(object sender, EventArgs e)
    {
        if (this.drpREASON.SelectedValue == "")
        {
            RegisterScript("alert('請選擇退件原因！');");
            return;
        }
        
        string CASEID = Request.QueryString["CASEID"];
        string CREDITDT = Request.QueryString["CREDITDT"];
        string USERID = Request.QueryString["USERID"];
        
        StringBuilder LSTR_Data = new StringBuilder();

        LSTR_Data.Append("SP_ML2001A_I03" + GSTR_ColDelimitChar);                                   //sp
        LSTR_Data.Append(CASEID + GSTR_TabDelimitChar);                                             //案件編號
        LSTR_Data.Append(this.drpREASON.SelectedValue + GSTR_TabDelimitChar);                       //退件原因
        LSTR_Data.Append(this.txtREASONDESC.Text.Replace("\r\n", "<br>") + GSTR_TabDelimitChar);    //退件內容
        LSTR_Data.Append(USERID);                                                                   //USERID
        LSTR_Data.Append(GSTR_ColDelimitChar);
        LSTR_Data.Append(GSTR_RowDelimitChar);

        try
        {
            ReturnObject<object> LOBJ_ReturnObject = UpdateCaseInfo(LSTR_Data.ToString());
            if (LOBJ_ReturnObject.ReturnSuccess)
            {
                RegisterScript("alert('退件原因存檔完成！');window.returnValue=true;window.close();");
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