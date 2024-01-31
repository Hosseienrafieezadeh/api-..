using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tamrin1.Entitis
{
    public class Person
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  DateTime RegistryDate { get; set; }
        
        public List<Book>  Books { get; set; }
    }
}
