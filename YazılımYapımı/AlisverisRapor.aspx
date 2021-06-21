<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlisverisRapor.aspx.cs" Inherits="YazilimYapimi.AlisverRapor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <form id="form1" runat="server">
            <script>
                <!--> Pdf'e ekranı <--!>
                var doc = new jsPDF();

                function saveDiv(divId,
                    title) {

                    let mywindow = window.open('', 'SAVE', 'height=650,width=900,top=100,left=150');
                    doc.fromHTML('<html><head><title>${title}</title></head><body>' + document.getElementById(divId).innerHTML + '</body></html>');
                    doc.save('div.pdf');
                }

                function printDiv(divId,
                    title) {

                    let mywindow = window.open('', 'PRINT', 'height=650,width=900,top=100,left=150');

                    mywindow.document.write('<html><head><title>${title}</title>');
                    mywindow.document.write('</head><body>');
                    mywindow.document.write(document.getElementById(divId).innerHTML);
                    mywindow.document.write('</body></html>');
                    mywindow.document.close();
                    mywindow.focus();

                    mywindow.print();
                    mywindow.close();

                    return true;
                }
            </script>

            <div>
                <asp:Label ID="Label1" runat="server" Text="Başlangıç Tarihi Seçiniz"></asp:Label>
                <input id="Text1" type="datetime-local" name="Text1" />
                <asp:Label ID="Label2" runat="server" Text="Bitiş Tarihi Seçiniz"></asp:Label>
                <input id="Text2" type="datetime-local" name="Text2" />
                <asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Listele" OnClick="Button1_Click" />
            </div>
            <button class="btn btn-info" onclick="printDiv('pdf','Title')">pdf'e çevir</button>
            <br />
            <div id="pdf">
                <div>
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Tarih</th>
                                <th>Ürün Tipi</th>
                                <th>Alım Tutarı</th>
                                <th>Miktar</th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Tarih")%></td>
                                        <td><%#Eval("KategoriAd")%></td>
                                        <td><%#Eval("Fiyat")%></td>
                                        <td><%#Eval("Miktar")%> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>

                    </table>
                </div>
                <div>
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Tarih</th>
                                <th>Ürün Tipi</th>
                                <th>Satış Tutarı</th>
                                <th>Miktar</th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Tarih")%></td>
                                        <td><%#Eval("KategoriAd")%></td>
                                        <td><%#Eval("Fiyat")%></td>
                                        <td><%#Eval("Miktar")%> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </form>
    </div>

</asp:Content>
