

namespace Repository.ViewModel
{
  using GalaSoft.MvvmLight.Command;
  using Repository.Model;
  using Repository.Patterns;
  using Repository.Services;
  using Repository.View;
  using System.Windows.Input;
  using Xamarin.Forms;
  class ActualizarViewModel : BaseViewModel
  {

    private DialogService _dialogService;
    Persona persona;
    //private string _nombre;
    //private string _apellido;
    //private string _direccion;
    //private int _edad;

    string old_nombre;
    string old_apellido;
    string old_direccion;
    int old_edad;


    public string Nombre
    {
      get { return old_nombre; }
      set { old_nombre = value; OnPropertyChanged(); }
    }
    public string Apellido
    {
      get { return old_apellido; }
      set { old_apellido = value; OnPropertyChanged(); }
    }
    public string Direccion
    {
      get { return old_direccion; }
      set { old_direccion = value; OnPropertyChanged(); }
    }
    public int Edad
    {
      get { return old_edad; }
      set { old_edad = value; OnPropertyChanged(); }
    }


    public ActualizarViewModel(Persona per)
    {
      _dialogService = new DialogService();
      persona = per;
      old_nombre = persona.nombre;
      old_apellido = persona.apellido;
      old_direccion = persona.direccion;
      old_edad = persona.edad;
    }

    public ICommand actualizar
    {
      get
      {
        return new RelayCommand(update);
      }
    }

    public ICommand cancelar
    {
      get
      {
        return new RelayCommand(cancel);
      }
    }

    public async void update()
    {
      Persona updatedPerson = new Persona();
      updatedPerson.nombre = Nombre;
      updatedPerson.apellido = Apellido;
      updatedPerson.direccion = Direccion;
      updatedPerson.edad = Edad;

      bool accion;
      accion = SingletonRepository.Instancia.Repository.Update(persona, updatedPerson);

      if (accion == false)
      {
        await _dialogService.Message("Notificacion",
           "No se ha podido actualizar la persona: " + updatedPerson.nombre + " " + persona.apellido);
      }
      await _dialogService.Message("Notificacion",
           "Se actualizó el registro de: " + updatedPerson.nombre + " " + persona.apellido + " correctamente ");
      Application.Current.MainPage = new NavigationPage(new Main());
    }
    public async void cancel()
    {
      await _dialogService.Message("Accion",
             "Usted ha cancelado");
    }
  }





}
