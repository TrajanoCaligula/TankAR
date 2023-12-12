using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBTN_RotationL : MonoBehaviour
{
    public GameObject my_object;
    public VirtualButtonBehaviour vbtn;

    public Material PressedMaterial;
    public Material originalMaterial;

    private GameObject vuforiaButton;

    private bool rotate;



    // Start is called before the first frame update
    void Start()
    {
        //default

        vbtn.RegisterOnButtonPressed(OnButtonPressed);
        vbtn.RegisterOnButtonReleased(OnButtonReleased);

        vuforiaButton = vbtn.gameObject;

        rotate = false;

        my_object.SetActive(true);
        my_object.transform.parent.gameObject.SetActive(true);


    }

    void Update()
    {
        //Shoot
        if (rotate == true) //Left
        {
            my_object.transform.Rotate(Vector3.up, -5f);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour Vb)
    {
        rotate = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour Vb)
    {
        rotate = false;
    }
}