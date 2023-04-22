using System;
using System.ComponentModel.DataAnnotations;

namespace Cella.Models;

public class StockItem : BaseEntity
{
    public int Id { get; set; }

    public enum Type
    {

           Goods = 1,
           FoodItem=2,
            Toppings=3,
            Digital = 4,
            DownLoad = 5,
            Voucher = 6,
            GitftCard = 7
            
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

        public string? Price { get; set; }
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
        public bool? isShowOnHomePage { get; set; }

        public int? StockItemType { get; set; }
        public bool? isShowPrice { get; set; }

        public bool? canAddToCart { get; set; }
        public bool? ShowCallForPrice { get; set; }

        public int? WarehouseLocation { get; set; }
        public int? ProductType { get; set; }

        public bool? isPublished { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal? DefaultPrice { get; set; }
        public int? PriceList { get; set; }
        public int? PriceListType { get; set; }
        public string? SKU { get; set; }


        public  bool? isFeatured { get; set; }
        public bool? isBackOrder { get; set; }
     
}