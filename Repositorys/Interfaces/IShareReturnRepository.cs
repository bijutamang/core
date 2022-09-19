using coresystem.Models;
using coresystem.ViewModels;

namespace coresystem.Repositorys.Interfaces
{
    public interface IShareReturnRepository
    {
        Task<IEnumerable<ShareReturnVm>> GetAllShareReturnAsync();
        Task SaveAsync(ShareReturn shareReturn);
    }
}
