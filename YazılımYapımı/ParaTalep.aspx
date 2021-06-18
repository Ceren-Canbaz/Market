<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ParaTalep.aspx.cs" Inherits="YazilimYapimi.Talep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<table class="table table-bordered table-hover">
		<tr>
			<th>Kullanıcı ID</th>
			<th>Kullanıcı Adı</th>
			<th>Kullanıcı Ad Soyad</th>
			<th>Talep</th>
			<th>Döviz</th>
			<th></th>
			<th></th>

			<tbody>
				<asp:Repeater ID="Repeater1" runat="server">
					<ItemTemplate>
						<tr>
							<td><%#Eval("KullaniciID")%></td>
							<td><%#Eval("KullaniciAdi")%></td>
							<td><%#Eval("KullaniciAdSoyad")%></td>
							<td><%#Eval("Para")%></td>
							<td><%#Eval("Doviz")%></td>
							<td>
								<a href="ParaTalep.aspx?TalepID=<%#Eval("TalepID")%>&islem=onayla&para=<%#Eval("Para")%>&doviz=<%#Eval("Doviz")%>">
								<asp:Label ID="Label2" runat="server" Text="Onayla"></asp:Label></a>
							</td>
							<td>
							<a href="ParaTalep.aspx?TalepID=<%#Eval("TalepID")%>&islem=sil">
								<asp:Label ID="Label1" runat="server" Text="Sil"></asp:Label></a>
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</tbody>
		</tr>

	</table>
</asp:Content>
