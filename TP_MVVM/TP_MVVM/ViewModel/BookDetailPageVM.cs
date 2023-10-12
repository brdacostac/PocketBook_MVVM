using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    class BookDetailPageVM : BaseViewModel
    {
        public BookVM Book { get; private set; }

        public BookDetailPageVM(BookVM bookVM)
        {
            Book = bookVM;
        }
    }
}
