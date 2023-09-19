
using System;
using System.Collections.Generic;
using System.Text;
namespace Cella.Models {
    public  class AuthenicationResponseOjbect {
         public long Id { get; set; }


        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string FirstName { get; set; }

         public string LastName { get; set; }

         public string Username { get; set; }

         public string JwtToken { get; set; }
  
        public object RefreshToken { get; set; }
    }
}
