﻿using System;
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
    [Table("Accounts")]
    public class Account : FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string AccountNumber { get; set; }

        [StringLength(200)]
        [Unicode(true)]
        [Required]
        public string AccountHolderName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> TransactionFroms { get; set; } = new List<Transaction>();
        public virtual ICollection<Transaction> TransactionTos { get; set; } = new List<Transaction>();
    }
}
