using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntrabankChallenge.API.Data;
using IntrabankChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace IntrabankChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        // O .NET passa o contexto do banco automaticamente aqui (Injeção de Dependência)
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // 1. ROTA PARA LISTAR TODOS OS CLIENTES (GET: api/cliente)
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            // Busca a lista de clientes direto da tabela do banco de dados
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // 2. ROTA PARA CRIAR UM NOVO CLIENTE (POST: api/cliente)
        [HttpPost]
        public async Task<IActionResult> Criar(ClienteInputModel input)
        {
            // Instancia a nossa entidade de Domínio com os dados recebidos
            var novoCliente = new ClienteEmpresarial(
                input.RazaoSocial,
                input.NomeFantasia,
                input.Cnpj,
                input.LimiteCredito
            );

            // Adiciona no rastreamento do Entity Framework e salva no banco de dados
            _context.Clientes.Add(novoCliente);
            await _context.SaveChangesAsync();

            // Retorna o status HTTP 201 (Created) informando que o registro foi criado
            return CreatedAtAction(nameof(ObterTodos), new { id = novoCliente.Id }, novoCliente);
        }
    }

    // Uma classe auxiliar (DTO) simples para receber os dados limpos do usuário
    public class ClienteInputModel
    {
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public decimal LimiteCredito { get; set; }
    }
}
