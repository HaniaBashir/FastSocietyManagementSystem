using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;
using FastSocietyManagementSystem.Repositories;

namespace FastSocietyManagementSystem.Services
{
    public class TaskService
    {
        private readonly ITaskRepository
            _taskRepository;

        public TaskService()
        {
            _taskRepository =
                new TaskRepository();
        }

        public void AddTask(
            SocietyTask societyTask
        )
        {
            _taskRepository.AddTask(
                societyTask
            );
        }

        public List<SocietyTask> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
    }
}
