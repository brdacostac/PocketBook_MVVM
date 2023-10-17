﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Model;
using MyToolKit;

namespace ViewModelWrapper
{
    public class ManagerVM : BaseViewModel<Manager>
    {

        private int nbPages;
        private int index;
        private int nbBooks;
        private int count = 10;

        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

        public int NbBooks
        {
            get => nbBooks;
            set => SetProperty(ref nbBooks, value); //on property changed pour nb pages
        }

        
        public int NbPages
        {
            get => nbPages;
            set => SetProperty(ref nbPages, value);
        }

        public int Count
        {
            get => count;
            set => count = value; //on property changed pour nb pages
        }

        public readonly ObservableCollection<BookVM> books = new ();


        public ReadOnlyObservableCollection<BookVM> Books
        {
            get;
            set;
        }

        public ICommand GetBooksCommand { get; set; }


        public ManagerVM(ILibraryManager libraryManager, IUserLibraryManager userLibraryManager)
            : base(new Manager(libraryManager, userLibraryManager))
        {
            Books = new(books);
            GetBooksCommand = new RelayCommand(async () => GetBooksFromCollection());
                  
        }


        private async Task GetBooksFromCollection()
        {
            var result = await Model.GetBooksFromCollection(Index, Count, "");
            NbBooks = (int)result.count;
            NbPages = (NbBooks / Count);
            books.Clear();

            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                books.Add(book);
            }
        }

    }
}