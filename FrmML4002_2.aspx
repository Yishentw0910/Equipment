<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML4002_2.aspx.cs" Inherits="FrmML4002_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
    <base target="_self"  />
    <meta http-equiv=Content-Type content="text/html; charset=big5">
    <meta http-equiv=expires content="Wed, 26 Feb 1950 08:21:57 GMT">
    <meta http-equiv=Pragma content=no-cache>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="MSThemeCompatible" content="No" />
    <link rel="stylesheet" href="css/rent.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="div_title" runat="server" id="divTitle">發票彙開明細資料</div>
            <table class="tb_Contact" style="margin:5px;" width="98%">
            <tr>
              <th>彙開合約編號</th>
              <th>合約編號</th>
              <th>發票開起月</th>
              <th>幾月一開</th>
              <th>指定日期</th>
              <th>發票統編</th>
              <th>發票抬頭</th>
              <th>承作類型</th>
              <th>期數</th>
              <th>總期數</th>
            </tr>
             <asp:Repeater ID="rptMLDPREINVOPEN" runat="server" 
                onitemcommand="rptMLDPREINVOPEN_ItemCommand">
                  <ItemTemplate> 
            <tr>
              <td><%#Eval("OPENCNTRNO")%></td>
              <td><%#Eval("CNTRNO")%></td>
		          <td><%#Eval("INVOPENMONTH")%></td>
		          <td><%#Eval("OPENMONTH")%></td>
		          <td><%#Eval("ORDERDATE")%></td>
		          <td><%#Eval("TARGETID")%></td>
		          <td><%#Eval("TARGETNAME")%></td>
		          <td><%#Eval("MAINTYPES")%></td>
		          <td><%#Eval("RPAY")%></td>
		          <td><%#Eval("CONTRACTMONTH")%></td>
            </tr>
             </ItemTemplate>
           </asp:Repeater>
          </table>
        </div>
        <div class="btn_div">
          <asp:Button ID="btnConfirm" runat="server" Text="彙開確認" Width="120px" CssClass="btn_normal" OnClick="btnConfirm_Click"  />
        </div>
    </div>
    </form>
</body>
</html>
