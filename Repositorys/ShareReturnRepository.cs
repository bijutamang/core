using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.ViewModels;
using Dapper;
using System.Data;

namespace coresystem.Repositorys
{
    public class ShareReturnRepository : IShareReturnRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;
        public ShareReturnRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }
        private IDbConnection GetConn()
        {
            return _dbConnectionProvider.GetConnection();
        }
        public async Task<IEnumerable<ShareReturnVm>> GetAllShareReturnAsync()
        {

            try
            {
                using (var conn = GetConn())
                {
                    var query = @"SELECT m.FullName, sr.ShareNo, sr.Amount, sr.Remarks, sr.ReturnDate
                                   FROM ShareReturn sr left join Member m ON m.Id = sr.MemberId WHERE sr.RecStatus='A';";
                    var allShareReturn = await conn.QueryAsync<ShareReturnVm>(query);
                    return allShareReturn;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveAsync(ShareReturn shareReturn)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"INSERT INTO ShareReturn (MemberId, ShareNo, Amount, Remarks, ReturnDate, RecStatus)
                    VALUES (@MemberId, @ShareNo, @Amount, @Remarks, @ReturnDate, @RecStatus)";
                    await conn.ExecuteAsync(query, shareReturn);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<decimal> GetShareAmountByMemberIdAsync(int memberId)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"
                    select
                    (select sum(ShareAmount) from SharePurchase where MemberId = @memberId) - (select sum(Amount) from ShareReturn where MemberId = @memberId)
                    ";
                    return await conn.ExecuteScalarAsync<decimal>(query, new { memberId });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
