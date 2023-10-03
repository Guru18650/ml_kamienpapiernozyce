namespace ml_kolkokrzyzyk
{
    public partial class App : Application
    {
        public static string username;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Start());
        }
    }
}