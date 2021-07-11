using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors.Autofac
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true, Inherited = true)]
    //Class'ın en tepesinde kullanabilir
    //Methodlarla kullanılabilir
    //Birden fazla kullanılabilir
    //Ve inherit edildiği alt classlarda da kullanılabilir
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Çalışma sırası

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
