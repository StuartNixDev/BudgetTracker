using System;
using System.Data.SqlClient;
using System.Configuration;


namespace BudgetTracker
{
    public static class Helper
    {

        public static string CnnVal(string name)

        {
            string output = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();
            return output;
        }
    }
}
