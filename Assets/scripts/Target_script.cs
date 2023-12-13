using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Target_script : MonoBehaviour
{
    public GameObject my_object;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (my_object.name == "Vehicle_v3" && !my_object.activeSelf)
        {
            my_object.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (my_object.name == "Vehicle_v1" && !my_object.activeSelf)
        {
            my_object.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void OnBecameVisible()
    {
        my_object.SetActive(true);
        
    }

    void OnBecameInvisible()
    {
        my_object.SetActive(false);
    }
}
