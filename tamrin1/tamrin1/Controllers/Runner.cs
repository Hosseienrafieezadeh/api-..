using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tamrin1.Entitis;
using tamrin1.EntitisMapas;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace tamrin1.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class Runner : ControllerBase
    {
        private EFDBContextcs _eFDBContext = new();
        [HttpPost("add-person")]
        public void Addperson([FromQuery] PersonDtocs personDtocs)
        {
            var personsss = new Person
            {
                Name = personDtocs.Name,
                RegistryDate = DateTime.Now
            };
            _eFDBContext.Persons.Add(personsss);
            _eFDBContext.SaveChanges();
        }
        [HttpGet("show-person")]
        public List<Person> Showperson()
        {

            return _eFDBContext.Persons.Include(_ => _.Books).ToList();

        }
        [HttpPatch("update-person/{id}")]
        public void updateperson([FromRoute] int id, [FromQuery] PersonDtocs personDtocs)
        {
            var pers = _eFDBContext.Persons.FirstOrDefault(_ => _.Id == id);
            pers.Name = personDtocs.Name;

            _eFDBContext.Persons.Add(pers);
            _eFDBContext.SaveChanges();
        }
        [HttpDelete("Delete-person{id}")]
        public void Deleteperson([FromRoute] int id, [FromQuery] PersonDtocs personDtocs)
        {
            var pers = _eFDBContext.Persons.FirstOrDefault(_ => _.Id == id);


            _eFDBContext.Persons.Remove(pers);
            _eFDBContext.SaveChanges();
        }
        [HttpPost("add-books")]
        public void AddBooks([FromQuery] BooksDto booksDto)
        {
            var book = new Book
            {
                Name = booksDto.Name,
                Count = booksDto.Count,
                Price = booksDto.Price

            };
            _eFDBContext.Books.Add(book);
            _eFDBContext.SaveChanges();
        }
        [HttpGet("show-books")]
        public List<Book> ShowBooks()
        {

            return _eFDBContext.Books.Include(_ => _.Person).ToList();

        }
        [HttpPatch("update-Books/{id}")]
        public void updateBooks(int id, [FromQuery] BooksDto booksDto)
        {
            var pers = _eFDBContext.Books.FirstOrDefault(_ => _.Id == id);
            pers.Name = booksDto.Name;
            pers.Count = booksDto.Count;
            pers.Price = booksDto.Price;
            _eFDBContext.Books.Add(pers);
            _eFDBContext.SaveChanges();
        }
        [HttpDelete("Delete-Books/{id}")]
        public void DeleteBooks(int id, [FromQuery] PersonDtocs personDtocs)
        {
            var pers = _eFDBContext.Books.FirstOrDefault(_ => _.Id == id);


            _eFDBContext.Books.Remove(pers);
            _eFDBContext.SaveChanges();
        }
        [HttpPatch("ad/dd")]
        public void AddBookToPerson([FromBody] BookPersonDto bookPersonDto)
        {
            var books = _eFDBContext.Books.FirstOrDefault(_ => _.Name == bookPersonDto.BookName);
            var person = _eFDBContext.Persons.FirstOrDefault(_ => _.Name == bookPersonDto.PersonName);

            if (books != null && person != null)
            {
                books.PersonId = person.Id;
                _eFDBContext.SaveChanges();
            }
        }




    }
}
