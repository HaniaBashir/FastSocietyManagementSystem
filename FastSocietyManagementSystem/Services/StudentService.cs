using FastSocietyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using FastSocietyManagementSystem.Models;
namespace FastSocietyManagementSystem.Services
{
    public class StudentService
    {
        private readonly IStudentRepository
            _studentRepository;

        public StudentService()
        {
            _studentRepository =
                new StudentRepository();
        }

        public int GetStudentIdByUserId(
            int userId
        )
        {
            return _studentRepository
                .GetStudentIdByUserId(userId);
        }

        public List<SocietyEvent> GetAllEvents()
        {
            return _studentRepository
                .GetAllEvents();
        }

        public void RegisterForEvent(int eventId, int studentId)
        {
            int registrationId = _studentRepository.RegisterForEvent(eventId, studentId);

            string ticketCode =
                $"TICKET-{registrationId}-{DateTime.Now:yyyyMMddHHmmss}";

            _studentRepository.CreateTicket(registrationId, ticketCode);
        }

        public List<Ticket> GetTicketsByStudentId(int studentId)
        {
            return _studentRepository.GetTicketsByStudentId(studentId);

        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public List<SocietyTask> GetTasksByStudentId(int studentId)
        {
            return _studentRepository.GetTasksByStudentId(studentId);
        }

        public void UpdateTaskStatus(
    int taskId,
    string status
)
        {
            _studentRepository
                .UpdateTaskStatus(
                    taskId,
                    status
                );
        }


        public bool IsStudentAlreadyRegistered(int eventId, int studentId)
        {
            return _studentRepository.IsStudentAlreadyRegistered(eventId, studentId);
        }

        public bool IsEventFull(int eventId)
        {
            int registrationCount =
                _studentRepository.GetEventRegistrationCount(eventId);

            int capacity =
                _studentRepository.GetEventCapacity(eventId);

            return capacity > 0 && registrationCount >= capacity;
        }
    }

}
