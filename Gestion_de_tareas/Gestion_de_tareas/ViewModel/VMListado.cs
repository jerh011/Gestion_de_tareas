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
    public class VMListado:BaseViewModel
    {
        #region VARIABLES


        // ObservableCollection<Mpokemon> _Listapokemon;//tiempo real 
        public List<MLista> _ListaTarea;// este no sirve para el tiempo real


        #endregion
        #region Contructor
        public VMListado(INavigation navigation)
        {
            Navigation = navigation;
            Mostrar();
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
        public async Task Mostrar()
        {
            var funcion = new DListado();
            Lista = await funcion.Mostrar();
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
        public async Task IraEditar(MLista editar)
        {
              await Navigation.PushAsync(new EditarTareas(editar));
        }
       
        #endregion.

        #region COMANDOS
        public ICommand IrARegistrocommand => new Command(async () => await IrARegistro());
        public ICommand IrAListadocommand => new Command(async () => await IrAListado());
        public ICommand IrAEstadoscommand => new Command<string>(async (p) => await IrAEstados(p));
        public ICommand IraEditarcommand => new Command<MLista>(async (p) => await IraEditar(p));
        #endregion






    }
}
