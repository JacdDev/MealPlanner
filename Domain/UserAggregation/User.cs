namespace Domain.UserAggregation
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }

        public User(Guid userId, string name)
        {
            UserId = userId;
            Name = name;
        }
    }
}
