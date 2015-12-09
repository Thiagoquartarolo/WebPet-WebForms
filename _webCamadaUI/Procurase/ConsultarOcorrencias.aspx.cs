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
    public partial class ConsultarOcorrencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated != true)
                Response.Redirect("~/Login/Default.aspx");

            buscarOcorrencias();
        }

        private void buscarOcorrencias()
        {
            OcorrenciaBLL ocorrencia = new OcorrenciaBLL();
            int ID_USUARIO = (int)(Session["ID_USUARIO"]);
            rptAnimal.DataSource = ocorrencia.getOcorrenciaUsuario(ID_USUARIO);
            rptAnimal.DataBind();
        }

        public string FormatarTextoAtivo(object temaAtivo)
        {
            string texto = "Não";

            if (temaAtivo != null)
            {
                bool ativo = false;
                bool.TryParse(temaAtivo.ToString(), out ativo);

                if (ativo)
                    texto = "Sim";
            }

            return texto;
        }

    }
}