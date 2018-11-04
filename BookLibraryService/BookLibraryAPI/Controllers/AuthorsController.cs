// <copyright file="AuthorsController.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookLibraryBusinessLogic.Models;
    using BookLibraryBusinessLogic.Service;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    /// <summary>
    /// Represents a controller
    /// for handling the requests related
    /// to Authors in Library Service
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("library/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private const string BAD_REQUEST = "No author with such an id in the library.";
        private const string NOT_FOUND = "Target item is not found.";

        /// <summary>
        /// The book library service interface link
        /// </summary>
        private ILibraryService bookLibrary;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="bookLibrary">
        /// The book library.
        /// </param>
        public AuthorsController(ILibraryService bookLibrary)
        {
            this.bookLibrary = bookLibrary;
        }

        /// <summary>
        /// Gets all the authors of the books in library.
        /// </summary>
        /// <returns>Authors collection.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            IActionResult result = this.NotFound(NOT_FOUND);

            List<Author> authors = this.bookLibrary.GetAllAuthors();
            if (authors.Count > 0)
            {
                result = this.Ok(authors);
            }

            return result;
        }

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier of author.</param>
        /// <returns>Concrete autor</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult result = this.NotFound(NOT_FOUND);

            Author targetAuthor = this.bookLibrary.GetAuthorById(id);
            if (targetAuthor != null)
            {
                result = this.Ok(targetAuthor);
            }

            return result;
        }

        /// <summary>
        /// Adds the specified new author.
        /// </summary>
        /// <param name="author">The new author.</param>
        /// <returns>
        /// <see cref="IActionResult" /> result.
        /// </returns>
        [HttpPost]
        public IActionResult Add([FromBody] Author author)
        {
            this.bookLibrary.AddAuthor(author);
            return this.Created("authors", author);
        }

        /// <summary>
        /// Updates the author by identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of existed author in library.
        /// </param>
        /// <param name="author">The new author.</param>
        /// <returns>
        /// <see cref="IActionResult" /> result.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Author author)
        {
            IActionResult result = this.BadRequest(BAD_REQUEST);

            if (this.bookLibrary.UpdateAuthor(id, author))
            {
                result = this.Ok(this.bookLibrary.GetAuthorById(id));
            }

            return result;
        }

        /// <summary>
        /// Deletes the author by identifier and all his books.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// <see cref="IActionResult" /> result.
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result = this.BadRequest(BAD_REQUEST);

            if (this.bookLibrary.RemoveAuthor(id))
            {
                result = this.Ok($"Author with id = {id} and his books were successfully removed.");
            }

            return result;
        }
    }
}