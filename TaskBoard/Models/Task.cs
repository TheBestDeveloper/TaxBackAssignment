using System;
using System.Collections.Generic;

namespace TaskBoard.Models
{
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? NextActionDate { get; set; }

        public TaskStatus StatusNavigation { get; set; }
        public TaskType TypeNavigation { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
