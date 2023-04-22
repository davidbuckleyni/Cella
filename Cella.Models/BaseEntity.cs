using System;
using System.Runtime.InteropServices.JavaScript;

namespace Cella.Models;

public abstract class BaseEntity
{

    public bool? IsDeleted { get; set; }

    public bool? IsActive { get; set; }

    public bool? CreatedBy { get; set; }
    
    public DateTime? CreatedDate { get; set; }
    
    public DateTime? LastUpdateDate { get; set; }
    

}
