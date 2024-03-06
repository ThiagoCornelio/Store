using Flunt.Validations;

namespace Store.Domain.ValueObjects.Contracts
{
    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
                .AreEquals(name.FirstName, name.FirstName.Length < 2 || name.FirstName.Length > 30, "Name.FirstName", "Nome deve conter 3 a 40 caracteres")
                .AreEquals(name.LastName, name.LastName.Length < 2 || name.LastName.Length > 30, "Name.LastName", "Sobrenome deve conter 3 a 40 caracteres");
        }
    }
}
