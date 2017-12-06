using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Url_Shortener.Models {
 
    public class Url {
        public int Id { get; set; }
        public string ShortURL { get; set; }
        public string LongURL { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastVisited { get; set; }
    }
}