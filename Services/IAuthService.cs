using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; }
        string CurrentUserName { get; }
        string CurrentUserEmail { get; }
        int HouseholdSize { get; }
        int NotificationDaysBefore { get; }
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string name, string email, string password, int householdSize);
        Task LogoutAsync();
        void UpdateSettings(int householdSize, int notificationDays);
    }

    public class AuthService : IAuthService
    {
        public bool IsAuthenticated { get; private set; } = false;
        public string CurrentUserName { get; private set; } = "Lucraine Fien";
        public string CurrentUserEmail { get; private set; } = "lucraine.fien@univ.edu";
        public int HouseholdSize { get; private set; } = 3;
        public int NotificationDaysBefore { get; private set; } = 2;

        public Task<bool> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }

            IsAuthenticated = true;
            if (!string.IsNullOrWhiteSpace(email))
            {
                CurrentUserEmail = email;
            }
            return Task.FromResult(true);
        }

        public Task<bool> RegisterAsync(string name, string email, string password, int householdSize)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }

            CurrentUserName = name;
            CurrentUserEmail = email;
            HouseholdSize = householdSize > 0 ? householdSize : 1;
            IsAuthenticated = true;
            return Task.FromResult(true);
        }

        public Task LogoutAsync()
        {
            IsAuthenticated = false;
            return Task.CompletedTask;
        }

        public void UpdateSettings(int householdSize, int notificationDays)
        {
            HouseholdSize = householdSize > 0 ? householdSize : 1;
            NotificationDaysBefore = notificationDays > 0 ? notificationDays : 2;
        }
    }
}
