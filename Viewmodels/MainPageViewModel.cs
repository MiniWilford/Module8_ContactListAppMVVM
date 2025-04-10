using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Module8_ContactListAppMVVM.Models;
using Module8_ContactListAppMVVM.Views;


namespace Module8_ContactListAppMVVM.Viewmodels
{
	public partial class MainPageViewModel : ObservableObject
	{
		// Get current navigation to ensure data can be pushed to ContactsPage
		public INavigation Navigation { get; set; }

		// Store user inputs for our contacts
		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private string email;

		[ObservableProperty]
		private string phone;

		[ObservableProperty]
		private string description;


		// Properties for placeholders to relay errors to users
		[ObservableProperty]
		private string namePlaceholder = "Please enter a name.";

		[ObservableProperty]
		private Color namePlaceholderColor = Colors.Gray;  // Reference for color placeholder solution: https://stackoverflow.com/questions/72901517/net-maui-how-to-reference-a-color-in-a-binding

		[ObservableProperty]
		private string emailPlaceholder = "Please enter an email.";

		[ObservableProperty]
		private Color emailPlaceholderColor = Colors.Gray;  

		[ObservableProperty]
		private string phonePlaceholder = "Please enter a phone number.";

		[ObservableProperty]
		private Color phonePlaceholderColor = Colors.Gray; 


		// Bind contact information to XAML
		[RelayCommand]
		private async void SaveContactsAsync()
		{
			// Perform checks to ensure no empty contacts can be added
			if(string.IsNullOrEmpty(Name))
			{
				NamePlaceholder = "Please do not leave the name blank";
				NamePlaceholderColor = Colors.Red; // Red for alerting the user of invalid entry
				return;
			}
			if(string.IsNullOrEmpty(Email) || !Email.Contains('@'))
			{
				Email = ""; // Clear field for placeholder text to show error
				EmailPlaceholder = "Please make sure to include a valid email address.";
				EmailPlaceholderColor = Colors.Red;
				return;
			}
			if (string.IsNullOrEmpty(Phone) || !Phone.Contains('-'))
			{
				Phone = ""; // Clear field for placeholder text to show error
				PhonePlaceholder = "Please enter a valid phone number.";
				PhonePlaceholderColor = Colors.Red;
				return;
			}


			// Create new contact
			var newContact = new Models.Contact
			{
				Name = Name,
				Email = Email,
				Phone = Phone,
				Description = Description
			};

			// Add the new contact made into the list
			App.ContactsCollection.Add(newContact);

			// Reset fields to prevent duplicates
			Name = string.Empty;
			Email = string.Empty;
			Phone = string.Empty;
			Description = string.Empty;

			// Navigate to the Contacts Page
			await Navigation.PushAsync(new Views.ContactsPage(new ContactsPageViewModel(App.ContactsCollection)));

		}

	}
}
