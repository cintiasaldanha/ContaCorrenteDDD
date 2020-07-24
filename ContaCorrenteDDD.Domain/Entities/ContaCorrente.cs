using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace ContaCorrenteDDD.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {
     
        public int NumeroConta { get; set; }
        public int NumeroReferencialCliente { get; set; }

        public decimal Saldo { get; set; }

        public decimal LimiteCredito { get; set; }

        public decimal ValorDebito { get; set; }

        public decimal ValorCredito { get; set; }

        public bool Debitar(decimal valor)
        {
            bool ehDebitoValido = false;
            //Verifica se valor solicitado para d�bito � v�lido
            //Valor do d�bito n�o pode ser superior do que Saldo + Limite de Cr�dito
         
                if (valor < 0)
                {
                   ehDebitoValido = false;
                }
                else if (valor <= Saldo)
                {
                    Saldo -= valor;
                    ehDebitoValido = true;
                 }
                 else if (valor <= (Saldo + LimiteCredito))
                 {
                    Saldo = 0;
                    LimiteCredito = valor - Saldo;
                    ehDebitoValido = true;
                  }
            
            return ehDebitoValido;
        }
                    

        public void Creditar(decimal valor)
        {            
            Saldo = Saldo + valor;

            if (valor > 50000)
            {
                Console.WriteLine("Alerta para COAF - transa��o acima de R$ 50.000,00");
            }
           
        }

        public string ValidarOperacao(decimal ValorDebito, decimal ValorCredito)
        {
            string mensagem= String.Empty;

            try
            {
                if (ValorCredito > 0 && ValorDebito > 0)
                    return "Somente um tipo de  opera��o pode ser realizada por solicita��o.";
                
                
                if (ValorCredito > 0)
                    Creditar(ValorCredito);
                else
                {
                    if (!Debitar(ValorDebito))
                    {
                        mensagem = "Valor do d�bito � inv�lido para opera��o!";
                    }

                }
                return mensagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                  
        }
    }
}