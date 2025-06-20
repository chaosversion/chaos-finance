using ChaosFinance.Domain.Enums;

namespace ChaosFinance.Application.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public int? DestinationAccountId { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string CategoryName { get; set; }
        public string AccountName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
