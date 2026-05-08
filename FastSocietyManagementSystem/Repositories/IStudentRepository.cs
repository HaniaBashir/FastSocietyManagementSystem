using FastSocietyManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastSocietyManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        int GetStudentIdByUserId(int userId);

        List<SocietyEvent> GetAllEvents();

        int RegisterForEvent(int eventId, int studentId);

        void CreateTicket(int registrationId, string ticketCode);

        List<Ticket> GetTicketsByStudentId(int studentId);

        List<Student> GetAllStudents();

        List<SocietyTask> GetTasksByStudentId(int studentId);

        bool IsStudentAlreadyRegistered(int eventId, int studentId);

        int GetEventRegistrationCount(int eventId);
        int GetEventCapacity(int eventId);

        void UpdateTaskStatus(
    int taskId,
    string status
);
    }




}
