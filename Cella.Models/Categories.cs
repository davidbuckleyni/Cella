using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
    public class Categories
    {
        

        public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public int? Type { get; set; }
        public int? ParentId { get; set; }

        public string? Description { get; set; }
        public string? ShortDescription { get; set; }

        public string? Image { get; set; }

        public int? SortOrder { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
    }
}
