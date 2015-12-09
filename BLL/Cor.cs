using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Cor : Conexao
    {
        public string id { get; set; }
        public string des { get; set; }

        public DataSet RetornarCor()
        {
            try
            {
                AbrirConexao();
                SqlCommand cmd = new SqlCommand("SELECT * FROM COR", Con);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter((SqlCommand)cmd);
                ad.Fill(ds);

                return ds;

            }
            catch(Exception ex)
            {
                throw new Exception( "Erro ao verificar a cor" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }


        }
    }
}
