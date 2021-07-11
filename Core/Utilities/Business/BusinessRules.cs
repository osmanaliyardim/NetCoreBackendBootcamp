using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Params sayesinde istediğimiz kadar iş kodu array halinde çalıştırılıyor
        public static IResult Run(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (item.Success)
                {
                    return item; //Hatalı olan iş kuralını Business'a bildir
                }
            }

            return null; //Başarılı ise bir şey yapma
        }
    }
}
