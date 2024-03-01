using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects.Contracts
{
    public class CreateNameContract
    {
        public class CreateEmailContract : Contract<Name>
        {
            public CreateEmailContract(Name name)
            {
                Requires()
                    .IsEmail(name.Name, "Email");
            }
        }
    }
}
