using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Include the List class

public class YourScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float detectionRadius = 1.0f;

    private int received_bullets = 0;
    public GameObject cube;
    public TMPro.TextMeshPro points_text;

    private int points = 0;


    void Start()
    {
        //
        //points_text = GetComponent<TMP_Text>().Find("points_text");
        
        //points_text.text = "Points: "+ points.ToString();

    }

    void Update()
    {
        // Check for nearby bullet instances
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, detectionRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("Bullet")) // Assuming you have set a tag "Bullet" to your bulletPrefab instances
            {
                points = int.Parse(points_text.text);

                collider.gameObject.tag = "Bullet_to_delete";
                Debug.Log("Receive: Bullet is near!");
                // Change color when the bullet is near
                received_bullets +=1;
                //cube  = GameObject.Find("vehicle_cube");
                //cubeRenderer = cube.GetComponent<Renderer>();
                cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

                points +=1;
                points_text.text =  points.ToString();

                // Do something when the bullet is near, e.g., take damage, destroy the bullet, etc.
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the detection radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
