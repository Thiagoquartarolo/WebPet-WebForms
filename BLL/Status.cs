using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Status : Conexao
    {
        public string ID_STATUS { get; set; }
        public string DESCRICAO { get; set; }

        public DataSet RetornarStatus()
        {
            try
            {
                AbrirConexao();
                SqlCommand cmd = new SqlCommand("SELECT * FROM STATUS", Con);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter((SqlCommand)cmd);
                ad.Fill(ds);

                return ds;

            }
            catch(Exception ex)
            {
                throw new Exception( "Erro ao verificar o status" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }


        }
    }
}
