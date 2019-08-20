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

        public void Atualizar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@id", generoDomain.IdGenero);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
