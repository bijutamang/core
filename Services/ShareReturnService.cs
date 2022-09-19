using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.Services.Interfaces;
using coresystem.ViewModels;

namespace coresystem.Services
{
    public class ShareReturnService : IShareReturnService
    {
        private readonly IShareReturnRepository _shareReturnRepository;
        public ShareReturnService(IShareReturnRepository shareReturnRepository)
        {
            _shareReturnRepository = shareReturnRepository;
        }

        public async Task<IEnumerable<ShareReturnVm>> GetAllShareReturnAsync() => await _shareReturnRepository.GetAllShareReturnAsync();


        public async Task ShareReturnAsync(ShareReturn shareReturn)
        {
            await _shareReturnRepository.SaveAsync(shareReturn);
        }
    }
}
