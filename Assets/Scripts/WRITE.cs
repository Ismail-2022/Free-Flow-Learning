using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using UnityEngine.SocialPlatforms.Impl;

public class WRITE : MonoBehaviour
{
   // public Text name;               //<<<<<<<<<<<<<<<< if we want to display name then we will do this otherwise use local
    ///                variable like name=userinfo.Username den run query 
    /// </summary>
    //public Text subject;
    
    private string username;/// <summary>
    /// </summary>
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

        // Get the score and username variables from your scene or wherever they are stored
        int score = UserInfo.score;//10
        username = UserInfo.Username;// "talha"
        Debug.Log("score from db:  !!!!!!" + score+" : "+username);
        string subject = "Chemistry";
        // Insert the score and username into the leader_board table
        MySqlCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = $"INSERT INTO leader_board (name, score, subject) VALUES ('{username}', {score}, '{subject}')";

        try
        {
            dbCommand.ExecuteNonQuery();
            Debug.Log("Data inserted successfully");
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

    // Method to get the score from your scene or wherever it is stored
    //private int GetScoreFromScene()
    //{
    //    // Replace this with your actual implementation to retrieve the score
    //    int score = 100;
    //    return score;
    //}

    //// Method to get the username from your scene or wherever it is stored
    //private string GetUsernameFromScene()
    //{
    //    // Replace this with your actual implementation to retrieve the username
    //    string username = "Player1";
    //    return username;
    //}
}