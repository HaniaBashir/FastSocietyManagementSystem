using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;
using System.Linq;

namespace FastSocietyManagementSystem.Services
{
    public class SocietyService
    {
        private readonly ISocietyRepository _societyRepository;

        public SocietyService()
        {
            _societyRepository =
                new SocietyRepository();
        }

        public List<Society> GetAllSocieties()
        {
            return _societyRepository
                .GetAllSocieties();
        }

        public bool IsSocietyHead(int userId)
        {
            return _societyRepository
                .IsSocietyHead(userId);
        }

        public void CreateEvent(
    SocietyEvent societyEvent
)
        {
            _societyRepository.CreateEvent(
                societyEvent
            );
        }

        public List<SocietyEvent> GetAllEvents()
        {
            return _societyRepository
                .GetAllEvents();
        }

        public void UpdateEvent(SocietyEvent societyEvent)
        {
            _societyRepository.UpdateEvent(societyEvent);
        }

        public void CancelEvent(int eventId)
        {
            _societyRepository.CancelEvent(eventId);
        }

        public void AddSociety(Society society)
        {
            _societyRepository.AddSociety(society);
        }

        public void ApproveSociety(int societyId)
        {
            _societyRepository.UpdateSocietyStatus(societyId, "Active");
        }

        public void SuspendSociety(int societyId)
        {
            _societyRepository.UpdateSocietyStatus(societyId, "Suspended");
        }

        public void DeleteSociety(int societyId)
        {
            _societyRepository.DeleteSociety(societyId);
        }

        public List<SocietyEvent> GetPendingEvents()
        {
            return _societyRepository.GetPendingEvents();
        }

        public void ApproveEvent(int eventId)
        {
            _societyRepository.UpdateEventStatus(eventId, "Active");
        }

        public void RejectEvent(int eventId)
        {
            _societyRepository.UpdateEventStatus(eventId, "Rejected");
        }

        public bool CanAdminApproveEvent(
    int eventId,
    out string message
)
        {
            List<SocietyEvent> pendingEvents =
                _societyRepository.GetPendingEvents();

            SocietyEvent? selectedEvent =
                pendingEvents.FirstOrDefault(
                    currentEvent => currentEvent.EventId == eventId
                );

            if (selectedEvent == null)
            {
                message = "Only pending events can be approved.";
                return false;
            }

            if (selectedEvent.EventDate <= DateTime.Now)
            {
                message = "This event date has already passed and cannot be approved.";
                return false;
            }

            message = "";
            return true;
        }

        public int GetSocietyIdByHeadUserId(int userId)
        {
            return _societyRepository.GetSocietyIdByHeadUserId(userId);
        }

        public List<SocietyEvent> GetEventsBySocietyId(int societyId)
        {
            return _societyRepository.GetEventsBySocietyId(societyId);
        }
    }
}
