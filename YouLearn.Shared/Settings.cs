using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Shared
{
    public static class Settings
    {
        private static string connectionString = "Data Source=.;Initial Catalog=YouLearnCurso; persist security info=True;Integrated Security=SSPI;";

        public static string ConnectionString
        {
            get { return connectionString; }set { connectionString = value; }
        }
    }
}
