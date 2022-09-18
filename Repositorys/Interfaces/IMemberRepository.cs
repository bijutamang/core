using coresystem.Models;
using System.Collections;

namespace coresystem.Repositorys.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMemberAsync();
        Task SaveAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(int id);
        Task<Member> GetSingleMemberAsync(int id);
    }
}
