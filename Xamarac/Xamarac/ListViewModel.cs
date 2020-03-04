using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Xamarac
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
