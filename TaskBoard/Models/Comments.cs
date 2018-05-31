using System;
using System.Collections.Generic;

namespace TaskBoard.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? NextActionDate { get; set; }

        public Task Task { get; set; }
    }
}
