using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace ExampleAppMobileDev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

		public TodoItemPage(bool isNew = false)
		{
			InitializeComponent();
			isNewItem = isNew;
		}

		async void OnSaveButtonClicked(object sender, EventArgs e)
		{	//Display alert to user 
            _ = DisplayAlert("Saved", "Todo item has been saved succesfully", "OK");
			var todoItem = (TodoItem)BindingContext;
			try //attempt to get location
			{
				var location = await Geolocation.GetLocationAsync();

				if (location != null)
				{
					//set location data on the fields from obtained location information
					Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
					todoItem.gps_lat = location.Latitude; 
					todoItem.gps_long = location.Longitude;
				}
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				Console.WriteLine("Handle not supported on device exception " + fnsEx.GetBaseException());
			}
			catch (FeatureNotEnabledException fneEx)
			{
				Console.WriteLine("Handle not enabled on device exception" + fneEx.GetBaseException());
			}
			catch (PermissionException pEx)
			{
				Console.WriteLine("Handle permission exception" + pEx.GetBaseException());
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to get location" + ex.GetBaseException());
			}
			//call the save task method, isNewItem will be set by constructor
			await App.TodoManager.SaveTaskAsync(todoItem, isNewItem);
			//pop the page to go back to the list
			await Navigation.PopAsync();
		}

		async void OnDeleteButtonClicked(object sender, EventArgs e)
		{
			//get the todo item from the context
			var todoItem = (TodoItem)BindingContext;
			//send item to the delete function
			await App.TodoManager.DeleteTaskAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelButtonClicked(object sender, EventArgs e)
		{
			//cancel back to the list view
			await Navigation.PopAsync();
		}
	}
}
