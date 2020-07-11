using System;
using System.Collections.Generic;
using System.Text;

namespace Stopaj_Data.Entity
{
   public class UserFilePath:BaseEntity
    {
        public int DealerId { get; set; }
        public string Path { get; set; }
        public DateTime FileDate { get; set; }
        public int SftpId { get; set; }
    }
}
