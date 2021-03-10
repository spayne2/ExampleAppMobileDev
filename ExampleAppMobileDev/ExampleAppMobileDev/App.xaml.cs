using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleAppMobileDev
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }
 
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            TodoManager = new TodoItemManager(new ToDoRestService());
         }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
