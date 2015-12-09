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
    public class TipoAnimal : Conexao
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public DataSet RecuperarTipoAnimais()
        {
            try
            {

                AbrirConexao();
                //Utilizando uma Stored Procedure
                string stProc = ("PR_SE_TIPOANIMAL");

                //Instanciando o comando no DB, informando o comando(string acima) e a conexão(aberta anteriormente)
                Cmd = new SqlCommand(stProc,Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                
                //Instanciando um DataSet (o que é dataset?)
                DataSet dsTipoAnimal = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
                adp.Fill(dsTipoAnimal);

                return dsTipoAnimal;

            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao listar Tipo de Animais" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
