using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleAppMobileDev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void onRepButtonClicked(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Reps clicked");
            await Navigation.PushModalAsync(page: new RepositoryPage(new RepositoryRestService()));
        }

        async void onTodoPageClicked(object sender, EventArgs e)
        {
            Console.Out.WriteLine("todos clicked");
            await Navigation.PushModalAsync(page: new NavigationPage(new TodoListPage()));
        }

    }
}
