<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sonserina.EscritorioDeProjetos.WebPet.Login.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(".cat_navbar ul").hide();
        $("div#login").hide();
        $("form").css("background", "#87CEFA");
        $(".cat_navbar").hide();

    </script>
    <style>
        #logoWebpet {
            float: left;
            position: absolute;
            margin-left: 514px;
            margin-top: 0px;
            width: 300px;
        }
    </style>
    <div style="border: 2px solid #ccc; width: 300px; float: left; margin-left: 311px; margin-bottom: 50px; margin-top: 227px; height: 300px; background: #ffffff; border-radius: 10px;">
        <a href="../Default.aspx">
            <img id="logoWebpet" src="../Images/webpet_logo.png" alt="WebPet" style="margin-top: -160px; margin-left: -2px;" /></a>
        <table style="height: 118px; float: left; margin-left: 38px;">
            <tr>
                <td>
                    <h3>Sign in to WebPet</h3>
					   <asp:Label ID="lblmsg" runat="server" ForeColor="red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                    <asp:TextBox runat="server" ID="txtEmail" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" AssociatedControlID="txtSenha">Senha:</asp:Label>
                    <asp:TextBox runat="server" ID="txtSenha" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogar" Text="Logar" class="btn btn-success" runat="server" OnClick="LogarUsuario" Style="float: left; margin-right: 48px;" />
                    <asp:Button ID="btnCadastrar" Text="Cadastre-se" class="btn btn-primary" runat="server" OnClick="CadastrarUsuario" />
                    <img src="../Images/facebook.png" style="margin-top: 13px; width: 194px; margin-left: 14px;" />
                </td>
                <tr>
                    <td class="style1" colspan="2">
                     
                    </td>
                </tr>
                <asp:CheckBox ID="Persist" runat="server" Visible="false" />
        </table>
    </div>
</asp:Content>
