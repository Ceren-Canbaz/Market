<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Rapor.aspx.cs" Inherits="YazılımYapımı.Rapor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<table class="table table-bordered table-hover">
		<tr>
			<th>Tarih</th>
			<th>Alıcı</th>
			<th>Satıcı</th>
			<th>İşlem</th>
			<th>Son</th>
			<tbody>
				<asp:Repeater ID="Repeater2" runat="server">
					<ItemTemplate>
						<tr>
							<td><%#Eval("Tarih")%></td>
							<td><%#Eval("AliciAd")%></td>
							<td><%#Eval("SaticiAd")%></td>
							<td><%#Eval("UrunMiktar")%> kg <%#Eval("UrunAd")%><br />
								Ürünün kg Fiyatı:<%#Eval("UrunFiyat")%> TL
							</td>
							<td><%#Eval("AliciAd")%>'ın <br />
								<%#Eval("KalanPara") %>TL'si kaldı.
							</td>
						</tr>
					</ItemTemplate>
				</asp:Repeater>
			</tbody>
		</tr>
	</table>
</asp:Content>
