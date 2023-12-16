using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class just_shoot : MonoBehaviour
{
    public GameObject myObject;
    public AudioClip shootSound;
    public AudioSource myAudioSource;
    public GameObject cube;

    public GameObject bulletPrefab;
    //public GameObject myObject;
    public TMPro.TextMeshPro textMenu;

    //public AudioClip shootSound;
    //private AudioSource audioSource;

    string btnName;
    float cooldown;

    //public Transform targetCube;
    private bool shooting =false;
    private float bulletSpeed = 2;
    private int k = 0;
    private bool verbose = true;
    private bool initial_update = false;

    // Start is called before the first frame update
    void Start()
    {
        //myAudioSource = GetComponent<AudioSource>();
        cooldown = 0.0f;

        //textMenu.text = GetComponent<Renderer>().enabled.ToString();
        //GetComponent<Renderer>().material.color = Random.ColorHSV();
        
        Debug.Log("just_shoot: start " + myObject.name.ToString());
        if (myObject.activeSelf == true){
            //cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            shooting = true;
            k=0;
            initial_update=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if ((myObject.activeSelf == true) and (!initial_update))
        if(myObject.activeSelf ==true && !initial_update){
            cube.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
            shooting = true;
            k=0;
            initial_update = true;
        }
            


        //textMenu.text = GetComponent<Renderer>().enabled.ToString();

        //if(gameObject.activeSelf ==true){
        if (shooting) // Adjust the input method as needed
        {   
            //Debug.Log("just_shoot: start " + myObject.name.ToString());
            
            if(verbose) Debug.Log("just_shoot: "+  myObject.name );

            //StartCoroutine(ShootBullets());
            StartCoroutine(StartShooting());
            shooting = false;    

            
        }

    }

    IEnumerator StartShooting()
    {

        List<Coroutine> coroutines = new List<Coroutine>();

        for (int i = 0; i < 1000; i++)
        {
            if (verbose) Debug.Log("Starting coroutine " + i);

            // Start a new coroutine and store its reference
            yield return new WaitForSeconds(2f);
            coroutines.Add(StartCoroutine(SpawnMoveAndDestroy2()));
            myAudioSource.PlayOneShot(shootSound);
        }

        // Wait for all coroutines to finish
        foreach (var coroutine in coroutines)
        {
            yield return coroutine;
        }
    }

    IEnumerator SpawnMoveAndDestroy2()
    {
    
        float time_life_bullet = 5f;
        float speed = 10f;
        // Instantiate the bulletPrefab at the position and rotation of myObject
        GameObject bulletInstance = Instantiate(bulletPrefab, myObject.transform.position + myObject.transform.forward * 3f, myObject.transform.rotation);
        //bulletInstance.tag("Bullet");
        // Get the rigidbody for movement
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();

        // Move the instantiated object for 2 seconds
        float elapsedTime = 0f;
        while (elapsedTime < time_life_bullet)
        {
            // Get the forward direction of the rotation of myObject
            Vector3 moveDirection = myObject.transform.forward;

            // Normalize the direction to ensure consistent speed
            moveDirection.Normalize();

            // Move the bulletInstance in the direction of myObject's forward
             // Adjust the speed as needed
            rb.velocity = moveDirection * speed;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            if(bulletInstance.tag == "Bullet_to_delete"){
                if (verbose) Debug.Log("Bullet: deleting " );
                Destroy(bulletInstance);
            }
            // Wait for the next frame
            yield return null;
        }

        // Stop the object's movement (set velocity to zero)
        rb.velocity = Vector3.zero;

        // Destroy the object after 2 seconds of movement
        Destroy(bulletInstance);
    }
}
