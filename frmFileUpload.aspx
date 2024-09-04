<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFileUpload.aspx.cs" Inherits="frmFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>附件檔案上傳</title>
     <link rel="stylesheet" href="css/rent.css" />    
    <base target="_self"  /> 
    
    <script language="javascript">
      var GSTR_ColDelimitChar = String.fromCharCode(1);
      var GSTR_RowDelimitChar = String.fromCharCode(2);

      function FileUpload(LSTR_FileName, LSTR_SaveName) {
        window.returnValue = LSTR_FileName + GSTR_ColDelimitChar + LSTR_SaveName;
        window.close();
      }
    </script>
</head>
<body style="background-color:#E5F1FE;">
    <form id="form1" runat="server">
    <div style="margin-top:20px;">
      <table class="table_fileUpload" style="width:400px;">
        <tr>
          <th style="width:26%;">附件檔名：</th>
          <td><asp:FileUpload ID="FileUpload1" style=" width:99%;height:20px;" CssClass="txt_normal" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="btnUpload" CssClass="btn_normal" 
                  style="height:20px; width: 46px;"  runat="server" Text="上傳" 
                  onclick="btnUpload_Click" />
                 <asp:Button ID="btnClose" CssClass="btn_normal" style="height:20px;"  OnClientClick="window.close();return false;" runat="server" Text="離開" />
            </td>
        </tr>
      </table>
      
    </div>
    </form>
</body>
</html>
