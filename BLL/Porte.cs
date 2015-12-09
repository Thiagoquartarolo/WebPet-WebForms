using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Porte : Conexao
    {
        public string ID { get; set; }
        public string descricao { get; set; }

        public Porte(string ID, string descricao)
        {
            this.ID = ID;
            this.descricao = descricao;
        }

        public DataSet RecuperarPorte()
        {
            try
            {
                AbrirConexao();
                string sql = "SELECT * FROM PORTE";
                SqlCommand cmd;
                SqlDataAdapter ad;
                DataSet ds;

                cmd = new SqlCommand(sql, Con);
                ds = new DataSet("dsPorte");
                ad = new SqlDataAdapter((SqlCommand)cmd);

                ad.Fill(ds,"PORTE");

                return ds;
            }

            catch(Exception ex)
            {
                throw new Exception("Erro ao Recuperar o porte do animal " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    
    }
}
