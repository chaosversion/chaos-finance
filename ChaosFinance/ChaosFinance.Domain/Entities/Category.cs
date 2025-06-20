using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class Category : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

        public Category(string name, int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(name, month, year, createdAt, updatedAt);
        }

        public void Update(string name,int month, int year, DateTime createdAt, DateTime updatedAt, int userId)
        {
            ValidateDomain(name, month, year, createdAt, updatedAt);
            UserId = userId;
        }

        private void ValidateDomain(string name, int month, int year, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(month == 0, "Month é obrigatório");
            DomainExceptionValidation.When(year == 0, "Year é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome é obrigatório.");

            Name = name;
            Month = month;
            Year = year;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
