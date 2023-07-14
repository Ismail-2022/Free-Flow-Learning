using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class ElementChecker : MonoBehaviour
{
    // The current location of the element
    private Vector3 currentLocation;

    // The spawn location of the element
    public Transform spawnLocation;

    // The placement threshold for the element
    public float placementThreshold = 0.1f;

    // The material used to display the element
    private Material elementMaterial;

    // The amount of time to glow the element
    public float glowTime = 2f;

    void Start()
    {
        // Store the current location of the element
        currentLocation = transform.position;

        // Get the material of the element
        elementMaterial = GetComponent<Renderer>().material;
    }

    // Check if the element is in its spawn location
    public bool IsInSpawnLocation()
    {
        Debug.Log("element is placed!");
        return Vector3.Distance(transform.position, spawnLocation.position) < placementThreshold;
    }

    // Glow the element for the specified amount of time in the specified color
    private IEnumerator GlowElement(Color color)
    {
        // Store the original color of the element
        Color originalColor = elementMaterial.color;

        // Set the color of the element to the specified color
        elementMaterial.color = color;

        // Wait for the specified amount of time
        yield return new WaitForSeconds(glowTime);

        // Restore the original color of the element
        elementMaterial.color = originalColor;
    }

    // Move the element back to its current location
    public void ResetElementLocation()
    {
        transform.position = currentLocation;
    }

    // Move the element to its spawn location
    public void MoveToSpawnLocation()
    {
        transform.position = spawnLocation.position;
    }

    // Check if the element is in its spawn location and glow it in the appropriate color
    public void CheckPlacement()
    {
        // Check the distance between the element and the spawn point
        float distance = Vector3.Distance(transform.position, spawnLocation.position);

        // If the element is within the placement threshold of the spawn point
        if (distance < placementThreshold)
        {
            // Glow the element in green for 2 seconds
            StartCoroutine(GlowElement(Color.green));
        }
        else
        {
            // Glow the element in red for 2 seconds
            StartCoroutine(GlowElement(Color.red));

            // Move the element back to its current location
            ResetElementLocation();
        }
    }
}