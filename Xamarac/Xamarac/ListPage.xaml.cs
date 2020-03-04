using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage() => InitializeComponent();

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cmnt = (ListViewModel) e.Item;
            if (cmnt is null)
                return;

            await DisplayAlert("Comment Tapped!", cmnt.Comment, "OK");

            ((ListView) sender).SelectedItem = null;
        }

        private void Entry_OnCompleted(object sender, EventArgs e)
        {
            var src = ((Entry) sender);
            var text = src.Text;

            ListViewModel.Comments.Add(new ListViewModel(text));
            src.Text = string.Empty;
        }
    }
}