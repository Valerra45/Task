﻿namespace Tasks.Api.Core.Domain.Tasks
{
    public class Partner : BaseEntity
    {
        public Guid GUID { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public string? Phone { get; set; }

        public virtual List<DocumentTask>? DocumentTasks { get; set; }
    }
}
