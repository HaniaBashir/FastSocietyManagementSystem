using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    public interface ISocietyRepository
    {
        List<Society> GetAllSocieties();

        bool IsSocietyHead(int userId);

        void AddSociety(Society society);

        void DeleteSociety(int societyId);

        void UpdateSocietyStatus(int societyId, string status);

        void CreateEvent(SocietyEvent societyEvent);

        List<SocietyEvent> GetAllEvents();

        List<SocietyEvent> GetPendingEvents();

        void UpdateEvent(SocietyEvent societyEvent);

        void CancelEvent(int eventId);

        void UpdateEventStatus(int eventId, string status);
    }
}