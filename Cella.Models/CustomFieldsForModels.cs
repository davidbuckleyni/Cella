using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
   public  class CustomFieldsForModels {

       public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? ControllerName { get; set; }

       public int? FormSection { get; set; }

        public int? FieldType { get; set; }

        public string? ValidationMessage { get; set; }


        public string? PlaceHolder { get; set; }


       public bool? IsRequired { get; set; }


       public int? Order { get; set; }

       public string? CreatedBy { get; set; }

       public bool? isActive { get; set; }

       public bool? isDeleted { get; set; }

    }
}
