using UnityEngine;

public class CloneOnRemove : MonoBehaviour
{
    public GameObject clonePrefab;  // The prefab to instantiate when the original is removed

    private GameObject clone;       // The instantiated clone
    private Vector3 originalPosition; // The original position of the GameObject

    private bool hasPositionChanged; // Flag indicating if the position has changed

    private void Start()
    {
        originalPosition = transform.position; // Store the original position of the GameObject
        hasPositionChanged = false; // Initially, position hasn't changed
    }

    private void Update()
    {
        // Check if the position has changed
        if (!hasPositionChanged && transform.position != originalPosition)
        {
            hasPositionChanged = true;
            // Position has changed, instantiate the clone at the new position
            clone = Instantiate(clonePrefab, transform.position, transform.rotation);
        }
    }

    private void OnDestroy()
    {
        // If the original is destroyed and position hasn't changed, instantiate the clone at the original position
        if (clone != null && hasPositionChanged)
        {
            Destroy(clone);
            //clone = Instantiate(clonePrefab, originalPosition, transform.rotation);
        }
    }
}
