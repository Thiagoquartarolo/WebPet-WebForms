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

namespace _webCamadaUI.Procurase
{
    public partial class EditarOcorrencia : System.Web.UI.Page
    {

        #region Propriedades
        private OcorrenciaBLL Entidade = new OcorrenciaBLL();
        DataRow representacao;

        int ID_OCORRENCIA
        {
            get
            {
                try
                {
                    string ocorrencia = Request.QueryString["ID_OCORRENCIA"].ToString();
                    int id_ocorrencia = int.Parse(ocorrencia);
                    return id_ocorrencia;
                }
                catch
                {
                    return 0;
                }
            }
        }

        int ID_USUARIO
        {
            get
            {
                try
                {
                    int usr = (int)Session["ID_USUARIO"];
                    return usr;
                }
                catch
                {
                    return 0;
                }
            }
        }

        #endregion

        #region acao

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

            if (!IsPostBack)
            {
				representacao = Entidade.ConsultarOcorrencia(ID_OCORRENCIA, ID_USUARIO);
                PreencherSelects();
				PreencherDados();
               
            }
        }

        protected void CadastrarOcorrencia(object sender, EventArgs e)
        {
            Ocorrencia ocorrencia = new Ocorrencia();
            Endereco endereco = new Endereco();

			ocorrencia.ID_OCORRENCIA = int.Parse(txtID_OCORRENCIA.Text);
            ocorrencia.ID_STATUS = int.Parse(dllStatus.SelectedValue);
            ocorrencia.ID_RACA = int.Parse(dllRaca.SelectedValue);
            ocorrencia.ID_COR = int.Parse(ddlCor.SelectedValue);
            ocorrencia.ID_PORTE = int.Parse(dllPorte.SelectedValue);
            ocorrencia.DESCRICAO_OCORRENCIA = txtDescricao.Text;
            endereco.ID_ENDERECO = int.Parse(txtID_ENDERECO.Text);
            endereco.LOGRADOURO = txtLogradouro.Text;
            endereco.NUMERO = int.Parse(txtNumero.Text);
            endereco.BAIRRO = txtBairro.Text;
            endereco.ID_CIDADE = int.Parse(ddlCidade.SelectedValue);
            endereco.ID_ESTADO = int.Parse(ddlEstado.SelectedValue);

            if (Entidade.AtualizarOcorrencia(ocorrencia, endereco, chbAtivo.Checked))
            {
                LimparCampos();
                Response.Write(@"<script language='javascript'>alert('Atualização de ocorrência realizada com sucesso.');</script>");
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Ocorreu um erro durante a atualização da ocorrência, tente novamente mais tarde.');</script>");
            }

        }

        #endregion

        #region Metodos

        public void LimparCampos()
        {
            dllStatus.SelectedValue = "";
            dllRaca.SelectedValue = "";
            ddlCor.SelectedValue = "";
            dllPorte.SelectedValue = "";
            txtDescricao.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            ddlCidade.SelectedValue = "";
            ddlEstado.SelectedValue = "";
			chbAtivo.Checked = false;
        }

        private void PreencherDados()
        {
			txtID_ENDERECO.Text = representacao["ID_ENDERECO"].ToString();
			txtID_OCORRENCIA.Text = representacao["ID_OCORRENCIA"].ToString();

            txtDescricao.Text = representacao["DESCRICAO"].ToString();
            txtLogradouro.Text = representacao["RUA"].ToString();
            txtNumero.Text = representacao["NUMERO"].ToString();
            txtBairro.Text = representacao["BAIRRO"].ToString();
            chbAtivo.Checked = Convert.ToBoolean(representacao["ATIVO"]);
			Selecionar(ddlEstado, "ESTADO");
			Selecionar(ddlCidade, "CIDADE");
			Selecionar(dllStatus, "SITUAÇÃO");
			Selecionar(dllTipo, "ANIMAL");
			Selecionar(dllRaca, "RAÇA");
			Selecionar(dllPorte, "PORTE");
			Selecionar(ddlCor, "COR");
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
            getTipoAnimal();
			getRacaAnimal(representacao["ANIMAL"].ToString());
			getPorte();
			getCor();
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

        public void getTipoAnimal()
        {
            TipoAnimal tipoAnimal = new TipoAnimal()
            {
                Codigo = "",
                Descricao = "Selecione"

            };

            List<TipoAnimal> listaAnimais = new List<TipoAnimal>();

            DataSet ds = tipoAnimal.RecuperarTipoAnimais();

            DataRowCollection linhas = ds.Tables[0].Rows;

            listaAnimais.Add(tipoAnimal);
            foreach (DataRow linha in linhas)
            {
                TipoAnimal nova = new TipoAnimal()
                {
                    Codigo = linha["ID_TIPO"].ToString(),
                    Descricao = linha["DESCRICAO"].ToString()
                };
                listaAnimais.Add(nova);
            }
            dllTipo.DataValueField = "codigo";
            dllTipo.DataTextField = "descricao";
            dllTipo.DataSource = listaAnimais;
            dllTipo.DataBind();
        }

        protected void getRacaAnimal(string ID_TIPO_RACA)
        {
            //Instanciando o classe da BLL 
            Raca raca = new Raca()
            {
                ID = "",
                descricao = "Selecione",

            };

            //Criando uma lista para pegar os itens do dataset e colocar no dll
            List<Raca> listaRacas = new List<Raca>();

            //Criando um dataset o instanciando com o dataset da Bll,
            DataSet dsRacas = raca.RecuperarRaca(ID_TIPO_RACA);

            //?
            DataRowCollection linhas = dsRacas.Tables[0].Rows;
            listaRacas.Add(raca);

            foreach (DataRow linha in linhas)
            {
                Raca novaRaca = new Raca()
                {
                    ID = linha["ID_RACA"].ToString(),
                    descricao = linha["DESCRICAO_RACA"].ToString(),
                };
                listaRacas.Add(novaRaca);
            }
            dllRaca.DataValueField = "ID";
            dllRaca.DataTextField = "descricao";
            dllRaca.DataSource = listaRacas;
            dllRaca.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dllRaca.Items.Clear();
            getRacaAnimal(dllTipo.SelectedValue);
        }

		public void getPorte()
		{
			List<Porte> listaPorte = new List<Porte>();
			Porte porteSelecione = new Porte("", "Selecione");

			DataSet ds = porteSelecione.RecuperarPorte();
			DataRowCollection linhas = ds.Tables[0].Rows;

			listaPorte.Add(porteSelecione);

			foreach (DataRow linha in linhas)
			{
				Porte novoPorte = new Porte(linha[0].ToString(), linha[1].ToString());
				listaPorte.Add(novoPorte);
			}

			dllPorte.DataValueField = "ID";
			dllPorte.DataTextField = "descricao";
			dllPorte.DataSource = listaPorte;
			dllPorte.DataBind();
		}

		public void getCor()
		{
			Cor cor = new Cor()
			{
				id = "",
				des = "Selecione..."
			};
			DataSet ds = cor.RetornarCor();
			DataRowCollection rows = ds.Tables[0].Rows;
			List<Cor> listaCor = new List<Cor>();
			listaCor.Add(cor);

			foreach (DataRow row in rows)
			{
				Cor newCor = new Cor()
				{
					id = row[0].ToString(),
					des = row[1].ToString()
				};
				listaCor.Add(newCor);
			}

			ddlCor.DataValueField = "id";
			ddlCor.DataTextField = "des";
			ddlCor.DataSource = listaCor;
			ddlCor.DataBind();

		}

        #endregion
    }
}