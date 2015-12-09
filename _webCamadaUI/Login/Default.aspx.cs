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

namespace Sonserina.EscritorioDeProjetos.WebPet.Login {
	public partial class Default : System.Web.UI.Page {

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

            }
		}

        protected void LogarUsuario(object sender, EventArgs e)
        {
            Session["EmailLogin"] = txtEmail.Text;

            if (new UsuarioBLL().LogarUsuario(txtEmail.Text, txtSenha.Text, Persist.Checked) == true)
                FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, Persist.Checked);
            else
                lblmsg.Text = "Usuário e/ou senha incorretos!";

        }

        protected void CadastrarUsuario(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/Cadastro.aspx");
        }
	}
}

