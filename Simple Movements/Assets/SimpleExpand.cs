using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleExpand : MonoBehaviour
{
    //This variable controls how fast the object scales
    public float scaleSpeed = 1f;

    //These variables set the maximum and minimum sizes for the object
    public float maxScale = 1.5f;
    public float minScale = 0.5f;

    // We need to keep track of the starting size of the object here
    private Vector3 originalScale;

    //this boolean checks wether we are making the object bigger or smaller
    private bool scalingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        //Save the starting scale for the object.
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (scalingUp)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

            if (transform.localScale.x >= originalScale.x * maxScale)
            { 
                scalingUp = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;

            if (transform.localScale.x <= originalScale.x * minScale)
            {
                scalingUp = true;
            }
        }

    }
}
