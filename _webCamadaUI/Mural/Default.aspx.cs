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

namespace Sonserina.EscritorioDeProjetos.WebPet.Mural
{
    public partial class Default : System.Web.UI.Page
    {
        #region Propriedades

        MuralBLL _entidade = new MuralBLL();
        DataRow representacao;
        public MuralBLL Entidade
        {
            get
            {
                if (_entidade == null)
                    _entidade = new MuralBLL();

                return _entidade;
            }
        }
        #endregion

        #region acao

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

            CarregarMensagens();

        }

        protected void EnviarMensagem(object sender, EventArgs e)
        {
            MuralBLL mural = new MuralBLL();

            string nome = (string)(Session["NOME"]);
            string sobrenome = (string)(Session["SOBRENOME"]);
            mural.NOME = nome +" "+ sobrenome;
            mural.MENSAGEM = TextArea.Text;
            mural.DATA_MENSAGEM = DateTime.Now;

            if (Entidade.GravarMensagem(mural))
            {
                Response.Write(@"<script language='javascript'>alert('Mensagem enviada com sucesso.');</script>");
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Ocorreu um erro durante o envio da mensagem. Tente novamente mais tarde.');</script>");
            }

            TextArea.Text = "";
            CarregarMensagens();
        }

        protected void CarregarMensagens()
        {
            lvMural.DataSource = Entidade.AtualizarMensagens();
            lvMural.DataBind();
        }

        #endregion
    }
}