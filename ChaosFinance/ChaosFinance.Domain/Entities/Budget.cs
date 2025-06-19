using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class Budget : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Budget(int userId, int categoryId, decimal amount, int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, categoryId, amount, month, year, createdAt, updatedAt);
        }

        public void Update(int userId, int categoryId, decimal amount, int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, categoryId, amount, month, year, createdAt, updatedAt);
            CategoryId = categoryId;
            UserId = userId;
        }

        private void ValidateDomain(int userId, int categoryId, decimal amount, int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(userId == 0, "ID de usuário é obrigatório");

            UserId = userId;
            CategoryId = categoryId;
            Amount = amount;
            Month = month;
            Year = year;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
