using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotate : MonoBehaviour
{
    public GameObject myObject;
    public AudioClip soundeff;
    public AudioSource myAudioSource;
    string btnName;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        cooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //Hasta aqui funciona, parece quer hay un problema con el rayo
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                Debug.Log("RayName: " + btnName);
                myAudioSource.clip = soundeff;
                switch (btnName)
                {
                    case "Right":
                        myAudioSource.Play();
                        myObject.transform.Rotate(Vector3.up, 15f);
                        cooldown = 0.25f;
                        break;
                    case "Left":
                        myAudioSource.Play();
                        myObject.transform.Rotate(Vector3.up, -15f);
                        cooldown = 0.25f;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
