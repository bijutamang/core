using coresystem.Models;

namespace coresystem.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int id);
        Task<Member> GetSingleMemberAsync(int id);
    }
}
