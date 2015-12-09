<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CadastroOcorrencia.aspx.cs" Inherits="_webCamadaUI.Procurase.CadastroOcorrencia" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="validarErro" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="editar-campos-principais" />
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.validation.js"></script>
    <div class="container">
        <div class="row row-centered" id="tudo">
            <div id="formulario" style="margin-left: 320px; padding-top: 100px;">
                <h1>Cadastre o animal
                    <!--inputar pelo banco ó status dele(perdido, achado) -->
                </h1>
            </div>

            <div style="float: right;">
                <h3>Informações sobre o animal</h3>
                <div>
                    Status da Ocorrência:<br />
                    <asp:DropDownList ID="dllStatus" runat="server">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                        <asp:ListItem Value="1" Text="Desaparecido"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Encontrado"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="dllStatus" ID="RequiredFieldValidator1" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione o Status da ocorrência."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                </div>
                <div>
                    Tipo de Animal:<br />
                    <asp:DropDownList ID="dllTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="dllTipo" ID="RequiredFieldValidator2" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione o tipo do animal."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Raça do animal:<br />
                    <asp:DropDownList ID="dllRaca" runat="server">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="dllRaca" ID="RequiredFieldValidator3" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione a raça do animal."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Porte do animal:<br />
                    <asp:DropDownList ID="dllPorte" runat="server">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="dllPorte" ID="RequiredFieldValidator4" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione o porte do animal."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Cor do animal:<br />
                    <asp:DropDownList ID="ddlCor" runat="server">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="ddlCor" ID="RequiredFieldValidator5" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione a cor do animal."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Imagem do animal:<br />
                    <asp:FileUpload ID="ImagemUpload" runat="server" />
                    <br />
                </div>
            </div>
            <div style="float: left;">
                <h3>Endereço da ocorrência
                    <!--inputar pelo banco ó status-->
                </h3>

                <div>
                    Logradouro:<br />
                    <asp:TextBox ID="txtLogradouro" runat="server" placeholder="Rua/Avenida" Width="45%" name="logradouro" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtLogradouro" ID="RequiredFieldValidator6" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo logradouro é obrigatorio!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Número:<br />
                    <asp:TextBox ID="txtNumero" runat="server" placeholder="Número" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtNumero" ID="RequiredFieldValidator7" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo número é obrigatorio!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Bairro:<br />
                    <asp:TextBox ID="txtBairro" runat="server" placeholder="Bairro" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtBairro" ID="RequiredFieldValidator8" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Bairro é obrigatorio!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Estado:<br />
                    <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="ddlEstado" ID="RequiredFieldValidator9" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione o Estado da ocorrência."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Cidade:<br />
                    <asp:DropDownList ID="ddlCidade" runat="server">
                        <asp:ListItem Value="" Text="Selecione..." />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="ddlCidade" ID="RequiredFieldValidator10" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, selecione a cidade da ocorrência."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Descrição da Ocorrência:<br />
                    <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" CssClass="form-control" Height="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtDescricao" ID="RequiredFieldValidator11" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="Por favor, faça uma breve descrição da ocorrência."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
        </div>
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="CadastrarOcorrencia" CssClass="btn btn-success" ValidationGroup="editar-campos-principais" />
        <input type="button" class="btn btn-primary" onclick="javascript: location.href = 'Default.aspx';" value="Voltar"/>
        <br />
        <p>
            <asp:Label ID="lblmsg" runat="server" Visible="false" />
        </p>
    </div>
</asp:Content>
