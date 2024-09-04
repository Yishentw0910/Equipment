<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmML5002A.aspx.cs" Inherits="FrmML5002A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>
    <%=this.GSTR_A_PRGID%>-<%=this.GSTR_PROGNM%></title>
  <link rel="stylesheet" href="css/rent.css" />
  <base target="_self" />
  <meta http-equiv="Content-Type" content="text/html; charset=big5">
  <meta http-equiv="expires" content="Wed, 26 Feb 1950 08:21:57 GMT">
  <meta http-equiv="Pragma" content="no-cache">
  <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
  <meta http-equiv="MSThemeCompatible" content="No" />

  <script type="text/javascript" language="javascript" src="js/UI.js"></script>

  <script language="javascript" src="js/Itg.js"></script>

  <script language="javascript" src="js/validate.js"></script>

  <link rel="stylesheet" href="css/rent.css" />

  <script language="javascript" type="text/javascript">
    <!-- #Include file='js/ML5002A.js' -->                   
  </script>

</head>
<body>
  <form id="form1" runat="server" onkeydown="body_OnKeyDown(event)">
  <div class="divBody">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="700">
      <tr>
        <td width="40%" align="right" class="ProgID_Title1">
          <br />
          <%=this.GSTR_A_PRGID%>
          &nbsp; &nbsp;
        </td>
        <td width="60%" align="left" class="ProgID_Title2">
          <br />
          <%=this.GSTR_PROGNM%>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <hr>
        </td>
      </tr>
    </table>
    <table class="divStatus" width="68%">
      <tr>
        <!--th>
          �ץ�s��
        </th-->
        <td>
          <asp:TextBox ID="txtCASEID" Width="100px" runat="server" CssClass="txt_readonly" ReadOnly="true" Style="display: none"></asp:TextBox>
        </td>
        <th>
          �X���s��
        </th>
        <td>
          <asp:TextBox ID="txtCNTRNO" Width="130px" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
        </td>
        <th>
          �ץ�֭��
        </th>
        <td>
          <asp:TextBox ID="txtSYSDT" custprop="010" runat="server" CssClass="txt_readonly" ReadOnly="true"></asp:TextBox>
        </td>
        <td>
          <asp:Label ID="lblStatus" runat="server" class="bold_red"></asp:Label>
        </td>
      </tr>
    </table>
    <div class="div_Info H_380" style="height: auto">
      <asp:HiddenField ID="hidRETUNID" runat="server" Value="" />
      <asp:HiddenField ID="hidINVCONFIRM" runat="server" Value="" />
      <asp:HiddenField ID="hidINVCONFIRMDATE" runat="server" Value="" />
      <asp:HiddenField ID="hidINVDCONFIRM" runat="server" Value="" />
      <asp:HiddenField ID="hidINVDCONFIRMDATED" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM1" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE1" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM2" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE2" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRM3" runat="server" Value="" />
      <asp:HiddenField ID="hidRETUNCONFIRMDATE3" runat="server" Value="" />
      <div class="div_title">
        �ץ���</div>
      <table class="tb_Info" cellpadding="1" cellspacing="1">
        <tr>
          <th width="12%">
            �ӧ@����
          </th>
          <td width="10%">
            <asp:TextBox ID="txtMAINTYPENM" CssClass="txt_readonly" ReadOnly="true" runat="server" Width="120px"></asp:TextBox>
          </td>
          <th width="15%">
            ���ڤ�
          </th>
          <td colspan="5">
            <asp:TextBox ID="txtPAYDATE" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            �X���_��
          </th>
          <td>
            <asp:TextBox ID="txtRENTSTDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            �X������
          </th>
          <td>
            <asp:TextBox ID="txtRENTENDT" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            ����
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtCONTRACTMONTH" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th>
            �ӧ@���B
          </th>
          <td>
            <asp:TextBox ID="txtACTUALLYAMOUNT" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            �i���O�Ҫ�
          </th>
          <td>
            <asp:TextBox ID="txtPERBOND" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th>
            ���ʫO�Ҫ�
          </th>
          <td colspan="3">
            <asp:TextBox ID="txtPURCHASEMARGIN" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <th width="12%">
            �C������
          </th>
          <td width="10%">
            <asp:TextBox ID="txtMPAY" CssClass="txt_readonly_right" Text="0" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th width="15%">
            IRR
          </th>
          <td width="10%">
            <asp:TextBox ID="txtIRR" CssClass="txt_readonly_right" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th width="15%" style="display: none;">
            ���ڤ覡
          </th>
          <td width="10%" style="display: none;">
            <asp:TextBox ID="txtD1" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
          <th width="15%">
            �I�ڤ覡
          </th>
          <td>
            <asp:TextBox ID="txtCUSTPAYTYPE" Width="140px" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
      </table>
      <div class="div_title" style="margin-top: 10px;">
        �i���o����ƽT�{</div>
      <%--<table width="98%" class="tb_Info" style="margin-top:10px;">
            <tr>
              <th width="14%">�o�����|���B</th>
              <td width="12%"><asp:TextBox ID="TextBox17" CssClass="txt_normal" runat="server"></asp:TextBox></td>
              <th width="12%">�i���|�B</th>
              <td width="12%"><asp:TextBox ID="TextBox18" CssClass="txt_normal" runat="server"></asp:TextBox></td>
              <th width="12%">�o���`���B</th>
              <td width="12%"><asp:TextBox ID="TextBox19" CssClass="txt_normal" runat="server"></asp:TextBox></td>
              <th width="12%"></th>
              <td></td>
            </tr>
          </table>--%>
      <div id="divMLDCONTRACTINV" class="div_table" style="overflow: auto; height: 100px">
        <table class="tb_Contact" style="margin: 15px;" width="2200px">
          <th>
            ����
          </th>
          <th>
            ���Ҹ��X
          </th>
          <th>
            �o�����
          </th>
          <th>
            ���|���B
          </th>
          <th>
            �|�B
          </th>
          <th>
            �t�|���B
          </th>
          <th>
            ��i���O�Ҫ�
          </th>
          <th>
            �诲�ʫO�Ҫ�
          </th>
          <th>
            ���Y����
          </th>
          <th>
            �~�N�ۥI�B
          </th>
          <th>
            �꼷���B
          </th>
          <th>
            �i���O�Ҫ�����
          </th>
          <th>
            ���ʫO�Ҫ�����
          </th>
          <th>
            �Y���ڲ���
          </th>
          <th>
            ������
          </th>
          <th>
            �״ڶ���
          </th>
          <th>
            �״ڻȦ�
          </th>
          <th>
            ����
          </th>
          <th>
            ��W
          </th>
          <th>
            �b��
          </th>
          </tr>
          <%--
        <tr>
          <th>
            �o�����X
          </th>
          <th>
            �o���νs
          </th>
          <th style="display:none;">
            �o������
          </th>
          <th>
            �o�����
          </th>
          <th>
            ���|���B
          </th>
          <th>
            �|�B
          </th>
          <th>
            �o�����B
          </th>
          <th>
            �X�p
          </th>
          <th>
            �~�N�ۥI�B
          </th>
        </tr>
        --%>
          <asp:Repeater ID="rptMLDCONTRACTINV" runat="server">
            <ItemTemplate>
              <tr>
                <td>
                  <%# Container.ItemIndex +1 %>
                </td>
                <td>
                  <%# Eval("CERTIFICATENO")%>
                </td>
                <td>
                  <%# Itg.Community.Util.GetRepYear(Eval("INVDATE").ToString()) %>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("NOTAXAMOUNT").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("TAX").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("ANOUMTTAX").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("PERBONDUSED").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("HIREPURUSED").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYUSED").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("INVSALESPAY").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("ACTUALLYAMOUNT").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("PERBONDNOTE").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("PURCHASENOTE").ToString())%>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("FIRSTPAYNOTE").ToString())%>
                </td>
                <td>
                  <%# Eval("SUPPLIER").ToString() + Eval("SUPPLIERS").ToString()%>
                </td>
                <td>
                  <%# Eval("SUPSEQ") %>
                </td>
                <td>
                  <%# Eval("BANKNM")%>
                </td>
                <td>
                  <%# Eval("COMPNM")%>
                </td>
                <td>
                  <%# Eval("RV_NAME")%>
                </td>
                <td>
                  <%# Eval("RVACNT")%>
                </td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
        </table>
      </div>
      <div class="div_title" style="margin-top: 10px;">
        �i���������</div>
      <table width="98%" class="tb_Info" cellpadding="1" cellspacing="1" style="margin-top: 0px;">
        <tr>
          <th style="display: none;" width="14%">
            ���|���B
          </th>
          <td style="display: none;" width="12%">
            <asp:TextBox ID="txtTPAY" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this);" onblur="MoneyBlur(this);SetTax();SumMoney();" onkeyup="CheckNumber_keyup(this);" MaxLength="9" CssClass="txt_normal_right" runat="server"></asp:TextBox>
          </td>
          <th style="display: none;" width="12%">
            �|�B
          </th>
          <td style="display: none;" width="12%">
            <asp:TextBox ID="txtAPAY" onkeypress="OnlyNum(this);" onfocus="MoneyFocus(this);" onblur="MoneyBlur(this);SumMoney();" onkeyup="CheckNumber_keyup(this);" MaxLength="9" CssClass="txt_normal_right" runat="server"></asp:TextBox>
          </td>
          <th style="display: none;" width="12%">
            �`�B
          </th>
          <td style="display: none;">
            <asp:TextBox ID="txtPAYALL" CssClass="txt_readonly" ReadOnly="true" runat="server"></asp:TextBox>
          </td>
        </tr>
      </table>
      <div style="overflow-x: scroll; height: 100px">
        <table class="tb_Contact" style="margin: 15px; width: 95%;">
          <tr>
            <th>
              �����o�����X
            </th>
            <th>
              �o���νs
            </th>
            <th>
              ������
            </th>
            <th>
              �������|���B
            </th>
            <th>
              �����|�B
            </th>
            <th>
              �`�B
            </th>
            <th>
              �X�p
            </th>
          </tr>
          <asp:Repeater ID="rptMLDCONTRACTINVD" runat="server">
            <ItemTemplate>
              <tr>
                <td>
                  <asp:Label ID="txtDISCOUNTINVNUM" Text='<%# Eval("DISCOUNTINVNUM")%>' runat="server"></asp:Label>
                </td>
                <td>
                  <asp:Label ID="txtSUPPLIER" Text='<%# Eval("SUPPLIER")%>' runat="server"></asp:Label>
                </td>
                <td>
                  <asp:TextBox ID="txtDISCOUNTDATE" MaxLength="8" onkeypress="OnlyNum(this);" onfocus="dateFocus(this)" CssClass="txt_table_right" Width="80px" onblur="dateBlur(this);" Text='<%# Itg.Community.Util.GetRepYear(Eval("DISCOUNTDATE").ToString()) %>' runat="server"></asp:TextBox>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>
                  <asp:TextBox ID="txtDISCOUNTAMOUNT" Style="display: none;" onkeypress="OnlyNum(this);" MaxLength="9" onfocus="MoneyFocus(this)" CssClass="txt_table_right" onblur="MoneyBlur(this);RSumMoney1(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNT").ToString())%>' runat="server"></asp:TextBox>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>
                  <asp:TextBox ID="txtDISCOUNTTAX" Style="display: none;" onkeypress="OnlyNum(this);" MaxLength="9" onfocus="MoneyFocus(this)" CssClass="txt_table_right" onblur="MoneyBlur(this);RSumMoney2(this);" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTTAX").ToString())%>' runat="server"></asp:TextBox>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>
                  <asp:TextBox ID="txtDISCOUNTAMOUNTTAX" Style="display: none;" CssClass="txt_readonly_right" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>' runat="server"></asp:TextBox>
                </td>
                <td>
                  <%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>
                  <asp:TextBox ID="txtTotal" Style="display: none;" CssClass="txt_readonly_right" ReadOnly="true" Text='<%# Itg.Community.Util.NumberFormat(Eval("DISCOUNTAMOUNTTAX").ToString())%>' runat="server"></asp:TextBox>
                </td>
                <%--<td><asp:Label ID="Label1"  Text="" runat="server" ></asp:Label></td>--%>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
        </table>
      </div>
    </div>
    <div class="btn_div">
      <asp:Button ID="btnSubmit" runat="server" Text="�T�{" CssClass="btn_normal" OnClick="btnSubmit_Click" />
      <input type="button" id="btnSelect" class="btn_normal" onclick="window.close();" value="����" />
    </div>
  </div>
  </form>
</body>
</html>
