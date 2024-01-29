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
    public class VMRegistro : BaseViewModel
    {
        ////////////////////////////
        #region Contructor
        public VMRegistro(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region VARIABLES
      
        string _Descripcion="";

        bool _EPendiente;
        bool _EEnProceso;
        bool _ERealizada;
        bool _Boton;

        bool _FechaAtrasada;

        DateTime _FechaInicio=DateTime.Today;
        DateTime _FechaFinal=DateTime.Today;
        #endregion
       
        #region Objetivo;
   
        
        public string Descripcion
        {
            get { return _Descripcion; }
            set { SetValue(ref _Descripcion, value); }
        }
        //Estados
        public bool EPendiente
        {
            get { return _EPendiente; }
            set { SetValue(ref _EPendiente, value); }
        }
      
        public bool EProceso
        {
            get { return _EEnProceso; }
            set { SetValue(ref _EEnProceso, value); }
        }
        public bool Button
        {
            get { return _Boton; }
            set { SetValue(ref _Boton, value); }
        }
        public bool ERealizada
        {
            get { return _ERealizada; }
            set { SetValue(ref _ERealizada, value); }
        }
        //
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { SetValue(ref _FechaInicio, value); }
        }
        public DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { SetValue(ref _FechaFinal, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var funcion = new DListado();//Coneccion con firebase
            var parametros = new MLista();//



            parametros.Descripcion = Descripcion;
            if (EPendiente == true || EProceso == true || ERealizada == true)
            {   if (EPendiente == true)
                    parametros.Estado = "Pendiente";
                else
            if (EProceso == true)
                    parametros.Estado = "En proceso";
                else
            if (ERealizada == true)
                    parametros.Estado = "Realizada";
            }
            else
                parametros.Estado = "Pendiente";

            parametros.FechaInicio = FechaInicio;
            parametros.FechaFinal = FechaFinal;
            
            await funcion.InsertarTarea(parametros);
            await Volver();
        }
        
         

        public async Task Volver()
        {
            await Navigation.PopAsync();
        }



        #endregion.
        
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());

        public ICommand Volvercommand => new Command(async () => await Volver());

        #endregion







        ///////////////////////////


    }
}