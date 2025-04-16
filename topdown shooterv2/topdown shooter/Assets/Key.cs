using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorManager doorManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Add this key to the door manager's collected keys
            doorManager.CollectKey(gameObject);

            SoundManager.Instance.PlaySound("Key"); // Ensure this matcches yoursound name
            SoundManager.Instance.PlaySound("Door");

            //Tell the doorManager to trigger the door animation
            doorManager.TriggerDoorAnimationForKey(gameObject);
            ///Destroy the key object after its collected
            Destroy(gameObject);
        }
    }
}
