﻿using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Model
{
	public class Manager
	{
		private ILibraryManager LibraryManager { get; set; }
		private IUserLibraryManager UserLibraryManager { get; set; }

		public ReadOnlyCollection<Book> Books { get; private set; }
		private List<Book> books = new();
 
		public Manager(ILibraryManager libMgr, IUserLibraryManager userLibMgr)
		{
			LibraryManager = libMgr;
			UserLibraryManager = userLibMgr;
			Books = new ReadOnlyCollection<Book>(books);
		}

		public async Task<Book> GetBookById(string id)
			=> await LibraryManager.GetBookById(id);

        public async Task<Book> GetBookByISBN(string isbn)
			=> await LibraryManager.GetBookByISBN(isbn);

        public async Task<(long count, IEnumerable<Book> books)> GetBooksByTitle(string title, int index, int count, string sort = "")
		{
			var result = await LibraryManager.GetBooksByTitle(title, index, count, sort);
			return (result.Item1, result.Item2);
		}

        public async Task<(long count, IEnumerable<Book> books)> GetBooksByAuthorId(string authorId, int index, int count, string sort = "")
		{
			var result = await LibraryManager.GetBooksByAuthorId(authorId, index, count, sort);
			return (result.Item1, result.Item2);
		}

        public async Task<(long count, IEnumerable<Book> books)> GetBooksByAuthor(string author, int index, int count, string sort = "")
		{
			var result = await LibraryManager.GetBooksByAuthor(author, index, count, sort);
			return (result.Item1, result.Item2);
		}

        public async Task<Author> GetAuthorById(string id)
			=> await LibraryManager.GetAuthorById(id);

        public async Task<(long count, IEnumerable<Author> authors)> GetAuthorsByName(string substring, int index, int count, string sort = "")
		{
			var result = await LibraryManager.GetAuthorsByName(substring, index, count, sort);
			return (result.Item1, result.Item2);
		}

		public Task<Book> AddBookToCollection(string id)
		{
			return UserLibraryManager.AddBook(id);
		}

        public Task<(long count, IEnumerable<Book> books)> GetFavoritesBooks(int index, int count)
        {
            var result = UserLibraryManager.GetFavoritesBooks(index, count).Result;
            return Task.FromResult((result.Item1, result.Item2));
        }

        public Task<bool> AddToFavorites(string id)
        {
            return UserLibraryManager.AddToFavorites(id);
        }

        public Task<bool> RemoveFromFavorites(string id)
        {
            return UserLibraryManager.RemoveFromFavorites(id);
        }

        public Task<bool> RemoveBook(Book book)
        {
            return UserLibraryManager.RemoveBook(book);
        }

        public async Task<Book> GetBookByIdFromCollection(string id)
			=> await UserLibraryManager.GetBookById(id);


		public Task<Book> UpdateBook(Book book)
		{
			return UserLibraryManager.UpdateBook(book);
		}

		public Task<(long count, IEnumerable<Book> books)> GetBooksFromCollection(int index, int count, string sort = "")
		{
			var result = UserLibraryManager.GetBooksFromCollection(index, count, sort).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}

		public Task<(long count, IEnumerable<Contact> contacts)> GetContacts(int index, int count)
		{
			var result = UserLibraryManager.GetContacts(index, count).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}

		public Task<(long count, IEnumerable<Loan> loans)> GetCurrentLoans(int index, int count)
		{
			var result = UserLibraryManager.GetCurrentLoans(index, count).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}

		public Task<(long count, IEnumerable<Loan> loans)> GetPastLoans(int index, int count)
		{
			var result = UserLibraryManager.GetPastLoans(index, count).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}

		public Task<(long count, IEnumerable<Borrowing> borrowings)> GetCurrentBorrowings(int index, int count)
		{
			var result = UserLibraryManager.GetCurrentBorrowings(index, count).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}

		public Task<(long count, IEnumerable<Borrowing> borrowings)> GetPastBorrowings(int index, int count)
		{
			var result = UserLibraryManager.GetPastBorrowings(index, count).Result;
			return Task.FromResult((result.Item1, result.Item2));
		}
	}
}

