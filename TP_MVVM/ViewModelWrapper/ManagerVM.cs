using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;


namespace ViewModelWrapper
{
    public partial class ManagerVM : ObservableObject
    {

        private int nbPages;
        private int index = 1;
        private int nbBooks;
        private int count = 10;
        private readonly ObservableCollection<BookVM> books = new();
        private readonly ObservableCollection<AuthorVM> authors = new();
        private readonly ObservableCollection<BookVM> favoriteBooks = new();
        private BookVM book;
        private string searchText;
        private bool isFavorite;
        public Manager Model { get; }
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

        public ObservableCollection<BookVM> FavoriteBooks
        {
            get => favoriteBooks;
        }

        public bool IsFavorite
        {
            get => isFavorite;
            set => SetProperty(ref isFavorite, value);
        }


        public string SearchText
        {
            get => searchText;
            set
            {
                SetProperty(ref searchText, value);

                // Appel de la methode de recherche lorsque le texte va changer
                SearchAuthors();
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

        public ICommand SearchCommand { get; set; }

        public ICommand GetBooksByAuthorCommand { get; set; }

        public ICommand GetFavoriteBooksCommand { get; private set; }

        public ICommand CheckIsFavoriteCommand { get; private set; }

        public ICommand AddFavoritesCommand { get; private set; }

        public ICommand RemoveFavoritesCommand { get; private set; }

        public ICommand RemoveBookCommand { get; private set; }

        public ICommand AddBookCommand { get; private set; }


        public ManagerVM(ILibraryManager libraryManager, IUserLibraryManager userLibraryManager)
        {
            Model = new Manager(libraryManager, userLibraryManager);
            Books = new(books);
            GetBooksCommand = new Command(async () => await GetBooksFromCollection());
            NextPageCommand = new Command(async () => await NextPage());
            PreviousPageCommand = new Command(async () => await PreviousPage());
            GetBookCommand = new Command<BookVM>(async (BookVM currentBook) => await GetBookById(currentBook));
            GetAuthorsCommand = new Command<string>(async (searchText) => await GetAllAuthors(searchText));
            SearchCommand = new Command(SearchAuthors);
            GetBooksByAuthorCommand = new Command<AuthorVM>(async (AuthorVM author) => await GetBooksByAuthor(author));
            GetFavoriteBooksCommand = new Command(async () => await GetFavoriteBooks());
            CheckIsFavoriteCommand = new Command<BookVM>(async bookVM => await CheckIsFavorite(bookVM));
            AddFavoritesCommand = new Command<BookVM>(async bookVM => await AddFavorites(bookVM));
            RemoveFavoritesCommand = new Command<BookVM>(async bookVM => await RemoveFavorites(bookVM));
            RemoveBookCommand = new Command<BookVM>(async (bookVM) => await RemoveBook(bookVM));
            AddBookCommand = new Command<string>(async (isbn) => await AddBook(isbn));

        }

        private async Task AddBook(string isbn)
        {
            var book = await Model.GetBookByISBN(isbn);
            if (book != null)
            {
                await Model.AddBookToCollection(book.Id);
            }
        }

        private async Task RemoveBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveBook(book);
            await GetBooksFromCollection();
        }

        private async Task GetFavoriteBooks()
        {
            var result = await Model.GetFavoritesBooks(0, 999);
            IEnumerable<Book> allbooks = result.books;
            books.Clear();
            favoriteBooks.Clear();
            foreach (var book in allbooks.Select(book => new BookVM(book)))
            {
                favoriteBooks.Add(book);
            }
        }

        private async Task AddFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.AddToFavorites(book.Id);
            await GetFavoriteBooks();
        }

        private async Task RemoveFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveFromFavorites(book.Id);

        }


        private async Task CheckIsFavorite(BookVM bookVM)
        {
            await GetFavoriteBooks();

            if (FavoriteBooks.Any(favoriteBook => favoriteBook.Id == bookVM.Id))
            {
                IsFavorite = true;
            }
            else
            {
                IsFavorite = false;
            }
        }

        private async Task GetBooksByAuthor(AuthorVM author)
        {
            var result = await Model.GetBooksByAuthor(author.Name,0,10);
            NbBooks = (int)result.count;
            NbPages = ((NbBooks - 1) / Count) + 1;
            books.Clear();
            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                books.Add(book);
            }

            GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);
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

        private async Task GetAllAuthors(string searchText)
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
                    if (string.IsNullOrEmpty(searchText) || author.Name.Contains(searchText))
                    {
                        var existingAuthor = authors.FirstOrDefault(a => a.Name == author.Name);


                        if (existingAuthor != null)
                        {
                            // Cette author est deja dans la liste alors on va juste incrementer son nbBooksByAuthor
                            existingAuthor.NbBooksByAuthor++;
                        }
                        else
                        {
                            authors.Add(author);
                            author.NbBooksByAuthor ++;
                        }
                    }
                }
            }

        }

        private async void SearchAuthors()
        {
            await GetAllAuthors(SearchText);
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