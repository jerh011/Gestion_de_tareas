using Firebase.Database.Query;
using Gestion_de_tareas.Conexion;
using Gestion_de_tareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_tareas.Datos
{
    public class DListado
    {
        public async Task InsertarTarea(MLista parametros)
        {
            await Cconexion.firebase.Child("Tareas").PostAsync(new MLista
            {
                Descripcion = parametros.Descripcion,
                Estado = parametros.Estado,
                FechaInicio = parametros.FechaInicio,
                FechaFinal = parametros.FechaFinal
               

            });

        }
       
        public async Task<List<MLista>> Mostrar()
        {
            return (await Cconexion.firebase.Child("Tareas")
                    .OnceAsync<MLista>())
                    .Select(item => new MLista
                    {
                        IdTarea = item.Key,
                        Descripcion = item.Object.Descripcion,
                        Estado = item.Object.Estado,
                        FechaInicio = item.Object.FechaInicio,
                        FechaFinal = item.Object.FechaFinal
                        
                    }).ToList();
        }

        public async Task<List<MLista>> MostrarEstados(string _Estado)
        {
            return (await Cconexion.firebase.Child("Tareas")
                    .OnceAsync<MLista>())
                    .Select(item => new MLista
                    {
                        IdTarea = item.Key,
                        Descripcion = item.Object.Descripcion,
                        Estado = item.Object.Estado,
                        FechaInicio = item.Object.FechaInicio,
                        FechaFinal = item.Object.FechaFinal

                    }).Where(tarea => tarea.Estado == _Estado)
                      .ToList();
        }





        public async Task Eliminarpokemon(MLista mLista)
        {
            string id = mLista.IdTarea;
            await Cconexion.firebase.Child("Tareas").Child(id).DeleteAsync();
        }

        public async Task Actualizar(MLista parametros)
        {
            await Cconexion.firebase.Child("Tareas").Child(parametros.IdTarea).PutAsync(new MLista
            {
                Descripcion = parametros.Descripcion,
                Estado = parametros.Estado,
                FechaInicio = parametros.FechaInicio,
                FechaFinal = parametros.FechaFinal


            });

        }

    }
}