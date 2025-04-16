using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    private float speed;
    private int points = 1;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        GameManager.instance.AddScore(points);

        Destroy(gameObject);
    }
}
