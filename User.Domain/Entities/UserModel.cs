using User.Domain.Interfaces;

namespace User.Domain.Entities
{
    public class UserModel(string email, string fullName)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; } = email;
        public string FullName { get; private set; } = fullName;
        public string PasswordHash { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Domain expresses the need for hashing but does not implement it.
        public void SetPassword(string password, IPasswordHasher hasher)
        {
            ArgumentNullException.ThrowIfNull(hasher);
            PasswordHash = hasher.HashPassword(password);
        }

        public bool VerifyPassword(string password, IPasswordHasher hasher)
        {
            ArgumentNullException.ThrowIfNull(hasher);
            return hasher.VerifyHashedPassword(password, PasswordHash);
        }
    }
}
