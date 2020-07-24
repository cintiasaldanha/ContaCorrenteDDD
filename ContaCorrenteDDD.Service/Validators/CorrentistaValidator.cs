using System;
using FluentValidation;
using ContaCorrenteDDD.Domain.Entities;

namespace ContaCorrenteDDD.Service.Validators
{
    public class CorrentistaValidator : AbstractValidator<Correntista>
    {
 	    public CorrentistaValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Correntista não localizado.");
                    });

            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("IPor favor, informe o nome do correntista.")
                    .NotNull().WithMessage("Por favor, informe o nome do correntista.");

            RuleFor(c => c.NumeroReferencialCliente)
                   .NotEmpty().WithMessage("Por favor, informe o número referencial do cliente.")
                   .NotNull().WithMessage("Por favor, informe o número referencial do cliente.");
            
            RuleFor(c => c.Cpf)
                    .NotEmpty().WithMessage("Por favor, informe o CPF do correntista.")
                    .NotNull().WithMessage("Por favor, informe o CPF do correntista.");

            RuleFor(c => c.Telefone)
                    .NotEmpty().WithMessage("IPor favor, informe o telefone do correntista.")
                    .NotNull().WithMessage("Por favor, informe o telefone do correntista.");

             RuleFor(c => c.Endereco)
                    .NotEmpty().WithMessage("Por favor, informe o endereço do correntista.")
                    .NotNull().WithMessage("Por favor, informe o endereço do correntista.");
            }
		}       
    
}