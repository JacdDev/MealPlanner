namespace Domain.UserAggregation
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }

        private User(Guid userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public static User Create(string name) 
        { 
            return new User(Guid.NewGuid(), name);
        }
    }
}
