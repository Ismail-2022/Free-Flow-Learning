using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class ElectronSnap : MonoBehaviour
{
    public GameObject shell; // Prefab of the electron GameObject
                             // private bool collided = false; // Flag to track collision
    public int KmaxElectrons;
    public int LmaxElectrons;
    private GameObject[] childs;
    private int KcurrentElectrons;
    private int LcurrentElectrons;
    private int McurrentElectrons;
    private void Start()
    {
        if (shell.name == "K")
        {
            KmaxElectrons = 2;

            //childs=shell.transform.GetComponentsInChildren<GameObject>().Where(child => child.CompareTag("Electron")).ToArray();
            //if (childs.Length == 2) 
            //{
            //    Collider collider = GetComponent<Collider>();
            //    if (collider != null)
            //    {
            //        collider.enabled = false;
            //    }

            //    // Disable the event system component to prevent interactions
            //    EventSystem eventSystem = GetComponent<EventSystem>();
            //    if (eventSystem != null)
            //    {
            //        eventSystem.enabled = false;
            //    }

            //}
        }
        if (shell.name == "L")
        {
            LmaxElectrons = 8;
        }
}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (shell.name=="K"&&KcurrentElectrons==KmaxElectrons)
    //    {
    //        Debug.Log("return K shell ");
    //        return;
    //    }
    //    if (shell.name == "L" && LcurrentElectrons == LmaxElectrons)
    //    {
    //        Debug.Log("return L shell ");
    //        return;
    //    }
    //    //shell 1
    //    if(shell.name =="K")
    //    {
    //        if (other.CompareTag("Electron"))
    //        {
    //            GameObject electron = other.gameObject;
    //            if (electron.transform.parent != shell.transform)
    //            {
    //                electron.transform.position = transform.position; // Set electron position to border's position
    //                electron.transform.SetParent(shell.transform);
    //                KcurrentElectrons++;
    //                Debug.Log("placing electron " + KcurrentElectrons);

    //            }

    //        }

    //    }
    //    //shell2
    //    if (shell.name == "L")
    //    {
    //        if (other.CompareTag("Electron"))
    //        {
    //            GameObject electron = other.gameObject;
    //            if (electron.transform.parent != shell.transform)
    //            {
    //                electron.transform.position = transform.position; // Set electron position to border's position
    //                electron.transform.SetParent(shell.transform);
    //                LcurrentElectrons++;
    //                Debug.Log("placing electron " + LcurrentElectrons);

    //            }

    //        }

    //    }
    //    //shell3
    //    if (shell.name == "M")
    //    {
    //        if (other.CompareTag("Electron"))
    //        {
    //            GameObject electron = other.gameObject;
    //            if (electron.transform.parent != shell.transform)
    //            {
    //                electron.transform.position = transform.position; // Set electron position to border's position
    //                electron.transform.SetParent(shell.transform);
    //                McurrentElectrons++;
    //                Debug.Log("placing electron " + McurrentElectrons);

    //            }

    //        }

    //    }

    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (shell.name == "K" && KcurrentElectrons == KmaxElectrons)
    //    {
    //        Debug.Log("Return K shell");
    //        return;
    //    }
    //    if (shell.name == "L" && LcurrentElectrons == LmaxElectrons)
    //    {
    //        Debug.Log("Return L shell");
    //        return;
    //    }

    //    if (other.CompareTag("Electron"))
    //    {
    //        GameObject electron = other.gameObject;
    //        if (electron.transform.parent ==null)
    //        {
    //            electron.transform.position = shell.transform.position; // Set electron position to shell's position
    //            electron.transform.SetParent(shell.transform);

    //            if (shell.name == "K")
    //            {
    //                KcurrentElectrons++;
    //                Debug.Log("Placing electron " + KcurrentElectrons + " in K shell");
    //            }
    //            else if (shell.name == "L")
    //            {
    //                LcurrentElectrons++;
    //                Debug.Log("Placing electron " + LcurrentElectrons + " in L shell");
    //            }
    //            else if (shell.name == "M")
    //            {
    //                McurrentElectrons++;
    //                Debug.Log("Placing electron " + McurrentElectrons + " in M shell");
    //            }
    //        }
    //    }
    //}
    //// 3rd 
    ///
    private void OnTriggerEnter(Collider other)
    {
        if (shell.name == "K" && KcurrentElectrons == KmaxElectrons)
        {
            Debug.Log("Return K shell");
            return;
        }
        if (shell.name == "L" && LcurrentElectrons == LmaxElectrons)
        {
            Debug.Log("Return L shell");
            return;
        }

        if (other.CompareTag("Electron"))
        {
            GameObject electron = other.gameObject;
            if (electron.transform.parent == null)
            {
                Vector3 snapPosition = shell.transform.position; // Reference position within the shell

                electron.transform.SetParent(shell.transform);
                electron.transform.localPosition = snapPosition; // Set electron's local position relative to the shell

                if (shell.name == "K")
                {
                    KcurrentElectrons++;
                    Debug.Log("Placing electron " + KcurrentElectrons + " in K shell");
                }
                else if (shell.name == "L")
                {
                    LcurrentElectrons++;
                    Debug.Log("Placing electron " + LcurrentElectrons + " in L shell");
                }
                else if (shell.name == "M")
                {
                    McurrentElectrons++;
                    Debug.Log("Placing electron " + McurrentElectrons + " in M shell");
                }
            }
        }
    }

}
