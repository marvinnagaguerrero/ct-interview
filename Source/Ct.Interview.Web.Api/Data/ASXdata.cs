using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Ct.Interview.Web.Api.Data
{
    public static class ASXdata
    {
        public static SQLiteConnection DbContext = new SQLiteConnection();
        public static AsxListedCompany GetOrganisation(string asxcode)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=DATA\\ASX.sqlite;Version=3;");
            try
            {
                m_dbConnection.Open();
                SQLiteCommand command = m_dbConnection.CreateCommand();
                command.CommandText = "select * from Companies where  ASXcode = @asxcode LIMIT 1";
                command.Parameters.Add(new SQLiteParameter("@asxcode", asxcode));
                var reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read() && reader.HasRows)
                {
                    return new AsxListedCompany()
                    {
                        AsxCode = reader["AsxCode"].ToString(),
                        CompanyName = reader["CompanyName"].ToString(),
                        GicsIndustryGroup = reader["GICSindustrygroup"].ToString()
                    };
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                m_dbConnection.Close();
            }
            return null;
        }
    }
}

