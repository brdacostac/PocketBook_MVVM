using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelWrapper
{
    public class BookVM 
    {

        private Book model;
        public Book BookModel { get => model; set => model = value; }

        public string Title { get => model.Title; set => model.Title = value; }

        public BookVM(Book bookModel)
        {
            this.model = bookModel;
        }

    }
}
