using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine.Analytics;
using UnityEditor.Search;

public class ReportPrompt : MonoBehaviour
{
    public string connectionString;
    private MySqlConnection dbConnection;
    //private MySqlConnection dbCommand;

    public string server = "localhost";
    public string database = "database";
    public string username = "root";
    public string password = "";

    /// 2nd attempts  <summary>
    /// 2nd attempts 
    public Text displayText;  // Reference to the Text componen
    public ScrollRect scrollRect;
    //public WindowGraph graph;
    void Start()
    {
        //graph = gameObject.GetComponent<WindowGraph>(); //// checking here

        //connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

        //// Open the database connection
        //dbConnection = new MySqlConnection(connectionString);

        //// Open the database connection
        //dbConnection = new MySqlConnection(connectionString);
        //MySqlCommand dbCommand = dbConnection.CreateCommand();

    }
    void Update()
    {

        // Get the Content object from the Scroll View
        GameObject content = scrollRect.content.gameObject;

        // Assuming you have a reference to the parent object that contains the buttons
        //  GameObject buttonsParent = GameObject.Find("Content");

        // Get all the buttons in the parent object
        Button[] buttons = content.GetComponentsInChildren<Button>();
        //displayText.text = "usman";
        
        // Assign the button click event to a method for each button
        for (int i = 0; i < buttons.Length; i++) // bad me turn on krna h
        {
            //buttons[i].onClick.AddListener(() => UpdateDisplayText(buttons[i]));
            Button button = buttons[i];
            button.onClick.AddListener(() => UpdateDisplayText(button));

            
        }


    }

    //private List<string> FetchUniqueNames(MySqlConnection connection)
    //{
    //    List<string> uniqueNames = new List<string>();

    //    string sqlQuery = "SELECT DISTINCT name FROM leader_board";

    //    MySqlCommand dbCommand = connection.CreateCommand();
    //    dbCommand.CommandText = sqlQuery;

    //    try
    //    {
    //        MySqlDataReader reader = dbCommand.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            string name = reader.GetString("name");
    //            uniqueNames.Add(name);
    //        }

    //        reader.Close();
    //    }
    //    catch (MySqlException ex)
    //    {
    //        Debug.LogError("Database query error: " + ex.Message);
    //    }
    //    finally
    //    {
    //        dbCommand.Dispose();
    //    }

    //    return uniqueNames;
    //}

    void UpdateDisplayText(Button button)
    {
        // Get the text from the button and assign it to the Text component
        displayText.text = button.GetComponentInChildren<Text>().text;
       // MySqlCommand dbCommand = dbConnection.CreateCommand();
        Debug.Log("Function dislay text called !!");

        connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";

        // Open the database connection
        dbConnection = new MySqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            Debug.Log("Database connection successful in ReportPrompt in UpdateDisplayText ");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database connection error: in ReportPrompt in UpdateDisplayText " + ex.Message);
            return ;
        }
        MySqlCommand dbCommand = dbConnection.CreateCommand();
        string sqlQuery = $"SELECT score AS SUM FROM leader_board WHERE name = '{displayText.text}'";

        dbCommand.CommandText = sqlQuery;
        //reader 
        try
        {
            List<int>score = new List<int>();
            int temp; 
            MySqlDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                temp = reader.GetInt32("SUM");
                score.Add(temp);
                
                // Debug.Log("LOOOOOOOOOOOOOOOOOOOOOOOOOOL" + score.ToString());

            }
            reader.Close();
            UserInfo.totalScores = score;               ///
                                                        ///
            //graph.ShowGraph(score);
            string scoreString = string.Join(", ", score);
            Debug.Log("Scores: " + scoreString);

        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database query error in ReportPrompt in UpdateDisplayText : " + ex.Message);
        }
        finally
        {
            // Close the command and connection
            dbCommand.Dispose();
            dbConnection.Close();

        }

        //MySqlDataReader reader = dbCommand.ExecuteReader();
        //int count = reader.GetInt32("SUM");
        //Debug.Log("LOOOOOOOOOOOOOOOOOOOOOOOOOOL" + count);

    }

    //private string GetUniqueNamesText(List<string> names)
    //{
    //    return string.Join(", ", names);
    //}
}
