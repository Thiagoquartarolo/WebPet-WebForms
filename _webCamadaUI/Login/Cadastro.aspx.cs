using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using BLL;

namespace _webCamadaUI.Login
{
    public partial class Cadastro : System.Web.UI.Page
    {

        #region Propriedades

        UsuarioBLL _entidade = new UsuarioBLL();
        public UsuarioBLL Entidade
        {
            get
            {
                if (_entidade == null)
                    _entidade = new UsuarioBLL();

                return _entidade;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
                CarregarEstados();
			}
        }

        protected void CadastrarCliente(object sender, EventArgs e)
        {
            Usuario usr = new Usuario();
            Endereco end = new Endereco();

            usr.NOME = txtNome.Text;
            usr.SOBRENOME = txtSobrenome.Text;
            usr.EMAIL = txtEmail.Text;
            usr.SENHA = txtSenha.Text;
            usr.TELEFONE = txtTelefone.Text;

            end.LOGRADOURO = txtLogradouro.Text;
            end.NUMERO = int.Parse(txtNumero.Text);
            end.BAIRRO = txtBairro.Text;

            end.ID_CIDADE = int.Parse(ddlCidade.SelectedValue);
            end.ID_ESTADO = int.Parse(ddlEstado.SelectedValue);

            if (Entidade.BuscarUsuario(usr.EMAIL))
            {
                if (Entidade.SalvarUsuario(usr, end))
                {
                    Response.Write(@"<script language='javascript'>alert('Cadastro realizado com sucesso.');</script>");
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Ocorreu um erro durante o cadastro, tente novamente mais tarde.');</script>");
                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Não foi possível efetuar o cadastro. Email já cadastrado.');</script>");
            }
        }

        protected void CarregarCidades(string strEstado)
		{
            Cidade cidade = new Cidade()
            {
                Codigo = "",
                Descricao = "Selecione..."
            };

            List<Cidade> listaCidades = new List<Cidade>();

            DataSet ds = cidade.RecuperarCidades(strEstado);
            DataRowCollection linhas = ds.Tables[0].Rows;

            listaCidades.Add(cidade);
            foreach (DataRow linha in linhas)
            {
                Cidade nova = new Cidade()
                {
                    Codigo = linha["ID_CIDADE"].ToString(),
                    Descricao = linha["NOME"].ToString()
                };
                listaCidades.Add(nova);
            }

            ddlCidade.DataValueField = "Codigo";
            ddlCidade.DataTextField = "Descricao";
            ddlCidade.DataSource = listaCidades;
            ddlCidade.DataBind();
		}

        public void CarregarEstados()
        {
            Estado estado = new Estado()
            {
                Codigo = "",
                Descricao = "Selecione..."
            };

            List<Estado> listaEstados = new List<Estado>();

            DataSet ds = estado.RecuperarEstados();
            DataRowCollection linhas = ds.Tables[0].Rows;

            listaEstados.Add(estado);
            foreach (DataRow linha in linhas)
            {
                Estado nova = new Estado()
                {
                    Codigo = linha["ID_ESTADO"].ToString(),
                    Descricao = linha["UF"].ToString()
                };
                listaEstados.Add(nova);
            }

            ddlEstado.DataValueField = "Codigo";
            ddlEstado.DataTextField = "Descricao";
            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataBind();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCidade.Items.Clear();
            CarregarCidades(ddlEstado.SelectedValue);
        }
    }
}