using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.Services.Interfaces;

namespace coresystem.Services
{
    public class SharePurchaseService : ISharePurchaseService
    {

        private ISharePurchaseRepository _ISharePurchaseRepository;
        public SharePurchaseService(ISharePurchaseRepository ISharePurchaseRepository)
        {
            _ISharePurchaseRepository = ISharePurchaseRepository;
        }
        public async Task<IEnumerable<SharePurchase>> GetAllSharePurchaseAsync() => await _ISharePurchaseRepository.GetAllSharePurchaseAsync();

        public async Task<SharePurchase> GetSingleSharePurchaseAsync(int id) => await _ISharePurchaseRepository.GetSingleSharePurchaseAsync(id);

        public async Task PurchaseShareAsync(SharePurchase sharePurchase)
        {
            await _ISharePurchaseRepository.SaveAsync(sharePurchase);
        }
    }
}
