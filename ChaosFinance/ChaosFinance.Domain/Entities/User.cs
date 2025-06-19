using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public User(string name, string email, string password, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(name, email, password, passwordHash, createdAt, updatedAt);
        }

        public void Update(string name, string email, string password, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(name, email, password, passwordHash, createdAt, updatedAt);
        }

        private void ValidateDomain(string name, string email, string password, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email inválido. O Email é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Password inválido. A Password é obrigatória");

            Name = name;
            Email = email;
            Password = password;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
