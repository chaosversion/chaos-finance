﻿using ChaosFinance.Domain.Enums;
using ChaosFinance.Domain.Validation;

namespace ChaosFinance.Domain.Entities
{
    public class Account : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Transaction> TransactionsAsOrigin { get; set; } = new List<Transaction>();
        public virtual ICollection<Transaction> TransactionsAsDestination { get; set; } = new List<Transaction>();


        public Account(int userId, string name, AccountType type, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, name, type, createdAt, updatedAt);
        }

        public void Update(int userId, string name, AccountType type, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(userId, name, type, createdAt, updatedAt);
            UserId = userId;
        }

        private void ValidateDomain(int userId, string name, AccountType type, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório");

            UserId = userId;
            Name = name;
            Type = type;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
