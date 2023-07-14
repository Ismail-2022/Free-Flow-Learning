using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
// just to store information about user                            
public class UserInfo : MonoBehaviour
{
    public static string Username;
    public static int score;
    public static List<int> totalScores = new List<int>();
}
