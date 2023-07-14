using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float proximityRadius = 0.2f;
    public GameObject cube;

    private bool cubeInRange = false;
    // private bool cubeCorrect = true;
    private Renderer cubeRenderer;
    public GameCustomManager CGM;
    public Transform destination;
    private Transform des_child;

    void Start()
    {
        // Get the renderer component from the cube game object
        cubeRenderer = cube.GetComponent<Renderer>();
        CGM = FindObjectOfType<GameCustomManager>();
        Debug.Log("selected_obj from start() in SP " + CGM + CGM.name);
        
    }

   
    void Update()
    {
        destination = CGM.transform.parent;
        //des_child = selected_Obj.chil;
        Debug.Log("Destination " + destination.name);
        // Check if the distance between the spawn point and the cube is within the proximity radius
        //float distance = Vector3.Distance(destination.transform.position, cube.transform.position);
        //if (distance <= proximityRadius)
        //{

        //    // Set the cubeInRange flag to true
        //    cubeInRange = true;
        //    // Change the color of the cube to green
        //    // if(cubeCorrect)
        //    cubeRenderer.material.color = Color.green;
        //}
        //else if (cubeInRange)
        //{
        //    // Set the cubeInRange flag to false
        //    cubeInRange = false;
        //    // Change the color of the cube back to its original color
        //    cubeRenderer.material.color = Color.white;
        //}
    }
}