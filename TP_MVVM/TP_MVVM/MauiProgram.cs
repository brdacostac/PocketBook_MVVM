﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TP_MVVM.View;
using TP_MVVM.ViewModel;

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
                .AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}