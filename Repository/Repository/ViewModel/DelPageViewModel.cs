

namespace Repository.ViewModel
{
  using GalaSoft.MvvmLight.Command;
  using Repository.Model;
  using Repository.Patterns;
  using Repository.Services;
  using Repository.View;
  using System.Windows.Input;
  using Xamarin.Forms;
  public class DelPageViewModel : BaseViewModel
  {
    

    private DialogService _dialogService;
    private string _nombre;

    #region Propiedades
    public string Nombre
    {
      get { return this._nombre; }
      set { _nombre = value; OnPropertyChanged(); }
    }
    #endregion

    public ICommand DelOne
    {
      get
      {
        return new RelayCommand(DelPerson);
      }
    }

    #region Constructor
    public DelPageViewModel()
    {
      _dialogService = new DialogService();
    }
    #endregion

    #region Metodos



    private async void DelPerson()
    {
      var per = SingletonRepository.Instancia.Repository.GetByName(Nombre);
      if (per == null)
      {
        await _dialogService.Message("Error al Encontrar",
           "No ha sido encontrar el registro");
        return;
      }
      await _dialogService.Message("Persona encontrada",
          "Persona" + per.nombre + ", " + per.apellido);

      Persona p = new Persona()
      {
        nombre = per.nombre,
        apellido=per.apellido,
        edad=per.edad,
        direccion=per.direccion
        
      };

      var del = SingletonRepository.Instancia.Repository.Delete(p);

      if (del ==false)
      {
        await _dialogService.Message("Error al eliminar", 
          "No ha sido posible eliminar el registro");
        return;
      }
      await _dialogService.Message("Accion exitosa", "El registro ha sido eliminado");
      Application.Current.MainPage = new NavigationPage(new Main());


    }

    #endregion

  }
}
