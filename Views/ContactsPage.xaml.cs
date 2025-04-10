using Module8_ContactListAppMVVM.Viewmodels;

namespace Module8_ContactListAppMVVM.Views
{
    public partial class ContactsPage : ContentPage
    {

        private ContactsPageViewModel _contactsPageViewModel;


        public ContactsPage(ContactsPageViewModel viewmodel)
        {
            InitializeComponent();

            // Bind viewmodel and add to navigation stack
            _contactsPageViewModel = viewmodel;
            _contactsPageViewModel.Navigation = this.Navigation;
            BindingContext = _contactsPageViewModel;
            
        }

	}

}
