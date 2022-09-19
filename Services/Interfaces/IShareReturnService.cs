using coresystem.Models;
using coresystem.ViewModels;

namespace coresystem.Services.Interfaces
{
    public interface IShareReturnService
    {
        Task<IEnumerable<ShareReturnVm>> GetAllShareReturnAsync();
        Task ShareReturnAsync(ShareReturn shareReturn);
    }
}
