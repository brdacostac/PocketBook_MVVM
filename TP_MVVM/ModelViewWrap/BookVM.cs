using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewWrap
{
    public class BookVM
    {
        
        private Book model;
        public Book BookModel { get => model; set => model = value; }

        public string Id { get=> model.Id; set => model.Id = value; }
        public string Title { get => model.Title; set => model.Title = value; }


        public BookVM(Book bookModel)
        {
            this.model = bookModel;
        }

    }
}
