using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBTN_fire : MonoBehaviour
{
    public GameObject my_object;
    public VirtualButtonBehaviour vbtn_fire;
    public VirtualButtonBehaviour vbtn_left;
    public VirtualButtonBehaviour vbtn_right;
    
    public Material PressedMaterial;
    public Material originalMaterial;

    private bool my_object_active = false;
    private GameObject vuforiaButtonFire; // Reference to your Vuforia virtual button GameObject
    private GameObject vuforiaButtonLeft;
    private GameObject vuforiaButtonRight;



    // Start is called before the first frame update
    void Start()
    {
        //default
        my_object.SetActive(false);
        my_object_active = false;

        vbtn_fire.RegisterOnButtonPressed(OnButtonPressed);
        vbtn_fire.RegisterOnButtonReleased(OnButtonReleased);
        vuforiaButtonFire = vbtn_fire.gameObject;

        vbtn_left.RegisterOnButtonPressed(OnButtonPressed);
        vbtn_left.RegisterOnButtonReleased(OnButtonReleased);
        vuforiaButtonLeft = vbtn_left.gameObject;
        vbtn_left.enabled = false;

        vbtn_right.RegisterOnButtonPressed(OnButtonPressed);
        vbtn_right.RegisterOnButtonReleased(OnButtonReleased);
        vuforiaButtonRight = vbtn_right.gameObject;
        vbtn_right.enabled = false;


    }

    public void OnButtonPressed(VirtualButtonBehaviour Vb)
    {
        if (my_object_active)
        {
            if (Vb.VirtualButtonName == "vbtn_fire")
            {
                //Disparar

                Renderer buttonRenderer = vuforiaButtonFire.GetComponent<Renderer>();
                // Check if the button has a renderer
                if (buttonRenderer != null)
                {
                    // Assign the new material to the button renderer
                    buttonRenderer.material = PressedMaterial;
                }
                vbtn_right.enabled = true;
                vbtn_left.enabled = true;
            }

            else if (Vb.VirtualButtonName == "vbtn_left")
            {

                my_object.transform.Rotate(Vector3.up, 45f);
                Renderer buttonRenderer = vuforiaButtonLeft.GetComponent<Renderer>();
                // Check if the button has a renderer
                if (buttonRenderer != null)
                {
                    // Assign the new material to the button renderer
                    buttonRenderer.material = PressedMaterial;
                }
            }
            else if (Vb.VirtualButtonName == "vbtn_right")
            {

                my_object.transform.Rotate(Vector3.up, -45f);
                Renderer buttonRenderer = vuforiaButtonRight.GetComponent<Renderer>();
                // Check if the button has a renderer
                if (buttonRenderer != null)
                {
                    // Assign the new material to the button renderer
                    buttonRenderer.material = PressedMaterial;
                }
            }
        }
        else //Si la torreta no esta activa, solo el boton de Fire es util, y activa el objeto
        {
            if (Vb.VirtualButtonName == "vbtn_fire")
            {
                my_object.transform.parent.gameObject.SetActive(true);  //El object contiene la cabeza de la torreta, necesitamos ir al padre para activar todo el objeto
                my_object_active = true;
                
                Renderer buttonRenderer = vuforiaButtonFire.GetComponent<Renderer>();
                // Check if the button has a renderer
                if (buttonRenderer != null)
                {
                    // Assign the new material to the button renderer
                    buttonRenderer.material = PressedMaterial;
                }
            }
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour Vb)
    {

        if (Vb.VirtualButtonName == "vbtn_fire")
        {
            Renderer buttonRenderer = vuforiaButtonFire.GetComponent<Renderer>();
            // Check if the button has a renderer
            if (buttonRenderer != null)
            {
                // Assign the new material to the button renderer
                buttonRenderer.material = originalMaterial;
            }
        }

    }

}