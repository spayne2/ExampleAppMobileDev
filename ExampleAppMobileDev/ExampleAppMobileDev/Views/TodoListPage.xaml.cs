using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ExampleAppMobileDev
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			//get the list of todo's and add them to the listview
			listView.ItemsSource = await App.TodoManager.GetTasksAsync();
		}

		async void OnAddItemClicked(object sender, EventArgs e)
		{	//load new todoitem page, pass true to the constructor so the app will call POST rather then PUT down the line
			await Navigation.PushAsync(new TodoItemPage(true)
			{
				BindingContext = new TodoItem
				{ //set the ID to a newly generated GUID
					ID = Guid.NewGuid().ToString()
				}
			});
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//load selected todo into the todoitem page
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}
