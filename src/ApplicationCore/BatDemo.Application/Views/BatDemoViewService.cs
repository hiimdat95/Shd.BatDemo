using Abp.Application.Services;
using BatDemo.Repositories;

namespace BatDemo.Views
{
    /// <summary>
    ///
    /// </summary>
    public class BatDemoViewService : ApplicationService, IBatDemoViewService
    {
        private readonly IReadViewRepository _readViewRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="readViewRepository"></param>
        public BatDemoViewService(IReadViewRepository readViewRepository)
        {
            _readViewRepository = readViewRepository;
        }
    }
}






