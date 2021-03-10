using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleAppMobileDev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepositoryPage : ContentPage
    {
        IRepositoryRestService restService;

        public RepositoryPage(IRepositoryRestService service)
        {
            InitializeComponent();
            restService = service;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Reps clicked");
            List<Repository> repositories = await restService.GetRepositoriesAsync(Constants.GitHubReposEndpoint);
            collectionView.ItemsSource = repositories;
        }

    }
}