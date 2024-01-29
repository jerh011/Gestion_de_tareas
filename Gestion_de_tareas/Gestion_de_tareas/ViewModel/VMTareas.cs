using Gestion_de_tareas.Datos;
using Gestion_de_tareas.Model;
using Gestion_de_tareas.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gestion_de_tareas.ViewModel
{
    public class VMTareas : BaseViewModel
    {
        #region VARIABLES


        // ObservableCollection<Mpokemon> _Listapokemon;//tiempo real 
        List<MLista> _ListaTarea;// este no sirve para el tiempo real
        #endregion
        #region Contructor
        public VMTareas(INavigation navigation, string _estados)
        {
            Navigation = navigation;
            Mostrar(_estados);
        }
        #endregion
        #region Objetivo;

        public List<MLista> Lista
        {
            get { return _ListaTarea; }
            set
            {
                SetValue(ref _ListaTarea, value);
                OnpropertyChanged();

            }
        }
        #endregion
        #region PROCESOS
        public async Task Mostrar(string _estados)
        {
            var funcion = new DListado();
            Lista = await funcion.MostrarEstados(_estados);
        }

        public async Task IrARegistro()
        {
            await Navigation.PushAsync(new Vregistro());
        }
        public async Task IrAListado()
        {
            await Navigation.PushAsync(new VListado());
        }

        public async Task IrAEstados(string Estados)
        {

            await Navigation.PushAsync(new VTareas(Estados));
        }
        /*  public async Task IraEditar(MDatos poquimon)
          {
              await Navigation.PushAsync(new Editarpokemon(poquimon));
          }
       */
        #endregion.

        #region COMANDOS
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand IrAListadocommand => new Command(async () => await IrAListado());
        public ICommand IrAEstadoscommand => new Command<string>(async (p) => await IrAEstados(p));
        //public ICommand IraEditarcommand => new Command<MDatos>(async (p) => await IraEditar(p));
        #endregion






    }
}