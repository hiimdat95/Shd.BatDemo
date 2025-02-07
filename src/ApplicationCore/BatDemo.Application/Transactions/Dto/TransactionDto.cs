

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static BatDemo.Utils.Enums.TransactionEnum;

namespace BatDemo.Transactions.Dto
{
    /// <summary>
    ///
    /// </summary>
    public class TransactionDto
    {
        /// <summary>
        /// 
        /// </summary>    
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "From account is required")]
        public Guid FromAccountId { get; set; }
        public string FromAccountNumber { get; set; }
        public string FromAccountHolderName { get; set; }

        [Required(ErrorMessage = "To account is required")]
        public Guid ToAccountId { get; set; }

        public string ToAccountNumber { get; set; }

        public string ToAccountHolderName { get; set; }


        [Required]
        public decimal Amount { get; set; }
        public TransactionStatusEnum Status { get; set; }

    }
}

