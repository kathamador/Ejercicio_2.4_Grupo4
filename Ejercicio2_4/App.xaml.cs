using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4
{
    public partial class App : Application
    {
        static DBProcess dBProcess;

        public static DBProcess Instancia
        {
            get
            {
                if(dBProcess == null)
                {
                    String dbname = "Proc.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    dBProcess = new DBProcess(dbfulp);
                }
                return dBProcess;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaFirmas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
