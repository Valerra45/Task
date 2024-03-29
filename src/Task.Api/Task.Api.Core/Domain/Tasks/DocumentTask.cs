﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class DocumentTask : BaseEntity
    {
        public Guid UtId { get; set; }

        [ForeignKey("AuthorId")]
        public Guid AuthorId { get; set; }

        public virtual Responsible? Author { get; set; }

        [ForeignKey("ExecutorId")]
        public Guid ExecutorId { get; set; }

        public virtual Responsible? Executor { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Report { get; set; }

        public virtual Partner? Partner { get; set; }

        public virtual Importance? Importance { get; set; }

        public int Priority { get; set; }

        public virtual TaskType? TaskType { get; set; }

        public bool Viewed { get; set; }

        public bool Completed { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int OffSet { get; set; }

        public virtual List<TaskProduct>? TaskProducts { get; set; }
    }
}
