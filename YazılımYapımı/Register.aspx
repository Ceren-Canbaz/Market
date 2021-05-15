<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YazılımYapımı.Register" %>

<!DOCTYPE html>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="LoginStyle.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>

	<div>
		<div class="wrapper fadeInDown">
			<div style="margin-top: auto; width: auto" id="formContent">



				<div class="fadeIn first">
					&nbsp;
				</div>


				<form runat="server">
					<div class="text-center">
						<asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
						<asp:TextBox ID="txtKullaniciAdi" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC"></asp:TextBox>
						<br />
						<asp:Label ID="Label2" runat="server" Text="Ad Soyad"></asp:Label>
						<asp:TextBox ID="txtAdSoyad" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC"></asp:TextBox>
						<br />
						<asp:Label ID="Label3" runat="server" Text="Parola"></asp:Label>
						<br />
						<asp:TextBox ID="txtParola" runat="server" CssClass="btn fadeIn fourth" TextMode="Password" Width="85%" Style="background-color: #CCCCCC" Height="54%"></asp:TextBox>
						<br />
						<asp:Label ID="Label4" runat="server" Text="TC Kimlik"></asp:Label>
						<br />
						<asp:TextBox ID="txtTC" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC"></asp:TextBox>
						<br />
						<asp:Label ID="Label5" runat="server" Text="Telefon"></asp:Label>
						<br />
						<asp:TextBox ID="txtTelefon" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC"></asp:TextBox>
						<br>
						<asp:Label ID="Label6" runat="server" Text="Mail Adresi"></asp:Label>
						<br />
						<asp:TextBox ID="txtMail" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC" Width="85%"></asp:TextBox>
						<br />
						<asp:Label ID="Label7" runat="server" Text="Adres"></asp:Label>
						<br />
						<asp:TextBox ID="txtAdres" runat="server" CssClass="btn fadeIn fourth" Height="85%" Style="background-color: #CCCCCC" TextMode="MultiLine" Width="85%"></asp:TextBox>
						<asp:Button ID="Button1" runat="server" Text="Kaydol" OnClick="Button1_Click" />
						<br />
						<asp:Label ID="Label8" runat="server" Text=""></asp:Label>

					</div>
				</form>


				<div id="formFooter">
					<a class="underlineHover" href="Login.aspx">Zaten Hesabın var mı?</a>
				</div>

			</div>
		</div>
	</div>

</body>
</html>
