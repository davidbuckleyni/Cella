using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models {
   public  class SalesOrderItem :BaseEntity {

    
        public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public Product StockItem { get; set; }
       [StringLength(50)]
        public string StockCode { get; set; }
       [StringLength(500)]
        public string Description { get; set; }


       public int Qty { get; set; }

        public decimal LinePrice { get; set;  }
        [StringLength(10)]
        public string Currency { get; set; }

       public DateTime OrderDate { get; set; }
     


    }
}
