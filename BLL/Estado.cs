using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Estado : Conexao
    {

        public string Codigo { get; set; }
        public string Descricao { get; set; }

        #region Métodos

        public System.Data.DataSet RecuperarEstados()
        {
            try
            {
                AbrirConexao();
                string sql = ("SELECT * FROM ESTADO ORDER BY UF");
                Cmd = new SqlCommand(sql, Con);
                DataSet dsEstados = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
                adp.Fill(dsEstados, "ESTADO");

                return dsEstados;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar os Estados: " + ex.Message);
            }
            finally
            {
                FecharConexao();

            }
        }

        #endregion
    }
}
