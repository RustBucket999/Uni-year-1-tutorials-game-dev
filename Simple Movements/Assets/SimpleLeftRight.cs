using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLeftRight : MonoBehaviour
{
    // This variable controls how fast the object moves up and down
    public float moveSpeed = 1f;

    // This variable sets how high the object goes before coming back down
    public float movemount = 1f;

    // This is the starting position of the object
    private Vector3 startPosition;



    // Start is called before the first frame update
    void Start()
    {
        // Save the object;s starting position
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the ne X position using a sine wave for smooth movement
        float newX = startPosition.x + Mathf.Sin(Time.time * moveSpeed);
        // Set the object's position with the new X value, while keeping Y and Z the same
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}
