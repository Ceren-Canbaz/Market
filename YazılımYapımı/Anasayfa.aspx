<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="YazilimYapimi.Anasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<link href="LoginStyle.css" rel="stylesheet" />
	<table class="table table-bordered table-hover">
		<tr>
			<th style="width:10px"></th>
			<th>KategoriID</th>
			<th>Kategori Adı</th>
			<th></th>
			
			<tbody>
				<asp:Repeater ID="Repeater1" runat="server">
					<ItemTemplate>
				<tr>
					<td><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("KategoriFotograf")%>'/></td>
					<td><%#Eval("UrunKategoriID")%></td>
					<td><%#Eval("KategoriAd")%></td>
					<td>
						
				<asp:HyperLink NavigateUrl='<%#"~/Urunler.aspx?UrunKategoriID="+Eval("UrunKategoriID")%>' ID="HyperLink2" CssClass="btn btn-success" runat="server">Devam Et</asp:HyperLink>
					</td>
				</tr>
						</ItemTemplate>
				</asp:Repeater>
			</tbody>
		</tr>

	</table>
</asp:Content>
