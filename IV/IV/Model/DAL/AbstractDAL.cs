using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IV.Model.DAL {
    public abstract class AbstractDAL {
        private static String _connectionString;

        static AbstractDAL() {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        protected static SqlConnection CreateConnection() {
            return new SqlConnection(_connectionString);
        }
    }
}