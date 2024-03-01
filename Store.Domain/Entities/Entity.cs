using Flunt.Notifications;

namespace Store.Domain.Entities
{
    public class Entity : Notifiable<Notification>// : IComparable 
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // public int CompareTo(object? obj)
        // {
        //    //Feito para comparar um customer com outro. 
        // }
    }
}