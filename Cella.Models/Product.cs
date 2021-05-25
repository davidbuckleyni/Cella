using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace Cella.Models
{
    public class Product
    {

        public int Id { get; set; }

        public enum Type
        {

            Goods = 1,
            Digital = 2,
            DownLoad = 3,
            Voucher = 4,
            GitfCard = 5,
            BalancePayment = 6
        }


        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }

        [StringLength(1000)]
        public string? StockCode { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(60)]
        public string? BarCode { get; set; }
          [StringLength(2000)]
        public string? ShortDescription { get; set; }

        [StringLength(5000)]
        public string? Name { get; set; }
        public string FullDescription { get; set; }
        [StringLength(5000)]
        public int? Categories { get; set; }
        [StringLength(5000)]
        public string? Manufactures { get; set; }
        public DateTime? AvailableStartDate { get; set; }

        public DateTime? AvailableEndDate { get; set; }
        public bool isShowCallButton { get; set; }
        public bool isNew { get; set; }
        [StringLength(1000)]
        public string? AdminComment { get; set; }
        public string? Tags { get; set; }
        public string? GTIN { get; set; }

        public string? ManufacturePartNo { get; set; }
        public bool? IsShowOnHomePage { get; set; }

        public int? StockItemType { get; set; }
        public bool? isShowPrice { get; set; }

        public bool? DisableAddToCart { get; set; }
        public bool? ShowCallForPrice { get; set; }

        public int? WarehouseLocation { get; set; }
        public int? ProductType { get; set; }

        public bool? isPublished { get; set; }

        public int? PriceListType { get; set; }
        public string? SKU { get; set; }


        //public virtual List<FileAttachments>? Photos { get; set; }

        public bool? isBackOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

    }
}
