using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarac
{
    public class PageDataViewModel
    {
        public PageDataViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public Type Type { private set; get; }

        public string Title { private set; get; }

        public string Description { private set; get; }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {
                new PageDataViewModel(typeof(MorsePage), "Morse Code",
                                      "Only haveing one button was a lie."),
                new PageDataViewModel(typeof(TilePage), "Tiles",
                                      "Flip, for no reason except it may flop."),
                new PageDataViewModel(typeof(ListPage), "List",
                                      "I love lists!!! I learned this from Tyler!")
            };
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}