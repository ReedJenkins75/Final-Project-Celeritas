using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
    public string weaponName; // Name of the weapon for identification (optional)
    public bool isPickedUp = false; // Boolean to track whether the weapon is picked up

    // Reference to the player object (optional if you want to notify the player of pickup)
    public GameObject player;

    // This will be called when the player collides with the weapon
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pickup the weapon
            PickupWeapon();

            // Optionally, update player inventory (this can be a simple example)
            // You can also add this to an inventory system later
            // InventorySystem.AddWeaponToInventory(weaponName);
        }
    }

    // Function to handle weapon pickup
    void PickupWeapon()
    {
        if (!isPickedUp)
        {
            // Disable the weapon object, effectively making it disappear from the scene
            gameObject.SetActive(false);

            // Update the flag to indicate that the weapon has been picked up
            isPickedUp = true;

            // Optionally, notify the player about the pickup (can be an audio cue, UI update, etc.)
            Debug.Log("Weapon picked up: " + weaponName);
        }
    }
}