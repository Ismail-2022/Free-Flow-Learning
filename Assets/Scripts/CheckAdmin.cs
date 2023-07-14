using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAdmin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        if (UserInfo.Username == "Admin")
        {
            gameObject.SetActive(true);
        }
    }
}
