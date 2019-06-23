using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiInClientwithJWT.Models
{
    public class Api
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
