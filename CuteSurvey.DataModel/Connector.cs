using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSharpy.Data;
using MySql.Data;
namespace CuteSurvey.Data
{
   
    public class MYSQLConnect : TechSharpy.Data.Connection.MySQL 
    {
        MySql.Data.MySqlClient.MySqlConnection Connection;
        private string _conn;

        public MYSQLConnect(string conn) {
            _conn = conn;
        }

        public new MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            if (Connection == null)
            {
                try
                {                                  
                    Connection = new MySql.Data.MySqlClient.MySqlConnection(getConnectionstring());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Connection;
        }   

        public override string getConnectionstring()
        {
            return _conn;
        }


        public override bool TestConnection()
        {
            throw new NotImplementedException();
        }

        
    }       

}
