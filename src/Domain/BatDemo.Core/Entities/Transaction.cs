using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

namespace BatDemo.Entities
{
    [Table("Transactions")]
    public class Transaction : FullAuditedEntity<Guid>
    {
        [Required]
        public Guid FromAccountId { get; set; }

        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string FromAccountNumber { get; set; }

        [Required]
        [StringLength(200)]
        [Unicode(true)]
        public string FromAccountHolderName { get; set; }

        [Required]
        public Guid ToAccountId { get; set; }

        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string ToAccountNumber { get; set; }

        [Required]
        [StringLength(200)]
        [Unicode(true)]
        public string ToAccountHolderName { get; set; }

        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string TransactionType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public BankAccount FromAccount { get; set; }

        public BankAccount ToAccount { get; set; }

    }
}
