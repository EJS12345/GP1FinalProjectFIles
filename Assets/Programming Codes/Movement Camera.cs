using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the speed of player movement
    public GameObject player; // Reference to the player object

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Move player left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector3.left;
        }

        // Move player right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector3.right;
        }

        // Move player up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += Vector3.up;
        }

        // Move player down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += Vector3.down;
        }

        // Apply the movement to the player
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        player.transform.Translate(movement);

        // Update the camera position to follow the player
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
    }
}



