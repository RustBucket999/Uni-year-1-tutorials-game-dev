using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public GameObject playerPrefab;  // Reference to the player prefab
    public Transform respawnPoint;   // The respawn point in the scene

    private GameObject currentPlayer;  // Track the current player instance
    private bool isRespawning = false; // Flag to prevent multiple respawns

    public void RespawnPlayer()
    {
        if (isRespawning)
        {
            Debug.LogWarning("Respawn already in progress, ignoring duplicate call.");
            return;
        }

        Debug.Log("Respawn initiated.");
        StartCoroutine(RespawnWithDelay(2f)); // Start coroutine with 2-second delay
    }

    private IEnumerator RespawnWithDelay(float delay)
    {
        isRespawning = true;
        Debug.Log("Respawn delay started.");

        if (currentPlayer != null)
        {
            Debug.Log($"Destroying old player: {currentPlayer.name}");
            Destroy(currentPlayer.gameObject);
            currentPlayer = null; // Ensure no reference remains
            yield return new WaitForSeconds(0.1f); // Ensure destruction completes
            Resources.UnloadUnusedAssets(); // Forces cleanup
        }

        yield return new WaitForSeconds(delay);

        if (playerPrefab != null && respawnPoint != null)
        {
            Debug.Log("Spawning new player.");
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);

            // Set the RespawnManager reference in the new player
            PlayerController playerController = currentPlayer.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.respawnManager = this;
            }

            Rigidbody2D newRigidbody = currentPlayer.GetComponent<Rigidbody2D>();
            if (newRigidbody != null)
            {
                newRigidbody.velocity = Vector2.zero;
                newRigidbody.WakeUp();
            }

            currentPlayer.SetActive(true);
        }
        else
        {
            Debug.LogError("Player prefab or respawn point is not assigned!");
        }

        isRespawning = false;
        Debug.Log("Respawn completed.");
        SoundManager.Instance.PlaySound("Spawn"); // Ensure this matches your sound name

    }
}