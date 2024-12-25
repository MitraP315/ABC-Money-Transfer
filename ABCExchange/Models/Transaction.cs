using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCExchange.Models
{
/*    public class Transaction
    {
        public int TransactionId { get; set; }
        public string RefrenceNumber { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public int TransactionBy { get; set; }
        public decimal TransferAmount { get; set; } 
        public decimal ExchangeRate { get; set; }
        public decimal PayOutAmount { get; set; } 
        public ICollection<TransactionDetails> TransactionDetails { get; set; } = new List<TransactionDetails>();
    }*/

    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderMiddleName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCountry { get; set; } = "Malaysia"; // Default sender country
        public string ReceiverFirstName { get; set; }
        public string ReceiverMiddleName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCountry { get; set; } = "Nepal"; // Default receiver country
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TransferAmount { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal ExchangeRate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PayOutAmount { get; set; }
        public int TransactionCreatedBy { get; set; }
        public DateTime TransactionCreatedDate { get; set; }
    /*    public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }*/
    }
}
