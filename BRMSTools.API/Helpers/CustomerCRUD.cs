using BRMSTools.API.v1.Models;
using BRMSWebApp.Hubs;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BRMSTools.API.Helpers
{
    public static class CustomerCRUD
    {
        public static ResponseStatus updateScoreRecord(string customerSSN, int newScore, string connectionString)
        {
            // var tcs = new TaskCompletionSource<JObject>();

            Console.WriteLine($"Updating Customer Record with SSN {customerSSN} to new score {newScore}");

            string status = string.Empty;
            string errMsg = string.Empty;

            if(!CheckIfUserExists(connectionString, customerSSN))
            {
                return new ResponseStatus
                {
                    Msg = "User Not Found",
                    Status = "Ack",
                };
            }

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    const string tblName = "borrowers";
                    string sqlText = string.Empty;

                    sqlText  = "Update " + tblName + " ";
                    sqlText += "SET score = @newScore ";
                    sqlText += "where ssn = @customerSSN";

                    //open connection to db
                    cn.Open();

                    using (MySqlCommand sqlCmd = new MySqlCommand(sqlText, cn))
                    {
                        sqlCmd.Parameters.AddWithValue("@customerSSN", customerSSN);
                        sqlCmd.Parameters.AddWithValue("@newScore", newScore);

                        //execute
                        sqlCmd.ExecuteNonQuery();
                    }   //using SqlCommand
                }   //using SqlConnection

                status = $"Borrower with SSN: {customerSSN} updated score to the new value: {newScore}";
            }//try
            catch (MySqlException ex)
            {
                errMsg = "Error:: updateUserImage (" + customerSSN + "): " + ex.Message;
                errMsg += Environment.NewLine + Environment.NewLine;
                errMsg += "Connection String: " + Environment.NewLine + connectionString;
                status = errMsg;
            }//SqlException
            catch (Exception ex)
            {
                errMsg = "Error:: updateUserImage (" + customerSSN + "): " + ex.Message;
                errMsg += Environment.NewLine + Environment.NewLine;
                errMsg += "Connection String: " + Environment.NewLine + connectionString;
                status = errMsg;
            }//Exception

            if (string.IsNullOrEmpty(errMsg) && !string.IsNullOrEmpty(status)) // means no errors
            {
                UpdateAuditTable(connectionString, status, "Credit Bureau Score Update");
            }

            return new ResponseStatus
            {
                Msg = errMsg,
                Status = status,
            };

            // return tcs.Task;
        }

        private static void UpdateAuditTable(string connectionString, string msg, string eventSource)
        {
            MySqlConnection mySqlConnection = null;
            try
            {
                using (mySqlConnection = new MySqlConnection(connectionString))
                {
                    const string tblName = "events";
                    string sqlText = string.Empty;
                    string guid = Guid.NewGuid().ToString();

                    sqlText = $"INSERT into {tblName}(id, event, description) values(@guid, @eventSource, @msg);";

                    //open connection to db
                    mySqlConnection.Open();

                    using (MySqlCommand sqlCmd = new MySqlCommand(sqlText, mySqlConnection))
                    {
                        sqlCmd.Parameters.AddWithValue("@eventSource", eventSource);
                        sqlCmd.Parameters.AddWithValue("@msg", msg);
                        sqlCmd.Parameters.AddWithValue("@guid", guid);

                        //execute
                        sqlCmd.ExecuteNonQuery();
                    }   //using SqlCommand
                }   //using SqlConnection

            }//try
            catch (MySqlException ex)
            {
                // TODO: log the Exception(s)
            }//SqlException
            catch (Exception ex)
            {
                // TODO: log the Exception(s)
            }//Exception
            finally
            {
                new NotificationHelper().NotificationCaller(eventSource, msg);
                mySqlConnection.Close();
            }
        }

        public static ResponseStatus updateCrimeRecord(string customerSSN, int crimeId)
        {
            // var tcs = new TaskCompletionSource<JObject>();

            // TODO: Update database with the results

            string connectionString = Startup.StaticConfig.GetConnectionString("DbConnection");

            Console.WriteLine($"Updating Customer Record with SSN {customerSSN} to new crime id {crimeId}");

            string status = string.Empty;
            string errMsg = string.Empty;

            if (!CheckIfUserExists(connectionString, customerSSN))
            {
                return new ResponseStatus
                {
                    Msg = "User Not Found",
                    Status = "Ack",
                };
            }

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    const string tblName = "borrowers";
                    string sqlText = string.Empty;

                    sqlText = "Update " + tblName + " ";
                    sqlText += "SET crimeid = @newCrimeId ";
                    sqlText += "where ssn = @customerSSN";

                    //open connection to db
                    cn.Open();

                    using (MySqlCommand sqlCmd = new MySqlCommand(sqlText, cn))
                    {
                        sqlCmd.Parameters.AddWithValue("@customerSSN", customerSSN);
                        sqlCmd.Parameters.AddWithValue("@newCrimeId", crimeId);

                        //execute
                        sqlCmd.ExecuteNonQuery();
                    }   //using SqlCommand
                }   //using SqlConnection

                status = $"Borrower with SSN: {customerSSN} updated Crime Id to the new value: {crimeId}";
            }//try
            catch (MySqlException ex)
            {
                errMsg = "Error:: updateUserImage (" + customerSSN + "): " + ex.Message;
                errMsg += System.Environment.NewLine + System.Environment.NewLine;
                errMsg += "Connection String: " + System.Environment.NewLine + connectionString;
                status = errMsg;
            }//SqlException
            catch (Exception ex)
            {
                errMsg = "Error:: updateUserImage (" + customerSSN + "): " + ex.Message;
                errMsg += System.Environment.NewLine + System.Environment.NewLine;
                errMsg += "Connection String: " + System.Environment.NewLine + connectionString;
                status = errMsg;
            }//Exception

            if (string.IsNullOrEmpty(errMsg) && !string.IsNullOrEmpty(status)) // means no errors
            {
                UpdateAuditTable(connectionString, status, "Crime Bureau Update");
            }

            return new ResponseStatus
            {
                Msg = errMsg,
                Status = status,
            };

            // return tcs.Task;
        }

        private static bool CheckIfUserExists(string connectionString,string customerSSN)
        {
            bool returnFlag = false;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    const string tblName = "borrowers";
                    string sqlText = $"SELECT id FROM {tblName} where ssn = @customerSSN";

                    //open connection to db
                    cn.Open();

                    using (MySqlCommand sqlCmd = new MySqlCommand(sqlText, cn))
                    {
                        sqlCmd.Parameters.AddWithValue("@customerSSN", customerSSN);

                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = sqlCmd.ExecuteReader();
                        
                        DataTable dt = new DataTable();
                        dt.Load(dataReader);
                        
                        if( dt.Rows.Count > 0 )
                            returnFlag = true;

                        //close Data Reader
                        dataReader.Close();

                    }   // using SqlCommand

                    cn.Close();
                }   //using SqlConnection

            } //try
            catch (MySqlException ex)
            {
                Console.WriteLine("Error:: updateUserImage (" + customerSSN + "): " + ex.Message);
                Console.WriteLine("Connection String: " + System.Environment.NewLine + connectionString);
            } // SqlException
            catch (Exception ex)
            {
                Console.WriteLine("Error:: updateUserImage (" + customerSSN + "): " + ex.Message);
                Console.WriteLine("Connection String: " + System.Environment.NewLine + connectionString);
            } // Exception

            return returnFlag;
        }
    }
}
