using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Model;

namespace ViewModelWrapper
{
    public class ManagerVM 
    {
        private Manager managerModel;

        public Manager Model
        {
            get => managerModel;
            set => managerModel = value;
        }

        IEnumerable<BookVM> books = new ObservableCollection<BookVM>();

        public IEnumerable<BookVM> Books
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
                this.Books = (managerModel.GetBooksByTitle("", 0, 10)).Result.books.Select(book => new BookVM(book));
            });


        }
    }
}