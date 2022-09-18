using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using Dapper;
using System.Data;

namespace coresystem.Repositorys
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;
        public MemberRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"UPDATE Member SET RecStatus='D' WHERE Id=@Id";
                    await conn.ExecuteAsync(query, new { Id = id });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Member>> GetAllMemberAsync()
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"SELECT * FROM Member WHERE RecStatus='A'";
                    var member = await conn.QueryAsync<Member>(query);
                    return member;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Member> GetSingleMemberAsync(int id)
        {
            try
            {
                using(var conn = GetConn())
                {
                    var query = @"SELECT * FROM Member WHERE Id=@Id";
                    return await conn.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveAsync(Member member)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"INSERT INTO Member
                    (FirstName, LastName, FatherName, MotherName, GrandFatherName, Address, Number, DateOfBirth, Gender, CreatedAt, RecStatus)
                    VALUES (@FirstName, @LastName, @FatherName, @MotherName, @GrandFatherName, @Address, @Number, @DateOfBirth, @Gender, @CreatedAt, @RecStatus)";
                    await conn.ExecuteAsync(query, member);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Member member)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"UPDATE Member SET FirstName=@FirstName, LastName=@LastName, FatherName=@FatherName,
                                MotherName=@MotherName, GrandFatherName=@GrandFatherName, Address=@Address, 
                                Number=@Number, DateOfBirth=@DateOfBirth, Gender=@Gender WHERE Id=@Id";
                    await conn.ExecuteAsync(query, member);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IDbConnection GetConn()
        {
            return _dbConnectionProvider.GetConnection();
        }
    }
}
