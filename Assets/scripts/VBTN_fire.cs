using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBTN_fire : MonoBehaviour
{
    public GameObject vehicle;
    public VirtualButtonBehaviour Vb;

    // Start is called before the first frame update
    void Start()
    {
        vehicle.SetActive(false);

        Vb.RegisterOnButtonPressed(OnButtonPressed);
        Vb.RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vehicle.SetActive(true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        vehicle.SetActive(false);
    }
}
