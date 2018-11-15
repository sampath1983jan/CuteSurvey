using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSharpy.Data;
using TechSharpy.Data.ABS;
using CuteSurvey.Data;
namespace CuteSurvey.Data
{
   // public class Connectivity {
       public abstract class DataSource
        {
            protected DataBase rd;
            protected void Init(string conn)
            {
            rd = new DataBase();
            var c = new TechSharpy.Data.DataType.MySQL();            
            c.Connection = new MYSQLConnect(conn);
            rd.da = c;             
            }
        }



     
    // }

}
