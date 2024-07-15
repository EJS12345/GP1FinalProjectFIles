using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Reference to the "You Win" Image
    public GameObject winImage;

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Display the "You Win" Image
            winImage.SetActive(true);
        }
    }
}

