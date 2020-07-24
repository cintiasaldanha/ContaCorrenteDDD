using System;
using FluentValidation;
using ContaCorrenteDDD.Domain.Entities;

namespace ContaCorrenteDDD.Service.Validators
{
    public class DebitoValidator : AbstractValidator<Debito>
    {
        public DebitoValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Conta Corrente não localizada");
                    });

            RuleFor(c => c.Valor)
                    .NotEmpty().WithMessage("Por favor, informe um valor válido.")
                    .NotNull().WithMessage("Por favor, informe um valor válido.");


        }
    }

}