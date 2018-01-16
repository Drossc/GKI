using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Unit-1 More namespaces.
using System.Configuration;

namespace GamesKnowledgeInterface2
{
    class Utility
    {
        //Get the connection string from App config file.
        internal static string GetConnectionString()
        {
            //Util-2 Assume failure.
            string returnValue = null;

            //Util-3 Look for the name in the connctionStrings section.
            ConnectionStringSettings settings = ConfiguartionManager.ConnectionString["VideoGame.Properties.Settings.connString"];

            //IF found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }
    }
}
