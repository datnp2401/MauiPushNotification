namespace MauiPushNotification
{
    public partial class App : Application
    {     
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();   
        }
        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            //var currentPage = _appNavigationService.GetCurrentPage();
            //var currentPage = Application.Current.Windows[0].Page;
            //var currentPage = Shell.Current.CurrentPage;


            //currentPage.HandleDeepLinkRequest(uri);
        }
    }
}
