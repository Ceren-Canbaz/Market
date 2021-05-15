<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alisveris.aspx.cs" Inherits="YazılımYapımı.Alisveris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
	<form id="Form1" runat="server">
		<div class="form-group">

			<div>
				<asp:Label for="Txtid" runat="server" Text="Ürün ID:"></asp:Label>
				<br />
				<asp:TextBox ID="Txtid" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label for="Txtad" runat="server" Text="Ürün Adı:"></asp:Label>
				<br />
				<asp:TextBox ID="Txtad" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label for="Txtsatici" runat="server" Text="Satıcı:"></asp:Label>
				<br />
				<asp:TextBox ID="Txtsatici" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label for="TxtFiyat" runat="server" Text="Kg/Lt Fiyatı:"></asp:Label>
				<br />
				<asp:TextBox ID="TxtFiyat" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label for="Txtmiktar" runat="server" Text="Stok Miktarı:"></asp:Label>
				<br />
				<asp:TextBox ID="Txtmiktar" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<br />
			<div>
				<asp:Label for="Txtadet" runat="server" Text="Adet Giriniz:"></asp:Label>
				<br />
				<asp:TextBox ID="Txtadet" runat="server" CssClass="form-control"></asp:TextBox>
			</div>
			<div>
				<asp:Label ID="lblrapor" runat="server"></asp:Label>
			</div>
		</div>
		<asp:Button ID="Button1" runat="server" Text="Satın Al" CssClass="btn btn-info" OnClick="Button1_Click"/>
	</form>
</asp:Content>
