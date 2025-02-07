using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo.Utils.Enums
{
    public class TransactionEnum
    {
        public enum TransactionStatusEnum
        {
            Pending,
            Completed,
            Failed
        }
    }
    
}
