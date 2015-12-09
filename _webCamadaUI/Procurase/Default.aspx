<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_webCamadaUI.Procurase.Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div style="margin-top: 84px; background-color: #f5be32; height: 100%; border-radius: 5px; border: 1px solid !important; padding-left: 10px; margin-left: 36px;">
		<table style="">
			<tr>
				<td>Status da Ocorrência:<br />
					<asp:DropDownList ID="dllStatus" runat="server" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
						<asp:ListItem Value="1" Text="Desaparecido"></asp:ListItem>
						<asp:ListItem Value="2" Text="Encontrado"></asp:ListItem>
					</asp:DropDownList>
					<br />
				</td>

				<td>Tipo de Animal:<br />
					<asp:DropDownList ID="dllTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
					<br />
				</td>

				<td>Raça do animal:<br />
					<asp:DropDownList ID="dllRaca" runat="server" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
					<br />
				</td>

				<td>Porte do animal:<br />
					<asp:DropDownList ID="dllPorte" runat="server" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
					<br />
				</td>
			</tr>
			<tr>
				<td>Cor do animal:<br />
					<asp:DropDownList ID="ddlCor" runat="server" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
					<br />
				</td>

				<td>Estado:<br />
					<asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
					<br />
				</td>

				<td>Cidade:<br />
					<asp:DropDownList ID="ddlCidade" runat="server" AutoPostBack="true">
						<asp:ListItem Value="" Text="Selecione..." />
					</asp:DropDownList>
				</td>
				<td style="float: left; padding-left: 15px;">
					<input type="button" class="btn btn-success" onclick="javascript: location.href = 'CadastroOcorrencia.aspx';" value="Cadastrar" />
					<asp:Button ID="btnConsultarOcorrencias" CssClass="btn btn-primary" Style="margin-top: 10px; margin-bottom: 10px;" runat="server" OnClick="ConsultarOcorrencias" Text="Minhas Ocorrencias" />
				</td>
			</tr>
		</table>
	</div>
	<style>
		.itemTamplate {
			height: 300px;
			width: 100%;
			padding-left: 10px;
			border: 1px solid #f5be32;
			margin-bottom: 30px;
			margin-top: 25px;
			background-color: #f5be32;
			border-radius: 5px;
		}

		.itemDois {
			height: 300px;
			width: 100%;
			padding-left: 10px;
			border: 1px solid #f5be32;
			margin-bottom: 30px;
			margin-top: 25px;
			background: #FCE797;
			border-radius: 5px;
		}
	</style>

	<asp:Repeater ID="rptAnimal" runat="server">
		<HeaderTemplate>
			<div style="margin-top: 58px;">
		</HeaderTemplate>
		<ItemTemplate>
			<div class="itemTamplate">
				<h3><%# DataBinder.Eval(Container.DataItem, "SITUACAO") %><p />
				</h3>
				<img src="../Images/Animais/<%# DataBinder.Eval(Container.DataItem, "CAMINHO") %>" height="240" width="240" align="left" style="margin-right: 10px" /><p />
				<b>Tipo do animal:</b> <%# DataBinder.Eval(Container.DataItem, "ANIMAL") %><p />
				<b>Cor:</b> <%# DataBinder.Eval(Container.DataItem, "COR") %><p />
				<b>Porte:</b> <%# DataBinder.Eval(Container.DataItem, "PORTE") %><p />
				<b>Local onde o animal foi <%# DataBinder.Eval(Container.DataItem, "SITUACAO") %>:</b> <%# DataBinder.Eval(Container.DataItem, "RUA") %>, Nº 
                <%# DataBinder.Eval(Container.DataItem, "NUMERO") %>, <%# DataBinder.Eval(Container.DataItem, "BAIRRO") %>, 
                <%# DataBinder.Eval(Container.DataItem, "CIDADE") %>
				<%# DataBinder.Eval(Container.DataItem, "ESTADO") %><p />
				<b>Contato:</b> <%# DataBinder.Eval(Container.DataItem, "NOME") %><p />
				<b>Email:</b> <%# DataBinder.Eval(Container.DataItem, "EMAIL") %>
				<div style="width: 50%">
					<b>Descrição:</b>
					<p style="float: right;"><%# DataBinder.Eval(Container.DataItem, "DESCRICAO") %></p>
				</div>
			</div>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<div class="itemDois">
				<h3><%# DataBinder.Eval(Container.DataItem, "SITUACAO") %><p />
				</h3>
				<img src="../Images/Animais/<%# DataBinder.Eval(Container.DataItem, "CAMINHO") %>" height="240" width="240" align="left" style="margin-right: 10px" /><p />
				<b>Tipo do animal:</b> <%# DataBinder.Eval(Container.DataItem, "ANIMAL") %><p />
				<b>Cor:</b> <%# DataBinder.Eval(Container.DataItem, "COR") %><p />
				<b>Porte:</b> <%# DataBinder.Eval(Container.DataItem, "PORTE") %><p />
				<b>Local onde o animal foi <%# DataBinder.Eval(Container.DataItem, "SITUACAO") %>:</b> <%# DataBinder.Eval(Container.DataItem, "RUA") %>, Nº 
                <%# DataBinder.Eval(Container.DataItem, "NUMERO") %>, <%# DataBinder.Eval(Container.DataItem, "BAIRRO") %>, 
                <%# DataBinder.Eval(Container.DataItem, "CIDADE") %>
				<%# DataBinder.Eval(Container.DataItem, "ESTADO") %><p />
				<b>Contato:</b> <%# DataBinder.Eval(Container.DataItem, "NOME") %><p />
				<b>Email:</b> <%# DataBinder.Eval(Container.DataItem, "EMAIL") %>
				<div style="width: 50%">
					<b>Descrição:</b>
					<p style="float: right;"><%# DataBinder.Eval(Container.DataItem, "DESCRICAO") %></p>
				</div>
			</div>
		</AlternatingItemTemplate>
		<FooterTemplate>
			</div>
		</FooterTemplate>
	</asp:Repeater>
</asp:Content>

