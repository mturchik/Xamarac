using System.ComponentModel;
using Xamarac.Services;
using Xamarin.Forms;

namespace Xamarac.Pages
{
    [DesignTimeVisible(false)]
    public partial class MorsePage : ContentPage
    {
        public MorsePage() => InitializeComponent();

        public void Short_Clicked(object sender, System.EventArgs e) => DecodeInput(".");
        public void Long_Clicked(object sender, System.EventArgs e) => DecodeInput("-");
        public void Space_Clicked(object sender, System.EventArgs e) => DecodeInput(" ");

        private string DecodedText = string.Empty;
        private string CodedTextStore = string.Empty;
        public void DecodeInput(string inp) {
            if (!string.IsNullOrWhiteSpace(inp))
                CodedTextStore += inp;
            else if(!string.IsNullOrWhiteSpace(CodedTextStore)) {
                DecodedText += Morse.MorseCoder(CodedTextStore);
                CodedTextStore = string.Empty;
                message.Text = DecodedText;
            }
        }
    }
}
