using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherController : MonoBehaviour
{

    public GameObject rocketPrefab;
    public Transform firePoint;
    public float rocketSpeed = 50f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Aim()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void Shoot()
    {
        
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rocketB = rocket.GetComponent<Rigidbody2D>();

        if (rocketB != null)
        {
            rocketB.velocity = firePoint.right * rocketSpeed;
        }
        
    }
}
