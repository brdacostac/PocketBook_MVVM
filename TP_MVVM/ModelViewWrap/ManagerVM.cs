﻿using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ModelViewWrap;


namespace ModelViewWrap
{ 
    public class ManagerVM
    {
        private Manager managerModel;

        public Manager Model
        {
            get => managerModel;
            set => managerModel = value;
        }

        Collection<BookVM> books = new Collection<BookVM>();

        public Collection<BookVM> Books
        {
            get => books;
            set => books = value;
        }

        public ICommand GetBooksCommand { get; set; }


        public ManagerVM(Manager managerModel)
        {

            this.managerModel = managerModel;

            GetBooksCommand = new Command(() =>
            {
                this.Books = (await managerModel.GetBooksByTitle("", 0, 10)).books.Select(book => new BookVM(book));
            });
            


        }
    }
    
}