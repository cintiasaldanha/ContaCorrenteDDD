using System;
using FluentValidation;
using ContaCorrenteDDD.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ContaCorrenteDDD.Service.Validators
{
    public class ContaCorrenteValidator : AbstractValidator<ContaCorrente>
    {
 	    public ContaCorrenteValidator(Debito debito )
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Conta Corrente não localizada");
                    });
            RuleFor(c => c.NumeroConta)
                 .NotEmpty().WithMessage("Por favor, informe o número da conta.")
                 .NotNull().WithMessage("Por favor, informe o número da conta.");

            RuleFor(c => c.NumeroReferencialCliente)
                 .NotEmpty().WithMessage("Por favor, informe o número referencial do cliente.")
                 .NotNull().WithMessage("Por favor, informe o número referencial do cliente.");

            _ = RuleFor(c => c.Saldo)
                    .NotEmpty().WithMessage("Por favor, informe um valor válido para Saldo.")
                    .NotNull().WithMessage("Por favor, informe um valor válido para Saldo.");
            
            _ = RuleFor(c => c.LimiteCredito)
                    .NotEmpty().WithMessage("Por favor, informe um valor válido para Limite de Crédito.")
                    .NotNull().WithMessage("Por favor, informe um valor válido para Limite de Crédito.");

        }

    }       
    
}