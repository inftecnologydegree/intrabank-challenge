using System;

namespace IntrabankChallenge.Domain.Entities
{
    public class ClienteEmpresarial
    {
        public Guid Id { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public decimal LimiteCredito { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public ClienteEmpresarial(string razaoSocial, string nomeFantasia, string cnpj, decimal limiteCredito)
        {
            Id = Guid.NewGuid();
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            LimiteCredito = limiteCredito;
            Ativo = true;
            DataCadastro = DateTime.UtcNow;
        }
    }
}
