using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMouseKick : MonoBehaviour
{
    public GameObject objectToSend; // The object you want to send toward the mouse
    public float radius = 5f; // Radius within which the object can be sent
    public float launchSpeed = 5f; // Speed at which the object moves towards the mouse

    private void Update()
    {
        // Detect mouse click and check if the object is within the radius of the player
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Vector2 playerPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get mouse position in world space

            // Check if the object is within the radius (distance between player and object)
            if (Vector2.Distance(playerPosition, objectToSend.transform.position) <= radius)
            {
                // Send the object towards the mouse
                SendObjectTowardMouse(mousePosition);
            }
        }
    }

    // Function to launch the object towards the mouse
    private void SendObjectTowardMouse(Vector2 targetPosition)
    {
        // Calculate the direction towards the mouse
        Vector2 direction = (targetPosition - (Vector2)objectToSend.transform.position).normalized;

        // Set the velocity of the object to launch it
        Rigidbody2D rb = objectToSend.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * launchSpeed;
        }
    }
}