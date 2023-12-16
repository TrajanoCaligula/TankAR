using UnityEngine;

public class set_plane : MonoBehaviour
{
    public GameObject objectToAlignWith; // Assign the second object in the Unity Editor

    public GameObject alignObject; 

    void Start()
    {
        // Ensure the second object is assigned
        if (objectToAlignWith == null)
        {
            Debug.LogError("Second object not assigned!");
            return;
        }

        // Align the objects to the same plane
        AlignToSamePlane();
    }

    void Update()
    {
        // Ensure the second object is assigned
        if (objectToAlignWith == null)
        {
            Debug.LogError("Second object not assigned!");
            return;
        }

        Vector3 currentPosition1 = transform.position;
        Vector3 currentPosition2 = objectToAlignWith.transform.position;

        if(currentPosition1.y  != currentPosition2.y){
            alignObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 1f);
            AlignToSamePlane();
        }

        // Align the objects to the same plane
        
    }

    void AlignToSamePlane()
    {
        // Get the current positions of the objects
        Vector3 currentPosition1 = transform.position;
        Vector3 currentPosition2 = objectToAlignWith.transform.position;

        // Calculate the difference in y positions
        float yOffset = -currentPosition1.y;

        // Adjust the positions to set y = 0
        transform.position = new Vector3(currentPosition1.x, currentPosition2.y, currentPosition1.z);
        //objectToAlignWith.transform.position = new Vector3(currentPosition2.x, 0f, currentPosition2.z);
    }
}