<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UrunTalep.aspx.cs" Inherits="YazilimYapimi.UrunTalep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<table class="table table-bordered table-hover">
		<tr>
			<th>Kullanıcı</th>
			<th>Kategori ID</th>
			<th>Ürün</th>
			<th>Adet</th>
			<th>Fiyat</th>
			<th></th>
			<th></th>

			<tbody>
				<asp:Repeater ID="Repeater2" runat="server">
					<ItemTemplate>
						<tr>
							<td><%#Eval("KullaniciID")%></td>
							<td><%#Eval("UrunKategoriID")%></td>
							<td><%#Eval("UrunAd")%></td>
							<td><%#Eval("UrunAdet")%> </td>
							<td><%#Eval("UrunFiyat")%> TL</td>
							<td>
								<a href="UrunTalep.aspx?UrunID=<%#Eval("UrunID")%>&islem=onayla">
								<asp:Label ID="Label2" runat="server" Text="Onayla"></asp:Label></a>
							</td>
							<td>
							<a href="UrunTalep.aspx?UrunID=<%#Eval("UrunID")%>&islem=sil">
								<asp:Label ID="Label1" runat="server" Text="Sil"></asp:Label></a>
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</tbody>
		</tr>

	</table>
</asp:Content>
