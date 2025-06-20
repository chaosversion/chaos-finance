using ChaosFinance.Domain.Validation;
using System.Transactions;
using System.Xml.Linq;

namespace ChaosFinance.Domain.Entities
{
    public class TransactionTag
    {
        public int TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
