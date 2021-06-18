<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParaEkle.aspx.cs" Inherits="YazilimYapimi.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<div class="container">
	<form id="Form1" runat="server">
		<div class="form-group">
			<div>
				<asp:Label for="TxtPara" ID="LblPara" runat="server" Text="Bakiyeniz"></asp:Label>
				<br />
				<asp:TextBox ID="TxtPara" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label ID="Lbltalep" runat="server" Text="Talep Ettiğiniz Miktar"></asp:Label>
				<br />
				<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<div>
				<asp:Label ID="Label1" runat="server"></asp:Label>
				<br />
				<asp:Button ID="Button1" runat="server" Text="Talep Oluştur" CssClass="btn btn-info" OnClick="Button1_Click" />

			    <asp:DropDownList ID="code" runat="server" Height="35px" Width="125px">
                    <asp:ListItem Value="USD">Dolar</asp:ListItem>
                    <asp:ListItem Value="EUR">Euro</asp:ListItem>
                    <asp:ListItem Value="TL">Turk lira</asp:ListItem>
                    <asp:ListItem Value="NOK">Norveç Kronu</asp:ListItem>
                    <asp:ListItem Value="KWD">Kuveyt Dinarı</asp:ListItem>
                </asp:DropDownList>
			</div>
		</div>
	</form>
	</div>
</asp:Content>
