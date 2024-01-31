using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tamrin1.Entitis
{
    public class Book
    {
     
        public int Id { get; set; }

        public String Name { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int Price { get; set; }
        public int Count { get;  set; }
    }
}
