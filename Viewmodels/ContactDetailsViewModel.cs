using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Module8_ContactListAppMVVM.Viewmodels
{
	public partial class ContactDetailsViewModel : ObservableObject
	{

		// Get current navigation stack
		public INavigation Navigation { get; set; }


		[ObservableProperty]
		private Models.Contact currentContact;


		[ObservableProperty]
		private bool isBeingEdited;  // Track when edits are being made


		public ContactDetailsViewModel(Models.Contact contact) 
		{ 
			CurrentContact = contact;
		}

		// Toggle Editable Fields for "Edit" button
		[RelayCommand]
		private void EditContact()
		{
			IsBeingEdited = true;
		}

		// Save changes from edit
		[RelayCommand]
		private void SaveContactChanges()
		{
			IsBeingEdited = false;
		}

		[RelayCommand]
		private async void GoBack()
		{
			// Return previous page visited to user
			await Navigation.PopAsync();
		}
		

	}
}
