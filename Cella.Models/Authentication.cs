using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Models
{
    public class Authentication
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string JWTToken { get; set; }
    }
}
