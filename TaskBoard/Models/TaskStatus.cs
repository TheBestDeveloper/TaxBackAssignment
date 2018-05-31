using System;
using System.Collections.Generic;

namespace TaskBoard.Models
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
