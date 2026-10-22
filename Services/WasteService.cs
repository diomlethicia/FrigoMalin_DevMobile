using FrigoMalin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public class WasteService : IWasteService
    {
        private readonly IDatabaseService _dbService;

        public WasteService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<List<WasteRecord>> GetRecentRecordsAsync()
        {
            var db = await _dbService.GetConnectionAsync();
            var records = await db.Table<WasteRecord>().ToListAsync();
            return records.OrderByDescending(r => r.ActionDate).ThenByDescending(r => r.Id).ToList();
        }

        public async Task<WasteStatsSummary> GetStatsSummaryAsync()
        {
            var records = await GetRecentRecordsAsync();

            int saved = records.Count(r => r.ActionType == WasteActionType.Consomme);
            int wasted = records.Count(r => r.ActionType == WasteActionType.Jete);
            int total = saved + wasted;

            decimal moneySaved = records.Where(r => r.ActionType == WasteActionType.Consomme).Sum(r => r.EstimatedCost);
            decimal moneyLost = records.Where(r => r.ActionType == WasteActionType.Jete).Sum(r => r.EstimatedCost);

            double rate = total > 0 ? Math.Round((double)saved / total * 100.0, 1) : 100.0;

            string badge = rate switch
            {
                >= 90 => "Maître Zéro Gaspillage",
                >= 75 => "Protecteur Anti-Gaspi",
                >= 50 => "Éco-Responsable en Progrès",
                _ => "Attention au Gaspillage"
            };

            return new WasteStatsSummary
            {
                TotalItemsProcessed = total,
                ItemsSaved = saved,
                ItemsWasted = wasted,
                TotalMoneySaved = moneySaved,
                TotalMoneyLost = moneyLost,
                SuccessRatePercentage = rate,
                EcoBadgeTitle = badge
            };
        }
    }
}
