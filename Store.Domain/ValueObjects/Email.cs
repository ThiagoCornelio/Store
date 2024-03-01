using Flunt.Notifications;
using Store.Domain.ValueObjects.Contracts;

namespace Store.Domain.ValueObjects
{
    public class Email : Notifiable<Notification>
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new CreateEmailContract(this));
        }

        public string Address { get; private set; }
    }
}
