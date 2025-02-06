namespace BatDemo.Utils.ViewModels.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedResultDto
    {
        /// <summary>
        ///
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object Items { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="items"></param>
        public PagedResultDto(int totalCount, object items)
        {
            TotalCount = totalCount;
            Items = items;
        }
    }
}





