using ChaosFinance.Domain.Enums;
using ChaosFinance.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosFinance.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public PersonType Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

        public User(string name, string email, string username, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(name, email, username, passwordHash, createdAt, updatedAt);
        }

        public void Update(string name, string email, string username, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(name, email, username, passwordHash, createdAt, updatedAt);
        }

        private void ValidateDomain(string name, string email, string username, string passwordHash, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email inválido. O Email é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(passwordHash), "Password inválido. A Password é obrigatória");

            Name = name;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
