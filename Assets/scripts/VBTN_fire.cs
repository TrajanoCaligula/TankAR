using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBTN_fire : MonoBehaviour
{
    public GameObject my_object;
    public VirtualButtonBehaviour vbtn_fire;
    public bool my_object_active;

    // Start is called before the first frame update
    void Start()
    {
        my_object.transform.parent.gameObject.SetActive(false);
        my_object_active = false;

        vbtn_fire.RegisterOnButtonPressed(OnButtonPressed);
        vbtn_fire.RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        my_object_active = !my_object_active;
        my_object.transform.parent.gameObject.SetActive(my_object_active);

        my_object.transform.Rotate(Vector3.up, 20f);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }
}
