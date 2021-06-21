<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BeklenenUrunler.aspx.cs" Inherits="YazilimYapimi.BeklenenUrunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<div class="container">
	<form id="form1" runat="server">
		<div class="container">
			<table class="table table-bordered table-hover">
				<tr>
					<th>İstenen Ürün</th>
					<th>İstenen Fiyat</th>
					<th>İstenen Adet</th>
					<th>Durum</th>
					<th></th>

					<tbody>
						<asp:Repeater ID="Repeater1" runat="server">
							<ItemTemplate>
								<tr>
									<td><%#Eval("KategoriAd")%></td>
									<td><%#Eval("Fiyat")%></td>
									<td><%#Eval("Adet")%></td>
									<td><%#Eval("Durum")%></td>
									<td>
										<a href="BeklenenUrunler.aspx?IstekID=<%#Eval("IstekID")%>&islem=iptal">
											<asp:Label ID="Label1" runat="server" Text="Sil"></asp:Label>
										</a>
									</td>
								</tr>
							</ItemTemplate>
						</asp:Repeater>
					</tbody>
				</tr>
			</table>
		</div>									
	</form>
		</div>
</asp:Content>
