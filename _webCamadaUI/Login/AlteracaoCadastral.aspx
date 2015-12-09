<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AlteracaoCadastral.aspx.cs" Inherits="_webCamadaUI.Login.AlteracaoCadastral" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="validarErro" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="editar-campos-principais" />
    <div style="margin-top:100px;margin-left:50px;">
        <div>
            <div>
                <h3>Alteração de Cadastro de Usuário</h3>

                <asp:TextBox ID="txtIdUser" runat="server" Visible="false" />
                <asp:TextBox ID="txtIdEnd" runat="server" Visible="false" />


                <div>
                    Nome:<br />
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtNome" ID="RequiredFieldValidator1" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Nome é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Sobrenome:<br />
                    <asp:TextBox ID="txtSobrenome" runat="server" placeholder="Nome" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtSobrenome" ID="RequiredFieldValidator2" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Sobrenome é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Email:<br />
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtEmail" ID="RequiredFieldValidator3" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Email é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Telefone:<br />
                    <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtTelefone" ID="RequiredFieldValidator4" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Telefone é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Logradouro:<br />
                    <asp:TextBox ID="txtLogradouro" runat="server" placeholder="Logradouro" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtLogradouro" ID="RequiredFieldValidator5" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Lougradouro é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Numero:<br />
                    <asp:TextBox ID="txtNumero" runat="server" placeholder="Numero" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtNumero" ID="RequiredFieldValidator6" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Número é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Bairro:<br />
                    <asp:TextBox ID="txtBairro" runat="server" placeholder="Bairro" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtBairro" ID="RequiredFieldValidator7" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Bairro é obrigatório!."
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
                        ControlToValidate="ddlEstado" ID="RequiredFieldValidator8" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Estado é obrigatório!."
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
                        ControlToValidate="ddlCidade" ID="RequiredFieldValidator9" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Cidade é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                </div>
                <div>
                    Senha:<br />
                    <asp:TextBox ID="txtSenha" type="password" runat="server" placeholder="Senha" Width="45%" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtSenha" ID="RequiredFieldValidator10" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Senha é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
                <asp:Button ID="btnCadastrar" runat="server" CssClass="btn btn-success" Text="Cadastrar" OnClick="AtualizarUsuario" ValidationGroup="editar-campos-principais" />
                <input type="button" class="btn btn-primary" onclick="javascript: window.history.go(-1);" value="Voltar" />
                <p>
                    <asp:Label ID="lblmsg" runat="server"  Visible="false" />
                </p>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
