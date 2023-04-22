namespace Cella.Models;

public class StockMovement : BaseEntity
{
    public int Id { get; set; }

    public int? StockId { get; set; }

    public int? PhysicalQty { get; set; }
    
    public int? QtyOnOrder { get; set; }

    public int? ActualQty { get; set; }
    
}