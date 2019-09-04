

namespace Repository.ViewModel
{
  using GalaSoft.MvvmLight.Command;
  using Repository.Model;
  using Repository.Patterns;
  using Repository.Services;
  using Repository.View;
  using System.Collections.ObjectModel;
  using System.Windows.Input;
  using Xamarin.Forms;
  public class MainViewModel : BaseViewModel
  {
    private DialogService _dialogService;

    Persona _elemento;
    public Persona Elemento
    {
      get
      {
        return _elemento;
      }
      set
      {
        _elemento = value;
        OnPropertyChanged("Elemento");
        IrAccion(_elemento);

      }
    }


    #region Propiedades
    public ObservableCollection<Persona> Personas { get; set; }
    public ICommand newPerson
    {
      get
      {
        return new RelayCommand(newPage);
      }
    }

    public ICommand deletePerson
    {
      get
      {
        return new RelayCommand(delPage);
      }

    }



    #endregion

    #region Constructor
    public MainViewModel()
    {
      GetPersons();
    }
    #endregion

    #region Metodos
    private async void IrAccion(Persona _elemento)
    {

      Application.Current.MainPage.Navigation.PushModalAsync(new Acciones(_elemento));
    }

    //---
    public void GetPersons()
    {
      Personas = new ObservableCollection<Persona>(
        SingletonRepository.Instancia.Repository.GetAll());
    }

    private void newPage()
    {
      Application.Current.MainPage.Navigation.PushAsync(new NewPage());
    }
    #endregion

    private void delPage()
    {
      Application.Current.MainPage.Navigation.PushAsync(new DelPage());
    }
  }


}
