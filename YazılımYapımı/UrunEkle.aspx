<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="YazilimYapimi.UrunEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<form runat="server">
	<div>
		<asp:Label ID="Label1" runat="server" Text="Kategori Seçin"></asp:Label>
		<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="KategoriAd" DataValueField="UrunKategoriID"></asp:DropDownList>
		<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:YazilimYapimiMarketConnectionString %>" SelectCommand="SELECT [UrunKategoriID], [KategoriAd] FROM [UrunKategori]"></asp:SqlDataSource>
	</div>
		<br />
		<div>
			<asp:Label ID="Label2" runat="server" Text="Ürün Adı:"></asp:Label>
			<asp:TextBox ID="TxtUrunad" runat="server" CssClass="form-control"></asp:TextBox>
		</div>
		<br />
		<div>
			<asp:Label ID="Label3" runat="server" Text="Ürün Adeti:"></asp:Label>
			<asp:TextBox ID="TxtAdet" runat="server" CssClass="form-control"></asp:TextBox>
		</div>
		<div>
			<asp:Label ID="Label4" runat="server" Text="Kg/Lt Fiyatı:"></asp:Label>
			<asp:TextBox ID="Fiyat" runat="server" CssClass="form-control"></asp:TextBox>
		</div>
		<asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-info" OnClick="Button1_Click" />
		<br />
			<asp:Label ID="Label5" runat="server"></asp:Label>
		<br />
		</form>
</asp:Content>
