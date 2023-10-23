using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BRodriguezControlEscolar"].ConnectionString.ToString(); //AQUI ES EL NOMBRE QUE SE LE PUSO A LA CONNECTION
                                                                                                                  //STRING EN EL WEB O APP CONFIG
        }
    }
}
