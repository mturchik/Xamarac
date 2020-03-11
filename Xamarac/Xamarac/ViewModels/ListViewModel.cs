using System.Collections.ObjectModel;

namespace Xamarac.ViewModels
{
    public class ListViewModel
    {
        public string Comment { get; set; }

        public ListViewModel(string comment) => Comment = comment;

        static ListViewModel()
        {
            Comments = new ObservableCollection<ListViewModel>
            {
                new ListViewModel("I'm a lonely comment...")
            };
        }

        public static ObservableCollection<ListViewModel> Comments { private set; get; }
    }
}
