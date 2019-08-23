using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_RoteiroFilmes;User Id=sa; Pwd=132";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> genero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain generos = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };

                        genero.Add(generos);

                    }
                }
            }
            return genero;
        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string Query = "INSERT INTO Generos(Nome) VALUES(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        while (sdr.Read())
                        {
                            GeneroDomain estilo = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                    return null;

                    // retornar
                }
            }
        }

        public void Atualizar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@id", generoDomain.IdGenero);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))

            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
