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

namespace Sonserina.EscritorioDeProjetos.WebPet.MasterPages
{
    public partial class Default : System.Web.UI.Page
    {
        #region Propriedades

        UsuarioBLL _entidade = new UsuarioBLL();
        DataRow representacao;
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
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

            MontarSession();
        }

        public void MontarSession()
        {
            string EMAIL = (string)(Session["EmailLogin"]);
            representacao = Entidade.RecuperarUsuario(EMAIL);

            Session["ID_USUARIO"] = representacao["ID_USUARIO"];
            Session["ID_ENDERECO"] = representacao["ID_ENDERECO"].ToString();
            Session["NOME"] = representacao["NOME"].ToString();
            Session["SOBRENOME"] = representacao["SOBRENOME"].ToString();
            Session["TELEFONE"] = representacao["TELEFONE"].ToString();

        }
    }
}