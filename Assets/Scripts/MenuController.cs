using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    //public void LoadNextScreen()
    //{
    //    int currentSceneIndex = MenuController.GetActiveSceneIndex().buildIndex;
    //    SceneManager.LoadScene(CurrentSceneIndex + 1);
    //}
    
    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadPostStartScreen()
    {
        SceneManager.LoadScene("2. Login As");
    }
    public void LoadStudentLogin()
    {
        SceneManager.LoadScene("3.2 Student Login");
    }
    public void LoadAdminLogin()
    {
        SceneManager.LoadScene("3.1 Admin Login");
    }
    public void LoadLoginAs()
    {
        SceneManager.LoadScene("2. Login As");
    }

    public void LoadChemistry()
    {
        SceneManager.LoadScene("4.1 Chemistry");
    }

    public void LoadPhysics()
    {
        SceneManager.LoadScene("4.2 Physics");
    }

    public void LoadBiology()
    {
        SceneManager.LoadScene("4.3 Biology");
    }

    public void LoadBackScreen()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y-1);
    }
    public void LoadAdminSelect()
    {
        SceneManager.LoadScene("3.1.2 Admin Select");
    }
    public void LoadSubjects()
    {
        SceneManager.LoadScene("4. Subject");
    }
    public void LoadReport()
    {
        SceneManager.LoadScene("3.1.3 Report");
    }
}