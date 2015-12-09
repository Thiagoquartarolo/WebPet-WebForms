<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarOcorrencias.aspx.cs" Inherits="_webCamadaUI.Procurase.ConsultarOcorrencias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .itemTamplate {
            height: 330px;
            width: 100%;
            padding-left: 10px;
            border: 1px solid #f5be32;
            margin-bottom: 30px;
            margin-top: 25px;
            background-color: #f5be32;
            border-radius: 5px;
        }

        .itemDois {
            height: 330px;
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
            <div style="margin-top: 119px;">
        </HeaderTemplate>
        <ItemTemplate>
            <div style="margin-left: 888px;margin-top: -35px;">
                <input type="button" class="btn btn-primary" onclick="javascript: window.history.go(-1);" value="Voltar" />
            </div>
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
                <div style="width: 100%">
                    <b>Descrição:</b><%# DataBinder.Eval(Container.DataItem, "DESCRICAO") %></p>
					<b>Ativo no sistema:</b> <%# FormatarTextoAtivo(DataBinder.Eval(Container.DataItem, "ATIVO")) %><p />
                    <a href="EditarOcorrencia.aspx?ID_OCORRENCIA=<%# DataBinder.Eval(Container.DataItem, "ID_OCORRENCIA") %>">
                        <input type="button" class="btn btn-inverse" value="Editar" /></a>
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
                <div style="width: 100%">
                    <b>Descrição:</b><%# DataBinder.Eval(Container.DataItem, "DESCRICAO") %></p>
					<b>Ativo no sistema:</b> <%# FormatarTextoAtivo(DataBinder.Eval(Container.DataItem, "ATIVO")) %><p />
                    <a href="EditarOcorrencia.aspx?ID_OCORRENCIA=<%# DataBinder.Eval(Container.DataItem, "ID_OCORRENCIA") %>">
                        <input type="button" class="btn btn-inverse" value="Editar" /></a>
                </div>
            </div>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
