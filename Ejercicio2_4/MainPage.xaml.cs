using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Ejercicio2_4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnguardarFirma_Clicked(object sender, EventArgs e)
        {
            byte[] firmabyte = null;

            using (MemoryStream memory = new MemoryStream())
            {
                Stream image = await signatureSample.GetImageStreamAsync(SignatureImageFormat.Jpeg, Color.Black, fillColor:Color.White);
                image.CopyTo(memory);
                firmabyte = memory.ToArray();

                String Base64 = Convert.ToBase64String(firmabyte);
            }
            
            var firma = new signaturess
            {
                descripcion = descripcion.Text,
                firmadigital = firmabyte
            };

            if(await App.Instancia.Agregar(firma) > 0)
            {
                await DisplayAlert("Aviso", "Firma guardada exitosamente!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Aviso", "Error al guardar firma!", "OK");
            }

           
        }
    }
}
