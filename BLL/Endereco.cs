using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace BLL
{
    public class Endereco
    {

        #region Propriedades

        public int ID_ENDERECO { get; set; }
        public string LOGRADOURO { get; set; }
        public int NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public int ID_CIDADE { get; set; }
        public int ID_ESTADO { get; set; }

        #endregion


    }
}
