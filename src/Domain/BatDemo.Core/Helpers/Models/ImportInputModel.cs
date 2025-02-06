using System;

namespace BatDemo.Domain.Core.Helpers
{
    public class ImportInputModel
    {
        public long BatchId { get; set; }
        public string FilePath { get; set; }
        public string TableName { get; set; }
        public long? NguoiDungId { get; set; }
        public long? DonViId { get; set; }
        public long? TempId { get; set; }
        public string BatchGuid { get; set; }
        public DateTime KyDuLieu { get; set; }
    }
}






