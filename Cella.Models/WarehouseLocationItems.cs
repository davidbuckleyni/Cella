﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
   public class WarehouseLocationItems
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }

        public Guid? TeannatId { get; set; }

        public string? BarCode { get; set; }

        public string? StockCode { get; set; }

        public string? Name { get; set; }

        public string? BinName { get; set; }


        public string? BinIlse { get; set; }

        public String? BinLevel { get; set; }

        public int? BinNumber { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

    }
}
