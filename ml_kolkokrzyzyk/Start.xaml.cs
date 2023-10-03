namespace ml_kolkokrzyzyk
{
    public partial class Start : ContentPage
    {

        public Start()
        {
            InitializeComponent();
        }

        private async void start_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(uname.Text) )
            {
                await DisplayAlert("Błąd", "Wprowadź poprawne dane", "OK");
                return;
            }
            App.username = uname.Text;
            await Navigation.PushAsync(new Play());
            Navigation.RemovePage(this);
        }
    }
}