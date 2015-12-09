using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using DAL;

namespace BLL
{
	public class Cidade : Conexao
	{

        public string Codigo { get; set; }
        public string Descricao { get; set; }

		#region Métodos

        public System.Data.DataSet RecuperarCidades(string strEstado)
        {
            try
            {
                AbrirConexao();
                string sql = ("SELECT * FROM CIDADE WHERE ESTADO = @ESTADO ORDER BY NOME");
                Cmd = new SqlCommand(sql, Con);
                Cmd.Parameters.AddWithValue("@ESTADO", strEstado);
                DataSet dsCidade = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
                adp.Fill(dsCidade, "CIDADE");

                return dsCidade;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar as Cidades: " + ex.Message);
            }
            finally
            {
                FecharConexao();

            }
        }

		#endregion
	}
}
