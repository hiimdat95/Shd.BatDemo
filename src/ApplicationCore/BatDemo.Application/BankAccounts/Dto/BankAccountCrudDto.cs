

using System;
using System.ComponentModel.DataAnnotations;

namespace BatDemo.BankAccounts.Dto
{
    /// <summary>
    ///
    /// </summary>
    public class BankAccountCrudDto
    {
        /// <summary>
        /// 
        /// </summary>    
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ///
        [Required(ErrorMessage = "AccountNumber is required")]
        [MaxLength(50, ErrorMessage = "The maximum length of the Account number is 50 characters.")]
        public string AccountNumber { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        ///
        [Required(ErrorMessage = "AccountHolderName is required")]
        [MaxLength(200, ErrorMessage = "The maximum length of the Account number is 200 characters.")]
        public string AccountHolderName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        ///
        [Required(ErrorMessage = "Balance is required")]
        public decimal Balance { get; set; }
    }
}

