using Module8_ContactListAppMVVM.Viewmodels;

namespace Module8_ContactListAppMVVM.Views
{
    public partial class ContactDetailsPage : ContentPage
    {

        private ContactDetailsViewModel _contactDetailsViewModel;

        public ContactDetailsPage(Models.Contact contactSelected)
        {
            InitializeComponent();
           
            // Bind viewmodel & pass contact selected onto page
            _contactDetailsViewModel = new ContactDetailsViewModel(contactSelected);
            _contactDetailsViewModel.Navigation = this.Navigation;
            BindingContext = _contactDetailsViewModel;

        }

	}

}
