using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using Oculus.Platform.Models;
using System.Data.Common;
using System.Collections.Generic;
using UnityEditor.Search;
using System.Linq;

public class ReportButton : MonoBehaviour
{
    public GameObject buttons;
    // Start is called before the first frame update
    public float yoffset = 2f;

    public Text displayText; // Reference to the Text component on the Canvas
    int count = 0;
    public string connectionString;
    private MySqlConnection dbConnection;

    public string server = "localhost";
    public string database = "database";
    public string username = "root";
    public string password = "";
    private string name_listStr; // hold names list for buttons.text

    void Start()
    {
        connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

        // Open the database connection
        dbConnection = new MySqlConnection(connectionString);

        // Open the database connection
        dbConnection = new MySqlConnection(connectionString);
        MySqlCommand dbCommand = dbConnection.CreateCommand();

        try
        {
            dbConnection.Open();
            Debug.Log("Database connection successful ___start function");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database connection error: " + ex.Message);
            return;
        }

        string sqlQuery = dbCommand.CommandText = "SELECT DISTINCT name AS unique_names FROM leader_board";

        //function that outputs the total number of unique name entries
        int uniqueNamesCount = CountUniqueNames();
        //Debug.Log("Number of unique names: " + uniqueNamesCount);
        ///////

        dbCommand.CommandText = sqlQuery;
        try
        {
            MySqlDataReader reader = dbCommand.ExecuteReader();
            List<string>namelist = new List<string>();
            while (reader.Read())
            {
                string name = reader.GetString("unique_names");
                namelist.Add(name);
                
            }
            reader.Close();
            name_listStr = string.Join(".", namelist);
            //Debug.Log("Unique NAMES " + name_listStr+ "index 0" + name_listStr[0]);

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
        /////////////
        string[] names = name_listStr.Split('.'); //stores all names
           
        Button originalButton = GetComponentInChildren<Button>(); // Get the Button component from the child GameObject
        Text OrgBtnText = originalButton.GetComponentInChildren<Text>();
        OrgBtnText.text= names[0];                                  //setting orginal button text
        //originalButton.AddComponent<ReportPrompt>();
        int y = 1;
        //dynamic creation of buttons 
        for (int i = 0; i < uniqueNamesCount - 1; i++,y++)
        {
            // a = -(2 / i);
            Vector3 newPosition = transform.position + new Vector3(0f, -i, 0f);
            Button newButton = Instantiate(originalButton, newPosition, Quaternion.identity, transform);
            // Optionally, you can modify other properties of the new button here
            Text buttonText = newButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                //string[] names = name_listStr.Split('.');
                if (i < names.Count())
                {
                    buttonText.text = names[y];
                }
            }
        }
    }

    int CountUniqueNames()
    {
        int count = 0;
        
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
            return 0;
        }

        MySqlCommand dbCommand = dbConnection.CreateCommand();
        //string query = "SELECT COUNT(DISTINCT name) AS unique_names_count FROM leader_board WHERE subject = 'Chemistry' GROUP BY name";
        string query = "SELECT COUNT(DISTINCT name) AS unique_names_count FROM leader_board WHERE subject = 'Chemistry'";
        dbCommand.CommandText = query;
        try 
        {
            MySqlDataReader reader = dbCommand.ExecuteReader();
            while(reader.Read())
            {
                count = reader.GetInt32("unique_names_count");
            }
            reader.Close();

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

        return count;
    }
}

