using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnpoint;
    /*Vector3 originalpos = GetComponent<Transform>;
    float pointx = spawnpoint.position.x;
    //public Transform SnapBack;
    private GameObject obj[];*/

    // Start is called before the first frame update
    void Start()
    {
        //SpawnBall();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Instantiate(ball, spawnpoint.position, Quaternion.identity);
    }
   
}
