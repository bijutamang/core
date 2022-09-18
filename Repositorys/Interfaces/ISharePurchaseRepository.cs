using coresystem.Models;
using coresystem.ViewModels;

namespace coresystem.Repositorys.Interfaces
{
    public interface ISharePurchaseRepository
    {
        Task<IEnumerable<SharePurchaseVm>> GetAllSharePurchaseAsync();
        Task SaveAsync(SharePurchase sharePurchase);
        Task<SharePurchase> GetSingleSharePurchaseAsync(int id);
    }
}
