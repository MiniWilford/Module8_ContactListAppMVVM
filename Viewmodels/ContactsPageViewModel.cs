using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Module8_ContactListAppMVVM.Models;
using System.Threading.Tasks;
using Module8_ContactListAppMVVM.Views;

namespace Module8_ContactListAppMVVM.Viewmodels
{
	public partial class ContactsPageViewModel : ObservableObject
	{

		// Fetch/Set Navigation (enables push/pop functionality from VM)
		public INavigation Navigation { get; set; }


		// Add contacts property
		[ObservableProperty]
		private ObservableCollection<Models.Contact> contacts;


		// Grab currently selected contact by user
		[ObservableProperty]
		private Models.Contact selectedContact;


		// Constructor to include current contacts in collection
		public ContactsPageViewModel(ObservableCollection<Models.Contact> contactsCollection) 
		{
			Contacts = contactsCollection;
		}


		// For the Button to go to Add Contact page
		[RelayCommand]
		private async void GoToAddContactPage()
		{
			await Navigation.PushAsync(new Views.MainPage());
		}


		// Return contact tapped when selected contact changes
		partial void OnSelectedContactChanged(Models.Contact contactSelected)
		{
			if (contactSelected == null)
			{
				// Do nothing on no selected contact
				return;
			}

			// Navigate to details page
			Navigation.PushAsync(new Views.ContactDetailsPage(contactSelected));

			// Clear contact selection
			SelectedContact = null;
		}
	}
}
