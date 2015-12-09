<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sonserina.EscritorioDeProjetos.WebPet.MasterPages.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 140px;">
        <h2>Bem-Vindo ao WebPet</h2>
        <p>Web-Pet é uma rede social destinada a pet de estimação, perdidos e encontrados.<br /> Troque informações com os outros usuarios.</p>
        <div style="width: 700px; height: 474px; float: left; padding-bottom:100px;">
            <img src="Images/Interactive-Google-Maps.png" />
        </div>
        <div style="border: 1px solid #f5be32; padding-left: 10px; width: 284px; height: 196px;float: right; background: #FCE797; margin-right: -96px; border-radius: 5px;">
            <p class="lead">Dica Útil</p>
            <p>Encontre dicas aqui.</p>
            <p>Faça faixas e cartazes grandes, coloque uma faixa com foto na frente da casa, isso ajuda a mobilizar as pessoas.</p>
            <p><a href="Dicas/Default.aspx">Veja +</a></p>

        </div>
        <div style="border: 1px solid #f5be32; padding-left: 10px; width: 284px; height: 196px; margin-top: 50px; float: right; background: #FCE797; margin-right: -96px; border-radius: 5px;">
            <p class="lead">Mural</p>
            <p>Fique por dentro de todos os assuntos compartilhados entre os usuários.</p>
            <p>Cadastre informações do seu interesse!</p>
            <p><a href="Mural/Default.aspx">Veja +</a></p>
        </div>

    </div>
    <div style="">
    </div>
</asp:Content>
