using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmesRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_RoteiroFilmes;User Id=sa;Pwd=132";

        public List<FilmesDomain> Listar()
        {
            string Query = "SELECT Filmes.IdFilme, Filmes.Titulo, Generos.IdGenero, Generos.Nome FROM Filmes JOIN Generos ON filmes.IdGenero = Generos.IdGenero;";
            List<FilmesDomain> filmes = new List<FilmesDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }
                        };

                        filmes.Add(filme);

                    }
                }
            }
            return filmes;
        }

        public FilmesDomain BuscarPorId (int id)
        {
            string Query = "SELECT Filmes.IdFilme, Filmes.Titulo, Generos.IdGenero, Generos.Nome FROM Filmes JOIN Generos ON filmes.IdGenero = Generos.IdGenero where IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            FilmesDomain filme = new FilmesDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }
                            };
                            return filme;

                        }
                    }
                }
                return null;
            }
        }



        public void Cadastrar(FilmesDomain filmesDomain)
        {
            string Query = "insert into Filmes (Titulo, IdGenero) values (@Titulo, @IdGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Titulo", filmesDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filmesDomain.IdGenero);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
