using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.ViewModels;
using Dapper;
using System.Data;
using System.Diagnostics.Metrics;

namespace coresystem.Repositorys
{
    public class SharePurchaseRepository : ISharePurchaseRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;
        public SharePurchaseRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<IEnumerable<SharePurchaseVm>> GetAllSharePurchaseAsync()
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"SELECT m.FullName, sp.ShareNo, sp.ShareAmount,sp.Remarks, sp.PurchaseDate
FROM SharePurchase sp left join Member m ON m.Id = sp.MemberId WHERE sp.RecStatus='A';";
                    var allSharePurchases = await conn.QueryAsync<SharePurchaseVm>(query);
                    return allSharePurchases;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SharePurchase> GetSingleSharePurchaseAsync(int id)
        {
            try
            {
                using (var conn = GetConn())
                {
                    var query = @"SELECT * FROM SharePurchase WHERE Id=@Id";
                    return await conn.QueryFirstOrDefaultAsync<SharePurchase>(query, new { Id = id });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveAsync(SharePurchase sharePurchase)
        {

            try
            {
                using (var conn = GetConn())
                {
                    var query = @"INSERT INTO SharePurchase
                    (MemberId, ShareNo, ShareAmount, Remarks, PurchaseDate, RecStatus)
                    VALUES (@MemberId, @ShareNo, @ShareAmount, @Remarks, @PurchaseDate, @RecStatus)";
                    await conn.ExecuteAsync(query, sharePurchase);
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
