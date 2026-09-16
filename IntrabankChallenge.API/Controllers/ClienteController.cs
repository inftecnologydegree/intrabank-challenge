using Microsoft.AspNetCore.Mvc;
using IntrabankChallenge.Domain.Entities; // Ajustado para o nome do seu namespace da imagem

namespace IntrabankChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // A rota no navegador será: api/cliente
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterExemploCliente()
        {
            // Criando o cliente usando a sua classe da imagem
            var clienteExemplo = new ClienteEmpresarial(
                "Intrabank Tecnologia LTDA", 
                "Intrabank", 
                "12345678000199", 
                50000.00m
            );

            // Retorna HTTP 200 OK com o JSON do cliente
            return Ok(clienteExemplo);
        }
    }
}
