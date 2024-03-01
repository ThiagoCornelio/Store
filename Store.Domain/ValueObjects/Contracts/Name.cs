using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects.Contracts
{
    public class Name : ValueObject
    {
        public Name(string firtName, string lastName)
        {
            FirtName = firtName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirtName, 3, "Name.FirtName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirtName, 40, "Name.FirtName", "Nome deve conter no máximo 40 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres")
                );
        }

        public string FirtName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{FirtName} {LastName}";
        }
    }
