using CADASTROPESSOAAPI.SERVICE;
using CADASTROPESSOAAPI.VIEWMODEL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<PESSOAVIEWMODEL> getall()
        {
            var service = new SERVICEPESSOA();
            return service.getall();
        }
        [HttpGet("GetById/{pessoid}")]
        public PESSOAVIEWMODEL GetById(int pessoid)
        {
            var service = new SERVICEPESSOA();
            return service.GetByid(pessoid);
        }

        //[HttpGet("GetByIdprimeiroNome/{primeiroNome}")]
        //public PESSOAVIEWMODEL GetByIdprimeiroNome(string primeiroNome)
        //{
        //    var service = new SERVICEPESSOA();
        //    return service.(primeiroNome);



        //}
        [HttpPut("update/{pessoaId}/{primeiroNome}")]
        public void update(int pessoaId, string primeiroNome)
        {
            var service = new servicePessoa();
            service.update(pessoaId, primeiroNome);
        }
        [HttpPost("create")]

        public IActionResult Create(PESSOAVIEWMODEL pessoa)
        {
            var service = new SERVICEPESSOA();
            var resultado = service.Create(pessoa);
            
            
                var result = new
                {
                    Sucess = true,
                    Data = "Cadastro Realizado com sucesso"
                };
                return Ok(result);
            

        }
    }
}
