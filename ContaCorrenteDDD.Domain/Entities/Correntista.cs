using System;

namespace ContaCorrenteDDD.Domain.Entities
{
    public class Correntista : BaseEntity
    {
        public int NumeroReferencialCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        

    }
}