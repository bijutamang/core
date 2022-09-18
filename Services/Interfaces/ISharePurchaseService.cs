using coresystem.Models;

namespace coresystem.Services.Interfaces
{
    public interface ISharePurchaseService
    {
        Task<IEnumerable<SharePurchase>> GetAllSharePurchaseAsync();
        Task PurchaseShareAsync(SharePurchase sharePurchase);
        Task<SharePurchase> GetSingleSharePurchaseAsync(int id);
    }
}
