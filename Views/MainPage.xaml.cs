using Module8_ContactListAppMVVM.Viewmodels;

namespace Module8_ContactListAppMVVM.Views
{
    public partial class MainPage : ContentPage
    {

        private MainPageViewModel _viewModel;


        public MainPage()
        {
            InitializeComponent();

            // Pass page navigation to viewmodel & ensure to bind viewmodel to BindingContext
            _viewModel = new MainPageViewModel();
            _viewModel.Navigation = this.Navigation;
            BindingContext = _viewModel;
        }
    }

}
