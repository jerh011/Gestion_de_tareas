using Gestion_de_tareas.Datos;
using Gestion_de_tareas.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gestion_de_tareas.ViewModel
{
    public class VMEditarTareas : BaseViewModel
    {
        #region variables
        public MLista _mLista;
            public bool _EPendiente =false;
            public bool _EProceso = false;
            public bool _ERealizada = false;
           
            public string _descripcion;
            public DateTime _fechaInicio;
            public DateTime _fechaFinal;
        #endregion

        #region Contructor
        public VMEditarTareas(INavigation naivigation,MLista mlista)
        {
            Navigation = naivigation;
            _mLista = mlista;
      
        }
        #endregion

        #region Objetos
         public MLista Lista
         {
             get { return _mLista; }
             set { SetValue(ref _mLista, value); }
         }

        public bool EPendiente
        {
            get { return _EPendiente; }
            set { SetValue(ref _EPendiente, value); }
        }

        public bool EProceso
        {
            get { return _EProceso; }
            set { SetValue(ref _EProceso, value); }
        }

        public bool ERealizada
        {
            get { return _ERealizada; }
            set { SetValue(ref _ERealizada, value); }
        }


        public string Descripcion 
        {
            get { return Lista.Descripcion; }
            set { SetValue(ref _descripcion, value); }
        }

        public DateTime DateFechaInicio
        {
            get { return Lista.FechaInicio; }
            set { SetValue(ref _fechaInicio, value); }
        
        }

        public DateTime DateFechaFinal
        {
            get { return Lista.FechaFinal;}
            set { SetValue(ref _fechaFinal, value); }
        }



        #endregion

        #region Procesos
        public async Task Volver()
        { 
            await Navigation.PopAsync();
        }

        public async Task Actualizar()
        {
            var funcion = new DListado();//Coneccion con firebase
            var parametro = new MLista();

            parametro.IdTarea = Lista.IdTarea;
            parametro.Descripcion = Descripcion;

            if (EPendiente == true || EProceso == true || ERealizada == true)
            {
              if (EPendiente == true)
                    parametro.Estado = "Pendiente";
                else
            if (EProceso == true)
                    parametro.Estado = "En proceso";
                else
            if (ERealizada == true)
                    parametro.Estado = "Realizada";
            }
            else
                parametro.Estado = "Pendiente";

            parametro.FechaInicio= DateFechaInicio;
            parametro.FechaFinal= DateFechaFinal;

            await funcion.Actualizar(parametro);
            await Volver();
        }





        #endregion




        #region Comandos

        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ActualizarCommand => new Command(async () => await Actualizar());
        #endregion   


    }
}
