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
    public class DadosOcorrencia : Conexao
    {
        public int ID_USUARIO { get; set; }
        public int ID_OCORRENCIA { get; set; }
        public int ID_ENDERECO { get; set; }
        public string SITUACAO { get; set; }
        public string ANIMAL { get; set; }
        public string RACA { get; set; }
        public string COR { get; set; }
        public string PORTE { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string CAMINHO { get; set; }
        public string DATA_OCORRENCIA { get; set; }
        public string RUA { get; set; }
        public string NUMERO { get; set; }
        public string DESCRICAO { get; set; }
		public bool ATIVO { get; set; }
    }
}
