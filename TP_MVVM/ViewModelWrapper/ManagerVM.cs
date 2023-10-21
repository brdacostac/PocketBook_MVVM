using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Model;
using MyToolKit;

namespace ViewModelWrapper
{
    public class ManagerVM : BaseViewModel<Manager>
    {

        private int nbPages;
        private int index = 1;
        private int nbBooks;
        private int count = 10;
        private readonly ObservableCollection<BookVM> books = new();
        private readonly ObservableCollection<AuthorVM> authors = new();
        private BookVM book;

        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

        public int NbBooks
        {
            get => nbBooks;
            set
            {
                SetProperty(ref nbBooks, value);
                OnPropertyChanged(nameof(nbPages));
            }
        }

        
        public int NbPages
        {
            get => nbPages;
            set => SetProperty(ref nbPages, value);
        }

        public int Count
        {
            get => count;
            set
            {
                SetProperty(ref count, value);
                OnPropertyChanged(nameof(nbPages));
            } 
        }


        public ReadOnlyObservableCollection<BookVM> Books
        {
            get;
            set;
        }

        public ObservableCollection<AuthorVM> Authors
        {
            get => authors;
        }

        public BookVM CurrentBook
        {
            get => book;
            set => SetProperty(ref book, value);

        }



        private IEnumerable<IGrouping<string, BookVM>> groupedBooks;

        public IEnumerable<IGrouping<string, BookVM>> GroupedBooks
        {
            get => groupedBooks;
            set => SetProperty(ref groupedBooks, value);
        }

        public ICommand GetAuthorsCommand { get; set; }

        public ICommand GetBooksCommand { get; set; }

        public ICommand GetBookCommand { get; set; }

        public ICommand NextPageCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }



        public ManagerVM(ILibraryManager libraryManager, IUserLibraryManager userLibraryManager)
            : base(new Manager(libraryManager, userLibraryManager))
        {
            Books = new(books);
            GetBooksCommand = new RelayCommand(async () => GetBooksFromCollection());
            NextPageCommand = new RelayCommand(async () => NextPage());
            PreviousPageCommand = new RelayCommand(async () => PreviousPage());
            GetBookCommand = new RelayCommand<BookVM>(async (BookVM currentBook) => await GetBookById(currentBook));
            GetAuthorsCommand = new RelayCommand(async () => GetAllAuthors());

        }


        private async Task GetBooksFromCollection()
        {
            var result = await Model.GetBooksFromCollection(Index -1, Count, "");
            NbBooks = (int)result.count;
            NbPages = ((NbBooks-1)/Count)+1;
            books.Clear();

            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                books.Add(book);
            }

            GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);

        }

        private async Task GetBookById(BookVM book)
        {
            var result = await Model.GetBookById(book.Id);
            CurrentBook = new BookVM(result);

        }

        private async Task GetAllAuthors()
        {
            var result = await Model.GetBooksFromCollection(0, 999);
            IEnumerable<Book> allbooks = result.books;
            books.Clear();
            authors.Clear();

            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                foreach (var author in book.Authors)
                {
                    authors.Add(author);
                    author.NbBooksByAuthor++;
                }
            }

        }

        public async Task NextPage()
        {
            if(Index != NbPages)
                Index++;
            await GetBooksFromCollection();
        }

        public async Task PreviousPage()
        {
            if(Index != 1)
                Index--;
            await GetBooksFromCollection();
        }


    }
}