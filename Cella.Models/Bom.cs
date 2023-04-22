using System;
using System.ComponentModel.DataAnnotations;
namespace Cella.Models;

public class Bom : BaseEntity
{
    public int Id { get; set; }
    
    public string? Description { get; set; }
    
    
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
    public string? FullDescription { get; set; }
    
    
}