using Microsoft.Extensions.Logging;
using Module8_ContactListAppMVVM.Viewmodels;
using System.Collections.ObjectModel;
using Module8_ContactListAppMVVM.Views;


namespace Module8_ContactListAppMVVM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Add ObservableCollection for contacts
            var sharedContacts = new ObservableCollection<Models.Contact>();


            //// Add viewmodels
            //builder.Services.AddSingleton<MainPageViewModel>(singleton => new MainPageViewModel());
            //builder.Services.AddSingleton<ContactsPageViewModel>(singleton => new ContactsPageViewModel() 
            //{
            //    Contacts = sharedContacts
            //});
            //builder.Services.AddTransient<ContactDetailsViewModel>();


            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ContactsPage>();
            builder.Services.AddTransient<ContactDetailsPage>();



#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
