using System;
using Xamarac.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarac.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                var pageData = args.SelectedItem as PageDataViewModel;
                var page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushAsync(page);
            }
        }
    }
}