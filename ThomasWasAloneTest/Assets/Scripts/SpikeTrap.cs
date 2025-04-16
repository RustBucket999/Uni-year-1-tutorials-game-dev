using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public RespawnManager respawnManager;  // Reference to the RespawnManager

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player (you can use tags or other checks as needed)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Optionally, play death animation or sound here

            // Disable the player (for respawn, you can also destroy the player)
            collision.gameObject.SetActive(false);

            // Call the RespawnManager to respawn the player
            respawnManager.RespawnPlayer();
        }
    }
}
