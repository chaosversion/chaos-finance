using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class Category : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Transaction> Categories { get; set; }

        public Category(int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(month, year, createdAt, updatedAt);
        }

        public void Update(int month, int year, DateTime createdAt, DateTime updatedAt, int userId)
        {
            ValidateDomain(month, year, createdAt, updatedAt);
            UserId = userId;
        }

        private void ValidateDomain(int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(month == 0, "Month é obrigatório");
            DomainExceptionValidation.When(year == 0, "Year é obrigatório");

            Month = month;
            Year = year;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
