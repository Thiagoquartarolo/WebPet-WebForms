using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace _webCamadaUI.Procurase
{
    public partial class Default : System.Web.UI.Page
    {

        #region Acao

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

            if (!IsPostBack)
            {
                PreencherSelects();
            }

            string estado = "%", cidade = "%", porte = "%", raca = "%", status = "%", tipo = "%", cor = "%";
            
            OcorrenciaBLL ani = new OcorrenciaBLL();
            if (ddlEstado.SelectedIndex > 0)
            { estado = ddlEstado.SelectedItem.Text; }
            if (ddlCidade.SelectedIndex > 0)
            { cidade = ddlCidade.SelectedItem.Text; }
            if (dllPorte.SelectedIndex > 0)
            { porte = dllPorte.SelectedItem.Text; }
            if (dllRaca.SelectedIndex > 0)
            { raca = dllRaca.SelectedItem.Text; }
            if (dllStatus.SelectedIndex > 0)
            { status = dllStatus.SelectedItem.Text; }
            if (dllTipo.SelectedIndex > 0)
            { tipo = dllTipo.SelectedItem.Text; }
            if (ddlCor.SelectedIndex > 0)
            { cor = ddlCor.SelectedItem.Text; }

            rptAnimal.DataSource = ani.getOcorrencia(estado, status, tipo, raca, porte, cor, cidade);
            rptAnimal.DataBind();           

        }

        protected void ConsultarOcorrencias(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarOcorrencias.aspx");
        }

        #endregion

        #region Metodos

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

        public void getStatus()
        {
            Status status = new Status()
            {
                ID_STATUS = "",
                DESCRICAO = "Selecione..."
            };
            DataSet ds = status.RetornarStatus();
            DataRowCollection rows = ds.Tables[0].Rows;
            List<Status> listaStatus = new List<Status>();
            listaStatus.Add(status);

            foreach (DataRow row in rows)
            {
                Status newStatus = new Status()
                {
                    ID_STATUS = row[0].ToString(),
                    DESCRICAO = row[1].ToString()
                };
                listaStatus.Add(newStatus);
            }

            ddlCor.DataValueField = "ID_STATUS";
            ddlCor.DataTextField = "DESCRICAO";
            ddlCor.DataSource = listaStatus;
            ddlCor.DataBind();
        }

        private void PreencherSelects()
        {
            getStatus();
            getTipoAnimal();
            getCor();
            getPorte();
            CarregarEstados();
        }

        #endregion

    }
}