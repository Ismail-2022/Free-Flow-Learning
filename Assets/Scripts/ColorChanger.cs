using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer renderer;
    private Material originalMaterial;
    private Material greenMaterial;

    private bool isGreen = false;

    private void Start()
    {
        // Get the Renderer component attached to the GameObject
        renderer = GetComponent<Renderer>();

        // Store the original material of the GameObject
        originalMaterial = renderer.material;

        // Create a new material with green color
        greenMaterial = new Material(originalMaterial);
        greenMaterial.color = Color.green;
    }

    public void ChangeColorToGreen()
    {
        // Check if the GameObject is already green
        if (isGreen)
            return;

        // Set the material of the Renderer to the green material
        renderer.material = greenMaterial;

        // Set the flag to indicate that the GameObject is green
        isGreen = true;

        // Start a coroutine to change the color back to the original after 2 seconds
        StartCoroutine(ResetColor());
    }

    private IEnumerator ResetColor()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Set the material of the Renderer back to the original material
        renderer.material = originalMaterial;

        // Reset the flag
        isGreen = false;
    }
}
