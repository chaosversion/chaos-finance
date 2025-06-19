using ChaosFinance.Domain.Validation;
using System.Transactions;
using System.Xml.Linq;

namespace ChaosFinance.Domain.Entities
{
    public class TransactionTag
    {
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public TransactionTag(int transactionId, int tagId)
        {
            ValidateDomain(transactionId, tagId);
        }

        public void Update(int transactionId, int tagId)
        {
            ValidateDomain(transactionId, tagId);
            TransactionId = transactionId;
            TagId = tagId;
        }

        private void ValidateDomain(int transactionId, int tagId)
        {
            DomainExceptionValidation.When(transactionId == 0, "transactionId inválido. O transactionId é obrigatório");

            TransactionId = transactionId;
            TagId = tagId;
        }
    }
}
