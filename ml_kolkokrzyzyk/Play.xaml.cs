using System.Drawing;

namespace ml_kolkokrzyzyk;

public partial class Play : ContentPage
{
    string wybrane = "";
    List<String> opcje = new List<String>() { "kamien", "papier", "nozyce" };
    Random rnd = new Random();
    int p1 = 0;
    int p2 = 0;
    int round = 1;
    public Play()
    {
        InitializeComponent();
        roundT.Text = $"Runda {round}";
        p1l.Text = $"{App.username}: {p1}";
    }

    private void btnkamien_Clicked(object sender, EventArgs e)
    {
        wybrane = "kamien";
        btnkamien.Background = Microsoft.Maui.Graphics.Color.FromRgba("A8FFB4");
        btnpapier.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");
        btnnozyce.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");
    }

    private void btnpapier_Clicked(object sender, EventArgs e)
    {
        wybrane = "papier";
        btnkamien.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");
        btnpapier.Background = Microsoft.Maui.Graphics.Color.FromRgba("A8FFB4");
        btnnozyce.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");

    }

    private void btnnozyce_Clicked(object sender, EventArgs e)
    {
        wybrane = "nozyce";
        btnkamien.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");
        btnpapier.Background = Microsoft.Maui.Graphics.Color.FromRgba("FFFFFF");
        btnnozyce.Background = Microsoft.Maui.Graphics.Color.FromRgba("A8FFB4");

    }

    private async void submit_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(wybrane))
            return;
        string enemyPick = opcje[rnd.Next(0, 3)];
        enemyPickText.Text = $"Przeciwnik wybra³: {enemyPick}";
        round++;
        roundT.Text = $"Runda {round}";
        if (wybrane == enemyPick)
        {
            wygrana.Text = "Remis";
        }
        else if ((wybrane == "kamien" && enemyPick == "nozyce") || (wybrane == "papier" && enemyPick == "kamien") || (wybrane == "nozyce" && enemyPick == "papier"))
        {
            p1++;
            wygrana.Text = "Wygra³eœ";
            p1l.Text = $"{App.username}: {p1}";
        }
        else
        {
            wygrana.Text = "Przegra³eœ";
            p2++;
            p2l.Text = $"Przeciwnik: {p2}";
        }
        if(p1 == 3)
        {
            await DisplayAlert("Gratulacje", "Wygra³eœ!", "OK");
            await Navigation.PushAsync(new Start());
            Navigation.RemovePage(this);

        }
        if (p2 == 3)
        {
            await DisplayAlert("Niestety", "Przegra³eœ", "OK");
            await Navigation.PushAsync(new Start());
            Navigation.RemovePage(this);

        }
    }
}