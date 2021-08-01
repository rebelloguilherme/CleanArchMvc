using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception //classe recebendo Exception como herança
    {
        public DomainExceptionValidation(string error) : base(error) //passando o error para a classe base
        {

        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
