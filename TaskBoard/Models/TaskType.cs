using System;
using System.Collections.Generic;

namespace TaskBoard.Models
{
    public partial class TaskType
    {
        public TaskType()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
