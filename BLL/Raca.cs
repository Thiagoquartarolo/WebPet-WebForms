using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Raca : Conexao
    {
        public string ID { get; set; }
        public string descricao { get; set; }
        
        public DataSet RecuperarRaca(string ID_TIPO_RACA)
        {
            try
            {
                //Abrindo a conexão
                AbrirConexao();
                //Criando um DataSet
                DataSet dsRecuRaca = new DataSet();
                //Criando um SqlComand
                SqlCommand Cmd = new SqlCommand("PR_SE_RACA", Con);
                //Definindo o SQLCommand como uma Store Procedure
                Cmd.CommandType = CommandType.StoredProcedure;
                //Adicionando o parametro da procedure
                Cmd.Parameters.AddWithValue("@ID_TIPO", ID_TIPO_RACA);
                //Criando um DataAdapter
                SqlDataAdapter daRaca = new SqlDataAdapter((SqlCommand)Cmd);
                //Enchendo o dataset via o dataadapter
                daRaca.Fill(dsRecuRaca, "Racas");

                return dsRecuRaca;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Listar as raças dos animais: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
