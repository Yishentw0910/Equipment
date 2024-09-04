using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmFileUpload : Itg.Community.PageBase
{
    //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
    string PRGID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
        PRGID = Request.QueryString["PRGID"] == null ? "" : Request.QueryString["PRGID"].ToString();
    }

    public void WriteJS(string LSTR_Script)
    {
      Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + LSTR_Script + "</script>");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
      string LSTR_FileName = null;
      string LSTR_GUID = null;
      bool LBOL_SaveSucess = false;
      string LSTR_UploadURL = null;

      Itg.Bussness.FileUploads LOBJ_UPComment;
      try
      {
        LSTR_FileName = FileUpload1.FileName;
        if (!string.IsNullOrEmpty(LSTR_FileName))
        {
          LOBJ_UPComment = new Itg.Bussness.FileUploads();
          //上傳文件格式設定(目前不限定上傳格式 )
          LOBJ_UPComment.FileType = "";
          //20161229 ADD BY SS ADAM REASON.改為進件資料，上傳增加到4個
          if (PRGID == "ML1002")
          {
              //限定附檔名為PDF,TIFF
              LOBJ_UPComment.FileType = ".pdf|.tiff";
          }
          //設定上傳路徑
          //LOBJ_UPComment.UploadDirectoryPath = Common.GetProfileString(GCST_EnvParameter, "UploadPath", GCST_AppPath + "\Log", GCST_IniFileName)
          LOBJ_UPComment.UploadDirectoryPath = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadPath");
          //指定文件的保存名字
          LSTR_GUID = Guid.NewGuid().ToString();
          LOBJ_UPComment.NewFileName = LSTR_GUID;
          //LOBJ_UPComment.NewFileName = Request.QueryString["caseid"].ToString();

          LBOL_SaveSucess = LOBJ_UPComment.FileSave(FileUpload1.PostedFile);
          if (LBOL_SaveSucess)
          {
            LSTR_UploadURL = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadURL");
            string LSTR_Script = "FileUpload('" + LSTR_FileName + "','" + LSTR_GUID + System.IO.Path.GetExtension(LSTR_FileName) + "');";
            WriteJS(LSTR_Script);
          }
          else
          {
            Alert(LOBJ_UPComment.OutMessage);
          }
        }
        else
        {
          Alert("請選擇上傳文件！");
        }
      }
      catch (Exception ex)
      {
        Alert(ex.Message);
      }

    }
}
