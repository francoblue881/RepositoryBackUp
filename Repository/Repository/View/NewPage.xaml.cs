

namespace Repository.View
{
  using Repository.ViewModel;
  using Xamarin.Forms;
  using Xamarin.Forms.Xaml;
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class NewPage : ContentPage
  {
    public NewPage()
    {
      InitializeComponent();
      BindingContext = new NewPageViewModel();
    }
  }
}