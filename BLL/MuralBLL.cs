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
    public class MuralBLL : Conexao
    {
        public string NOME { get; set; }
        public string MENSAGEM { get; set; }
        public DateTime DATA_MENSAGEM { get; set; }

        #region metodos

        public bool GravarMensagem(MuralBLL mural)
        {
            bool resultado;
            try
            {
                AbrirConexao();
                string sql = ("INSERT INTO MURAL VALUES(@MENSAGEM, @NOME, @DATA_MENSAGEM)");
                Cmd = new SqlCommand(sql, Con);
                Cmd.Parameters.AddWithValue("@MENSAGEM", mural.MENSAGEM);
                Cmd.Parameters.AddWithValue("@NOME", mural.NOME);
                Cmd.Parameters.AddWithValue("@DATA_MENSAGEM", mural.DATA_MENSAGEM);
                Cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception ex)
            {
                resultado = false;
                throw new Exception("Erro ao gravar Mensagem: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }

            return resultado;
        }

        public DataSet AtualizarMensagens()
        {
            try
            {
                AbrirConexao();
				string sql = ("SELECT * FROM MURAL ORDER BY DATA_MENSAGEM DESC");
                Cmd = new SqlCommand(sql, Con);
                Cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
                adp.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao carregar mensagens: " + ex.Message);
            }
            finally
            {
                FecharConexao();

            }
        }

        #endregion

    }
}
