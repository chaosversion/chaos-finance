using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class Tag : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<TransactionTag> TransactionTags { get; set; }

        public Tag(int userId, string name, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, name, createdAt, updatedAt);
        }

        public void Update(int userId, string name, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, name, createdAt, updatedAt);
            UserId = userId;
        }

        private void ValidateDomain(int userId, string name, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(userId == 0, "ID de usuário é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório");

            UserId = userId;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
