using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using DAL;


namespace BLL {
    public class Usuario : Conexao
    {

        #region Propriedades

        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string ID_ENDERECO { get; set; }
        public string TELEFONE { get; set; }

        #endregion
        

    }
}
