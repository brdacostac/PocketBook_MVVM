using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class BookDetailPageVM : BaseViewModel
    {
        public BookVM Book { get; private set; }
        public ManagerVM ManagerVM { get; private set; }

        public BookDetailPageVM(BookVM bookVM , ManagerVM managerVM)
        {
            Book = bookVM;
            ManagerVM = managerVM;
        }
    }
}
