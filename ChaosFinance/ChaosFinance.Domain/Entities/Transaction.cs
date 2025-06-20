using ChaosFinance.Domain.Enums;
using ChaosFinance.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosFinance.Domain.Entities
{
    public class Transaction : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public int? DestinationAccountId { get; set; }
        public virtual Account? DestinationAccount { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string AccountName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<TransactionTag> TransactionTags { get; set; } = new List<TransactionTag>();

        public Transaction()
        {
        }

        public Transaction(string description, decimal amount, DateTime date, TransactionType type, int accountId, int destinationAccountId, int categoryId, string categoryName, string accountName, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(description, amount, date, type, categoryName, accountName, createdAt, updatedAt);
        }

        public void Update(int userId, string description, decimal amount, DateTime date, TransactionType type, int accountId, int destinationAccountId, int categoryId, string categoryName, string accountName, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(description, amount, date, type, categoryName, accountName, createdAt, updatedAt);
            UserId = userId;
            AccountId = accountId;
            DestinationAccountId = destinationAccountId;
            CategoryId = categoryId;
        }

        private void ValidateDomain(string description, decimal amount, DateTime date, TransactionType type, string categoryName, string accountName, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválido. Descrição é obrigatório");

            Description = description;
            Amount = amount;
            Date = date;
            Type = type;
            CategoryName = categoryName;
            AccountName = accountName;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
