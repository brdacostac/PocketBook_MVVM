using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;


namespace ViewModelWrapper
{
    public partial class ManagerVM : ObservableObject
    {
        [ObservableProperty]
        private int nbPages;

        [ObservableProperty]
        private int index = 1;

        [ObservableProperty]
        private int nbBooks;

        [ObservableProperty]
        private int count = 10;

        [ObservableProperty]
        private ObservableCollection<BookVM> books = new();

        [ObservableProperty]
        private ObservableCollection<AuthorVM> authors = new();

        [ObservableProperty]
        private ObservableCollection<BookVM> favoriteBooks = new();

        [ObservableProperty]
        private BookVM currentBook;

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                SetProperty(ref searchText, value);

                // Appel de la commande de recherche lorsque le texte va changer
                SearchAuthorsCommand.Execute(null);
            }
        }

        [ObservableProperty]
        private bool isFavorite;

        [ObservableProperty]
        public Manager model;

        [ObservableProperty]
        private IEnumerable<IGrouping<string, BookVM>> groupedBooks;




        public ManagerVM(Manager model)
        {
            Model = model;

        }

        [RelayCommand]
        private async Task AddBook(string isbn)
        {
            var book = await Model.GetBookByISBN(isbn);
            if (book != null)
            {
                await Model.AddBookToCollection(book.Id);
            }
        }

        [RelayCommand]
        private async Task RemoveBook(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveBook(book);
            await GetBooksFromCollection();
        }

        [RelayCommand]
        private async Task GetFavoriteBooks()
        {
            var result = await Model.GetFavoritesBooks(0, 999);
            IEnumerable<Book> allbooks = result.books;
            Books.Clear();
            FavoriteBooks.Clear();
            foreach (var book in allbooks.Select(book => new BookVM(book)))
            {
                FavoriteBooks.Add(book);
            }
        }

        [RelayCommand]
        private async Task AddFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.AddToFavorites(book.Id);
            await GetFavoriteBooks();
        }

        [RelayCommand]
        private async Task RemoveFavorites(BookVM bookVM)
        {
            var book = await Model.GetBookById(bookVM.Id);
            await Model.RemoveFromFavorites(book.Id);

        }

        [RelayCommand]
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

        [RelayCommand]
        private async Task GetBooksByAuthor(AuthorVM author)
        {
            var result = await Model.GetBooksByAuthor(author.Name,0,10);
            NbBooks = (int)result.count;
            NbPages = ((NbBooks - 1) / Count) + 1;
            Books.Clear();
            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                Books.Add(book);
            }

            GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);
        }

        [RelayCommand]
        private async Task GetBooksFromCollection()
        {
            var result = await Model.GetBooksFromCollection(Index -1, Count, "");
            NbBooks = (int)result.count;
            NbPages = ((NbBooks-1)/Count)+1;
            Books.Clear();

            var booksVM = result.books.Select(book => new BookVM(book));
            foreach (var book in booksVM)
            {
                Books.Add(book);
            }

            GroupedBooks = Books.GroupBy(b => b.Author).OrderBy(group => group.Key);

        }

        [RelayCommand]
        private async Task GetBookById(BookVM book)
        {
            var result = await Model.GetBookById(book.Id);
            CurrentBook = new BookVM(result);

        }

        [RelayCommand]
        private async Task GetAllAuthors(string searchText)
        {
            var result = await Model.GetBooksFromCollection(0, 999);
            IEnumerable<Book> allbooks = result.books;
            Books.Clear();
            Authors.Clear();

            var booksVM = result.books.Select(book => new BookVM(book));

            foreach (var book in booksVM)
            {
                foreach (var author in book.Authors)
                {
                    if (string.IsNullOrEmpty(searchText) || author.Name.Contains(searchText))
                    {
                        var existingAuthor = Authors.FirstOrDefault(a => a.Name == author.Name);


                        if (existingAuthor != null)
                        {
                            // Cette author est deja dans la liste alors on va juste incrementer son nbBooksByAuthor
                            existingAuthor.NbBooksByAuthor++;
                        }
                        else
                        {
                            Authors.Add(author);
                            author.NbBooksByAuthor ++;
                        }
                    }
                }
            }

        }

        [RelayCommand]
        private async Task SearchAuthors()
        {
            await GetAllAuthors(SearchText);
        }

        [RelayCommand]
        public async Task NextPage()
        {
            if(Index != NbPages)
                Index++;
            await GetBooksFromCollection();
        }

        [RelayCommand]
        public async Task PreviousPage()
        {
            if(Index != 1)
                Index--;
            await GetBooksFromCollection();
        }


    }
}