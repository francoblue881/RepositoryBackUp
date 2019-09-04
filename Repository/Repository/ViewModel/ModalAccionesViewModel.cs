
namespace Repository.ViewModel
{
  using GalaSoft.MvvmLight.Command;
  using Repository.Model;
  using Repository.Patterns;
  using Repository.Services;
  using Repository.View;
  using System.Windows.Input;
  using Xamarin.Forms;

  public class ModalAccionesViewModel : BaseViewModel
  {
    private DialogService _dialogService;
    Persona persona;
    public ModalAccionesViewModel(Persona _elemento)
    {
      _dialogService = new DialogService();
      persona = _elemento;
    }

    public ICommand eliminar
    {
      get
      {
        return new RelayCommand(del);
      }
    }

    public ICommand actualizar
    {
      get
      {
        return new RelayCommand(update);
      }

    }


    public async void del()
    {


      bool accion;
      accion = SingletonRepository.Instancia.Repository.Delete(persona);

      if (accion == false)
      {
        await _dialogService.Message("Error al eliminar",
          "No ha sido posible eliminar el registro");
        return;
      }
      await _dialogService.Message("Accion exitosa", "El registro ha sido eliminado");
      Application.Current.MainPage = new NavigationPage(new Main());
    }

    public async void update()
    {
      Application.Current.MainPage.Navigation.PopModalAsync();
      Application.Current.MainPage = new NavigationPage(new Actualizar(persona));
    }

  }
}
