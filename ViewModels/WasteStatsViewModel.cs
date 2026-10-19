using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrigoMalin.Models;
using FrigoMalin.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FrigoMalin.ViewModels
{
    public partial class WasteStatsViewModel : ObservableObject
    {
        private readonly IWasteService _wasteService;

        [ObservableProperty]
        private WasteStatsSummary _summary = new();

        [ObservableProperty]
        private ObservableCollection<WasteRecord> _recentRecords = new();

        [ObservableProperty]
        private bool _isBusy;

        public WasteStatsViewModel(IWasteService wasteService)
        {
            _wasteService = wasteService;
        }

        [RelayCommand]
        public async Task LoadStatsAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                Summary = await _wasteService.GetStatsSummaryAsync();

                var records = await _wasteService.GetRecentRecordsAsync();
                RecentRecords.Clear();
                foreach (var r in records)
                {
                    RecentRecords.Add(r);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
