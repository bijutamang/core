using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.Services.Interfaces;

namespace coresystem.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task AddMemberAsync(Member member)
        {
            await _memberRepository.SaveAsync(member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync() => await _memberRepository.GetAllMemberAsync();

        public async Task<Member> GetSingleMemberAsync(int id) => await _memberRepository.GetSingleMemberAsync(id);

        public async Task UpdateMemberAsync(Member member)
        {
            await _memberRepository.UpdateAsync(member);
        }
    }
}
