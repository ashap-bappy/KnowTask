namespace User.Domain.Entities
{
    public class UserModel
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private UserModel() { } // For EF

        public UserModel(string email, string passwordHash, string fullName)
        {
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            FullName = fullName;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
