using PasarSQLFirebase.Modelo;
using PasarSQLFirebase.VistasModelo;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasarSQLFirebase.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuarios : ContentPage
    {
        public Usuarios()
        {
            InitializeComponent();
            _ = mostrarUsuarios();
        }
        MediaFile file;

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            await InsertarUsuarios();
        }

        private async Task InsertarUsuarios()
        {
            VMusuarios function = new VMusuarios();
            MUsuarios parametros = new MUsuarios();
            parametros.Usuario = txtusuario.Text;
            parametros.Pass = txtcontrasenia.Text;
            parametros.Icono = "-";
            parametros.Estado = "-";

            await function.insertar_usuario(parametros);
            await DisplayAlert("Listo", "Usuario agregado", "OK");
            await mostrarUsuarios();
        }


        private async Task mostrarUsuarios()
        {
            VMusuarios function = new VMusuarios();
            var data = await function.mostrar_usuarios();
            listaUsuarios.ItemsSource = data;
        }

        private async void btnagregarimagen_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                });
                if (file==null)
                {
                    return;
                } else
                {
                    imagenCelular.Source = ImageSource.FromStream(() =>
                    {
                        var rutaImagen = file.GetStream();
                        return rutaImagen;
                    });
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
    }
}