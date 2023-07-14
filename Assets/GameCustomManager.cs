using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;

public class GameCustomManager : MonoBehaviour
{
    public GameObject[] elements;
    public GameObject[] selectedElements = new GameObject[5];
    public float proximityRadius = 0.25f;
    public Transform[] spawnPoints;  //public GameObject[] selectedElements;
    private bool CubeInRange = false;
    private Renderer render;
    //public Color glowColor;\
    public GlowEffect glowEffect; //cclass approch
    private HashSet<GameObject> glowingObjects = new HashSet<GameObject>();
    public GameObject WriteDb;// pass database manager here 
    
    //to check username 
    public Text UsersName;  //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<,
    ///
     //to check scoring
    private Scoring UserScore;
    int correctCount = 0;
    /// 
    ///
    private float startTime; // Start time of the game
   /* private bool gameEnded = false;*/ // Flag to indicate if the game has ended
    private bool flag_score = false;

    void Start()
    {
        UsersName.text = UserInfo.Username;  //           <<<    storing info 

        // Find all game objects with the "element" tag and store them in the elements array
        elements = GameObject.FindGameObjectsWithTag("elements");

        // Randomly select 5 game objects from the elements array and store them in the selectedElements array
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, elements.Length);
            selectedElements[i] = elements[randomIndex];
            // putting selected elements in grabbable layer so no other element can move
            selectedElements[i].layer = LayerMask.NameToLayer("grabbable");

            selectedElements[i].AddComponent<ColorChanger>();
        }
        UserScore = GetComponent<Scoring>();
        spawn();
        startTime = Time.time;
    }
    void Update()
    {
        //if (gameEnded)
        //    enabled = false;
            //return;

        foreach (GameObject selectedElement in selectedElements)
        {
            // Check if the selected element has a parent block
            if (selectedElement.transform.parent != null)
            {
                // Get the parent block
                GameObject parentBlock = selectedElement.transform.parent.gameObject;
                // Check if the selected element is within the proximity radius of the parent block
                float distance = Vector3.Distance(selectedElement.transform.position, parentBlock.transform.position);
                if (distance <= proximityRadius)
                {
                    CubeInRange = true;
                    // Snap the selected element to the position of the parent block
                    selectedElement.transform.position = parentBlock.transform.position;
                    selectedElement.transform.rotation = parentBlock.transform.rotation;
                    ////   
                    //AddGlowEffect(selectedElement, Color.green);
                    if (!glowingObjects.Contains(selectedElement))
                    {
                        ColorChanger colorChanger = selectedElement.GetComponent<ColorChanger>();
                        if (colorChanger != null)
                        {
                            //UserScore.AddScore(1);
                            colorChanger.ChangeColorToGreen();
                            glowingObjects.Add(selectedElement);
                            //UserScore.AddScore(1);
                            correctCount++;                                         // break case 
                        }
                    }  
                    
                }
               
            }
        }
        // stop mechanic need to be implemented here 
        if (correctCount == selectedElements.Length && flag_score == false)
        {
            // All elements have been correctly placed
            // Calculate the elapsed time
            float elapsedTime = Time.time - startTime;

            // Calculate the score based on the elapsed time
            int score = Mathf.RoundToInt(1000 / elapsedTime); // Adjust the formula according to your desired scoring system
            score = score + 45; 
            //// Add your stop mechanic code here
            Debug.Log("All elements have been placed correctly!");
            Debug.Log("Score: " + score);
            UserScore.AddScore(score);
            UserInfo.score = score;
            //gameEnded = true; // Set the gameEnded flag to prevent further updates
            WriteDb.AddComponent<WRITE>();
            flag_score= true;
        }

    }

    //by using class approach
    //public void AddGlowEffect(GameObject obj, Color glowColor)
    //{
    //    Renderer renderer = obj.GetComponent<Renderer>();
    //    if (renderer != null)
    //    {
    //        // Check if the glow effect has already been applied
    //        if (obj.GetComponent<GlowEffect>() == null)
    //        {
    //            // Create a new GlowEffect component and add it to the game object
    //            GlowEffect glowEffect = obj.AddComponent<GlowEffect>();
    //            glowEffect.glowMaterial.color = Color.green;
    //            glowEffect.ApplyGlowEffect();
    //        }
    //    }
    //}
    ///////////////////

    /// other method 
   /*
    public void AddGlowEffect(GameObject obj, Color glowColor)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Store the original material
            Material originalMaterial = renderer.material;

            // Create a new material with the specified glow color
            Material glowMaterial = new Material(originalMaterial);
            glowMaterial.color = Color.green;
            renderer.material = glowMaterial;

            // Start a coroutine to wait for 2 seconds before removing the glow effect
            StartCoroutine(RemoveGlowEffect(glowMaterial, originalMaterial, renderer));
        }
    }

    private IEnumerator RemoveGlowEffect(Material glowMaterial, Material originalMaterial, Renderer renderer)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Set the object's material back to the original material
        renderer.material = originalMaterial;
    }
   */
    void spawn()
    {

       
            // Loop through each selected element
            for (int i = 0; i < selectedElements.Length; i++)
            {
                // Get the transform position of the current spawn point
                Vector3 spawnPos = spawnPoints[i].position;

                // Set the position of the selected element to the spawn point position
                selectedElements[i].transform.position = spawnPos;

                //// If the selected element is one of the 5 selected elements, change its color to green
                //if (Array.IndexOf(elements, selectedElements[i]) != -1)
                //{
                //    Renderer renderer = selectedElements[i].GetComponent<Renderer>();
                //    renderer.material.color = Color.green;
                //}
            }
        


        /*
        // Loop through each spawn point
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Get a random index for the selectedElements array
          //  int randomIndex = Random.Range(0, selectedElements.Length);

            // Instantiate a random element at the current spawn point
            GameObject element = Instantiate(selectedElements[i], spawnPoints[i].position, Quaternion.identity);

            // Set the parent of the element to the current spawn point
            element.transform.parent = spawnPoints[i];
        }
        */


    }

}