using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolog_Andreea_Proiect.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
