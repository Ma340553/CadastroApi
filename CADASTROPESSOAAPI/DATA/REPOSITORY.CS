using CADASTROPESSOAAPI.SERVICE;
using CADASTROPESSOAAPI.VIEWMODEL;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CADASTROPESSOAAPI.DATA
{
    public class REPOSITORY
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PESSOAVIEWMODEL> GETALL()
        {
            string query = "SELECT TOP 1000 * FROM PESSOA";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PESSOAVIEWMODEL>(query);
            }
        }
        public PESSOAVIEWMODEL GetByid(int pessoaid)
        {
            string query = "SELECT * FROM PESSOA WHERE pessoaid = @pessoaid";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PESSOAVIEWMODEL>(query, new { pessoaid = pessoaid });
            }
        }
        public void Update(int pessoaId, string PrimeiroNome)

        {
            string query = "UPDATE PESSOA SET primeiroNome=@primeironome where pessoaId=@pessoaId";
                          using (SqlConnection con = new SqlConnection(conexao))
            {
                con.Execute(query, new { pessoaId, PrimeiroNome = PrimeiroNome });
            }
        }
        public string create(PESSOAVIEWMODEL pessoa)
        {
            try
            {
                string query = @"
                            INSERT INTO PESSOA(PRIMEIRONOME,NOMEMEIO, ULTIMONOME, CPF)
                            Values(@primeironome, @NOMEMEIO,@ULTIMONOME, @cpf)

";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoa.PRIMEIRONOME,
                        NOMEMEIO = pessoa.NOMEMEIO,
                        cpf = pessoa.CPF,
                        ULTIMONOME = pessoa.ULTIMONOME,
                    });
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


    }
}

