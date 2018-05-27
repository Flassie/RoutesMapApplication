using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesMapApplication
{
    public class DB
    {
        OleDbConnection connection = new OleDbConnection();
        UTMConverter converter = new UTMConverter(null);

        public DB() {}
        ~DB()
        {
            try
            {
                connection.Close();
            }
            catch (Exception) { }

            connection.Dispose();
        }

        public void Connect(String path, List<String> checkTables = null)
        {
            connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", path);
            connection.Open();

            if(checkTables != null)
            {
                var dt = connection.GetSchema("Tables");
                foreach(DataRow row in dt.Rows)
                {
                    var tableName = row.ItemArray[2].ToString();
                    checkTables.Remove(tableName);
                }
            }

            if(checkTables.Count > 0)
            {
                throw new InvalidOperationException("Tables that were not found: \n" + string.Join(",", checkTables.Select(m => m.ToString())));
            }

            connection.Close();
        }

        public void Open()
        {
            connection.Open();
        }


        public OleDbDataReader Execute(String query)
        {
            OleDbCommand cmd = new OleDbCommand(query, connection);
            return cmd.ExecuteReader();
        }
    }
}
