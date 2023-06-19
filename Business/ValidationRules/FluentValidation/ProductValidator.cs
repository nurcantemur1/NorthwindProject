using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //categoryid 1 oldugunda ürün fiyatı min 10 olmalıdır
            RuleFor(p=>p.ProductName).Must(StartsWithA).WithMessage("ürün ismi a ile başlamalı");
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("a");
        }
    }
}
