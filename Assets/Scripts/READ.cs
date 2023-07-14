using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using Oculus.Platform.Models;

public class READ : MonoBehaviour
{
    public Text displayText; // Reference to the Text component on the Canvas

    private string connectionString;
    private MySqlConnection dbConnection;

    void Start()
    {

        string server = "localhost";
        string database = "database";
        string username = "root";
        string password = "";

        connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

        // Open the database connection
        dbConnection = new MySqlConnection(connectionString);

        try
        {
            dbConnection.Open();
            Debug.Log("Database connection successful");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database connection error: " + ex.Message);
            return;
        }

        // Query the database
        MySqlCommand dbCommand = dbConnection.CreateCommand();
       // string parameterValue = "Your Text Parameter"; // Replace with the desired text parameter value
        string sqlQuery = "SELECT name,id, MAX(score) AS score FROM leader_board WHERE subject = 'Chemistry' GROUP BY name ORDER BY score DESC LIMIT 5";
        dbCommand.CommandText = sqlQuery;

        try
        {
            MySqlDataReader reader = dbCommand.ExecuteReader();

            // Create a string to store the retrieved data
            string displayString = "";

            // Iterate through the result set
            while (reader.Read())
            {
                string name = reader.GetString("name");
                int id=reader.GetInt32("id");
                int score = reader.GetInt32("score");

                // Append the retrieved data to the display string
                //displayString += "Name:" + name + ", Score: " + score + "\n";
                displayString += ""+id +"           "+ name + "         " + score + "      \n";
            }

            // Close the reader
            reader.Close();

            // Assign the display string to the Text component
            displayText.text = displayString;
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database query error: " + ex.Message);
        }
        finally
        {
            // Close the command and connection
            dbCommand.Dispose();
            dbConnection.Close();
        }
    }
}
    
    ///////////////////
    //dbCommand.CommandText = sqlQuery;

    //    try
    //    {

    //        MySqlDataReader reader = dbCommand.ExecuteReader();
    //        Debug.Log("TRYING TO WORK  !!!!!!!!!");
    //        // Create a string to store the retrieved data
    //        string displayString = "";

    //        // Iterate through the result set
    //        while (reader.Read())
    //        {
    //            string name = reader.GetString("name");
    //            int score = reader.GetInt32("score");
    //            string subject = reader.GetString("subject");

    //            // Append the retrieved data to the display string
    //            displayString += "Name: " + name + ", Score: " + score + ", Subject: " + subject + "\n";
    //        }

    //        // Close the reader
    //        reader.Close();

    //        // Assign the display string to the Text component
    //        displayText.text = displayString;
    //    }
    //    catch (MySqlException ex)
    //    {
    //        Debug.LogError("Database query error: " + ex.Message);
    //    }
    //    finally
    //    {
    //        // Close the command and connection
    //        dbCommand.Dispose();
    //        dbConnection.Close();
    //    }
    //}



    //First approach 
    /*
    private string connectionString;
    string query;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    private MySqlDataReader MS_Reader;
    public Text textCanvas;
    

    private void Start()
    {
        viewInfo();
    }
    public void viewInfo()
    {
        query = "SELECT * FROM database";
        // query="SELECT NAME,SCORE from LeaderBoard WHERE Subject ='Chemistry' ORDER BY Score DESC LIMIT 5"

        //connectionString = "Server = localhost; Database = database ; User = root; Password = ''; Charset = utf8;";
        //MS_Connection = new MySqlConnection(connectionString);
        //MS_Connection.Open();

        //MS_Command = new MySqlCommand(query, MS_Connection);

        //MS_Reader = MS_Command.ExecuteReader();

        //while (MS_Reader.Read())
        //{
            textCanvas.text += "ipoopsometimes" /*+ MS_Reader;*/
    //    textCanvas.text += "\n      " + MS_Reader[0] + "           " + MS_Reader[1] + "          " + MS_Reader[2] + "          ";
    //}
    //MS_Reader.Close();
    // }

    //public void connection()
    //{
    //    connectionString = "Server = example.com ; Database = DataBase ; User = userName; Password = ''; Charset = utf8";
    //    MS_Connection = new MySqlConnection(connectionString);

    //    MS_Connection.Open();
    //}

    //    SELECT name, score, subject
    //FROM your_table_name
    //WHERE subject = 'Chemistry'
    //ORDER BY score DESC
    //LIMIT 5; */

//}