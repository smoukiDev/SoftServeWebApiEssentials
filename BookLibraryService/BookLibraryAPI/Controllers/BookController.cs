// <copyright file="BookController.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookLibraryBusinessLogic.Models;
    using BookLibraryBusinessLogic.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a controller
    /// for handling the requests related
    /// to BookLibrary Service
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    // TODO: Rename route
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private const string BAD_REQUEST = "No book with such an id in the library";

        /// <summary>
        /// The book library service interface link
        /// </summary>
        private IBookLibrary bookLibrary;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BookController"/> class.
        /// </summary>
        /// <param name="bookLibrary">
        /// The book library.
        /// </param>
        public BookController(IBookLibrary bookLibrary)
        {
            this.bookLibrary = bookLibrary;
        }

        /// <summary>
        /// Gets all the books in library.
        /// </summary>
        /// <returns>Books collection</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IActionResult result = this.NotFound();

            try
            {
                List<Book> books;
                books = this.bookLibrary.GetLibraryBooks().ToList();
                if (books.Count > 0)
                {
                    result = this.Ok(books);
                }
                else
                {
                }
            }
            catch (ArgumentException ex)
            {
                result = this.NotFound(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier of book.</param>
        /// <returns>Concrete book</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult result = this.NotFound();

            Book targetBook = this.bookLibrary.GetBookById(id);
            if (targetBook != null)
            {
                result = this.Ok(targetBook);
            }
            else
            {
            }

            return result;
        }

        /// <summary>
        /// Adds the specified new book.
        /// </summary>
        /// <param name="newBook">The new book.</param>
        /// <returns>
        /// RedirectResult displaying all the books of library
        /// </returns>
        [HttpPost]
        public IActionResult Add([FromBody] Book newBook)
        {
            this.bookLibrary.AddBook(newBook);
            return this.Redirect("book");
        }

        /// <summary>
        /// Updates the book by identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of existed book in library.
        /// </param>
        /// <param name="newBook">The new book.</param>
        /// <returns>
        /// <see cref="IActionResult" /> result.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book newBook)
        {
            IActionResult result = this.BadRequest(BAD_REQUEST);

            if (this.bookLibrary.UpdateBook(id, newBook))
            {
                result = this.Ok();
            }
            else
            {
            }

            return result;
        }

        /// <summary>
        /// Deletes the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// <see cref="IActionResult" /> result.
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result = this.BadRequest(BAD_REQUEST);

            if (this.bookLibrary.RemoveBook(id))
            {
                result = this.Ok();
            }
            else
            {
            }

            return result;
        }
    }
}