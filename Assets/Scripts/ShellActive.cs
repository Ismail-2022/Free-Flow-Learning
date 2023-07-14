using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting;

public class ShellActive : MonoBehaviour
{
    
    public GameObject FirstShell;  // K
    public GameObject SecondShell; // L
    public GameObject ThirdShell;//M

    public GameObject ring2;//L shell
    public GameObject ring3; // M shell

    private GameObject[] childs1;
    private GameObject[] childs2;
    //private GameObject[] childs3;


    // count vars
    //private int count1;
    //private int count2;
    //private int count3;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //childs1 = FirstShell.transform.GetComponentsInChildren<GameObject>().Where(child => child.CompareTag("Electron")).ToArray();
        //Debug.Log("child1 length: " + childs1.Length);
        if (FirstShell.transform.childCount == 14 )//*childs1.Length==2 ) // as onechild is border
        {
            SecondShell.SetActive(true);
            ring2.SetActive(true);
        }
        //second shell active so first shell should be uninteractable 
        //if (SecondShell.activeSelf)
        //{
        //    // DisableGameObject(FirstShell);
        //}
       // childs2 = SecondShell.transform.GetComponentsInChildren<GameObject>().Where(child => child.CompareTag("Electron")).ToArray();
       

        if(SecondShell.transform.childCount == 30/*childs2.Length==8*/) //  as onechild is border
        {
            ThirdShell.SetActive(true);
            ring2.SetActive(true);
        }
        //Second shell disable 
        //if (ThirdShell.activeSelf)
        //{
        //    //DisableGameObject(SecondShell);
        //}
        
    }
    void  DisableGameObject(GameObject go)
    {
        Collider collider = go.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Disable the event system component to prevent interactions
        EventSystem eventSystem = go.GetComponent<EventSystem>();
        if (eventSystem != null)
        {
            eventSystem.enabled = false;
        }
    }
}
