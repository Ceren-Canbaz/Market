<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaticiUrunler.aspx.cs" Inherits="YazilimYapimi.SaticiUrunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="table table-bordered table-hover">
        <tr>
            <th>Ürün</th>
            <th>Ürün Fiyat</th>
            <th></th>

            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                <tr>
                    <td><%#Eval("UrunAd")%></td>
                    <td><%#Eval("UrunFiyat")%> TL</td>
                    <td>

                <asp:HyperLink NavigateUrl='<%#"~/UrunDuzenle.aspx?UrunID="+Eval("UrunID")%>' ID="HyperLink2" CssClass="btn btn-success" runat="server">Devam Et</asp:HyperLink>
                    </td>
                </tr>
                        </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </tr>
    </table>
</asp:Content>
