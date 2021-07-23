﻿using Castle.DynamicProxy;
using Core.CrossCuttinConcerns.Validation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspects : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspects(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);

            foreach (var item in entities)
            {
                ValidationTool.Validate(validator, item);
            }
        }
    }
}
