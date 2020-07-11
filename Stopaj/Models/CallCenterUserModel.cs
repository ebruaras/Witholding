using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stopaj.Models
{
    public class CallCenterUserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
