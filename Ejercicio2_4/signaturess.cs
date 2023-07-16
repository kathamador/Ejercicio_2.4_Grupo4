using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace Ejercicio2_4
{
    public class signaturess
    {
        public int Id { get; set; }
        public string descripcion { get; set; }
        public byte[] firmadigital { get; set; }
        public ImageSource firmadigitalimagen
        {
            get
            {
                byte[] bytesImage = firmadigital;
                var stream = new MemoryStream(bytesImage);
                return ImageSource.FromStream(() => stream);


            }
        }
    }
}
