using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace BLL
{
	public class UsuarioBLL : Usuario
	{

		#region Métodos

		public Boolean LogarUsuario(string EMAIL, string SENHA, bool persist)
		{
			AbrirConexao();
			Cmd = new SqlCommand("PR_SE_VERIFICAR_USUARIO", Con);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
			Cmd.Parameters.AddWithValue("@SENHA", SENHA);
			Cmd.ExecuteNonQuery();
			Dr = Cmd.ExecuteReader();

			while (Dr.Read())
			{
				if (EMAIL == Dr["EMAIL"].ToString() && SENHA == Dr["SENHA"].ToString())
				{
					FormsAuthentication.RedirectFromLoginPage(EMAIL, persist);
					return true;
				}

			}
			return false;
		}

		public bool BuscarUsuario(string EMAIL)
		{

			AbrirConexao();
			Cmd = new SqlCommand("PR_SE_USUARIO", Con);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
			Cmd.ExecuteNonQuery();
			Dr = Cmd.ExecuteReader();

			if (Dr.HasRows)
				return false;
			else
				return true;

		}

		public bool SalvarUsuario(Usuario usuario, Endereco endereco)
		{
			bool resultado;
			try
			{
                if (RecuperarUsuario(usuario.EMAIL) == null)
					GravarUsuario(usuario, endereco);
				else
					AtualizarUsuario(usuario, endereco);

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

		public DataRow RecuperarUsuario(string email)
		{
			DataSet usuario = ConsultarUsuario(email);

			try
			{
				return usuario.Tables[0].Rows[0];
			}
			catch
			{
				return null;
			}
		}

		public DataSet ConsultarUsuario(string email)
		{
			AbrirConexao();
			Cmd = new SqlCommand("PR_SE_DADOS_USUARIO", Con);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@EMAIL", email);

			DataSet ds = new DataSet();
			SqlDataAdapter adp = new SqlDataAdapter((SqlCommand)Cmd);
			adp.Fill(ds);

			return ds;
		}

		public void GravarUsuario(Usuario usuario, Endereco endereco)
		{
			try
			{
				AbrirConexao();
				Cmd = new SqlCommand("PR_IN_USUARIO", Con);
				Cmd.CommandType = CommandType.StoredProcedure;

				Cmd.Parameters.AddWithValue("@NOME", usuario.NOME);
				Cmd.Parameters.AddWithValue("@SOBRENOME", usuario.SOBRENOME);
				Cmd.Parameters.AddWithValue("@EMAIL", usuario.EMAIL);
				Cmd.Parameters.AddWithValue("@SENHA", usuario.SENHA);
				Cmd.Parameters.AddWithValue("@TELEFONE", usuario.TELEFONE);
				Cmd.Parameters.AddWithValue("@LOGRADOURO", endereco.LOGRADOURO);
				Cmd.Parameters.AddWithValue("@NUMERO", endereco.NUMERO);
				Cmd.Parameters.AddWithValue("@BAIRRO", endereco.BAIRRO);
				Cmd.Parameters.AddWithValue("@ID_CIDADE", endereco.ID_CIDADE);
				Cmd.Parameters.AddWithValue("@ID_ESTADO", endereco.ID_ESTADO);
				Cmd.ExecuteNonQuery();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao gravar Usuario: " + ex.Message);
			}
			finally
			{
				FecharConexao();

			}
		}

		public void AtualizarUsuario(Usuario usuario, Endereco endereco)
		{
			try
			{
				AbrirConexao();
				Cmd = new SqlCommand("PR_UP_USUARIO", Con);
				Cmd.CommandType = CommandType.StoredProcedure;

				Cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.ID_USUARIO);
				Cmd.Parameters.AddWithValue("@NOME", usuario.NOME);
				Cmd.Parameters.AddWithValue("@SOBRENOME", usuario.SOBRENOME);
				Cmd.Parameters.AddWithValue("@EMAIL", usuario.EMAIL);
				Cmd.Parameters.AddWithValue("@SENHA", usuario.SENHA);
				Cmd.Parameters.AddWithValue("@ID_ENDERECO", usuario.ID_ENDERECO);
				Cmd.Parameters.AddWithValue("@TELEFONE", usuario.TELEFONE);
				Cmd.Parameters.AddWithValue("@LOGRADOURO", endereco.LOGRADOURO);
				Cmd.Parameters.AddWithValue("@NUMERO", endereco.NUMERO);
				Cmd.Parameters.AddWithValue("@BAIRRO", endereco.BAIRRO);
				Cmd.Parameters.AddWithValue("@ID_CIDADE", endereco.ID_CIDADE);
				Cmd.Parameters.AddWithValue("@ID_ESTADO", endereco.ID_ESTADO);
				Cmd.ExecuteNonQuery();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao atualizar Usuario: " + ex.Message);
			}
			finally
			{
				FecharConexao();

			}
		}

		#endregion

	}
}
