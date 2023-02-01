using Firebase.Database.Query;
using Firebase.Storage;
using PasarSQLFirebase.Modelo;
using PasarSQLFirebase.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PasarSQLFirebase.VistasModelo
{
    public class VMusuarios
    {
        List<MUsuarios> Usuarios = new List<MUsuarios>();
        string rutaFoto;
        public async Task <List<MUsuarios>> mostrar_usuarios() {

            var data = await ConexionFirebase.firebase
                .Child("Usuarios")
                .OrderByKey()
                .OnceAsync<MUsuarios>();

            foreach(var dato in data)
            {
                MUsuarios parametros = new MUsuarios();
                parametros.Id_usuario = dato.Key;
                parametros.Usuario = dato.Object.Usuario;
                parametros.Pass = dato.Object.Pass;
                parametros.Icono = dato.Object.Icono;
                parametros.Estado = dato.Object.Estado;

                Usuarios.Add(parametros);

            }
            return Usuarios;
        }

        public async Task insertar_usuario(MUsuarios parametros)
        {
            await ConexionFirebase.firebase
                .Child("Usuarios")
                .PostAsync(new MUsuarios()
                {
                    Usuario = parametros.Usuario,
                    Pass = parametros.Pass,
                    Icono = parametros.Icono,
                    Estado = parametros.Estado,
                }
                );
        }

        public async Task<string> SubirIMagenesStorage(Stream ImagenStream,string Idusuario)
        {
            var dataAlmacenamiento = await new FirebaseStorage("usuarios-d6c94.appspot.com")
                .Child("Usuarios")
                .Child(Idusuario + ".jpg")
                .PutAsync(ImagenStream);
            rutaFoto = dataAlmacenamiento;
            return rutaFoto;
        }
    }
}
