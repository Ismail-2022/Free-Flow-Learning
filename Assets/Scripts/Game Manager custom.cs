using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] elements;
    public GameObject[] selectedElements = new GameObject[5];

    void Start()
    {
        // Find all game objects with the "element" tag and store them in the elements array
        elements = GameObject.FindGameObjectsWithTag("element");

        // Randomly select 5 game objects from the elements array and store them in the selectedElements array
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, elements.Length);
            selectedElements[i] = elements[randomIndex];
        }
    }
}
