using System.Collections.ObjectModel;
using Module8_ContactListAppMVVM.Models;
using Module8_ContactListAppMVVM.Viewmodels;
using Module8_ContactListAppMVVM.Views;

namespace Module8_ContactListAppMVVM
{
    public partial class App : Application
    {

		public static ObservableCollection<Models.Contact> ContactsCollection { get; } = new ObservableCollection<Models.Contact>();

		public App()
        {
            InitializeComponent();
		}

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Enable stacknav
            return new Window(new NavigationPage(new MainPage()));
        }

    }
}