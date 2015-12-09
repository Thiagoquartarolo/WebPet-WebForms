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
    public class OcorrenciaBLL : Ocorrencia
    {

        public bool SalvarOcorrencia(Usuario usuario, Ocorrencia ocorrencia, Endereco endereco, Imagem img)
        {
            bool resultado;
            try
            {
                GravarOcorrencia(usuario, ocorrencia, endereco, img);
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return resultado;
        }

        public bool AtualizarOcorrencia(Ocorrencia ocorrencia, Endereco endereco, bool ATIVO)
        {
            bool resultado;
            try
            {
                GravarOcorrencia(ocorrencia, endereco, ATIVO);
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
            return resultado;
        }

        public bool GravarOcorrencia(Usuario usuario, Ocorrencia ocorrencia, Endereco endereco, Imagem img)
        {
            bool resultado = false;
            try
            {
                AbrirConexao();
                SqlCommand cmd = new SqlCommand("PR_IN_OCORRENCIA", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.ID_USUARIO);
                cmd.Parameters.AddWithValue("@ID_STATUS", ocorrencia.ID_STATUS);
                cmd.Parameters.AddWithValue("@ID_COR", ocorrencia.ID_COR);
                cmd.Parameters.AddWithValue("@ID_RACA", ocorrencia.ID_RACA);
                cmd.Parameters.AddWithValue("@ID_PORTE", ocorrencia.ID_PORTE);
                cmd.Parameters.AddWithValue("@DESCRICAO_OCORRENCIA", ocorrencia.DESCRICAO_OCORRENCIA);
                cmd.Parameters.AddWithValue("@DATA_OCORRENCIA", ocorrencia.DATA_OCORRENCIA);
                cmd.Parameters.AddWithValue("@ATIVO", 1);
                cmd.Parameters.AddWithValue("@LOGRADOURO", endereco.LOGRADOURO);
                cmd.Parameters.AddWithValue("@NUMERO", endereco.NUMERO);
                cmd.Parameters.AddWithValue("@BAIRRO", endereco.BAIRRO);
                cmd.Parameters.AddWithValue("@ID_CIDADE", endereco.ID_CIDADE);
                cmd.Parameters.AddWithValue("@ID_ESTADO", endereco.ID_ESTADO);
                cmd.Parameters.AddWithValue("@ENDERECO_IMG", img.ENDERECO);

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir a ocorrência " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }

            return resultado;
        }

        public bool GravarOcorrencia(Ocorrencia ocorrencia, Endereco endereco, bool? ATIVO)
        {
            bool resultado = false;
            try
            {
                AbrirConexao();
                SqlCommand cmd = new SqlCommand("PR_UP_OCORRENCIA", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_OCORRENCIA", ocorrencia.ID_OCORRENCIA);
                cmd.Parameters.AddWithValue("@ID_STATUS", ocorrencia.ID_STATUS);
                cmd.Parameters.AddWithValue("@ID_COR", ocorrencia.ID_COR);
                cmd.Parameters.AddWithValue("@ID_RACA", ocorrencia.ID_RACA);
                cmd.Parameters.AddWithValue("@ID_PORTE", ocorrencia.ID_PORTE);
                cmd.Parameters.AddWithValue("@DESCRICAO_OCORRENCIA", ocorrencia.DESCRICAO_OCORRENCIA);
                cmd.Parameters.AddWithValue("@ID_ENDERECO", endereco.ID_ENDERECO);
                cmd.Parameters.AddWithValue("@LOGRADOURO", endereco.LOGRADOURO);
                cmd.Parameters.AddWithValue("@NUMERO", endereco.NUMERO);
                cmd.Parameters.AddWithValue("@BAIRRO", endereco.BAIRRO);
                cmd.Parameters.AddWithValue("@ID_CIDADE", endereco.ID_CIDADE);
                cmd.Parameters.AddWithValue("@ID_ESTADO", endereco.ID_ESTADO);
                cmd.Parameters.AddWithValue("@ATIVO", ATIVO);

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar a ocorrência " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }

            return resultado;
        }

        public List<DadosOcorrencia> getOcorrencia(string estado, string status, string tipo, string raca, string porte, string cor, string cidade)
        {
            AbrirConexao();

            List<DadosOcorrencia> ListaOcorrencia = new List<DadosOcorrencia>();

            SqlCommand cmd = new SqlCommand("PR_SE_DADOS_OCORRENCIA", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            cmd.Parameters.AddWithValue("@STATUS", status);
            cmd.Parameters.AddWithValue("@TIPO", tipo);
            cmd.Parameters.AddWithValue("@RACA", raca);
            cmd.Parameters.AddWithValue("@PORTE", porte);
            cmd.Parameters.AddWithValue("@COR", cor);
            cmd.Parameters.AddWithValue("@CIDADE", cidade);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);

            DataRowCollection linhas = ds.Tables[0].Rows;

            foreach (DataRow linha in linhas)
            {
                DadosOcorrencia novo = new DadosOcorrencia();
                novo.COR = linha["COR"].ToString();
                novo.ANIMAL = linha["ANIMAL"].ToString();
                novo.BAIRRO = linha["BAIRRO"].ToString();
                novo.CAMINHO = linha["CAMINHO"].ToString();
                novo.CIDADE = linha["CIDADE"].ToString();
                novo.DATA_OCORRENCIA = linha["DATA"].ToString();
                novo.EMAIL = linha["EMAIL"].ToString();
                novo.ESTADO = linha["ESTADO"].ToString();
                novo.NOME = linha["NOME"].ToString();
                novo.PORTE = linha["PORTE"].ToString();
                novo.RACA = linha["RAÇA"].ToString();
                novo.SITUACAO = linha["SITUAÇÃO"].ToString();
                novo.TELEFONE = linha["TELEFONE"].ToString();
                novo.RUA = linha["RUA"].ToString();
                novo.NUMERO = linha["NUMERO"].ToString();
                novo.DESCRICAO = linha["DESCRICAO"].ToString();
                ListaOcorrencia.Add(novo);
            }

            return ListaOcorrencia;
        }

        public List<DadosOcorrencia> getOcorrenciaUsuario(int ID_USUARIO)
        {
            AbrirConexao();

            List<DadosOcorrencia> ListaOcorrenciaUsuario = new List<DadosOcorrencia>();

            SqlCommand cmd = new SqlCommand("PR_SE_DADOS_OCORRENCIA_USUARIO", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_USUARIO", ID_USUARIO);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);

            DataRowCollection linhas = ds.Tables[0].Rows;

            foreach (DataRow linha in linhas)
            {
                DadosOcorrencia novo = new DadosOcorrencia();
                novo.ATIVO = Convert.ToBoolean(linha["ATIVO"]);
                novo.COR = linha["COR"].ToString();
                novo.ANIMAL = linha["ANIMAL"].ToString();
                novo.BAIRRO = linha["BAIRRO"].ToString();
                novo.CAMINHO = linha["CAMINHO"].ToString();
                novo.CIDADE = linha["CIDADE"].ToString();
                novo.DATA_OCORRENCIA = linha["DATA"].ToString();
                novo.EMAIL = linha["EMAIL"].ToString();
                novo.ESTADO = linha["ESTADO"].ToString();
                novo.NOME = linha["NOME"].ToString();
                novo.PORTE = linha["PORTE"].ToString();
                novo.RACA = linha["RAÇA"].ToString();
                novo.SITUACAO = linha["SITUAÇÃO"].ToString();
                novo.TELEFONE = linha["TELEFONE"].ToString();
                novo.RUA = linha["RUA"].ToString();
                novo.NUMERO = linha["NUMERO"].ToString();
                novo.DESCRICAO = linha["DESCRICAO"].ToString();
                novo.ID_OCORRENCIA = (int)(linha["ID_OCORRENCIA"]);
                novo.ID_USUARIO = (int)(linha["ID_USUARIO"]);
                ListaOcorrenciaUsuario.Add(novo);
            }

            return ListaOcorrenciaUsuario;
        }

        public DataRow ConsultarOcorrencia(int ID_OCORRENCIA, int ID_USUARIO)
        {
            DataSet ocorrencia = OcorrenciaUsuario(ID_OCORRENCIA, ID_USUARIO);

            try
            {
                return ocorrencia.Tables[0].Rows[0];
            }
            catch
            {
                return null;
            }
        }

        public DataSet OcorrenciaUsuario(int ID_OCORRENCIA, int ID_USUARIO)
        {
            AbrirConexao();
            Cmd = new SqlCommand("PR_SE_DADOS_USUARIO_OCORRENCIA", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ID_OCORRENCIA", ID_OCORRENCIA);
            Cmd.Parameters.AddWithValue("@ID_USUARIO", ID_USUARIO);

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
            adp.Fill(ds);

            return ds;
        }
    }
}
