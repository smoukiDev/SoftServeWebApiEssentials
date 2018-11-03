// <copyright file="LibraryServiceTests.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogicTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Models;
    using BookLibraryBusinessLogic.Service;
    using Moq;

    /// <summary>
    /// Provides Test Methods for class LibraryService
    /// aimed on books management functionality.
    /// </summary>
    [TestClass]
    public class LibratyServiceTests
    {
        /// <summary>
        /// List of default books to use
        /// mocking IDataProvider.
        /// </summary>
        private List<Book> books;
        /// <summary>
        /// List of default authors to use
        /// mocking IDataProvider.
        private List<Author> authors;

        /// <summary>
        /// LibraryService object under testing.
        /// </summary>
        private LibraryService libraryService;

        /// <summary>
        /// IDataProvider Mock.
        /// </summary>
        Mock<IDataProvider> mockDataProvider;

        /// <summary>
        /// Initialize required object before start of
        /// every test method.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            int counter = 0;
            books = new List<Book>()
            {
                new Book(++counter, new DateTime(2017,07,07),"Title1", 3),
                new Book(++counter, new DateTime(2018,08,08),"Title2", 1),
                new Book(++counter, new DateTime(2016,06,06),"Title3", 2)
            };

            counter = 0;
            authors = new List<Author>()
            {
                new Author(++counter, "FirstName1","LastName1"),
                new Author(++counter, "FirstName2","LastName2", null),
                new Author(++counter, "FirstName3","LastName3", "NickName"),
            };

            mockDataProvider = new Mock<IDataProvider>();

        }

        #region BooksManagementTestMethods

        /// <summary>
        /// Checks whether method GetAllBooks
        /// return collection of all available books correctly.
        /// </summary>
        [TestMethod]
        public void GetAllBooks_ReturnsAllBooksSuccessfully()
        {
            // Arrange
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            List<Book> expected = books;
            List<Book> actual;

            // Act
            actual = libraryService.GetAllBooks();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method GetBookById
        /// return required book correctly.
        /// </summary>
        [TestMethod]
        public void GetBookById_ReturnsBookWithSpecifiedId()
        {
            // Arrange
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            int bookId = 1;
            Book expected = books[0];
            Book actual;

            // Act
            actual = libraryService.GetBookById(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBook
        /// adds book to library and returns BookId of new bool.
        /// </summary>
        [TestMethod]
        public void AddBook_ReturnsIdOfBookJustHasBeenAdded()
        {
            // Arrange
            int expected = 4;
            int actual;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            Book newBook = new Book(expected, DateTime.Now, "Title4", null);
            

            // Act
            actual = libraryService.AddBook(newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBook
        /// removes book by identifier from library correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        [TestMethod]
        public void RemoveBook_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.RemoveBook(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBook
        /// removes book by identifier from library correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveBook_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.RemoveBook(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateBook
        /// updates all information about book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void UpdateBook_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            Book newBook = new Book(7, DateTime.Now, "Title7", null);


            // Act
            actual = libraryService.UpdateBook(bookId, newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateBook
        /// updates all information about book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void UpdateBook_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);
            Book newBook = new Book(7, DateTime.Now, "Title7", null);


            // Act
            actual = libraryService.UpdateBook(bookId, newBook);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBookAutor removes
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void RemoveBookAutor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.RemoveBookAutor(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveBookAutor removes
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveBookAutor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.RemoveBookAutor(bookId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBookAutor add
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void AddBookAutor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int bookId = 3;
            int authorId = 5;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.AddBookAuthor(bookId, authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddBookAutor add
        /// reference on author in book
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void AddBookAutor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int bookId = 13;
            int authorId = 5;
            mockDataProvider.Setup(b => b.Books).Returns(books);
            libraryService = new LibraryService(mockDataProvider.Object);


            // Act
            actual = libraryService.AddBookAuthor(bookId, authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AuthorsManagementTestMethods

        /// <summary>
        /// Checks whether method GetAllAuthors
        /// return collection of all available authors correctly.
        /// </summary>
        [TestMethod]
        public void GetAllAuthors_ReturnsAllAuthorsSuccessfully()
        {
            // Arrange
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            List<Author> expected = authors;
            List<Author> actual;

            // Act
            actual = libraryService.GetAllAuthors();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method GetAuthorById
        /// return required author correctly.
        /// </summary>
        [TestMethod]
        public void GetAuthorById_ReturnsAuthorWithSpecifiedId()
        {
            // Arrange
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            int authorId = 1;
            Author expected = authors[0];
            Author actual;

            // Act
            actual = libraryService.GetAuthorById(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method AddAuthor
        /// adds author to library and returns AuthorId of new author.
        /// </summary>
        [TestMethod]
        public void AddAuthor_ReturnsIdOfAuthorJustHasBeenAdded()
        {
            // Arrange
            int expected = 4;
            int actual;
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            Author newAuthor = new Author(expected, "firstname", "lastname", null);

            // Act
            actual = libraryService.AddAuthor(newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveAuthor
        /// removes author by identifier from library correctly
        /// in case author with such an identifier is exist.
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int authorId = 3;
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);

            // Act
            actual = libraryService.RemoveAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method RemoveAuthor
        /// removes author by identifier from library correctly
        /// in case author with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int authorId = 13;
            mockDataProvider.SetupProperty(a => a.Authors, authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            
            // Act
            actual = libraryService.RemoveAuthor(authorId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateAuthor
        /// updates all information about author
        /// with specified identifier correctly
        /// in case author with such an identifier is exist.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void UpdateAuthor_ReturnsTrue()
        {
            // Arrange
            bool expected = true;
            bool actual;
            int authorId = 3;
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            Author newAuthor = new Author(7,"firstname", "lastname", null);


            // Act
            actual = libraryService.UpdateAuthor(authorId, newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks whether method UpdateAuthor
        /// updates all information about author
        /// with specified identifier correctly
        /// in case book with such an identifier isn't exist.
        /// </summary>
        [TestMethod]
        public void UpdateAuthor_ReturnsFalse()
        {
            // Arrange
            bool expected = false;
            bool actual;
            int authorId = 13;
            mockDataProvider.Setup(a => a.Authors).Returns(authors);
            libraryService = new LibraryService(mockDataProvider.Object);
            Author newAuthor = new Author(7, "firstname", "lastname", null);

            // Act
            actual = libraryService.UpdateAuthor(authorId, newAuthor);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
