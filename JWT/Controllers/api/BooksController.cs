using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWT.Controllers.api
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet, Authorize]
        public IEnumerable<Book> Get([FromHeader(Name="Accept")] string accept)
        {
            var currentUser = HttpContext.User;
            var resultBookList = new Book[] {
            new Book { Author = "Ray Bradbury",Title = "Fahrenheit 451" },
            new Book { Author = "Gabriel García Márquez", Title = "One Hundred years of Solitude" },
            new Book { Author = "George Orwell", Title = "1984" },
            new Book { Author = "Anais Nin", Title = "Delta of Venus" }
            };

            var claims = currentUser.Claims;
            

            return resultBookList;
        }

        public class Book
        {
            public bool AgeRestriction { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
        }
    }
}