using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Checklist
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GetConnectionStringByName("MaConnexion");
             // Application.Run(new authentification());
            // Application.Run(new TestTreeview());
           // Application.Run(new testWord());
        }



        static string GetConnectionStringByName(string name)
        {

            string returnValue = null;

            // Recherchez le nom dans la section connectionStrings.

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MaConnexion"];

            //Si trouvé, retourne la chaîne de connexion et lance la forme.

            if (settings != null)
            {

                try
                {
                    returnValue = settings.ConnectionString;
                    Application.Run(new authentification());
                }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            }
            //Sinon retourne un Message d'erreur

            else
            {
                MessageBox.Show("veuillez créer un fichier de configuration");
            }

            return returnValue;
        }
    }
}
