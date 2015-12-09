<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sonserina.EscritorioDeProjetos.WebPet.Mural.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="validarErro" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="editar-campos-principais" />
    <div style="padding-top: 150px; margin-left:10px; height: 100%;">
        <div id="title">
            <p>
             <h2>Deixe aqui sua mensagem, duvida, sugestão... Este é um espaço para colaboração de dicas, eventos entre outras curiosidade.</h2>
            </p>
        </div>
        <div id="Mensagem">
            <div>
               <b> Mensagem :</b><br />
                <asp:TextBox ID="TextArea" TextMode="multiline" Columns="00" Rows="7" maxlength="500" runat="server" Height="110px" Width="920px" />
                <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                    ControlToValidate="TextArea" ID="RequiredFieldValidator1" runat="server" Text=" * "
                    Display="Dynamic" ErrorMessage="O campo Mensagem é obrigatório!."
                    Style="color: red; display: inline; float: left;">
                </asp:RequiredFieldValidator>
            </div>
            <br />

            <asp:Button ID="btnEnviar" class="btn btn-inverse" runat="server" Text="Enviar" OnClick="EnviarMensagem" ValidationGroup="editar-campos-principais" /><br />
        </div>
        <br />
        &nbsp;<br />
        <div id="listaMural">
            <asp:ListView ID="lvMural" runat="server">
                <EmptyDataTemplate>
                    <tr>
                        <td>Não Existe Registros no Mural</td>
                    </tr>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div style="border-radius: 5px; border: 1px solid; background: #f5be32; padding-left: 10px;margin-bottom:10px;">
                        <tr>
                            <td><b>Data da Publicação: </b><%#Eval("DATA_MENSAGEM","{0:dd/MM/yyyy}")%><br />
                            </td>
                            <td><b>Nome: </b><%#Eval("NOME")%></td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Label name="mensagem" runat="server" Text="Mensagem :" Font-Bold="True" /><p><%#Eval("MENSAGEM")%></p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">&nbsp;</td>
                        </tr>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div style="border-radius: 5px; border: 1px solid; background: #ffffff; padding-left: 10px;margin-bottom:10px;">
                        <tr>
                            <td><b>Data da Publicação: </b><%#Eval("DATA_MENSAGEM","{0:dd/MM/yyyy}")%><br />
                            </td>
                            <td><b>Nome: </b><%#Eval("NOME")%></td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Label name="mensagem" runat="server" Text="Mensagem :" Font-Bold="True" /><p><%#Eval("MENSAGEM")%></p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">&nbsp;</td>
                        </tr>
                    </div>
                </AlternatingItemTemplate>
            </asp:ListView>
        </div>
        <br />
    </div>
</asp:Content>
