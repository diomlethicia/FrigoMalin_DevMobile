using FrigoMalin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IWasteService
    {
        Task<List<WasteRecord>> GetRecentRecordsAsync();
        Task<WasteStatsSummary> GetStatsSummaryAsync();
    }

    public class WasteStatsSummary
    {
        public int TotalItemsProcessed { get; set; }
        public int ItemsSaved { get; set; }
        public int ItemsWasted { get; set; }
        public decimal TotalMoneySaved { get; set; }
        public decimal TotalMoneyLost { get; set; }
        public double SuccessRatePercentage { get; set; }
        public string EcoBadgeTitle { get; set; } = "Éco-Citoyen Débutant";
    }
}
