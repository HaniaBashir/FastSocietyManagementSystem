using System;
using System.Collections.Generic;
using System.Text;
using FastSocietyManagementSystem.Models;

namespace FastSocietyManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        void AddTask(SocietyTask societyTask);

        List<SocietyTask> GetAllTasks();
    }
}
