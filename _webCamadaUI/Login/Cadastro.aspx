<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="_webCamadaUI.Login.Cadastro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cadastroUsuario {
            border-radius: 5px;
        }

        #logoWebpet {
            margin-top: 0;
            float: left;
            position: absolute;
            margin-left: 893px;
            margin-top: -16px;
        }

        #Cadastrase {
            margin-top: 22px;
        }
    </style>
    <script>
        $(".cat_navbar").hide();
    </script>
    <asp:ValidationSummary ID="validarErro" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="editar-campos-principais" />
    <div>
        <div>
            <div id="Cadastrase">
                <h3>Cadastra-se</h3>
                Preencha seus dados abaixo para fazer seu cadastro no WebPet e aproveitar todos os benefícios.<br />
            </div>
            <div style="border-top: 1px solid #000; padding-top: 39px; margin-top: 20px;">
                <h3>Dados Pessoais</h3>
                <div class="colunaEsquerda" style="float: left;">
                    Nome:<br />
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtNome" ID="RequiredFieldValidator1" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Nome é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Sobrenome:<br />
                    <asp:TextBox ID="txtSobrenome" runat="server" placeholder="Sobrenome" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtSobrenome" ID="RequiredFieldValidator2" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Sobrenome é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Email:<br />
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtEmail" ID="RequiredFieldValidator3" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Email é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Telefone:<br />
                    <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtTelefone" ID="RequiredFieldValidator4" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Telefone é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Senha:<br />
                    <asp:TextBox ID="txtSenha" type="password" runat="server" placeholder="Senha" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtSenha" ID="RequiredFieldValidator10" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Senha é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
                <div class="colunaDireita" style="float: right; margin-right: 50px;">
                    Logradouro:<br />
                    <asp:TextBox ID="txtLogradouro" runat="server" placeholder="Logradouro" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtLogradouro" ID="RequiredFieldValidator5" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Lougradouro é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Numero:<br />
                    <asp:TextBox ID="txtNumero" runat="server" placeholder="Numero" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtNumero" ID="RequiredFieldValidator6" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Número é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />

                    Bairro:<br />
                    <asp:TextBox ID="txtBairro" runat="server" placeholder="Bairro" Width="300" CssClass="cadastroUsuario" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ValidationGroup="editar-campos-principais"
                        ControlToValidate="txtBairro" ID="RequiredFieldValidator7" runat="server" Text=" * "
                        Display="Dynamic" ErrorMessage="O campo Bairro é obrigatório!."
                        Style="color: red; display: inline; float: left;">
                    </asp:RequiredFieldValidator>
                    <br />


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


                    <asp:Button ID="btnCadastrar" runat="server" class="btn btn-success" Text="Cadastrar" OnClick="CadastrarCliente" ValidationGroup="editar-campos-principais"/>
                    <input type="button" class="btn btn-primary" onclick="javascript: window.history.go(-1);" value="Voltar" />
                    <p>
                        <asp:Label ID="lblmsg" runat="server" Visible="false" />
                    </p>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>

</asp:Content>



