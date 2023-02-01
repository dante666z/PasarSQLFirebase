using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace PasarSQLFirebase.Servicios
{
    public class ConexionFirebase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://usuarios-d6c94-default-rtdb.firebaseio.com/");
    }
}
