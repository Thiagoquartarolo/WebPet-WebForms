using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DAL;

namespace BLL
{
    public class Ocorrencia : Conexao
    {
        public int ID_OCORRENCIA { get; set; }
        public int ID_STATUS { get; set; }
        public int ID_COR { get; set; }
        public int ID_RACA { get; set; }
        public int ID_ENDERECO { get; set; }
        public int ID_PORTE { get; set; }
        public int ID_IMAGEM { get; set; }
        public string DESCRICAO_OCORRENCIA { get; set; }
        public DateTime DATA_OCORRENCIA { get; set; }
        public int ATIVO { get; set; }
    }
}
