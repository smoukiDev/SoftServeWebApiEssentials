// <copyright file="BookGenerator.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Services
{
    using System;
    using System.Collections.Generic;
    using BookLibraryBusinessLogic.Models;

    /// <summary>
    /// Represents static method
    /// GenerateDefaultBooks
    /// in order to fill in
    /// the book library service
    /// by default books.
    /// </summary>
    internal static class BookGenerator
    {
        /// <summary>
        /// Generates the default books for service.
        /// </summary>
        /// <returns>List of books</returns>
        public static List<Book> GenerateDefaultBooks()
        {
            // Initialization of the book storage
            List<Book> books = new List<Book>(3);

            // Declaration of parameters
            string author;
            string title;
            DateTime date;
            Book book;

            // Add first book
            author = "James Corey";
            title = "Leviathan Wakes";
            date = new DateTime(2011, 06, 15);
            book = new Book(author, title, date);
            books.Add(book);

            // Add second book
            author = "Dmitry Glukhovsky";
            title = "Metro 2035";
            date = new DateTime(2016, 12, 10);
            book = new Book(author, title, date);
            books.Add(book);

            // Add third book
            author = "Andrew Troelsen";
            title = "Pro C# 7 - With .NET and .NET Core";
            date = new DateTime(2017, 03, 03);
            book = new Book(author, title, date);
            books.Add(book);

            return books;
        }
    }
}
