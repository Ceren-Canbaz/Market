﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UrunDuzenle.aspx.cs" Inherits="YazilimYapimi.UrunDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
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
                <asp:Label for="TxtFiyat" runat="server" Text="Kg/Lt Fiyatı:"></asp:Label>
                <br />
                <asp:TextBox ID="TxtFiyat" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label for="TextBox2" runat="server" Text="Adet:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
             <div>
                <asp:Label for="TextBox1" runat="server" Text="Yeni Fiyat:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblrapor" runat="server"></asp:Label>
            </div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="Button1_Click"/>
    </form>
        </div>
</asp:Content>
