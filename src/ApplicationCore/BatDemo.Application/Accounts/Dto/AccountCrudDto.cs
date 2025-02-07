

using System;
using System.ComponentModel.DataAnnotations;

namespace BatDemo.Accounts.Dto
{
    /// <summary>
    ///
    /// </summary>
    public class AccountCrudDto
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
        public string AccountNumber { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        ///
        [Required(ErrorMessage = "AccountHolderName is required")]
        public string AccountHolderName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        ///
        [Required(ErrorMessage = "Balance is required")]
        public decimal Balance { get; set; }
    }
}

