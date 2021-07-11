using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //Buraya kesinlikle Business kuralları konulmamalı
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).Length(2,30);
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(1);
            
            //Örnek olması amaçlı
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x=>x.ProductId ==1);
            RuleFor(x => x.ProductName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
