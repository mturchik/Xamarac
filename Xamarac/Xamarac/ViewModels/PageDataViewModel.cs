using System;
using System.Collections.Generic;
using Xamarac.Pages;

namespace Xamarac.ViewModels
{
    public class PageDataViewModel
    {
        public PageDataViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public Type Type { get; }

        public string Title { get; }

        public string Description { get; }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {
                new PageDataViewModel(typeof(MorsePage), "Morse Code",
                                      "Only haveing one button was a lie."),
                new PageDataViewModel(typeof(TilePage), "Tiles",
                                      "Flip, for no reason except it may flop."),
                new PageDataViewModel(typeof(ListPage), "List",
                                      "I love lists!!! I learned this from Tyler!"),
                new PageDataViewModel(typeof(PersonalityPage), "Personality",
                                      "Take a Spongebob Personality test, personalized to YOU!")
            };
        }

        public static IList<PageDataViewModel> All { get; }
    }
}