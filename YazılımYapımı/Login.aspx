<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YazilimYapimi.Login" %>

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
			<div style="margin-top: 150px" id="formContent">
				<div class="fadeIn first">
					&nbsp;
				</div>

				<form runat="server">
					<asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
					<asp:TextBox ID="TextBox1" runat="server" CssClass="btn fadeIn fourth" Height="54%" Style="background-color: #CCCCCC"></asp:TextBox>
					<br />
					<asp:Label ID="Label2" runat="server" Text="Parola"></asp:Label>
					<br />
					<asp:TextBox ID="TextBox2" runat="server" CssClass="btn fadeIn fourth" TextMode="Password" Width="85%" Style="background-color: #CCCCCC"></asp:TextBox>
					<asp:Button ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" />
					<br />
					<asp:Label ID="Label3" runat="server"></asp:Label>
				</form>
				<div id="formFooter">
					<a class="underlineHover" href="Register.aspx">Kaydol</a>
				</div>

			</div>
		</div>
	</div>

</body>
</html>






