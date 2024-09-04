using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class FrmML4004A_1 : Itg.Community.PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Vincent-20100817-Add for 畫面控制項屬性設定
        PageInitProcess();

        if (!IsPostBack)
        {
            string strAMOUNT = Request.QueryString["AMOUNT"];
            string strTAX = Request.QueryString["TAX"];
            string strINVDESCTYPE = Request.QueryString["INVDESCTYPE"];

            this.hdnMAINTYPE.Value = Request.QueryString["MAINTYPE"];
            this.hdnISSUE.Value = Request.QueryString["ISSUE"];
            string strINVNO = Request.QueryString["INVNO"];
            this.txtAMOUNT.Text = System.Convert.ToDecimal(strAMOUNT).ToString("#,##0");
            this.spanAMOUNT.Text = this.txtAMOUNT.Text;
            this.txtTAX.Text = System.Convert.ToDecimal(strTAX).ToString("#,##0");
            this.spanTAX.Text = this.txtTAX.Text;
            if (strINVDESCTYPE == "2")
            {
                this.txtINVDESC.Text = "押金設算息";
                this.txtINVDESC.Attributes.Add("style", "display:none;");
                this.spanINVDESC.Text = "押金設算息";
                this.txtINVDESC.Enabled = false;
            }
            else
            {
                this.txtINVDESC.Text = Request.QueryString["INVDESC"];
                this.spanINVDESC.Text = Request.QueryString["INVDESC"];
                if (this.hdnMAINTYPE.Value == "01")
                {
                    this.txtINVDESC.Text = "租金收入";
                    this.spanINVDESC.Text = "租金收入";
                    this.txtINVDESC.Enabled = false;
                    this.txtINVDESC.Attributes.Add("style", "display:none;");
                }
                else if (this.hdnMAINTYPE.Value == "03")
                {
                    this.spanINVDESC.Attributes.Add("style", "display:none;");
                }
                else
                {
                    this.spanINVDESC.Attributes.Add("style", "display:none;");
                }
                if (strINVNO.Trim() != "")
                {
                    this.txtINVDESC.Attributes.Add("style", "display:none;");
                    this.spanINVDESC.Attributes.Add("style", "display:;");
                }
            }
            string strISSUE = Request.QueryString["ISSUE"];

            HtmlTableRowCollection tbrInvDescInfo = this.tabINVDESC.Rows;

            if ((this.hdnMAINTYPE.Value == "02") && (strINVDESCTYPE != "2"))
            {
                this.txtINVDESC_RTNAMT.Text = "本金";
                this.txtINVDESC_RTNAMT.Attributes.Add("style", "display:none;");
                this.txtINVDESC_INSTAMT.Text = "利息";
                this.txtINVDESC_INSTAMT.Attributes.Add("style", "display:none;");
                this.txtINVDESC_INSTAMT.Enabled = false;
                tbrInvDescInfo[2].Attributes.Remove("display:none;");
                tbrInvDescInfo[2].Attributes.Add("style", "display:");
                tbrInvDescInfo[3].Attributes.Remove("display:none;");
                tbrInvDescInfo[3].Attributes.Add("style", "display:");
                this.txtRTNAMT.Attributes.Add("style", "display:none;");
                this.txtRTNAMT_TAX.Attributes.Add("style", "display:none;");
                this.txtRTNAMT.Text = Request.QueryString["RTNAMT"];
                this.txtRTNAMT.Text = System.Convert.ToDecimal(Request.QueryString["RTNAMT"]).ToString("#,##0");
                this.txtRTNAMT_TAX.Text = System.Convert.ToDecimal(Request.QueryString["RTNAMTTAX"]).ToString("#,##0");
                //                this.txtRTNAMT_TAX.Text = string.Format("{0:0,0}", System.Convert.ToDecimal(Request.QueryString["RTNAMTTAX"]).ToString());
                this.txtINSTAMT.Attributes.Add("style", "display:none;");
                this.txtINSTAMT_TAX.Attributes.Add("style", "display:none;");
                this.txtINSTAMT.Text = System.Convert.ToDecimal(Request.QueryString["INSTAMT"]).ToString("#,##0");
                this.txtINSTAMT_TAX.Text = System.Convert.ToDecimal(Request.QueryString["INSTAMTTAX"]).ToString("#,##0");
                this.spanRTNAMT.Text = this.txtRTNAMT.Text;
                this.spanRTNAMT_TAX.Text = this.txtRTNAMT_TAX.Text;
                this.spanINSTAMT.Text = this.txtINSTAMT.Text;
                this.spanINSTAMT_TAX.Text = this.txtINSTAMT_TAX.Text;

                if (strISSUE == "00")
                {
                    tbrInvDescInfo[3].Attributes.Remove("display:;");
                    tbrInvDescInfo[3].Attributes.Add("style", "display:none");
                }
            }
            else
            {
                tbrInvDescInfo[1].Attributes.Remove("display:none;");
                tbrInvDescInfo[1].Attributes.Add("style", "display:");
                this.spanAMOUNT.Text = this.txtAMOUNT.Text;
                this.spanTAX.Text = this.txtTAX.Text;
            }
            this.txtAMOUNT.Attributes.Add("style", "display:none");
            this.txtTAX.Attributes.Add("style", "display:none");
            this.txtRTNAMT_TAX.Attributes.Add("style", "display:none");
            this.txtRTNAMT.Attributes.Add("style", "display:none");
            this.txtINSTAMT.Attributes.Add("style", "display:none");
            this.txtRTNAMT_TAX.Attributes.Add("style", "display:none");
        }
     
    }

    /// <summary>
    /// 畫面初始屬性設定
    /// </summary>
    private void PageInitProcess()
    {
        this.txtAMOUNT.Attributes.Add("onkeypress", "OnlyNum(this);");
        this.txtAMOUNT.Attributes.Add("onfocus", "MoneyFocus(this);");
        this.txtTAX.Attributes.Add("onkeypress", "OnlyNum(this);");
        this.txtTAX.Attributes.Add("onfocus", "MoneyFocus(this);");

    }

}
