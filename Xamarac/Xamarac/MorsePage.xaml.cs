using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarac
{
    [DesignTimeVisible(false)]
    public partial class MorsePage : ContentPage
    {
        public MorsePage()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, System.EventArgs e) => DecodeInput(((Button)sender).Text.Trim());

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
