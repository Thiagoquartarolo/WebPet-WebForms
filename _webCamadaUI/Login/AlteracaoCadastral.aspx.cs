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
	public partial class AlteracaoCadastral : System.Web.UI.Page
	{

		#region Propriedades

		private UsuarioBLL Entidade = new UsuarioBLL();
		DataRow representacao;
		#endregion

		#region acao

		protected void Page_Load(object sender, EventArgs e)
		{
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

			if (!IsPostBack)
			{
				string EMAIL = (string)(Session["EmailLogin"]);

				representacao = Entidade.RecuperarUsuario(EMAIL);
				PreencherSelects();
				PreencherDados();
			}
		}

		protected void AtualizarUsuario(object sender, EventArgs e)
		{
			Usuario usr = new Usuario();
			Endereco end = new Endereco();

			usr.ID_USUARIO = int.Parse(txtIdUser.Text);
			usr.ID_ENDERECO = txtIdEnd.Text;
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

			if (Entidade.SalvarUsuario(usr, end))
			{
                Response.Write(@"<script language='javascript'>alert('Atualização realizada com sucesso.');</script>");
			}
			else
			{
                Response.Write(@"<script language='javascript'>alert('Ocorreu um erro durante a atualização, tente novamente mais tarde.');</script>");
			}
		}

		#endregion

		#region Metodos

		private void PreencherDados()
		{
			txtIdUser.Text = representacao["ID_USUARIO"].ToString();
			txtIdEnd.Text = representacao["ID_ENDERECO"].ToString();
			txtNome.Text = representacao["NOME"].ToString();
			txtSobrenome.Text = representacao["SOBRENOME"].ToString();
			txtEmail.Text = representacao["EMAIL"].ToString();
			txtTelefone.Text = representacao["TELEFONE"].ToString();
			txtSenha.Text = representacao["SENHA"].ToString();
			txtLogradouro.Text = representacao["LOGRADOURO"].ToString();
			txtNumero.Text = representacao["NUMERO"].ToString();
			txtBairro.Text = representacao["BAIRRO"].ToString();
			Selecionar(ddlEstado, "ESTADO");
			ddlCidade.SelectedValue = representacao["CIDADE"].ToString();

		}

		private void Selecionar(DropDownList ddl, string name)
		{
			string valor = representacao[name].ToString();
			ddl.SelectedValue = valor;
			if (ddl.SelectedValue == "")
			{
				ddl.Items.Add(new ListItem(valor, valor));
				ddl.SelectedValue = valor;
			}
		}

		private void PreencherSelects()
		{
			CarregarEstados();
			CarregarCidades(representacao["ESTADO"].ToString());
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

		protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
		{
			ddlCidade.Items.Clear();
			CarregarCidades(ddlEstado.SelectedValue);
		}

		#endregion
	}
}