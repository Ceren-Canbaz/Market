﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="YazilimYapimi.Urunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<table class="table table-bordered table-hover">
		<tr>
			<th>Satıcı</th>
			<th>Ürün</th>
			<th>Ürün Fiyat</th>
			<th></th>
			
			<tbody>
				<asp:Repeater ID="Repeater1" runat="server">
					<ItemTemplate>
				<tr>
					<td><%#Eval("KullaniciAdSoyad")%></td>
					<td><%#Eval("UrunAd")%></td>
					<td><%#Eval("UrunFiyat")%> TL</td>
					<td>
						
				<asp:HyperLink NavigateUrl='<%#"~/Alisveris.aspx?UrunID="+Eval("UrunID")%>' ID="HyperLink2" CssClass="btn btn-success" runat="server">Devam Et</asp:HyperLink>
					</td>
				</tr>
						</ItemTemplate>
				</asp:Repeater>
			</tbody>
		</tr>

	</table>
</asp:Content>
