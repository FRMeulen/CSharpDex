#region Namespaces
using System;
using System.Data;
using MySql.Data.MySqlClient;
#endregion

namespace CSharpDex.Data
{
    /// <summary>
    /// Singleton dex connector.
    /// Handles queries to the database and returns data.
    /// </summary>
    public sealed class DexConnector
    {
        /// Lazily defined singleton instance.
        private static readonly Lazy<DexConnector> lazy = new Lazy<DexConnector>(() => new DexConnector());

        /// Instance getter.
        public static DexConnector Instance { get { return lazy.Value; } }

        /// Private members.
        private readonly string connstring = @"server=localhost;userid=dex;password=CSharpDex;database=dex_database";
        private MySqlConnection conn = null;


        /// Constructor.
        private DexConnector()
        {

        }

        /// Private methods.
        private bool OpenConnection()
        {
            // Try to create and open connection.
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();
                return true;
            }

            // Catch failures.
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                return false;
            }
        }

        private void CloseConnection()
        {
            // Close connection if it still exists.
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        /// Public methods.
        public DataTable Query(string query, string targetTable)
        {
            // Cancel if connection cannot be opened.
            if (!OpenConnection()) return null;

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataSet set = new DataSet();
            adapter.Fill(set, targetTable);
            DataTable result = set.Tables[targetTable];

            // Close connection after querying.
            CloseConnection();

            return result;
        }
    }
}