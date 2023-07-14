using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CheckChildTag : MonoBehaviour
{
    public GameObject K;
    public GameObject L;
    public GameObject M;
    //count
    private int elecK=0;
    private int elecL = 0;
    private int elecM = 0;

    //scoring
    private float startTime; //start time 
    private Scoring UserScore; //static class  

    private bool flag_score = false;// game end
    private void Start()
    {
        //CheckChildrenWithTag(K);
        //CheckChildrenWithTag(L);
        //CheckChildrenWithTag(M);
        startTime = Time.time;
        UserScore = GetComponent<Scoring>();
    }
    private void Update()
    {
        elecK = HasChildWithTag(K.transform, "Electron");
        elecL = HasChildWithTag(L.transform, "Electron");
        elecM = HasChildWithTag(M.transform, "Electron");
        // stoping implementation 
        if(elecK == 2&& elecL==8&&elecM==2&& flag_score==false) 
        {
            float elapsedTime = Time.time - startTime;

            // Calculate the score based on the elapsed time
            int score = Mathf.RoundToInt(1000 / elapsedTime); // 
            score = score + 45;

            Debug.Log("All elements have been placed correctly!");
            Debug.Log("Score: " + score);
            UserScore.AddScore(score);
            UserInfo.score = score;

            flag_score = true; // game ended
        }


    }
    //private int CheckChildrenWithTag(GameObject p)
    //{
    //    int count = 0;
    //    if (p == null)
    //    {
    //        Debug.LogError("Parent GameObject is null.");
    //        return 0;
    //    }

    //    // Check if the parent has a child with the tag "Electron"


    //    //if (HasChildWithTag(parent.transform, "Electron"))
    //    //{
    //    //    Debug.Log(parent.name + " has a child with the tag 'Electron'");
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log(parent.name + " does not have a child with the tag 'Electron'");
    //    //}

    //    count=HasChildWithTag(p.transform,"Electron");
    //    return count; 
    //}

    private int HasChildWithTag(Transform parent, string tag)
    {
        Debug.Log("Function hasChildWithTag Running !");
        int count = 0;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.CompareTag(tag))
            {
                count++;
               // return true;
            }
        }
        //return false;
        return count;
    }
}
