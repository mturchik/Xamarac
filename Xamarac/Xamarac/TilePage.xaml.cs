using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TilePage : ContentPage
    {
        public TilePage() => InitializeComponent();
        
        private void Button_OnClicked(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            if (btn.BackgroundColor == AppConstants.InactiveTile)
                btn.BackgroundColor = AppConstants.ActiveTile;
            else if (btn.BackgroundColor == AppConstants.ActiveTile)
                btn.BackgroundColor = AppConstants.InactiveTile;
        }
    }
}