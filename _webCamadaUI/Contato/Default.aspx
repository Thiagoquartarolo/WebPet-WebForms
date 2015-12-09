<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sonserina.EscritorioDeProjetos.WebPet.Contato.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div style="margin-top: 130px;padding-bottom:100px;">
		<h1>Fale Conosco</h1>
		<p>O Web Pet quer ouvir você, seus elogios, sugestões ou críticas, basta preencher o formulário abaixo e clicar no botão Enviar.</p>

		<div class="prefix_1">

				<input name="__RequestVerificationToken" type="hidden" value="IpJsS2jldky3qKkqQNrIM6uvgTgJJ2HxXei0C3q8ycE8P3pmkEvhLaeqT+efrwfyDO/jkz/6SLyaXlk6H0/gxE8zmDZ6AniOsWPclgOoIIJ7yBIfwCtE1DvDUmum652uANZ7UH3v4NSBsiSespy4rBDZ+dLmahxkQC+74d+S4Fo=">
				<div class="field">
					<label for="Nome">Nome Completo</label>
					<input data-val="true" data-val-required="The Nome Completo field is required." id="Nome" name="Nome" type="text" value="">
				</div>
				<div class="field">
					<label for="Email">E-mail</label>
					<input class="w_4" data-val="true" data-val-required="The E-mail field is required." id="Email" name="Email" type="text" value="">
				</div>
				<div class="field">
					<label for="Assunto">Assunto</label>
					<input class="w_5" data-val="true" data-val-required="The Assunto field is required." id="Assunto" name="Assunto" type="text" value="">
				</div>
				<div class="field">
					<label for="Mensagem">Mensagem</label>
					<textarea cols="20" data-val="true" data-val-required="The Mensagem field is required." id="Mensagem" name="Mensagem" rows="2"></textarea>
				</div>
				<button id="" type="button" class="btn btn-success" onclick="javascript:(0);">Enviar</button>
		
		</div>

	</div>
	
</asp:Content>

