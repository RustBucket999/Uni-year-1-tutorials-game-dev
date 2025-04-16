using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimpleRotation : MonoBehaviour
{
    // This variable will control how fast the object rotates
    public float rotationSpeed = 50f;
    // This will choose which axis to rotate around (x = 1, y = 2, z = 1)
    public Vector3 rotationAxis = Vector3.up;
    // Update is called once per frame
    void Update()
    {

        // Rotate the object around the chosen axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

    }
}
