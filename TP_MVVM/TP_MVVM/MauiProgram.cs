using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TP_MVVM.View;
using TP_MVVM.ViewModel;
using ViewModelWrapper;
using Model;
using StubLib;
using TP_MVVM.View.Custom;

namespace TP_MVVM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SF-Compact-Display-Bold.ttf", "SFCompactDisplayBold");
                });

            builder.Services
                .AddSingleton<NavigationVM>()
                .AddSingleton<MainPage>()
                .AddSingleton<MainPageVM>()
                .AddSingleton<DatePublication>()
                .AddSingleton<Emprunts>()
                .AddSingleton<MyList>()
                .AddSingleton<Auteurs>()
                .AddSingleton<AuteursPageVM>()
                .AddSingleton<BookDetail>()
                .AddSingleton<BookDetailPageVM>()
                .AddSingleton<BookListPageVM>()
                .AddSingleton<ILibraryManager, LibraryStub>()
                .AddSingleton<IUserLibraryManager, UserLibraryStub>()
                .AddSingleton<Manager>()
                .AddSingleton<ManagerVM>()
                .AddSingleton<Favorites>()
                .AddSingleton<FavoritesPageVM>()
                .AddSingleton<CustomMenuPopUp>()
                .AddSingleton<CustomHeaderPopUpVM>()
                .AddSingleton<CustomHeader>()
                .AddSingleton<Book>()
                .AddSingleton<BookVM>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}