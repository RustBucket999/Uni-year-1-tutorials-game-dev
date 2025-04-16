using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUpDown : MonoBehaviour
{
    // This variable controls how fast the object moves up and down
    public float moveSpeed = 1f;
    // This variable sets how high the object goes before coming back down 
    public float moveAmount = 1f;
    // This is the starting position of the object
    private Vector3 startPosition;



    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveAmount;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
