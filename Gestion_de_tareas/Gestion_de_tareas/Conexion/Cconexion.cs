using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace Gestion_de_tareas.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://gestion-de-tarea-default-rtdb.firebaseio.com/");
    }
}
