using System.Web;
using System.Web.Services;
using System.IO;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Microsoft.VisualBasic;
public class Component : System.Web.IHttpHandler
{
   
    public void ProcessRequest(HttpContext context)
    {
        //*****必要宣告*****
        string LSTR_ClassName = "";
        string LSTR_MethodName = "";
        string LSTR_LogFile = "";
       
        //*****額外宣告*****
        string LSTR_PackageName = null;
        string LSTR_ComponentName = null;
       
        string[] LVAR_Temp = null;
        StringBuilder LSTR_Code = default(StringBuilder);
        int LINT_ColIndex = 0;
        string LSTR_Result = "";
        //object ScriptControl = null;
        string Str_TransactionId = null;
        int Int_PMCount = 0;
        ArrayList Var_Parameter = new ArrayList();
        HttpRequest Request = context.Request;
        HttpResponse Response = context.Response;
       
        try {
            LSTR_ClassName = "Comus.Component";
            LSTR_MethodName = "ProcessRequest";
            LSTR_LogFile = LSTR_ClassName + "_" + LSTR_MethodName + ".log";
           
            Request.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
           
            Str_TransactionId = Request["TPID"].ToString();
            Int_PMCount = Convert.ToInt32(Request["PMCOUNT"].ToString());
            LogFile(LSTR_LogFile, "Start Process", Str_TransactionId);
           
            for (LINT_ColIndex = 1; LINT_ColIndex <= Int_PMCount; LINT_ColIndex++) {
                Var_Parameter.Add(Request["PM" + LINT_ColIndex].ToString());
            }
            //Dim strBig5 As Byte() = Encoding.Convert(Encoding.GetEncoding("big5"), Encoding.Unicode, Encoding.GetEncoding("big5").GetBytes(Request("PM" & LINT_ColIndex)))
            //Var_Parameter.Add(Encoding.Unicode.GetString(strBig5))
           
            LVAR_Temp = Regex.Split(Str_TransactionId, ".");
            LSTR_PackageName = LVAR_Temp[0].Trim();
            LSTR_ClassName =LVAR_Temp[1].Trim();
            LSTR_MethodName = LVAR_Temp[2].Trim();
            LSTR_ComponentName =  LSTR_PackageName.Trim() + "." +  LSTR_ClassName.Trim();
            if ((LSTR_ClassName + "." + LSTR_MethodName).ToUpper() ==  ("Execute.Exe").ToUpper()) {
                LSTR_Result = Var_Parameter[0].ToString();
                return;
            }
            else if ((LSTR_ClassName + "." + LSTR_MethodName).ToUpper() == ("ServerService.GetUserIP").ToUpper()) {
                LSTR_Result = "0" + Request.UserHostAddress;
                //Request.ServerVariables("REMOTE_ADDR")
                return;
            }
            //***** 宣告要執行的Script *****
            LSTR_Code = new StringBuilder();
            LSTR_Code.Append("function TPDispatch() {").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append(" var LOBJ_MTSComponent;").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append(" var LSTR_RC;").Append("\n");
            LSTR_Code.Append(" LOBJ_MTSComponent = new ActiveXObject(\"").Append(LSTR_ComponentName).Append("\");").Append(Constants.vbCrLf);
            LSTR_Code.Append(" LSTR_RC = LOBJ_MTSComponent.").Append(LSTR_MethodName).Append("(");
            for (LINT_ColIndex = 1; LINT_ColIndex <= Int_PMCount; LINT_ColIndex++) {
                if (LINT_ColIndex == Int_PMCount) {
                    LSTR_Code.Append("\"").Append(Var_Parameter[LINT_ColIndex - 1].ToString()).Append("\"");
                }
                else {
                    LSTR_Code.Append("\"").Append(Var_Parameter[LINT_ColIndex - 1].ToString()).Append("\",");
                }
            }
            LSTR_Code.Append(");").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append(" LOBJ_MTSComponent = null;").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append(" delete LOBJ_MTSComponent;").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append(" return LSTR_RC;").Append(Convert.ToChar(13) + Convert.ToChar(10));
            LSTR_Code.Append("}").Append(Convert.ToChar(13) + Convert.ToChar(10));


            MSScriptControl.ScriptControl ScriptControl = new MSScriptControl.ScriptControlClass();
            ScriptControl.Language = "JavaScript";

            object[] parameters = new object[0] { };
            ScriptControl.AddCode(LSTR_Code.ToString());
            object obf = ScriptControl.Run(ScriptControl.Procedures[1].ToString(), parameters);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(ScriptControl);
            ScriptControl = null;

            ////***** 轉換特殊字元 *****
            LSTR_Result = Regex.Replace(LSTR_Result, @"\", @"\\");
            LSTR_Result = Regex.Replace(LSTR_Result, Convert.ToString((char)10), "<BR>");
            LSTR_Result = Regex.Replace(LSTR_Result, Convert.ToString((char)13), "");
            
            
        }
        catch (System.Exception Exception) {
            //LSTR_Result = Replace(LSTR_Result, """", "\""")
            //LSTR_Result = Replace(LSTR_Result, "'", "\'")
           
            LSTR_Result = Exception.Message;
        }
        finally {
            LogFile(LSTR_LogFile, "End Process", "");
            if ((LSTR_ClassName + "." + LSTR_MethodName).ToUpper() == ("Execute.Exe").ToUpper()) {
                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.BufferOutput = true;
                Response.ContentType = "application/comus-waf-ap";
                Response.Clear();
                Response.Write(LSTR_Result);
                Response.Flush();
                Response.End();
            }
            else {
                Response.Charset = "utf-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.Write(LSTR_Result);
            }
        }
    }
    private void LogFile(string LISTR_FileName, string LISTR_Explain, string LISTR_LogString)
    {
        //int LLNG_FileHandle = 0;
        //string LSTR_Path = null;
        //string GCST_LogPath = "C:";
       
        //if (Directory.Exists(GCST_LogPath) == false) {
        //    Directory.CreateDirectory(GCST_LogPath);
        //}
        //LSTR_Path = GCST_LogPath + "\\" + SysDate("") + "_" + LISTR_FileName;
        //LLNG_FileHandle = FileSystem.FreeFile();
        //if (string.IsNullOrEmpty(FileSystem.Dir(LSTR_Path, FileAttribute.Normal).Trim)) {
        //    FileSystem.FileOpen(LLNG_FileHandle, LSTR_Path, OpenMode.Output);
        //}
        //else {
        //    FileSystem.FileOpen(LLNG_FileHandle, LSTR_Path, OpenMode.Append);
        //}
        //FileSystem.PrintLine(LLNG_FileHandle, Today.ToShortDateString + " " + TimeOfDay.ToLongTimeString + "------>" + LISTR_Explain + " = " + LISTR_LogString);
       
        //FileSystem.FileClose(LLNG_FileHandle);
    }
    //private string SysDate([System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("")] // ERROR: Optional parameters aren't supported in C# System.Object LSTR_Separator)
    //{
    //    string LSTR_ClassName = null;
    //    string LSTR_MethodName = null;
    //    string LSTR_Return = null;
       
    //    LSTR_ClassName = "Comus.Component";
    //    LSTR_MethodName = "SysDate";
    //    LSTR_Return = Today.Year.ToString.PadLeft(4, '0');
    //    LSTR_Return += LSTR_Separator;
    //    LSTR_Return += Today.Month.ToString.PadLeft(2, '0');
    //    LSTR_Return += LSTR_Separator;
    //    LSTR_Return += Today.Day.ToString.PadLeft(2, '0');
       
    //    return LSTR_Return;
    //}
   
    public bool IsReusable {
        get { return false; }
    }
   
}